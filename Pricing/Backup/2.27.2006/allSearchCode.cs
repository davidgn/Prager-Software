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

//-----------------------------------------------------------------------------------
        private void searchAllAtOnce()
        {
/*
0345377443
1578200849
0345377343
0764550497
1565924010
*/

            string[] workingISBNs = tbISBNs.Lines;
            int j = workingISBNs.GetLength(0);  //  get number of ISBNs

            progressBar.Visible = true;  // Display the ProgressBar control.
            progressBar.Minimum = 1;  // Set Minimum to 1 to represent the first ISBN
            progressBar.Maximum = j + 1;  // Set Maximum to the total number of ISBNs
            progressBar.Value = 1;  // Set the initial value of the ProgressBar.
            progressBar.Step = 1;  // Set the Step property to a value of 1 to represent each ISBN

            clearListBoxes();

            Regex r;
            Match m;
            for (int i = 0; i < j; i++)
            {
                if (workingISBNs[i].ToString() == "")
                    continue;
                if (workingISBNs[i].ToString().Length < 10)
                {
                    lSearchISBN1.Text = "ISBN length less than 10";
                    lSearchISBN1.ForeColor = Color.Red;
                    lSearchISBN1.Refresh();
                    progressBar.PerformStep();
                    continue;
                }
                r = new Regex(@"-");  // look for dashes...
                m = r.Match(workingISBNs[i]);
                if (m.Success == true)
                {
                    lSearchISBN1.Text = "Dashes not allowed in ISBN";
                    lSearchISBN1.ForeColor = Color.Red;
                    lSearchISBN1.Refresh();
                    continue;
                }

                startMultipleSearch(workingISBNs[i], i);
                progressBar.PerformStep();

            }

            Cursor.Current = Cursors.Default;

        }


//--------------------------------------------------------------------------------------------------
        private void startMultipleSearch(string sISBN, int itemNumber)
        {
            int rc = 0;
            Cursor.Current = Cursors.AppStarting;

            switch (itemNumber)
            {
                case 0:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN1, listView1, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN1.Text = "ISBN not found";
                    //        lSearchISBN1.ForeColor = Color.Red;
                    //        lSearchISBN1.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN1, listView1, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN1.Text = "ISBN not found";
                            lSearchISBN1.ForeColor = Color.Red;
                            lSearchISBN1.Refresh();
                        }
//                    }
                    break;
                case 1:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN2, listView2, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN2.Text = "ISBN not found";
                    //        lSearchISBN2.ForeColor = Color.Red;
                    //        lSearchISBN2.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN2, listView2, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN2.Text = "ISBN not found";
                            lSearchISBN2.ForeColor = Color.Red;
                            lSearchISBN2.Refresh();
                        }
//                    }
                    break;
                case 2:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN3, listView3, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN3.Text = "ISBN not found";
                    //        lSearchISBN3.ForeColor = Color.Red;
                    //        lSearchISBN3.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN3, listView3, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN3.Text = "ISBN not found";
                            lSearchISBN3.ForeColor = Color.Red;
                            lSearchISBN3.Refresh();
                        }
//                    }
                    break;
                case 3:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN4, listView4, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN4.Text = "ISBN not found";
                    //        lSearchISBN4.ForeColor = Color.Red;
                    //        lSearchISBN4.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN4, listView4, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN4.Text = "ISBN not found";
                            lSearchISBN4.ForeColor = Color.Red;
                            lSearchISBN4.Refresh();
                        }
 //                   }
                    break;
                case 4:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN5, listView5, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN5.Text = "ISBN not found";
                    //        lSearchISBN5.ForeColor = Color.Red;
                    //        lSearchISBN5.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN5, listView5, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN5.Text = "ISBN not found";
                            lSearchISBN5.ForeColor = Color.Red;
                            lSearchISBN5.Refresh();
                        }
 //                   }
                    break;
                case 5:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN6, listView6, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN6.Text = "ISBN not found";
                    //        lSearchISBN6.ForeColor = Color.Red;
                    //        lSearchISBN6.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN6, listView6, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN6.Text = "ISBN not found";
                            lSearchISBN6.ForeColor = Color.Red;
                            lSearchISBN6.Refresh();
                        }
//                    }
                    break;
                case 6:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN7, listView7, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN7.Text = "ISBN not found";
                    //        lSearchISBN7.ForeColor = Color.Red;
                    //        lSearchISBN7.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN7, listView7, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN7.Text = "ISBN not found";
                            lSearchISBN7.ForeColor = Color.Red;
                            lSearchISBN7.Refresh();
                        }
 //                   }
                    break;
                case 7:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN8, listView8, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN8.Text = "ISBN not found";
                    //        lSearchISBN8.ForeColor = Color.Red;
                    //        lSearchISBN8.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN8, listView8, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN8.Text = "ISBN not found";
                            lSearchISBN8.ForeColor = Color.Red;
                            lSearchISBN8.Refresh();
                        }
//                    }
                    break;
                case 8:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN9, listView9, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN9.Text = "ISBN not found";
                    //        lSearchISBN9.ForeColor = Color.Red;
                    //        lSearchISBN9.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN9, listView9, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN9.Text = "ISBN not found";
                            lSearchISBN9.ForeColor = Color.Red;
                            lSearchISBN9.Refresh();
                        }
    //                }
                    break;
                case 9:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN10, listView10, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN10.Text = "ISBN not found";
                    //        lSearchISBN10.ForeColor = Color.Red;
                    //        lSearchISBN10.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN10, listView10, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN10.Text = "ISBN not found";
                            lSearchISBN10.ForeColor = Color.Red;
                            lSearchISBN10.Refresh();
                        }
 //                   }
                    break;
                case 10:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN11, listView11, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN11.Text = "ISBN not found";
                    //        lSearchISBN11.ForeColor = Color.Red;
                    //        lSearchISBN11.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN11, listView11, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN11.Text = "ISBN not found";
                            lSearchISBN11.ForeColor = Color.Red;
                            lSearchISBN11.Refresh();
                        }
 //                   }
                    break;
                case 11:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN12, listView12, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN12.Text = "ISBN not found";
                    //        lSearchISBN12.ForeColor = Color.Red;
                    //        lSearchISBN12.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN12, listView12, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN12.Text = "ISBN not found";
                            lSearchISBN12.ForeColor = Color.Red;
                            lSearchISBN12.Refresh();
                        }
     //               }
                    break;
                case 12:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN13, listView13, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN13.Text = "ISBN not found";
                    //        lSearchISBN13.ForeColor = Color.Red;
                    //        lSearchISBN13.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN13, listView13, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN13.Text = "ISBN not found";
                            lSearchISBN13.ForeColor = Color.Red;
                            lSearchISBN13.Refresh();
                        }
 //                   }
                    break;
                case 13:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN14, listView14, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN14.Text = "ISBN not found";
                    //        lSearchISBN14.ForeColor = Color.Red;
                    //        lSearchISBN14.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN14, listView14, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN14.Text = "ISBN not found";
                            lSearchISBN14.ForeColor = Color.Red;
                            lSearchISBN14.Refresh();
                        }
  //                  }
                    break;
                case 14:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN15, listView15, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN15.Text = "ISBN not found";
                    //        lSearchISBN15.ForeColor = Color.Red;
                    //        lSearchISBN15.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN15, listView15, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN15.Text = "ISBN not found";
                            lSearchISBN15.ForeColor = Color.Red;
                            lSearchISBN15.Refresh();
                        }
 //                   }
                    break;
                case 15:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN16, listView16, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN16.Text = "ISBN not found";
                    //        lSearchISBN16.ForeColor = Color.Red;
                    //        lSearchISBN16.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN16, listView16, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN16.Text = "ISBN not found";
                            lSearchISBN16.ForeColor = Color.Red;
                            lSearchISBN16.Refresh();
                        }
   //                 }
                    break;
                case 16:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN17, listView17, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN17.Text = "ISBN not found";
                    //        lSearchISBN17.ForeColor = Color.Red;
                    //        lSearchISBN17.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN17, listView17, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN17.Text = "ISBN not found";
                            lSearchISBN17.ForeColor = Color.Red;
                            lSearchISBN17.Refresh();
                        }
       //             }
                    break;
                case 17:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN18, listView18, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN18.Text = "ISBN not found";
                    //        lSearchISBN18.ForeColor = Color.Red;
                    //        lSearchISBN18.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN18, listView18, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN18.Text = "ISBN not found";
                            lSearchISBN18.ForeColor = Color.Red;
                            lSearchISBN18.Refresh();
                        }
     //               }
                    break;
                case 18:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN19, listView19, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN19.Text = "ISBN not found";
                    //        lSearchISBN19.ForeColor = Color.Red;
                    //        lSearchISBN19.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN19, listView19, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN19.Text = "ISBN not found";
                            lSearchISBN19.ForeColor = Color.Red;
                            lSearchISBN19.Refresh();
                        }
//                    }
                    break;
                case 19:
                    //if (rbNormal.Checked == true)
                    //{
                    //    BookInfo = readAddallBookInfo(sISBN);
                    //    rc = parseAddallPricingInfo(BookInfo, lSearchISBN20, listView20, sISBN);  //  parse pricing info and populate list box
                    //    if (rc == -1)
                    //    {
                    //        lSearchISBN20.Text = "ISBN not found";
                    //        lSearchISBN20.ForeColor = Color.Red;
                    //        lSearchISBN20.Refresh();
                    //    }
                    //}
                    //if (rbExtended.Checked == true)
                    //{
                        BookInfo = readCampusiBookPricesHtmlPage(sISBN);
                        rc = parseCampusiBookPricesBookInfo(BookInfo, lSearchISBN20, listView20, sISBN);
                        if (rc == -1)
                        {
                            lSearchISBN20.Text = "ISBN not found";
                            lSearchISBN20.ForeColor = Color.Red;
                            lSearchISBN20.Refresh();
                        }
      //              }
                    break;

                default:
                    break;

            }  //  end switch

            tabControl2.Refresh();  //  redraw
            tabControl1.Refresh();  //  here too...
            

        }
     

        
//------------------------------------------------------------------------------------------------
        private void clearListBoxes()
        {
            //  clear out the old stuff
            listView1.Clear();  //  removes all items AND columns from the control
            listView1.View = View.Details;
            listView1.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView1.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView1.AllowColumnReorder = false;
            listView1.Refresh();
            lSearchISBN1.Text = "ISBN:";
            lSearchISBN1.ForeColor = Color.Black;
            lSearchISBN1.Refresh();

            listView2.Clear();  //  removes all items AND columns from the control
            listView2.View = View.Details;
            listView2.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView2.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView2.AllowColumnReorder = false;
            listView2.Refresh();
            lSearchISBN2.Text = "ISBN:";
            lSearchISBN2.ForeColor = Color.Black;
            lSearchISBN2.Refresh();

            listView3.Clear();  //  removes all items AND columns from the control
            listView3.View = View.Details;
            listView3.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView3.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView3.AllowColumnReorder = false;
            listView3.Refresh();
            lSearchISBN3.Text = "ISBN:";
            lSearchISBN3.ForeColor = Color.Black;
            lSearchISBN3.Refresh();

            listView4.Clear();  //  removes all items AND columns from the control
            listView4.View = View.Details;
            listView4.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView4.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView4.AllowColumnReorder = false;
            listView4.Refresh();
            lSearchISBN4.Text = "ISBN:";
            lSearchISBN4.ForeColor = Color.Black;
            lSearchISBN4.Refresh();

            listView5.Clear();  //  removes all items AND columns from the control
            listView5.View = View.Details;
            listView5.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView5.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView5.AllowColumnReorder = false;
            listView5.Refresh();
            lSearchISBN5.Text = "ISBN:";
            lSearchISBN5.ForeColor = Color.Black;
            lSearchISBN5.Refresh();

            listView6.Clear();  //  removes all items AND columns from the control
            listView6.View = View.Details;
            listView6.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView6.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView6.AllowColumnReorder = false;
            listView6.Refresh();
            lSearchISBN6.Text = "ISBN:";
            lSearchISBN6.ForeColor = Color.Black;
            lSearchISBN6.Refresh();

            listView7.Clear();  //  removes all items AND columns from the control
            listView7.View = View.Details;
            listView7.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView7.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView7.AllowColumnReorder = false;
            listView7.Refresh();
            lSearchISBN7.Text = "ISBN:";
            lSearchISBN7.ForeColor = Color.Black;
            lSearchISBN7.Refresh();

            listView8.Clear();  //  removes all items AND columns from the control
            listView8.View = View.Details;
            listView8.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView8.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView8.AllowColumnReorder = false;
            listView8.Refresh();
            lSearchISBN8.Text = "ISBN:";
            lSearchISBN8.ForeColor = Color.Black;
            lSearchISBN8.Refresh();

            listView9.Clear();  //  removes all items AND columns from the control
            listView9.View = View.Details;
            listView9.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView9.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView9.AllowColumnReorder = false;
            listView9.Refresh();
            lSearchISBN9.Text = "ISBN:";
            lSearchISBN9.ForeColor = Color.Black;
            lSearchISBN9.Refresh();

            listView10.Clear();  //  removes all items AND columns from the control
            listView10.View = View.Details;
            listView10.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView10.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView10.AllowColumnReorder = false;
            listView10.Refresh();
            lSearchISBN10.Text = "ISBN:";
            lSearchISBN10.ForeColor = Color.Black;
            lSearchISBN10.Refresh();

            listView11.Clear();  //  removes all items AND columns from the control
            listView11.View = View.Details;
            listView11.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView11.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView11.AllowColumnReorder = false;
            listView11.Refresh();
            lSearchISBN11.Text = "ISBN:";
            lSearchISBN11.ForeColor = Color.Black;
            lSearchISBN11.Refresh();

            listView12.Clear();  //  removes all items AND columns from the control
            listView12.View = View.Details;
            listView12.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView12.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView12.AllowColumnReorder = false;
            listView12.Refresh();
            lSearchISBN12.Text = "ISBN:";
            lSearchISBN12.ForeColor = Color.Black;
            lSearchISBN12.Refresh();

            listView13.Clear();  //  removes all items AND columns from the control
            listView13.View = View.Details;
            listView13.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView13.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView13.AllowColumnReorder = false;
            listView13.Refresh();
            lSearchISBN13.Text = "ISBN:";
            lSearchISBN13.ForeColor = Color.Black;
            lSearchISBN13.Refresh();

            listView14.Clear();  //  removes all items AND columns from the control
            listView14.View = View.Details;
            listView14.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView14.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView14.AllowColumnReorder = false;
            listView14.Refresh();
            lSearchISBN14.Text = "ISBN:";
            lSearchISBN14.ForeColor = Color.Black;
            lSearchISBN14.Refresh();

            listView15.Clear();  //  removes all items AND columns from the control
            listView15.View = View.Details;
            listView15.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView15.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView15.AllowColumnReorder = false;
            listView15.Refresh();
            lSearchISBN15.Text = "ISBN:";
            lSearchISBN15.ForeColor = Color.Black;
            lSearchISBN15.Refresh();

            listView16.Clear();  //  removes all items AND columns from the control
            listView16.View = View.Details;
            listView16.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView16.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView16.AllowColumnReorder = false;
            listView16.Refresh();
            lSearchISBN16.Text = "ISBN:";
            lSearchISBN16.ForeColor = Color.Black;
            lSearchISBN16.Refresh();

            listView17.Clear();  //  removes all items AND columns from the control
            listView17.View = View.Details;
            listView17.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView17.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView17.AllowColumnReorder = false;
            listView17.Refresh();
            lSearchISBN17.Text = "ISBN:";
            lSearchISBN17.ForeColor = Color.Black;
            lSearchISBN17.Refresh();

            listView18.Clear();  //  removes all items AND columns from the control
            listView18.View = View.Details;
            listView18.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView18.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView18.AllowColumnReorder = false;
            listView18.Refresh();
            lSearchISBN18.Text = "ISBN:";
            lSearchISBN18.ForeColor = Color.Black;
            lSearchISBN18.Refresh();

            listView19.Clear();  //  removes all items AND columns from the control
            listView19.View = View.Details;
            listView19.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView19.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView19.AllowColumnReorder = false;
            listView19.Refresh();
            lSearchISBN19.Text = "ISBN:";
            lSearchISBN19.ForeColor = Color.Black;
            lSearchISBN19.Refresh();

            listView20.Clear();  //  removes all items AND columns from the control
            listView20.View = View.Details;
            listView20.Columns.Add("Source", 130, HorizontalAlignment.Left);
            listView20.Columns.Add("Price", 57, HorizontalAlignment.Right);
            listView20.AllowColumnReorder = false;
            listView20.Refresh();
            lSearchISBN20.Text = "ISBN:";
            lSearchISBN20.ForeColor = Color.Black;
            lSearchISBN20.Refresh();

        }

    }  //  end class
}  //  end namespace