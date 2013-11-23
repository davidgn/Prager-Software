#region Using directive
using System;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Text.RegularExpressions;
using System.Globalization;
#endregion

namespace Media_Inventory_Manager
{
    class importTabDelimitedFiles
    {

        internal int SKUIndex = -1;
        internal int ASINIndex = -1;
        internal int UPCIndex = -1;
        internal int itemNotesIndex = -1;
        internal int qtyIndex = -1;
        internal int expeditedIndex = -1;
        internal int internationalIndex = -1;
        internal int conditionIndex = -1;
        internal int costIndex = -1;
        internal int dateSoldIndex = -1;
        internal int descIndex = -1;
        internal int ProductIDIndex = -1;
        internal int priceIndex = -1;
        internal int titleIndex = -1;
        internal int typeIndex = -1;

        static int rejectedCount = 0;

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    read the file to import
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        static int count = 0;
        public void convertFile(mainForm mf, string sFileName, Label recordsProcessed, ListBox lbMappingNames, Label recordsRejected, ListBox rejectedRecs,
            RadioButton rbMarkAsSold, RadioButton rbReplaceRecords, RadioButton rbImportAZ) {

            string inputRecord;

            FbCommand cmd = new FbCommand();

            //  create stream reader object 
            System.IO.StreamReader sr = new System.IO.StreamReader(sFileName);
            sr.ReadLine();  //  get past the first record which contains the header information

            while ((inputRecord = sr.ReadLine()) != null)  //  read a tab-delimited records
            {
                int rc = createDatabaseElements(mf, inputRecord, cmd, lbMappingNames, recordsRejected, rejectedRecs, rbMarkAsSold, rbReplaceRecords, rbImportAZ);  //  create data for insert into database
                recordsProcessed.Text = "Records Processed: " + ++count;
                recordsProcessed.Refresh();

                if (rc == -1) {
                    recordsRejected.Text = "Records Rejected: " + ++rejectedCount;
                    recordsRejected.Refresh();
                }

                Application.DoEvents();

            }

            sr.Close();  //  close the stream reader
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    createDatabaseElements from file to import
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private int createDatabaseElements(mainForm mf, string inputRecord, FbCommand cmd, ListBox lbMappingNames, Label recordsRejected, ListBox rejRecords,
            RadioButton rbMarkAsSold, RadioButton rbReplaceRecords, RadioButton rbImportAZ) {

            string[] delimitedData = inputRecord.Split('\t');  //  now split each record into elements

            //  find out how many valid elements are in the Tab Mapping cells
            if (lbMappingNames.Items.Count != delimitedData.Length && rbImportAZ.Checked == false) {
                rejRecords.Items.Add(delimitedData[SKUIndex] + " - Number of fields (" +
                    delimitedData.Length.ToString() + ") does not match header count (" +
                    lbMappingNames.Items.Count.ToString() + ")");
                rejRecords.Refresh();
                return -1;
            }

            //  check to see if this record is for media
            if (!delimitedData[titleIndex].Contains("[Audio CD]") &&
                !delimitedData[titleIndex].Contains("[DVD]") &&
                !delimitedData[titleIndex].Contains("[VHS Tape]")) {
                int bracketIndex = delimitedData[titleIndex].IndexOf("[");
                rejRecords.Items.Add("Invalid media: " + delimitedData[titleIndex].Substring(bracketIndex, 10));
                rejRecords.Refresh();
                return -1;
            }

            //  minimal error checking
            if (delimitedData[SKUIndex].Length == 0) {
                rejRecords.Items.Add("SKU is missing");
                rejRecords.Refresh();
                return -1;
            }

            if (delimitedData[titleIndex].Length == 0) {
                rejRecords.Items.Add(delimitedData[SKUIndex] + " - Title is missing");
                rejRecords.Refresh();
                return -1;
            }

            string[] pricePieces = delimitedData[priceIndex].Split(' ');  //  dig out the price
            pricePieces[0] = pricePieces[0].Replace("\"", "");
            pricePieces[0] = pricePieces[0].Replace("$", "");  //  10.5.0
            if (!mainForm.IsNumeric(pricePieces[0])) {
                rejRecords.Items.Add(delimitedData[SKUIndex] + " - Price is not numeric");
                rejRecords.Refresh();
                return -1;
            }
            if (delimitedData[priceIndex].Length == 0) {
                rejRecords.Items.Add(delimitedData[SKUIndex] + " - Price is missing");
                rejRecords.Refresh();
                return -1;
            }


            //if (rbImportAZ.Checked == false)
            //{
            //    if (delimitedData[bindingIndex].Length == 0)
            //    {
            //        rejRecords.Items.Add(delimitedData[SKUIndex] + " - Binding is missing");
            //        rejRecords.Refresh();
            //        return -1;
            //    }
            //}

            //  work on dates...
            DateTime tempDate = DateTime.Now;
            mainForm.DateAdded = tempDate.ToString("g");
            mainForm.DateAdded = Regex.Replace(mainForm.DateAdded, "AM|PM|a.m.|p.m.", "");
            mainForm.DateUpdated = mainForm.DateAdded;
          
            mainForm.SKU = delimitedData[SKUIndex];  //  SKU

            //  title
            mainForm.Title = delimitedData[titleIndex].Length > 100 ? delimitedData[titleIndex].Substring(0, 100) : delimitedData[titleIndex];

            if (delimitedData[conditionIndex].Length == 0)  //  condition
                mainForm.Condition = "Good";
            else
                mainForm.Condition = delimitedData[conditionIndex].Length > 25 ? delimitedData[conditionIndex].Substring(0, 25) : delimitedData[conditionIndex];

            //if (publisherIndex != -1)
            //    if (delimitedData[publisherIndex].Length == 0)
            //        mainForm.Mfgr = "n/a";
            //    else
            //        mainForm.Mfgr = delimitedData[publisherIndex].Length > 85 ? delimitedData[publisherIndex].Substring(0, 85) : delimitedData[publisherIndex];
            //else
            //    mainForm.Mfgr = "";


            //  UPC (Product ID)
            if (ProductIDIndex == -1 || rbImportAZ.Checked)  //  Amazon does not supply the UPC, must use ASIN 
                mainForm.UPC = "";
            else
                if (!delimitedData[ProductIDIndex].StartsWith("B")) {
                    Regex r = new Regex(@"-\s*");  //  remove dashes and blanks
                    mainForm.UPC = delimitedData[ProductIDIndex].Length > 13 ? delimitedData[ProductIDIndex].Substring(0, 13) : delimitedData[ProductIDIndex];
                    mainForm.UPC = r.Replace(mainForm.UPC, "");
                }

            const byte DomStd = 32;  //  shipping
            //byte DomExp = 16;
            //byte IntlStd = 2;

            //ExpeditedShip = DBNull.Value;  //  set the old fields to null
            //InternationalShip = DBNull.Value;

            mainForm.Shipping = DomStd;  //  this is a given

            //if (expeditedIndex != -1)  //  Domestic expedited shipping 
            //    mainForm.Shipping = delimitedData[expeditedIndex] == "y" ? (byte)mainForm.Shipping & DomExp : mainForm.Shipping;

            //if (internationalIndex != -1)  //  international shipping
            //    mainForm.Shipping = delimitedData[internationalIndex] == "y" ? (byte)mainForm.Shipping & IntlStd : mainForm.Shipping;

            CultureInfo ci = CultureInfo.CurrentCulture;
            NumberFormatInfo nfi = ci.NumberFormat;
            //string Cost = "";
            //string tempSigning = "";

            if (priceIndex == -1)   //  price
                mainForm.Price = "0" + nfi.CurrencyDecimalSeparator.ToString() + "00";
            else
                mainForm.Price = mainForm.IsNumeric(delimitedData[priceIndex]) ? delimitedData[priceIndex] : "0.00";

            if (costIndex == -1)   //  cost
                mainForm.Cost = "0" + nfi.CurrencyDecimalSeparator.ToString() + "00";
            else
                mainForm.Cost = mainForm.IsNumeric(delimitedData[costIndex]) ? delimitedData[costIndex] : "0.00";

            mainForm.MfgrYear = "";
            //if (yearPubIndex != -1)
            //{
            //    if (delimitedData[yearPubIndex].Length == 4)
            //        PubYear = delimitedData[yearPubIndex];
            //    else if (delimitedData[yearPubIndex].Length < 4)
            //        PubYear = DBNull.Value;
            //}

            if (descIndex == -1)  //  description...
                mainForm.Description = "";
            else
                mainForm.Description = delimitedData[descIndex].Length > 500 ? delimitedData[descIndex].Substring(0, 500) : delimitedData[descIndex];

            //  media type (product type)
            if (typeIndex == -1)
                mainForm.MediaType = "";
            else
                mainForm.MediaType = delimitedData[typeIndex].Length > 15 ? delimitedData[typeIndex].Substring(0, 15) : delimitedData[typeIndex];

            ////  status...
            //mainForm.Status = "";  //  initialize
            //if (statusIndex != -1) {
            //    switch (delimitedData[statusIndex]) {
            //        case "Available":
            //        case "In Store":
            //            mainForm.Status = "For Sale";
            //            break;
            //        case "On Hold":
            //        case "Pending":
            //            mainForm.Status = "Hold";
            //            break;
            //        case "Sold":
            //            mainForm.Status = "Sold";
            //            break;
            //        default:
            //            if (qtyIndex != -1 && int.Parse(delimitedData[qtyIndex]) > 0)  //  if user indicated they have copies
            //                mainForm.Status = "For Sale";
            //            else if (qtyIndex != -1 && int.Parse(delimitedData[qtyIndex]) == 0)
            //                mainForm.Status = "Sold";
            //            break;
            //    }
            //}

            //  quantity
            if (qtyIndex == -1) {  //  if user didn't indicate they have copies
                mainForm.Quantity = 1;
            }
            else {  //  the user does have copies indicated...
                if (mainForm.IsInteger(delimitedData[qtyIndex]))
                    mainForm.Quantity = int.Parse(delimitedData[qtyIndex]);
                else  //  number of copies is not numeric, so default
                    mainForm.Quantity = rbMarkAsSold.Checked == true ? 0 : 1;
            }

            if (mainForm.Quantity == 0)
                mainForm.Status = "Sold";
            else
                mainForm.Status = "For Sale";

            //  asin
            if (delimitedData[ASINIndex].ToString().Length != 0)  //  there is no upc/ean, use asin
                mainForm.ASIN = delimitedData[ASINIndex];

            //  bullet proofing...
            string tempDescr = "";
            if (mainForm.Description != null) {
                tempDescr = Regex.Replace(mainForm.Description, @"[\r\n]", " ");
                tempDescr = Regex.Replace(tempDescr, @"[']", "''");      //  replace single quotes with two of them...
            }
            if (mainForm.Title != null)
                mainForm.Title = Regex.Replace(mainForm.Title, @"[']", "''");
            if (mainForm.Mfgr != null)
                mainForm.Mfgr = Regex.Replace(mainForm.Mfgr, @"[']", "''");
            if (mainForm.Notes != null)
                mainForm.Notes = Regex.Replace(mainForm.Notes, @"[']", "''");

            if (mainForm.DateAdded == null || mainForm.DateAdded.ToString().Length < 8) {
                mainForm.DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                mainForm.DateUpdated = mainForm.DateAdded;  //  indicates book was just added
            }

            mainForm.Cost = mainForm.Cost.Replace("\r\n", "");
            mainForm.Cost = (mainForm.Cost.IndexOf('.') == -1) ? mainForm.Cost + ".00" : mainForm.Cost;
            mainForm.Price = mainForm.Price.Replace("\r\n", "");
            mainForm.Price = (mainForm.Price.IndexOf('.') == -1) ? mainForm.Price + ".00" : mainForm.Price;

            String insertString =
                "insert into tMedia (SKU, TITLE, UPC, LOCN, PRICE, COST, TRANC, MFGR, MFGRYEAR, DESCR, CONDN, DATEA, DATEU, " +
                "NOTES, STAT, INVOICENBR, DONOTREPRICE, ImageURL, NBROFDISKS, SHIPPING, QUANTITY, MediaType, AUDIOFORMAT, " +
                "MPAARATING, AudioEncoding, VIDEOFORMAT, LANGUAGE, RUNTIME, SUBTITLES, ADULTCONTENT, PrivNotes, Origin, AudioKeywords," +
                "VideoKeywords, VinylDetails, Artist, Composer, Conductor, Orchestra, CatalogID, ProductType, ASIN) " +
                " values ('" + mainForm.SKU +
                "', '" + mainForm.Title +
                "', '" + mainForm.UPC +
                "', '" + mainForm.Locn +
                "', '" + mainForm.Price +
                "', '" + mainForm.Cost +
                "', '" + mainForm.TranC +
                "', '" + mainForm.Mfgr +
                "', '" + mainForm.MfgrYear +
                "', '" + mainForm.Description +
                "', '" + mainForm.Condition +
                "', '" + mainForm.DateAdded +
                "', '" + mainForm.DateUpdated +
                "', '" + mainForm.Notes +
                "', '" + mainForm.Status +
                "', '" + mainForm.InvoiceNbr +
                "', '" + mainForm.DoNotReprice +
                "', '" + mainForm.ImageURL +
                "', '" + mainForm.NbrOfDisks +
                "', '" + mainForm.Shipping +
                "', '" + mainForm.Quantity +
                "', '" + mainForm.MediaType +
                "', '" + mainForm.AudioFormat +
                "', '" + mainForm.MPAARating +
                "', '" + mainForm.AudioEncoding +
                "', '" + mainForm.VideoFormat +
                "', '" + mainForm.Language +
                "', '" + mainForm.Runtime +
                "', '" + mainForm.SubTitles +
                "', '" + mainForm.AdultContent +
                "', '" + mainForm.PrivateNotes +
                "', '" + mainForm.Origin +
                "', '" + mainForm.AudioKeywords +
                "', '" + mainForm.VideoKeywords +
                "', '" + mainForm.VinylDetails +
                "', '" + mainForm.Artist +
                "', '" + mainForm.Composer +
                "', '" + mainForm.Conductor +
                "', '" + mainForm.Orchestra +
                "', '" + mainForm.CatalogID +
                "', '" + mainForm.ProductType +
                "', '" + mainForm.ASIN +
             "')";

            cmd.CommandText = insertString;
            cmd.Connection = mainForm.mediaConn;

            try {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                if (ex.Message.Contains("violation of PRIMARY or UNIQUE KEY constraint")) {
                    if (rbReplaceRecords.Checked == true) {
                        string fbUpdateString = @"UPDATE tMedia SET " +
                            "Title = '" + mainForm.Title +
                            "', UPC = '" + mainForm.UPC +
                            "', Locn = '" + mainForm.Locn +
                            "', Price = " + mainForm.Price +
                            ", Cost = " + mainForm.Cost +
                            ", TranC = 'U" +
                            "', Mfgr = '" + mainForm.Mfgr +
                            "', MfgrYear = '" + mainForm.MfgrYear +
                            "', Descr = '" + mainForm.Description +
                            "', Condn = '" + mainForm.Condition +
                            "', DateA = '" + mainForm.DateAdded +
                            "', DateU = '" + mainForm.DateUpdated +
                            "', Notes = '" + mainForm.Notes +
                            "', Stat = '" + mainForm.Status +
                            "', InvoiceNbr = '" + mainForm.InvoiceNbr +
                            "', DoNotReprice = '" + mainForm.DoNotReprice +
                            "', ImageURL = '" + mainForm.ImageURL +
                            "', NbrOfDisks = '" + mainForm.NbrOfDisks +
                            "', Shipping = " + mainForm.Shipping +
                            ", Quantity = " + mainForm.Quantity +
                            ", MediaType = '" + mainForm.MediaType +
                            "', AudioFormat = '" + mainForm.AudioFormat +
                            "', MPAARating = '" + mainForm.MPAARating +
                            "', AudioEncoding = '" + mainForm.AudioEncoding +
                            "', VideoFormat = '" + mainForm.VideoFormat +
                            "', Language = '" + mainForm.Language +
                            "', Runtime = '" + mainForm.Runtime +
                            "', SUBTITLES = '" + mainForm.SubTitles +
                            "', PrivNotes = '" + mainForm.PrivateNotes +
                            "', Origin = '" + mainForm.Origin +
                            "', AudioKeywords = '" + mainForm.AudioKeywords +
                            "', VideoKeywords = '" + mainForm.VideoKeywords +
                            "', VinylDetails = '" + mainForm.VinylDetails +
                            "', Artist = '" + mainForm.Artist +
                            "', Composer = '" + mainForm.Composer +
                            "', Conductor = '" + mainForm.Conductor +
                            "', Orchestra = '" + mainForm.Orchestra +
                            "', CatalogID = '" + mainForm.CatalogID +
                            "', ProductType = '" + mainForm.ProductType +
                            "', ASIN = '" + mainForm.ASIN +
                            "' WHERE SKU = '" + mainForm.SKU + "'";

                        cmd.CommandText = fbUpdateString;
                        cmd.Connection = mainForm.mediaConn;
                        cmd.ExecuteNonQuery();
                    }
                    else  //  reject record with a reason
                    {
                        mf.lbRejectedRecords.Items.Add("SKU: " + mainForm.SKU + "  " + ex.Message);
                        mf.lbRejectedRecords.Refresh();
                        return -1;
                    }
                }  //  not a violation of the key, so it must be something else... 
                else {
                    mf.lbRejectedRecords.Items.Add("SKU: " + mainForm.SKU + "  " + ex.Message);
                    mf.lbRejectedRecords.Refresh();
                    return -1;
                }
            }

            return 0;
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    put heading names in listbox
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        internal void putHeaderNamesInListBox(string sFileName, ListBox lbMappingNames) {
            string input;

            //  create stream reader object
            System.IO.StreamReader sr = new System.IO.StreamReader(sFileName);
            input = sr.ReadLine();  //  read first line to get titles
            sr.Close();  //  close the stream reader

            mainForm.headingNames = input.Split('\t');  //  tab delimited
            foreach (string dataString in mainForm.headingNames) {
                lbMappingNames.Items.Add(dataString);
            }

            return;
        }

    }
}
