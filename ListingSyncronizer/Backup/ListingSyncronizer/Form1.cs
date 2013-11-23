#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace ListingSyncronizer
{
    partial class Form1 : Form
    {

        static IFormatProvider localCulture = System.Globalization.CultureInfo.CurrentCulture;  //  get current culture
        public static DateTime compileDate = DateTime.Parse("29 Oct 2007 10:07:00 AM", localCulture);

        public static string versionNumber = "3.0 " + compileDate.ToShortDateString();
        //public static string versionNumber = "3.0a BETA " + compileDate.ToShortDateString();
        
        public Form1()
        {
            InitializeComponent();

            this.Text = "Prager Listing Synchronizer Program    Version " + versionNumber;

            License lic = new License();
            int rc = lic.checkForLicense();  //  check for user registration
            if (rc == -1)
            {
                bStart.Enabled = false;
            }

            lSKULS.Visible = false;
            tbSKULS.Visible = false;
            lStatusLS.Visible = false;
            tbStatusLS.Visible = false;
        }

        public string sFileName;


        //-----------------------------------------------------------------------------------------------
        private void bOpenDialog_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sFileName = openFileDialog1.FileName;
                tbFilename.Text = sFileName;
            }
        }


        //------------------------------------------------------------------------------------------------
        private void bStart_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            listBox2.Items.Clear();

            Cursor.Current = Cursors.WaitCursor;

            if (rbMI4Sale.Checked == false && rbMISold.Checked == false)
            {
                MessageBox.Show("You must indicate what to do when Status field is blank", "Prager, Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  take exported file from inventory program and format it (in memory)
            int rc = 0;
            if (formatInventoryFile(tbFilename2.Text) == 0)
                rc = formatListingFile(tbFilename.Text);  //  take listing file and format it
            if (rc == 0)
                compareFiles();  //  compare files and list differences

            Cursor.Current = Cursors.Default;
        }


        //-----------------------------------------------------------------------------------------------
        private void bBrowseInp_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sFileName = openFileDialog1.FileName;
                tbFilename.Text = sFileName;
                if (tbFilename2.Text.Length > 0)
                    bStart.Enabled = true;
            }
        }


        //-----------------------------------------------------------------------------------------------
        private void bBrowseInv_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sFileName = openFileDialog1.FileName;
                tbFilename2.Text = sFileName;
                if (tbFilename.Text.Length > 0)
                    bStart.Enabled = true;
            }
        }


        //------------------------------------------------------------------------------------------
        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //-----------------------------------------------------------------------------------------
        private void bYesGo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.pragersoftware.com");
        }


        //-----------------------------------------------------------------------
        private void rbTabLS_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTabLS.Checked == true)
            {
                lSKULS.Visible = true;
                tbSKULS.Visible = true;
                lStatusLS.Visible = true;
                tbStatusLS.Visible = true;
            }
            else
            {
                lSKULS.Visible = false;
                tbSKULS.Visible = false;
                lStatusLS.Visible = false;
                tbStatusLS.Visible = false;
            }
        }


    }
}