
#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.Data.SqlClient;
//using System.Data.SqlTypes;
using Microsoft.Win32;
using System.Management;
using FirebirdSql.Data.FirebirdClient;

#endregion

namespace Media_Inventory_Manager
{
    //  GUID: 5a240079-5834-4e60-9b71-d11956f214a5
    //  license:  p9ghx26HVAKDuy5laRhzhw==


    partial class LicenseScreen : Form
    {
        public LicenseScreen() {

            InitializeComponent();
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user has clicked on Purchase License button
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bPurchaseLicense_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://www.pragersoftware.com/purchase.php?GUID=" + mainForm.storedGUID);
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    user has clicked on PUrchase later
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bPurchaseLater_Click(object sender, EventArgs e) {
            this.Close();
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    validate license data
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bValidateLicenseInfo_Click(object sender, EventArgs e) {

            if (tbLicenseInfo.Text.Length < 15) {
                MessageBox.Show("License key is invalid", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tbLicenseInfo.Text.Length == 24) {  //  this is the new encrypted date
                //FbConnection mediaConn = new FbConnection("User=prager;Password=books;Database=" + mainForm.dbPath);
                if (mainForm.mediaConn.State == ConnectionState.Closed)
                    mainForm.mediaConn.Open();

                FbDataReader rdr = null;
                FbCommand cmd = new FbCommand("select tInstallDate, GUID from tOptions", mainForm.mediaConn);

                rdr = cmd.ExecuteReader();
                rdr.Read();  //  get the row
                string debugString = rdr[1].ToString();

                encryptionRoutines er = new encryptionRoutines();
                DateTime dtd = DateTime.MinValue;  //  initializatiion

                //  see if it's a valid date...
                try {
                    dtd = DateTime.Parse(er.decryptString(tbLicenseInfo.Text, mainForm.storedGUID));
                }
                catch (Exception ex) {
                    if (ex.Message.Contains("not recognized as a valid DateTime")) {
                        try {
                            dtd = DateTime.Parse(er.decryptString(tbLicenseInfo.Text, mainForm.MACAddress));
                            Console.WriteLine("dtd: " + dtd);
                        }
                        catch {
                            MessageBox.Show("Error in License data\rPlease do a cut and paste for accuracy",
                                "Prager Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                if (DateTime.Parse(rdr[0].ToString()) == DateTime.Today) {  //  was it installed today?
                    MessageBox.Show("You must wait 24 hours from time of installation to enter new License key", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                setEncryptedDate(tbLicenseInfo.Text, 0);  //  store encrypted date in tOptions table
                mainForm.freeTrialExpired = false;

                lUnlockMsg.Visible = true;
                bClose.Visible = true;

                MessageBox.Show("You need to restart the program to enable features that were disabled", "Prager Inventory Manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            //  allow one 30-day extension  <----------------------------- TODO
            //if (tbLicenseInfo.Text.Contains("WJ8B-TFE4-H25R-CGIB")) {  //  extension has been granted
            //      look to see if it has already been done (can do only once)
            //    FbConnection mediaConn = new FbConnection("User=prager;Password=books;Database=" + mainForm.dbPath);
            //    if (mainForm.mediaConn.State == ConnectionState.Closed)
            //        mainForm.mediaConn.Open();

            //    FbDataReader rdr = null;
            //    FbCommand cmd = new FbCommand("select tInstallDate, GUID from tOptions", mainForm.mediaConn);

            //    rdr = cmd.ExecuteReader();
            //    rdr.Read();  //  get the row
            //    string rdr0 = rdr[0].ToString();  //  install date
            //    string rdr1 = rdr[1].ToString();  //  unlock code

            //    if (!rdr.IsDBNull(0) && rdr[1].ToString().Contains("WJ8B-TFE4-H25R-CGIB"))  //  is it there?
            //    {
            //        MessageBox.Show("You can only have one 30-day extension", "Prager Inventory Prgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        rdr.Close();
            //        return;
            //    }
            //    rdr.Close();

            //    setEncryptedDate(tbLicenseInfo.Text, 1);
            //    mainForm.freeTrialExpired = false;

            //    lUnlockMsg.Visible = true;
            //    bClose.Visible = true;

            //    MessageBox.Show("You need to restart the program to enable features that were disabled", "Prager Media Inventory Manager",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    set encrypted date in tOptions table
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int setEncryptedDate(string encryptedDate, int retType)  //  0 = normal, 1 = extension
        {
            string updateString = "";
            encryptionRoutines er = new encryptionRoutines();
            string debugDate = er.decryptString(encryptedDate, mainForm.storedGUID);  //  what if MAC was used?<--------  TODO
            if (debugDate == "Bad Data") {  //  try using MAC address
                debugDate = er.decryptString(encryptedDate, mainForm.MACAddress);
                if (debugDate == "Bad Data")  {
                    MessageBox.Show("Invalid date; contact support and start a 'new issue'", "Prager Media Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -2;
                }
            }
            //TimeSpan thirtyDays = TimeSpan.FromDays(30);
            IFormatProvider localCulture = System.Globalization.CultureInfo.CurrentCulture;  //  get current culture

            if (retType == 0) {
                updateString = "UPDATE tOptions SET eDate = '" + encryptedDate + "' ROWS 1";
                //sendMachineInfo(unlockCode);
            }
            else {
                //  set installation date to today
                AtomicTime at = new AtomicTime();
                DateTime currentDate = DateTime.Parse(at.getAtomicTime(), localCulture);

                //DateTime expireDate = currentDate.Add(thirtyDays);  //  use atomic date and time
                updateString = "UPDATE tOptions SET eDate = '" + encryptedDate + "', tInstallDate = '" + DateTime.Today.ToShortDateString() + "' ROWS 1";
            }

            FbCommand cmd = new FbCommand(updateString);
            cmd.Connection = mainForm.mediaConn;
            if (mainForm.mediaConn.State == ConnectionState.Closed)
                mainForm.mediaConn.Open();

            cmd.ExecuteNonQuery();
            mainForm.expireDate = DateTime.Parse(debugDate); 

            return 0;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    close the window
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}