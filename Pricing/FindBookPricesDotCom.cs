using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Globalization;
using System.Threading;


namespace Prager_Pricing_Program
{
    public class FindBookPricesDotCom  //  has no book info; prices are very good
    {

        Regex r;
        Match m;
        Regex r1;
        Match m1;
        public decimal accumulatedPrice = 0.00M;
        public string[,] priceAndVenue = new string[100, 2];  //  book price, bookstore
        string decimalSeparator = "";
        int ndx1 = 1;

        public FindBookPricesDotCom()  //  constructor
        {
            decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
        }


        string bookInfo;
        //-----------------------------------------------------------------------------
        public bool getBookPrices(string ISBN)
        {

            //if (ISBN.Length == 10)
                bookInfo = readBookInfo(ISBN);
            //else
            //{
            //    ConvertISBN c = new ConvertISBN();
            //    bookInfo = readBookInfo(c.convertToISBN10(ISBN));
            //}
            return (parseBookInfoForPrices(bookInfo));  //  returns false if no data

        }

        //-----------------------------------------------------------------------
        private string readBookInfo(string isbn)
        {

            Cursor.Current = Cursors.AppStarting;

            System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;

            Uri uri = new Uri("http://www.moreprices.com/?pr=books&query=" + isbn + "&x=13&y=9");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Referer = "http://www.moreprices.com/";

            Cookie sessionID = new Cookie("ASP.NET_SessionId", "4u1f0pihfopqu5nguu21js55");
            Cookie uguid = new Cookie("uguid", "bcb6e5c9f8cc436b8cc99861158ba39d");
            Cookie sguid = new Cookie("sguid", "2e315d5c00224775b32b0bb0865293f9");
            Cookie src = new Cookie("src", "1");

            CookieCollection cc = new CookieCollection();
            request.CookieContainer = new CookieContainer();
            cc.Add(sessionID);
            cc.Add(uguid);
            cc.Add(sguid);
            cc.Add(src);
            request.CookieContainer.Add(uri, cc);

            request.KeepAlive = false;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = 0;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";

            string page = "";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
                page = readStream.ReadToEnd();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to read data from the transport connection"))
                    return "Unable to read data from the transport connection";
            }
            return (page);  //  next, page has to be parsed for prices and any errors

        }


        //-----------------------------------------------------------------------------
        private bool parseBookInfoForPrices(string bookInfo)
        {
            if (bookInfo.Contains("We're sorry, but no matching books were found."))
                return false;

            if (bookInfo.Contains(" 0 matches found."))
                return false;

            if (bookInfo.Contains("Server Error in '/' Application.") || bookInfo.Contains("server-error") || bookInfo.Contains("Bad Request (Invalid Hostname)") ||
                bookInfo.Contains("Unable to read data from the transport connection"))
            {
                MessageBox.Show("There is a problem with the server that gets book information.\n" +
                    "Please try again later.  We are sorry for the inconvenience.", "Prager Inventory Program",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Application.Exit();
                return false;
            }

            //  clear out the old stuff
            for (int i = 0; i < priceAndVenue.GetLength(0); i++)
            {
                priceAndVenue[i, 0] = "";
                priceAndVenue[i, 1] = "";
            }
            ndx1 = 1;
            accumulatedPrice = 0.00M;

            //<font size="-2"><br/><br/>List Price: $25.95</font>
            r = new Regex("<font size=\"-2\"><br/><br/>List Price:");  //  look for list price
            m = r.Match(bookInfo, 0);
            if (m.Success)
            {
                r1 = new Regex(@"</font>");  //  look for list price
                m1 = r1.Match(bookInfo, m.Index);
                if (m1.Success)
                {
                    priceAndVenue[0, 0] = bookInfo.Substring(m.Index + 38, m1.Index - (m.Index + 38));  // move list price
                    priceAndVenue[0, 1] = "List Price";
                    if (decimalSeparator != ".")
                        priceAndVenue[0, 0] = priceAndVenue[0, 0].Replace(".", decimalSeparator);
                }
            }
            else
                priceAndVenue[0, 1] = "List Price - n/a";

            //  <font size="+1">Used Books</font>  or  <font size="+1">New Books</font>
            //r1 = new Regex("<font size=\"\\+1\">(New Books</font>|Used Books</font>)");  //  find starting point of selling prices
            r1 = new Regex("<b><font size=\"\\+1\">New & Used Books</font>");
            m1 = r1.Match(bookInfo, 0);
            if (m1.Success)
            {
                do
                {
                    //     nowrap="">Amazon Marketplace   </td>  <td align="left">&nbsp;&nbsp;<i>Used  </i></td>
                    r = new Regex("nowrap=\"\">");  //  find beginning of store name
                    m = r.Match(bookInfo, m1.Index);
                    if (m.Success)
                    {
                        string workingName = "";
                        r1 = new Regex(" </td>  <td align=\"left\">&nbsp;&nbsp;");  //  find end
                        m1 = r1.Match(bookInfo, m.Index + 10);
                        if (m.Success && m1.Success)    //  we found the bookstore name
                        {

                            workingName = bookInfo.Substring(m.Index + 10, m1.Index - (m.Index + 10));  // move name of store
                            workingName = workingName + "(" + bookInfo.Substring(m1.Index + 40, 6).Trim() + ")";  //  get book type...
                            workingName = workingName.Replace("<b>", "");
                            priceAndVenue[ndx1, 1] = workingName.Replace("</b>", "");

                            //now look for price  ("<td align="right">&nbsp;&nbsp;$")
                            r = new Regex(@">&nbsp;&nbsp;\$");  //  beginning of price
                            m = r.Match(bookInfo, m.Index + 14);
                            if (m.Success)
                            {
                                r1 = new Regex("</td>  <td align=\"center\">");  //  end of price
                                m1 = r1.Match(bookInfo, m.Index + 14);
                            }
                            if (m.Success && m1.Success)
                            {
                                priceAndVenue[ndx1, 0] = bookInfo.Substring(m.Index + 14, m1.Index - (m.Index + 14));

                                //accumulatedPrice += Convert.ToDecimal(priceAndVenue[ndx1 - 1, 0]);
                                //if (decimalSeparator != ".")
                                //    priceAndVenue[ndx1, 0] = priceAndVenue[ndx1, 0].Replace(".", decimalSeparator);
                                accumulatedPrice += Convert.ToDecimal(priceAndVenue[ndx1++, 0], CultureInfo.InvariantCulture);
                               
                                if (decimalSeparator != ".")  //  now make it presentable...
                                    priceAndVenue[ndx1 - 1, 0] = priceAndVenue[ndx1 - 1, 0].Replace(".", decimalSeparator);
                            }
                        }
                    }
                } while (m.Success && m1.Success);
                
                return true;
            }
            else
                return false;
        }

    }
}
