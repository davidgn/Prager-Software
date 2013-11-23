//#define TRACE

#region Using directives

using System;
using System.Data;
using System.Diagnostics;
using System.Security.AccessControl;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Xml;
using FirebirdSql.Data.FirebirdClient;
using System.Collections.Generic;

#endregion



namespace Media_Inventory_Manager
{

    partial class mainForm : Form
    {
        #region string Definitions
        static string[] ffPrefix = { "", "", "", "" };

        internal static string AlibrisUID = "";
        internal static string AlibrisPwd = "";
        internal static string PapaMediaUID = "";
        internal static string PapaMediaPwd = "";
        internal static string ScribblemongerUID = "";
        internal static string ScribblemongerPwd = "";
        internal static string AmazonUID = "";
        internal static string AmazonPwd = "";
        internal static string HalfDotComUID = "";
        internal static string HalfDotComPwd = "";
        internal static string BandNUID = "";
        internal static string BandNPwd = "";
        internal static string ChrislandsUID = "";
        internal static string ChrislandsPwd = "";

        internal static string CSUID1 = "";
        internal static string CSPwd1 = "";
        internal static string CSURL1 = "";
        internal static string CSDir1 = "";
        internal static string CSFF1 = "";

        internal static string CSUID2 = "";
        internal static string CSPwd2 = "";
        internal static string CSURL2 = "";
        internal static string CSDir2 = "";
        internal static string CSFF2 = "";

        internal static string CSUID3 = "";
        internal static string CSPwd3 = "";
        internal static string CSURL3 = "";
        internal static string CSDir3 = "";
        internal static string CSFF3 = "";

        internal static string CSUID4 = "";
        internal static string CSPwd4 = "";
        internal static string CSURL4 = "";
        internal static string CSDir4 = "";
        internal static string CSFF4 = "";

        internal static string HalfDotComToken = "";
        internal static bool networkingFlag = false;
        #endregion

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  save options
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void saveOptions() {

            if (backupRestoreFlag == true || networkingFlag == true)  //  don't save network settings
                return;

            //  save options and canned text in XML file
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Prager";
            bool modified;

            if (!Directory.Exists(directory)) {  //  create it if it's missing
                DirectoryInfo directoryInfo = directoryInfo = Directory.CreateDirectory(directory);
                DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
                AccessRule rule = new FileSystemAccessRule(
                    "Users",
                    FileSystemRights.Write |
                    FileSystemRights.ReadAndExecute |
                    FileSystemRights.Modify,
                    InheritanceFlags.ContainerInherit |
                    InheritanceFlags.ObjectInherit,
                    PropagationFlags.InheritOnly,
                    AccessControlType.Allow);
                directorySecurity.ModifyAccessRule(AccessControlModification.Add, rule, out modified);
                directoryInfo.SetAccessControl(directorySecurity);
            }
            /*
             * This is much better
            FileStream fs = null;
            xmlFilename = System.AppDomain.CurrentDomain.BaseDirectory + @"\Prager\prager.MediaOptions.xml";  //  use the last one...
                            if (!File.Exists(xmlFilename))
                            {
                                 //  must be first time, so it doesn't exist; create it...
                             DirectoryInfo di = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Prager");
                             if (di.Exists)
                             {
                                 fs = File.Create(di.FullName + @"\prager.MediaOptions.xml");
                                 //xmlFilename = di.FullName + @"\prager.MediaOptions.xml";
            //fs.Close();
                             }
                            }
                        }

                        XmlTextWriter tw = null;
                        try
                        {
                            tw = new XmlTextWriter(fs, null);  //null represents the Encoding Type
                        }
                        finally
            {
               fs.Close();
               tw.Close();

            }
             * */
            //    string xmlFilename = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Prager\prager.MediaOptions.xml";
            string xmlFilename = directory + @"\prager.MediaOptions.xml";
            if (!File.Exists(xmlFilename))  {  //  if it's NOT in the new directory
                FileStream fs = null;
                xmlFilename = System.AppDomain.CurrentDomain.BaseDirectory + @"\Prager\prager.MediaOptions.xml";  //  use the last one...
                if (!File.Exists(xmlFilename)) {
                    //  must be first time, so it doesn't exist; create it...
                    DirectoryInfo di = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Prager");
                    if (di.Exists) {
                        fs = File.Create(di.FullName + @"\prager.MediaOptions.xml");
                        xmlFilename = fs.Name;    // di.FullName + @"\prager.MediaOptions.xml";
                        fs.Close();  //  try to release it...
                    }
                }
            }

            XmlTextWriter tw = null;
            try {
                tw = new XmlTextWriter(xmlFilename, null);  //null represents the Encoding Type
            }
            catch (Exception ex) {
                if (ex.Message.Contains("prager.MediaOptions.xml' is denied")) {
                    MessageBox.Show("You do not have write permission to the prager.MediaOptions.xml file.  Disable UAC or run this program as Administrator, otherwise your options will not be saved.", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            tw.Formatting = Formatting.Indented;  //for xml tags to be indented
            tw.WriteStartDocument();   //Indicates the starting of document (Required)

            //  canned text  <----------------- REMOVE later
            tw.WriteStartElement("Prager");
            tw.WriteStartElement("CannedText");

            tw.WriteAttributeString("tTextTitle1", tbCannedTitle1.Text);
            tw.WriteAttributeString("tCannedDesc1", tbCannedDesc1.Text);
            tw.WriteAttributeString("tTextTitle2", tbCannedTitle2.Text);
            tw.WriteAttributeString("tCannedDesc2", tbCannedDesc2.Text);
            tw.WriteAttributeString("tTextTitle3", tbCannedTitle3.Text);
            tw.WriteAttributeString("tCannedDesc3", tbCannedDesc3.Text);
            tw.WriteAttributeString("tTextTitle4", tbCannedTitle4.Text);
            tw.WriteAttributeString("tCannedDesc4", tbCannedDesc4.Text);
            tw.WriteAttributeString("tTextTitle5", tbCannedTitle5.Text);
            tw.WriteAttributeString("tCannedDesc5", tbCannedDesc5.Text);
            tw.WriteAttributeString("tTextTitle6", tbCannedTitle6.Text);
            tw.WriteAttributeString("tCannedDesc6", tbCannedDesc6.Text);
            tw.WriteAttributeString("tTextTitle7", tbCannedTitle7.Text);
            tw.WriteAttributeString("tCannedDesc7", tbCannedDesc7.Text);
            tw.WriteAttributeString("tTextTitle8", tbCannedTitle8.Text);
            tw.WriteAttributeString("tCannedDesc8", tbCannedDesc8.Text);
            tw.WriteAttributeString("tTextTitle9", tbCannedTitle9.Text);
            tw.WriteAttributeString("tCannedDesc9", tbCannedDesc9.Text);
            tw.WriteAttributeString("tTextTitle10", tbCannedTitle10.Text);
            tw.WriteAttributeString("tCannedDesc10", tbCannedDesc10.Text);
            tw.WriteAttributeString("tTextTitle11", tbCannedTitle11.Text);
            tw.WriteAttributeString("tCannedDesc11", tbCannedDesc11.Text);
            tw.WriteAttributeString("tTextTitle12", tbCannedTitle12.Text);
            tw.WriteAttributeString("tCannedDesc12", tbCannedDesc12.Text);
            tw.WriteAttributeString("tTextTitle13", tbCannedTitle13.Text);
            tw.WriteAttributeString("tCannedDesc13", tbCannedDesc13.Text);
            tw.WriteAttributeString("tTextTitle14", tbCannedTitle14.Text);
            tw.WriteAttributeString("tCannedDesc14", tbCannedDesc14.Text);
            tw.WriteAttributeString("tTextTitle15", tbCannedTitle15.Text);
            tw.WriteAttributeString("tCannedDesc15", tbCannedDesc15.Text);
            tw.WriteAttributeString("tTextTitle16", tbCannedTitle16.Text);
            tw.WriteAttributeString("tCannedDesc16", tbCannedDesc16.Text);
            tw.WriteAttributeString("tTextTitle17", tbCannedTitle17.Text);
            tw.WriteAttributeString("tCannedDesc17", tbCannedDesc17.Text);
            tw.WriteAttributeString("tTextTitle18", tbCannedTitle18.Text);
            tw.WriteAttributeString("tCannedDesc18", tbCannedDesc18.Text);
            tw.WriteEndElement();

            //  program options
            tw.WriteStartElement("ProgramOptions");
            tw.WriteAttributeString("oAutoPricing", cbAutoPricingLookup.Checked ? "true" : "false");
            tw.WriteAttributeString("oVerifyDeletes", cbVerifyDeletes.Checked ? "true" : "false");
            tw.WriteAttributeString("oBackupDB", cbBackupDB.Checked ? "true" : "false");
            
            tw.WriteAttributeString("oAutoSKU", cbAutomaticSKU.Checked ? "true" : "false");
            tw.WriteAttributeString("oStartingSKU", tbStartingSKU.Text);
            tw.WriteAttributeString("oSKUPrefix", tbSKUPrefix.Text);
            tw.WriteAttributeString("oSKUSuffix", tbSKUSuffix.Text);

            tw.WriteAttributeString("oWarnNoCat", cbWarnNoCatalog.Checked ? "true" : "false");
            tw.WriteAttributeString("oWarnNoLoc", cbWarnNoLocation.Checked ? "true" : "false");
            tw.WriteAttributeString("oGenCustNbr", cbAutoCustomerNbr.Checked ? "true" : "false");
            tw.WriteAttributeString("oGenInvNbr", cbAutoInvoiceNbr.Checked ? "true" : "false");
            tw.WriteAttributeString("oAutoFileRetn", cbAutoFileRetention.Checked ? "true" : "false");
            //tw.WriteAttributeString("oCapTitle", cbCapTitleAuthor.Checked ? "true" : "false");
            tw.WriteAttributeString("oToolTipsOff", cbToolTips.Checked ? "true" : "false");
            tw.WriteAttributeString("oStartPanelSearch", rbStartSearch.Checked ? "true" : "false");
            tw.WriteAttributeString("oCurrEnglish", rbGBPound.Checked ? "true" : "false");
            tw.WriteAttributeString("oCurrEuro", rbEUDollar.Checked ? "true" : "false");
            tw.WriteAttributeString("oCurrUS", rbCNDollar.Checked ? "true" : "false");
            tw.WriteAttributeString("oMoveAvgPrice", rbMoveAvgPrice.Checked ? "true" : "false");
            tw.WriteAttributeString("oMoveLowPrice", rbMoveLowPrice.Checked ? "true" : "false");
            tw.WriteAttributeString("oUseAWS", cbUseAWS.Checked ? "true" : "false");
            tw.WriteAttributeString("oNoDesc", cbAddDesc.Checked ? "true" : "false");
            tw.WriteAttributeString("oDontOverlay", cbDontOverlay.Checked ? "true" : "false");
            tw.WriteAttributeString("oCreateNewKey", rbCreateNewKey.Checked ? "true" : "false");

            //  save Amazon keys  <-----------------------------  remove when table is working  TODO
            //tw.WriteAttributeString("oAWSKey", tbAWSKey.Text);
            //tw.WriteAttributeString("oAWSSecretKey", tbAWSSecretKey.Text);
            //tw.WriteAttributeString("oAZAssocTag", tbAZAssocTag.Text);
            //tw.WriteAttributeString("oMerchantID", tbMerchantID.Text);
            //tw.WriteAttributeString("oMarketplaceID", tbMarketplaceID.Text);

            tw.WriteAttributeString("oHalfDotComToken", tbHalfToken.Text);

            tw.WriteAttributeString("oSortOverride", cbSortOverride.Checked ? "true" : "false");
            tw.WriteAttributeString("oSortAsc", rbSortAsc.Checked ? "true" : "false");
            tw.WriteAttributeString("oSortDsc", rbSortDsc.Checked ? "true" : "false");
            tw.WriteAttributeString("oAllowAddUpdate", cbAllowAddUpdate.Checked ? "true" : "false");  //  added 11.7
            tw.WriteAttributeString("oUseReceipt", cbUseReceipt.Checked ? "true" : "false");
            tw.WriteEndElement();

            // tab sequences...
            tw.WriteStartElement("tabSettings");
            tw.WriteAttributeString("oUPCSeq", tbUPC.TabIndex.ToString());
            tw.WriteAttributeString("oQtySeq", tbQty.TabIndex.ToString());
            tw.WriteAttributeString("oLocSeq", tbLocn.TabIndex.ToString());
            tw.WriteAttributeString("oSKUSeq", tbSKU.TabIndex.ToString());
            tw.WriteAttributeString("oCostSeq", tbCost.TabIndex.ToString());
            tw.WriteAttributeString("oPriceSeq", tbPrice.TabIndex.ToString());
            tw.WriteAttributeString("oRePriceSeq", cbDoNotReprice.TabIndex.ToString());
            tw.WriteAttributeString("oTitleSeq", tbTitle.TabIndex.ToString());
            tw.WriteAttributeString("oASignedSeq", tbImageURL.TabIndex.ToString());
            tw.WriteAttributeString("oPubSeq", tbMusicLabel.TabIndex.ToString());
            tw.WriteAttributeString("oYearSeq", tbMusicYear.TabIndex.ToString());
            tw.WriteAttributeString("oDescSeq", tbItemNote.TabIndex.ToString());
            tw.WriteAttributeString("oCannedSeq", lbCannedText.TabIndex.ToString());
            tw.WriteAttributeString("oCondSeq", cbCondition.TabIndex.ToString());
            tw.WriteAttributeString("oJacketSeq", coMediaType.TabIndex.ToString());
            tw.WriteAttributeString("oNbrOfDisks", tbNbrOfDisks.TabIndex.ToString());
            tw.WriteAttributeString("oTypeSeq", coLanguage.TabIndex.ToString());
            tw.WriteEndElement();

            //  upload selections...
            tw.WriteStartElement("UploadSelections");
            tw.WriteAttributeString("uAmazon", cbUploadAmazon.Checked && AmazonUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uAmazonUK", cbUploadAmazonUK.Checked && AmazonUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uAlibris", cbUploadAlibris.Checked && AlibrisUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uBandN", cbUploadBandN.Checked && BandNUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uPapaMedia", cbUploadPapaMedia.Checked && PapaMediaUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uScribblemonger", cbUploadScribblemonger.Checked && ScribblemongerUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uHalfDotCom", cbUploadHalfDotCom.Checked ? "true" : "false");
            tw.WriteAttributeString("uChrislands", cbUploadChrislands.Checked && ChrislandsUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uCS1", cbUploadCS1.Checked ? "true" : "false");
            tw.WriteAttributeString("uCS2", cbUploadCS2.Checked ? "true" : "false");
            tw.WriteAttributeString("uCS3", cbUploadCS3.Checked ? "true" : "false");
            tw.WriteAttributeString("uCS4", cbUploadCS4.Checked ? "true" : "false");
            tw.WriteEndElement();

            //  repricing selections...
            tw.WriteStartElement("RepricingSelections");
            tw.WriteAttributeString("highByAmt", tbHighByAmt.Text);
            tw.WriteAttributeString("whatPriceH", lbWhatPriceH.SelectedIndex.ToString());
            tw.WriteAttributeString("lowByAmt", tbLowByAmt.Text);
            tw.WriteAttributeString("whatPriceL", lbWhatPriceL.SelectedIndex.ToString());
            tw.WriteAttributeString("newByAmt", tbNewByAmt.Text);
            tw.WriteAttributeString("newWhatPrice", lbNewWhatPrice.SelectedIndex.ToString());
            tw.WriteAttributeString("condAmtVG", tbCondAmtVG.Text);
            tw.WriteAttributeString("condAmtG", tbCondAmtG.Text);
            tw.WriteAttributeString("condAmtP", tbCondAmtP.Text);
            tw.WriteAttributeString("belowMyCostOr", tbBelowMyCostOr.Text);
            tw.WriteAttributeString("discardBelowAmt", tbDiscardBelowAmt.Text);
            tw.WriteAttributeString("discardAboveAmt", tbDiscardAboveAmt.Text);
            tw.WriteAttributeString("priceLowPct", rbPriceLowPct.Checked ? "true" : "false");
            tw.WriteAttributeString("greaterSugg", cbGreaterSugg.Checked ? "true" : "false");
            tw.WriteAttributeString("lessSugg", cbLessSugg.Checked ? "true" : "false");
            //tw.WriteAttributeString("useAmazon", cbAmazonPrice.Checked == true ? "true" : "false"); 
            tw.WriteAttributeString("highBelow", rbHighBelow.Checked ? "true" : "false");
            tw.WriteAttributeString("priceHighPct", rbPriceHighPct.Checked ? "true" : "false");
            //tw.WriteAttributeString("repriceWithgUPCs", rbRepriceWithUPCs.Checked == true ? "true" : "false");
            tw.WriteAttributeString("lowBelow", rbLowBelow.Checked ? "true" : "false");
            tw.WriteAttributeString("dontGoBelowCost", cbDontGoBelowCost.Checked ? "true" : "false");
            tw.WriteAttributeString("priceNewPct", rbPriceNewPct.Checked ? "true" : "false");
            tw.WriteEndElement();


            ////  now do the book conditions
            //tw.WriteStartElement("BookConditions");
            //tw.WriteAttributeString("Amazon", rbUseAmazonCond.Checked == true ? "true" : "false");
            //tw.WriteAttributeString("Generic", rbUseGenericCond.Checked == true ? "true" : "false");
            //tw.WriteAttributeString("Custom", rbUseCustomCond.Checked == true ? "true" : "false");

            //if (rbUseCustomCond.Checked) {
            //    tw.WriteAttributeString("CustomCount", coCondition.Items.Count.ToString());
            //    for (int i = 0; i < coCondition.Items.Count; i++) {
            //        tw.WriteAttributeString("item" + i.ToString(), coCondition.Items[i].ToString());
            //    }
            //}
            //tw.WriteEndElement();


            /*
            //  now save positions of tabs
            tw.WriteStartElement("TabSequence");
            tw.WriteAttributeString("cPricingResults", tabTaskPanel.TabPages.IndexOf(pricingResultsTab).ToString());
            tw.WriteAttributeString("cExport", tabTaskPanel.TabPages.IndexOf(ExportTab).ToString());
            tw.WriteAttributeString("cUpload", tabTaskPanel.TabPages.IndexOf(uploadTab).ToString());
            tw.WriteAttributeString("cAccounting", tabTaskPanel.TabPages.IndexOf(accountingTab).ToString());
            tw.WriteAttributeString("cRepricing", tabTaskPanel.TabPages.IndexOf(RePricingTool).ToString());
            tw.WriteAttributeString("cASIN", tabTaskPanel.TabPages.IndexOf(getASIN).ToString());
            tw.WriteAttributeString("cProgramOptions", tabTaskPanel.TabPages.IndexOf(optionsTab).ToString());
            tw.WriteAttributeString("cCustomerInfo", tabTaskPanel.TabPages.IndexOf(customerInfoTab).ToString());
            tw.WriteAttributeString("cInvoice", tabTaskPanel.TabPages.IndexOf(invoiceTab).ToString());
            tw.WriteAttributeString("cBookDetail", tabTaskPanel.TabPages.IndexOf(bookDetailTab).ToString());
            tw.WriteAttributeString("cSearch", tabTaskPanel.TabPages.IndexOf(searchTab).ToString());
            tw.WriteAttributeString("cTabMapping", tabTaskPanel.TabPages.IndexOf(mappingTab).ToString());
            tw.WriteAttributeString("cImport", tabTaskPanel.TabPages.IndexOf(Import).ToString());
            tw.WriteAttributeString("cWebPages", tabTaskPanel.TabPages.IndexOf(webSites).ToString());
            tw.WriteAttributeString("cMassChanges", tabTaskPanel.TabPages.IndexOf(alterPricesTab).ToString());
            tw.WriteAttributeString("cCatalogs", tabTaskPanel.TabPages.IndexOf(catalogTab).ToString());
            tw.WriteAttributeString("cCannedText", tabTaskPanel.TabPages.IndexOf(cannedTextTab).ToString());
            tw.WriteAttributeString("cUIDPswd", tabTaskPanel.TabPages.IndexOf(UIDandPswdMaintenance).ToString());
            tw.WriteAttributeString("cReports", tabTaskPanel.TabPages.IndexOf(Reports).ToString());
            tw.WriteAttributeString("cStatus", tabTaskPanel.TabPages.IndexOf(StatusTab).ToString());
            tw.WriteEndElement();
*/

            //  now do the miscellaneous stuff 
            tw.WriteStartElement("Miscellaneous");
            tw.WriteAttributeString("mPictureFilename", pictureFileName);
            tw.WriteAttributeString("mBusinessAddress", tbBusinessAddr.Text);
            tw.WriteAttributeString("mReceiptWidth", tbWidth.Text);
            tw.WriteAttributeString("mStoreName", tbStoreName.Text);
            tw.WriteEndElement();

            //  now do the custom site names  
            tw.WriteStartElement("CustomSites");
            tw.WriteAttributeString("customSite1", tbCustomSite1.Text);
            tw.WriteAttributeString("customSite2", tbCustomSite2.Text);
            tw.WriteAttributeString("customSite3", tbCustomSite3.Text);
            tw.WriteAttributeString("customSite4", tbCustomSite4.Text);
            tw.WriteEndElement();

            tw.WriteEndElement();  // </Prager>
            tw.WriteEndDocument();
            tw.Flush();
            tw.Close();

            //  save last export date
            if (!lastExport.ToString().Contains("01/01/0001") && !lastExport.ToString().Contains("1/1/0001"))
                dateTimePicker1.Value = lastExport;  //  set to date last exported
            else {
                dateTimePicker1.Value = installedDate;  //  just so we have something
                lastExport = installedDate;
            }

            //  save the Amazon keys to tAZUID table
            string updateString = "UPDATE tAZUID SET MWSMerchantID = '" + tbMerchantID.Text + "', " +
            " MWSMarketplaceID = '" + tbMarketplaceID.Text + "', " +
            " AWSAccessKey = '" + tbAWSKey.Text + "', " +
            " AWSSecretKey = '" + tbAWSSecretKey.Text + "', " +
            " AWSAssocTag = '" + tbAZAssocTag.Text + "' ROWS 1";
            sqlCmd = new FbCommand(updateString, mediaConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                MessageBox.Show("Error adding Amazon IDs: " + e.Message, "Prager, Media Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //  save options in tOptions table  <---------- save in prager.ini file  TODO
            string updateCmd = "UPDATE tOptions SET " +
                "tDateLastExported = '" + lastExport.ToString("yyyy-MM-dd HH:mm:ss", localCulture) +
                "', tBackupToPath = '" + backupPath +
                "', tBackupRetention = '" + daysRetention + "' ROWS 1";
            FbCommand updtCmd = new FbCommand(updateCmd, mediaConn);
            //updtCmd.Connection = new FbConnection("User=prager;Password=media;Database=" + dbPath);
            try {
                if (mediaConn.State == ConnectionState.Closed)
                    mediaConn.Open();
                updtCmd.ExecuteNonQuery();

            }
            catch (FbException ex) {
                MessageBox.Show("410 - error saving Options: \n" + ex.Message + "\n" + ex.StackTrace, "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbStatus.Items.Insert(0, "-->error saving Options");
                lbStatus.Refresh();
            }

            lbStatus.Items.Insert(0, "Options saved");
            lbStatus.Refresh();
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  restore options
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void restoreOptions() {
            Cursor.Current = Cursors.WaitCursor;
            string xmlFilename = "";

            //   int i = 0;  //  index to control the insertion of canned text
            lbCannedText.Items.Clear();

            //  if programOptionsPath is NOT null, then user IS networking
            if (programOptionsPath != null) //  user wants to network program options...
            {
                string optionsPath = programOptionsPath + @"\prager.MediaOptions.xml";
                if (File.Exists(optionsPath)) {
                    xmlFilename = optionsPath;
                    networkingFlag = true;
                }
            }
            else {
                //  either didn't find options, or doesn't want to network them...
                networkingFlag = false;
                xmlFilename = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
                              @"\Prager\prager.MediaOptions.xml";
                if (!File.Exists(xmlFilename)) //  if it doesn't exist, look-see if it's in the new directory?
                {
                    xmlFilename = System.AppDomain.CurrentDomain.BaseDirectory;
                    if (xmlFilename.Contains(@"bin\Debug"))
                        xmlFilename += @"\prager.MediaOptions.xml";
                    else
                        xmlFilename += @"\Prager\prager.MediaOptions.xml";

                    if (!File.Exists(xmlFilename))
                        xmlFilename = ""; //  must be first time, so it doesn't exist... 
                }
            }

            fTrace("I - prager.MediaOptions.xml file path: " + xmlFilename);

            if (File.Exists(xmlFilename)) {
                using (XmlReader tr = XmlReader.Create(xmlFilename)) {
                    try {
                        while (tr.Read()) // If the node has value 
                        {
                            if (tr.IsStartElement("CannedText")) {
                                if (flagCannedText == true) {
                                    //  if the dgv has values, move titles to media page
                                    ; //  <----------------------------  TODO
                                }
                                else {
                                    if (tr.GetAttribute("tTextTitle1").Contains("Repl w/ title") == false) {
                                        tbCannedTitle1.Text = tr.GetAttribute("tTextTitle1");
                                        tbCannedDesc1.Text = tr.GetAttribute("tCannedDesc1");
                                        lbCannedText.Items.Add(tbCannedTitle1.Text);
                                    }
                                    if (tr.GetAttribute("tTextTitle2").Contains("Repl w/ title") == false) {
                                        tbCannedTitle2.Text = tr.GetAttribute("tTextTitle2");
                                        tbCannedDesc2.Text = tr.GetAttribute("tCannedDesc2");
                                        lbCannedText.Items.Add(tbCannedTitle2.Text);
                                    }
                                    if (tr.GetAttribute("tTextTitle3").Contains("Repl w/ title") == false) {
                                        tbCannedTitle3.Text = tr.GetAttribute("tTextTitle3");
                                        tbCannedDesc3.Text = tr.GetAttribute("tCannedDesc3");
                                        lbCannedText.Items.Add(tbCannedTitle3.Text);
                                    }
                                    if (tr.GetAttribute("tTextTitle4").Contains("Repl w/ title") == false) {
                                        tbCannedTitle4.Text = tr.GetAttribute("tTextTitle4");
                                        tbCannedDesc4.Text = tr.GetAttribute("tCannedDesc4");
                                        lbCannedText.Items.Add(tbCannedTitle4.Text);
                                    }
                                    if (tr.GetAttribute("tTextTitle5").Contains("Repl w/ title") == false) {
                                        tbCannedTitle5.Text = tr.GetAttribute("tTextTitle5");
                                        tbCannedDesc5.Text = tr.GetAttribute("tCannedDesc5");
                                        lbCannedText.Items.Add(tbCannedTitle5.Text);
                                    }
                                    if (tr.GetAttribute("tTextTitle6").Contains("Repl w/ title") == false) {
                                        tbCannedTitle6.Text = tr.GetAttribute("tTextTitle6");
                                        tbCannedDesc6.Text = tr.GetAttribute("tCannedDesc6");
                                        lbCannedText.Items.Add(tbCannedTitle6.Text);
                                    }
                                    if (tr.GetAttribute("tTextTitle7").Contains("Repl w/ title") == false) {
                                        tbCannedTitle7.Text = tr.GetAttribute("tTextTitle7");
                                        tbCannedDesc7.Text = tr.GetAttribute("tCannedDesc7");
                                        lbCannedText.Items.Add(tbCannedTitle7.Text);
                                    }
                                    if (tr.GetAttribute("tTextTitle8").Contains("Repl w/ title") == false) {
                                        tbCannedTitle8.Text = tr.GetAttribute("tTextTitle8");
                                        tbCannedDesc8.Text = tr.GetAttribute("tCannedDesc8");
                                        lbCannedText.Items.Add(tbCannedTitle8.Text);
                                    }
                                    if (tr.GetAttribute("tTextTitle9").Contains("Repl w/ title") == false) {
                                        tbCannedTitle9.Text = tr.GetAttribute("tTextTitle9");
                                        tbCannedDesc9.Text = tr.GetAttribute("tCannedDesc9");
                                        lbCannedText.Items.Add(tbCannedTitle9.Text);
                                    }
                                    if (tr.GetAttribute("tTextTitle10").Contains("Repl w/ title") == false) {
                                        tbCannedTitle10.Text = tr.GetAttribute("tTextTitle10");
                                        tbCannedDesc10.Text = tr.GetAttribute("tCannedDesc10");
                                        lbCannedText.Items.Add(tbCannedTitle10.Text);
                                    }
                                    if (tr.GetAttribute("tTextTitle11") != null)
                                    //  if we haven't saved anything past 10...
                                    {
                                        if (tr.GetAttribute("tTextTitle11").Contains("Repl w/ title") == false) {
                                            tbCannedTitle11.Text = tr.GetAttribute("tTextTitle11");
                                            tbCannedDesc11.Text = tr.GetAttribute("tCannedDesc11");
                                            lbCannedText.Items.Add(tbCannedTitle11.Text);
                                        }
                                        if (tr.GetAttribute("tTextTitle12").Contains("Repl w/ title") == false) {
                                            tbCannedTitle12.Text = tr.GetAttribute("tTextTitle12");
                                            tbCannedDesc12.Text = tr.GetAttribute("tCannedDesc12");
                                            lbCannedText.Items.Add(tbCannedTitle12.Text);
                                        }
                                        if (tr.GetAttribute("tTextTitle13").Contains("Repl w/ title") == false) {
                                            tbCannedTitle13.Text = tr.GetAttribute("tTextTitle13");
                                            tbCannedDesc13.Text = tr.GetAttribute("tCannedDesc13");
                                            lbCannedText.Items.Add(tbCannedTitle13.Text);
                                        }
                                        if (tr.GetAttribute("tTextTitle14").Contains("Repl w/ title") == false) {
                                            tbCannedTitle14.Text = tr.GetAttribute("tTextTitle14");
                                            tbCannedDesc14.Text = tr.GetAttribute("tCannedDesc14");
                                            lbCannedText.Items.Add(tbCannedTitle14.Text);
                                        }
                                        if (tr.GetAttribute("tTextTitle15").Contains("Repl w/ title") == false) {
                                            tbCannedTitle15.Text = tr.GetAttribute("tTextTitle15");
                                            tbCannedDesc15.Text = tr.GetAttribute("tCannedDesc15");
                                            lbCannedText.Items.Add(tbCannedTitle15.Text);
                                        }
                                        if (tr.GetAttribute("tTextTitle16").Contains("Repl w/ title") == false) {
                                            tbCannedTitle16.Text = tr.GetAttribute("tTextTitle16");
                                            tbCannedDesc16.Text = tr.GetAttribute("tCannedDesc16");
                                            lbCannedText.Items.Add(tbCannedTitle16.Text);
                                        }
                                        if (tr.GetAttribute("tTextTitle17").Contains("Repl w/ title") == false) {
                                            tbCannedTitle17.Text = tr.GetAttribute("tTextTitle17");
                                            tbCannedDesc17.Text = tr.GetAttribute("tCannedDesc17");
                                            lbCannedText.Items.Add(tbCannedTitle17.Text);
                                        }
                                        if (tr.GetAttribute("tTextTitle18").Contains("Repl w/ title") == false) {
                                            tbCannedTitle18.Text = tr.GetAttribute("tTextTitle18");
                                            tbCannedDesc18.Text = tr.GetAttribute("tCannedDesc18");
                                            lbCannedText.Items.Add(tbCannedTitle18.Text);
                                        }
                                    }
                                }
                            }

                            //  program options...
                            if (tr.IsStartElement("ProgramOptions")) {
                                
                                if (tr.GetAttribute("oStartPanelSearch") == "true")
                                    rbStartSearch.Checked = true;
                                else
                                    rbStartDetail.Checked = true;

                                cbAutoPricingLookup.Checked = tr.GetAttribute("oAutoPricing") == "true";
                                cbVerifyDeletes.Checked = tr.GetAttribute("oVerifyDeletes") == "true";
                                cbBackupDB.Checked = tr.GetAttribute("oBackupDB") == "true";
                                cbWarnNoCatalog.Checked = tr.GetAttribute("oWarnNoCat") == "true";
                                
                                //  deal with SKU options
                                cbAutomaticSKU.Checked = tr.GetAttribute("oAutoSKU") == "true";
                                if (tr.GetAttribute("oStartingSKU").Length > 0)
                                    tbStartingSKU.Text = tr.GetAttribute("oStartingSKU");
                                if (tr.GetAttribute("oSKUPrefix").Length > 0)
                                    tbSKUPrefix.Text = tr.GetAttribute("oSKUPrefix");
                                if (tr.GetAttribute("oSKUSuffix").Length > 0)
                                    tbSKUSuffix.Text = tr.GetAttribute("oSKUSuffix");

                                cbWarnNoLocation.Checked = tr.GetAttribute("oWarnNoLoc") == "true";
                                cbAutoCustomerNbr.Checked = tr.GetAttribute("oGenCustNbr") == "true";
                                cbAutoInvoiceNbr.Checked = tr.GetAttribute("oGenInvNbr") == "true";
                                cbAutoFileRetention.Checked = tr.GetAttribute("oAutoFileRetn") == "true";
                                cbToolTips.Checked = tr.GetAttribute("oToolTipsOff") == "true";
                                cbAllowAddUpdate.Checked = tr.GetAttribute("oAllowAddUpdate") == "true";
                                rbGBPound.Checked = tr.GetAttribute("oCurrEnglish") == "true";
                                rbEUDollar.Checked = tr.GetAttribute("oCurrEuro") == "true";
                                rbCNDollar.Checked = tr.GetAttribute("oCurrCanadian") == "true";
                                cbUseAWS.Checked = tr.GetAttribute("oUseAWS") == "true";
                                rbMoveAvgPrice.Checked = tr.GetAttribute("oMoveAvgPrice") == "true";
                                rbMoveLowPrice.Checked = tr.GetAttribute("oMoveLowPrice") == "true";
                                cbAddDesc.Checked = tr.GetAttribute("oNoDesc") == "true";
                                cbSortOverride.Checked = tr.GetAttribute("oSortOverride") == "true";
                                rbSortAsc.Checked = tr.GetAttribute("oSortAsc") == "true";
                                rbSortDsc.Checked = tr.GetAttribute("oSortDsc") == "true";
                                cbUseReceipt.Checked = tr.GetAttribute("oUseReceipt") == "true";
                                cbDontOverlay.Checked = tr.GetAttribute("oDontOverlay") == "true";
                                rbCreateNewKey.Checked = tr.GetAttribute("oCreateNewKey") == "true";

                                //  restore Amazon keys  <-------------------------   remove after first set  TODO
                                //if (tr.GetAttribute("oAWSKey").Length > 0)
                                //    tbAWSKey.Text = tr.GetAttribute("oAWSKey");

                                //if (tr.GetAttribute("oAWSSecretKey").Length > 0)
                                //    tbAWSSecretKey.Text = tr.GetAttribute("oAWSSecretKey");

                                //if (tr.GetAttribute("oAZAssocTag").Length > 0)
                                //    tbAZAssocTag.Text = tr.GetAttribute("oAZAssocTag");

                                //if (tr.GetAttribute("oMerchantID").Length > 0)
                                //    tbMerchantID.Text = tr.GetAttribute("oMerchantID");

                                //if (tr.GetAttribute("oMarketplaceID").Length > 0)
                                //    tbMarketplaceID.Text = tr.GetAttribute("oMarketplaceID");

                                if (tr.GetAttribute("oHalfDotComToken").Length > 0)
                                    tbHalfToken.Text = tr.GetAttribute("oHalfDotComToken");
                            }

                            //  set tab sequence settings on Media Detail page 
                            if (tr.IsStartElement("tabSettings")) {
                                if (tr.GetAttribute("oUPCSeq").Length > 0)
                                    tbUPC.TabIndex = Convert.ToInt32(tr.GetAttribute("oUPCSeq"));
                                if (tr.GetAttribute("oQtySeq").Length > 0)
                                    tbQty.TabIndex = Convert.ToInt32(tr.GetAttribute("oQtySeq"));
                                if (tr.GetAttribute("oLocSeq").Length > 0)
                                    tbLocn.TabIndex = Convert.ToInt32(tr.GetAttribute("oLocSeq"));
                                if (tr.GetAttribute("oSKUSeq").Length > 0)
                                    tbSKU.TabIndex = Convert.ToInt32(tr.GetAttribute("oSKUSeq"));
                                if (tr.GetAttribute("oCostSeq").Length > 0)
                                    tbCost.TabIndex = Convert.ToInt32(tr.GetAttribute("oCostSeq"));
                                if (tr.GetAttribute("oPriceSeq").Length > 0)
                                    tbPrice.TabIndex = Convert.ToInt32(tr.GetAttribute("oPriceSeq"));
                                if (tr.GetAttribute("oRePriceSeq").Length > 0)
                                    cbDoNotReprice.TabIndex = Convert.ToInt32(tr.GetAttribute("oRePriceSeq"));
                                if (tr.GetAttribute("oTitleSeq").Length > 0)
                                    if (tr.GetAttribute("oASignedSeq").Length > 0)
                                        tbImageURL.TabIndex = Convert.ToInt32(tr.GetAttribute("oASignedSeq"));
                                if (tr.GetAttribute("oPubSeq").Length > 0)
                                    tbMusicLabel.TabIndex = Convert.ToInt32(tr.GetAttribute("oPubSeq"));
                                if (tr.GetAttribute("oYearSeq").Length > 0)
                                    tbMusicYear.TabIndex = Convert.ToInt32(tr.GetAttribute("oYearSeq"));
                                if (tr.GetAttribute("oDescSeq").Length > 0)
                                    tbItemNote.TabIndex = Convert.ToInt32(tr.GetAttribute("oDescSeq"));
                                if (tr.GetAttribute("oCannedSeq").Length > 0)
                                    lbCannedText.TabIndex = Convert.ToInt32(tr.GetAttribute("oCannedSeq"));
                                if (tr.GetAttribute("oCondSeq").Length > 0)
                                    cbCondition.TabIndex = Convert.ToInt32(tr.GetAttribute("oCondSeq"));
                                if (tr.GetAttribute("oJacketSeq").Length > 0)
                                    coMediaType.TabIndex = Convert.ToInt32(tr.GetAttribute("oJacketSeq"));
                                if (tr.GetAttribute("oNbrOfDisks").Length > 0)
                                    tbNbrOfDisks.TabIndex = Convert.ToInt32(tr.GetAttribute("oNbrOfDisks"));
                                if (tr.GetAttribute("oTypeSeq").Length > 0)
                                    coLanguage.TabIndex = Convert.ToInt32(tr.GetAttribute("oTypeSeq"));
                            }

                            //  upload selections...
                            if (tr.IsStartElement("UploadSelections")) {
                                if (tr.GetAttribute("uAmazon") == "true" && tbMarketplaceID.Text.Length > 0 &&
                                    tbMerchantID.Text.Length > 0)
                                    cbUploadAmazon.Checked = true;
                                else
                                    cbUploadAmazon.Checked = false;

                                if (tr.GetAttribute("uAmazonUK") == "true" && tbAWSKey.Text.Length > 0 &&
                                    tbAWSSecretKey.Text.Length > 0)
                                    cbUploadAmazonUK.Checked = true;
                                else
                                    cbUploadAmazonUK.Checked = false;

                                if (tr.GetAttribute("uAlibris") == "true" && AlibrisUID.Length > 0)
                                    cbUploadAlibris.Checked = true;
                                else
                                    cbUploadAlibris.Checked = false;

                                if (tr.GetAttribute("uBandN") == "true" && BandNUID.Length > 0)
                                    cbUploadBandN.Checked = true;
                                else
                                    cbUploadBandN.Checked = false;
                                if (tr.GetAttribute("uPapaMedia") == "true" && PapaMediaUID.Length > 0)
                                    cbUploadPapaMedia.Checked = true;
                                else
                                    cbUploadPapaMedia.Checked = false;

                                if (tr.GetAttribute("uScribblemonger") == "true" && ScribblemongerUID.Length > 0)
                                    cbUploadScribblemonger.Checked = true;
                                else
                                    cbUploadScribblemonger.Checked = false;

                                if (tr.GetAttribute("uHalfDotCom") == "true" && HalfDotComUID.Length > 0)
                                    cbUploadHalfDotCom.Checked = true;
                                else
                                    cbUploadHalfDotCom.Checked = false;

                                if (tr.GetAttribute("uChrislands") == "true" && ChrislandsUID.Length > 0)
                                    cbUploadChrislands.Checked = true;
                                else
                                    cbUploadChrislands.Checked = false;

                                if (tr.GetAttribute("uCS1") == "true" && CSUID1.Length > 0)
                                    cbUploadCS1.Checked = true;
                                else
                                    cbUploadCS1.Checked = false;

                                if (tr.GetAttribute("uCS2") == "true" && CSUID2.Length > 0)
                                    cbUploadCS2.Checked = true;
                                else
                                    cbUploadCS2.Checked = false;

                                if (tr.GetAttribute("uCS3") == "true" && CSUID3.Length > 0)
                                    cbUploadCS3.Checked = true;
                                else
                                    cbUploadCS3.Checked = false;

                                if (tr.GetAttribute("uCS4") == "true" && CSUID4.Length > 0)
                                    cbUploadCS4.Checked = true;
                                else
                                    cbUploadCS4.Checked = false;
                            }

                            //  repricing selections...
                            if (tr.IsStartElement("RepricingSelections")) {
                                tbHighByAmt.Text = tr.GetAttribute("highByAmt");
                                lbWhatPriceH.SelectedIndex = int.Parse(tr.GetAttribute("whatPriceH"));
                                tbLowByAmt.Text = tr.GetAttribute("lowByAmt");
                                lbWhatPriceL.SelectedIndex = int.Parse(tr.GetAttribute("whatPriceL"));
                                tbNewByAmt.Text = tr.GetAttribute("newByAmt");
                                lbNewWhatPrice.SelectedIndex = int.Parse(tr.GetAttribute("newWhatPrice"));
                                tbCondAmtVG.Text = tr.GetAttribute("condAmtVG");
                                tbCondAmtG.Text = tr.GetAttribute("condAmtG");
                                tbCondAmtP.Text = tr.GetAttribute("condAmtP");
                                tbBelowMyCostOr.Text = tr.GetAttribute("belowMyCostOr");
                                tbDiscardBelowAmt.Text = tr.GetAttribute("discardBelowAmt");
                                tbDiscardAboveAmt.Text = tr.GetAttribute("discardAboveAmt");
                                rbPriceLowPct.Checked = tr.GetAttribute("priceLowPct") == "true";
                                cbGreaterSugg.Checked = tr.GetAttribute("greaterSugg") == "true";
                                cbLessSugg.Checked = tr.GetAttribute("lessSugg") == "true";
                                rbHighBelow.Checked = tr.GetAttribute("highBelow") == "true";
                                rbPriceHighPct.Checked = tr.GetAttribute("priceHighPct") == "true";
                                rbLowBelow.Checked = tr.GetAttribute("lowBelow") == "true";
                                cbDontGoBelowCost.Checked = tr.GetAttribute("dontGoBelowCost") == "true";
                                rbPriceNewPct.Checked = tr.GetAttribute("priceNewPct") == "true";

                            }

                            //  now finish up with the Miscellaneous items
                            if (tr.IsStartElement("Miscellaneous")) {
                                if (tr.GetAttribute("mPictureFilename").Length > 0)
                                    pictureFileName = tr.GetAttribute("mPictureFilename");
                                if (tr.GetAttribute("mBusinessAddress").Length > 0)
                                    tbBusinessAddr.Text = tr.GetAttribute("mBusinessAddress");
                                if (tr.GetAttribute("mReceiptWidth") != null &&
                                    tr.GetAttribute("mReceiptWidth").Length > 0)
                                    tbWidth.Text = tr.GetAttribute("mReceiptWidth");
                                if (tr.GetAttribute("mStoreName") != null && tr.GetAttribute("mStoreName").Length > 0)
                                    tbStoreName.Text = tr.GetAttribute("mStoreName");
                            }

                            //  do the custom site names
                            if (tr.IsStartElement("CustomSites")) {
                                if (tr.GetAttribute("customSite1").Length > 0)
                                    tbCustomSite1.Text = tr.GetAttribute("customSite1");
                                if (tr.GetAttribute("customSite2").Length > 0)
                                    tbCustomSite2.Text = tr.GetAttribute("customSite2");
                                if (tr.GetAttribute("customSite3").Length > 0)
                                    tbCustomSite3.Text = tr.GetAttribute("customSite3");
                                if (tr.GetAttribute("customSite4").Length > 0)
                                    tbCustomSite4.Text = tr.GetAttribute("customSite4");
                            }
                        }
                    }
                    catch (Exception ex) {
                        if (ex.Message.Contains("Root element is missing"))
                            ; //  do nothing; first time, so nothing to restore
                    }

                    tr.Close();
                }
            }
            else {
                if (!installedDate.Equals(DateTime.Today) && xmlFilename != "") {
                    fTrace("E - unable to locate prager.MediaOptions.xml");
                    MessageBox.Show("Unable to locate prager.MediaOptions.xml file; please contact Support for help",
                                    "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                    fTrace("I - Installed today");
            }

            //  now get remainder of the stuff from tOptions...
            commandString = "select tDateLastExported, GUID from tOptions";

            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();
            FbDataReader dr = null;
            FbCommand cmd = new FbCommand(commandString, mediaConn);
            dr = cmd.ExecuteReader();

            while (dr.Read()) {
                if (!dr.IsDBNull(0)) {
                    //dateTimePicker1.Value = (DateTime)dr["tDateLastExported"];  //  set to date last exported
                    dateTimePicker1.Value = (DateTime)dr[0]; //  set to date last exported
                    lastExport = (DateTime)dr[0]; //  here too...
                    //storedGUID = (string)dr[1];  //  save guid for display on about page (11.4.1)
                }
            }

            //  now, move the Amazon keys to the textboxes
            const string selectString = "SELECT * from tAZUID";
            sqlCmd = new FbCommand(selectString, mediaConn);
            dr = sqlCmd.ExecuteReader();
            dr.Read(); //  read the only row
            //string x = dr[0].ToString();
            if (dr[2].ToString().Length != 0) {
                tbMerchantID.Text = dr[0].ToString();
                tbMarketplaceID.Text = dr[1].ToString();
                tbAWSKey.Text = dr[2].ToString();
                tbAWSSecretKey.Text = dr[3].ToString();
                tbAZAssocTag.Text = dr[4].ToString();
                dr.Close();
            }

            return;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  check installation date
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int checkInstallationDate() {
            DateTime todaysDate = DateTime.Now;
            string[] dateComponents = todaysDate.ToString(localCulture).Split(' ');

            if (lastExport.Equals(DateTime.MinValue))  //  if lastExport date is missing, make it today...
                lastExport = DateTime.Today.Subtract(TimeSpan.FromDays(1));

            //string insertString = "insert into tOptions (tInstallDate) values (current_date)";  //  <--------------- change in Book Inv pgm...  TO DO
            const string insertString = "insert into tOptions (tInstallDate) values ('11/2/2011')";
            commandString = "select tInstallDate from tOptions";

            FbDataReader rdr = null;

            try  //  initial open of Firebird database
            {
                if (mediaConn.State == ConnectionState.Closed)
                    mediaConn.Open();
            }
            catch (Exception ex) {
                if (ex.Message.Contains("unsupported on-disk structure for file"))
                    MessageBox.Show("You have a conflict in Firebird versions; please contact support@pragersoftware.com for assistance", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Firebird open error: " + ex.Message + "  please contact support@pragersoftware.com for assistance", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);

                fTrace("E - 1139: " + ex.Message.Substring(0, 50));
                return -1;
            }

            FbCommand cmd = new FbCommand(commandString, mediaConn);
            rdr = cmd.ExecuteReader();

            if (!rdr.Read() || rdr.IsDBNull(0)) {  //  if installDate is missing, then this is the first time...
                fTrace("I - installation date missing (first time)");
                cmd = new FbCommand(insertString);
                cmd.Connection = mediaConn;
                cmd.ExecuteNonQuery();  //  update installation date

                //  create the GUID and put it in the field
                System.Guid guid = System.Guid.NewGuid();  //  <----------------  use MAC instead?  TODO  <++++++++++++++
                string maintenanceString = "UPDATE tOptions SET GUID = '" + guid.ToString() + "' ROWS 1";
                sqlCmd = new FbCommand(maintenanceString, mediaConn);
                sqlCmd.ExecuteNonQuery();

                //  get guid for encryption/decryption...
                string selectString = "SELECT GUID FROM tOptions";  //  get the GUID
                FbCommand selCmd = new FbCommand(selectString, mediaConn);
                //try {
                FbDataReader dr2 = selCmd.ExecuteReader();
                if (dr2.Read()) {
                    if (dr2[0] != DBNull.Value)  //  if there exists an install date and no eDate...
                        storedGUID = dr2[0].ToString();
                }
                dr2.Close();

                //  encrypt renewal date for existing installations
                encryptionRoutines er = new encryptionRoutines();
                selectString = "SELECT TINSTALLDATE, eDate, GUID FROM tOptions";  //  get the installation date and expiration date
                selCmd = new FbCommand(selectString, mediaConn);
                //try {
                FbDataReader dr3 = selCmd.ExecuteReader();
                if (dr3.Read()) {
                    if (dr3[0] != DBNull.Value && dr3[1] == DBNull.Value) {  //  if there exists an install date and no eDate...
                        DateTime dt = DateTime.Parse(dr3[0].ToString());  //  convert object to DateTime so we can get short date
                        if (dt == DateTime.Today) //{  //  if it's today, this is a new install, so give them 30-days
                            dt = dt.AddMonths(1);
                        maintenanceString = "UPDATE tOptions SET eDate = '" + er.encryptString(dt.ToShortDateString(),
                            storedGUID) + "' ROWS 1";
                        // }
                        //else  //  install date is not today, so eDate = installDate
                        //    maintenanceString = "UPDATE tOptions SET eDate = '" + er.encryptString(dt.ToShortDateString(), dr3[2].ToString()) + "' ROWS 1";

                        selCmd = new FbCommand(maintenanceString, mediaConn);
                        selCmd.ExecuteNonQuery();  //  update eDate with encrypted install date (renewal date will be computed in LicenseInformation)
                    }

                    selectString = "SELECT eDate FROM tOptions";  //  get renewal date and move it to mainForm renewal date
                    selCmd = new FbCommand(selectString, mediaConn);
                    FbDataReader dr4 = selCmd.ExecuteReader();
                    if (dr4.Read()) {
                        if (dr4[0] != DBNull.Value)
                            renewalDate = DateTime.Parse(er.decryptString(dr4[0].ToString(), storedGUID));  //  test for 'bad data'
                    }
                    dr4.Close();
                }
                dr3.Close();

                fTrace("I - going to fillUPloadInfoTable");
                fillUploadInfoTable();  //  first time, fill UID and Password table
            }
            else
                installedDate = (DateTime)rdr[0];

            rdr.Close();

            return 0;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  save import tab mapping
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void saveMapping() {

            Cursor.Current = Cursors.WaitCursor;
            //  string filename = System.AppDomain.CurrentDomain.BaseDirectory + "pragerMediatabSettings.xml";

            string directory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Prager";
            bool modified;
            if (!Directory.Exists(directory)) {
                DirectoryInfo directoryInfo = directoryInfo = Directory.CreateDirectory(directory);
                DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
                AccessRule rule = new FileSystemAccessRule(
                    "Users",
                    FileSystemRights.Write |
                    FileSystemRights.ReadAndExecute |
                    FileSystemRights.Modify,
                    InheritanceFlags.ContainerInherit |
                    InheritanceFlags.ObjectInherit,
                    PropagationFlags.InheritOnly,
                    AccessControlType.Allow);
                //directorySecurity.ModifyAccessRule(AccessControlModification.Add, rule, out modified);
                directorySecurity.ModifyAccessRule(AccessControlModification.Add, rule, out modified);
                directoryInfo.SetAccessControl(directorySecurity);
                //Directory.CreateDirectory(directory);
            }

            string xmlFilename = "";
            if (rbImportAZ.Checked)  //  if this is an Amazon input file...
                xmlFilename = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Prager\prager.Media.AZimporttabSettings.xml";
            else
                xmlFilename = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Prager\prager.Media.importtabSettings.xml";

            XmlTextWriter tw = new XmlTextWriter(xmlFilename, null);  //null represents the Encoding Type
            tw.Formatting = Formatting.Indented;  //for xml tags to be indented
            tw.WriteStartDocument();   //Indicates the starting of document (Required)
            tw.WriteStartElement("ImportTabSettings");

            tw.WriteAttributeString("AddDesc1", tbMapAddTitle.Text);
            tw.WriteAttributeString("AddDesc2", tbMapAddDesc2.Text);
            tw.WriteAttributeString("AddDesc3", tbMapAddDesc3.Text);
            tw.WriteAttributeString("MapQuantity", tbMapQty.Text);
            tw.WriteAttributeString("MapMediaCond", tbMapMediaCond.Text);
            tw.WriteAttributeString("MapSKU", tbMapSKU.Text);
            tw.WriteAttributeString("MapASIN", tbMapASIN.Text);
            tw.WriteAttributeString("MapCost", tbMapProdIDType.Text);
            tw.WriteAttributeString("MapDateSold", tbMapDateSold.Text);
            tw.WriteAttributeString("MapDesc", tbMapDesc.Text);
            tw.WriteAttributeString("MapEdition", tbMapItemNotes.Text);
            tw.WriteAttributeString("MapUPC", tbMapUPC.Text);
            tw.WriteAttributeString("MapPrice", tbMapPrice.Text);
            tw.WriteAttributeString("MapPrivateNotes", tbMapPrivateNotes.Text);
            tw.WriteAttributeString("MapPublisher", tbMapPublisher.Text);
            tw.WriteAttributeString("MapPubLoc", tbMapPubLoc.Text);
            tw.WriteAttributeString("MapTitle", tbMapTitle.Text);
            tw.WriteAttributeString("MapType", tbMapProductID.Text);
            tw.WriteAttributeString("MapLocation", tbMapLocation.Text);
            tw.WriteAttributeString("MapYearPub", tbMapCondition.Text);
            tw.WriteAttributeString("MapShipExp", tbExpedited.Text);
            tw.WriteAttributeString("MapShipIntl", tbInternational.Text);
            tw.WriteAttributeString("MapStatus", tbMapStatus.Text);

            tw.WriteEndElement();
            tw.WriteEndDocument();

            tw.Flush();
            tw.Close();

            lOptionsSaved.Visible = true;  //  display message...

            Cursor.Current = Cursors.Default;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  restore import tab mapping
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void restoreImportTabMapping() {

            Cursor.Current = Cursors.WaitCursor;
            string xmlFilename = "";
            if (rbImportAZ.Checked)  //  if this is an Amazon input file...
                xmlFilename = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Prager\prager.Media.AZimporttabSettings.xml";
            else
                xmlFilename = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Prager\prager.Media.importtabSettings.xml";


            if (!File.Exists(xmlFilename))   //  is it in the new directory?
                xmlFilename = System.AppDomain.CurrentDomain.BaseDirectory + "prager.MediaTabSettings.xml";  //  use the last one...

            if (File.Exists(xmlFilename)) {
                XmlTextReader tr = new XmlTextReader(xmlFilename);

                tr.Read();

                while (tr.Read())  // If the node has value
                {
                    tr.MoveToElement();  // Move to fist element

                    tbMapAddTitle.Text = tr.GetAttribute("AddDesc1");
                    tbMapAddDesc2.Text = tr.GetAttribute("AddDesc2");
                    tbMapAddDesc3.Text = tr.GetAttribute("AddDesc3");
                    tbMapQty.Text = tr.GetAttribute("MapQuantity");
                    tbMapMediaCond.Text = tr.GetAttribute("MapMediaCond");
                    tbMapSKU.Text = tr.GetAttribute("MapSKU");
                    tbMapASIN.Text = tr.GetAttribute("MapASIN");
                    tbMapProdIDType.Text = tr.GetAttribute("MapCost");
                    tbMapDateSold.Text = tr.GetAttribute("MapDateSold");
                    tbMapDesc.Text = tr.GetAttribute("MapDesc");
                    tbMapItemNotes.Text = tr.GetAttribute("MapEdition");
                    tbMapUPC.Text = tr.GetAttribute("MapUPC");
                    tbMapPrice.Text = tr.GetAttribute("MapPrice");
                    tbMapPrivateNotes.Text = tr.GetAttribute("MapPrivateNotes");
                    tbMapPublisher.Text = tr.GetAttribute("MapPublisher");
                    tbMapPubLoc.Text = tr.GetAttribute("MapPubLoc");
                    tbMapTitle.Text = tr.GetAttribute("MapTitle");
                    tbMapProductID.Text = tr.GetAttribute("MapType");
                    tbMapLocation.Text = tr.GetAttribute("MapLocation");
                    tbMapCondition.Text = tr.GetAttribute("MapYearPub");
                    tbInternational.Text = tr.GetAttribute("MapShipIntl");
                    tbExpedited.Text = tr.GetAttribute("MapShipExp");
                    tbMapStatus.Text = tr.GetAttribute("MapStatus");
                }

                tr.Close();
            }
            Cursor.Current = Cursors.Default;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--  clear import tab mappings
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void clearImportTabMappings() {
            tbMapTitle.Text = "";
            tbMapDesc.Text = "";
            tbMapSKU.Text = "";
            tbMapPrice.Text = "";
            tbMapQty.Text = "";
            tbMapProdIDType.Text = "";
            tbMapItemNotes.Text = "";
            tbMapCondition.Text = "";
            tbMapASIN.Text = "";
            tbMapProductID.Text = "";

            return;
        }


        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////--  user has changed a User ID or password
        ////++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //private void dataGridValueChanged(DataGridViewCellEventArgs e) {
        //    if (e.RowIndex == -1)
        //        return;

        //    DataGridViewRow dataRow = UIDdataGridView.Rows[e.RowIndex];

        //    switch (dataRow.Cells[0].Value.ToString()) {
        //        case "Alibris":
        //            if (dataRow.Cells[1].Value == null)
        //                dataRow.Cells[1].Value = "";
        //            AlibrisUID = dataRow.Cells[1].Value.ToString();
        //            if (dataRow.Cells[2].Value == null)
        //                dataRow.Cells[2].Value = "";
        //            AlibrisPwd = dataRow.Cells[2].Value.ToString();
        //            break;
        //        case "Papa Media":
        //            if (dataRow.Cells[1].Value == null)
        //                dataRow.Cells[1].Value = "";
        //            PapaMediaUID = dataRow.Cells[1].Value.ToString();
        //            if (dataRow.Cells[2].Value == null)
        //                dataRow.Cells[2].Value = "";
        //            PapaMediaPwd = dataRow.Cells[2].Value.ToString();
        //            break;
        //        case "Scribblemonger":
        //            if (dataRow.Cells[1].Value == null)
        //                dataRow.Cells[1].Value = "";
        //            ScribblemongerUID = dataRow.Cells[1].Value.ToString();
        //            if (dataRow.Cells[2].Value == null)
        //                dataRow.Cells[2].Value = "";
        //            ScribblemongerPwd = dataRow.Cells[2].Value.ToString();
        //            break;
        //        case "Half.com":
        //            if (dataRow.Cells[1].Value == null)
        //                dataRow.Cells[1].Value = "";
        //            HalfDotComUID = dataRow.Cells[1].Value.ToString();
        //            if (dataRow.Cells[2].Value == null)
        //                dataRow.Cells[2].Value = "";
        //            HalfDotComPwd = dataRow.Cells[2].Value.ToString();
        //            break;
        //        case "Barnes & Noble":
        //            if (dataRow.Cells[1].Value == null)
        //                dataRow.Cells[1].Value = "";
        //            BandNUID = dataRow.Cells[1].Value.ToString();
        //            if (dataRow.Cells[2].Value == null)
        //                dataRow.Cells[2].Value = "";
        //            BandNPwd = dataRow.Cells[2].Value.ToString();
        //            break;
        //        case "Chrislands":
        //            if (dataRow.Cells[1].Value == null)
        //                dataRow.Cells[1].Value = "";
        //            ChrislandsUID = dataRow.Cells[1].Value.ToString();
        //            if (dataRow.Cells[2].Value == null)
        //                dataRow.Cells[2].Value = "";
        //            ChrislandsPwd = dataRow.Cells[2].Value.ToString();
        //            break;
        //        default:
        //            if (dataRow.Cells[1].Value == null)
        //                dataRow.Cells[1].Value = "";
        //            if (dataRow.Cells[2].Value == null)
        //                dataRow.Cells[2].Value = "";
        //            if (dataRow.Cells[3].Value == null)
        //                dataRow.Cells[3].Value = "";
        //            if (dataRow.Cells[4].Value == null)
        //                dataRow.Cells[4].Value = "";
        //            if (dataRow.Cells[5].Value == null)
        //                dataRow.Cells[5].Value = "";
        //            break;
        //    }
        //}

    }  //  end Form1
}  //  end namespace

