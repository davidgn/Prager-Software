
using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Net;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace Media_Inventory_Manager
{

    partial class mainForm : Form
    {

        public string sFileName1;
        public string sFileName2;
        string tempArg;

        public class mediaData
        {
            public string UPC;
            public decimal listPrice;
            public int salesRank;
            public Dictionary<string, pricingData> mediaList = new Dictionary<string, pricingData>();
        }
        public class pricingData
        {
            public string venueName;
            public string price;
            public char itemCondn;
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  read the configuration file
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        private void readConfigFile() {
            string applicationPath = Application.StartupPath;
            //applicationPath = @"C:\Program Files (x86)\Prager\Med";  //  for TESTING ONLY!!
            //applicationPath = @"C:\Program Files\Prager\Med";  //  for TESTING ONLY!!

            FileInfo newLoc = new FileInfo(@"C:\Prager\MediaInventory.cfg");

            //  now read it...
            XmlTextReader reader = new XmlTextReader(@"C:\Prager\MediaInventory.cfg");
            while (reader.Read()) {
                if (reader.NodeType == XmlNodeType.Element) {
                    switch (reader.LocalName) {
                        case "DatabasePath":
                            databasePath = reader.ReadElementContentAsString();
                            break;
                        case "BackupPath":
                            backupPath = reader.ReadElementContentAsString();
                            if (backupPath.Length != 0 && !Directory.Exists(backupPath))
                                Directory.CreateDirectory(backupPath);
                            break;
                        case "ExportPath":
                            exportPath = reader.ReadElementContentAsString();
                            if (exportPath.Length != 0 && !Directory.Exists(exportPath))
                                Directory.CreateDirectory(exportPath);
                            break;
                        case "DaysRetention":
                            daysRetention = reader.ReadElementContentAsString();
                            break;
                        //case "ProgramOptionsFilePath":
                        //    programOptionsPath = reader.ReadElementContentAsString();
                        //    break;
                        default:
                            break;
                    }
                }
            }
            reader.Close();

            //if (pathFound == false)
            //    MessageBox.Show("You need to modify Inventory.cfg file to indicate FIrebird installation path", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);

            fTrace("I - Database Path: " + databasePath);
            fTrace("I - Backup Path: " + backupPath);  //  trace <--
            fTrace("I - Export Path: " + exportPath);

            if (backupPath.Length > 50) {
                fTrace("W - backupPath.Length > 50");
                MessageBox.Show("The backup path length exceeds 50 characters; program is unable to backup files without causing an error.",
                    "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            if (databasePath == null || backupPath == null || exportPath == null || daysRetention == null ||
                databasePath.Length == 0 || backupPath.Length == 0 || exportPath.Length == 0 || daysRetention.Length == 0) {
                fTrace("E - configuration file is invalid");
                MessageBox.Show("The configuration file is invalid; the Inventory program is \nunable to continue without major damage to the database!",
                    "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                throw new System.ArgumentException("invalid configuration file");
            }
            fTrace("I - finished readConfigFile");
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  check memory and OS
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        private void checkMemoryAndOS()  //  did have static after private; removed because ftrace had errors
        {
            ulong totalMemory = 0;
            ulong memoryInK = 0;
            ManagementObjectSearcher query;
            ManagementObjectCollection queryCollection;
            System.Management.ObjectQuery oq;

            ConnectionOptions co = new ConnectionOptions();

            System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2", co);

            oq = new System.Management.ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            query = new ManagementObjectSearcher(ms, oq);

            queryCollection = query.Get();
            foreach (ManagementObject mo in queryCollection) {
                osName = (string)mo["Caption"];
                osServicePack = mo["ServicePackMajorVersion"].ToString();
            }


            if (osName.Contains("2000 Professional") == true) {
                if (osServicePack != "4")
                    MessageBox.Show("Your Service Pack level is not current.  This may affect the execution of this program.",
                        "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (osName.Contains("Windows XP") == true) {
                if (osServicePack != "2" && osServicePack != "3")
                    MessageBox.Show("Your Service Pack level is not current.  This may affect the execution of this program.",
                        "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (backupPath.Contains("Program Files"))
                    MessageBox.Show("You must change your backup path to a directory that does not have 'Program Files' as a parent\n" +
                        "For information and instructions, please see the Help file (press F1)", "Prager Media Inventory Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            //  if it's not Vista, check the service pack level of .NET v2.0
            if (!osName.Contains("Vista") && !osName.Contains("Windows 7")) {
                //  delete the old restoreKey stuff... (caused David's window to shrink on the right)
                using (RegistryKey restoreState = Registry.CurrentUser.OpenSubKey("SOFTWARE\\RestoreState\\RealPosition\\", true)) {
                    if (restoreState != null) {
                        try {
                            restoreState.DeleteSubKeyTree("RealPosition");
                        }
                        catch (Exception ex) {
                            if (!ex.Message.Contains("the subkey does not exist"))
                                fTrace("W - 193 (Subkey RealPosition does not exist): " + ex.Message);
                        }
                    }
                }

            }

            //machine info
            oq = new System.Management.ObjectQuery("SELECT * FROM Win32_ComputerSystem");
            query = new ManagementObjectSearcher(ms, oq);
            queryCollection = query.Get();

            foreach (ManagementObject mo in queryCollection)
                totalMemory = (ulong)mo["totalphysicalmemory"];

            //  enough memory?
            amountOfMemory = (totalMemory / 1048576).ToString();  //  just in case we abort and need to send email
            fTrace("I - memory = " + (totalMemory / 1048576) + "K");
            if (int.Parse(amountOfMemory) < 510) {
                memoryInK = totalMemory / 1048576;
                MessageBox.Show("You only have " + memoryInK.ToString() + " Mb of memory which is not enough to run this\n" +
                    "program successfully.  Please contact support@pragersoftware.com \nfor instructions.", "Prager Media Inventory Manager", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                //traceSource.TraceInformation("-->Critical - memory: " + memoryInK.ToString());
                //traceSource.Flush();
                Application.Exit();  //  cancel program
            }

            //  get machine serial number
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            //string MACAddress = String.Empty;
            foreach (ManagementObject mo in moc) {
                if ((bool)mo["IPEnabled"] == true)
                    MACAddress = mo["MacAddress"].ToString();
                mo.Dispose();
            }
            MACAddress = MACAddress.Replace(":", "");
            fTrace("I - MAC Address: " + MACAddress);

            //  get screen size and see if they need to increase the resolution
            int width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            fTrace("I - screen resolution: (W x H): " + width.ToString() + " x " + height.ToString());
            if (width < 1024 && height < 960)
                MessageBox.Show("Your screen resolution is too low (" + width.ToString() + " X " + height.ToString() + ") to view the entire program window.  Please set it to something greater than 1024 x 768", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //  32-bit or 64-bit?


        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    getTimeSpan
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        static TimeSpan startTime;
        public TimeSpan getTimeSpan(string startOrStop) {
            TimeSpan stopTime;
            TimeSpan elapsedTime;

            if (startOrStop == "start") {
                startTime = DateTime.Now.TimeOfDay;
                lbStatus.Items.Insert(0, "start time: " + startTime);
                lbStatus.Refresh();
            }
            else {
                stopTime = DateTime.Now.TimeOfDay;
                lbStatus.Items.Insert(0, "stop time: " + stopTime);
                lbStatus.Refresh();

                return (elapsedTime = stopTime - startTime);
            }
            return (TimeSpan.Zero);
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    parse keywords
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        private string parseKeywords(string inputTitle) {
            string workingString = "";

            const string newPattern = @"(?i)\band\b|\bor\b|\bthe\b|\ba\b|\bwith\b|\bof\b|\ban\b|\bin\b|\bor\b|\bat\b|&|\bto\b|\bis\b|\bfor\b|\bnor\b";
            workingString = Regex.Replace(inputTitle, newPattern, "");
            int length = workingString.Length > 80 ? 80 : workingString.Length;

            //if (cbAddAuthor2Keywords.Checked == true)  //  if user wants to add author to keywords...
            //    workingString += tbAuthor.Text;

            return workingString.Substring(0, length).ToUpper() + " ";
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  download version information
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        static string DownloadVersionInfo() {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            string replyFromHost = " ";
            StreamReader sr = null;
            try {
                // create a FtpWebRequest object
                request = (HttpWebRequest)HttpWebRequest.Create(new Uri(@"http://www.pragersoftware.com/downloads/MediaVersionInfo.txt"));
                request.Timeout = 30000;  //  30 seconds
                //request.Credentials = credentials;
                request.KeepAlive = false;

                System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;  //  needed for bug in .NET 2.0

                // get the response object
                response = (HttpWebResponse)request.GetResponse();

                // to read the contents of the file, get the ResponseStream
                sr = new StreamReader(response.GetResponseStream());
                replyFromHost = sr.ReadToEnd();
            }

            catch (WebException ex) {
                if (ex.Message.Contains("The operation has timed out."))
                    return " ";
                //    MessageBox.Show(e.ToString());
                MessageBox.Show("Unable to determine if there is a new version (site busy)\nPlease try later", "Prager Media Inventory Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return " ";
            }

            return replyFromHost;

        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    get media prices from internet
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        private void getMediaPrices(char itemCondn, string AWSKey) {
#if UNAVAILABLE
            Cursor.Current = Cursors.WaitCursor;

            lbPricingResults.Items.Clear();
            lbPricingResults.Refresh();
            lbPrice.Items.Clear();
            lbPrice.Refresh();
            lbCondn.Items.Clear();
            lbCondn.Refresh();
            lListPrice.Text = "List Price:";  //  clear old price
            lListPrice.Refresh();


            if (tbUPC.Text.Length == 12 || tbUPC.Text.Length == 13)  //  only do it if there is an UPC to check
            {
                //mainForm.mediaData bD = new mainForm.mediaData();
                //AmazonWebServices aws = new AmazonWebServices();
                //BestWebBuysDotCom bwb = new BestWebBuysDotCom();
                mainForm mf = new mainForm(false);

                decimal accumulatedPrice = 0.00M;
                bool rc = true;

                PricingRoutines pr = new PricingRoutines();
                PricingRoutines.PricingData pD = new PricingRoutines.PricingData();
                PricingRoutines.BookData bD = new PricingRoutines.BookData();

                rc = pr.getInternetPrices(mtbISBN.Text, bD, pD);

                if (rc == true) {
                    if (bD.listPrice == 0.0M)
                        lListPrice.Text = "List Price: n/a";
                    else
                        lListPrice.Text = "List Price: " + bD.listPrice;

                    //if (bD.salesRank == 0)
                    //    lSalesRank.Text = "Sales Rank: n/a";
                    //else
                    //    lSalesRank.Text = "Sales Rank: " + bD.salesRank;

                    //  fill the listboxes
                    decimal avgPrice = 0.0M;

                    int lbCount = bD.mediaList.Count > 35 ? 35 : bD.mediaList.Count;
                    if (bD.mediaList.Count > 35)
                        lPricesReturned.Text = bD.mediaList.Count.ToString() + " prices returned for this item; only showing first 35.";
                    else
                        lPricesReturned.Text = bD.mediaList.Count.ToString() + " prices returned for this item.";


                    int i = 0;
                    int j = 1;
                    int recordCount = 0;
                    //string savedPrice = "";
                    //char savedCondn = ' ';
                    decimal lowestPrice = 9999.99M;

                    //  try to aggregate the total of each price (count duplicates)...
                    foreach (string key in bD.mediaList.Keys) {

                        recordCount++;  //  so we can tell when we're at EOF

                        if (cbUseAWS.Checked == true)  //  using Amazon prices...
                        {
                            if (savedPrice == "")   //  first time
                            {
                                //savedPrice = bD.mediaList[key].price;
                                //savedCondn = bD.mediaList[key].itemCondn;
                                accumulatedPrice += decimal.Parse(bD.mediaList[key].price);
                                continue;
                            }
                            else if (bD.mediaList[key].price == savedPrice)  //  if it's the same, then aggregate it...
                            {
                                j++;  //  indicate we have another one...
                                continue;
                            }

                            int lbcount0 = lbPrice.Items.Count;  //  DEBUGGING  <-------------------------------

                            //  process previous key
                            if (j > 1)
                                lbPricingResults.Items.Add("Amazon.com" + " (" + j.ToString() + " with same price)");  // with amazon.com, there is no valid venue name
                            else
                                //lbPricingResults.Items.Add("Amazon.com");  // with amazon.com, there is no valid venue name
                                lbPricingResults.Items.Add(bD.mediaList[key].venueName);  // with amazon.com, there is no valid venue name

                            lbPrice.Items.Add(savedPrice);
                            accumulatedPrice += decimal.Parse(bD.mediaList[key].price);

                            switch (bD.mediaList[key].itemCondn) {
                                case 'n':
                                    lbCondn.Items.Add("New");
                                    break;
                                case 'u':
                                    lbCondn.Items.Add("Used");
                                    break;
                                case ' ':
                                default:
                                    lbCondn.Items.Add(" ");
                                    break;
                            }

                            //  reset everything...
                            savedPrice = bD.mediaList[key].price;
                            savedCondn = bD.mediaList[key].itemCondn;
                            j = 1;

                        }
                        else {  //  non-Amazon pricing...
                            //Console.Write("price: " +  bD.bookList[key].price);  //  DEBUG
                            if (string.IsNullOrEmpty(bD.mediaList[key].price))  //  validate...
                                bD.mediaList[key].price = "0.00";

                            lbPricingResults.Items.Add(bD.mediaList[key].venueName);  //  name of store
                            //    decimal workingPrice = decimal.Parse(bD.bookList[key].price); 
                            //     lbPrice.Items.Add(workingPrice.ToString());
                            lbPrice.Items.Add(bD.mediaList[key].price);  //  price

                            switch (bD.mediaList[key].itemCondn) {
                                case 'n':
                                    lbCondn.Items.Add("New");
                                    break;
                                case 'u':
                                    lbCondn.Items.Add("Used");
                                    break;
                                case ' ':
                                default:
                                    lbCondn.Items.Add(" ");
                                    break;
                            }
                            accumulatedPrice += decimal.Parse(bD.mediaList[key].price.Replace("$", ""));
                        }

                        i++;  //  count number of entries
                        if (i > 34)  //  only have room for 35 
                            break;

                        int lbcount1 = lbPrice.Items.Count;  //  debugging ONLY  <---------------------------------

                        if (cbUseAWS.Checked == true && bD.mediaList.Keys.Count == recordCount)  //  using Amazon prices...  was ==
                        {
                            if (j > 1)
                                lbPricingResults.Items.Add("Amazon.com" + " (" + j.ToString() + " with same price)");  // with amazon.com, there is no valid venue name
                            else
                                lbPricingResults.Items.Add("Amazon.com");  // with amazon.com, there is no valid venue namelbPrice.Items.Add(bD.bookList[key].price);  //  price
                            lbPrice.Items.Add(bD.mediaList[key].price);  //  price
                            switch (bD.mediaList[key].itemCondn) {
                                case 'n':
                                    lbCondn.Items.Add("New");
                                    break;
                                case 'u':
                                    lbCondn.Items.Add("Used");
                                    break;
                                case ' ':
                                default:
                                    lbCondn.Items.Add(" ");
                                    break;
                            }
                        }
                        if (rbMoveLowPrice.Checked) {   //  find lowest price
                            decimal temp = decimal.Parse(bD.mediaList[key].price.Replace("$", ""));
                            if (temp < lowestPrice)
                                lowestPrice = temp;
                        }
                    }

                    int lbcount2 = lbPrice.Items.Count;  //  DEBUGGING  <-------------------------------------------------

                    //try {
                    if (lbPrice.Items.Count > 0) {
                        avgPrice = accumulatedPrice / lbPrice.Items.Count;
                        lAveragePrice.Text = "Average Price: $" + Math.Round(avgPrice, 2);
                        if (rbMoveAvgPrice.Checked == true)
                            tbPrice.Text = Math.Round(avgPrice, 2).ToString();

                        else if (rbMoveLowPrice.Checked)
                            tbPrice.Text = lowestPrice.ToString();
                    }
                    //}
                    //catch (Exception ex) {
                    //    if (ex.Message.Contains("Attempted to divide by zero."))
                    //        ;
                    //}
                }

                //if ((!rbMoveAvgPrice.Checked && !rbMoveLowPrice.Checked) && rc == true)
                if (rc == true)
                    tabTaskPanel.SelectTab(cPricingResults);  //  make pricing tab on top
            }
            else {
                MessageBox.Show("UPC must be 10 or 13 digits long, without any dashes", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Cursor.Current = Cursors.Default;
 #endif
       }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  import items into database
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        static int count = 1;
        static bool firstTimeFlag = true;
        private void importMediaToDatabase() {
            string input;

            if (rbFormatUIEE.Checked == false && rbTabDelimited.Checked == false && rbImportAZ.Checked == false) {
                MessageBox.Show("Input file format missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbStatus.Items.Insert(0, "import started");
            lbStatus.Refresh();

            //  reset any old stuff from previous import
            lbRejectedRecords.Items.Clear();  //  clears listbox
            lRecordsProcessed.Text = "";
            lRecordsRejected.Text = "";
            rejectedCount = 0;

            if (cbDeleteFirst.Checked == true)  //  clear the tMedia table
                truncateMediaTable();

            try {
                //  create stream reader object 
                System.IO.StreamReader sr = new System.IO.StreamReader(sFileName1);
                InputData.Clear();
                count = 1;

                while ((input = sr.ReadLine()) != null)  //  now read entire file into the array
                {
                    if (rbFormatUIEE.Checked == true)
                        InputData.Add(input + "\r\n");
                    else
                        InputData.Add(input);
                }
                sr.Close();  //  close the stream reader
            }
            catch (Exception ex) {
                if (ex.Message.Contains("used by another process")) {
                    MessageBox.Show("File is being used by another process; close the other program and try again", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else {
                    MessageBox.Show("Error trying to open input file: " + ex.Message, "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;

                }
            }

            if (rbTabDelimited.Checked || rbImportAZ.Checked) {  //  convert a tab-delimited file...
                if (firstTimeFlag == true && InputData[0].ToString().IndexOf('\t', 0) == 0) {
                    firstTimeFlag = false;  //  don't go here again...
                    DialogResult dlgResult = DialogResult.None;
                    dlgResult = MessageBox.Show("The file you are trying to import does not appear to be in tab-delimited format; click Yes to process this file", "Prager Media Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dlgResult == DialogResult.No)  //  no, don't process it...
                        return;
                }
                tdf.putHeaderNamesInListBox(sFileName1, lbMappingNames);  //  read the first record to get mapping labels and put in ListBox
                tabTaskPanel.SelectTab(cTabMapping);  //  go to Mapping tab...
            }
            else {  //  it's not a tab-delimited file
                if (rbFormatUIEE.Checked == true) {
                    if (firstTimeFlag == true && InputData[6].ToString().Substring(2, 1) != "|") {
                        firstTimeFlag = false;  //  don't go here again...
                        DialogResult dlgResult = DialogResult.None;
                        dlgResult = MessageBox.Show("The file you are trying to import does not appear to be in UIEE format; click Yes to process this file", "Prager Media Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dlgResult == DialogResult.No)  //  no, don't process it...
                            return;
                    }

                    Cursor.Current = Cursors.WaitCursor; //  change cursor to 'wait'
                    Cursor.Current = Cursors.Default; //  now change it back...
                }
            }

            createCommandString();  //  show all the items
            fillDataBasePanel(commandString);  //  fill the listview

            bOpenFileDialog.Enabled = true;  //  reset controls
            bImportMedia.Enabled = false;

            lbStatus.Items.Insert(0, "import completed");
            lbStatus.Refresh();

            backupNeeded = true;

            return;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    bulk mark items
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bulkMarkBoookStatus(int whatToDo) {
            /*
            whatToDo:
            1 = Sold
            2 = Hold
            3 = For Sale
            */

            Cursor.Current = Cursors.WaitCursor;

            foreach (ListViewItem item in dataBasePanel.SelectedItems) {
                PopulateDetailPanel(item.SubItems[0].Text);

                if (whatToDo == 1)
                    tbQty.Text = "0";

                if (whatToDo == 3)
                    tbQty.Text = "1";

                tMediaUpdateRecord();  //  update it...
            }

            //createCommandString();  //  get sql statement to refresh dataset
            //fillDataBasePanel(commandString);

            Cursor.Current = Cursors.Default;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    exportMedia()
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        private void exportMedia() {

            rbExportInclusiveSearch.Enabled = false;  //  reset it...

            //  create the files in different formats
            int rc = 0;
            DateTime exportStartDateTime = DateTime.Now;  //  do it now because of latency
            string formattedDate = DateTime.Now.ToString("MMddyyyyHHmmss");

            if (rbExportAll.Checked == false && rbChangeDate.Checked == false && rbExportInclusiveSearch.Checked == false && rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  create the CSV file for the Open Dialog
            rc = createCSVFormatExportFile(formattedDate);    // general purpose CSV
            if (rc != 0) {
                MessageBox.Show("There was an error creating the CSV Delimited format export file",
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //--  Half.com
            rc = createHalfDotComCSVExportFile(formattedDate);   //  create a CSV format file for Half.com
            if (rc != 0) {
                MessageBox.Show("There was an error creating the CSV Delimited format export file for Half.com",
                    "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //--  Amazon files
            rc = createAudioExportAmazonFormat(formattedDate);   //  create an Amazon tab-delimited format file
            if (rc != 0) {
                MessageBox.Show("There was an error creating the Amazon.com audio format export file",
                    "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            rc = createVideoExportAmazonFormat(formattedDate);   //  create an Amazon tab-delimited format file
            if (rc != 0) {
                MessageBox.Show("There was an error creating the Amazon.com video format export file",
                    "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //--  Chrislands          <---------- add RC  TODO
            Chrislands chr = new Chrislands();
            rc = chr.createChrislandsCSVExportFile(formattedDate, this, commandString, mediaConn, exportPath);
            if (rc != 0) {
                MessageBox.Show("There was an error creating the export file for Chrislands",
                    "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //--  Alibris
            if (AlibrisUID.Length > 0) {  //  create an Alibris export file
                AlibrisExport ae = new AlibrisExport();
                rc = ae.createAlibrisMovieFormat(this, formattedDate, exportPath, mediaConn);
                if (rc != 0) {
                    MessageBox.Show("There was an error creating the video export file for Alibris",
                        "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                rc = ae.createAlibrisMusicFormat(this, formattedDate, exportPath, mediaConn);
                if (rc != 0) {
                    MessageBox.Show("There was an error creating the music export file for Alibris",
                        "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //--  Papa Media
            PapaMedia pm = new PapaMedia();
            rc = pm.createTabDelimitedFile(this, mediaConn, PapaMediaUID, exportPath, commandString);
            if (rc != 0) {
                MessageBox.Show("There was an error creating the Tab Delimited format export file for Papa Media",
                    "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //--  GEMM
            GEMM gemm = new GEMM();
            rc = gemm.createGEMMExportFormat(formattedDate, this, mediaConn, exportPath);
            if (rc != 0) {
                MessageBox.Show("There was an error creating the Tab Delimited format export file for GEMM",
                    "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  if doing a purge/replace or the date has changed, store new date info
            if (cbPurgeReplace.Checked == true || rbChangeDate.Checked == true) {
                lastExport = exportStartDateTime;  //  store it now just in cast we crashed and didn't complete export
                dateTimePicker1.Value = lastExport;
                dateTimePicker1.Refresh();
            }

            lFileWaiting.Text = "File(s) waiting to be uploaded";  //  on upload tab
            lFileWaiting.Refresh();

            updateCounters();  //  update 

            tabTaskPanel.SelectedIndex = cUpload;  //  go to the Upload Tab
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    cleanUpOldFiles()
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        private void cleanUpOldFiles() {
            if (!Directory.Exists(exportPath)) //  if first time, there is nothing to maintain
                return;

            string[] files = Directory.GetFiles(exportPath, "HDC*.csv");  //  half.com
            int nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "CSV*.csv");
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "AZ*.txt");  //  Amazon
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "*-.txt");
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "AL*.tab");  //  Alibris
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "Val*.csv");
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "CH*.csv");  //  Chrislands
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "purge*.*");
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "ABE*.tab");
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "HB*.txt");
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);


            files = Directory.GetFiles(exportPath, "TB*.tab");
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "UI*.txt");
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            //  do backup files
            files = Directory.GetFiles(backupPath, "*.gbk");
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    prune files
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        private void pruneFiles(string[] files, int nbrOfFiles) {

            DateTime compareDate = DateTime.Now;
            compareDate = compareDate.Subtract(TimeSpan.FromDays(Double.Parse(daysRetention)));

            // go into a loop looking at the creation date of each file
            for (int i = 0; i < nbrOfFiles; i++) {
                DateTime dateCreated = File.GetLastWriteTime(files[i]);
                if (dateCreated.CompareTo(compareDate) == -1)  //  eligible for deletion 
                    if ((File.GetAttributes(files[i]) & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)  //  if not protected, then delete it
                        File.Delete(files[i]);
            }

        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    initialize upload page
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        private void initializeUploadPage() {
            cbUploadAlibris.Enabled = false;  //  initial set just in case they supplied UID
            cbUploadAmazon.Enabled = false;
            cbUploadPapaMedia.Enabled = false;
            cbUploadScribblemonger.Enabled = false;
            cbUploadBandN.Enabled = false;  //  11.4.2
            cbUploadHalfDotCom.Enabled = false;
            cbUploadChrislands.Enabled = false;
            cbUploadCS1.Enabled = false;
            cbUploadCS2.Enabled = false;
            cbUploadCS3.Enabled = false;
            cbUploadCS4.Enabled = false;

            if (AlibrisUID.Length > 0)
                cbUploadAlibris.Enabled = true;

            if ((tbMerchantID.Text.Length > 0 && tbMarketplaceID.Text.Length > 0) && localCulture.ToString() == "en-US")
                cbUploadAmazon.Enabled = true;
            if ((tbMerchantID.Text.Length > 0 && tbMarketplaceID.Text.Length > 0) && localCulture.ToString() == "en-GB")
                cbUploadAmazonUK.Enabled = true;

            if (localCulture.ToString() == "en-US")  //  can't upload outside of your locale
                cbUploadAmazonUK.Enabled = false;
            else if (localCulture.ToString() == "en-GB")
                cbUploadAmazon.Enabled = false;

            if (PapaMediaUID.Length > 0)
                cbUploadPapaMedia.Enabled = true;
            if (ScribblemongerUID.Length > 0)
                cbUploadScribblemonger.Enabled = true;
            if (BandNUID.Length > 0)
                cbUploadBandN.Enabled = true;
            if (ChrislandsUID.Length > 0)
                cbUploadChrislands.Enabled = true;
            if (CSUID1.Length > 0)
                cbUploadCS1.Enabled = true;
            if (CSUID2.Length > 0)
                cbUploadCS2.Enabled = true;
            if (CSUID3.Length > 0)
                cbUploadCS3.Enabled = true;
            if (CSUID4.Length > 0)
                cbUploadCS4.Enabled = true;

        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    test to see if an object is numeric
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        public static bool IsNumeric(object value) {
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();

            if (value == null)
                return false;
            else {
                try {
                    Double d = Double.Parse(value.ToString(), nfi);
                    return true;
                }
                catch (FormatException) {
                    return false;
                }
            }
        }



        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    test to see if an object is an integer
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        public static bool IsInteger(object value) {
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();

            try {
                Int64 d = Int64.Parse(value.ToString(), nfi);
                return true;
            }
            catch (FormatException) {
                return false;
            }
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create index's by mapping ListBox names to heading
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        public int createIndexes() {
            int nbrOfElements = 0;
            if (headingNames != null)  //  check to see if they put anything in the heading names?
                nbrOfElements = headingNames.Length;  //  get number of elements
            if (nbrOfElements < 7) {
                MessageBox.Show("You do not have the minimum number of elements defined (wrong file format selected?); please see Help file for more information", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            //  figure out where each title is in relation to a column
            for (int i = 0; i < nbrOfElements; i++) {
                if (headingNames[i] == "")  //  bypass blank column titles
                    continue;

                //  quantity
                if (tbMapQty.Text == headingNames[i]) {
                    tdf.qtyIndex = i;
                    //ibt.copiesIndex = i;
                }

                //  SKU
                if (tbMapSKU.Text == headingNames[i]) {
                    tdf.SKUIndex = i;
                    //ibt.SKUIndex = i;
                }

                //  UPC
                if (tbMapUPC.Text == headingNames[i]) {
                    tdf.UPCIndex = i;
                    //ibt.catalogIndex = i;
                }

                //  ASIN
                if (tbMapASIN.Text == headingNames[i]) {
                    tdf.ASINIndex = i;
                    //ibt.catalogIndex = i;
                }

                //   product ID type
                if (tbMapProdIDType.Text == headingNames[i]) {
                    tdf.costIndex = i;
                    //ibt.costIndex = i;
                }

                //  description
                if (tbMapDesc.Text == headingNames[i]) {
                    tdf.descIndex = i;
                    //ibt.descIndex = i;
                }

                //  item notes
                if (tbMapItemNotes.Text == headingNames[i]) {
                    tdf.itemNotesIndex = i;
                    //ibt.editionIndex = i;
                }

                //  price
                if (tbMapPrice.Text == headingNames[i]) {
                    tdf.priceIndex = i;
                    //ibt.priceIndex = i;
                }

                //  title
                if (tbMapTitle.Text == headingNames[i]) {
                    tdf.titleIndex = i;
                    //ibt.titleIndex = i;
                }

                //  product ID
                if (tbMapProductID.Text == headingNames[i]) {
                    tdf.ProductIDIndex = i;
                    //ibt.typeIndex = i;
                }

                //  condition
                if (tbMapCondition.Text == headingNames[i]) {  //  <-------------------- change in books
                    tdf.conditionIndex = i;
                    //ibt.conditionIndex = i;
                }

                //  expedited shipping
                if (tbExpedited.Text == headingNames[i]) {
                    tdf.expeditedIndex = i;
                    //ibt.expeditedIndex = i;
                }

                //  international shipping
                if (tbInternational.Text == headingNames[i]) {
                    tdf.internationalIndex = i;
                    //ibt.internationalIndex = i;
                }
            }

            if (rbImportAZ.Checked == false) {
                if (tdf.SKUIndex == -1 || tdf.descIndex == -1 || tdf.titleIndex == -1 || tdf.priceIndex == -1 || tdf.qtyIndex == -1
                    || tdf.conditionIndex == -1) {
                    MessageBox.Show("You are missing one of the required input fields (they are highlighted on the Tab Mapping page)", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            else   //  Amazon file import
            {
                if (tdf.SKUIndex == -1 || tdf.titleIndex == -1 || tdf.priceIndex == -1 || tdf.descIndex == -1) {
                    MessageBox.Show("You are missing one of the required input fields (they are highlighted on the Tab Mapping page)", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            return 0;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    allow user to send trace data
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void fTrace(string str) {

            trace.Add(str);
        }


        ////---------------------    special updates    -----------------------------]
        //private void doSpecialUpdate() {
        //    string dataString = "";
        //    string recordCode = "";
        //    string dataSubString = "";
        //    int i = 0;
        //    int counter = 0;
        //    int rejects = 0;

        //    if (Count(dbPath, ':') > 1) {
        //        MessageBox.Show("Backups can only be done from the machine where the database resides.", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        databaseBackupToolStripMenuItem.Enabled = false;
        //        return;
        //    }
        //    else
        //        backupDatabase();  //  perform a backup for safety reasons...

        //    FbCommand cmd = new FbCommand();

        //    StreamReader sr = new StreamReader(sFileName1);
        //    sr.ReadLine();  //  get past the first record which contains the header information

        //    while ((dataString = sr.ReadLine()) != null)  //  read a record
        //    {
        //        if (dataString != null && dataString != "") {
        //            recordCode = dataString.Substring(0, 4);  //  get the first 4 characters
        //            switch (recordCode) {
        //                case "BOOS":  //  book start, so clear the fields from the last time
        //                    SignedBy = "";
        //                    Edition = "";
        //                    break;
        //                case "BOOK":  //  book number
        //                    i = dataString.Length - 5;
        //                    if (i > 15)
        //                        i = 15;
        //                    SKU = dataString.Substring(5, i);
        //                    break;
        //                case "SGNT":
        //                    i = dataString.Length - 5;
        //                    dataSubString = dataString.Substring(5, i);
        //                    switch (dataSubString.ToLower()) {
        //                        case "signed":
        //                        case "signed by author":
        //                            SignedBy = "A";
        //                            break;
        //                        case "signed by illustrator":
        //                            SignedBy = "I";
        //                            break;
        //                        case "signed by all three":
        //                        case "signed by author and illustrator":
        //                        case "signed by both":
        //                            SignedBy = "B";
        //                            break;
        //                        default:
        //                            lbSUtrace.Items.Insert(0, SKU + "    Author field unknown: " + dataSubString);
        //                            lbSUtrace.Refresh();
        //                            rejects++;
        //                            break;
        //                    }
        //                    break;
        //                case "EDTN":  //  edition
        //                    i = dataString.Length - 5;
        //                    if (i > 15)
        //                        i = 15;
        //                    Edition = dataString.Substring(5, i);
        //                    break;
        //                case "BOOE":  //  indicates end of book listing
        //                    cmd.Connection = mediaConn;
        //                    if (cmd.Connection.State == ConnectionState.Closed)
        //                        cmd.Connection.Open();
        //                    cmd.CommandText = @"UPDATE tMedia SET Signed  = '" + SignedBy + "', Ed = '" + Edition + "'  WHERE SKU = '" + SKU + "'";
        //                    cmd.ExecuteNonQuery();  //  update the file

        //                    lSURecProc.Text = "Records processed: " + counter++;
        //                    lSURecProc.Refresh();
        //                    lSURecRej.Text = "Fields rejected: " + rejects;
        //                    lSURecRej.Refresh();

        //                    //  lines for report

        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //    }
        //    lSUfinished.Visible = true;  //  indicate we're done...
        //}


        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    start service
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void StartService(string serviceName, int timeoutMilliseconds) {
            ServiceController service = new ServiceController(serviceName);
            try {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch {
                // ...  <=================  TODO
            }
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    select all fields for inventory report
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        private void invReportSelectAll() {
            cbIRType.Checked = true;
            cbIRCost.Checked = true;
            cbIRDateA.Checked = true;
            cbIRTitle.Checked = true;
            cbIRDateU.Checked = true;
            cbIRCat.Checked = true;
            cbIRSKU.Checked = true;
            cbIRNotes.Checked = true;
            cbIRStatus.Checked = true;
            cbIRInvoice.Checked = true;
            cbIREdition.Checked = true;
            cbIRUPC.Checked = true;
            cbIRLocn.Checked = true;
            cbIRMediaCond.Checked = true;
            cbIRQty.Checked = true;
            cbIRPrice.Checked = true;
            cbIRAdultContent.Checked = true;
            cbIRPub.Checked = true;
            cbIRASIN.Checked = true;
            cbIRPubYear.Checked = true;
            cbIRPrivNotes.Checked = true;
            cbIRDesc.Checked = true;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create export command string
        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        public string createExportCommandString() {
            if (rbExportAll.Checked == true)  //  are we exporting all of the items?
                commandString = "SELECT * from tMedia WHERE Stat = 'For Sale'";
            else  //  no... find out what we are trying to export
            {
                if (rbExportInclusiveSearch.Checked == true)  //  are we exporting from the search tab?
                {
                    if (inclusiveSearchString.Length == 0) {
                        MessageBox.Show("Error: you must use Inclusive Search to fill Database Panel", "Prager Media Inventory Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        commandString = inclusiveSearchString.Replace("SKU, Title, UPC, Quantity, Locn, Price, Stat, InvoiceNbr", "*");
                }
                else if (rbExportSelected.Checked == true)  //  user has selected which items to export in Database panel
                {
                    //  create the command string, concatening all of the SKU's
                    commandString = "SELECT * from tMedia where Stat <> 'Pending' and SKU IN ('";

                    //  find out which items have been selected
                    ListView.SelectedIndexCollection listData = dataBasePanel.SelectedIndices;
                    foreach (int lvIndex in listData)
                        commandString += dataBasePanel.Items[lvIndex].SubItems[0].Text + "', '";

                    commandString = commandString.Substring(0, commandString.Length - 4) + "')";
                }
                else { //  we are doing a regular export from the Export tab
                    if (changedExportDateTime == false)
                        commandString = "SELECT * from tMedia where Stat <> 'Hold' and " +
                            "Stat <> 'Pending' and " +
                            "DateU >= '" + lastExport.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    else
                        commandString = "SELECT * from tMedia where Stat <> 'Hold' and " +
                            "Stat <> 'Pending' and " +
                            "DateU >= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                }
            }
            return commandString;
        }

        ////----------------    send email if over 30 days and no license    -------------------------------
        //private void send30DayEmail() {
        //    string emailData = "No License (over 30 days): " + DateTime.Now + "\n\rVersion: " + versionNumber +
        //        "\n\rOS: " + osName +
        //        "  (SP: " + osServicePack + ")" +
        //        "\n\rMAC: " + MACAddress;

        //    MailMessage message = new MailMessage();
        //    //message.From = new MailAddress("support@pragersoftware.com");
        //    //message.To.Add(new MailAddress("support@pragersoftware.com"));
        //    message.Subject = "Inventory Program: No License (over 30 days)";
        //    message.Body = emailData;

        //    //SmtpClientEx client = new SmtpClientEx();
        //    SmtpClient client = new SmtpClient();
        //    client.Host = "mail.pragersoftware.com";
        //    client.Port = 25;
        //    client.Credentials = new NetworkCredential("support@pragersoftware.com", "Sp0Kane");

        //    //client.Send(message);
        //    object sendComplete = null; ;
        //    client.SendAsync("support@pragersoftware.com", "support@pragersoftware.com",
        //        "Inventory Program: No License (over 30 days)", emailData, sendComplete);

        //}
    }

}