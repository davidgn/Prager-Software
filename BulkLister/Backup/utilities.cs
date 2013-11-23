using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace BulkAddBooks
{
    public partial class mainForm : Form
    {

        //----------------------------------------------------------------------    read the configuration file    -----------------------------------
        private int readConfigFile()
        {
            //bool pathFound = false;  //  indicator for FirebirdInstallationPath

            //  find Inventory Program application path...
            string applicationPath = Application.StartupPath;
            fTrace("I - applicationPath:  " + applicationPath);

            //  see if it's there; otherwise ask where it is
            FileInfo fi = new FileInfo(applicationPath + @"\Inv\Inventory.cfg");
            if (!fi.Exists)
            {
                DialogResult dr = MessageBox.Show("Unable to locate Inventory program configuration file (Inventory.cfg)." +
                    @"It should be in the C:\Program Files\Prager\Inv sub-directory" +
                     "\nClick OK to enter the location of the Inventory.cfg file", "Prager, Software",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "configuration files (*.cfg)|*.cfg";
                    if (ofd.ShowDialog() == DialogResult.OK)
                        applicationPath = System.IO.Path.GetDirectoryName(ofd.FileName);
                    else
                        return -1;
                }
                else
                    return -1;
            }

            XmlTextReader reader = new XmlTextReader(applicationPath + @"\Inventory.cfg");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "DatabasePath":
                            databasePath = reader.ReadElementContentAsString();
                            break;
                        //case "FirebirdInstallationPath":
                        //    firebirdInstallationPath = reader.ReadElementContentAsString();
                        //    fTrace("I - Firebird installation path: " + firebirdInstallationPath);
                        //    //pathFound = true;
                        //    break;
                        default:
                            break;
                    }
                }
            }
            reader.Close();

            //if (pathFound == false)
            //    MessageBox.Show("You need to modify Inventory.cfg file to indicate FIrebird installation path", "Prager Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);

            fTrace("I - Database Path: " + databasePath);
            fTrace("I - Backup Path: " + backupPath);  
            fTrace("I - Export Path: " + exportPath);

            //if (databasePath == null || backupPath == null || exportPath == null || daysRetention == null ||
            //    databasePath.Length == 0 || backupPath.Length == 0 || exportPath.Length == 0 || daysRetention.Length == 0)
            //{
            //    fTrace("E - configuration file is invalid");
            //    MessageBox.Show("The configuration file is invalid; the Inventory program is \nunable to continue without major damage to the database!",
            //        "Prager Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    Application.Exit();
            //}
            fTrace("I - finished readConfigFile");
            return 0;
        }


        //---------------------------------    allow user to send trace data    ----------------------------------------
        private void fTrace(string str)
        {
            //trace.Add(str);
        }


        //-------------------------------------    used to change look of datagridview    ---------------------------------------------------
        static DataGridViewHeaderBorderStyle ProperColumnHeadersBorderStyle
        {
            get
            {
                return (SystemFonts.MessageBoxFont.Name == "Segoe UI") ?
                    DataGridViewHeaderBorderStyle.None :
                    DataGridViewHeaderBorderStyle.Raised;
            }
        }



    }
}
