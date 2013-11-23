#region Using directives

using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using System.Collections;

#endregion

namespace Prager_Pricing_Program
{

    partial class formISBNLookup : Form
    {

        static public string programVersion = "12.0.0";  //  good for 12 months from compileDate (BETA only good for 30 days)
        //static public string programVersion = "5.2.5 BETA"; 
        //  registration code:  VVAI-RYBO-GRXT-984

        public static IFormatProvider localCulture = CultureInfo.CurrentCulture;  //  get current culture
        public static DateTime compileDate = DateTime.Parse("16 Feb 2012 11:24:00 AM", localCulture);
        static string osServicePack = "";
        static string osName = "";
        public static string version = "";
        public static bool systemCrash = false;
        static string MACAddress = String.Empty;
        static string amountOfMemory = String.Empty;
        static public ArrayList trace = new ArrayList();

        
        /*
         *   Changes:
         *   
         -  added:  restricted list
         -  changed:  removed option to check for updates
         -  changed:  removed expiration date
         -  fixed:  prices not being returned correctly (5.3.6)
         -  fixed:  added List Price and removed dollar signs (5.3.7)
         -  added:  book type and condition (5.4.0)
         -  fixed:  registration check (5.4.1)
         -  changed:  check for updates when program starts (5.4.1)
         -  changed:  always check for program update when program starts (5.4.1)
         -  changed:  general cleanup  (5.4.1)
         -  fixed:  prices not being returned correctly  (5.5.0)
         -  fixed:  divide by zero when no prices were returned (5.5.1)
         -  fixed:  invalid ISBN message not being displayed (5.5.1)
         -  added: exception trap
         -  changed: SendAsync to Send (5.11.0)
         -  fixed:  verifyRegistration was looking in wrong Registry (5.11.1)
         -  changed:  pricing site  (12.0.0)
         * */


        //-------------------------------------------------------------------------------------------
        public formISBNLookup()
        {

            InitializeComponent();
            this.Text = "Prager Pricing Program Version " + programVersion;

            checkMemoryAndOS();  //  just in case...

            bool showIt = false;
            backgroundWorker1.RunWorkerAsync(showIt);  //  see if there is a new version (in the background)

            License lic = new License();
            int rc = 0;
            if (!programVersion.Contains("BETA"))
                rc = lic.checkForLicense();  //  check for user registration
            if (rc == -1)
                bSearch.Enabled = false;

            this.Text = "Prager Pricing Program    v. " + programVersion;

            //RegistryKey OurKey = Registry.Users;
            //OurKey = OurKey.OpenSubKey(".DEFAULT", true); // Set it to HKEY_USERS\.DEFUALT
            //OurKey = OurKey.OpenSubKey(@"Prager\MultiISBN", true);

            //string OptionCheckForUpdates = (string)OurKey.GetValue("Check For Updates");
            //if (OptionCheckForUpdates == "1")
            //    automaticallyCheckForUpdatesToolStripMenuItem.Checked = true;
            //else
            //    automaticallyCheckForUpdatesToolStripMenuItem.Checked = false;


            /*
0345377443
0935097406
0345377433
0671871188
9780596159764
            */
        }


        //-----------------------------------------------------------------------------------------------
        private void bSearch_Click(object sender, EventArgs e)
        {
            bSearch.Enabled = false;  //  don't allow double clicks
            Cursor.Current = Cursors.WaitCursor;  //  make it wait...

            string[] lines = tbISBNs.Lines;
            if (tbISBNs.Lines.Length == 0)
            {
                MessageBox.Show("You don't have any ISBN's entered", "Prager, Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bSearch.Enabled = true;
                return;
            }

            ListView[] lvArray = { listView1, listView2, listView3, listView4, listView5, listView6,
                    listView7, listView8, listView9, listView10, listView11, listView12, listView13,
                    listView14, listView15, listView16, listView17, listView18, listView19, listView20 };

            if (lvArray[0].Columns.Count == 0)
                for (int i = 0; i < 20; i++)
                {
                    lvArray[i].View = View.Details;  // Set the view to show details.
                    lvArray[i].LabelEdit = false;  // Allow the user to edit item text.
                    lvArray[i].GridLines = true;
                    lvArray[i].AllowColumnReorder = true;  // Allow the user to rearrange columns.
                    lvArray[i].FullRowSelect = true;  // Select the item and subitems when selection is made.
                    lvArray[i].Columns.Add("Venue", 145, HorizontalAlignment.Left);
                    //lvArray[i].Columns.Add("Type", 45, HorizontalAlignment.Center);
                    lvArray[i].Columns.Add("Cond", 85, HorizontalAlignment.Left);
                    lvArray[i].Columns.Add("Price", 50, HorizontalAlignment.Right);
                    lvArray[i].Items.Clear();
                }

            for (int i = 0; i < 20; i++)
            {
                lvArray[i].Items.Clear();
                lvArray[i].Refresh();
            }


            FindBookPricesDotCom fbp = new FindBookPricesDotCom();
   
            int listViewPointer = 0;

            foreach (string line in lines)  //  for each ISBN...
            {
                if (line.Length == 0)
                    continue;
                
                line.Replace("-", "");

                if (!fbp.getBookPrices(line.Trim()))  //  parameter -> isbn; returns priceAndVenue array [price, bookseller]
                {

                    ListViewItem lvi = new ListViewItem("ISBN: " + line);
                    lvi.BackColor = Color.LightSteelBlue;
                    lvArray[listViewPointer].Items.Add(lvi);  // Add the list items to the ListView
                    
                    ListViewItem lvi1 = new ListViewItem("No prices found");
                    lvi1.BackColor = Color.LightSalmon;
                    lvArray[listViewPointer].Items.Add(lvi1);

                    lvArray[listViewPointer].Refresh();
                    listViewPointer++;
                    continue;
                }

                lvArray[listViewPointer].Items.Clear();  // Clear the ListView control

                //  find out how many filled elements are in the array
                int lbCount = 0;
                for (int i = 0; i < fbp.priceAndVenue.GetLength(0); i++)
                {
                    if (fbp.priceAndVenue[i, 1] != null && fbp.priceAndVenue[i, 1].Length != 0)
                        lbCount = i;
                }

                //Console.Write("\n-->number of elements: " + lbCount);

                //  now go through the returned prices and place them in a listview
                decimal avgPrice = 0.0M;
                for (int i = 0; i < lbCount + 1; i++)
                {
                    if (i == 0)  //  first line
                    {
                        ListViewItem lvi = new ListViewItem("ISBN: " + line);
                        lvi.BackColor = Color.LightSteelBlue;
                        lvArray[listViewPointer].Items.Add(lvi);  // Add the list items to the ListView
                    }

                    ListViewItem lvi1 = new ListViewItem(fbp.priceAndVenue[i, 1]);
                    lvi1.SubItems.Add(fbp.priceAndVenue[i, 2]);  //  add condition
                    lvi1.SubItems.Add(fbp.priceAndVenue[i, 0]);  //  and price
                    if (i < 2)  //  list price
                        lvi1.BackColor = Color.LightYellow;
                  if (fbp.priceAndVenue[i, 1].Contains("Invalid 10 digit ISBN"))
                    lvi1.BackColor = Color.LightCoral;
                  lvArray[listViewPointer].Tag = "Title";


                    lvArray[listViewPointer].Items.Add(lvi1);  // Add the list items to the ListView
                }

                if(lbCount > 1)
                avgPrice = fbp.accumulatedPrice / (lbCount-1);
                avgPrice = Math.Round(avgPrice, 2);
                ListViewItem lvi2 = new ListViewItem("Average Price (USD)");
                lvi2.BackColor = Color.LightYellow;
                lvi2.SubItems.Add(" ");
                lvi2.SubItems.Add(avgPrice.ToString());
                lvArray[listViewPointer].Items.Add(lvi2);  // add the item to 3rd column
                lvArray[listViewPointer].Refresh();
                listViewPointer++;
            }

            Cursor.Current = Cursors.Default;  //  reset the cursor
            bSearch.Enabled = true;  //  reset it...

        }


        //-------------------------------------------------------------------------------------------------
        private static void errorISBNMissing()
        {
            MessageBox.Show("ISBN missing", "Prager Pricing Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }


        //-------------------------------------------------------------------------------------------------
        private void bClear_Click(object sender, EventArgs e)
        {
            tbISBNs.Clear();
        }



        //---------------------------------------------------------------------------------------------
        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //-----------------------------------------------------------------------------------------
        private void enterUnlockCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            License lic = new License();
            lic.Show();
            lic.TopMost = true;
        }


        //-----------------------------------------------------------------------------------------
        private void displayPurchaseLicense_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.pragersoftware.com/pricing.htm");
        }


        ////-------------------------------------------------------------------------------------------
        //private void checkfornewversionToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Cursor.Current = Cursors.WaitCursor;

        //    checkForUpdates();

        //    Cursor.Current = Cursors.Default;
        //}


        //----------------------------------------------------------------------------------------
        private void formISBNLookup_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (saveOptionsToolStripMenuItem.Checked == true)
            //{
            //    RegistryKey OurKey = Registry.CurrentUser;
            //    OurKey = OurKey.OpenSubKey("Software", RegistryKeyPermissionCheck.ReadWriteSubTree);
            //    if (OurKey.OpenSubKey(@"Prager\MultiISBN", true) == null)

            //        if (automaticallyCheckForUpdatesToolStripMenuItem.Checked == true)
            //        OurKey.SetValue("Check for Updates", "1");
            //    else
            //        OurKey.SetValue("Check for Updates", "0");
            //}

            //if (automaticallyCheckForUpdatesToolStripMenuItem.Checked == true)
                //checkForUpdates();

        }


        //--------------------------------------------------------------------------------------
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutScreen aboutScreen = new AboutScreen();
            aboutScreen.Show();
        }


        //--------------------------------------------------------------------------------------
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            License regScreen = new License();    //  display the form
            regScreen.Show();
            regScreen.TopMost = true;
        }


        //------------------------------    background worker stuff    -------------------------------------------------------
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = false;  //  set so to avoid null error
            string replyFromHost = DownloadVersionInfo();

            int dataLength = replyFromHost.Length - 4;
            string debugInfo = replyFromHost.Substring(1, dataLength + 1);
            if (programVersion != replyFromHost.Substring(1, dataLength + 1))
                e.Result = true;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            bool showIt = (bool)e.Result;
            if (showIt)
                newVersionAvailableToolStripMenuItem.Visible = true;
        }

        
        //-------------------------------------------------------------------    handles all thread exceptions    --------------------------------------------------------
        public static void Form1_UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            Cursor.Current = Cursors.WaitCursor;

            //DialogResult result = DialogResult.Cancel;
            //try
            //{
                //string x = t.Exception.Message.ToString();
                ShowThreadExceptionDialog("Prager Pricing Program", t.Exception);
            //}
            //catch (Exception ex)
            //{
            //    try
            //    {
            //        StringBuilder traceData = new StringBuilder(256);
            //        for (int i = 0; i < trace.Count; i++)
            //            traceData.Append(trace[i] + "\n");

            //        StackTrace st = new StackTrace(new StackFrame(true));
            //        StackFrame sf = st.GetFrame(0);

            //        string emailData = "001-" + DateTime.Now + "\n\rVersion: " + versionNumber + "\n\rOS: " + osName + " (SP: " + osServicePack + ")" + " MAC: " + MACAddress +
            //            "  Memory: " + amountOfMemory + " Mb   Culture Info: " + localCulture.ToString() + "\n\rError Message: " +
            //            "\n\rMethod: " + Convert.ToString(sf.GetMethod()) + "    Line number: " + Convert.ToString(sf.GetFileLineNumber()) +
            //            ex.Message + "\n\r StackTrace: " + ex.StackTrace + "\n\rTrace: " + traceData;

            //        MailMessage message = new MailMessage();
            //        message.From = new MailAddress("support@pragersoftware.com");
            //        message.To.Add(new MailAddress("support@pragersoftware.com"));
            //        message.Subject = "Exception in Pricing Program";
            //        message.Body = emailData;

            //SmtpClient client = new SmtpClient();
            //client.Host = "mail.pragersoftware.com";
            //client.Port = 25;
            //client.Credentials = new NetworkCredential("support@pragersoftware.com", "Sp0Kane");

            //object sendComplete = null; ;
            //client.SendAsync("support@pragersoftware.com", "support@pragersoftware.com",
            //    "Pricing Program Trace", emailData, sendComplete);

            //    }
            //    catch (Exception ex1)
            //    {
            //        string xx = ex1.Message;
            //    }
            //    finally
            //    {
            //        systemCrash = true;
            //        Application.Exit();
            //    }
            //}

            //Application.Exit();
        }


        //---------------------------------------------------------------------------------------------------------
        // NOTE: This exception cannot be kept from terminating the application - it can only log the event, and inform the user about it. 
        internal static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Exception ex = (Exception)e.ExceptionObject;

            StringBuilder traceData = new StringBuilder(256);
            for (int i = 0; i < trace.Count; i++)
                traceData.Append(trace[i] + "\n");

            StackTrace st = new StackTrace(new StackFrame(true));
            StackFrame sf = st.GetFrame(0);

            string emailData = "002-" + DateTime.Now + "\n\rVersion: " + programVersion + "\n\rOS: " + osName + " (SP: " + osServicePack + ")" + " MAC: " + MACAddress +
                "  Memory: " + amountOfMemory + " Mb   Culture Info: " + localCulture.ToString() + "\n\rError Message: " + ex.Message +
                "\n\rMethod: " + Convert.ToString(sf.GetMethod()) + "    Line number: " + Convert.ToString(sf.GetFileLineNumber()) +
                "\n\r StackTrace: " + ex.StackTrace + "\n\rTrace: " + traceData;

            MailMessage message = new MailMessage();
            message.From = new MailAddress("support@pragersoftware.com");
            message.To.Add(new MailAddress("support@pragersoftware.com"));
            message.Subject = "Exception in Pricing Program";
            message.Body = emailData;

            SmtpClient client = new SmtpClient();
            client.Host = "mail.pragersoftware.com";
            client.Port = 25;
            client.Credentials = new NetworkCredential("support@pragersoftware.com", "Sp0Kane");

            //object sendComplete = null; ;
            client.Send("support@pragersoftware.com", "support@pragersoftware.com",
                "Exception in Pricing Program", emailData);


            Cursor.Current = Cursors.Default;
            systemCrash = true;

            Application.Exit();
        }


        // --------------------------------------------------------------    Creates the error message and displays it.    --------------------------------
        private static void ShowThreadExceptionDialog(string title, Exception ex)
        {
            Cursor.Current = Cursors.WaitCursor;

            //  send email to support@pragersoftware.com using SMTP
            StringBuilder traceData = new StringBuilder(256);
            for (int i = 0; i < trace.Count; i++)
                traceData.Append(trace[i] + "\n");

            StackTrace st = new StackTrace(new StackFrame(true));
            StackFrame sf = st.GetFrame(0);

            string emailData = "003-" + DateTime.Now + "\n\rVersion: " + programVersion + "\n\rOS: " + osName + " (SP: " + osServicePack + ")" + " MAC: " + MACAddress +
                "  Memory: " + amountOfMemory + " Mb   Culture Info: " + localCulture.ToString() + "\n\rError Message: " + ex.Message +
                "\n\rMethod: " + Convert.ToString(sf.GetMethod()) + "Line number: " + Convert.ToString(sf.GetFileLineNumber()) +
                "\n\r StackTrace: " + ex.StackTrace + "\n\rTrace: " + traceData;


            MailMessage message = new MailMessage();
            message.From = new MailAddress("support@pragersoftware.com");
            message.To.Add(new MailAddress("support@pragersoftware.com"));
            message.Subject = "Exception in Pricing Program";
            message.Body = emailData;

            SmtpClient client = new SmtpClient();
            client.Host = "mail.pragersoftware.com";
            client.Port = 25;
            client.Credentials = new NetworkCredential("support@pragersoftware.com", "Sp0Kane");

            //object sendComplete = null;
            //client.SendAsync("support@pragersoftware.com", "support@pragersoftware.com",
            //    "Pricing Program Trace", emailData, sendComplete);
            client.Send("support@pragersoftware.com", "support@pragersoftware.com",
            "Exception in Pricing Program", emailData);


            Cursor.Current = Cursors.Default;
            systemCrash = true;

            Application.Exit();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            throw new System.ArgumentException("test throw");
        }




    }


    }
//}