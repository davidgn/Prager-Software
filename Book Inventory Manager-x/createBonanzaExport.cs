
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

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create a file in tab-delimited format for EXPORT
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int createBonanzaExportTabFormat(string formattedDate) {

            Cursor.Current = Cursors.WaitCursor;

            if (rbExportAll.Checked == false && rbChangeDate.Checked == false && rbExportInclusiveSearch.Checked == false && rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

//#if EXPORTTESTING
//                exportPath = @"d:\temp\prager\export\";  //  create normal export file
//#endif
            //if (cbPurgeReplace.Checked == true)  //  doing a purge/replace?
            //    sFileName1 = exportPath + "purgeTB" + formattedDate + ".tab";
            //else  //  no just exporting those that were changed
            sFileName1 = exportPath + "Bza" + formattedDate + ".txt";

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
            lbUploadStatus.Items.Insert(0, "Bonanza format export started");
            lbUploadStatus.Refresh();

            //  write header
            tw1.WriteLine("ID\tTitle\tDescription\tPrice\tcategory\tQuantity\tshipping_type\tshipping_price\tbooth_category\tTrait");

            while (data.Read()) {
                tbBookNbr.Text = data["BookNbr"].ToString();  //  for debugging purposes only!

                if (cbPurgeReplace.Checked == true && data["Stat"].ToString() == "Sold")
                    continue;  //  if purge/replace and Sold, don't upload

                if (data["Stat"].ToString() == "Hold")
                    continue;  //  don't export

                buildBonanzaTabDelimitedFile(data);

                count++;  //  increment counter
            }

            tw1.Close();  //  close the stream

            if (data != null)  //  close the data reader
                data.Close();

            Cursor.Current = Cursors.Default;

            lbUploadStatus.Items.Insert(0, "Bonanza format export(s) completed: " + count + " books exported to file " + sFileName1);
            lbUploadStatus.Refresh();

            return 0;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    build a TAB delimited format file
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void buildBonanzaTabDelimitedFile(FbDataReader data) {

            string dataBuild;
            dataBuild = data["BookNbr"].ToString() + "\t";  //  ID

            dataBuild += data["Title"].ToString() + "\t";  //  title

            dataBuild += data["Descr"].ToString() + "\t";  //  description

            dataBuild += data["Price"].ToString() + "\t";  //  price

            dataBuild += data["NbrOfPages"].ToString() + "\t";  //  pages

            dataBuild += data["Quantity"] + "\t";  //  quantity

            dataBuild += data["pubplace"] + "\t";  //  shipping_type

            dataBuild += data["bookweight"] + "\t";  //  shipping_price

            dataBuild += data["subcategory"] + "\t";  //  booth_category

            //  now start on "traits"
            if (data["Bndg"] != DBNull.Value)
                dataBuild += "[[FORMAT: " + data["Bndg"].ToString() + "]] ";  //  binding

            if (data["ISBN"] != DBNull.Value && !data["ISBN"].ToString().StartsWith("B")) //  ISBN
                dataBuild += "[[ISBN: " + data["ISBN"].ToString() + "]] ";

            if (data["Author"] != DBNull.Value)
                dataBuild += "[[AUTHOR: " + data["Author"].ToString() + "]] ";  //  author

            if (data["Condn"] != DBNull.Value)
                dataBuild += "[[CONDITION: " + data["Condn"].ToString() + "]] ";  //  condition

            if (data["Pub"] != DBNull.Value)
                dataBuild += "[[PUBLISHER: " + data["Pub"].ToString() + "]] ";  //  publisher

            if (data["Ed"] != DBNull.Value)
                dataBuild += "[[EDITION: " + data["Ed"].ToString() + "]] ";  //  Edition

            if (data["PubYear"] != DBNull.Value)
                dataBuild += "[[PUBLICATION YEAR: " + data["PubYear"].ToString() + "]] ";  //  year published

            if (data["Jaket"] != DBNull.Value)
                dataBuild += "[[DUST JACKET: " + data["Jaket"].ToString() + "]] ";  //  jacket

            if (data["Cat"] != DBNull.Value)
                dataBuild += "[[CATEGORY: " + data["CAT"].ToString() + "]] ";  //  primary catalog

            if (data["Illus"] != DBNull.Value)
                dataBuild += "[[EDITION DESCRIPTION: " + data["Illus"].ToString() + "]] ";  //  illustrator

            if (data["Ed"] != DBNull.Value && data["Ed"].ToString().Contains("1st Ed"))
                dataBuild += "[[SPECIAL ATTRIBIUTES: 1ST EDITION]]";  //  Edition



            tw1.WriteLine(dataBuild);
            return;
        }


    }
}

