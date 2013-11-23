using System;
using System.IO;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;


namespace Prager_Book_Inventory
{
    class PapaMedia
    {

        //enum tBooks : int  //  enumerations for tBooks table (also found in MainForm)
        //{
        //    BookNbr, Title, Author, ISBN, Illus, Locn, Price, Cost, TranC, Pub, PubPlace, PubYear, Keywds, Descr, Jaket, Bndg,  //  0-15
        //    Condn, Ed, Signed, Type, Size, DateA, DateU, Cat, Notes, Stat, InvoiceNbr, ExpediteShip, IntlShip, SubCategory,  //  16-29
        //    DoNotReprice, NbrOfPages, BookWeight, ImageFileName, NbrOfCopies, Quantity, Shipping   //  30-36
        //};

        public PapaMedia()  //  constructor
        {
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create tab-delimited file
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int createTabDelimitedFile(mainForm mf, FbConnection bookConn, string PapaMediaUID, string exportPath, string commandString) {
            Cursor.Current = Cursors.WaitCursor;

            mf.lbUploadStatus.Items.Insert(0, "Papa Media format export started ");
            mf.lbUploadStatus.Refresh();

            DateTime exportStartDateTime = DateTime.Now;  //  do it now because of latency
            string formattedDate = DateTime.Now.ToString("MMddyyyyHHmmss");

            mf.createExportCommandString();  //  create command string

            if (mf.rbExportAll.Checked == false && mf.rbChangeDate.Checked == false && mf.rbExportInclusiveSearch.Checked == false && mf.rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (mf.cbPurgeReplace.Checked)  //  doing a purge/replace?
                mf.sFileName1 = exportPath + "purge" + formattedDate + "-" + PapaMediaUID + ".txt";  //  must have email address in filename
            else  //  no just exporting those that were changed
                mf.sFileName1 = exportPath + formattedDate + "-" + PapaMediaUID + ".txt";

            TextWriter tw = null;
            try {
                tw = new StreamWriter(mf.sFileName1);  //  for normal tab-delimited files
            }
            catch (Exception e) {
                if (e.ToString().Substring(10, 26) == "DirectoryNotFoundException") {
                    try {
                        DirectoryInfo di = Directory.CreateDirectory(exportPath);   // Try to create the directory
                        tw = new StreamWriter(mf.sFileName1);
                    }
                    catch (Exception e1) {
                        MessageBox.Show("Unable to create export directory: " + e1.Message, "Prager Book Inventory Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }

            mf.createExportCommandString();
            ConvertISBN ci = new ConvertISBN();

            //  find books in table
            FbCommand command = new FbCommand(commandString, bookConn);
            FbDataReader data = command.ExecuteReader();

            int count = 0;

            //  write header
            tw.WriteLine("Code\tAlternate Code\tTitle\tAuthor\tFormat\tCondition\tPrice ($)\tStatus\tQuantity\tWeight (gms)\tComments");

            while (data.Read()) {
                if (mf.cbPurgeReplace.Checked && data.GetString(25) == "Sold")
                    continue;  //  if purge/replace and Sold, don't upload
                
                if (data.GetString(25) == "Hold")
                    continue;  //  don't upload

                if (buildTabDelimitedFile(data, tw, ci))
                    count++;  //  increment counter
            }

            tw.Close();  //  close the stream

            if (data != null)  //  close the data reader
                data.Close();

            Cursor.Current = Cursors.Default;
            mf.lbUploadStatus.Items.Insert(0, "Papa Media format export completed: " + count + " books exported to file " + mf.sFileName1);
            mf.lbUploadStatus.Refresh();

            return 0;

        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    build a TAB delimited format file
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private bool buildTabDelimitedFile(FbDataReader data, TextWriter tw, ConvertISBN ci) {
            //   tw.WriteLine("Code\tAlternate Code\tTitle\tAuthor\tFormat\tCondition\tPrice\tStatus\tQuantity\tWeight\tComments");

            string dataBuild = "";
            string tempStatus = "";
            //string tempISBN = "";
            string ISBN = "";

            ISBN = data["ISBN"].ToString();

            if (ISBN.Length == 10)
                dataBuild = ISBN + "\t\t";  //  ISBN (required)
            else if (ISBN.Length == 13)
                dataBuild = "\t" + ISBN + "\t";
            else
                return false;

            dataBuild += data["Title"].ToString() + "\t";  //  title

            dataBuild += data["Author"].ToString() + "\t";  //  author

            dataBuild += data["Bndg"].ToString() + "\t";  //  format

            string tempCond = "";
            if (data["Condn"] != DBNull.Value) {
                switch (data["Condn"].ToString().ToLower()) {
                    case "new":
                    case "as new":
                    case "new book":
                    case "fine":
                    case "fine - used":
                    case "fine - collectible":
                    case "used; like new":  //  amazon
                    case "collectible; like new":
                        tempCond = "New ";
                        break;
                    case "very good":
                    case "very good - used":
                    case "very good - collectible":
                    case "used; very good":  //  amazon
                    case "collectible; very good":
                    case "good":
                    case "good - used":
                    case "good - collectible":
                    case "used; good":  //  amazon
                    case "collectible; good":
                    case "fair":
                    case "fair - used":
                    case "poor":
                    case "poor - used":
                    case "fair - collectible":
                    case "poor - collectible":
                    case "used; acceptable":  //  amazon
                    case "collectible; acceptable":
                        tempCond = "Used";
                        break;
                    default:
                        tempCond = "Used";
                        break;
                }
                dataBuild += tempCond + "\t";  //  condition (required)
            }
            else
                return false;    //  add reason?         <----------------  TODO

            dataBuild += data["Price"].ToString() + "\t";  //  price

            if (data["Stat"] != DBNull.Value) {
                tempStatus = data["Stat"].ToString() == "For Sale" ? "A" : "D";
                dataBuild += tempStatus + "\t";  //  status (required)
            }
            else
                return false;  //  should never get here...

            dataBuild += data["Quantity"].ToString() + "\t";  //  quantity (required)

            dataBuild += " \t";  //  weight

            if (data["Descr"] != DBNull.Value)
                dataBuild += data["Descr"].ToString();  //  description (comments)
            else
                dataBuild += "";

            tw.WriteLine(dataBuild);
            return true;
        }

    }

}
