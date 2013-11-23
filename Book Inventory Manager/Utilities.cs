
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Management;
using System.Net;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using BookInfo;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Win32;


namespace Prager_Book_Inventory
{

    partial class mainForm : Form
    {

        public string sFileName1;
        public string sFileName2;
        string tempArg;

        public class bookData  //  bD
        {
            public string ISBN;
            public decimal listPrice;
            public int salesRank;
            public Dictionary<string, pricingData> bookList = new Dictionary<string, pricingData>();
        }

        public class pricingData  //  pD
        {
            public string venueName;
            public string price;
            public char bookCondn;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    read the configuration file
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void readConfigFile() {
            string applicationPath = Application.StartupPath;
            //applicationPath = @"C:\Program Files (x86)\Prager\Inv";  //  for TESTING ONLY!!
            //applicationPath = @"C:\Program Files\Prager\Inv";  //  for TESTING ONLY!!

            FileInfo newLoc = new FileInfo(@"C:\Prager\Inventory.cfg");
            if (!newLoc.Exists)  //  if the config file is NOT in the new directory...
            {
                //  look at the first possible application path...
                fTrace("I - applicationPath:  " + applicationPath);
                if (applicationPath.Contains("Program Files (x86)"))  //  on 64-bit machines
                {
                    FileInfo x86 = new FileInfo(applicationPath + @"\Inventory.cfg");
                    if (x86.Exists)  //  yep, it's here, so move it to new directory
                        x86.MoveTo(@"C:\Prager\Inventory.cfg");  //  move to new directory
                }
                else  //  application path is C:\Program Files\Prager\Inv (on 32-bit machines)
                {
                    FileInfo x64 = new FileInfo(applicationPath + @"\Inventory.cfg");
                    if (x64.Exists)  //  yep, it's here, so move it to new directory
                        x64.MoveTo(@"C:\Prager\Inventory.cfg");  //  move to new directory
                    else  //  it's missing (shouldn't happen!)
                    {
                        MessageBox.Show("Inventory.cfg file is missing - contact support@pragersoftware.com", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        systemCrash = true;
                        Application.Exit();
                    }
                }
            }

            //  now read it...
            XmlTextReader reader = new XmlTextReader(@"C:\Prager\Inventory.cfg");
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
            //    MessageBox.Show("You need to modify Inventory.cfg file to indicate FIrebird installation path", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);

            fTrace("I - Database Path: " + databasePath);
            fTrace("I - Backup Path: " + backupPath);  //  trace <--
            fTrace("I - Export Path: " + exportPath);

            if (backupPath.Length > 50) {
                fTrace("W - backupPath.Length > 50");
                MessageBox.Show("The backup path length exceeds 50 characters; program is unable to backup files without causing an error.",
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            if (databasePath == null || backupPath == null || exportPath == null || daysRetention == null ||
                databasePath.Length == 0 || backupPath.Length == 0 || exportPath.Length == 0 || daysRetention.Length == 0) {
                fTrace("E - configuration file is invalid");
                MessageBox.Show("The configuration file is invalid; the Inventory program is \nunable to continue without major damage to the database!",
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                throw new System.ArgumentException("invalid configuration file");
            }
            fTrace("I - finished readConfigFile");
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    check memory and OS
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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
                        "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (osName.Contains("Windows XP") == true) {
                if (osServicePack != "2" && osServicePack != "3")
                    MessageBox.Show("Your Service Pack level is not current.  This may affect the execution of this program.",
                        "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (backupPath.Contains("Program Files"))
                    MessageBox.Show("You must change your backup path to a directory that does not have 'Program Files' as a parent\n" +
                        "For information and instructions, please see the Help file (press F1)", "Prager Book Inventory Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            fTrace("I - OS: " + osName);  //  trace

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

            //  machine info
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
                    "program successfully.  Please contact support@pragersoftware.com \nfor instructions.", "Prager Book Inventory Manager", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                //traceSource.TraceInformation("-->Critical - memory: " + memoryInK.ToString());
                //traceSource.Flush();
                Application.Exit();  //  cancel program
            }

            //  get machine serial number
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            //string localMACAddress = String.Empty;
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
                MessageBox.Show("Your screen resolution is too low (" + width.ToString() + " X " + height.ToString() + ") to view the entire program window.  Please set it to something greater than 1024 x 768", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //  32-bit or 64-bit?
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    getTimeSpan
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    parse keywords
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private string parseKeywords(string inputTitle) {
            string workingString = "";

            const string newPattern = @"(?i)\band\b|\bor\b|\bthe\b|\ba\b|\bwith\b|\bof\b|\ban\b|\bin\b|\bor\b|\bat\b|&|\bto\b|\bis\b|\bfor\b|\bnor\b";
            workingString = Regex.Replace(inputTitle, newPattern, "");
            int length = workingString.Length > 80 ? 80 : workingString.Length;

            if (cbAddAuthor2Keywords.Checked == true)  //  if user wants to add author to keywords...
                workingString += tbAuthor.Text;

            return workingString.Substring(0, length).ToUpper() + " ";
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    download Version Info
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        static string DownloadVersionInfo() {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            string replyFromHost = " ";
            StreamReader sr = null;
            try {
                // create a FtpWebRequest object
                request = (HttpWebRequest)HttpWebRequest.Create(new Uri(@"http://www.pragersoftware.com/downloads/versionInfo.txt"));
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
                MessageBox.Show("Unable to determine if there is a new version (site busy)\nPlease try later", "Prager Book Inventory Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return " ";
            }

            return replyFromHost;

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    get book prices from the internet
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void getBookPrices(char bookCondn, string AWSKey) {
            Cursor.Current = Cursors.WaitCursor;

            lbPricingResults.Items.Clear();
            lbPricingResults.Refresh();
            lbPrice.Items.Clear();
            lbPrice.Refresh();
            lbCondn.Items.Clear();
            lbCondn.Refresh();
            lListPrice.Text = "List Price:";  //  clear old price
            lListPrice.Refresh();


            if (mtbISBN.Text.Length >= 10) {  //  only do it if there is an ISBN to check

                mainForm mf = new mainForm(false);

                decimal accumulatedPrice = 0.00M;
                bool rc = true;

                PricingRoutines pr = new PricingRoutines();
                PricingRoutines.PricingData pD = new PricingRoutines.PricingData();
                PricingRoutines.BookData bD = new PricingRoutines.BookData();

                rc = pr.getInternetPrices(mtbISBN.Text, bD, pD);

                //   lVendorNote.Visible = false;  //  if a vendor has multiple books listed...

                if (rc == true) {
                    if (bD.listPrice == 0.0M)
                        lListPrice.Text = "List Price: n/a";
                    else
                        lListPrice.Text = "List Price: " + bD.listPrice;

                    //  fill the listboxes
                    decimal avgPrice = 0.0M;

                    int lbCount = bD.bookList.Count > 35 ? 35 : bD.bookList.Count;
                    if (bD.bookList.Count > 35)
                        lPricesReturned.Text = bD.bookList.Count.ToString() + " prices returned for this book; only showing first 35.";
                    else
                        lPricesReturned.Text = bD.bookList.Count.ToString() + " prices returned for this book.";


                    int i = 0;
                    int j = 1;
                    int recordCount = 0;
                    //string savedPrice = "";
                    //char savedCondn = ' ';
                    decimal lowestPrice = 9999.99M;

                    //  try to aggregate the total of each price (count duplicates)...
                    foreach (string key in bD.bookList.Keys) {

                        recordCount++;  //  so we can tell when we're at EOF

                        if (bD.bookList[key].price == null || bD.bookList[key].price == "")  //  validate...
                            bD.bookList[key].price = "0.00";

                        lbPricingResults.Items.Add(bD.bookList[key].venueName);  //  name of store
                        //    decimal workingPrice = decimal.Parse(bD.bookList[key].price); 
                        //     lbPrice.Items.Add(workingPrice.ToString());
                        lbPrice.Items.Add(bD.bookList[key].price);  //  price

                        switch (bD.bookList[key].bookCondn) {
                            case 'g':
                                lbCondn.Items.Add("Good");
                                break;
                            case 'f':
                                lbCondn.Items.Add("Fair");
                                break;
                            case 'v':
                                lbCondn.Items.Add("Very Good");
                                break;
                            case 'l':
                                lbCondn.Items.Add("Like New");
                                break;
                            case 'a':
                                lbCondn.Items.Add("Acceptable");
                                break;
                            case 'n':
                                lbCondn.Items.Add("New");
                                break;
                            case ' ':
                            default:
                                lbCondn.Items.Add("g");
                                break;
                        }
                        accumulatedPrice += decimal.Parse(bD.bookList[key].price);


                        i++;  //  count number of entries
                        if (i > 34)  //  only have room for 35 
                            break;

                        int lbcount1 = lbPrice.Items.Count;  //  debugging ONLY  <---------------------------------

                        //if (cbUseAWS.Checked == true && bD.bookList.Keys.Count == recordCount)  //  using Amazon prices...  was ==
                        //{
                        //    if (j > 1)
                        //        if (rbAmazonCA.Checked)
                        //            lbPricingResults.Items.Add("Amazon.ca" + " (" + j.ToString() + " with same price)");  // with amazon.com, there is no valid venue name
                        //        else if (rbAmazonUS.Checked)
                        //            lbPricingResults.Items.Add("Amazon.com" + " (" + j.ToString() + " with same price)");
                        //        else
                        //            lbPricingResults.Items.Add(bD.bookList[key].venueName);

                        //    lbPrice.Items.Add(bD.bookList[key].price);  //  price
                        //    switch (bD.bookList[key].bookCondn) {
                        //        case 'n':
                        //            lbCondn.Items.Add("New");
                        //            break;
                        //        case 'u':
                        //            lbCondn.Items.Add("Used");
                        //            break;
                        //        case ' ':
                        //        default:
                        //            lbCondn.Items.Add(" ");
                        //            break;
                        //    }
                        //}

                        if (rbMoveLowPrice.Checked) {   //  find lowest price
                            decimal temp = decimal.Parse(bD.bookList[key].price.Replace("$", ""));
                            if (temp < lowestPrice)
                                lowestPrice = temp;
                        }
                    }

                    int lbcount2 = lbPrice.Items.Count;  //  DEBUGGING  <-------------------------------------------------

                    try {
                        avgPrice = accumulatedPrice / lbPrice.Items.Count;
                        if (CultureInfo.CurrentCulture.Name == "en-US")
                            lAveragePrice.Text = "Average Price: $" + Math.Round(avgPrice, 2);
                        else if (CultureInfo.CurrentCulture.Name == "en-GB")
                            lAveragePrice.Text = "Average Price: £" + Math.Round(avgPrice, 2);

                        if (rbMoveAvgPrice.Checked == true)
                            tbListPrice.Text = Math.Round(avgPrice, 2).ToString();

                        else if (rbMoveLowPrice.Checked)
                            tbListPrice.Text = lowestPrice.ToString();
                    }
                    catch (Exception ex) {
                        if (ex.Message.Contains("Attempted to divide by zero."))
                            ;
                    }
                }
                else
                    lPricesReturned.Text = "0 prices returned for this book";  //  indicate book not found...

                //if ((!rbMoveAvgPrice.Checked && !rbMoveLowPrice.Checked) && rc == true)
                if (rc == true)
                    tabTaskPanel.SelectTab(cPricingResults);  //  make pricing tab on top
            }
            else {
                MessageBox.Show("ISBN must be 10 or 13 digits long, without any dashes", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Cursor.Current = Cursors.Default;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    import books into database
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        static int count = 1;
        static bool firstTimeFlag = true;
        private void importBooksToDatabase() {
            string input;

            if (rbFormatHB.Checked == false && rbFormatUIEE.Checked == false && rbTabDelimited.Checked == false &&
                rbImportAZ.Checked == false && rbImportBT.Checked == false && rbABEtabFile.Checked == false) {
                MessageBox.Show("Input file format missing", "Prager Book Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbStatus.Items.Insert(0, "import started");
            lbStatus.Refresh();

            //  reset any old stuff from previous import
            lbRejectedRecords.Items.Clear();  //  clears listbox
            lRecordsProcessed.Text = "";
            lRecordsRejected.Text = "";
            rejectedCount = 0;

            if (cbDeleteFirst.Checked == true)  //  clear the tBooks table
                truncateBooksTable();

            try {
                //  create stream reader object 
                System.IO.StreamReader sr = new System.IO.StreamReader(sFileName1);
                InputData.Clear();
                count = 1;

                while ((input = sr.ReadLine()) != null)  //  now read entire file into the array  <----------------------------   CR/LF????
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
                    MessageBox.Show("File is being used by another process; close the other program and try again", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else {
                    MessageBox.Show("Error trying to open input file: " + ex.Message, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;

                }
            }

            if (rbTabDelimited.Checked || rbImportAZ.Checked || rbImportBT.Checked || rbABEtabFile.Checked)  //  convert a tab-delimited file...
            {
                if (firstTimeFlag == true && InputData[0].ToString().IndexOf('\t', 0) == 0) {
                    firstTimeFlag = false;  //  don't go here again...
                    DialogResult dlgResult = DialogResult.None;
                    dlgResult = MessageBox.Show("The file you are trying to import does not appear to be in tab-delimited format; click Yes to process this file", "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dlgResult == DialogResult.No)  //  no, don't process it...
                        return;
                }

                //importTabDelimitedFiles itf = new importTabDelimitedFiles();
                tdf.putHeaderNamesInListBox(sFileName1, lbMappingNames);  //  read the first record to get mapping labels and put in ListBox
                tabTaskPanel.SelectTab(cTabMapping);  //  go to Mapping tab...
            }
            else if (rbFormatHB.Checked == true) {
                if (firstTimeFlag == true && InputData[0].ToString().Substring(4, 1) != "|") {
                    firstTimeFlag = false;
                    DialogResult dlgResult = DialogResult.None;
                    dlgResult = MessageBox.Show("The file you are trying to import does not appear to be in HomeBase format; click Yes to process this file", "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dlgResult == DialogResult.No)  //  no, don't process it...
                        return;
                }

                Cursor.Current = Cursors.WaitCursor; //  change cursor to 'wait'
                ParseHBInputOldFormat();  //  now parse and add to database
                Cursor.Current = Cursors.Default; //  now change it back...
            }
            else {

                if (rbFormatUIEE.Checked == true) {
                    if (firstTimeFlag == true && InputData[6].ToString().Substring(2, 1) != "|") {
                        firstTimeFlag = false;  //  don't go here again...
                        DialogResult dlgResult = DialogResult.None;
                        dlgResult = MessageBox.Show("The file you are trying to import does not appear to be in UIEE format; click Yes to process this file", "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dlgResult == DialogResult.No)  //  no, don't process it...
                            return;
                    }

                    Cursor.Current = Cursors.WaitCursor; //  change cursor to 'wait'
                    ParseUIEEInput();
                    Cursor.Current = Cursors.Default; //  now change it back...
                }
            }

            createCommandString();  //  show all the books
            fillDataBasePanel(commandString);  //  fill the listview

            bOpenFileDialog.Enabled = true;  //  reset controls
            bImportBooks.Enabled = false;

            lbStatus.Items.Insert(0, "import completed");
            lbStatus.Refresh();

            backupNeeded = true;

            return;
        }



        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    bulk mark books
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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
                    tbCopies.Text = "0";

                if (whatToDo == 3)
                    tbCopies.Text = "1";

                tBooksUpdateRecord();  //  update it...
            }

            Cursor.Current = Cursors.Default;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    export Books
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void exportBooks() {

            rbExportInclusiveSearch.Enabled = false;  //  reset it...

            if (rbExportAll.Checked == false && rbChangeDate.Checked == false && rbExportInclusiveSearch.Checked == false && rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  now, create the files in different formats for general use
            int rc;
            DateTime exportStartDateTime = DateTime.Now;  //  do it now because of latency
            string formattedDate = DateTime.Now.ToString("MMddyyyyHHmmss");

            rc = exportHBData(formattedDate);  //  general purpose HB format

            if (rc != 0) {
                MessageBox.Show("There was an error creating the HomeBase format export file",
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            rc = createCSVFormatExportFile(formattedDate);    // general purpose CSV
            if (rc != 0) {
                MessageBox.Show("There was an error creating the CSV Delimited format export file",
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            rc = createUIEEExportFile(formattedDate, false);  //  general purpose UIEE
            if (rc == -1) {
                MessageBox.Show("There was an error creating the UIEE format export file",
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            rc = createExportTabFormat(formattedDate);  //  general purpose Tab format
            if (rc != 0) {
                MessageBox.Show("There was an error creating the Tab Delimited format export file",
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //-- ABE
            rc = createABEExport(formattedDate);
            if (rc != 0) {
                MessageBox.Show("There was an error creating the ABE export file",
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //-- Bonanza.com
            rc = createBonanzaExportTabFormat(formattedDate);  //  general purpose Tab format
            if (rc != 0) {
                MessageBox.Show("There was an error creating the Bonanza.com format export file",
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //-- Barnes and Noble
            rc = createBnNExport(formattedDate);
            if (rc != 0) {
                MessageBox.Show("There was an error creating the BnN export file",
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //--  Chrislands
            Chrislands cr = new Chrislands();  //  instantiate
            rc = cr.createChrislandsTabExportFile(formattedDate, this, commandString, bookConn, exportPath);
            if (rc != 0) {
                MessageBox.Show("There was an error creating the Tab-Delimited format export file for Chrislands",
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //-- Half.com 
            rc = createHalfDotComCSVExportFile(formattedDate);
            if (rc != 0) {
                MessageBox.Show("There was an error creating the CSV Delimited format export file for Half.com",
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //-- Valore
            rc = createValoreExportFile(formattedDate);
            if (rc != 0) {
                MessageBox.Show("There was an error creating the CSV Delimited format export file for Valore",
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //--  Amazon (Barnes and Noble also uses Amazon's file)
            rc = createExportAmazonFormat(formattedDate);
            if (rc != 0) {
                MessageBox.Show("There was an error creating the Amazon format export file",
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //--  Papa Media
            PapaMedia pm = new PapaMedia();
            pm.createTabDelimitedFile(this, bookConn, PapaMediaUID, exportPath, commandString);


            //  if doing a purge/replace or the date has changed, store new date info
            if (cbPurgeReplace.Checked == true || rbChangeDate.Checked == true) {
                lastExport = exportStartDateTime;  //  store it now just in cast we crashed and didn't complete export
                dateTimePicker1.Value = lastExport;
                dateTimePicker1.Refresh();
            }

            //  do the following when all of the files have been uploaded
            lFileWaiting.Text = "File(s) waiting to be uploaded";  //  on upload tab
            lFileWaiting.Refresh();

            updateCounters();  //  update counters

            tabTaskPanel.SelectedIndex = cUpload;  //  go to the Upload Tab
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    cleanup Old Files
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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

            files = Directory.GetFiles(exportPath, "Chr*.tab");  //  Chrislands 
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "deleteChr*.tab");  // Chrislands 
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "Val*.csv");
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            //files = Directory.GetFiles(exportPath, "CH*.csv");  //  Chrislands
            //nbrOfFiles = files.Length;
            //pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "purge*.*");
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "ABE*.tab");
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "HB*.txt");
            nbrOfFiles = files.Length;
            pruneFiles(files, nbrOfFiles);

            files = Directory.GetFiles(exportPath, "*.txt");  //  Barnes and Noble
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

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    prune files
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void pruneFiles(string[] files, int nbrOfFiles) {

            DateTime compareDate = DateTime.Now;
            compareDate = compareDate.Subtract(TimeSpan.FromDays(Double.Parse(daysRetention)));

            // go into a loop looking at the creation date of each file
            try {
                for (i = 0; i < nbrOfFiles; i++) {
                    DateTime dateCreated = File.GetLastWriteTime(files[i]);
                    if (dateCreated.CompareTo(compareDate) == -1) //  eligible for deletion 
                        if ((File.GetAttributes(files[i]) & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
                            //  if not protected, then delete it
                            File.Delete(files[i]);
                }
            }
            catch (Exception ex) {
                ;
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    initialize upload page
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void initializeUploadPage() {

            cbUploadAlibris.Enabled = false;  //  initial set just in case they supplied UID
            cbUploadABE.Enabled = false;
            cbUploadAmazon.Enabled = false;
            cbUploadBiblio.Enabled = false;
            cbUploadAntiqBook.Enabled = false;
            cbUploadPapaMedia.Enabled = false;
            cbUploadScribblemonger.Enabled = false;
            cbUploadTomFolio.Enabled = false;
            cbUploadBandN.Enabled = false;  //  11.4.2
            cbUploadBibliophile.Enabled = false;
            cbUploadChooseBks.Enabled = false;
            cbUploadHalfDotCom.Enabled = false;
            cbUploadBiblion.Enabled = false;
            cbUploadGoogleBase.Enabled = false;
            cbUploadChrislands.Enabled = false;
            cbUploadBookByte.Enabled = false;
            cbUploadValoreBooks.Enabled = false;
            cbUploadCS1.Enabled = false;
            cbUploadCS2.Enabled = false;
            cbUploadCS3.Enabled = false;
            cbUploadCS4.Enabled = false;

            if (AlibrisUID.Length > 0)
                cbUploadAlibris.Enabled = true;
            if (ABEUID.Length > 0)
                cbUploadABE.Enabled = true;

            //  check to see if user did a purge/replace and color it red if so
            if (cbPurgeReplace.Checked)
                cbUploadPurgeReplace.ForeColor = System.Drawing.Color.Red;


            //  check for Amazon keys
            if (tbMerchantID.Text.Length > 0 && tbMarketplaceID.Text.Length > 0) {
                cbUploadAmazon.Enabled = true;
                cbUploadAmazonUK.Enabled = true;
                cbUploadAmazonCA.Enabled = true;
            }
            else {
                cbUploadAmazon.Enabled = false;
                cbUploadAmazonUK.Enabled = false;
                cbUploadAmazonCA.Enabled = false;
            }

            if (BiblioUID.Length > 0)
                cbUploadBiblio.Enabled = true;
            if (AntiqBookUID.Length > 0)
                cbUploadAntiqBook.Enabled = true;
            if (PapaMediaUID.Length > 0)
                cbUploadPapaMedia.Enabled = true;
            if (ScribblemongerUID.Length > 0)
                cbUploadScribblemonger.Enabled = true;
            if (TomFolioUID.Length > 0)
                cbUploadTomFolio.Enabled = true;
            if (BibliophileUID.Length > 0)
                cbUploadBibliophile.Enabled = true;
            if (BonanzaUID.Length > 0)
                cbUploadBonanza.Enabled = true;
            if (ChooseUID.Length > 0)
                cbUploadChooseBks.Enabled = true;
            if (tbHalfToken.Text.Length > 0 && HalfDotComUID.Length > 0)
                cbUploadHalfDotCom.Enabled = true;
            if (BiblionUID.Length > 0)
                cbUploadBiblion.Enabled = true;
            if (BandNUID.Length > 0)
                cbUploadBandN.Enabled = true;
            if (GoogleUID.Length > 0)
                cbUploadGoogleBase.Enabled = true;
            if (ChrislandsUID.Length > 0)
                cbUploadChrislands.Enabled = true;
            if (BookByteUID.Length > 0)
                cbUploadBookByte.Enabled = true;
            if (ValoreUID.Length > 0)
                cbUploadValoreBooks.Enabled = true;
            if (CSUID1.Length > 0)
                cbUploadCS1.Enabled = true;
            if (CSUID2.Length > 0)
                cbUploadCS2.Enabled = true;
            if (CSUID3.Length > 0)
                cbUploadCS3.Enabled = true;
            if (CSUID4.Length > 0)
                cbUploadCS4.Enabled = true;

            //  issue warning about sort order of export file names
            if (DateTime.Now.Month == 1) {
                MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();
                DialogResult dlgResult =
                dlg.Show(@"Software\Prager\BookInventoryManager\osFNOrder",  //  registry entry
                "DontShowAgain",  //  registry value name
                DialogResult.OK,  //  default return value returned immediately if box is not shown
                "Don't show this again",  //  message for checkbox
                "Due to the start of another year, the sort order of the exported file names is not in the " +
                "order you expect.  Look at the top of the list for the latest file name; until you export " +
                "enough files to fill up the dialog, they will start at the top.  After that, the files will be in " +
                "descending order.", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    test to see if an object is numeric
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public static bool IsNumeric(object value) {

            System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();

            //  ^([-+]?\d(?:(,\d{3})|(\d*))+\d*)?\.?\d*$ 

            Regex r1;
            Match m1;
            r1 = new Regex(@"^([-+]?\d(?:(,\d{3})|(\d*))+\d*)?\.?\d*$");
            string testValue = (string)value;
            m1 = r1.Match(testValue, 0);
            if (m1.Success)
                return true;
            else
                return false;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    test to see if an object is an integer
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create a thumbnail image from a stored image
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //http://www.csharp-station.com/GlobalErrorHandler.aspx?aspxerrorpath=/Articles/Thumbnails.aspx  ??????????
        private MemoryStream CreateThumbNail(Stream dataStream, string sFileType, int iHeight, int iWidth) {

            EncoderParameters encodeParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 80;
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encodeParams.Param[0] = encoderParam;
            ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();

            ImageCodecInfo jpegICI = null;
            ImageCodecInfo gifICI = null;
            ImageCodecInfo bmpICI = null;
            ImageCodecInfo pngICI = null;

            for (int x = 0; x < arrayICI.Length; x++) {
                if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    jpegICI = arrayICI[x];
                else if (arrayICI[x].FormatDescription.Equals("GIF"))
                    gifICI = arrayICI[x];
                else if (arrayICI[x].FormatDescription.Equals("BMP"))
                    bmpICI = arrayICI[x];
                else if (arrayICI[x].FormatDescription.Equals("PNG"))
                    pngICI = arrayICI[x];
            }

            //Get the image from the  stream.
            System.Drawing.Bitmap image = (Bitmap)System.Drawing.Image.FromStream(dataStream);


            //Scale factor to resize the image.
            double sImageWidth = image.Width;
            double sImageHeight = image.Height;
            double scaleFactor = 0;

            if (iWidth / sImageWidth < iHeight / sImageHeight)
                scaleFactor = iWidth / sImageWidth;
            else
                scaleFactor = iHeight / sImageHeight;

            int iNewHeight = Convert.ToInt32(sImageHeight * scaleFactor);
            int iNewWidth = Convert.ToInt32(sImageWidth * scaleFactor);

            //Get the thumbnail for the image.
            System.Drawing.Bitmap thumbNail = new System.Drawing.Bitmap(iNewWidth, iNewHeight);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(thumbNail);
            g.DrawImage(image, new Rectangle(0, 0, thumbNail.Width, thumbNail.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            image.Dispose();

            MemoryStream ms = new MemoryStream();

            //Save the image corresponding to its Type.
            switch (sFileType.ToLower()) {
                case "jpg":
                case "jpeg":
                    thumbNail.Save(ms, jpegICI, encodeParams);
                    break;

                case "bmp":
                    thumbNail.Save(ms, bmpICI, encodeParams);
                    break;

                case "gif":
                    thumbNail.Save(ms, gifICI, encodeParams);
                    break;

                case "png":
                    thumbNail.Save(ms, pngICI, encodeParams);
                    break;

            }
            return ms;

        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create index's by mapping ListBox names to heading
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int createIndexes() {
            int nbrOfElements = 0;

            if (headingNames != null)  //  check to see if they put anything in the heading names?
                nbrOfElements = headingNames.Length;  //  get number of elements

            if (nbrOfElements < 6 && (rbImportAZ.Checked && nbrOfElements != 4)) {
                MessageBox.Show("You do not have the minimum number of elements defined (wrong file format selected?); please see Help file for more information", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            //  figure out where each title is in relation to a column
            for (int i = 0; i < nbrOfElements; i++) {

                if (headingNames[i].Equals(""))  //  bypass blank column titles
                    continue;

                if (tbMapAddTitle.Text.Equals(headingNames[i])) {
                    tdf.appendToTitleIndex = i;
                    ibt.appendToTitleIndex = i;
                }

                if (tbMapAddDesc2.Text.Equals(headingNames[i])) {
                    tdf.addDesc2Index = i;
                    ibt.addDesc2Index = i;
                }

                if (tbMapAddDesc3.Text.Equals(headingNames[i])) {
                    tdf.addDesc3Index = i;
                    ibt.addDesc3Index = i;
                }

                if (tbNbrOfCopies.Text.Equals(headingNames[i])) {
                    tdf.copiesIndex = i;
                    ibt.copiesIndex = i;
                }

                if (tbMapWeight.Text.Equals(headingNames[i])) {
                    tdf.bookWeightIndex = i;
                    ibt.bookWeightIndex = i;
                }

                if (tbMapAuthor.Text.Equals(headingNames[i])) {
                    tdf.authorIndex = i;
                    ibt.authorIndex = i;
                }

                if (tbMapBinding.Text.Equals(headingNames[i])) {
                    tdf.bindingIndex = i;
                    ibt.bindingIndex = i;
                }

                if (tbMapBookCond.Text.Equals(headingNames[i])) {
                    tdf.bookCondIndex = i;
                    ibt.bookCondIndex = i;
                }

                if (tbMapBookNbr.Text.Equals(headingNames[i])) {
                    tdf.bookNbrIndex = i;
                    ibt.bookNbrIndex = i;
                }

                if (tbMapBookSize.Text.Equals(headingNames[i])) {
                    tdf.bookSizeIndex = i;
                    ibt.bookSizeIndex = i;
                }

                if (tbMapCatalog.Text.Equals(headingNames[i])) {
                    tdf.priCatIndex = i;
                    ibt.priCatIndex = i;
                }

                if (tbMapCatalog.Text.Equals(headingNames[i])) {
                    tdf.priCatIndex = i;
                    ibt.priCatIndex = i;
                }

                if (tbMapSecCat.Text.Equals(headingNames[i])) {
                    tdf.secCatIndex = i;
                    ibt.secCatIndex = i;
                }

                if (tbMapCost.Text.Equals(headingNames[i])) {
                    tdf.costIndex = i;
                    ibt.costIndex = i;
                }

                if (tbMapDateSold.Text.Equals(headingNames[i])) {
                    tdf.dateSoldIndex = i;
                    ibt.dateSoldIndex = i;
                }

                if (tbMapDesc.Text.Equals(headingNames[i])) {
                    tdf.descIndex = i;
                    ibt.descIndex = i;
                }

                if (tbMapDJCond.Text.Equals(headingNames[i])) {
                    tdf.djCondIndex = i;
                    ibt.djCondIndex = i;
                }

                if (tbMapEdition.Text.Equals(headingNames[i])) {
                    tdf.editionIndex = i;
                    ibt.editionIndex = i;
                }

                if (tbMapIllus.Text.Equals(headingNames[i])) {
                    tdf.illusIndex = i;
                    ibt.illusIndex = i;
                }

                if (tbMapISBN.Text.Equals(headingNames[i])) {
                    tdf.ISBNIndex = i;
                    ibt.ISBNIndex = i;
                }

                if (tbMapKeywords.Text.Equals(headingNames[i])) {
                    tdf.keywordsIndex = i;
                    ibt.keywordsIndex = i;
                }

                if (tbMapPrice.Text.Equals(headingNames[i])) {
                    tdf.priceIndex = i;
                    ibt.priceIndex = i;
                }

                if (tbMapPrivateNotes.Text.Equals(headingNames[i])) {
                    tdf.privNotesIndex = i;
                    ibt.privNotesIndex = i;
                }

                if (tbMapPublisher.Text.Equals(headingNames[i])) {
                    tdf.publisherIndex = i;
                    ibt.publisherIndex = i;
                }

                if (tbMapPubLoc.Text.Equals(headingNames[i])) {
                    tdf.pubLocIndex = i;
                    ibt.pubLocIndex = i;
                }

                if (tbMapSignedAuthor.Text.Equals(headingNames[i])) {
                    tdf.signedAuthorIndex = i;
                    ibt.signedAuthorIndex = i;
                }

                if (tbMapSignedIllus.Text.Equals(headingNames[i])) {
                    tdf.signedIllusIndex = i;
                    ibt.signedIllusIndex = i;
                }

                if (tbMapNbrPages.Text.Equals(headingNames[i])) {
                    tdf.nbrOfPagesIndex = i;
                    ibt.nbrOfPagesIndex = i;
                }

                if (tbMapTitle.Text.Equals(headingNames[i])) {
                    tdf.titleIndex = i;
                    ibt.titleIndex = i;
                }

                if (tbMapType.Text.Equals(headingNames[i])) {
                    tdf.typeIndex = i;
                    ibt.typeIndex = i;
                }

                if (tbMapYearPub.Text.Equals(headingNames[i])) {
                    tdf.yearPubIndex = i;
                    ibt.yearPubIndex = i;
                }

                if (tbMapLocation.Text.Equals(headingNames[i])) {
                    tdf.locationIndex = i;
                    ibt.locationIndex = i;
                }

                if (tbExpedited.Text.Equals(headingNames[i])) {
                    tdf.expeditedIndex = i;
                    ibt.expeditedIndex = i;
                }

                if (tbInternational.Text.Equals(headingNames[i])) {
                    tdf.internationalIndex = i;
                    ibt.internationalIndex = i;
                }

                if (tbMapStatus.Text.Equals(headingNames[i])) {
                    tdf.statusIndex = i;
                    ibt.statusIndex = i;
                }
            }

            if (rbImportAZ.Checked == false) {  //  non-Amazon
                if (tdf.bookNbrIndex == -1 || tdf.authorIndex == -1 || tdf.titleIndex == -1 || tdf.publisherIndex == -1 || tdf.priceIndex == -1
                    || tdf.bindingIndex == -1 || tdf.bookCondIndex == -1) {
                    MessageBox.Show("You are missing one of the required input fields (they are highlighted on the Tab Mapping page)", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            else {  //  Amazon file import
                if (tdf.bookNbrIndex == -1 || tdf.titleIndex == -1 || tdf.priceIndex == -1 || tdf.bookCondIndex == -1) {
                    MessageBox.Show("You are missing one of the required input fields (they are highlighted on the Tab Mapping page)", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            return 0;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    special updates
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void doSpecialUpdate() {
            string dataString = "";
            string recordCode = "";
            string dataSubString = "";
            int i = 0;
            int counter = 0;
            int rejects = 0;

            if (Count(dbPath, ':') > 1) {
                MessageBox.Show("Backups can only be done from the machine where the database resides.", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                databaseBackupToolStripMenuItem.Enabled = false;
                return;
            }
            else
                backupDatabase();  //  perform a backup for safety reasons...

            FbCommand cmd = new FbCommand();

            StreamReader sr = new StreamReader(sFileName1);
            sr.ReadLine();  //  get past the first record which contains the header information

            while ((dataString = sr.ReadLine()) != null)  //  read a record
            {
                if (dataString != null && dataString != "") {
                    recordCode = dataString.Substring(0, 4);  //  get the first 4 characters
                    switch (recordCode) {
                        case "BOOS":  //  book start, so clear the fields from the last time
                            SignedBy = "";
                            Edition = "";
                            break;
                        case "BOOK":  //  book number
                            i = dataString.Length - 5;
                            if (i > 15)
                                i = 15;
                            BookNumber = dataString.Substring(5, i);
                            break;
                        case "SGNT":
                            i = dataString.Length - 5;
                            dataSubString = dataString.Substring(5, i);
                            switch (dataSubString.ToLower()) {
                                case "signed":
                                case "signed by author":
                                    SignedBy = "A";
                                    break;
                                case "signed by illustrator":
                                    SignedBy = "I";
                                    break;
                                case "signed by all three":
                                case "signed by author and illustrator":
                                case "signed by both":
                                    SignedBy = "B";
                                    break;
                                default:
                                    lbSUtrace.Items.Insert(0, BookNumber + "    Author field unknown: " + dataSubString);
                                    lbSUtrace.Refresh();
                                    rejects++;
                                    break;
                            }
                            break;
                        case "EDTN":  //  edition
                            i = dataString.Length - 5;
                            if (i > 15)
                                i = 15;
                            Edition = dataString.Substring(5, i);
                            break;
                        case "BOOE":  //  indicates end of book listing
                            cmd.Connection = bookConn;
                            if (cmd.Connection.State == ConnectionState.Closed)
                                cmd.Connection.Open();
                            cmd.CommandText = @"UPDATE tBooks SET Signed  = '" + SignedBy + "', Ed = '" + Edition + "'  WHERE BookNbr = '" + BookNumber + "'";
                            cmd.ExecuteNonQuery();  //  update the file

                            lSURecProc.Text = "Records processed: " + counter++;
                            lSURecProc.Refresh();
                            lSURecRej.Text = "Fields rejected: " + rejects;
                            lSURecRej.Refresh();

                            //  lines for report

                            break;
                        default:
                            break;
                    }
                }
            }
            lSUfinished.Visible = true;  //  indicate we're done...
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    start service
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void StartService(string serviceName, int timeoutMilliseconds) {
            ServiceController service = new ServiceController(serviceName);
            try {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch {
                // ...
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    select all fields for inventory report
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void invReportSelectAll() {
            cbIRType.Checked = true;
            cbIRSize.Checked = true;
            cbIRCost.Checked = true;
            cbIRDateA.Checked = true;
            cbIRTitle.Checked = true;
            cbIRDateU.Checked = true;
            cbIRSigned.Checked = true;
            cbIRCat.Checked = true;
            cbIRSKU.Checked = true;
            cbIRNotes.Checked = true;
            cbIRStatus.Checked = true;
            cbIRAuthor.Checked = true;
            cbIRInvoice.Checked = true;
            cbIREdition.Checked = true;
            cbIRSecCat.Checked = true;
            cbIRIllus.Checked = true;
            cbIRDNRFlag.Checked = true;
            cbIRISBN.Checked = true;
            cbIRPages.Checked = true;
            cbIRLocn.Checked = true;
            cbIRWeight.Checked = true;
            cbIRBookCond.Checked = true;
            cbIRQty.Checked = true;
            cbIRPrice.Checked = true;
            cbIRShipping.Checked = true;
            cbIRPub.Checked = true;
            cbIRBinding.Checked = true;
            cbIRPubLoc.Checked = true;
            cbIRPubYear.Checked = true;
            cbIRJacket.Checked = true;
            cbIRKeywords.Checked = true;
            cbIRDesc.Checked = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  clear existing tab mapping for importing
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void clearExistingImportMapping() {

            tbMapAddTitle.Text = "";
            tbMapAddDesc2.Text = "";
            tbMapAddDesc3.Text = "";
            tbNbrOfCopies.Text = "";
            tbMapWeight.Text = "";
            tbMapAuthor.Text = "";
            tbMapBinding.Text = "";
            tbMapBookCond.Text = "";
            tbMapBookNbr.Text = "";
            tbMapBookSize.Text = "";
            tbMapCatalog.Text = "";
            tbMapCost.Text = "";
            tbMapDateSold.Text = "";
            tbMapDesc.Text = "";
            tbMapDJCond.Text = "";
            tbMapEdition.Text = "";
            tbMapIllus.Text = "";
            tbMapISBN.Text = "";
            tbMapKeywords.Text = "";
            tbMapPrice.Text = "";
            tbMapPrivateNotes.Text = "";
            tbMapPublisher.Text = "";
            tbMapPubLoc.Text = "";
            tbMapSignedAuthor.Text = "";
            tbMapSignedIllus.Text = "";
            tbMapNbrPages.Text = "";
            tbMapTitle.Text = "";
            tbMapType.Text = "";
            tbMapLocation.Text = "";
            tbMapYearPub.Text = "";
            tbInternational.Text = "";
            tbExpedited.Text = "";
            tbMapStatus.Text = "";

        }
    }
}