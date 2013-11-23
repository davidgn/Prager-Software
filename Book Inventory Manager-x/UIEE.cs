
#region Using directives

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

#endregion


namespace Prager_Book_Inventory
{

    partial class mainForm : Form
    {

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create an input record from the UIEE data
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void ParseUIEEInput() {
            //int count = 1;
            string dataSubString;
            int i;
            bool doNotList = false;

            Cursor.Current = Cursors.WaitCursor; //  change cursor to 'wait'
            /*
            In the BOOKS set, the following tokens must always appear, and should appear in this order:

            UR or RE User Record Number (UR preferred, RE supported for compatibility).
            TI Book Title
            (remaining fields appear in any order)
            PR Price (parsed in For-Sale records only).
            XA Lifespan
            XB Action Code
            XC Family Code
            XD Database Code

            */
            //lbStatus.Items.Insert(0, "import started");
            //lbStatus.Refresh();

            Cursor.Current = Cursors.WaitCursor;

            foreach (string dataString in InputData) {
                if (dataString != null && dataString != "" && dataString.Length != 1)  //  is this a valid record?
                {
                    if (dataString.Substring(0, 2) == "\r\n")  //  indicates end of record
                    {
                        processCRLF(ref doNotList);
                        continue;
                    }

                    if (dataString.Length > 3 && dataString.Substring(2, 1) != "|")   //  if pipe symbol is missing, ignore line
                    {
                        lbRejectedRecords.Items.Insert(0, "Line not recognized (ignored): " + dataString);
                        lbRejectedRecords.Refresh();
                        continue;  //  get next line
                    }

                    dataSubString = dataString.Substring(0, 2);  //  get the first 2 characters
                    switch (dataSubString) {
                        case "UR":  //  book number
                            i = dataString.Length - 3;
                            if (i > 15)
                                i = 15;
                            BookNumber = dataString.Substring(3, i);
                            break;
                        case "AA":  //  author
                            i = dataString.Length - 3;
                            if (i > 55)
                                i = 55;
                            Author = dataString.Substring(3, i);
                            break;
                        case "AI":  //  name of illustrator
                            i = dataString.Length - 3;
                            if (i > 55)
                                i = 55;
                            Illustrator = dataString.Substring(3, i);
                            break;
                        case "CA":  //  Catalog entry (ignore for now)
                            //    i = dataString.Length - 3;
                            //    if (i > 50)
                            //        i = 50;
                            //    Catalog = dataString.Substring(3, i);
                            break;
                        case "TI":  //  title
                            i = dataString.Length - 3;
                            if (i > 100)
                                i = 100;
                            Title = dataString.Substring(3, i);
                            break;
                        case "PU":  //  publisher
                            i = dataString.Length - 3;
                            if (i > 85)
                                i = 85;
                            Publisher = dataString.Substring(3, i);
                            break;
                        case "KE":  //  keywords
                            i = dataString.Length - 3;
                            if (i > 85)
                                i = 85;
                            Keywords = dataString.Substring(3, i);
                            break;
                        case "IM":  //  keywords
                            i = dataString.Length - 3;
                            if (i > 256)
                                i = 256;
                            ImageFileName = dataString.Substring(3, i);
                            break;
                        case "NT":  //  description
                            i = dataString.Length - 3;
                            if (i > 500)
                                i = 500;
                            Description = dataString.Substring(3, i);
                            SignedBy = "";  //  clear out
                            if (Description.IndexOf("Signed by Author", 0, i) > 0)
                                SignedBy = "A";
                            if (Description.IndexOf("Signed by Illustrator", 0, i) > 0)
                                SignedBy = "I";
                            break;
                        case "PR":  //  price
                            i = dataString.Length - 3;
                            Price = dataString.Substring(3, i);
                            break;
                        case "BD":  //  binding
                            i = dataString.Length - 3;
                            if (i > 15)
                                i = 15;
                            BookBinding = dataString.Substring(3, i);
                            break;
                        //case "DS":  //  date updated (system date)
                        case "DT":
                            i = dataString.Length - 5;
                            DateUpdated = dataString.Substring(5, i);
                            break;
                        case "ED":  //  edition
                            i = dataString.Length - 3;
                            if (i > 15)
                                i = 15;
                            Edition = dataString.Substring(3, i);
                            break;
                        //case "FC":  //  catalog and sub-category delimited by #
                        //    string[] catNSubCat;
                        //    if (dataString.Contains("#"))
                        //    {
                        //        catNSubCat = dataString.Substring(3, dataString.Length - 3).Split('#');
                        //        Catalog = catNSubCat[0];
                        //        SubCategory = catNSubCat[1];
                        //    }
                        //    else
                        //    {
                        //        i = dataString.Length - 3;
                        //        if (i > 35)
                        //            i = 35;
                        //        Catalog = dataString.Substring(3, i);
                        //    }
                        //    break;
                        //case "NC":
                        //    if(dataString.Length == 13  //  isbn?
                        case "BN":  //  ISBN
                            i = dataString.Length - 3;
                            ISBN = dataString.Substring(3, i).Trim();
                            r = new Regex(@"-\s*");
                            ISBN = r.Replace(ISBN, "");
                            break;
                        case "JK":  //  dust jacket condition
                            i = dataString.Length - 3;
                            if (i > 25)
                                i = 25;
                            Jacket = dataString.Substring(3, i);
                            break;
                        case "CN":  //  book condition
                            i = dataString.Length - 3;
                            if (i > 25)
                                i = 25;
                            switch (dataString.ToLower().Substring(3, i)) {
                                case "fine":
                                case "fine - used":
                                case "fine - collectible":
                                    Condition = dataString.Substring(3, i);
                                    break;
                                case "very good":
                                case "very good - used":
                                case "very good - collectible":
                                case "vg":
                                    Condition = dataString.Substring(3, i);
                                    break;
                                case "good":
                                case "good - used":
                                case "good - collectible":
                                case "g":
                                    Condition = dataString.Substring(3, i);
                                    break;
                                case "fair":
                                case "fair - used":
                                case "fair - collectible":
                                    Condition = dataString.Substring(3, i);
                                    break;
                                case "poor":
                                case "poor - used":
                                case "poor - collectible":
                                    Condition = dataString.Substring(3, i);
                                    break;
                                case "new":
                                case "new book":
                                    Condition = dataString.ToLower().Substring(3, i);
                                    break;
                                default:
                                    Condition = "Unknown";
                                    break;
                            }
                            break;
                        case "CO":  //  number of copies available 
                            i = dataString.Length - 3;
                            if (i > 3)
                                i = 3;
                            Quantity = int.Parse(dataString.Substring(3, i));
                            break;
                        case "PP":  //  publisher location
                            i = dataString.Length - 3;
                            if (i > 25)
                                i = 25;
                            PubPlace = dataString.Substring(3, i);
                            break;
                        case "AN":  //  private notes
                            i = dataString.Length - 3;
                            if (i > 50)
                                i = 50;
                            Notes = dataString.Substring(3, i);
                            break;
                        case "IS":  //  status
                            i = dataString.Length - 3;
                            if (dataString.ToLower().Contains("available"))
                                Status = "For Sale";
                            else
                                Status = dataString.Substring(3, i);
                            break;
                        case "PC":  //  cost
                            i = dataString.Length - 3;
                            Cost = dataString.Substring(3, i);
                            break;
                        case "PG":  //  number of pages
                            i = dataString.Length - 3;
                            NbrOfPages = dataString.Substring(3, i);
                            break;
                        case "SD":  //  date added?
                            i = dataString.Length - 3;
                            DateAdded = dataString.Substring(3, i);
                            DateAdded = Regex.Replace(DateAdded, "AM|PM|a.m.|p.m.", "");
                            break;
                        case "DP":  //  year published
                            i = dataString.Length - 3;
                            if (i > 4)
                                i = 4;
                            PubYear = dataString.Substring(3, i);
                            break;
                        case "WT":  //  book weight
                            i = dataString.Length - 3;
                            if (i > 6)
                                i = 6;
                            BookWeight = dataString.Substring(3, i);
                            break;
                        case "LO":  //  location
                            i = dataString.Length - 3;
                            if (i > 10)
                                i = 10;
                            Locn = dataString.Substring(3, i);
                            break;
                        case "TP":  //  size and type
                            i = dataString.Trim().Length - 3;
                            if (i == 0)  //  nothing in size or type
                                break;
                            if (i > 35)
                                i = 35;
                            string[] sizeAndType = dataString.Substring(3, i).Split('/');
                            if (sizeAndType.Length == 2) {
                                BookSize = sizeAndType[0];
                                BookType = sizeAndType[1];
                            }
                            else
                                BookSize = dataString.Substring(3, i);
                            break;
                        case "XA":  //  lifespan
                            break;
                        case "XB":  //  status
                            switch (dataString.Substring(0, 4)) {
                                case "XB|1":
                                    Status = "For Sale";
                                    Quantity = 1;
                                    break;
                                case "XB|2":
                                    Status = "Sold";
                                    Quantity = 0;
                                    break;
                                case "XB|5":
                                    //lbStatus.Items.Insert(0, "Record rejected; XB=5: " + ISBN);
                                    //lbStatus.Refresh();
                                    //continue; 
                                    doNotList = true; //  don't import this book
                                    break;
                                case "XB|6":
                                    doNotList = true;
                                    Quantity = 1;
                                    break;
                                case "XB|7":
                                    Status = "Hold";
                                    Quantity = 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "XC":  //  family code (BO)
                        case "XD":  //  database code (S)
                            break;
                        case "LG":  //  Language
                            break;
                        default:
                            lbRejectedRecords.Items.Insert(0, "Invalid input line format: '" + dataSubString + "'");
                            lbRejectedRecords.Refresh();
                            break;
                    }  //  end switch
                    continue;
                }  //  end if statement (check for valid record)

            }   //  end foreach

            processCRLF(ref doNotList);  //  process final record...

            Cursor.Current = Cursors.Default;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    process a complete record based on final /r/n
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void processCRLF(ref bool doNotList) {
            if (BookNumber != null) {
                if (Illustrator == null)
                    Illustrator = "  ";  //  correct so spaces show vs null
                //if (ISBN == null)
                //    ISBN = "  ";  //  correct so spaces show vs null  r.marsh
                if (Edition == null)
                    Edition = " ";
                if (SignedBy == null)
                    SignedBy = " ";
                if (BookType == null)
                    BookType = " ";
                if (BookSize == null)
                    BookSize = " ";
                if (PubYear == null)
                    PubYear = " ";
                if (Notes == null)
                    Notes = " ";
                if (Keywords == null)
                    Keywords = " ";
                if (Cost == null)
                    Cost = "0.00";
                if (Locn == null)
                    Locn = " ";
                if (Author == null)
                    Author = " ";
                if (Publisher == null)
                    Publisher = " ";

                if (DateAdded == null || DateAdded.Length == 0) {
                    DateAdded = DateTime.Now.ToString("G");
                    DateAdded = Regex.Replace(DateAdded, "AM|PM|a.m.|p.m.", "");
                    DateUpdated = DateAdded;
                }

                if (cbDontImportSold.Checked == true && Status.ToString() == "Sold")  //  don't import
                    return;

                if (Status == null || Status.Length == 0)  //  book has no status, therefore take the marked default
                {
                    if (rbMarkAsForSale.Checked == true)
                        Status = "For Sale";
                    else
                        if (rbMarkAsSold.Checked == true)
                            Status = "Sold";
                        else
                            Status = "Sold";  //  default
                }

                if (doNotList == false && (BookNumber != null && BookNumber.Length > 4)) {
                    tBooksAddBook();  //  add record

                    lRecordsProcessed.Text = "Records Processed: " + count++;
                    lRecordsProcessed.Refresh();
                    Application.DoEvents();
                }
                else
                    doNotList = false;  //  if it was true, reset to false
            }

            resetStrings();  //  clear out old stuff
            return;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create an UIEE export record
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int createUIEEExportFile(string formattedDate, bool AmazonFlag) {
            bool errorFlag = false;
            int count = 0;

            Cursor.Current = Cursors.WaitCursor;

            lbUploadStatus.Items.Insert(0, "UIEE export started");
            lbUploadStatus.Refresh();

//#if EXPORTTESTING
//                exportPath = @"d:\temp\prager\export\";  //  create normal export file
//#endif

            if (cbPurgeReplace.Checked == true)
                sFileName1 = exportPath + "purgeUI" + formattedDate + ".txt";
            else
                sFileName1 = exportPath + "UI" + formattedDate + ".txt";

            try {
                tw1 = new StreamWriter(sFileName1);  //  open the output file
            }
            catch (Exception e) {
                if (e.ToString().Substring(10, 26) == "DirectoryNotFoundException") {
                    try {
                        if (Directory.Exists(exportPath)) {
                            return 0;
                        }
                        DirectoryInfo di = Directory.CreateDirectory(exportPath);   // Try to create the directory
                        tw1 = new StreamWriter(sFileName1);
                    }
                    catch (Exception e1) {
                        MessageBox.Show("UIEE Export failed:" + e1.ToString(), "Prager Book Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorFlag = true;
                        return -1;
                    }
                }
            }

            /*
            The UIEE file header consists of five lines of text which are common to all versions of UIEE:

            # Line 1 — User Id
            # Line 2 — Books
            # Line 3 — Date (MM-DD-YYYY)
            # Line 4 — Time (HH:MM:SS)
            # Line 5 — Blank [CR] [LF]
            */

            //  now, build and write header information
            if (errorFlag == false) {
                createExportCommandString();  //  command string to get all of the books for export

                //  find books in table
                FbCommand command = new FbCommand(commandString, bookConn);
                FbDataReader data = command.ExecuteReader();

                count = 0;
                string description = " ";
                string sizeType = " ";

                while (data.Read()) {
                    tbBookNbr.Text = data["BookNbr"].ToString();  //  for debugging purposes only!

                    if (data["Stat"].ToString() == "Hold")
                        continue;  //  don't export  (12.0.8)

                    lbExportList.Items.Insert(0, tbBookNbr.Text);
                    lbExportList.Refresh();

                    tw1.WriteLine("UR|" + data["BookNbr"].ToString());  //  book number

                    if (data["Author"] != DBNull.Value)
                        tw1.WriteLine("AA|" + data["Author"].ToString());  //  author

                    if (data["Illus"] != DBNull.Value)
                        tw1.WriteLine("AI|" + data["Illus"].ToString());  //  illustrator

                    tw1.WriteLine("TI|" + data["Title"].ToString());  //  Title

                    if (data["PubYear"] != DBNull.Value)
                        tw1.WriteLine("DP|" + data["PubYear"].ToString());  //  year published

                    if (data["Pub"] != DBNull.Value)
                        tw1.WriteLine("PU|" + data["Pub"].ToString());  //  publisher

                    if (data["PubPlace"] != DBNull.Value)
                        tw1.WriteLine("PP|" + data["PubPlace"].ToString());  //  publisher location

                    tw1.WriteLine("LG|English");  //  language

                    if (data["Ed"] != DBNull.Value)
                        tw1.WriteLine("ED|" + data["Ed"].ToString());  //  edition

                    if (data["Bndg"] != DBNull.Value)
                        tw1.WriteLine("BD|" + data["Bndg"].ToString());  //  binding

                    if (data["ISBN"] != DBNull.Value) {
                        string tempISBN = data["ISBN"].ToString().StartsWith("B") ? " " : data["ISBN"].ToString();
                        tw1.WriteLine("BN|" + tempISBN);  //  ISBN
                        tw1.WriteLine("NC|" + tempISBN);  //  temporary fix for A1Books
                    }

                    if (data["Condn"] != DBNull.Value)
                        tw1.WriteLine("CN|" + data["Condn"].ToString());  //  condition

                    if (data["Jaket"] != DBNull.Value)
                        tw1.WriteLine("JK|" + data["Jaket"].ToString());  // jacket

                    tw1.WriteLine("PR|" + (decimal)data["Price"]);  //  price

                    //  description is built here
                    if (data["Descr"] != DBNull.Value)
                        description = data["Descr"].ToString();

                    //  do signed
                    if (data["Signed"] != DBNull.Value) {
                        if (data["Signed"].ToString() == "A")
                            description += " Signed by Author";
                        else {
                            if (data["Signed"].ToString() == "I")
                                description += " Signed by Illustrator";
                            else {
                                if (data["Signed"].ToString() == "B")
                                    description += " Signed by Author and Illustrator";
                            }
                        }
                    }

                    tw1.WriteLine("NT|" + description);  //  description

                    string catalogNSubCategory = "";
                    if (data["Cat"] != DBNull.Value) {
                        catalogNSubCategory = data["Cat"].ToString();
                        if (data["SubCategory"] != DBNull.Value)
                            catalogNSubCategory += "-" + data["SubCategory"].ToString();

                        tw1.WriteLine("MT|" + catalogNSubCategory);  //  catalog and sub-category
                    }

                    if (data["Keywds"] != DBNull.Value)
                        tw1.WriteLine("KE|" + data["Keywds"].ToString().Trim());  //  keywords

                    if (data["Locn"] != DBNull.Value)
                        tw1.WriteLine("LO|" + data["Locn"].ToString());  //  location

                    if (data["NbrOfPages"] != DBNull.Value)
                        tw1.WriteLine("PG|" + data["NbrOfPages"].ToString());  // pages

                    if (data["BookWeight"] != DBNull.Value)
                        tw1.WriteLine("WT|" + data["BookWeight"].ToString());  // book weight

                    if (data["Cost"] != DBNull.Value)
                        tw1.WriteLine("PC|" + data["Cost"]);  //  cost

                    if (data["BookSize"] != DBNull.Value) {  //  book size/type  (11.5.9)
                        string[] tempSize = data["BookSize"].ToString().Split(' ');
                        sizeType = tempSize[1] + tempSize[2] + tempSize[3] + tempSize[4];
                    }
                    if (data["BookType"] != DBNull.Value) {  //  book type
                        if (sizeType.Length > 0)  //  size and type go together
                            sizeType += "/";
                        sizeType += data["BookType"].ToString();
                        tw1.WriteLine("TP|" + sizeType);
                    }

                    tw1.WriteLine("IS|" + data["Stat"].ToString());  //  status

                    tw1.WriteLine("XA|4");  // lifespan

                    if (data["Stat"].ToString() == "For Sale")
                        tw1.WriteLine("XB|1");  //  action code = 1 (For Sale)
                    else
                        tw1.WriteLine("XB|2");  //  action code = 2 (Sold)

                    tw1.WriteLine("XC|BO");  //  book family

                    tw1.WriteLine("XD|S");  //  database code

                    tw1.WriteLine("CO|" + data["Quantity"]);  //  quantity

                    tw1.WriteLine();

                    count++;  //  update counter
                }

                tw1.WriteLine(Environment.NewLine);  //  we're done!
                tw1.Close();  //  close the stream

                if (!data.IsClosed)  //  close the data reader
                    data.Close();

                Cursor.Current = Cursors.Default;
                lbUploadStatus.Items.Insert(0, "UIEE export completed: " + count + " books exported to file " + sFileName1);
                lbUploadStatus.Refresh();
            }  

            return count;  //  returns count of records

        }  
    }  
} 
