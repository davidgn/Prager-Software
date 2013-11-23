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
    public class findBookPricesDotCom  //  has no book info; prices are very good
    {

        Regex r;
        Match m;
        Regex r1;
        Match m1;
        public decimal accumulatedPrice = 0.00M;
        public string[,] priceAndVenue = new string[100, 2];  //  book price, bookstore
        int ndx1 = 1;

        public findBookPricesDotCom()  //  constructor
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
            byte[] buf = new byte[8192];
            string page = "";
            WebClient webClient = new WebClient();
            string strUrl = @"http://www.findbookprices.com/search/?isbn=" + isbn;
            byte[] reqHTML;
            reqHTML = webClient.DownloadData(strUrl);
            UTF8Encoding objUTF8 = new UTF8Encoding();
            page = objUTF8.GetString(reqHTML);

            return page;
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
