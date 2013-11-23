#region Using directives

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace ListingSyncronizer
{
    partial class mainForm : Form
    {
        static string osServicePack = "";
        static string osName = "";
        static string MACAddress = String.Empty;
        static string amountOfMemory = String.Empty;
        string databasePath = "";
        static bool systemCrash = false;

        static IFormatProvider localCulture = System.Globalization.CultureInfo.CurrentCulture;  //  get current culture
        public static DateTime compileDate = DateTime.Parse("25 Jan 2013 7:13:00 AM", localCulture);

        public static string versionNumber = "5.11.4 " + compileDate.ToShortDateString();
        //public static string versionNumber = "4.3.0 BETA " + compileDate.ToShortDateString();
        //  registry key:  DERM-XNMG-NIPI-981

        /*
         * CHANGES:
         * 
         * ---------------  version 5.11.x  -----------------
         * 
         -  fixed:  path to Inventory.cfg file (5.11.2)
         -  fixed:  verifyRegCode was looking in wrong registry  (5.11.1)
         * 
         * 
         * -------    version 5.00    -----------
         -  changed:  using Inventory program's configuration file to find database  (v5.0.0)
         -  fixed:  check for registration information (5.0.1)
         -  fixed:  SendAsync -> Send (5.11.0)
         * 
         * TODO:
         * fix check of installtion date (license.cs, 134)
        
         * 
         * * */


        public mainForm() {
            InitializeComponent();

            this.Text = "Prager Listing Synchronizer Program    Version " + versionNumber;

            checkMemoryAndOS();  //  just in case we need it...

            License lic = new License();
            int rc = lic.checkForLicense();  //  check for user registration
            if (rc == -1)
                bStart.Enabled = false;

            lSKULS.Visible = false;
            lbSKU.Visible = false;
            lStatusLS.Visible = false;
            lbStatus.Visible = false;

        }

        public string sFileName;


        //-----------------------------------------------------------------------------------------------
        private void bOpenDialog_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                sFileName = openFileDialog1.FileName;
                tbFilename.Text = sFileName;
            }
        }


        //------------------------------------------------------------------------------------------------
        private void bStart_Click(object sender, EventArgs e) {

            if (SKUIndex == -1 || statusIndex == -1)  //  if -1, we have not determined column descriptions
            {
                //if (lbSKU.SelectedIndex == -1 || lbStatus.SelectedIndex == -1)
                //{
                //    MessageBox.Show("You have not chosen the column names for either SKU or Book Status or both", "Prager, Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                SKUIndex = rbAmazon.Checked == true? 3: lbSKU.SelectedIndex;
                statusIndex = lbStatus.SelectedIndex;  //  quantity = 3
            }

            listBox1.Items.Clear();
            listBox2.Items.Clear();

            Cursor.Current = Cursors.WaitCursor;

            int rc = 0;

            readConfigFile();  //  get database path from Inventory.cfg file

            rc = createInventoryArray();  //  create an array of SKU and Status for every book in the inventory
            rc = formatVenueFile(tbFilename.Text);  //  take listing file and format it

            if (rc == 0)
                compareFiles();  //  compare files and list differences

            Cursor.Current = Cursors.Default;
        }


        //------------------------------------------------------------------------------------------
        private void bExit_Click(object sender, EventArgs e) {
            this.Close();
        }


        //-----------------------------------------------------------------------------------------
        private void bYesGo_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://www.pragersoftware.com");
        }


        //-----------------------------------------------------------------------
        private void rbTabLS_CheckedChanged(object sender, EventArgs e) {
            if (rbTabLS.Checked == true || rbCSVLS.Checked == true) {
                lSKULS.Visible = true;
                lbSKU.Visible = true;
                lStatusLS.Visible = true;
                lbStatus.Visible = true;

                StreamReader sr = null;
                string[] tmp = null;

                try {
                    if (File.Exists(sFileName))
                        sr = new System.IO.StreamReader(sFileName);  //  create stream reader object
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Prager Listing Synchronizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //else {
                //    MessageBox.Show("The filename is either missing or invalid", "Prager, Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                inputRecord = sr.ReadLine();  //  read first record in the file
                if (inputRecord != null && SKUIndex == -1) {
                    if (sFileName.Contains(".txt"))
                        tmp = inputRecord.Split('\t');  // split into parts
                    else if (sFileName.Contains(".csv"))
                        tmp = inputRecord.Split(',');  // split into parts

                    for (int x = 0; x < tmp.Length; x++) {
                        lbSKU.Items.Add(tmp[x]);
                        lbStatus.Items.Add(tmp[x]);
                    }

                    sr.Close();
                    sr.Dispose();
                }
            }
            else {
                lSKULS.Visible = false;
                lbSKU.Visible = false;
                lStatusLS.Visible = false;
                lbStatus.Visible = false;
            }
        }


        //-------------------------------     try to match the selected item in the other listbox    ------------------------------------
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            string[] x = listBox1.SelectedItem.ToString().Split('\t');  //  get the selected item
            string[] lb2Items;
            for (int i = 0; i < listBox2.Items.Count; i++)  //  now look for a match
            {
                //string debug = listBox2.Items[i].ToString();
                lb2Items = listBox2.Items[i].ToString().Split('\t');
                if (x[0] == lb2Items[0]) {
                    listBox2.SelectedIndex = i;
                    return;
                }
            }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) {
            string[] x = listBox2.SelectedItem.ToString().Split('\t');  //  get the selected item
            string[] lb1Items;
            for (int i = 0; i < listBox1.Items.Count; i++)  //  now look for a match
            {
                //string debug = listBox1.Items[i].ToString();
                lb1Items = listBox1.Items[i].ToString().Split('\t');
                if (x[0] == lb1Items[0]) {
                    listBox1.SelectedIndex = i;
                    return;
                }
            }
        }


        //-------------------------------------------------------------    display the license window    ------------------------------------
        private void registerToolStripMenuItem_Click(object sender, EventArgs e) {
            License regScreen = new License();    //  display the form
            regScreen.tbLicenseMsg.Visible = true;
            regScreen.Show();
            regScreen.TopMost = true;
        }


        //-------------------------------------------------------------------    handles all thread exceptions    --------------------------------------------------------
        internal static void Form1_UIThreadException(object sender, ThreadExceptionEventArgs t) {
            Cursor.Current = Cursors.WaitCursor;
            ShowThreadExceptionDialog("Prager Listing Synchronizer", t.Exception);
        }


        //---------------------------------------------------------------------------------------------------------
        // NOTE: This exception cannot be kept from terminating the application - it can only log the event, and inform the user about it. 
        internal static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            Cursor.Current = Cursors.WaitCursor;

            Exception ex = (Exception)e.ExceptionObject;

            StringBuilder traceData = new StringBuilder(256);
            for (int i = 0; i < trace.Count; i++)
                traceData.Append(trace[i] + "\n");

            StackTrace st = new StackTrace(new StackFrame(true));
            StackFrame sf = st.GetFrame(0);

            string emailData = "002-" + DateTime.Now + "\n\rVersion: " + versionNumber + "\n\rOS: " + osName + " (SP: " + osServicePack + ")" + " MAC: " + MACAddress +
                "  Memory: " + amountOfMemory + " Mb   Culture Info: " + localCulture.ToString() + "\n\rError Message: " + ex.Message +
                "\n\rMethod: " + Convert.ToString(sf.GetMethod()) + "    Line number: " + Convert.ToString(sf.GetFileLineNumber()) +
                "\n\r StackTrace: " + ex.StackTrace;

            MailMessage message = new MailMessage();
            message.From = new MailAddress("support@pragersoftware.com");
            message.To.Add(new MailAddress("support@pragersoftware.com"));
            message.Subject = "Exception in Listing Synchronizer";
            message.Body = emailData;

            SmtpClient client = new SmtpClient();
            client.Host = "mail.pragersoftware.com";
            client.Port = 25;
            client.Credentials = new NetworkCredential("support@pragersoftware.com", "Sp0Kane");

            //object sendComplete = null; ;
            //client.SendAsync("support@pragersoftware.com", "support@pragersoftware.com",
            //    "Listing Synchronizer Trace", emailData, sendComplete);
            client.Send("support@pragersoftware.com", "support@pragersoftware.com",
                "Exception in Listing Synchronizer", emailData);

            Cursor.Current = Cursors.Default;
            systemCrash = true;

            Application.Exit();
        }


        // --------------------------------------------------------------    Creates the error message and displays it.    --------------------------------
        private static void ShowThreadExceptionDialog(string title, Exception ex) {
            //  send email to support@pragersoftware.com using SMTP
            StringBuilder traceData = new StringBuilder(256);
            for (int i = 0; i < trace.Count; i++)
                traceData.Append(trace[i] + "\n");

            StackTrace st = new StackTrace(new StackFrame(true));
            StackFrame sf = st.GetFrame(0);

            string emailData = "003-" + DateTime.Now + "\n\rVersion: " + versionNumber + "\n\rOS: " + osName + " (SP: " + osServicePack + ")" + " MAC: " + MACAddress +
                "  Memory: " + amountOfMemory + " Mb   Culture Info: " + localCulture.ToString() + "\n\rError Message: " + ex.Message +
                "\n\rMethod: " + Convert.ToString(sf.GetMethod()) + "Line number: " + Convert.ToString(sf.GetFileLineNumber()) +
                "\n\r StackTrace: " + ex.StackTrace;

            MailMessage message = new MailMessage();
            message.From = new MailAddress("support@pragersoftware.com");
            message.To.Add(new MailAddress("support@pragersoftware.com"));
            message.Subject = "Exception in Listing Synchronizer"; message.Body = emailData;

            SmtpClient client = new SmtpClient();
            client.Host = "mail.pragersoftware.com";
            client.Port = 25;
            client.Credentials = new NetworkCredential("support@pragersoftware.com", "Sp0Kane");

            //object sendComplete = null; ;
            //client.SendAsync("support@pragersoftware.com", "support@pragersoftware.com",
            //    "Listing Synchronizer Trace", emailData, sendComplete);
            client.Send("support@pragersoftware.com", "support@pragersoftware.com",
                "Exception in Listing Synchronizer", emailData);


            systemCrash = true;

            Application.Exit();
        }

        //------------------------------    test thrown exception    -----------------------|
        private void button1_Click(object sender, EventArgs e) {
            //throw new System.ArgumentException("test throw");

            object foo = null;
            int x = int.Parse(foo.ToString());



        }

    }
}