#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
#endregion

namespace Prager_Book_Inventory
{
    partial class aboutScreen : Form
    {

        //-------------------------------------------------------------------------------------------------
        public aboutScreen() {

            InitializeComponent();

            //  fill in data...
            tbVersion.Text = mainForm.versionNumber;

            //  if not networking AND not on my testing machine...
            if (!mainForm.networkedClient && !mainForm.MACAddress.Contains("00044B03C59E")) {
                tbExpireDate.Text = mainForm.decryptedDate.ToString();  //  get data from storage
                tbGUID.Text = mainForm.MACAddress;
                tbRegKey.Text = mainForm.encryptedDate;
            }
            else {  //  otherwise, we're networking or on my machine, so get data from d/b
                string commandString = "select MAC, eDate from tOptions";  //  eDate is encrypted
                FbDataReader rdr = null;
                if (mainForm.bookConn.State == ConnectionState.Closed)
                    mainForm.bookConn.Open();

                FbCommand regCmd = new FbCommand(commandString, mainForm.bookConn);
                rdr = regCmd.ExecuteReader();
                rdr.Read();  //  read the only row...

                tbGUID.Text = rdr[0].ToString();
                tbRegKey.Text = rdr[1].ToString();
                bCopyGUID.Visible = false;
                if (!mainForm.MACAddress.Contains("00044B03C59E"))
                    lNetworked.Visible = true;

                encryptionRoutines er = new encryptionRoutines();
                tbExpireDate.Text = er.decryptString(tbRegKey.Text, tbGUID.Text);
            }
        }


        //-------------------------------------------------------------------------------------------------       
        private void button1_Click(object sender, EventArgs e) {
            Close();
        }


        //------------------------------------------------------------------------------------------------
        private void llPragerSoftware_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(@"http://www.pragersoftware.com");
        }


        //-------------------    copy GUID to clipboard    ------------------------|
        private void bCopyGUID_Click(object sender, EventArgs e) {
            Clipboard.SetText(tbGUID.Text);
        }

    }
}