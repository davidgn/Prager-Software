
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using FirebirdSql.Data.FirebirdClient;

namespace Prager_Book_Inventory
{
    class asin
    {

        ArrayList alComments = new ArrayList();

        internal struct sData   {
            internal string ASIN;
            internal string Title;
            internal string Author;
            internal string Publisher;
            internal string Year;
            internal string Binding;
            internal string Edition;
            //internal string ISBN;
            internal string Rank;
        };

        internal struct aData  {
            internal string SKU;
            internal string ASIN;
        };

        public List<sData> alData = new List<sData>();
        public List<aData> ASINData = new List<aData>();


        //-------------------------------------------------------------------------------------
        //--    main entry point to routine
        public void getASIN(ListView lv1, string SKU, string title, string author, string pub, string awsKey, string awsSecretKey, TextBox tbasin, FbConnection bookConn,
            ListView dbp, ListView.SelectedIndexCollection dbpIndex) {

            //string yy = "";
            //   string xx = "";
            string replyFromHost = "";
            //   string errorMsg = "";
            StreamReader sr = null;

            Cursor.Current = Cursors.WaitCursor;

            if (lv1.Items.Count > 0)
                lv1.Items.Clear();  //  clear out the old items

            title = title.Length < 100 ? title : title.Substring(0, 99);

            // Open the XML document
            string requestString = ("Service=AWSECommerceService&Version=2011-08-01" +
                   "&SubscriptionId=" + awsKey +      //  084BT0EPNB27A07DGR82
                   "&Operation=ItemSearch" +
                   "&ResponseGroup=Offers,Medium" +
                   "&SearchIndex=Books" + 
                   "&AssociateTag=Pragbook-20" +     //AssocTag +
                   "&Power=title:" + title + ", author:" + author + ", publisher:" + pub +
                   "&Sort=salesrank");

            SignedRequestHelper helper = new SignedRequestHelper(awsKey, awsSecretKey, "ecs.amazonaws.com");
            string requestURL = helper.Sign(requestString);
            WebRequest request = HttpWebRequest.Create(requestURL);


            request.Timeout = 30000;  //  30 seconds
            System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;  //  needed for bug in .NET 2.0

            // get the response object
            HttpWebResponse response = null;
            try {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex) {
                if (ex.Message.Contains("(403) Forbidden")) {
                    MessageBox.Show("Check your user id's, passwords and Aamzon keys - they were rejected by Amazon", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // to read the contents of the file, get the ResponseStream
            try {
                sr = new StreamReader(response.GetResponseStream());
                replyFromHost = sr.ReadToEnd();  //  used for XPath below
            }
            catch (Exception ex) {
                if (ex.Message.Contains("Unable to read data from the transport connection")) {
                    MessageBox.Show("Amazon connection is unavailable; please try again in a few minutes", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //else if (ex.Message.Contains("not set to an instance of an object")) {
                //    MessageBox.Show("Amazon connection is unavailable; please try again in a few minutes", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                else {
                    MessageBox.Show("Error getting ASIN info from Amazon: " + ex.Message, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //  now read the initial XML data returned by Amazon
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(replyFromHost);

            //  check for errors
            ListViewItem lvi = null;
            XmlNodeList error = doc.GetElementsByTagName("Error");
            foreach (XmlNode node in error) {
                XmlElement bookElement = (XmlElement)node;
                string errorMsg = bookElement.GetElementsByTagName("Message")[0].InnerText;
                if (errorMsg.Contains("is not a valid value for ItemId"))
                    return;
                else if (errorMsg.Contains("We did not find any matches")) {
                    lvi = new ListViewItem("             ASIN information not found");
                    lvi.ForeColor = Color.Firebrick;
                    lv1.Tag = "Rank";
                    lv1.Items.Add(lvi);  //  add the items to the listview


                    return;
                }
                else {
                    MessageBox.Show("AWS Error: " + errorMsg, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            using (XmlReader xmlReader = XmlReader.Create(new StringReader(replyFromHost))) {

                sData sD = new sData();

                xmlReader.ReadToFollowing("Items");  //  position

                while (!xmlReader.EOF) {

                    xmlReader.ReadToFollowing("Item");  //  here too...

                    //  now start gathering info from the elements
                    xmlReader.ReadToFollowing("ASIN");
                    if (xmlReader.NodeType != XmlNodeType.None)
                        sD.ASIN = xmlReader.ReadElementContentAsString();

                    xmlReader.ReadToFollowing("SalesRank");
                    if (xmlReader.NodeType != XmlNodeType.None)
                        sD.Rank = xmlReader.ReadElementContentAsString();

                    xmlReader.ReadToFollowing("ItemAttributes");  // position the file...

                    xmlReader.ReadToFollowing("Author");
                    if (xmlReader.NodeType != XmlNodeType.None)
                        sD.Author = xmlReader.ReadElementContentAsString();

                    xmlReader.ReadToFollowing("Binding");
                    if (xmlReader.NodeType != XmlNodeType.None)
                        sD.Binding = xmlReader.ReadElementContentAsString();

                    xmlReader.ReadToFollowing("Edition");
                    if (xmlReader.NodeType != XmlNodeType.None)
                        sD.Edition = xmlReader.ReadElementContentAsString();

                    xmlReader.ReadToFollowing("PublicationDate");
                    if (xmlReader.NodeType != XmlNodeType.None)
                        sD.Year = xmlReader.ReadElementContentAsString();

                    xmlReader.ReadToFollowing("Publisher");
                    if (xmlReader.NodeType != XmlNodeType.None)
                        sD.Publisher = xmlReader.ReadElementContentAsString();

                    xmlReader.ReadToFollowing("Title");
                    if (xmlReader.NodeType != XmlNodeType.None)
                        sD.Title = xmlReader.ReadElementContentAsString();

                    alData.Add(sD);

                }


            }

            //  now, present the data...
            int i = 0;
            foreach (object obj in alData) {
                lvi = new ListViewItem(alData[i].Title);
                lvi.SubItems.Add(alData[i].Author);
                lvi.SubItems.Add(alData[i].Publisher);
                lvi.SubItems.Add(alData[i].Year);
                lvi.SubItems.Add(alData[i].Binding);
                lvi.SubItems.Add(alData[i].ASIN);
                lvi.SubItems.Add(alData[i].Rank);
                lv1.Tag = "Rank";
                lv1.Items.Add(lvi);  //  add the items to the listview
                i++;
            }

            return;
        }


        //-------------------------------------------------------------------------------------
        //--    update asin from a text file
        public void doASINupdate(OpenFileDialog openFileDialog1, FbConnection bookConn) {
            string sFileName = "";
            string input = "";
            string[] inputArray;
            aData ad = new aData();
            string updateString = "";
            FbCommand cmd;

            //  find file and open it
            openFileDialog1.Filter = @"Text files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                sFileName = openFileDialog1.FileName;
                System.IO.StreamReader sr = new System.IO.StreamReader(sFileName);
                ASINData.Clear();  //  make sure it's empty...

                Application.DoEvents();  //  repaint the window...
                Cursor.Current = Cursors.WaitCursor;

                while ((input = sr.ReadLine()) != null)  //  now read entire file into the array
                {
                    inputArray = input.Split('\t');
                    inputArray[0] = inputArray[0].Replace('\"', ' ');
                    ad.SKU = inputArray[0].Trim();
                    inputArray[3] = inputArray[3].Replace('\"', ' ');
                    ad.ASIN = inputArray[3].Trim();

                    ASINData.Add(ad);
                }
                sr.Close();  //  close the stream reader

                //  loop to update SKUs with ASINs
                for (int i = 1; i < ASINData.Count; i++) {
                    if (ASINData[i].ASIN.Substring(0, 1) == "B") {
                        updateString = @"UPDATE tBooks SET ISBN = ' " + ASINData[i].ASIN + "' WHERE BookNbr = '" + ASINData[i].SKU + "'";
                        cmd = new FbCommand(updateString);
                        cmd.Connection = bookConn;
                        if (cmd.Connection.State == ConnectionState.Closed)
                            cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            Cursor.Current = Cursors.Default;
            return;
        }

    }
}


