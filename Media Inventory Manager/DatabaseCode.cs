//#define TRACE
//#define backuptest

#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.ServiceProcess;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

//using FirebirdSql.Data.Firebird.Services;

#endregion


namespace Media_Inventory_Manager
{

    partial class mainForm : Form
    {
        FbCommand sqlCmd;
        static public FbConnection mediaConn;
        static public string dbPath;


        //-------------------    backup the database    --------------------]
        [STAThread]
        private void backupDatabase() {
            string currentTime = DateTime.Now.ToString("yyyyMMddHHmmss");

#if !backuptest
            //  make sure gbak.exe is in the Firebird/bin directory
            if (!File.Exists(firebirdInstallationPath + @"bin\gbak.exe")) {
                MessageBox.Show("A basic component of the Firebird backup system (gbak.exe) is missing;\n Contact support@pragersoftware.com for help", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.WorkingDirectory = firebirdInstallationPath;
            //  gbak.exe -backup -user sysdba -pass masterkey c:\prager\dbBooks.fdb c:\prager\backup\test.gbk
            p.StartInfo.FileName = @"bin\gbak.exe";
            string debugString = @" -backup -user sysdba -pass masterkey " + dbPath + " " + backupPath + "M" + currentTime + ".gbk";
            p.StartInfo.Arguments = debugString;
            p.Start();

#endif

        }



        //-------------------    restore database    ----------------------]
        private void restoreDatabase() {
            string backupFilename = "";

            if (Count(dbPath, ':') > 1) {
                MessageBox.Show("Restores should be done from the server, not the client", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                restoreToolStripMenuItem.Enabled = false;
                return;
            }

            //  make sure our database is closed
            if (mediaConn.State == ConnectionState.Open) {
                mediaConn.Close();
                mediaConn.Dispose();
            }

            //  now stop the service...
            ServiceController controller = new ServiceController();
            controller.MachineName = ".";
            controller.ServiceName = "FirebirdServerDefaultInstance";
            if (controller.Status == ServiceControllerStatus.Running)
                controller.Stop();

            //  get name of file to restore from
            openFileDialog1.Filter = "Backup files (M*.gbk)|M*.gbk|All files (*.*)|*.*";
            openFileDialog1.InitialDirectory = backupPath;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                backupFilename = openFileDialog1.FileName;
            else
                return;

            lbStatus.Items.Insert(0, "restore of database " + dataBaseName + " using " + backupFilename + " started");
            lbStatus.Refresh();

            Cursor.Current = Cursors.WaitCursor;

            // restart the service
            controller.Start();

            //  restore the database     
            System.Diagnostics.Process p = new System.Diagnostics.Process();

            p.StartInfo.WorkingDirectory = firebirdInstallationPath;
            p.StartInfo.FileName = @"bin\gbak.exe";

            //  gbak.exe -REP -user sysdba -pass prager "J:\Email Attachments\20080925120723.gbk" c:\prager\dbBooks.fdb
            string debugString = " -REP -user sysdba -pass masterkey \"" + backupFilename + "\" " + dbPath;
            p.StartInfo.Arguments = debugString;
            p.Start();
            p.WaitForExit();

            MessageBox.Show("You must restart the program...", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }


        //--------------------    counts the number of specific characters in a string    ----------]
        public static int Count(string src, char find) {
            int ret = 0;
            foreach (char s in src) {
                if (s == find) {
                    ++ret;
                }
            }
            return ret;
        }

        //-------------------    fill UploadInfo table with static information    ----------------------]
        private int fillUploadInfoTable() {
            string[] insertStr = new string[30];

            insertStr[0] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Alibris','','','aus.alibris.com','/','HB')";

            insertStr[1] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Amazon','','','n/a','/','Tab')";

            insertStr[2] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Barnes & Noble','','','sftp.barnesandnoble.com','/home/Listings/Inventory_to_Drop/','UIEE')";

            insertStr[3] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Chrislands','','','ftp.chrislands.com','/','Tab')";

            insertStr[4] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Half.com','','','n/a','/','CSV')";

            insertStr[5] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Papa Media','','','(internal)','(internal)','Tab')";

            insertStr[6] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Scribblemonger','','','ftp.scribblemonger.com','/','Tab')";

            insertStr[7] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                "values('Custom Site #1','','','','','')";

            insertStr[8] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                "values('Custom Site #2','','','','','')";

            insertStr[9] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                "values('Custom Site #3','','','','','')";

            insertStr[10] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                "values('Custom Site #4','','','','','')";

            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();

            for (int i = 0; i < 11; i++) {  //  insert info for each of the listing services
                sqlCmd = new FbCommand(insertStr[i], mediaConn);
                sqlCmd.ExecuteNonQuery();
            }

            //  NOTE:  if all entries are not showing up in table, go to mainForm and search for "farkeled"
            lbStatus.Items.Insert(0, "table tUploadInfo loaded successfully");
            lbStatus.Refresh();

            return 0;
        }


        ////----------------------    add an image to a record    ------------------------]
        //private void addBookImage() {
        //    string sFilename = "";

        //    //  get name of file to add or update
        //    openFileDialog1.Filter = @"Image Files(*.tif;*.tiff;*.jpg;*.jpeg)|*.tif;*.tiff;*.jpg;*.jpeg";
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //        sFilename = openFileDialog1.FileName;
        //    else
        //        return;

        //    //  add it to table
        //    ImageURL = sFilename;
        //    if (tbSKU.Text.Length != 0)
        //        bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;

        //    string addFileName = "UPDATE tMedia SET ImageURL = '" + sFilename + "' WHERE SKU = '" + tbSKU.Text + "'";
        //    FbCommand addCmd = new FbCommand(addFileName);
        //    addCmd.Connection = mediaConn;
        //    addCmd.ExecuteNonQuery();

        //    //  now display it...
        //    FileInfo fi = new FileInfo(sFilename);
        //    string fileType = fi.Extension.Substring(1, fi.Extension.Length - 1);

        //    FileStream streamx = new FileStream(sFilename, FileMode.Open, FileAccess.Read);  // Access the file stream; store the file in a memory byte array.
        //    MemoryStream tbstream = CreateThumbNail(streamx, fileType, 80, 109);

        //    Bitmap bmp = new Bitmap(tbstream);
        //    //pbBookImage.Image = bmp;

        //}


        ////---------------------------    delete the image in the table    --------------------------]
        //private void deleteBookImage() {
        //    //  now delete the image in the record
        //    string findTextPtr = "UPDATE tMedia SET ImageURL = NULL WHERE SKU = '" + tbSKU.Text + "'";
        //    FbCommand cmd = new FbCommand(findTextPtr, mediaConn);
        //    cmd.ExecuteNonQuery();

        //    pbBookImage.Image = null;

        //}


        //----------------------------    purge items in table by year    ----------------------]
        private void purgeMediaByYear() {
            //  get the number of items with a status of "SOLD"
            FbCommand cmd = new FbCommand();
            string selectString = "SELECT COUNT(*) FROM tMedia WHERE STAT = 'Sold'";
            cmd.CommandText = selectString;
            cmd.Connection = mediaConn;
            int fullCount = (int)cmd.ExecuteScalar();

            //  now setup for the purge
            DateTime temp = DateTime.Parse("12/31/" + tbPurgeDate.Text);
            string purgeString = "DELETE FROM tMedia WHERE Stat = 'Sold' AND DateU <= '" + temp.ToShortDateString() + "'";

            cmd.CommandText = purgeString;
            cmd.Connection = mediaConn;
            cmd.ExecuteNonQuery();

            cbDeleteByYear.Checked = false;  //  reset it...

            ////  get the new count of books with a status of "SOLD"
            //cmd = new FbCommand("SELECT ROW_COUNT", bookConn);
            //int count = (int)cmd.ExecuteScalar();

            //  get the difference and we have a count of how many we deleted
            //FbCommand cmd = new FbCommand();
            selectString = "SELECT COUNT(*) FROM tMedia WHERE STAT = 'Sold'";
            cmd.CommandText = selectString;
            cmd.Connection = mediaConn;
            int purgeCount = (int)cmd.ExecuteScalar();

            lItemsPurged.Text = (fullCount - purgeCount).ToString() + " items purged from database.";
            lItemsPurged.Visible = true;
        }



        ////-----------------------    move old NbrOfCopies to Quantity    -------------------]
        //public void moveNbrOfCopies() {

        //    //  now, see if we have already moved the old data
        //    string maintenanceString = "SELECT NbrOfCopies, Quantity, Stat, SKU from tMedia"; //  see if column is null, means we have already moved the data
        //    string updateString = "";
        //    int qty = 0;
        //    string rdrTwoContents = "";


        //    sqlCmd = new FbCommand(maintenanceString, mediaConn);
        //    FbCommand sqlCmd2 = new FbCommand(updateString, mediaConn);

        //    try {
        //        FbDataReader rdr = sqlCmd.ExecuteReader();  //  see if it's still there
        //        while (rdr.Read()) {

        //            if (rdr.IsDBNull(0) && IsNumeric(rdr[1])) {  //  if NbrOfCopies is null and Quantity is numeric
        //                updateString = "Update tMedia set NbrOfCopies = null WHERE SKU = '" + rdr[3] + "'";  //  set NbrOfCopies = null
        //                sqlCmd2 = new FbCommand(updateString, mediaConn);
        //                sqlCmd2.ExecuteNonQuery();
        //            }
        //            else
        //                if (rdr[0].ToString().Length == 0 && IsNumeric(rdr[1])) { //  if NbrOfCopies is blank and Quantity is numeric
        //                    updateString = "Update tMedia set NbrOfCopies = null WHERE SKU = '" + rdr[3] + "'";  //  set NbrOfCopies = null
        //                    sqlCmd2 = new FbCommand(updateString, mediaConn);
        //                    sqlCmd2.ExecuteNonQuery();
        //                }
        //                else
        //                    if (IsNumeric(rdr[0]) && rdr.IsDBNull(1)) {  //  if NbrOfCopies is valid and Quantity is null 
        //                        rdrTwoContents = rdr[2].ToString();  //  DEBUGGING
        //                        qty = rdr[2].ToString() == "For Sale" ? int.Parse(rdr[0].ToString()) : 0;
        //                        updateString = "Update tMedia set Quantity = " + qty + " WHERE SKU = '" + rdr[3] + "'";
        //                        sqlCmd2 = new FbCommand(updateString, mediaConn);
        //                        sqlCmd2.ExecuteNonQuery();

        //                        updateString = "Update tMedia set NbrOfCopies = null WHERE SKU = '" + rdr[3] + "'";
        //                        sqlCmd2 = new FbCommand(updateString, mediaConn);
        //                        sqlCmd2.ExecuteNonQuery();
        //                    }

        //        }
        //    lbStatus.Items.Insert(0, "Correction of Quantity field completed");
        //    lbStatus.Refresh();
        //    tabTaskPanel.SelectTab(cStatus);  //  to to the status page
        //    }
        //    catch (System.Exception ex) {
        //        if (ex.Message.Contains("duplicate value") || ex.Message.Contains("There are no data to read"))
        //            return;
        //        else
        //            MessageBox.Show("Error adding Quantity field:\r" + ex.Message + "\n" + ex.StackTrace);
        //    }
        //    return;
        //}

    }  //  end class Form1
}  //  end namespace
