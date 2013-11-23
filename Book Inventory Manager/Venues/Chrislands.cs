//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using FirebirdSql.Data.FirebirdClient;
//using System.Windows.Forms;
using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Prager_Book_Inventory
{
    class Chrislands
    {
        TextWriter tw1, tw2;
        public int count1 = 0;
        public int count2 = 0;

        //--  create Chrislands tab Export file
        public int createChrislandsTabExportFile(string formattedDate, mainForm mf, string commandString, FbConnection databaseConn, string exportPath) {

            Cursor.Current = Cursors.WaitCursor;

            if (mf.rbExportAll.Checked == false && mf.rbChangeDate.Checked == false && mf.rbExportInclusiveSearch.Checked == false && mf.rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (mf.cbPurgeReplace.Checked)  //  doing a purge/replace?
                mf.sFileName1 = exportPath + "purgeChr" + formattedDate + ".tab";
            else {
                mf.sFileName1 = exportPath + "Chr" + formattedDate + ".tab";  //  defaults to add/modify
                mf.sFileName2 = exportPath + "deleteChr" + formattedDate + ".tab";  //  deleted records
            }

            try { //  look for Export directory
                tw1 = new StreamWriter(mf.sFileName1);  //  add/modify
                tw2 = new StreamWriter(mf.sFileName2);  //  deletes
            }
            catch (Exception e) {
                if (e.ToString().Substring(10, 26) == "DirectoryNotFoundException") {
                    try {
                        DirectoryInfo di = Directory.CreateDirectory(exportPath);   // Try to create the directory
                        tw1 = new StreamWriter(mf.sFileName1);
                        tw2 = new StreamWriter(mf.sFileName2);  //  12.4.2  added...
                    }
                    catch (Exception e1) {
                        MessageBox.Show("Unable to create export directory: " + e1.Message, "Prager Media Inventory Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }

            mf.createExportCommandString();  //  create export command string depending on what we're doing

            //  find items in table
            FbCommand command = new FbCommand(commandString, databaseConn);
            FbDataReader data = command.ExecuteReader();

            mf.lbUploadStatus.Items.Insert(0, "Chrislands export started");
            mf.lbUploadStatus.Refresh();

            //  write headers                          
            tw1.WriteLine("Seller ID\t Author\t Title\t Illustrator\t Book condition\t Book size\t Jacket condition\t " +
                "Binding\t Book type\t ISBN\t Publisher\t Publisher Place\t Publish Date\t Edition\t Inscription\t " +
                "Description\t Quantity\t Price\t Image\t Category 1\t Category 2\t Category 3\t Category 4\t Category 5\t " +
                "Keyword 1\t Keyword 1\t Keyword 1\t Keyword 1\t Keyword 1\t Keyword 1\t Keyword 1\t Keyword 1\t Keyword 1\t " +
                "Weight\t Featured Item");  //  add/modify
            if (!mf.cbPurgeReplace.Checked)
                tw2.WriteLine("Seller ID");  //  delete

            BuildChrislandsFile(mf, data);

            tw1.Flush();
            tw1.Close();  //  close the streams
            if (!mf.cbPurgeReplace.Checked) {
                tw2.Flush();
                tw2.Close();
            }

            if (data != null)  //  close the data reader
                data.Close();

            Cursor.Current = Cursors.Default;

            mf.lbUploadStatus.Items.Insert(0, "Chrislands export completed: " + count1 + " items exported to file " + mf.sFileName1);
            mf.lbUploadStatus.Items.Insert(0, "Chrislands export completed: " + count2 + " items exported to file " + mf.sFileName2);
            mf.lbUploadStatus.Refresh();

            return 0;
        }


        //--  build Chrislands tab file
        private void BuildChrislandsFile(mainForm mf, FbDataReader data) {

            string workingDescrField = "";
            string dataBuild = "";

            while (data.Read()) {

                if (data["Stat"].ToString() == "Hold")  //  we don't export these... (12.0.8)
                    continue;

                mf.tbBookNbr.Text = data["BookNbr"].ToString();  //  for debugging purposes only!

                string[] keyWords = data["Keywds"].ToString().Split(' ');  //  let's split them up

                if (mf.cbPurgeReplace.Checked && data["Stat"].ToString() == "Sold")
                    continue;  //  if purge/replace and Sold, don't upload

                //if (data["ISBN"].ToString().Length < 10)  //  can only take items with ISBNs
                //    continue;

                if (data["Quantity"].ToString() == "0" && !mf.cbPurgeReplace.Checked) {  //  delete record
                    dataBuild = data["BookNbr"].ToString();  //  deletes only need SKU
                    count2++;  //  increment counter
                    tw2.WriteLine(dataBuild);  //  write it out
                }
                else {
                    dataBuild = data["BookNbr"].ToString() + "\t ";  //  Seller ID (SKU)
                    dataBuild += data["Author"].ToString() + "\t ";  //  author
                    dataBuild += data["Title"].ToString() + "\t ";  //  title
                    //dataBuild += data["Illus"].ToString().Length == 0 ? "\t" : data["Illus"].ToString() + "\t ";  //  illustrator
                    dataBuild += data["Illus"].ToString() + "\t ";  //  illustrator

                    if (data["Condn"] != DBNull.Value)  //  book condition
                        switch (data["Condn"].ToString().ToLower()) {
                            case "new":
                            case "new book":
                                dataBuild += "New\t ";
                                break;
                            case "fine":
                            case "fine - used":
                            case "fine - collectible":
                            case "used; like new":  //  amazon
                            case "collectible; like new":
                            case "as new":
                            case "like new":
                                dataBuild += "Like New\t ";
                                break;
                            case "very good":
                            case "very good - used":
                            case "very good - collectible":
                            case "used; very good":  //  amazon
                            case "collectible; very good":
                                dataBuild += "Very Good\t ";
                                break;
                            case "good":
                            case "good - used":
                            case "good - collectible":
                            case "used; good":  //  amazon
                            case "collectible; good":
                                dataBuild += "Good\t ";
                                break;
                            case "fair":
                            case "fair - used":
                            case "poor":
                            case "poor - used":
                            case "fair - collectible":
                            case "poor - collectible":
                            case "used; acceptable":  //  amazon
                            case "collectible; acceptable":
                                dataBuild += "Acceptable\t ";
                                break;
                            default:
                                dataBuild += "Good\t ";
                                break;
                        }

                    dataBuild += data["BookSize"].ToString() + "\t ";  //  size
                    dataBuild += data["Jaket"].ToString() + "\t ";  //  jacket condition
                    dataBuild += data["Bndg"].ToString() + "\t ";  //  binding
                    dataBuild += data["BookType"].ToString() + "\t ";  //  book type
                    dataBuild += data["ISBN"].ToString() + "\t ";  //  ISBN
                    dataBuild += data["Pub"].ToString() + "\t ";  //  publisher
                    dataBuild += data["PubPlace"].ToString() + "\t ";  //  publisher location
                    dataBuild += data["PubYear"].ToString() + "\t ";  //  pub date
                    dataBuild += data["Ed"].ToString() + "\t ";  //  edition
                    dataBuild += "\t ";  //  inscription  (missing)

                    if (data["Descr"] != DBNull.Value) { //  description (notes)
                        workingDescrField = data["Descr"].ToString();
                        workingDescrField = workingDescrField.Replace("\"", "in. ");  //  replace " with the word 'in.'
                        dataBuild += workingDescrField.Replace('\t', ';') + "\t";
                    }
                    else
                        dataBuild += "\t ";  //  no description or private notes

                    dataBuild += data["Quantity"].ToString() + "\t ";  //  quantity
                    dataBuild += data["Price"].ToString() + "\t ";  //  price
                    dataBuild += "\t ";  //  image  <----------------- verify this is a URL\t not a filename
                    dataBuild += data["Cat"].ToString() + "\t "; //  catalog (category)
                    dataBuild += "\t\t\t" + "\t ";  //  category 2-5

                    //  do keywords
                    int keywordCount = keyWords.Length;
                    string[] validKeywords = { "", "", "", "", "", "", "", "", "" };
                    for (int i = 0, j = 0; i < keywordCount && j < 9; i++) {
                        if (keyWords[i].Length > 3 && String.IsNullOrWhiteSpace(keyWords[i]) == false)
                            validKeywords[j++] = keyWords[i];
                    }

                    //  keywords 1-9
                    dataBuild += validKeywords[0] + "\t" + validKeywords[1] + "\t" + validKeywords[2] + "\t" +
                        validKeywords[3] + "\t" + validKeywords[4] + "\t" + validKeywords[5] + "\t" +
                        validKeywords[6] + "\t" + validKeywords[7] + "\t" + validKeywords[8] + "\t"; 

                    dataBuild += data["BookWeight"].ToString() + "\t ";  //  book weight

                    tw1.WriteLine(dataBuild);  //  add/modify
                    count1++;

                }
            }

            return;
        }
    }
}
