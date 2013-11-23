#define COMPILED4OTHERS
//#define TRACE

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Win32;

/*
Consider a version format of X.Y.Z (Major.Minor.Patch). 
Bug fixes not affecting the API increment the patch version, 
backwards compatible API additions/changes increment the minor version, and 
backwards incompatible API changes increment the major version.
*/

namespace Media_Inventory_Manager
{

    //  License: hlLhVtP+NFT6OAf3H9zlIQ==
    //  GUID:  9438e730-458f-48ea-9511-c56ef3790f98

    public partial class mainForm : Form
    {
        public static IFormatProvider localCulture = System.Globalization.CultureInfo.CurrentCulture;  //  get current culture
        public static DateTime compileDate = DateTime.Parse("Apr 21, 2013 8:05 AM", localCulture);
        public static string versionNumber = "13.111 " + compileDate.ToString("dd-MMM-yyyy");
        //public static string versionNumber = "1.2.2 BETA   " + compileDate.ToString("dd-MMM-yyyy");
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++    verify UploadListings.cs - line 418 (return statement to prevent uploads)    ++++++++++++++
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /*---------------    Changes    -------------------------
        *----    1.0.x    ----
         -  changed:  cleaned-up the inventory report  (1.1.0)
         -  fixed:  database connection string  (1.1.0)
         -  added: MAC address to replace GUID in license verification  (1.1.1)
         -  added:  export file created for GEMM  (1.1.1)
         -  fixed:  Alibris music and video export files  (1.1.2)
         -  fixed: error in license logic (1.2.0)
         -  added:  option for SKU prefix and suffix  (1.2.1)
         -  added: option for starting SKU number  (1.2.1)
         -  fixed: Auto-SKU numbering with prefix (13.111)

        */
        /* --------------    TODO    ----------------------------
         
        HIGH PRIORITY
         * web browser
         * *  create sample tab-delimited import file
        *  creaate code for normal tab-delimited file
        *	Get ASIN
         *	repricing routines
        * 
        MEDIUM PRIORITY

        LOW PRIORITY
        
        */

        //static TraceSource traceSource = new TraceSource("prager");  //  for tracing mainForm
        #region  //  public objects
        public bool searchOnCatalog = false;
        public bool dataBaseMissing = false;
        public bool addButtonClicked = false;
        public bool choosingSecondary = false;
        public bool choosingPrimary = false;
        public bool statusForSale = false;
        public bool flagCannedText = false;  //  indicates if the dgv is "alive" 
        static string osServicePack = "";
        static string osName = "";
        public static string MACAddress = String.Empty;
        static string amountOfMemory = String.Empty;
        public static DateTime installedDate;
        public static DateTime renewalDate;  //  decrypted
        public static bool freeTrialExpired = false;
        public static bool missingAmazonKeys = false;
        public static string commandString;
        public bool backupRestoreFlag = false;
        public static bool systemCrash = false;  //  crash indicator so we can exit cleanly
        public static bool criticalError = false;
        public static string backupPath;
        public static string imagePath;
        public static string exportPath;
        public static string daysRetention;
        public static string programOptionsPath;
        public static string programUnlockCode;
        public static bool notFoundFlag;
        public bool changedExportDateTime = false;
        public ArrayList InputData = new ArrayList();
        ArrayList DelimitedData = new ArrayList();
        static public ArrayList shoppingCart = new ArrayList();
        importTabDelimitedFiles tdf = new importTabDelimitedFiles();
        public bool backupNeeded = false;
        static public string dataBaseName;
        static public string firebirdInstallationPath;
        public static string databasePath;
        public static string serverInstance;
        public static string serverInstallationPath;
        public static string[] headingNames;
        string pictureFileName = "";
        public static bool updateNeeded = false;
        static System.Threading.Mutex appMutex;
        public string programFilesDirectoryName;
        DateTime lastExport;
        public static string googleRegisteredFilename;
        public static string storedGUID;
        public static DateTime expireDate;
        public static string eDate;
        FbDataAdapter dAdapter = null;
        DataTable dTable = null;
        FbCommandBuilder cBuilder = null;

        //  default tab order
        int cPricingResults = 0;
        int cExport = 1;
        int cUpload = 2;
        int cAccounting = 3;
        int cRepricing = 4;
        int cASIN = 5;
        int cProgramOptions = 6;
        int cCustomerInfo = 7;
        int cInvoice = 8;
        int cMediaDetail = 9;
        int cSearch = 10;
        int cTabMapping = 11;
        int cImport = 12;
        int cMassChanges = 13;
        int cCannedText = 14;
        int cUIDPswd = 15;
        int cReports = 16;
        int cWebPages = 17;
        int cStatus = 18;
        #endregion

        Color enabled = Color.FromKnownColor(KnownColor.Control);
        static public ArrayList trace = new ArrayList();

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  constructors
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public mainForm() {
            InitializeComponent();  //  auto-generated
            ProgramInitialization();
        }
        public mainForm(bool flag) { //  don't show splash screen or do anything else
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  Program Initialization
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void ProgramInitialization() {

            Cursor.Current = Cursors.WaitCursor;

            fTrace("\nI - starting initialization");

            //  get program files directory name
            programFilesDirectoryName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            fTrace("I - programFilesDirectoryName:  " + programFilesDirectoryName);

            appMutex = new System.Threading.Mutex(false, "PragerInventoryMutex");  //  prevents install when program is running

            splashScreen ss = new splashScreen();

            //  start progress bar
            ss.splashProgressBar.Increment(5);


            //  read config file
            ss.Text = "reading configuration file...";
            ss.Show();
            fTrace("I - reading configuration file");
            readConfigFile();  //  read the configuration file

            //  check memory and OS
            ss.Text = "checking memory and operating system";
            ss.Refresh();
            fTrace("I - checking memory and OS");
            checkMemoryAndOS();  //  make sure we have enough memory, etc.

            ss.splashProgressBar.Increment(5);

            //  check for internet connection  
            ss.Text = "checking internet connection";
            ss.Refresh();
            fTrace("I - checking internet connection");
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()) {
                fTrace("E - no internet connection");
                DialogResult dlgResult = DialogResult.None;
                dlgResult = MessageBox.Show("No internet connection; do you wish to work offline?", "Prager Media Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.Yes)
                    workOfflineToolStripMenuItem.Checked = true;
                else
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
            }

            ss.splashProgressBar.Increment(5);

            //  check data base components
            ss.Text = "checking database components";
            ss.Refresh();
            fTrace("I - checking database components");
            string OperSysName = osName.ToString();

            try {
                ServiceController service = new ServiceController("firebird guardian - defaultinstance");
                if (service.Status == ServiceControllerStatus.Stopped)
                    StartService("firebird guardian - defaultinstance", 5000);
            }
            catch (Exception ex) {
                if (ex.Message.Contains("Unable to complete network request to host"))

                    fTrace("E - error trying to start Firebird Guardian; " + ex.Message);
                MessageBox.Show("Error 190: unable to start Firebird Guardian - " + ex.Message + "\nPlease notify Prager, Software", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

#if COMPILED4OTHERS
            dataBaseName = "dbMedia.fdb";
            this.Text = "Prager Media Inventory Manager    Version  " + versionNumber;
#else
            dataBaseName = "dbPrager";
            this.Text = "Prager, Booksellers    Version " + versionNumber;
#endif

            Cursor.Current = Cursors.WaitCursor;

            //  check to see if database is there...
            dbPath = databasePath + dataBaseName;

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
                MessageBox.Show("The database is missing and the program can not continue. \nNotify support@pragersoftware.com for help", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }

            ss.splashProgressBar.Increment(5);

            //  now check for Firebird installation path and gsec.exe
            RegistryKey regKey = null;
            String appName = null;

            appName = "FBDBServer_2_1_is1";
            string keyPath32 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\" + appName;  //  32 bit OS
            string keyPath64 = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\" + appName;  //  64-bit OS

            regKey = Registry.LocalMachine.OpenSubKey(keyPath32);
            if (regKey != null)
                firebirdInstallationPath = regKey.GetValue("InstallLocation") as String;     // Cast to String in case of NULL value
            else {
                regKey = Registry.LocalMachine.OpenSubKey(keyPath64);
                if (regKey != null)
                    firebirdInstallationPath = regKey.GetValue("InstallLocation") as String;
            }

            fTrace("I - Firebird installation path: " + firebirdInstallationPath);

            if (!File.Exists(firebirdInstallationPath + @"bin\gsec.exe")) {
                fTrace("W - gsec.exe not found");
                MessageBox.Show("Unable to find Firebird file gsec.exe; please notify Support via our website", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            ss.splashProgressBar.Increment(5);

            try  //  now, let's try to connect to the database
            {
                mediaConn = new FbConnection("User=media;Password=prager;Database=" + dbPath);
                //mediaConn = new FbConnection("User=sysdba;Password=masterkey;Database=" + dbPath);
                mediaConn.Open();
            }
            catch (Exception ex) {
                if (ex.Message.Contains("Your user name and password are not defined")) {
                    fTrace("W - user name and password were not defined");

                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo.WorkingDirectory = firebirdInstallationPath;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.FileName = firebirdInstallationPath + @"bin\gsec.exe";
                    p.StartInfo.Arguments = "-user sysdba -pass masterkey -add media -pw prager";
                    p.Start();
                    p.WaitForExit();

                    MessageBox.Show("User ID and password created; you must restart the program...", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();


                }
                else {
                    if (ex.Message.Contains("Unable to complete network request to host"))  //  should never get here!
                        StartService("firebird guardian - defaultinstance", 5000);
                    else {
                        fTrace("E - error occurred while verifying the database; " + ex.Message);
                        MessageBox.Show("An error occurred while verifying the database (" + dbPath + "): " + ex.Message + "\nPlease notify support@pragersoftware.com of this error", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        throw new System.ArgumentException("error during database verification");
                    }
                }
            }

            ss.splashProgressBar.Increment(5);

            //  verify installation date
            fTrace("I - going to verify installation date");
            int retCode = checkInstallationDate();  //  if install date is missing, then database is new...
            fTrace("I - returned from checkInstallationDate; rc= " + retCode.ToString());
            if (retCode == -1)  //  error in database engine during initial open
            {
                MessageBox.Show("Unable to open database - contact support@pragersoftware.com", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                throw new System.ArgumentException("unable to open database");
            }

            ss.splashProgressBar.Increment(5);

            //  modify the database tables
            ss.Text = "Performing database maintenance";
            ss.Refresh();
            fTrace("I - going to modify the database tables");
            modifyExistingTables(ss);  //  do database maintenance if necessary

            ss.splashProgressBar.Increment(5);

            //  have to restore UIDs and Passwords so options can be restored properly (this must appear before restoreOptions())
            ss.Text = "populating User IDs and Passwords...";
            ss.Refresh();
            fTrace("I - populating user id's and passwords");
            populateUIDs ui = new populateUIDs();  //  upload UploadInfo info and populate datagrid
            ui.populateDataGridView(UIDdataGridView);
            if (UIDdataGridView.Rows.Count > 11)  //  means table is farkeled up
                ui.removeDuplicates(UIDdataGridView, ui);  //  remove the extra entries

            ss.splashProgressBar.Increment(5);

            //  restore program options
            ss.Text = "restoring program options...";
            ss.Refresh();
            fTrace("I - restoring program options");

            //   //  see if tCannedText is alive
            //   dAdapter = new FbDataAdapter("SELECT * FROM tCannedText", mediaConn);
            //   dTable = new DataTable();
            //   dAdapter.Fill(dTable);  //  fill the datatable
            //   BindingSource bSource = new BindingSource();
            //   cBuilder = new FbCommandBuilder(dAdapter);  //  make the FbCommandBuilder
            //   dAdapter.InsertCommand = cBuilder.GetInsertCommand(false);
            //   dAdapter.UpdateCommand = cBuilder.GetUpdateCommand(true);
            //   dAdapter.DeleteCommand = cBuilder.GetDeleteCommand(true);

            //   bSource.DataSource = dTable;
            //   dgvCannedText.DataSource = bSource;  //  set the dgv source object

            //   if (dgvCannedText.Rows[0].Cells[0].Value != null)  //  look-see if there is anything in it...
            //       flagCannedText = true;

            restoreOptions();  //  restore any saved options

            //  now restore custom site names
            UIDdataGridView.Rows[7].Cells[0].Value = tbCustomSite1.Text;  //  set site names from DGV
            UIDdataGridView.Rows[8].Cells[0].Value = tbCustomSite2.Text;
            UIDdataGridView.Rows[9].Cells[0].Value = tbCustomSite3.Text;
            UIDdataGridView.Rows[10].Cells[0].Value = tbCustomSite4.Text;
            UIDdataGridView.Columns[0].ReadOnly = true;  //  now make first column read-only

            fTrace("I - going to createCommandString");
            createCommandString();  //  create the general purpose command string

            ss.splashProgressBar.Increment(5);

            //  fill listview panel
            ss.Text = "filling database panel...";
            ss.Refresh();
            fTrace("I - going to database panel...");
            fillDataBasePanel(commandString);  //  fill the tMedia datagridview

            //  fill country combobox
            const string selectString = "SELECT * FROM TCountries";
            dAdapter = new FbDataAdapter(selectString, mediaConn);
            DataTable source = new DataTable();
            dAdapter.Fill(source);
            coOrigin.DataSource = source;
            coOrigin.DisplayMember = "CountryName";
            coOrigin.ValueMember = "CountryID";



            //  updating counters
            ss.Text = "updating counters...";
            ss.Refresh();
            fTrace("I - updating counters...");
            updateCounters();  //  update "items waiting" counter

            tabTaskPanel.SelectTab(cMediaDetail);//  make Detail tab the default

            bGetMediaInfo.Enabled = false;

#if COMPILED4OTHERS
            int rc = 0;

            ss.splashProgressBar.Increment(5);

            //  checking License
            ss.Text = "Checking license...";
            ss.Refresh();
            fTrace("I - Checking license...");

            LicenseScreen licScreen = new LicenseScreen();

            LicenseInformation LicInfo = new LicenseInformation();
            rc = LicInfo.getLicenseInformation();
            string reason = "";
            switch (rc) {
                case 0:
                    reason = "Valid";
                    break;
                case -1:
                    reason = "Installation date missing/invalid";
                    break;
                case -2:
                    reason = "Expiration date missing/invalid";
                    break;
                case -3:
                    reason = "30-days free license";
                    break;
                case -4:
                    reason = "1-year free license";
                    break;
                case -5:
                    reason = "License expired";
                    freeTrialExpired = true;
                    break;
                default:
                    reason = "unknown return code: " + rc.ToString();
                    break;
            }
            fTrace("I - return code from checking license: " + reason);

            if (rc < 0)  //  time has expired
            {
                switch (rc) {
                    case -1:
                        licScreen.tbLicenseMsg.Text = "The installation date is missing or altered." +
                            "\nPlease contact support@pragersoftware.com for further help.";
                        licScreen.Show();
                        licScreen.TopMost = true;
                        break;
                    case -2:
                        licScreen.tbLicenseMsg.Text = "Expiration date is missing or altered; please contact support@pragersoftware.com to resolve this issue";
                        licScreen.Show();
                        licScreen.TopMost = true;
                        break;
                    case -3:   //  grant a 30-day extension
                        break;
                    case -5:
                        licScreen.tbLicenseMsg.Text = "Your license has expired; please renew it now";

                        freeTrialExpired = true;  //  remove permissions
                        cbAutoPricingLookup.Enabled = false;
                        cbAutoPricingLookup.Checked = false;
                        rbExportInclusiveSearch.Enabled = false;
                        bGetMediaInfo.Enabled = false;
                        bLookupPrices.Enabled = false;  //  don't allow user to lookup prices
                        licScreen.Show();
                        licScreen.TopMost = true;
                        break;
                }
            }
            else  //  rc = 0, time not expired dispose of it...
                licScreen.Dispose();


#endif

            ss.splashProgressBar.Increment(5);

            //  now check settings...
            if (cbToolTips.Checked == true)
                toolTip1.Active = false;
            else
                toolTip1.Active = true;

            lPricingServiceStatus.Text = "";  //  initialize this too...

            if (cbCondition.Items.Count == 0) {
                MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();
                DialogResult dlgResult =
                dlg.Show(@"Software\Prager\MediaInventoryManager\MediaCondition",  //  registry entry
                "DontShowAgain",  //  registry value name
                DialogResult.OK,  //  default return value returned immediately if box is not shown
                "Don't show this again",  //  message for checkbox
                "You have not initialized the media condition menu; do you want to do it now?", "Prager Media Inventory Manager",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dlgResult == DialogResult.Yes) {
                    tabTaskPanel.SelectTab(cProgramOptions);
                    tabPrimary.SelectTab(2);
                }
            }

            missingAmazonKeys = false;
            if (tbAWSKey.Text.Length == 0 || tbAWSSecretKey.Text.Length == 0) {
                fTrace("W - Amazon keys are missing");
                MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();
                DialogResult dlgResult =
                dlg.Show(@"Software\Prager\MediaInventoryManager\AmazonKeys",  //  registry entry
                "DontShowAgain",  //  registry value name
                DialogResult.OK,  //  default return value returned immediately if box is not shown
                "Don't show this again",  //  message for checkbox
                "You must have an Amazon Access Key and Secret Key to to do most functions; do you want to get them now?\n\n" +
                "If you don't get them, you may be unable to get media info or lookup prices." +
                "(When you have them, enter them on the User ID's and Passwords page)", "Prager Media Inventory Manager",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dlgResult == DialogResult.Yes) {
                    System.Diagnostics.Process.Start(@"http://www.amazon.com/gp/aws/registration/registration-form.html");
                    tabTaskPanel.SelectTab(cUIDPswd);
                }
                else {
                    missingAmazonKeys = true;  //  don't allow Amazon functions
                    bGetMediaInfo.Enabled = false;
                    bUpdateInfo.Enabled = false;
                    bLookupPrices.Enabled = false;
                }
            }

            ss.splashProgressBar.Increment(5);

            ss.Text = "checking for updates...";
            ss.Refresh();
            fTrace("I - checking for updates");

            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.RunWorkerAsync();  //  check for program updates in a separate thread

            ss.splashProgressBar.Increment(5);

            fTrace("I - initialization completed");
            ss.Text = "Initialization completed...";
            ss.Refresh();

            Cursor.Current = Cursors.Default;

            ss.Close();
            ss.Dispose();

            MsgBoxCheck.MessageBox dlg1 = new MsgBoxCheck.MessageBox();
            DialogResult dlgResult1 =
            dlg1.Show(@"Software\Prager\Inventory Program\osTicket",  //  registry entry
            "DontShowAgain",  //  registry value name
            DialogResult.OK,  //  default return value returned immediately if box is not shown
            "Don't show this again",  //  message for checkbox
            "We have recently introduced two new pages to our website that we want you to be aware of.  First, we " +
            "have added a new issue tracking system that we would like you to use rather than sending us emails. " +
            "We get a lot of emails, and don't want to lose any of the important ones.  It's intuitive and we think, easy to use. " +
            "It can  be found on the website's Support page." +
            "\n\nThe other page is a What's New page where you can find the latest information about what's happening, " +
            "including programs, critical issues, etc.  It's kinda like a blog, but we haven't got time to work on a blog " +
            "right now (too many things going on at Amazon!).  We will convert it to a blog on the website's Home page after " +
            "we have time to breathe!\n\nThanks to all of you for your support; we continually strive to make our software " +
            "the best in the business for a reasonable price!", "Prager Media Inventory Manager",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  tab selected
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tabSelected(object sender, TabControlEventArgs e) {
            //    freeTrialExpired = true;  //  testing only  <--------
            if (freeTrialExpired == true)
                switch (tabTaskPanel.SelectedTab.Name) {
                    case "browserTab":  //  websites
                    case "ExportTab":  //  export files
                    case "pricingResultsTab": //  pricing results
                    case "alterPricesTab":  //  mass changes
                    case "customerInfoTab":  //  customer info
                    case "invoiceTab":  //  invoice
                    case "uploadTab":  //  upload
                    case "UIDandPswdMaintenance":  //  user id's and passwords
                    case "RePricingTool":  //  repricing
                    case "Reports":  //  reports
                    case "getASIN":  //  getASIN
                        MessageBox.Show("That function is available only in the Licensed version.",
                            "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabTaskPanel.SelectTab(cMediaDetail);  //  make media detail default tab
                        LicenseScreen licScreen = new LicenseScreen();  //  show license screen
                        licScreen.Show();
                        return;
                    default:
                        break;
                }

            switch (tabTaskPanel.SelectedTab.Name) {
                case "browserTab":
                    break;
                case "pricingResultsTab":  //  pricing results
                case "alterPricesTab":  //  mass changes
                    break;
                case "customerInfoTab":  //  customer info
                    bAddCustomer.Enabled = true;
                    if (customerLVInitialized == false)
                        initializeCustomerListView();
                    lUpdateStatus2.Visible = false;
                    fillCustomerListView();
                    break;
                case "invoiceTab":  //  invoice
                    initializeInvoice();
                    bAddInvoice.Enabled = true;
                    lUpdateStatus.Visible = false;
                    pInvoiceLogo.ImageLocation = pictureFileName;  //  restore logo to invoice
                    break;
                case "optionsTab":  //  options
                    break;
                case "mappingTab":  //  tab mapping
                    lOptionsSaved.Visible = false;
                    lbMappingNames.Enabled = true;  //  default
                    if (rbImportAZ.Checked) {  //  if this is an Amazon import, prefill fields
                        tbMapSKU.Text = "seller-sku";
                        tbMapTitle.Text = "item-name";
                        tbMapDesc.Text = "item-description";
                        tbMapPrice.Text = "price";
                        tbMapUPC.Text = "product-id";
                        tbMapCondition.Text = "item-condition";
                        tbMapQty.Text = "quantity";
                        tbMapAddDesc2.Text = "item-note";
                        lbMappingNames.Enabled = false;  //  don't allow changes if it's Amazon
                    }
                    else
                        restoreImportTabMapping();
                    break;
                case "Import":  //  import
                    break;
                case "searchTab":  //  search
                    tbsrchTitle.Focus();
                    break;
                case "mediaDetailTab": //  media detail
                    tbUPC.SelectionStart = 0;
                    if (cbAutomaticSKU.Checked == true) {
                        tbSKU.Enabled = false;
                        //tbSKUPrefix.Enabled = false;
                        //lSKUPrefix.Enabled = false;
                        //tbSKUSuffix.Enabled = false;
                        //lSKUSuffix.Enabled = false;
                    }
                    else {
                        tbSKU.Enabled = true;
                        //tbSKUPrefix.Enabled = true;
                        //lSKUPrefix.Enabled = true;
                        //tbSKUSuffix.Enabled = true;
                        //lSKUSuffix.Enabled = true;
                    }
                    updateNeeded = false;  //  just in case...
                    break;
                case "ExportTab":  //  export
                    updateCounters();
                    break;
                case "uploadTab": //  upload
                    initializeUploadPage();
                    break;
                case "accountingTab":  //  accounting
                    lbAcctgYear.SetSelected(8, true);  //  sets default year
                    updateItemStatistics();  //  get initial database statistics
                    break;
                case "cannedTextTab":  //  canned text
                    break;
                case "UIDandPswdMaintenance": //  user id's and passwords
                    lMsgSettingsSaved.Visible = false;
                    break;
                case "StatusTab":  //  status & log
                    bSendTrace.Enabled = false;
                    break;
                case "Reports":  //  reports
                    break;
                case "RePricingTool":  //  re-pricing tool
                case "getASIN":  //  ASIN
                default:
                    MessageBox.Show("Sorry, but this is not supported at this time", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //if (rbStartDetail.Checked == true)
                    tabTaskPanel.SelectTab(cMediaDetail);//  make Detail tab the default
                    break;
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  delete an item
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bDeleteItem_Click(object sender, EventArgs e) {
            //  find which row was selected
            ListView.SelectedIndexCollection listData = dataBasePanel.SelectedIndices;

            int rc = 0;
            foreach (int lvIndex in listData) {
                rc = tMediaDeleteEntry(dataBasePanel.Items[lvIndex].SubItems[0].Text);
                if (rc == -1)
                    break;
            }

            createCommandString();
            clearDetailPanel();  //  remove reminants of item(s) just deleted
            fillDataBasePanel(commandString);

            backupNeeded = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  clear entries in detail panel
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bClear_Click(object sender, EventArgs e) {
            clearDetailPanel();
            tbUPC.Clear();
            tbUPC.SelectionStart = 0;
            tbUPC.Focus();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  the text of the filename has changed
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbFileName_TextChanged(object sender, EventArgs e) {
            bImportMedia.Enabled = true;
            bOpenFileDialog.Enabled = true;  //  reset controls
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  reprice items
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bReprice_Click(object sender, EventArgs e) {
            changePrices();
            backupNeeded = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  selected "Changed since" for export
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            //  set to date/time of last export  
            lastExport = dateTimePicker1.Value;
            updateCounters();
            changedExportDateTime = true;

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  add a record
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bAddRecord_Click(object sender, EventArgs e) {
            addRecord();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  update detail record
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bUpdateRecord_Click(object sender, EventArgs e) {

            if (cbAllowAddUpdate.Checked == false)  //  check for required fields?
            {
                if (checkForRequiredFields() == -1)  //  some fields are missing
                {
                    updateNeeded = true;  //  was doing an update, so allow it again
                    return;
                }
                else
                    bUpdateRecord.Enabled = true; //  make sure it's enabled
            }

            tMediaUpdateRecord();

            bUpdateRecord.BackColor = enabled;
            updateNeeded = false;  //  reset it...
            backupNeeded = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  change SKU, mark for sale and add
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bRelist_Click(object sender, EventArgs e) {
            relistItem();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  build a file for export
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bExport_Click(object sender, EventArgs e) {
            exportMedia();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  rbChangeDate checked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void rbChangeDate_CheckedChanged(object sender, EventArgs e) {
            dateTimePicker1.Enabled = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  rbExportAll checked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void rbExportAll_CheckedChanged(object sender, EventArgs e) {
            dateTimePicker1.Enabled = false;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  rbImportMedia clicked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bImportMedia_Click(object sender, EventArgs e) {
            if (tbFileName.Text.Length == 0) {
                MessageBox.Show("You must choose a file to import.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            importMediaToDatabase();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  user has clicked the Continue button on the import
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bContinueImport_Click(object sender, EventArgs e) {

            tabTaskPanel.SelectTab(cImport);  //  go to Import tab
            tabTaskPanel.Refresh();

            if (createIndexes() == -1)  //  create index's from mapping
                return;

            //  do the actual import
            tdf.convertFile(this, sFileName1, lRecordsProcessed, lbMappingNames, lRecordsRejected, lbRejectedRecords, rbMarkAsSold, rbReplaceRecord, rbImportAZ);

            createCommandString();  //  show all items
            fillDataBasePanel(commandString);  //  fill the listview

            bOpenFileDialog.Enabled = false;  //  reset controls
            bImportMedia.Enabled = false;

            backupNeeded = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  Help files are on the web
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://www.pragersoftware.com/webhelp/index.html");
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  show the About screen
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            aboutScreen about = new aboutScreen();
            about.Show();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  user wants to do a backup
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e) {
            if (Count(dbPath, ':') > 1) {
                MessageBox.Show("Backups can only be done from the machine where the database resides.", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                databaseBackupToolStripMenuItem.Enabled = false;
                return;
            }

            backupDatabase();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    restore the database
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void restoreToolStripMenuItem_Click(object sender, EventArgs e) {

            restoreDatabase();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    prep for the upload
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bFTPUpload_Click(object sender, EventArgs e) {

            if (workOfflineToolStripMenuItem.Checked == true) {  //  we're working offline for now...
                MessageBox.Show("You are working offline (go to Tools->Work Offline); you can not upload unless you have an internet connection",
                    "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbUploadAmazon.Checked && !cbUploadAmazonUK.Checked) {
                MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();
                DialogResult dr =
                    dlg.Show(@"Software\Prager\MediaInventoryManager\MWSkeys",  //  registry entry
                    "DontShowAgain",  //  registry value name
                    DialogResult.OK,  //  default return value returned immediately if box is not shown
                    "Don't show this again",  //  message for checkbox
                    "A reminder that you must register for Amazon's Marketplace Web Services (MWS) BEFORE you can upload any items.\n" +
                    "Go to our web-based Help, click on Uploading Files to the Listing Services -> Amazon Setup for further information",
                    "Prager Media Inventory Manager",  //  window title
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);  //  button and icon code
            }

            //webBrowser1.Navigate("https://mws.amazonservices.com/scratchpad/index.html");  //  prime web page

            prepareForUpload();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    event when X is clicked on upper right of form
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            updateCounters();  //  check to see if there are any items waiting to be exported

            if (lItemsWaiting.Text.Substring(0, 1) != "0" && backupRestoreFlag == false && systemCrash == false) {
                DialogResult dlgResult = DialogResult.None;
                dlgResult = MessageBox.Show("You have media waiting to be exported and uploaded.\rDo you want to exit anyway?",
                    "Prager Media Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)  //  no, don't exit
                {
                    e.Cancel = true;
                    return;
                }
            }
            //else if (systemCrash == true) {
            //    MessageBox.Show("The program has encountered a critical error and must close - " +
            //        "please go to our website (pragersoftware.com/support), open a new issue and tell us " +
            //        "specifically what you were doing and what error message (if any) was displayed.",
            //        "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            //    throw new System.ArgumentException("Unknown System Crash");
            //}

            if (dataBaseMissing == false) {
                tabTaskPanel.SelectTab(cStatus);  //  to to the status page

                saveOptions();  //  save options each time...

                if (backupRestoreFlag == false) //  means we have not just done a restore
                {
                    if (cbBackupDB.Checked == true || backupNeeded == true)
                        databaseBackupToolStripMenuItem_Click(sender, e);
                }
            }


            //  close the FbConnections
            if (mediaConn != null && mediaConn.State == ConnectionState.Open)
                mediaConn.Close();

            //  clean up the files in the directory
            if (cbAutoFileRetention.Checked == true)
                cleanUpOldFiles();

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    when 'exit' is clicked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e) {
            this.Close();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make cost 'stickey'
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lCost_Click(object sender, EventArgs e) {
            if (lCost.ForeColor == SystemColors.ControlDark)
                lCost.ForeColor = SystemColors.ControlText;
            else
                lCost.ForeColor = SystemColors.ControlDark;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make location 'stickey'
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lLocation_Click(object sender, EventArgs e) {
            if (lLocation.ForeColor == SystemColors.ControlDark)
                lLocation.ForeColor = SystemColors.ControlText;
            else
                lLocation.ForeColor = SystemColors.ControlDark;

        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make shipping 'stickey'
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void gbShipping_Click(object sender, EventArgs e) {
            if (gbShipping.ForeColor == SystemColors.ControlDark)
                gbShipping.ForeColor = SystemColors.ControlText;
            else
                gbShipping.ForeColor = SystemColors.ControlDark;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make binding 'stickey'
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lBinding_Click(object sender, EventArgs e) {
            if (lBinding.ForeColor == SystemColors.ControlDark)
                lBinding.ForeColor = SystemColors.ControlText;
            else
                lBinding.ForeColor = SystemColors.ControlDark;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make condition 'stickey'
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lCondition_Click(object sender, EventArgs e) {
            if (lCondition.ForeColor == SystemColors.ControlDark)
                lCondition.ForeColor = SystemColors.ControlText;
            else
                lCondition.ForeColor = SystemColors.ControlDark;
        }


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    make jacket 'stickey'
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void lJacket_Click(object sender, EventArgs e) {
        //    if (lMediaType.ForeColor == SystemColors.ControlDark)
        //        lMediaType.ForeColor = SystemColors.ControlText;
        //    else
        //        lMediaType.ForeColor = SystemColors.ControlDark;
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    check to see if there are any changes to canned titles
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbCannedTitle1_Leave(object sender, EventArgs e) {
            if (tbCannedTitle1.Text.CompareTo("Repl w/ title") != 0) {
                lbCannedText.Items.Remove(0);
                lbCannedText.Items.Insert(0, tbCannedTitle1.Text);
                lbCannedText.Refresh();
            }
        }

        private void tbCannedTitle2_Leave(object sender, EventArgs e) {
            if (tbCannedTitle2.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(1, tbCannedTitle2.Text);
        }

        private void tbCannedTitle3_Leave(object sender, EventArgs e) {
            if (tbCannedTitle3.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(2, tbCannedTitle3.Text);
        }

        private void tbCannedTitle4_Leave(object sender, EventArgs e) {
            if (tbCannedTitle4.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(3, tbCannedTitle4.Text);
        }

        private void tbCannedTitle5_Leave(object sender, EventArgs e) {
            if (tbCannedTitle5.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(4, tbCannedTitle5.Text);
        }

        private void tbCannedTitle6_Leave(object sender, EventArgs e) {
            if (tbCannedTitle6.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(5, tbCannedTitle6.Text);
        }

        private void tbCannedTitle7_Leave(object sender, EventArgs e) {
            if (tbCannedTitle7.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(6, tbCannedTitle7.Text);
        }

        private void tbCannedTitle8_Leave(object sender, EventArgs e) {
            if (tbCannedTitle8.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(7, tbCannedTitle8.Text);
        }

        private void tbCannedTitle9_Leave(object sender, EventArgs e) {
            if (tbCannedTitle9.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(8, tbCannedTitle9.Text);
        }

        private void tbCannedTitle10_Leave(object sender, EventArgs e) {
            if (tbCannedTitle10.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(9, tbCannedTitle10.Text);
        }

        private void tbCannedTitle11_Leave(object sender, EventArgs e) {
            if (tbCannedTitle11.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(10, tbCannedTitle11.Text);
        }

        private void tbCannedTitle12_Leave(object sender, EventArgs e) {
            if (tbCannedTitle12.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(11, tbCannedTitle12.Text);
        }

        private void tbCannedTitle13_Leave(object sender, EventArgs e) {
            if (tbCannedTitle13.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(12, tbCannedTitle13.Text);
        }

        private void tbCannedTitle14_Leave(object sender, EventArgs e) {
            if (tbCannedTitle14.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(13, tbCannedTitle14.Text);
        }

        private void tbCannedTitle15_Leave(object sender, EventArgs e) {
            if (tbCannedTitle15.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(14, tbCannedTitle15.Text);
        }

        private void tbCannedTitle16_Leave(object sender, EventArgs e) {
            if (tbCannedTitle16.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(15, tbCannedTitle16.Text);
        }

        private void tbCannedTitle17_Leave(object sender, EventArgs e) {
            if (tbCannedTitle17.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(16, tbCannedTitle17.Text);
        }

        private void tbCannedTitle18_Leave(object sender, EventArgs e) {
            if (tbCannedTitle18.Text.CompareTo("Repl w/ title") != 0)
                lbCannedText.Items.Insert(17, tbCannedTitle18.Text);
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  user has selected a row in the lbCannedText
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lbCannedText_SelectedIndexChanged(object sender, EventArgs e) {
            switch (lbCannedText.SelectedIndex) {
                case 0:
                    tbItemNote.AppendText("  " + tbCannedDesc1.Text);
                    break;
                case 1:
                    tbItemNote.AppendText("  " + tbCannedDesc2.Text);
                    break;
                case 2:
                    tbItemNote.AppendText("  " + tbCannedDesc3.Text);
                    break;
                case 3:
                    tbItemNote.AppendText("  " + tbCannedDesc4.Text);
                    break;
                case 4:
                    tbItemNote.AppendText("  " + tbCannedDesc5.Text);
                    break;
                case 5:
                    tbItemNote.AppendText("  " + tbCannedDesc6.Text);
                    break;
                case 6:
                    tbItemNote.AppendText("  " + tbCannedDesc7.Text);
                    break;
                case 7:
                    tbItemNote.AppendText("  " + tbCannedDesc8.Text);
                    break;
                case 8:
                    tbItemNote.AppendText("  " + tbCannedDesc9.Text);
                    break;
                case 9:
                    tbItemNote.AppendText("  " + tbCannedDesc10.Text);
                    break;
                case 10:
                    tbItemNote.AppendText("  " + tbCannedDesc11.Text);
                    break;
                case 11:
                    tbItemNote.AppendText("  " + tbCannedDesc12.Text);
                    break;
                case 12:
                    tbItemNote.AppendText("  " + tbCannedDesc13.Text);
                    break;
                case 13:
                    tbItemNote.AppendText("  " + tbCannedDesc14.Text);
                    break;
                case 14:
                    tbItemNote.AppendText("  " + tbCannedDesc15.Text);
                    break;
                case 15:
                    tbItemNote.AppendText("  " + tbCannedDesc16.Text);
                    break;
                case 16:
                    tbItemNote.AppendText("  " + tbCannedDesc17.Text);
                    break;
                case 17:
                    tbItemNote.AppendText("  " + tbCannedDesc18.Text);
                    break;
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  check for updates
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void getUpdatesToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("http://pragersoftware.com/downloads.htm");
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    display license screen
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void licenseToolStripMenuItem_Click(object sender, EventArgs e) {
            LicenseScreen licScreen = new LicenseScreen();
            licScreen.Show();
        }



        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    populate detail panel
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //int i;
        //private void dgItems_Click(object sender, EventArgs e) {

        //    PopulateDetailPanel(SKU);  //  now populate the detail panel
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    do an inclusive search
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bSSearch_Click(object sender, EventArgs e) {
            doInclusiveSearch();
        }



        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    databasePanel selected index changed
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ListView.SelectedIndexCollection dbPanelIndex = null;
        private void dataBasePanel_SelectedIndexChanged(object sender, EventArgs e) {

            dbPanelIndex = dataBasePanel.SelectedIndices;  //  find which row was selected

            if (dbPanelIndex.Count > 1) {  //  more than one row was selected..
                bDeleteItem.Enabled = true;
                bClone.Enabled = true;
                bLookupPrices.Enabled = false;
                bGetMediaInfo.Enabled = false;
                bUpdateInfo.Enabled = false;
                bLookupPrices.Enabled = false;
                bAddRecord.Enabled = false;
                bUpdateRecord.Enabled = false;
                bRelist.Enabled = false;
                bClear.Enabled = false;
                bNextItem.Enabled = false;
            }
            else if (dbPanelIndex.Count == 1) {  //  only selected one row
                //if (rbExportSelected.Checked)
                //    return;

                foreach (int lvIndex in dbPanelIndex)
                    SKU = dataBasePanel.Items[lvIndex].SubItems[0].Text;

                if (tabTaskPanel.SelectedIndex == cASIN) {  //  if we are just going after the ASIN...
                    if (workOfflineToolStripMenuItem.Checked == true)
                        return;  //  we're working offline for now...

                    populateASINPage(SKU);  //  fill in media data
                    tbasinASIN.Text = "";
                    Application.DoEvents();

                    asin grabbit = new asin();
                    grabbit.getASIN(listView1, tbasinSKU.Text, tbasinTitle.Text, tbasinAuthor.Text, tbasinPublisher.Text, tbAWSKey.Text,
                        tbAWSSecretKey.Text, tbasinASIN, mediaConn, dataBasePanel, dataBasePanel.SelectedIndices, tbAZAssocTag.Text);
                }
                else
                    PopulateDetailPanel(SKU);  //  now populate the detail panel

                tbSKU.Enabled = false;  //  don't allow the number to be changed
                bDeleteItem.Enabled = true;  //  allow deletes regardless of status
                bClone.Enabled = true;
                bClear.Enabled = true;
                bNextItem.Enabled = true;

                if (tbQty.Text.Length != 0 && int.Parse(tbQty.Text) == 0) {  //  item has been sold, so don't allow anything except 'delete' and 'relist'   
                    bLookupPrices.Enabled = false;
                    bGetMediaInfo.Enabled = false;
                    bUpdateInfo.Enabled = false;
                    bLookupPrices.Enabled = false;
                    bAddRecord.Enabled = false;
                    bUpdateRecord.Enabled = true;  //  just in case it was a mistake
                    bRelist.Enabled = true;
                }
                else {  //  item has a quantity of 1 or greater or has been placed on Hold
                    updateNeeded = false;  //  just in case...

                    if (!freeTrialExpired)
                        bLookupPrices.Enabled = true;

                    bUpdateInfo.Enabled = true;
                    bAddRecord.Enabled = false;
                    bUpdateRecord.Enabled = true;
                    bRelist.Enabled = false;

                    if (tbUPC.Text.Length == 0 && mtbASIN.Text.Length == 0)
                        bGetMediaInfo.Enabled = false;
                    else
                        bGetMediaInfo.Enabled = true;
                }

                if (tabTaskPanel.SelectedIndex != cASIN)
                    tabTaskPanel.SelectTab(cMediaDetail);//  make Detail tab the default

                dataBasePanel.Focus();
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    when the user presses the arrow key, change the current selection
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void dataBasePanel_KeyPress(object sender, KeyPressEventArgs e) {
            int index;

            if (dataBasePanel.SelectedIndices.Count == 0) // if there is no items selected, do nothing
                return;

            index = dataBasePanel.SelectedIndices[0];
            index++;
            dataBasePanel.Focus();

            if (e.KeyChar == (char)Keys.Up) {
                if (index > 0)   //  check the index before reaching out of bounds
                    dataBasePanel.Items[index - 1].Selected = true;
            }
            else if (e.KeyChar == (char)Keys.Down) {
                if (index < dataBasePanel.Items.Count - 1)
                    dataBasePanel.Items[index].Selected = true;  //  select item...

                dataBasePanel.Items[index].Selected = true;
                dataBasePanel.FocusedItem = dataBasePanel.Items[index];
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    add item to shopping cart
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bShoppingCart_Click(object sender, EventArgs e) {
            if (int.Parse(tbQty.Text) != 0) {
                MessageBox.Show("Quantity is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListViewItem lvi = dataBasePanel.FindItemWithText(tbSKU.Text);  //  find the item we were working on...
            int listIndex = lvi.Index;

            if (dataBasePanel.Items[listIndex].SubItems[7].Text.Length == 0)  //  if greater than zero, this item is already attached to invoice
                shoppingCart.Add(tbSKU.Text);
            else
                MessageBox.Show("This item is already attached to an invoice: " + dataBasePanel.Items[listIndex].SubItems[7].Text,
                    "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    start with a new shopping cart
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bClearShoppingCart_Click(object sender, EventArgs e) {
            shoppingCart.Clear();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    report a problem
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void reportaproblemToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("http://pragersoftware.com/support.htm");
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user has clicked exit on the menu
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void toolStripMenuItemExit_Click(object sender, EventArgs e) {
            this.Close();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    usr clicked the mass change button
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bMassChange_Click(object sender, EventArgs e) {
            makeMassChange();
        }


        ////---------------------------------------------------------------------------------------
        //private void rbNo_CheckedChanged(object sender, EventArgs e) {
        //    bMassChange.Enabled = false;
        //}


        ////---------------------------------------------------------------------------------------
        //private void lbMChangeFields_SelectedIndexChanged(object sender, EventArgs e) {

        //    switch (lbMChangeFields.SelectedItem.ToString()) {
        //        case "Location":  //  can not be null
        //            tbMChangeFrom.MaxLength = 10;
        //            tbMChangeTo.MaxLength = 10;
        //            lMaxLength.Text = "10";
        //            break;
        //        case "Type":
        //        case "Edition":
        //            tbMChangeFrom.MaxLength = 15;
        //            tbMChangeTo.MaxLength = 15;
        //            lMaxLength.Text = "15";
        //            break;
        //        case "Size":
        //            tbMChangeFrom.MaxLength = 40;
        //            tbMChangeTo.MaxLength = 40;
        //            lMaxLength.Text = "40";
        //            break;
        //        case "Keywords":
        //            tbMChangeFrom.MaxLength = 85;
        //            tbMChangeTo.MaxLength = 85;
        //            lMaxLength.Text = "85";
        //            break;
        //        case "Jacket":
        //        case "Binding":
        //        case "Condition":
        //        case "Mfgr Location":
        //            tbMChangeFrom.MaxLength = 25;
        //            tbMChangeTo.MaxLength = 25;
        //            lMaxLength.Text = "25";
        //            break;
        //        case "Catalog":
        //        case "Private Notes":
        //            tbMChangeFrom.MaxLength = 50;
        //            tbMChangeTo.MaxLength = 50;
        //            lMaxLength.Text = "50";
        //            break;
        //        case "Cost":
        //            tbMChangeFrom.MaxLength = 7;
        //            tbMChangeTo.MaxLength = 7;
        //            lMaxLength.Text = "7";
        //            break;
        //        case "Shipping":
        //            tbMChangeFrom.MaxLength = 2;
        //            tbMChangeTo.MaxLength = 2;
        //            lMaxLength.Text = "2";
        //            break;
        //        default:
        //            break;
        //    }

        //    lMaxLength.Refresh();
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    delete an invoice
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bDeleteInvoice_Click(object sender, EventArgs e) {
            deleteRecordFromInvoiceTable();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  user wants to update the invoice table
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bUpdateInvoice_Click(object sender, EventArgs e) {
            updateInvoiceTable();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user wants to add an invoice
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bAddInvoice_Click(object sender, EventArgs e) {
            addInvoiceToTable();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  search by Customer number
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bCustSearch_Click(object sender, EventArgs e) {
            searchByCustomerNbr();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    search by invoice number
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bInvSearch_Click(object sender, EventArgs e) {
            searchByInvoiceNbr();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  do a print preview of the invoice
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bPrintPreview_Click(object sender, EventArgs e) {
            previewPrintInvoice();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    do a print setup
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bPageSetup_Click(object sender, EventArgs e) {
            pageSetup();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    print the invoice
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bPrintInvoice_Click(object sender, EventArgs e) {
            printInvoice();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    print the document
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            tbBusinessAddr.BorderStyle = BorderStyle.None;
            if (cbUseReceipt.Checked == false)
                drawInvoice(e.Graphics);
            else
                drawReceipt(e.Graphics);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    change the logo
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bChangeLogo_Click(object sender, EventArgs e) {

            openFileDialog1.Filter = @"BMP files (*.bmp)|*.bmp|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                pInvoiceLogo.Image = Image.FromFile(openFileDialog1.FileName);
                pictureFileName = openFileDialog1.FileName;
            }

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    remove an item from the shopping cart
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bRemoveItem_Click(object sender, EventArgs e) {
            removeShoppingCartItem();
        }



        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    sort on database panel columns
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private int sortColumn = -1;
        private string sequence = "";
        private void dataBasePanel_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e) {
            if (cbSortOverride.Checked)  // if overriding the sorting of columns, do nothing
                return;

            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn) {
                sortColumn = e.Column;
                sequence = "ASC";
            }
            else {
                // Determine what the last sort order was and change it.
                if (sequence == "ASC")
                    sequence = "DESC";
                else
                    sequence = "ASC";
            }

            //string commandString = "";
            if (cbFreezeDBPanel.Checked == false) {
                if (tsShowForSale.Checked == true)
                    commandString = "SELECT SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr from tMedia where Stat = 'For Sale' ORDER BY ";
                else if (tsShowHold.Checked == true)
                    commandString = "SELECT SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr from tMedia where Stat = 'Hold' ORDER BY ";
                else if (tsShowSold.Checked == true)
                    commandString = "SELECT SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr from tMedia where Stat = 'Sold' ORDER BY ";
                else if (tsShowPending.Checked == true)
                    commandString = "SELECT SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr from tMedia where Stat = 'Pending' ORDER BY ";
                else
                    commandString = "SELECT SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr from tMedia ORDER BY ";
            }
            else  //  "freeze results" is in effect
            {

                commandString = inclusiveSearchString + " ORDER BY ";  //  use inclusive search select statement
            }

            switch (sortColumn)  //  determine which column to sort on...
            {
                case 0:  //  SKU
                    commandString += "SKU " + sequence;
                    break;
                case 1:  //  Title
                    commandString += "Title " + sequence;
                    break;
                case 2:  //  number of copies
                    commandString += " Quantity " + sequence;
                    break;
                case 3:  //  UPC
                    commandString += "UPC " + sequence;
                    break;
                case 4:  //  location
                    commandString += "Locn " + sequence;
                    break;
                case 5:  //  price
                    commandString += "Price " + sequence;
                    break;
                case 6:  //  status
                    commandString += "Stat " + sequence;
                    break;
                case 7:  //  invoice
                    commandString += "InvoiceNbr " + sequence;
                    break;
            }

            fillDataBasePanel(commandString);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    validate price field
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
                e.Handled = true;  //  reject the keypress
        }


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    validate 'to' price field
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void tbPriceTo_KeyPress(object sender, KeyPressEventArgs e) {
        //    if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
        //        e.Handled = true;
        //}


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    make sure amount is numeric
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void tbAmount_KeyPress(object sender, KeyPressEventArgs e) {
        //    if (char.IsDigit(e.KeyChar) == false && e.KeyChar != '.' && e.KeyChar != '\b')
        //        e.Handled = true;
        //}


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    user changed the Title text
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void tbTitle_TextChanged(object sender, EventArgs e) {

        //}


        ////----------------------------------------------------------------------------------------
        //private void tbAuthor_TextChanged(object sender, EventArgs e) {
        //    //  if we are adding a record, don't highlight 'update' button
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }

        //    if (tbTitle.Text.Length > 0)
        //        bGetMediaInfo.Enabled = true;
        //    else
        //        bGetMediaInfo.Enabled = false;
        //}


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    publisher text has changed
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void tbPub_TextChanged(object sender, EventArgs e) {

        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    common routine for text changed
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void textbox_TextChanged(object sender, EventArgs e) {
            if (updateNeeded == true) {  //  if we are adding a record, don't highlight 'update' button
                bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
                bUpdateRecord.Enabled = true;
            }
        }


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    description text has changed
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void tbDesc_TextChanged(object sender, EventArgs e) {

        //}


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    primary catalog text changed
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void tbPriCatalog_TextChanged(object sender, EventArgs e) {
        //    //  if we are adding a record, don't highlight 'update' button
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }

        //    if (tbCatalogID.Text.Length > 50)
        //        tbCatalogID.Text = tbCatalogID.Text.Substring(0, 50);
        //}


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    notes changed
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void tbNotes_TextChanged(object sender, EventArgs e) {

        //}


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    copy mapping names
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void copyCtrlCToolStripMenuItem_Click(object sender, EventArgs e) {
        //    Clipboard.SetDataObject(lbMappingNames.SelectedItem.ToString());

        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    print Database Panel
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bPrintListView_Click(object sender, EventArgs e) {
            printInclusiveSearchResults();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    preview inclusive search results
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bPrintPreviewLV_Click(object sender, EventArgs e) {
            previewInclusiveSearchResults();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    purge/replace has been checked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void cbPurgeReplace_CheckedChanged(object sender, EventArgs e) {
            if (cbPurgeReplace.Checked == true) {
                if (cbUploadAlibris.Checked == false &&
                    cbUploadAmazon.Checked == false &&
                    cbUploadChrislands.Checked == false) {
                    MessageBox.Show("You do not have a valid site checked for purge/replace on the Uploads page",
                        "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    cbUploadPurgeReplace.Checked = true;  //  check here too...
            }
            else
                cbUploadPurgeReplace.Checked = false;  //  make sure this matches...
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    mouse down on Mapping names
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lbMappingNames_MouseDown(object sender, MouseEventArgs e) {
            // Start the Drag Operation
            string strItem = e.ToString();
            DoDragDrop(strItem, DragDropEffects.Copy | DragDropEffects.Move);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    drag and drop for tab mapping                                     <------- TODO
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbMapSKU_DragDrop(object sender, DragEventArgs e) {
            tbMapSKU.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapTitle_DragDrop(object sender, DragEventArgs e) {
            tbMapTitle.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapPublisher_DragDrop(object sender, DragEventArgs e) {
            tbMapPublisher.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapDesc_DragDrop(object sender, DragEventArgs e) {
            tbMapDesc.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapPrice_DragDrop(object sender, DragEventArgs e) {
            tbMapPrice.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapEdition_DragDrop(object sender, DragEventArgs e) {
            tbMapItemNotes.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapCatalog_DragDrop(object sender, DragEventArgs e) {
            tbMapASIN.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapUPC_DragDrop(object sender, DragEventArgs e) {
            tbMapUPC.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapMediaCond_DragDrop(object sender, DragEventArgs e) {
            tbMapMediaCond.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapPubLoc_DragDrop(object sender, DragEventArgs e) {
            tbMapPubLoc.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapCost_DragDrop(object sender, DragEventArgs e) {
            tbMapProdIDType.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapYearPub_DragDrop(object sender, DragEventArgs e) {
            tbMapCondition.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapType_DragDrop(object sender, DragEventArgs e) {
            tbMapProductID.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapDateSold_DragDrop(object sender, DragEventArgs e) {
            tbMapDateSold.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapStatus_DragDrop(object sender, DragEventArgs e) {
            tbMapStatus.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapPrivateNotes_DragDrop(object sender, DragEventArgs e) {
            tbMapPrivateNotes.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapLocation_DragDrop(object sender, DragEventArgs e) {
            tbMapLocation.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbNbrOfCopies_DragDrop(object sender, DragEventArgs e) {
            tbMapQty.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapAddDesc1_DragDrop(object sender, DragEventArgs e) {
            tbMapAddTitle.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapAddDesc2_DragDrop(object sender, DragEventArgs e) {
            tbMapAddDesc2.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapAddDesc3_DragDrop(object sender, DragEventArgs e) {
            tbMapAddDesc3.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbExpedited_DragDrop(object sender, DragEventArgs e) {
            tbExpedited.Text = lbMappingNames.SelectedItem.ToString();
        }
        private void tbInternational_DragDrop(object sender, DragEventArgs e) {
            tbInternational.Text = lbMappingNames.SelectedItem.ToString();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    common mapping drag and drop routine
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void mappingDragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    add customer to table clicked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bAddCustomer_Click(object sender, EventArgs e) {
            addCustomerInfo();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update customer table clicked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bCustUpdate_Click(object sender, EventArgs e) {
            updateCustomerTable();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    delete customer from customer table
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bCustDelete_Click(object sender, EventArgs e) {
            deleteRecordFromCustomerTable();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    mass changes - type of change
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void rbAbsolute_CheckedChanged(object sender, EventArgs e) {
            if (rbAbsolute.Checked == true) {
                rbPercentage.Enabled = false;
                rbAmount.Enabled = false;
                tbAmount.Focus();
            }
            else {
                rbPercentage.Enabled = true;
                rbAmount.Enabled = true;
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    display open file dialog
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bOpenFileDialog_Click(object sender, EventArgs e) {
            // Display the OpenDialog Window to allow user to select a file for importing
            openFileDialog1.Filter = @"Import files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                if (sender == bOpenFileDialog) {
                    sFileName1 = openFileDialog1.FileName;
                    tbFileName.Text = sFileName1;
                    bImportMedia.Enabled = true;
                }

                return;
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    save mapping
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bSaveMapping_Click(object sender, EventArgs e) {
            saveMapping();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user has changed accounting year
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lbAcctgYear_SelectedValueChanged(object sender, EventArgs e) {
            updateItemStatistics();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    go to our website
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void pragerOnTheWebToolStripMenuItem_Click(object sender, EventArgs e) {

            System.Diagnostics.Process.Start("http://www.pragersoftware.com/");
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user clicked save user ids button
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bSaveUIDs_Click(object sender, EventArgs e) {
            populateUIDs ui = new populateUIDs();  //  instantiate...
            ui.saveDGVContents(UIDdataGridView, this);  //  save user ID's and passwords
            ui.populateDataGridView(UIDdataGridView);  //  refresh (0.0.12)
            lMsgSettingsSaved.Visible = true;
        }


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    user wants to ship int'l
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void cbWillShipIntl_CheckStateChanged(object sender, EventArgs e) {
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }
        //}


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    user wants expedited shipping
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void cbExpeditedShipping_CheckStateChanged(object sender, EventArgs e) {
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user has changed the status of the record
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bChangeStatus_Click(object sender, EventArgs e) {
            if (rbMarkSold.Checked == true)
                bulkMarkBoookStatus(1);  //  code 1 = Sold
            else if (rbMarkHold.Checked == true)
                bulkMarkBoookStatus(2);  //  code 2 = Hold
            else if (rbMark4Sale.Checked == true)
                bulkMarkBoookStatus(3);  //  code 3 = For Sale
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user wants to clear cust info
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bClearCustInfo_Click(object sender, EventArgs e) {
            clearCustDetailPanel();
            bAddCustomer.Enabled = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    occurs when any of the invoice fields have been modified
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void invFieldsChanged(object sender, EventArgs e) {
            if (tbTaxPct.Text.Length > 0)
                tbTaxVAT.Enabled = false;
            else
                tbTaxVAT.Enabled = true;

            computeNewInvTotal();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    handle keypress events
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void numericKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '\r') {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
                e.Handled = true;
        }



        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    transfer data to invoice
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bXfer_Click(object sender, EventArgs e) {
            xferDataToInvoice();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    start the pricing service
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        internal void bStartPricingService_Click(object sender, EventArgs e) {

            if (workOfflineToolStripMenuItem.Checked == true) {
                MessageBox.Show("You must have an internet connection to do repricing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  //  we're working offline for now...
            }

            prepareForPricingService();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    prepare for pricing
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void prepareForPricingService() {
            if ((rbPriceHighFixed.Checked == false && rbPriceHighPct.Checked == false)
                || (rbPriceLowFixed.Checked == false && rbPriceLowPct.Checked == false)
                || (cbAmazonPrice.Checked == false && rbVenuePrice.Checked == false)) {
                MessageBox.Show("You must indicate how to compute a suggested price by selecting from each of the pairs of buttons" +
                    " in the groups marked REQUIRED.", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  check all fields for validity
            if (rbPriceHighFixed.Checked == true || rbPriceHighPct.Checked == true) {
                if (tbHighByAmt.Text.Length == 0 || (rbHighAbove.Checked == false && rbHighBelow.Checked == false) ||
                    lbWhatPriceH.SelectedIndex == -1) {
                    MessageBox.Show("Error: some fields missing in 'If my price is HIGH' filter", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (rbPriceLowFixed.Checked == true || rbPriceLowPct.Checked == true) {
                if (tbLowByAmt.Text.Length == 0 || (rbLowAbove.Checked == false && rbLowBelow.Checked == false) ||
                    lbWhatPriceL.SelectedIndex == -1) {
                    MessageBox.Show("Error: some fields missing in 'If my price is LOW' filter", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (rbPriceNewFixed.Checked == true || rbPriceNewPct.Checked == true) {
                if (tbNewByAmt.Text.Length == 0 || lbNewWhatPrice.SelectedIndex == -1) {
                    MessageBox.Show("Error: some fields missing in 'If item is NEW' filter", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (cbExcludeAbove.Checked == true && tbExcludeAboveAmt.Text.Length == 0) {
                MessageBox.Show("Error: you checked 'Exclude Above', but gave no amount", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbExcludeBelow.Checked == true && tbExcludeBelowAmt.Text.Length == 0) {
                MessageBox.Show("Error: you checked 'Exclude Below', but gave no amount", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbDontGoBelowCost.Checked == true && tbBelowMyCostOr.Text.Length == 0) {
                MessageBox.Show("Error: you checked 'Dont Price Below Cost or', but gave no amount", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bStartPricingService.Enabled = false;
            bMarkAll.Enabled = false;
            bPricingServiceUpdate.Enabled = false;
            lPricingServiceStatus.Visible = true;
            lProgress.Text = "Processing: 0 of 0";  //  reset

            tabControl1.SelectedIndex = 1;  //  go to results page
            tabControl1.Refresh();

            lvPricingService.Items.Clear();  // Clear the ListView control
            stopPricingService = false;
            bStopPricingService.Enabled = true;

            RePricingRoutines rpr = new RePricingRoutines();

            ArrayList parms = new ArrayList();
            parms.Insert(0, mediaConn);
            parms.Insert(1, dr);
            parms.Insert(2, lPricingServiceStatus);
            parms.Insert(3, rbStartWithNbr);
            parms.Insert(4, rbRepriceThus);
            parms.Insert(5, dtpReprice);
            parms.Insert(6, tbStartNbr);
            parms.Insert(7, lvPricingService);
            parms.Insert(8, tbAWSKey.Text);   //  new 11.5.0
            parms.Insert(9, lTimeRemaining);
            parms.Insert(10, tbDiscardAboveAmt.Text);
            parms.Insert(11, tbDiscardBelowAmt.Text);
            parms.Insert(12, bMarkAll);
            parms.Insert(13, bPricingServiceUpdate);
            parms.Insert(14, bStartPricingService);
            parms.Insert(15, bStopPricingService);
            parms.Insert(16, cbAboveLow);
            parms.Insert(17, cbAmazonPrice);
            parms.Insert(18, cbCombineNewUsed);
            //parms.Insert(19, cbSkipFEandS);
            parms.Insert(20, cbExcludeAbove);
            parms.Insert(21, cbExcludeBelow);
            parms.Insert(22, tbExcludeAboveAmt);
            parms.Insert(23, tbExcludeBelowAmt);
            parms.Insert(24, rbPriceNewFixed);
            parms.Insert(25, rbPriceNewPct);
            parms.Insert(26, lbNewWhatPrice);
            parms.Insert(27, tbNewByAmt);
            parms.Insert(28, missingAmazonKeys);
            parms.Insert(29, cbDontGoBelowCost);
            parms.Insert(30, rbPriceHighFixed);
            parms.Insert(31, rbHighBelow);
            parms.Insert(32, lbWhatPriceH);
            parms.Insert(33, tbHighByAmt);
            parms.Insert(34, rbPriceHighPct);
            parms.Insert(35, rbLowBelow);
            parms.Insert(36, tbLowByAmt);
            parms.Insert(37, rbPriceLowFixed);
            parms.Insert(38, lbWhatPriceL);
            parms.Insert(39, rbPriceLowPct);
            parms.Insert(42, tbCondAmtVG);
            parms.Insert(43, tbCondAmtG);
            parms.Insert(44, tbCondAmtP);
            parms.Insert(46, tbBelowMyCostOr);
            parms.Insert(47, tbAZAssocTag.Text);   //  new 11.5.0
            parms.Insert(48, cbAboveAverage);
            parms.Insert(49, cbAboveHigh);
            parms.Insert(50, cbBelowAverage);
            parms.Insert(51, cbGreaterSugg);
            parms.Insert(52, cbEqualSugg);
            parms.Insert(53, cbLessSugg);
            parms.Insert(54, lProgress);
            parms.Insert(55, tbAWSKey);
            parms.Insert(56, tbBelowMyCostOr);
            parms.Insert(57, tbAWSSecretKey);
            parms.Insert(58, tabTaskPanel);
            parms.Insert(59, cWebPages);

            Thread t = new Thread(delegate() { rpr.doPricingService(parms); });
            t.TrySetApartmentState(ApartmentState.STA);
            t.Start();
            while (t.IsAlive) {
                if (stopPricingService == true)
                    t.Abort();
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);

            }
        }


        public bool stopPricingService = false;
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    stop the pricing service
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bStopPricingService_Click(object sender, EventArgs e) {
            stopPricingService = true;
            bStartPricingService.Enabled = true;
            lPricingServiceStatus.Text = "Pricing Service stopped!";
            bPricingServiceUpdate.Enabled = true;
            bMarkAll.Enabled = true;
            bStopPricingService.Enabled = false;
            Application.DoEvents();

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update prices from pricing service clicked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bPricingServiceUpdate_Click(object sender, EventArgs e) {
            lPricingServiceStatus.Visible = false;
            updateFromPricingService();
            bPricingServiceUpdate.Enabled = false;  //  disable it...
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    switch to customer info tab
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lbSoldTo_Click(object sender, EventArgs e) {
            tabTaskPanel.SelectTab(cCustomerInfo);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    customer has selected a customer from list
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lvCustomerList_SelectedIndexChanged(object sender, EventArgs e) {
            string custNbr = "";
            bXfer.Enabled = true;  //  allow xfer of data

            //  find which row was selected
            ListView.SelectedListViewItemCollection custdata = lvCustomerList.SelectedItems;
            foreach (ListViewItem item in custdata)
                custNbr = item.SubItems[1].Text;

            bAddCustomer.Enabled = false;  //  don't allow add's when customer was selected
            PopulateCustDetailPanel(custNbr);  //  now populate the detail panel
            bClearShoppingCart.BackColor = Color.Firebrick;
            //    shoppingCart.Clear();  //  clear out the items that belong to previous customer
            bShoppingCart.Enabled = true;  //  now, enable shopping cart for adding items
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    same as billing checked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void cbSameAsBillingInfo_CheckedChanged(object sender, EventArgs e) {
            propagateBillingInfo();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    select row from invoice list
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lvInvoiceList_SelectedIndexChanged(object sender, EventArgs e) {
            string invoiceNbr = "";

            //  find which row was selected
            ListView.SelectedListViewItemCollection invdata = lvInvoiceList.SelectedItems;
            foreach (ListViewItem item in invdata) {
                invoiceNbr = item.SubItems[0].Text;
                PopulateInvoiceDetailPanel(invoiceNbr);  //  now populate the detail panel
            }

            bAddInvoice.Enabled = false;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    clear invoice fields
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bClearInvFields_Click(object sender, EventArgs e) {
            clearInvDetailPanel();  //  clear out old stuff
            shoppingCart.Clear();
        }


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    prints the contents of the listview
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void bPrintPricingService_Click(object sender, EventArgs e) {
        //    //                                                   <------------------ TODO
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    mark all records for updating
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bMarkAll_Click(object sender, EventArgs e) {

            foreach (ListViewItem lvi in lvPricingService.Items) {
                if (lvi.SubItems.Count > 8 && !lvi.SubItems[8].Text.Trim().Contains("---"))  //  if there is a 'suggested price' and it's not '---'
                    if (decimal.Parse(lvi.SubItems[8].Text) != decimal.Parse(lvi.SubItems[3].Text.Replace('$', ' ')))   //  make sure it's not same as current price
                        lvi.Checked = true;
            }

            bPricingServiceUpdate.Enabled = true;  //  enable update button
        }


        ////-----------------------------------------------------------------------------------------------
        //private void rbStatusForSale_Click(object sender, EventArgs e) {
        //    // if (bAddRecord.BackColor != System.Drawing.Color.OrangeRed)  //  if we are adding a record, don't highlight 'update' button
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }

        //}

        ////-----------------------------------------------------------------------------------------------
        //private void rbStatusHold_Click(object sender, EventArgs e) {
        //    //  if we are adding a record, don't highlight 'update' button
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }

        //}

        ////-----------------------------------------------------------------------------------------------
        //private void rbStatusSold_Click(object sender, EventArgs e) {
        //    //  if we are adding a record, don't highlight 'update' button
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }

        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    mouse down
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbUPC_MouseDown(object sender, MouseEventArgs e) {
            if (tbUPC.Text.Length == 0)
                tbUPC.SelectionStart = 0;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    text changed
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbUPC_Leave(object sender, EventArgs e) {

            if (tbUPC.Text.Length == 12 || tbUPC.Text.Length == 13 || mtbASIN.Text.Length == 10) {
                Repository.maskedTxtBoxValue = tbUPC.Text;  //  save it just in case we crash!

                if (freeTrialExpired == false) {
                    bLookupPrices.Enabled = true;
                    bUpdateInfo.Enabled = true;
                    bGetMediaInfo.Enabled = true;  //  allow button to be clicked
                    bGetMediaInfo.Focus();  //  and give it focus for enter key
                }
                else {
                    bLookupPrices.Enabled = false;
                    bGetMediaInfo.Enabled = false;
                    bUpdateInfo.Enabled = false;
                }
            }
            else {  //  text length in box is less than any valid UPC or ASIN
                bLookupPrices.Enabled = false;
                bGetMediaInfo.Enabled = false;
                bUpdateInfo.Enabled = false;
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    mouse click
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void mtbASIN_MouseClick(object sender, MouseEventArgs e) {
            mtbASIN.SelectionStart = 0;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    mouse down
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void mtbASIN_MouseDown(object sender, MouseEventArgs e) {
            if (mtbASIN.Text.Length == 0)
                mtbASIN.SelectionStart = 0;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    text changed
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void mtbASIN_TextChanged(object sender, EventArgs e) {

            if (mtbASIN.Text.Length == 12 || mtbASIN.Text.Length == 13 || mtbASIN.Text.Length == 10) {
                Repository.maskedTxtBoxValue = mtbASIN.Text;  //  save it just in case we crash!

                if (freeTrialExpired == false) {
                    bLookupPrices.Enabled = true;
                    bUpdateInfo.Enabled = true;
                    bGetMediaInfo.Enabled = true;  //  allow button to be clicked
                    bGetMediaInfo.Focus();  //  and give it focus for enter key
                }
                else {
                    bLookupPrices.Enabled = false;
                    bGetMediaInfo.Enabled = false;
                    bUpdateInfo.Enabled = false;
                }
            }
            else {  //  text length in box is less than any valid UPC or ASIN
                bLookupPrices.Enabled = false;
                bGetMediaInfo.Enabled = false;
                bUpdateInfo.Enabled = false;
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    purge items by year
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bDeleteByYear_Click(object sender, EventArgs e) {
            purgeMediaByYear();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    routines (2) to purge by year
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void cbDeleteByYear_CheckedChanged(object sender, EventArgs e) {
            if (cbDeleteByYear.Checked == true && tbPurgeDate.Text.Length == 4)
                bDeleteByYear.Enabled = true;
            else
                bDeleteByYear.Enabled = false;
        }
        private void tbPurgeDate_TextChanged(object sender, EventArgs e) {
            if (tbPurgeDate.Text.Length == 4 && DateTime.Now.Year.ToString() == tbPurgeDate.Text) {
                MessageBox.Show("Error: you can not purge items in the current year", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbPurgeDate.Text.Length == 4 && cbDeleteByYear.Checked == true)
                bDeleteByYear.Enabled = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    do aging report
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bGenerateAgingReport_Click(object sender, EventArgs e) {
            doAgingReport();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    when user selects a particular report
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl2.SelectedIndex > 2) {
                MessageBox.Show("Sorry, this report is not yet available.", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl2.SelectTab(0);
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    copy shipping address to clipboard
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lbShipTo_Click(object sender, EventArgs e) {
            copyShipAddressToClipboard(lbShipTo);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    check to see if we need to mask the input  <--------------------------------- TODO ????
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbCustID_KeyPress(object sender, KeyPressEventArgs e) {
            if (cbAutoCustomerNbr.Checked == true) {
                if (char.IsDigit(e.KeyChar) == false && e.KeyChar != '\b')  //  if it's not a digit or a backspace
                {
                    MessageBox.Show("Because you have checked Auto Generate Customer Numbers, your starting number must be numeric",
                        "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Handled = true;  //  don't allow it...
                }
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    check to see if we need to mask the input
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbInvoiceNbr_KeyPress(object sender, KeyPressEventArgs e) {
            if (cbAutoInvoiceNbr.Checked == true) {
                if (char.IsDigit(e.KeyChar) == false && e.KeyChar != '\b')  //  if it's not a digit or a backspace
                {
                    MessageBox.Show("Because you have checked Auto Generate Invoice Numbers, your starting number must be numeric",
                        "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Handled = true;
                }
            }
        }



        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    user has changed the id or password
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
        //    dataGridValueChanged(e);
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    the following two methods increment/decrement the copies field
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bDecrement_Click(object sender, EventArgs e) {
            int x = int.Parse(tbQty.Text);
            if (--x >= 0)
                tbQty.Text = x.ToString();

            //bShoppingCart.Enabled = true;
            if (bUpdateRecord.Enabled == true)
                bUpdateRecord.BackColor = Color.OrangeRed;
        }
        private void bIncrement_Click(object sender, EventArgs e) {
            if (tbQty.Text.Length == 0)
                tbQty.Text = "1";
            int x = int.Parse(tbQty.Text) + 1;
            tbQty.Text = x.ToString();
            if (bUpdateRecord.Enabled == true)
                bUpdateRecord.BackColor = Color.OrangeRed;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    fill in media detail w/optional prices
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bGetMediaInfo_Click(object sender, EventArgs e) {

            if (mtbASIN.Text.Length > 0)
                AmazonLookupData(mtbASIN.Text, tbAWSKey.Text, tbAWSSecretKey.Text);  //  use ASIN to get media info
            else if (tbUPC.Text.Length > 0)
                AmazonLookupData(tbUPC.Text, tbAWSKey.Text, tbAWSSecretKey.Text);  //  no ASIN, so use UPC

            if (updateNeeded)
                bUpdateRecord.BackColor = Color.Red;
            else
                bAddRecord.BackColor = Color.Red;

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--   getPricesFromInternet clicked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bLookupPrices_Click(object sender, EventArgs e) {

            if (workOfflineToolStripMenuItem.Checked == true)
                return;  //  we're working offline for now...

            char itemCondn = ' ';
            itemCondn = cbCondition.Text.ToString().ToLower().Contains("new") ? 'n' : 'u';
            getMediaPrices(itemCondn, tbAWSKey.Text);  //  get prices for this item and display on tab(1)
            //tabTaskPanel.SelectTab(cPricingResults);  //  now go to the results tab
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    get next item in list
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bNextItem_Click(object sender, EventArgs e) {
            getNextItemInList();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    turn tool tips on or off
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void cbToolTips_CheckedChanged(object sender, EventArgs e) {
            if (cbToolTips.Checked == true)
                toolTip1.Active = false;
            else
                toolTip1.Active = true;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    check for illegal cross thread calls
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void mainForm_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    move cursor to position 1
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbUPC_MouseClick(object sender, MouseEventArgs e) {
            tbUPC.SelectionStart = 0;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    enable/disable resetDBPanel button
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void cbFreezeDBPanel_CheckStateChanged(object sender, EventArgs e) {
            if (cbFreezeDBPanel.Checked == true)  //  if we want to freeze d/b panel, don't allow reset
                resetDBPanel.Enabled = false;
            else
                resetDBPanel.Enabled = true;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    reset d/b panel
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void resetDBPanel_Click(object sender, EventArgs e) {
            fillDataBasePanel(createCommandString());  //  fill the tMedia datagridview 

            //tbPriCatalogSearch.Text = " ";
            searchOnCatalog = false;
        }



        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    get Amazon.com Access Keys
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bGetAmazonKeys_Click(object sender, EventArgs e) {

            if (localCulture.ToString() == "en-US")
                webBrowser1.Navigate(@"http://aws.amazon.com");
            else
                if (localCulture.ToString() == "en-GB")
                    webBrowser1.Navigate(@"http://aws.amazon.co.uk");
            tabTaskPanel.SelectTab(cWebPages);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    get MWS keys
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bGetMWSKeys_Click(object sender, EventArgs e) {

            if (localCulture.ToString() == "en-US")
                webBrowser1.Navigate(@"https://developer.amazonservices.com/");
            else if (localCulture.ToString() == "en-GB")
                webBrowser1.Navigate(@"https://developer.amazonservices.co.uk/index.html");

            tabTaskPanel.SelectTab(cWebPages);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    get Amazon Associate Tag
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bGetAssocTag_Click(object sender, EventArgs e) {

            if (localCulture.ToString() == "en-US")
                webBrowser1.Navigate(@"https://affiliate-program.amazon.com/");
            else if (localCulture.ToString() == "en-GB")
                webBrowser1.Navigate(@"https://affiliate-program.amazon.co.uk/");

            tabTaskPanel.SelectTab(cWebPages);

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    get Half.com Token
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bGetHalfToken_Click(object sender, EventArgs e) {
            webBrowser1.Navigate(@"https://developer.ebay.com/DevZone/account/tokens/default.aspx");
            tabTaskPanel.SelectTab(cWebPages);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update information without disturbing the existing info
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        bool doingAnUpdate = false;
        private void bUpdateInfo_Click(object sender, EventArgs e) {

            if (workOfflineToolStripMenuItem.Checked == true)
                return;  //  we're working offline for now...

            doingAnUpdate = true;
            notFoundFlag = false;

            AmazonLookupData(tbUPC.Text, tbAWSKey.Text, tbAWSSecretKey.Text);
            char itemCondn = ' ';

            if (cbAutoPricingLookup.Checked == true) {
                itemCondn = cbCondition.Text.ToString().ToLower().Contains("used") ? 'u' : 'n';
                getMediaPrices(itemCondn, tbAWSKey.Text);  //  get prices for this item and fill in tab(1)
                //             tabTaskPanel.SelectTab(cPricingResults);  //  now go to the results tab
            }

            if (notFoundFlag == true)
                lNotFound.Visible = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    when Hold Status changes, make sure Update button is set to red
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void cbStatusHold_CheckedChanged(object sender, EventArgs e) {
            if (doingAnUpdate)
                bUpdateRecord.BackColor = Color.OrangeRed;
            else
                bUpdateRecord.BackColor = SystemColors.Window;
        }


        //private void rbSortDirection_CheckedChanged(object sender, EventArgs e)  //  for DESC also
        //{
        //    createCommandString();
        //    fillDataBasePanel(commandString);
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    start tutorials in web browser
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tutorialsToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("http://www.pragersoftware.com/tutorials.html");

        }


        ////--------------------------    toggle to place book on hold    --------------------------------------------
        //private void bHold_Click(object sender, EventArgs e)
        //{
        //    if (cbStatusHold.Checked == true)
        //        cbStatusHold.Checked = false;
        //    else
        //        cbStatusHold.Checked = true;
        //}


        //private void bAddImage_Click(object sender, EventArgs e)
        //{
        //    addBookImage();
        //}

        //private void bUpdateImage_Click(object sender, EventArgs e) {
        //    addBookImage();
        //}

        //private void bDeleteImage_Click(object sender, EventArgs e) {
        //    deleteBookImage();
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update the current item with the new ASIN
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bUpdateASIN_Click(object sender, EventArgs e) {
            if (tbasinASIN.Text.Length != 10)  //  ASIN must be 10 characters long
            {
                MessageBox.Show("ASIN is invalid (length not 10 characters)", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbasinSKU.Text.Length == 0)  //  ASIN must be 10 characters long
            {
                MessageBox.Show("Invalid SKU (nothing selected from Database Panel)", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string updateString = "update tMedia set UPC = '" + tbasinASIN.Text + "' , DateU = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE SKU = '" + tbasinSKU.Text + "'";
            FbCommand fbc = new FbCommand(updateString);
            fbc.Connection = mediaConn;
            fbc.ExecuteNonQuery();

            if (dataBasePanel.SelectedIndices.Count == 0) {
                MessageBox.Show("Nothing has been selected for updating", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int lastSelection = dataBasePanel.SelectedIndices[0];  //  save last place (index) where we were

            commandString = "select SKU, Title, UPC, Quantity, Locn, Price, Stat, InvoiceNbr from tMedia where Stat = 'For Sale' and UPC = '' ";  //  create sql statement to refresh dataset
            fillDataBasePanel(commandString);

            if (lastSelection < dataBasePanel.Items.Count)
                dataBasePanel.Items[lastSelection].EnsureVisible();  //  make sure next row is visible

            if (listView1.Items.Count > 0)
                listView1.Items.Clear();  //  clear out the old items

            //  clear the old stuff
            tbasinSKU.Text = "";
            tbasinTitle.Text = "";
            tbasinAuthor.Text = "";
            tbasinPublisher.Text = "";
            tbasinASIN.Text = "";
            bUpdateASIN.BackColor = enabled;

            return;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    pick the correct ASIN and put it in the textbox
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            tbasinASIN.ForeColor = Color.Black;
            bUpdateASIN.BackColor = Color.OrangeRed;

            ListView.SelectedListViewItemCollection line = this.listView1.SelectedItems;
            foreach (ListViewItem item in line) {
                tbasinASIN.Text = item.SubItems[5].Text;
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    we have selected an item to be displayed
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void dataBasePanel_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                updateNeeded = true;  //  indicate we selected a row
                bAddRecord.Enabled = false;
            }
            else
                dataBasePanel.SelectedItems.Clear();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    setup for wildcard search
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bSearch_Click(object sender, EventArgs e) {
            if (tbsrchSKU.Text.Length > 0)
                genericSearch("SKU", tbsrchSKU.Text);
            else if (tbsrchUPC.Text.Length > 0)
                genericSearch("UPC", tbsrchUPC.Text);
            //else if (tbsrchAuthor.Text.Length > 0)
            //    genericSearch("Author", tbsrchAuthor.Text);
            else if (tbsrchTitle.Text.Length > 0)
                genericSearch("Title", tbsrchTitle.Text);
            else if (tbsrchKeywords.Text.Length > 0)
                genericSearch("Keywds", tbsrchKeywords.Text);
            else
                MessageBox.Show("You must indicate what you are searching for...", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    setup for a drill-down search
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void setupDrillDownSearch(object sender, EventArgs e) {
            if (cbWildCardSearch.Checked == true)  //  if we're doing a wildcard search, return
                return;

            if (tbsrchSKU.Text.Length > 0)
                drillDownSearch("SKU", tbsrchSKU.Text);
            else if (tbsrchUPC.Text.Length > 0)
                drillDownSearch("UPC", tbsrchUPC.Text);
            //else if (tbsrchAuthor.Text.Length > 0)
            //    drillDownSearch("Author", tbsrchAuthor.Text);
            else if (tbsrchTitle.Text.Length > 0)
                drillDownSearch("Title", tbsrchTitle.Text);
            //else if (tbsrchKeywords.Text.Length > 0)
            //    drillDownSearch("Keywds", tbsrchKeywords.Text);
            else
                fillDataBasePanel(createCommandString());
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    change the Search button enablement
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void cbWildCardSearch_CheckStateChanged(object sender, EventArgs e) {
            if (cbWildCardSearch.Checked == true)
                bSearch.Enabled = true;
            else
                bSearch.Enabled = false;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    clear the search textboxes
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bClearSearch_Click(object sender, EventArgs e) {
            tbsrchUPC.Clear();
            //tbsrchAuthor.Clear();
            tbsrchSKU.Clear();
            tbsrchTitle.Clear();
        }


        ////----------------    handles the up or down key for database panel    --------------------]
        //private void dataBasePanel_KeyDown(object sender, KeyEventArgs e)
        //{
        //    int index;

        //    if (dataBasePanel.SelectedIndices.Count == 0) // if there is no items selected, do nothing; or whatever you want
        //        return;

        //    index = dataBasePanel.SelectedIndices[0];
        //    if (e.KeyCode == Keys.Up)
        //    {
        //        if (index > 0) // you should check the index to reaching out of bounds
        //            dataBasePanel.Items[index - 1].Selected = true;
        //    }
        //    else if (e.KeyCode == Keys.Down)
        //        if (index < dataBasePanel.Items.Count - 1)
        //            dataBasePanel.Items[index + 1].Selected = true;

        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    sort records either ascending or descending
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void rbSortAsc_CheckedChanged(object sender, EventArgs e) { //  for Dsc also...
            createCommandString();
            fillDataBasePanel(commandString);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    send trace
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bSendTrace_Click(object sender, EventArgs ex) {

            StringBuilder traceData = new StringBuilder(256);
            for (int i = 0; i < trace.Count; i++)
                traceData.Append(trace[i] + "\n");

            string emailData = "006-" + DateTime.Now + "\n\rVersion: " + versionNumber + "\n\rOS: " + osName + " (SP: " + osServicePack + ")" + " MAC: " + MACAddress +
                "  Memory: " + amountOfMemory + " Mb " + "\n\rComments: " + tbTraceComments + "\n\rTrace: " + traceData;

            MailMessage message = new MailMessage();
            //message.From = new MailAddress("support@pragersoftware.com");
            //message.To.Add(new MailAddress("support@pragersoftware.com"));
            //message.Subject = "Inventory program trace";
            message.Body = emailData;

            SmtpClient client = new SmtpClient();
            client.Host = "mail.pragersoftware.com";
            client.Port = 25;
            client.Credentials = new NetworkCredential("support@pragersoftware.com", "Sp0Kane");

            object sendComplete = null;
            client.SendAsync("support@pragersoftware.com", "support@pragersoftware.com",
                "Media Program Trace", emailData, sendComplete);

            if (MessageBox.Show("Would you like to see the data you're sending?", "Prager Media Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Cursor.Current = Cursors.WaitCursor;
                for (int i = 0; i < trace.Count; i++)
                    lbStatus.Items.Add(trace[i]);
                lbStatus.Refresh();
            }

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    clone the item
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bClone_Click(object sender, EventArgs e) {

            tbSKU.Text = "";  //  clear the SKU and enable the Add button
            tbSKU.Enabled = true;

            bAddRecord.Enabled = true;
            bUpdateRecord.Enabled = false;
            bDeleteItem.Enabled = false;
            bRelist.Enabled = false;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    if leaving ASIN tab, refresh database panel
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tabTaskPanel_Deselecting(object sender, TabControlCancelEventArgs e) {
            if (e.TabPageIndex == cASIN)
                fillDataBasePanel(createCommandString());
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    background worker to check for program updates
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            m = Regex.Match(versionNumber, "BETA");
            if (m.Success)  //  if we are in BETA, don't check for version
                return;

            e.Result = DownloadVersionInfo();

        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {

            if (e.Result == null)
                return;

            string result = e.Result.ToString();
            string[] workingVerNbr = versionNumber.Split(' ');
            //replyFromHost = ">10.2.0:Critical<\n";  //  testing only!  <----------------
            //replyFromHost = ">4.5c<\n";  //  testing only!  <----------------

            string reply = "";
            if (result.Length > 1)
                reply = result.Substring(1, result.IndexOf('<') - 1).Trim();

            if (reply.Length >= 3)  //  make sure we got a good reply
            {
                if (reply != workingVerNbr[0]) {
                    if (result.Contains("Critical")) {
                        newVersionAvailableToolStripMenuItem.Text = "There is a CRITICAL update available for this program!";
                        newVersionAvailableToolStripMenuItem.Visible = true;
                    }
                    else {
                        newVersionAvailableToolStripMenuItem.Visible = true;

                    }
                }
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    start number validation
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbStartNbr_Leave(object sender, EventArgs e) {
            if (tbStartNbr.Text.Length > 0)
                rbStartWithNbr.Checked = true;  //  so we don't have to do it manually
        }



        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    contextmenustrip2 checked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            switch (e.ClickedItem.Name) {
                case "tsShowAll": {
                        tsShowForSale.Checked = false;
                        tsShowHold.Checked = false;
                        tsShowSold.Checked = false;
                        tsShowCatalog.Checked = false;
                        tsShowPending.Checked = false;

                        commandString = "select SKU, Title, UPC, Quantity,  Locn, Price, Stat, InvoiceNbr from tMedia ORDER BY SKU ASC ";
                        fillDataBasePanel(commandString);  //  fill the tMedia datagridview 
                        searchOnCatalog = false;
                        break;
                    }

                case "tsShowForSale": {
                        tsShowAll.Checked = false;
                        tsShowHold.Checked = false;
                        tsShowSold.Checked = false;
                        tsShowCatalog.Checked = false;
                        tsShowPending.Checked = false;

                        commandString = "select SKU, Title, UPC, Quantity,  Locn, Price, Stat, InvoiceNbr from tMedia where Stat = 'For Sale' ORDER BY SKU ASC ";
                        fillDataBasePanel(commandString);  //  fill the tMedia datagridview 
                        searchOnCatalog = false;
                        break;
                    }

                case "tsShowHold": {
                        tsShowForSale.Checked = false;
                        tsShowAll.Checked = false;
                        tsShowSold.Checked = false;
                        tsShowCatalog.Checked = false;
                        tsShowPending.Checked = false;

                        commandString = "select SKU, Title, UPC, Quantity, Locn, Price, Stat, InvoiceNbr from tMedia where Stat = 'Hold' ORDER BY SKU ASC ";
                        fillDataBasePanel(commandString);  //  fill the tMedia datagridview 
                        searchOnCatalog = false;
                        break;
                    }

                case "tsShowSold": {
                        tsShowForSale.Checked = false;
                        tsShowHold.Checked = false;
                        tsShowAll.Checked = false;
                        tsShowCatalog.Checked = false;
                        tsShowPending.Checked = false;

                        commandString = "select SKU, Title, UPC, Quantity,  Locn, Price, Stat, InvoiceNbr from tMedia where Stat = 'Sold' ORDER BY SKU ASC ";
                        fillDataBasePanel(commandString);  //  fill the tMedia datagridview 
                        searchOnCatalog = false;
                        break;
                    }

                case "tsShowPending": {
                        tsShowForSale.Checked = false;
                        tsShowHold.Checked = false;
                        tsShowAll.Checked = false;
                        tsShowSold.Checked = false;
                        tsShowPending.Checked = true;

                        commandString = "select SKU, Title, UPC, Quantity,  Locn, Price, Stat, InvoiceNbr from tMedia where Stat = 'Pending' ORDER BY SKU ASC ";
                        fillDataBasePanel(commandString);  //  fill the tMedia datagridview 
                        searchOnCatalog = false;
                        break;
                    }
                default:   //  default is Show All when nothing is checked...
                    tsShowAll.Checked = true;

                    commandString = "select SKU, Title, UPC, Quantity, Locn, Price, Stat, InvoiceNbr from tMedia ORDER BY SKU ASC ";
                    fillDataBasePanel(commandString);  //  fill the tMedia datagridview 
                    searchOnCatalog = false;
                    break;
            }

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    clears all fields in inclusive search
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bClearIncSearch_Click(object sender, EventArgs e) {
            cbSSColumn1.SelectedIndex = 0;
            cbSSColumn2.SelectedIndex = 0;
            cbSSColumn3.SelectedIndex = 0;
            cbSSColumn4.SelectedIndex = 0;

            tbSSCompareTo1.Text = "";
            tbSSCompareTo2.Text = "";
            tbSSCompareTo3.Text = "";
            tbSSCompareTo4.Text = "";

            lbSSAndOr2.SelectedIndex = -1;
            lbSSAndOr3.SelectedIndex = -1;
            lbSSAndOr4.SelectedIndex = -1;

            lbSSCompare1.SelectedIndex = -1;
            lbSSCompare2.SelectedIndex = -1;
            lbSSCompare3.SelectedIndex = -1;
            lbSSCompare4.SelectedIndex = -1;
            lItemsReturned.Text = "0 items found.";
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    first time, clear out the help text
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbSSCompareTo1_Enter(object sender, EventArgs e) {
            tbSSCompareTo1.Text = "";
            tbSSCompareTo1.ForeColor = System.Drawing.Color.Black;
            tbSSCompareTo1.BackColor = System.Drawing.Color.White;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    copies the contents of the listview to the clipboard
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bCopy2Clipboard_Click(object sender, EventArgs e) {
            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < dataBasePanel.Columns.Count; i++)  //  copy the column names to clipboard
            {
                buffer.Append(dataBasePanel.Columns[i].Text);
                buffer.Append("\t");
            }
            buffer.Append("\n");

            foreach (ListViewItem item in dataBasePanel.Items) {
                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems) {
                    buffer.Append(subitem.Text);
                    buffer.Append("\t");
                }
                buffer.Append("\n");
            }

            Clipboard.SetText(buffer.ToString());

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    coCondition combobox maintenance
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void coCondition_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                cbCondition.Items.Add(cbCondition.Text.ToString());
                cbCondition.ResetText();
            }
            else if (e.KeyCode == Keys.Delete && cbCondition.SelectedIndex > -1)
                cbCondition.Items.RemoveAt(cbCondition.SelectedIndex);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    updates the database with user's Amazon.com list of ASINs
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void aSINUpdateToolStripMenuItem_Click(object sender, EventArgs e) {

            asin asinUpdate = new asin();
            asinUpdate.doASINupdate(openFileDialog1, mediaConn);

            //  refresh the listview
            createCommandString();  //  get sql statement to refresh dataset
            fillDataBasePanel(commandString);

            //  indicate the status
            backupNeeded = true;
            MessageBox.Show("ASIN update completed...", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    if all of a sudden the user checks "allow add/update w/o required fields, enable buttons
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void cbAllowAddUpdate_Click(object sender, EventArgs e) {
            bAddRecord.Enabled = true;
            bUpdateRecord.Enabled = true;
        }


        //private void tabOptions_Enter(object sender, EventArgs e) {
        //    //  display current tab settings
        //    tbUPCSeq.Text = tbUPC.TabIndex.ToString();
        //    tbQtySeq.Text = tbQty.TabIndex.ToString();
        //    tbLocSeq.Text = tbLocn.TabIndex.ToString();
        //    tbSKUSeq.Text = tbSKU.TabIndex.ToString();
        //    //tbInvSeq.Text = tbBookDtlInvNbr.TabIndex.ToString();
        //    //tbShipSeq.Text = ddcbShipping.TabIndex.ToString();
        //    tbCostSeq.Text = tbCost.TabIndex.ToString();
        //    tbPriceSeq.Text = tbPrice.TabIndex.ToString();
        //    tbRepriceSeq.Text = cbDoNotReprice.TabIndex.ToString();
        //    tbTitleSeq.Text = tbTitle.TabIndex.ToString();
        //    //tbAuthorSeq.Text = tbAuthor.TabIndex.ToString();
        //    tbIllusSeq.Text = tbImageURL.TabIndex.ToString();
        //    //tbAuthorSignSeq.Text = cbAuthorSigned.TabIndex.ToString();
        //    //tbIllusSignedSeq.Text = cbIllusSigned.TabIndex.ToString();
        //    tbPubSeq.Text = tbMusicLabel.TabIndex.ToString();
        //    //tbPlaceSeq.Text = tbPlace.TabIndex.ToString();
        //    tbYearSeq.Text = tbMusicYear.TabIndex.ToString();
        //    tbDescSeq.Text = tbItemNote.TabIndex.ToString();
        //    tbCannedSeq.Text = lbCannedText.TabIndex.ToString();
        //    tbBindingSeq.Text = coProductType.TabIndex.ToString();
        //    tbCondSeq.Text = coCondition.TabIndex.ToString();
        //    tbJacketSeq.Text = coMediaType.TabIndex.ToString();
        //    tbEdSeq.Text = tbNbrOfDisks.TabIndex.ToString();
        //    //tbPagesSeq.Text = tbPages.TabIndex.ToString();
        //    //tbWeightSeq.Text = tbWeight.TabIndex.ToString();
        //    tbTypeSeq.Text = coLanguage.TabIndex.ToString();
        //    //tbSizeSeq.Text = coSize.TabIndex.ToString();
        //    tbPriSeq.Text = tbCatalogID.TabIndex.ToString();
        //    //tbSecSeq.Text = tbSecCatalog.TabIndex.ToString();
        //    tbKeySeq.Text = tbKeywords.TabIndex.ToString();
        //}

        //private void tabOptions_Leave(object sender, EventArgs e) {
        //    //  set new tab settings
        //    tbUPC.TabIndex = Convert.ToInt32(tbUPCSeq.Text);
        //    tbQty.TabIndex = Convert.ToInt32(tbQtySeq.Text);
        //    tbLocn.TabIndex = Convert.ToInt32(tbLocSeq.Text);
        //    tbSKU.TabIndex = Convert.ToInt32(tbSKUSeq.Text);
        //    //tbBookDtlInvNbr.TabIndex = Convert.ToInt32(tbInvSeq.Text);
        //    //ddcbShipping.TabIndex = Convert.ToInt32(tbShipSeq.Text);
        //    tbCost.TabIndex = Convert.ToInt32(tbCostSeq.Text);
        //    tbPrice.TabIndex = Convert.ToInt32(tbPriceSeq.Text);
        //    cbDoNotReprice.TabIndex = Convert.ToInt32(tbRepriceSeq.Text);
        //    tbTitle.TabIndex = Convert.ToInt32(tbTitleSeq.Text);
        //    //tbAuthor.TabIndex = Convert.ToInt32(tbAuthorSeq.Text);
        //    tbImageURL.TabIndex = Convert.ToInt32(tbIllusSeq.Text);
        //    //cbAuthorSigned.TabIndex = Convert.ToInt32(tbAuthorSignSeq.Text);
        //    //cbIllusSigned.TabIndex = Convert.ToInt32(tbIllusSignedSeq.Text);
        //    tbMusicLabel.TabIndex = Convert.ToInt32(tbPubSeq.Text);
        //    //tbPlace.TabIndex = Convert.ToInt32(tbPlaceSeq.Text);
        //    tbMusicYear.TabIndex = Convert.ToInt32(tbYearSeq.Text);
        //    tbItemNote.TabIndex = Convert.ToInt32(tbDescSeq.Text);
        //    lbCannedText.TabIndex = Convert.ToInt32(tbCannedSeq.Text);
        //    coProductType.TabIndex = Convert.ToInt32(tbBindingSeq.Text);
        //    coCondition.TabIndex = Convert.ToInt32(tbCondSeq.Text);
        //    coMediaType.TabIndex = Convert.ToInt32(tbJacketSeq.Text);
        //    //coNbrOfDisks.TabIndex = Convert.ToInt32(tbEdSeq.Text);
        //    //tbPages.TabIndex = Convert.ToInt32(tbPagesSeq.Text);
        //    //tbWeight.TabIndex = Convert.ToInt32(tbWeightSeq.Text);
        //    coLanguage.TabIndex = Convert.ToInt32(tbTypeSeq.Text);
        //    //coSize.TabIndex = Convert.ToInt32(tbSizeSeq.Text);
        //    tbCatalogID.TabIndex = Convert.ToInt32(tbPriSeq.Text);
        //    //tbSecCatalog.TabIndex = Convert.ToInt32(tbSecSeq.Text);
        //    tbKeywords.TabIndex = Convert.ToInt32(tbKeySeq.Text);

        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    do sales report (2 routines)
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        string tagValue = "";
        private void bCreateSalesReport_Click(object sender, EventArgs e) {
            doSalesReport(tagValue);
        }
        private void reportingPeriod_CheckedChanged(object sender, EventArgs e) {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked) {
                //Console.WriteLine(rb.Name + " was checked!");
                // grab the tag value...if you assigned this in the IDE it's a STRING
                tagValue = (string)rb.Tag;
                //Console.WriteLine("Tag = " + tagValue);
            }

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    three routines to allow movement of the tab panel sequence
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private TabPage SourceTab = null;
        private void tabTaskPanel_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                int DragIndex = TabFromPoint();
                if (DragIndex != -1) {
                    SourceTab = tabTaskPanel.TabPages[DragIndex];
                }
                else {
                    SourceTab = null;
                }
            }
        }

        private void tabTaskPanel_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                int OverIndex = TabFromPoint();
                if (OverIndex != -1) {
                    TabPage overTab = tabTaskPanel.TabPages[OverIndex];
                    if (overTab != SourceTab) {
                        if (OverIndex < tabTaskPanel.TabPages.IndexOf(SourceTab)) {
                            tabTaskPanel.TabPages.Remove(SourceTab);
                            tabTaskPanel.TabPages.Insert(tabTaskPanel.TabPages.IndexOf(overTab), SourceTab);
                            tabTaskPanel.SelectedTab = SourceTab;
                        }
                        else {
                            tabTaskPanel.TabPages.Remove(SourceTab);
                            if (OverIndex < tabTaskPanel.TabCount - 1) {
                                tabTaskPanel.TabPages.Insert(OverIndex + 1, SourceTab);
                            }
                            else {
                                tabTaskPanel.TabPages.Add(SourceTab);
                            }
                            tabTaskPanel.SelectedTab = SourceTab;
                        }

                        //  now, reset the numbers of the positions...
                        cPricingResults = tabTaskPanel.TabPages.IndexOf(pricingResultsTab);
                        cExport = tabTaskPanel.TabPages.IndexOf(ExportTab);
                        cUpload = tabTaskPanel.TabPages.IndexOf(uploadTab);
                        cAccounting = tabTaskPanel.TabPages.IndexOf(accountingTab);
                        cRepricing = tabTaskPanel.TabPages.IndexOf(RePricingTool);
                        cASIN = tabTaskPanel.TabPages.IndexOf(getASIN);
                        cProgramOptions = tabTaskPanel.TabPages.IndexOf(optionsTab);
                        cCustomerInfo = tabTaskPanel.TabPages.IndexOf(customerInfoTab);
                        cInvoice = tabTaskPanel.TabPages.IndexOf(invoiceTab);
                        cMediaDetail = tabTaskPanel.TabPages.IndexOf(mediaDetailTab);
                        cSearch = tabTaskPanel.TabPages.IndexOf(searchTab);
                        cTabMapping = tabTaskPanel.TabPages.IndexOf(mappingTab);
                        cImport = tabTaskPanel.TabPages.IndexOf(Import);
                        //cWebPages = tabTaskPanel.TabPages.IndexOf(webSites);
                        cMassChanges = tabTaskPanel.TabPages.IndexOf(alterPricesTab);
                        //cCatalogs = tabTaskPanel.TabPages.IndexOf(catalogTab);
                        cCannedText = tabTaskPanel.TabPages.IndexOf(cannedTextTab);
                        cUIDPswd = tabTaskPanel.TabPages.IndexOf(UIDandPswdMaintenance);
                        cReports = tabTaskPanel.TabPages.IndexOf(Reports);
                        cStatus = tabTaskPanel.TabPages.IndexOf(StatusTab);
                    }
                }
            }
        }

        private int TabFromPoint() {
            Point pt = tabTaskPanel.PointToClient(Cursor.Position);
            for (int i = 0; i < tabTaskPanel.TabCount; i++) {
                if (tabTaskPanel.GetTabRect(i).Contains(pt)) {
                    return i;
                }
            }
            return -1;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    print an invoice report with user selectable fields
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bPrintInvReport_Click(object sender, EventArgs e) {
            InvReport ivr = new InvReport();
            ivr.printInvReport(this, dataBasePanel, mediaConn, exportPath);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--   prints the Inventory report (a RichTextBox)
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        string[] lines;
        private void printDocument3_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            char[] param = { '\n' };

            lines = richTextBox1.Text.Split(param);

            int i = 0;
            char[] trimParam = { '\r' };
            foreach (string s in lines) {
                lines[i++] = s.TrimEnd(trimParam);
            }
        }

        int linesPrinted;
        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Brush brush = new SolidBrush(richTextBox1.ForeColor);

            while (linesPrinted < lines.Length) {
                e.Graphics.DrawString(lines[linesPrinted++],
                    richTextBox1.Font, brush, x, y);
                y += 15;
                if (y >= e.MarginBounds.Bottom) {
                    e.HasMorePages = true;
                    return;
                }
            }

            linesPrinted = 0;
            e.HasMorePages = false;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    setup the page for inventory report
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bPageSetup3_Click(object sender, EventArgs e) {
            // Initialize the dialog's PrinterSettings property to hold user defined printer settings.
            pageSetupDialog3.PageSettings = new System.Drawing.Printing.PageSettings();

            // Initialize dialog's PrinterSettings property to hold user set printer settings.
            pageSetupDialog3.PrinterSettings = new System.Drawing.Printing.PrinterSettings();

            //Do not show the network in the printer dialog.
            pageSetupDialog3.ShowNetwork = false;

            //Show the dialog storing the result.
            DialogResult result = pageSetupDialog3.ShowDialog();

        }


        ////--------------------------------    custom special updates done here    ----------------------------
        //private void bSUupdate_Click(object sender, EventArgs e) {
        //    DialogResult dlgResult = DialogResult.None;
        //    dlgResult = MessageBox.Show("Have you done a backup before you do this database update?", "Prager Media Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //    if (dlgResult == DialogResult.No)  //  no, don't process it...
        //        return;

        //    doSpecialUpdate();
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    check for valid email address before sending trace
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbTraceComments_TextChanged(object sender, EventArgs e) {
            if (tbTraceComments.Text.Contains("@") && tbTraceComments.Text.Contains("."))
                bSendTrace.Enabled = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    work offline
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void workOfflineToolStripMenuItem_Click(object sender, EventArgs e) {
            if (workOfflineToolStripMenuItem.Checked == true)
                workOfflineToolStripMenuItem.Checked = false;
            else
                workOfflineToolStripMenuItem.Checked = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    prints rejected records from import
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bPrintRejRecords_Click(object sender, EventArgs e) {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            pd.Print();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    select all for the inventory report
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void invRepSelAll_Click(object sender, EventArgs e) {
            invReportSelectAll();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user wants to convert USD
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void rbConvertUSD_CheckedChanged(object sender, EventArgs e) {

            if (rbGBPound.Checked == true || rbEUDollar.Checked == true || rbCNDollar.Checked == true) {
                MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();
                DialogResult dlgResult =
                dlg.Show(@"Software\Prager\MediaInventoryManager\ConvertDollars",  //  registry entry
                "DontShowAgain",  //  registry value name
                DialogResult.OK,  //  default return value returned immediately if box is not shown
                "Don't show this again",  //  message for checkbox
                "WARNING! You have checked the Amazon conversion option - this will convert all prices in US Dollars to the currency of choice without regard to your " +
                "location during the export to Amazon ONLY!  Are you sure you want to do this?", "Prager Media Inventory Manager",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dlgResult == DialogResult.No) {
                    rbCNDollar.Checked = false;
                    rbEUDollar.Checked = false;
                    rbGBPound.Checked = false;
                }
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    copy the Amazon developer's key to clipboard
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bCopyDevKey_Click(object sender, EventArgs e) {
            Clipboard.SetText(tbDevKey.Text);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    remove shipping info from description
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void removeShipMsgFromDescriptionToolStripMenuItem_Click(object sender, EventArgs e) {
            removeWillNotShip();
        }


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    fix quantity column
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void initializeQuantityFieldToolStripMenuItem_Click(object sender, EventArgs e) {
        //    moveNbrOfCopies();
        //}


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    make Keys info visible
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void pbAWSKey_MouseHover(object sender, EventArgs e) {
        //    lAWSKeys.Visible = true;
        //}
        //private void pbAWSKey_MouseLeave(object sender, EventArgs e) {
        //    lAWSKeys.Visible = false;
        //}
        //private void pbAssocTag_MouseHover(object sender, EventArgs e) {
        //    lAssocTag.Visible = true;
        //}
        //private void pbAssocTag_MouseLeave(object sender, EventArgs e) {
        //    lAssocTag.Visible = false;
        //}
        //private void pbMWSKeys_MouseHover(object sender, EventArgs e) {
        //    lMWSKeys.Visible = true;
        //}
        //private void pbMWSKeys_MouseLeave(object sender, EventArgs e) {
        //    lMWSKeys.Visible = false;
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    set audio or video tab based on product type selected
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void coProductType_SelectedIndexChanged(object sender, EventArgs e) {
            switch (coProductType.SelectedIndex) {
                case 0:
                case 1:
                    tabSpecificInfo.SelectTab(0);
                    break;
                case 2:
                case 3:
                    tabSpecificInfo.SelectTab(1);
                    break;
                default:
                    break;
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user changed the selection of Media Type
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void coMediaType_SelectedIndexChanged(object sender, EventArgs e) {
            if (coMediaType.SelectedIndex == 1) {
                tbVinylDetails.BackColor = Color.PaleGoldenrod;
                tbArtist.BackColor = Color.PaleGoldenrod;
                tbComposer.BackColor = Color.PaleGoldenrod;
                tbConductor.BackColor = Color.PaleGoldenrod;
                tbOrchestra.BackColor = Color.PaleGoldenrod;
                tbCatalogID.BackColor = Color.PaleGoldenrod;
            }
            else {
                tbVinylDetails.BackColor = Color.White;
                tbArtist.BackColor = Color.White;
                tbComposer.BackColor = Color.White;
                tbConductor.BackColor = Color.White;
                tbOrchestra.BackColor = Color.White;
                tbCatalogID.BackColor = Color.White;
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    get the country abbreviation
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void coOrigin_SelectedIndexChanged(object sender, EventArgs e) {

            if (coOrigin.SelectedIndex != -1 && coOrigin.SelectedValue.ToString() != "System.Data.DataRowView")
                Origin = coOrigin.SelectedValue.ToString();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    clear import tab mappings
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bClearImportTabMappings_Click(object sender, EventArgs e) {

            clearImportTabMappings();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    subscribe to File Exchange
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bSubscribeFileEx_Click(object sender, EventArgs e) {

            webBrowser1.Navigate(@"http://pages.ebay.com/sellerinformation/sellingresources/fileexchange.html");
            tabTaskPanel.SelectTab(cWebPages);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    hidden buttons to throw an exception for testing
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void button1_Click(object sender, EventArgs e) {
            throw new InvalidConstraintException();
            //throw new System.ArgumentException("test throw");
        }
        private void button2_Click(object sender, EventArgs e) {
            emailDebuggingData("test");
            //throw new InvalidCastException();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // --    Creates the error message and sends it
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void ShowThreadExceptionDialog(string title, Exception ex, string mtv) {

            StringBuilder traceData = new StringBuilder(512);

            for (int i = 0; i < trace.Count; i++)
                traceData.Append(trace[i] + "\n");

            StackTrace st = new StackTrace(new StackFrame(true));
            StackFrame sf = st.GetFrame(0);

            string emailData = DateTime.Now + "\n\rVersion: " + versionNumber + "\n\rOS: " + osName + " (SP: " + osServicePack + ")" + " MAC: " + MACAddress +
                "  Memory: " + amountOfMemory + " Mb   Culture Info: " + localCulture.ToString() +
                "\n\rError Message: " + ex.Message +
                "\n\r tbUPC: " + mtv + "\n\r commandString: " + commandString +
                "\n\rMethod: " + Convert.ToString(sf.GetMethod()) + "Line number: " + Convert.ToString(sf.GetFileLineNumber()) +
                "\n\r StackTrace: " + ex.StackTrace + "\n\rTrace: " + traceData;


            MailMessage message = new MailMessage();
            message.Body = emailData;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.pragersoftware.com";

            smtp.Port = 25;
            smtp.Credentials = new NetworkCredential("support@pragersoftware.com", "Sp0Kane");

            object sendComplete = null;

            //  wire up the handler for when the send has completed
            smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);

            //  send message
            smtp.SendAsync("support@pragersoftware.com", "support@pragersoftware.com",
                "Exception in Media Inventory Manager", emailData, sendComplete);

        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    handler for when the email send has completed
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private static void smtp_SendCompleted(object sender, AsyncCompletedEventArgs e) {
            systemCrash = true;
            Application.Exit();
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    email debugging data
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void emailDebuggingData(string data) {

            string emailData = "->007-" + DateTime.Now + "\n\rVersion: " + versionNumber + "\n\rOS: " + osName + " (SP: " + osServicePack + ")" + " MAC: " + MACAddress +
            "  Memory: " + amountOfMemory + " Mb   Culture Info: " + localCulture.ToString() + "\n\rData: " + data;

            MailMessage message = new MailMessage();
            message.Body = emailData;

            SmtpClient client = new SmtpClient();
            client.Host = "mail.pragersoftware.com";

            client.Port = 25;
            client.Credentials = new NetworkCredential("support@pragersoftware.com", "Sp0Kane");

            object sendComplete = null;
            client.SendAsync("support@pragersoftware.com", "support@pragersoftware.com",
                "Debugging Data", emailData, sendComplete);

        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    go to Amazon's site to verify the upload
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bVerifyAZUploads_Click(object sender, EventArgs e) {

            //webBrowser1.Navigate("https://mws.amazonservices.com/scratchpad/index.html");
            Process.Start("https://mws.amazonservices.com/scratchpad/index.html");

            ////  fill in what we can...
            //HtmlElement text = webBrowser1.Document.GetElementById("merchantID");
            //text.InnerText = tbMerchantID.Text;
            //text = webBrowser1.Document.GetElementById("awsAccountID");
            //text.InnerText = tbAWSKey.Text;
            //text = webBrowser1.Document.GetElementById("secretKey");
            //text.InnerText = tbAWSSecretKey.Text;
            //text = webBrowser1.Document.GetElementById("FeedSubmissionID");
            //if (Clipboard.ContainsText())
            //    text.InnerText = Clipboard.GetText();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    verify that the image textbox contains a URL
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbImageURL_Leave(object sender, EventArgs e) {
            if (tbImageURL.Text.ToLower().StartsWith("http://"))
                return;
            else {
                MessageBox.Show("Image URL does not start with 'http://'", "Prager Media Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

//  once we have the correct length, enable the getMediaInfo button
        private void tbUPC_TextChanged(object sender, EventArgs e) {
            if(tbUPC.Text.Length >=12)
            bGetMediaInfo.Enabled = true;
        }


    }
}