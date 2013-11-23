using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FirebirdSql.Data.FirebirdClient;

namespace Media_Inventory_Manager
{
    class Scribblemonger
    {
        TextWriter tw = null;

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--   create a Scribblemonger export file in tab-delimited format
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int createScribbleTabFormat(mainForm mf, string formattedDate, string exportPath, FbConnection mediaConn) {

            Cursor.Current = Cursors.WaitCursor;

            if (mf.rbExportAll.Checked == false && mf.rbChangeDate.Checked == false && mf.rbExportInclusiveSearch.Checked == false && mf.rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (mf.cbPurgeReplace.Checked == true)  //  doing a purge/replace?
                mf.sFileName1 = exportPath + "purgeTB" + formattedDate + ".tab";
            else  //  no just exporting those that were changed
                mf.sFileName1 = exportPath + "TB" + formattedDate + ".tab";

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
                        MessageBox.Show("Unable to create export directory: " + e1.Message, "Prager Media Inventory Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }

            //  find items in table
            FbCommand command = new FbCommand(mf.createExportCommandString(), mediaConn);
            FbDataReader data = command.ExecuteReader();

            int count = 0;
            mf.lbUploadStatus.Items.Insert(0, "Tab-delimited format export started");
            mf.lbUploadStatus.Refresh();

            //  write header
            tw.WriteLine(
                "SKU\t" +
                "Title\t" +
                "tAuthor\t" +
                "UPC\t" +
                "NbrOfCopies\t" +
                "Illustrator\t" +
                "Price\t" +
                "Edition\t" +
                "SignedBy\t" +
                "Mfgr\t" +
                "Publish Place\t" +
                "Publish Year\t" +
                "Notes\t" +
                "Size\t" +
                "Keywords\t" +
                "Jacket Condition\t" +
                "Binding\t" +
                "Book Type\t" +
                "Condition\t" +
                "Catalog\t" +
                "Status\t" +
                "WillExpediteShipping\t" +
                "WillShipIntl\t");

            while (data.Read()) {
                mf.tbSKU.Text = data["SKU"].ToString();  //  for debugging purposes only!

                if (mf.cbPurgeReplace.Checked == true && data["Stat"].ToString() == "Sold")
                    continue;  //  if purge/replace and Sold, don't upload

                if (data["Stat"].ToString() == "Hold")
                    continue;  //  don't export

                buildTabDelimitedFile(data);

                count++;  //  increment counter
            }

            tw.Close();  //  close the stream

            if (data != null)  //  close the data reader
                data.Close();

            Cursor.Current = Cursors.Default;

            mf.lbUploadStatus.Items.Insert(0, "Tab-delimited format export(s) completed: " + count + " items exported to file " + mf.sFileName1);
            mf.lbUploadStatus.Refresh();

            return 0;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    build a TAB delimited format file
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void buildTabDelimitedFile(FbDataReader data) {

            string dataBuild;
            dataBuild = data["SKU"].ToString() + "\t";  //  SKU

            dataBuild += data["Title"].ToString() + "\t";  //  title

            string tempUPC = data["UPC"].ToString().StartsWith("B") ? "" : data["UPC"].ToString();
            dataBuild += tempUPC + "\t";

            dataBuild += data["Quantity"] + "\t";  //  quantity

            dataBuild += data["Price"].ToString() + "\t";  //  price

            if (data["Edition"] != DBNull.Value)
                dataBuild += data["Edition"].ToString() + "\t";  //  Edition
            else
                dataBuild += " \t";

            if (data["Mfgr"] != DBNull.Value)
                dataBuild += data["Mfgr"].ToString() + "\t";  //  Mfgr
            else
                dataBuild += " \t";

            if (data["MfgrYear"] != DBNull.Value)
                dataBuild += data["MfgrYear"].ToString() + "\t";  //  year published
            else
                dataBuild += " \t";

            if (data["Descr"] != DBNull.Value)
                dataBuild += data["Descr"].ToString() + "\t";  //  description
            else
                dataBuild += " \t";

            if (data["MediaType"] != DBNull.Value)
                dataBuild += data["MediaType"].ToString() + "\t";  //  media type
            else
                dataBuild += " \t";

            if (data["Condn"] != DBNull.Value)
                dataBuild += data["Condn"].ToString() + "\t";  //  condition
            else
                dataBuild += " \t";

            if (data["CatalogID"] != DBNull.Value)
                dataBuild += data["CatalogID"].ToString() + "\t";  //  catalog number
            else
                dataBuild += " \t";

            if (data["Stat"] != DBNull.Value)
                dataBuild += data["Stat"].ToString() + "\t";  //  status
            else
                dataBuild += " \t";

            tw.WriteLine(dataBuild);
            return;
        }
    }
}
