using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;


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
        int ndx1 = 1;

        public FindBookPricesDotCom()  //  constructor
        {
        }


        string bookInfo;
        //-----------------------------------------------------------------------------
        public bool getBookPrices(string ISBN)
        {
            bookInfo = readBookInfo(ISBN);

            return (parseBookInfoForPrices(bookInfo));  //  returns false if no data

        }

        //-----------------------------------------------------------------------
        private string readBookInfo(string isbn)
        {

            Cursor.Current = Cursors.AppStarting;

            System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;

            Uri uri = new Uri("http://www.findbookprices.com/search/?isbn=" + isbn);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Referer = "http://www.findbookprices.com/";

            Cookie sessionID = new Cookie("ASP.NET_SessionId", "5iaext55h2kvbou3s3e0ynnc");
            Cookie source = new Cookie("src", "1");

            CookieCollection cc = new CookieCollection();
            request.CookieContainer = new CookieContainer();
            cc.Add(sessionID);
            cc.Add(source);
            request.CookieContainer.Add(uri, cc);

            request.KeepAlive = false;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = 0;  
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
            string page = readStream.ReadToEnd();

            Cursor.Current = Cursors.Default;
            return (page);  //  next, page has to be parsed for prices and any errors

        }


        //-----------------------------------------------------------------------------
        private bool parseBookInfoForPrices(string bookInfo)
        {
            if (bookInfo.Contains("We're sorry, but no matching books were found."))
                return false;

            //  clear out the old stuff
            for (int i = 0; i < priceAndVenue.GetLength(0); i++)
            {
                priceAndVenue[i, 0] = "";
                priceAndVenue[i, 1] = "";
            }
            ndx1 = 1;
            accumulatedPrice = 0.00M;

            //<font size="-2"><br/><br/>List Price: $25.95</font>
            r = new Regex(@"<font size=""-2""><br/><br/>List Price:");  //  look for list price
            m = r.Match(bookInfo, 0);
            if (m.Success)
            {
                r1 = new Regex(@"</font>");  //  look for list price
                m1 = r1.Match(bookInfo, m.Index);
                if (m1.Success)
                {
                    priceAndVenue[0, 0] = bookInfo.Substring(m.Index + 38, m1.Index - (m.Index + 38));  // move list price
                    priceAndVenue[0, 1] = "List Price";
                }
            }

            r1 = new Regex("Compare Prices");  //  find starting point of selling prices
            m1 = r1.Match(bookInfo, 0);
            if (m1.Success)
            {
                do
                {
                    //  find price
                    r = new Regex(@"return false;");
                    m = r.Match(bookInfo, m1.Index);
                    if (m.Success)
                    {
                        r1 = new Regex(@"</td>  <td align=""center"">&nbsp;&nbsp;");  //  find end
                        m1 = r1.Match(bookInfo, m.Index + 62);
                        if (m.Success && m1.Success)    //  we found the price
                        {
                            priceAndVenue[ndx1, 0] = bookInfo.Substring(m.Index + 59, m1.Index - (m.Index + 59));  // move price
                            accumulatedPrice += Convert.ToDecimal(priceAndVenue[ndx1, 0]);

                            //  now look for bookstore
                            r = new Regex(@" at ");
                            m = r.Match(bookInfo, m1.Index + 40);
                            r1 = new Regex(@"</td>  <td></td></tr>");  //  find end
                            m1 = r1.Match(bookInfo, m.Index + 4);
                            if (m.Success && m1.Success)
                            {
                                string tempString = bookInfo.Substring(m.Index + 4, m1.Index - (m.Index + 4));
                                tempString = tempString.Replace("</b>", "");
                                priceAndVenue[ndx1++, 1] = tempString.Replace("<b>", "");
                            }
                        }
                    }
                } while (m.Success);

                return true;
            }
            else
                return false;
        }

    }
}
