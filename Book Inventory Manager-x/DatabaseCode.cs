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


namespace Prager_Book_Inventory
{

    partial class mainForm : Form
    {
        FbCommand sqlCmd;
        static public FbConnection bookConn;
        static public string dbPath;

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    backup the database
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        [STAThread]
        private void backupDatabase() {
            string currentTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            //  make sure gbak.exe is in the Firebird/bin directory
            if (!File.Exists(firebirdInstallationPath + @"bin\gbak.exe")) {
                MessageBox.Show("A basic component of the Firebird backup system (gbak.exe) is missing;\n Contact support@pragersoftware.com for help", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.WorkingDirectory = firebirdInstallationPath;
            //  gbak.exe -backup -user sysdba -pass masterkey c:\prager\dbBooks.fdb c:\prager\backup\test.gbk
            p.StartInfo.FileName = @"bin\gbak.exe";
            string debugString = @" -backup -user sysdba -pass masterkey " + dbPath + " " + backupPath + "B" + currentTime + ".gbk";
            p.StartInfo.Arguments = debugString;
            p.Start();

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    counts the number of specific characters in a string
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public static int Count(string src, char find) {
            int ret = 0;
            foreach (char s in src) {
                if (s == find) {
                    ++ret;
                }
            }
            return ret;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    restore database
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void restoreDatabase() {
            string backupFilename = "";

            if (Count(dbPath, ':') > 1) {
                MessageBox.Show("Restores should be done from the server, not the client", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                restoreToolStripMenuItem.Enabled = false;
                return;
            }

            //  make sure our database is closed
            if (bookConn.State == ConnectionState.Open) {
                bookConn.Close();
                bookConn.Dispose();
            }

            //  now stop the service...
            ServiceController controller = new ServiceController();
            controller.MachineName = ".";
            controller.ServiceName = "FirebirdServerDefaultInstance";
            if (controller.Status == ServiceControllerStatus.Running)
                controller.Stop();

            //  get name of file to restore from
            openFileDialog1.Filter = "Backup files (B*.gbk)|B*.gbk|All files (*.*)|*.*";
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

            MessageBox.Show("You must restart the program...", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    fill UploadInfo table with static information (only done 1st time)
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private int fillUploadInfoTable() {

            string[] insertStr = new string[30];

            //  truncate the table
            mainForm.commandString = "delete from tUploadInfo";
            FbCommand sqlCmd = new FbCommand(mainForm.commandString, mainForm.bookConn);
            sqlCmd.ExecuteNonQuery();

            insertStr[0] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
            @"values('A1 Books','','','mkt.A1books.com','/data','Tab')";

            insertStr[1] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('ABE','','','ftp.abebooks.com','','ABE')";

            insertStr[2] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Alibris','','','aus.alibris.com','/','HB')";

            insertStr[3] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Amazon','','','n/a','/','Tab')";

            insertStr[4] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Antiqbook','','','dusty.antiqbook.com','/','UIEE')";

            insertStr[5] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Barnes & Noble','','','sftp.barnesandnoble.com','/home/Listings/Inventory_to_Drop/','Tab')";

            insertStr[6] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Biblio','','','ftp.biblio.com','./','UIEE')";

            insertStr[7] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Biblion','','','217.158.127.116','./','UIEE')";

            insertStr[8] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Bibliophile','','','www.bookbase.com','/','UIEE')";

            insertStr[9] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Book Byte','','','ftp.bookbyte.com','/','UIEE')";

            insertStr[10] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Bonanza','','','ftp.bonanza.com','/','Tab')";

            insertStr[11] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('ChooseBooks','','','ftp.choosebooks.com','/','UIEE')";

            insertStr[12] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Chrislands','','','ftp.chrislands.com','/','Tab')";

            insertStr[13] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Google','','','uploads.google.com','/','XML')";

            insertStr[14] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Half.com','','','n/a','/','CSV')";

            insertStr[15] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Papa Media','','','(internal)','(internal)','Tab')";

            insertStr[16] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Scribblemonger','','','ftp.scribblemonger.com','/','UIEE')";

            insertStr[17] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Tom Folio','','','204.246.14.212','/','UIEE')";

            insertStr[18] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                @"values('Valore Books','','','ftp.valorebooks.com','/Inventory','CSV')";

            insertStr[19] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                "values('Custom Site #1','','','','','')";

            insertStr[20] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                "values('Custom Site #2','','','','','')";

            insertStr[21] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                "values('Custom Site #3','','','','','')";

            insertStr[22] = "insert into tUploadInfo (ListingService, UID, Pwd, FTPAddr, FTPDir, FileFmt ) " +
                "values('Custom Site #4','','','','','')";

            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();

            for (int i = 0; i < 23; i++) {  //  insert info for each of the listing services
                sqlCmd = new FbCommand(insertStr[i], bookConn);
                sqlCmd.ExecuteNonQuery();
            }

            //  NOTE:  if all entries are not showing up in table, go to mainForm and search for "farkeled"
            lbStatus.Items.Insert(0, "table tUploadInfo loaded successfully");
            lbStatus.Refresh();

            return 0;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    add an image to a record
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void addBookImage() {
            string sFilename = "";

            //  get name of file to add or update
            openFileDialog1.Filter = @"Image Files(*.tif;*.tiff;*.jpg;*.jpeg)|*.tif;*.tiff;*.jpg;*.jpeg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                sFilename = openFileDialog1.FileName;
            else
                return;

            //  add it to table
            ImageFileName = sFilename;
            if (tbBookNbr.Text.Length != 0)
                bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;

            string addFileName = "UPDATE tBooks SET ImageFileName = '" + sFilename + "' WHERE BookNbr = '" + tbBookNbr.Text + "'";
            FbCommand addCmd = new FbCommand(addFileName);
            addCmd.Connection = bookConn;
            addCmd.ExecuteNonQuery();

            //  now display it...
            FileInfo fi = new FileInfo(sFilename);
            string fileType = fi.Extension.Substring(1, fi.Extension.Length - 1);

            FileStream streamx = new FileStream(sFilename, FileMode.Open, FileAccess.Read);  // Access the file stream; store the file in a memory byte array.
            MemoryStream tbstream = CreateThumbNail(streamx, fileType, 80, 109);

            Bitmap bmp = new Bitmap(tbstream);
            pbBookImage.Image = bmp;

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    delete the image in the table
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void deleteBookImage() {
            //  now delete the image in the record
            string findTextPtr = "UPDATE tBooks SET ImageFileName = NULL WHERE BookNbr = '" + tbBookNbr.Text + "'";
            FbCommand cmd = new FbCommand(findTextPtr, bookConn);
            cmd.ExecuteNonQuery();

            pbBookImage.Image = null;

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    purge books in table by year
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void purgeBooksByYear() {

            //  validate year
            if (tbPurgeDate.Text.Length == 0) {
                MessageBox.Show("Purge date missing", "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  get the number of books with a status of "SOLD"
            FbCommand cmd = new FbCommand();
            string selectString = "SELECT COUNT(*) FROM tBooks WHERE STAT = 'Sold'";
            cmd.CommandText = selectString;
            cmd.Connection = bookConn;
            int fullCount = (int)cmd.ExecuteScalar();

            //  now setup for the purge
            DateTime temp = DateTime.Parse("12/31/" + tbPurgeDate.Text);
            string purgeString = "DELETE FROM tBooks WHERE Stat = 'Sold' AND DateU <= '" + temp.ToShortDateString() + "'";

            cmd.CommandText = purgeString;
            cmd.Connection = bookConn;
            cmd.ExecuteNonQuery();

            cbDeleteByYear.Checked = false;  //  reset it...

            ////  get the new count of books with a status of "SOLD"
            //cmd = new FbCommand("SELECT ROW_COUNT", bookConn);
            //int count = (int)cmd.ExecuteScalar();

            //  get the difference and we have a count of how many we deleted
            //FbCommand cmd = new FbCommand();
            selectString = "SELECT COUNT(*) FROM tBooks WHERE STAT = 'Sold'";
            cmd.CommandText = selectString;
            cmd.Connection = bookConn;
            int purgeCount = (int)cmd.ExecuteScalar();

            lBooksPurged.Text = (fullCount - purgeCount).ToString() + " books purged from database.";
            lBooksPurged.Visible = true;
        }



        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    move old NbrOfCopies to Quantity
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void moveNbrOfCopies() {

            //  now, see if we have already moved the old data
            string maintenanceString = "SELECT NbrOfCopies, Quantity, Stat, BookNbr from tBooks"; //  see if column is null, means we have already moved the data
            string updateString = "";
            int qty = 0;
            string rdrTwoContents = "";


            sqlCmd = new FbCommand(maintenanceString, bookConn);
            FbCommand sqlCmd2 = new FbCommand(updateString, bookConn);

            try {
                FbDataReader rdr = sqlCmd.ExecuteReader();  //  see if it's still there
                while (rdr.Read()) {

                    if (rdr.IsDBNull(0) && IsNumeric(rdr[1])) {  //  if NbrOfCopies is null and Quantity is numeric
                        updateString = "Update tBooks set NbrOfCopies = null WHERE BookNbr = '" + rdr[3] + "'";  //  set NbrOfCopies = null
                        sqlCmd2 = new FbCommand(updateString, bookConn);
                        sqlCmd2.ExecuteNonQuery();
                    }
                    else
                        if (rdr[0].ToString().Length == 0 && IsNumeric(rdr[1])) { //  if NbrOfCopies is blank and Quantity is numeric
                            updateString = "Update tBooks set NbrOfCopies = null WHERE BookNbr = '" + rdr[3] + "'";  //  set NbrOfCopies = null
                            sqlCmd2 = new FbCommand(updateString, bookConn);
                            sqlCmd2.ExecuteNonQuery();
                        }
                        else
                            if (IsNumeric(rdr[0]) && rdr.IsDBNull(1)) {  //  if NbrOfCopies is valid and Quantity is null 
                                rdrTwoContents = rdr[2].ToString();  //  DEBUGGING
                                qty = rdr[2].ToString() == "For Sale" ? int.Parse(rdr[0].ToString()) : 0;
                                updateString = "Update tBooks set Quantity = " + qty + " WHERE BookNbr = '" + rdr[3] + "'";
                                sqlCmd2 = new FbCommand(updateString, bookConn);
                                sqlCmd2.ExecuteNonQuery();

                                updateString = "Update tBooks set NbrOfCopies = null WHERE BookNbr = '" + rdr[3] + "'";
                                sqlCmd2 = new FbCommand(updateString, bookConn);
                                sqlCmd2.ExecuteNonQuery();
                            }

                }
            lbStatus.Items.Insert(0, "Correction of Quantity field completed");
            lbStatus.Refresh();
            tabTaskPanel.SelectTab(cStatus);  //  to to the status page
            }
            catch (System.Exception ex) {
                if (ex.Message.Contains("duplicate value") || ex.Message.Contains("There are no data to read"))
                    return;
                else
                    MessageBox.Show("Error adding Quantity field:\r" + ex.Message + "\n" + ex.StackTrace);
            }
            return;
        }

    }  
}  