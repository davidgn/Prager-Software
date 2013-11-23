//#define TRACE
#region Using directives

using System.Data;
using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
#endregion


namespace Media_Inventory_Manager
{

    partial class mainForm : Form
    {

        // maintenanceString = "UPDATE tOptions SET GUID = '" + guid.ToString() + "' ROWS 1";


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  modify existing tables
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void modifyExistingTables(splashScreen ss) {

            FbCommand sqlCmd;
            string maintenanceString = "";

            fTrace("I - starting database maintenance");
            ss.Text = "starting database maintenance";
            ss.Refresh();

            //  change user to SYSDBA
            FbConnection maintenanceConn = new FbConnection("User=sysdba;Password=masterkey;Database=" + dbPath);
            maintenanceConn.Open();

            //-----------------    change Chrislands file format to 'tab'    -----------
            maintenanceString = "UPDATE tUploadInfo SET FILEFMT = 'Tab' WHERE LISTINGSERVICE = 'Chrislands'";
            sqlCmd = new FbCommand(maintenanceString, mediaConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (System.Exception ex) {
                MessageBox.Show("Error changing Chrislands fileformat to 'tab':\r" + ex.Message + "\n" + ex.StackTrace);
            }


            //  add column Actors
            maintenanceString = "ALTER TABLE tMedia ADD Actors varchar(100)";
            sqlCmd = new FbCommand(maintenanceString, maintenanceConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                if (!e.Message.Contains("attempt to store duplicate value"))
                    MessageBox.Show("Error adding Actors to tMedia: " + e.Message, "Prager, Media Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //  add column Director
            maintenanceString = "ALTER TABLE tMedia ADD Director varchar(50)";
            sqlCmd = new FbCommand(maintenanceString, maintenanceConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                if (!e.Message.Contains("attempt to store duplicate value"))
                    MessageBox.Show("Error adding Director to tMedia: " + e.Message, "Prager, Media Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //  add column Edition
            maintenanceString = "ALTER TABLE tMedia ADD Edition varchar(25)";
            sqlCmd = new FbCommand(maintenanceString, maintenanceConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                if (!e.Message.Contains("attempt to store duplicate value"))
                    MessageBox.Show("Error adding Edition to tMedia: " + e.Message, "Prager, Media Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //  add column MAC
            maintenanceString = "ALTER TABLE tOptions ADD MAC varchar(12)";
            sqlCmd = new FbCommand(maintenanceString, maintenanceConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                if (!e.Message.Contains("attempt to store duplicate value"))
                    MessageBox.Show("Error adding MAC to tOptions: " + e.Message, "Prager, Media Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //  create table to hold Amazon's various keys
            string createString = "CREATE TABLE tAZUID (MWSMerchantID VARCHAR (25), MWSMarketplaceID VARCHAR (25), " +
                "AWSAccessKey VARCHAR (25), AWSSecretKey VARCHAR (50), AWSAssocTag VARCHAR (15))";
            sqlCmd = new FbCommand(createString, maintenanceConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                if (e.Message.Contains("Table TAZUID already exists"))
                    goto lcannedText;
                else
                    MessageBox.Show("Error creating tAZUID: " + e.Message, "Prager, Media Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //  now, grant permissions
            string grantPermissions = "GRANT ALL ON tAZUID TO PUBLIC";
            sqlCmd = new FbCommand(grantPermissions, maintenanceConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                MessageBox.Show("Error creating permissions for tAZUID: " + e.Message, "Prager, Media Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string insertString = "INSERT INTO tAZUID (MWSMerchantID, MWSMarketplaceID, AWSAccessKey, AWSSecretKey, AWSAssocTag) " +
                "VALUES ('', '', '', '', '')";
            sqlCmd = new FbCommand(insertString, maintenanceConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                MessageBox.Show("Error creating permissions for tAZUID: " + e.Message, "Prager, Media Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        lcannedText:  //  create table to hold Canned Text
            //  drop table if it alredy exists

            //  create table
            createString = "CREATE TABLE tCannedText (sTitle VARCHAR (20) PRIMARY KEY, sCannedText VARCHAR (200))";
            sqlCmd = new FbCommand(createString, maintenanceConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                if (e.Message.Contains("Table TCANNEDTEXT already exists"))
                    goto weAreDone;
                else
                    MessageBox.Show("Error creating tCannedText: " + e.Message, "Prager, Media Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //  grant permissions
            grantPermissions = "GRANT ALL ON tCannedText TO PUBLIC";
            sqlCmd = new FbCommand(grantPermissions, maintenanceConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                MessageBox.Show("Error creating permissions for tCannedText: " + e.Message, "Prager, Media Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

weAreDone:  //  clean up and get outta Dodge
            maintenanceConn.Close();
            maintenanceConn.Dispose();

            fTrace("I - finished database maintenance");
            ss.Text = "finished database maintenance";
            ss.splashProgressBar.Value = 100;
            ss.Refresh();

        }
    }
}

