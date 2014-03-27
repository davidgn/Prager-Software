//#define EXPORTTESTING

#region Using directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using FirebirdSql.Data.FirebirdClient;
using MarketplaceWebServiceProducts;
using MarketplaceWebServiceProducts.Model;
using MarketplaceWebService;
using MarketplaceWebService.Model;

#endregion




namespace Media_Inventory_Manager
{

    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //--    Amazon Web Services
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class AmazonWebServices
    {

        internal struct sData
        {
            internal string alPrice;
            internal string alVenueName;
            internal char alCondn;
        };

        class SDataComparer : IComparer<sData>
        {
            public int Compare(sData x, sData y) {
                int result = decimal.Parse(x.alPrice).CompareTo(decimal.Parse(y.alPrice));
                if (result != 0) {
                    return result;
                }
                result = x.alVenueName.CompareTo(y.alVenueName);
                if (result != 0) {
                    return result;
                }
                return x.alCondn.CompareTo(y.alCondn);
            }
        }

        public int ndx1 = 0;  //  indicates how many prices there were


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    routine to get media prices from Amazon.com
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public bool getPricesFromAmazon(mainForm.mediaData bD, string UPC, char itemCondn, string AWSKey, string AWSSecretKey,
                        TabControl tabTaskPanel, int cWebPages, string AssocTag) {
            HttpWebResponse response = null;
            string replyFromHost = " ";
            StreamReader sr = null;
            string errorMsg = "";
            string requestString = "";
            //string myAmazonAccessKey = "";  //  "084BT0EPNB27A07DGR82";
            //string myAmazonSecretKey = "";  //"Gk0QGlcORtiSZQxqGiifKyiarqmyf9jcS1U/5Eyw";


            WebBrowser webBrowser2 = new WebBrowser();
            List<sData> alData = new List<sData>();

            /*
            Service=AWSECommerceService
            Version=2011-08-01
            Operation=ItemLookup
            ItemId=0345377443
            Condition=Used
            IdType=ISBN
            SearchIndex=Books 
            MerchantID=All
            Offers=Medium
            Timestamp=2011-10-12T17:51:30.000Z
            AWSAccessKeyId=084BT0EPNB27A07DGR82
             * 
            * */

            //try {
            // create a FtpWebRequest object  
            if (UPC.Substring(0, 1).ToLower() != "b") {  //  it's an UPC                {
                if (itemCondn == 'n')  //  only new
                    requestString =
                        "Service=AWSECommerceService&Version=2011-08-01&Operation=ItemLookup" +
                        "&ItemId=" + UPC + "&AssociateTag=" + AssocTag +
                        "&IdType=UPC&Condition=New&OfferPage=1" +
                        "&SearchIndex=Music&MerchantId=All&ResponseGroup=Medium,Offers";
                else if (itemCondn == 'u')  //  only used
                    requestString =
                          "Service=AWSECommerceService&Version=2011-08-01&Operation=ItemLookup" +
                         "&ItemId=" + UPC + "&AssociateTag=" + AssocTag +
                         "&IdType=UPC&Condition=Used&OfferPage=1" +
                         "&SearchIndex=Music&MerchantId=All&ResponseGroup=Medium,Offers";
                else if (itemCondn == 'b')  //  get new and used
                    requestString =
                        "Service=AWSECommerceService&Version=2011-08-01&Operation=ItemLookup" +
                        "&ItemId=" + UPC + "&AssociateTag=" + AssocTag +
                        "&IdType=UPC&Condition=All&OfferPage=1" +
                        "&SearchIndex=Music&MerchantId=All&ResponseGroup=Medium,Offers";
            }
            else {
                if (itemCondn == 'n')  //  only new
                    requestString =
                        "Service=AWSECommerceService&Version=2011-08-01&Operation=ItemLookup" +
                        "&ItemId=" + UPC + "&AssociateTag=" + AssocTag +
                        "&IdType=ASIN&Condition=New&OfferPage=1" +
                        "&SearchIndex=Music&MerchantId=All&ResponseGroup=Medium,Offers";
                else if (itemCondn == 'u')  //  only used
                    requestString =
                        "Service=AWSECommerceService&Version=2011-08-01&Operation=ItemLookup" +
                        "&ItemId=" + UPC + "&AssociateTag=" + AssocTag +
                        "&IdType=ASIN&Condition=Used&OfferPage=1" +
                        "&SearchIndex=Music&MerchantId=All&ResponseGroup=Medium,Offers";
                else if (itemCondn == 'b')  //  get new and used
                    requestString =
                      "Service=AWSECommerceService&Version=2011-08-01&Operation=ItemLookup" +
                       "&ItemId=" + UPC + "&AssociateTag=" + AssocTag +
                       "&IdType=ASIN&Condition=All&OfferPage=1" +
                        "&SearchIndex=Music&MerchantId=All&ResponseGroup=Medium,Offers";
            }

            SignedRequestHelper helper = new SignedRequestHelper(AWSKey, AWSSecretKey, "ecs.amazonaws.com");
            string requestURL = helper.Sign(requestString);
            WebRequest request = HttpWebRequest.Create(requestURL);

            request.Timeout = 30000;  //  30 seconds
            System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;  //  needed for bug in .NET 2.0

            try {
                response = (HttpWebResponse)request.GetResponse();   // get the response object
            }
            catch (Exception ex) {
                if (ex.Message.Contains("(400) Bad Request")) {
                    MessageBox.Show("Amazon returned an error: (400 - Bad Request).  If this continues, please notify Support at pragersoftware.com",
                    "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                    if (ex.Message.Contains("The remote name could not be resolved")) {
                        MessageBox.Show("Your internet connection appears to be down.  If this continues, please notify Support at pragersoftware.com",
                        "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else {
                        MessageBox.Show("Amazon has responded with an error: " + ex.Message + " please send this message to support@pragersoftware.com",
                        "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
            }

            // to read the contents of the file, get the ResponseStream
            sr = new StreamReader(response.GetResponseStream());
            try {
                replyFromHost = sr.ReadToEnd();  //  <------ this is where we can see what came back
            }
            catch (Exception ex) {
                if (ex.Message.Contains("Unable to read data from the transport connection")) {
                    MessageBox.Show("Amazon connection is unavailable; please try again in a few minutes", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            //  now read the initial XML data returned by Amazon.com
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(replyFromHost);

            //  check for errors
            XmlNodeList error = doc.GetElementsByTagName("Error");
            foreach (XmlNode node in error) {
                XmlElement mediaElement = (XmlElement)node;
                errorMsg = mediaElement.GetElementsByTagName("Message")[0].InnerText;
                if (errorMsg.Contains("is not a valid value for ItemId"))
                    return false;
                else {
                    MessageBox.Show("AWS Error: " + errorMsg, "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            //  now get the sales rank data
            string url = "";
            XmlNodeList salesRank = doc.GetElementsByTagName("SalesRank");
            //public int salesrank = 0;
            foreach (XmlNode node in salesRank) {
                bD.salesRank = int.Parse(doc.GetElementsByTagName("SalesRank")[0].InnerText);
            }

            //  now get the offer data
            XmlNodeList offers = doc.GetElementsByTagName("Offers");
            foreach (XmlNode node in offers) {
                XmlElement mediaElement = (XmlElement)node;
                url = mediaElement.GetElementsByTagName("MoreOffersUrl")[0].InnerText;
                if (url.Length == 1)
                    return false;  //  <---------------------------- TODO
            }

            //  go to the url and get the data for screen scraping
            System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;

            Uri uri = new Uri(url);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.Referer = "http://www.pragersoftware.com/";

            req.KeepAlive = false;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = 0;
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";

            string page = string.Empty;  //  clear it...
            try {
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream responseStream = resp.GetResponseStream();
                StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
                page = readStream.ReadToEnd();
            }
            catch (Exception ex) {
                if (ex.Message.Contains("Unable to read data from the transport connection"))
                    return false;
                else if (ex.Message.Contains("(503) Server Unavailable.")) {
                    MessageBox.Show("Remote server is unavailable; try in a few minutes", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            //  we got it, now scrape it for prices, etc.
            Regex r, r1;
            Match m, m1;
            int nbrOfOffers = 0;

            r = new Regex(@"class=""numberofresults"">");  //  get number of results
            m = r.Match(page, 0);
            if (m.Success) {
                r1 = new Regex("offers");
                m1 = r1.Match(page, m.Index + 24);  //  look for "offers"
                if (m1.Success) {
                    nbrOfOffers = int.Parse(page.Substring(m1.Index - 3, 3));  //  only picks up TWO (2) digits!
                }
            }

            int startingIndex = 31460;
            do {
                mainForm.pricingData pD = new mainForm.pricingData();  //  new instance
                sData sD = new sData();  //  one for each seller

                r = new Regex(@"<tbody class=""result"">");  //  new entry starts here
                m = r.Match(page, startingIndex);

                if (m.Success) {
                    r1 = new Regex(@"class=""price"">");  //  find start of price
                    m1 = r1.Match(page, m.Index + 30);
                    if (m1.Success) {  //  we found start of price
                        r = new Regex(@"</span>");  //  end of price
                        m = r.Match(page, m1.Index);
                        if (m.Success) {  //  save price
                            sD.alPrice = page.Substring(m1.Index + 15, m.Index - (m1.Index + 15));  //  was 14
                        }
                    }

                    r1 = new Regex(@"<div class=""condition"">");  //  find condition
                    m1 = r1.Match(page, m.Index);
                    if (m1.Success) {
                        r = new Regex(@"</div>");  //  end of condition
                        m = r.Match(page, m1.Index);
                        if (m.Success) {  //  save price
                            string conditionData = page.Substring(m1.Index + 23, m.Index - (m1.Index + 23));
                            switch (conditionData) {  //  <--------------------- TODO  (elaborate in display)
                                case "Used\n - Like New\n":
                                case "Used":
                                //case "marketplace":
                                case "Used\n - Acceptable\n":
                                case "Used\n - Very Good\n":
                                case "Used\n - Good\n":
                                //case "sale":
                                case "Collectible\n - Like New\n":
                                    sD.alCondn = 'u';
                                    break;
                                case "New":
                                    //case "memberprice":
                                    //case "brandnew":
                                    //case "clubprice":
                                    sD.alCondn = 'n';
                                    break;
                                default:
                                    sD.alCondn = 'u';
                                    break;
                            }
                        }
                    }

                    r = new Regex(@">Seller:</span>");  //  get in the area of seller name
                    m = r.Match(page, m1.Index);
                    if (m.Success) {
                        r1 = new Regex(@"><b>");  //  beginning of seller name
                        m1 = r1.Match(page, m.Index + 170);
                        if (m1.Success) {
                            r = new Regex(@"</b>");  //  end of seller name
                            m = r.Match(page, m1.Index);
                            if (m.Success) {
                                sD.alVenueName = page.Substring(m1.Index + 4, m.Index - (m1.Index + 4));
                            }
                        }
                    }

                    alData.Add(sD);  //  put it into the array
                }


                startingIndex = m.Index + 14000;  //  get in area of next "result" phrase

            } while (m.Index != 0);                              //(startingIndex < (page.Length - 14350));

            //  now, put the elements in the dictionary...  
            //         alData.Sort(new SDataComparer());  //  sort the struct's

            // do stuff with stuff.alVenueName
            sData stuff;
            for (int k = 0; k < alData.Count; k++) {
                mainForm.pricingData pD = new mainForm.pricingData();  //  new instance
                stuff = alData[k];
                pD.venueName = stuff.alVenueName;
                pD.price = stuff.alPrice;
                pD.itemCondn = stuff.alCondn;

                string key = stuff.alVenueName + "." + stuff.alPrice + "." + stuff.alCondn;
                if (!bD.mediaList.ContainsKey(key))  //  if the vendor/price key is same, drop it...
                    bD.mediaList.Add(key, pD);
            }
            bD.UPC = UPC;
            //}
            //catch (WebException ex) {
            //    MessageBox.Show("Error from AWS: " + ex.Message, "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;

            //}

            return true;
        }
    }


    partial class mainForm : Form
    {
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create the amazon.com MUSIC export files
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        TextWriter azTextWriter;
        public int createAudioExportAmazonFormat(string formattedDate) {

            Cursor.Current = Cursors.WaitCursor;
            lbUploadStatus.Items.Insert(0, "Amazon.com format export started");
            lbUploadStatus.Refresh();

            if (rbExportAll.Checked == false && rbChangeDate.Checked == false && rbExportInclusiveSearch.Checked == false && rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            //if (cbPurgeReplace.Checked == true) {

            //    sFileName1 = exportPath + "purgeAZUPC" + formattedDate + ".txt";  //  doing a purge/replace?
            //}
            //else {
            sFileName1 = exportPath + "AZMu" + formattedDate + ".txt";  //  no just exporting those that were changed
            //}

            try {
                azTextWriter = new StreamWriter(sFileName1);  //  try to create the file
            }
            catch (Exception e) {
                if (e.ToString().Substring(10, 26) == "DirectoryNotFoundException") {
                    try {
                        DirectoryInfo di = Directory.CreateDirectory(exportPath);   // Try to create the directory

                        //  create the stream writers
                        azTextWriter = new StreamWriter(sFileName1);
                    }
                    catch (Exception e1) {
                        MessageBox.Show("Unable to create export directory: " + e1.Message, "Prager Media Inventory Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }

            createExportCommandString();

            //  write the header (new for MWS)
            azTextWriter.WriteLine(
                "sku\t" +
                "product-id\t" +
                "product-id-type\t" +
                "title\t" +
                "music-label\t" +
                "product-type\t" +
                "media-type\t" +
                "item-condition\t" +
                "price\t" +
                "quantity\t" +
                "item-note\t" +
                "description\t" +
                "main-image-url\t" +
                "publication-date\t" +
                "number-of-disks\t" +
                "language\t" +
                "expedited-shipping\t" +
                "will-ship-internationally\t" +
                "catalog-id-number\t" +
                "add-delete");

            //  find music media in table
            FbCommand command = new FbCommand(commandString, mediaConn);
            FbDataReader dr = command.ExecuteReader();
            int count = 0;

            while (dr.Read()) {
                tbSKU.Text = dr["SKU"].ToString();  //  for debugging purposes only!

                if (cbPurgeReplace.Checked == true && dr.GetString(25) == "Sold")
                    continue;  //  if purge/replace and Sold, don't upload

                if (dr.GetString(25) == "Hold")
                    continue;  //  don't export

                buildAmazonAudioTabFile(dr);  //  build an Amazon tab-delimited file, passing the DataReader
                count++;  //  increment counter
            }

            azTextWriter.Close();  //  close the stream
            //twStdAmazon.Close();

            if (dr != null)  //  close the data reader
                dr.Close();

            Cursor.Current = Cursors.Default;

            lbUploadStatus.Items.Insert(0, "Amazon.com format export(s) completed: " + count + " items exported to file " + sFileName1);
            lbUploadStatus.Refresh();

            return 0;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create a file for music in tab-delimited format
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void buildAmazonAudioTabFile(FbDataReader dr) {

            string dataBuild = "";

            dataBuild = dr["SKU"] + "\t";  //  SKU

            dataBuild += dr["UPC"] + "\t";  //  product-id (UPC)

            if (dr["UPC"].ToString().Length > 0) //  product-id type
                dataBuild += dr["UPC"].ToString().Length == 12 ? "3\t" : "4\t";  //  indicate ASIN or UPC
            else
                dataBuild += "\t";  //  UPC is missing

            dataBuild += dr["Title"] + "\t";  // title

            dataBuild += dr["MFGR"] + "\t";  // music label

            dataBuild += dr["ProductType"] + "\t";  //  product type

            dataBuild += dr["MediaType"] + "\t"; //  media type

            string tempCond = dr["Condn"].ToString();  //  item condition
            switch (tempCond.ToLower()) {
                case "new":
                case "as new":
                    //case "new book":
                    dataBuild += "11\t";  //  item is "new"
                    break;
                case "fine":
                case "fine - used":
                case "used: like new":  //  az
                    dataBuild += "1\t";  //  used; like new
                    break;
                case "very good":
                case "very good - used":
                case "used: very good":  //  az
                    dataBuild += "2\t";  //  used; very good
                    break;
                case "good":
                case "good - used":
                case "used: good":  //  az
                    dataBuild += "3\t";  //  used; good
                    break;
                case "fair":
                case "fair - used":
                case "poor":
                case "poor - used":
                case "used: acceptable":  //  az
                    dataBuild += "4\t";  //  used; acceptable
                    break;
                case "fine - collectible":
                case "collectible: like new":  //  az
                    dataBuild += "5\t";  //  collectible; like new
                    break;
                case "very good - collectible":
                case "collectible: very good":  //  az
                    dataBuild += "6\t";  //  collectible; very good
                    break;
                case "good - collectible":
                case "collectible: good":  //  az
                    dataBuild += "7\t";  //  collectible; good
                    break;
                case "fair - collectible":
                case "poor - collectible":
                case "collectible: acceptable":  //  az
                    dataBuild += "8\t";  //  collectible; acceptable
                    break;
                default:
                    dataBuild += "3\t";  //  default to "Used: Good"
                    break;
            }

            dataBuild += dr["Price"] + "\t";  //  price 

            dataBuild += dr["Quantity"] + "\t";  //  quantity

            dataBuild += dr["Notes"] + "\t";  //  item notes

            if (dr["Descr"] != DBNull.Value && dr["Descr"].ToString().Length > 0)
                dataBuild += dr["Descr"] + "\t";  //  description
            else
                dataBuild += "\t";  //  description is missing

            dataBuild += dr["ImageURL"] + "\t";  //  image URL

            if (dr["MfgrYear"].ToString().Length == 4)  //  pub date
                dataBuild += dr["MfgrYear"] + "-01-01\t";
            else
                dataBuild += "\t";

            dataBuild += dr["NbrOfDisks"] + "\t";  //  number of disks

            dataBuild += dr["Language"] + "\t";  //  language

            UInt16 target = 0;
            string shipVerbage = "";
            if (dr["Shipping"] != DBNull.Value) {  //  Shipping field exists... 

                target = ushort.Parse(dr["Shipping"].ToString());

                if ((target | 61) != 0) {  //  is there any expedited shipping?
                    shipVerbage = (target & 16) == 16 ? "Domestic," : "";  //  domestic expedited
                    shipVerbage += (target & 8) == 8 ? "Second," : "";  //  2nd day
                    shipVerbage += (target & 4) == 4 ? "Next," : "";  //  next day
                    shipVerbage += (target & 1) == 1 ? "International" : "";  //  Expedited

                    dataBuild += shipVerbage + "\t";  //  ending tab
                }
                else
                    dataBuild += shipVerbage + "n\t";  //  no expedited shipping

                dataBuild += ((target & 2) == 2) ? "y\t" : "n\t";  //  Intl' standard
            }
            else
                dataBuild += "n\tn\t";  //  only available to U.S. customers w/ no expedited shipping

            dataBuild += dr["CatalogID"] + "\t";  //  catalog ID

            if (dr["Stat"].ToString() == "Sold")  //  add-delete
                dataBuild += "d\t";  //  delete item from inventory
            else
                dataBuild += "a\t";  //  update/add item to inventory

            azTextWriter.WriteLine(dataBuild);  //  that's it... write the line out

            return;
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create the amazon.com Video export files
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //TextWriter azTextWriter;
        public int createVideoExportAmazonFormat(string formattedDate) {

            Cursor.Current = Cursors.WaitCursor;
            lbUploadStatus.Items.Insert(0, "Amazon.com format export started");
            lbUploadStatus.Refresh();

            if (rbExportAll.Checked == false && rbChangeDate.Checked == false && rbExportInclusiveSearch.Checked == false && rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            //if (cbPurgeReplace.Checked == true) {

            //    sFileName1 = exportPath + "purgeAZUPC" + formattedDate + ".txt";  //  doing a purge/replace?
            //}
            //else {
            sFileName1 = exportPath + "AZVi" + formattedDate + ".txt";  //  no just exporting those that were changed
            //}

            try {
                azTextWriter = new StreamWriter(sFileName1);  //  try to create the file
            }
            catch (Exception e) {
                if (e.ToString().Substring(10, 26) == "DirectoryNotFoundException") {
                    try {
                        DirectoryInfo di = Directory.CreateDirectory(exportPath);   // Try to create the directory

                        //  create the stream writers
                        azTextWriter = new StreamWriter(sFileName1);
                    }
                    catch (Exception e1) {
                        MessageBox.Show("Unable to create export directory: " + e1.Message, "Prager Media Inventory Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }

            createExportCommandString();

            //  write the header (new for MWS)
            azTextWriter.WriteLine(
                "sku\t" +
                "product-id\t" +
                "product-id-type\t" +
                "title\t" +
                "product-type\t" +
                "media-type\t" +
                "mpaa-rating\t" +
                "item-condition\t" +
                "price\t" +
                "quantity\t" +
                "item-note\t" +
                "description\t" +
                "studio\t" +
                "publication-date\t" +
                "number-of-disks\t" +
                "runtime\t" +
                "main-image-url\t" +
                "audio-encoding\t" +
                "language\t" +
                "subtitle-language1\t" +
                "expedited-shipping\t" +
                "will-ship-internationally\t" +
                "country-of-origin\t" +
                "add-delete");

            //  find music media in table
            FbCommand command = new FbCommand(commandString, mediaConn);
            FbDataReader dr = command.ExecuteReader();
            int count = 0;

            while (dr.Read()) {
                tbSKU.Text = dr["SKU"].ToString();  //  for debugging purposes only!

                if (cbPurgeReplace.Checked == true && dr.GetString(25) == "Sold")
                    continue;  //  if purge/replace and Sold, don't upload

                if (dr.GetString(25) == "Hold")
                    continue;  //  don't export

                if (dr["ProductType"].ToString().Length == 0 || dr["ProductType"].ToString().Substring(0, 5) == "Music")
                    continue;

                buildAmazonVideoTabFile(dr);  //  build an Amazon tab-delimited file, passing the DataReader
                count++;  //  increment counter
            }

            azTextWriter.Close();  //  close the stream
            //twStdAmazon.Close();

            if (dr != null)  //  close the data reader
                dr.Close();

            Cursor.Current = Cursors.Default;

            lbUploadStatus.Items.Insert(0, "Amazon.com format export(s) completed: " + count + " items exported to file " + sFileName1);
            lbUploadStatus.Refresh();

            return 0;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create a file for Video in tab-delimited format
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void buildAmazonVideoTabFile(FbDataReader dr) {

            string dataBuild = "";

            dataBuild = dr["SKU"] + "\t";  //  SKU

            dataBuild += dr["UPC"] + "\t";  //  product-id (UPC)

            if (dr["UPC"].ToString().Length > 0) //  product-id type
                dataBuild += dr["UPC"].ToString().Length == 12 ? "3\t" : "4\t";  //  indicate UPC or EAN
            else
                dataBuild += "\t";  //  UPC is missing

            dataBuild += dr["Title"] + "\t";  // title

            dataBuild += dr["ProductType"].ToString().Replace(" ", "") + "\t";  //  product type (remove spaces)

            dataBuild += dr["MediaType"] + "\t"; //  media type

            dataBuild += dr["MPAARating"] + "\t";  //  mpaa rating

            string tempCond = dr["Condn"].ToString();  //  item condition
            switch (tempCond.ToLower()) {
                case "new":
                case "as new":
                    //case "new book":
                    dataBuild += "11\t";  //  item is "new"
                    break;
                case "fine":
                case "fine - used":
                case "used: like new":  //  az
                    dataBuild += "1\t";  //  used; like new
                    break;
                case "very good":
                case "very good - used":
                case "used: very good":  //  az
                    dataBuild += "2\t";  //  used; very good
                    break;
                case "good":
                case "good - used":
                case "used: good":  //  az
                    dataBuild += "3\t";  //  used; good
                    break;
                case "fair":
                case "fair - used":
                case "poor":
                case "poor - used":
                case "used: acceptable":  //  az
                    dataBuild += "4\t";  //  used; acceptable
                    break;
                case "fine - collectible":
                case "collectible: like new":  //  az
                    dataBuild += "5\t";  //  collectible; like new
                    break;
                case "very good - collectible":
                case "collectible: very good":  //  az
                    dataBuild += "6\t";  //  collectible; very good
                    break;
                case "good - collectible":
                case "collectible: good":  //  az
                    dataBuild += "7\t";  //  collectible; good
                    break;
                case "fair - collectible":
                case "poor - collectible":
                case "collectible: acceptable":  //  az
                    dataBuild += "8\t";  //  collectible; acceptable
                    break;
                default:
                    dataBuild += "3\t";  //  default to "Used: Good"
                    break;
            }

            dataBuild += dr["Price"] + "\t";  //  price 

            dataBuild += dr["Quantity"] + "\t";  //  quantity

            dataBuild += dr["Notes"] + "\t";  //  item notes

            if (dr["Descr"] != DBNull.Value && dr["Descr"].ToString().Length > 0)
                dataBuild += dr["Descr"].ToString() + "\t";  //  description
            else
                dataBuild += "\t";  //  description is missing

            dataBuild += dr["MFGR"].ToString() + "\t";  // studio

            if (dr["MfgrYear"].ToString().Length == 4)  //  pub date
                dataBuild += dr["MfgrYear"].ToString() + "-01-01\t";
            else
                dataBuild += "\t";

            dataBuild += dr["NbrOfDisks"] + "\t";  //  number of disks

            dataBuild += dr["Runtime"].ToString() + "\t";  // runtime

            dataBuild += dr["ImageURL"] + "\t";  //  image URL

            dataBuild += dr["AudioEncoding"].ToString() + "\t";  // audio encoding

            dataBuild += dr["Language"] + "\t";  //  language

            dataBuild += dr["Subtitles"].ToString() + "\t";  // sub-title


            dataBuild += dr["Title"].ToString() + "\t";  // title

            UInt16 target = 0;
            string shipVerbage = "";
            if (dr["Shipping"] != DBNull.Value) {  //  Shipping field exists... 

                target = ushort.Parse(dr["Shipping"].ToString());

                if ((target | 61) != 0) {  //  is there any expedited shipping?
                    shipVerbage = (target & 16) == 16 ? "Domestic," : "";  //  domestic expedited
                    shipVerbage += (target & 8) == 8 ? "Second," : "";  //  2nd day
                    shipVerbage += (target & 4) == 4 ? "Next," : "";  //  next day
                    shipVerbage += (target & 1) == 1 ? "International" : "";  //  Expedited

                    dataBuild += shipVerbage + "\t";  //  ending tab
                }
                else
                    dataBuild += shipVerbage + "n\t";  //  no expedited shipping

                dataBuild += ((target & 2) == 2) ? "y\t" : "n\t";  //  Intl' standard
            }
            else
                dataBuild += "n\tn\t";  //  only available to U.S. customers w/ no expedited shipping

            dataBuild += dr["Origin"] + "\t";  //  country of origin

            if (dr["Stat"].ToString() == "Sold")  //  add-delete
                dataBuild += "d\t";  //  delete item from inventory
            else
                dataBuild += "a\t";  //  update/add item to inventory

            azTextWriter.WriteLine(dataBuild);  //  that's it... write the line out

            return;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    actual upload to Amazon.com
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int uploadAmazonFiles(string[] args) {

            //  instantiate implementation of MWS
            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            if (cbUploadAmazon.Checked)
                config.ServiceURL = @"https://mws.amazonservices.com";
            else if (cbUploadAmazonUK.Checked) {
                config.ServiceURL = @"https://mws.amazonservices.co.uk";
                AmazonUKUpload uk = new AmazonUKUpload();
                uk.uploadAmazonUKFiles(args, lbUploadStatus);
                return 0;
            }

            const string applicationName = "Prager Media";
            const string applicationVersion = "0.0.21";

            MarketplaceWebServiceClient service = new MarketplaceWebServiceClient(
                "AKIAIZEE34BK5NOX5SDA",  //  developer access key
                "37eqs33ahd+Vbrc2AR/OTXwnpEfuOkNr3kM6UO0G", //  developer secret key
                applicationName,
                applicationVersion, config);

            SubmitFeedRequest request = new SubmitFeedRequest();
            request.Merchant = tbMerchantID.Text;  //  user's merchant id
            request.MarketplaceIdList = new IdList();
            request.MarketplaceIdList.Id = new List<string>(new string[] { tbMarketplaceID.Text });  //  user's marketplace id

            request.FeedContent = File.Open(args[2], FileMode.Open, FileAccess.Read);
            request.ContentMD5 = MarketplaceWebServiceClient.CalculateContentMD5(request.FeedContent);
            request.FeedContent.Position = 0;  //  Calculating the MD5 hash value exhausts the stream; therefore we have to reset the position
            request.FeedType = "_POST_FLAT_FILE_INVLOADER_DATA_";
            if (cbUploadPurgeReplace.Checked)
                request.PurgeAndReplace = true;
            else
                request.PurgeAndReplace = false;

            try {
                SubmitFeedResponse response = service.SubmitFeed(request);  //  submit the feed...

                //config.SetUserAgentHeader(applicationName, applicationVersion, "C#", "Service", "Request");  //  ?????????

                //MarketplaceWebServiceClient service = new MarketplaceWebServiceClient(
                //    tbAWSKey.Text,  //  user's access key
                //    tbAWSSecretKey.Text, //  user's secret key
                //    applicationName, applicationVersion, config);

                //SubmitFeedRequest request = new SubmitFeedRequest();
                //request.Merchant = tbMerchantID.Text;  //  user's merchant id
                //request.MarketplaceIdList = new IdList();
                //request.MarketplaceIdList.Id = new List<string>(new string[] { tbMarketplaceID.Text });  //  user's marketplace id

                //request.FeedContent = File.Open(args[2], FileMode.Open, FileAccess.Read);
                //request.ContentMD5 = MarketplaceWebServiceClient.CalculateContentMD5(request.FeedContent);
                //request.FeedContent.Position = 0;  //  Calculating the MD5 hash value exhausts the stream; therefore we have to reset the position
                //request.FeedType = "_POST_FLAT_FILE_INVLOADER_DATA_";
                //if (cbUploadPurgeReplace.Checked)
                //    request.PurgeAndReplace = true;
                //else
                //    request.PurgeAndReplace = false;

                //try {
                //    SubmitFeedResponse response = service.SubmitFeed(request);  //  submit the feed...
                if (response.IsSetSubmitFeedResult()) {
                    SubmitFeedResult submitFeedResult = response.SubmitFeedResult;
                    if (submitFeedResult.IsSetFeedSubmissionInfo()) {
                        FeedSubmissionInfo feedSubmissionInfo = submitFeedResult.FeedSubmissionInfo;
                        if (feedSubmissionInfo.IsSetFeedSubmissionId()) {
                            lbUploadStatus.Items.Insert(0, "-->SubmissionID: " + feedSubmissionInfo.FeedSubmissionId);
                            Clipboard.SetText(feedSubmissionInfo.FeedSubmissionId);  //  copy it to the clipboard also 11.5.0

                        }
                    }
                }

            }
            catch (MarketplaceWebServiceException ex) {

                MessageBox.Show("MWS Exception: " + ex.Message + "\nResponse Status: " + ex.StatusCode +
                    "\nError Code: " + ex.ErrorCode + "\nError Type: " + ex.ErrorType + "\nRequest ID: " + ex.RequestId,
                    "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }

            return 0;
        }



        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    does a lookup on Amazon.com for media information
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public bool AmazonLookupData(string asin, string AWSKey, string AWSSecretKey) {

            if (tbAWSKey.Text.Length == 0 || tbAWSSecretKey.Text.Length == 0) {  //  if user doesn't have an Amazon Access Key, ask...
                if (MessageBox.Show("You need an Amazon Access Key or Secret Key; do you want to get them now?", "Prager Media Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(@"http://www.amazon.com/gp/aws/registration/registration-form.html");
                else  // no...
                    return false;
            }

            if (asin.Length == 0) {  
                MessageBox.Show("ASIN, UPC or EAN is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Valid Values: SKU | UPC | EAN | ISBN 
            //string idType = asin.Substring(0, 1) == "B" ? idType = "ASIN" : idType = "UPC";
            string idType = "";
            if (mtbASIN.Text.Length > 0) {
                idType = "ASIN";
                if (!InvokeItemSearch("ASIN", asin, AWSKey, AWSSecretKey))
                    return false;  //  we had an error (most likely, couldn't find the item)

            }
            else if (tbUPC.Text.Length > 0) {
                idType = "UPC";
                if (!InvokeItemSearch("UPC", asin, AWSKey, AWSSecretKey))   //  probably not found
                    return false;
            }

            return true;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    look for media and parse results
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private bool InvokeItemSearch(string idType, string UPC, string AWSKey, string MerchantID, string MarketplaceID,
        //    string AWSSecretKey) {

        //    Cursor.Current = Cursors.WaitCursor;

        //    //   Access Key ID and Secret Access Key ID
        //    String accessKeyId = AWSKey;
        //    String secretAccessKey = AWSSecretKey;
        //    String merchantId = MerchantID;
        //    String marketplaceId = MarketplaceID;

        //    const string applicationName = "PragerMediaInventory";
        //    const string applicationVersion = "13.111";

        //    MarketplaceWebServiceProductsConfig config = new MarketplaceWebServiceProductsConfig();
        //    config.ServiceURL = "https://mws.amazonservices.com/Products/2011-10-01";

        //    MarketplaceWebServiceProductsClient service = new MarketplaceWebServiceProductsClient(
        //        applicationName, applicationVersion, accessKeyId, secretAccessKey, config);

        //    GetMatchingProductForIdRequest request = new GetMatchingProductForIdRequest();

        //    //  set request parameters
        //    request.IdList = new IdListType();
        //    request.IdType = idType;
        //    request.IdList.Id = new List<string>();

        //    //  add the UPC to the list
        //    request.IdList.Id.Add(UPC);
        //    request.SellerId = merchantId;
        //    request.MarketplaceId = marketplaceId;

        //    GetMatchingProductForIdResponse response = service.GetMatchingProductForId(request);
        //    List<GetMatchingProductForIdResult> getMatchingProductResultList = response.GetMatchingProductForIdResult;

        //    // take the response and convert it to a XML string
        //    string xml = null;
        //    foreach (GetMatchingProductForIdResult getMatchingProductForIdResult in getMatchingProductResultList) {
        //        if (getMatchingProductForIdResult.IsSetProducts())  {                       //.IsSetProduct()) {
        //            ProductList products = getMatchingProductForIdResult.Products;

        //            //if (products.IsSetAttributeSets()) {  //  is attributes set?
        //            //    foreach (var attribute in products.AttributeSets.Any) {  //  send each XML element
        //            //        xml = ProductsUtil.FormatXml((System.Xml.XmlElement)attribute);
        //                }
        //            }
        //            //System.Diagnostics.Debug.WriteLine(xml);  //  DEBUGGING
        //        }
        //    }

        //    //  check for error...
        //    if (xml == null) {
        //        lNotFound.Visible = true;
        //        return false;
        //    }

        //    byte[] byteArray = Encoding.ASCII.GetBytes(xml);
        //    MemoryStream stream = new MemoryStream(byteArray);

        //    XmlTextReader reader = new XmlTextReader(stream);
        //    while (reader.Read()) {
        //        switch (reader.NodeType) {
        //            case XmlNodeType.Element:  //  the node is an element
        //                if (reader.Name == "ns2:ItemAttributes")
        //                    break;
        //                if (reader.Name == "ns2:Author") {
        //                    reader.Read();  //  get value
        //                    tbAuthor.Text = reader.Value;
        //                }
        //                if (reader.Name == "ns2:Binding") {
        //                    reader.Read();  //  get value
        //                    coBinding.Text = reader.Value;
        //                }
        //                if (reader.Name == "ns2:NumberOfPages") {
        //                    reader.Read();  //  get value
        //                    tbPages.Text = reader.Value;
        //                }
        //                if (reader.Name == "ns2:PublicationDate") {
        //                    reader.Read();  //  get value
        //                    tbYear.Text = reader.Value.Length > 0 ? reader.Value.Substring(0, 4) : "";
        //                }
        //                if (reader.Name == "ns2:Publisher") {
        //                    reader.Read();  //  get value
        //                    tbPub.Text = reader.Value;
        //                }
        //                if (reader.Name == "ns2:Title") {
        //                    reader.Read();  //  get value
        //                    tbTitle.Text = reader.Value.Replace("&amp;", "&");  //  (13.0.3)
        //                }
        //                break;
        //            default:
        //                break;
        //        }

        //        //System.Diagnostics.Debug.Write("<name: " + reader.Name + ">");
        //        //case XmlNodeType.Text:  //  display text in each element
        //        //    System.Diagnostics.Debug.Write("<value: " + reader.Value + ">");
        //        //    break;
        //        //case XmlNodeType.EndElement:  //  display the end of the element
        //        //    System.Diagnostics.Debug.Write("</" + reader.Name + ">\n\r");
        //        //    break;
        //    }

        //    bookDetailTab.Refresh();
        //    tbCopies.Text = tbCopies.Text.Length == 0 ? "1" : tbCopies.Text;  //  if it's empty, default to 1

        //    if (cbCreateKeywords.Checked && tbKeywords.Text.Length == 0 && int.Parse(tbCopies.Text) > 0 && !tbTitle.Text.Contains("No Title Found"))
        //        tbKeywords.Text = parseKeywords(tbTitle.Text);  //  update keywords if empty and still for sale

        //    Cursor.Current = Cursors.Default;
        //    if (doingAnAdd && bAddRecord.Enabled)  //  make sure it's allowed
        //        bAddRecord.BackColor = Color.OrangeRed;

        //    return true;  //  good return code
        //}

        private bool InvokeItemSearch(string idType, string asin, string AWSKey, string AWSSecretKey) {
        //    Cursor.Current = Cursors.WaitCursor;

        //    const string associateTag = "pragbook-20"; //"pragbook-20";
        //    string requestString = "";
        //    //string searchIndex = "";

        //    if (idType == "ASIN")
        //        requestString =
        //           "Service=AWSECommerceService" +
        //           "&Version=2011-08-01" +
        //           "&Operation=ItemLookup" +
        //           "&ItemId=" + asin +
        //           "&IdType=" + idType +
        //           "&MerchantId=All" +
        //           "&AssociateTag=" + associateTag +
        //           "&ResponseGroup=Medium";
        //    else {
        //        requestString =
        //            "Service=AWSECommerceService" +
        //            "&Version=2011-08-01" +
        //            "&Operation=ItemLookup" +
        //            "&ItemId=" + asin +  //  value of ASIN, UPC, EAN or ISBN
        //            "&IdType=" + idType +
        //            "&SearchIndex=Music" +
        //            "&MerchantId=All" +
        //            "&AssociateTag=" + associateTag +
        //            "&ResponseGroup=Medium";
        //    }


        //    SignedRequestHelper helper = new SignedRequestHelper(AWSKey, AWSSecretKey, @"ecs.amazonaws.com");
        //    string requestURL = helper.Sign(requestString);
        //    WebRequest request = HttpWebRequest.Create(requestURL);
        //    request.Timeout = 30000;  //  30 seconds
        //    System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;  //  needed for bug in .NET 2.0

        //    // get the response object
        //    HttpWebResponse response = null;
        //    try {
        //        response = (HttpWebResponse)request.GetResponse();
        //    }
        //    catch (Exception ex) {
        //        if (ex.Message.Contains("(403) Forbidden") || ex.Message.Contains("(400) Bad Request")) {
        //            MessageBox.Show("Invalid Amazon key(s); verify them and try again", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }
        //    }
        //    //ImageURL = "";  //  clear it...

        //    // to read the contents of the file, get the ResponseStream
        //    StreamReader sr = null;
        //    try {
        //        sr = new StreamReader(response.GetResponseStream());
        //    }
        //    catch (Exception ex) {
        //        if (ex.Message.Contains("unable to connect to the remote server")) {
        //            MessageBox.Show("Amazon.com appears to be busy; please try again", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return false;
        //        }
        //    }

        //    // Create an instance of XmlTextReader and call Read method to read the file
        //    XmlTextReader br = new XmlTextReader(sr);  //  was tr
        //    br.WhitespaceHandling = WhitespaceHandling.None;
        //    //XmlBookmarkReader br = new XmlBookmarkReader(tr);
        //    //string xx = getXmlTextReaderAsString(br);

        //    bool notFound = true;
        //    string musicType = "";

        //    try {
        //        br.Read();
        //        br.MoveToFirstAttribute();

        //        br.ReadToFollowing("Items");
        //        br.ReadToFollowing("Item");
        //        br.ReadToFollowing("ASIN");
        //        br.Read();
        //        mtbASIN.Text = br.Value;  //  move ASIN                }

        //        //  go to ImageSets to get the image URL
        //        br.ReadToFollowing("ImageSets");
        //        br.ReadToFollowing("ImageSet");
        //        br.ReadToFollowing("TinyImage");
        //        br.ReadToFollowing("URL");
        //        br.Read();
        //        tbImageURL.Text = br.Value;  //  move it to textbox

        //    }
        //    catch (Exception ex) {
        //        if (ex.Message.Contains("Root Element Missing") || ex.Message.Contains("Service Unavailable"))
        //            MessageBox.Show("Amazon is returning a message: 'Service Unavailable'; try again in a few minutes", "Prager Media Inventory Manager",
        //                MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    br.ReadToFollowing("ItemAttributes");
        //    while (br.Read()) {
        //        if (br.NodeType == XmlNodeType.Element && br.NodeType != XmlNodeType.EndElement)
        //            switch (br.LocalName) {
        //                case "Binding":
        //                    br.Read(); //  get value
        //                    if (br.Value.Contains("DVD"))
        //                        coProductType.Text = "Video DVD";
        //                    else if (br.Value.Contains("VHS"))
        //                        coProductType.Text = "Video VHS";
        //                    else if (br.Value.Contains("Audio"))
        //                        musicType = br.Value;
        //                    //  save this for after "creator" ?????????????????????                           
        //                    coMediaType.Text = br.Value;

        //                    if (br.Value.Contains("Video"))
        //                        tabSpecificInfo.SelectedIndex = 1; //  bring video to the front
        //                    else
        //                        tabSpecificInfo.SelectedIndex = 0; //  otherwise, make it audio
        //                    notFound = false;
        //                    break;
        //                case "EAN":
        //                case "UPC":
        //                    br.Read();
        //                    tbUPC.Text = br.Value;
        //                    break;
        //                case "Creator":
        //                    br.MoveToFirstAttribute();
        //                    if (br.Value == "Composer") {
        //                        br.Read();
        //                        if (tbComposer.Text.Length > 0 && !cbDontOverlay.Checked)
        //                            tbComposer.Text = br.Value;
        //                    }
        //                    if (br.Value == "Conductor") {
        //                        br.Read();
        //                        if (tbConductor.Text.Length > 0 && !cbDontOverlay.Checked)
        //                            tbConductor.Text = br.Value;
        //                    }
        //                    if (br.Value == "Orchestra") {
        //                        br.Read();
        //                        if (tbOrchestra.Text.Length > 0 && !cbDontOverlay.Checked)
        //                            tbOrchestra.Text = br.Value;
        //                    }
        //                    break;
        //                case "ReleaseDate":
        //                    br.Read(); //  get value
        //                    string[] splitFields = br.Value.Split('-');
        //                    if (coProductType.Text.Contains("Video"))
        //                        tbVideoYear.Text = splitFields[0]; //  just take the year
        //                    else
        //                        tbMusicYear.Text = splitFields[0]; //  just take the year
        //                    notFound = false;
        //                    break;
        //                case "Publisher":
        //                    br.Read(); //  get value
        //                    if (coProductType.Text.Contains("Video"))
        //                        tbStudio.Text = br.Value.Length > 85 ? br.Value.Substring(0, 85) : br.Value;
        //                    else
        //                        tbMusicLabel.Text = br.Value.Length > 85 ? br.Value.Substring(0, 85) : br.Value;
        //                    notFound = false;
        //                    break;
        //                case "Title":
        //                    br.Read(); //  get value
        //                    //if (tbTitle.Text.Length > 0 && !cbDontOverlay.Checked)
        //                    tbTitle.Text = br.Value.Length > 100 ? br.Value.Substring(0, 100) : br.Value;
        //                    notFound = false;
        //                    break;
        //                case "Format":
        //                    br.Read();
        //                    coVideoFormat.Text = br.Value;
        //                    break;
        //                case "ProductGroup":
        //                    br.Read();
        //                    coProductType.Text = br.Value.Contains("Music") ? "Music: Popular" : "Video: DVD";
        //                    break;
        //                case "UPCList":
        //                case "EANList":
        //                    br.Read();
        //                    br.Read(); //  point to EANList Element
        //                    if (tbUPC.Text.Length > 0 && !cbDontOverlay.Checked)
        //                        tbUPC.Text = br.Value;
        //                    break;
        //                case "Content":
        //                    br.Read();
        //                    tbDesc.Text = br.Value.Length > 500 ? br.Value.Substring(0, 500) : br.Value;
        //                    break;
        //                default:
        //                    break;
        //            }
        //    }

        //    //System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
        //    //xdoc.LoadXml(getXmlTextReaderAsString(br));
        //    //System.Xml.XmlNode EditorialReviewMatchAmazon1 = xdoc.SelectSingleNode("//EditorialReview[Source='Amazon.com']");
        //    //System.Xml.XmlNode contentNode1 = EditorialReviewMatchAmazon1.SelectSingleNode("./Content");
        //    //tbDesc.Text = contentNode1.InnerXml;

        //    br.Close();  //  close the reader


        //    if (notFound)  //  if we didn't find anything using UPC, try again using ASIN
        //        return false;

        //    //mediaDetailTab.Refresh();
        //    tbQty.Text = tbQty.Text.Length == 0 ? "1" : tbQty.Text;  //  if it's empty, default to 1

        //    Cursor.Current = Cursors.Default;
            return true;
        }



        private static string getXmlTextReaderAsString(System.Xml.XmlTextReader tr) {
            System.Text.StringBuilder y = new StringBuilder();
            while (tr.Read()) {
                switch (tr.NodeType) {
                    case System.Xml.XmlNodeType.Element:
                        y.AppendFormat("<{0}>", tr.Name);
                        break;
                    case System.Xml.XmlNodeType.Text:
                        y.Append(tr.Value);
                        break;
                    case System.Xml.XmlNodeType.CDATA:
                        y.AppendFormat("<![CDATA[{0}]]>", tr.Value);
                        break;
                    case System.Xml.XmlNodeType.ProcessingInstruction:
                        y.AppendFormat("<?{0} {1}?>", tr.Name, tr.Value);
                        break;
                    case System.Xml.XmlNodeType.Comment:
                        y.AppendFormat("<!--{0}-->", tr.Value);
                        break;
                    case System.Xml.XmlNodeType.XmlDeclaration:
                        y.Append("<?xml version='1.0'?>");
                        break;
                    case System.Xml.XmlNodeType.Document:
                        break;
                    case System.Xml.XmlNodeType.DocumentType:
                        y.AppendFormat("<!DOCTYPE {0} [{1}]", tr.Name, tr.Value);
                        break;
                    case System.Xml.XmlNodeType.EntityReference:
                        y.Append(tr.Name);
                        break;
                    case System.Xml.XmlNodeType.EndElement:
                        y.AppendFormat("</{0}>", tr.Name);
                        break;
                }
            }
            return y.ToString();
        }






        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    actual code to update the database with the ASINs
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private bool updateDBwithASINs() {
            string sFileName = "";
            string updateString = "";

            //  get filename
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                sFileName = openFileDialog1.FileName;
            else
                return false;  //  user canceled...

            string inputRecord;

            //  create stream reader object 
            System.IO.StreamReader sr = new System.IO.StreamReader(sFileName);
            sr.ReadLine();  //  get past the first record which contains the header information

            while ((inputRecord = sr.ReadLine()) != null)  //  read a tab-delimited records
            {
                string[] delimitedData = inputRecord.Split('\t');  //  now split each record into elements
                if (delimitedData[22].StartsWith("B"))  //  we have an ASIN
                {
                    //  update the record in the table
                    updateString = "UPDATE tMedia SET UPC = '" + delimitedData[22] + "' WHERE SKU = '" + delimitedData[3] + "'";
                    FbCommand cmd = new FbCommand(updateString);
                    cmd.Connection = mediaConn;
                    if (cmd.Connection.State == System.Data.ConnectionState.Closed)
                        cmd.Connection.Open();

                    cmd.ExecuteNonQuery();
                }

            }

            sr.Close();  //  close the stream reader

            return true;
        }

    }


    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //--    signed request helper
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    class SignedRequestHelper
    {
        private string endPoint;
        private string akid;
        private byte[] secret;
        private HMAC signer;

        private const string REQUEST_URI = "/onca/xml";
        private const string REQUEST_METHOD = "GET";

        /*
         * Use this constructor to create the object. The AWS credentials are available on
         * http://aws.amazon.com
         * 
         * The destination is the service end-point for your application:
         *  US: ecs.amazonaws.com
         *  JP: ecs.amazonaws.jp
         *  UK: ecs.amazonaws.co.uk
         *  DE: ecs.amazonaws.de
         *  FR: ecs.amazonaws.fr
         *  CA: ecs.amazonaws.ca
         */
        public SignedRequestHelper(string awsAccessKeyId, string awsSecretKey, string destination) {
            this.endPoint = destination.ToLower();
            this.akid = awsAccessKeyId;
            this.secret = Encoding.UTF8.GetBytes(awsSecretKey);
            this.signer = new HMACSHA256(this.secret);
        }

        /*
         * Sign a request in the form of a Dictionary of name-value pairs.
         * 
         * This method returns a complete URL to use. Modifying the returned URL
         * in any way invalidates the signature and Amazon will reject the requests.
         */
        public string Sign(IDictionary<string, string> request) {
            // Use a SortedDictionary to get the parameters in naturual byte order, as
            // required by AWS.
            ParamComparer pc = new ParamComparer();
            SortedDictionary<string, string> sortedMap = new SortedDictionary<string, string>(request, pc);

            // Add the AWSAccessKeyId and Timestamp to the requests.
            sortedMap["AWSAccessKeyId"] = this.akid;
            sortedMap["Timestamp"] = this.GetTimestamp();

            // Get the canonical query string
            string canonicalQS = this.ConstructCanonicalQueryString(sortedMap);

            // Derive the bytes needs to be signed.
            StringBuilder builder = new StringBuilder();
            builder.Append(REQUEST_METHOD)
                .Append("\n")
                .Append(this.endPoint)
                .Append("\n")
                .Append(REQUEST_URI)
                .Append("\n")
                .Append(canonicalQS);

            string stringToSign = builder.ToString();
            byte[] toSign = Encoding.UTF8.GetBytes(stringToSign);

            // Compute the signature and convert to Base64.
            byte[] sigBytes = signer.ComputeHash(toSign);
            string signature = Convert.ToBase64String(sigBytes);

            // now construct the complete URL and return to caller.
            StringBuilder qsBuilder = new StringBuilder();
            qsBuilder.Append("http://")
                .Append(this.endPoint)
                .Append(REQUEST_URI)
                .Append("?")
                .Append(canonicalQS)
                .Append("&Signature=")
                .Append(this.PercentEncodeRfc3986(signature));

            return qsBuilder.ToString();
        }

        /*
         * Sign a request in the form of a query string.
         * 
         * This method returns a complete URL to use. Modifying the returned URL
         * in any way invalidates the signature and Amazon will reject the requests.
         */
        public string Sign(string queryString) {
            IDictionary<string, string> request = this.CreateDictionary(queryString);
            return this.Sign(request);
        }

        /*
         * Current time in IS0 8601 format as required by Amazon
         */
        private string GetTimestamp() {
            DateTime currentTime = DateTime.UtcNow;
            string timestamp = currentTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
            return timestamp;
        }

        /*
         * Percent-encode (URL Encode) according to RFC 3986 as required by Amazon.
         * 
         * This is necessary because .NET's HttpUtility.UrlEncode does not encode
         * according to the above standard. Also, .NET returns lower-case encoding
         * by default and Amazon requires upper-case encoding.
         */
        private string PercentEncodeRfc3986(string str) {
            str = HttpUtility.UrlEncode(str, System.Text.Encoding.UTF8);
            str = str.Replace("'", "%27").Replace("(", "%28").Replace(")", "%29").Replace("*", "%2A").Replace("!", "%21").Replace("%7e", "~").Replace("+", "%20");

            StringBuilder sbuilder = new StringBuilder(str);
            for (int i = 0; i < sbuilder.Length; i++) {
                if (sbuilder[i] == '%') {
                    if (Char.IsLetter(sbuilder[i + 1]) || Char.IsLetter(sbuilder[i + 2])) {
                        sbuilder[i + 1] = Char.ToUpper(sbuilder[i + 1]);
                        sbuilder[i + 2] = Char.ToUpper(sbuilder[i + 2]);
                    }
                }
            }
            return sbuilder.ToString();
        }

        /*
         * Convert a query string to corresponding dictionary of name-value pairs.
         */
        private IDictionary<string, string> CreateDictionary(string queryString) {
            Dictionary<string, string> map = new Dictionary<string, string>();

            string[] requestParams = queryString.Split('&');

            for (int i = 0; i < requestParams.Length; i++) {
                if (requestParams[i].Length < 1) {
                    continue;
                }

                char[] sep = { '=' };
                string[] param = requestParams[i].Split(sep, 2);
                for (int j = 0; j < param.Length; j++) {
                    param[j] = HttpUtility.UrlDecode(param[j], System.Text.Encoding.UTF8);
                }
                switch (param.Length) {
                    case 1: {
                            if (requestParams[i].Length >= 1) {
                                if (requestParams[i].ToCharArray()[0] == '=') {
                                    map[""] = param[0];
                                }
                                else {
                                    map[param[0]] = "";
                                }
                            }
                            break;
                        }
                    case 2: {
                            if (!string.IsNullOrEmpty(param[0])) {
                                map[param[0]] = param[1];
                            }
                        }
                        break;
                }
            }

            return map;
        }

        /*
         * Consttuct the canonical query string from the sorted parameter map.
         */
        private string ConstructCanonicalQueryString(SortedDictionary<string, string> sortedParamMap) {
            StringBuilder builder = new StringBuilder();

            if (sortedParamMap.Count == 0) {
                builder.Append("");
                return builder.ToString();
            }

            foreach (KeyValuePair<string, string> kvp in sortedParamMap) {
                builder.Append(this.PercentEncodeRfc3986(kvp.Key));
                builder.Append("=");
                builder.Append(this.PercentEncodeRfc3986(kvp.Value));
                builder.Append("&");
            }
            string canonicalString = builder.ToString();
            canonicalString = canonicalString.Substring(0, canonicalString.Length - 1);
            return canonicalString;
        }
    }

    /*
     * To help the SortedDictionary order the name-value pairs in the correct way.
     */
    class ParamComparer : IComparer<string>
    {
        public int Compare(string p1, string p2) {
            return string.CompareOrdinal(p1, p2);
        }
    }
}
