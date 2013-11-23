
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Media_Inventory_Manager
{
    public class BestWebBuysDotCom  //  has no media info; prices are very good
    {

        Regex r, r1;
        Match m, m1;
        string mediaInfo;
        static TraceSource traceSource = new TraceSource("prager");  //  for tracing mainForm

        //--  used for getting prices from the internet
        public bool getMediaPrices(string UPC, mainForm.mediaData bD) {
            if (UPC.Length == 12 || UPC.Length == 13)
                mediaInfo = readMediaInfo(UPC);
            else
                return false;

            return (parseMediaInfoForPricesAndVenues(UPC, mediaInfo, bD));  //  returns false if no data, else puts data in structure

        }

        //--  goes to BestWebBuys and scrape the book information
        private string readMediaInfo(string isbn) {
            Cursor.Current = Cursors.AppStarting;

            System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;

            Uri uri = new Uri("http://www.bestwebbuys.com/music/compare/upc/" + isbn);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Referer = "http://www.moreprices.com/";

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


        public int ndx1 = 0;  //  indicates how many prices there were 

        //--  used for automatic pricing of books
        private bool parseMediaInfoForPricesAndVenues(string UPC, string mediaInfo, mainForm.mediaData bD) {
            ndx1 = 0;
            //string debuggingData = "";
            string pricingData = "";
            bD.UPC = UPC;  //  might as well, since we're here anyway...

            if (mediaInfo.Contains("we did not find this book for sale at"))
                return false;

            if (mediaInfo.Contains("Oops...there was a problem with"))
                return false;

            if (mediaInfo.Contains("Server Error in '/' Application.") || mediaInfo.Contains("server-error") || mediaInfo.Contains("Bad Request (Invalid Hostname)") ||
                mediaInfo.Contains("Unable to read data from the transport connection")) {
                MessageBox.Show("There is a problem with the server that gets book information.\n" +
                    "Please try again later.  We are sorry for the inconvenience.", "Prager Book Inventory Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            r = new Regex("product:listPrice\">");  //  find starting point of List Price:
            m = r.Match(mediaInfo, 0);
            if (m.Success) {
                r1 = new Regex("</span><br />");  //  find end of List Price:
                m1 = r1.Match(mediaInfo, m.Index + 19);
                if (m.Success && m1.Success) {
                    string debugString = mediaInfo.Substring(m.Index + 19, m1.Index - (m.Index + 19));
                    if (mediaInfo.Substring(m.Index + 19, 1) == "$")
                        bD.listPrice = decimal.Parse(mediaInfo.Substring(m.Index + 20, m1.Index - (m.Index + 20)));
                    else
                        bD.listPrice = decimal.Parse(mediaInfo.Substring(m.Index + 19, m1.Index - (m.Index + 19)));

                }
            }
            else
                bD.listPrice = 0.0M;

            //--  now do selling prices
            r1 = new Regex(">Total Cost</th>");  //  find starting point of selling prices
            m1 = r1.Match(mediaInfo, 0);
            if (m1.Success) {
                do  //  now, go through each store and price  
                {
                    r = new Regex("target=\"");   //  find beginning of store name
                    m = r.Match(mediaInfo, m1.Index);
                    if (m.Success)  //  found it...
                    {
                        //string workingName = "";
                        r1 = new Regex(" title=");  //  M1 -> end of store name
                        m1 = r1.Match(mediaInfo, m.Index + 8);

                        if (m.Success && m1.Success)  //  store name was found...
                        {
                            mainForm.pricingData pD = new mainForm.pricingData();  //  new instance

                            pD.venueName = mediaInfo.Substring(m.Index + 8, m1.Index - (m.Index + 9));  // move name of store

                            //  find beginning of price 
                            r = new Regex("\\$");
                            m = r.Match(mediaInfo, m1.Index + 7, 500);  //  m1 -> end of store name
                            if (m.Success) {  //  m -> beginning of price
                                r1 = new Regex("<span class=");
                                m1 = r1.Match(mediaInfo, m.Index, 30);
                                if (m1.Success) //  m1 -> end of price
                                    pricingData = mediaInfo.Substring(m.Index, m1.Index - (m.Index));  //  includes $ sign
                            }

                            if (m.Success && m1.Success) {  //  beginning and end of price for this store was found...
                           
                                pD.price = pricingData;

                                //-->    (<span class="glossary_term2">Used</span>)
                                ////  now try to find the book condition (new or used)
                                //r2 = new Regex("tinyred");   //  now, look for book condition (new or used in pos 82)
                                //m2 = r2.Match(mediaInfo, m1.Index + 40, 80);  //  (m1.Index points to end of price)
                                //debuggingData = mediaInfo.Substring(m1.Index + 40, 80);
                                //if (m2.Success)  //  m.Index now points to "tinyred"
                                //{
                                //    if (debuggingData.Contains("International Edition") || debuggingData.Contains("Edition Unknown"))
                                //        break;  //  we're done...

                                //    r3 = new Regex(@"'");  //  find end of book condition
                                //    m3 = r3.Match(mediaInfo, m2.Index + 42, 24);
                                //    //debuggingData2 = mediaInfo.Substring(m.Index + 42, 30);
                                //    if (m3.Success)
                                //    {
                                //        conditionData = mediaInfo.Substring(m2.Index + 42, (m3.Index) - (m2.Index + 42));
                                //        switch (conditionData)
                                //        {
                                //            case "likenew":
                                //            case "used":
                                //            case "marketplace":
                                //            case "acceptable":
                                //            case "verygood":
                                //            case "good":
                                //            case "sale":
                                //            case "collectible":
                                //                pD.bookCondn = 'u';
                                //                break;
                                //            case "new":
                                //            case "memberprice":
                                //            case "brandnew":
                                //            case "clubprice":
                                //                pD.bookCondn = 'n';
                                //                break;
                                //            default:
                                //                pD.bookCondn = 'u';
                                //                //MessageBox.Show("unknown condition: " + conditionData + ", ISBN: " + ISBN, "Prager Book Inventory Manager",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                //                break;
                                //        }
                                //    }
                                //    else
                                //        pD.bookCondn = 'u';  //  default if not indicated
                            }
                            //}
                            string key = pD.venueName + "." + pD.price + "." + pD.itemCondn;
                            if (!bD.mediaList.ContainsKey(key))
                                bD.mediaList.Add(key, pD);
                        }
                    }
                    //r2 = new Regex(" target=\"");
                    //m2 = r2.Match(mediaInfo, m2.Index + 100);  //  adjust index to point past current store

                    //if (m2.Index == 0 || ndx1 > 999)
                    //    break;  //  we're done!

                } while (m1.Success && m.Success);

                return true;
            }
            return false;
        }
    }  
}  