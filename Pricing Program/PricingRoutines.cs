using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;



//------------    static keys for uploads    -----------------
//  Developer: MWS Access Key ID:  AKIAIZEE34BK5NOX5SDA
//             Secret Key: 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

//----------    my MWS keys for uploading files    -------------
//  Seller:  Merchant ID: A20V78MULJSCYR
//           Marketplace ID: ATVPDKIKX0DER

namespace BookInfo
{

    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //--  PricingRoutines
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class PricingRoutines
    {

        public int ndx1 = 0;  //  indicates how many prices there were 

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ 
        public class PricingData
        {
            public string venueName;
            public string price;
            public char bookCondn;
        }

        public class BookData
        {
            public string ISBN;
            public decimal listPrice;
            public int salesRank;
            public Dictionary<string, PricingData> bookList = new Dictionary<string, PricingData>();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    get book prices 
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public bool getInternetPrices(string isbn, BookData bD, PricingData pD) {

            //  make sure this is NOT an ASIN
            if (isbn.StartsWith("B")) {
                //  show message
                return false;
            }

            string page = readPricesDotCom(isbn);
            bool rc = parsePricesDotCom(page, isbn, bD, pD);

            return rc;
        }

        /*
         //http://www.bookfinder4u.com/IsbnSearch.aspx?isbn=0345377443&mode=direct&option=all
         //  http://www.findbookprices.com/search/?isbn=0345377443 
         * 
         * */
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    read FindBookPrices.com
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private string readPricesDotCom(string isbn) {

            Cursor.Current = Cursors.AppStarting;

            System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;

            Uri uri = new Uri("http://www.findbookprices.com/search/?isbn=" + isbn);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Referer = "http://www.findbookprices.com";
            request.KeepAlive = false;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = 0;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";


            string page = string.Empty;  //  clear it...
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


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    parse FindBookPrices.com
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private bool parsePricesDotCom(string page, string isbn, BookData bD, PricingData pD) {

            Regex r = null, r1 = null, r2 = null;
            Match m = null, m1 = null, m2 = null;
            int startIndex = 0;
            ndx1 = 0;
            string conditionData = "";
            string debuggingData = "";
            string pricingData = "";

            bD.ISBN = isbn;  //  might as well, since we're here anyway...

            if (page.Contains("Invalid ISBN was detected"))
                return false;

            //if (page.Contains("Oops...there was a problem with"))
            //    return false;

            //if (page.Contains("Server Error in '/' Application.") || page.Contains("server-error") || page.Contains("Bad Request (Invalid Hostname)") ||
            //    page.Contains("Unable to read data from the transport connection")) {
            //    MessageBox.Show("There is a problem with the server that gets book information.\n" +
            //        "Please try again later.  We are sorry for the inconvenience.", "Prager Book Inventory Manager",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}


            //--  do list price
            //r = new Regex("<br/>List Price: ");  //  find starting point of list price
            //m = r.Match(page, 0);
            //if (m.Success) {
            //    r1 = new Regex("</font><font size=\"-2\">");  //  find end of List Price:
            //    m1 = r1.Match(page, m.Index + 17);
            //    if (m.Success && m1.Success) {
            //        if (page.Substring(m.Index + 17, 1) == "$")
            //            bD.listPrice = decimal.Parse(page.Substring(m.Index + 18, m1.Index - (m.Index + 18)));
            //        else
            //            bD.listPrice = decimal.Parse(page.Substring(m.Index + 17, m1.Index - (m.Index + 17)));
            //    }
            //}
            //else {
            //    bD.listPrice = 0.0M;
            //    r1 = new Regex(@"New & Used Books");  //  find starting point of list price
            //    m1 = r1.Match(page, 0);
            //}

            //--  do selling prices 
            //r = new Regex(@"New & Used Books");  //  find starting point of selling prices (m.Index)
            //m = r.Match(page, 0);  //  m1.Index
            //if (m.Success) {
            //    startIndex = m.Index;  //  position it...

                do {  //  now, go through each store and price 

                    r1 = new Regex("title=\"Visit Store for Details\">");  //  find starting point of store name (32 char count)
                    if (bD.bookList.Count == 0)
                        m1 = r1.Match(page, startIndex + 1880);  //  offset from "New & Used Books"
                    else
                        m1 = r1.Match(page, startIndex);  //  2nd time around it should start at 4900

                    if (m1.Success) {  //  found "visit store for details"

                        //debuggingData = page.Substring(m1.Index, 60);

                        //  find end of store name (m1 -> title="visit store for details"
                        //  Books A Million Marketplace</a></font></b><font color=#666666></font></td><td align=left>&nbsp;&nbsp

                        r = new Regex("</a></font><br/>&nbsp;&nbsp;&nbs|" +
                            "</a></font><font color=#666666>|" +
                            "</a></font></b><font color=#666666></font></td><td align=left>&nbsp;&nbsp;<i><b>|" +
                            "</a></font></b><font color=#666666></font></td><td align=left>&nbsp;&nbsp;|" +
                            "</a></font></b><font color=#666666><br/><i>&nbsp;&nbsp;&nbsp;|" +
                            "</a></font></b><font color=#666666><br/>|" +
                            "</a></font></b><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=#666666><i>|" +
                            "</a></font><a href=");
                        m = r.Match(page, m1.Index + 32, 120);

                        debuggingData = page.Substring(m1.Index + 32, 120);
                        if (m.Success == false)  //  testing only
                            continue;

                        if (m.Success) {  //  store name was found...
                            pD = new PricingData();  //  new instance
                            pD.venueName = page.Substring(m1.Index + m1.Length, m.Index - (m1.Index + m1.Length));  // m1+32->start, m->end

                            if (pD.venueName.Contains("Abebooks.co.uk") ||
                                pD.venueName.Contains("Biblio.co.uk Marketplace") ||
                                pD.venueName.Contains("Half.com Marketplace") ||
                                pD.venueName.Contains("Book Depository.co.uk") ||
                                pD.venueName.Contains("Amazon.co.uk")) {

                                //r1 = new Regex("title=\"Visit Store for Details\">");  //  find starting point of store name (32 char count)
                                //m1 = r1.Match(page, m.Index + 500);  //  2nd time around it should start at 4900
                                //int offsetLength = m1.Index - m.Index;
                                //startIndex = m.Index + offsetLength - pD.venueName.Length;
                                startIndex = m.Index + 6440;  //  end of price for this store
                                continue;
                            }

                            //debuggingData = page.Substring(m.Index, 80);  //  'm' should point to end of venue name

                            //  find beginning of book condition
                            r2 = new Regex("<font color=#666666></font></td><td align=left>&nbsp;&nbsp;<i>[a-zA-Z]|" +
                            "<font color=#666666>[a-zA-Z]|<font color=#000000>[a-zA-Z]");
                            m2 = r2.Match(page, m.Index, 680);

                            //debuggingData = page.Substring(m.Index + m2.Length, 1300);  //  m2.index -> beginning of condition

                            if (m2.Success) {  //  find end of condition
                                r = new Regex("</a></i></td><td align=right|</i></td><td align=right|</a></b></i></td><td align=right");
                                m = r.Match(page, m2.Index + m2.Length, 85);  //  m -> end of condition

                                //debuggingData = page.Substring(m2.Index + m2.Length - 1, 10);  //  should point to beginning of condition

                                if (m.Success && m2.Success) {
                                    //debuggingData = page.Substring(m.Index, 80);  // should point to end of condition

                                    conditionData = page.Substring(m2.Index + m2.Length - 1, m.Index - (m2.Index + m2.Length - 1));
                                    switch (conditionData) {
                                        case "Good":
                                            pD.bookCondn = 'g';
                                            break;
                                        case "Used":
                                            pD.bookCondn = 'u';
                                            break;
                                        case "Very&nbsp;Good":
                                            pD.bookCondn = 'v';
                                            break;
                                        case "Acceptable":
                                            pD.bookCondn = 'a';
                                            break;
                                        case "Like&nbsp;New":
                                            pD.bookCondn = 'l';
                                            break;
                                        case "New":
                                            pD.bookCondn = 'n';
                                            break;
                                        default:
                                            pD.bookCondn = 'u';
                                            break;
                                    }
                                }
                            }

                            //  find beginning of price 
                            r1 = new Regex("\">[$]");
                            m1 = r1.Match(page, m.Index + 690, 800);  //  m1 -> beginning of price string

                            //debuggingData = page.Substring(m1.Index, 10);

                            if (m1.Success) {  //  m1 -> beginning of price
                                r = new Regex(@"</a></font></td><td");  //  find end of price string
                                m = r.Match(page, m1.Index + 3, 40);

                                //debuggingData = page.Substring(m1.Index + 3, 40);

                                if (m.Success) //  m -> end of price
                                    pricingData = page.Substring(m1.Index + 3, m.Index - (m1.Index + 3));  //  includes $ sign
                            }
                            if (m.Success && m1.Success) {  //  beginning and end of price for this store was found...
                                pD.price = pricingData;

                                string key = pD.venueName + "." + pD.price + "." + pD.bookCondn;
                                if (!bD.bookList.ContainsKey(key))  //  don't keep duplicates
                                    bD.bookList.Add(key, pD);

                            }
                        }
                    }

                    startIndex = m.Index + 4900;  //  end of price for this store
                }
                while (m1.Success && m.Success && (startIndex < page.Length));
//            }

            return true;
        }
    }
}