#define COMPILED4OTHERS

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


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    parse HB OLD format for IMPORT
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //static int count = 1;
        private void ParseHBInputOldFormat()  //  starting at the beginning, go thru the array and build the row
        {
            string dataSubString;
            int i;
            int lineCount = InputData.Count;

            foreach (string dataString in InputData) {
                if (dataString != null && dataString != "") {
                    dataSubString = dataString.Substring(0, 4);  //  get the first 4 characters
                    switch (dataSubString) {
                        case "HDRS":  //  the following are only used for exporting
                            break;
                        case "PRCT":  //  inventory program name and version
                            if (dataString.Substring(0, 11) != @"PRCT|HBV3.0" && dataString.Substring(0, 11) != @"PRCT|HBV2.0") {
                                MessageBox.Show("Invalid input file format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            break;
                        case "DATE":
                        case "TIME":
                        case "HVER":
                        case "USER":
                        case "COMM":
                        case "SYST":
                        case "FNAM":
                        case "HPFM":
                        case "TRAN":
                        case "HDRE":  //  end of header
                            break;
                        case "ABLE":  //  not used
                            //                           MessageBox.Show("able: " + dataString);
                            break;
                        case "BOOS":  //  book start
                            resetStrings();  //  initialize BookRecord
                            break;
                        case "BOOK":  //  book number
                            i = dataString.Length - 5;
                            if (i > 15)
                                i = 15;
                            BookNumber = dataString.Substring(5, i);
                            break;
                        case "ANAM":  //  author
                            i = dataString.Length - 5;
                            if (i > 55)
                                i = 55;
                            Author = dataString.Substring(5, i);
                            break;
                        case "INAM":  //  name of illustrator
                            i = dataString.Length - 5;
                            if (i > 55)
                                i = 55;
                            Illustrator = dataString.Substring(5, i);
                            break;
                        case "TNAM":  //  title
                            i = dataString.Length - 5;
                            if (i > 100)
                                i = 100;
                            Title = dataString.Substring(5, i);

                            if (cbCreateKeywords.Checked)
                                Keywords = parseKeywords(Title);
                            break;
                        case "PBLS":  //  publisher
                            i = dataString.Length - 5;
                            if (i > 85)
                                i = 85;
                            Publisher = dataString.Substring(5, i);
                            break;
                        case "DESC":  //  description
                            i = dataString.Length - 5;
                            if (i == 0)
                                break;
                            if (i > 500)
                                i = 500;
                            Description = dataString.Substring(5, i);
                            break;
                        case "SGNT":
                            i = dataString.Length - 5;
                            if (dataString.Substring(5, i).Contains("Signed by Author"))
                                SignedBy = "A";
                            if (dataString.Substring(5, i).Contains("Signed by Illustrator"))
                                SignedBy = "I";
                            break;
                        case "PRIC":  //  price
                            i = dataString.Length - 5;
                            Price = dataString.Substring(5, i);
                            Price = Regex.Replace(Price, @"\$", "");  //  remove any $
                            break;
                        case "JACK":  //  jacket (yes or no)  <----------------------------
                            //                           MessageBox.Show("jack: " + dataString);
                            break;
                        case "BIND":  //  binding
                            i = dataString.Length - 5;
                            if (i > 15)
                                i = 15;
                            BookBinding = dataString.Substring(5, i);
                            break;
                        case "UPDT":  //  date updated  <-------------------------  TODO  local culture
                            i = dataString.Length - 5;
                            //string[] workingDate = dataString.Substring(5, i).Split('/');  //  en-AU -> 1/09/2006 
                            //if (mainForm.currentCulture.Name.ToString() == "en-US")
                            //    DateUpdated = workingDate[0] + "/" + workingDate[1] + "/" + workingDate[2];
                            //else
                            //    DateUpdated = workingDate[1] + "/" + workingDate[0] + "/" + workingDate[2];
                            DateUpdated = dataString.Substring(5, i);
                            break;
                        case "UPTM":  //  time last updated
                            i = dataString.Length - 5;
                            TimeUpdated = dataString.Substring(5, i);
                            DateUpdated = DateUpdated + " " + TimeUpdated;
                            break;
                        case "EDTN":  //  edition
                            i = dataString.Length - 5;
                            if (i > 15)
                                i = 15;
                            Edition = dataString.Substring(5, i);
                            break;
                        case "BCAT":  //  catalog
                            i = dataString.Length - 5;
                            if (i > 35)
                                i = 35;
                            Catalog = dataString.Substring(5, i);
                            break;
                        case "ISBN":  //  duh!
                            i = dataString.Length - 5;
                            if (i > 10)
                                i = 10;
                            ISBN = dataString.Substring(5, i).Trim();
                            r = new Regex(@"-\s*");  //  remove dashes and white space
                            ISBN = r.Replace(ISBN, "");
                            break;
                        case "JCKC":  //  dust jacket condition
                            i = dataString.Length - 5;
                            if (i > 25)
                                i = 25;
                            Jacket = dataString.Substring(5, i);
                            break;
                        case "BNDC":  //  binding
                            i = dataString.Length - 5;
                            if (i > 15)
                                i = 15;
                            BookBinding = dataString.Substring(5, i);
                            if (BookBinding.Contains("Mass Market") == true)
                                BookBinding = "MMPB";
                            break;
                        case "BOOC":  //  book condition  
                            i = dataString.Length - 5;
                            if (i > 25)
                                i = 25;
                            Condition = dataString.Substring(5, i);
                            break;
                        case "PBPL":  //  publisher location
                            i = dataString.Length - 5;
                            if (i > 25)
                                i = 25;
                            PubPlace = dataString.Substring(5, i);
                            break;
                        case "PDSC":  //  private notes
                            i = dataString.Length - 5;
                            if (i > 50)
                                i = 50;
                            Notes = dataString.Substring(5, i);
                            break;
                        case "STAT":  //  status
                            i = dataString.Length - 5;
                            if (i > 10)
                                i = 10;
                            Status = dataString.Substring(5, i);

                            switch (Status) {
                                case "For Sale":
                                    Status = "For Sale";
                                    Quantity = Quantity == 0 ? 1 : Quantity;
                                    break;
                                case "On Hold":
                                case "Pending":
                                    Status = "Hold";
                                    Quantity = Quantity == 0 ? 1 : Quantity;
                                    break;
                                case "Sold":
                                    Status = "Sold";
                                    Quantity = 0;
                                    break;
                                default:
                                    if (rbMark4Sale.Checked) { //  default
                                        Status = "For Sale";
                                        Quantity = Quantity == 0 ? 1 : Quantity;
                                    }
                                    else {
                                        Status = "Sold";
                                        Quantity = 0;
                                    }
                                    break;
                            }
                            break;
                        case "PPRC":  //  cost
                            i = dataString.Length - 5;
                            Cost = dataString.Substring(5, i);
                            break;
                        case "PBYR":  //  year published
                            i = dataString.Length - 5;
                            if (i > 4)
                                i = 4;
                            PubYear = dataString.Substring(5, i);
                            break;
                        case "LOCA":  //  location
                            i = dataString.Length - 5;
                            if (i > 10)
                                i = 10;
                            Locn = dataString.Substring(5, i);
                            break;
                        case "QNTY":  //  quantity
                            i = dataString.Length - 5;
                            if (i > 3)
                                i = 3;
                            Quantity = int.Parse(dataString.Substring(5, i));
                            break;
                        case "BOOE":  //  indicates end of book listing
                            if (BookNumber.Length == 0 && cbAutomaticSKU.Checked == true) {
                                Int64 lastKey = findHighestBookNbr();
                                lastKey = lastKey + 1;
                                BookNumber = lastKey.ToString();  //  pad w/ zeros
                            }

                            if (BookNumber.Length == 0 || Title.Length == 0 || Price.Length == 0) {  //  reject book
                                lbRejectedRecords.Items.Insert(0, "Record rejected during parsing of input: Book Nbr=" + BookNumber + " ISBN=" + ISBN);
                                lbRejectedRecords.Refresh();
                                lRecordsRejected.Text = "Records rejected: " + ++rejectedCount;
                                lRecordsRejected.Refresh();
                                break;
                            }

                            if (Illustrator == "")
                                Illustrator = " ";  //  correct so spaces show vs null
                            if (Edition == "")
                                Edition = " ";
                            if (SignedBy == "")
                                SignedBy = " ";
                            if (BookType == "")
                                BookType = " ";
                            if (BookSize == "")
                                BookSize = " ";
                            if (PubYear == "")
                                PubYear = " ";
                            if (Notes == "")
                                Notes = " ";
                            if (Edition == "")
                                Edition = " ";
                            if (Locn == "")
                                Locn = " ";
                            if (Author == "")
                                Author = " ";
                            if (Publisher == "")
                                Publisher = " ";
                            if (Cost.Length == 0)
                                Cost = "0.00";

                            if (cbDontImportSold.Checked == true && Status.ToString() == "Sold")  //  don't import
                                break;

                            if (Status.Length == 0)  //  book has no status, therefore take the marked default
                            {
                                if (rbMarkAsForSale.Checked == true) {
                                    Status = "For Sale";
                                    Quantity = Quantity == 0 ? 1 : Quantity;
                                }
                                else
                                    if (rbMarkAsSold.Checked == true) {
                                        Status = "Sold";
                                        Quantity = 0;
                                    }
                                    else {
                                        Status = "Sold";  //  default
                                        Quantity = 0;
                                    }
                            }

                            addButtonClicked = false; //  we don't want to export these records

                            tBooksAddBook();  //  add record

                            lRecordsProcessed.Text = "Records Processed: " + count++;
                            lRecordsProcessed.Refresh();
                            Application.DoEvents();
                            break;
                        case "SIGN":
                            break;
                        case "SIZE":  //  size
                            i = dataString.Length - 5;
                            if (i > 35)
                                i = 35;
                            BookSize = dataString.Substring(5, i);
                            break;
                        case "BTYP":  //  book type ("Ex-Library")
                            i = dataString.Length - 5;
                            if (i > 10)
                                i = 10;
                            BookType = dataString.Substring(5, i);
                            break;
                        case "UBID":  //  unique book id (different from my id)
                        case "TRLS":
                        case "TADD":
                        case "TDEL":
                        case "TCNT":
                        case "TRLE":
                            break;
                        default:
                            lbStatus.Items.Insert(0, "unknown record code: " + dataSubString);
                            lbStatus.Refresh();
                            break;
                    }

                }
            }

        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create a file in HomeBase format to EXPORT
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //TextWriter tw1;
        public int exportHBData(string formattedDate) {
            Cursor.Current = Cursors.WaitCursor;

            if (rbExportAll.Checked == false && rbChangeDate.Checked == false && rbExportInclusiveSearch.Checked == false && rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            lbUploadStatus.Items.Insert(0, "HomeBase format export started");
            lbUploadStatus.Refresh();

//#if EXPORTTESTING
//                exportPath = @"d:\temp\prager\export\";  //  create normal export file
//#endif
            if (cbPurgeReplace.Checked == true)
                sFileName1 = exportPath + "purgeHB" + formattedDate + ".txt";
            else
                sFileName1 = exportPath + "HB" + formattedDate + ".txt";

            try {
                tw1 = new StreamWriter(sFileName1);

                //  now, build and write header information (this is in the try block just in case tw1 is null)
                tw1.WriteLine("HDRS|");
                tw1.WriteLine("PRCT|HBV3.0");
                tw1.WriteLine("DATE|" + DateTime.Now);
                tw1.WriteLine("TIME|" + DateTime.Now.TimeOfDay);
                tw1.WriteLine("HVER|2.3.19");
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
                else if (e.ToString().Contains("The device is not ready.")) {
                    MessageBox.Show("The drive is unavailable; please check your settings in Inventory.cfg file", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }


#if COMPILED4OTHERS
            if (ABEUID.Length > 0)
                tw1.WriteLine("USER|" + ABEUID);
            else if (BiblioUID.Length > 0)
                tw1.WriteLine("USER|" + BiblioUID);
#else
            tw1.WriteLine("USER|Prager");
#endif
            tw1.WriteLine("COMM|");
            tw1.WriteLine("SYST|PROD");
            tw1.WriteLine("FNAM|" + sFileName1);
            tw1.WriteLine("HPFM|");
            tw1.WriteLine("HDRE|");

            createExportCommandString();

            //  find books in table
            FbCommand command = new FbCommand(commandString, bookConn);

            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();

            FbDataReader dataReader = command.ExecuteReader();

            int countSold = 0;
            int count4Sale = 0;
            int count = 0;
            //string debuggingInfo = "";

            while (dataReader.Read()) {

                if (dataReader["Stat"].ToString() == "Hold")
                    continue;  //  don't export (12.0.8)

                tbBookNbr.Text = dataReader["BookNbr"].ToString();  //  for debugging purposes only!

                tw1.WriteLine("BOOS|");  //  "Book Start"
                tw1.WriteLine("BOOK|" + dataReader["BookNbr"].ToString());  //  SKU

                if (dataReader["Stat"].ToString() == "Sold")  //  check cbpurgereplace  <---------------------- TODO
                {
                    tw1.WriteLine("TRAN|D");
                    countSold++;
                }
                else {
                    if (dataReader["Stat"].ToString() == "For Sale")
                        tw1.WriteLine("TRAN|A");
                    count4Sale++;
                }

                if (dataReader["Author"] != DBNull.Value)
                    tw1.WriteLine("ANAM|" + dataReader["Author"].ToString());  //  author

                if (dataReader["Illus"] != DBNull.Value)
                    tw1.WriteLine("INAM|" + dataReader["Illus"].ToString());

                tw1.WriteLine("TNAM|" + dataReader["Title"].ToString());

                if (dataReader["Pub"] != DBNull.Value)
                    tw1.WriteLine("PBLS|" + dataReader["Pub"].ToString());

                if (dataReader["Keywds"] != DBNull.Value)
                    tw1.WriteLine("SUB1|" + dataReader["Keywds"].ToString());

                if (dataReader["Descr"] != DBNull.Value)
                    tw1.WriteLine("DESC|" + dataReader["Descr"].ToString());

                tw1.WriteLine("PRIC|" + dataReader["Price"]);  //  price

                if (dataReader["Jaket"].ToString() != "Missing" && dataReader["Jaket"].ToString() != "None As Issued")
                    tw1.WriteLine("JCKC|" + dataReader["Jaket"].ToString());  //  (10.5.6)
                else
                    tw1.WriteLine("JCKC|No Jacket ");

                if (dataReader["Bndg"] != DBNull.Value && dataReader["Bndg"].ToString().Length >= 4) {
                    if (dataReader["Bndg"].ToString().Substring(0, 4) == "Hard")
                        tw1.WriteLine("BIND|H");
                    else
                        tw1.WriteLine("BIND|S");
                }

                if (dataReader["Ed"] != DBNull.Value) {
                    if (dataReader["Ed"].ToString() == "First Edition")
                        tw1.WriteLine("EDTN|F");
                }

                if (dataReader["Signed"] != DBNull.Value) {
                    if (dataReader["Signed"].ToString() == "A")
                        tw1.WriteLine("SIGN|A");
                    else
                        if (dataReader["Signed"].ToString() == "I")
                            tw1.WriteLine("SIGN|I");
                }

                if (dataReader["DateU"] != DBNull.Value) {
                    string workingDateTime = dataReader["DateU"].ToString();
                    string[] dateTime = workingDateTime.Split(' ');
                    tw1.WriteLine("UPDT|" + dateTime[0]); //  date updated
                    tw1.WriteLine("UPTM|" + dateTime[1]);  //   + ' ' + dateTime[2]); //  time updated
                }

                if (dataReader["Cat"] != DBNull.Value)  //  catalog
                    tw1.WriteLine("BCAT|" + dataReader["Cat"].ToString());

                tw1.WriteLine("ABLE|1");

                if (dataReader["ISBN"] != DBNull.Value) {
                    string tempISBN = dataReader["ISBN"].ToString().StartsWith("B") ? "" : dataReader["ISBN"].ToString();
                    tw1.WriteLine("ISBN|" + tempISBN);  //  ISBN
                }
                if (dataReader["Ed"] != DBNull.Value)
                    tw1.WriteLine("EDNT|" + dataReader["Ed"].ToString());  //  edition

                if (dataReader["Signed"] != DBNull.Value)  //  signed
                    tw1.WriteLine("SGNT|" + dataReader["Signed"].ToString());

                //if (dataReader["Jaket))
                //    tw1.WriteLine("JCKC|" + dataReader["Jaket));  //  jacket condition

                if (dataReader["Bndg"] != DBNull.Value)
                    tw1.WriteLine("BNDC|" + dataReader["Bndg"].ToString());  //  binding

                if (dataReader["PubPlace"] != DBNull.Value)
                    tw1.WriteLine("PBPL|" + dataReader["PubPlace"].ToString());

                if (dataReader["PubYear"] != DBNull.Value)
                    tw1.WriteLine("PBYR|" + dataReader["PubYear"].ToString());  //  year published

                if (dataReader["Condn"] != DBNull.Value)
                    tw1.WriteLine("BOOC|" + dataReader["Condn"].ToString());

                if (dataReader["BookType"] != DBNull.Value)
                    tw1.WriteLine("BTYP|" + dataReader["BookType"].ToString());  //  book type (ie ex-lib)

                if (dataReader["BookSize"] != DBNull.Value) {
                    string[] tempSize = dataReader["BookSize"].ToString().Split(' ');
                    tw1.WriteLine("SIZE|" + tempSize[1] + tempSize[2] + tempSize[3] + tempSize[4]);
                }

                tw1.WriteLine("STAT|" + dataReader["Stat"].ToString());

                if (dataReader["Cost"] != DBNull.Value)
                    tw1.WriteLine("PPRC|" + dataReader["Cost"].ToString());  //  cost

                if (dataReader["Locn"] != DBNull.Value)
                    tw1.WriteLine("LOCA|" + dataReader["Locn"].ToString());

                tw1.WriteLine("BOOE|");

                count++;  //  increment counter
            }

            //  now, build and write trailer information
            tw1.WriteLine("TRLS|");
            tw1.WriteLine("PRCT|HBV3.0");
            tw1.WriteLine("DATE|" + DateTime.Now);
            tw1.WriteLine("TIME|" + DateTime.Now.TimeOfDay);
            tw1.WriteLine("HVER|2.3.19");
            //#if COMPILED4OTHERS
            //                tw1.WriteLine("USER|" + tbExportUserID.Text);
            //#else
            //                tw1.WriteLine("USER|Prager");
            //#endif
            tw1.WriteLine("COMM|");
            tw1.WriteLine("SYST|PROD");
            tw1.WriteLine("FNAM|" + sFileName1);
            tw1.WriteLine("HPFM|");
            tw1.WriteLine("HDRE|");
            tw1.WriteLine("TADD|" + count4Sale);
            tw1.WriteLine("TDEL|" + countSold);
            i = count4Sale + countSold;
            tw1.WriteLine("TCNT|" + i);
            tw1.WriteLine("TRLE|");

            tw1.Close();  //  close the stream
            Cursor.Current = Cursors.Default;

            if (dataReader != null)  //  close the data reader
                dataReader.Close();

            lbUploadStatus.Items.Insert(0, "HomeBase format export completed: " + count + " books exported to file " + sFileName1);
            lbUploadStatus.Refresh();

            return 0;

        }


    }
}

