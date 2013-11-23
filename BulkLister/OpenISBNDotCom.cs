using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace BulkAddBooks
{
    public class OpenISBNDotCom
    {

        private string page;

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++
        //-  main routine - getBookInfo
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++
        //public bool getBookInfo(MaskedTextBox isbn, TextBox tbTitle, TextBox tbAuthor, TextBox tbPub,
        //   TextBox tbPages, TextBox tbYear, ComboBox coBinding, ComboBox coEdition) {
        public bool getBookInfo(string isbn, string tbTitle, string tbAuthor, string tbPub,
                               string tbPages, string tbYear, string coBinding, string coEdition) {


            page = readOpenISBNDotCom(isbn);  //  really mtbISBN.Text
            bool rc = parseReturnData(page);
            return rc;

        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++
        //-  read OpenISBN.com
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++
        private string readOpenISBNDotCom(string isbn) {

            Cursor.Current = Cursors.AppStarting;

            System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;

            Uri uri = new Uri("http://www.openisbn.com/isbn/" + isbn + "/");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Referer = "http://www.openisbn.com";
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


        //++++++++++++++++++++++++++++++++++++++++++++++++++++
        //-  parseReturnData
        //++++++++++++++++++++++++++++++++++++++++++++++++++++
        private bool parseReturnData(string page) {

            Regex r, r1 = null;
            Match m, m1 = null;

            r = new Regex("404 - Page Not Found - OPENISBN");
            m = r.Match(page, 0);
            if (m.Success)
                return false;


            //--  title
            r = new Regex("border=0 *title=\"");  //  get start of title
            m = r.Match(page, 0);
            if (m.Success) {
                r1 = new Regex("></div>");  //  find end of title
                m1 = r1.Match(page, m.Index + 16);
                if (m1.Success) {
                    string tempTitle = page.Substring(m.Index + 16, m1.Index - (m.Index + 17));  //  move title
                    tempTitle = tempTitle.Replace("&amp;", @"&");
                    tempTitle = tempTitle.Replace("'", "''");
                    mainForm.Title = tempTitle.Length < 100 ? tempTitle : tempTitle.Substring(0, 100);
                }
            }

            //-- author
            r = new Regex(@"></div>Authors?:? ");  //  get start of "Authors:"
            m = r.Match(page, m1.Index);
            if (m.Success) {
                r1 = new Regex("/\">");  //  find start of actual author's name
                m1 = r1.Match(page, m.Index + 16);
                if (m1.Success) {
                    r = new Regex("</a>[<BR>]?");  //  find end of author
                    m = r.Match(page, m1.Index + 3);
                    if (m.Success) {
                        string tempAuthor = page.ToString().Substring(m1.Index + 3, m.Index - (m1.Index + 3));
                        mainForm.Author = tempAuthor.Replace("'", "''");
                    }
                }
            }

            //--  publisher
            //     </a>, <BR>Publisher: <a href="/publisher/Pfeiffer/">Pfeiffer</a><BR>    (0787988502)
            //     </a><BR>Publisher: <a href="/publisher/Ballantine_Books/">Ballantine Books</a><BR>    (0345377443)
            r = new Regex(@"</a>,? *]?<BR>Publisher: ");  //  get start of "Publisher:"
            m = r.Match(page, m1.Index);
            if (m.Success) {
                r1 = new Regex("/\">");  //  find start of actual publisher's name
                m1 = r1.Match(page, m.Index + 16);
                if (m1.Success) {
                    r = new Regex("</a><BR>");  //  find end of publisher
                    m = r.Match(page, m1.Index + 3);
                    if (m.Success) {
                        string tempPub = page.Substring(m1.Index + 3, m.Index - (m1.Index + 3));
                        mainForm.Pub = tempPub.Replace("'", "''");
                    }
                }
            }

            //--  pages
            r = new Regex(@"<BR>Pages: ");  //  get start of "Pages:"
            m = r.Match(page, m1.Index + 3);
            if (m.Success) {
                r1 = new Regex("<BR>");  //  find end of publisher
                m1 = r1.Match(page, m.Index + 11);
                if (m1.Success)
                    mainForm.Pages = page.Substring(m.Index + 11, m1.Index - (m.Index + 11));
            }

            //--  year published
            r = new Regex(@"<BR>Published: ");  //  get start of "Published:"
            m = r.Match(page, m1.Index);
            if (m.Success) {
                r1 = new Regex("<BR>");  //  find end of date
                m1 = r1.Match(page, m.Index + 11);
                if (m1.Success) {
                    string tempDate = page.Substring(m.Index + 15, m1.Index - (m.Index + 15));  //  move yyyy-dd-mm
                    mainForm.PubDate = tempDate.Substring(0, 4);  //  move just the year
                }
            }

            //--  binding
            r = new Regex(@"<BR>Binding: ");  //  get start of "Binding:"
            m = r.Match(page, m1.Index);
            if (m.Success) {
                r1 = new Regex("<BR>");  //  find end of date
                m1 = r1.Match(page, m.Index + 13);
                if (m1.Success) {
                    string tempBinding = page.Substring(m.Index + 13, m1.Index - (m.Index + 13));  //  move binding
                    int parenNdx = tempBinding.LastIndexOf("(");  //  remove any garbage
                    mainForm.Binding = (parenNdx == -1) ? tempBinding : tempBinding.Substring(0, parenNdx);
                }
            }

            return true;
        }
    }
}
