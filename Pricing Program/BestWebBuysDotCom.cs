
using System;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace Prager_Pricing_Program
{
    public class BestWebBuysDotCom  //  has no book info; prices are very good
    {

        Regex r;
        Match m;
        Regex r1;
        Match m1;
        string bookInfo;
        public decimal accumulatedPrice = 0.00M;
        static TraceSource traceSource = new TraceSource("prager");  //  for tracing mainForm

        public BestWebBuysDotCom()  //  constructor
        {
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    used for getting prices from the internet (click bLookupPrices)
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public bool getBookPrices(string ISBN) {
            //  9781449381653

            if (ISBN.Length == 10 || ISBN.Length == 13)
                bookInfo = readBookInfo(ISBN);
            else
                return false;
            bool rc = parseBookInfoForPricesAndVenues(bookInfo);
            return rc;  //  returns false if no data

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    goes to the website and scrapes the book information
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public string readBookInfo(string isbn) {

            Cursor.Current = Cursors.AppStarting;

            System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;

            Uri uri = new Uri("http://www.bestwebbuys.com/books/compare/isbn/" + isbn);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Referer = "http://www.moreprices.com/";

            request.KeepAlive = false;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = 0;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";

            string page = string.Empty;
            try {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
                page = readStream.ReadToEnd();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex) {
                if (ex.Message.Contains("Unable to read data from the transport connection"))
                    return "Unable to read data from the transport connection";
            }
            return (page);  //  next, page has to be parsed for prices and any errors
        }


        public string[,] priceAndVenue = new string[100, 3];
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    used for automatic pricing of books
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public bool parseBookInfoForPricesAndVenues(string bookInfo) {
            int ndx1 = 2;
            accumulatedPrice = 0.00M;

            for (int i = 0; i < 100; i++) {
                priceAndVenue[i, 0] = "";  //  price
                priceAndVenue[i, 1] = "";  //  venue
                priceAndVenue[i, 2] = "";  //  condition
            }

            //if (bookInfo.Contains("we did not find this book for sale"))
            //    return false;

            if (bookInfo.Contains("<h1>Error!</h1>") && bookInfo.Contains("Invalid 10 digit ISBN")) {
                priceAndVenue[0, 1] = "Invalid 10 digit ISBN";
                return true;
            }

            if (bookInfo.Contains("Server Error in '/' Application.") || bookInfo.Contains("server-error") || bookInfo.Contains("Bad Request (Invalid Hostname)") ||
                bookInfo.Contains("Unable to read data from the transport connection")) {
                MessageBox.Show("There is a problem with the server that gets book information.\n" +
                    "Please try again later.  We are sorry for the inconvenience.", "Prager Inventory Program",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //--    find list price
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //    <span class="metadata_heading">List Price:</span> $<span property="product:listPrice">64.99</span><br />
            r = new Regex("product:listPrice\">");  //  find starting point of List Price:
            m = r.Match(bookInfo, 0);
            if (m.Success) {
                r1 = new Regex("</span><br />");  //  find end of List Price:
                m1 = r1.Match(bookInfo, m.Index + 19);
                if (m.Success && m1.Success) {
                    priceAndVenue[0, 0] = bookInfo.Substring(m.Index + 19, m1.Index - (m.Index + 19));
                    priceAndVenue[0, 1] = "List Price: ";
                }
            }
            else {
                priceAndVenue[0, 0] = "n/a";
                priceAndVenue[0, 1] = "List Price: ";

            }


            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //--    find binding
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //  look for type (Hardcover, etc.)
            //  <span class="book_format">Hardcover</span>
            r = new Regex("<span class=\"book_format\">");  //  find starting point of book format
            m = r.Match(bookInfo, 0);
            if (m.Success) {
                r1 = new Regex("</span>");  //  find end of book format
                m1 = r1.Match(bookInfo, m.Index + 26, 20);
                if (m.Success && m1.Success) {
                    priceAndVenue[1, 2] = bookInfo.Substring(m.Index + 26, m1.Index - (m.Index + 26));
                    priceAndVenue[1, 1] = "Book Format: ";
                }
            }
            else {
                priceAndVenue[1, 0] = "n/a";
                priceAndVenue[1, 1] = "Book Format: ";

            }

            //    9781449381653
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //--    find selling prices
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            bool firstTime = true;

            do {
                r = new Regex("target=");  //  find starting point of selling prices

                if (firstTime) {
                    m = r.Match(bookInfo, m.Index + 26);    //  points to end of "book format"
                    firstTime = false;
                }
                else
                    m = r.Match(bookInfo, m1.Index);  //  points to end of last condition

                if (m.Success)  //  m.index+8 points to start of store name
                {
                    r1 = new Regex(" title=\"Click to");  //  find end of store name
                    m1 = r1.Match(bookInfo, m.Index);

                    string debuggingData = bookInfo.Substring(m.Index + 8, 50);
                    string debuggingData2 = bookInfo.Substring(m1.Index, 50);

                    if (m.Success && m1.Success)    //  save it...
                        priceAndVenue[ndx1, 1] = bookInfo.Substring(m.Index + 8, m1.Index - (m.Index + 9));  // move name of store

                    //  make sure we are not looking at a "rental"
                    if (bookInfo.Substring(m.Index + 8, 50).Contains("Click to RENT"))
                        continue;  //  skip it...

                    //  find beginning of price 
                    r = new Regex(@"(<td class=""center"">)\s*(\$\d+\.\d+)");
                    m = r.Match(bookInfo, m1.Index + 400, 150);  //  m1.Index  points to end of store name
                    debuggingData = bookInfo.Substring(m.Index, 50);
                    if (m.Success)  //  did we find price (m.Index + 23)?
                    {
                        r1 = new Regex("<span class=\"tiny\">");  //  now, find end of price
                        m1 = r1.Match(bookInfo, m.Index + 20, 36);  //  m.Index points to beginning of price
                        debuggingData = bookInfo.Substring(m.Index + 20, 36);
                        decimal tempPrice = 0;
                        if (m.Success && m1.Success) {
                            priceAndVenue[ndx1++, 0] = bookInfo.Substring(m.Index + 20, m1.Index - (m.Index + 20)).Trim();
                            //  debuggingData = bookInfo.Substring(m.Index + 36, m1.Index - (m.Index + 36)).Trim();
                            tempPrice = decimal.Parse(bookInfo.Substring(m.Index + 21, m1.Index - (m.Index + 21)).Trim());
                            accumulatedPrice += tempPrice;

                            //  find new or used...
                            debuggingData = bookInfo.Substring(m.Index + 20, 70);
                            r = new Regex("<span class=\"glossary_term\">");
                            m = r.Match(bookInfo, m.Index + 28, 70);  //  look at the first 50 characters
                            if (m.Success)  //  did we find it?
                            {
                                //  find the end
                                r1 = new Regex("</span>");
                                m1 = r1.Match(bookInfo, m.Index + 28, 20);  //  m1.Index will point to end of condition
                                if (m1.Success) {
                                    //      debuggingData = bookInfo.Substring(m.Index + 28, m1.Index - (m.Index + 28));
                                    priceAndVenue[ndx1 - 1, 2] = bookInfo.Substring(m.Index + 28, m1.Index - (m.Index + 28));
                                }
                            }
                        }
                    }
                }
            } while ((m1.Index + 4000) < bookInfo.Length - 4000);

            return true;
        }
    }
}
