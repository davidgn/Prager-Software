#define COMPILED4OTHERS

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
using BookInfo;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Win32;


namespace Prager_Book_Inventory
{

    public partial class mainForm : Form
    {
        public static IFormatProvider localCulture = System.Globalization.CultureInfo.CurrentCulture;  //  get current culture
        public static DateTime compileDate = DateTime.Parse("Oct 27, 2013 7:25 AM", localCulture);
        public static string versionNumber = "13.307  " + compileDate.ToString("dd-MMM-yyyy");
        //public static string versionNumber = "13.294 BETA   " + compileDate.ToString("dd-MMM-yyyy");

        //  UploadListings.cs - line 779 CHECK FOR UNCOMMENTED RETURN WHICH WILL PREVENT UPLOADS  <-----------------

        /*---------------    Changes    -------------------------
        
        *---- 13.x
        -  changed: file type for ABE should be .txt  (13.307)
        -  changed: version numbering system to year.julian creation date (13.270)
        -  fixed: Amazon export with image URL put in wrong place (13.270)
        
        *----    12.0.x    ----
        -  fixed: error in license entry screen (12.10.0)
        -  changed: B&N, ABE now use same FTP routines  (12.10.0)
        -  added:  email to me re: 30-day license period  (DON"T PUBLISH!)
        -  changed: message when missing Amazon keys  (13.0.1)
        -  fixed:  support for getting Book Info using ASINs  (13.0.1)
        -  fixed: removed double-quotes from fields  (13.0.2)
        -  fixed: loop caused when exiting the program from menu  (13.0.2)
        -  changed:  removed sort of User IDs  (13.0.3)
        -  fixed: Valore uploads (13.0.3)
        -  added:  warning when deleting a book from database  (13.0.3)
        -  fixed:  Get Info was returning a starting double-quote  (13.0.3)
        -  fixed:  non-Amazon Get Book Info returns double-quotes in Title  (13.0.4)
        -  updated:  Amazon MWS API  (13.1.0)
        -  fixed:  UIEE import routines  (13.1.1)
        -  fixed: removed blanks from SKU during d/b update  (13.1.1)
        -  fixed: import of tab-delimited files  (13.1.2)
        -  changed: Chrisland's uploads now using FTPS  (13.1.3)
        -  added:  auto-restore of tab settings for BT import (13.1.4)
        -  added:  Amazon tax categories  (13.2.0)
        -  fixed: ABE Books changed one of their keys for uploading  (13.116)
        -  changed: wrong record count shown when "date of last export" is wrong  (13.121)
        -  changed: when purge/replace is checked on export, it's red in color on upload page  (13.125)
        -  changed: removed restriction of uploading outside your locale  (13.125)
        -  fixed: purge/replace for Amazon.com  (13.125)
        -  fixed: Get Info for book information optionally now uses Amazon.com (13.125)
        -  fixed: inventory report sort feature (13.159)
        -  fixed:  removed &amp; from Title in Get Book Info  (13.159)
        -  fixed:  pricing routines  (13.159)
        -  fixed:  Amazon shipping codes (13.159)
        -  fixed:  upload to Amazon.ca and Amazon.co.uk  (13.159)
        -  fixed: title length > 100 causes crash in Bulk Loader (13.221)
        -  changed: removed Half.com from one-click upload (13.221)
        -  added: Notes field for Amazon book description, etc.  (13.221)
        -  added: keywords now added to Chrislands export file  (13.221)
        -  added: using Amazon GetInfo, added weight and image URL  (13.221)
        -  changed:  added BookNotes to Description field for all exports but Amazon (13.249) 
         * 
         * 
         * 
       * 
        */


        /* --------------    TODO    ----------------------------
         
         HIGH PRIORITY
         * 
        -  combine FTP code
        *  ASIN - get condition of books 
        *  add multiple prices
        -  upgraded to .NET 4.5 for spelling checking  (12.8.2)  <-----------TODO
        *  when doing an add to invoice d/b, top listview is not populated!
        -  spelling checker for Description textbox  (12.8.2)  <------------- TODO
        *  DO NOT upload files with a zero length  <-------------  TODO IMPORTANT!
        *  replace .NET 2.0 with 3.5 in InnoSetup
        *  labels for book spine
        *  create sample tab-delimited import file
        *  import customer info from tab-delimited file
        *  IP-19 --  ( Custom Export) Exporting to Quickbooks
        *  
        *  Google uploads
        *  change inclusive search (don't allow "greater than" for alpha)
        *   IP-18 -- Inclusive Search Result Inaccurate (Inclusive Search where SKU is greater than 40= SKU 1 thru 9 and then grater than 40)
        * get image from Amazon if box is checked
        * automate ABE import v3.0 tab files
        *  special update for Mike (3/28 email)
        * numeric/string sort (see sample in directory)
        * add "sticky's" to invoices
        * clean createHB...cs file (move import stuff to another file)
        *  allow editing/entering of book condition and jacket
        *  give users a choice of which columns they want to view in database panel (allow reordering)
        *  expand 'catalog' limits
        *	
        * 
         MEDIUM PRIORITY
         *  letter that can be sent to places that I list, indicating the change of software and the new mapping of data? Bookhound, does
         *  Amazon.com import mapping (see email dated 4/22)  ??????????????

         LOW PRIORITY
         *  registration database (check licenses against the database)
         *  check ASIN against what's in the database (Amazon to program)
         *  add search for any string in the record... (change drilldown to have checkboxes for major search fields)
         *  allow status qualifiers to be stacked
         *  change database listview to datagridview
        
        */

        #region Variable Definitions
        public int i;
        public bool searchOnCatalog = false;
        public bool dataBaseMissing = false;
        public bool addButtonClicked = false;
        public bool choosingSecondary = false;
        public bool choosingPrimary = false;
        public bool statusForSale = false;
        public bool startOnProgramOptions = false;
        static string osServicePack = "";
        static string osName = "";
        public static string MACAddress = String.Empty;
        static string amountOfMemory = String.Empty;
        public static DateTime installedDate;
        //    public static DateTime renewalDate;  //  decrypted
        //public static string GUID = "";
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
        public static bool networkedClient = false;
        public bool changedExportDateTime = false;
        public bool backupNeeded = false;
        bool catalogTabClicked = false;  //  used to prevent leaving catalog tab
        static public string dataBaseName;
        static public string firebirdInstallationPath;
        public static string databasePath;
        public static string serverInstance;
        public static string serverInstallationPath;
        public static string[] headingNames;
        string pictureFileName = "";
        public static bool updateNeeded = false;
        public static bool doingAnAdd = false;
        static System.Threading.Mutex appMutex;
        public string programFilesDirectoryName;
        DateTime lastExport;
        FileInfo fi;
        public static string googleRegisteredFilename;
        public static DateTime decryptedDate;  //  expiration date  (decrypted)
        public static string encryptedDate;
        public static string chosenSortFields = "";
        public static bool UIDorPasswordChanged = false;
        //    public static void fTrace(string str);  //  allows calling from within the program
        public ArrayList InputData = new ArrayList();
        ArrayList DelimitedData = new ArrayList();
        static public ArrayList shoppingCart = new ArrayList();
        importTabDelimitedFiles tdf = new importTabDelimitedFiles();
        importBookTrakkerFiles ibt = new importBookTrakkerFiles();

        //enum tBooks : int  //  enumerations for tBooks table (also found in PapaMedia class)
        //{
        //    BookNbr, Title, Author, ISBN, Illus, Locn, Price, Cost, TranC, Pub, PubPlace, PubYear, Keywds, Descr, Jaket, Bndg,  //  0-15
        //    Condn, Ed, Signed, Type, Size, DateA, DateU, Cat, Notes, Stat, InvoiceNbr, ExpediteShip, IntlShip, SubCategory,  //  16-29
        //    DoNotReprice, NbrOfPages, BookWeight, ImageFileName, NbrOfCopies, Shipping, Quantity, Volume   //  30-37
        //};


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
        int cBookDetail = 9;
        int cSearch = 10;
        int cTabMapping = 11;
        int cImport = 12;
        int cWebPages = 13;
        int cMassChanges = 14;
        int cCatalogs = 15;
        int cCannedText = 16;
        int cUIDPswd = 17;
        int cReports = 18;
        int cStatus = 19;
        #endregion

        Color enabled = Color.FromKnownColor(KnownColor.Control);
        static public ArrayList trace = new ArrayList();


        //-------------------------    constructors    ---------------------------------
        public mainForm() {
            InitializeComponent();  //  auto-generated
            ProgramInitialization();
        }
        public mainForm(bool flag) { //  don't show splash screen or do anything else

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    Program Initialization
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void ProgramInitialization() {

            Cursor.Current = Cursors.WaitCursor;

            ////  message about major changes
            //MsgBoxCheck.MessageBox dlg0 = new MsgBoxCheck.MessageBox();
            //DialogResult dlgResult0 =
            //dlg0.Show(@"Software\Prager\BookInventoryManager\crashReporting",  //  registry entry
            //"DontShowAgain",  //  registry value name
            //DialogResult.OK,  //  default return value returned immediately if box is not shown
            //"Don't show this again",  //  message for checkbox
            //"We have added a special function called Crash Reporting.  When the program crashes, it will gather information " +
            //"regarding what caused the crash, and send it to us so we may fix it without delay.  If you opt to not have this feature, we will " +
            //"not know if the program crashes, and we will probably not be able to fix it (hopefully, this will not happen, " +
            //"but this way we can stay on top of all issues that we are aware of).  NOTE: We do NOT capture any personal information!",
            //"Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            //  check for internet connection  
            ss.Text = "checking internet connection";
            ss.Refresh();
            fTrace("I - checking internet connection");
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()) {
                fTrace("E - no internet connection");
                DialogResult dlgResult = DialogResult.None;
                dlgResult = MessageBox.Show("No internet connection; do you wish to work offline?", "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                MessageBox.Show("Error 190: unable to start Firebird Guardian - " + ex.Message + "\nPlease notify Prager, Software", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

#if COMPILED4OTHERS
            dataBaseName = "dbBooks";
            this.Text = "Prager Book Inventory Manager    Version  " + versionNumber;
#else
            dataBaseName = "dbPrager";
            this.Text = "Prager, Booksellers    Version " + versionNumber;
#endif

            Cursor.Current = Cursors.WaitCursor;

            //  check to see if database is there...
            //dbPath = "Rolf-PC:" + databasePath + dataBaseName + ".fdb";  //  TESTING!
            dbPath = databasePath + dataBaseName + ".fdb";
            //MessageBox.Show("dbpath: " + dbPath);

            if (dbPath.IndexOf(':') == dbPath.LastIndexOf(':')) {  //  if not equal, then we are networked
                fi = new FileInfo(dbPath);
                networkedClient = false;
            }
            else {
                networkedClient = true;
                int i = dbPath.IndexOf(':');
                string filePath = @"\\" + dbPath.Substring(0, i) + @"\";
                filePath += dbPath.Substring(i + 3, dbPath.Length - i - 3);
                fi = new FileInfo(filePath);
            }

            if (!fi.Exists) { //  if the database is missing, stop...
                fTrace("E - database is missing: " + dbPath);
                MessageBox.Show("The database is missing and the program can not continue. \nNotify support@pragersoftware.com for help", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }

            ss.splashProgressBar.Increment(5);

            //  now check for Firebird installation path and gsec.exe
            RegistryKey regKey = null;
            //String keyPath32 = null;
            String appName = null;
            //String appPath = null;

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
                MessageBox.Show("Unable to find Firebird file gsec.exe; please notify Support via our website", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            ss.splashProgressBar.Increment(5);

            try { //  now, let's try to connect to the database
                bookConn = new FbConnection("User=prager;Password=books;Database=" + dbPath + ";Pooling=true;");
                bookConn.Open();
            }
            catch (Exception ex) {
                if (ex.Message.Contains("Your user name and password are not defined")) {
                    fTrace("W - user name and password were not defined");

                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo.WorkingDirectory = firebirdInstallationPath;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.FileName = firebirdInstallationPath + @"bin\gsec.exe";
                    p.StartInfo.Arguments = "-user sysdba -pass masterkey -add prager -pw books";
                    p.Start();
                    p.WaitForExit();

                    MessageBox.Show("User ID and password created; you must restart the program...", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();

                    //string output = p.StandardOutput.ReadToEnd();
                    //MessageBox.Show("output from gsec.exe: " + output, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //  bookConn = new FbConnection("User=prager;Password=books;Database=" + dbPath);
                    //bookConn = new FbConnection("Database=" + dbPath);  (12.1.6)
                    bookConn.Open();
                }
                else {
                    if (ex.Message.Contains("Unable to complete network request to host"))  //  should never get here!
                        StartService("firebird guardian - defaultinstance", 5000);
                    else {
                        fTrace("E - error occurred while verifying the database; " + ex.Message);
                        MessageBox.Show("An error occurred while verifying the database (" + dbPath + "): " + ex.Message + "\nPlease notify support@pragersoftware.com of this error", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        throw new System.ArgumentException("error during database verification");
                    }
                }
            }

            ss.splashProgressBar.Increment(5);

            if (!networkedClient) {  //  if networking, don't check installation date or do d/b maintenance
                //  verify installation date
                fTrace("I - going to verify installation date");
                int retCode = checkInstallationDate();  //  if install date is missing, then database is new...
                fTrace("I - returned from checkInstallationDate; rc= " + retCode.ToString());
                if (retCode == -1) { //  error in database engine during initial open
                    MessageBox.Show("Unable to open database - contact support@pragersoftware.com", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    throw new System.ArgumentException("unable to open database");
                }

                ss.splashProgressBar.Increment(5);

                //  modify the database tables
                ss.Text = "Performing database maintenance";
                ss.Refresh();
                fTrace("I - going to modify the database tables");
                modifyExistingTables(ss);  //  do database maintenance if necessary

                ss.splashProgressBar.Increment(5);
            }

            //  have to restore UIDs and Passwords so options can be restored properly (this must appear before restoreOptions())
            ss.Text = "populating User IDs and Passwords...";
            ss.Refresh();
            fTrace("I - populating user id's and passwords");
            populateUIDs ui = new populateUIDs();  //  upload UploadInfo info and populate datagrid
            ui.populateDataGridView(UIDdataGridView);

            //if (UIDdataGridView.Rows.Count > 24)  //  means table is farkeled up  <------------------ TODO (remove?)
            //    ui.placeUIDsInArray(UIDdataGridView, ui);  //  remove the extra entries

            ss.splashProgressBar.Increment(5);

            //  restore program options
            ss.Text = "restoring program options...";
            ss.Refresh();
            fTrace("I - restoring program options");
#if COMPILED4OTHERS
            restoreOptions(@"\prager.Options.xml");  //  restore options each time...
#else
            restoreOptions(@"\pragerbooksellers.Options.xml"); 
#endif

            ////  now restore custom site names
            //if (UIDdataGridView.Rows.Count > 17) {
            //    UIDdataGridView.Rows[18].Cells[0].Value = tbCustomSite1.Text;  //  set site names from DGV
            //    UIDdataGridView.Rows[19].Cells[0].Value = tbCustomSite2.Text;
            //    UIDdataGridView.Rows[20].Cells[0].Value = tbCustomSite3.Text;
            //    UIDdataGridView.Rows[21].Cells[0].Value = tbCustomSite4.Text;
            //    UIDdataGridView.Columns[0].ReadOnly = true;  //  now make first column read-only
            //}

            fTrace("I - going to createCommandString");
            createCommandString();  //  create the general purpose command string

            ss.splashProgressBar.Increment(5);

            //  fill listview panel
            ss.Text = "filling database panel...";
            ss.Refresh();
            fTrace("I - going to fillListviewPanel with: " + commandString);
            fillDataBasePanel(commandString);  //  fill the tBooks datagridview

            //  updating counters
            ss.Text = "updating counters...";
            ss.Refresh();
            fTrace("I - updating counters...");
            updateCounters();  //  update "books waiting" counter

            //  setting default start page
            if (startOnProgramOptions)
                tabTaskPanel.SelectTab(cProgramOptions);
            else if (rbStartDetail.Checked == true)
                tabTaskPanel.SelectTab(cBookDetail);
            else
                tabTaskPanel.SelectTab(cSearch);

            if (rbOunces.Checked == true)
                lWeight.Text = "Weight (pounds)";
            else
                lWeight.Text = "Weight (kilograms)";

            fTrace("I - set binding categories");
            setBindingCategories();

            bGetInfoWISBN.Enabled = false;

#if COMPILED4OTHERS
            int rc = 0;

            ss.splashProgressBar.Increment(5);

            //  validate the License
            ss.Text = "Checking license...";
            ss.Refresh();
            fTrace("I - Checking license...");

            LicenseValidation lv = new LicenseValidation();
            rc = lv.validateLicense(bookConn, ref encryptedDate, networkedClient, ref decryptedDate, ref MACAddress);

            string reason = "";
            switch (rc) {
                case 0:
                    reason = "Valid";
                    freeTrialExpired = false;
                    break;
                case -1:
                    reason = "Installation date missing/invalid";
                    freeTrialExpired = true;
                    break;
                case -2:
                    reason = "Expiration date missing/invalid";
                    freeTrialExpired = true;
                    break;
                case -3:
                    reason = "30-days free license";
                    freeTrialExpired = false;
                    emailDebuggingData("-->  30-day license granted");  //  send email
                    break;
                //case -4:
                //    reason = "1-year free license";
                //    break;
                case -5:
                    reason = "License expired";
                    freeTrialExpired = true;
                    break;
                case -6:
                    reason = "Network license conflict";
                    freeTrialExpired = true;
                    break;
                default:
                    reason = "unknown return code: " + rc.ToString();
                    freeTrialExpired = true;
                    break;
            }
            fTrace("D - decryptedDate: " + mainForm.decryptedDate.ToString());
            fTrace("I - return code from checking license: " + reason);

            DisplayLicenseScreen licScreen = new DisplayLicenseScreen();
            if (rc < 0) { //  time has expired
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
                        bGetInfoWISBN.Enabled = false;
                        bLookupPrices.Enabled = false;  //  don't allow user to lookup prices
                        licScreen.Show();
                        licScreen.TopMost = true;
                        break;
                }
                //licScreen.Show();
                //licScreen.TopMost = true;
            }
            else  //  rc = 0, time not expired dispose of it...
                licScreen.Dispose();
            //}
#endif

            ss.splashProgressBar.Increment(5);

            //  now check settings...
            if (cbToolTips.Checked == true)
                toolTip1.Active = false;
            else
                toolTip1.Active = true;

            lPricingServiceStatus.Text = "";  //  initialize this too...

            if (coCondition.Items.Count == 0) {
                MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();
                DialogResult dlgResult =
                dlg.Show(@"Software\Prager\BookInventoryManager\BookCondition",  //  registry entry
                "DontShowAgain",  //  registry value name
                DialogResult.OK,  //  default return value returned immediately if box is not shown
                "Don't show this again",  //  message for checkbox
                "You have not initialized the book condition menu; do you want to do it now?", "Prager Book Inventory Manager",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dlgResult == DialogResult.Yes) {
                    tabTaskPanel.SelectTab(cProgramOptions);
                    tabPrimary.SelectTab(2);
                }
            }

            missingAmazonKeys = false;
            if (tbAWSKey.Text.Length == 0 || tbAWSSecretKey.Text.Length == 0 ||
                (rbAmazonUS.Checked && (tbMerchantID.Text.Length == 0 || tbMarketplaceID.Text.Length == 0))) {
                fTrace("W - Amazon keys are missing");
                MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();
                DialogResult dlgResult =
                dlg.Show(@"Software\Prager\BookInventoryManager\AmazonKeys",  //  registry entry
                "DontShowAgain",  //  registry value name
                DialogResult.OK,  //  default return value returned immediately if box is not shown
                "Don't show this again",  //  message for checkbox
                "You must have the Amazon AWS and MWS keys to get book and price information from Amazon.com; " +
                " Do you want to get them now? (they are free)",
                "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dlgResult == DialogResult.Yes) {
                    if (rbAmazonUS.Checked)
                        System.Diagnostics.Process.Start(@"http://www.amazon.com/gp/aws/registration/registration-form.html");
                    else if (rbAmazonCA.Checked)
                        System.Diagnostics.Process.Start(@"http://www.amazon.ca/gp/aws/registration/registration-form.html");
                    else if (rbAmazonUK.Checked)
                        System.Diagnostics.Process.Start(@"http://www.amazon.co.uk/gp/aws/registration/registration-form.html");
                    tabTaskPanel.SelectTab(cUIDPswd);
                    tcKeys.SelectTab("tabGetKeys");
                }
                else {
                    missingAmazonKeys = true;  //  don't allow Amazon functions
                    cbUseAmazon4BookInfo.Checked = false;
                    bGetInfoWISBN.Enabled = false;
                    bUpdateInfo.Enabled = false;
                    bLookupPrices.Enabled = false;
                }
            }


            ////  display message about Amazon's condition error
            //if (installedDate.Date != DateTime.Today.Date || AmazonUID.Length != 0)  //  only do it if they are not new users
            //{
            //    MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();
            //    DialogResult dResult =
            //    dlg.Show(@"Software\Prager\Inventory Program\ConditionError",  //  registry entry
            //    "DontShowAgain",  //  registry value name
            //    DialogResult.OK,  //  default return value returned immediately if box is not shown
            //    "Don't show this again",  //  message for checkbox
            //    "CRITICAL MESSAGE:  This ONLY APPLIES if you use the Amazon book conditions (selected from Program Options - Book Conditions)\n\n" +
            //    "With the installation of version 10.1.0, we inadvertently introduced an error " +
            //    "in the translation of one of the book conditions ('used: like new' was translated to 'new' rather than 'like new')" +
            //    ".  This has the effect of all used books with a condition of 'like new' being marked as 'new', which may" +
            //    " cause problems when your buyer gets the book and see's it's not new.\n\nOur solution is to do a search " +
            //    " on all books added after Jan 23, 2010 with a condition of 'new' and verify the actual condition, changing it if necessary. " +
            //    "When completed, do an export and then an upload to all venues.  We apologize for the inconvenience this has caused.",
            //    "Prager Book Inventory Manager",  //  window title
            //    MessageBoxButtons.OK, MessageBoxIcon.Warning);  //  button and icon code
            //}

            ss.splashProgressBar.Increment(5);

            ss.Text = "checking for updates...";
            ss.Refresh();
            fTrace("I - checking for updates");

            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.RunWorkerAsync();  //  check for program updates in a separate thread

            ss.splashProgressBar.Increment(5);

            //  disable using Amazon for book info  (12.9.1)  revised 12.10.1
            //cbUseAmazon4BookInfo.Checked = false;
            //cbUseAmazon4BookInfo.Enabled = false;

            fTrace("I - initialization completed");
            ss.Text = "Initialization completed...";
            ss.Refresh();


            Cursor.Current = Cursors.Default;

            ss.Close();
            ss.Dispose();

            //MsgBoxCheck.MessageBox dlg1 = new MsgBoxCheck.MessageBox();
            //DialogResult dlgResult1 =
            //dlg1.Show(@"Software\Prager\BookInventoryManager\osTicket",  //  registry entry
            //"DontShowAgain",  //  registry value name
            //DialogResult.OK,  //  default return value returned immediately if box is not shown
            //"Don't show this again",  //  message for checkbox
            //"We have recently introduced two new pages to our website that we want you to be aware of.  First, we " +
            //"have added a new issue tracking system that we would like you to use rather than sending us emails. " +
            //"We get a lot of emails, and don't want to lose any of the important ones.  It's intuitive and we think, easy to use. " +
            //"It can  be found on the website's Support page." +
            //"\n\nThe other page is a What's New page where you can find the latest information about what's happening, " +
            //"including programs, critical issues, etc.  It's kinda like a blog, but we haven't got time to work on a blog " +
            //"right now (too many things going on at Amazon!).  We will convert it to a blog on the website's Home page after " +
            //"we have time to breathe!\n\nThanks to all of you for your support; we continually strive to make our software " +
            //"the best in the business for a reasonable price!", "Prager Book Inventory Manager",
            //MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    tab selected
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tabSelected(object sender, TabControlEventArgs e) {
            //    freeTrialExpired = true;  //  testing only  <--------
            if (freeTrialExpired == true && !networkedClient)
                switch (tabTaskPanel.SelectedTab.Name) {
                    case "webSites":  //  websites
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
                            "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabTaskPanel.SelectTab(cBookDetail);  //  make book detail default tab
                        DisplayLicenseScreen licScreen = new DisplayLicenseScreen();  //  show license screen
                        licScreen.Show();
                        return;
                    default:
                        break;
                }

            switch (tabTaskPanel.SelectedTab.Name) {
                case "webSite":
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
                        tbMapBookNbr.Text = "seller-sku";
                        tbMapTitle.Text = "item-name";
                        tbMapDesc.Text = "item-description";
                        tbMapPrice.Text = "price";
                        tbMapISBN.Text = "product-id";
                        tbMapBookCond.Text = "item-condition";
                        tbNbrOfCopies.Text = "quantity";
                        tbMapAddDesc2.Text = "item-note";
                        lbMappingNames.Enabled = false;  //  don't allow changes if it's Amazon
                    }
                    else
                        restoreMapping();
                    break;
                case "Import":  //  import
                    break;
                case "searchTab":  //  search
                    tbsrchTitle.Focus();
                    break;
                case "bookDetailTab": //  book detail
                    mtbISBN.SelectionStart = 0;
                    if (cbAutomaticSKU.Checked == true)
                        tbBookNbr.Enabled = false;
                    else
                        tbBookNbr.Enabled = true;
                    updateNeeded = false;  //  just in case...
                    fillBookCondition();
                    break;
                case "ExportTab":  //  export
                    updateCounters();
                    break;
                case "uploadTab": //  upload
                    initializeUploadPage();
                    break;
                case "catalogTab":  //  catalog
                    populatePriCatalogListbox();
                    break;
                case "accountingTab":  //  accounting
                    lbAcctgYear.SetSelected(8, true);  //  sets default year
                    updateBookStatistics();  //  get initial database statistics
                    break;
                case "cannedTextTab":  //  canned text
                    break;
                case "UIDandPswdMaintenance": //  user id's and passwords
                    //lMsgSettingsSaved.Visible = false;
                    break;
                case "StatusTab":  //  status & log
                    bSendTrace.Enabled = false;
                    break;
                case "RePricingTool":  //  re-pricing tool
                    //MessageBox.Show("Temporarily disabled while it's being re-written (Amazon's new requirements)", "Prager, Software",
                    //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //tabTaskPanel.SelectTab(cBookDetail);//  make Detail tab
                    //if (tbAWSKey.Text.Length == 0 || tbAWSSecretKey.Text.Length == 0)
                    //    bGetAccessKey.Visible = true;
                    //else
                    //    bGetAccessKey.Visible = false;
                    break;
                case "Reports":  //  reports
                    break;
                case "getASIN":  //  ASIN
                    commandString = "select BookNbr, Title, ISBN, Quantity, Locn, Price, Stat, InvoiceNbr from tBooks where Stat = 'For Sale' and ISBN = '' ";  //  create sql statement to refresh dataset
                    fillDataBasePanel(commandString);
                    break;
                default:
                    MessageBox.Show("Sorry, this area is not available.",
                        "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (rbStartDetail.Checked == true)
                        tabTaskPanel.SelectTab(cBookDetail);//  make Detail tab the default
                    else
                        if (rbStartSearch.Checked == true)
                            tabTaskPanel.SelectTab(cSearch);
                    break;
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    find catalog
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bFindCatalog_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                sFileName1 = openFileDialog1.FileName;
                tbCatFn.Text = sFileName1;
                bImportCatalog.Enabled = true;
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    import catalog
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bImportCatalog_Click(object sender, EventArgs e) {
            importCatalog();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    adds entry in textbox to catalog
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bAddCatalog_Click(object sender, EventArgs e) {
            backupNeeded = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    deletes selected item in catalog
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bCatDeleteEntry_Click(object sender, EventArgs e) {
            tCatDeleteEntry();
            backupNeeded = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    delete a book
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bDeleteBook_Click(object sender, EventArgs e) {

            //  find which row was selected
            ListView.SelectedIndexCollection listData = dataBasePanel.SelectedIndices;

            int rc = 0;
            foreach (int lvIndex in listData) {
                rc = tBookDeleteEntry(dataBasePanel.Items[lvIndex].SubItems[0].Text);
                if (rc == -1)
                    break;
            }

            createCommandString();
            clearDetailPanel(false);  //  remove reminants of book(s) just deleted (not doing an update)
            fillDataBasePanel(commandString);

            backupNeeded = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    primary catalog index changed
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lbPrimaryCatalog_SelectedIndexChanged(object sender, EventArgs e) {
            populateSecCatalogListbox();  //  see if there are any entries for a secondary catalog
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    attach Secondary selection to record
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lbSecondaryCatalog_SelectedIndexChanged(object sender, EventArgs e) {
            chooseSecondaryCatalogEntry();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    add a catalog entry
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bAddCatalogEntry_Click(object sender, EventArgs e) {
            tCatAddEntry();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    clear entries in detail panel
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //  clear all of the entries in the detail pane
        private void bClear_Click(object sender, EventArgs e) {
            clearDetailPanel(false);  //  not doing an update
            mtbISBN.Clear();
            mtbISBN.SelectionStart = 0;
            mtbISBN.Focus();
        }



        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    the text of the filename has changed
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbFileName_TextChanged(object sender, EventArgs e) {
            bImportBooks.Enabled = true;
            bOpenFileDialog.Enabled = true;  //  reset controls
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    reprice books
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bReprice_Click(object sender, EventArgs e) {
            changePrices();
            backupNeeded = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--     selected "Changed since" for export
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            //  set to date/time of last export  
            lastExport = dateTimePicker1.Value;
            updateCounters();
            changedExportDateTime = true;

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    add a record
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bAddRecord_Click(object sender, EventArgs e) {
            addRecord();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update detail record
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bUpdateRecord_Click(object sender, EventArgs e) {

            if (cbAllowAddUpdate.Checked == false)  //  check for required fields?
            {
                if (checkForRequiredFields() == -1)  //  some fields are missing
                {
                    //bUpdateRecord.Enabled = false;  //  disable Update button
                    updateNeeded = true;  //  was doing an update, so allow it again
                    return;
                }
                else
                    bUpdateRecord.Enabled = true; //  make sure it's enabled
            }

            tBooksUpdateRecord();

            //if (cbFreezeDBPanel.Checked == false)  //  OK to refresh the database panel?
            //    updateDataBasePanel(createCommandString());  //  get sql statement to refresh dataset

            bUpdateRecord.BackColor = enabled;  //  reset the color back to default
            updateNeeded = false;  //  reset it...
            backupNeeded = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    change book number, mark for sale and add
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bRelist_Click(object sender, EventArgs e) {
            relistBook();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    build a file for export
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bExport_Click(object sender, EventArgs e) {
            exportBooks();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    date has been changed?
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void rbChangeDate_CheckedChanged(object sender, EventArgs e) {
            dateTimePicker1.Enabled = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    export all has been checked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void rbExportAll_CheckedChanged(object sender, EventArgs e) {
            if (rbExportAll.Checked)
                dateTimePicker1.Enabled = false;
            else
                dateTimePicker1.Enabled = true;

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    import books has been clicked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bImportBooks_Click(object sender, EventArgs e) {
            if (tbFileName.Text.Length == 0) {
                MessageBox.Show("You must choose a file to import.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            importBooksToDatabase();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    continue the import process
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bContinueImport_Click(object sender, EventArgs e) {
            tabTaskPanel.SelectTab(cImport);  //  go to Import tab
            tabTaskPanel.Refresh();

            if (createIndexes() == -1)  //  create index's from mapping
                return;

            //  do the actual import
            if (rbImportBT.Checked == false)  //  regular tab-delimited file?
                tdf.convertFile(this, sFileName1, lRecordsProcessed, lbMappingNames, lRecordsRejected, lbRejectedRecords, rbMarkAsSold, rbReplaceRecord, rbImportAZ);
            else  //  no, it's Booktrakker
                ibt.convertFile(this, sFileName1, lRecordsProcessed, lbMappingNames, lRecordsRejected, lbRejectedRecords, rbMarkAsSold, rbReplaceRecord, rbImportAZ);

            createCommandString();  //  show all the books
            fillDataBasePanel(commandString);  //  fill the listview

            bOpenFileDialog.Enabled = false;  //  reset controls
            bImportBooks.Enabled = false;

            backupNeeded = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    Help files are on the web
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://www.pragersoftware.com/bookWebHelp/index.html");
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    show the About screen
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            aboutScreen about = new aboutScreen();
            about.Show();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user wants to backup the database
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e) {
            if (Count(dbPath, ':') > 1) {
                MessageBox.Show("Backups can only be done from the machine where the database resides.", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                databaseBackupToolStripMenuItem.Enabled = false;
                return;
            }

            backupDatabase();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user requests restore of the d/b
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void databaseRestoreToolStripMenuItem_Click(object sender, EventArgs e) {

            restoreDatabase();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user wants to do an upload
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bFTPUpload_Click(object sender, EventArgs e) {

            if (workOfflineToolStripMenuItem.Checked == true) {  //  we're working offline for now...
                MessageBox.Show("You are working offline (go to Tools->Work Offline); you can not upload unless you have an internet connection",
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!cbUploadAmazon.Checked && !cbUploadAmazonUK.Checked && !rbAmazonUK.Checked) {
                MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();
                DialogResult dr =
                    dlg.Show(@"Software\Prager\BookInventoryManager\MWSkeys",  //  registry entry
                    "DontShowAgain",  //  registry value name
                    DialogResult.OK,  //  default return value returned immediately if box is not shown
                    "Don't show this again",  //  message for checkbox
                    "A reminder that you must register for Amazon's Marketplace Web Services (MWS) BEFORE you can upload any books.\n" +
                    "Go to our web-based Help, click on Uploading Files to the Listing Services -> Amazon Setup for further information",
                    "Prager Book Inventory Manager",  //  window title
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);  //  button and icon code
            }

            prepareForUpload();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    event when X is clicked on upper right of form or Database->Exit
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {

            updateCounters();  //  check to see if there are any books waiting to be exported

            if (lBooksWaiting.Text.Substring(0, 1) != "0" && backupRestoreFlag == false && systemCrash == false) {
                DialogResult dlgResult = DialogResult.None;
                dlgResult = MessageBox.Show("You have books waiting to be exported and uploaded.\rDo you want to exit anyway?",
                    "Prager Book Inventory Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)  //  no, don't exit
                {
                    e.Cancel = true;
                    return;
                }
            }

            //  save UIDs if necessary
            if (UIDorPasswordChanged == true) {
                populateUIDs ui = new populateUIDs();  //  instantiate...
                ui.saveDGVContents(UIDdataGridView, this);  //  save user ID's and passwords
            }

            if (dataBaseMissing == false) {
                tabTaskPanel.SelectTab(cStatus);  //  to to the status page

#if COMPILED4OTHERS
                saveOptions(@"\prager.Options.xml");  //  save options each time...
#else
                saveOptions(@"\pragerbooksellers.Options.xml"); 
#endif

                if (backupRestoreFlag == false) {  //  means we have not just done a restore
                    if (cbBackupDB.Checked || backupNeeded)
                        //databaseBackupToolStripMenuItem_Click(sender, e);
                        backupDatabase();
                }
            }

            //  close the FbConnections
            if (bookConn != null && bookConn.State == ConnectionState.Open)
                bookConn.Close();

            //  clean up the files in the directory
            if (cbAutoFileRetention.Checked == true)
                cleanUpOldFiles();

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user has clicked exit on the main menu
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e) {
            this.Close();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make private notes stickey
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lPrivNotes_Click(object sender, EventArgs e) {
            if (lPrivNotes.ForeColor == SystemColors.ControlDark)
                lPrivNotes.ForeColor = SystemColors.ControlText;
            else
                lPrivNotes.ForeColor = SystemColors.ControlDark;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make cost stickey
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lCost_Click(object sender, EventArgs e) {
            if (lCost.ForeColor == SystemColors.ControlDark)
                lCost.ForeColor = SystemColors.ControlText;
            else
                lCost.ForeColor = SystemColors.ControlDark;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make location stickey
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lLocation_Click(object sender, EventArgs e) {
            if (lLocation.ForeColor == SystemColors.ControlDark)
                lLocation.ForeColor = SystemColors.ControlText;
            else
                lLocation.ForeColor = SystemColors.ControlDark;

        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make shipping stickey
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void gbShipping_Click(object sender, EventArgs e) {
            if (gbShipping.ForeColor == SystemColors.ControlDark)
                gbShipping.ForeColor = SystemColors.ControlText;
            else
                gbShipping.ForeColor = SystemColors.ControlDark;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make place stickey
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lPlace_Click(object sender, EventArgs e) {
            if (lPlace.ForeColor == SystemColors.ControlDark)
                lPlace.ForeColor = SystemColors.ControlText;
            else
                lPlace.ForeColor = SystemColors.ControlDark;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make binding stickey
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lBinding_Click(object sender, EventArgs e) {
            if (lBinding.ForeColor == SystemColors.ControlDark)
                lBinding.ForeColor = SystemColors.ControlText;
            else
                lBinding.ForeColor = SystemColors.ControlDark;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make condition stickey
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lCondition_Click(object sender, EventArgs e) {
            if (lCondition.ForeColor == SystemColors.ControlDark)
                lCondition.ForeColor = SystemColors.ControlText;
            else
                lCondition.ForeColor = SystemColors.ControlDark;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make jacket condition stickey
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lJacket_Click(object sender, EventArgs e) {
            if (lJacket.ForeColor == SystemColors.ControlDark)
                lJacket.ForeColor = SystemColors.ControlText;
            else
                lJacket.ForeColor = SystemColors.ControlDark;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    type of catalog changed
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void rbCatalog_CheckedChanged(object sender, EventArgs e) {
            if (rbCatalog.Checked == true)
                lbChangePricesCat.Enabled = true;
            else
                lbChangePricesCat.Enabled = false;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    check to see if there are any changes to canned text
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

        private void lbCannedText_SelectedIndexChanged(object sender, EventArgs e) {
            switch (lbCannedText.SelectedIndex) {
                case 0:
                    tbBookNotes.AppendText("  " + tbCannedDesc1.Text);
                    break;
                case 1:
                    tbBookNotes.AppendText("  " + tbCannedDesc2.Text);
                    break;
                case 2:
                    tbBookNotes.AppendText("  " + tbCannedDesc3.Text);
                    break;
                case 3:
                    tbBookNotes.AppendText("  " + tbCannedDesc4.Text);
                    break;
                case 4:
                    tbBookNotes.AppendText("  " + tbCannedDesc5.Text);
                    break;
                case 5:
                    tbBookNotes.AppendText("  " + tbCannedDesc6.Text);
                    break;
                case 6:
                    tbBookNotes.AppendText("  " + tbCannedDesc7.Text);
                    break;
                case 7:
                    tbBookNotes.AppendText("  " + tbCannedDesc8.Text);
                    break;
                case 8:
                    tbBookNotes.AppendText("  " + tbCannedDesc9.Text);
                    break;
                case 9:
                    tbBookNotes.AppendText("  " + tbCannedDesc10.Text);
                    break;
                case 10:
                    tbBookNotes.AppendText("  " + tbCannedDesc11.Text);
                    break;
                case 11:
                    tbBookNotes.AppendText("  " + tbCannedDesc12.Text);
                    break;
                case 12:
                    tbBookNotes.AppendText("  " + tbCannedDesc13.Text);
                    break;
                case 13:
                    tbBookNotes.AppendText("  " + tbCannedDesc14.Text);
                    break;
                case 14:
                    tbBookNotes.AppendText("  " + tbCannedDesc15.Text);
                    break;
                case 15:
                    tbBookNotes.AppendText("  " + tbCannedDesc16.Text);
                    break;
                case 16:
                    tbBookNotes.AppendText("  " + tbCannedDesc17.Text);
                    break;
                case 17:
                    tbBookNotes.AppendText("  " + tbCannedDesc18.Text);
                    break;
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    get updates clicked from main menu
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void getUpdatesToolStripMenuItem_Click(object sender, EventArgs e) {
            if (newVersionAvailableToolStripMenuItem1.Visible) {
                if (workOfflineToolStripMenuItem.Checked == true)
                    System.Diagnostics.Process.Start("http://pragersoftware.com/downloads.htm");
                else
                    MessageBox.Show("You must be connected to the internet to check for updates (program automatically checks at startup)",
                        "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("You are running the latest version", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    show license screen
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void licenseToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!networkedClient) {
                DisplayLicenseScreen licScreen = new DisplayLicenseScreen();
                licScreen.Show();
            }
            else {
                MessageBox.Show("You must renew your license from the SERVER machine; the CLIENT machine uses the SERVER's license", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }



        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    populate detail panel
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //public string bookNbr;
        //private void dgBooks_Click(object sender, EventArgs e) {
        //    PopulateDetailPanel(bookNbr);  //  now populate the detail panel
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    inclusive search
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bSSearch_Click(object sender, EventArgs e) {
            doInclusiveSearch();
        }



        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    databasePanel selected index changed
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ListView.SelectedIndexCollection dbPanelIndex = null;
        private void dataBasePanel_SelectedIndexChanged(object sender, EventArgs e) {

            doingAnAdd = false;  //  guess we're not doing an add

            dbPanelIndex = dataBasePanel.SelectedIndices;  //  find which row was selected

            if (dbPanelIndex.Count > 1) { //  more than one row was selected..
                bDeleteBook.Enabled = true;
                bClone.Enabled = true;
                bLookupPrices.Enabled = false;
                bGetInfoWISBN.Enabled = false;
                bUpdateInfo.Enabled = false;
                bLookupPrices.Enabled = false;
                bAddRecord.Enabled = false;
                bUpdateRecord.Enabled = false;
                bRelist.Enabled = false;
                bClear.Enabled = false;
                bNextBook.Enabled = false;
            }
            else if (dbPanelIndex.Count == 1)  //  only selected one row
            {
                foreach (int lvIndex in dbPanelIndex)
                    bookNbr = dataBasePanel.Items[lvIndex].SubItems[0].Text;


                if (tabTaskPanel.SelectedIndex == cASIN) { //  if we are just going after the ASIN...
                    if (workOfflineToolStripMenuItem.Checked == true)
                        return;  //  we're working offline for now...

                    populateASINPage(bookNbr);  //  fill in book data
                    tbasinASIN.Text = "";
                    Application.DoEvents();

                    asin grabbit = new asin();
                    grabbit.getASIN(listView1, tbasinSKU.Text, tbasinTitle.Text, tbasinAuthor.Text, tbasinPublisher.Text, tbAWSKey.Text,
                        tbAWSSecretKey.Text, tbasinASIN, bookConn, dataBasePanel, dataBasePanel.SelectedIndices);
                }
                else
                    PopulateDetailPanel(bookNbr);  //  now populate the detail panel

                tbBookNbr.Enabled = false;  //  don't allow the number to be changed
                bDeleteBook.Enabled = true;  //  allow deletes regardless of status
                bClone.Enabled = true;
                bClear.Enabled = true;
                bNextBook.Enabled = true;

                if (tbCopies.Text.Length != 0 && int.Parse(tbCopies.Text) == 0)  //  book has been sold, so don't allow anything except 'delete' and 'relist'   
                {
                    bLookupPrices.Enabled = false;
                    bGetInfoWISBN.Enabled = false;
                    bUpdateInfo.Enabled = false;
                    bLookupPrices.Enabled = false;
                    bAddRecord.Enabled = false;
                    bUpdateRecord.Enabled = true;  //  just in case it was a mistake
                    bRelist.Enabled = true;
                }
                else  //  book has a quantity of 1 or greater or has been placed on Hold
                {
                    if (!freeTrialExpired)
                        bLookupPrices.Enabled = true;

                    bUpdateInfo.Enabled = true;
                    bAddRecord.Enabled = false;
                    bUpdateRecord.Enabled = true;
                    bRelist.Enabled = false;

                    if (mtbISBN.Text.Length == 0)
                        bGetInfoWISBN.Enabled = false;
                    else
                        bGetInfoWISBN.Enabled = true;
                }

                if (tabTaskPanel.SelectedIndex != cASIN)
                    tabTaskPanel.SelectTab(cBookDetail);//  make Detail tab the default

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
        //--    add book to shopping cart
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bShoppingCart_Click(object sender, EventArgs e) {
            if (int.Parse(tbCopies.Text) != 0) {
                MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();
                DialogResult dr =
                    dlg.Show(@"Software\Prager\BookInventoryManager\Cart",  //  registry entry
                    "DontShowAgain",  //  registry value name
                    DialogResult.OK,  //  default return value returned immediately if box is not shown
                    "Don't show this again",  //  message for checkbox
                    "The quantity for this book is not zero; are you sure you want to send this book to the shopping cart?",
                    "Prager Book Inventory Manager",  //  window title
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);  //  button and icon code
                if (dr.ToString() == "No")
                    return;
            }

            ListViewItem lvi = dataBasePanel.FindItemWithText(tbBookNbr.Text);  //  find the item we were working on...
            int listIndex = lvi.Index;

            if (dataBasePanel.Items[listIndex].SubItems[7].Text.Length == 0)  //  if greater than zero, this book is already attached to invoice
                shoppingCart.Add(tbBookNbr.Text);
            else
                MessageBox.Show("This book is already attached to an invoice: " + dataBasePanel.Items[listIndex].SubItems[7].Text,
                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            System.Diagnostics.Process.Start("http://pragersoftware.com/support.htm");
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    exit clicked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void toolStripMenuItemExit_Click(object sender, EventArgs e) {
            this.Close();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    mass change clicked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bMassChange_Click(object sender, EventArgs e) {
            makeMassChange();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    delete record from invoice
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bDeleteInvoice_Click(object sender, EventArgs e) {
            deleteRecordFromInvoiceTable();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update invoice
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bUpdateInvoice_Click(object sender, EventArgs e) {
            updateInvoiceTable();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    add invoice to table
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bAddInvoice_Click(object sender, EventArgs e) {
            addInvoiceToTable();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    search customer table by cust number
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
        //--    print preview of invoice
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bPrintPreview_Click(object sender, EventArgs e) {
            previewPrintInvoice();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    do page setup
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bPageSetup_Click(object sender, EventArgs e) {
            pageSetup();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    print invoice
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bPrintInvoice_Click(object sender, EventArgs e) {
            printInvoice();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    draw the invoice
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            tbBusinessAddr.BorderStyle = BorderStyle.None;
            if (cbUseReceipt.Checked == false)
                drawInvoice(e.Graphics);
            else
                drawReceipt(e.Graphics);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user wants to change the logo
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bChangeLogo_Click(object sender, EventArgs e) {

            openFileDialog1.Filter = @"BMP files (*.bmp)|*.bmp|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                pInvoiceLogo.Image = Image.FromFile(openFileDialog1.FileName);
                pictureFileName = openFileDialog1.FileName;
            }

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    remove item from shopping cart
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
            if (cbSortOverride.Checked == true)  // if overriding the sorting of columns, do nothing
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
                    commandString = "SELECT BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr from tBooks where Stat = 'For Sale' ORDER BY ";
                else if (tsShowHold.Checked == true)
                    commandString = "SELECT BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr from tBooks where Stat = 'Hold' ORDER BY ";
                else if (tsShowSold.Checked == true)
                    commandString = "SELECT BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr from tBooks where Stat = 'Sold' ORDER BY ";
                else if (tsShowPending.Checked == true)
                    commandString = "SELECT BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr from tBooks where Stat = 'Pending' ORDER BY ";
                else
                    commandString = "SELECT BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr from tBooks ORDER BY ";
            }
            else  //  "freeze results" is in effect
            {

                commandString = inclusiveSearchString + " ORDER BY ";  //  use inclusive search select statement
            }

            switch (sortColumn)  //  determine which column to sort on...
            {
                case 0:  //  SKU
                    commandString += "BookNbr " + sequence;
                    break;
                case 1:  //  Title
                    commandString += "Title " + sequence;
                    break;
                case 2:  //  number of copies
                    commandString += " Quantity " + sequence;
                    break;
                case 3:  //  ISBN
                    commandString += "ISBN " + sequence;
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
        //--    left title textbox
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbTitle_Leave(object sender, EventArgs e) {
            if (cbCapTitleAuthor.Checked == true)
                tbTitle.Text = tbTitle.Text.ToUpper();

            if (cbCreateKeywords.Checked == true)
                tbKeywords.Text = parseKeywords(tbTitle.Text);

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    left author textbox
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbAuthor_Leave(object sender, EventArgs e) {
            if (cbCapTitleAuthor.Checked == true)
                tbAuthor.Text = tbAuthor.Text.ToUpper();

            if (cbAddAuthor2Keywords.Checked == true)
                tbKeywords.Text += parseKeywords(tbAuthor.Text);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    mass changes
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbPriceFrom_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
                e.Handled = true;  //  reject the keypress
        }
        private void tbPriceTo_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
                e.Handled = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make sure amount is numeric
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e) {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != '.' && e.KeyChar != '\b')
                e.Handled = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    title changed
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbTitle_TextChanged(object sender, EventArgs e) {

            if (updateNeeded == true) {
                bUpdateRecord.BackColor = Color.OrangeRed;
                bUpdateRecord.Enabled = true;
            }
            //else {
            //    bAddRecord.BackColor = Color.OrangeRed;
            //    bAddRecord.Enabled = true;
            //}

            if (tbTitle.Text.Length > 0 && tbAuthor.Text.Length > 0)
                bGetInfoWISBN.Enabled = true;
            else
                bGetInfoWISBN.Enabled = false;

        }


        ////----------------------------------------------------------------------------------------
        //private void tbAuthor_TextChanged(object sender, EventArgs e) {
        //    //  if we are adding a record, don't highlight 'update' button
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }

        //    if (tbAuthor.Text.Length > 75)
        //        tbAuthor.Text = tbAuthor.Text.Substring(0, 75);

        //    if (tbTitle.Text.Length > 0 && tbAuthor.Text.Length > 0)
        //        bGetInfoWISBN.Enabled = true;
        //    else
        //        bGetInfoWISBN.Enabled = false;
        //}


        ////---------------------------------------------------------------------------------------
        //private void tbIllus_TextChanged(object sender, EventArgs e) {
        //    //  if we are adding a record, don't highlight 'update' button
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }

        //    if (tbIllus.Text.Length > 75)
        //        tbIllus.Text = tbIllus.Text.Substring(0, 75);
        //}


        ////--------------------------------------------------------------------------------------
        //private void tbPub_TextChanged(object sender, EventArgs e) {
        //    //  if we are adding a record, don't highlight 'update' button
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }

        //    if (tbPub.Text.Length > 85)
        //        tbPub.Text = tbPub.Text.Substring(0, 85);
        //}


        ////--------------------------------------------------------------------------------------
        //private void tbPlace_TextChanged(object sender, EventArgs e) {
        //    //  if we are adding a record, don't highlight 'update' button
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }

        //    if (tbPlace.Text.Length > 25)
        //        tbPlace.Text = tbPlace.Text.Substring(0, 25);
        //}
       

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    common routine for text changed
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void textbox_TextChanged(object sender, EventArgs e) {

            //  if we are adding a record, don't highlight 'update' button
            if (updateNeeded) {
                bUpdateRecord.BackColor = Color.OrangeRed;
                bUpdateRecord.Enabled = true;
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    bindings have changed, check for paperback
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void coBinding_SelectedIndexChanged(object sender, EventArgs e) {
            if (!cbAmazonCategories.Checked)  //  we're not using Amazon categories...
            {
                switch (coBinding.SelectedIndex) {
                    case 0:
                    case 3:  //  MMPB
                    case 4:  //  Trade PB
                    case 5:  //  Leather
                    case 6:  //  Spiral
                        coJacket.SelectedIndex = 8;  // set jacket to "none as issued"
                        break;
                    case 1:  //  hard cover
                    case 2:  //  Cloth
                    case 7:  //  other
                    default:
                        break;
                }
            }
            else //  use Amazon binding categories to determine dj 
            {
                switch (coBinding.SelectedIndex) {
                    case 1:  //  hardcover
                        coJacket.SelectedIndex = 0;  // clear it...
                        break;
                    case 0:  //  paperback
                        if (cbUseBlank.Checked)
                            coJacket.SelectedIndex = 0;
                        break;
                    case 2:  //  Audio CD
                    case 3:  //  Board Book

                    case 4:  //  Calendar
                    case 5:  //  Cards
                    case 6:  //  Audio Casette
                    case 7:  //  CD-ROM
                    case 8:  //  Comic
                    case 9:  //  Hardcover Comic
                    case 10:  //  Diskette
                    case 11:  //  
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                        coJacket.SelectedIndex = 8;  // none as issued
                        break;
                    //case -1:  //  no selection
                    //    coJacket.SelectedIndex = -1;  // clear it...
                    //    break;
                    default:
                        break;
                }
            }

            //  if we are adding a record, don't highlight 'update' button
            if (updateNeeded == true) {
                bUpdateRecord.BackColor = Color.OrangeRed;
                bUpdateRecord.Enabled = true;
            }

        }


        ////-------------------------------------------------------------------------------------------------
        //private void tbDesc_TextChanged(object sender, EventArgs e) {
        //    //  if we are adding a record, don't highlight 'update' button
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }

        //    if (tbDesc.Text.Length > 500)
        //        tbDesc.Text = tbDesc.Text.Substring(0, 500);
        //}


        ////-------------------------------------------------------------------------------------------------
        //private void tbKeywords_TextChanged(object sender, EventArgs e) {
        //    //  if we are adding a record, don't highlight 'update' button
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }

        //    if (tbKeywords.Text.Length > 85)
        //        tbKeywords.Text = tbKeywords.Text.Substring(0, 85);
        //}


        ////---------------------------------------------------------------------------------------------
        //private void tbPriCatalog_TextChanged(object sender, EventArgs e) {
        //    //  if we are adding a record, don't highlight 'update' button
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }

        //    if (tbPriCatalog.Text.Length > 50)
        //        tbPriCatalog.Text = tbPriCatalog.Text.Substring(0, 50);
        //}


        ////--------------------------------------------------------------------------------------------
        //private void tbSecCatalog_TextChanged(object sender, EventArgs e) {
        //    //  if we are adding a record, don't highlight 'update' button
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }

        //    if (tbSecCatalog.Text.Length > 50)
        //        tbSecCatalog.Text = tbSecCatalog.Text.Substring(0, 50);
        //}


        ////-------------------------------------------------------------------------------------------
        //private void tbNotes_TextChanged(object sender, EventArgs e) {
        //    //  if we are adding a record, don't highlight 'update' button
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }

        //    if (tbNotes.Text.Length > 50)
        //        tbNotes.Text = tbNotes.Text.Substring(0, 50);
        //}


        ////--------------------------------------------------------------------------------------
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
        //--    doing a purge replace
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void cbPurgeReplace_CheckedChanged(object sender, EventArgs e) {
            if (cbPurgeReplace.Checked == true) {
                if (cbUploadAlibris.Checked == false &&
                    cbUploadBiblio.Checked == false &&
                    cbUploadChooseBks.Checked == false &&
                    cbUploadValoreBooks.Checked == false &&
                    cbUploadAmazon.Checked == false &&
                    //tbHalfDotComToken.Text.Length == 0 &&
                    cbUploadBandN.Checked == false &&
                    cbUploadChrislands.Checked == false) {
                    MessageBox.Show("You do not have a valid site checked for purge/replace on the Uploads page",
                        "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    cbUploadPurgeReplace.Checked = true;  //  check here too...
            }
            else
                cbUploadPurgeReplace.Checked = false;  //  make sure this matches...
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    doing a drag n' drop on mapping names
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lbMappingNames_MouseDown(object sender, MouseEventArgs e) {
            // Start the Drag Operation
            string strItem = e.ToString();
            DoDragDrop(strItem, DragDropEffects.Copy | DragDropEffects.Move);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    drag and drop for tab mapping
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbMapBookNbr_DragDrop(object sender, DragEventArgs e) {
            tbMapBookNbr.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapAuthor_DragDrop(object sender, DragEventArgs e) {
            tbMapAuthor.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapIllus_DragDrop(object sender, DragEventArgs e) {
            tbMapIllus.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapTitle_DragDrop(object sender, DragEventArgs e) {
            tbMapTitle.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapPublisher_DragDrop(object sender, DragEventArgs e) {
            tbMapPublisher.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapKeywords_DragDrop(object sender, DragEventArgs e) {
            tbMapKeywords.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapDesc_DragDrop(object sender, DragEventArgs e) {
            tbMapDesc.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapPrice_DragDrop(object sender, DragEventArgs e) {
            tbMapPrice.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapBinding_DragDrop(object sender, DragEventArgs e) {
            tbMapBinding.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapEdition_DragDrop(object sender, DragEventArgs e) {
            tbMapEdition.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapCatalog_DragDrop(object sender, DragEventArgs e) {
            tbMapCatalog.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapISBN_DragDrop(object sender, DragEventArgs e) {
            tbMapISBN.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapDJCond_DragDrop(object sender, DragEventArgs e) {
            tbMapDJCond.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapBookCond_DragDrop(object sender, DragEventArgs e) {
            tbMapBookCond.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapPubLoc_DragDrop(object sender, DragEventArgs e) {
            tbMapPubLoc.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapSignedAuthor_DragDrop(object sender, DragEventArgs e) {
            tbMapSignedAuthor.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapSignedIllus_DragDrop(object sender, DragEventArgs e) {
            tbMapSignedIllus.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapCost_DragDrop(object sender, DragEventArgs e) {
            tbMapCost.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapYearPub_DragDrop(object sender, DragEventArgs e) {
            tbMapYearPub.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapBookSize_DragDrop(object sender, DragEventArgs e) {
            tbMapBookSize.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapType_DragDrop(object sender, DragEventArgs e) {
            tbMapType.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapDateSold_DragDrop(object sender, DragEventArgs e) {
            tbMapDateSold.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapStatus_DragDrop(object sender, DragEventArgs e) {
            tbMapStatus.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapSecCat_DragDrop(object sender, DragEventArgs e) {
            tbMapSecCat.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapPrivateNotes_DragDrop(object sender, DragEventArgs e) {
            tbMapPrivateNotes.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbMapLocation_DragDrop(object sender, DragEventArgs e) {
            tbMapLocation.Text = lbMappingNames.SelectedItem.ToString();
        }

        private void tbNbrOfCopies_DragDrop(object sender, DragEventArgs e) {
            tbNbrOfCopies.Text = lbMappingNames.SelectedItem.ToString();
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

        private void tbMapNbrPages_DragDrop(object sender, DragEventArgs e) {
            tbMapNbrPages.Text = lbMappingNames.SelectedItem.ToString();
        }
        private void tbMapWeight_DragDrop(object sender, DragEventArgs e) {
            tbMapWeight.Text = lbMappingNames.SelectedItem.ToString();
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
        //--    add customer button clicked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bAddCustomer_Click(object sender, EventArgs e) {
            addCustomerInfo();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update customer button clicked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bCustUpdate_Click(object sender, EventArgs e) {
            updateCustomerTable();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    delete record from customer table
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bCustDelete_Click(object sender, EventArgs e) {
            deleteRecordFromCustomerTable();
        }



        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    price change is to be absolute             <---------------------------------- TODO ????
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
        //--    web browser control buttons
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bStop_Click(object sender, EventArgs e) {
            webBrowser1.Stop();
        }
        private void bGoBack_Click(object sender, EventArgs e) {
            webBrowser1.GoBack();
        }
        //-------------------------------------------------------------------------------------------------------
        private void bGoForward_Click(object sender, EventArgs e) {
            webBrowser1.GoForward();
        }
        //-------------------------------------------------------------------------------------------------------
        private void bPrintWebPage_Click(object sender, EventArgs e) {
            webBrowser1.Print();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--   Display the OpenDialog Window to allow user to select a file for importing
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bOpenFileDialog_Click(object sender, EventArgs e) {
            //string[] tempFilename;
            openFileDialog1.Filter = @"Import files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                if (sender == bOpenFileDialog) {
                    sFileName1 = openFileDialog1.FileName;
                    tbFileName.Text = sFileName1;
                    bImportBooks.Enabled = true;
                }
                else if (sender == bSUbrowse) {
                    sFileName1 = openFileDialog1.FileName;
                    string[] tempFilename = sFileName1.Split('\\');
                    tbSUfilename.Text = tempFilename[tempFilename.Length - 1];
                }
            }

            return;

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    save mapping
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bSaveMapping_Click(object sender, EventArgs e) {
            saveMapping();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    accounting year has changed
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lbAcctgYear_SelectedValueChanged(object sender, EventArgs e) {
            updateBookStatistics();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user wants to go to our website
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void pragerOnTheWebToolStripMenuItem_Click(object sender, EventArgs e) {

            System.Diagnostics.Process.Start("http://www.pragersoftware.com/");
        }


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    save user IDs
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void bSaveUIDs_Click(object sender, EventArgs e) {
        //populateUIDs ui = new populateUIDs();  //  instantiate...
        //ui.saveDGVContents(UIDdataGridView, this);  //  save user ID's and passwords
        //    //ui.populateDataGridView(UIDdataGridView);   //  refresh 
        //    //lMsgSettingsSaved.Visible = true;
        //}


        ////-----------------------------------------------------------------------------------------
        //private void cbWillShipIntl_CheckStateChanged(object sender, EventArgs e) {
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }
        //}


        ////----------------------------------------------------------------------------------------
        //private void cbExpeditedShipping_CheckStateChanged(object sender, EventArgs e) {
        //    if (updateNeeded == true) {
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
        //        bUpdateRecord.Enabled = true;
        //    }
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user wants to change status
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bChangeStatus_Click(object sender, EventArgs e) {
            if (rbMarkSold.Checked == true)
                bulkMarkBoookStatus(1);  //  code 1 = Sold
            else if (rbMarkHold.Checked == true)
                bulkMarkBoookStatus(2);  //  code 2 = Hold
            else if (rbMark4Sale.Checked == true)
                bulkMarkBoookStatus(3);  //  code 3 = For Sale
        }


        ////--    attach catalog entry to record
        //private void bAttachPriCatalog_Click(object sender, EventArgs e) {
        //    choosingPrimary = true;
        //    populatePriCatalogListbox();
        //    tbPriCatalog.Text = "";  //  clear out the old stuff
        //    tabTaskPanel.SelectTab((int)cCatalogs);  //  go to Catalog tab
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    clear customer info button clicked
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
                MessageBox.Show("You must have an internet connection to do repricing", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  //  we're working offline for now...
            }

            prepareForPricingService();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    prepare for pricing
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void prepareForPricingService() {

            if ((rbPriceHighFixed.Checked == false && rbPriceHighPct.Checked == false)
                || (rbPriceLowFixed.Checked == false && rbPriceLowPct.Checked == false)) {
                MessageBox.Show("You must indicate how to compute a suggested price by selecting from each of the pairs of buttons" +
                    " in the groups marked REQUIRED.", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  check all fields for validity
            if (rbPriceHighFixed.Checked == true || rbPriceHighPct.Checked == true) {
                if (tbHighByAmt.Text.Length == 0 || (rbHighAbove.Checked == false && rbHighBelow.Checked == false) ||
                    lbWhatPriceH.SelectedIndex == -1) {
                    MessageBox.Show("Error: some fields missing in 'If my price is HIGH' filter", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (rbPriceLowFixed.Checked == true || rbPriceLowPct.Checked == true) {
                if (tbLowByAmt.Text.Length == 0 || (rbLowAbove.Checked == false && rbLowBelow.Checked == false) ||
                    lbWhatPriceL.SelectedIndex == -1) {
                    MessageBox.Show("Error: some fields missing in 'If my price is LOW' filter", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (rbPriceNewFixed.Checked == true || rbPriceNewPct.Checked == true) {
                if (tbNewByAmt.Text.Length == 0 || lbNewWhatPrice.SelectedIndex == -1) {
                    MessageBox.Show("Error: some fields missing in 'If book is NEW' filter", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (cbExcludeAbove.Checked == true && tbExcludeAboveAmt.Text.Length == 0) {
                MessageBox.Show("Error: you checked 'Exclude Above', but gave no amount", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbExcludeBelow.Checked == true && tbExcludeBelowAmt.Text.Length == 0) {
                MessageBox.Show("Error: you checked 'Exclude Below', but gave no amount", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbDontGoBelowCost.Checked == true && tbBelowMyCostOr.Text.Length == 0) {
                MessageBox.Show("Error: you checked 'Dont Price Below Cost or', but gave no amount", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            try {
                ArrayList parms = new ArrayList();
                parms.Insert(0, bookConn);
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
                parms.Insert(19, cbSkipFEandS);
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
                parms.Insert(40, tb1stPremium);
                parms.Insert(41, tbSignedPremium);
                parms.Insert(42, tbCondAmtVG);
                parms.Insert(43, tbCondAmtG);
                parms.Insert(44, tbCondAmtP);
                parms.Insert(45, cbAdjustPostage);
                parms.Insert(46, tbBelowMyCostOr);
                parms.Insert(47, null);   //  new 11.5.0  (not needed?)
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
                t.IsBackground = true;  //  prevent app from blocking exit

                //t.ApartmentState = 
                // t.SetApartmentState = ApartmentState.STA;
                t.Start();
                while (t.IsAlive) {
                    if (stopPricingService == true)
                        t.Abort();
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(500);

                }
            }
            catch (Exception ex) {
                MessageBox.Show("error: " + ex.Message);
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
        //--    update the records that were repriced
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bPricingServiceUpdate_Click(object sender, EventArgs e) {
            lPricingServiceStatus.Visible = false;
            updateFromPricingService();
            bPricingServiceUpdate.Enabled = false;  //  disable it...
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    transfers control the the customer info page
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lbSoldTo_Click(object sender, EventArgs e) {
            tabTaskPanel.SelectTab(cCustomerInfo);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user clicked a customer in the list
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
        //--    propogate billing info to shipping addr
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void cbSameAsBillingInfo_CheckedChanged(object sender, EventArgs e) {
            propagateBillingInfo();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user selected an invoice
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


        ////--    prints the contents of the listview
        //private void bPrintPricingService_Click(object sender, EventArgs e) {
        //    //  <------------------ TODO
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    mark all records for updating
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bMarkAll_Click(object sender, EventArgs e) {

            foreach (ListViewItem lvi in lvPricingService.Items) {
                if (lvi.SubItems.Count > 8 && !lvi.SubItems[8].Text.Trim().Contains("---"))  //  if there is a 'suggested price' and it's not '---'
                    //if (lvi.SubItems[8].Text.Trim() != lvi.SubItems[3].Text.Trim())   //  make sure it's not same as current price
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

        ////----------------------------------------------------------------------------------------------
        //private void mtbISBN_MouseDown(object sender, MouseEventArgs e) {
        //    if (mtbISBN.Text.Length == 0)
        //        mtbISBN.SelectionStart = 0;
        //}

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    ISBN text has changed
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void mtbISBN_TextChanged(object sender, EventArgs e) {

            if (mtbISBN.Text.Length == 10 && mtbISBN.Text.Substring(0, 3).Contains("978"))
                return;

            if (mtbISBN.Text.Length == 13 || mtbISBN.Text.Length == 10) {
                Repository.maskedTxtBoxValue = mtbISBN.Text;  //  save it just in case we crash!

                if (freeTrialExpired == false) {
                    bLookupPrices.Enabled = true;
                    bUpdateInfo.Enabled = true;
                    bGetInfoWISBN.Enabled = true;  //  allow button to be clicked
                    bGetInfoWISBN.Focus();  //  and give it focus for enter key
                }
                else {
                    bLookupPrices.Enabled = false;
                    bGetInfoWISBN.Enabled = false;
                    bUpdateInfo.Enabled = false;
                }
            }
            else  //  text length in box is less than any valid ISBN or ASIN
            {
                bLookupPrices.Enabled = false;
                bGetInfoWISBN.Enabled = false;
                bUpdateInfo.Enabled = false;
            }
        }


        ////----------------------------------------------------------------------------------------------
        //private void rbSearchCatalog_Click(object sender, EventArgs e) {
        //    searchOnCatalog = true;
        //    tabTaskPanel.SelectTab((int)cCatalogs);  //  go to Catalog tab and allow user to pick catalog
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    mark that the user clicked the catalog tab
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tabTaskPanel_Click(object sender, EventArgs e) {
            if (tabTaskPanel.SelectedIndex == cCatalogs)
                catalogTabClicked = true;
            else
                catalogTabClicked = false;
        }


        ////------------    tool to convert 10-digit ISBN to 13-digits    -------------------------------
        //private void convertTo13digitISBNToolStripMenuItem_Click(object sender, EventArgs e) {

        //}
        //private void bConvertToISBN13_Click(object sender, EventArgs e) {
        //    //ConvertISBN ISBNConverter = new ConvertISBN();
        //    //string ISBN13 = ISBNConverter.convertToISBN13("0345377443");

        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    purge books by year
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bDeleteByYear_Click(object sender, EventArgs e) {
            purgeBooksByYear();
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user wants to purge books (next 2 methods)
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void cbDeleteByYear_CheckedChanged(object sender, EventArgs e) {
            if (cbDeleteByYear.Checked == true && tbPurgeDate.Text.Length == 4)
                bDeleteByYear.Enabled = true;
            else
                bDeleteByYear.Enabled = false;
        }
        private void tbPurgeDate_TextChanged(object sender, EventArgs e) {
            if (tbPurgeDate.Text.Length == 4 && DateTime.Now.Year.ToString() == tbPurgeDate.Text) {
                MessageBox.Show("Error: you can not purge books in the current year", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Sorry, this report is not yet available.", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        //--    check to see if we need to mask the input      <-------------------  DO WE REALLY NEED THIS?????  TODO
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbCustID_KeyPress(object sender, KeyPressEventArgs e) {
            if (cbAutoCustomerNbr.Checked == true) {
                if (char.IsDigit(e.KeyChar) == false && e.KeyChar != '\b')  //  if it's not a digit or a backspace
                {
                    MessageBox.Show("Because you have checked Auto Generate Customer Numbers, your starting number must be numeric",
                        "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Handled = true;
                }
            }
        }


        ////----------------------    handle images to/from database    ---------------------------
        //private void imageAdd_Click(object sender, EventArgs e)
        //{
        //}

        //private void imageUpdate_Click(object sender, EventArgs e)
        //{
        //    addBookImage();
        //}

        //private void imageDelete_Click(object sender, EventArgs e)
        //{
        //    deleteBookImage();
        //}


        ////-----------------    USED TO TEST THE GOOGLE XML CODE    -----------------------
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string formattedDate = DateTime.Now.ToString("MMddyyyyHHmmss");
        //    createGoogleXMLFormat(formattedDate);
        //}



        ////-----------------------    user has changed the id or password    ------------------
        //private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
        //    dataGridValueChanged(e);
        //}


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    pick website here
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void rbWWWBiblio_CheckedChanged(object sender, EventArgs e) {
        //    if (workOfflineToolStripMenuItem.Checked == true)
        //        return;  //  we're working offline for now...

        //    if (mtbISBN.Text.Length != 0)
        //        webBrowser1.Navigate("http://www.biblio.com/isbn/" +
        //        mtbISBN.Text + ".html", false);
        //    else
        //        webBrowser1.Navigate("http://www.biblio.com", false);
        //}
        //private void rbWWWAddAll_CheckedChanged(object sender, EventArgs e) {
        //    if (workOfflineToolStripMenuItem.Checked == true)
        //        return;  //  we're working offline for now...

        //    if (mtbISBN.Text.Length != 0)
        //        webBrowser1.Navigate("http://used.addall.com/SuperRare/submitRare.cgi?author=" +
        //        "&title=&keyword=&isbn=" + mtbISBN.Text + "&order=TITLE&ordering=ASC&dispCurr=USD" +
        //        "&binding=Any+Binding&min=&max=&timeout=20&match=Y&store=Abebooks&store=" +
        //        "AbebooksDE&store=AbebooksFR&store=AbebooksUK&store=Alibris&store=Amazon&store" +
        //        "=AmazonCA&store=AmazonUK&store=AmazonDE&store=AmazonFR&store=Antiqbook&store=" +
        //        "Biblio&store=Biblion&store=Bibliophile&store=Bibliopoly&store=Booksandcollectibles" +
        //        "&store=Half&store=ILAB&store=LivreRareBook&store=Powells&store=Strandbooks&store=ZVAB", false);
        //    else
        //        webBrowser1.Navigate("http://used.addall.com/", false);
        //}
        //private void rbWWWBookfinder_CheckedChanged(object sender, EventArgs e) {
        //    if (workOfflineToolStripMenuItem.Checked == true)
        //        return;  //  we're working offline for now...

        //    if (mtbISBN.Text.Length != 0)
        //        webBrowser1.Navigate("http://www.bookfinder.com/search/?author=&title=&lang=en" +
        //        "&submit=Begin+search&new_used=%2A&destination=us&currency=USD&binding=%2A&isbn=" +
        //        mtbISBN.Text +
        //        "&keywords=&minprice=&maxprice=&mode=advanced&st=sr&ac=qr", false);
        //    else
        //        webBrowser1.Navigate("http://www.bookfinder.com", false);
        //}
        //private void rbWWWAmazon_CheckedChanged(object sender, EventArgs e) {
        //    if (workOfflineToolStripMenuItem.Checked == true)
        //        return;  //  we're working offline for now...

        //    if (rbAmazonUS.Checked)
        //        webBrowser1.Navigate("http://www.amazon.com", false);
        //    else if (rbAmazonCA.Checked)
        //        webBrowser1.Navigate("http://www.amazon.ca", false);
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    the following two methods increment/decrement the copies field
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bDecrement_Click(object sender, EventArgs e) {
            int x = int.Parse(tbCopies.Text);
            if (--x >= 0)
                tbCopies.Text = x.ToString();

            //bShoppingCart.Enabled = true;
            if (bUpdateRecord.Enabled == true)
                bUpdateRecord.BackColor = Color.OrangeRed;
        }
        private void bIncrement_Click(object sender, EventArgs e) {
            if (tbCopies.Text.Length == 0)
                tbCopies.Text = "1";
            int x = int.Parse(tbCopies.Text) + 1;
            tbCopies.Text = x.ToString();
            if (bUpdateRecord.Enabled == true)
                bUpdateRecord.BackColor = Color.OrangeRed;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    fill in book detail w/optional prices
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bGetInfoWISBN_Click(object sender, EventArgs e) {

            if (workOfflineToolStripMenuItem.Checked == true) {
                MessageBox.Show("Did you forget? You're working offline now", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;  //  we're working offline for now...
            }

            bool foundFlag = false;
            lNotFound.Visible = false;
            doingAnUpdate = false;
            bool rc = true;

            //  get book information
            if (cbUseAmazon4BookInfo.Checked && missingAmazonKeys == false)
                foundFlag = BookInfoLookup(mtbISBN.Text, tbAWSKey.Text, tbMerchantID.Text, tbMarketplaceID.Text,
                    tbAWSSecretKey.Text);
            else {
                GetBookInfo gbi = new GetBookInfo();  // get book information from openISBN.com
                foundFlag = gbi.getBookInfo(mtbISBN, tbTitle, tbAuthor, tbPub, tbPages, tbYear, coBinding, coEdition);
            }

            if (foundFlag == false)
                lNotFound.Visible = true;

            //  get book prices if requested
            char bookCondn = ' ';
            if (cbAutoPricingLookup.Checked == true && rc == true) {
                bookCondn = coCondition.Text.ToLower().Contains("used") ? 'u' : 'n';
                getBookPrices(bookCondn, tbAWSKey.Text);  //  get prices for this book and fill in tab(1)
            }

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    getPricesFromInternet clicked
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bLookupPrices_Click(object sender, EventArgs e) {

            if (workOfflineToolStripMenuItem.Checked == true) {
                MessageBox.Show("Did you forget? You're working offline now", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;  //  we're working offline for now...
            }

            char bookCondn = ' ';
            lNotFound.Visible = false;  //  reset it...

            bookCondn = coCondition.Text.ToString().ToLower().Contains("new") ? 'n' : 'u';
            getBookPrices(bookCondn, tbAWSKey.Text);  //  get prices for this book and display on tab(1)

            //tabTaskPanel.SelectTab(cPricingResults);  //  now go to the results tab
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    populate secondary catalog
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lbPrimaryCatalog_Click(object sender, EventArgs e) {
            populateSecCatalogListbox();
            choosePriCatalogEntry();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user clicked on secondary catalog
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void lbSecondaryCatalog_Click(object sender, EventArgs e) {
            chooseSecondaryCatalogEntry();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user selected the catalog tab
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bSelectCatalog_Click(object sender, EventArgs e) {
            tabTaskPanel.SelectTab(cCatalogs);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user wants next book in list
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bNextBook_Click(object sender, EventArgs e) {
            getNextBookInList();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    toggle to turn on or off tool tips
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void cbToolTips_CheckedChanged(object sender, EventArgs e) {
            if (cbToolTips.Checked == true)
                toolTip1.Active = false;
            else
                toolTip1.Active = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    check for illegal cross threads
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void mainForm_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user has clicked on the ISBN field - set to start on position 0
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void mtbISBN_MouseClick(object sender, MouseEventArgs e) {
            mtbISBN.SelectionStart = 0;
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
            fillDataBasePanel(createCommandString());  //  fill the tBooks datagridview 

            //tbPriCatalogSearch.Text = " ";
            searchOnCatalog = false;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    Creates the error message and sends it.
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void ShowThreadExceptionDialog(string title, Exception ex, string mtv) {

            StringBuilder traceData = new StringBuilder(256);

            for (int i = 0; i < trace.Count; i++)
                traceData.Append(trace[i] + "\n");

            StackTrace st = new StackTrace(new StackFrame(true));
            StackFrame sf = st.GetFrame(0);

            string emailData = DateTime.Now + "\n\rVersion: " + versionNumber +
                "\n\rOS: " + osName + " (SP: " + osServicePack + ")" +
                "  Memory: " + amountOfMemory + " Mb   Culture Info: " + localCulture +
                "\n\rError Message: " + ex.Message +
                "\n\r mtbISBN: " + mtv + "\n\r commandString: " + commandString +
                "\n\r MAC: " + MACAddress + "      License: " + encryptedDate +
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
                "Exception in Book Inventory Manager", emailData, sendComplete);

        }

        //--  handler for when the email send has completed
        private static void smtp_SendCompleted(object sender, AsyncCompletedEventArgs e) {
            systemCrash = true;
            //        Application.Exit();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    email debugging data
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void emailDebuggingData(string data) {

            string emailData = "->007-" + DateTime.Now + "\n\rVersion: " + versionNumber + "\n\rOS: " + osName + " (SP: " +
                osServicePack + ")" + " MAC: " + MACAddress + "  Memory: " + amountOfMemory + " Mb   Culture Info: " +
                localCulture.ToString() + "\n\rData: " + data;

            MailMessage message = new MailMessage();
            message.Body = emailData;

            // SmtpClientEx client = new SmtpClientEx();
            SmtpClient client = new SmtpClient();
            client.Host = "mail.pragersoftware.com";

            client.Port = 25;
            client.Credentials = new NetworkCredential("support@pragersoftware.com", "Sp0Kane");

            object sendComplete = null; ;
            client.SendAsync("support@pragersoftware.com", "support@pragersoftware.com",
                "Debugging Data", emailData, sendComplete);

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    two buttons to throw exceptions (for testing)
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void button1_Click(object sender, EventArgs e) {
            throw new InvalidConstraintException();
        }
        private void button2_Click(object sender, EventArgs e) {
            throw new InvalidCastException();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    get Amazon Access Keys
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bGetAmazonKeys_Click(object sender, EventArgs e) {

            if (localCulture.ToString() == "en-US" || localCulture.ToString() == "en-CA") {
                webBrowser1.Navigate(@"http://aws.amazon.com");
                if (rbAmazonCA.Checked)
                    webBrowser1.Navigate(@"http://aws.amazon.ca");
            }
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

            if (localCulture.ToString() == "en-US" || localCulture.ToString() == "en-CA") {
                if (rbAmazonUS.Checked) {
                    webBrowser1.Navigate(@"https://affiliate-program.amazon.com/gp/flex/associates/apply-login.html");
                    if (rbAmazonCA.Checked)
                        webBrowser1.Navigate(@"https://affiliate-program.amazon.ca/");
                }
                else if (localCulture.ToString() == "en-GB")
                    webBrowser1.Navigate(@"https://affiliate-program.amazon.co.uk/");
            }
            tabTaskPanel.SelectTab(cWebPages);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    get Half.com Token
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bGetHalfToken_Click(object sender, EventArgs e) {

            webBrowser1.Navigate(@"https://signin.ebay.com/ws/eBayISAPI.dll?SignIn&runame=F-FILEEXL51P1EHH6L899Q9B969GE134DK-FileUpload");
            tabTaskPanel.SelectTab(cWebPages);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    subscribe to File Exchange
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bSubscribeFileEx_Click(object sender, EventArgs e) {

            webBrowser1.Navigate(@"http://pages.ebay.com/sellerinformation/sellingresources/fileexchange.html");
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
            bool foundFlag = false;

            //  get book information from ?
            if (cbUseAmazon4BookInfo.Checked) {
                if (tbAWSKey.Text.Length == 0 || tbAWSSecretKey.Text.Length == 0) {  //  if user doesn't have an Amazon Access Key, ask...
                    if (MessageBox.Show("You need an Amazon Access Key or Secret Key; do you want to get them now?", "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        System.Diagnostics.Process.Start(@"http://www.amazon.com/gp/aws/registration/registration-form.html");
                    if (rbAmazonCA.Checked)
                        System.Diagnostics.Process.Start(@"http://www.amazon.ca/gp/aws/registration/registration-form.html");
                    else  // no...
                        return;
                }

                foundFlag = BookInfoLookup(mtbISBN.Text, tbAWSKey.Text, tbMerchantID.Text, tbMarketplaceID.Text,
                    tbAWSSecretKey.Text);
            }
            else {
                GetBookInfo gbi = new GetBookInfo();
                foundFlag = gbi.getBookInfo(mtbISBN, tbTitle, tbAuthor, tbPub, tbPages, tbYear, coBinding, coEdition);
            }

            char bookCondn = ' ';

            if (cbAutoPricingLookup.Checked == true) {
                bookCondn = coCondition.Text.ToString().ToLower().Contains("used") ? 'u' : 'n';
                getBookPrices(bookCondn, tbAWSKey.Text);  //  get prices for this book and fill in tab(1)
                //             tabTaskPanel.SelectTab(cPricingResults);  //  now go to the results tab
            }

            if (foundFlag == false)
                lNotFound.Visible = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    when Hold Status changes, make sure Update button is set to red
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void cbStatusHold_CheckedChanged(object sender, EventArgs e) {
            bUpdateRecord.BackColor = Color.OrangeRed;
        }


        //private void rbSortDirection_CheckedChanged(object sender, EventArgs e)  //  for DESC also
        //{
        //    createCommandString();
        //    fillDataBasePanel(commandString);
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  user wants to see the tutorials
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tutorialsToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://www.pragersoftware.com/tutorials.html");

        }


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--    toggle to place book on hold
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void bHold_Click(object sender, EventArgs e) {
        //    if (cbStatusHold.Checked)
        //        cbStatusHold.Checked = false;
        //    else
        //        cbStatusHold.Checked = true;
        //}


        //private void bAddImage_Click(object sender, EventArgs e)
        //{
        //    addBookImage();  TODO 
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    image handling routines         <------------------------- TODO (replace with URL)
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bUpdateImage_Click(object sender, EventArgs e) {
            addBookImage();
        }
        private void bDeleteImage_Click(object sender, EventArgs e) {
            deleteBookImage();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update the current book with the new ASIN
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bUpdateASIN_Click(object sender, EventArgs e) {
            if (tbasinASIN.Text.Length != 10)  //  ASIN must be 10 characters long
            {
                MessageBox.Show("ASIN is invalid (length not 10 characters)", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbasinSKU.Text.Length == 0)  //  ASIN must be 10 characters long
            {
                MessageBox.Show("Invalid SKU (nothing selected from Database Panel)", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string updateString = "update tBooks set ISBN = '" + tbasinASIN.Text + "' , DateU = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE BookNbr = '" + tbasinSKU.Text + "'";
            FbCommand fbc = new FbCommand(updateString);
            fbc.Connection = bookConn;
            if (fbc.Connection.State == ConnectionState.Closed)
                fbc.Connection.Open();

            fbc.ExecuteNonQuery();

            if (dataBasePanel.SelectedIndices.Count == 0) {
                MessageBox.Show("Nothing has been selected for updating", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int lastSelection = dataBasePanel.SelectedIndices[0];  //  save last place (index) where we were

            commandString = "select BookNbr, Title, ISBN, Quantity, Locn, Price, Stat, InvoiceNbr from tBooks where Stat = 'For Sale' and ISBN = '' ";  //  create sql statement to refresh dataset
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


        ////----------------    if tab selected is not 19 (get asin) then use normal select string    -------------------------
        //private void tabTaskPanel_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (tabTaskPanel.SelectedIndex != cASIN && cbFreezeDBPanel.Checked == false && commandString.Contains("and ISBN = '' "))
        //    {
        //        createCommandString();
        //        fillDataBasePanel(commandString);
        //    }
        //}



        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    we have selected a book to be displayed
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
            if (tbsrchBookNbr.Text.Length > 0)
                genericSearch("BookNbr", tbsrchBookNbr.Text);
            else if (tbsrchISBN.Text.Length > 0)
                genericSearch("ISBN", tbsrchISBN.Text);
            else if (tbsrchAuthor.Text.Length > 0)
                genericSearch("Author", tbsrchAuthor.Text);
            else if (tbsrchTitle.Text.Length > 0)
                genericSearch("Title", tbsrchTitle.Text);
            else if (tbsrchKeywords.Text.Length > 0)
                genericSearch("Keywds", tbsrchKeywords.Text);
            else
                MessageBox.Show("You must indicate what you are searching for...", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    setup for a drill-down search
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void setupDrillDownSearch(object sender, EventArgs e) {
            if (cbWildCardSearch.Checked == true)  //  if we're doing a wildcard search, return
                return;

            if (tbsrchBookNbr.Text.Length > 0)
                drillDownSearch("BookNbr", tbsrchBookNbr.Text);
            else if (tbsrchISBN.Text.Length > 0)
                drillDownSearch("ISBN", tbsrchISBN.Text);
            else if (tbsrchAuthor.Text.Length > 0)
                drillDownSearch("Author", tbsrchAuthor.Text);
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
            tbsrchISBN.Clear();
            tbsrchAuthor.Clear();
            tbsrchBookNbr.Clear();
            tbsrchTitle.Clear();
        }


        ////--    handles the up or down key for database panel    ---------------------------------
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


        //private void rbSortAsc_CheckedChanged(object sender, EventArgs e)  //  for Dsc also...
        //{
        //    createCommandString();
        //    fillDataBasePanel(commandString);
        //}


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
            message.Body = emailData;

            SmtpClient client = new SmtpClient();
            client.Host = "mail.pragersoftware.com";
            client.Port = 25;
            client.Credentials = new NetworkCredential("support@pragersoftware.com", "Sp0Kane");
            object sendComplete = null; ;

            //string recipients = cbCopyMe.Checked ? string.Format("support@pragersoftware.com, {0}", tbTraceComments.Text) : "support@pragersoftware.com";
            //client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            client.SendAsync("support@pragersoftware.com", "support@pragersoftware.com", "Inventory Program Trace", emailData, sendComplete);

            if (MessageBox.Show("Would you like to see the data you're sending?", "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Cursor.Current = Cursors.WaitCursor;
                for (int i = 0; i < trace.Count; i++)
                    lbStatus.Items.Add(trace[i]);
                lbStatus.Refresh();
            }

            bSendTrace.Enabled = false;  //  disable it so we don't send twice
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    clone the book
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bClone_Click(object sender, EventArgs e) {

            tbBookNbr.Text = "";  //  clear the SKU and enable the Add button
            tbBookNbr.Enabled = true;

            bAddRecord.Enabled = true;
            bUpdateRecord.Enabled = false;
            bDeleteBook.Enabled = false;
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
                reply = result.Substring(1, result.IndexOf('<') - 1);

            if (reply.Length >= 3)  //  make sure we got a good reply
            {
                if (reply != workingVerNbr[0]) {
                    if (result.Contains("Critical")) {
                        newVersionAvailableToolStripMenuItem1.Text = "There is a CRITICAL update available for this program!";
                        newVersionAvailableToolStripMenuItem1.Visible = true;
                    }
                    else {
                        newVersionAvailableToolStripMenuItem1.Visible = true;

                    }
                }
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    has user changed the starting number?
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

                        commandString = "select BookNbr, Title, ISBN, Quantity,  Locn, Price, Stat, InvoiceNbr from tBooks ORDER BY BookNbr ASC ";
                        fillDataBasePanel(commandString);  //  fill the tBooks datagridview 
                        searchOnCatalog = false;
                        break;
                    }

                case "tsShowForSale": {
                        tsShowAll.Checked = false;
                        tsShowHold.Checked = false;
                        tsShowSold.Checked = false;
                        tsShowCatalog.Checked = false;
                        tsShowPending.Checked = false;

                        commandString = "select BookNbr, Title, ISBN, Quantity,  Locn, Price, Stat, InvoiceNbr from tBooks where Stat = 'For Sale' ORDER BY BookNbr ASC ";
                        fillDataBasePanel(commandString);  //  fill the tBooks datagridview 
                        searchOnCatalog = false;
                        break;
                    }

                case "tsShowHold": {
                        tsShowForSale.Checked = false;
                        tsShowAll.Checked = false;
                        tsShowSold.Checked = false;
                        tsShowCatalog.Checked = false;
                        tsShowPending.Checked = false;

                        commandString = "select BookNbr, Title, ISBN, Quantity, Locn, Price, Stat, InvoiceNbr from tBooks where Stat = 'Hold' ORDER BY BookNbr ASC ";
                        fillDataBasePanel(commandString);  //  fill the tBooks datagridview 
                        searchOnCatalog = false;
                        break;
                    }

                case "tsShowSold": {
                        tsShowForSale.Checked = false;
                        tsShowHold.Checked = false;
                        tsShowAll.Checked = false;
                        tsShowCatalog.Checked = false;
                        tsShowPending.Checked = false;

                        commandString = "select BookNbr, Title, ISBN, Quantity,  Locn, Price, Stat, InvoiceNbr from tBooks where Stat = 'Sold' ORDER BY BookNbr ASC ";
                        fillDataBasePanel(commandString);  //  fill the tBooks datagridview 
                        searchOnCatalog = false;
                        break;
                    }

                case "tsShowCatalog": {
                        tsShowForSale.Checked = false;
                        tsShowHold.Checked = false;
                        tsShowAll.Checked = false;
                        tsShowSold.Checked = false;
                        tsShowPending.Checked = false;

                        searchOnCatalog = true;
                        tabTaskPanel.SelectTab(cCatalogs);  //  go to Catalog tab and allow user to pick catalog
                        break;
                    }

                case "tsShowPending": {
                        tsShowForSale.Checked = false;
                        tsShowHold.Checked = false;
                        tsShowAll.Checked = false;
                        tsShowSold.Checked = false;
                        tsShowPending.Checked = true;

                        commandString = "select BookNbr, Title, ISBN, Quantity,  Locn, Price, Stat, InvoiceNbr from tBooks where Stat = 'Pending' ORDER BY BookNbr ASC ";
                        fillDataBasePanel(commandString);  //  fill the tBooks datagridview 
                        searchOnCatalog = false;
                        break;
                    }
                default:   //  default is Show All when nothing is checked...
                    tsShowAll.Checked = true;

                    commandString = "select BookNbr, Title, ISBN, Quantity, Locn, Price, Stat, InvoiceNbr from tBooks ORDER BY BookNbr ASC ";
                    fillDataBasePanel(commandString);  //  fill the tBooks datagridview 
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
            lBooksReturned.Text = "0 books found.";
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
                coCondition.Items.Add(coCondition.Text.ToString());
                coCondition.ResetText();
            }
            else if (e.KeyCode == Keys.Delete && coCondition.SelectedIndex > -1)
                coCondition.Items.RemoveAt(coCondition.SelectedIndex);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    updates the database with user's Amazon list of ASINs
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void aSINUpdateToolStripMenuItem_Click(object sender, EventArgs e) {

            asin asinUpdate = new asin();
            asinUpdate.doASINupdate(openFileDialog1, bookConn);

            //  refresh the listview
            createCommandString();  //  get sql statement to refresh dataset
            fillDataBasePanel(commandString);

            //  indicate the status
            backupNeeded = true;
            MessageBox.Show("ASIN update completed...", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    if all of a sudden the user checks "allow add/update w/o required fields, enable buttons
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void cbAllowAddUpdate_Click(object sender, EventArgs e) {
            bAddRecord.Enabled = true;
            bUpdateRecord.Enabled = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    display tab settings
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tabOptions_Enter(object sender, EventArgs e) {
            //  display current tab settings
            tbISBNSeq.Text = mtbISBN.TabIndex.ToString();
            tbQtySeq.Text = tbCopies.TabIndex.ToString();
            tbLocSeq.Text = tbLocn.TabIndex.ToString();
            tbSKUSeq.Text = tbBookNbr.TabIndex.ToString();
            tbCostSeq.Text = tbMyCost.TabIndex.ToString();
            tbPriceSeq.Text = tbListPrice.TabIndex.ToString();
            tbRepriceSeq.Text = cbDoNotReprice.TabIndex.ToString();
            tbTitleSeq.Text = tbTitle.TabIndex.ToString();
            tbAuthorSeq.Text = tbAuthor.TabIndex.ToString();
            tbIllusSeq.Text = tbIllus.TabIndex.ToString();
            tbAuthorSignSeq.Text = cbAuthorSigned.TabIndex.ToString();
            tbIllusSignedSeq.Text = cbIllusSigned.TabIndex.ToString();
            tbPubSeq.Text = tbPub.TabIndex.ToString();
            tbPlaceSeq.Text = tbPlace.TabIndex.ToString();
            tbYearSeq.Text = tbYear.TabIndex.ToString();
            tbDescSeq.Text = tbDesc.TabIndex.ToString();
            tbCannedSeq.Text = lbCannedText.TabIndex.ToString();
            tbBindingSeq.Text = coBinding.TabIndex.ToString();
            tbCondSeq.Text = coCondition.TabIndex.ToString();
            tbJacketSeq.Text = coJacket.TabIndex.ToString();
            tbEdSeq.Text = coEdition.TabIndex.ToString();
            tbPagesSeq.Text = tbPages.TabIndex.ToString();
            tbWeightSeq.Text = tbWeight.TabIndex.ToString();
            tbTypeSeq.Text = coType.TabIndex.ToString();
            tbSizeSeq.Text = coSize.TabIndex.ToString();
            tbPriSeq.Text = tbPriCatalog.TabIndex.ToString();
            tbSecSeq.Text = tbSecCatalog.TabIndex.ToString();
            tbKeySeq.Text = tbKeywords.TabIndex.ToString();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    set new tab settings
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tabOptions_Leave(object sender, EventArgs e) {
            //  set new tab settings
            mtbISBN.TabIndex = Convert.ToInt32(tbISBNSeq.Text);
            tbCopies.TabIndex = Convert.ToInt32(tbQtySeq.Text);
            tbLocn.TabIndex = Convert.ToInt32(tbLocSeq.Text);
            tbBookNbr.TabIndex = Convert.ToInt32(tbSKUSeq.Text);
            //tbBookDtlInvNbr.TabIndex = Convert.ToInt32(tbInvSeq.Text);
            //ddcbShipping.TabIndex = Convert.ToInt32(tbShipSeq.Text);
            tbMyCost.TabIndex = Convert.ToInt32(tbCostSeq.Text);
            tbListPrice.TabIndex = Convert.ToInt32(tbPriceSeq.Text);
            cbDoNotReprice.TabIndex = Convert.ToInt32(tbRepriceSeq.Text);
            tbTitle.TabIndex = Convert.ToInt32(tbTitleSeq.Text);
            tbAuthor.TabIndex = Convert.ToInt32(tbAuthorSeq.Text);
            tbIllus.TabIndex = Convert.ToInt32(tbIllusSeq.Text);
            cbAuthorSigned.TabIndex = Convert.ToInt32(tbAuthorSignSeq.Text);
            cbIllusSigned.TabIndex = Convert.ToInt32(tbIllusSignedSeq.Text);
            tbPub.TabIndex = Convert.ToInt32(tbPubSeq.Text);
            tbPlace.TabIndex = Convert.ToInt32(tbPlaceSeq.Text);
            tbYear.TabIndex = Convert.ToInt32(tbYearSeq.Text);
            tbDesc.TabIndex = Convert.ToInt32(tbDescSeq.Text);
            lbCannedText.TabIndex = Convert.ToInt32(tbCannedSeq.Text);
            coBinding.TabIndex = Convert.ToInt32(tbBindingSeq.Text);
            coCondition.TabIndex = Convert.ToInt32(tbCondSeq.Text);
            coJacket.TabIndex = Convert.ToInt32(tbJacketSeq.Text);
            coEdition.TabIndex = Convert.ToInt32(tbEdSeq.Text);
            tbPages.TabIndex = Convert.ToInt32(tbPagesSeq.Text);
            tbWeight.TabIndex = Convert.ToInt32(tbWeightSeq.Text);
            coType.TabIndex = Convert.ToInt32(tbTypeSeq.Text);
            coSize.TabIndex = Convert.ToInt32(tbSizeSeq.Text);
            tbPriCatalog.TabIndex = Convert.ToInt32(tbPriSeq.Text);
            tbSecCatalog.TabIndex = Convert.ToInt32(tbSecSeq.Text);
            tbKeywords.TabIndex = Convert.ToInt32(tbKeySeq.Text);

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    do sales report
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


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user is re-ordering the tabs
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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
                        cBookDetail = tabTaskPanel.TabPages.IndexOf(bookDetailTab);
                        cSearch = tabTaskPanel.TabPages.IndexOf(searchTab);
                        cTabMapping = tabTaskPanel.TabPages.IndexOf(mappingTab);
                        cImport = tabTaskPanel.TabPages.IndexOf(Import);
                        cWebPages = tabTaskPanel.TabPages.IndexOf(webSite);
                        cMassChanges = tabTaskPanel.TabPages.IndexOf(alterPricesTab);
                        cCatalogs = tabTaskPanel.TabPages.IndexOf(catalogTab);
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

            Cursor.Current = Cursors.WaitCursor;  //  set hourglass cursor

            if (!rbIRClipBoard.Checked && !rbIRFile.Checked && !rbIRPrint.Checked) {
                MessageBox.Show("You must choose a report output media", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            printInvReport(this, dataBasePanel, bookConn, exportPath, lbSortSequence);
        }

        //  actual printing done here
        string[] lines = null;
        private void printDocument3_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            char[] param = { '\n' };

            lines = richTextBox1.Text.Split(param);

            int i = 0;
            char[] trimParam = { '\r' };
            foreach (string s in lines) {
                lines[i++] = s.TrimEnd(trimParam);
            }
        }

        int linesPrinted = 0;
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
            Cursor.Current = Cursors.Default;

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


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    custom special updates done here
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bSUupdate_Click(object sender, EventArgs e) {
            DialogResult dlgResult = DialogResult.None;
            dlgResult = MessageBox.Show("Have you done a backup before you do this database update?", "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlgResult == DialogResult.No)  //  no, don't process it...
                return;

            doSpecialUpdate();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    validate user's email address to send trace
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tbTraceComments_TextChanged(object sender, EventArgs e) {
            if (tbTraceComments.Text.Contains("@") && tbTraceComments.Text.Contains("."))
                bSendTrace.Enabled = true;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user wants to work offline
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
        //--    what does the user want to see in the report?
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void invRepSelAll_Click(object sender, EventArgs e) {
            invReportSelectAll();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    convert from USD to ?
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void rbConvertUSD_CheckedChanged(object sender, EventArgs e) {

            if (rbGBPound.Checked == true || rbEUDollar.Checked == true || rbCNDollar.Checked == true) {
                MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();
                DialogResult dlgResult =
                dlg.Show(@"Software\Prager\BookInventoryManager\ConvertDollars",  //  registry entry
                "DontShowAgain",  //  registry value name
                DialogResult.OK,  //  default return value returned immediately if box is not shown
                "Don't show this again",  //  message for checkbox
                "WARNING! You have checked the Amazon conversion option - this will convert all prices in US Dollars to the currency of choice without regard to your " +
                "location during the export to Amazon ONLY!  Are you sure you want to do this?", "Prager Book Inventory Manager",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dlgResult == DialogResult.No) {
                    rbCNDollar.Checked = false;
                    rbEUDollar.Checked = false;
                    rbGBPound.Checked = false;
                }
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    copy the Amazon keys to clipboard
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bCopyDevKey_Click(object sender, EventArgs e) {
            Clipboard.SetText(tbDevKey.Text);
        }

        private void bCopyMktPlaceID_Click(object sender, EventArgs e) {
            Clipboard.SetText(tbMarketplaceID.Text);
        }

        private void bCopySellerID_Click(object sender, EventArgs e) {
            Clipboard.SetText(tbMerchantID.Text);
        }

        private void bCopyAccessKey_Click(object sender, EventArgs e) {
            Clipboard.SetText(tbAWSKey.Text);
        }

        private void bCopySecretKey_Click(object sender, EventArgs e) {
            Clipboard.SetText(tbAWSSecretKey.Text);
        }

        private void bValidateKeys_Click(object sender, EventArgs e) {
            validateAmazonKeys(tbAWSKey.Text, tbMerchantID.Text, tbMarketplaceID.Text, tbAWSSecretKey.Text);
        }



        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    remove shipping info from description
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void removeShipMsgFromDescriptionToolStripMenuItem_Click(object sender, EventArgs e) {
            removeWillNotShip();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    fix quantity column
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void initializeQuantityFieldToolStripMenuItem_Click(object sender, EventArgs e) {
            moveNbrOfCopies();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make Keys info visible
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void pbAWSKey_MouseHover(object sender, EventArgs e) {
            lAWSKeys.Visible = true;
        }
        private void pbAWSKey_MouseLeave(object sender, EventArgs e) {
            lAWSKeys.Visible = false;
        }
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
        //private void pbMerchantID_MouseHover(object sender, EventArgs e) {
        //    lMWSMerchantID.Visible = true;
        //}
        //private void pbMerchantID_MouseLeave(object sender, EventArgs e) {
        //    lMWSMerchantID.Visible = false;
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  go to Amazon's site to verify the upload
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bVerifyAZUploads_Click(object sender, EventArgs e) {

            //MessageBox.Show("Be sure to use your MWS keys, not your AWS keys in the Authentication section - the Amazon site is incorrect!",
            //    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            HtmlElement textArea = null;
            webBrowser1.Navigate("https://mws.amazonservices.com/scratchpad/index.html");

            //do {
            //    ;
            //}
            //while (webBrowser1.ReadyState != WebBrowserReadyState.Complete);

            //if(webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            //    textArea = webBrowser1.Document.All["merchantID"];
            //textArea.InnerText = "Rolf";

            //   webBrowser1.Document.All.GetElementsByName("merchantID")[0].SetAttribute("merchantID", "Rolf");
            tabTaskPanel.SelectTab(cWebPages);//  make Detail tab the default
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  display image if it exists as a URL
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bShowImage_Click(object sender, EventArgs e) {

            string validURL = @"^(ht|f)tp(s?)\:\/\/(([a-zA-Z0-9\-\._]+(\.[a-zA-Z0-9\-\._]+" +
                @")+)|localhost)(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?([\d\w\.\/\%\+" +
                @"\-\=\&amp;\?\:\\\&quot;\'\,\|\~\;]*)$";

            if (Regex.IsMatch(tbImageURL.Text, validURL)) {
                Cursor.Current = Cursors.WaitCursor;

                try {
                    System.Net.WebClient wc = new System.Net.WebClient(); //  need web client
                    byte[] imageInBytes = wc.DownloadData(new Uri(tbImageURL.Text)); //  byte array holds the data
                    System.IO.MemoryStream imageStream = new System.IO.MemoryStream(imageInBytes);
                    pbBookImage.Image = new System.Drawing.Bitmap(imageStream);
                }
                catch (Exception ex) {
                    MessageBox.Show("Error displying image: " + ex.Message, "Prager Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Cursor.Current = Cursors.Default;
            }
            else {
                MessageBox.Show("Invalid image URL", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pbBookImage.Image = null;
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  clear existing tab mapping for importing
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bClearExisting_Click(object sender, EventArgs e) {

            clearExistingImportMapping();
        }

        private void tbURL_MouseDown(object sender, MouseEventArgs e) {
            tbURL.Text = "";  //  clear comment
            tbURL.ForeColor = Color.Black;
        }

        private void bGo_Click(object sender, EventArgs e) {
            webBrowser1.Navigate(tbURL.Text);
            //            tabTaskPanel.SelectTab(cWebPages);//  make Detail tab the default

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    allow user to send trace data
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void fTrace(string str) {

            trace.Add(str);
        }


        ////------------------------------------------------------------------------------
        ////--  sort fields for Report
        //private void cbIRSort_CheckedChanged(object sender, EventArgs e) {

        //    if (chosenSortFields.Length > 0)
        //        chosenSortFields += ", ";

        //    string cbText = ((CheckBox)sender).Text;
        //    switch (cbText) {
        //        case "SKU":
        //            chosenSortFields += "BookNBr, ";
        //            break;
        //        case "Title":
        //            chosenSortFields += "Title, ";
        //            break;
        //        case "Author":
        //            chosenSortFields += "Author, ";
        //            break;
        //        case "ISBN/ASIN":
        //            chosenSortFields += "ISBN, ";
        //            break;
        //        case "Illustrator":
        //            chosenSortFields += "Illus, ";
        //            break;
        //        case "Location":
        //            chosenSortFields += "Locn, ";
        //            break;
        //        case "Price":
        //            chosenSortFields += "Price, ";
        //            break;
        //        case "Cost":
        //            chosenSortFields += "Cost, ";
        //            break;
        //        case "Publisher":
        //            chosenSortFields += "Pub, ";
        //            break;
        //        case "Pub Location":
        //            chosenSortFields += "PubPlace, ";
        //            break;
        //        case "Year Published":
        //            chosenSortFields += "PubYear, ";
        //            break;
        //        case "Keywords":
        //            chosenSortFields += "Keywds, ";
        //            break;
        //        case "Description":
        //            chosenSortFields += "Descr, ";
        //            break;
        //        case "Jacket":
        //            chosenSortFields += "Jaket, ";
        //            break;
        //        case "Binding":
        //            chosenSortFields += "Bndg, ";
        //            break;
        //        case "Book Condition":
        //            chosenSortFields += "Condn, ";
        //            break;
        //        case "Edition":
        //            chosenSortFields += "Ed, ";
        //            break;
        //        case "Signed":
        //            chosenSortFields += "Signed, ";
        //            break;
        //        case "Book Type":
        //            chosenSortFields += "BookType, ";
        //            break;
        //        case "Book Size":
        //            chosenSortFields += "BookSize, ";
        //            break;
        //        case "Date Added":
        //            chosenSortFields += "DateA, ";
        //            break;
        //        case "Date Updated":
        //            chosenSortFields += "DateU, ";
        //            break;
        //        case "Primary Catalog":
        //            chosenSortFields += "Cat, ";
        //            break;
        //        case "Notes":
        //            chosenSortFields += "Notes, ";
        //            break;
        //        case "Status":
        //            chosenSortFields += "Stat, ";
        //            break;
        //        case "Invoice Number":
        //            chosenSortFields += "InvoiceNbr, ";
        //            break;
        //        case "Secondary Catalog":
        //            chosenSortFields += "SubCategory, ";
        //            break;
        //        case "Do Not Reprice Flag":
        //            chosenSortFields += "DoNotReprice, ";
        //            break;
        //        case "Pages":
        //            chosenSortFields += "NbrOfPages, ";
        //            break;
        //        case "Book Weight":
        //            chosenSortFields += "BookWeight, ";
        //            break;
        //        case "Quantity":
        //            chosenSortFields += "Quantity, ";
        //            break;
        //        case "Shipping":
        //            chosenSortFields += "Shipping, ";
        //            break;
        //        default:
        //            break;
        //    }

        //    int indx = chosenSortFields.LastIndexOf(',');  //  remove the last comma
        //    if (indx != -1)
        //        chosenSortFields = chosenSortFields.Remove(indx);


        //}



        //----------------------------------------------------------------------------
        //--  remove duplicate entries from the User IDs 
        private void removeDuplicateUIDsToolStripMenuItem_Click(object sender, EventArgs e) {

            populateUIDs ui = new populateUIDs();
            ui.cleanDGVtable(UIDdataGridView);  //  clean DGV table

        }


        //----------------------------------------------------------------------
        //--  allows user to select one field to sort the Inventory report on
        private void lbSortSequence_SelectedIndexChanged(object sender, EventArgs e) {

            switch (lbSortSequence.Items[lbSortSequence.SelectedIndex].ToString()) {
                case "SKU":
                    chosenSortFields += "BookNBr, ";
                    break;
                case "Title":
                    chosenSortFields += "Title, ";
                    break;
                case "Author":
                    chosenSortFields += "Author, ";
                    break;
                case "ISBN/ASIN":
                    chosenSortFields += "ISBN, ";
                    break;
                case "Illustrator":
                    chosenSortFields += "Illus, ";
                    break;
                case "Location":
                    chosenSortFields += "Locn, ";
                    break;
                case "Price":
                    chosenSortFields += "Price, ";
                    break;
                case "Cost":
                    chosenSortFields += "Cost, ";
                    break;
                case "Publisher":
                    chosenSortFields += "Pub, ";
                    break;
                case "Pub Location":
                    chosenSortFields += "PubPlace, ";
                    break;
                case "Year Published":
                    chosenSortFields += "PubYear, ";
                    break;
                case "Keywords":
                    chosenSortFields += "Keywds, ";
                    break;
                case "Description":
                    chosenSortFields += "Descr, ";
                    break;
                case "Jacket":
                    chosenSortFields += "Jaket, ";
                    break;
                case "Binding":
                    chosenSortFields += "Bndg, ";
                    break;
                case "Book Condition":
                    chosenSortFields += "Condn, ";
                    break;
                case "Edition":
                    chosenSortFields += "Ed, ";
                    break;
                case "Signed":
                    chosenSortFields += "Signed, ";
                    break;
                case "Book Type":
                    chosenSortFields += "BookType, ";
                    break;
                case "Book Size":
                    chosenSortFields += "BookSize, ";
                    break;
                case "Date Added":
                    chosenSortFields += "DateA, ";
                    break;
                case "Date Updated":
                    chosenSortFields += "DateU, ";
                    break;
                case "Primary Catalog":
                    chosenSortFields += "Cat, ";
                    break;
                case "Notes":
                    chosenSortFields += "Notes, ";
                    break;
                case "Status":
                    chosenSortFields += "Stat, ";
                    break;
                case "Invoice Number":
                    chosenSortFields += "InvoiceNbr, ";
                    break;
                case "Secondary Catalog":
                    chosenSortFields += "SubCategory, ";
                    break;
                case "Do Not Reprice Flag":
                    chosenSortFields += "DoNotReprice, ";
                    break;
                case "Pages":
                    chosenSortFields += "NbrOfPages, ";
                    break;
                case "Book Weight":
                    chosenSortFields += "BookWeight, ";
                    break;
                case "Quantity":
                    chosenSortFields += "Quantity, ";
                    break;
                case "Shipping":
                    chosenSortFields += "Shipping, ";
                    break;
                default:
                    break;
            }
        }
        //    }
        //}


        //----------------------------------------------------------------------
        //--  cell value has changed in DGV
        private void UIDdataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {

            dataGridValueChanged(e);  //  restore mapping
            UIDorPasswordChanged = true;

        }

        //----------------------------------------------------------------------
        //--  bulk book loader startClick
        private void bBulkLoaderStart_Click(object sender, EventArgs e) {

            bblStart(dgvBulkLoaderDataEntry, lDone, cbBLAutomaticSKU);  //  start looking
        }

        private void bBulkLoaderClear_Click(object sender, EventArgs e) {

            dgvBulkLoaderDataEntry.ReadOnly = false;  //  mark dgv as read only now...
            lDone.Visible = false;

            //  now loop through the rows in the dgv
            foreach (DataGridViewRow r in dgvBulkLoaderDataEntry.Rows) {
                r.Cells[0].Value = null;
                r.Cells[1].Value = null;
            }
        }



        /*
         * Applications can use the SPI_SETLISTBOXSMOOTHSCROLLING parameter 
         * when calling the SystemParametersInfo function to enable or to disable smooth 
         * scrolling in list-view controls and in list box controls.
         * */


    }

}
//}