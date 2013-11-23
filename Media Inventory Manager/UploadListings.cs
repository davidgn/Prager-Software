
#region Using directives

using System;
using System.IO;
using System.Windows.Forms;
using EnterpriseDT.Net.Ftp;

#endregion

namespace Media_Inventory_Manager
{

    partial class mainForm : Form
    {
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    prepare for upload
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void prepareForUpload() {

            if (cbUploadAlibris.Checked == false &&
                cbUploadPapaMedia.Checked == false &&
                cbUploadScribblemonger.Checked == false &&
                cbUploadBandN.Checked == false &&
                cbUploadHalfDotCom.Checked == false &&
                cbUploadAmazon.Checked == false &&
                cbUploadAmazonUK.Checked == false &&
                cbUploadChrislands.Checked == false &&
                cbUploadCS1.Checked == false &&
                cbUploadCS2.Checked == false &&
                cbUploadCS3.Checked == false &&
                cbUploadCS4.Checked == false) {
                MessageBox.Show("No Site Marked for Uploading", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            //  check for Amazon keys
            if ((cbUploadAmazon.Checked == true && (tbMerchantID.Text.Length == 0 || tbMarketplaceID.Text.Length == 0)) ||
                (cbUploadAmazonUK.Checked == true && (tbAWSKey.Text.Length == 0 || tbAWSSecretKey.Text.Length == 0))) {
                DialogResult dResult = MessageBox.Show("You must provide the Amazon keys if you are going to upload to Amazon.com.  Do you want to get them now?", "Prager Media Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dResult.ToString().ToLower() == "no")
                    return;
                else if (dResult.ToString().ToLower() == "yes") {
                    tabTaskPanel.SelectTab(cUIDPswd);  //  go to UserID and Passwords tab to get keys
                    return;
                }
            }

           
            if (cbUploadTest.Checked == true)  //  is this a test?
                sFileName1 = exportPath + @"HBTestUpload.txt";
            else { //  if purge is checked, open dialog with "purge" filter
                if (cbUploadPurgeReplace.Checked == true && (!cbUploadAmazon.Checked && !cbUploadAmazonUK.Checked))
                    openFileDialog1.Filter = @"Export files (purgeCSV*.csv)|purgeCSV*.csv";
                else  //  no, just a plain upload
                    openFileDialog1.Filter = @"Export files (CSV*.csv)|CSV*.csv";
                openFileDialog1.InitialDirectory = exportPath;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    sFileName1 = openFileDialog1.FileName;  // let users pick the correct file
                else
                    return;
            }

            //  verify venues that allow purge
            if (sFileName1.IndexOf("purge", 0) > 0) {  //  we are trying to do a purge...
                if (cbUploadPapaMedia.Checked == true ||
                   cbUploadScribblemonger.Checked == true ||
                   cbUploadAmazon.Checked == true ||
                   cbUploadAmazonUK.Checked == true ||
                   cbUploadHalfDotCom.Checked == true) {
                    MessageBox.Show("Automatic purge is only accepted by Alibris, Amazon and Chrislands",
                        "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            lbUploadStatus.Items.Insert(0, "-->uploads started...");  //  show message

            uploadListings(sFileName1);  //  do the actual upload here

            lbUploadStatus.Items.Insert(0, "-->uploads ended...");
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    upload listings
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void uploadListings(string sFileName) {
            string[] args = { null, null, null, null, null };
            int rc = 0;
            MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();


            //-->  Alibris (TAB)  
            if (cbUploadAlibris.Checked == true && AlibrisUID.Length == 0)
                MessageBox.Show("Alibris User ID is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (cbUploadAlibris.Checked) {  // only do the upload if selected
                    lbUploadStatus.Items.Insert(0, "upload to Alibris started");
                    lbUploadStatus.Refresh();

                    args[0] = AlibrisUID;
                    args[1] = AlibrisPwd;
                    args[2] = @"aus.alibris.com";

                    tempArg = sFileName.Replace("CSV", "ALMu");  //  change filename
                    tempArg = tempArg.Replace(".csv", ".tab");  //  change extension
                    args[3] = tempArg;
                    //  if any of the buttons are checked to limit the number of records, process them here  <--------------  TODO
                    args[4] = @"/";

                    if ((rc = uploadFile(args)) == 0)  //  do the upload
                        lbUploadStatus.Items.Insert(0, "Music upload to Alibris ended successfully");
                    else
                        lbUploadStatus.Items.Insert(0, "--> Music upload to Alibris had an error: " + rc);

                    tempArg = sFileName.Replace("CSV", "ALVi");  //  change filename
                    tempArg = tempArg.Replace(".csv", ".tab");  //  change extension
                    args[3] = tempArg;
                    //  if any of the buttons are checked to limit the number of records, process them here  <--------------  TODO
                    //args[4] = @"/";

                    if ((rc = uploadFile(args)) == 0)  //  do the upload
                        lbUploadStatus.Items.Insert(0, "Video upload to Alibris ended successfully");
                    else
                        lbUploadStatus.Items.Insert(0, "--> Video upload to Alibris had an error: " + rc);

                    Cursor.Current = Cursors.WaitCursor;

                    lbUploadStatus.Refresh();
                    Application.DoEvents();
                }


            //-->  Barnes & Noble (TAB)  <------------  but sending HB for now  TODO 
            if (cbUploadBandN.Checked && BandNUID.Length == 0)   //  check for uid and password
                MessageBox.Show("Barnes & Noble User ID is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (cbUploadBandN.Checked) {  //  only do upload if selected
                    lbUploadStatus.Items.Insert(0, "upload to Barnes & Noble started");
                    lbUploadStatus.Refresh();

                    args[0] = BandNUID;
                    args[1] = BandNPwd;
                    args[2] = @"sftp.barnesandnoble.com";

                    //tempArg = sFileName.Replace("CSV", "BN");  //  change prefix...
                    //tempArg = tempArg.Replace(".csv", ".txt");  // and file type
                    string[] splitFields = sFileName.Split('\\');  //  split into groups...
                    string originalFN = splitFields[3];

                    //  now, change the name from CSV12052011131335.csv
                    string workingFilename = originalFN.Substring(3, originalFN.Length - 3);
                    splitFields[3] = workingFilename.Substring(4, 4) + workingFilename.Substring(0, 4) + "_" + workingFilename.Substring(8, 4) + ".txt";
                    string newFN = splitFields[0] + @"\" + splitFields[1] + @"\" + splitFields[2] + @"\" + splitFields[3];  //  new filename

                    //  now make a copy of the file...
                    FileInfo fi = new FileInfo(sFileName);  //  find the filename
                    fi.CopyTo(newFN, true);  //  make a copy using the new name
                    args[3] = newFN;

                    args[3] = originalFN;  // use original file
                    args[4] = @"Listings/Inventory_To_Drop/";     //  chdir  <-------------- VERIFY ????????????  TODO

                    if (doBarnesAndNobleUpload(sFileName, args) == 0)
                        lbUploadStatus.Items.Insert(0, "upload to Barnes & Noble ended successfully");
                    else
                        lbUploadStatus.Items.Insert(0, "--> upload to Barnes & Noble had an error: " + rc);
                    lbUploadStatus.Refresh();
                    Application.DoEvents();
                }


            //  Half.com (CSV)
            if (cbUploadHalfDotCom.Checked && tbHalfToken.Text.Length == 0)   //  Token replaces User ID
                MessageBox.Show("Half.com User ID is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (cbUploadHalfDotCom.Checked) {  //  only do upload if selected
                    doHalfDotComUpload(sFileName, tbHalfToken.Text);
                    Application.DoEvents();
                }


            //-->  Amazon.com (Tab)
            string uploadAZMu = "";
            string uploadAZVi = "";
            //if ((cbUploadAmazon.Checked || cbUploadAmazonUK.Checked))  // && AmazonUID.Length == 0)
            //    MessageBox.Show("Amazon User ID is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else
                if (cbUploadAmazon.Checked || cbUploadAmazonUK.Checked) {  //  only do if selected
                    int x = 0;  //  get feed file 
                    string[] fileNameParts = sFileName.Split('\\');  //  break it down...
                    for (x = 0; x < fileNameParts.Length; x++)
                        uploadAZMu += fileNameParts[x] + @"\";

                    uploadAZMu = uploadAZMu.Substring(0, uploadAZMu.Length - 1);
                    uploadAZMu = fileNameParts[0] + @"\" + fileNameParts[1] + @"\" + fileNameParts[2] + @"\" + fileNameParts[3].Replace("CSV", "AZMu");
                    uploadAZVi = fileNameParts[0] + @"\" + fileNameParts[1] + @"\" + fileNameParts[2] + @"\" + fileNameParts[3].Replace("CSV", "AZVi");
                    uploadAZMu = uploadAZMu.Replace(".csv", ".txt");
                    uploadAZVi = uploadAZVi.Replace(".csv", ".txt");
                    if (cbUploadAmazonUK.Checked == true)
                        lbUploadStatus.Items.Insert(0, "upload to Amazon.co.uk started (" + uploadAZMu + ")");
                    else
                        lbUploadStatus.Items.Insert(0, "upload to Amazon.com started (" + uploadAZMu + ")");
                    lbUploadStatus.Refresh();

                    args[0] = AmazonUID;  //  <-------- not used except for Az.co.UK
                    args[1] = AmazonPwd;

                    args[2] = uploadAZMu;  //  Amazon file for Music
                    rc = uploadAmazonFiles(args);
                    Application.DoEvents();

                    args[2] = uploadAZVi;  //  Amazon file for Video
                    rc = uploadAmazonFiles(args);
                    Application.DoEvents();


                    if (cbUploadAmazonUK.Checked == true)
                        lbUploadStatus.Items.Insert(0, "upload to Amazon.co.uk ended");
                    else
                        lbUploadStatus.Items.Insert(0, "upload to Amazon.com ended");
                }


            //-->  Papa Media (uses Amazon's Tab file)  
            if (cbUploadPapaMedia.Checked && PapaMediaUID.Length == 0)
                MessageBox.Show("Papa Media User ID is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (cbUploadPapaMedia.Checked) {  //  only do if selected
                    lbUploadStatus.Items.Insert(0, "upload to Papa Media started");
                    lbUploadStatus.Refresh();

                    args[0] = "papaMedia@pragersoftware.com";
                    args[1] = "6+Eep&SbY#e+";
                    args[2] = "www.pragersoftware.com";
                    args[3] = uploadAZMu;  //  upload the music file first
                    args[4] = "/";
                    if ((rc = uploadFile(args)) == 0)
                        lbUploadStatus.Items.Insert(0, "Music upload to Papa Media ended successfully");
                    else
                        lbUploadStatus.Items.Insert(0, "--> Music upload to Papa Media had an error: " + rc);

                    //args[0] = "papaMedia@pragersoftware.com";
                    //args[1] = "6+Eep&SbY#e+";
                    //args[2] = "www.pragersoftware.com";
                    args[3] = uploadAZVi;  //  upload the video file
                    //args[4] = "/";
                    if ((rc = uploadFile(args)) == 0)
                        lbUploadStatus.Items.Insert(0, "Video upload to Papa Media ended successfully");
                    else
                        lbUploadStatus.Items.Insert(0, "--> Video upload to Papa Media had an error: " + rc);

                    Cursor.Current = Cursors.WaitCursor;

                    lbUploadStatus.Refresh();
                    Application.DoEvents();
                }


            //-->  Chrislands (CSV)
            if (cbUploadChrislands.Checked && ChrislandsUID.Length == 0)
                MessageBox.Show("Chrislands User ID is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (cbUploadChrislands.Checked) {  //  only do if selected
                    lbUploadStatus.Items.Insert(0, "upload to Chrislands started");
                    lbUploadStatus.Refresh();

                    args[0] = ChrislandsUID;
                    args[1] = ChrislandsPwd;
                    args[2] = @"ftp.chrislands.com";
                    args[3] = sFileName.Replace("HB", "CH");
                    args[4] = @"/";  //  chdir

                    Cursor.Current = Cursors.WaitCursor;
                    if ((rc = uploadFile(args)) == 0)
                        lbUploadStatus.Items.Insert(0, "upload to Chrislands ended successfully");
                    else
                        lbUploadStatus.Items.Insert(0, "--> upload to Chrislands had an error: " + rc);

                    lbUploadStatus.Refresh();
                    Application.DoEvents();
                }


            //-->  Scribblemonger (Tab) 
            if (cbUploadScribblemonger.Checked && ScribblemongerUID.Length == 0)
                MessageBox.Show("Scribblemonger User ID is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (cbUploadScribblemonger.Checked) {  //  only do if selected
                    lbUploadStatus.Items.Insert(0, "upload to Scribblemonger started");
                    lbUploadStatus.Refresh();

                    args[0] = ScribblemongerUID;
                    args[1] = ScribblemongerPwd;
                    args[2] = "ftp.Scribblemonger.com";
                    args[3] = sFileName.Replace("HB", "UI");
                    args[4] = "";  //  chdir

                    Cursor.Current = Cursors.WaitCursor;
                    if ((rc = uploadFile(args)) == 0)
                        lbUploadStatus.Items.Insert(0, "upload to Scribblemonger ended successfully");
                    else
                        lbUploadStatus.Items.Insert(0, "--> upload to Scribblemonger had an error: " + rc);

                    lbUploadStatus.Refresh();
                    Application.DoEvents();
                }


            //-->  Custom Site 1
            if (cbUploadCS1.Checked) {
                lbUploadStatus.Items.Insert(0, "upload to " + cbUploadCS1.Text + " started");
                lbUploadStatus.Refresh();

                args[0] = CSUID1;
                args[1] = CSPwd1;
                args[2] = CSURL1;
                if (!CSFF1.Contains("HB"))
                    args[3] = sFileName.Replace("HB", CSFF1.Substring(0, 2));
                args[4] = CSDir1;  //  chdir

                Cursor.Current = Cursors.WaitCursor;

                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to " + cbUploadCS1.Text + " ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to " + cbUploadCS1.Text + " had an error: " + rc);
                lbUploadStatus.Refresh();
                Application.DoEvents();
            }

            //-->  Custom Site 2
            if (cbUploadCS2.Checked) {
                lbUploadStatus.Items.Insert(0, "upload to " + cbUploadCS2.Text + " started");
                lbUploadStatus.Refresh();

                args[0] = CSUID2;
                args[1] = CSPwd2;
                args[2] = CSURL2;
                if (!CSFF2.Contains("HB"))
                    args[3] = sFileName.Replace("HB", CSFF2.Substring(0, 2));
                args[4] = CSDir2;  //  chdir

                Cursor.Current = Cursors.WaitCursor;

                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to " + cbUploadCS2.Text + " ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to " + cbUploadCS2.Text + " had an error: " + rc);
                lbUploadStatus.Refresh();
                Application.DoEvents();
            }

            //-->  Custom Site 3
            if (cbUploadCS3.Checked) {
                lbUploadStatus.Items.Insert(0, "upload to " + cbUploadCS3.Text + " started");
                lbUploadStatus.Refresh();

                args[0] = CSUID3;
                args[1] = CSPwd3;
                args[2] = CSURL3;
                if (!CSFF3.Contains("HB"))
                    args[3] = sFileName.Replace("HB", CSFF3.Substring(0, 2));
                args[4] = CSDir3;  //  chdir

                Cursor.Current = Cursors.WaitCursor;

                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to " + cbUploadCS3.Text + " ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to " + cbUploadCS3.Text + " had an error: " + rc);
                lbUploadStatus.Refresh();
                Application.DoEvents();
            }

            //-->  Custom Site 4
            if (cbUploadCS4.Checked) {
                lbUploadStatus.Items.Insert(0, "upload to " + cbUploadCS4.Text + " started");
                lbUploadStatus.Refresh();

                args[0] = CSUID4;
                args[1] = CSPwd4;
                args[2] = CSURL4;
                if (!CSFF4.Contains("HB"))
                    args[3] = sFileName.Replace("HB", CSFF4.Substring(0, 2));
                args[4] = CSDir4;  //  chdir

                Cursor.Current = Cursors.WaitCursor;

                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to " + cbUploadCS4.Text + " ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to " + cbUploadCS4.Text + " had an error: " + rc);
                lbUploadStatus.Refresh();
                Application.DoEvents();
            }


            Cursor.Current = Cursors.Default;
            lFileWaiting.Text = "NO file waiting to be uploaded.";  //  (assumes no errors)  <-----------  To Do
            lFileWaiting.Refresh();

            return;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    code to upload a file
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int uploadFile(string[] args) {

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //+++++++++++++++++++++++++    for TESTING ONLY!    +++++++++++++++++++++++++++
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //MessageBox.Show("Uploads have been disabled for testing; notify support@pragersoftware.com", "Prager Media Inventory Manager",
            //    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //return 0;


            // assign args to make it clear
            string userID = args[0];
            string password = args[1];
            string hostURL = args[2];
            string fileName = args[3];
            string directory = args[4];

            FTPClient ftp = new FTPClient();
            ftp.RemoteHost = hostURL;

            string[] shortFilename2 = fileName.Split('\\');

            try {
                //  connect
                ftp.Connect();
                if (ftp.IsConnected == true) {
                    // login
                    ftp.Login(userID, password);

                    // set up passive ASCII transfers
                    //log.Debug("Setting up passive, ASCII transfers and TransferBufferSize"); 
                    ftp.ConnectMode = FTPConnectMode.PASV;
                    ftp.TransferType = FTPTransferType.ASCII;
                    ftp.TransferBufferSize = 2048;

                    //  change directory if necessary
                    if (!string.IsNullOrEmpty(directory))
                        ftp.ChDir(directory);

                    // copy file to server 
                    string[] shortFilename = fileName.Split('\\');
                    lbUploadStatus.Items.Insert(0, "starting transfer of " + shortFilename[3]);
                    lbUploadStatus.Refresh();

                    //log.Info("Putting file: " + fileName + " shortFilename: " + shortFilename[3]); 
                    ftp.Put(fileName, shortFilename[3]);  //  local path, remote filename

                    // Shut down client 
                    //log.Info("Quit issued..."); 
                    ftp.Quit();
                }
            }
            catch (Exception e) {
                MessageBox.Show("File transfer error: " + e.Message, "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return 0;
        }
    }
}