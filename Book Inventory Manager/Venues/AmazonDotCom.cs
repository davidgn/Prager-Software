
#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using FirebirdSql.Data.FirebirdClient;
using MarketplaceWebServiceProducts;
using MarketplaceWebServiceProducts.Model;
using MarketplaceWebService;
using MarketplaceWebService.Model;




#endregion

//------------    static keys for uploads and upload Verification   -----------------
//  Developer: MWS Access Key ID:  AKIAIZEE34BK5NOX5SDA
//             Secret Key: 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
//             Account Nbr: 1145-8140-6600
//             Merchant ID: A20V78MULJSCYR  (aka "Seller ID")
//             Marketplace ID: ATVPDKIKX0DER

//----------    my AWS keys for getting prices    ------------------  ??????????????????
//  Seller:  Access key:  AKIAJCD64XK7AANOIA3A
//           Secret Key:  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
//           Associates Tag: wwwpragerbook-20   

namespace Prager_Book_Inventory
{
    //--------------------------------------------------------
    //--    Amazon Web Services
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
    }


    partial class mainForm : Form
    {
        //----------------------------------------------------------------
        //--    create the amazon export files
        TextWriter azTextWriter;
        public int createExportAmazonFormat(string formattedDate) {

            Cursor.Current = Cursors.WaitCursor;
            lbUploadStatus.Items.Insert(0, "Amazon format export started");
            lbUploadStatus.Refresh();

            if (rbExportAll.Checked == false && rbChangeDate.Checked == false && rbExportInclusiveSearch.Checked == false && rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            sFileName1 = exportPath + "AZisbn" + formattedDate + ".txt";  //  create the filename...

            try {
                azTextWriter = new StreamWriter(sFileName1);  //  try to create the file
            }
            catch (Exception e) {
                if (e.ToString().Substring(10, 26) == "DirectoryNotFoundException") {
                    try {
                        DirectoryInfo di = Directory.CreateDirectory(exportPath);   // Try to create the directory
                        azTextWriter = new StreamWriter(sFileName1); //  create the stream writers
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Unable to create export directory: " + e.Message, "Prager Book Inventory Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //lbStatus.Items.Insert(0, "Unable to create export directory " + ex.Message);
                        //lbStatus.Refresh();
                        return -1;
                    }
                }
                else {
                    MessageBox.Show("Error creating Amazon export file: " + e.Message, "Prager Book Inventory Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }

            createExportCommandString();

            //  write the header (new for MWS)
            azTextWriter.WriteLine(
                "sku\t" +  // 0
                "author\t" +  // 1
                "title\t" +  // 2
                "publisher\t" +  // 3
                "pub-date\t" +  // 4
                "binding\t" +  // 5
                "price\t" +  // 6
                "product-id\t" +  // 7
                "product-id-type\t" +  // 8
                "description\t" +  // 9
                "item-note\t" +   // 10 
                "quantity\t" +  // 11
                "item-condition\t" +  // 12
                "item-note\t" +  // 13
                "volume\t" +  // 14
                "will-ship-internationally\t" +  // 15
                "expedited-shipping\t" +  // 16
//                "standard-plus\t" +  // 17
                "illustrator\t" +  // 18
                "main-image-url\t" +  // 19
                "edition\t" +  // 20
                "add-delete\t" +  // 21
                "dust-jacket\t" +  // 22
                "signed-by");  // 23


            //  find books in table
            FbCommand command = new FbCommand(commandString, bookConn);
            FbDataReader dr = command.ExecuteReader();
            int count = 0;

            while (dr.Read()) {
                tbBookNbr.Text = dr["BookNbr"].ToString();  //  for debugging purposes only!

                if (cbPurgeReplace.Checked && dr.GetString(25) == "Sold")
                    continue;  //  if purge/replace and Sold , don't upload

                if (dr.GetString(25) == "Hold")
                    continue;  //  don't export Hold

                buildAmazonISBNTabFile(dr);  //  build an Amazon tab-delimited file, passing the DataReader
                count++;  //  increment counter
            }

            azTextWriter.Close();  //  close the stream
            //twStdAmazon.Close();

            //if (dr != null)  //  close the data reader
            dr.Close();

            Cursor.Current = Cursors.Default;

            lbUploadStatus.Items.Insert(0, "Amazon format export(s) completed: " + count + " books exported to file " + sFileName1);
            lbUploadStatus.Refresh();

            return 0;
        }


        //------------------------------------------------------------------------
        //--  create a file for MWS in tab-delimited format
        private void buildAmazonISBNTabFile(FbDataReader dr) {
            string dataBuild = "";

            dataBuild = dr["BookNbr"] + "\t";  //  SKU 0
            dataBuild += dr["Author"] + "\t";  //  author 1

            dataBuild += dr["Title"] + "\t";  // title 2

            dataBuild += dr["Pub"] + "\t";  //  publisher 3

            if (dr["PubYear"].ToString().Length == 4)  //  pub date 4
                dataBuild += dr["PubYear"] + "-01-01\t";
            else
                dataBuild += "\t";

            dataBuild += dr["Bndg"] + "\t"; //  binding 5

            dataBuild += dr["Price"] + "\t";  //  price 6
            dataBuild += dr["ISBN"] + "\t";  //  product-id (ISBN) 7

            if (dr["ISBN"].ToString().Length > 0) //  product-id type 8
                dataBuild += dr["ISBN"].ToString().Substring(0, 1) == "B" ? "1\t" : "2\t";  //  indicate ASIN or ISBN
            else
                dataBuild += "\t";  //  ISBN is missing

            if (dr["Descr"] != DBNull.Value && dr["Descr"].ToString().Length > 0)
                dataBuild += dr["Descr"] + "\t";  //  description 9
            else
                dataBuild += "\t";  //  description is missing

            if (dr["BookNotes"] != DBNull.Value && dr["BookNotes"].ToString().Length > 0)
                dataBuild += dr["BookNotes"] + "\t";  //  BookNotes 10
            else
                dataBuild += "\t";  //  BookNotes is missing

            dataBuild += dr["Quantity"] + "\t";  //  quantity 11

            string tempCond = dr["Condn"].ToString();  //  item condition  12
            switch (tempCond.ToLower()) {
                case "new":
                case "as new":
                case "new book":
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

            if (dr["Descr"] != DBNull.Value && dr["Descr"].ToString().Length > 0)
                dataBuild += dr["Descr"] + "\t";  //  put the description in item-notes too...
            else
                dataBuild += "\t";  //  description (use item-note instead) 13

            if (dr["Volume"] != DBNull.Value)   //  Volume field exists...
                dataBuild += dr["Volume"] + "\t";  //  volume 14
            else
                dataBuild += "\t";  //  no volume info

            //  now figure out the shipping codes...
            UInt16 target = 0;
            string shipVerbage = "";
            if (dr["Shipping"] != DBNull.Value)   //  Shipping field exists...
            {
                target = ushort.Parse(dr["Shipping"].ToString());
                dataBuild += ((target & 2) == 2) ? "y\t" : "n\t";  //  Intl' standard 15

                if ((target | 61) != 0)  //  is there any expedited shipping? 16
                {
                    shipVerbage = (target & 16) == 16 ? "Domestic," : "";  //  domestic expedited
                    shipVerbage += (target & 8) == 8 ? "Second," : "";  //  2nd day
                    shipVerbage += (target & 4) == 4 ? "Next," : "";  //  next day
                    shipVerbage += (target & 1) == 1 ? "International" : "";  

                    dataBuild += shipVerbage + "\t";  //  ending tab
                }
                else
                    dataBuild += shipVerbage + "N\t";  //  no expedited shipping 
            }
            else
                dataBuild += "n\tn\t\t";  //  only available to U.S. customers w/ no expedited shipping

            ////  test for comma in last shipping type
            //int lastComma = dataBuild.IndexOf(',', dataBuild.Length - 4, 4);
            //dataBuild = (lastComma > 0) ? dataBuild.Remove(lastComma, 1) : dataBuild;

            dataBuild += dr["Illus"] + "\t";  //  illustrator 18
            dataBuild += dr["ImageFileName"] + "\t";  //  image URL 19
            dataBuild += dr["Ed"] + "\t";  //  edition 20

            if (dr["Stat"].ToString() == "Sold")  //  add-delete
                dataBuild += "d\t";  //  delete item from inventory
            else
                dataBuild += "a\t";  //  update/add item to inventory

            string dustJacket = dr["Jaket"].ToString();  //  dust-jacket
            switch (dustJacket) {
                case "New":
                case "Fine":
                    dataBuild += "1\t";
                    break;
                case "Very Good":
                    dataBuild += "2\t";
                    break;
                case "Good":
                    dataBuild += "3\t";
                    break;
                case "Fair":
                case "Poor":
                    dataBuild += "4\t";
                    break;
                case "Missing":
                    dataBuild += "0\t";
                    break;
                default:
                    dataBuild += "\t";
                    break;
            }

            string signedBy = dr["Signed"].ToString();  //  signed-by
            if (signedBy == "A")
                dataBuild += "author";
            else
                if (signedBy == "I")
                    dataBuild += "illustrator";

            azTextWriter.WriteLine(dataBuild);  //  that's it... write the line out

            return;
        }


        //-----------------------------------------------------------------------
        //--  actual upload to Amazon
        public int uploadAmazonFiles(string[] args) {

            //  instantiate implementation of MWS
            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            if (cbUploadAmazon.Checked)
                config.ServiceURL = @"https://mws.amazonservices.com";
            else if (cbUploadAmazonCA.Checked)
                config.ServiceURL = @"https://mws.amazonservices.ca";
            else if (cbUploadAmazonUK.Checked) {
                config.ServiceURL = @"https://mws.amazonservices.co.uk";
                AmazonUKUpload uk = new AmazonUKUpload();
                uk.uploadAmazonUKFiles(args, lbUploadStatus);
                return 0;
            }
            const string applicationName = "Prager Inventory Manager";
            const string applicationVersion = "12.7.0";

            MarketplaceWebServiceClient service = new MarketplaceWebServiceClient(
                "AKIAIZEE34BK5NOX5SDA",  //  developer access key
                "37eqs33ahd+Vbrc2AR/OTXwnpEfuOkNr3kM6UO0G", //  developer secret key
                applicationName,
                applicationVersion, config);

            SubmitFeedRequest request = new SubmitFeedRequest();
            request.MarketplaceIdList = new IdList();

            if (cbUploadAmazon.Checked) {
                request.Merchant = tbMerchantID.Text;  //  user's merchant id
                request.MarketplaceIdList.Id = new List<string>(new string[] { tbMarketplaceID.Text });  //  user's marketplace id
            }
            else if (cbUploadAmazonCA.Checked) {
                request.Merchant = tbAmazonCAMWSMerchantID.Text;
                request.MarketplaceIdList.Id = new List<string>(new string[] { tbAmazonCAMWSMktPlaceID.Text });  //  user's marketplace id
            }
            else if (cbUploadAmazonUK.Checked) {
                request.Merchant = tbAmazonUKMWSMerchantID.Text;
                request.MarketplaceIdList.Id = new List<string>(new string[] { tbAmazonUKMWSMktPlaceID.Text });  //  user's marketplace id
            }


            if (cbUploadPurgeReplace.Checked) {
                args[2] = args[2].Replace("purge", "");  //  remove "purge"
                request.PurgeAndReplace = true;
            }
            else
                request.PurgeAndReplace = false;

            try {
                request.FeedContent = File.Open(args[2], FileMode.Open, FileAccess.Read);
                if (request.FeedContent == null) {
                    MessageBox.Show("Test upload files are missing; contact support@pragersoftware.com", "Prager, Book Inventory Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            catch (Exception ex) {
                if (ex.Message.Contains("being used by another process")) {
                    MessageBox.Show("The exported file is LOCKED; please close any other program that is using it and try again",
                        "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }

            request.ContentMD5 = MarketplaceWebServiceClient.CalculateContentMD5(request.FeedContent);
            request.FeedContent.Position = 0;  //  Calculating the MD5 hash value exhausts the stream; therefore we have to reset the position
            request.FeedType = "_POST_FLAT_FILE_BOOKLOADER_DATA_";

            try {
                SubmitFeedResponse response = service.SubmitFeed(request);  //  submit the feed...

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
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
                //    throw new System.ArgumentException("MWS Exception");
            }
            catch (Exception ex) {
                if (ex.Message.Contains("being used by another process")) {
                    MessageBox.Show("The exported file is LOCKED; please close any other program that is using it and try again",
                        "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else {
                    MessageBox.Show("Error: " + ex.Message, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }

            return 0;
        }


        //-------------------------------------------------------------------------
        //--    does a lookup on Amazon for book information
        public bool BookInfoLookup(string asin, string AWSAccessKeyID, string MerchantID, string MarketplaceID,
            string AWSSecretKey) {

            string idType = "";
            //bool rc;

            if (asin.Length > 0)
                idType = asin.Substring(0, 1) == "B" ? "ASIN" : "ISBN";

            bool rc = InvokeItemSearch(idType, asin, AWSAccessKeyID, MerchantID, MarketplaceID, AWSSecretKey);  //  return true if OK

            return rc;
            //if (InvokeItemSearch(idType, asin, AWSAccessKeyID, MerchantID, MarketplaceID, AWSSecretKey)) {  //  probably not found
            //if (idType == "ISBN")  //  if we tried ISBN already, try ASIN
            //    if (!InvokeItemSearch("ASIN", asin, AWSAccessKeyID, MarketplaceID, MarketplaceID, AWSSecretKey))
            //    return true;  //  we had an error (most likely, couldn't find the book)
            //}

            //return false;

        }


        //-------------------------------------------------------------------------------
        //--    look for book info and parse results
        public bool InvokeItemSearch(string idType, string ISBN, string AWSKey, string MerchantID, string MarketplaceID,
            string AWSSecretKey) {

            Cursor.Current = Cursors.WaitCursor;

            //   Access Key ID and Secret Access Key ID
            String accessKeyId = AWSKey;
            String secretAccessKey = AWSSecretKey;
            String merchantId = MerchantID;
            String marketplaceId = MarketplaceID;

            const string applicationName = "PragerBookInventory";
            const string applicationVersion = "12.7.0";

            MarketplaceWebServiceProductsConfig config = new MarketplaceWebServiceProductsConfig();
            config.ServiceURL = "https://mws.amazonservices.com/Products/2011-10-01";

            MarketplaceWebServiceProductsClient service = new MarketplaceWebServiceProductsClient(
                applicationName, applicationVersion, accessKeyId, secretAccessKey, config);

            GetMatchingProductForIdRequest request = new GetMatchingProductForIdRequest();
            IdListType iDType = new IdListType();

            request.IdList = new IdListType();
            request.IdType = idType;
            request.IdList.Id = new List<string>();
            request.IdList.Id.Add(ISBN);

            request.MarketplaceId = marketplaceId;
            request.SellerId = merchantId;

            GetMatchingProductForIdResponse response = service.GetMatchingProductForId(request);
            List<GetMatchingProductForIdResult> getMatchingProductResultList = response.GetMatchingProductForIdResult;

            // take the response and convert it to a XML string
            string xml = response.ToXML();

            //  check for error...
            if (xml == null) {
                lNotFound.Visible = true;
                return false;
            }

            byte[] byteArray = Encoding.ASCII.GetBytes(xml);
            MemoryStream stream = new MemoryStream(byteArray);

            XmlTextReader reader = new XmlTextReader(stream);
            while (reader.Read()) {
                switch (reader.NodeType) {
                    case XmlNodeType.Element:  //  the node is an element
                        if (reader.Name == "ns2:ItemAttributes")
                            break;
                        if (reader.Name == "ns2:Author") {
                            reader.Read();  //  get value
                            tbAuthor.Text = reader.Value;
                        }
                        if (reader.Name == "ns2:Binding") {
                            reader.Read();  //  get value
                            coBinding.Text = reader.Value;
                        }
                        if (reader.Name == "ns2:NumberOfPages") {
                            reader.Read();  //  get value
                            tbPages.Text = reader.Value;
                        }
                        if (reader.Name == "ns2:PublicationDate") {
                            reader.Read();  //  get value
                            tbYear.Text = reader.Value.Length > 0 ? reader.Value.Substring(0, 4) : "";
                        }
                        if (reader.Name == "ns2:Publisher") {
                            reader.Read();  //  get value
                            tbPub.Text = reader.Value;
                        }
                        if (reader.Name == "ns2:Title") {
                            reader.Read();  //  get value
                            tbTitle.Text = reader.Value.Replace("&amp;", "&");  //  (13.0.3)
                        }
                        if (reader.Name == "ns2:Weight")  {  //  (13.221)
                            reader.Read();  //  get value
                            tbWeight.Text = reader.Value;
                        }
                        if(reader.Name == "ns2:URL")  {  //  (13.221)
                            reader.Read();
                            tbImageURL.Text = reader.Value;
                        }
                        break;
                    default:
                        break;
                }

                System.Diagnostics.Debug.Write("<name: " + reader.Name + ">");
                System.Diagnostics.Debug.Write("<value: " + reader.Value + ">");

                //case XmlNodeType.Text:  //  display text in each element
                //    break;
                //case XmlNodeType.EndElement:  //  display the end of the element
                //    System.Diagnostics.Debug.Write("</" + reader.Name + ">\n\r");
                //    break;
            }

            bookDetailTab.Refresh();
            tbCopies.Text = tbCopies.Text.Length == 0 ? "1" : tbCopies.Text;  //  if it's empty, default to 1

            if (cbCreateKeywords.Checked && tbKeywords.Text.Length == 0 && int.Parse(tbCopies.Text) > 0 && !tbTitle.Text.Contains("No Title Found"))
                tbKeywords.Text = parseKeywords(tbTitle.Text);  //  update keywords if empty and still for sale

            Cursor.Current = Cursors.Default;
            if (doingAnAdd && bAddRecord.Enabled)  //  make sure it's allowed
                bAddRecord.BackColor = Color.OrangeRed;

            return true;  //  good return code
        }


        //--------------------------------------------------------------------------------
        //--    routine to get book prices from Amazon
        //public bool getPricesFromAmazon(mainForm mf, mainForm.bookData bD, string ISBN, char bookCondn, string AWSKey, string AWSSecretKey,
        //                TabControl tabTaskPanel, int cWebPages, string AssocTag) {
        //    HttpWebResponse response = null;
        //    string replyFromHost = " ";
        //    StreamReader sr = null;
        //    string errorMsg = "";
        //    string requestString = "";
        //    //string myAmazonAccessKey = "";  //  "084BT0EPNB27A07DGR82";
        //    //string myAmazonSecretKey = "";  //"Gk0QGlcORtiSZQxqGiifKyiarqmyf9jcS1U/5Eyw";


        //    WebBrowser webBrowser2 = new WebBrowser();
        //    List<sData> alData = new List<sData>();

        //    if (ISBN.Substring(0, 1).ToLower() != "b")  //  it's an ISBN
        //        {
        //        if (bookCondn == 'n')  //  only new
        //            requestString =
        //                "Service=AWSECommerceService&Version=2011-08-01&Operation=ItemLookup" +
        //                "&ItemId=" + ISBN + "&AssociateTag=" + AssocTag +
        //                "&IdType=ISBN&Condition=New&OfferPage=1" +
        //                "&SearchIndex=Books&MerchantId=All&ResponseGroup=Medium,Offers";
        //        else if (bookCondn == 'u')  //  only used
        //            requestString =
        //                  "Service=AWSECommerceService&Version=2011-08-01&Operation=ItemLookup" +
        //                 "&ItemId=" + ISBN + "&AssociateTag=" + AssocTag +
        //                 "&IdType=ISBN&Condition=Used&OfferPage=1" +
        //                 "&SearchIndex=Books&MerchantId=All&ResponseGroup=Medium,Offers";
        //        else if (bookCondn == 'b')  //  get new and used
        //            requestString =
        //                "Service=AWSECommerceService&Version=2011-08-01&Operation=ItemLookup" +
        //                "&ItemId=" + ISBN + "&AssociateTag=" + AssocTag +
        //                "&IdType=ISBN&Condition=All&OfferPage=1" +
        //                "&SearchIndex=Books&MerchantId=All&ResponseGroup=Medium,Offers";
        //    }
        //    else {
        //        if (bookCondn == 'n')  //  only new
        //            requestString =
        //                "Service=AWSECommerceService&Version=2011-08-01&Operation=ItemLookup" +
        //                "&ItemId=" + ISBN + "&AssociateTag=" + AssocTag +
        //                "&IdType=ASIN&Condition=New&OfferPage=1" +
        //                "&MerchantId=All&ResponseGroup=Medium,Offers";
        //        else if (bookCondn == 'u')  //  only used
        //            requestString =
        //                "Service=AWSECommerceService&Version=2011-08-01&Operation=ItemLookup" +
        //                "&ItemId=" + ISBN + "&AssociateTag=" + AssocTag +
        //                "&IdType=ASIN&Condition=Used&OfferPage=1" +
        //                "&MerchantId=All&ResponseGroup=Medium,Offers";
        //        else if (bookCondn == 'b')  //  get new and used
        //            requestString =
        //              "Service=AWSECommerceService&Version=2011-08-01&Operation=ItemLookup" +
        //               "&ItemId=" + ISBN + "&AssociateTag=" + AssocTag +
        //               "&IdType=ASIN&Condition=All&OfferPage=1" +
        //               "&MerchantId=All&ResponseGroup=Medium,Offers";
        //    }

        //    SignedRequestHelper helper = new SignedRequestHelper(AWSKey, AWSSecretKey, "ecs.amazonaws.com");
        //    if (mf.rbAmazonCA.Checked)
        //        helper = new SignedRequestHelper(AWSKey, AWSSecretKey, "ecs.amazonaws.ca");
        //    string requestURL = helper.Sign(requestString);
        //    WebRequest request = HttpWebRequest.Create(requestURL);

        //    request.Timeout = 30000;  //  30 seconds
        //    System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;  //  needed for bug in .NET 2.0

        //    try {
        //        response = (HttpWebResponse)request.GetResponse();   // get the response object
        //    }
        //    catch (Exception ex) {
        //        if (ex.Message.Contains("(400) Bad Request")) {
        //            MessageBox.Show("Amazon returned an error: (400 - Bad Request).  If this continues, please notify Support at pragersoftware.com",
        //            "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }
        //        else
        //            if (ex.Message.Contains("The remote name could not be resolved")) {
        //                MessageBox.Show("Your internet connection appears to be down.  If this continues, please notify Support at pragersoftware.com",
        //                "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return false;
        //            }
        //            else {
        //                MessageBox.Show("Exception: " + ex.Message + " Please notify support@pragersoftware.com",
        //                "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return false;
        //            }
        //    }

        //    // to read the contents of the file, get the ResponseStream
        //    sr = new StreamReader(response.GetResponseStream());
        //    try {
        //        replyFromHost = sr.ReadToEnd();  //  <------ this is where we can see what came back
        //    }
        //    catch (Exception ex) {
        //        if (ex.Message.Contains("Unable to read data from the transport connection")) {
        //            MessageBox.Show("Amazon connection is unavailable; please try again in a few minutes", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }
        //    }

        //    //  now read the initial XML data returned by Amazon
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(replyFromHost);

        //    //  check for errors
        //    XmlNodeList error = doc.GetElementsByTagName("Error");
        //    foreach (XmlNode node in error) {
        //        XmlElement bookElement = (XmlElement)node;
        //        errorMsg = bookElement.GetElementsByTagName("Message")[0].InnerText;
        //        if (errorMsg.Contains("is not a valid value for ItemId"))
        //            return false;
        //        else {
        //            MessageBox.Show("AWS Error: " + errorMsg, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return false;
        //        }
        //    }

        //    //  now get the sales rank data
        //    string url = "";
        //    XmlNodeList salesRank = doc.GetElementsByTagName("SalesRank");
        //    //public int salesrank = 0;
        //    foreach (XmlNode node in salesRank) {
        //        bD.salesRank = int.Parse(doc.GetElementsByTagName("SalesRank")[0].InnerText);
        //    }

        //    //  now get the offer data
        //    XmlNodeList offers = doc.GetElementsByTagName("Offers");
        //    foreach (XmlNode node in offers) {
        //        XmlElement bookElement = (XmlElement)node;
        //        url = bookElement.GetElementsByTagName("MoreOffersUrl")[0].InnerText;
        //        if (url.Length == 1)
        //            return false;  //  <---------------------------- TODO
        //    }

        //    //  go to the url and get the data for screen scraping
        //    System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;

        //    Uri uri = new Uri(url);
        //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
        //    req.Referer = "http://www.pragersoftware.com/";

        //    req.KeepAlive = false;
        //    req.Method = "POST";
        //    req.ContentType = "application/x-www-form-urlencoded";
        //    req.ContentLength = 0;
        //    req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";

        //    string page = string.Empty;  //  clear it...
        //    try {
        //        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        //        Stream responseStream = resp.GetResponseStream();
        //        StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
        //        page = readStream.ReadToEnd();
        //    }
        //    catch (Exception ex) {
        //        if (ex.Message.Contains("Unable to read data from the transport connection"))
        //            return false;
        //        else if (ex.Message.Contains("(503) Server Unavailable.")) {
        //            System.Threading.Thread.Sleep(1000);
        //            try {
        //                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        //                Stream responseStream = resp.GetResponseStream();
        //                StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
        //                page = readStream.ReadToEnd();
        //            }
        //            catch (Exception ex1) {
        //                if (ex.Message.Contains("Unable to read data from the transport connection"))
        //                    return false;
        //                if (ex1.Message.Contains("(503) Server Unavailable.")) {
        //                    MessageBox.Show("Remote server is unavailable; try in a few minutes", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return false;
        //                }
        //            }

        //        }
        //    }

        //    //  we got it, now scrape it for prices, etc.
        //    Regex r, r1;
        //    Match m, m1;
        //    int nbrOfOffers = 0;

        //    r = new Regex(@"class=""numberofresults"">");  //  get number of results
        //    m = r.Match(page, 0);
        //    if (m.Success) {
        //        r1 = new Regex("offers");
        //        m1 = r1.Match(page, m.Index + 24);  //  look for "offers"
        //        if (m1.Success) {
        //            nbrOfOffers = int.Parse(page.Substring(m1.Index - 3, 3));  //  only picks up TWO (2) digits!
        //        }
        //    }

        //    int startingIndex = 31460;
        //    do {
        //        mainForm.pricingData pD = new mainForm.pricingData();  //  new instance of pricing data array
        //        sData sD = new sData();  //  one for each seller

        //        r = new Regex(@"<tbody class=""result"">");  //  new book entry starts here
        //        m = r.Match(page, startingIndex);

        //        if (m.Success) {
        //            r1 = new Regex(@"class=""price"">");  //  find start of price
        //            m1 = r1.Match(page, m.Index + 30);
        //            if (m1.Success) {  //  we found start of price
        //                r = new Regex(@"</span>");  //  end of price
        //                m = r.Match(page, m1.Index);
        //                if (m.Success) {  //  save price
        //                    if (mf.rbAmazonUS.Checked)
        //                        sD.alPrice = page.Substring(m1.Index + 15, m.Index - (m1.Index + 15));
        //                    if (mf.rbAmazonCA.Checked)
        //                        sD.alPrice = page.Substring(m1.Index + 18, m.Index - (m1.Index + 18));  //  was 14
        //                }
        //            }

        //            r1 = new Regex(@"<div class=""condition"">");  //  find condition
        //            m1 = r1.Match(page, m.Index);
        //            if (m1.Success) {
        //                r = new Regex(@"</div>");  //  end of condition
        //                m = r.Match(page, m1.Index);
        //                if (m.Success) {  //  save price
        //                    string conditionData = page.Substring(m1.Index + 23, m.Index - (m1.Index + 23));
        //                    switch (conditionData) {  //  <--------------------- TODO  (elaborate in display)
        //                        case "Used\n - Like New\n":
        //                        case "Used":
        //                        //case "marketplace":
        //                        case "Used\n - Acceptable\n":
        //                        case "Used\n - Very Good\n":
        //                        case "Used\n - Good\n":
        //                        //case "sale":
        //                        case "Collectible\n - Like New\n":
        //                            sD.alCondn = 'u';
        //                            break;
        //                        case "New":
        //                            //case "memberprice":
        //                            //case "brandnew":
        //                            //case "clubprice":
        //                            sD.alCondn = 'n';
        //                            break;
        //                        default:
        //                            sD.alCondn = 'u';
        //                            break;
        //                    }
        //                }
        //            }

        //            r = new Regex(@">Seller:</span>");  //  get in the area of seller name
        //            m = r.Match(page, m1.Index);
        //            if (m.Success) {
        //                r1 = new Regex(@"><b>");  //  beginning of seller name
        //                m1 = r1.Match(page, m.Index + 170);
        //                if (m1.Success) {
        //                    r = new Regex(@"</b>");  //  end of seller name
        //                    m = r.Match(page, m1.Index);
        //                    if (m.Success) {
        //                        sD.alVenueName = page.Substring(m1.Index + 4, m.Index - (m1.Index + 4));
        //                    }
        //                }
        //            }

        //            alData.Add(sD);  //  put it into the array
        //        }


        //        startingIndex = m.Index + 14000;  //  get in area of next "result" phrase

        //    } while (m.Index != 0);                              //(startingIndex < (page.Length - 14350));

        //    //  now, put the elements in the dictionary...  
        //    //         alData.Sort(new SDataComparer());  //  sort the struct's

        //    // do stuff with stuff.alVenueName
        //    sData stuff;
        //    for (int k = 0; k < alData.Count; k++) {
        //        mainForm.pricingData pD = new mainForm.pricingData();  //  new instance
        //        stuff = (sData)(alData[k]);
        //        pD.venueName = stuff.alVenueName;
        //        pD.price = stuff.alPrice;
        //        pD.bookCondn = stuff.alCondn;

        //        string key = stuff.alVenueName + "." + stuff.alPrice + "." + stuff.alCondn;
        //        if (!bD.bookList.ContainsKey(key))  //  if the vendor/price key is same, drop it...
        //            bD.bookList.Add(key, pD);
        //    }
        //    bD.ISBN = ISBN;
        //    //}
        //    //catch (WebException ex) {
        //    //    MessageBox.Show("Error from AWS: " + ex.Message, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //    return false;

        //    //}


        //    return true;
        //}


        //------------------------------------------------------------------------------
        //-  validate Amazon keys
        private void validateAmazonKeys(string AWSKey, string MerchantID, string MarketplaceID, string AWSSecretKey) {
            //   Access Key ID and Secret Access Key ID
            String accessKeyId = AWSKey;
            String secretAccessKey = AWSSecretKey;
            String merchantId = MerchantID;
            String marketplaceId = MarketplaceID;

            const string applicationName = "PragerBookInventory";
            const string applicationVersion = "12.7.0";

            MarketplaceWebServiceProductsConfig config = new MarketplaceWebServiceProductsConfig();
            config.ServiceURL = "https://mws.amazonservices.com/Products/2011-10-01";

            MarketplaceWebServiceProductsClient service = new MarketplaceWebServiceProductsClient(
                applicationName, applicationVersion, accessKeyId, secretAccessKey, config);

            GetMatchingProductRequest request = new GetMatchingProductRequest();

            ASINListType wsList = new ASINListType();
            wsList.ASIN.Add("0345377443");
            request.ASINList = wsList;
            request.MarketplaceId = marketplaceId;
            request.SellerId = merchantId;

            try {
                GetMatchingProductResponse response = service.GetMatchingProduct(request);
                List<GetMatchingProductResult> getMatchingProductResultList = response.GetMatchingProductResult;

                // take the response and convert it to a XML string
                string xml = null;
                foreach (GetMatchingProductResult getMatchingProductResult in getMatchingProductResultList) {
                    if (getMatchingProductResult.IsSetProduct()) {
                        Product product = getMatchingProductResult.Product;

                        if (product.IsSetAttributeSets()) {  //  is attributes set?
                            foreach (var attribute in product.AttributeSets.Any) {  //  send each XML element
                                xml = ProductsUtil.FormatXml((System.Xml.XmlElement)attribute);
                                System.Diagnostics.Debug.WriteLine(xml);  //  DEBUGGING
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Prager, Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Congratulations! All four (4) MWS keys are valid", "Prager, Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }


        //    //------------------------------------------------------------------------------
        //    //--    actual code to update the database with the ASINs
        //    private bool updateDBwithASINs() {
        //        string sFileName = "";
        //        string updateString = "";

        //        //  get filename
        //        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //            sFileName = openFileDialog1.FileName;
        //        else
        //            return false;  //  user canceled...

        //        string inputRecord;

        //        System.IO.StreamReader sr = new StreamReader(sFileName);  //  create stream reader object 
        //        sr.ReadLine();  //  get past the first record which contains the header information

        //        while ((inputRecord = sr.ReadLine()) != null)  //  read a tab-delimited records
        //        {
        //            string[] delimitedData = inputRecord.Split('\t');  //  now split each record into elements
        //            if (delimitedData[22].StartsWith("B"))  //  we have an ASIN
        //            {
        //                //  update the record in the table
        //                updateString = "UPDATE tBooks SET ISBN = '" + delimitedData[22] + "' WHERE BookNbr = '" + delimitedData[3] + "'";
        //                FbCommand cmd = new FbCommand(updateString);
        //                cmd.Connection = bookConn;
        //                if (cmd.Connection.State == System.Data.ConnectionState.Closed)
        //                    cmd.Connection.Open();

        //                cmd.ExecuteNonQuery();
        //            }

        //        }

        //        sr.Close();  //  close the stream reader

        //        return true;
        //    }

    }  //  end: partial class of MainForm


    //-----------------------------------------------------------------------------
    //--    signed request helper
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
            endPoint = destination.ToLower();
            akid = awsAccessKeyId;
            secret = Encoding.UTF8.GetBytes(awsSecretKey);
            signer = new HMACSHA256(secret);
        }

        /*
         * Sign a request in the form of a Dictionary of name-value pairs.
         * 
         * This method returns a complete URL to use. Modifying the returned URL
         * in any way invalidates the signature and Amazon will reject the requests.
         */
        public string Sign(IDictionary<string, string> request) {
            // Use a SortedDictionary to get the parameters in naturual byte order, as required by AWS.
            ParamComparer pc = new ParamComparer();
            SortedDictionary<string, string> sortedMap = new SortedDictionary<string, string>(request, pc);

            // Add the AWSAccessKeyId and Timestamp to the requests.
            sortedMap["AWSAccessKeyId"] = akid;
            sortedMap["Timestamp"] = GetTimestamp();

            // Get the canonical query string
            string canonicalQS = ConstructCanonicalQueryString(sortedMap);

            // Derive the bytes needs to be signed.
            StringBuilder builder = new StringBuilder();
            builder.Append(REQUEST_METHOD)
                .Append("\n")
                .Append(endPoint)
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
                .Append(endPoint)
                .Append(REQUEST_URI)
                .Append("?")
                .Append(canonicalQS)
                .Append("&Signature=")
                .Append(PercentEncodeRfc3986(signature));

            return qsBuilder.ToString();
        }

        /*
         * Sign a request in the form of a query string.
         * 
         * This method returns a complete URL to use. Modifying the returned URL
         * in any way invalidates the signature and Amazon will reject the requests.
         */
        public string Sign(string queryString) {
            IDictionary<string, string> request = CreateDictionary(queryString);
            return Sign(request);
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
            str = HttpUtility.UrlEncode(str, Encoding.UTF8);
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
                    param[j] = HttpUtility.UrlDecode(param[j], Encoding.UTF8);
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
                builder.Append(PercentEncodeRfc3986(kvp.Key));
                builder.Append("=");
                builder.Append(PercentEncodeRfc3986(kvp.Value));
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