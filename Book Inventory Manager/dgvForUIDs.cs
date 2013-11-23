#region Using directives

using System.Collections;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Collections.Generic;
using System;



#endregion

namespace Prager_Book_Inventory
{

    class populateUIDs
    {
        HashSet<string> collection = new HashSet<string>();

        public void cleanDGVtable(DataGridView dgv) {

            placeUIDsInArray(dgv);  //  save UIDs to an array to check for duplicates
            mainForm mf = new mainForm(false);
            mf.createUploadInfoTable();  //  delete table and recreate it...
            saveOldDGVContentsToTable(dgv);  //  save the collectionString elements to table
            populateDataGridView(dgv);  //  now populate mainForm userIDs 
        }


        //------------------------------------------------------------------------
        //--  remove duplicate entries from UID and Passwords DGV
        private void placeUIDsInArray(DataGridView dgv1) {

            int x = dgv1.Columns.Count;
            int y = dgv1.Rows.Count;

            string collectionString = "";  //  repository for DGV data

            try {
                for (int rowNdx = 0; rowNdx < dgv1.RowCount; rowNdx++) { //  go through each of the valid rows

                    //string a = dgv1.Rows[rowNdx].Cells["dgvListingServiceID"].Value.ToString();
                    //string b = dgv1.Rows[rowNdx].Cells["dgvUserID"].Value.ToString();
                    //string c = dgv1.Rows[rowNdx].Cells["dgvPassword"].Value.ToString();

                    if (!dgv1.Rows[rowNdx].Cells["dgvUserID"].Value.Equals("") &&
                        !dgv1.Rows[rowNdx].Cells["dgvUserID"].Value.Equals(DBNull.Value)) {

                        collectionString =
                        dgv1.Rows[rowNdx].Cells["dgvListingServiceID"].Value.ToString() + ":" +
                        dgv1.Rows[rowNdx].Cells["dgvUserID"].Value.ToString() + ":" +
                        dgv1.Rows[rowNdx].Cells["dgvPassword"].Value.ToString();
                        collection.Add(collectionString);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("error: " + ex.Message);
            }

        }


        //------------------------------------------------------------------------
        //--   save contents of the datagridview to tUploadInfo table
        public void saveOldDGVContentsToTable(DataGridView dgv) {

            string updateString = "";
            FbCommand sqlCmd = new FbCommand();
            //string customSiteName = "";

            //foreach (DataGridViewRow dataRow in dgv.Rows) {  //  take each row and make an update statement with it
            //    //    int rowNbr = dataRow.Index;  //  DEBUGGING  <------------
            //    if (dataRow.IsNewRow)
            //        continue;
            string[] savedValues = null;
            try {
                foreach (var item in collection) {
                    savedValues = item.ToString().Split(':');
                }

                if (!savedValues[0].Contains("Custom Site"))  //  not a custom site
                    updateString = "UPDATE tUploadInfo SET  UID = '" + savedValues[1] +
                        "', Pwd = '" + savedValues[2] + "' WHERE ListingService = '" + savedValues[0] + "'";
                else {  //  otherwise this is a custom site


                    //if (!dataRow.Cells[0].Value.ToString().Contains("Custom Site"))  //  not a custom site
                    //    updateString = "UPDATE tUploadInfo SET  UID = '" + dataRow.Cells[1].Value.ToString() +
                    //        "', Pwd = '" + dataRow.Cells[2].Value.ToString() +
                    //        "' WHERE ListingService = '" + dataRow.Cells[0].Value.ToString() + "'";
                    //else {  //  otherwise this is a custom site

                    //    //    switch (dataRow.Index - 19) {
                    //    //        case 0:
                    //    //            customSiteName = mf.tbCustomSite1.Text;
                    //    //            break;
                    //    //        case 1:
                    //    //            customSiteName = mf.tbCustomSite2.Text;
                    //    //            break;
                    //    //        case 2:
                    //    //            customSiteName = mf.tbCustomSite3.Text;
                    //    //            break;
                    //    //        case 3:
                    //    //            customSiteName = mf.tbCustomSite4.Text;
                    //    //            break;
                    //    //    }

                    //    updateString = "UPDATE tUploadInfo SET  UID = '" + dataRow.Cells[1].Value.ToString() +
                    //    "', Pwd = '" + dataRow.Cells[2].Value.ToString() +
                    //    "', FTPAddr = '" + dataRow.Cells[3].Value.ToString() +
                    //    "', FTPDir = '" + dataRow.Cells[4].Value.ToString() +
                    //    "', FileFmt = '" + dataRow.Cells[5].Value.ToString() +
                    //    "', ListingService = '" + customSiteName + "'" +  //  <-------------------
                    //    " ROWS " + (dataRow.Index + 1) + " TO " + (dataRow.Index + 1);

                }

                //  now, update the table
                sqlCmd.CommandText = updateString;
                sqlCmd.Connection = mainForm.bookConn;
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                MessageBox.Show("error: " + ex.Message);
            }

        }


        //-------------------------------------------------------------------------------
        public void populateDataGridView(DataGridView dgv1) {

            DataTable dt = new DataTable("tUploadInfo");
            FbDataAdapter da = new FbDataAdapter("SELECT * from tUploadInfo", mainForm.bookConn);
            da.Fill(dt);  //  fill datatable
            dgv1.DataSource = dt;

            populateUserIDs(dgv1);
        }


        //--------------------------------------------------------------------------------
        //--  populate the User IDs and Passwords
        private void populateUserIDs(DataGridView dgv1) {

            //  move the data to internal strings
            foreach (DataGridViewRow dataRow in dgv1.Rows) {
                if (dataRow.Cells[0].Value == null)
                    continue;
                switch (dataRow.Cells[0].Value.ToString()) {  
                    case "A1 Books":
                        mainForm.A1BooksUID = dataRow.Cells[1].Value.ToString();
                        mainForm.A1BooksPwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "ABE":
                        mainForm.ABEUID = dataRow.Cells[1].Value.ToString();
                        mainForm.ABEPwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "Alibris":
                        mainForm.AlibrisUID = dataRow.Cells[1].Value.ToString();
                        mainForm.AlibrisPwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "Amazon.ca":
                        mainForm.AmazoncaUID = dataRow.Cells[1].Value.ToString();
                        mainForm.AmazoncaPwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "Amazon.co.uk":
                        mainForm.AmazoncoUKUID = dataRow.Cells[1].Value.ToString();
                        mainForm.AmazoncoUKPwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "Antiqbook":
                        mainForm.AntiqBookUID = dataRow.Cells[1].Value.ToString();
                        mainForm.AntiqBookPwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "Biblio":
                        mainForm.BiblioUID = dataRow.Cells[1].Value.ToString();
                        mainForm.BiblioPwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "Barnes & Noble":
                        mainForm.BandNUID = dataRow.Cells[1].Value.ToString();
                        mainForm.BandNPwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "Biblion":
                        mainForm.BiblionUID = dataRow.Cells[1].Value.ToString();
                        mainForm.BiblionPwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "Bibliophile":
                        mainForm.BibliophileUID = dataRow.Cells[1].Value.ToString();
                        mainForm.BibliophilePwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "Book Byte":
                        mainForm.BookByteUID = dataRow.Cells[1].Value.ToString();
                        mainForm.BookBytePwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "ChooseBooks":
                        mainForm.ChooseUID = dataRow.Cells[1].Value.ToString();
                        mainForm.ChoosePwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "Chrislands":
                        mainForm.ChrislandsUID = dataRow.Cells[1].Value.ToString();
                        mainForm.ChrislandsPwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "Google":
                        mainForm.GoogleUID = dataRow.Cells[1].Value.ToString();
                        mainForm.GooglePwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "Half.com":
                        mainForm.HalfDotComUID = dataRow.Cells[1].Value.ToString();
                        mainForm.HalfDotComPwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "Tom Folio":
                        mainForm.TomFolioUID = dataRow.Cells[1].Value.ToString();
                        mainForm.TomFolioPwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "Papa Media":
                        mainForm.PapaMediaUID = dataRow.Cells[1].Value.ToString().Trim();
                        mainForm.PapaMediaPwd = dataRow.Cells[2].Value.ToString().Trim();
                        if (mainForm.PapaMediaUID.Length != 0 && !mainForm.PapaMediaUID.Contains("@"))
                            MessageBox.Show("Warning: Papa Media requires an email address for UserID", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case "Scribblemonger":
                        mainForm.ScribblemongerUID = dataRow.Cells[1].Value.ToString().Trim();
                        mainForm.ScribblemongerPwd = dataRow.Cells[2].Value.ToString().Trim();
                        if (mainForm.ScribblemongerUID.Length != 0 && !mainForm.ScribblemongerUID.Contains("@"))
                            MessageBox.Show("Warning: Scribblemonger requires an email address for UserID", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case "Valore Books":
                        mainForm.ValoreUID = dataRow.Cells[1].Value.ToString();
                        mainForm.ValorePwd = dataRow.Cells[2].Value.ToString();
                        break;

                    case "Custom Site 1":
                        mainForm.CSUID1 = dataRow.Cells[1].Value.ToString();
                        mainForm.CSPwd1 = dataRow.Cells[2].Value.ToString();
                        mainForm.CSURL1 = dataRow.Cells[3].Value.ToString();
                        mainForm.CSDir1 = dataRow.Cells[4].Value.ToString();
                        mainForm.CSFF1 = dataRow.Cells[5].Value.ToString();
                        break;
                    case "Custom Site 2":
                        mainForm.CSUID2 = dataRow.Cells[1].Value.ToString();
                        mainForm.CSPwd2 = dataRow.Cells[2].Value.ToString();
                        mainForm.CSURL2 = dataRow.Cells[3].Value.ToString();
                        mainForm.CSDir2 = dataRow.Cells[4].Value.ToString();
                        mainForm.CSFF2 = dataRow.Cells[5].Value.ToString();
                        break;
                    case "Custom Site 3":
                        mainForm.CSUID3 = dataRow.Cells[1].Value.ToString();
                        mainForm.CSPwd3 = dataRow.Cells[2].Value.ToString();
                        mainForm.CSURL3 = dataRow.Cells[3].Value.ToString();
                        mainForm.CSDir3 = dataRow.Cells[4].Value.ToString();
                        mainForm.CSFF3 = dataRow.Cells[5].Value.ToString();
                        break;
                    case "Custom Site 4":
                        mainForm.CSUID4 = dataRow.Cells[1].Value.ToString();
                        mainForm.CSPwd4 = dataRow.Cells[2].Value.ToString();
                        mainForm.CSURL4 = dataRow.Cells[3].Value.ToString();
                        mainForm.CSDir4 = dataRow.Cells[4].Value.ToString();
                        mainForm.CSFF4 = dataRow.Cells[5].Value.ToString();
                        break;
                    default:
                        break;
                }

            }

     //       dgv1.Sort(dgv1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);  // (12.8.3)

        }

        
        //---------------    save contents of the datagridview to tUploadInfo table    -------------------------------------
        public void saveDGVContents(DataGridView dgv1, mainForm mf) {
            string updateString = "";
            FbCommand sqlCmd = new FbCommand();
            string customSiteName = "";

            foreach (DataGridViewRow dataRow in dgv1.Rows)  //  take each row and make an update statement with it
            {
                int rowNbr = dataRow.Index;

                if (dataRow.IsNewRow)
                    continue;

                if (dataRow.Index < 21)  //  first 21 'named' sites UID and passwords
                    updateString = "UPDATE tUploadInfo SET  UID = '" + dataRow.Cells[1].Value.ToString() +
                        "', Pwd = '" + dataRow.Cells[2].Value.ToString() +
                        "' WHERE ListingService = '" + dataRow.Cells[0].Value.ToString() + "'";
                else {  //  otherwise this is a custom site

                    switch (dataRow.Index - 21) {
                        case 0:
                            customSiteName = mf.tbCustomSite1.Text;
                            break;
                        case 1:
                            customSiteName = mf.tbCustomSite2.Text;
                            break;
                        case 2:
                            customSiteName = mf.tbCustomSite3.Text;
                            break;
                        case 3:
                            customSiteName = mf.tbCustomSite4.Text;
                            break;
                    }

                    updateString = "UPDATE tUploadInfo SET  UID = '" + dataRow.Cells[1].Value.ToString() +
                    "', Pwd = '" + dataRow.Cells[2].Value.ToString() +
                    "', FTPAddr = '" + dataRow.Cells[3].Value.ToString() +
                    "', FTPDir = '" + dataRow.Cells[4].Value.ToString() +
                    "', FileFmt = '" + dataRow.Cells[5].Value.ToString() +
                    "', ListingService = '" + customSiteName + "'" + 
                    " ROWS " + (dataRow.Index + 1) + " TO " + (dataRow.Index + 1);
                }

                sqlCmd.CommandText = updateString;
                sqlCmd.Connection = mainForm.bookConn;

                if (sqlCmd.Connection.State == ConnectionState.Closed) {
                    sqlCmd.Connection.Open();  //  this was an issue: connection string is not initialized  <----------
                }
                try {
                    sqlCmd.ExecuteNonQuery();
                }
                catch (Exception ex) {
                    string data = updateString + "\nError: " + ex.Message;
                    mainForm.emailDebuggingData(data);
             //       MessageBox.Show("updateString: " + updateString, "Debugging",MessageBoxButtons.OK);
                }
            }

        }

    }
}