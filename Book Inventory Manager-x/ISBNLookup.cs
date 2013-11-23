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


namespace Prager_Book_Inventory
{

    partial class mainForm : Form
    {





        ////------------------------------------------------------------------------------------
        //private String readAddallBookInfo(string ISBN)
        //{

        //    //traceSource.TraceEvent(TraceEventType.Start, 76, "readAddallBookInfo");

        //  //  string remainderOfPostData = "&order=TITLE&ordering=ASC&dispCurr=USD&binding=Any+Binding&min=&max=&timeout=20&match=Y&StoreAbebooks=on&StoreAlibris=on&StoreAmazon=on&StoreAmazonUK=on&StoreAmazonDE=on&StoreAmazonFR=on&StoreAntiqbook=on&StoreBiblio=on&StoreBiblion=on&StoreBibliophile=on&StoreBibliopoly=on&StoreBooksandcollectibles=on&StoreHalf=on&StoreILAB=on&StoreMaremagnum=on&StorePowells=on&StoreStrandbooks=on&StoreZVAB=on";
        //    string remainderOfPostData = "?query=0916260755&type=ISBN&location=10000&state=WA&dispCurr=USD";
        //    Cursor.Current = Cursors.AppStarting;
        //  //  Uri uri = new Uri("http://used.addall.com/SuperRare/submitRare.cgi");
        //    Uri rui = new Uri("http://www.addall.com/New/submitNew.cgi");
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        //    request.Referer = "http://www.addall.com/";
        //    string postsourcedata;
        //    postsourcedata = "author=&title=&keyword=&isbn=" + ISBN + remainderOfPostData;

        //    request.Method = "POST";
        //    request.ContentType = "application/x-www-form-urlencoded";
        //    request.ContentLength = postsourcedata.Length;
        //    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";

        //    try
        //    {
        //        Stream writeStream = request.GetRequestStream();

        //        UTF8Encoding encoding = new UTF8Encoding();
        //        byte[] bytes = encoding.GetBytes(postsourcedata);
        //        writeStream.Write(bytes, 0, bytes.Length);
        //        writeStream.Close();

        //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //        Stream responseStream = response.GetResponseStream();
        //        StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
        //        string page = readStream.ReadToEnd();
        //        lbStatus.Items.Insert(0, "returned");
        //        lbStatus.Refresh();
        //        Cursor.Current = Cursors.Default;
        //        return (page);  //  next, page has to be parsed for prices and any errors

        //    }
        //    catch (WebException e)
        //    {
        //        lbStatus.Items.Insert(0, "Internet error: " + e);
        //        lbStatus.Refresh();
        //        return ("");
        //    }

        //    //traceSource.TraceEvent(TraceEventType.Stop, 117, "readAddallBookInfo");
        //}  



        ////---------------------------------------------------------------------------------------
        //private int parseAddallBookInfo(string BookInfo)
        //{

        //    string rawData;
        //    int length = 0;

        //    r = new Regex(@"<FONT COLOR=000000 SIZE=+0><B>");
        //    m = r.Match(BookInfo);
        //    if (!m.Success)  //   title missing?
        //    {
        //        MessageBox.Show("ISBN not found", "Check data", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return -1;
        //    }

        //    //  do title
        //    r = new Regex(@"<FONT COLOR=000000 SIZE=+0><B>");
        //    m = r.Match(BookInfo);
        //    r1 = new Regex(@"</B></font><font color=blue>");  //  find end of title
        //    m1 = r1.Match(BookInfo, m.Index + 36);
        //    if (m.Success && m1.Success)
        //    {
        //        length = m1.Index - (m.Index + 43) > 100 ? 100 : m1.Index - (m.Index + 43);
        //        tbTitle.Text = BookInfo.Substring(m.Index + 43, length).Trim();  //  move it!

        //        //  now replace "&amp;" with a pure ampersand 
        //        tbTitle.Text.Replace("&amp;", "&");

        //        if (capitalizeTitleandAuthorToolStripMenuItem.Checked == true)
        //            tbTitle.Text = tbTitle.Text.ToUpper();
        //    }

        //    //  do author
        //    MatchCollection mc;
        //    r = new Regex(@"by ");
        //    m = r.Match(BookInfo, m1.Index);
        //    r1 = new Regex(@"<b>ISBN: ");  //  find end
        //    m1 = r1.Match(BookInfo, m.Index + 3);
        //    if (m.Success && m1.Success)
        //    {
        //        r2 = new Regex(@"<a href=/author/");
        //        mc = r2.Matches(BookInfo, m.Index);  //  find all authors (they are listed twice, top and bottom)
        //        m2 = r2.Match(BookInfo, m.Index);  //  find start of link

        //        //  Single Author w/ no Link:   0300056400
        //        //   by Wayne A. Meeks<BR><b>ISBN: 
        //        //  m^                  m1^  
        //        if (mc.Count == 0)  //  single/multiple author(s) w/ no link
        //            tbAuthor.Text = BookInfo.Substring(m.Index + 3, m1.Index - m.Index - 8);
        //        else
        //        {
        //            //  Single Author w/ Link:  1564558452
        //            //   by <a href=/author/2749492-1>Clarissa Pinkola Estes</a><BR><b>ISBN:
        //            //  m^   m2^                   m3^                            m1^
        //            if (mc.Count == 2)  //  single author w/ Link
        //            {
        //                r3 = new Regex(">");  //  find end of href stuff (beginning of name)
        //                m3 = r3.Match(BookInfo, m2.Index);
        //                if (m3.Success)
        //                    tbAuthor.Text = BookInfo.Substring(m3.Index + 1, m1.Index - m3.Index - 10);

        //            }
        //            else
        //            //  Multple Authors w/ Links: 0668055928
        //            //   by <a href=/author/10126261-1>Bernard Deyries</a>, <a href=/author/10126262-1>Denys Lemery</a>,
        //            //  m^   m2^                    m3^              m^    
        //            //     <a href=/author/2996897-1>Michael Sadler</a><BR><b>ISBN:
        //            //                                                   m1^
        //            {  //  multiple authors w/ Links
        //                int iterations = mc.Count / 2;
        //                int searchIndx = m2.Index;
        //                StringBuilder workingString = new StringBuilder();

        //                for (i = 0; i < iterations; i++)
        //                {
        //                    r3 = new Regex(">");  //  find end of href stuff (beginning of name)
        //                    m3 = r3.Match(BookInfo, searchIndx);
        //                    r = new Regex("</a>");  //  end of name
        //                    m = r.Match(BookInfo, m3.Index);
        //                    if (m3.Success && m.Success)
        //                    {
        //                        workingString.Append(BookInfo.Substring(m3.Index + 1, m.Index - m3.Index - 1));
        //                        if (i < iterations - 1)
        //                            workingString.Append(", ");

        //                        searchIndx = m.Index + 6;  //  increment to next address
        //                    }
        //                }
        //                tbAuthor.Text = workingString.ToString();
        //            }
        //        }
        //    }
        //    if (capitalizeTitleandAuthorToolStripMenuItem.Checked == true)
        //        tbAuthor.Text = tbAuthor.Text.ToUpper();

        //    //  <B>Publisher: </B> William Morrow &amp; Company<BR>    -->0688159885
        //    //  m^                                                 m1^             
        //    //  do publisher
        //    string pubString = "";
        //    r = new Regex(@"<B>Publisher:");
        //    m = r.Match(BookInfo, m1.Index);
        //    r1 = new Regex(@"<b>Publish Date:");
        //    m1 = r1.Match(BookInfo, m.Index + 13);
        //    if (m.Success && m1.Success)
        //    {
        //        pubString = BookInfo.Substring(m.Index + 19, m1.Index - (m.Index + 24)).Trim();  //  move it!
        //        tbPub.Text = pubString.Replace("amp;", "");
        //    }

        //    //  do publish date
        //    r = new Regex(@"<b>Publish Date:");
        //    m = r.Match(BookInfo, m1.Index);
        //    r1 = new Regex(@"<b>Binding:");
        //    m1 = r1.Match(BookInfo, m.Index + 16);
        //    if (m.Success && m1.Success)
        //    {
        //        rawData = BookInfo.Substring(m.Index + 16, m1.Index - (m.Index + 16)).Trim();  //  move it!
        //        length = rawData.Length;
        //        tbYear.Text = rawData.Substring(length - 8, 4);  //  get only the year portion
        //    }

        //    //  do binding
        //    r = new Regex(@"<b>Binding:");
        //    m = r.Match(BookInfo);
        //    r1 = new Regex(@"<B>List Price:");  //  find end of title
        //    m1 = r1.Match(BookInfo, m.Index + 11);
        //    if (m.Success && m1.Success)
        //    {
        //        rawData = BookInfo.Substring(m.Index + 16, m1.Index - (m.Index + 22)).Trim();
        //        switch (rawData.ToLower().Substring(0, 9))
        //        {
        //            case "hardcover":
        //            case "gebundene ausgabe":
        //                coBinding.Text = "Hard Cover";
        //                break;
        //            case "paperback":
        //            case "broschiert":
        //            case "taschenbuch":
        //                coBinding.Text = "Trade PB";
        //                break;
        //            default:
        //                coBinding.Text = rawData.ToString();
        //                break;
        //        }
        //    }

        //    return 0;

        //}  //  end parseBookInfo


        ////---------------------------------------------------------------------------------------
        //private void parseAddallPricingInfo(string WebPageString)
        //{

        //    lbPricingResults.Items.Clear();
        //    lbPrice.Items.Clear();
        //    accumulatedPrice = 0;

        //    r = new Regex(@"<B>List Price:");  // find beginning
        //    m = r.Match(BookInfo);
        //    r1 = new Regex(@"<BR>");  // find beginning
        //    m1 = r1.Match(BookInfo, m.Index + 19);

        //    if (m.Success)
        //    {
        //        lListPrice.Text = "List Price (New): " + BookInfo.ToString().Substring(m.Index + 19,
        //            m1.Index - (m.Index + 19));
        //    }

        //    r = new Regex(@">Alibris<");  // find beginning
        //    m = r.Match(WebPageString);
        //    r1 = new Regex(@" *<TD ALIGN=CENTER>");  //  find end
        //    m1 = r1.Match(WebPageString, m.Index);
        //    if (m.Success)
        //    {
        //        formatAddallNameAndPrice(WebPageString, m, m1);
        //    }

        //    r = new Regex(@">Walmart<");
        //    m = r.Match(WebPageString);
        //    r1 = new Regex(@" *<TD ALIGN=CENTER>");
        //    m1 = r1.Match(WebPageString, m.Index);
        //    if (m.Success)
        //    {
        //        formatAddallNameAndPrice(WebPageString, m, m1);
        //    }

        //    r = new Regex(@">Abebooks<");
        //    m = r.Match(WebPageString);
        //    r1 = new Regex(@" *<TD ALIGN=CENTER>");
        //    m1 = r1.Match(WebPageString, m.Index);
        //    if (m.Success)
        //    {
        //        formatAddallNameAndPrice(WebPageString, m, m1);
        //    }

        //    r = new Regex(@">Powell's<");
        //    m = r.Match(WebPageString);
        //    r1 = new Regex(@" *<TD ALIGN=CENTER>");
        //    m1 = r1.Match(WebPageString, m.Index);
        //    if (m.Success)
        //    {
        //        formatAddallNameAndPrice(WebPageString, m, m1);
        //    }

        //    r = new Regex(@">Amazon<");
        //    m = r.Match(WebPageString);
        //    r1 = new Regex(@" *<TD ALIGN=CENTER>");
        //    m1 = r1.Match(WebPageString, m.Index);
        //    if (m.Success)
        //    {
        //        formatAddallNameAndPrice(WebPageString, m, m1);
        //    }

        //    r = new Regex(@">Buy.com<");
        //    m = r.Match(WebPageString);
        //    r1 = new Regex(@" *<TD ALIGN=CENTER>");
        //    m1 = r1.Match(WebPageString, m.Index);
        //    if (m.Success)
        //    {
        //        formatAddallNameAndPrice(WebPageString, m, m1);
        //    }

        //    r = new Regex(@">ecampus.com<");
        //    m = r.Match(WebPageString);
        //    r1 = new Regex(@" *<TD ALIGN=CENTER>");
        //    m1 = r1.Match(WebPageString, m.Index);
        //    if (m.Success)
        //    {
        //        formatAddallNameAndPrice(WebPageString, m, m1);
        //    }

        //    r = new Regex(@">BooksAMillion<");
        //    m = r.Match(WebPageString);
        //    r1 = new Regex(@" *<TD ALIGN=CENTER>");
        //    m1 = r1.Match(WebPageString, m.Index);
        //    if (m.Success)
        //    {
        //        formatAddallNameAndPrice(WebPageString, m, m1);
        //    }

        //    r = new Regex(@">Barnes & Noble.com<");
        //    m = r.Match(WebPageString);
        //    r1 = new Regex(@" *<TD ALIGN=CENTER>");
        //    m1 = r1.Match(WebPageString, m.Index);
        //    if (m.Success)
        //    {
        //        formatAddallNameAndPrice(WebPageString, m, m1);
        //    }

        //    int divisor = lbPrice.Items.Count;
        //    if (divisor != 0)
        //    {
        //        decimal holdingAmount = accumulatedPrice / divisor;
        //        lAveragePrice.Text = "Average price: $" + decimal.Round(holdingAmount, 2);
        //    }
        //    else
        //        lAveragePrice.Text = "Average price: prices not found";


        //}//  end parsePricingInfo



        ////------------------------------------------------------------------------------------------
        ////  adds name and price to the list boxes
        //private void formatAddallNameAndPrice(string WebPageString, Match m, Match m1)
        //{
        //    string name;
        //    string price;

        //    int i = WebPageString.Substring(m1.Index + 18, 6).Length;
        //    price = WebPageString.Substring(m1.Index + 18, 9).Substring(0, i - 1);

        //    name = m.Value.Substring(1, m.Length - 2);
        //    lbPricingResults.Items.Add(name);

        //    price = Regex.Replace(price, @"[</]", " ");  //  remove the garbage
        //    try
        //    {
        //        accumulatedPrice += Convert.ToDecimal(price.Replace('$', ' '));
        //    }
        //    catch (System.InvalidCastException)
        //    {
        //        ;  //  do nothing
        //    }

        //    lbPrice.Items.Add(System.Convert.ToDecimal(price));
        //    lbPrice.RightToLeft = RightToLeft.Yes;

        //    return;
        //}







        ////---------------------  now known as DealOz    --------------------------------------
        //public int parseCampusiBookPrices(string BookInfo)
        //{
        //    string name;
        //    string price;
        //    accumulatedPrice = 0;

        //    r = new Regex(@" no pricing information available");  //  valid info returned?
        //    m = r.Match(BookInfo);
        //    if (m.Success)
        //    {
        //        lNotFound.Visible = true;
        //        return -1;
        //    }

        //    lbPricingResults.Items.Clear();
        //    lbPrice.Items.Clear();

        //    r = new Regex(@"List price");  // find beginning of word "List price"
        //    m = r.Match(BookInfo, 1);
        //    if (m.Success)
        //    {
        //        r1 = new Regex(@"<td><font face=""arial"" size=2>");  //  find actual price
        //        m1 = r1.Match(BookInfo, m.Index + 10);
        //        r2 = new Regex(@"</td>");  //  end of price
        //        m2 = r2.Match(BookInfo, m1.Index + 30);
        //        r = new Regex(@"\$");
        //        m = r.Match(BookInfo, m1.Index + 34, 2);
        //        if (m1.Success && m2.Success && m.Success)
        //            lListPrice.Text = "List Price (New): " + BookInfo.ToString().Substring(m1.Index + 34, m2.Index - (m1.Index + 37));
        //        else
        //            lListPrice.Text = "List Price (New): n/a";
        //    }

        //    int lastIndex = m1.Index;
        //    for (i = 2; i < 33; i++)  //  look for first entry
        //    {
        //        r = new Regex(@"color=teal><b>");  // find beginning of dealer
        //        m = r.Match(BookInfo, lastIndex);
        //        r1 = new Regex(@"</b></font></a>&nbsp;");  // find end of dealer
        //        m1 = r1.Match(BookInfo, m.Index + 14);
        //        if (m.Success && m1.Success)
        //        {
        //            name = BookInfo.Substring(m.Index + 14, m1.Index - (m.Index + 14));
        //            name = Regex.Replace(name, @"<b>|</b>", "");  //  remove the garbage
        //            lbPricingResults.Items.Add(name);

        //            r = new Regex(@"color=darkgreen><b>");  // find beginning of price
        //            m = r.Match(BookInfo, m1.Index + 14);
        //            r1 = new Regex(@"</b></font>&nbsp;");  //  find end of price
        //            m1 = r1.Match(BookInfo, m.Index + 19);

        //            price = BookInfo.Substring(m.Index + 19, m1.Index - (m.Index + 19));
        //            try
        //            {
        //                accumulatedPrice += Convert.ToDecimal(price.Replace('$', ' '));
        //            }
        //            catch (System.InvalidCastException)
        //            {
        //                ;  //  do nothing
        //            }

        //            lbPrice.Items.Add(price);
        //            lbPrice.RightToLeft = RightToLeft.Yes;
        //            lastIndex = m.Index;
        //        }
        //        else
        //            break;

        //    }  //  end for

        //    int divisor = i - 2;

        //    decimal holdingAmount = accumulatedPrice / divisor;
        //    lAveragePrice.Text = "Average price: $" + decimal.Round(holdingAmount, 2);

        //    return 0;
        //}


        ////------------------------------------------------------------------------------------
        //private String readCampusiBookInfo(string ISBN)
        //{
        //    //traceSource.TraceEvent(TraceEventType.Start, 642, "starting readCampusiBookInfo");

        //    Cursor.Current = Cursors.AppStarting;

        //    StringBuilder page = new StringBuilder();
        //    byte[] buf = new byte[8192];

        //    HttpWebRequest request = (HttpWebRequest)
        //        //  WebRequest.Create("http://www.campusi.com/bookFind/asp/bookFindPrefindLst.asp?srchTxtIsbn=" + ISBN);
        //    WebRequest.Create("http://www.campusi.com/bookFind/asp/bookFindPriceLst.asp?prodId=" + ISBN);
        //    HttpWebResponse response = (HttpWebResponse)
        //    request.GetResponse();

        //    Stream resStream = response.GetResponseStream();
        //    string tempString = null;
        //    int count = 0;
        //    do
        //    {
        //        count = resStream.Read(buf, 0, buf.Length);  // fill the buffer with data
        //        if (count != 0)  // make sure we read some data
        //        {
        //            tempString = Encoding.ASCII.GetString(buf, 0, count);  // translate from bytes to ASCII text
        //            page.Append(tempString);  // continue building the string
        //        }
        //    }
        //    while (count > 0);

        //    //traceSource.TraceEvent(TraceEventType.Stop, 669, "returning from readCampusiBookInfo");

        //    Cursor.Current = Cursors.Default;
        //    return (page.ToString());  //  next, page has to be parsed for prices and any errors

        //}  //  end readFindBookPricesHtmlPage



        ////----------------------------------------------------------------------------------------------
        //public int parseCampusiBookInfo(string BookInfo)
        //{
        //    //traceSource.TraceEvent(TraceEventType.Start, 681, "starting parseCampusiBookInfo");

        //    int lastIndex = 0;

        //    /*
        //    <b>Title:</b></td><td colSpan=3><font face="arial" size=2><b><font color=blue>
        //    */

        //    //  Title
        ////    r = new Regex("title=\"");  //  find beginning
        //    r = new Regex(@"<b>Title:</b></td><td colSpan=3><font face=""arial"" size=2><b><font color=blue>");
        //    m = r.Match(BookInfo, lastIndex);
        //    r1 = new Regex(@"</font>");  // find end of title
        //    m1 = r1.Match(BookInfo, m.Index + 78);
        //    if (m.Success && m1.Success)
        //    {
        //        tbTitle.Text = BookInfo.Substring(m.Index + 7, m1.Index - (m.Index + 7));  //  move to text box
        //        tbTitle.Text.Replace("&amp;", "and");  //  now replace "&amp;" with a pure ampersand 
        //    }

        //    if (tbTitle.Text.Length == 0)
        //    {
        //        lNotFound.Visible = true;
        //        return -1;
        //    }

        //    //  Author
        //    r = new Regex("search by author\">");  // find beginning
        //    m = r.Match(BookInfo, m1.Index + 7);
        //    r1 = new Regex(@"</a>&nbsp;");  //  find end
        //    m1 = r1.Match(BookInfo, m.Index + 18);
        //    if (m.Success && m1.Success)
        //    {
        //        tbAuthor.Text = BookInfo.Substring(m.Index + 18, m1.Index - (m.Index + 18));  //  move to text box
        //        tbAuthor.Text.Replace("&amp;", "and");  //  now replace "&amp;" with a pure ampersand 
        //    }

        //    //  Publisher
        //    r = new Regex("<br>Publisher: ");  // find beginning
        //    m = r.Match(BookInfo, m1.Index + 10);
        //    r1 = new Regex(@"<br>");  //  find end
        //    m1 = r1.Match(BookInfo, m.Index + 15);
        //    if (m.Success && m1.Success)
        //        tbPub.Text = BookInfo.Substring(m.Index + 15, m1.Index - (m.Index + 15));  //  move to text box

        //    //  Edition
        //    r = new Regex("<br>Edition:");  // find beginning
        //    m = r.Match(BookInfo, m1.Index);
        //    r1 = new Regex(@"<br>");  //  find end
        //    m1 = r1.Match(BookInfo, m.Index + 12);
        //    if (m.Success && m1.Success)
        //        if (BookInfo.Substring(m.Index + 13, m1.Index - (m.Index + 13)) != "Older Edition")
        //            coEdition.Text = BookInfo.Substring(m.Index + 12, m1.Index - (m.Index + 12));  //  move to text box

        //    //  Date Published
        //    r = new Regex("<br>Date published: ");  // find beginning
        //    m = r.Match(BookInfo, m1.Index);
        //    r1 = new Regex(@"<br>");  //  find end
        //    m1 = r1.Match(BookInfo, m.Index + 4);
        //    if (m.Success && m1.Success)
        //        tbYear.Text = BookInfo.Substring(m.Index + 20, 4);  //  move to text box

        //    //  Format (hardcover, etc)
        //    r = new Regex(@"<br>Format: ");  // find beginning
        //    m = r.Match(BookInfo, m1.Index);
        //    r1 = new Regex(@"<br>");  //  find end
        //    m1 = r1.Match(BookInfo, m.Index + 12);
        //    if (m.Success && m1.Success)
        //        coBinding.Text = BookInfo.Substring(m.Index + 12, m1.Index - (m.Index + 12));  //  move to text box
        //    if (coBinding.Text == "Paperback")
        //        coBinding.Text = "Trade Paperback";


        //    //  Number of pages
        //    r = new Regex("<br>Number of pages:");  // find beginning
        //    m = r.Match(BookInfo, m1.Index);
        //    r1 = new Regex(@"<br>");  //  find end
        //    m1 = r1.Match(BookInfo, m.Index + 20);
        //    //string mIndexData = BookInfo.Substring(m.Index, 20);  //  TESTING ONLY!
        //    //string m1IndexData = BookInfo.Substring(m1.Index, 20);  //  TESTING ONLY!
        //    if (m.Success && m1.Success)
        //        tbDesc.Text = BookInfo.Substring(m.Index + 4, m1.Index - (m.Index + 4));  //  move to text box

        //    lbStatus.Items.Insert(0, "completed parsing");
        //    lbStatus.Refresh();
        //    panel2.Refresh();  //  let's show it while waiting for pricing

        //    return 0;
        //}

    }  //  end partial class Form1

}  //  end Namespace

//http://www.findbookprices.com/search/?isbn=basic+mathematics+for+aviation
