using System;
using System.Data;
using System.Linq;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Data.Odbc;
using FirebirdSql;
using FirebirdSql.Data.FirebirdClient;


namespace BulkAddBooks
{
    public partial class mainForm : Form
    {
        //  now, get Amazon keys
        private void getAmazonKeys() {
            
            string selectString = "SELECT * from tAZUID";
            FbCommand sqlCmd = new FbCommand(selectString, bookConn);
            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();

            FbDataReader dr = sqlCmd.ExecuteReader();
            dr.Read();  //  read the only row


            if (dr[0].ToString().Length != 0) {
                merchantId = dr[0].ToString();
                marketplaceId = dr[1].ToString();
                accessKeyId = dr[2].ToString();
                secretAccessKey = dr[3].ToString();
            }

            dr.Close();

            return;
        }


        //------------------------    read Inventory.cfg file    -----------------|
        private void readConfigFile() {
            string applicationPath = Application.StartupPath;

            FileInfo newLoc = new FileInfo(@"C:\Prager\Inventory.cfg");
            if (!newLoc.Exists)  //  if the config file is NOT in the new directory...
            {
                //  look at the first possible application path...
                fTrace("I - applicationPath:  " + applicationPath);
                if (applicationPath.Contains("Program Files (x86)"))  //  on 64-bit machines
                {
                    FileInfo x86 = new FileInfo(applicationPath + @"\Inventory.cfg");
                    if (x86.Exists)  //  yep, it's here, so move it to new directory
                        x86.MoveTo(@"C:\Prager\Inventory.cfg");  //  move to new directory
                }
                else  //  application path is C:\Program Files\Prager\Inv (on 32-bit machines)
                {
                    FileInfo x64 = new FileInfo(applicationPath + @"\Inventory.cfg");
                    if (x64.Exists)  //  yep, it's here, so move it to new directory
                        x64.MoveTo(@"C:\Prager\Inventory.cfg");  //  move to new directory
                    else  //  it's missing (shouldn't happen!)
                    {
                        MessageBox.Show("Inventory.cfg file is missing - contact support@pragersoftware.com", "Prager, Software", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Application.Exit();
                    }
                }
            }

            XmlTextReader reader = new XmlTextReader(@"C:\Prager\Inventory.cfg");
            while (reader.Read()) {
                if (reader.NodeType == XmlNodeType.Element) {
                    switch (reader.LocalName) {
                        case "DatabasePath":
                            databasePath = reader.ReadElementContentAsString();
                            break;
                        case "BackupPath":
                            backupPath = reader.ReadElementContentAsString();
                            if (backupPath.Length != 0 && !Directory.Exists(backupPath))
                                Directory.CreateDirectory(backupPath);
                            break;
                        case "ExportPath":
                            exportPath = reader.ReadElementContentAsString();
                            if (exportPath.Length != 0 && !Directory.Exists(exportPath))
                                Directory.CreateDirectory(exportPath);
                            break;
                        case "DaysRetention":
                            daysRetention = reader.ReadElementContentAsString();
                            break;
                        default:
                            break;
                    }
                }
            }
            reader.Close();

            fTrace("I - Database Path: " + databasePath);

            if (databasePath == null || backupPath == null || exportPath == null || daysRetention == null ||
                databasePath.Length == 0 || backupPath.Length == 0 || exportPath.Length == 0 || daysRetention.Length == 0) {
                fTrace("E - configuration file is invalid");
                MessageBox.Show("The configuration file is invalid; the Inventory program is \nunable to continue without major damage to the database!",
                    "Prager Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                throw new System.ArgumentException("invalid configuration file");
            }
            fTrace("I - finished readConfigFile");
        }



        //----------------------    allow user to send trace data    ---------------------|
        private void fTrace(string str) {
            //trace.Add(str);
        }


        //---------------------    used to change look of datagridview    -----------------------|
        static DataGridViewHeaderBorderStyle ProperColumnHeadersBorderStyle {
            get {
                return (SystemFonts.MessageBoxFont.Name == "Segoe UI") ?
                    DataGridViewHeaderBorderStyle.None :
                    DataGridViewHeaderBorderStyle.Raised;
            }
        }


        //----------------------------    save current entries    ------------------------|
        public void saveCurrentEntries() {
            dgvDataEntry.ReadOnly = true;  //  mark dgv as read only now...
            lDone.Visible = false;
            StreamWriter writer = new StreamWriter(exportPath + @"DGVExport.txt");

            if (dgvDataEntry.Rows.Count > 0) {
                foreach (DataGridViewColumn col in dgvDataEntry.Columns) {
                    if (col.Index == dgvDataEntry.Columns.Count - 1) {  //  header text
                        writer.WriteLine(col.HeaderText);
                    }
                    else {
                        writer.Write(string.Concat(col.HeaderText, ","));
                    }
                }

                foreach (DataGridViewRow row in dgvDataEntry.Rows) {  //  actual data
                    foreach (DataGridViewCell cell in row.Cells) {
                        if (cell.OwningColumn.Index == dgvDataEntry.Columns.Count - 1) {
                            if (cell.Value != null)
                                writer.WriteLine(cell.Value.ToString());
                            else
                                writer.WriteLine("");
                        }
                        else {
                            if (cell.Value != null)
                                writer.Write(string.Concat(cell.Value.ToString(), ","));
                            else
                                writer.Write(string.Concat("", ","));
                        }
                    }
                }
            }

            writer.Close();
            lSaveDone.Visible = true;  //  show message
        }


        //-----------------------------    restore saved entries    ------------------|
        public void restoreSavedEntries() {

            string sourceFile = @"C:\Prager\Export\DGVExport.txt";

            if (!File.Exists(sourceFile)) {
                MessageBox.Show("something missing", "Prager, Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FileInfo file = new FileInfo(sourceFile);
            DataSet ds = new DataSet();
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source=" +
                    file.DirectoryName + "; Extended Properties=\"Text;FMT=Delimited\"");

            conn.Open();
            OleDbDataAdapter CSVAdapter = new OleDbDataAdapter("SELECT * FROM " + sourceFile, conn);
            CSVAdapter.Fill(ds);

            dgvDataEntry.Columns.Clear();  //  remove all existing columns

            dgvDataEntry.DataSource = ds.Tables[0];

        }

    }
}


