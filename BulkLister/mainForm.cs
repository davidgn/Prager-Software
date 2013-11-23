using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using FirebirdSql.Data.FirebirdClient;

namespace BulkAddBooks
{

    public partial class mainForm : Form
    {
        public static string SKU = "";
        public static string Author = "";
        public static string Binding = "";
        public static string Edition = "";
        public static string Pages = "";
        public static string PubDate = "";
        public static string Pub = "";
        public static string Title = "";
        public static string DateAdded = "";
        public static string DateUpdated = "";

        public static string backupPath;
        public static string imagePath;
        public static string exportPath;
        public static string daysRetention;
        public static string databasePath;
        public static string firebirdInstallationPath;
        static public string dataBaseName = "dbBooks";
            
        public static string accessKeyId;   //   Access Key ID and Secret Access Key IDs
        public static string secretAccessKey;
        public static string merchantId;
        public static string marketplaceId;

        public static FbConnection bookConn;

        static IFormatProvider localCulture = System.Globalization.CultureInfo.CurrentCulture;  //  get current culture
        public static DateTime compileDate = DateTime.Parse("16 Apr 2013 7:25 AM", localCulture);
        public static string versionNumber = "13.0.1 " + compileDate.ToString("dd-MMM-yyyy");

        /*
         *
         ------    Cumulative changes    ----------------
         
         -  added:  save current entries for later use  (1.2.0)
         -  changed:  extended data entry window  (1.2.0)
         -  changed: not using Amazon to get book info (12.3.0)
         -  changed: version numbering to come in line with other programs (12.3.0)
         -  fixed: not getting book info correctly  (12.4.0)
         -  changed: using Amazon for book info  (12.5.0)
         -  fixed: quotes in Title; length of Title exceeded 100 characters (13.0.0)
         -  fixed: length of title; removed quotes from newly sized string  (13.0.1)
         * 
         * 
         * ----    TODO    ---------------------
         * change from Amazon to same venue as Inv program for getting informaion
         */


        //---------------------------    Initialization routines    -------------------|
        public mainForm() {
            InitializeComponent();

            dgvDataEntry.ColumnHeadersBorderStyle = ProperColumnHeadersBorderStyle;
            this.Text = "Prager Bulk Book Loader     Version: " + versionNumber;

            readConfigFile();  //  do it the same way as inventory pgm 

            //  check to see if database is there...
            string dbPath = databasePath + dataBaseName + ".fdb";
            fTrace("I - dbPath: " + dbPath);    //<------------  nETVISTA-8311:c:\Prager\  (change first : to a \\)

            FileInfo fi;
            if (dbPath.IndexOf(':') == dbPath.LastIndexOf(':'))
                fi = new FileInfo(dbPath);
            else {
                int i = dbPath.IndexOf(':');
                string filePath = @"\\" + dbPath.Substring(0, i) + @"\";
                //filePath += dbPath.Substring(i + 1, dbPath.Length - i - 1);
                filePath += dbPath.Substring(i + 3, dbPath.Length - i - 3);
                fi = new FileInfo(filePath);
            }
            if (!fi.Exists)  //  if the database is missing, stop...
            {
                fTrace("E - database is missing");
                MessageBox.Show("The database is missing; notify support@pragersoftware.com for help", "Prager, Software", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
                return;
            }

            bookConn = new FbConnection("User=prager;Password=books;Database=" + dbPath);

        }


        //-----------------------    main routine    -------------------|
        private void bStart_Click(object sender, EventArgs e) {
            dgvDataEntry.ReadOnly = true;  //  mark dgv as read only now...
            lDone.Visible = false;
            string sku = "";

            //  now loop through the rows in the dgv
            foreach (DataGridViewRow r in dgvDataEntry.Rows) {
                if (r.IsNewRow == true)  //  end of rows?
                    break;  //  yep, we're done

                if (r.Cells[1].Value == null && !cbAutomaticSKU.Checked) {  //  no SKU was provided
                    MessageBox.Show("You must either provide a SKU or check the box for automatic SKU numbering", "Prager, Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                //  get the keys from the database
                getAmazonKeys();

                AmazonMWS amws = new AmazonMWS();
                bool rc = amws.InvokeItemSearch(r.Cells[0].Value.ToString(), accessKeyId, merchantId, marketplaceId, secretAccessKey);

                if (rc == false) {
                    r.Cells[1].Style.ForeColor = System.Drawing.Color.Red;
                    r.Cells[1].Value = "Not Found";
                    continue;
                }

                if (r.Cells[1].Value == null)  //  did the user supply a SKU?
                    sku = "";  //  no...
                else
                    sku = r.Cells[1].Value.ToString();  //  yes, save it...

                tBooksAddBook(r.Cells[0].Value.ToString(), sku);  //  add it to the database, passing possible SKU

                r.Cells[1].Style.ForeColor = System.Drawing.Color.Black;
                r.Cells[1].Value = SKU;  //  display the SKU
            }

            Cursor.Current = Cursors.Default;
            lDone.Text = "Finished";
            lDone.Visible = true;
        }



        ////--------------------------    find the book data using Amazon.com    --------------------|
        //private bool InvokeItemSearch(string ISBN, string AWSKey, string AWSSecretKey) {
        //    Cursor.Current = Cursors.WaitCursor;

        //    //string DestinationPath = mainForm.backupPath.Replace("Backup", "ImageFiles");
        //    string idType = "";

        //    idType = "ISBN&SearchIndex=Books";
        //    string requestString =
        //        "Service=AWSECommerceService&Version=2009-03-31&Operation=ItemLookup" +
        //        "&ItemId=" + ISBN + "&IdType=" + idType + "&Condition=New&OfferPage=1" +
        //        "&MerchantId=All&ResponseGroup=Medium";

        //    SignedRequestHelper helper = new SignedRequestHelper(AWSKey, AWSSecretKey, "ecs.amazonaws.com");
        //    string requestURL = helper.Sign(requestString);
        //    WebRequest request = HttpWebRequest.Create(requestURL);


        //    request.Timeout = 30000;  //  30 seconds
        //    System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;  //  needed for bug in .NET 2.0

        //    // get the response object
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();


        //    // to read the contents of the file, get the ResponseStream
        //    StreamReader sr = null;
        //    try {
        //        sr = new StreamReader(response.GetResponseStream());
        //    }
        //    catch (Exception ex) {
        //        if (ex.Message.Contains("unable to connect to the remote server")) {
        //            MessageBox.Show("Amazon.com appears to be busy; please try again", "Prager, Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return false;
        //        }
        //    }

        //    // Create an insntance of XmlTextReader and call Read method to read the file
        //    XmlTextReader textReader = new XmlTextReader(sr);
        //    textReader.Read();

        //    // If the node has value
        //    textReader.MoveToAttribute("ItemLookupRequest");
        //    while (textReader.Read()) {
        //        if (textReader.NodeType == XmlNodeType.Element && textReader.NodeType != XmlNodeType.EndElement)
        //            switch (textReader.LocalName) {
        //                case "Author":
        //                    textReader.Read();  //  get value
        //                    Author = textReader.Value.Length > 75 ? textReader.Value.Substring(0, 75) : textReader.Value;
        //                    break;
        //                //case "Illustrator":  <------------------------ TODO
        //                //    textReader.Read();  //  get value
        //                //    Illus = textReader.Value.Length > 75 ? textReader.Value.Substring(0, 75) : textReader.Value;
        //                //    break;
        //                case "Binding":
        //                    textReader.Read();  //  get value
        //                    Binding = textReader.Value;
        //                    break;
        //                case "Edition":
        //                    textReader.Read();  //  get value
        //                    Edition = textReader.Value.Length > 15 ? textReader.Value.Substring(0, 15) : textReader.Value;
        //                    break;
        //                case "NumberOfPages":
        //                    textReader.Read();  //  get value
        //                    Pages = textReader.Value.ToString();
        //                    break;
        //                case "PublicationDate":
        //                    textReader.Read();  //  get value
        //                    string[] splitFields = textReader.Value.Split('-');
        //                    PubDate = splitFields[0];  //  just take the year
        //                    break;
        //                case "Publisher":
        //                    textReader.Read();  //  get value
        //                    Publisher = textReader.Value.Length > 85 ? textReader.Value.Substring(0, 85) : textReader.Value;
        //                    break;
        //                case "Title":
        //                    textReader.Read();  //  get value
        //                    Title = textReader.Value.Length > 100 ? textReader.Value.Substring(0, 100) : textReader.Value;
        //                    Title = Title.Replace("'", "''");
        //                    break;
        //                default:
        //                    break;
        //            }

        //    }
        //    return true;
        //}


        //---------------------------    add a book to the table    ---------------|
        private int tBooksAddBook(string ISBN, string possibleSKU) {

            DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateUpdated = DateAdded;  //  indicates book was just added
            string Condn = "";

            CultureInfo ci = CultureInfo.CurrentCulture;
            NumberFormatInfo nfi = ci.NumberFormat;
            //decimal decPrice = decimal.Parse(Price, nfi);

            //if (Binding.ToLower().Contains("paperback"))
            // Jacket.SelectedIndex = 8;  // none as issued 

            if (cbAutomaticSKU.Checked) {
                long sku = findHighestBookNbr();  //  get next book number
                sku++;
                SKU = sku.ToString();  //  convert it...
            }
            else { //  use user provided SKU
                SKU = possibleSKU;
            }

            //  fix title
            int titleLength = Title.Length;
            string newTitle = Title.Length > 100 ? Title.Substring(0, 100) : Title;
            newTitle = newTitle.Replace("'", "");

            String insertString =
                "insert into tBooks (BookNbr, Title, Author, ISBN, Locn, Pub, PubYear, Bndg, Condn, Ed, DateA, DateU, TranC, Stat, NbrOfPages, Price)" +
                " values ('" + SKU + "', '" + newTitle + "', '" + Author + "', '" + ISBN + "', '" + "" + "', '" + Pub +
                "', '" + PubDate + "', '" + Binding + "', '" + Condn + "', '" + Edition + "', '" + DateAdded + "', '" + DateUpdated +
                "', '" + "A" + "', '" + "Pending" + "', '" + Pages + "', '" + 0.00M + "')";

            FbCommand cmd = new FbCommand(insertString, bookConn);
            try {
                if (bookConn.State == ConnectionState.Closed)
                    bookConn.Open();

                cmd.ExecuteNonQuery();
            }

            catch (FbException ex) {
                if (ex.Message.Substring(0, 34).Contains("violation of PRIMARY or UNIQUE KEY")) {
                    MessageBox.Show("Error: duplicate SKU (" + SKU + "); check Automatic SKU numbering to resolve this automatically.", "Prager, Software",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -2;  //  duplicate SKU
                }
                else { //  reject the book
                    MessageBox.Show("exception: " + ex.Message);
                    if (ex.Message.Length > 36)
                        return -1;
                }
            }  //  end Catch

            cmd.Dispose();
            return 0;

        }  //  end - tBooksAddBook


        //-------------------------------    find highest book number    ----------------------|
        public Int64 findHighestBookNbr() {

            //  get all of the book numbers and place them in an array
            ArrayList al = new ArrayList();
            string selectString = "select BookNbr from tBooks";

            FbDataReader rdr = null;
            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();
            FbCommand cmd = new FbCommand(selectString, bookConn);
            rdr = cmd.ExecuteReader();

            while (rdr.Read()) {
                if (IsNumeric(rdr[0]))
                    al.Add(Int64.Parse((string)rdr[0]));
            }

            if (al.Count == 0 && cbAutomaticSKU.Checked == true)  //  if first time and they forgot to put in a starting SKU
                return 0;

            //  now find the highest numeric BookNbr in the array and return it as int64
            al.Sort();
            Int64 debugInt = (Int64)al[al.Count - 1];
            cmd.Dispose();

            return (Int64)al[al.Count - 1];

        }



        //-------------------------    test to see if an object is numeric    ---------------|
        public static bool IsNumeric(object value) {
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();

            try {
                Double d = Double.Parse(value.ToString(), nfi);
                return true;
            }
            catch (FormatException) {
                return false;
            }

        }


        //-------------------------    clear current entries    ------------------------|
        private void bClear_Click(object sender, EventArgs e) {
            dgvDataEntry.ReadOnly = false;  //  mark dgv as read only now...
            lDone.Visible = false;
            //var sku = "";

            //  now loop through the rows in the dgv
            foreach (DataGridViewRow r in dgvDataEntry.Rows) {
                r.Cells[0].Value = null;
                r.Cells[1].Value = null;
            }
        }


        //----------------------------    save current entries    ----------------------|
        private void bSave_Click(object sender, EventArgs e) {

            saveCurrentEntries();
        }


        //---------------------------    restore saved entries    ----------------------------|
        private void bRestore_Click(object sender, EventArgs e) {

            restoreSavedEntries();
        }


    }
}

