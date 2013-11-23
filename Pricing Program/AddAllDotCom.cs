using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;


//namespace Prager_Pricing_Program
namespace FindBookPrices
{
    public class AddAllDotCom  //  has no book info; prices are very good
    {

        Regex r;
        Match m;
        Regex r1;
        Match m1;
        public decimal accumulatedPrice = 0.00M;
        public string[,] priceAndVenue = new string[100, 2];  //  book price, bookstore
        int ndx1 = 1;

        public AddAllDotCom()  //  constructor
        {
        }


        //-----------------------------------------------------------------------
        private string readBookInfo(string isbn)
        {
            string remainderOfPostData = "&order=TITLE&ordering=ASC&dispCurr=USD&binding=Any+Binding&min=&max=&timeout=20&match=Y&noQuote=on&store=Abebooks&store=AbebooksDE&store=AbebooksFR&store=AbebooksUK&store=Alibris&store=Amazon&store=AmazonCA&store=AmazonUK&store=AmazonDE&store=AmazonFR&store=Antiqbook&store=Biblio&store=Biblion&store=Bibliophile&store=Bibliopoly&store=Booksandcollectibles&store=Half&store=ILAB&store=LivreRareBook&store=Maremagnum&store=Powells&store=Strandbooks&store=Tomfolio&store=ZVAB";
            Cursor.Current = Cursors.AppStarting;
            Uri uri = new Uri("http://used.addall.com/SuperRare/submitRare.cgi");
            //Uri uri = new Uri("http:www.addall.com/New/submitNew.cgi");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Referer = "http:www.addall.com/";
            string postsourcedata;
            postsourcedata = "author=&title=&keyword=&isbn=" + isbn + remainderOfPostData;

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postsourcedata.Length;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";

            try
            {
                Stream writeStream = request.GetRequestStream();

                UTF8Encoding encoding = new UTF8Encoding();
                byte[] bytes = encoding.GetBytes(postsourcedata);
                writeStream.Write(bytes, 0, bytes.Length);
                writeStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
                string page = readStream.ReadToEnd();
                Cursor.Current = Cursors.Default;
                return (page);  //  next, page has to be parsed for prices and any errors

                /* to get remainder of pages...
                 * http://used.addall.com/SuperRare/RefineRare.fcgi?start=250&id=070511160844720503&order=TITLE&ordering=ASC&dispCurr=USD&inTitle=&inAuthor=&inDesc=&exTitle=&exAuthor=&exDesc=&match=Y
                 * */
            }
            catch (WebException e)
            {
                return ("An error has occurred obtaining prices from the internet: " + e.Message);
            }

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
                priceAndVenue[i, 0] = "";  //  price
                priceAndVenue[i, 1] = "";  //  bookseller
            }
            ndx1 = 1;
            accumulatedPrice = 0.00M;

            //  start looking for beginning of prices...








            return true;
        }
    }
}