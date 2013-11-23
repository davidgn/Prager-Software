
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

namespace Prager_Book_Inventory
{

    partial class DisplayLicenseScreen : Form
    {
        const string networkingLicense = "L9JWdZrH8pdTxCRdMCpALg==";  //  key was all 0's; expires 01.01.2023
        
        public DisplayLicenseScreen() {

            InitializeComponent();

        }


        //------------------------------------------------------------------
        //--  purchase license click
        private void bPurchaseLicense_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://www.pragersoftware.com/purchase.php?GUID=" + mainForm.MACAddress);
        }


        //------------------------------------------------------------------
        //--    user clicked Purchase Later
        private void bPurchaseLater_Click(object sender, EventArgs e) {
            this.Close();
        }


        //------------------------------------------------------------------
        //--    close the window
        private void bClose_Click(object sender, EventArgs e) {
            this.Close();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    validate license key entered in license screen
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bValidateLicenseInfo_Click(object sender, EventArgs e) {

            if (tbLicenseInfo.Text.Length < 15) {
                MessageBox.Show("License key is invalid", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (tbLicenseInfo.Text.Length == 24) {  //  this is the new encrypted date
            //    if (tbLicenseInfo.Text == networkingLicense) {  //  see if this is a networking license
            //        if (mainForm.dbPath.IndexOf(':') == mainForm.dbPath.LastIndexOf(':')) {  //  is there more than 1 colon?
            //            MessageBox.Show("Your license is for the client machine on a network; correct Inventory.cfg file",
            //                "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //            return;
            //        }
            //        else {
            //            mainForm.networkedClient = true;
            //            string updateString = "UPDATE tOptions SET eDate = '" + networkingLicense + "' ROWS 1";
            //            FbCommand cmd1 = new FbCommand(updateString);
            //            cmd1.Connection = mainForm.bookConn;
            //            if (mainForm.bookConn.State == ConnectionState.Closed)
            //                mainForm.bookConn.Open();

            //            cmd1.ExecuteNonQuery();
            //            mainForm.expireDate = DateTime.Parse("Jan 1, 2023 12:00:00 PM");

            //            mainForm.freeTrialExpired = false;
            //            lUnlockMsg.Visible = true;
            //            bClose.Visible = true;
            //            return;
            //        }
            //    }

                encryptionRoutines er = new encryptionRoutines();
                DateTime dtd = DateTime.MinValue;  //  initializatiion

                //  see if licenseInfo.Text is a valid date...
                try {
                    dtd = DateTime.Parse(er.decryptString(tbLicenseInfo.Text, mainForm.MACAddress));
                }
                catch (Exception ex) {
                    if (ex.Message.Contains("not recognized as a valid DateTime")) {
                        try {
                            dtd = DateTime.Parse(er.decryptString(tbLicenseInfo.Text, mainForm.MACAddress));
                        }
                        catch {  //  check to see if this is a client machine in a network
                            MsgBoxCheck.MessageBox dlg0 = new MsgBoxCheck.MessageBox();
                            DialogResult dlgResult0 =
                            dlg0.Show(@"Software\Prager\BookInventoryManager\networkClient",  //  registry entry
                            "DontShowAgain",  //  registry value name
                            DialogResult.OK,  //  default return value returned immediately if box is not shown
                            "Don't show this again",  //  message for checkbox
                            "Is this a client machine on a network? (i.e. does the database reside on another machine?)",
                            "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (dlgResult0 == DialogResult.Yes)   //  yes, it's being networked
                                mainForm.networkedClient = true;
                            else {
                                mainForm.networkedClient = false;
                                MessageBox.Show("Error in License data\rPlease do a cut and paste for accuracy",
                                    "Prager Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

            ////  check to see if it was installed today; if so show message
            //if (mainForm.bookConn.State == ConnectionState.Closed)  //  (12.1.6)
            //    mainForm.bookConn.Open();
            //FbDataReader rdr = null;
            //FbCommand cmd = new FbCommand("select tInstallDate from tOptions", mainForm.bookConn);
            //rdr = cmd.ExecuteReader();
            //rdr.Read();  //  get the row
            //if (DateTime.Parse(rdr[0].ToString()) == DateTime.Today) {  //  was it installed today?
            //    MessageBox.Show("You must wait 24 hours from time of installation to enter the License key", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}

            //  validate the license key that was entered
            LicenseValidation lv = new LicenseValidation();
            lv.validateLicense(mainForm.bookConn, ref mainForm.encryptedDate, mainForm.networkedClient,
                ref mainForm.decryptedDate, ref mainForm.MACAddress);

            //  store encrypted date in tOptions table
            setEncryptedDate(tbLicenseInfo.Text);
            mainForm.freeTrialExpired = false;
            lUnlockMsg.Visible = true;
            bClose.Visible = true;

            MessageBox.Show("You need to restart the program to enable features that were disabled", "Prager Inventory Manager",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update encrypted date in tOptions table
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int setEncryptedDate(string encryptedDate) {

            string updateString = "";
            encryptionRoutines er = new encryptionRoutines();

            updateString = "UPDATE tOptions SET eDate = '" + encryptedDate + "' ROWS 1";
            FbCommand cmd = new FbCommand(updateString);
            cmd.Connection = mainForm.bookConn;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();

            cmd.ExecuteNonQuery();

            return 0;
        }

    }
}