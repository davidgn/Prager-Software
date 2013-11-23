//#define TRACE

#region Using directives

using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using AlexPilotti.FTPS.Client;
using AlexPilotti.FTPS.Common;
using EnterpriseDT.Net.Ftp;
using WinSCP;

#endregion

namespace Prager_Book_Inventory
{

    partial class mainForm : Form
    {
        bool BibliologyUIEE = false;
        bool BiblioUIEE = false;
        bool ABETab = false;
        bool BibliophileUIEE = false;
        bool UsedBookCentralUIEE = false;
        bool BiblionUIEE = false;

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    prepare for upload
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void prepareForUpload() {

            if (cbUploadAlibris.Checked == false &&
                cbUploadBiblio.Checked == false &&
                cbUploadABE.Checked == false &&
                cbUploadChooseBks.Checked == false &&
                cbUploadAntiqBook.Checked == false &&
                cbUploadPapaMedia.Checked == false &&
                cbUploadScribblemonger.Checked == false &&
                cbUploadTomFolio.Checked == false &&
                cbUploadBibliophile.Checked == false &&
                cbUploadGoogleBase.Checked == false &&
                cbUploadBiblion.Checked == false &&
                cbUploadBonanza.Checked == false &&
                cbUploadBandN.Checked == false &&
                cbUploadHalfDotCom.Checked == false &&
                cbUploadGoogleBase.Checked == false &&
                cbUploadAmazon.Checked == false &&
                cbUploadAmazonUK.Checked == false &&
                cbUploadAmazonCA.Checked == false &&
                cbUploadChrislands.Checked == false &&
                cbUploadBookByte.Checked == false &&
                cbUploadValoreBooks.Checked == false &&
                cbUploadCS1.Checked == false &&
                cbUploadCS2.Checked == false &&
                cbUploadCS3.Checked == false &&
                cbUploadCS4.Checked == false) {
                MessageBox.Show("No Site Marked for Uploading", "Prager Book Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if ((cbUploadAmazon.Checked && (tbMerchantID.Text.Length == 0 || tbMarketplaceID.Text.Length == 0)) ||
                (cbUploadAmazonUK.Checked && (tbAWSKey.Text.Length == 0 || tbAWSSecretKey.Text.Length == 0))) {
                DialogResult dResult = MessageBox.Show("You must provide the Amazon keys if you are going to upload to Amazon.  Do you want to get them now?", "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dResult.ToString().ToLower() == "no")
                    return;
                else if (dResult.ToString().ToLower() == "yes") {
                    tabTaskPanel.SelectTab(cUIDPswd);  //  go to UserID and Passwords tab to get keys
                    return;
                }
            }

            if (cbUploadTest.Checked)
                sFileName1 = exportPath + @"HBTestUpload.txt";
            else {
                if (cbUploadPurgeReplace.Checked)  // && (!cbUploadAmazon.Checked && !cbUploadAmazonUK.Checked))
                    openFileDialog1.Filter = @"Export files (purgeHB*.txt)|purgeHB*.txt";
                else
                    openFileDialog1.Filter = @"Export files (HB*.txt)|HB*.txt";
                openFileDialog1.InitialDirectory = exportPath;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    sFileName1 = openFileDialog1.FileName;  // let users pick the correct file
                else
                    return;
            }

            //Form.ActiveForm.Refresh();
            if (sFileName1.IndexOf("purge", 0) > 0)  //  we are trying to do a purge...
            {
                if (cbUploadABE.Checked ||
                    cbUploadAntiqBook.Checked ||
                    cbUploadPapaMedia.Checked ||
                    cbUploadScribblemonger.Checked ||
                    cbUploadTomFolio.Checked ||
                    cbUploadBibliophile.Checked ||
                    cbUploadAmazonUK.Checked ||
                    cbUploadHalfDotCom.Checked ||
                    cbUploadBiblion.Checked ||
                    //cbUploadBibliology.Checked == true ||
                    cbUploadBookByte.Checked) {
                    MessageBox.Show("Automatic purge is only accepted by Alibris, A1 Books,\n" +
                        "Biblio, Amazon, Choosebooks, Valore and Chrislands",
                        "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            lbUploadStatus.Items.Insert(0, "-->uploads started...");

            uploadListings(sFileName1);

            lbUploadStatus.Items.Insert(0, "-->uploads ended...");

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    upload listings
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void uploadListings(string sFileName) {
            string[] args = { null, null, null, null, null, null };
            int rc = 0;
            MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();

            //-->  ABE (txt)  
            if (cbUploadABE.Checked) {
                lbUploadStatus.Items.Insert(0, "upload to ABE Books started");
                lbUploadStatus.Refresh();

                args[0] = ABEUID.ToUpper();
                args[1] = ABEPwd;
                args[2] = "ftp.abebooks.com";  
                args[3] = sFileName.Replace("HB", "ABE");
//                args[3] = args[3].Replace("txt", "tab");  (13.307)
                args[4] = @"/";
                args[5] = @"ssh-rsa 2048 ff:b3:f8:c1:c9:5c:b1:9e:a4:87:86:b2:0e:a9:42:3a";  // SshHostKeyFingerprint 
                Cursor.Current = Cursors.WaitCursor;
                //  if ((rc = uploadFileUsingFTPS(args)) == 0)
                if ((rc = sftpUpload(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to ABE ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to ABE had an error: " + rc);
                lbUploadStatus.Refresh();
                Application.DoEvents();
            }


            //-->  Alibris (UIEE)  
            if (cbUploadAlibris.Checked) {
                lbUploadStatus.Items.Insert(0, "upload to Alibris started");
                lbUploadStatus.Refresh();

                args[0] = AlibrisUID;  //  rmmarsh0
                args[1] = AlibrisPwd;  //  katiem
                args[2] = @"aus.alibris.com";

                tempArg = sFileName.Replace("HB", "UI");  //  change prefix to UI02272006131752.txt
                args[3] = tempArg;

                //  if any of the buttons are checked to limit the number of records, process them here  <--------------  TODO

                args[4] = @"/";       // +tbAlibrisUID ;  //  chdir

                Cursor.Current = Cursors.WaitCursor;
                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to Alibris ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to Alibris had an error: " + rc);
                lbUploadStatus.Refresh();
                Application.DoEvents();
            }


            //-->  Amazon.com (Tab)
            if (cbUploadAmazon.Checked == true || cbUploadAmazonUK.Checked == true || cbUploadAmazonCA.Checked == true) {

                string uploadFN1 = "";
                //string uploadFN2 = "";

                int x = 0;  //  get feed file 
                string[] fileNameParts = sFileName.Split('\\');  //  break it down...
                for (x = 0; x < fileNameParts.Length; x++)
                    uploadFN1 += fileNameParts[x] + @"\";

                uploadFN1 = uploadFN1.Substring(0, uploadFN1.Length - 1);
                uploadFN1 = fileNameParts[0] + @"\" + fileNameParts[1] + @"\" + fileNameParts[2] + @"\" + fileNameParts[3].Replace("HB", "AZisbn");
                //uploadFN2 = fileNameParts[0] + @"\" + fileNameParts[1] + @"\" + fileNameParts[2] + @"\" + fileNameParts[3].Replace("HB", "AZnoisbn");
                if (cbUploadAmazon.Checked) {
                    lbUploadStatus.Items.Insert(0, "upload to Amazon.com started (" + uploadFN1 + ")");
                    lbUploadStatus.Refresh();
                }
                else if (cbUploadAmazonCA.Checked) {  //   not used except for Az.co.UK
                    args[0] = AmazoncaUID;
                    args[1] = AmazoncaPwd;
                }
                else if (cbUploadAmazonUK.Checked) {  //   not used except for Az.co.UK
                    args[0] = AmazoncoUKUID;
                    args[1] = AmazoncoUKPwd;
                }

                args[2] = uploadFN1;  //  Amazon file for ISBNs
                rc = uploadAmazonFiles(args);
                Application.DoEvents();

                if (rc != 0) {
                    lbUploadStatus.Items.Insert(0, "upload to Amazon ended with an error.");
                    return;
                }
                else {
                    lbUploadStatus.Items.Insert(0, "upload to Amazon ended (check MWS Scratchpad for results).");
                    bVerifyAZUploads.Visible = true;
                }
            }

            //-->  Barnes & Noble (Tab)
            string[] splitFields;
            if (cbUploadBandN.Checked == true) {
                lbUploadStatus.Items.Insert(0, "upload to Barnes & Noble started");
                lbUploadStatus.Refresh();

                args[0] = BandNUID;
                args[1] = BandNPwd;
                args[2] = @"sftp.barnesandnoble.com";

                if (cbUploadTest.Checked) {
                    //args[3] = sFileName.Replace("HB", "BnN");
                    //args[3] = args[3].Replace(".txt", ".tab");  //  it's a tab-delimited file
                    args[3] = "BnNT20121028_0910.txt";
                }
                else {
                    splitFields = sFileName.Split('\\');
                    tempArg = splitFields[0] + "\\" + splitFields[1] + "\\" + splitFields[2] + "\\";

                    if (cbUploadPurgeReplace.Checked == false)
                        args[3] = tempArg + splitFields[3].Substring(6, 4) + splitFields[3].Substring(2, 4) +
                            "_" + splitFields[3].Substring(10, 4) + ".txt";
                    else  //    C:\Prager\Export\purgeHB12062012115754.txt
                        args[3] = tempArg + splitFields[3].Substring(11, 4) + splitFields[3].Substring(7, 4) +
                            "_" + splitFields[3].Substring(15, 4) + "_purge.txt";
                }

                args[4] = @"/Listings/Inventory_To_Drop/";     //  chdir
                args[5] = "ssh-dss 2048 da:48:4b:09:de:f2:a5:4e:1f:7e:63:b0:f9:b5:64:39";    // SshHostKeyFingerprint 

                if ((rc = sftpUpload(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to Barnes & Noble ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to Barnes & Noble had an error: " + rc);

                lbUploadStatus.Refresh();
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
            }


            //-->  Bonanza (Tab)
            if (cbUploadBonanza.Checked == true) {
                lbUploadStatus.Items.Insert(0, "upload to Bonanza started");
                lbUploadStatus.Refresh();

                args[0] = BonanzaUID;
                args[1] = BonanzaPwd;
                args[2] = @"ftp.bonanza.com";
                args[3] = sFileName.Replace("HB", "Bza");  // extension remains as .txt
                args[4] = @"/";  //  chdir
                Cursor.Current = Cursors.WaitCursor;

                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to Bonanza ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to Bonanza had an error: " + rc);
                lbUploadStatus.Refresh();
                Application.DoEvents();
            }



            //  Half.com (CSV)
            if (cbUploadHalfDotCom.Checked == true) {
                doHalfDotComUpload(sFileName, tbHalfToken.Text);
                Application.DoEvents();
            }

            //-->  ValoreBooks (Tab) <--- uses Amazon's file format
            if (cbUploadValoreBooks.Checked == true) {
                lbUploadStatus.Items.Insert(0, "upload to ValoreBooks started");
                lbUploadStatus.Refresh();

                args[0] = ValoreUID;  //  prager  <----  s/b "seller id"
                args[1] = ValorePwd;  //  4prager78
                args[2] = @"ftp.valorebooks.com";

                //sFileName --> C:\Program Files\Prager\Export\HB02272006131752.txt
                string modifiedFN = "";
                modifiedFN = sFileName;  //  need this so we can find file to copy
                modifiedFN = modifiedFN.Replace("HB", "Valore");
                modifiedFN = modifiedFN.Replace("txt", "csv");

                splitFields = sFileName.Split('\\');  //  split into groups...

                string newFN = "";

                //x = splitFields[3] -> HB09012010085037.txt
                //                      0 2     8  
                //                      purgeHB09012010151635.txt
                //                      0      7     13
                newFN = splitFields[0] + @"\" + splitFields[1] + @"\" + splitFields[2] + @"\" + ValoreUID.Replace(" ", "") + "_";
                newFN += cbUploadPurgeReplace.Checked == true ? splitFields[3].Substring(13, 2) : splitFields[3].Substring(8, 2); //  yy
                newFN += cbUploadPurgeReplace.Checked == true ? splitFields[3].Substring(7, 4) : splitFields[3].Substring(2, 4); //  mmdd
                newFN += cbUploadPurgeReplace.Checked == true ? "_" + splitFields[3].Substring(15, 4) : "_" + splitFields[3].Substring(10, 4); //  hhmm

                newFN += cbUploadPurgeReplace.Checked == true ? ".full.csv" : ".part.csv";
                newFN = newFN.Replace(" ", "");
                args[3] = newFN;

                //  make a copy of the file...
                FileInfo fi = new FileInfo(modifiedFN);  //  find the filename

                //  make a copy using the new name 
                fi.CopyTo(args[3], true);

                args[4] = @"/Inventory";  //  chdir

                Cursor.Current = Cursors.WaitCursor;
                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to ValoreBooks ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to ValoreBooks had an error: " + rc);

                lbUploadStatus.Refresh();
                Application.DoEvents();
            }


            //-->  Biblio (UIEE)  
            if (cbUploadBiblio.Checked == true) {
                lbUploadStatus.Items.Insert(0, "upload to Biblio started");
                lbUploadStatus.Refresh();

                args[0] = BiblioUID;  //  Prager
                args[1] = BiblioPwd;  //  XrXgiaEp
                args[2] = @"ftp.biblio.com";

                if (!BiblioUIEE) {
                    //DialogResult dResult = MessageBox.Show("Have you notified Biblio that you have switched to the UIEE format?  If yes, we will upload a UIEE file; " +
                    //    "otherwise, we will upload in the old HomeBase format (please notify Biblio that you want to change to the UIEE upload format)",
                    //    "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    DialogResult dResult =
                    dlg.Show(@"Software\Prager\BookInventoryManager\BiblioUIEE",  //  registry entry
                    "DontShowAgain",  //  registry value name
                    DialogResult.OK,  //  default return value returned immediately if box is not shown
                    "Don't show this again",  //  message for checkbox
                    "Have you notified Biblio that you have switched to the UIEE format?  If yes, we will upload a UIEE file; " +
                    "otherwise, we will upload in the old HomeBase format (please notify Biblio that you want to change to the UIEE upload format)",
                    "Prager Book Inventory Manager",  //  window title
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);  //  button and icon code

                    if (dResult.ToString().ToLower() == "no")
                        args[3] = sFileName;
                    else {
                        args[3] = sFileName.Replace("HB", "UI");
                        BiblioUIEE = true;
                    }
                }
                else
                    args[3] = sFileName.Replace("HB", "UI");

                args[4] = @"./";

                Cursor.Current = Cursors.WaitCursor;
                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to Biblio ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to Biblio had an error: " + rc);
                lbUploadStatus.Refresh();
                Application.DoEvents();
            }


            //-->  ChooseBooks (UIEE)           
            if (cbUploadChooseBks.Checked == true) {
                lbUploadStatus.Items.Insert(0, "upload to ChooseBooks started");
                lbUploadStatus.Refresh();

                args[0] = ChooseUID;  //  pragerbooksellers
                args[1] = ChoosePwd;  //  123
                args[2] = @"ftp.choosebooks.com";

                if (cbUploadPurgeReplace.Checked == true) {
                    args[3] = sFileName.Replace("purgeHB", "purgeUI");
                    //File.Move(sFileName, args[3]);  //  now rename it...  <----------------------?????????????
                }
                else
                    args[3] = sFileName.Replace("HB", "UI");

                args[4] = @"/";  //  chdir

                Cursor.Current = Cursors.WaitCursor;
                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to ChooseBooks ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to ChooseBooks had an error: " + rc);

                lbUploadStatus.Refresh();
                Application.DoEvents();
            }

            //-->  AntiqBook (UIEE)
            /*
            * •  address: dusty.antiqbook.com;
            •    username: pra;
            •    password: thingstodo;
            •    directory: /
            * */
            if (cbUploadAntiqBook.Checked == true) {
                lbUploadStatus.Items.Insert(0, "upload to AntiqBook started");
                lbUploadStatus.Refresh();

                if (cbUploadPurgeReplace.Checked == true) {
                    args[3] = sFileName.Replace("HB", "replUI");
                    File.Move(sFileName, args[3]);  //  now rename it...
                }
                else
                    args[3] = sFileName.Replace("HB", "UI");

                args[0] = AntiqBookUID;
                args[1] = AntiqBookPwd;
                args[2] = "dusty.antiqbook.com";
                args[4] = @"/";  //  chdir

                Cursor.Current = Cursors.WaitCursor;
                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to AntiqBook ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to AntiqBook had an error: " + rc);

                lbUploadStatus.Refresh();
                Application.DoEvents();
            }

            //-->  Papa Media (Tab)  
            if (cbUploadPapaMedia.Checked == true) {
                lbUploadStatus.Items.Insert(0, "upload to Papa Media started");
                lbUploadStatus.Refresh();

                args[0] = "papaMedia@pragersoftware.com";
                args[1] = "6+Eep&SbY#e+";
                args[2] = "www.pragersoftware.com";
                args[3] = sFileName1;
                args[4] = "/";

                Cursor.Current = Cursors.WaitCursor;
                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to Papa Media ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to Papa Media had an error: " + rc);

                lbUploadStatus.Refresh();
                Application.DoEvents();
            }

            //-->  TomFolio (UIEE)
            if (cbUploadTomFolio.Checked == true) {
                lbUploadStatus.Items.Insert(0, "upload to TomFolio started");
                lbUploadStatus.Refresh();

                args[0] = TomFolioUID;
                args[1] = TomFolioPwd;
                args[2] = @"ftp.tomfolio.com";
                args[3] = sFileName.Replace("HB", "UI");
                args[4] = @"/" + TomFolioUID;  //  chdir

                Cursor.Current = Cursors.WaitCursor;
                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to TomFolio ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to TomFolio had an error: " + rc);

                lbUploadStatus.Refresh();
                Application.DoEvents();
            }

            //-->  Bibliophile (UIEE) 
            if (cbUploadBibliophile.Checked == true) {
                lbUploadStatus.Items.Insert(0, "upload to Bibliophile started");
                lbUploadStatus.Refresh();

                args[0] = TomFolioUID;
                args[1] = TomFolioPwd;
                args[2] = @"www.bookbase.com";

                if (!BibliophileUIEE) {
                    DialogResult dResult = MessageBox.Show("Have you notified Bibliophile that you have switched to the UIEE format?  If yes, we will upload a UIEE file; " +
                        "otherwise, we will upload in the old HomeBase format (please notify Bibliophile that you want to change to the UIEE upload format)",
                        "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    dResult =
                        dlg.Show(@"Software\Prager\BookInventoryManager\bibliophileUIEE",  //  registry entry
                        "DontShowAgain",  //  registry value name
                        DialogResult.OK,  //  default return value returned immediately if box is not shown
                        "Don't show this again",  //  message for checkbox
                        "Have you notified Bibliophile that you have switched to the UIEE format?  If yes, we will upload a UIEE file; " +
                        "otherwise, we will upload in the old HomeBase format (please notify Bibliophile that you want to change to the UIEE upload format)",
                        "Prager Book Inventory Manager",  //  window title
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);  //  button and icon code

                    if (dResult.ToString().ToLower() == "no")
                        args[3] = sFileName;
                    else {
                        args[3] = sFileName.Replace("HB", "UI");
                        BibliophileUIEE = true;
                    }
                }
                else
                    args[3] = sFileName.Replace("HB", "UI");

                args[4] = @"/";  //  chdir

                Cursor.Current = Cursors.WaitCursor;
                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to Bibliophile ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to Bibliophile had an error: " + rc);

                lbUploadStatus.Refresh();
                Application.DoEvents();
            }


            //-->  Biblion (UIEE)
            if (cbUploadBiblion.Checked == true) {
                lbUploadStatus.Items.Insert(0, "upload to Biblion started");
                lbUploadStatus.Refresh();

                args[0] = BiblionUID;
                args[1] = BiblionPwd;
                args[2] = @"217.158.127.116";
                if (!BiblionUIEE) {
                    //DialogResult dResult = MessageBox.Show("Have you notified Biblion that you have switched to the UIEE format?  If yes, we will upload a UIEE file; " +
                    //    "otherwise, we will upload in the old HomeBase format (please notify Biblion that you want to change to the UIEE upload format)",
                    //    "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    DialogResult dResult =
                        dlg.Show(@"Software\Prager\BookInventoryManager\biblionUIEE",  //  registry entry
                        "DontShowAgain",  //  registry value name
                        DialogResult.OK,  //  default return value returned immediately if box is not shown
                        "Don't show this again",  //  message for checkbox
                        "Have you notified Biblion that you have switched to the UIEE format?  If yes, we will upload a UIEE file; " +
                        "otherwise, we will upload in the old HomeBase format (please notify Biblion that you want to change to the UIEE upload format)",
                        "Prager Book Inventory Manager",  //  window title
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);  //  button and icon code

                    if (dResult.ToString().ToLower() == "no")
                        args[3] = sFileName;
                    else {
                        args[3] = sFileName.Replace("HB", "UI");
                        BiblionUIEE = true;
                    }
                }
                else
                    args[3] = sFileName.Replace("HB", "UI");

                args[4] = @"./";  //  chdir

                Cursor.Current = Cursors.WaitCursor;
                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to Biblion ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to Biblion had an error: " + rc);

                lbUploadStatus.Refresh();
                Application.DoEvents();
            }


            //-->  Chrislands (Tab)  (2 files, one for add/modify, the other for deletes)
            if (cbUploadChrislands.Checked == true) {
                lbUploadStatus.Items.Insert(0, "upload to Chrislands started");
                lbUploadStatus.Refresh();

                args[0] = ChrislandsUID;
                args[1] = ChrislandsPwd;
                args[2] = @"ftp.chrislands.com";
                args[4] = @"/";  //  chdir

                if (cbUploadPurgeReplace.Checked == true) {
                    string tempFN = sFileName.Replace("HB", "Chr");
                    args[3] = tempFN.Replace("txt", "tab");
                    if ((rc = uploadFileUsingFTPS(args)) != 0)
                        //if ((rc = uploadFile(args)) != 0)

                        lbUploadStatus.Items.Insert(0, "--> purge/replace upload to Chrislands had an error: " + rc);
                    else
                        lbUploadStatus.Items.Insert(0, "purge/replace upload to Chrislands ended successfully");
                }
                else {
                    sFileName1 = sFileName.Replace("HB", "Chr");
                    sFileName2 = sFileName.Replace("HB", "deleteChr");

                    args[3] = sFileName1.Replace(".txt", ".tab");
                    if ((rc = uploadFileUsingFTPS(args)) != 0) lbUploadStatus.Items.Insert(0, "--> add/modify upload to Chrislands had an error: " + rc);
                    else {
                        args[3] = sFileName2.Replace(".txt", ".tab");
                        if ((rc = uploadFileUsingFTPS(args)) != 0) lbUploadStatus.Items.Insert(0, "--> delete upload to Chrislands had an error: " + rc);
                        else
                            lbUploadStatus.Items.Insert(0, "upload to Chrislands ended successfully");
                    }
                }

                Cursor.Current = Cursors.WaitCursor;
                lbUploadStatus.Refresh();
                Application.DoEvents();
            }


            //-->  BookByte (UIEE)
            if (cbUploadBookByte.Checked == true) {
                lbUploadStatus.Items.Insert(0, "upload to BookByte started");
                lbUploadStatus.Refresh();

                args[0] = BookByteUID;
                args[1] = BookBytePwd;
                args[2] = @"ftp.bookbyte.com";
                args[3] = sFileName.Replace("HB", "UI");
                args[4] = @"/";  //  chdir

                Cursor.Current = Cursors.WaitCursor;
                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to BookByte ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to BookByte had an error: " + rc);

                lbUploadStatus.Refresh();
                Application.DoEvents();
            }


            //-->  Scribblemonger (UIEE)
            if (cbUploadScribblemonger.Checked == true) {
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

            //-->  Google
            if (cbUploadGoogleBase.Checked == true) {
                lbUploadStatus.Items.Insert(0, "upload to Googe Base started");
                lbUploadStatus.Refresh();

                args[0] = GoogleUID;
                args[1] = GooglePwd;
                args[2] = "uploads.google.com";
                string temp = sFileName.Replace("HB", "XML");  //  get rid of the HB prefix
                temp = temp.Replace("txt", "xml");  //  now, get rid of the suffix
                string[] tempArray = temp.Split('\\');  //  extract the actual filename
                string newFN = tempArray[0] + "\\" + tempArray[1] + "\\" + tempArray[2] + "\\" + googleRegisteredFilename;
                File.Copy(temp, newFN, true);  //  now copy it with a new name...
                args[3] = newFN;
                args[4] = @"/";  //  no chdir

                Cursor.Current = Cursors.WaitCursor;
                if ((rc = uploadFile(args)) == 0)
                    lbUploadStatus.Items.Insert(0, "upload to Google Base ended successfully");
                else
                    lbUploadStatus.Items.Insert(0, "--> upload to Google Base had an error: " + rc);
                lbUploadStatus.Refresh();
                Application.DoEvents();
            }


            //-->  Custom Site 1
            if (cbUploadCS1.Checked == true) {
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
            if (cbUploadCS2.Checked == true) {
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
            if (cbUploadCS3.Checked == true) {
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
            if (cbUploadCS4.Checked == true) {
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


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    upload a file using FTP
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int uploadFile(string[] args) {

            // assign args to make it clear
            string userID = args[0];
            string password = args[1];
            string hostURL = args[2];
            string fileName = args[3];
            string directory = args[4];

            FileInfo fi = new FileInfo(args[3]);  //  get filename
            if (fi.Length == 0)  //  if file has a length of zero, return
                return 0;

            FTPClient ftp = new FTPClient();
            ftp.RemoteHost = hostURL;

            string[] shortFilename2 = fileName.Split('\\');

            //+++++++++++++++++++++++++++++++++++++
            //return 0;  //  TESTING ONLY!
            //+++++++++++++++++++++++++++++++++++++

            try {
                //  connect
                ftp.Connect();
                if (ftp.IsConnected == true) {
                    ftp.Login(userID, password);  // login

                    // set up passive ASCII transfers
                    //log.Debug("Setting up passive, ASCII transfers and TransferBufferSize"); 
                    ftp.ConnectMode = FTPConnectMode.PASV;
                    ftp.TransferType = FTPTransferType.ASCII;
                    ftp.TransferBufferSize = 2048;

                    //  change directory if necessary
                    if (directory != null && directory.Length > 0)
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
                MessageBox.Show("File transfer error: " + e.Message, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return 0;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  uploadFileUsingFTPS (AlexPilotti.FTPS.Client.FTPSCLient)
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int uploadFileUsingFTPS(string[] args) {

            // assign args to make it clear
            string userID = args[0];
            string password = args[1];
            string hostURL = args[2];
            string fileName = args[3];
            string directory = args[4];

            FileInfo fi = new FileInfo(args[3]);  //  get filename
            if (fi.Length == 0)  //  if file has a length of zero, return
                return -1;

            try {

                FTPSClient ftpsClient = new FTPSClient();

                ftpsClient.Connect(hostURL, new NetworkCredential(userID, password),
                    ESSLSupportMode.CredentialsRequired | ESSLSupportMode.DataChannelRequested);
                ftpsClient.SetTransferMode(ETransferMode.ASCII);
                ftpsClient.SetCurrentDirectory(directory);

                //  split the filename to get only actual file name
                string[] shortFilename = fileName.Split('\\');

                //  upload the file
                ftpsClient.PutFile(fileName, shortFilename[3]);
                ftpsClient.Close();
            }
            catch (Exception ex) {
                MessageBox.Show("FTPS error: " + ex.Message);
                return -1;
            }

            return 0;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--   upload file using SFTP (WinSCP)
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int sftpUpload(string[] args) {

            // assign args to make it clearer
            string userID = args[0];
            string password = args[1];
            string hostURL = args[2];
            string fileName = args[3];
            string directory = args[4];

            try {
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = args[2],
                    UserName = args[0],
                    Password = args[1],
                    PortNumber = 22,
                    SshHostKeyFingerprint = args[5]
                };

                using (Session session = new Session()) {

                    session.Open(sessionOptions);  //  connect

                    //TransferOptions transferOptions = new TransferOptions();  //  not used for sftp
                    //transferOptions.PreserveTimestamp = true;

                    TransferOperationResult transferResult;
                    transferResult = session.PutFiles(args[3], args[4], false, null);   //  upload files

                    transferResult.Check();   //  throw any errors

                }
                return 0;
            }
            catch (Exception ex) {
                if (!ex.Message.Contains("error occurred while setting the permissions")) {
                    MessageBox.Show("SFTP error: " + ex.Message);
                    return -1;
                }
                return 0;
            }

            //   // Run hidden WinSCP process
            //   Process winscp = new Process();
            ////   winscp.StartInfo.FileName = programFilesDirectoryName + @"\WinSCP\winscp.com";
            //   winscp.StartInfo.FileName = @"D:\Prager Software\WinSCP\winscp.exe";
            // //  winscp.StartInfo.Arguments = "/log=" + logname;
            //   winscp.StartInfo.UseShellExecute = false;
            //   winscp.StartInfo.RedirectStandardInput = true;
            //   winscp.StartInfo.RedirectStandardOutput = true;
            //   winscp.StartInfo.CreateNoWindow = true;
            //   winscp.Start();

            //   // Feed in the scripting commands
            //   winscp.StandardInput.WriteLine("option batch abort");
            //   winscp.StandardInput.WriteLine("option confirm off");
            //   winscp.StandardInput.WriteLine("open sftp://" + args[0] + ":" + args[1] +
            //       "@sftp.barnesandnoble.com:22 " +
            //       "-hostkey=\"ssh-dss 2048 da:48:4b:09:de:f2:a5:4e:1f:7e:63:b0:f9:b5:64:39\"");
            //   winscp.StandardInput.WriteLine(@"cd " + args[4]);
            //   winscp.StandardInput.WriteLine("put " + args[3]);
            //   winscp.StandardInput.Close();

            //   // Collect all output
            //   string output = winscp.StandardOutput.ReadToEnd();

            //   // Wait until WinSCP finishes
            //   winscp.WaitForExit();

            //   if (winscp.ExitCode != 0) {
            //       winscp.Close();
            //       return -1;
            //   }
            //   else {
            //       winscp.Close();
            //       return 0;
            //   }

            //   /// Parse and interpret the XML log
            //   /// (Note that in case of fatal failure the log file may not exist at all)
            //   XPathDocument log = new XPathDocument(logname);
            //   XmlNamespaceManager ns = new XmlNamespaceManager(new NameTable());
            //   ns.AddNamespace("w", "http://winscp.net/schema/session/1.0");
            //   XPathNavigator nav = log.CreateNavigator();

            //   /// Success (0) or error?
            //   if (winscp.ExitCode != 0)
            //   {
            //       Console.WriteLine("Error occured");

            //       /// See if there are any messages associated with the error
            //       foreach (XPathNavigator message in nav.Select("//w:message", ns))
            //       {
            //           Console.WriteLine(message.Value);
            //       }
            //   }
            //   else
            //   {
            //       // It can be worth looking for directory listing even in case of error as possibly only upload may fail
            //       XPathNodeIterator files = nav.Select("//w:file", ns);
            //       Console.WriteLine(string.Format("There are {0} files and subdirectories:", files.Count));
            //       foreach (XPathNavigator file in files)
            //       {
            //           Console.WriteLine(file.SelectSingleNode("w:filename/@value", ns).Value);
            //       }
            //   }

            //       return 0;
            //   }

        }
    }
}