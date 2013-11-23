//#define TRACE

#region Using directives

using System;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using System.Text;
using System.IO;


#endregion

namespace Prager_Book_Inventory
{

    partial class mainForm : Form
    {

        //-----------------------------------------------------------------------
        //--    create aging report
        private void doAgingReport() {
            Cursor.Current = Cursors.WaitCursor;

            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();

            string selectCommand = "SELECT * from tBooks WHERE Stat = 'For Sale' ORDER BY DateA";
            FbCommand cmd = new FbCommand(selectCommand, bookConn);  //  select string sort by date (oldest first)
            dr = cmd.ExecuteReader();

            listView2.Items.Clear();  // Clear the ListView control

            // Display items in the ListView control
            listView2.BeginUpdate();  //  hold off re-painting until load is complete

            while (dr.Read()) {
                ListViewItem lvi = new ListViewItem(dr["BookNbr"].ToString());

                if (dr["Title"].ToString().Length > 80)
                    lvi.SubItems.Add(dr["Title"].ToString().Substring(0, 80));
                else
                    lvi.SubItems.Add(dr["Title"].ToString());

                lvi.SubItems.Add(dr["ISBN"].ToString());
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
                if (cbAgingFilter.Checked && diff < int.Parse(tbAgingDays.Text))
                    continue;
                else
                    lvi.SubItems.Add(diff.ToString());

                listView2.Tag = "Title";
                listView2.Items.Add(lvi);  // Add the list items to the ListView
            }
            listView2.EndUpdate();

            dr.Close();
        }


        //-------------------------------------------------------------------------------
        //--    create sales report
        private void doSalesReport(string tagValue) {
            Cursor.Current = Cursors.WaitCursor;
            CultureInfo ci = CultureInfo.CurrentCulture;
            NumberFormatInfo nfi = ci.NumberFormat;
            string currentYear = DateTime.Today.Year.ToString();
            string currentMonth = DateTime.Today.Month.ToString();
            string lastMonth = (DateTime.Today.Month - 1).ToString();
            string currentDay = DateTime.Today.Day.ToString();

            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();

            string selectCommand = "Select tBooks.*, tInvoice.tInvCustNbr FROM tBooks LEFT OUTER JOIN tInvoice ON tBooks.InvoiceNbr = tInvoice.tInvoiceNbr " +
                " WHERE tBooks.Stat = 'Sold' ";

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
                         * Select tBooks.*, tInvoice.tInvCustNbr FROM tBooks LEFT OUTER JOIN tInvoice ON tBooks.InvoiceNbr = tInvoice.tInvoiceNbr
                        WHERE tBooks.Stat = 'Sold'
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
                        MessageBox.Show("You did not select a time period for reporting - YTD assumed", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        selectCommand += "AND extract(year from DateU) = " + currentYear;
                        break;
                }
            }
            else {  //  11.3.6
                MessageBox.Show("You must select a time period for report generation", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectCommand += " ORDER BY tBooks.DateU";

            FbCommand cmd = new FbCommand(selectCommand, bookConn);  //  select string sort by date (oldest first)
            dr = cmd.ExecuteReader();

            lvSalesReport.Items.Clear();  // Clear the ListView control

            // Display items in the ListView control
            lvSalesReport.BeginUpdate();  //  hold off re-painting until load is complete

            while (dr.Read()) {
                ListViewItem lvi = new ListViewItem(dr["BookNbr"].ToString());

                if (dr["Title"].ToString().Length > 80)
                    lvi.SubItems.Add(dr["Title"].ToString().Substring(0, 80));
                else
                    lvi.SubItems.Add(dr["Title"].ToString());

                lvi.SubItems.Add(dr["ISBN"].ToString());

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


        //-------------------------------------------------------------------------
        //--    create Inventory Report
        public void printInvReport(mainForm mf, ListView dataBasePanel, FbConnection bookConn, string exportPath, ListBox lbSortSeq) {

            Cursor.Current = Cursors.WaitCursor;
            string chosenFields = "";
            mf.lFinished.Visible = false;  //  finished message on report creation page

            //ArrayList alSKU = new ArrayList();
            //ArrayList alCheckBoxes = new ArrayList();

            ////  contents are already in database panel, so get SKU so we can get the record  
            //foreach (ListViewItem item in dataBasePanel.Items)
            //    alSKU.Add(item.Text);  //  put SKU's in arrayList

            //  build the chosenFields object
            CheckBox cb = null;
            foreach (Control ctl in mf.gbFields.Controls) {
                if (ctl.Name == "invRepSelAll")
                    continue;

                cb = (CheckBox)ctl;
                if (cb.Checked) {
                    switch (cb.Text) {  //  or cb.name or whatever gives me the text associated with the cb
                        case "SKU":
                            chosenFields += "BookNBr, ";
                            break;
                        case "Title":
                            chosenFields += "Title, ";
                            break;
                        case "Author":
                        case "AuthorLastNameFirst":
                            chosenFields += "Author, ";
                            break;
                        case "ISBN/ASIN":
                            chosenFields += "ISBN, ";
                            break;
                        case "Illustrator":
                            chosenFields += "Illus, ";
                            break;
                        case "Location":
                            chosenFields += "Locn, ";
                            break;
                        case "Price":
                            chosenFields += "Price, ";
                            break;
                        case "Cost":
                            chosenFields += "Cost, ";
                            break;
                        case "Publisher":
                            chosenFields += "Pub, ";
                            break;
                        case "Pub Location":
                            chosenFields += "PubPlace, ";
                            break;
                        case "Year Published":
                            chosenFields += "PubYear, ";
                            break;
                        case "Keywords":
                            chosenFields += "Keywds, ";
                            break;
                        case "Description":
                            chosenFields += "Descr, ";
                            break;
                        case "Jacket":
                            chosenFields += "Jaket, ";
                            break;
                        case "Binding":
                            chosenFields += "Bndg, ";
                            break;
                        case "Book Condition":
                            chosenFields += "Condn, ";
                            break;
                        case "Edition":
                            chosenFields += "Ed, ";
                            break;
                        case "Signed":
                            chosenFields += "Signed, ";
                            break;
                        case "Book Type":
                            chosenFields += "BookType, ";
                            break;
                        case "Book Size":
                            chosenFields += "BookSize, ";
                            break;
                        case "Date Added":
                            chosenFields += "DateA, ";
                            break;
                        case "Date Updated":
                            chosenFields += "DateU, ";
                            break;
                        case "Primary Catalog":
                            chosenFields += "Cat, ";
                            break;
                        case "Notes":
                            chosenFields += "Notes, ";
                            break;
                        case "Status":
                            chosenFields += "Stat, ";
                            break;
                        case "Invoice Number":
                            chosenFields += "InvoiceNbr, ";
                            break;
                        case "Secondary Catalog":
                            chosenFields += "SubCategory, ";
                            break;
                        case "Do Not Reprice Flag":
                            chosenFields += "DoNotReprice, ";
                            break;
                        case "Pages":
                            chosenFields += "NbrOfPages, ";
                            break;
                        case "Book Weight":
                            chosenFields += "BookWeight, ";
                            break;
                        case "Quantity":
                            chosenFields += "Quantity, ";
                            break;
                        case "Shipping":
                            chosenFields += "Shipping, ";
                            break;
                        default:
                            break;
                    }
                }
            }

            //  remove the last comma
            int indx = chosenFields.LastIndexOf(',');
            if (indx != -1)
                chosenFields = chosenFields.Remove(indx);

            //  add field to sort on... 
            //if (mainForm.chosenSortFields.Length == 0) {
            //if (lbSortSeq.SelectedItem != null && lbSortSeq.SelectedItem.Equals("Author (by last name)")) {
            //    mainForm.chosenSortFields = "TRIM(SUBSTRING(Author FROM POSITION (' ') + 1))";
            //}
            ////}
            //else {
                //mainForm.chosenSortFields = lbSortSeq.SelectedItem.ToString() == "SKU" ? "BookNbr" : lbSortSeq.SelectedItem.ToString();
            if(lbSortSeq.SelectedItem != null)       
            switch (lbSortSeq.SelectedItem.ToString()) {  //  or cb.name or whatever gives me the text associated with the cb
                        case "SKU":
                            chosenSortFields = "BookNBr ";
                            break;
                        case "Title":
                            chosenSortFields = "Title ";
                            break;
                        case "Author":
                            chosenSortFields = "Author ";
                            break;
                        case "ISBN/ASIN":
                            chosenSortFields = "ISBN ";
                            break;
                        case "Illustrator":
                            chosenSortFields = "Illus ";
                            break;
                        case "Location":
                            chosenSortFields = "Locn ";
                            break;
                        case "Price":
                            chosenSortFields = "Price ";
                            break;
                        case "Cost":
                            chosenSortFields = "Cost ";
                            break;
                        case "Publisher":
                            chosenSortFields = "Pub ";
                            break;
                        case "Pub Location":
                            chosenSortFields = "PubPlace ";
                            break;
                        case "Year Published":
                            chosenSortFields = "PubYear ";
                            break;
                        case "Keywords":
                            chosenSortFields = "Keywds ";
                            break;
                        case "Description":
                            chosenSortFields = "Descr ";
                            break;
                        case "Jacket":
                            chosenSortFields = "Jaket ";
                            break;
                        case "Binding":
                            chosenSortFields = "Bndg ";
                            break;
                        case "Book Condition":
                            chosenSortFields = "Condn ";
                            break;
                        case "Edition":
                            chosenSortFields = "Ed ";
                            break;
                        case "Signed":
                            chosenSortFields = "Signed ";
                            break;
                        case "Book Type":
                            chosenSortFields = "BookType ";
                            break;
                        case "Book Size":
                            chosenSortFields = "BookSize ";
                            break;
                        case "Date Added":
                            chosenSortFields = "DateA ";
                            break;
                        case "Date Updated":
                            chosenSortFields = "DateU ";
                            break;
                        case "Primary Catalog":
                            chosenSortFields = "Cat ";
                            break;
                        case "Notes":
                            chosenSortFields = "Notes ";
                            break;
                        case "Status":
                            chosenSortFields = "Stat ";
                            break;
                        case "Invoice Number":
                            chosenSortFields = "InvoiceNbr ";
                            break;
                        case "Secondary Catalog":
                            chosenSortFields = "SubCategory ";
                            break;
                        case "Do Not Reprice Flag":
                            chosenSortFields = "DoNotReprice ";
                            break;
                        case "Pages":
                            chosenSortFields = "NbrOfPages ";
                            break;
                        case "Book Weight":
                            chosenSortFields = "BookWeight ";
                            break;
                        case "Quantity":
                            chosenSortFields = "Quantity ";
                            break;
                        case "Shipping":
                            chosenSortFields = "Shipping ";
                            break;
                        default:
                            break;
                    }
                //}
            //}

            indx = mainForm.chosenSortFields.LastIndexOf(',');  //  remove the last comma
            if (indx != -1)
                mainForm.chosenSortFields = mainForm.chosenSortFields.Remove(indx);

            //  setup output writer
            StringBuilder stringBuilder = new StringBuilder();
            TextWriter tw1 = null;

            if (mf.rbIRPrint.Checked)
                mf.richTextBox1.Text = chosenFields + "\r\n\r\n";
            else if (mf.rbIRClipBoard.Checked)  //  comma-delimited
                stringBuilder.Append(chosenFields + "\r\n");
            else if (mf.rbIRFile.Checked) { //  comma-delimited
                string sFileName = "";
                sFileName = exportPath + "InvReport.tab";  //  create filename
                tw1 = new StreamWriter(sFileName);
                tw1.WriteLine(chosenFields + "\r\n");  //  now, build and write header line
            }

            //  now, read each book in listview from the table    <----------------- ????
            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();
            FbDataReader dr = null;
            FbCommand sqlCmd = null;
            Clipboard.Clear();  //  clear out old stuff...

            mainForm.commandString = "SELECT " + chosenFields + " FROM tBooks ";
            if (mainForm.chosenSortFields.Length > 3)  // || !mainForm.chosenSortFields.Contains("Author (by last name)"))
                mainForm.commandString += " ORDER BY " + mainForm.chosenSortFields;

            sqlCmd = new FbCommand(mainForm.commandString, bookConn);
            dr = sqlCmd.ExecuteReader();

            //int authorIndex = 99;  //  used for splitting author
            //string[] tempAuthor;
            //int splitCount;
            //string splitAuthor = "";

            while (dr.Read()) {    //  create output lines
                //for(int i = 0; i < chosenSortFields.Length; i++)
                //if (mainForm.chosenSortFields == "Author (by last name)" && authorIndex == 99) {
                //    if (dr[0].ToString().Contains("Author")) {
                //        authorIndex = 0;
                //        break;
                //    }
                //    else if (dr[1].ToString().Contains("Author")) {
                //        authorIndex = 1;
                //        break;
                //    }
                //    else if (dr[2].ToString().Contains("Author")) {
                //        authorIndex = 2;
                //        break;
                //    }
                //}

                //if(authorIndex < 3)  {  //  means we are sorting on author's last name
                //    tempAuthor = dr[authorIndex].ToString().Split(' ');
                //    splitCount = tempAuthor.Length;
                //    splitAuthor = tempAuthor[splitCount];
                //}

                if (mf.rbIRPrint.Checked) {  //  to printer
                    string text = "";
                    for (int c = 0; c < dr.FieldCount; c++) {
                        text += dr[c].ToString() + "\t";
                    }
                    mf.richTextBox1.AppendText(text + "\r\n");
                }
                else if (mf.rbIRClipBoard.Checked) {  //  clipboard
                    string text = "";
                    for (int c = 0; c < dr.FieldCount; c++) {
                        //if(c == authorIndex)  {
                        //    text += splitAuthor;
                        //}
                        //else {
                        text += dr[c].ToString() + "\t";
                        //}
                    }
                    stringBuilder.Append(text + "\r\n");
                }
                else if (mf.rbIRFile.Checked) {  //  tab-delimited file
                    string text = "";
                    for (int c = 0; c < dr.FieldCount; c++) {
                        text += dr[c].ToString() + "\t";
                    }
                    tw1.WriteLine(text + "\r\n");  //   build and write header line
                }
            }
            dr.Close();  //  close the reader (leave the connection open)

            //  we're done, so clean it up...
            if (mf.rbIRPrint.Checked) {
                mf.printDialog3.Document = mf.printDocument3;
                if (mf.printDialog3.ShowDialog() == DialogResult.OK)
                    mf.printDocument3.Print();
            }
            else if (mf.rbIRClipBoard.Checked) {  //  comma-delimited
                Clipboard.SetText(stringBuilder.ToString());
            }
            else if (mf.rbIRFile.Checked) {  //  comma-delimited
                tw1.Flush();  //  flush it...
                tw1.Close();  //  and close it...
            }

            mainForm.chosenSortFields = "";  //  clear out old stuff

            Cursor.Current = Cursors.Default;
            mf.lFinished.Visible = true;
        }


    }
}