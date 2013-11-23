#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

#endregion

namespace Prager_Pricing_Program
{
    partial class formISBNLookup : Form
    {

        string BookInfo;
        string sISBN;


//-----------------------------------------------------------------------------------------------
        private void singleSearch()
        {

            // Set to details view.
            listView0.Clear();  //  removes all items AND columns from the control

            listView0.View = View.Details;
            listView0.Columns.Add("Source", 132, HorizontalAlignment.Left);
            listView0.Columns.Add("Price", 55, HorizontalAlignment.Right);
            listView0.AllowColumnReorder = false;
            listView0.Refresh();

            sISBN = tbSingleISBNs.SelectedText;
            if (sISBN == "")
            {
                MessageBox.Show("You must select which ISBN to search by double-clicking it",
                    "Prager Pricing Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sISBN.Length < 10)
            {
                MessageBox.Show("Length of ISBN " + sISBN + " is invalid",
                    "Prager Pricing Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Regex r;
            Match m;
            r = new Regex(@"-");  // look for dashes...
            m = r.Match(sISBN);
            if (m.Success == true)
            {
                MessageBox.Show("Dashes are not allowed; " + sISBN + " is invalid",
                    "Prager Pricing Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            startSearch();

        }



//------------------------------------------------------------------------------------------------        
        public void startSearch()
        {
            int rc = 0;
            Cursor.Current = Cursors.WaitCursor;

            lSearchISBN0.Text = "ISBN:";
            lSearchISBN0.ForeColor = Color.Black;
            lSearchISBN0.Refresh();

            if (sISBN.Length == 10)  //  only do it if we have an ISBN
            {
                //if (rbNormal.Checked == true)  //  check if Pricing Service requested
                //{
                //    BookInfo = readAddallBookInfo(sISBN);
                //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN0, listView0, sISBN);  //  parse pricing info and populate list box
                //    if (rc == -1)
                //    {
                //        lSearchISBN0.Text = "ISBN not found";
                //        lSearchISBN0.ForeColor = Color.Red;
                //        lSearchISBN0.Refresh();
                //    }
                    
                //}
                //else
                //{
                //    if (rbExtended.Checked == true)
                //    {
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN0, listView0, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN0.Text = "ISBN not found";
                            lSearchISBN0.ForeColor = Color.Red;
                            lSearchISBN0.Refresh();
                        }
             //       }
            //    }

            }

            Cursor.Current = Cursors.Default;
        }

    }
}