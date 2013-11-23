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
    public class CampusiDotCom  //  has no book info; prices are very good
    {

        Regex r;
        Match m;
        Regex r1;
        Match m1;
        public decimal accumulatedPrice = 0.00M;
        public string[,] priceAndVenue = new string[100, 2];  //  book price, bookstore
        int ndx1 = 1;

        public CampusiDotCom()  //  constructor
        {
        }


        //-----------------------------------------------------------------------
        private string readBookInfo(string isbn)
        {

            Cursor.Current = Cursors.AppStarting;

            StringBuilder page = new StringBuilder();
            byte[] buf = new byte[8192];

            HttpWebRequest request = (HttpWebRequest)
            //WebRequest.Create("http://www.campusi.com/bookFind/asp/bookFindPrefindLst.asp?srchTxtIsbn=" + isbn);
            
            WebRequest.Create("http://www.campusi.com/bookFind/asp/bookFindPriceLoad.asp?prodId=" + isbn);
            HttpWebResponse response = (HttpWebResponse)
            request.GetResponse();

            Stream resStream = response.GetResponseStream();
            string tempString = null;
            int count = 0;
            do
            {
                count = resStream.Read(buf, 0, buf.Length);   //  fill the buffer with data
                if (count != 0) //  make sure we read some data
                {
                    tempString = Encoding.ASCII.GetString(buf, 0, count);  // translate from bytes to ASCII text
                    page.Append(tempString);   //continue building the string
                }
            }
            while (count > 0);


            Cursor.Current = Cursors.Default;
            return (page.ToString());   // next, page has to be parsed for prices and any errors

        }


        string bookInfo;
        //-----------------------------------------------------------------------------
        public bool getBookPrices(string ISBN)
        {
            bookInfo = readBookInfo(ISBN);

            return (parseBookInfoForPrices(bookInfo));  //  returns false if no data

        }

        //-----------------------------------------------------------------------------
        private bool parseBookInfoForPrices(string bookInfo)
        {
            //if (bookInfo.Contains("We're sorry, but no matching books were found."))
            //    return false;

            //  clear out the old stuff
            for (int i = 0; i < priceAndVenue.GetLength(0); i++)
            {
                priceAndVenue[i, 0] = "";
                priceAndVenue[i, 1] = "";
            }
            ndx1 = 1;
            accumulatedPrice = 0.00M;








            return true;
        }
    }
}