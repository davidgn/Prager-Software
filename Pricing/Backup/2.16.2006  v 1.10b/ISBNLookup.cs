#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;

#endregion


namespace Prager_Pricing_Program
{
    partial class formISBNLookup : Form
    {

        Regex r;
        Match m;
        Regex r1;
        Match m1;
        Regex r2;
        Match m2;


//------------------------------------------------------------------------------------
        private String readAddallBookInfo(string ISBN)
        {

            Uri uri = new Uri("http://www3.addall.com/New/submitNew.cgi");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Referer = "http://www.addall.com/";

            string postsourcedata;
            postsourcedata = "&query=" + ISBN + "&type=ISBN";
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postsourcedata.Length;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
            Stream writeStream = request.GetRequestStream();

            UTF8Encoding encoding = new UTF8Encoding();
            byte[] bytes = encoding.GetBytes(postsourcedata);
            writeStream.Write(bytes, 0, bytes.Length);
            writeStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
            string page = readStream.ReadToEnd();

            return (page);  //  next, page has to be parsed for prices and any errors

        }  //  end readAddallHtmlPage


//---------------------------------------------------------------------------------------
        private int parseAddallPricingInfo(string webPageString, Label lp, ListView lv, string sisbn)
        {

            r = new Regex("<b>ISBN:");  // find beginning
            m = r.Match(BookInfo);
            if (m.Success)
                lp.Text = BookInfo.ToString().Substring(m.Index + 14, 10);

            int indx = 2;  //  was 0
            r = new Regex(@"<B>List Price:");  // find beginning
            m = r.Match(BookInfo);
            r1 = new Regex(@"<BR>");  // find end
            m1 = r1.Match(BookInfo, m.Index + 19);
            r2 = new Regex("USD ");
            m2 = r2.Match(BookInfo, m.Index + 14);
            if (m.Success && m2.Success)
            {
                lp.Text = sisbn;  //  display ISBN
                lp.Refresh();
                lv.Items.Add("List Price: ");
                lv.Items[0].SubItems.Add(BookInfo.ToString().Substring(m2.Index + 4, m1.Index - (m2.Index + 4)));
                lv.Items.Add(" ");  //  space

            }
            else
            {
                r = new Regex(@"No valid Info");  // find beginning
                m = r.Match(BookInfo);
                if (m.Success)
                    return -1;
            }

            r = new Regex(@">Alibris<");  // find beginning
            m = r.Match(webPageString);
            r1 = new Regex(@" *<TD ALIGN=CENTER>");  //  find end
            m1 = r1.Match(webPageString, m.Index);
            if (m.Success && m1.Success)
                formatAddallNameAndPrice(webPageString, m, m1, lv, indx);

            r = new Regex(@">Walmart<");
            m = r.Match(webPageString);
            r1 = new Regex(@" *<TD ALIGN=CENTER>");
            m1 = r1.Match(webPageString, m.Index);
            if (m.Success && m1.Success)
                formatAddallNameAndPrice(webPageString, m, m1, lv, ++indx);

            r = new Regex(@">Abebooks<");
            m = r.Match(webPageString);
            r1 = new Regex(@" *<TD ALIGN=CENTER>");
            m1 = r1.Match(webPageString, m.Index);
            if (m.Success && m1.Success)
                formatAddallNameAndPrice(webPageString, m, m1, lv, ++indx);

            r = new Regex(@">Powell's<");
            m = r.Match(webPageString);
            r1 = new Regex(@" *<TD ALIGN=CENTER>");
            m1 = r1.Match(webPageString, m.Index);
            if (m.Success && m1.Success)
                formatAddallNameAndPrice(webPageString, m, m1, lv, ++indx);

            r = new Regex(@">Amazon<");
            m = r.Match(webPageString);
            r1 = new Regex(@" *<TD ALIGN=CENTER>");
            m1 = r1.Match(webPageString, m.Index);
            if (m.Success && m1.Success)
                formatAddallNameAndPrice(webPageString, m, m1, lv, ++indx);

            r = new Regex(@">Buy.com<");
            m = r.Match(webPageString);
            r1 = new Regex(@" *<TD ALIGN=CENTER>");
            m1 = r1.Match(webPageString, m.Index);
            if (m.Success && m1.Success)
                formatAddallNameAndPrice(webPageString, m, m1, lv, ++indx);

            r = new Regex(@">ecampus.com<");
            m = r.Match(webPageString);
            r1 = new Regex(@" *<TD ALIGN=CENTER>");
            m1 = r1.Match(webPageString, m.Index);
            if (m.Success && m1.Success)
                formatAddallNameAndPrice(webPageString, m, m1, lv, ++indx);

            r = new Regex(@">BooksAMillion<");
            m = r.Match(webPageString);
            r1 = new Regex(@" *<TD ALIGN=CENTER>");
            m1 = r1.Match(webPageString, m.Index);
            if (m.Success && m1.Success)
                formatAddallNameAndPrice(webPageString, m, m1, lv, ++indx);

            r = new Regex(@">Barnes & Noble.com<");
            m = r.Match(webPageString);
            r1 = new Regex(@" *<TD ALIGN=CENTER>");
            m1 = r1.Match(webPageString, m.Index);
            if (m.Success && m1.Success)
                formatAddallNameAndPrice(webPageString, m, m1, lv, ++indx);

            return 0;
        }  //  end parsePricingInfo


//------------------------------------------------------------------------------------------
        //  adds name and price to the list boxes
        private void formatAddallNameAndPrice(string WebPageString, Match m, Match m1, ListView lv, int indx)
        {
            string name;
            string price;

            name = m.Value.Substring(1, m.Length - 2);
            lv.Items.Add(name);

            int i = WebPageString.Substring(m1.Index + 18, 6).Length;
            price = WebPageString.Substring(m1.Index + 18, 9).Substring(0, i - 1);

            price = Regex.Replace(price, @"[</]", " ");  //  remove the garbage
            lv.Items[indx].SubItems.Add(System.Convert.ToDecimal(price).ToString());
            lv.Refresh();

            return;
        }


//------------------------------------------------------------------------------------
        private String readCampusiBookPricesHtmlPage(string ISBN)
        {

            StringBuilder page = new StringBuilder();
            byte[] buf = new byte[8192];

            HttpWebRequest request = (HttpWebRequest)
                WebRequest.Create("http://www.campusi.com/bookFind/asp/bookFindPriceLst.asp?prodId=" + ISBN);
// (old one)    WebRequest.Create("http://findbookprices.com/search/?isbn=" + ISBN);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream resStream = response.GetResponseStream();
            string tempString = null;
            int count = 0;
            do
            {
                count = resStream.Read(buf, 0, buf.Length);  // fill the buffer with data
                if (count != 0)  // make sure we read some data
                {
                    tempString = Encoding.ASCII.GetString(buf, 0, count);  // translate from bytes to ASCII text
                    page.Append(tempString);  // continue building the string
                }
            }
                while (count > 0);

            Cursor.Current = Cursors.Default;
            return (page.ToString());  //  next, page has to be parsed for prices and any errors

        }  //  end readFindBookPricesHtmlPage



//----------------------------------------------------------------------------------------------
        public int parseCampusiBookPricesBookInfo(string BookInfo, Label lp, ListView lv, string sisbn)
        {
            string name;
            string price;
            int i = 0;

            r = new Regex(@" no pricing information available");  //  valid info returned?
            m = r.Match(BookInfo);
            if (m.Success)
                return -1;

            r = new Regex(@"List price");  // find beginning of word "List price"
            m = r.Match(BookInfo,1);
            if (m.Success)
            {
                r1 = new Regex(@"<td><font face=""arial"" size=2>");  //  find actual price
                m1 = r1.Match(BookInfo, m.Index + 10);
                r2 = new Regex(@"</td>");  //  end of price
                m2 = r2.Match(BookInfo, m1.Index + 30);
                r = new Regex(@"\$");
                m = r.Match(BookInfo, m1.Index + 34, 2);
                if (m1.Success && m2.Success && m.Success)
                {
                    lp.Text = sisbn;  //  display ISBN
                    lp.Refresh();
                    lv.Items.Add("List Price: ");
                    lv.Items[0].SubItems.Add(BookInfo.ToString().Substring(m1.Index + 34, m2.Index - (m1.Index + 37)));
                    lv.Items.Add(" ");  //  space
                }
                else
                {
                    lp.Text = sisbn;  //  display ISBN
                    lp.Refresh();
                    lv.Items.Add("List Price:");
                    lv.Items[0].SubItems.Add(@"n/a");
                    lv.Items.Add(" ");  //  space

                }
            }
            int lastIndex = m1.Index;
            for (i = 2; i < 33; i++)  //  look for first entry
            {
                r = new Regex(@"color=teal><b>");  // find beginning of dealer
                m = r.Match(BookInfo, lastIndex);
                r1 = new Regex(@"</b></font></a>&nbsp;");  // find end of dealer
                m1 = r1.Match(BookInfo, m.Index + 14);
                if (m.Success && m1.Success)
                {
                    name = BookInfo.Substring(m.Index + 14, m1.Index - (m.Index + 14));
                    name = Regex.Replace(name, @"<b>|</b>", "");  //  remove the garbage
                    if (name == @"Toys Hobbies & games")
                        continue;
//  color=darkgreen><b>  beginning of price
//  </b></font>&nbsp;  end of price
                    lv.Items.Add(name);

                    r = new Regex(@"color=darkgreen><b>");  // find beginning of price
                    m = r.Match(BookInfo, m1.Index + 14);
                    r1 = new Regex(@"</b></font>&nbsp;");  //  find end of price
                    m1 = r1.Match(BookInfo, m.Index + 19);

                    price = BookInfo.Substring(m.Index + 19, m1.Index - (m.Index + 19));
                    lv.Items[i].SubItems.Add(price);
                    lastIndex = m.Index;
                    lv.Items[i].SubItems.Add(price);
                }
                lv.Refresh();
            }  //  end for

            return 0;
        }

    }  //  end partial class Form1

}  //  end Namespace

//http://www.findbookprices.com/search/?isbn=basic+mathematics+for+aviation
