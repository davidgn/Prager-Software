//#define TRACE

#region Using directives

using System;
using System.Data;
using System.Linq;
using System.Diagnostics;
using System.Security.AccessControl;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Xml;
using FirebirdSql.Data.FirebirdClient;
using System.Collections.Generic;

#endregion



namespace Prager_Book_Inventory
{

    partial class mainForm : Form
    {
        #region string Definitions
        static string[] ffPrefix = { "", "", "", "" };

        internal static string AlibrisUID = "";
        internal static string AlibrisPwd = "";
        internal static string ABEUID = "";
        internal static string ABEPwd = "";
        internal static string BiblioUID = "";
        internal static string BiblioPwd = "";
        internal static string ChooseUID = "";
        internal static string ChoosePwd = "";
        internal static string AntiqBookUID = "";
        internal static string AntiqBookPwd = "";
        internal static string PapaMediaUID = "";
        internal static string PapaMediaPwd = "";
        internal static string ScribblemongerUID = "";
        internal static string ScribblemongerPwd = "";
        internal static string TomFolioUID = "";
        internal static string TomFolioPwd = "";
        internal static string GoogleUID = "";
        internal static string GooglePwd = "";
        internal static string BibliophileUID = "";
        internal static string BibliophilePwd = "";
        internal static string BonanzaUID = "";
        internal static string BonanzaPwd = "";
        //internal static string AmazonUID = "";
        //internal static string AmazonPwd = "";
        internal static string UsedBookCntrlUID = "";
        internal static string UsedBookCntrlPwd = "";
        internal static string HalfDotComUID = "";
        internal static string HalfDotComPwd = "";
        internal static string BiblionUID = "";
        internal static string BiblionPwd = "";
        internal static string BandNUID = "";
        internal static string BandNPwd = "";
        internal static string ChrislandsUID = "";
        internal static string ChrislandsPwd = "";
        internal static string BookByteUID = "";
        internal static string BookBytePwd = "";
        internal static string BookPursuitUID = "";
        internal static string BookPursuitPwd = "";
        internal static string ValoreUID = "";
        internal static string ValorePwd = "";
        internal static string A1BooksUID = "";
        internal static string A1BooksPwd = "";
        //internal static string ScribblemongerUID = "";
        //internal static string ScribblemongerPwd = "";

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
        #endregion

        //+++++++++++++++++++++++++++++++++++++++++++++++
        //--  restore options
        //+++++++++++++++++++++++++++++++++++++++++++++++
        public void restoreOptions(string optionsXMLFilename) {
            Cursor.Current = Cursors.WaitCursor;
            string xmlFilename = "";

            //   int i = 0;  //  index to control the insertion of canned text
            lbCannedText.Items.Clear();

            //  if programOptionsPath is NOT null, then user IS networking
            if (programOptionsPath != null)  { //  user wants to network program options...
                //string optionsPath = programOptionsPath + @"\prager.Options.xml";
                string optionsPath = programOptionsPath + optionsXMLFilename;
                if (File.Exists(optionsPath)) {
                    xmlFilename = optionsPath;
                //    networkedClient = true;
                }
            }
            else  { //  either didn't find options, or doesn't want to network them...
            //    networkedClient = false;
                xmlFilename = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Prager" + optionsXMLFilename;
                if (!File.Exists(xmlFilename))   //  if it doesn't exist, look-see if it's in the new directory?
                {
                    xmlFilename = System.AppDomain.CurrentDomain.BaseDirectory;
                    if (xmlFilename.Contains(@"bin\Debug"))
                        xmlFilename += optionsXMLFilename;
                    else
                        xmlFilename += @"\Prager" + optionsXMLFilename;

                    if (!File.Exists(xmlFilename))
                        xmlFilename = "";  //  must be first time, so it doesn't exist... 
                }
            }

            fTrace("I - prager.Options.xml file path: " + xmlFilename);

            if (File.Exists(xmlFilename)) {
                //File.SetAttributes(xmlFilename, FileAttributes.);  //  so we can write on the file
                using (XmlReader tr = XmlReader.Create(xmlFilename)) {
                    try {
                        while (tr.Read())  // If the node has value 
                        {
                            if (tr.IsStartElement("CannedText")) {
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
                                if (tr.GetAttribute("tTextTitle11") != null)  //  if we haven't saved anything past 10...
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

                            //  now get program options...
                            if (tr.IsStartElement("ProgramOptions")) {
                                if (tr.GetAttribute("oAutoPricing") == "true")
                                    cbAutoPricingLookup.Checked = true;
                                else cbAutoPricingLookup.Checked = false;

                                if (tr.GetAttribute("oVerifyDeletes") == "true")
                                    cbVerifyDeletes.Checked = true;
                                else cbVerifyDeletes.Checked = false;

                                if (tr.GetAttribute("oBackupDB") == "true")
                                    cbBackupDB.Checked = true;
                                else cbBackupDB.Checked = false;

                                if (tr.GetAttribute("oKeywords") == "true")
                                    cbCreateKeywords.Checked = true;
                                else cbCreateKeywords.Checked = false;

                                if (tr.GetAttribute("oWarnNoCat") == "true")
                                    cbWarnNoCatalog.Checked = true;
                                else cbWarnNoCatalog.Checked = false;

                                if (tr.GetAttribute("oAutoSKU") == "true")
                                    cbAutomaticSKU.Checked = true;
                                else cbAutomaticSKU.Checked = false;

                                if (tr.GetAttribute("oWarnNoLoc") == "true")
                                    cbWarnNoLocation.Checked = true;
                                else cbWarnNoLocation.Checked = false;

                                if (tr.GetAttribute("oWarnNoDJ") == "true")
                                    cbWarnNoDJ.Checked = true;
                                else cbWarnNoDJ.Checked = false;

                                if (tr.GetAttribute("oGenCustNbr") == "true")
                                    cbAutoCustomerNbr.Checked = true;
                                else cbAutoCustomerNbr.Checked = false;

                                if (tr.GetAttribute("oGenInvNbr") == "true")
                                    cbAutoInvoiceNbr.Checked = true;
                                else cbAutoInvoiceNbr.Checked = false;

                                if (tr.GetAttribute("oAutoFileRetn") == "true")
                                    cbAutoFileRetention.Checked = true;
                                else cbAutoFileRetention.Checked = false;

                                if (tr.GetAttribute("oCapTitle") == "true")
                                    cbCapTitleAuthor.Checked = true;
                                else cbCapTitleAuthor.Checked = false;

                                if (tr.GetAttribute("oUseDualCat") == "true")
                                    cbUseDualCatalogs.Checked = true;
                                else cbUseDualCatalogs.Checked = false;

                                if (tr.GetAttribute("oToolTipsOff") == "true")
                                    cbToolTips.Checked = true;
                                else cbToolTips.Checked = false;

                                if (tr.GetAttribute("oCrashReporting") == "false")
                                    cbEnableCR.Checked = false;
                                else cbEnableCR.Checked = true;

                                if (tr.GetAttribute("oAllowAddUpdate") == "true")
                                    cbAllowAddUpdate.Checked = true;
                                else cbAllowAddUpdate.Checked = false;

                                if (tr.GetAttribute("oAmazonCat") == "true")
                                    cbAmazonCategories.Checked = true;
                                else cbAmazonCategories.Checked = false;

                                if (tr.GetAttribute("oAddAuthor2Keywords") == "true")
                                    cbAddAuthor2Keywords.Checked = true;
                                else cbAddAuthor2Keywords.Checked = true;

                                if (tr.GetAttribute("oStartPanelSearch") == "true")
                                    rbStartSearch.Checked = true;
                                else rbStartDetail.Checked = true;

                                if (tr.GetAttribute("oCurrEnglish") == "true")
                                    rbGBPound.Checked = true;
                                else rbGBPound.Checked = false;

                                if (tr.GetAttribute("oCurrEuro") == "true")
                                    rbEUDollar.Checked = true;
                                else rbEUDollar.Checked = false;

                                if (tr.GetAttribute("oCurrCanadian") == "true")
                                    rbCNDollar.Checked = true;
                                else rbCNDollar.Checked = false;

                                if (tr.GetAttribute("oWeight") == "true")
                                    rbOunces.Checked = true;
                                else rbOunces.Checked = false;

                                if (tr.GetAttribute("oUseBlank") == "true")
                                    cbUseBlank.Checked = true;
                                else cbUseBlank.Checked = false;

                                if (tr.GetAttribute("oMoveAvgPrice") == "true")
                                    rbMoveAvgPrice.Checked = true;
                                else
                                    rbMoveAvgPrice.Checked = false;

                                if (tr.GetAttribute("oMoveLowPrice") == "true")
                                    rbMoveLowPrice.Checked = true;
                                else
                                    rbMoveLowPrice.Checked = false;

                                if (tr.GetAttribute("oNoDesc") == "true")
                                    cbAddDesc.Checked = true;
                                else
                                    cbAddDesc.Checked = false;

                                if (tr.GetAttribute("oSortOverride") == "true")
                                    cbSortOverride.Checked = true;
                                else
                                    cbSortOverride.Checked = false;

                                if (tr.GetAttribute("oSortAsc") == "true")
                                    rbSortAsc.Checked = true;
                                else
                                    rbSortAsc.Checked = false;

                                if (tr.GetAttribute("oSortDsc") == "true")
                                    rbSortDsc.Checked = true;
                                else
                                    rbSortDsc.Checked = false;

                                if (tr.GetAttribute("oUseReceipt") == "true")
                                    cbUseReceipt.Checked = true;
                                else
                                    cbUseReceipt.Checked = false;

                                if (tr.GetAttribute("oDontOverlay") == "true")
                                    cbDontOverlay.Checked = true;
                                else
                                    cbDontOverlay.Checked = false;

                                if (tr.GetAttribute("oAmazonUS") == "true")
                                    rbAmazonUS.Checked = true;
                                else
                                    rbAmazonUS.Checked = false;

                                if (tr.GetAttribute("oAmazonCA") == "true")
                                    rbAmazonCA.Checked = true;
                                else
                                    rbAmazonCA.Checked = false;

                                if (!rbAmazonUS.Checked && !rbAmazonCA.Checked)  //  first time
                                    rbAmazonUS.Checked = true;


                                //  Amazon keys
                                if (tr.GetAttribute("oAWSKey").Length > 0)
                                    tbAWSKey.Text = tr.GetAttribute("oAWSKey");

                                if (tr.GetAttribute("oAWSSecretKey").Length > 0)
                                    tbAWSSecretKey.Text = tr.GetAttribute("oAWSSecretKey");

                                if (tr.GetAttribute("oAZAssocTag").Length > 0)
                                    tbAZAssocTag.Text = tr.GetAttribute("oAZAssocTag");

                                if (tr.GetAttribute("oMerchantID").Length > 0)
                                    tbMerchantID.Text = tr.GetAttribute("oMerchantID");

                                if (tr.GetAttribute("oMarketplaceID").Length > 0)
                                    tbMarketplaceID.Text = tr.GetAttribute("oMarketplaceID");

                                if (tr.GetAttribute("oHalfDotComToken").Length > 0)
                                    tbHalfToken.Text = tr.GetAttribute("oHalfDotComToken");

                            }

                            //  set tab sequence settings
                            if (tr.IsStartElement("tabSettings")) {
                                if (tr.GetAttribute("oISBNSeq").Length > 0)
                                    mtbISBN.TabIndex = Convert.ToInt32(tr.GetAttribute("oISBNSeq"));
                                if (tr.GetAttribute("oQtySeq").Length > 0)
                                    tbCopies.TabIndex = Convert.ToInt32(tr.GetAttribute("oQtySeq"));
                                if (tr.GetAttribute("oLocSeq").Length > 0)
                                    tbLocn.TabIndex = Convert.ToInt32(tr.GetAttribute("oLocSeq"));
                                if (tr.GetAttribute("oSKUSeq").Length > 0)
                                    tbBookNbr.TabIndex = Convert.ToInt32(tr.GetAttribute("oSKUSeq"));
                                if (tr.GetAttribute("oCostSeq").Length > 0)
                                    tbMyCost.TabIndex = Convert.ToInt32(tr.GetAttribute("oCostSeq"));
                                if (tr.GetAttribute("oPriceSeq").Length > 0)
                                    tbListPrice.TabIndex = Convert.ToInt32(tr.GetAttribute("oPriceSeq"));
                                if (tr.GetAttribute("oRePriceSeq").Length > 0)
                                    cbDoNotReprice.TabIndex = Convert.ToInt32(tr.GetAttribute("oRePriceSeq"));
                                if (tr.GetAttribute("oTitleSeq").Length > 0)
                                    tbTitle.TabIndex = Convert.ToInt32(tr.GetAttribute("oTitleSeq"));
                                if (tr.GetAttribute("oAuthorSeq").Length > 0)
                                    tbAuthor.TabIndex = Convert.ToInt32(tr.GetAttribute("oAuthorSeq"));
                                if (tr.GetAttribute("oASignedSeq").Length > 0)
                                    tbIllus.TabIndex = Convert.ToInt32(tr.GetAttribute("oASignedSeq"));
                                if (tr.GetAttribute("oIllusSeq").Length > 0)
                                    cbAuthorSigned.TabIndex = Convert.ToInt32(tr.GetAttribute("oIllusSeq"));
                                if (tr.GetAttribute("oISignedSeq").Length > 0)
                                    cbIllusSigned.TabIndex = Convert.ToInt32(tr.GetAttribute("oISignedSeq"));
                                if (tr.GetAttribute("oPubSeq").Length > 0)
                                    tbPub.TabIndex = Convert.ToInt32(tr.GetAttribute("oPubSeq"));
                                if (tr.GetAttribute("oPlaceSeq").Length > 0)
                                    tbPlace.TabIndex = Convert.ToInt32(tr.GetAttribute("oPlaceSeq"));
                                if (tr.GetAttribute("oYearSeq").Length > 0)
                                    tbYear.TabIndex = Convert.ToInt32(tr.GetAttribute("oYearSeq"));
                                if (tr.GetAttribute("oDescSeq").Length > 0)
                                    tbDesc.TabIndex = Convert.ToInt32(tr.GetAttribute("oDescSeq"));
                                if (tr.GetAttribute("oCannedSeq").Length > 0)
                                    lbCannedText.TabIndex = Convert.ToInt32(tr.GetAttribute("oCannedSeq"));
                                if (tr.GetAttribute("oBindingSeq").Length > 0)
                                    coBinding.TabIndex = Convert.ToInt32(tr.GetAttribute("oBindingSeq"));
                                if (tr.GetAttribute("oCondSeq").Length > 0)
                                    coCondition.TabIndex = Convert.ToInt32(tr.GetAttribute("oCondSeq"));
                                if (tr.GetAttribute("oJacketSeq").Length > 0)
                                    coJacket.TabIndex = Convert.ToInt32(tr.GetAttribute("oJacketSeq"));
                                if (tr.GetAttribute("oEdSeq").Length > 0)
                                    coEdition.TabIndex = Convert.ToInt32(tr.GetAttribute("oEdSeq"));
                                if (tr.GetAttribute("oPagesSeq").Length > 0)
                                    tbPages.TabIndex = Convert.ToInt32(tr.GetAttribute("oPagesSeq"));
                                if (tr.GetAttribute("oWtSeq").Length > 0)
                                    tbWeight.TabIndex = Convert.ToInt32(tr.GetAttribute("oWtSeq"));
                                if (tr.GetAttribute("oTypeSeq").Length > 0)
                                    coType.TabIndex = Convert.ToInt32(tr.GetAttribute("oTypeSeq"));
                                if (tr.GetAttribute("oSizeSeq").Length > 0)
                                    coSize.TabIndex = Convert.ToInt32(tr.GetAttribute("oSizeSeq"));
                                if (tr.GetAttribute("oPriSeq").Length > 0)
                                    tbPriCatalog.TabIndex = Convert.ToInt32(tr.GetAttribute("oPriSeq"));
                                if (tr.GetAttribute("oSecSeq").Length > 0)
                                    tbSecCatalog.TabIndex = Convert.ToInt32(tr.GetAttribute("oSecSeq"));
                                if (tr.GetAttribute("oKeySeq").Length > 0)
                                    tbKeywords.TabIndex = Convert.ToInt32(tr.GetAttribute("oKeySeq"));
                            }

                            //  now restore the previous upload selections...
                            if (tr.IsStartElement("UploadSelections")) {
                                if (tr.GetAttribute("uAmazon") == "true" && tbMarketplaceID.Text.Length > 0 && tbMerchantID.Text.Length > 0)
                                    cbUploadAmazon.Checked = true;
                                else
                                    cbUploadAmazon.Checked = false;

                                if (tr.GetAttribute("uAmazonUK") == "true" && tbAWSKey.Text.Length > 0 && tbAWSSecretKey.Text.Length > 0)
                                    cbUploadAmazonUK.Checked = true;
                                else
                                    cbUploadAmazonUK.Checked = false;

                                if (tr.GetAttribute("uABE") == "true" && ABEUID.Length > 0)
                                    cbUploadABE.Checked = true;
                                else
                                    cbUploadABE.Checked = false;

                                if (tr.GetAttribute("uAlibris") == "true" && AlibrisUID.Length > 0)
                                    cbUploadAlibris.Checked = true;
                                else
                                    cbUploadAlibris.Checked = false;

                                if (tr.GetAttribute("uAntiqBook") == "true" && AntiqBookUID.Length > 0)
                                    cbUploadAntiqBook.Checked = true;
                                else
                                    cbUploadAntiqBook.Checked = false;

                                if (tr.GetAttribute("uBiblio") == "true" && BiblioUID.Length > 0)
                                    cbUploadBiblio.Checked = true;
                                else
                                    cbUploadBiblio.Checked = false;

                                if (tr.GetAttribute("uBandN") == "true" && BandNUID.Length > 0)
                                    cbUploadBandN.Checked = true;
                                else
                                    cbUploadBandN.Checked = false;

                                if (tr.GetAttribute("uBiblion") == "true" && BiblionUID.Length > 0)
                                    cbUploadBiblion.Checked = true;
                                else
                                    cbUploadBiblion.Checked = false;

                                if (tr.GetAttribute("uBibliophile") == "true" && BibliophileUID.Length > 0)
                                    cbUploadBibliophile.Checked = true;
                                else
                                    cbUploadBibliophile.Checked = false;

                                if (tr.GetAttribute("uPapaMedia") == "true" && PapaMediaUID.Length > 0)
                                    cbUploadPapaMedia.Checked = true;
                                else
                                    cbUploadPapaMedia.Checked = false;

                                if (tr.GetAttribute("uScribblemonger") == "true" && ScribblemongerUID.Length > 0)
                                    cbUploadScribblemonger.Checked = true;
                                else
                                    cbUploadScribblemonger.Checked = false;

                                if (tr.GetAttribute("uBookByte") == "true" && BookByteUID.Length > 0)
                                    cbUploadBookByte.Checked = true;
                                else
                                    cbUploadBookByte.Checked = false;

                                if (tr.GetAttribute("uHalfDotCom") == "true" && HalfDotComUID.Length > 0)
                                        cbUploadHalfDotCom.Checked = true;
                                else
                                    cbUploadHalfDotCom.Checked = false;

                                if (tr.GetAttribute("uChooseBooks") == "true" && ChooseUID.Length > 0)
                                    cbUploadChooseBks.Checked = true;
                                else
                                    cbUploadChooseBks.Checked = false;

                                if (tr.GetAttribute("uChrislands") == "true" && ChrislandsUID.Length > 0)
                                    cbUploadChrislands.Checked = true;
                                else
                                    cbUploadChrislands.Checked = false;

                                if (tr.GetAttribute("uGoogleBase") == "true" && GoogleUID.Length > 0)
                                    cbUploadGoogleBase.Checked = true;
                                else
                                    cbUploadGoogleBase.Checked = false;

                                if (tr.GetAttribute("uTomFolio") == "true" && TomFolioUID.Length > 0)
                                    cbUploadTomFolio.Checked = true;
                                else
                                    cbUploadTomFolio.Checked = false;

                                if (tr.GetAttribute("uValore") == "true" && ValoreUID.Length > 0)
                                    cbUploadValoreBooks.Checked = true;
                                else
                                    cbUploadValoreBooks.Checked = false;

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

                                //  the following are for HB to UIEE upload format message
                                if (tr.GetAttribute("BiblioUIEE") == "true")
                                    BiblioUIEE = true;
                                else BiblioUIEE = false;

                                if (tr.GetAttribute("ABETab") == "true")
                                    ABETab = true;
                                else ABETab = false;

                                if (tr.GetAttribute("BibliophileUIEE") == "true")
                                    BibliophileUIEE = true;
                                else BibliophileUIEE = false;

                                if (tr.GetAttribute("UsedBookCentralUIEE") == "true")
                                    UsedBookCentralUIEE = true;
                                else UsedBookCentralUIEE = false;

                                if (tr.GetAttribute("BiblionUIEE") == "true")
                                    BiblionUIEE = true;
                                else BiblionUIEE = false;

                                if (tr.GetAttribute("BibliologyUIEE") == "true")
                                    BibliologyUIEE = true;
                                else BibliologyUIEE = false;

                            }

                            //  now do the repricing selections...
                            if (tr.IsStartElement("RepricingSelections")) {
                                tbHighByAmt.Text = tr.GetAttribute("highByAmt");
                                lbWhatPriceH.SelectedIndex = int.Parse(tr.GetAttribute("whatPriceH"));
                                tbLowByAmt.Text = tr.GetAttribute("lowByAmt");
                                lbWhatPriceL.SelectedIndex = int.Parse(tr.GetAttribute("whatPriceL"));
                                tbNewByAmt.Text = tr.GetAttribute("newByAmt");
                                lbNewWhatPrice.SelectedIndex = int.Parse(tr.GetAttribute("newWhatPrice"));
                                tb1stPremium.Text = tr.GetAttribute("firstPremium");
                                tbSignedPremium.Text = tr.GetAttribute("signedPremium");
                                tbCondAmtVG.Text = tr.GetAttribute("condAmtVG");
                                tbCondAmtG.Text = tr.GetAttribute("condAmtG");
                                tbCondAmtP.Text = tr.GetAttribute("condAmtP");
                                tbBelowMyCostOr.Text = tr.GetAttribute("belowMyCostOr");
                                tbDiscardBelowAmt.Text = tr.GetAttribute("discardBelowAmt");
                                tbDiscardAboveAmt.Text = tr.GetAttribute("discardAboveAmt");

                                if (tr.GetAttribute("priceLowPct") == "true")
                                    rbPriceLowPct.Checked = true;
                                else
                                    rbPriceLowPct.Checked = false;

                                if (tr.GetAttribute("greaterSugg") == "true")
                                    cbGreaterSugg.Checked = true;
                                else
                                    cbGreaterSugg.Checked = false;

                                if (tr.GetAttribute("lessSugg") == "true")
                                    cbLessSugg.Checked = true;
                                else
                                    cbLessSugg.Checked = false;

                                if (tr.GetAttribute("highBelow") == "true")
                                    rbHighBelow.Checked = true;
                                else
                                    rbHighBelow.Checked = false;

                                if (tr.GetAttribute("priceHighPct") == "true")
                                    rbPriceHighPct.Checked = true;
                                else
                                    rbPriceHighPct.Checked = false;

                                if (tr.GetAttribute("lowBelow") == "true")
                                    rbLowBelow.Checked = true;
                                else
                                    rbLowBelow.Checked = false;

                                if (tr.GetAttribute("dontGoBelowCost") == "true")
                                    cbDontGoBelowCost.Checked = true;
                                else
                                    cbDontGoBelowCost.Checked = false;

                                if (tr.GetAttribute("priceNewPct") == "true")
                                    rbPriceNewPct.Checked = true;
                                else
                                    rbPriceNewPct.Checked = false;

                                if (tr.GetAttribute("adjustPostage") == "true")
                                    cbAdjustPostage.Checked = true;
                                else
                                    cbAdjustPostage.Checked = false;
                            }

                            if (tr.IsStartElement("BookConditions")) {  //  restore user's pick for book conditions
                                rbUseAmazonCond.Checked = false;
                                rbUseGenericCond.Checked = false;
                                rbUseCustomCond.Checked = false;

                                if (tr.GetAttribute("Amazon") == "true")  //  we're using Amazon's conditions
                                    rbUseAmazonCond.Checked = true;
                                else if (tr.GetAttribute("Generic") == "true")  //  using Generic conditions
                                    rbUseGenericCond.Checked = true;
                                else if (tr.GetAttribute("Custom") == "true")  {  //  user has entered custom conditions
                                    rbUseCustomCond.Checked = true;

                                    int itemCount = 0;
                                    itemCount = int.Parse(tr.GetAttribute("CustomCount"));
                                    for (i = 0; i < itemCount; i++) {
                                        tbcustomCondition.AppendText(tr.GetAttribute("item" + i.ToString()) + "\r\n");
                                        coCondition.Items.Add(tr.GetAttribute("item" + i.ToString()));
                                    }
                                }

                                if (!rbUseAmazonCond.Checked && !rbUseGenericCond.Checked && !rbUseCustomCond.Checked) {
                                    DialogResult dlgResult = DialogResult.None;
                                    dlgResult = MessageBox.Show("You do not have a set of Book Conditions selected; do you want to do it now?",
                                        "Prager Book Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (dlgResult == DialogResult.Yes)
                                        //tabTaskPanel.SelectTab(cProgramOptions);  //  to to Program Options
                                        startOnProgramOptions = true;
                                }

                                fillBookCondition();  // now fill it in the Book Detail tab
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

                            //  now finish up with the Miscellaneous items
                            if (tr.IsStartElement("Miscellaneous")) {
                                if (tr.GetAttribute("mPictureFilename").Length > 0)
                                    pictureFileName = tr.GetAttribute("mPictureFilename");
                                if (tr.GetAttribute("mBusinessAddress").Length > 0)
                                    tbBusinessAddr.Text = tr.GetAttribute("mBusinessAddress");
                                if (tr.GetAttribute("mReceiptWidth") != null && tr.GetAttribute("mReceiptWidth").Length > 0)
                                    tbWidth.Text = tr.GetAttribute("mReceiptWidth");
                                if (tr.GetAttribute("mStoreName") != null && tr.GetAttribute("mStoreName").Length > 0)
                                    tbStoreName.Text = tr.GetAttribute("mStoreName");
                                //if (tr.GetAttribute("NetworkedClient") == "true")  //  we're networking, so ignore license errors
                                //    networkedClient = true;
                                //else
                                //    networkedClient = false;

                            }
                        }
                    }
                    catch (Exception ex) {
                        if (ex.Message.Contains("Root element is missing"))
                            ;  //  do nothing; first time, so nothing to restore
                    }

                    tr.Close();

                    if (cbEnableCR.Checked)
                        fTrace("\nI - Crash Reporting enabled");
                    else
                        fTrace("\nI - Crash Reporting NOT enabled");

                }
            }
            else {
                if (!installedDate.Equals(DateTime.Today)) {
                    fTrace("E - unable to locate prager.Options.xml");
                    MessageBox.Show("Unable to locate prager.Options.xml file; please go to our website, Support page and fill out a ticket",
                        "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                    fTrace("I - Installed today");
            }

            commandString = "select tDateLastExported from tOptions";

            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();
            FbCommand cmd = new FbCommand(commandString, bookConn);
            dr = cmd.ExecuteReader();

            while (dr.Read()) {
                if (!dr.IsDBNull(0)) {
                    dateTimePicker1.Value = (DateTime)dr[0];  //  set to date last exported
                    lastExport = (DateTime)dr[0];  //  here too...
                }
            }

            //  now, move the Amazon keys to the textboxes
            string selectString = "SELECT * from tAZUID";
            sqlCmd = new FbCommand(selectString, bookConn);
            dr = sqlCmd.ExecuteReader();
            dr.Read();  //  read the only row


            if (dr[0].ToString().Length != 0) {
                tbMerchantID.Text = dr[0].ToString();
                tbMarketplaceID.Text = dr[1].ToString();
                tbAWSKey.Text = dr[2].ToString();
                tbAWSSecretKey.Text = dr[3].ToString();
                tbAZAssocTag.Text = dr[4].ToString();
            }
            dr.Close();

            return;
        }



        //+++++++++++++++++++++++++++++++++++++++++++++++
        //--  save options
        //+++++++++++++++++++++++++++++++++++++++++++++++
        public void saveOptions(string optionsXMLFilename) {
            if (backupRestoreFlag == true || networkedClient == true)  //  don't save network settings
                return;

            //  save options and canned text in XML file
            //string filename = System.AppDomain.CurrentDomain.BaseDirectory + "prager.Options.xml";
            //string filename = @"C:\Prager\prager.Options.xml";

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
                directorySecurity.ModifyAccessRule(AccessControlModification.Add, rule, out modified);
                directoryInfo.SetAccessControl(directorySecurity);
            }

            /*
            * This is much better
            FileStream fs = null;
            xmlFilename = System.AppDomain.CurrentDomain.BaseDirectory + @"\Prager\prager.Options.xml";  //  use the last one...
                if (!File.Exists(xmlFilename))
                {
                        //  must be first time, so it doesn't exist; create it...
                    DirectoryInfo di = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Prager");
                    if (di.Exists)
                    {
                        fs = File.Create(di.FullName + @"\prager.Options.xml");
                        //xmlFilename = di.FullName + @"\prager.Options.xml";
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

            //    string xmlFilename = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Prager\prager.Options.xml";
            //string xmlFilename = directory + @"\prager.Options.xml";
            string xmlFilename = directory + optionsXMLFilename;
            if (!File.Exists(xmlFilename))   //  if it's NOT in the new directory
            {
                FileStream fs = null;
                xmlFilename = System.AppDomain.CurrentDomain.BaseDirectory + @"\Prager\" + optionsXMLFilename;  //  use the last one...
                if (!File.Exists(xmlFilename)) {
                    //  must be first time, so it doesn't exist; create it...
                    DirectoryInfo di = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Prager");
                    if (di.Exists) {
                        fs = File.Create(di.FullName + optionsXMLFilename);
                        xmlFilename = fs.Name;    // di.FullName + @"\prager.Options.xml";
                        fs.Close();  //  try to release it...
                    }
                }
            }

            XmlTextWriter tw = null;
            try {
                tw = new XmlTextWriter(xmlFilename, null);  //null represents the Encoding Type
            }
            catch (Exception ex) {
                if (ex.Message.Contains("prager.Options.xml' is denied")) {
                    MessageBox.Show("You do not have write permission to the prager.Options.xml file.  Disable UAC or run this program as Administrator, otherwise your options will not be saved.", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            tw.Formatting = Formatting.Indented;  //for xml tags to be indented
            tw.WriteStartDocument();   //Indicates the starting of document (Required)

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
            tw.WriteAttributeString("oKeywords", cbCreateKeywords.Checked ? "true" : "false");
            tw.WriteAttributeString("oAutoSKU", cbAutomaticSKU.Checked ? "true" : "false");
            tw.WriteAttributeString("oWarnNoCat", cbWarnNoCatalog.Checked ? "true" : "false");
            tw.WriteAttributeString("oWarnNoLoc", cbWarnNoLocation.Checked ? "true" : "false");
            tw.WriteAttributeString("oWarnNoDJ", cbWarnNoDJ.Checked ? "true" : "false");
            tw.WriteAttributeString("oGenCustNbr", cbAutoCustomerNbr.Checked ? "true" : "false");
            tw.WriteAttributeString("oGenInvNbr", cbAutoInvoiceNbr.Checked ? "true" : "false");
            tw.WriteAttributeString("oAutoFileRetn", cbAutoFileRetention.Checked ? "true" : "false");
            tw.WriteAttributeString("oCapTitle", cbCapTitleAuthor.Checked ? "true" : "false");
            tw.WriteAttributeString("oUseDualCat", cbUseDualCatalogs.Checked ? "true" : "false");
            tw.WriteAttributeString("oToolTipsOff", cbToolTips.Checked ? "true" : "false");
            tw.WriteAttributeString("oCrashReporting", cbEnableCR.Checked ? "true" : "false");
            tw.WriteAttributeString("oAmazonCat", cbAmazonCategories.Checked ? "true" : "false");
            tw.WriteAttributeString("oAddAuthor2Keywords", cbAddAuthor2Keywords.Checked ? "true" : "false");
            tw.WriteAttributeString("oStartPanelSearch", rbStartSearch.Checked ? "true" : "false");
            tw.WriteAttributeString("oCurrEnglish", rbGBPound.Checked ? "true" : "false");
            tw.WriteAttributeString("oCurrEuro", rbEUDollar.Checked ? "true" : "false");
            tw.WriteAttributeString("oCurrUS", rbCNDollar.Checked ? "true" : "false");
            tw.WriteAttributeString("oWeight", rbOunces.Checked ? "true" : "false");
            tw.WriteAttributeString("oMoveAvgPrice", rbMoveAvgPrice.Checked ? "true" : "false");
            tw.WriteAttributeString("oMoveLowPrice", rbMoveLowPrice.Checked ? "true" : "false");
            tw.WriteAttributeString("oUseBlank", cbUseBlank.Checked ? "true" : "false");
            tw.WriteAttributeString("oNoDesc", cbAddDesc.Checked ? "true" : "false");
            tw.WriteAttributeString("oDontOverlay", cbDontOverlay.Checked ? "true" : "false");
            tw.WriteAttributeString("oAmazonUS", rbAmazonUS.Checked ? "true" : "false");
            tw.WriteAttributeString("oAmazonCA", rbAmazonCA.Checked ? "true" : "false");

            //  Amazon keys
            tw.WriteAttributeString("oAWSKey", tbAWSKey.Text);
            tw.WriteAttributeString("oAWSSecretKey", tbAWSSecretKey.Text);
            tw.WriteAttributeString("oAZAssocTag", tbAZAssocTag.Text);
            tw.WriteAttributeString("oMerchantID", tbMerchantID.Text);
            tw.WriteAttributeString("oMarketplaceID", tbMarketplaceID.Text);

            tw.WriteAttributeString("oHalfDotComToken", tbHalfToken.Text);

            tw.WriteAttributeString("oSortOverride", cbSortOverride.Checked ? "true" : "false");
            tw.WriteAttributeString("oSortAsc", rbSortAsc.Checked ? "true" : "false");
            tw.WriteAttributeString("oSortDsc", rbSortDsc.Checked ? "true" : "false");
            tw.WriteAttributeString("oAllowAddUpdate", cbAllowAddUpdate.Checked ? "true" : "false");  //  added 11.7
            tw.WriteAttributeString("oUseReceipt", cbUseReceipt.Checked ? "true" : "false");
            tw.WriteEndElement();

            // tab sequences...
            tw.WriteStartElement("tabSettings");
            tw.WriteAttributeString("oISBNSeq", mtbISBN.TabIndex.ToString());
            tw.WriteAttributeString("oQtySeq", tbCopies.TabIndex.ToString());
            tw.WriteAttributeString("oLocSeq", tbLocn.TabIndex.ToString());
            tw.WriteAttributeString("oSKUSeq", tbBookNbr.TabIndex.ToString());
            tw.WriteAttributeString("oCostSeq", tbMyCost.TabIndex.ToString());
            tw.WriteAttributeString("oPriceSeq", tbListPrice.TabIndex.ToString());
            tw.WriteAttributeString("oRePriceSeq", cbDoNotReprice.TabIndex.ToString());
            tw.WriteAttributeString("oTitleSeq", tbTitle.TabIndex.ToString());
            tw.WriteAttributeString("oAuthorSeq", tbAuthor.TabIndex.ToString());
            tw.WriteAttributeString("oASignedSeq", tbIllus.TabIndex.ToString());
            tw.WriteAttributeString("oIllusSeq", cbAuthorSigned.TabIndex.ToString());
            tw.WriteAttributeString("oISignedSeq", cbIllusSigned.TabIndex.ToString());
            tw.WriteAttributeString("oPubSeq", tbPub.TabIndex.ToString());
            tw.WriteAttributeString("oPlaceSeq", tbPlace.TabIndex.ToString());
            tw.WriteAttributeString("oYearSeq", tbYear.TabIndex.ToString());
            tw.WriteAttributeString("oDescSeq", tbDesc.TabIndex.ToString());
            tw.WriteAttributeString("oCannedSeq", lbCannedText.TabIndex.ToString());
            tw.WriteAttributeString("oBindingSeq", coBinding.TabIndex.ToString());
            tw.WriteAttributeString("oCondSeq", coCondition.TabIndex.ToString());
            tw.WriteAttributeString("oJacketSeq", coJacket.TabIndex.ToString());
            tw.WriteAttributeString("oEdSeq", coEdition.TabIndex.ToString());
            tw.WriteAttributeString("oPagesSeq", tbPages.TabIndex.ToString());
            tw.WriteAttributeString("oWtSeq", tbWeight.TabIndex.ToString());
            tw.WriteAttributeString("oTypeSeq", coType.TabIndex.ToString());
            tw.WriteAttributeString("oSizeSeq", coSize.TabIndex.ToString());
            tw.WriteAttributeString("oPriSeq", tbPriCatalog.TabIndex.ToString());
            tw.WriteAttributeString("oSecSeq", tbSecCatalog.TabIndex.ToString());
            tw.WriteAttributeString("oKeySeq", tbKeywords.TabIndex.ToString());
            tw.WriteEndElement();

            //  upload selections...
            tw.WriteStartElement("UploadSelections");
            tw.WriteAttributeString("uAmazon", cbUploadAmazon.Checked == true && tbMarketplaceID.Text.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uAmazonUK", cbUploadAmazonUK.Checked == true && tbMarketplaceID.Text.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uABE", cbUploadABE.Checked == true && ABEUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uAlibris", cbUploadAlibris.Checked == true && AlibrisUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uAntiqBook", cbUploadAntiqBook.Checked == true && AntiqBookUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uBiblio", cbUploadBiblio.Checked == true && BiblioUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uBibliology", cbUploadBandN.Checked == true && BandNUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uBiblion", cbUploadBiblion.Checked == true && BiblionUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uBibliophile", cbUploadBibliophile.Checked == true && BibliophileUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uBandN", cbUploadBandN.Checked == true && BandNUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uPapaMedia", cbUploadPapaMedia.Checked == true && PapaMediaUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uScribblemonger", cbUploadScribblemonger.Checked == true && ScribblemongerUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uBookByte", cbUploadBookByte.Checked == true && BookByteUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uHalfDotCom", cbUploadHalfDotCom.Checked == true && HalfDotComUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uChooseBooks", cbUploadChooseBks.Checked == true && ChooseUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uChrislands", cbUploadChrislands.Checked == true && ChrislandsUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uGoogleBase", cbUploadGoogleBase.Checked == true && GoogleUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uTomFolio", cbUploadTomFolio.Checked == true && TomFolioUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uValore", cbUploadValoreBooks.Checked == true && ValoreUID.Length > 0 ? "true" : "false");
            tw.WriteAttributeString("uCS1", cbUploadCS1.Checked == true ? "true" : "false");
            tw.WriteAttributeString("uCS2", cbUploadCS2.Checked == true ? "true" : "false");
            tw.WriteAttributeString("uCS3", cbUploadCS3.Checked == true ? "true" : "false");
            tw.WriteAttributeString("uCS4", cbUploadCS4.Checked == true ? "true" : "false");
            tw.WriteAttributeString("BiblioUIEE", BiblioUIEE ? "true" : "false");
            tw.WriteAttributeString("ABETab", ABETab ? "true" : "false");
            tw.WriteAttributeString("BibliophileUIEE", BibliophileUIEE ? "true" : "false");
            tw.WriteAttributeString("UsedBookCentralUIEE", UsedBookCentralUIEE ? "true" : "false");
            tw.WriteAttributeString("BiblionUIEE", BiblionUIEE ? "true" : "false");
            tw.WriteAttributeString("BibliologyUIEE", BibliologyUIEE ? "true" : "false");
            tw.WriteEndElement();

            //  repricing selections...
            tw.WriteStartElement("RepricingSelections");
            tw.WriteAttributeString("highByAmt", tbHighByAmt.Text);
            tw.WriteAttributeString("whatPriceH", lbWhatPriceH.SelectedIndex.ToString());
            tw.WriteAttributeString("lowByAmt", tbLowByAmt.Text);
            tw.WriteAttributeString("whatPriceL", lbWhatPriceL.SelectedIndex.ToString());
            tw.WriteAttributeString("newByAmt", tbNewByAmt.Text);
            tw.WriteAttributeString("newWhatPrice", lbNewWhatPrice.SelectedIndex.ToString());
            tw.WriteAttributeString("firstPremium", tb1stPremium.Text);
            tw.WriteAttributeString("signedPremium", tbSignedPremium.Text);
            tw.WriteAttributeString("condAmtVG", tbCondAmtVG.Text);
            tw.WriteAttributeString("condAmtG", tbCondAmtG.Text);
            tw.WriteAttributeString("condAmtP", tbCondAmtP.Text);
            tw.WriteAttributeString("belowMyCostOr", tbBelowMyCostOr.Text);
            tw.WriteAttributeString("discardBelowAmt", tbDiscardBelowAmt.Text);
            tw.WriteAttributeString("discardAboveAmt", tbDiscardAboveAmt.Text);
            tw.WriteAttributeString("priceLowPct", rbPriceLowPct.Checked == true ? "true" : "false");
            tw.WriteAttributeString("greaterSugg", cbGreaterSugg.Checked == true ? "true" : "false");
            tw.WriteAttributeString("lessSugg", cbLessSugg.Checked == true ? "true" : "false");
            tw.WriteAttributeString("highBelow", rbHighBelow.Checked == true ? "true" : "false");
            tw.WriteAttributeString("priceHighPct", rbPriceHighPct.Checked == true ? "true" : "false");
            tw.WriteAttributeString("lowBelow", rbLowBelow.Checked == true ? "true" : "false");
            tw.WriteAttributeString("dontGoBelowCost", cbDontGoBelowCost.Checked == true ? "true" : "false");
            tw.WriteAttributeString("priceNewPct", rbPriceNewPct.Checked == true ? "true" : "false");
            tw.WriteAttributeString("adjustPostage", cbAdjustPostage.Checked == true ? "true" : "false");
            tw.WriteEndElement();

            //  book conditions
            tw.WriteStartElement("BookConditions");
            tw.WriteAttributeString("Amazon", rbUseAmazonCond.Checked == true ? "true" : "false");
            tw.WriteAttributeString("Generic", rbUseGenericCond.Checked == true ? "true" : "false");
            tw.WriteAttributeString("Custom", rbUseCustomCond.Checked == true ? "true" : "false");

            if (rbUseCustomCond.Checked) {
                int lineCount = tbcustomCondition.Lines.Where(line => !String.IsNullOrWhiteSpace(line)).Count();
                tw.WriteAttributeString("CustomCount", lineCount.ToString());  // save count of items
                for (int i = 0; i < lineCount; i++) {  //  save the items
                    tw.WriteAttributeString("item" + i.ToString(), tbcustomCondition.Lines[i]);
                }
            }
            tw.WriteEndElement();


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
            //tw.WriteAttributeString("NetworkedClient", networkedClient ? "true" : "false");

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

            //  now, save last export date
            if (!lastExport.ToString().Contains("01/01/0001") && !lastExport.ToString().Contains("1/1/0001"))
                dateTimePicker1.Value = lastExport;  //  set to date last exported
            else {
                dateTimePicker1.Value = installedDate;  //  just so we have something
                lastExport = installedDate;
            }

            //  now, save the Amazon keys to tAZUID table
            string updateString = "UPDATE tAZUID SET MWSMerchantID = '" + tbMerchantID.Text + "', " +
            " MWSMarketplaceID = '" + tbMarketplaceID.Text + "', " +
            " AWSAccessKey = '" + tbAWSKey.Text + "', " +
            " AWSSecretKey = '" + tbAWSSecretKey.Text + "', " +
            " AWSAssocTag = '" + tbAZAssocTag.Text + "' ROWS 1";
            sqlCmd = new FbCommand(updateString, bookConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                MessageBox.Show("Error adding Amazon IDs: " + e.Message, "Prager, Media Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //  save options in tOptions table
            string updateCmd = "UPDATE tOptions SET " +
                "tDateLastExported = '" + lastExport.ToString("yyyy-MM-dd HH:mm:ss", localCulture) +
                "', tBackupToPath = '" + backupPath +
                "', tBackupRetention = '" + daysRetention + "' ROWS 1";

            FbCommand updtCmd = new FbCommand(updateCmd);
            updtCmd.Connection = new FbConnection("User=prager;Password=books;Database=" + dbPath);
            try {
                if (updtCmd.Connection.State == ConnectionState.Closed)  //  <--------------- causes crash!!
                    updtCmd.Connection.Open();

                updtCmd.ExecuteNonQuery();
                updtCmd.Connection.Close();
            }
            catch (FbException ex) {
                MessageBox.Show("410 - error saving Options: \n" + ex.Message + "\n" + ex.StackTrace, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbStatus.Items.Insert(0, "-->error saving Options");
                lbStatus.Refresh();
            }

            lbStatus.Items.Insert(0, "Options saved");
            lbStatus.Refresh();
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++
        //--  check installation date                        
        //+++++++++++++++++++++++++++++++++++++++++++++++
        public int checkInstallationDate() {
            //string todaysDate = DateTime.Today.ToString("d", localCulture);
            DateTime todaysDate = DateTime.Now;
            string[] dateComponents = todaysDate.ToString(localCulture).Split(' ');

            if (lastExport.Equals(DateTime.MinValue))  //  if lastExport date is missing, make it today...
                lastExport = DateTime.Today.Subtract(TimeSpan.FromDays(1));

            //string updateString = "INSERT INTO tOptions (tInstallDate) values (CURRENT_DATE)";
            string updateString = "UPDATE tOptions SET tInstallDate = CURRENT_DATE ROWS 1";
            commandString = "select tInstallDate from tOptions";

            FbDataReader rdr = null;

            try { //  initial open of Firebird database
                if (bookConn.State == ConnectionState.Closed)
                    bookConn.Open();
            }
            catch (Exception ex) {
                if (ex.Message.Contains("unsupported on-disk structure for file"))
                    MessageBox.Show("You have a conflict in Firebird versions; please contact support@pragersoftware.com for assistance", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Firebird open error: " + ex.Message + "  please contact support@pragersoftware.com for assistance", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);

                fTrace("E - 1139: " + ex.Message.Substring(0, 50));
                return -1;
            }

            FbCommand cmd = new FbCommand(commandString, bookConn);
            rdr = cmd.ExecuteReader();

            if (!rdr.Read() || rdr.IsDBNull(0)) {  //  if installDate is missing, then this is the first time...
                fTrace("I - installation date missing (first time)");
                cmd = new FbCommand(updateString);
                cmd.Connection = bookConn;
                cmd.ExecuteNonQuery();  //  update installation date

                fTrace("I - going to fillUPloadInfoTable");
                fillUploadInfoTable();  //  first time, fill UID and Password table
            }
            else
                installedDate = (DateTime)rdr[0];

            rdr.Close();

            return 0;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++
        //--  save mapping of import fields
        //+++++++++++++++++++++++++++++++++++++++++++++++
        public void saveMapping() {

            Cursor.Current = Cursors.WaitCursor;
            //  string filename = System.AppDomain.CurrentDomain.BaseDirectory + "prager.tabSettings.xml";

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

            string xmlFilename = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Prager\prager.tabSettings.xml";

            XmlTextWriter tw = new XmlTextWriter(xmlFilename, null);  //null represents the Encoding Type
            tw.Formatting = Formatting.Indented;  //for xml tags to be indented
            tw.WriteStartDocument();   //Indicates the starting of document (Required)
            tw.WriteStartElement("ImportTabSettings");

            //  check for BT, which is constant
            if (rbImportBT.Checked) {
                tw.WriteAttributeString("MapBookNbr", "Book_ID");
                tw.WriteAttributeString("MapAuthor", "Author");
                tw.WriteAttributeString("MapTitle", "Title");
                tw.WriteAttributeString("MapIllus", "Illustrator");
                tw.WriteAttributeString("MapPublisher", "Publisher");
                tw.WriteAttributeString("MapDesc", "Description");
                tw.WriteAttributeString("MapPrice", "Retail_Price");
                tw.WriteAttributeString("MapBinding", "Binding");
                tw.WriteAttributeString("MapEdition", "Edition");
                tw.WriteAttributeString("MapCost", "Cost");
                tw.WriteAttributeString("MapYearPub", "Date");
                tw.WriteAttributeString("MapBookSize", "Size");
                tw.WriteAttributeString("MapDateSold", "DateSold");
                tw.WriteAttributeString("MapISBN", "ISBN");
                tw.WriteAttributeString("MapDJCond", "DJ");
                tw.WriteAttributeString("MapBookCond", "Condition");
                tw.WriteAttributeString("MapPubLoc", "Place");
                tw.WriteAttributeString("MapShipExp", "Expedite");
                tw.WriteAttributeString("MapShipIntl", "International");
                tw.WriteAttributeString("MapPages", "Pages");
                tw.WriteAttributeString("MapPrivateNotes", "Notes");
                tw.WriteAttributeString("MapLocation", "Location");
                tw.WriteAttributeString("MapQuantity", "Quantity");
                tw.WriteAttributeString("MapWeight", "Weight");
                tw.WriteAttributeString("MapAddTitle", "Subtitle");
                tw.WriteAttributeString("MapStatus", "Status");
            }
            else {
                tw.WriteAttributeString("AddDesc1", tbMapAddTitle.Text);
                tw.WriteAttributeString("AddDesc2", tbMapAddDesc2.Text);
                tw.WriteAttributeString("AddDesc3", tbMapAddDesc3.Text);
                tw.WriteAttributeString("MapQuantity", tbNbrOfCopies.Text);
                tw.WriteAttributeString("AddNotes2", tbMapWeight.Text);
                tw.WriteAttributeString("MapAuthor", tbMapAuthor.Text);
                tw.WriteAttributeString("MapBinding", tbMapBinding.Text);
                tw.WriteAttributeString("MapBookCond", tbMapBookCond.Text);
                tw.WriteAttributeString("MapBookNbr", tbMapBookNbr.Text);
                tw.WriteAttributeString("MapBookSize", tbMapBookSize.Text);
                tw.WriteAttributeString("MapCatalog", tbMapCatalog.Text);
                tw.WriteAttributeString("MapCost", tbMapCost.Text);
                tw.WriteAttributeString("MapDateSold", tbMapDateSold.Text);
                tw.WriteAttributeString("MapDesc", tbMapDesc.Text);
                tw.WriteAttributeString("MapDJCond", tbMapDJCond.Text);
                tw.WriteAttributeString("MapEdition", tbMapEdition.Text);
                tw.WriteAttributeString("MapIllus", tbMapIllus.Text);
                tw.WriteAttributeString("MapISBN", tbMapISBN.Text);
                tw.WriteAttributeString("MapKeywords", tbMapKeywords.Text);
                tw.WriteAttributeString("MapPrice", tbMapPrice.Text);
                tw.WriteAttributeString("MapPrivateNotes", tbMapPrivateNotes.Text);
                tw.WriteAttributeString("MapPublisher", tbMapPublisher.Text);
                tw.WriteAttributeString("MapPubLoc", tbMapPubLoc.Text);
                tw.WriteAttributeString("MapSignedAuthor", tbMapSignedAuthor.Text);
                tw.WriteAttributeString("MapSignedIllus", tbMapSignedIllus.Text);
                tw.WriteAttributeString("MapPages", tbMapNbrPages.Text);
                tw.WriteAttributeString("MapTitle", tbMapTitle.Text);
                tw.WriteAttributeString("MapType", tbMapType.Text);
                tw.WriteAttributeString("MapLocation", tbMapLocation.Text);
                tw.WriteAttributeString("MapYearPub", tbMapYearPub.Text);
                tw.WriteAttributeString("MapShipExp", tbExpedited.Text);
                tw.WriteAttributeString("MapShipIntl", tbInternational.Text);
                tw.WriteAttributeString("MapStatus", tbMapStatus.Text);
            }

            tw.WriteEndElement();
            tw.WriteEndDocument();
            tw.Flush();
            tw.Close();
            //File.SetAttributes(filename, FileAttributes.Hidden);

            lOptionsSaved.Visible = true;  //  display message...

            Cursor.Current = Cursors.Default;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++
        //--  restore mapping
        //+++++++++++++++++++++++++++++++++++++++++++++++
        public void restoreMapping() {

            Cursor.Current = Cursors.WaitCursor;
            //string xmlFilename = System.AppDomain.CurrentDomain.BaseDirectory + "prager.tabSettings.xml";
            string xmlFilename = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Prager\prager.tabSettings.xml";
            if (!File.Exists(xmlFilename))   //  is it in the new directory?
                xmlFilename = System.AppDomain.CurrentDomain.BaseDirectory + "prager.tabSettings.xml";  //  use the last one...

            if (File.Exists(xmlFilename)) {
                XmlTextReader tr = new XmlTextReader(xmlFilename);

                tr.Read();

                while (tr.Read())  // If the node has value
                {
                    tr.MoveToElement();  // Move to fist element

                    tbMapAddTitle.Text = tr.GetAttribute("AddDesc1");
                    tbMapAddDesc2.Text = tr.GetAttribute("AddDesc2");
                    tbMapAddDesc3.Text = tr.GetAttribute("AddDesc3");
                    tbNbrOfCopies.Text = tr.GetAttribute("MapQuantity");
                    tbMapWeight.Text = tr.GetAttribute("AddNotes2");
                    tbMapAuthor.Text = tr.GetAttribute("MapAuthor");
                    tbMapBinding.Text = tr.GetAttribute("MapBinding");
                    tbMapBookCond.Text = tr.GetAttribute("MapBookCond");
                    tbMapBookNbr.Text = tr.GetAttribute("MapBookNbr");
                    tbMapBookSize.Text = tr.GetAttribute("MapBookSize");
                    tbMapCatalog.Text = tr.GetAttribute("MapCatalog");
                    tbMapCost.Text = tr.GetAttribute("MapCost");
                    tbMapDateSold.Text = tr.GetAttribute("MapDateSold");
                    tbMapDesc.Text = tr.GetAttribute("MapDesc");
                    tbMapDJCond.Text = tr.GetAttribute("MapDJCond");
                    tbMapEdition.Text = tr.GetAttribute("MapEdition");
                    tbMapIllus.Text = tr.GetAttribute("MapIllus");
                    tbMapISBN.Text = tr.GetAttribute("MapISBN");
                    tbMapKeywords.Text = tr.GetAttribute("MapKeywords");
                    tbMapPrice.Text = tr.GetAttribute("MapPrice");
                    tbMapPrivateNotes.Text = tr.GetAttribute("MapPrivateNotes");
                    tbMapPublisher.Text = tr.GetAttribute("MapPublisher");
                    tbMapPubLoc.Text = tr.GetAttribute("MapPubLoc");
                    tbMapSignedAuthor.Text = tr.GetAttribute("MapSignedAuthor");
                    tbMapSignedIllus.Text = tr.GetAttribute("MapSignedIllus");
                    tbMapNbrPages.Text = tr.GetAttribute("MapPages");
                    tbMapTitle.Text = tr.GetAttribute("MapTitle");
                    tbMapType.Text = tr.GetAttribute("MapType");
                    tbMapLocation.Text = tr.GetAttribute("MapLocation");
                    tbMapYearPub.Text = tr.GetAttribute("MapYearPub");
                    tbInternational.Text = tr.GetAttribute("MapShipIntl");
                    tbExpedited.Text = tr.GetAttribute("MapShipExp");
                    tbMapStatus.Text = tr.GetAttribute("MapStatus");
                }

                tr.Close();
            }
            Cursor.Current = Cursors.Default;
        }



        //+++++++++++++++++++++++++++++++++++++++++++++++
        //-- user has changed a User ID or password
        //+++++++++++++++++++++++++++++++++++++++++++++++
        private void dataGridValueChanged(DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1)
                return;

            DataGridViewRow dataRow = UIDdataGridView.Rows[e.RowIndex];

            switch (dataRow.Cells[0].Value.ToString()) {
                case "Alibris":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    AlibrisUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    AlibrisPwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "ABE":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    ABEUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    ABEPwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "Biblio":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    BiblioUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    BiblioPwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "ChooseBooks(ZVAB)":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    ChooseUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    ChoosePwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "Google":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    GoogleUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    GooglePwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "Antiqbook":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    AntiqBookUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    AntiqBookPwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "Papa Media":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    PapaMediaUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    PapaMediaPwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "Scribblemonger":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    ScribblemongerUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    ScribblemongerPwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "Tom Folio":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    TomFolioUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    TomFolioPwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "Bibliophile":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    BibliophileUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    BibliophilePwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "Half.com":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    HalfDotComUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    HalfDotComPwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "Biblion":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    BiblionUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    BiblionPwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "Valore":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    ValoreUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    ValorePwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "Barnes & Noble":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    BandNUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    BandNPwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "Chrislands":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    ChrislandsUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    ChrislandsPwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "Book Byte":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    BookByteUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    BookBytePwd = dataRow.Cells[2].Value.ToString();
                    break;
                case "A1 Books":
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    A1BooksUID = dataRow.Cells[1].Value.ToString();
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    A1BooksPwd = dataRow.Cells[2].Value.ToString();
                    break;
                default:
                    if (dataRow.Cells[1].Value == null)
                        dataRow.Cells[1].Value = "";
                    if (dataRow.Cells[2].Value == null)
                        dataRow.Cells[2].Value = "";
                    if (dataRow.Cells[3].Value == null)
                        dataRow.Cells[3].Value = "";
                    if (dataRow.Cells[4].Value == null)
                        dataRow.Cells[4].Value = "";
                    if (dataRow.Cells[5].Value == null)
                        dataRow.Cells[5].Value = "";
                    break;
            }
        }
    }
}

