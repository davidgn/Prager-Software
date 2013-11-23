#define COMPILED4OTHERS
//#define EXPORTTESTING  //  TESTING ONLY  <-----------------

using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Media_Inventory_Manager
{

    partial class mainForm : Form
    {
        Regex r;
        Match m;
        TextWriter tw1;

        public static string SKU;              //  <------------------------ TODO (move somewhere else)
        public static string Title;
        public static string UPC;  //  product-id
        public static string Locn;
        public static string Price;
        public static string Cost;
        public static string TranC;
        public static string Mfgr;
        public static string MfgrYear;
        public static string Description;
        public static string Condition;
        public static string DateAdded;
        public static string DateUpdated;
        public static string Notes;
        public static string Status;
        public static string InvoiceNbr;
        public static string DoNotReprice;
        public static string ImageURL;
        public static string NbrOfDisks;
        public static uint Shipping;  //  contains the binary flags to indicate shipping choices
        public static int Quantity;
        public static string MediaType;
        public static string AudioFormat;
        public static string MPAARating;
        public static string AudioEncoding;
        public static string VideoFormat;
        public static string Language;
        public static string Runtime;
        public static string SubTitles;
        public static string AdultContent;
        public static string PrivateNotes;
        public static string Origin;
        public static string AudioKeywords;
        public static string VideoKeywords;
        public static string VinylDetails;
        public static string Artist;
        public static string Composer;
        public static string Conductor;
        public static string Orchestra;
        public static string CatalogID;
        public static string ProductType;
        public static string ASIN;



        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // --    reset strings
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        void resetStrings() {
            SKU = "";
            Title = "";
            UPC = "";
            Locn = "";
            Price = "";
            Cost = "";
            TranC = "";
            Mfgr = "";
            MfgrYear = "";
            Description = "";
            Condition = "";
            DateAdded = "";
            DateUpdated = "";
            Notes = "";
            Status = "";
            InvoiceNbr = "";
            DoNotReprice = "";
            ImageURL = "";
            NbrOfDisks = "";
            Shipping = 0;
            Quantity = 0;
            MediaType = "";
            AudioFormat = "";
            MPAARating = "";
            AudioEncoding = "";
            VideoFormat = "";
            Language = "";
            Runtime = "";
            SubTitles = "";
            AdultContent = "";
            PrivateNotes = "";
            Origin = "";
            AudioKeywords = "";
            VideoKeywords = "";
            VinylDetails = "";
            Artist = "";
            Composer = "";
            Conductor = "";
            Orchestra = "";
            CatalogID = "";
            ProductType = "";
            ASIN = "";
        }


        ////------------------------    create a file in tab-delimited format for EXPORT   -------------------------------
        //public int createExportTabFormat(string formattedDate) {

        //    Cursor.Current = Cursors.WaitCursor;

        //    if (rbExportAll.Checked == false && rbChangeDate.Checked == false && rbExportInclusiveSearch.Checked == false && rbExportSelected.Checked == false) {
        //        MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return -1;
        //    }

        //    if (cbPurgeReplace.Checked == true)  //  doing a purge/replace?
        //        sFileName1 = exportPath + "purgeTB" + formattedDate + ".tab";
        //    else  //  no just exporting those that were changed
        //        sFileName1 = exportPath + "TB" + formattedDate + ".tab";

        //    try {
        //        tw1 = new StreamWriter(sFileName1);  //  for normal tab-delimited files
        //    }
        //    catch (Exception e) {
        //        if (e.ToString().Substring(10, 26) == "DirectoryNotFoundException") {
        //            try {
        //                DirectoryInfo di = Directory.CreateDirectory(exportPath);   // Try to create the directory
        //                tw1 = new StreamWriter(sFileName1);
        //            }
        //            catch (Exception) {
        //                lbStatus.Items.Insert(0, "Error - unable to create export directory");
        //                lbStatus.Refresh();
        //                return -1;
        //            }
        //        }
        //    }

        //    createExportCommandString();

        //    //  find items in table
        //    FbCommand command = new FbCommand(commandString, mediaConn);
        //    FbDataReader data = command.ExecuteReader();

        //    int count = 0;
        //    lbUploadStatus.Items.Insert(0, "Tab-delimited format export started");
        //    lbUploadStatus.Refresh();

        //    //  write header
        //    tw1.WriteLine("SKU\tTitle\tAuthor\tUPC\tNbrOfCopies\tIllustrator\tPrice\tEdition\tSignedBy\t" +
        //        "Mfgr\tPublish Place\tPublish Year\tNotes\tSize\tKeywords\tJacket Condition\tBinding\tBook Type\t" +
        //        "Condition\tCatalog\tStatus\tWillExpediteShipping\tWillShipIntl\t");

        //    while (data.Read()) {
        //        tbSKU.Text = data["SKU"].ToString();  //  for debugging purposes only!

        //        if (cbPurgeReplace.Checked == true && data["Stat"].ToString() == "Sold")
        //            continue;  //  if purge/replace and Sold, don't upload

        //        buildTabDelimitedFile(data);

        //        count++;  //  increment counter
        //    }

        //    tw1.Close();  //  close the stream

        //    if (data != null)  //  close the data reader
        //        data.Close();

        //    Cursor.Current = Cursors.Default;

        //    lbUploadStatus.Items.Insert(0, "Tab-delimited format export(s) completed: " + count + " items exported to file " + sFileName1);
        //    lbUploadStatus.Refresh();

        //    return 0;
        //}


        ////-----------------------    build a TAB delimited format file    --------------------------------------
        //private void buildTabDelimitedFile(FbDataReader data) {

        //    string dataBuild;
        //    dataBuild = data["SKU"].ToString() + "\t";  //  SKU

        //    dataBuild += data["Title"].ToString() + "\t";  //  title

        //    string tempUPC = data["UPC"].ToString().StartsWith("B") ? "" : data["UPC"].ToString();
        //    dataBuild += tempUPC + "\t";

        //    dataBuild += data["Quantity"] + "\t";  //  quantity

        //    dataBuild += data["Price"].ToString() + "\t";  //  price

        //    if (data["Edition"] != DBNull.Value)
        //        dataBuild += data["Edition"].ToString() + "\t";  //  Edition
        //    else
        //        dataBuild += " \t";

        //    if (data["Mfgr"] != DBNull.Value)
        //        dataBuild += data["Mfgr"].ToString() + "\t";  //  Mfgr
        //    else
        //        dataBuild += " \t";

        //    if (data["MfgrYear"] != DBNull.Value)
        //        dataBuild += data["MfgrYear"].ToString() + "\t";  //  year published
        //    else
        //        dataBuild += " \t";

        //    if (data["Descr"] != DBNull.Value)
        //        dataBuild += data["Descr"].ToString() + "\t";  //  description
        //    else
        //        dataBuild += " \t";

        //    if (data["MediaType"] != DBNull.Value)
        //        dataBuild += data["MediaType"].ToString() + "\t";  //  media type
        //    else
        //        dataBuild += " \t";

        //    if (data["Condn"] != DBNull.Value)
        //        dataBuild += data["Condn"].ToString() + "\t";  //  condition
        //    else
        //        dataBuild += " \t";

        //    if (data["CatalogID"] != DBNull.Value)
        //        dataBuild += data["CatalogID"].ToString() + "\t";  //  catalog number
        //    else
        //        dataBuild += " \t";

        //    if (data["Stat"] != DBNull.Value)
        //        dataBuild += data["Stat"].ToString() + "\t";  //  status
        //    else
        //        dataBuild += " \t";

        //    tw1.WriteLine(dataBuild);
        //    return;
        //}


        //----------------    create a file in comma-separated-value format    --------------]
        //public int createChrislandsExportFile(string formattedDate) {

        //    Cursor.Current = Cursors.WaitCursor;

        //    if (rbExportAll.Checked == false && rbChangeDate.Checked == false && rbExportInclusiveSearch.Checked == false && rbExportSelected.Checked == false) {
        //        MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return -1;
        //    }

        //    if (cbPurgeReplace.Checked == true)  //  doing a purge/replace?
        //        sFileName1 = exportPath + "purgeCH" + formattedDate + ".csv";
        //    else  //  no just exporting those that were changed
        //        sFileName1 = exportPath + "CH" + formattedDate + ".csv";

        //    try  //  look for Export directory
        //    {
        //        tw1 = new StreamWriter(sFileName1);
        //    }
        //    catch (Exception e) {
        //        if (e.ToString().Substring(10, 26) == "DirectoryNotFoundException") {
        //            try {
        //                DirectoryInfo di = Directory.CreateDirectory(exportPath);   // Try to create the directory
        //                tw1 = new StreamWriter(sFileName1);
        //            }
        //            catch (Exception e1) {
        //                MessageBox.Show("Unable to create export directory: " + e1.Message, "Prager Media Inventory Manager",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return -1;
        //            }
        //        }
        //    }

        //    createExportCommandString();

        //    //  find items in table
        //    FbCommand command = new FbCommand(commandString, mediaConn);
        //    FbDataReader data = command.ExecuteReader();

        //    int count = 0;
        //    lbUploadStatus.Items.Insert(0, "Chrislands format export started");
        //    lbUploadStatus.Refresh();

        //    //  write header                          
        //    tw1.WriteLine("Seller ID, Author, Title, Illustrator, Book condition, Book size");

        //    //int actionCounter = 0;
        //    while (data.Read()) {
        //        tbSKU.Text = data["SKU"].ToString();  //  for debugging purposes only!

        //        if (cbPurgeReplace.Checked == true && data["Stat"].ToString() == "Sold")
        //            continue;  //  if purge/replace and Sold, don't upload

        //        if (data["UPC"].ToString().Length < 10)  //  can only take items with UPCs
        //            continue;

        //        buildChrislandsFile(data);
        //        count++;
        //    }  //  end while

        //    tw1.Close();  //  close the stream

        //    if (data != null)  //  close the data reader
        //        data.Close();

        //    Cursor.Current = Cursors.Default;

        //    lbUploadStatus.Items.Insert(0, "CSV-delimited format export(s) completed: " + count + " items exported to file " + sFileName1);
        //    lbUploadStatus.Refresh();

        //    return 0;
        //}


        ////-----------------------------    build a CSV file    -----------------------------------------------------
        //private void buildChrislandsFile(FbDataReader data) {

        //    string workingDescrField = "";
        //    string dataBuild = "";

        //    string tempUPC = data["UPC"].ToString().StartsWith("B") ? "" : data["UPC"].ToString();
        //    dataBuild = tempUPC + ", ";
        //    dataBuild += data["Quantity"] + ", ";
        //    dataBuild += data["Price"].ToString() + ", ";

        //    if (data["Condn"] != DBNull.Value)  //  condition
        //        switch (data["Condn"].ToString().ToLower()) {
        //            case "new":
        //            case "new book":
        //                dataBuild += "New, ";
        //                break;
        //            case "fine":
        //            case "fine - used":
        //            case "fine - collectible":
        //            case "used; like new":  //  amazon
        //            case "collectible; like new":
        //            case "as new":
        //            case "like new":
        //                dataBuild += "Like New, ";
        //                break;
        //            case "very good":
        //            case "very good - used":
        //            case "very good - collectible":
        //            case "used; very good":  //  amazon
        //            case "collectible; very good":
        //                dataBuild += "Very Good, ";
        //                break;
        //            case "good":
        //            case "good - used":
        //            case "good - collectible":
        //            case "used; good":  //  amazon
        //            case "collectible; good":
        //                dataBuild += "Good, ";
        //                break;
        //            case "fair":
        //            case "fair - used":
        //            case "poor":
        //            case "poor - used":
        //            case "fair - collectible":
        //            case "poor - collectible":
        //            case "used; acceptable":  //  amazon
        //            case "collectible; acceptable":
        //                dataBuild += "Acceptable, ";
        //                break;
        //            default:
        //                dataBuild += "Good, ";
        //                break;
        //        }

        //    if (data["Descr"] != DBNull.Value)  //  description (notes)
        //    {
        //        workingDescrField = data["Descr"].ToString();
        //        workingDescrField = workingDescrField.Replace("\"", "in. ");  //  replace " with the word 'in.'
        //        dataBuild += workingDescrField.Replace(',', ';') + ",,";  //  no private notes
        //    }
        //    else
        //        dataBuild += ",, ";  //  no description or private notes

        //    dataBuild += data["SKU"].ToString();    //  SKU

        //    tw1.WriteLine(dataBuild);
        //    return;
        //}


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create a file in comma-separated-value format
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int createCSVFormatExportFile(string formattedDate) {

            Cursor.Current = Cursors.WaitCursor;

            if (rbExportAll.Checked == false && rbChangeDate.Checked == false && rbExportInclusiveSearch.Checked == false && rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

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
                        MessageBox.Show("Unable to create export directory: " + e1.Message, "Prager Media Inventory Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }

            createExportCommandString();

            //  find items in table
            FbCommand command = new FbCommand(commandString, mediaConn);
            FbDataReader data = command.ExecuteReader();

            int count = 0;
            lbUploadStatus.Items.Insert(0, "CSV format export started");
            lbUploadStatus.Refresh();

            //  write header                          
            //tw1.WriteLine("Action (SiteID=US|Country=US|Currency=USD|CC=UTF-8|ListingType=Half|Location=US|ListingDuration=GTC)," +
            //    "ProductIDType, ProductIDValue, ItemID, SKU, Quantity, Price, A:Condition, A:Notes");
            tw1.WriteLine("UPC, Quantity, Price, Condition, Comment, Private Notes, SKU");


            //int actionCounter = 0;
            while (data.Read()) {
                tbSKU.Text = data["SKU"].ToString();  //  for debugging purposes only!

                if (cbPurgeReplace.Checked == true && data["Stat"].ToString() == "Sold")
                    continue;  //  if purge/replace and Sold, don't upload

                if (data["Stat"].ToString() == "Hold")
                    continue;  //  don't export

                if (data["UPC"].ToString().Length < 10)  //  can only take items with UPCs
                    continue;

                buildCSVDelimitedFile(data);
                count++;
            }  //  end while

            tw1.Close();  //  close the stream

            if (data != null)  //  close the data reader
                data.Close();

            Cursor.Current = Cursors.Default;

            lbUploadStatus.Items.Insert(0, "CSV-delimited format export(s) completed: " + count + " items exported to file " + sFileName1);
            lbUploadStatus.Refresh();

            return 0;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    build a CSV file
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void buildCSVDelimitedFile(FbDataReader data) {

            string workingDescrField = "";
            string dataBuild = "";

            string tempUPC = data["UPC"].ToString().StartsWith("B") ? "" : data["UPC"].ToString();
            dataBuild = tempUPC + ", ";
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

            dataBuild += data["SKU"].ToString();    //  SKU

            tw1.WriteLine(dataBuild);
            return;
        }


        ////-----------------------------    create export command string    ----------------------------------------------------
        //public string createExportCommandString() {
        //    if (rbExportAll.Checked == true)  //  are we exporting all of the items?
        //        commandString = "SELECT * from tMedia WHERE Stat = 'For Sale'";
        //    else  //  no... find out what we are trying to export
        //    {
        //        if (rbExportInclusiveSearch.Checked == true)  //  are we exporting from the search tab?
        //        {
        //            if (inclusiveSearchString.Length == 0) {
        //                MessageBox.Show("Error: you must use Inclusive Search to fill Database Panel", "Prager Media Inventory Manager",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //            else
        //                commandString = inclusiveSearchString.Replace("SKU, Title, UPC, Quantity, Locn, Price, Stat, InvoiceNbr", "*");
        //        }
        //        else if (rbExportSelected.Checked == true)  //  user has selected which items to export in Database panel
        //        {
        //            //  create the command string, concatening all of the SKU's
        //            commandString = "SELECT * from tMedia where Stat <> 'Pending' and SKU IN ('";

        //            //  find out which items have been selected
        //            ListView.SelectedIndexCollection listData = dataBasePanel.SelectedIndices;
        //            foreach (int lvIndex in listData)
        //                commandString += dataBasePanel.Items[lvIndex].SubItems[0].Text + "', '";

        //            commandString = commandString.Substring(0, commandString.Length - 4) + "')";
        //        }
        //        else { //  we are doing a regular export from the Export tab
        //            if (changedExportDateTime == false)
        //                commandString = "SELECT * from tMedia where Stat <> 'Hold' and " +
        //                    "Stat <> 'Pending' and " +
        //                    "DateU >= '" + lastExport.ToString("yyyy-MM-dd HH:mm:ss") + "'";
        //            else
        //                commandString = "SELECT * from tMedia where Stat <> 'Hold' and " +
        //                    "Stat <> 'Pending' and " +
        //                    "DateU >= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
        //        }
        //    }
        //return commandString;
        //}
    }
}

