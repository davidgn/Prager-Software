
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;


namespace Prager_Book_Inventory
{

    partial class mainForm : Form
    {
        private FbDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
        private FbDataReader dr;
        //private uint Shipping = 0;  //  contains the binary flags to indicate shipping choices
        int rejectedCount = 0;
        static string inclusiveSearchString = "";

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update ONE (1) item in listview panel
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void updateDataBasePanel(string SKU) {
            Cursor.Current = Cursors.WaitCursor;

            if (SKU == null) {
                MessageBox.Show("UpdateDatabasePanel: SKU not set; notify Support using osTicket on Support webpage",
                    "Prager Book Information Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CultureInfo ci = CultureInfo.CurrentCulture;
            NumberFormatInfo nfi = ci.NumberFormat;

            commandString = "SELECT BookNbr, Title, Quantity, ISBN, Locn, Price, Stat, InvoiceNbr FROM tBooks WHERE BookNbr = '" + SKU + "'";
            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();
            FbCommand cmd = new FbCommand(commandString, bookConn);

            dr = cmd.ExecuteReader();

            ListViewItem lvi = dataBasePanel.FindItemWithText(SKU);  //  find the item we were working on...
            int listIndex = lvi.Index;
            dataBasePanel.BeginUpdate();
            while (dr.Read()) {
                dataBasePanel.Items[listIndex].SubItems[1].Text = (string)dr["Title"];
                dataBasePanel.Items[listIndex].SubItems[2].Text = dr["Quantity"].ToString();
                dataBasePanel.Items[listIndex].SubItems[3].Text = (string)dr["ISBN"];
                dataBasePanel.Items[listIndex].SubItems[4].Text = (string)dr["Locn"];

                decimal workingPrice = 0.00M;  //  get price if it's there
                if (!dr.IsDBNull(5))
                    workingPrice = dr.GetDecimal(5);
                else
                    workingPrice = 0.00M;
                dataBasePanel.Items[listIndex].SubItems[5].Text = workingPrice.ToString("##,###.00", nfi);

                dataBasePanel.Items[listIndex].SubItems[6].Text = (string)dr["Stat"];

                if (!dr.IsDBNull(7))
                    dataBasePanel.Items[listIndex].SubItems[7].Text = (string)dr["InvoiceNbr"];
                else
                    dataBasePanel.Items[listIndex].SubItems[7].Text = "";  //  if it's null, then clear it out

                if (dr["Stat"].Equals("Sold"))  //  make items that are sold light grey in color
                    dataBasePanel.Items[listIndex].ForeColor = Color.LightGray;
                else
                    dataBasePanel.Items[listIndex].ForeColor = Color.Black;
            }
            dataBasePanel.EndUpdate();

            if (dataBasePanel.Items.Count > 0)
                dataBasePanel.Items[listIndex].EnsureVisible();  //  make sure next row is visible

            Cursor.Current = Cursors.Default;
            dr.Close();

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    fill database panel
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void fillDataBasePanel(string commandString) {

            Cursor.Current = Cursors.WaitCursor;
            dataBasePanel.Items.Clear();  //  get rid of the other stuff

            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();
            FbCommand cmd = new FbCommand(commandString, bookConn); //   from tBooks where Title NOT LIKE '%'the%'

            dr = cmd.ExecuteReader();

            CultureInfo ci = CultureInfo.CurrentCulture;
            NumberFormatInfo nfi = ci.NumberFormat;

            dataBasePanel.BeginUpdate();
            while (dr.Read()) {
                ListViewItem lvi = new ListViewItem((string)dr["BookNbr"]);

                if (dr["Title"].ToString().Length > 80)
                    lvi.SubItems.Add(dr["Title"].ToString().Substring(0, 80));
                else
                    lvi.SubItems.Add((string)dr["Title"]);

                if (dr["Quantity"].ToString().Length == 0)  // if Qty is blank, default is 0
                    lvi.SubItems.Add("0");
                else
                    lvi.SubItems.Add(dr["Quantity"].ToString());

                lvi.SubItems.Add((string)dr["ISBN"]);

                if (!dr.IsDBNull(4))  //  <--------------------------------- TODO
                    lvi.SubItems.Add((string)dr["Locn"]);

                decimal workingPrice = 0.00M;  //  get price if it's there
                if (!dr.IsDBNull(5))
                    workingPrice = dr.GetDecimal(5);
                else
                    workingPrice = 0.00M;

                lvi.SubItems.Add(workingPrice.ToString("##,###.00", nfi));

                string xx = (string)dr["Stat"];
                lvi.SubItems.Add((string)dr["Stat"]);

                if (!dr.IsDBNull(7))
                    lvi.SubItems.Add((string)dr["InvoiceNbr"]);
                else
                    lvi.SubItems.Add("");

                if (dr["Stat"].Equals("Sold"))  //  make items that are sold light grey in color
                    lvi.SubItems[0].ForeColor = Color.LightGray;

                dataBasePanel.Tag = "Title";
                dataBasePanel.Items.Add(lvi);  // Add the list items to the ListView
            }

            dataBasePanel.EndUpdate();  //  now paint

            if (dataBasePanel.Items.Count > 0)
                dataBasePanel.EnsureVisible(0);   //  set listview to point to first record

            Cursor.Current = Cursors.Default;
            dr.Close();

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create command string
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public string createCommandString() {
            //traceSource.TraceInformation("start: createCommandString");
            //traceSource.Flush();

            if (tsShowForSale.Checked)
                commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr from tBooks where Stat = 'For Sale' ";
            else if (tsShowSold.Checked)
                commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr from tBooks where Stat = 'Sold' ";
            else if (tsShowHold.Checked)
                commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr from tBooks where Stat = 'Hold' ";
            else if (tsShowPending.Checked)
                commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr from tBooks where Stat = 'Pending' ";
            else  //  show all
                commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr from tBooks ";

            if (cbSortOverride.Checked)
                commandString += rbSortAsc.Checked ? "ORDER BY DateA ASC" : "ORDER BY DateA DESC";
            else
                commandString += "ORDER BY BookNbr ASC";  //  ascending is default

            return commandString;

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    does a 'drill down' search of the tBooks
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void drillDownSearch(string whatField, string fieldData) {
            if (fieldData.Length > 0)  //  make sure we have something to search for
            {
                fieldData = fieldData.Replace("'", "''");  //  replace single quote with two of 'em...
                if (tsShowForSale.Checked == true)
                    commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                        " from tBooks where Stat = 'For Sale'  and lower(" + whatField + ") like '" + fieldData.ToLower() + "%'";
                else if (tsShowSold.Checked == true)
                    commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                        " from tBooks where Stat = 'Sold'  and lower(" + whatField + ") like '" + fieldData.ToLower() + "%'";
                else if (tsShowHold.Checked == true)
                    commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                        " from tBooks where Stat = 'Hold' and lower(" + whatField + ") like '" + fieldData.ToLower() + "%'";
                else if (tsShowPending.Checked == true)
                    commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                        " from tBooks where Stat = 'Pending' and lower(" + whatField + ") like '" + fieldData.ToLower() + "%'";
                else  //  show all
                    commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                        " from tBooks where lower(" + whatField + ") like '" + fieldData.ToLower() + "%'";

            }

            fillDataBasePanel(commandString);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    generic search
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void genericSearch(string whatField, string fieldData) {
            string s = "";
            int i = 0;

            if (fieldData.Contains("'"))  //  like L'Amour
                fieldData = fieldData.Replace("'", "''");

            if (fieldData.Contains("*"))  //  we are using the wild card...
            {
                i = fieldData.IndexOf('*');  //  remove the asterisk
                s = fieldData.Replace('*', '%');


                if (tsShowForSale.Checked == true)
                    commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tBooks where Stat = 'For Sale' and lower(" + whatField + ") like '" + s.ToLower() + "%'";
                else if (tsShowSold.Checked == true)
                    commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tBooks where Stat = 'Sold' and lower(" + whatField + ") like '" + s.ToLower() + "%'";
                else if (tsShowHold.Checked == true)
                    commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tBooks where Stat = 'Hold' and lower(" + whatField + ") like '" + s.ToLower() + "%'";
                else if (tsShowPending.Checked == true)
                    commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tBooks where Stat = 'Pending' and lower(" + whatField + ") like '" + s.ToLower() + "%'";
                else
                    commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tBooks where lower(" + whatField + ") like '" + s.ToLower() + "%'";
            }
            else  //  no wild card in data, but cbWildCardSearch was checked
            {
                if (tbsrchBookNbr.Text.Length > 0)
                    commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tBooks where lower(BookNbr) = '" + fieldData.ToLower() + "'";
                else if (tbsrchISBN.Text.Length > 0)
                    commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tBooks where lower(ISBN) = '" + fieldData.ToLower() + "'";
                else if (tbsrchAuthor.Text.Length > 0)
                    commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tBooks where lower(Author) = '" + fieldData.ToLower() + "'";
                else if (tbsrchTitle.Text.Length > 0)
                    commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tBooks where lower(Title) = '" + fieldData.ToLower() + "'";
                else if (tbsrchKeywords.Text.Length > 0)
                    commandString = "select BookNbr, Title, ISBN,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tBooks where lower(Keywds) = '" + fieldData.ToLower() + "'";
            }

            fillDataBasePanel(commandString);

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    populate sql fields from detail panel
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private int PopulateFieldsFromDetailPanel() {

            BookNumber = tbBookNbr.Text;
            Title = tbTitle.Text.Length > 100 ? tbTitle.Text.Substring(0, 100) : tbTitle.Text;
            Author = tbAuthor.Text;
            ISBN = mtbISBN.Text;
            Illustrator = tbIllus.Text;
            Locn = tbLocn.Text;

            int commaIndex = tbListPrice.Text.IndexOf(',');
            if (commaIndex != -1) {
                Price = tbListPrice.Text.Substring(0, commaIndex) + tbListPrice.Text.Substring(commaIndex + 1, tbListPrice.Text.Length - (commaIndex + 1));
            }
            else
                Price = tbListPrice.Text;
            if (tbMyCost.Text == "")  //  cost
                Cost = "1.00";  //  default to $1.00  
            else
                Cost = tbMyCost.Text;


            Publisher = tbPub.Text;
            PubPlace = tbPlace.Text;
            PubYear = tbYear.Text.Length > 4 ? tbYear.Text.Substring(0, 4) : tbYear.Text;

            Description = tbDesc.Text;
            BookNotes = tbBookNotes.Text;
            Notes = tbNotes.Text;
            Keywords = tbKeywords.Text;
            Catalog = tbPriCatalog.Text;
            SubCategory = tbSecCatalog.Text;
            ImageFileName = tbImageURL.Text;  //  image URL

            //  jacket
            if (coJacket.Text != "")
                Jacket = coJacket.Text;
            else if (cbWarnNoDJ.Checked == true) {
                if (MessageBox.Show("Jacket is missing; continue anyway?", "Prager Book Inventory Manager", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.No)
                    return -1;
            }

            //  binding
            BookBinding = coBinding.Text;

            //  condition
            if (coCondition.Text.Length != 0)  //  combo box empty?
                if (coType.Text != "Ex-Library")
                    Condition = coCondition.Text;
                else  //  condition is ex-lib
                {
                    if (coCondition.Text.Contains("Fine") || coCondition.Text.Contains("Very Good") || coCondition.Text.Contains("New"))
                        Condition = "Good";  //  can't have a condition other than Good with Ex-Lib books
                    else
                        Condition = coCondition.Text;
                }

            //  type
            if (coType.Text.Length > 0 && coType.SelectedIndex != -1)
                BookType = coType.Text;
            else
                BookType = "";

            //  edition
            if (coEdition.Text != "")
                Edition = coEdition.Text.Length > 15 ? coEdition.Text.Substring(0, 15) : coEdition.Text;
            else
                Edition = "";

            //  status
            if (cbStatusHold.Checked == true && int.Parse(tbCopies.Text) > 0)
                Status = "Hold";
            else if (int.Parse(tbCopies.Text) == 0)
                Status = "Sold";
            else
                Status = "For Sale";

            //  signed
            SignedBy = " ";
            if (cbAuthorSigned.Checked == true && cbIllusSigned.Checked == true)
                SignedBy = "B";
            else {
                if (cbAuthorSigned.Checked == true)
                    SignedBy = "A";
                else {
                    if (cbIllusSigned.Checked == true)
                        SignedBy = "I";
                }
            }

            //  size
            if (coSize.Text.Length > 0)
                BookSize = coSize.Text;
            else
                BookSize = " ";

            //  shipping 
            Shipping = 0;  //  reset it...
            Shipping += cbDomStd.Checked ? (byte)32 : (byte)0;
            Shipping += cbDomExp.Checked ? (byte)16 : (byte)0;
            Shipping += cb2dDom.Checked ? (byte)8 : (byte)0;
            Shipping += cb1dDom.Checked ? (byte)4 : (byte)0;
            Shipping += cbIntlStd.Checked ? (byte)2 : (byte)0;
            Shipping += cbIntlExp.Checked ? (byte)1 : (byte)0;
            Shipping = Shipping == 0 ? 32 : Shipping;  //  if it's zero, set to Domestic Std as default

            NbrOfPages = tbPages.Text;
            BookWeight = tbWeight.Text;
            Quantity = int.Parse(tbCopies.Text);
            Volume = tbVolume.Text;  //  (11.5.0)

            return (0);
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    add book to database  (called from bAddRecord_Click)
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void addRecord() {
            int rc = 0;  //  return code from addBooks

            if (cbAllowAddUpdate.Checked == false)  //  check for required fields?
            {
                if (checkForRequiredFields() == -1)  //  some fields are missing...
                {
                    //bAddRecord.Enabled = false;  //  disable Add button
                    return;
                }
                else
                    bAddRecord.Enabled = true;  // otherwise, make sure it's enabled
            }

            if (PopulateFieldsFromDetailPanel() != 0)  //  if we had any errors, return without adding book  <----------------------- ????????  TODO
                return;

            if (tbCopies.Text.Length == 0) {
                MessageBox.Show("Quantity is missing", "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                Quantity = int.Parse(tbCopies.Text);

            if (cbAutomaticSKU.Checked == true) {  //  if we are doing auto-numbering...
                Int64 lastKey = findHighestBookNbr();
                lastKey = lastKey + 1;
                tbBookNbr.Text = lastKey.ToString();  //  pad w/ zeros
                BookNumber = lastKey.ToString();
            }
            else {  // user has to supply book number
                if (tbBookNbr.Text.Length == 0) {
                    MessageBox.Show("Book number is missing", "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            addButtonClicked = true;
            rc = tBooksAddBook();

            resetStrings();  //  clear out old stuff

            fillDataBasePanel(createCommandString());

            backupNeeded = true;

            if (rc == 0)  //  only clear if we didn't have an error...
                clearDetailPanel(false);  //  clear the old stuff (not doing an update)

            mtbISBN.Text = "";
            mtbISBN.Focus();  //  ISBN entry has focus

            lbPricingResults.Items.Clear();
            lbPricingResults.Refresh();
            lbPrice.Items.Clear();
            lbPrice.Refresh();
            lbCondn.Items.Clear();
            lbCondn.Refresh();
            lListPrice.Text = "List Price:";  //  clear old price
            lListPrice.Refresh();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    add a book to the table  (called from the import routines)
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private int tBooksAddBook() {

            //  If we are doing an add from an import, then the lastExport date should be less 
            //  than today to prevent this being added to records to be exported.
            TimeSpan oneMinute = TimeSpan.FromMinutes(1);
            DateTime tempDate;

            //if (addButtonClicked == false && cbFlag4Exporting.Checked == false)  //  this is an update
            if (addButtonClicked == false) {  //  this is an update  (11.1.0)
                if (lastExport.Equals(DateTime.MinValue))
                    lastExport = DateTime.Now;
                tempDate = lastExport.Subtract(TimeSpan.FromMinutes(1));
            }
            else  //  add button was clicked or flag was set, so we want to mark book for export
                tempDate = DateTime.Now.Add(oneMinute);

            //  bullet proofing...
            string tempDescr = "";
            if (Description != null) {
                tempDescr = Regex.Replace(Description, @"[\r\n]", " ");
                tempDescr = Regex.Replace(tempDescr, @"[']", "''");      //  replace single quotes with two of them...
            }
            //  replace single quotes with double
            if (Title != null)
                Title = Regex.Replace(Title, @"[']", "''");
            if (Author != null)
                Author = Regex.Replace(Author, @"[']", "''");
            if (Illustrator != null)
                Illustrator = Regex.Replace(Illustrator, @"[']", "''");
            if (Publisher != null)
                Publisher = Regex.Replace(Publisher, @"[']", "''");
            if (Keywords != null)
                Keywords = Regex.Replace(Keywords, @"[']", "''");
            if (Catalog != null)
                Catalog = Regex.Replace(Catalog, @"[']", "''");
            if (Notes != null)
                Notes = Regex.Replace(Notes, @"[']", "''");
            if (BookType != null)
                BookType = Regex.Replace(BookType, @"[']", "''");
            if (BookBinding != null)
                BookBinding = Regex.Replace(BookBinding, @"[']", "''");
            if (PubPlace != null)
                PubPlace = Regex.Replace(PubPlace, @"[']", "''");

            if (DateAdded == null || DateAdded.ToString().Length < 8) {
                //DateAdded = DateTime.Now.ToString("g");  //  11:32 AM
                DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //DateAdded = Regex.Replace(DateAdded, "AM|PM|a.m.|p.m.", "");
                DateUpdated = DateAdded;  //  indicates book was just added
            }

            //  remove double quotes too...  (13.0.2)
            Description = Description.Replace("\"", "''");
            Author = Author.Replace("\"", "''");
            Illustrator = Illustrator.Replace("\"", "''");
            Title = Title.Replace("\"", "''");
            Publisher = Publisher.Replace("\"", "''");
            PubPlace = PubPlace == null? "": PubPlace.Replace("\"", "''");
            Keywords = Keywords == null? "": Keywords.Replace("\"", "''").TrimEnd();
            Catalog = Catalog == null? "": Catalog.Replace("\"", "''");
            Notes = Notes == null? "": Notes.Replace("\"", "''");
            BookNotes = BookNotes == null ? "" : BookNotes.Replace("\"", "''");
            Locn = Locn.Replace("\"", "''");

            Cost = Cost.Replace("\r\n", "");
            Price = Price.Replace("\r\n", "");
            Cost = (Cost.IndexOf('.') == -1) ? Cost + ".00" : Cost;
            Price = (Price.IndexOf('.') == -1) ? Price + ".00" : Price;

            CultureInfo ci = CultureInfo.CurrentCulture;
            NumberFormatInfo nfi = ci.NumberFormat;

            string firstChar = Price.Substring(0, 1);  //  get first character
            if (!IsNumeric(firstChar))
                Price = Price.Remove(0, 1);
            firstChar = Cost.Substring(0, 1);  //  get first character
            if (!IsNumeric(firstChar))
                Cost = Cost.Remove(0, 1);
            decimal decPrice = decimal.Parse(Price, nfi);
            decimal decCost = decimal.Parse(Cost, nfi);

            if (coType.SelectedIndex == -1 || coType.Text.Length == 0)
                BookType = "";
            if (coEdition.SelectedIndex == -1 || coEdition.Text.Length == 0)
                Edition = "";

            //  shipping
            Shipping = 0;  //  reset it...
            Shipping += cbDomStd.Checked ? (byte)32 : (byte)0;
            Shipping += cbDomExp.Checked ? (byte)16 : (byte)0;
            Shipping += cb2dDom.Checked ? (byte)8 : (byte)0;
            Shipping += cb1dDom.Checked ? (byte)4 : (byte)0;
            Shipping += cbIntlStd.Checked ? (byte)2 : (byte)0;
            Shipping += cbIntlExp.Checked ? (byte)1 : (byte)0;
            Shipping = Shipping == 0 ? 32 : Shipping;  //  if it's zero, set to Domestic Std as default

            char TranC = 'A';  //  this is an Add

            string DoNotReprice = "";
            if (cbDoNotReprice.Checked == true)
                DoNotReprice = "T";
            else
                DoNotReprice = "F";

            string expediteShip = " ";
            string intlShip = " ";

            String insertString =
                "insert into tBooks (BookNbr, Title, Author, ISBN, Illus, Locn, Price, Ed, Signed, Cost, TranC, Pub, PubPlace," +
                "PubYear, Descr, bookSize, Notes, Keywds, Jaket, Bndg, bookType, Condn, ExpediteShip, IntlShip, DateA, DateU, Cat, " +
                " SubCategory, Stat, " + "DoNotReprice, NbrOfPages, BookWeight, ImageFileName, NbrOfCopies, Shipping, Volume, Quantity, BookNotes) " +

                " values ('" + BookNumber + "', '" + Title + "', '" + Author + "', '" + ISBN + "', '" + Illustrator +
                "', '" + Locn + "', '" + decPrice + "', '" + Edition.Trim() + "', '" + SignedBy + "', '" + decCost +
                "', '" + TranC + "', '" + Publisher + "', '" + PubPlace + "', '" + PubYear + "', '" + tempDescr +
                "', '" + BookSize + "', '" + Notes + "', '" + Keywords.Trim() + "', '" + Jacket + "', '" + BookBinding +
                "', '" + BookType + "', '" + Condition + "', '" + expediteShip + "', '" + intlShip + "', '" + DateAdded +
                "', '" + DateUpdated + "', '" + Catalog + "', '" + SubCategory + "', '" + Status + "', '" + DoNotReprice +
                "', '" + NbrOfPages + "', '" + BookWeight + "', '" + ImageFileName + "', '" + DBNull.Value + "', '" + Shipping +
                "', '" + Volume + "', '" + Quantity + "', '" + BookNotes + "')";

            FbCommand cmd = new FbCommand(insertString, bookConn);

            try {
                if (bookConn.State == ConnectionState.Closed)
                    bookConn.Open();

                cmd.ExecuteNonQuery();
            }

            catch (FbException ex) {

                if (ex.Message.Length > 36) {
                    if ((rbRejectRecord.Checked == true && addButtonClicked == false) && ex.Message.Substring(0, 40) == "String or binary data would be truncated") {
                        lbRejectedRecords.Items.Add(BookNumber + ": Data too long");
                        lbRejectedRecords.Refresh();
                        lRecordsRejected.Text = "Records rejected: " + ++rejectedCount;
                        lRecordsRejected.Refresh();
                        return -1;
                    }

                    if (ex.Message.Substring(0, 42).ToLower().Contains("arithmetic exception, numeric overflow,")) {
                        lbRejectedRecords.Items.Add(BookNumber + ": invalid numeric field");
                        lbRejectedRecords.Refresh();

                        lRecordsRejected.Text = "Records rejected: " + ++rejectedCount;
                        lRecordsRejected.Refresh();
                        return -1;
                    }

                    if (ex.Message.Substring(0, 34).Contains("violation of PRIMARY or UNIQUE KEY") && addButtonClicked == false) {
                        if (rbCreateNewKey.Checked == true) { //  do they want us to create a new SKU?
                            Int64 lastKey = findHighestBookNbr();
                            lastKey++;
                            BookNumber = lastKey.ToString();

                            tBooksAddBook();  //  try it again...
                            return 0;
                        }
                        else if (rbReplaceRecord.Checked == true) { //  replace the record on duplicate SKU?
                            string fbUpdateString = @"UPDATE tBooks SET " + "Title = '" + Title + "', Author = '" + Author + "', ISBN = '" + ISBN +
                                "', Illus = '" + Illustrator + "', Locn = '" + Locn + "', Price = '" + decPrice + "', Ed = '" + Edition.Trim() + "', Signed = '" + SignedBy +
                                "', Cost = '" + decCost + "', TranC = 'A" + "', Pub = '" + Publisher + "', PubPlace = '" + PubPlace + "', PubYear = '" + PubYear +
                                "', Descr = '" + tempDescr + "', bookSize = '" + BookSize + "', Notes = '" + Notes + "', Keywds = '" + Keywords.Trim() +
                                "', Jaket = '" + Jacket + "', Bndg = '" + BookBinding + "', bookType = '" + BookType + "', Condn = '" + Condition +
                                "', DateA = '" + DateAdded + "', DateU = '" + DateUpdated + "', Cat = '" + Catalog + "', Stat = '" + Status +
                                "', DoNotReprice = '" + DoNotReprice + "', NbrOfPages = '" + NbrOfPages + "', BookWeight = '" + BookWeight +
                                "', ImageFileName = '" + ImageFileName + "', NbrOfCopies = '" + DBNull.Value + "', Shipping = '" + Shipping +
                                "', Volume = '" + Volume + "', Quantity = '" + Quantity + "', BookNotes = '" + BookNotes +
                                 "' WHERE BookNbr = '" + BookNumber + "'";

                            cmd.CommandText = fbUpdateString;
                            cmd.Connection = mainForm.bookConn;
                            cmd.ExecuteNonQuery();
                        }
                        else { //  no, reject the book
                            lbRejectedRecords.Items.Add(BookNumber + ": duplicate SKU (BookNbr)");
                            lbRejectedRecords.Refresh();
                            lRecordsRejected.Text = "Records rejected: " + ++rejectedCount;
                            lRecordsRejected.Refresh();

                            return -2;
                        }
                        //}
                    }
                }

            }

            cmd.Dispose();

            //  move book number (SKU) to XML file as last used  <-------------------------TODO  
            return 0;

        }



        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    find highest book number
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public Int64 findHighestBookNbr() {

            //  get all of the book numbers and place them in an array
            ArrayList al = new ArrayList();
            commandString = "select BookNbr from tBooks";

            FbDataReader rdr = null;
            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();
            FbCommand cmd = new FbCommand(commandString, bookConn);
            rdr = cmd.ExecuteReader();

            while (rdr.Read()) {
                if (IsInteger(rdr[0]))
                    al.Add(Int64.Parse((string)rdr[0]));
            }

            if (al.Count == 0 && cbAutomaticSKU.Checked == true)  //  if first time and they forgot to put in a starting SKU
                return 0;

            //  now find the highest numeric BookNbr in the array and return it as int64
            al.Sort();
            Int64 debugInt = (Int64)al[al.Count - 1];
            cmd.Dispose();

            return (Int64)al[al.Count - 1];

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update books table
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int tBooksUpdateRecord() {
            //  update keywords if empty and still for sale
            if (cbCreateKeywords.Checked && tbKeywords.Text.Length < 4 && int.Parse(tbCopies.Text) > 0)
                Keywords = parseKeywords(tbTitle.Text);

            if (PopulateFieldsFromDetailPanel() == 0) {
                DateTime tempDateTime = DateTime.Now;  //  date/time updated
                string newDateTime = tempDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                int x = Keywords.Length;
                string y = Keywords;

                //  remove single quotes
                Description = Description.Replace("'", "''");
                Author = Author.Replace("'", "''");
                Illustrator = Illustrator.Replace("'", "''");
                Title = Title.Replace("'", "''");
                Publisher = Publisher.Replace("'", "''");
                PubPlace = PubPlace.Replace("'", "''");
                Keywords = Keywords.Replace("'", "''").TrimEnd();
                Catalog = Catalog.Replace("'", "''");
                Notes = Notes.Replace("'", "''");
                Locn = Locn.Replace("'", "''");

                //  remove double quotes too...  (13.0.2)
                Description = Description.Replace("\"", "''");
                Author = Author.Replace("\"", "''");
                Illustrator = Illustrator.Replace("\"", "''");
                Title = Title.Replace("\"", "''");
                Publisher = Publisher.Replace("\"", "''");
                PubPlace = PubPlace.Replace("\"", "''");
                Keywords = Keywords.Replace("\"", "''").TrimEnd();
                Catalog = Catalog.Replace("\"", "''");
                Notes = Notes.Replace("\"", "''");
                Locn = Locn.Replace("\"", "''");


                Keywords = Keywords.Length > 85 ? Keywords.Substring(0, 85) : Keywords;

                if (Price.Length > 0) {
                    //  string firstChar = Price.Substring(0, 1);  //  get first character
                    if (!IsNumeric(Price.Substring(0, 1)))
                        Price = Price.Remove(0, 1);
                }
                else
                    Price = "0.00";

                if (Cost.Length > 0) {
                    if (!IsNumeric(Cost.Substring(0, 1))) {
                        if (Cost.StartsWith("$"))  //  remove $ just in case
                            Cost = Cost.Remove(0, 1);
                    }
                }

                Regex.Replace(Description, @"[\r\n]", " ");
                string DoNotReprice = "";
                if (cbDoNotReprice.Checked == true)
                    DoNotReprice = "T";
                else
                    DoNotReprice = "F";

                CultureInfo ci = CultureInfo.CurrentCulture;
                NumberFormatInfo nfi = ci.NumberFormat;

                string updateString = @"UPDATE tBooks SET Title = '" + Title + "', Author = '" + Author +
                    "', ISBN = '" + ISBN + "', Illus = '" + Illustrator + "', Locn = '" + Locn + "', Price = '" + Price.Replace(nfi.CurrencyDecimalSeparator, ".") +
                    "', Ed = '" + Edition + "', Signed = '" + SignedBy + "', Cost = '" + Cost.Replace(nfi.CurrencyDecimalSeparator, ".") + "', TranC = 'U" +
                    "', Pub = '" + Publisher + "', PubPlace = '" + PubPlace + "', PubYear = '" + PubYear + "', Descr = '" + Description +
                    "', bookSize = '" + BookSize + "', Notes = '" + Notes + "', Keywds = '" + Keywords.Trim() + "', Jaket = '" + Jacket +
                    "', Bndg = '" + BookBinding + "', bookType = '" + BookType + "', Condn = '" + Condition + "', DateU = '" + newDateTime +
                    "', Cat = '" + Catalog + "', SubCategory = '" + SubCategory + "', Stat = '" + Status +
                    "', DoNotReprice = '" + DoNotReprice + "', NbrOfPages = '" + NbrOfPages + "', BookWeight = '" + BookWeight +
                    "', ImageFileName = '" + ImageFileName + "', NbrOfCopies = '" + DBNull.Value + "', Shipping = '" + Shipping +
                    "', Volume = '" + Volume + "', Quantity = '" + Quantity + "', BookNotes = '" + BookNotes +
                    "' WHERE BookNbr = '" + tbBookNbr.Text + "'";
                try {
                    FbCommand cmd = new FbCommand(updateString);
                    cmd.Connection = bookConn;
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (FbException ex) {

                    lbStatus.ForeColor = Color.Red;
                    lbStatus.Refresh();
                    lbStatus.Items.Insert(0, "Record rejected during update: Book Nbr=" + BookNumber + " ISBN=" + ISBN + " " + ex.Message);
                    lbStatus.ForeColor = Color.Black;
                    lbStatus.Refresh();

                    lRecordsRejected.Text = "Records rejected: " + ++rejectedCount;
                    lRecordsRejected.Refresh();
                    tabTaskPanel.SelectedIndex = cStatus;  //  show log

                    return -1;
                }

                tbsrchAuthor.Text = "";  //  clear the search text boxes
                tbsrchBookNbr.Text = "";
                tbsrchISBN.Text = "";
                tbsrchTitle.Text = "";

                if (cbFreezeDBPanel.Checked == false && tbBookNbr.Text.Length > 0)  //  OK to refresh the database panel?
                    updateDataBasePanel(tbBookNbr.Text);  //  refresh database panel (send SKU)
            }

            return 0;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update counters
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void updateCounters() {

            CultureInfo ci = System.Globalization.CultureInfo.CurrentCulture;  //  Thread.CurrentThread.CurrentCulture;  
            string lastExportDate = lastExport.ToString("MM/dd/yyyy HH:mm:ss", ci);
            lastExportDate = Regex.Replace(lastExportDate, "AM|PM|a.m.|p.m.", "");

            if (lastExport.ToString("mm-dd-yyyy").Substring(0, 10) == "01/01/0001")  //  nothing was exported...
                return;

            commandString = "select COUNT(*) from tBooks where Stat != 'Hold' and DateU > '" + lastExportDate.Trim() + "'";
            int bookCount = 0;

            try {
                if (bookConn.State == ConnectionState.Closed)
                    bookConn.Open();
                FbCommand cmd = new FbCommand(commandString, bookConn);

                bookCount = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex) {
                if (ex.Message.Contains("Error reading data from the connection"))
                    MessageBox.Show("Unable to reach database; check your client/server", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            lBooksWaiting.Text = bookCount.ToString() + " books waiting to be exported";  //  on import/export tab
            lBooksWaiting.Refresh();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    checks for required fields
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private int checkForRequiredFields() {
            if (tbCopies.Text.Length == 0) {
                MessageBox.Show("Quantity is missing", "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (int.Parse(tbCopies.Text) == 0)  //  if we are marking book Sold, don't check any further
                return 0;

            if (int.Parse(tbCopies.Text) > 0) {
                if (tbBookNbr.Text.Length == 0 && cbAutomaticSKU.Checked == false) {
                    MessageBox.Show("You are missing the SKU and do not have Automatic SKU Numbering checked", "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }

                if (tbTitle.Text.Length == 0) {
                    MessageBox.Show("Title is missing", "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!cbAllowAddUpdate.Checked)
                        return -1;
                }
                if (tbAuthor.Text.Length == 0) {
                    MessageBox.Show("Author is missing", "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!cbAllowAddUpdate.Checked)
                        return -1;
                }
                if (tbListPrice.Text.Length == 0) {
                    MessageBox.Show("Price is missing", "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!cbAllowAddUpdate.Checked)
                        return -1;
                }
                if (tbPub.Text.Length == 0) {
                    MessageBox.Show("Publisher is missing", "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!cbAllowAddUpdate.Checked)
                        return -1;
                }
                if (coBinding.Text.Length == 0) {
                    MessageBox.Show("Binding missing", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!cbAllowAddUpdate.Checked)
                        return -1;
                }
                if (coCondition.Text.Length == 0) {
                    MessageBox.Show("Condition is missing", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!cbAllowAddUpdate.Checked)
                        return -1;
                }

                DialogResult dg = DialogResult.None;  //  initialize

                if (cbWarnNoCatalog.Checked == true && tbPriCatalog.Text.Length == 0) {
                    dg = MessageBox.Show("Catalog entry is missing; do you want to continue anyway?", "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dg == DialogResult.No)
                        return -1;
                }

                if (cbWarnNoLocation.Checked == true && tbLocn.Text.Length == 0) {
                    dg = MessageBox.Show("Location entry is missing; do you want to continue anyway?", "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dg == DialogResult.No)
                        return -1;
                }

            }

            return 0;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    delete book entry from table
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private int tBookDeleteEntry(string bookNumber) {
            commandString = "DELETE FROM tBooks where BookNbr = '" + bookNumber + "'";
            sqlCmd = new FbCommand(commandString, bookConn);

            DialogResult dg = DialogResult.None;  //  initialize
            if (cbVerifyDeletes.Checked == true)
                dg = MessageBox.Show("READ THIS!  IF this book is listed on any venues, you MUST mark it as Sold, export it" + 
                    "and upload the exported file before you can delete it from the database.  \n\nAre you sure you want" +
                    " to delete this record?", "Verify Deletion", MessageBoxButtons.YesNoCancel);

            if (dg == DialogResult.Yes || cbVerifyDeletes.Checked == false) {
                try {
                    if (bookConn.State == ConnectionState.Closed)
                        bookConn.Open();

                    sqlCmd.ExecuteNonQuery();
                }
                catch (System.Exception ex) {
                    MessageBox.Show("Error deleting record " + bookNumber + "\r" + ex.Message);
                }
                finally {
                    Cursor.Current = Cursors.Default;
                }
            }
            else if (dg == DialogResult.Cancel)
                return -1;

            return 0;

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    relist a book
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void relistBook() {
            if (!statusForSale && int.Parse(tbCopies.Text) == 0)  //  only do this if book is marked Sold and quantity is zero
            {
                if (cbAutomaticSKU.Checked == true)  //  if we are doing auto-numbering...
                {
                    Int64 lastKey = findHighestBookNbr();
                    lastKey = lastKey + 1;
                    tbBookNbr.Text = lastKey.ToString();  //  pad w/ zeros
                    BookNumber = lastKey.ToString();
                }
                else  // user has to supply book number
                {
                    tbBookNbr.Enabled = true;  //  enable entering new book number
                    if (tbBookNbr.Text.Length == 0) {
                        MessageBox.Show("Book number is missing", "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                int rc = PopulateFieldsFromDetailPanel();
                if (rc == 0) {
                    Quantity = 1;  //  override 
                    Status = "For Sale";
                    addButtonClicked = true;
                    tBooksAddBook();
                }

                resetStrings();  //  clear out old stuff

                createCommandString();
                fillDataBasePanel(commandString);  //  fill the listview panel

                backupNeeded = true;

                clearDetailPanel(true);  //  clear the old stuff (can do an update)
                mtbISBN.Focus();  //  ISBN entry has focus

                lbPricingResults.Items.Clear();
                lbPricingResults.Refresh();
                lbPrice.Items.Clear();
                lbPrice.Refresh();
                lbCondn.Items.Clear();
                lbCondn.Refresh();
                lListPrice.Text = "List Price:";  //  clear old price
                lListPrice.Refresh();
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update book statistics
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void updateBookStatistics() {
            Cursor.Current = Cursors.WaitCursor;
            string currentYear = null;

            if (lbAcctgYear.SelectedIndex.Equals(-1))
                currentYear = DateTime.Today.Year.ToString();
            else
                currentYear = lbAcctgYear.SelectedItem.ToString();

            //  database statistics
            string selectStatement = "select sum(Quantity) from tBooks WHERE Stat <> 'Sold'";
            //string selectStatement = "select sum(Quantity) from tBooks";
            FbCommand cmd = new FbCommand(selectStatement, bookConn);
            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();
            object result = cmd.ExecuteScalar();
            int Count = (result == DBNull.Value ? 0 : Convert.ToInt32(result));
            lblTotalCount.Text = "Total In Inventory:    " + Count.ToString();

            selectStatement = "select sum(Quantity) from tBooks where Stat = 'For Sale'";
            //selectStatement = "select sum(Quantity) from tBooks where Stat = 'For Sale'";
            cmd = new FbCommand(selectStatement, bookConn);
            int forSaleCount = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            lblSaleCount.Text = "For Sale:    " + forSaleCount.ToString();

            selectStatement = "select COUNT(*) from tBooks where Stat = 'Sold'";
            cmd = new FbCommand(selectStatement, bookConn);
            //Count = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            Count = (result == DBNull.Value ? 0 : Convert.ToInt32(result));
            lblSoldCount.Text = "Sold:    " + Count.ToString();

            selectStatement = "select COUNT(*) from tBooks where Stat = 'Pending'";
            cmd = new FbCommand(selectStatement, bookConn);
            //Count = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            Count = (result == DBNull.Value ? 0 : Convert.ToInt32(result));
            lblPendingCount.Text = "Pending:    " + Count.ToString();

            selectStatement = "select coalesce(count(Quantity),0) from tBooks where Stat = 'Hold'";
            cmd = new FbCommand(selectStatement, bookConn);
            //Count = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            //Count = (result == DBNull.Value ? 0 : Convert.ToInt32(result));
            result = cmd.ExecuteScalar();
            Count = (result == DBNull.Value ? 0 : Convert.ToInt32(result));
            lblHoldCount.Text = "Hold:    " + Count.ToString();

            //  total inventory cost  
            selectStatement = "select sum(Cost) from tBooks where Stat = 'For Sale'";
            cmd = new FbCommand(selectStatement, bookConn);
            //decimal tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            decimal tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblTotalCost.Text = "Total Inventory Cost:    " + String.Format("{0:c}", tempDollars);

            //  total value
            selectStatement = "select sum(Price * Quantity) as totalValue from tBooks where Stat = 'For Sale' ";
            cmd = new FbCommand(selectStatement, bookConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblTotalValue.Text = "Total Inventory Value:    " + String.Format("{0:c}", tempDollars);

            //  1st quarter sales figures
            selectStatement = @"select SUM(Price) from tBooks where Stat = 'Sold' and extract(month from DateU) >= 1 " +
                "and extract(month from DateU) <= 3 and extract(year from DateU) = " + currentYear;
            cmd = new FbCommand(selectStatement, bookConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblQtr1Sales.Text = @"1st Qtr:    " + String.Format("{0:c}", tempDollars);

            //  2nd quarter sales figures
            selectStatement = @"select SUM(Price) from tBooks where Stat = 'Sold' and extract(month from DateU) >= 4 " +
                "and extract(month from DateU) <= 6 and extract(year from DateU) = " + currentYear;
            cmd = new FbCommand(selectStatement, bookConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblQtr2Sales.Text = @"2nd Qtr:    " + String.Format("{0:c}", tempDollars);

            //  3rd quarter sales figures
            selectStatement = @"select sum(Price) from tBooks where Stat = 'Sold' and extract(month from DateU) >= 7 " +
                "and extract(month from DateU) <= 9 and extract(year from DateU) = " + currentYear;
            cmd = new FbCommand(selectStatement, bookConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblQtr3Sales.Text = @"3nd Qtr:    " + String.Format("{0:c}", tempDollars);

            //  4th quarter sales figures
            selectStatement = @"select sum(Price) from tBooks where Stat = 'Sold' and extract(month from DateU) >= 10 " +
                "and extract(month from DateU) <= 12 and extract(year from DateU) = " + currentYear;
            cmd = new FbCommand(selectStatement, bookConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblQtr4Sales.Text = @"4th Qtr:    " + String.Format("{0:c}", tempDollars);

            //  ytd sales figures
            selectStatement = "select sum(Price) from tBooks where Stat = 'Sold' " +
                "and extract(year from DateU) = '" + currentYear + "'";
            cmd = new FbCommand(selectStatement, bookConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblTotalYTD.Text = @"Total Sales YTD:    " + String.Format("{0:c}", tempDollars);

            //  1st Q cost of goods figures
            selectStatement = @"select sum(Cost) from tBooks where extract(month from DateU) >= 1 " +
                "and extract(month from DateU) <= 3 and extract(year from DateA) = " + currentYear;
            cmd = new FbCommand(selectStatement, bookConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblCOG1.Text = @"1st Qtr:    " + String.Format("{0:c}", tempDollars);

            //  2nd Q cost of goods figures
            selectStatement = @"select sum(Cost) from tBooks where extract(month from DateU) >= 3 " +
                "and extract(month from DateU) <= 6 and extract(year from DateA) = " + currentYear;
            cmd = new FbCommand(selectStatement, bookConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblCOG2.Text = @"2nd Qtr:    " + String.Format("{0:c}", tempDollars);


            //  3rd Q cost of goods figures
            selectStatement = @"select sum(Cost) from tBooks where extract(month from DateU) >= 7 " +
                "and extract(month from DateU) <= 9 and extract(year from DateA) = " + currentYear;
            cmd = new FbCommand(selectStatement, bookConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblCOG3.Text = @"3rd Qtr:    " + String.Format("{0:c}", tempDollars);

            //  4th Q cost of goods figures
            selectStatement = @"select sum(Cost) from tBooks where extract(month from DateU) >= 10 " +
                "and extract(month from DateU) <= 12 and extract(year from DateA) = " + currentYear;
            cmd = new FbCommand(selectStatement, bookConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblCOG4.Text = @"4th Qtr:    " + String.Format("{0:c}", tempDollars);


            //  ytd CostofGoods figures
            selectStatement = "select sum(Cost) from tBooks where extract(year from DateA) = '" + currentYear + "'";
            cmd = new FbCommand(selectStatement, bookConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblTotalCostofGoods.Text = @"Total Cost YTD:    " + String.Format("{0:c}", tempDollars);

            Cursor.Current = Cursors.Default;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    using T-SQL statements, change prices in d/b
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void changePrices() {
            //string commandString = "";

            //  do some error checking
            if (rbAmount.Checked == false && rbPercentage.Checked == false && rbAbsolute.Checked == false) {
                MessageBox.Show("You must check either Amount, Percentage or Absolute Amount", "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else {
                if (tbAmount.Text.Length == 0) {
                    MessageBox.Show("You must enter either an amount or percentage", "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Cursor.Current = Cursors.WaitCursor;

            lbStatus.Items.Insert(0, "started changing prices");
            lbStatus.Refresh();

            DateTime newDateTime = DateTime.Now;

            //  determine what we are going to change
            if (rbAll.Checked == true)  //  are we are going to price all of them?
                commandString = "select * from tBooks where Stat = 'For Sale'";
            else {
                if (rbPriceRange.Checked == true)  //  or are we going to do a range?
                {
                    if (tbPriceFrom.Text == " " || tbPriceTo.Text == " ") {
                        MessageBox.Show("Price From and/or Price To are invalid", "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        commandString = @"select * from tBooks where Stat = 'For Sale' and
                             Price >= '" + tbPriceFrom.Text + @"' and Price <= '" + tbPriceTo.Text + "'";
                }  //  end range
                else {
                    if (rbCatalog.Checked == true) {
                        if (lbChangePricesCat.SelectedIndex != 0) {
                            commandString = @"select * from tBooks where Stat = 'For Sale' and Cat = '" +
                               lbChangePricesCat.Text + "'";
                        }
                    }
                    else {
                        if (rbBookNbr.Checked == true)  //  do a range of book numbers
                        {
                            commandString = @"select * from tBooks where Stat = 'For Sale' " +
                                "and BookNbr >= '" + tbBkNbrFrom.Text + "' and BookNbr <= '" + tbBkNbrTo.Text + "'";

                        }
                    }

                }
            }

            dataAdapter = new FbDataAdapter(commandString, bookConn);
            dataSet = new DataSet();  //  create a new dataset
            dataAdapter.Fill(dataSet, "tBooks");  //  fill the dataset from rows in the Table
            dataTable = dataSet.Tables[0];  //  pick out my table from tBooks

            FbCommandBuilder commandBuilder = new FbCommandBuilder(dataAdapter);  //  <------------- REMOVE????

            decimal amount;
            decimal decimalAmt = 0.00M;
            decimal one = 1.00M;
            decimal pctg = Convert.ToDecimal(tbAmount.Text) / 100;

            if (rbIncrease.Checked == true)  //  increase prices...
            {
                pctg = decimal.Add(pctg, one);
                foreach (DataRow dataRow in dataTable.Rows) {
                    amount = decimal.Parse(dataRow["Price"].ToString());  //  get the price to update

                    if (rbAmount.Checked == true)  //  update by amount
                        amount += decimal.Parse(tbAmount.Text.ToString());
                    else  //  update by percentage
                    {
                        decimalAmt = amount;
                        amount = Math.Round(decimalAmt * pctg, 2);
                    }
                    int rowIndex = dataTable.Rows.IndexOf(dataRow);
                    dataSet.Tables["tBooks"].Rows[rowIndex]["Price"] = amount.ToString();
                    dataSet.Tables["tBooks"].Rows[rowIndex]["DateU"] = newDateTime;  //  updated now...
                    amount = 0;  //  clear it
                }
            }
            else  //  decrease prices?
            {
                if (rbDecrease.Checked == true) {
                    pctg = decimal.Subtract(one, pctg);
                    foreach (DataRow dataRow in dataTable.Rows) {
                        amount = decimal.Parse(dataRow["Price"].ToString());  //  get the price to update

                        if (rbAmount.Checked == true)  //  update by amount
                            amount -= decimal.Parse(tbAmount.Text.ToString());
                        else  //  update by percentage
                        {
                            decimalAmt = amount;
                            amount = Math.Round(decimalAmt * pctg, 2);
                        }

                        int rowIndex = dataTable.Rows.IndexOf(dataRow);
                        dataSet.Tables["tBooks"].Rows[rowIndex]["Price"] = amount.ToString();
                        dataSet.Tables["tBooks"].Rows[rowIndex]["DateU"] = newDateTime;  //  updated now...
                        amount = 0;
                    }
                }  //  end decrease
                else //  must be absolute
                {
                    foreach (DataRow dataRow in dataTable.Rows) {
                        int rowIndex = dataTable.Rows.IndexOf(dataRow);
                        amount = Decimal.Parse(tbAmount.Text);
                        dataSet.Tables["tBooks"].Rows[rowIndex]["Price"] = amount.ToString();
                        dataSet.Tables["tBooks"].Rows[rowIndex]["DateU"] = newDateTime;  //  updated now...
                        //       amount = 0;
                    }

                }  //  end absolute
            }

            dataAdapter.Update(dataSet, "tBooks");  //  update database w/ changes
            dataSet.AcceptChanges();

            //  command string for displaying the books
            fillDataBasePanel(createCommandString());

            rbAmount.Checked = false;
            rbPercentage.Checked = false;

            lbStatus.Items.Insert(0, "price changes completed");
            lbStatus.Refresh();

            Cursor.Current = Cursors.Default;

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    Inclusive search
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void doInclusiveSearch() {
            ArrayList ssColumnArray = new ArrayList();
            ssColumnArray.Add(cbSSColumn1);
            ssColumnArray.Add(cbSSColumn2);
            ssColumnArray.Add(cbSSColumn3);
            ssColumnArray.Add(cbSSColumn4);

            ArrayList ssCompareTypeArray = new ArrayList();
            ssCompareTypeArray.Add(lbSSCompare1);
            ssCompareTypeArray.Add(lbSSCompare2);
            ssCompareTypeArray.Add(lbSSCompare3);
            ssCompareTypeArray.Add(lbSSCompare4);

            ArrayList ssCompareToArray = new ArrayList();
            ssCompareToArray.Add(tbSSCompareTo1);
            ssCompareToArray.Add(tbSSCompareTo2);
            ssCompareToArray.Add(tbSSCompareTo3);
            ssCompareToArray.Add(tbSSCompareTo4);

            ArrayList ssAndOrArray = new ArrayList();
            ssAndOrArray.Add(null);
            ssAndOrArray.Add(lbSSAndOr2);
            ssAndOrArray.Add(lbSSAndOr3);
            ssAndOrArray.Add(lbSSAndOr4);

            //  make sure something is there to search for... (11.0.3)
            if (((cbSSColumn1.SelectedItem != null || (string)cbSSColumn1.SelectedItem != "") && tbSSCompareTo1.Text.Length == 0) &&  // tbSSCompareTo1.Text.Contains(" search terms go"))) ||
                 ((cbSSColumn2.SelectedItem != null || (string)cbSSColumn2.SelectedItem != "") && tbSSCompareTo2.Text.Length == 0) &&
                 ((cbSSColumn3.SelectedItem != null || (string)cbSSColumn3.SelectedItem != "") && tbSSCompareTo3.Text.Length == 0) &&
                 ((cbSSColumn4.SelectedItem != null || (string)cbSSColumn4.SelectedItem != "") && tbSSCompareTo4.Text.Length == 0)) {

                MessageBox.Show("If you select an item, you must provide search criteria", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            //  validate the request.. 
            if (cbSSColumn1.SelectedItem != null && (cbSSColumn1.SelectedItem.Equals("Date Added") || cbSSColumn1.SelectedItem.Equals("Date Updated"))) {
                if (tbSSCompareTo1.Text.IndexOf("-") == -1 && tbSSCompareTo1.Text.IndexOf(@"/") == -1 || tbSSCompareTo1.Text.IndexOf(".") != -1) {
                    MessageBox.Show("Date format must be either mm/dd/yyyy or mm-dd-yyyy", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (cbSSColumn2.SelectedItem != null)
                if (cbSSColumn2.SelectedItem.Equals("Date Added") || cbSSColumn2.SelectedItem.Equals("Date Updated")) {
                    if (tbSSCompareTo2.Text.IndexOf("-") == -1 && tbSSCompareTo2.Text.IndexOf(@"/") == -1) {
                        MessageBox.Show("Date format must be either mm/dd/yyyy or mm-dd-yyyy", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            if (cbSSColumn3.SelectedItem != null)
                if (cbSSColumn3.SelectedItem.Equals("Date Added") || cbSSColumn3.SelectedItem.Equals("Date Updated")) {
                    if (tbSSCompareTo3.Text.IndexOf("-") == -1 && tbSSCompareTo3.Text.IndexOf(@"/") == -1) {
                        MessageBox.Show("Date format must be either mm/dd/yyyy or mm-dd-yyyy", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            if (cbSSColumn4.SelectedItem != null)
                if (cbSSColumn4.SelectedItem.Equals("Date Added") || cbSSColumn4.SelectedItem.Equals("Date Updated")) {
                    if (tbSSCompareTo4.Text.IndexOf("-") == -1 && tbSSCompareTo4.Text.IndexOf(@"/") == -1) {
                        MessageBox.Show("Date format must be either mm/dd/yyyy or mm-dd-yyyy", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            int arrayNdx = 0;  //  index into the above arrays...

            StringBuilder sb = new StringBuilder("select BookNbr, Title, ISBN, Quantity, Locn, Price, Stat, InvoiceNbr from tBooks where ");  //  initialize

            if (((ComboBox)ssColumnArray[arrayNdx]).SelectedIndex == -1 || ((ListBox)ssCompareTypeArray[arrayNdx]).SelectedIndex == -1) {
                MessageBox.Show("You must click on your selection so it turns blue", "Prager Book Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (((ComboBox)ssColumnArray[arrayNdx]).SelectedItem.ToString())  //  first selection
            {
                case "SKU":
                    sb.Append("BookNbr ");
                    break;
                case "Location":
                    sb.Append("Locn ");
                    break;
                case "Publisher":
                    sb.Append("Pub ");
                    break;
                case "Publisher Location":
                    sb.Append("PubPlace ");
                    break;
                case "Year Published":
                    sb.Append("PubYear ");
                    break;
                case "Keywords":
                    sb.Append("Keywds ");
                    break;
                case "Description":
                    sb.Append("Descr ");
                    break;
                case "Jacket":
                    sb.Append("Jaket ");
                    break;
                case "Binding":
                    sb.Append("Bndg ");
                    break;
                case "Condition":
                    sb.Append("Condn ");
                    break;
                case "Edition":
                    sb.Append("Ed ");
                    break;
                case "Invoice":
                    sb.Append("InvoiceNbr ");
                    break;

                //  for dates: select Booknbr, Title, Locn, DateA from tBooks where extract(month from DateA) = '01' and
                //  extract(day from DateA) = '10' and extract(year from DateA) = '2005'  <------------------ TODO

                case "Date Added":
                    sb.Append("DateA ");
                    break;
                case "Date Updated":
                    sb.Append("DateU ");
                    break;
                case "Primary Catalog":
                    sb.Append("Cat ");
                    break;
                case "Sub-Category":
                    sb.Append("SubCategory ");
                    break;
                case "Private Notes":
                    sb.Append("Notes ");
                    break;
                case "Status":
                    sb.Append("Stat ");
                    break;
                case "Quantity":
                    sb.Append("Quantity ");
                    break;
                case "Book Weight":
                    sb.Append("BookWeight ");
                    break;
                case "Illustrator":
                    sb.Append("Illus ");
                    break;
                case "Type":
                    sb.Append("BookType ");
                    break;
                case "Size":
                    sb.Append("BookSize ");
                    break;
                case "Title":
                case "Author":
                case "ISBN":
                case "Price":
                case "Cost":
                case "Signed":
                case "Shipping":
                    sb.Append(((ComboBox)ssColumnArray[arrayNdx]).SelectedItem.ToString() + " ");
                    break;
                default:
                    break;
            }

            // Get the number of times asterisks are in the string
            int asteriskCount = Regex.Matches(((TextBox)ssCompareToArray[arrayNdx]).Text, @"\*").Count;

            //  check to see if there is a wildcard (asterisk) with an equal compare
            r = new Regex("[*]");
            m = r.Match(((TextBox)ssCompareToArray[arrayNdx]).Text);

            if (m.Success) {
                switch (((ListBox)ssCompareTypeArray[arrayNdx]).SelectedItem.ToString())  //  first selection
                {
                    case "is equal to":
                        sb.Append("LIKE '");
                        sb.Append(r.Replace(((TextBox)ssCompareToArray[arrayNdx]).Text, @"%"));
                        sb.Append("'");  //  trailing quote
                        break;
                    case "is not equal to":
                        sb.Append("NOT LIKE '");
                        sb.Append(r.Replace(((TextBox)ssCompareToArray[arrayNdx]).Text, @"%"));
                        sb.Append("'");  //  trailing quote
                        break;
                    default:
                        MessageBox.Show("Error: can not use wildcard (*) with anything \r" +
                                         "other than 'is equal to' or 'is not equal to'",
                                         "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }
            else  //  no, just a regular compare
            {
                switch (((ListBox)ssCompareTypeArray[arrayNdx]).SelectedItem.ToString())  //  first selection
                {
                    case "is equal to":
                        sb.Append("= '");
                        break;
                    case "is not equal to":
                        sb.Append("<> '");
                        break;
                    case "is greater than":
                        sb.Append("> '");
                        break;
                    case "is less than":
                        sb.Append("< '");
                        break;
                    default:
                        break;
                }
                sb.Append(((TextBox)ssCompareToArray[arrayNdx]).Text + @"'");
            }


            int itemCount = 0;
            for (arrayNdx = 1; arrayNdx < 4; arrayNdx++) {
                if (((ListBox)ssAndOrArray[arrayNdx]).SelectedIndex != -1 && (((ComboBox)ssColumnArray[arrayNdx]).SelectedIndex == -1 || ((ListBox)ssCompareTypeArray[arrayNdx]).SelectedIndex == -1)) {
                    MessageBox.Show("You must click on your selection so it turns blue", "Prager Book Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (((ListBox)ssAndOrArray[arrayNdx]).Text == "- - -" || ((ListBox)ssAndOrArray[arrayNdx]).Text == "") {
                    inclusiveSearchString = sb.ToString();  //  copy this just in case we are going to do an export
                    fillDataBasePanel(sb.ToString());
                    rbExportInclusiveSearch.Enabled = true;

                    itemCount = dataBasePanel.Items.Count;
                    lBooksReturned.Text = itemCount + " books found.";
                    return;
                }

                //  and/or selected...
                sb.Append(" " + ((ListBox)ssAndOrArray[arrayNdx]).Text + " ");

                switch (((ComboBox)ssColumnArray[arrayNdx]).SelectedItem.ToString())  //  second selection
                {
                    case "SKU":
                        sb.Append("BookNbr ");
                        break;
                    case "Location":
                        sb.Append("Locn ");
                        break;
                    case "Publisher":
                        sb.Append("Pub ");
                        break;
                    case "Publisher Location":
                        sb.Append("PubPlace ");
                        break;
                    case "Year Published":
                        sb.Append("PubYear ");
                        break;
                    case "Keywords":
                        sb.Append("Keywds ");
                        break;
                    case "Description":
                        sb.Append("Descr ");
                        break;
                    case "Jacket":
                        sb.Append("Jaket ");
                        break;
                    case "Binding":
                        sb.Append("Bndg ");
                        break;
                    case "Condition":
                        sb.Append("Condn ");
                        break;
                    case "Edition":
                        sb.Append("Ed ");
                        break;
                    case "Invoice":
                        sb.Append("InvoiceNbr ");
                        break;
                    case "Date Added":
                        sb.Append("DateA ");
                        break;
                    case "Date Updated":
                        sb.Append("DateU ");
                        break;
                    case "Primary Catalog":
                        sb.Append("Cat ");
                        break;
                    case "Sub-Category":
                        sb.Append("SubCategory ");
                        break;
                    case "Private Notes":
                        sb.Append("Notes ");
                        break;
                    case "Status":
                        sb.Append("Stat ");
                        break;
                    case "Quantity":
                        sb.Append("Quantity ");
                        break;
                    case "Book Weight":
                        sb.Append("BookWeight ");
                        break;
                    case "Illustrator":
                        sb.Append("Illus ");
                        break;
                    case "Type":
                        sb.Append("BookType ");
                        break;
                    case "Size":
                        sb.Append("BookSize ");
                        break;
                    case "Title":
                    case "Author":
                    case "ISBN":
                    case "Price":
                    case "Cost":
                    case "Signed":
                    case "Shipping":
                        sb.Append(((ComboBox)ssColumnArray[arrayNdx]).SelectedItem.ToString() + " ");
                        break;
                    default:
                        break;
                }

                // Get the number of times asterisks are in the string
                asteriskCount = Regex.Matches(((TextBox)ssCompareToArray[arrayNdx]).Text, @"\*").Count;

                //  check to see if there is a wildcard (asterisk) with an equal compare
                r = new Regex("[*]");
                m = r.Match(((TextBox)ssCompareToArray[arrayNdx]).Text);
                if (m.Success) {
                    switch (((ListBox)ssCompareTypeArray[arrayNdx]).SelectedItem.ToString())  //  second selection
                    {
                        case "is equal to":
                            sb.Append("LIKE '");
                            sb.Append(r.Replace(((TextBox)ssCompareToArray[arrayNdx]).Text, @"%"));
                            sb.Append("'");  //  trailing quote
                            break;
                        case "is not equal to":
                            sb.Append("NOT LIKE '");
                            sb.Append(r.Replace(((TextBox)ssCompareToArray[arrayNdx]).Text, @"%"));
                            sb.Append("'");  //  trailing quote
                            break;
                        default:
                            break;
                    }
                }
                else  //  no, just a regular compare
                {
                    switch (((ListBox)ssCompareTypeArray[arrayNdx]).SelectedItem.ToString())  //  second selection
                    {
                        case "is equal to":
                            sb.Append("= '");
                            break;
                        case "is not equal to":
                            sb.Append("<> '");
                            break;
                        case "is greater than":
                            sb.Append("> '");
                            break;
                        case "is less than":
                            sb.Append("< '");
                            break;
                        default:
                            break;
                    }
                    sb.Append(((TextBox)ssCompareToArray[arrayNdx]).Text + @"'");
                }
            }



            inclusiveSearchString = sb.ToString();  //  copy this just in case we are going to do an export
            fillDataBasePanel(sb.ToString());
            rbExportInclusiveSearch.Enabled = true;

            itemCount = dataBasePanel.Items.Count;
            lBooksReturned.Text = itemCount + " books found";

            return;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--   truncate books table
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        internal void truncateBooksTable() {
            Cursor.Current = Cursors.WaitCursor;

            DialogResult dlgResult = DialogResult.None;
            dlgResult = MessageBox.Show("You have asked to delete all books currently in your inventory.\rAre you sure you want to do this?",
                "Prager Book Inventory Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.No)
                return;

            commandString = "delete from tBooks";
            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();

            sqlCmd = new FbCommand(commandString, bookConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (System.Exception ex) {
                MessageBox.Show("Error deleting complete inventory" + ex, "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally {
                dataBasePanel.Items.Clear();  //  remove all of the "dead" stuff from the listview
                //importDataFile.Refresh();
                cbDeleteFirst.Checked = false;
                Cursor.Current = Cursors.Default;
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make mass changes
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void makeMassChange() {
            if (lbMChangeFields.SelectedIndex == -1) {
                MessageBox.Show("You must highlight a field", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fieldNameToChange = "";
            switch (lbMChangeFields.SelectedItem.ToString()) {
                case "Type":
                    fieldNameToChange = "Type";
                    break;
                case "Size":
                    fieldNameToChange = "Size";
                    break;
                case "Location":
                    fieldNameToChange = "Locn";
                    break;
                case "Keywords":
                    fieldNameToChange = "Keywds";
                    break;
                case "Cost":
                    fieldNameToChange = "Cost";
                    break;
                case "Jacket":
                    fieldNameToChange = "Jaket";
                    break;
                case "Binding":
                    fieldNameToChange = "Bndg";
                    break;
                case "Condition":
                    fieldNameToChange = "Condn";
                    break;
                case "Edition":
                    fieldNameToChange = "Ed";
                    break;
                case "Catalog":
                    fieldNameToChange = "Cat";
                    break;
                case "Private Notes":
                    fieldNameToChange = "Notes";
                    break;
                case "Publisher":
                    fieldNameToChange = "Pub";
                    break;
                case "Shipping":
                    fieldNameToChange = "Shipping";
                    break;
                case "Date of Publication":
                    fieldNameToChange = "PubYear";
                    break;
                case "Publisher Location":
                    fieldNameToChange = "PubPlace";
                    break;
                case "Signed by Author":
                case "Signed by Illustrator":
                case "Signed by Both":
                    fieldNameToChange = "Signed";
                    break;
                default:
                    break;

            }

            if (tbMChangeFrom.Text == "NULL" || tbMChangeFrom.Text.Length == 0)
                commandString = "UPDATE tBooks SET " + fieldNameToChange + " = '" + tbMChangeTo.Text + "' " +
                    " WHERE " + fieldNameToChange + " IS NULL"; //'" + tbMChangeFrom.Text + "'";
            else
                commandString = "UPDATE tBooks SET " + fieldNameToChange + " = '" + tbMChangeTo.Text + "' " +
                    " WHERE " + fieldNameToChange + " = '" + tbMChangeFrom.Text + "'";

            Cursor.Current = Cursors.WaitCursor;
            try {
                if (bookConn.State == ConnectionState.Closed)
                    bookConn.Open();
                sqlCmd = new FbCommand(commandString, bookConn);

                sqlCmd.ExecuteNonQuery();
            }
            catch (System.Exception ex) {
                MessageBox.Show("Error updating record " + ex.Message + "\n" + ex.StackTrace);
            }
            finally {
                Cursor.Current = Cursors.Default;
                createCommandString();
                fillDataBasePanel(commandString);
            }

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    remove "Will not ship int'l" message from description field
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void removeWillNotShip() {

            string alteredDesc = "";
            int bookCount = 0;

            commandString = "SELECT BookNbr, Descr from tBooks";
            FbDataReader rdr = null;
            FbCommand selectCmd = new FbCommand(commandString, bookConn);

            //  read book inventory
            rdr = selectCmd.ExecuteReader();
            while (rdr.Read()) {
                if (rdr[1].ToString().Contains("Will NOT ship international; ")) {
                    alteredDesc = rdr[1].ToString().Replace("Will NOT ship international; ", " ");
                    try {
                        string updateString = "UPDATE tBooks SET Descr = '" + alteredDesc + "' WHERE BookNbr = '" + rdr[0].ToString() + "'";
                        FbCommand tempCmd = new FbCommand(updateString, bookConn);

                        tempCmd.ExecuteNonQuery();
                        bookCount++;

                        lbStatus.Items.Add("SKU: '" + rdr[0] + "'");
                        lbStatus.Refresh();

                    }
                    catch (System.Exception ex) {
                        MessageBox.Show("Error updating record: " + ex.Message + "\n" + ex.StackTrace);
                    }
                }
            }

            lbStatus.Items.Add("Total modified: '" + bookCount.ToString() + "'");
            lbStatus.Refresh();
            tabTaskPanel.SelectTab(cStatus);

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update from pricing service
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void updateFromPricingService() {
            lPricingServiceStatus.Text = "Updating book inventory...";

            lProgress.Visible = true;
            lProgress.Text = "Updating book 1 of " + lvPricingService.CheckedItems.Count.ToString();
            int recordCounter = 1;


            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();

            Cursor.Current = Cursors.WaitCursor;

            if (lvPricingService.CheckedItems.Count > 0)  //  make sure we have something to update
            {
                foreach (ListViewItem CurrentItem in lvPricingService.CheckedItems)  //  go through all of them
                {
                    string updateString = "UPDATE tBooks SET Price = " + CurrentItem.SubItems[8].Text.Trim() +
                        ", DateU = ' " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                        "',  TranC = 'U' WHERE BookNbr = '" + CurrentItem.SubItems[0].Text.Trim() + "'";
                    FbCommand cmd = new FbCommand(updateString, bookConn);
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    ++recordCounter;
                    lProgress.Text = "Processing: " + recordCounter.ToString() + " of " + lvPricingService.CheckedItems.Count.ToString();
                    lProgress.Refresh();
                }

                fillDataBasePanel(createCommandString());
                //fillDataBasePanel("select BookNbr, Title, ISBN,  NbrOfCopies, Locn, Price, Stat, InvoiceNbr from tBooks");
                Cursor.Current = Cursors.Default;
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    get next book from table
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void getNextBookInList() {
            string searchString = "";
            if (tbBookNbr.Text.Length == 0)  // nothing selected, so give them an error message
            {
                MessageBox.Show("Error: you must select a book to start with from the top panel", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else {
                searchString = "SELECT BookNbr FROM tBooks WHERE BookNbr = (SELECT MIN(BookNbr) FROM tBooks WHERE BookNbr > '" + tbBookNbr.Text + "')";
                FbDataReader dr = null;
                if (bookConn.State != ConnectionState.Open)
                    bookConn.Open();
                sqlCmd = new FbCommand(searchString, bookConn);
                dr = sqlCmd.ExecuteReader();

                if (!dr.Read()) {
                    dr.Close();
                    MessageBox.Show("There are no more records to display", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string sku = dr[0].ToString();
                dr.Close();

                PopulateDetailPanel(sku);
                bUpdateRecord.Enabled = true;  //  allow updates 
                updateNeeded = false;
            }
        }

    }

}

