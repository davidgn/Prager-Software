#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

#endregion

namespace Prager_Pricing_Program
{

    partial class formISBNLookup : Form
    {
        static public string programVersion = "3.4b";

        public formISBNLookup()
        {
            InitializeComponent();

            checkForLicense();  //  check for user registration

            RegistryKey OurKey = Registry.Users;
            OurKey = OurKey.OpenSubKey(".DEFAULT", true); // Set it to HKEY_USERS\.DEFUALT
            OurKey = OurKey.OpenSubKey(@"Prager\MultiISBN", true);

            string primaryTab = (string)OurKey.GetValue("Primary");  //  primary tab option
            if (primaryTab == "0")
                tabControl1.SelectTab(0);
            else
                tabControl1.SelectTab(1);
            groupBox2.Enabled = false;

            string searchDefault = (string)OurKey.GetValue("Search");
            if (searchDefault == "0")
                rbNormal.Checked = true;
            else
                rbExtended.Checked = true;

 
            checkForUpdates();

        }



//-----------------------------------------------------------------------------------------------
        private void bSearch_Click(object sender, EventArgs e)
        {
            if (rbNormal.Checked == false && rbExtended.Checked == false)
            {
                MessageBox.Show("Type of Search not selected (Consolidated or Extended)", "Prager Pricing Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (tabControl1.SelectedIndex == 0)
                    singleSearch();
                else
                    searchAllAtOnce();
            }
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
            tbSingleISBNs.Text = "";
            tbISBNs.Clear();
        }



//---------------------------------------------------------------------------------------------
        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
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


//-------------------------------------------------------------------------------------
        private void searchoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searchoneToolStripMenuItem.Checked == true)
            {
                searchallToolStripMenuItem.Checked = false;
                tabControl1.SelectTab(0);
            }
        }


//--------------------------------------------------------------------------------------
        private void searchallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searchallToolStripMenuItem.Checked == true)
            {
                searchoneToolStripMenuItem.Checked = false;
                tabControl1.SelectTab(1);
            }
        }


//--------------------------------------------------------------------------------------------
        private void saveOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey OurKey = Registry.Users;

            OurKey = OurKey.OpenSubKey(".DEFAULT", true); // Set it to HKEY_USERS\.DEFUALT
            OurKey = OurKey.OpenSubKey(@"Prager\MultiISBN", true);

            if (searchallToolStripMenuItem.Checked == true)
                OurKey.SetValue("Primary", "1");
            else
                OurKey.SetValue("Primary", "0");

            if (limitedToolStripMenuItem.Checked == true)
                OurKey.SetValue("Search", "0");
            else
                OurKey.SetValue("Search", "1");

        }


//--------------------------------------------------------------------------------------------
        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (limitedToolStripMenuItem.Checked == true)
            {
                extendedToolStripMenuItem.Checked = false;
                rbNormal.Checked = true;
            }
        }


//---------------------------------------------------------------------------------------------
        private void extendedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (extendedToolStripMenuItem.Checked == true)
            {
                limitedToolStripMenuItem.Checked = false;
                rbExtended.Checked = true;
            }
        }


//---------------------------------------------------------------------------------------------
        private void formISBNLookup_Load(object sender, EventArgs e)
        {
            if (searchoneToolStripMenuItem.Checked == true)
                tabControl1.SelectTab(0);
        }


//--------------------------------------------------------------------------------------------
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0 || tabControl1.SelectedIndex == 1)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                bSearch.Enabled = true;
                bClear.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                bSearch.Enabled = false;
                bClear.Enabled = false;
            }
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
            System.Diagnostics.Process.Start("http://www.pragerbooksellers.com/html/book_pricing_program.html");
        }


//----------------------------------------------------------------------------------------        
        private void bWebBack_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
                webBrowser1.GoBack();
            else
            if (tabControl1.SelectedIndex == 3)
                webBrowser2.GoBack();
            else
            if (tabControl1.SelectedIndex == 4)
                webBrowser3.GoBack();
            else
            if (tabControl1.SelectedIndex == 5)
                webBrowser4.GoBack();
        }


//------------------------------------------------------------------------------------------
        private void bWebStop_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
                webBrowser1.Stop();
            else
            if (tabControl1.SelectedIndex == 3)
                webBrowser2.Stop();
            else
            if (tabControl1.SelectedIndex == 4)
                webBrowser3.Stop();
            else
            if (tabControl1.SelectedIndex == 5)
                webBrowser4.Stop();
        }


//------------------------------------------------------------------------------------------
        private void bWebPrint_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
                webBrowser1.Print();
            else
            if (tabControl1.SelectedIndex == 3)
                webBrowser2.Print();
            else
            if (tabControl1.SelectedIndex == 4)
                webBrowser3.Print();
            else
            if (tabControl1.SelectedIndex == 5)
                webBrowser4.Print();
        }


//----------------------------------------------------------------------------------------
        private void bWebForward_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
                webBrowser1.GoForward();
            else
            if (tabControl1.SelectedIndex == 3)
                webBrowser2.GoForward();
            else
            if (tabControl1.SelectedIndex == 4)
                webBrowser3.GoForward();
            else
            if (tabControl1.SelectedIndex == 5)
                webBrowser4.GoForward();
        }


//------------------------------------------------------------------------------------------
        private void bWebNewEntry_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
                webBrowser1.Navigate(@"http://used.addall.com/", false);
            else
            if (tabControl1.SelectedIndex == 3)
                webBrowser2.Navigate(@"http://www.fetchbook.info", false);
            else
            if (tabControl1.SelectedIndex == 4)
                webBrowser3.Navigate(@"http://www.findbookprices.com", false);
            else
            if (tabControl1.SelectedIndex == 5)
                webBrowser4.Navigate(@"http://www.campusi.com/book/default.asp", false);
        }


//-------------------------------------------------------------------------------------------
        private void checkfornewversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkForUpdates();
        }

    }
}