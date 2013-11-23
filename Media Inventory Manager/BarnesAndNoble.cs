using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.IO;

//  my B&N ID:   BNA0098923
//  my B&N password:  QNy1vSTn
//  B&N hostname:  sftp.barnesandnoble.com

namespace Media_Inventory_Manager
{
    partial class mainForm : Form
    {
        //------------------    do the upload to B & N (uses Amazon's file)    -------------------------]
        public int doBarnesAndNobleUpload(string sFileName, string[] args) {

            //args[0] = BandNUID;
            //args[1] = BandNPwd;
            //args[2] = @"sftp.barnesandnoble.com";

            //tempArg = sFileName.Replace("CSV", "BN");  //  change prefix...
            //tempArg = tempArg.Replace(".csv", ".txt");  // and file type
            //string[] splitFields = sFileName.Split('\\');  //  split into groups...
            //string originalFN = splitFields[3];

            ////  now, change the name from CSV12052011131335.csv
            //string workingFilename = originalFN.Substring(6, originalFN.Length - 6);
            //splitFields[3] = workingFilename.Substring(4, 4) + workingFilename.Substring(0, 4) + "_" + workingFilename.Substring(8, 4) + ".txt";
            //string newFN = splitFields[0] + @"\" + splitFields[1] + @"\" + splitFields[2] + @"\" + splitFields[3];  //  new filename

            ////  now make a copy of the file...
            //FileInfo fi = new FileInfo(tempArg);  //  find the filename
            //fi.CopyTo(newFN, true);  //  make a copy using the new name
            //args[3] = newFN;

            //args[3] = newFN;  // use original file
            //args[4] = @"Listings/Inventory_To_Drop/";     //  chdir

            //Cursor.Current = Cursors.WaitCursor;
            return (sftpUpload(args));
        }


        //-------------------------------------------    SFTP file upload    --------------------------------------------------
        public int sftpUpload(string[] args) {
            const string logname = "log.xml";

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

