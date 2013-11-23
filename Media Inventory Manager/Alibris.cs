#define COMPILED4OTHERS
//#define EXPORTTESTING  //  TESTING ONLY  <-----------------

using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Media_Inventory_Manager
{

    public class AlibrisExport
    {
        TextWriter tw1;

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create Alibris movie format file (tab-delimited)
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int createAlibrisMovieFormat(mainForm mf, string formattedDate, string exportPath, FbConnection mediaConn) {

            Cursor.Current = Cursors.WaitCursor;

            if (mf.rbExportAll.Checked == false && mf.rbChangeDate.Checked == false && mf.rbExportInclusiveSearch.Checked == false &&
                mf.rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            string sFileName1 = "";
            if (mf.cbPurgeReplace.Checked == true)  //  doing a purge/replace?
                sFileName1 = exportPath + "purgeALVi" + formattedDate + ".tab";
            else  //  no just exporting those that were changed
                sFileName1 = exportPath + "ALVi" + formattedDate + ".tab";

            try {
                tw1 = new StreamWriter(sFileName1);  //  for normal tab-delimited files
            }
            catch (Exception e) {
                if (e.ToString().Substring(10, 26) == "DirectoryNotFoundException") {
                    try {
                        DirectoryInfo di = Directory.CreateDirectory(exportPath);   // Try to create the directory
                        tw1 = new StreamWriter(sFileName1);
                    }
                    catch (Exception e1) {
                        MessageBox.Show("Unable to create export directory: " + e1.Message, "Prager Media Inventory Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }

            //  find items in table
            FbCommand command = new FbCommand(mf.createExportCommandString(), mediaConn);
            FbDataReader data = command.ExecuteReader();

            int count = 0;
            mf.lbUploadStatus.Items.Insert(0, "Alibris video export started");
            mf.lbUploadStatus.Refresh();

            //  write header
            tw1.WriteLine("UPC\tSKU\tTitle\tReleaseYear\tPrice\tItemCondition\tCoverCondn\tEdition\tNbrOfDisks\t" +
                "ReleaseDate\tKeywords\tDescription\tStatus\tQuantity\tImageURL\tPrivateNotes\tCost\tLocn\t" +
                "Actors\tDirector\tVideoFormat\tDVDRegion\tScreenFormat\tMPAARating\tStudio\tLanguage\t");  //  movie specific

            while (data.Read()) {

                //  bomb-proof it...
                if (data["UPC"] == DBNull.Value || data["SKU"] == DBNull.Value || data["Title"] == DBNull.Value ||
                    data["Price"] == DBNull.Value || data["Condn"] == DBNull.Value || data["VideoFormat"] == DBNull.Value) {
                    MessageBox.Show("Record SKU:" + data["SKU"].ToString() + " is missing required fields; not exported", "Prager Media Inventory Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                mf.tbSKU.Text = data["SKU"].ToString();  //  for debugging purposes only!

                if (mf.cbPurgeReplace.Checked == true && data["Stat"].ToString() == "Sold")
                    continue;  //  if purge/replace and Sold, don't upload

                if (data["Stat"].ToString() == "Hold")
                    continue;  //  don't export

                buildAlibrisMovieFile(data);

                count++;  //  increment counter
            }

            tw1.Close();  //  close the stream

            if (data != null)  //  close the data reader
                data.Close();

            Cursor.Current = Cursors.Default;

            mf.lbUploadStatus.Items.Insert(0, "Alibris video export completed: " + count + " items exported to file " + sFileName1);
            mf.lbUploadStatus.Refresh();

            return 0;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    build a TAB delimited movie file
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void buildAlibrisMovieFile(FbDataReader data) {

            string dataBuild;
            dataBuild = data["UPC"].ToString() + "\t";  //  UPC
            dataBuild += data["SKU"].ToString() + "\t";  //  SKU
            dataBuild += data["Title"].ToString() + "\t";  //  title

            if (data["MfgrYear"] != DBNull.Value)
                dataBuild += data["MfgrYear"] + "\t";  //  release year
            else
                dataBuild += " \t";

            dataBuild += data["Price"] + "\t";  //  price
            
            dataBuild += data["Condn"] + "\t";  //  item condition

            dataBuild += "\t";  //  cover condition

            if (data["Edition"] != DBNull.Value)
                dataBuild += data["Edition"] + "\t";  //  edition
            else
                dataBuild += " \t";

            if (data["NbrOfDisks"] != DBNull.Value)
                dataBuild += data["NbrOfDisks"] + "\t";  //  number of disks
            else
                dataBuild += " \t";

            if (data["MfgrYear"] != DBNull.Value)
                dataBuild += "01/01" + data["MfgrYear"] + "\t";  //  release date
            else
                dataBuild += " \t";

            if (data["VideoKeywords"] != DBNull.Value)
                dataBuild += data["VideoKeywords"].ToString() + "\t";  //  keywords
            else
                dataBuild += " \t";

            if (data["Descr"] != DBNull.Value)
                dataBuild += data["Descr"].ToString() + "\t";  //  description
            else
                dataBuild += " \t";

            if (data["Stat"] != DBNull.Value)
                dataBuild += data["Stat"].ToString() + "\t";  //  status  <------------------ VErify
            else
                dataBuild += " \t";

            dataBuild += data["Quantity"] + "\t";  //  quantity

            if (data["ImageURL"] != DBNull.Value)
                dataBuild += data["ImageURL"].ToString() + "\t";  //  image url
            else
                dataBuild += " \t";

            dataBuild += "\t";  //  private notes

            dataBuild += data["Cost"].ToString() + "\t";  //  cost
            
            dataBuild += "\t";  //  location

            //  video specifics start here...
            if (data["Actors"] != DBNull.Value)
                dataBuild += data["Actors"].ToString() + "\t";  // actors 
            else
                dataBuild += " \t";

            if (data["Director"] != DBNull.Value)
                dataBuild += data["Director"].ToString() + "\t";  // director 
            else
                dataBuild += " \t";

            if (data["VideoFormat"] != DBNull.Value)
                dataBuild += data["VideoFormat"].ToString() + "\t";  // video format
            else
                dataBuild += " \t";

            if (data["MPAARating"] != DBNull.Value)
                dataBuild += data["MPAARating"].ToString() + "\t";  // MPAA Rating
            else
                dataBuild += " \t";

            if (data["MFGR"] != DBNull.Value)
                dataBuild += data["MFGR"].ToString() + "\t";  // studio
            else
                dataBuild += " \t";

            if (data["Language"] != DBNull.Value)
                dataBuild += data["Language"].ToString() + "\t";  // language
            else
                dataBuild += " \t";

            tw1.WriteLine(dataBuild);
            return;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--   create Alibris music format file
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int createAlibrisMusicFormat(mainForm mf, string formattedDate, string exportPath, FbConnection mediaConn) {

            Cursor.Current = Cursors.WaitCursor;

            if (mf.rbExportAll.Checked == false && mf.rbChangeDate.Checked == false && mf.rbExportInclusiveSearch.Checked == false &&
                mf.rbExportSelected.Checked == false) {
                MessageBox.Show("You must choose 'All' or 'Changed since' for Export", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            string sFileName1 = "";
            if (mf.cbPurgeReplace.Checked == true)  //  doing a purge/replace?
                sFileName1 = exportPath + "purgeALMu" + formattedDate + ".tab";
            else  //  no just exporting those that were changed
                sFileName1 = exportPath + "ALMu" + formattedDate + ".tab";

            try {
                tw1 = new StreamWriter(sFileName1);  //  for normal tab-delimited files
            }
            catch (Exception e) {
                if (e.ToString().Substring(10, 26) == "DirectoryNotFoundException") {
                    try {
                        DirectoryInfo di = Directory.CreateDirectory(exportPath);   // Try to create the directory
                        tw1 = new StreamWriter(sFileName1);
                    }
                    catch (Exception e1) {
                        MessageBox.Show("Unable to create export directory: " + e1.Message, "Prager Media Inventory Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }

            //  find items in table
            FbCommand command = new FbCommand(mf.createExportCommandString(), mediaConn);
            FbDataReader data = command.ExecuteReader();

            int count = 0;
            mf.lbUploadStatus.Items.Insert(0, "Alibris music export started");
            mf.lbUploadStatus.Refresh();

            //  write header
            tw1.WriteLine("UPC\tSKU\tTitle\tReleaseYear\tPrice\tItemCondition\tCoverCondn\tEdition\tNbrOfDisks\t" +
                "ReleaseDate\tAudioKeywords\tDescription\tStatus\tQuantity\tImageURL\tPrivateNotes\tCost\tLocn\t" +
                "Artist\tCatalogNbr\tOrchestra\tMusicFormat\tAdultContent\tRecordLabel\t");  //  music specific

            while (data.Read()) {

                //  bomb-proof it...
                if (data["UPC"] == DBNull.Value || data["SKU"] == DBNull.Value || data["Title"] == DBNull.Value ||
                    data["Price"] == DBNull.Value || data["Condn"] == DBNull.Value || data["AudioFormat"] == DBNull.Value ||
                    data["Artist"] == DBNull.Value)  {
                    MessageBox.Show("Record SKU:" + data["SKU"].ToString() + " is missing required fields; not exported", "Prager Media Inventory Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                mf.tbSKU.Text = data["SKU"].ToString();  //  for debugging purposes only!

                if (mf.cbPurgeReplace.Checked == true && data["Stat"].ToString() == "Sold")
                    continue;  //  if purge/replace and Sold, don't upload

                if (data["Stat"].ToString() == "Hold")
                    continue;  //  don't export

                buildAlibrisMusicFile(data);

                count++;  //  increment counter
            }

            tw1.Close();  //  close the stream

            if (data != null)  //  close the data reader
                data.Close();

            Cursor.Current = Cursors.Default;

            mf.lbUploadStatus.Items.Insert(0, "Alibris music export completed: " + count + " items exported to file " + sFileName1);
            mf.lbUploadStatus.Refresh();

            return 0;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    build a TAB delimited music file
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void buildAlibrisMusicFile(FbDataReader data) {
            string dataBuild;
            dataBuild = data["UPC"].ToString() + "\t";  //  UPC
            dataBuild += data["SKU"].ToString() + "\t";  //  SKU
            dataBuild += data["Title"].ToString() + "\t";  //  title

            if (data["MfgrYear"] != DBNull.Value)
                dataBuild += data["MfgrYear"] + "\t";  //  release year
            else
                dataBuild += " \t";

            dataBuild += data["Price"] + "\t";  //  price
            dataBuild += data["Condn"] + "\t";  //  item condition

            dataBuild += "\t";  //  cover condition

            if (data["Edition"] != DBNull.Value)
                dataBuild += data["Edition"] + "\t";  //  edition
            else
                dataBuild += " \t";

            if (data["NbrOfDisks"] != DBNull.Value)
                dataBuild += data["NbrOfDisks"] + "\t";  //  number of disks
            else
                dataBuild += " \t";

            if (data["MfgrYear"] != DBNull.Value)
                dataBuild += "01/01" + data["MfgrYear"] + "\t";  //  release date
            else
                dataBuild += " \t";

            if (data["AudioKeywords"] != DBNull.Value)
                dataBuild += data["AudioKeywords"].ToString() + "\t";  //  keywords
            else
                dataBuild += " \t";

            if (data["Descr"] != DBNull.Value)
                dataBuild += data["Descr"].ToString() + "\t";  //  description
            else
                dataBuild += " \t";

            if (data["Stat"] != DBNull.Value)
                dataBuild += data["Stat"].ToString() + "\t";  //  status  <--------------------- verify
            else
                dataBuild += " \t";

            dataBuild += data["Quantity"] + "\t";  //  quantity

            if (data["ImageURL"] != DBNull.Value)
                dataBuild += data["ImageURL"].ToString() + "\t";  //  image url
            else
                dataBuild += " \t";

            dataBuild += "\t";  //  private notes

            dataBuild += data["Cost"].ToString() + "\t";  //  cost

            dataBuild += "\t";  //  location

            //  music specifics start here...
            if (data["Artist"] != DBNull.Value)
                dataBuild += data["Artist"].ToString() + "\t";  // artist
            else
                dataBuild += " \t";

            if (data["CatalogID"] != DBNull.Value)
                dataBuild += data["CatalogID"].ToString() + "\t";  // catalog number
            else
                dataBuild += " \t";

            if (data["Orchestra"] != DBNull.Value)
                dataBuild += data["Orchestra"].ToString() + "\t";  // orchestra
            else
                dataBuild += " \t";

            if (data["AudioFormat"] != DBNull.Value)
                dataBuild += data["AudioFormat"].ToString() + "\t";  // music format
            else
                dataBuild += " \t";

            if (data["AdultContent"] != DBNull.Value)
                dataBuild += data["AdultContent"].ToString() + "\t";  //  adult content  <--------------- Verify
            else
                dataBuild += " \t";

            if (data["MFGR"] != DBNull.Value)
                dataBuild += data["MFGR"].ToString() + "\t";  // record label
            else
                dataBuild += " \t";

            tw1.WriteLine(dataBuild);
            return;
        }

        //Regex r;
        //Match m;

        ////  common
        //public static string UPC;
        //public static string SKU;
        //public static string Title;
        //public static string ReleaseYear;
        //public static string Price;
        //public static string ItemCondition;
        //public static string CoverCondn;
        //public static string Edition;
        //public static string NbrOfDisks;
        //public static string ReleaseDate;
        //public static string Keywords;
        //public static string Description;
        //public static string Status;
        //public static int Quantity;
        //public static string ImageURL;
        //public static string PrivateNotes;
        //public static string Cost;
        //public static string Locn;

        ////  movie specific
        //public static string Actors;
        //public static string Director;
        //public static string VideoFormat;
        //public static string DVDRegion;
        //public static string ScreenFormat;
        //public static string MPAARating;
        //public static string Studio;
        //public static string Language;


        ////  music specific
        //public static string Artist;
        //public static string CatalogNbr;
        //public static string Orchestra;
        //public static string MusicFormat;
        //public static string AdultContent;
        //public static string RecordLabel;



        //// ------------------------    reset strings    ----------------------]
        //void resetStrings() {

        //    UPC = "";
        //    SKU = "";
        //    Title = "";
        //    ReleaseYear = "";
        //    Price = "";
        //    ItemCondition = "";
        //    CoverCondn = "";
        //    Edition = "";
        //    NbrOfDisks = "";
        //    ReleaseDate = "";
        //    Keywords = "";
        //    Description = "";
        //    Status = "";
        //    Quantity = 0;
        //    ImageURL = "";
        //    PrivateNotes = "";
        //    Cost = "";
        //    Locn = "";

        //    //  movie specific
        //    Actors = "";
        //    Director = "";
        //    VideoFormat = "";
        //    DVDRegion = "";
        //    ScreenFormat = "";
        //    MPAARating = "";
        //    Studio = "";
        //    Language = "";


        //    //  music specific
        //    Artist = "";
        //    CatalogNbr = "";
        //    Orchestra = "";
        //    MusicFormat = "";
        //    AdultContent = "";
        //    RecordLabel = "";
        //}

    }
}

