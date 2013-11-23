#region Using directives

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using FindBookPrices;

#endregion

namespace Prager_Pricing_Program
{

    partial class formISBNLookup : Form
    {

        static public string programVersion = "5.1";  //  good until 12/31/2007

        //  added: restricted list


        //-------------------------------------------------------------------------------------------
        public formISBNLookup()
        {
            //            Cursor.Current = Cursors.WaitCursor;

            InitializeComponent();
            
            License lic = new License();
            int rc = lic.checkForLicense();  //  check for user registration
            if (rc == -1)
            {
                bSearch.Enabled = false;
            }

            RegistryKey OurKey = Registry.Users;
            OurKey = OurKey.OpenSubKey(".DEFAULT", true); // Set it to HKEY_USERS\.DEFUALT
            OurKey = OurKey.OpenSubKey(@"Prager\MultiISBN", true);

            string OptionCheckForUpdates = (string)OurKey.GetValue("Check For Updates");
            if (OptionCheckForUpdates == "1")
                checkForUpdatesToolStripMenuItem.Checked = true;
            else
                checkForUpdatesToolStripMenuItem.Checked = false;

            /*
            0345377443
            0935097406
            0345377433
            0671871188
            */
        }


        //-----------------------------------------------------------------------------------------------
        private void bSearch_Click(object sender, EventArgs e)
        {
            bSearch.Enabled = false;  //  don't allow double clicks
            Cursor.Current = Cursors.WaitCursor;  //  make it wait...

            string[] lines = tbISBNs.Lines;

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
                    lvArray[i].Columns.Add("Venue", 225, HorizontalAlignment.Left);
                    lvArray[i].Columns.Add("Price", 55, HorizontalAlignment.Right);
                    lvArray[i].Items.Clear();
                }

            for (int i = 0; i < 20; i++)
            {
                lvArray[i].Items.Clear();
                lvArray[i].Refresh();
            }
            FindBookPricesDotCom fbp = new FindBookPricesDotCom();
            //AddAllDotCom cdc = new AddAllDotCom();
            //CampusiDotCom cdc = new CampusiDotCom();
            int listViewPointer = 0;

            foreach (string line in lines)  //  for each ISBN...
            {
                //if (!fbp.getBookPrices(line))  //  returns priceAndVenue array [price, bookseller]
                if (!fbp.getBookPrices(line))  //  parameter -> isbn; returns priceAndVenue array [price, bookseller]
                {
                    ListViewItem lvi = new ListViewItem("No prices found");
                    lvi.BackColor = Color.LightSalmon;
                    lvArray[listViewPointer].Items.Add(lvi);
                    listViewPointer++;
                    continue;
                }

                lvArray[listViewPointer].Items.Clear();  // Clear the ListView control

                //  find out how many filled elements are in the array
                int lbCount = 0;
                for (int i = 0; i < fbp.priceAndVenue.GetLength(0); i++)
                {
                    if (fbp.priceAndVenue[i, 0].Length == 0)
                    {
                        lbCount = i;
                        break;
                    }
                }
                Console.Write("\n-->number of elements: " + lbCount);

                //  now go through the returned prices and place them in a listview
                for (int i = 0; i < lbCount; i++)
                {
                    if (i == 0)  //  first line
                    {
                        ListViewItem lvi = new ListViewItem("ISBN: " + line);
                        lvi.BackColor = Color.LightSteelBlue;
                        lvArray[listViewPointer].Items.Add(lvi);  // Add the list items to the ListView
                    }

                    if (i == lbCount - 1)
                    {
                        decimal avgPrice = fbp.accumulatedPrice / i;
                        avgPrice = Math.Round(avgPrice, 2);
                        ListViewItem lvi = new ListViewItem("Average Price");
                        lvi.BackColor = Color.LightYellow;
                        lvi.SubItems.Add(avgPrice.ToString());
                        lvArray[listViewPointer].Items.Add(lvi);  // Add the list items to the ListView
                    }
                    else
                    {
                        ListViewItem lvi = new ListViewItem(fbp.priceAndVenue[i, 1]);
                        lvi.SubItems.Add(fbp.priceAndVenue[i, 0]);
                        if (i == 0)  //  list price
                            lvi.BackColor = Color.LightYellow;
                        lvArray[listViewPointer].Tag = "Title";
                        lvArray[listViewPointer].Items.Add(lvi);  // Add the list items to the ListView
                    }
                }
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
            System.Diagnostics.Process.Start("http://www.pragersoftware.com/html/pricing_program.html");
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