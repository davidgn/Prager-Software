//#define TRACE

#region Using directives

using System;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using FirebirdSql.Data.FirebirdClient;


#endregion

namespace Media_Inventory_Manager
{

    partial class mainForm : Form
    {

        //-----------------------    create aging report    -----------------------------------------
        private void doAgingReport()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();

            string selectCommand = "SELECT * from tMedia WHERE Stat = 'For Sale' ORDER BY DateA";
            FbCommand cmd = new FbCommand(selectCommand, mediaConn);  //  select string sort by date (oldest first)
            dr = cmd.ExecuteReader();

            listView2.Items.Clear();  // Clear the ListView control

            // Display items in the ListView control
            listView2.BeginUpdate();  //  hold off re-painting until load is complete

            while (dr.Read())
            {
                ListViewItem lvi = new ListViewItem(dr["SKU"].ToString());

                if (dr["Title"].ToString().Length > 80)
                    lvi.SubItems.Add(dr["Title"].ToString().Substring(0, 80));
                else
                    lvi.SubItems.Add(dr["Title"].ToString());

                lvi.SubItems.Add(dr["UPC"].ToString());
                lvi.SubItems.Add(dr["Locn"].ToString());

                char[] doubleZeros = { '0', '0' };
                //string xx = dr["Price"].ToString();  //  debugging

                //string workingPrice = dr["Price"].ToString().TrimEnd(doubleZeros);
                //int indx = workingPrice.IndexOf('.');
                //if ((indx + 1) == workingPrice.Length - 1)
                //    workingPrice = workingPrice.PadRight(workingPrice.Length + 1, '0');

                decimal workingPrice = (decimal)(dr["Price"]);

                lvi.SubItems.Add(workingPrice.ToString("N2"));

                //  convert DateA to number of days from today
                DateTime d1 = DateTime.Parse(dr["DateA"].ToString(), localCulture);
                DateTime d2 = DateTime.Today;

                int diff = (d2 - d1).Days;
                if (cbAgingFilter.Checked == true && diff < int.Parse(tbAgingDays.Text))
                    continue;
                else
                    lvi.SubItems.Add(diff.ToString());

                listView2.Tag = "Title";
                listView2.Items.Add(lvi);  // Add the list items to the ListView
            }
            listView2.EndUpdate();

            dr.Close();
        }

        //-----------------------    create sales report    -----------------------------------------
        private void doSalesReport(string tagValue)
        {
            Cursor.Current = Cursors.WaitCursor;
            CultureInfo ci = CultureInfo.CurrentCulture;
            NumberFormatInfo nfi = ci.NumberFormat;
            string currentYear = DateTime.Today.Year.ToString();
            string currentMonth = DateTime.Today.Month.ToString();
            string lastMonth = (DateTime.Today.Month - 1).ToString();
            string currentDay = DateTime.Today.Day.ToString();

            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();

            string selectCommand = "Select tMedia.*, tInvoice.tInvCustNbr FROM tMedia LEFT OUTER JOIN tInvoice ON tMedia.InvoiceNbr = tInvoice.tInvoiceNbr " +
                " WHERE tMedia.Stat = 'Sold' ";

            //  now determine which radio button was checked
            if (tagValue != "") {
                switch (int.Parse(tagValue)) {
                    case 0:  //  daily
                        selectCommand += " AND extract(month from DateU) = " + currentMonth + " AND extract(day from DateU) = " + currentDay + " AND extract(year from DateU) = " + currentYear;
                        break;
                    case 1:  //  weekly
                        DateTime stDate;
                        DateTime endDate;
                        double offset = 0;
                        switch (System.DateTime.Today.DayOfWeek) {
                            case DayOfWeek.Sunday:
                                offset = 0;
                                break;
                            case DayOfWeek.Monday:
                                offset = -1;
                                break;
                            case DayOfWeek.Tuesday:
                                offset = -2;
                                break;
                            case DayOfWeek.Wednesday:
                                offset = -3;
                                break;
                            case DayOfWeek.Thursday:
                                offset = -4;
                                break;
                            case DayOfWeek.Friday:
                                offset = -5;
                                break;
                            case DayOfWeek.Saturday:
                                offset = -6;
                                break;
                        }
                        /*
                         * Select tMedia.*, tInvoice.tInvCustNbr FROM tMedia LEFT OUTER JOIN tInvoice ON tMedia.InvoiceNbr = tInvoice.tInvoiceNbr
                        WHERE tMedia.Stat = 'Sold'
                        AND (extract(month from DateU) = 2 and extract(day from DateU) >= 7 and extract(year from DateU) = 2010)
                        AND (extract(month from DateU) = 2 and extract(day from DateU) <= 14 and extract(year from DateU) = 2010)
                         * */
                        endDate = System.DateTime.Today.AddDays(offset);
                        stDate = System.DateTime.Today.AddDays(-7 + offset);
                        selectCommand += " AND (extract(month from DateU) = " + stDate.Month +
                            " and extract(day from DateU) >= " + stDate.Day +
                            " and extract(year from DateU) = " + stDate.Year +
                            ") AND (extract(month from DateU) = " + endDate.Month +
                            " and extract(day from DateU) <= " + endDate.Day +
                            " and extract(year from DateU) = " + endDate.Year + ") ";
                        break;
                    case 2:  //  1st qtr
                        selectCommand += " AND extract(month from DateU) >= 1 and extract(month from DateU) <= 3 and extract(year from DateU) = " + currentYear;
                        break;
                    case 3:  //  2nd qtr
                        selectCommand += " AND extract(month from DateU) >= 4 and extract(month from DateU) <= 6 and extract(year from DateU) = " + currentYear;
                        break;
                    case 4:  //  3rd qtr
                        selectCommand += " AND extract(month from DateU) >= 7 and extract(month from DateU) <= 9 and extract(year from DateU) = " + currentYear;
                        break;
                    case 5:  //  4th qtr
                        selectCommand += " AND extract(month from DateU) >= 10 and extract(month from DateU) <= 12 and extract(year from DateU) = " + currentYear;
                        break;
                    case 6:  //  monthly
                        selectCommand += " AND extract(month from DateU) = " + currentMonth;
                        break;
                    case 7:  //  ytd
                        selectCommand += "AND extract(year from DateU) = " + currentYear;
                        break;
                    default:  //  nothing selected - give message
                        MessageBox.Show("You did not select a time period for reporting - YTD assumed", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        selectCommand += "AND extract(year from DateU) = " + currentYear;
                        break;
                }
            }
            else {  //  11.3.6
                MessageBox.Show("You must select a time period for report generation", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectCommand += " ORDER BY tMedia.DateU";

            FbCommand cmd = new FbCommand(selectCommand, mediaConn);  //  select string sort by date (oldest first)
            dr = cmd.ExecuteReader();

            lvSalesReport.Items.Clear();  // Clear the ListView control

            // Display items in the ListView control
            lvSalesReport.BeginUpdate();  //  hold off re-painting until load is complete

            while (dr.Read())
            {
                ListViewItem lvi = new ListViewItem(dr["SKU"].ToString());

                if (dr["Title"].ToString().Length > 80)
                    lvi.SubItems.Add(dr["Title"].ToString().Substring(0, 80));
                else
                    lvi.SubItems.Add(dr["Title"].ToString());

                    lvi.SubItems.Add(dr["UPC"].ToString());

                DateTime tempDate = (DateTime)dr["DateU"];
                lvi.SubItems.Add(tempDate.ToString("d"));

                decimal workingPrice = (decimal)dr["Price"];
                lvi.SubItems.Add(workingPrice.ToString("##,###.00", nfi));
                lvi.SubItems.Add(dr["InvoiceNbr"].ToString());
                lvi.SubItems.Add(dr["tInvCustNbr"].ToString());

                lvSalesReport.Tag = "Title";
                lvSalesReport.Items.Add(lvi);  // Add the list items to the ListView
            }
            lvSalesReport.EndUpdate();

            dr.Close();
        }
    }
}