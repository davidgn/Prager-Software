
using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Prager_Book_Inventory
{

    partial class mainForm : Form
    {
        Regex r;
        Match m;
        TextWriter tw1;

        string Title;
        string Author;
        string ISBN;
        string BookNumber;
        string Illustrator;
        string Locn;
        string Price;
        string Cost;
        string Publisher;
        string PubPlace;
        string PubYear;
        string Keywords;
        string Description;
        string Notes;
        string Jacket;
        string BookBinding;
        string Edition;
        string SignedBy;
        string BookType;
        string BookSize;
        string DateAdded;
        string DateUpdated;
        string TimeUpdated;
        string Catalog;
        string SubCategory;
        string Condition;
        string Status;
        string NbrOfPages;
        string BookWeight;
        string ImageFileName;
        //string NbrOfCopies;
        uint Shipping;  //  contains the binary flags to indicate shipping choices
        string Volume;
        int Quantity;


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // --    reset strings
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        void resetStrings() {
            Title = "";
            Author = "";
            ISBN = "";
            BookNumber = "";
            Illustrator = "";
            Locn = "";
            Price = "";
            Cost = "";
            Publisher = "";
            PubPlace = "";
            PubYear = "";
            Keywords = "";
            Description = "";
            Notes = "";
            Jacket = "";
            BookBinding = "";
            Edition = "";
            SignedBy = "";
            BookType = "";
            BookSize = "";
            DateAdded = "";
            DateUpdated = "";
            TimeUpdated = "";
            Catalog = "";
            Condition = "";
            Status = "";
            Notes = "";
            //NbrOfCopies = "";
            Shipping = 0;
            Volume = "";
            Quantity = 0;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create a file in tab-delimited format for EXPORT
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int createExportTabFormat(string formattedDate) {

            Cursor.Current = Cursors.WaitCursor;

            if (rbExportAll.Checked == false && rbChangeDate.Checked == false && rbExportInclusiveSearch.Checked == false && rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

//#if EXPORTTESTING
//                exportPath = @"d:\temp\prager\export\";  //  create normal export file
//#endif
            if (cbPurgeReplace.Checked == true)  //  doing a purge/replace?
                sFileName1 = exportPath + "purgeTB" + formattedDate + ".tab";
            else  //  no just exporting those that were changed
                sFileName1 = exportPath + "TB" + formattedDate + ".tab";

            try {
                tw1 = new StreamWriter(sFileName1);  //  for normal tab-delimited files
            }
            catch (Exception e) {
                if (e.ToString().Substring(10, 26) == "DirectoryNotFoundException") {
                    try {
                        DirectoryInfo di = Directory.CreateDirectory(exportPath);   // Try to create the directory
                        tw1 = new StreamWriter(sFileName1);
                    }
                    catch (Exception e1) {
                        MessageBox.Show("Unable to create export directory: " + e1.Message, "Prager Book Inventory Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }

            createExportCommandString();

            //  find books in table
            FbCommand command = new FbCommand(commandString, bookConn);
            FbDataReader data = command.ExecuteReader();

            int count = 0;
            lbUploadStatus.Items.Insert(0, "Tab-delimited format export started");
            lbUploadStatus.Refresh();

            //  write header
            tw1.WriteLine("Book Number\tTitle\tAuthor\tISBN\tNbrOfCopies\tIllustrator\tPrice\tEdition\tSignedBy\t" +
                "Publisher\tPublish Place\tPublish Year\tNotes\tSize\tKeywords\tJacket Condition\tBinding\tBook Type\t" +
                "Condition\tCatalog\tStatus\tWillExpediteShipping\tWillShipIntl\t");

            while (data.Read()) {
                tbBookNbr.Text = data["BookNbr"].ToString();  //  for debugging purposes only!

                if (cbPurgeReplace.Checked == true && data["Stat"].ToString() == "Sold")
                    continue;  //  if purge/replace and Sold, don't upload

                if (data["Stat"].ToString() == "Hold")
                    continue;  //  don't export

                buildTabDelimitedFile(data);

                count++;  //  increment counter
            }

            tw1.Close();  //  close the stream

            if (data != null)  //  close the data reader
                data.Close();

            Cursor.Current = Cursors.Default;

            lbUploadStatus.Items.Insert(0, "Tab-delimited format export(s) completed: " + count + " books exported to file " + sFileName1);
            lbUploadStatus.Refresh();

            return 0;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    build a TAB delimited format file
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void buildTabDelimitedFile(FbDataReader data) {

            string dataBuild;
            dataBuild = data["BookNbr"].ToString() + "\t";  //  book number

            dataBuild += data["Title"].ToString() + "\t";  //  title

            dataBuild += data["Author"].ToString() + "\t";  //  author

            //string debugString = data["ISBN);
            string tempISBN = data["ISBN"].ToString().StartsWith("B") ? "" : data["ISBN"].ToString();
            dataBuild += tempISBN + "\t";
            //if (!data.IsDBNull((int)tBooks.ISBN) && data["ISBN).StartsWith("B"))
            //    dataBuild += data["ISBN) + "\t";  //  ISBN
            //else
            //    dataBuild += " \t";

            dataBuild += data["Quantity"] + "\t";  //  quantity

            if (data["Illus"] != DBNull.Value)
                dataBuild += data["Illus"].ToString() + "\t";  //  illustrator
            else
                dataBuild += " \t";

            dataBuild += data["Price"].ToString() + "\t";  //  price

            if (data["Ed"] != DBNull.Value)
                dataBuild += data["Ed"].ToString() + "\t";  //  Edition
            else
                dataBuild += " \t";

            if (data["Signed"] != DBNull.Value)  //  signed-by
                if (data["Signed"].ToString() == "B")
                    dataBuild += "Signed by Author and Illustrator\t";
                else if (data["Signed"].ToString() == "A")
                    dataBuild += "Signed by Author\t";
                else if (data["Signed"].ToString() == "I")
                    dataBuild += "Signed by Illustrator\t";
                else
                    dataBuild += " \t";

            if (data["Pub"] != DBNull.Value)
                dataBuild += data["Pub"].ToString() + "\t";  //  publisher
            else
                dataBuild += " \t";

            if (data["PubPlace"] != DBNull.Value)
                dataBuild += data["PubPlace"].ToString() + "\t";  //  place published
            else
                dataBuild += " \t";

            if (data["PubYear"] != DBNull.Value)
                dataBuild += data["PubYear"].ToString() + "\t";  //  year published
            else
                dataBuild += " \t";

            if (data["Descr"] != DBNull.Value)
                dataBuild += data["Descr"].ToString() + "\t";  //  description
            else
                dataBuild += " \t";

            if (data["BookSize"] != DBNull.Value) {
                string[] tempSize = data["BookSize"].ToString().Split(' ');
                dataBuild += tempSize[1] + tempSize[2] + tempSize[3] + tempSize[4] + "\t";  //  book size
            }
            else
                dataBuild += " \t";

            //tw1.WriteLine("Book Number\tTitle\tAuthor\tISBN\tQuantity\tIllustrator\tPrice\tEdition\tSignedBy\t" +
            //"Publisher\tPublish Place\tPublish Year\tNotes\tSize\tKeywords\tJacket Condition\tBinding\tBook Type\t" +
            //"Condition\tCatalog\tStatus\tWillExpediteShipping\tWillShipIntl\t");

            if (data["Keywds"] != DBNull.Value)
                dataBuild += data["Keywds"].ToString() + "\t";  //  keywords
            else
                dataBuild += " \t";

            if (data["Jaket"] != DBNull.Value)
                dataBuild += data["Jaket"].ToString() + "\t";  //  jacket
            else
                dataBuild += " \t";

            if (data["Bndg"] != DBNull.Value)
                dataBuild += data["Bndg"].ToString() + "\t";  //  binding
            else
                dataBuild += " \t";

            if (data["BookType"] != DBNull.Value)
                dataBuild += data["BookType"].ToString() + "\t";  //  book type
            else
                dataBuild += " \t";

            if (data["Condn"] != DBNull.Value)
                dataBuild += data["Condn"].ToString() + "\t";  //  condition
            else
                dataBuild += " \t";

            if (data["Cat"] != DBNull.Value)
                dataBuild += data["Cat"].ToString() + "\t";  //  catalog
            else
                dataBuild += " \t";

            if (data["Stat"] != DBNull.Value)
                dataBuild += data["Stat"].ToString() + "\t";  //  status
            else
                dataBuild += " \t";

            UInt16 target = 0;
            if (data["Shipping"] != DBNull.Value)   //  Shipping
                target = UInt16.Parse(data["Shipping"].ToString());  //  <------------ TODO
            dataBuild += (target & 16) == 1 ? "y\t" : "n\t";  //  Expedited domestic
            dataBuild += (target & 2) == 1 ? "y\t" : "n\t";  //  Intl' standard

            //dataBuild += data["NbrOfCopies) + "\t";  //  add number of copies

            tw1.WriteLine(dataBuild);
            return;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create a file in comma-separated-value format
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int createCSVFormatExportFile(string formattedDate) {

            Cursor.Current = Cursors.WaitCursor;

            if (rbExportAll.Checked == false && rbChangeDate.Checked == false && rbExportInclusiveSearch.Checked == false && rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

//#if EXPORTTESTING
//                exportPath = @"d:\temp\prager\export\";  //  create normal export file
//#endif
            if (cbPurgeReplace.Checked == true)  //  doing a purge/replace?
                sFileName1 = exportPath + "purgeCSV" + formattedDate + ".csv";
            else  //  no just exporting those that were changed
                sFileName1 = exportPath + "CSV" + formattedDate + ".csv";

            try  //  look for Export directory
            {
                tw1 = new StreamWriter(sFileName1);
            }
            catch (Exception e) {
                if (e.ToString().Substring(10, 26) == "DirectoryNotFoundException") {
                    try {
                        DirectoryInfo di = Directory.CreateDirectory(exportPath);   // Try to create the directory
                        tw1 = new StreamWriter(sFileName1);
                    }
                    catch (Exception e1) {
                        MessageBox.Show("Unable to create export directory: " + e1.Message, "Prager Book Inventory Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }

            createExportCommandString();

            //  find books in table
            FbCommand command = new FbCommand(commandString, bookConn);
            FbDataReader data = command.ExecuteReader();

            int count = 0;
            lbUploadStatus.Items.Insert(0, "CSV format export started");
            lbUploadStatus.Refresh();

            //  write header                          
            //tw1.WriteLine("Action (SiteID=US|Country=US|Currency=USD|CC=UTF-8|ListingType=Half|Location=US|ListingDuration=GTC)," +
            //    "ProductIDType, ProductIDValue, ItemID, SKU, Quantity, Price, A:Condition, A:Notes");
            tw1.WriteLine("ISBN, Quantity, Price, Condition, Comment, Private Notes, SKU");


            //int actionCounter = 0;
            while (data.Read()) {
                tbBookNbr.Text = data["BookNbr"].ToString();  //  for debugging purposes only!

                if (cbPurgeReplace.Checked == true && data["Stat"].ToString() == "Sold")
                    continue;  //  if purge/replace and Sold, don't upload

                if (data["ISBN"].ToString().Length < 10 || data["Stat"].ToString() == "Hold")  //  can only take books with ISBNs
                    continue;

                buildCSVDelimitedFile(data);
                count++;
            }

            tw1.Close();  //  close the stream

            if (data != null)  //  close the data reader
                data.Close();

            Cursor.Current = Cursors.Default;

            lbUploadStatus.Items.Insert(0, "CSV-delimited format export(s) completed: " + count + " books exported to file " + sFileName1);
            lbUploadStatus.Refresh();

            return 0;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    build a CSV file
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void buildCSVDelimitedFile(FbDataReader data) {

            string workingDescrField = "";
            string dataBuild = "";

            string tempISBN = data["ISBN"].ToString().StartsWith("B") ? "" : data["ISBN"].ToString();
            dataBuild = tempISBN + ", ";
            dataBuild += data["Quantity"] + ", ";
            dataBuild += data["Price"].ToString() + ", ";

            if (data["Condn"] != DBNull.Value)  //  condition
                switch (data["Condn"].ToString().ToLower()) {
                    case "new":
                    case "new book":
                        dataBuild += "New, ";
                        break;
                    case "fine":
                    case "fine - used":
                    case "fine - collectible":
                    case "used; like new":  //  amazon
                    case "collectible; like new":
                    case "as new":
                    case "like new":
                        dataBuild += "Like New, ";
                        break;
                    case "very good":
                    case "very good - used":
                    case "very good - collectible":
                    case "used; very good":  //  amazon
                    case "collectible; very good":
                        dataBuild += "Very Good, ";
                        break;
                    case "good":
                    case "good - used":
                    case "good - collectible":
                    case "used; good":  //  amazon
                    case "collectible; good":
                        dataBuild += "Good, ";
                        break;
                    case "fair":
                    case "fair - used":
                    case "poor":
                    case "poor - used":
                    case "fair - collectible":
                    case "poor - collectible":
                    case "used; acceptable":  //  amazon
                    case "collectible; acceptable":
                        dataBuild += "Acceptable, ";
                        break;
                    default:
                        dataBuild += "Good, ";
                        break;
                }

            if (data["Descr"] != DBNull.Value)  //  description (notes)
            {
                workingDescrField = data["Descr"].ToString();
                workingDescrField = workingDescrField.Replace("\"", "in. ");  //  replace " with the word 'in.'
                dataBuild += workingDescrField.Replace(',', ';') + ",,";  //  no private notes
            }
            else
                dataBuild += ",, ";  //  no description or private notes

            dataBuild += data["BookNbr"].ToString();    //  SKU

            tw1.WriteLine(dataBuild);
            return;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create a file in comma-separated-value format for Valore
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int createValoreExportFile(string formattedDate) {

            Cursor.Current = Cursors.WaitCursor;

            if (rbExportAll.Checked == false && rbChangeDate.Checked == false && rbExportInclusiveSearch.Checked == false && rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

//#if EXPORTTESTING
//                exportPath = @"d:\temp\prager\export\";  //  create normal export file
//#endif
            //if (cbPurgeReplace.Checked == true)  //  doing a purge/replace?
            //    sFileName1 = exportPath + "purgeCSV" + formattedDate + ".csv";
            //else  //  no just exporting those that were changed
            sFileName1 = exportPath + "Valore" + formattedDate + ".csv";

            try  //  look for Export directory
            {
                tw1 = new StreamWriter(sFileName1);
            }
            catch (Exception e) {
                if (e.ToString().Substring(10, 26) == "DirectoryNotFoundException") {
                    try {
                        DirectoryInfo di = Directory.CreateDirectory(exportPath);   // Try to create the directory
                        tw1 = new StreamWriter(sFileName1);
                    }
                    catch (Exception) {
                        MessageBox.Show("Unable to create export directory: " + e.Message, "Prager Book Inventory Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }

            createExportCommandString();

            //  find books in table
            FbCommand command = new FbCommand(commandString, bookConn);
            FbDataReader data = command.ExecuteReader();

            int count = 0;
            lbUploadStatus.Items.Insert(0, "Valore CSV format export started");
            lbUploadStatus.Refresh();

            //  write header                          
            tw1.WriteLine("add-modify-delete, product-code-type, product-code, sku, price, quantity, item-condition, item-note");


            //int actionCounter = 0;
            while (data.Read()) {
                tbBookNbr.Text = data["BookNbr"].ToString();  //  for debugging purposes only!

                if (cbPurgeReplace.Checked == true && data["Stat"].ToString() == "Sold")
                    continue;  //  if purge/replace and Sold, don't upload

                if (data["ISBN"].ToString().Length < 10 || data["Stat"].ToString() == "Hold")  //  can only take books with ISBNs
                    continue;

                buildValoreFile(data);
                count++;
            }  //  end while

            tw1.Close();  //  close the stream

            if (data != null)  //  close the data reader
                data.Close();

            Cursor.Current = Cursors.Default;

            lbUploadStatus.Items.Insert(0, "Valore  format export(s) completed: " + count + " books exported to file " + sFileName1);
            lbUploadStatus.Refresh();

            return 0;
        }



        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    build Valore CSV file
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void buildValoreFile(FbDataReader data) {

            string workingDescrField = "";
            string dataBuild = "";

            //  add-modify-delete
            //if ( (char)data["TranC"] == 'A')
            //    dataBuild = "A,";
            //else
            //    if (int.Parse(data["Quantity"].ToString()) > 0)
            //        dataBuild = "M,";
            //    else
            //        dataBuild = "D,";
            switch (data["TranC"].ToString()) {
                case "A":
                    dataBuild = "A,";
                    break;
                default:
                    if (int.Parse(data["Quantity"].ToString()) > 0)
                        dataBuild = "M,";
                    else
                        dataBuild = "D,";
                    break;
            }

            //  product-code-type
            dataBuild += "1,";  //  isbn

            //  product-code
            string tempISBN = data["ISBN"].ToString().StartsWith("B") ? "" : data["ISBN"].ToString();
            dataBuild += tempISBN + ", ";

            //  SKU
            dataBuild += data["BookNbr"].ToString() + ",";

            //  price
            dataBuild += (decimal)data["Price"] + ", ";

            //  quantity
            dataBuild += int.Parse(data["Quantity"].ToString()) + ", ";

            //  item-condition
            if (data["Condn"] != DBNull.Value)  //  condition
                switch (data["Condn"].ToString().ToLower()) {
                    case "new":
                    case "new book":
                        dataBuild += "New, ";
                        break;
                    case "fine":
                    case "fine - used":
                    case "fine - collectible":
                    case "used; like new":  //  amazon
                    case "collectible; like new":
                    case "as new":
                    case "like new":
                        dataBuild += "Like New, ";
                        break;
                    case "very good":
                    case "very good - used":
                    case "very good - collectible":
                    case "used; very good":  //  amazon
                    case "collectible; very good":
                        dataBuild += "Very Good, ";
                        break;
                    case "good":
                    case "good - used":
                    case "good - collectible":
                    case "used; good":  //  amazon
                    case "collectible; good":
                        dataBuild += "Good, ";
                        break;
                    case "fair":
                    case "fair - used":
                    case "poor":
                    case "poor - used":
                    case "fair - collectible":
                    case "poor - collectible":
                    case "used; acceptable":  //  amazon
                    case "collectible; acceptable":
                        dataBuild += "Acceptable, ";
                        break;
                    default:
                        dataBuild += "Good, ";
                        break;
                }

            //  item-note
            if (data["Descr"] != DBNull.Value)  //  description (notes)
            {
                workingDescrField = data["Descr"].ToString();
                workingDescrField = workingDescrField.Replace("\"", "in. ");  //  replace " with the word 'in.'
                dataBuild += workingDescrField.Replace(',', ';') + " ";  //  no private notes
            }
            else
                dataBuild += ", ";  //  no description or private notes

            tw1.WriteLine(dataBuild);
            return;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  create export command string
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void createExportCommandString() {
            if (rbExportAll.Checked == true)  //  are we exporting all of the books?
                commandString = "SELECT * from tBooks WHERE Stat = 'For Sale'";
            else  //  no... find out what we are trying to export
            {
                if (rbExportInclusiveSearch.Checked == true)  //  are we exporting from the search tab?
                {
                    if (inclusiveSearchString.Length == 0) {
                        MessageBox.Show("Error: you must use Inclusive Search to fill Database Panel", "Prager Book Inventory Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        commandString = inclusiveSearchString.Replace("BookNbr, Title, ISBN, Quantity, Locn, Price, Stat, InvoiceNbr", "*");
                }
                else if (rbExportSelected.Checked == true)  //  user has selected which books to export in Database panel
                {
                    //  create the command string, concatening all of the SKU's
                    commandString = "SELECT * from tBooks where Stat <> 'Pending' and BookNbr IN ('";

                    //  find out which books have been selected, if any
                    ListView.SelectedIndexCollection listData = dataBasePanel.SelectedIndices;
                    if (listData.Count == 0) {
                        MessageBox.Show("No books were selected in Database Panel; try again", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (int lvIndex in listData)
                        commandString += dataBasePanel.Items[lvIndex].SubItems[0].Text + "', '";

                    commandString = commandString.Substring(0, commandString.Length - 4) + "')";
                }
                else  //  we are doing a regular export from the Export tab
                {
                    if (changedExportDateTime == false)
                        commandString = "SELECT * from tBooks where Stat <> 'Hold' and " +
                            "Stat <> 'Pending' and " +
                            "DateU >= '" + lastExport.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    else
                        commandString = "SELECT * from tBooks where Stat <> 'Hold' and " +
                            "Stat <> 'Pending' and " +
                            "DateU >= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                }
            }
        }



        //--------------------    create a file in XML format for Google    ------------------|
        //public int createGoogleXMLFormat(string formattedDate) {

        //            Cursor.Current = Cursors.WaitCursor;
        //            if (!File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "pragerGoogle.xml")) {
        //                MessageBox.Show("You can not export to Google without completing Google options (Main Menu -> Tools -> Google Setup)",
        //                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                //googleOptions go = new googleOptions();  //  has to be a MIDI file before it works properly  TODO
        //                //go.googleSetup();
        //                return -1;
        //            }

        //#if EXPORTTESTING
        //                    exportPath = @"d:\temp\prager\export\";  //  create normal export file
        //#endif

        //            sFileName1 = exportPath + "XML" + formattedDate + ".xml";  //e:\Prager\Export\\

        //            //  get size of table
        //            FbCommand cmd;
        //            cmd = new FbCommand("select COUNT  (*) from rdb$relation_fields where RDB$RELATION_NAME='TBOOKS'", bookConn);
        //            int columnCount = (int)cmd.ExecuteScalar();

        //            //commandString = "SELECT * from tBooks WHERE Stat = 'For Sale'";
        //            createExportCommandString();

        //            int count = 0;
        //            lbUploadStatus.Items.Insert(0, "Google XML format export started");
        //            lbUploadStatus.Refresh();

        //            //  now, create the Google XML file
        //            BooksGoogle g = new BooksGoogle();

        //            g.createGoogleHeader(sFileName1);  //  now write the header records  
        //            string[] bookData = new string[columnCount];

        //            //  find books in table
        //            FbCommand command = new FbCommand(commandString, bookConn);
        //            FbDataReader data = command.ExecuteReader();
        //            while (data.Read()) {
        //                tbBookNbr.Text = data["BookNbr"].ToString();  //  for debugging purposes only!

        //                //if (data.GetString(25) == "Sold")
        //                //    continue;  //  if Sold, don't upload

        //                bookData["BookNbr"] = data["BookNbr"].ToString();
        //                bookData["Title"] = data["Title"].ToString();
        //                bookData["Author"] = data["Author"].ToString();

        //                if (data["ISBN"] != DBNull.Value) 
        //                    bookData["ISBN"] = data["ISBN"].ToString();
        //                bookData["Price"] = data["Price"].ToString();
        //                bookData["Pub"] = data["Pub"].ToString();
        //                bookData["Descr"] = data["Descr"].ToString();
        //                bookData["Bndg"] = data["Bndg"].ToString();
        //                bookData["Condn"] = data["Condn"].ToString();
        //                if (data["Cat"] != DBNull.Value)
        //                    bookData["Cat"] = data["Cat"].ToString();

        //                UInt16 target = 0;
        //                if (data["Shipping"] != DBNull.Value)   //  Shipping
        //                {
        //                    //if (data["Shipping"] != DBNull.Value)
        //                        target = (UInt16)data["Shipping"];
        //                    bookData["ExpediteShip"] = (target & 16) == 1 ? "y\t" : "n\t";  //  Expedited domestic
        //                    bookData["IntlShip"] = (target & 2) == 1 ? "y\t" : "n\t";  //  Intl' standard
        //                }
        //                //if (data["IntlShip))    //  <-------------- TODO
        //                //    bookData["IntlShip] = data["IntlShip);

        //                //if (data["ExpediteShip))     //  <-------------- TODO
        //                //    bookData["ExpediteShip] = data["ExpediteShip);

        //                if (data["SubCategory"] != DBNull.Value)
        //                    bookData["SubCategory"] = data["SubCategory"].ToString().Trim();  //  <------------- TODO
        //                if (data["Ed"] != DBNull.Value)
        //                    bookData["Ed"] = data["Ed"].ToString();
        //                bookData["Cat"] = data["Cat"].ToString().Trim();
        //                if (data["Quantity"] != DBNull.Value)
        //                    bookData["Quantity"] = data["NbrOfPages"].ToString();

        //                g.createGoogleXMLRecord(bookData);

        //                count++;  //  update counter
        //            }

        //            g.createGoogleEOF();

        //            if (data != null)  //  close the data reader
        //                data.Close();

        //            Cursor.Current = Cursors.Default;

        //            lbUploadStatus.Items.Insert(0, "Google XML format export completed: " + count + " books exported to file " + sFileName1);
        //            lbUploadStatus.Refresh();

        //    return 0;
        //}

    }
}

