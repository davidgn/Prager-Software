using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using FirebirdSql.Data.FirebirdClient;
using System.Globalization;

//  my B&N ID:   BNA0098923
//  my B&N password:  QNy1vSTn
//  B&N hostname:  sftp.barnesandnoble.com

namespace Prager_Book_Inventory
{
    partial class mainForm : Form
    {
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create a file in tab-delimited format for Barnes and Noble
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public string BnNFileName;
        public int createBnNExport(string formattedDate) {

            Cursor.Current = Cursors.WaitCursor;
            TextWriter tw = null;

            if (rbExportAll.Checked == false && rbChangeDate.Checked == false && rbExportInclusiveSearch.Checked == false && rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            BnNFileName = exportPath + "BnN" + formattedDate.Substring(0, 8) + "_" + formattedDate.Substring(8, 4) + ".txt";

            try {
                tw = new StreamWriter(BnNFileName);  //  for normal tab-delimited files
            }
            catch (Exception e) {
                if (e.ToString().Substring(10, 26) == "DirectoryNotFoundException") {
                    try {
                        DirectoryInfo di = Directory.CreateDirectory(exportPath);   // Try to create the directory
                        tw = new StreamWriter(BnNFileName);
                    }
                    catch (Exception e1) {
                        MessageBox.Show("Unable to create BnN export directory: " + e1.Message, "Prager Book Inventory Manager",
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
            lbUploadStatus.Items.Insert(0, "B & N export started");
            lbUploadStatus.Refresh();

            //  write header
            tw.WriteLine("SKU\tISBN\tPrice\tComments\tCondition\tDustJacket\tFirstEdition\tSigned\tTitle\tAuthor\tFormat\t" + 
                "Publisher\tIllustrator\tPublishPlace\tPublishYear\tQuantity\tType\t");

            while (data.Read()) {
                tbBookNbr.Text = data["BookNbr"].ToString();  //  for debugging purposes only!

                //if (cbPurgeReplace.Checked == true && data["Stat"].ToString() == "Sold")
                //    continue;  //  if purge/replace and Sold, don't upload

                if (data["Stat"].ToString() == "Hold")
                    continue;  //  don't export

                buildBnNTabDelimitedFile(data, tw);

                count++;  //  increment counter
            }

            tw.Close();  //  close the stream

            if (data != null)  //  close the data reader
                data.Close();

            Cursor.Current = Cursors.Default;

            lbUploadStatus.Items.Insert(0, "B & N export(s) completed: " + count + " books exported to file " + exportPath + BnNFileName);
            lbUploadStatus.Refresh();

            return 0;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    build a TAB delimited format file
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void buildBnNTabDelimitedFile(FbDataReader data, TextWriter tw) {

            string dataBuild;
            string tempData = "";
            decimal tempAmount = 0.0M;

            dataBuild = data["BookNbr"].ToString() + "\t";  //  SKU

            string tempISBN = data["ISBN"].ToString().StartsWith("B") ? "" : data["ISBN"].ToString();  //  ISBN
            dataBuild += tempISBN + "\t";

            tempAmount = (decimal)data["Price"];
            tempData = tempAmount.ToString("C");
            dataBuild += tempData.Replace("$", "") +"\t";  //  price

            if (data["Descr"] != DBNull.Value)
                dataBuild += data["Descr"].ToString() + "\t";  //  description
            else
                dataBuild += " \t";

            if (data["Condn"] != DBNull.Value)
                dataBuild += data["Condn"].ToString() + "\t";  //  condition
            else
                dataBuild += " \t";

            dataBuild += data["Jaket"] != DBNull.Value ? "Y\t" : "N\t";  //  dust jacket exists?

            if (data["Ed"] != DBNull.Value) {
                tempData = data["Ed"].ToString();  //  Edition
                dataBuild += tempData.Contains("First Ed") ? "Y\t" : "N\t";
            }

            if (data["Signed"] != DBNull.Value)  //  signed-by Author
                if (data["Signed"].ToString() == "A")
                    dataBuild += "Y\t";
                else
                    dataBuild += "N\t";

            dataBuild += data["Title"].ToString() + "\t";  //  title

            dataBuild += data["Author"].ToString() + "\t";  //  author

            if (data["Bndg"] != DBNull.Value)
                dataBuild += data["Bndg"].ToString() + "\t";  //  binding
            else
                dataBuild += " \t";

            if (data["Pub"] != DBNull.Value)
                dataBuild += data["Pub"].ToString() + "\t";  //  publisher
            else
                dataBuild += " \t";

            if (data["Signed"] != DBNull.Value)  //  signed-by Illustrator
                if (data["Signed"].ToString() == "I")
                    dataBuild += "Y\t";
                else
                    dataBuild += "N\t";

            if (data["PubPlace"] != DBNull.Value)
                dataBuild += data["PubPlace"].ToString() + "\t";  //  place published
            else
                dataBuild += " \t";

            if (data["PubYear"] != DBNull.Value)
                dataBuild += data["PubYear"].ToString() + "\t";  //  year published
            else
                dataBuild += " \t";

            dataBuild += data["Quantity"] + "\t";  //  quantity

            dataBuild += "Book\t";  //  product type

            tw.WriteLine(dataBuild);

            return;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    SFTP file upload for Barnes & Noble
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int sftpUpload(string[] args)
        {
            const string logname = "log.xml";

            //++++++++++++++++++++++++++++++++++++
            //  return 0;  TESTING ONLY!  <-----------
            //++++++++++++++++++++++++++++++++++++

            // assign args to make it clearer
            string userID = args[0];
            string password = args[1];
            string hostURL = args[2];
            string fileName = args[3];
            string directory = args[4];

            // Run hidden WinSCP process
            Process winscp = new Process();
            winscp.StartInfo.FileName = programFilesDirectoryName + @"\WinSCP\winscp.com";
            winscp.StartInfo.Arguments = "/log=" + logname;
            winscp.StartInfo.UseShellExecute = false;
            winscp.StartInfo.RedirectStandardInput = true;
            winscp.StartInfo.RedirectStandardOutput = true;
            winscp.StartInfo.CreateNoWindow = true;
            winscp.Start();

            // Feed in the scripting commands
            winscp.StandardInput.WriteLine("option batch abort");
            winscp.StandardInput.WriteLine("option confirm off");
            winscp.StandardInput.WriteLine("open sftp://" + args[0] + ":" + args[1] +
                "@sftp.barnesandnoble.com:22 " +
                "-hostkey=\"ssh-dss 2048 da:48:4b:09:de:f2:a5:4e:1f:7e:63:b0:f9:b5:64:39\"");
            winscp.StandardInput.WriteLine(@"cd " + args[4]);
            winscp.StandardInput.WriteLine("put " + args[3]);
            winscp.StandardInput.Close();

            // Collect all output
            string output = winscp.StandardOutput.ReadToEnd();

            // Wait until WinSCP finishes
            winscp.WaitForExit();
            winscp.Close();

            //if (winscp.ExitCode != 0)  can't use this because we already closed it!
            //    return -1;
            //else
                return 0;

            ///// Parse and interpret the XML log
            ///// (Note that in case of fatal failure the log file may not exist at all)
            //XPathDocument log = new XPathDocument(logname);
            //XmlNamespaceManager ns = new XmlNamespaceManager(new NameTable());
            //ns.AddNamespace("w", "http://winscp.net/schema/session/1.0");
            //XPathNavigator nav = log.CreateNavigator();

            ///// Success (0) or error?
            //if (winscp.ExitCode != 0)
            //{
            //    Console.WriteLine("Error occured");

            //    /// See if there are any messages associated with the error
            //    foreach (XPathNavigator message in nav.Select("//w:message", ns))
            //    {
            //        Console.WriteLine(message.Value);
            //    }
            //}
            //else
            //{
            //    // It can be worth looking for directory listing even in case of error as possibly only upload may fail
            //    XPathNodeIterator files = nav.Select("//w:file", ns);
            //    Console.WriteLine(string.Format("There are {0} files and subdirectories:", files.Count));
            //    foreach (XPathNavigator file in files)
            //    {
            //        Console.WriteLine(file.SelectSingleNode("w:filename/@value", ns).Value);
            //    }
            //}

            //return 0;
        }

    }

}

