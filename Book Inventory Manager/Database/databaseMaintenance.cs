//#define TRACE
#region Using directives

using System.Data;
using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Win32;
#endregion

/*
        // Save user prefs to registry
        RegistryKey regKey = Registry.CurrentUser;
        regKey = regKey.CreateSubKey("Software\\Intertech\\YourKeyRes");
        regKey.SetValue("CurrSize", "29");
        regKey.SetValue("CurrColor", "Red");
        Console.WriteLine("Settings saved in registry");

        //  read from registry
        RegistryKey regKey1 = Registry.CurrentUser;
        regKey1 = regKey1.CreateSubKey("Software\\Intertech\\YourKeyRes");
        Console.WriteLine(regKey1.GetValue("CurrSize", "30"));
        Console.WriteLine(regKey1.GetValue("CurrColor", "Blue"));

 * */
namespace Prager_Book_Inventory
{

    partial class mainForm : Form
    {
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    modify existing tables
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void modifyExistingTables(splashScreen ss) {
            bool beenThereFlag = false;
            FbDataReader dr1;
            FbCommand sqlCmd;
            string maintenanceString = "";

            fTrace("I - starting database maintenance");
            ss.Text = "starting database maintenance";
            ss.Refresh();

            ////  Fix Scribblemonger duplicate row issue
            //FbCommand cmd1 = new FbCommand();    //  count number of entries
            //string selectStr = "SELECT COUNT(*) FROM tUploadInfo WHERE ListingService = 'Scribblemonger'";
            //cmd1.CommandText = selectStr;
            //cmd1.Connection = bookConn;
            //int fullCount = (int)cmd1.ExecuteScalar();
            ////  MessageBox.Show("fullcount: " + fullCount.ToString());

            //if (fullCount == 2) {  //  if there are 2 Scribblemongers, delete one of them
            //    //  get data from existing entry
            //    string ls, uid, pwd, fa, fd, ff = "";
            //    commandString = "SELECT * FROM tUploadInfo WHERE ListingService = 'Scribblemonger'";
            //    cmd1.CommandText = commandString;
            //    FbDataReader rdr1 = cmd1.ExecuteReader();
            //    rdr1.Read();  //  read the first row
            //    ls = rdr1[0].ToString();
            //    uid = rdr1[1].ToString();
            //    pwd = rdr1[2].ToString();
            //    fa = rdr1[3].ToString();
            //    fd = rdr1[4].ToString();
            //    ff = rdr1[5].ToString();
            //    rdr1.Close();

            //    //  delete entries (both of them get deleted)
            //    commandString = "DELETE FROM tUploadInfo where ListingService = 'Scribblemonger'";
            //    sqlCmd = new FbCommand(commandString, bookConn);
            //    if (bookConn.State == ConnectionState.Closed)
            //        bookConn.Open();
            //    sqlCmd.ExecuteNonQuery();

            //    //  add record back in again
            //    string insertString1 = "INSERT INTO tUploadInfo (ListingService, UID, PWD, FTPADDR, FTPDIR, FILEFMT)" +
            //        " VALUES ('" + ls + "', '" + uid + "', '" + pwd + "', '" + fa + "', '" + fd + "', '" + ff + "')";

            //    sqlCmd.CommandText = insertString1;
            //    sqlCmd.ExecuteNonQuery();

            //}

            ////--  increase column size of customer ID
            //maintenanceString = "ALTER TABLE tUploadInfo ALTER UID TYPE VARCHAR(50)";
            //sqlCmd = new FbCommand(maintenanceString, bookConn);
            //try {
            //    sqlCmd.ExecuteNonQuery();
            //}
            //catch (Exception e) {
            //}

            ////  remove GUID and tInvInstall, add GUID and hashed renewal date  (11.4.0)" + 
            //maintenanceString = "SELECT tInvInstallDte from tOptions"; //  see if column is there
            //sqlCmd = new FbCommand(maintenanceString, bookConn);

            //if (bookConn.State == ConnectionState.Closed)
            //    bookConn.Open();

            //try {
            //    dr1 = sqlCmd.ExecuteReader();  //  see if tInvInstallDate still there
            //    dr1.Read();
            //    if (dr1[0] == DBNull.Value) {  //  column is still there, so we have not done the changes

            //        //  drop column tInvInstallDte
            //        maintenanceString = "ALTER TABLE tOptions drop tInvInstallDte";
            //        sqlCmd = new FbCommand(maintenanceString, bookConn);
            //        sqlCmd.ExecuteNonQuery();

            //        //  drop the 'unlock code' column
            //        maintenanceString = "ALTER TABLE tOptions drop tUnlockCode";
            //        sqlCmd = new FbCommand(maintenanceString, bookConn);
            //        try {
            //            sqlCmd.ExecuteNonQuery();
            //        }
            //        catch (Exception ex) {  //  just in case the column isn't there
            //            ;
            //        }

            //        //  drop column GUID
            //        maintenanceString = "ALTER TABLE tOptions drop GUID";
            //        sqlCmd = new FbCommand(maintenanceString, bookConn);
            //        try {
            //            sqlCmd.ExecuteNonQuery();
            //        }
            //        catch (Exception ex) {  //  just in case the column isn't there
            //            ;
            //        }
            //    }
            //}
            //catch (Exception ex) {  //  if tInvInstallDate is missing, this is where we wind up...
            //    if (!ex.Message.Contains("Column unknown"))
            //        MessageBox.Show("Error in creating license columns: " + ex.Message, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //  add column for tbBookNotes  (13.221)
            maintenanceString = "ALTER TABLE tBooks ADD BookNotes varchar(500)";
            sqlCmd = new FbCommand(maintenanceString, bookConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex) {  //  just in case the column isn't there
                ;
            }

            ////--  add column MAC
            //maintenanceString = "ALTER TABLE tOptions ADD MAC varchar(12)";
            //sqlCmd = new FbCommand(maintenanceString, bookConn);
            //try {
            //    sqlCmd.ExecuteNonQuery();
            //}
            //catch (Exception e) {
            //    if (!e.Message.Contains("attempt to store duplicate value"))
            //        MessageBox.Show("Error adding MAC to tOptions: " + e.Message, "Prager, Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            ////--  set GUID/MAC for encryption/decryption... and re-encrypt decryptedDate with MAC
            //encryptionRoutines er = new encryptionRoutines();
            //string selectString = "SELECT GUID, MAC, decryptedDate FROM tOptions";
            //FbCommand selCmd = new FbCommand(selectString, bookConn);
            //storedMAC = localMACAddress;  //  save MAC address

            //try {
            //    FbDataReader dr2 = selCmd.ExecuteReader();
            //    if (dr2.Read()) {
            //        string oldGUID = dr2[0].ToString();
            //        string oldExpDate = dr2[2].ToString();

            //        if (dr2[0] != DBNull.Value && dr2[1] == DBNull.Value) { //  check for valid GUID and empty MAC
            //            string endDate = er.decryptString(oldExpDate, oldGUID);  // get current decryptedDate using old GUID
            //            if (endDate == "Bad Data") {
            //                MessageBox.Show("There is a problem with your license; contact Support using OSTicket on Support web page",
            //                    "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                Application.Exit();
            //            }
            //            string newEndDate = er.encryptString(endDate, storedMAC);  //  reset decryptedDate using MAC address
            //            maintenanceString = "UPDATE tOptions SET MAC = '" + localMACAddress + "', GUID = ''" +
            //                ", decryptedDate = '" + newEndDate + "' ROWS 1";
            //            selCmd = new FbCommand(maintenanceString, bookConn);
            //            selCmd.ExecuteNonQuery();  //  update decryptedDate using MAC address, clear GUID
            //        }
            //        dr2.Close();
            //    }
            //}
            //catch (Exception ex) {
            //    if (ex.Message.Contains("Column unknown\r\nGUID"))
            //        Console.WriteLine(ex.Message);
            //}

            ////  encrypt renewal date for existing installations  (11.4.0)
            //selectString = "SELECT TINSTALLDATE, decryptedDate FROM tOptions";  //  get the installation date and expiration date
            //selCmd = new FbCommand(selectString, bookConn);
            //DateTime dt = DateTime.Now;
            //try {
            //    FbDataReader dr3 = selCmd.ExecuteReader();
            //    if (dr3.Read()) {
            //        string installDate = dr3[0].ToString();
            //        string exDate = dr3[1].ToString();

            //        //  if there exists an install date and no decryptedDate...
            //        if (dr3[0] != DBNull.Value && (dr3[1] == DBNull.Value || (string)dr3[1] == "")) {
            //            dt = DateTime.Parse(dr3[0].ToString());  //  convert object to DateTime so we can get short date

            //            if (dt == DateTime.Today) {  //  if it's today, this is a new install, so give them 30-days
            //                dt = dt.AddMonths(1);
            //                maintenanceString = "UPDATE tOptions SET MAC = '" + storedMAC + "', decryptedDate = '" + er.encryptString(dt.ToShortDateString(), storedMAC) + "' ROWS 1";
            //                //     fTrace("databaseMaintenance-1");
            //            }
            //            else {  //  install date is not today, so decryptedDate = installDate
            //                maintenanceString = "UPDATE tOptions SET decryptedDate = '" + er.encryptString(dt.ToShortDateString(), storedMAC) + "' ROWS 1";
            //                //     fTrace("databaseMaintenance-2");
            //            }
            //            selCmd = new FbCommand(maintenanceString, bookConn);
            //            selCmd.ExecuteNonQuery();  //  update decryptedDate with encrypted install date (renewal date will be computed in LicenseInformation)
            //        }

            //        selectString = "SELECT decryptedDate FROM tOptions";  //  get renewal date and move it to mainForm renewal date
            //        selCmd = new FbCommand(selectString, bookConn);
            //        FbDataReader dr4 = selCmd.ExecuteReader();
            //        if (dr4.Read()) {
            //            //    fTrace("databaseMaintenance-3: dr4: " + dr4[0].ToString() + " storedMAC: " + storedMAC);
            //            renewalDate = DateTime.Parse(er.decryptString(dr4[0].ToString(), storedMAC));  //  test for 'bad data'
            //            //   fTrace("databaseMaintenance-3a");
            //        }
            //        dr4.Close();
            //    }
            //    dr3.Close();
            //}
            //catch (System.Exception ex) {  // not recognized as a valid DateTime.  (12.4.0)
            //    if (ex.Message.Contains("not recognized as a valid DateTime")) {
            //        maintenanceString = "UPDATE tOptions SET decryptedDate = '" + er.encryptString(dt.ToShortDateString(), localMACAddress) + "' ROWS 1";
            //        //     fTrace("databaseMaintenance-4");
            //        selCmd = new FbCommand(maintenanceString, bookConn);
            //        selCmd.ExecuteNonQuery();  //  update decryptedDate with encrypted install date (renewal date will be computed in LicenseInformation)
            //    }
            //    else
            //        if (ex.Message.Contains("decryptedDate"))  //  must be for a brand new d/b
            //            ;
            //        else
            //            MessageBox.Show("Error reading Edate:\r" + ex.Message + "\n" + ex.StackTrace); //  change message <----- TODO
            //}

            ss.splashProgressBar.Increment(5);

            ////------------------------------------    checked 12.5.2012; remove 5.1.2013
            ////--  change 'bookavenue' to PapaMedia
            //maintenanceString = "SELECT ListingService from tUploadInfo WHERE ListingService = 'Book Avenue'"; //  see if column is still there
            sqlCmd = new FbCommand(maintenanceString, bookConn);
            FbDataReader rdr = null;
            //try {
            //    rdr = sqlCmd.ExecuteReader();  //  see if it's still there
            //    if (!rdr.Read())
            //        throw new ArgumentException("donePapaMedia");

            //    maintenanceString = "UPDATE tUploadInfo SET LISTINGSERVICE = 'Papa Media' WHERE LISTINGSERVICE = 'Book Avenue'";
            //    sqlCmd = new FbCommand(maintenanceString, bookConn);
            //    sqlCmd.ExecuteNonQuery();

            //    maintenanceString = "UPDATE tUploadInfo SET FTPADDR = '(internal)' WHERE LISTINGSERVICE = 'Papa Media'";
            //    sqlCmd = new FbCommand(maintenanceString, bookConn);
            //    sqlCmd.ExecuteNonQuery();

            //    maintenanceString = "UPDATE tUploadInfo SET FTPDIR = '(internal)' WHERE LISTINGSERVICE = 'Papa Media'";
            //    sqlCmd = new FbCommand(maintenanceString, bookConn);
            //    sqlCmd.ExecuteNonQuery();

            //    maintenanceString = "UPDATE tUploadInfo SET FILEFMT = 'Tab' WHERE LISTINGSERVICE = 'Papa Media'";
            //    sqlCmd = new FbCommand(maintenanceString, bookConn);
            //    sqlCmd.ExecuteNonQuery();
            //}
            //catch (Exception ex) {  //  already done... move on to next one...
            //    if (!ex.Message.Contains("donePapaMedia"))
            //        MessageBox.Show("Error in creating PapaMedia: " + ex.Message, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //rdr.Close();
            ss.splashProgressBar.Increment(5);


            ////--  change Bibliology's listing to B&N
            //maintenanceString = "SELECT ListingService from tUploadInfo WHERE ListingService = 'Bibliology'"; //  see if column is still there
            //sqlCmd = new FbCommand(maintenanceString, bookConn);

            //try {
            //rdr = sqlCmd.ExecuteReader();  //  see if it's still there
            //    if (!rdr.Read())
            //        throw new ArgumentException("doneB&N");

            //    maintenanceString = "UPDATE tUploadInfo SET LISTINGSERVICE = 'Barnes & Noble' WHERE LISTINGSERVICE = 'Bibliology'";
            //    sqlCmd = new FbCommand(maintenanceString, bookConn);
            //    sqlCmd.ExecuteNonQuery();

            //    maintenanceString = "UPDATE tUploadInfo SET FTPADDR = 'sftp.barnesandnoble.com' WHERE LISTINGSERVICE = 'Barnes & Noble'";
            //    sqlCmd = new FbCommand(maintenanceString, bookConn);
            //    sqlCmd.ExecuteNonQuery();

            //    maintenanceString = "UPDATE tUploadInfo SET FTPDIR = '/home/Listings/Inventory_to_Drop/' WHERE LISTINGSERVICE = 'Barnes & Noble'";
            //    sqlCmd = new FbCommand(maintenanceString, bookConn);
            //    sqlCmd.ExecuteNonQuery();

            //    maintenanceString = "UPDATE tUploadInfo SET FILEFMT = 'Tab' WHERE LISTINGSERVICE = 'Barnes & Noble'";
            //    sqlCmd = new FbCommand(maintenanceString, bookConn);
            //    sqlCmd.ExecuteNonQuery();
            //}
            //catch (Exception ex) {  //  already done... move on to next one...
            //    if (!ex.Message.Contains("doneB&N"))
            //        MessageBox.Show("Error in creating B && N: " + ex.Message, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //rdr.Close();
            ss.splashProgressBar.Increment(5);


            //--  add Amazon.ca
            maintenanceString = "SELECT ListingService from tUploadInfo WHERE ListingService = 'Amazon.ca'"; //  see if column is still there
            sqlCmd = new FbCommand(maintenanceString, bookConn);

            try {
                rdr = sqlCmd.ExecuteReader();  //  see if it's there
                if (rdr.Read())
                    throw new ArgumentException("doneAca");

                maintenanceString = "INSERT INTO tUploadInfo (ListingService, FTPAddr, FTPDir, FileFmt)" +
                    @"VALUES ('Amazon.ca', 'ftp.amazon.ca', '/', 'Tab')";
                sqlCmd = new FbCommand(maintenanceString, bookConn);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex) {  //  already done... move on to next one...
                if (!ex.Message.Contains("doneAca"))
                    MessageBox.Show("Error in creating Amazon.ca listing: " + ex.Message, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            rdr.Close();

            //--  add Amazon.co.uk
            maintenanceString = "SELECT ListingService from tUploadInfo WHERE ListingService = 'Amazon.co.uk'"; //  see if column is still there
            sqlCmd = new FbCommand(maintenanceString, bookConn);

            try {
                rdr = sqlCmd.ExecuteReader();  //  see if it's there
                if (rdr.Read())
                    throw new ArgumentException("doneAuk");

                maintenanceString = "INSERT INTO tUploadInfo (ListingService, FTPAddr, FTPDir, FileFmt)" +
                    @"VALUES ('Amazon.co.uk', 'ftp.amazon.co.uk', '/', 'Tab')";
                sqlCmd = new FbCommand(maintenanceString, bookConn);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex) {  //  already done... move on to next one...
                if (!ex.Message.Contains("doneAuk"))
                    MessageBox.Show("Error in creating Amazon.co.uk listing: " + ex.Message, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            rdr.Close();

            //--  add Bonanza
            maintenanceString = "SELECT ListingService from tUploadInfo WHERE ListingService = 'Bonanza'"; //  see if column is still there
            sqlCmd = new FbCommand(maintenanceString, bookConn);

            try {
                rdr = sqlCmd.ExecuteReader();  //  see if it's there
                if (rdr.Read())
                    throw new ArgumentException("doneBza");

                maintenanceString = "INSERT INTO tUploadInfo (ListingService, FTPAddr, FTPDir, FileFmt)" +
                    @"VALUES ('Bonanza', 'ftp.bonanza.com', '/', 'Tab')";
                sqlCmd = new FbCommand(maintenanceString, bookConn);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex) {  //  already done... move on to next one...
                if (!ex.Message.Contains("doneBza"))
                    MessageBox.Show("Error in creating Bonanza listing: " + ex.Message, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            rdr.Close();
            ss.splashProgressBar.Increment(5);


            ////--  change Used Book Central to Scribblemonger
            //maintenanceString = "SELECT ListingService from tUploadInfo WHERE ListingService = 'Used Book Central'"; //  see if column is still there
            //sqlCmd = new FbCommand(maintenanceString, bookConn);
            //try {
            //    rdr = sqlCmd.ExecuteReader();  //  see if it's still there
            //    if (!rdr.Read())
            //        throw new ArgumentException("doneScr");

            //    maintenanceString = "UPDATE tUploadInfo SET LISTINGSERVICE = 'Scribblemonger' WHERE LISTINGSERVICE = 'Used Book Central'";
            //    sqlCmd = new FbCommand(maintenanceString, bookConn);
            //    sqlCmd.ExecuteNonQuery();

            //    maintenanceString = "UPDATE tUploadInfo SET FTPADDR = 'ftp.scribblemonger.com' WHERE LISTINGSERVICE = 'Scribblemonger'";
            //    sqlCmd = new FbCommand(maintenanceString, bookConn);
            //    sqlCmd.ExecuteNonQuery();

            //    maintenanceString = "UPDATE tUploadInfo SET FTPDIR = '/' WHERE LISTINGSERVICE = 'Scribblemonger'";
            //    sqlCmd = new FbCommand(maintenanceString, bookConn);
            //    sqlCmd.ExecuteNonQuery();

            //    maintenanceString = "UPDATE tUploadInfo SET FILEFMT = 'UIEE' WHERE LISTINGSERVICE = 'Scribblemonger'";
            //    sqlCmd = new FbCommand(maintenanceString, bookConn);
            //    sqlCmd.ExecuteNonQuery();
            //}
            //catch (Exception ex) {  //  already done... move on to next one...
            //    if (!ex.Message.Contains("doneScr"))
            //        MessageBox.Show("Error in creating Scribblemonger: " + ex.Message, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //rdr.Close();
            ss.splashProgressBar.Increment(5);


            ////  remove Book Pursuit from the table
            //maintenanceString = "DELETE FROM tUploadInfo WHERE LISTINGSERVICE = 'Book Pursuit'";
            //sqlCmd = new FbCommand(maintenanceString, bookConn);
            //try {
            //    sqlCmd.ExecuteNonQuery();
            //}
            //catch (Exception) {
            //    ;  //  <--------------------------   TODO
            //}


            ////-----------------    change ABE's file format to 'tab'    -----------
            //maintenanceString = "UPDATE tUploadInfo SET FILEFMT = 'Tab' WHERE LISTINGSERVICE = 'ABE'";
            //sqlCmd = new FbCommand(maintenanceString, bookConn);
            //try {
            //    sqlCmd.ExecuteNonQuery();
            //}
            //catch (System.Exception ex) {
            //    MessageBox.Show("Error changing ABE fileformat to 'tab':\r" + ex.Message + "\n" + ex.StackTrace);
            //}

            ////-----------------    change Chrislands file format to 'tab'    -----------
            //maintenanceString = "UPDATE tUploadInfo SET FILEFMT = 'Tab' WHERE LISTINGSERVICE = 'Chrislands'";
            //sqlCmd = new FbCommand(maintenanceString, bookConn);
            //try {
            //    sqlCmd.ExecuteNonQuery();
            //}
            //catch (System.Exception ex) {
            //    MessageBox.Show("Error changing Chrislands fileformat to 'tab':\r" + ex.Message + "\n" + ex.StackTrace);
            //}

            ////-----------------    change Valore Books file format to 'csv'    -----------
            //maintenanceString = "UPDATE tUploadInfo SET FILEFMT = 'CSV' WHERE LISTINGSERVICE = 'Valore Books'";
            //sqlCmd = new FbCommand(maintenanceString, bookConn);
            //try {
            //    sqlCmd.ExecuteNonQuery();
            //}
            //catch (System.Exception ex) {
            //    MessageBox.Show("Error changing Valore fileformat to 'csv':\r" + ex.Message + "\n" + ex.StackTrace);
            //}

            ////-----------------    change size of keywords column    -----------  <-------- STILL NEEDED ?????
            //maintenanceString = "ALTER TABLE tBooks ALTER keywds TYPE char(500)";
            //sqlCmd = new FbCommand(maintenanceString, bookConn);
            //try {
            //    sqlCmd.ExecuteNonQuery();
            //}
            //catch (System.Exception ex) {
            //    MessageBox.Show("Error changing Keywords to 500 characters:\r" + ex.Message + "\n" + ex.StackTrace);
            //}
            ss.splashProgressBar.Increment(5);


            ////-----------------    change size of tInvCustNbr column in tInvoice table   -----------
            //maintenanceString = "ALTER TABLE tInvoice ALTER tInvCustNbr TYPE varchar(15)";
            //sqlCmd = new FbCommand(maintenanceString, bookConn);
            //try {
            //    sqlCmd.ExecuteNonQuery();
            //}
            //catch (System.Exception ex) {
            //    MessageBox.Show("Error changing tInvCustNbr to 15 characters:\r" + ex.Message + "\n" + ex.StackTrace);
            //}

            ////--  add quantity field
            //maintenanceString = "ALTER TABLE tBooks ADD Quantity SMALLINT;";
            //sqlCmd = new FbCommand(maintenanceString, bookConn);
            //try {
            //    sqlCmd.ExecuteNonQuery();
            //}
            //catch (System.Exception ex) {
            //    if (ex.Message.Contains("store duplicate value"))
            //        goto doneQuantity;
            //    else
            //        MessageBox.Show("Error adding Quantity field:\r" + ex.Message + "\n" + ex.StackTrace);
            //}

            //ss.splashProgressBar.Increment(5);
            //moveNbrOfCopies();  //  do it right!

//doneQuantity:
            ss.splashProgressBar.Increment(5);

            ////--  add volume field
            //maintenanceString = "ALTER TABLE tBooks ADD Volume VARCHAR (3) ";
            //sqlCmd = new FbCommand(maintenanceString, bookConn);
            //try {
            //    sqlCmd.ExecuteNonQuery();
            //}
            //catch (System.Exception ex) {
            //    if (ex.Message.Contains("duplicate value"))
            //        ;
            //    else
            //        MessageBox.Show("Error adding Volume field:\r" + ex.Message + "\n" + ex.StackTrace);
            //}

            ss.splashProgressBar.Value = 80;
            ss.Refresh();

            //--  change ExpeditedShip from CHAR(1) to SMALLINT
            maintenanceString = "ALTER TABLE tBooks ADD Shipping SMALLINT ";
            sqlCmd = new FbCommand(maintenanceString, bookConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (System.Exception) {
                beenThereFlag = true;
            }

            if (beenThereFlag == false)  //  we have not been here before...
            {
                fTrace("I - converting shipping codes");
                ss.Text = "converting shipping codes (DO NOT stop this conversion!)";
                ss.Refresh();

                //  convert ExpediteShip and IntlShip to new Shipping field 
                maintenanceString = "SELECT BookNbr, ExpediteShip, IntlShip from tBooks";
                sqlCmd = new FbCommand(maintenanceString, bookConn);

                rdr = sqlCmd.ExecuteReader();
                while (rdr.Read()) {
                    maintenanceString = rdr[0] + ", " + rdr[1] + ", " + rdr[2];  //  debugging
                    Shipping = 0;
                    if (rdr[1].ToString().Contains("y"))
                        Shipping = (Shipping | 16);  //  indicate Domestic Expedited
                    if (rdr[2].ToString().Contains("y"))
                        Shipping = (Shipping | 2);  //  indicate Int'l Standard shipping

                    maintenanceString = "UPDATE tBooks SET Shipping = '" + Shipping + "' WHERE BookNbr = '" + rdr[0] + "'";
                    sqlCmd = new FbCommand(maintenanceString, bookConn);
                    sqlCmd.ExecuteNonQuery();
                }
            }

            //--  remove primary key from tCatalog
            maintenanceString = "select * from rdb$relation_constraints";
            sqlCmd = new FbCommand(maintenanceString, bookConn);
            try {
                rdr = sqlCmd.ExecuteReader();
                while (rdr.Read()) {
                    if (rdr[0].ToString().Contains("INTEG_3")) {
                        maintenanceString = "ALTER TABLE TCATALOG DROP CONSTRAINT INTEG_3;"; //  create index on SKU
                        sqlCmd = new FbCommand(maintenanceString, bookConn);
                        sqlCmd.ExecuteNonQuery();
                        maintenanceString = "ALTER TABLE TCATALOG DROP CONSTRAINT INTEG_2;"; //  create index on SKU
                        sqlCmd = new FbCommand(maintenanceString, bookConn);
                        sqlCmd.ExecuteNonQuery();
                        break;
                    }
                }
            }
            catch (Exception ex) {
                ;
            }

            //--  add indexes
            maintenanceString = "create unique asc index SKU on tBooks (booknbr)"; //  create index on SKU
            sqlCmd = new FbCommand(maintenanceString, bookConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (System.Exception ex) {
                if (!ex.Message.Substring(0, 28).Contains("unsuccessful metadata update")) //  not a constraint error...
                    MessageBox.Show("Error adding index to table\r" + ex.Message + "\n" + ex.StackTrace);
            }

            maintenanceString = "create asc index ISBN on tBooks (ISBN)"; //  create index on ISBN
            sqlCmd = new FbCommand(maintenanceString, bookConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (System.Exception ex) {
                if (!ex.Message.Substring(0, 28).Contains("unsuccessful metadata update")) //  not a constraint error...
                    MessageBox.Show("Error adding index to table\r" + ex.Message + "\n" + ex.StackTrace);
            }

            maintenanceString = "create asc index TITLE on tBooks (Title)"; //  create index on Title
            sqlCmd = new FbCommand(maintenanceString, bookConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (System.Exception ex) {
                if (!ex.Message.Substring(0, 28).Contains("unsuccessful metadata update")) //  not a constraint error...
                    MessageBox.Show("Error adding index to table\r" + ex.Message + "\n" + ex.StackTrace);
            }

            maintenanceString = "create asc index AUTHOR on tBooks (Author)"; //  create index on Author
            sqlCmd = new FbCommand(maintenanceString, bookConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (System.Exception ex) {
                if (!ex.Message.Substring(0, 28).Contains("unsuccessful metadata update")) //  not a constraint error...
                    MessageBox.Show("Error adding index to table\r" + ex.Message + "\n" + ex.StackTrace);
            }

            //--  add stored procedure for inventory report - last name first)



            fTrace("I - finished database maintenance");
            ss.Text = "finished database maintenance";
            //ss.splashProgressBar.Value = 100;
            ss.Refresh();

        }
    }
}

