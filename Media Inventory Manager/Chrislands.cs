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

namespace Media_Inventory_Manager
{
    class Chrislands
    {
        TextWriter tw1, tw2;
        public int count1 = 0;
        public int count2 = 0;

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create Chrislands CSV Export file
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int createChrislandsCSVExportFile(string formattedDate, mainForm mf, string commandString, FbConnection databaseConn, string exportPath) {

            Cursor.Current = Cursors.WaitCursor;

            if (mf.rbExportAll.Checked == false && mf.rbChangeDate.Checked == false && mf.rbExportInclusiveSearch.Checked == false && mf.rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (mf.cbPurgeReplace.Checked == true)  //  doing a purge/replace?
                mf.sFileName1 = exportPath + "purgeMChr" + formattedDate + ".tab";
            else {
                mf.sFileName1 = exportPath + "MChr" + formattedDate + ".tab";  //  defaults to add/modify
                mf.sFileName2 = exportPath + "deleteMChr" + formattedDate + ".tab";  //  deleted records
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
            tw2.WriteLine("Seller ID");  //  delete

            buildChrislandsFile(mf, data);

            //  close the streams
            tw1.Flush();
            tw1.Close();
            tw2.Flush();
            tw2.Close();

            if (data != null)  //  close the data reader
                data.Close();

            Cursor.Current = Cursors.Default;

            mf.lbUploadStatus.Items.Insert(0, "Chrislands export completed: " + count1 + " items exported to file " + mf.sFileName1);
            mf.lbUploadStatus.Items.Insert(0, "Chrislands export completed: " + count2 + " items exported to file " + mf.sFileName2);
            mf.lbUploadStatus.Refresh();

            return 0;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    build Chrislands CSV file
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void buildChrislandsFile(mainForm mf, FbDataReader data) {

            string workingDescrField = "";
            string dataBuild = "";

            while (data.Read()) {

                mf.tbSKU.Text = data["SKU"].ToString();  //  for debugging purposes only!

                if (mf.cbPurgeReplace.Checked == true && data["Stat"].ToString() == "Sold")
                    continue;  //  if purge/replace and Sold, don't upload

                if (data["Stat"].ToString() == "Hold")
                    continue;  //  don't export

                if (data["UPC"].ToString().Length < 12)  //  can only take items with UPCs
                    continue;

                if (data["Quantity"].ToString() == "0") {  //  delete record
                    dataBuild = data["SKU"].ToString();  //  deletes only need SKU
                    count2++;  //  increment counter
                    tw2.WriteLine(dataBuild);  //  write it out
                }
                else {
                    dataBuild = data["SKU"].ToString() + "\t ";  //  Seller ID (SKU)
                    dataBuild += "\t ";  //  author
                    dataBuild += data["Title"].ToString() + "\t ";  //  title
                    dataBuild += "\t ";  //  illustrator
                    dataBuild += data["Condn"].ToString() + "\t ";  //  condition
                    dataBuild += "\t\t\t\t\t ";  //  book size\t jacket condition\t binding\t book type\t ISBN
                    dataBuild += data["Mfgr"].ToString() + "\t ";  //  publisher
                    dataBuild += "\t ";  //  mfgr location (not used)
                    dataBuild += data["MfgrYear"].ToString() + "\t ";  //  pub date
                    dataBuild += data["Edition"].ToString() + "\t ";  //  edition
                    dataBuild += "\t ";  //  inscription

                    if (data["Descr"] != DBNull.Value) { //  description (notes)
                        workingDescrField = data["Descr"].ToString();
                        workingDescrField += data["ProductType"].ToString().Length == 0 ? "" : "Product Type: " + data["ProductType"].ToString() + ", ";
                        workingDescrField += data["NbrOfDisks"].ToString().Length == 0 ? "" : "Nbr of Disks: " + data["NbrOfDisks"].ToString() + ", ";
                        workingDescrField += data["MediaType"].ToString().Length == 0 ? "" : "Media Type: " + data["MediaType"].ToString() + ", ";
                        workingDescrField += data["AudioFormat"].ToString().Length == 0 ? "" : "Audio Format: " + data["AudioFormat"].ToString() + ", ";
                        workingDescrField += data["AdultContent"].ToString().Length != 0 ? "Adult Content: N, " : "Adult Content: " + data["AdultContent"].ToString() + ", ";

                        if (data["ProductType"].ToString().Contains("Music")) {
                            workingDescrField += data["Language"].ToString().Length == 0 ? "" : "Language: " + data["Language"].ToString() + ", ";
                            workingDescrField += data["Artist"].ToString().Length == 0 ? "" : "Artist: " + data["Artist"].ToString() + ", ";
                            workingDescrField += data["Composer"].ToString().Length == 0 ? "" : "Composer: " + data["Composer"].ToString() + ", ";
                            workingDescrField += data["Conductor"].ToString().Length == 0 ? "" : "Conductor: " + data["Conductor"].ToString() + ", ";
                            workingDescrField += data["Orchestra"].ToString().Length == 0 ? "" : "Orchestra: " + data["Orchestra"].ToString() + ", ";
                            workingDescrField += data["Origin"].ToString().Length == 0 ? "" : "Origin: " + data["Origin"].ToString() + ", ";
                        }
                        else {  //  must be video
                            workingDescrField += data["MPAARating"].ToString().Length == 0 ? "" : "MPAA Rating: " + data["MPAARating"].ToString() + ", ";
                            workingDescrField += data["VideoFormat"].ToString().Length == 0 ? "" : "Video Format: " + data["VideoFormat"].ToString() + ", ";
                            workingDescrField += data["AudioEncoding"].ToString().Length == 0 ? "" : "Audio Encoding: " + data["AudioEncoding"].ToString() + ", ";
                            workingDescrField += data["Language"].ToString().Length == 0 ? "" : "Language: " + data["Language"].ToString() + ", ";
                            workingDescrField += data["Runtime"].ToString().Length == 0 ? "" : "Runtime: " + data["Runtime"].ToString() + ", ";
                            workingDescrField += data["Subtitles"].ToString().Length == 0 ? "" : "Subtitles: " + data["Subtitles"].ToString() + ", ";
                            workingDescrField += data["Actors"].ToString().Length == 0 ? "" : "Actors: " + data["Actors"].ToString() + ", ";
                            workingDescrField += data["Director"].ToString().Length == 0 ? "" : "Director: " + data["Director"].ToString() + ", ";
                            workingDescrField += data["Origin"].ToString().Length == 0 ? "" : "Origin: " + data["Origin"].ToString() + ", ";
                            workingDescrField += data["Notes"].ToString().Length == 0 ? "" : "Notes: " + data["Notes"].ToString() + ", ";
                        }
                        dataBuild += workingDescrField + "\t ";  //  move description
                    }
                    else
                        dataBuild += "\t ";  //  no description or private notes

                    dataBuild += data["Quantity"].ToString() + "\t ";  //  quantity
                    dataBuild += data["Price"].ToString() + "\t ";  //  price
                    dataBuild += "\t ";  //  image  <----------------- verify this is a URL\t not a filename
                    dataBuild += data["CatalogID"].ToString() + "\t "; //  catalog (category)
                    dataBuild += "\t\t\t" + "\t ";  //  category 2-5
                    dataBuild += "\t\t\t\t\t\t\t\t" + "\t ";  //  keywords 1-9
                    dataBuild += "\t ";  //  book weight (not used)

                    tw1.WriteLine(dataBuild);  //  add/modify
                    count1++;

                }
            }

            return;
        }
    }
}
