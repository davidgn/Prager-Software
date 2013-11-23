#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Media_Inventory_Manager
{
    partial class aboutScreen : Form
    {

        //-------------------------------------------------------------------------------------------------
        public aboutScreen() {
            InitializeComponent();

            //  fill in data...
            tbVersion.Text = mainForm.versionNumber;
            tbExpireDate.Text = mainForm.expireDate.ToShortDateString();
            tbGUID.Text = mainForm.MACAddress;
            tbRegKey.Text = mainForm.eDate;
        }


        //-------------------------------------------------------------------------------------------------       
        private void button1_Click(object sender, EventArgs e) {
            Close();
        }


        //------------------------------------------------------------------------------------------------
        private void llPragerSoftware_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(@"http://www.pragersoftware.com");
        }


        //-------------------    copy GUID to clipboard    ------------------------]
        private void bCopyGUID_Click(object sender, EventArgs e) {
            Clipboard.SetText(tbGUID.Text);
        }

        private void label4_Click(object sender, EventArgs e) {

        }






    }
}