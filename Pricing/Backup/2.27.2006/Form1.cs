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

        static public string programVersion = "4.0d";

        public formISBNLookup()
        {
//            Cursor.Current = Cursors.WaitCursor;

            InitializeComponent();

            License lic = new License();
            int rc = lic.checkForLicense();  //  check for user registration
            if (rc == -1)
            {
                bSearch.Enabled = false;
                tabControl1.Enabled = false;
            }

            RegistryKey OurKey = Registry.Users;
            OurKey = OurKey.OpenSubKey(".DEFAULT", true); // Set it to HKEY_USERS\.DEFUALT
            OurKey = OurKey.OpenSubKey(@"Prager\MultiISBN", true);

            string OptionCheckForUpdates = (string)OurKey.GetValue("Check For Updates");
            if (OptionCheckForUpdates == "1")
                checkForUpdatesToolStripMenuItem.Checked = true;
            else
                checkForUpdatesToolStripMenuItem.Checked = false;

     //       string primaryTab = (string)OurKey.GetValue("Primary");  //  primary tab option
     //       if (primaryTab == "0")
     //       {
     ////           searchoneToolStripMenuItem.Checked = true;
     //           tabControl1.SelectTab(0);
     //       }
     //       else
     //       {
     //   //        searchallToolStripMenuItem.Checked = true;
     //           tabControl1.SelectTab(1);
     //           groupBox2.Enabled = false;
     //       }

     //       string searchDefault = (string)OurKey.GetValue("Search");
     //       if (searchDefault == "0")
     //       {
     // //          limitedToolStripMenuItem.Checked = true;
     //           rbNormal.Checked = true;
     //       }
     //       else
     //       {
     // //          extendedToolStripMenuItem.Checked = true;
     //           rbExtended.Checked = true;
     //       }
//            Cursor.Current = Cursors.Default;

        }


//-----------------------------------------------------------------------------------------------
        private void bSearch_Click(object sender, EventArgs e)
        {
            //if (rbNormal.Checked == false && rbExtended.Checked == false)
            //{
            //    MessageBox.Show("Type of Search not selected (Consolidated or Extended)", "Prager Pricing Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //else
            //{
                if (tabControl1.SelectedIndex == 0)
                    singleSearch();
                else
                    searchAllAtOnce();
          //  }
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



//--------------------------------------------------------------------------------------------
//        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            if (limitedToolStripMenuItem.Checked == true)
//            {
//                extendedToolStripMenuItem.Checked = false;
//                rbNormal.Checked = true;
//            }
//        }


////---------------------------------------------------------------------------------------------
//        private void extendedToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            if (extendedToolStripMenuItem.Checked == true)
//            {
//                limitedToolStripMenuItem.Checked = false;
//                rbExtended.Checked = true;
//            }
//        }


//---------------------------------------------------------------------------------------------
        //private void formISBNLookup_Load(object sender, EventArgs e)
        //{
        //    if (searchoneToolStripMenuItem.Checked == true)
        //        tabControl1.SelectTab(0);
        //}


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
            System.Diagnostics.Process.Start("http://www.pragersoftware.com/html/pricing_program.html");
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
            else
            if (tabControl1.SelectedIndex == 6)
                webBrowser5.GoBack();
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
            else
            if (tabControl1.SelectedIndex == 6)
                webBrowser5.Stop();
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
            else
            if (tabControl1.SelectedIndex == 6)
                webBrowser5.Print();
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
            else
            if (tabControl1.SelectedIndex == 6)
                webBrowser5.GoForward();
        }


//------------------------------------------------------------------------------------------
        private void bWebNewEntry_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
                webBrowser1.Navigate(@"http://used.addall.com/", false);
            else
            if (tabControl1.SelectedIndex == 3)
                webBrowser2.Navigate(@"http://www.isbn.nu/welcome.html", false);
            else
            if (tabControl1.SelectedIndex == 4)
                webBrowser3.Navigate(@"http://www.findbookprices.com", false);
            else
            if (tabControl1.SelectedIndex == 5)
                webBrowser4.Navigate(@"http://www.campusi.com/book/default.asp", false);
            else
            if (tabControl1.SelectedIndex == 6)
                webBrowser5.Navigate(@"http://www.bookfinder.com", false);
        }


//-------------------------------------------------------------------------------------------
        private void checkfornewversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            checkForUpdates();

            Cursor.Current = Cursors.Default;
        }


//----------------------------------------------------------------------------------------
        private void formISBNLookup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveOptionsToolStripMenuItem.Checked == true)
            {
                RegistryKey OurKey = Registry.Users;

                OurKey = OurKey.OpenSubKey(".DEFAULT", true); // Set it to HKEY_USERS\.DEFUALT
                OurKey = OurKey.OpenSubKey(@"Prager\MultiISBN", true);

                if (checkForUpdatesToolStripMenuItem.Checked == true)
                    OurKey.SetValue("Check for Updates", "1");
                else
                    OurKey.SetValue("Check for Updates", "0");
            }

            if (automaticallyCheckForUpdatesToolStripMenuItem.Checked == true)
                checkForUpdates();
        
        }


        //--------------------------------------------------------------------------------------
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutScreen aboutScreen = new AboutScreen();
            aboutScreen.Show();
        }


        //--------------------------------------------------------------------------------------
        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            checkForUpdates();
            Cursor.Current = Cursors.Default;
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

 
    }
}