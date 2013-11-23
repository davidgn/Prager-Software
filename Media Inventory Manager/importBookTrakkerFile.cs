#region Using directive
using System;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Text.RegularExpressions;
using System.Globalization;
#endregion

namespace Media_Inventory_Manager
{
    class importBookTrakkerFiles
    {

        internal int SKUIndex = -1;
        internal int addDesc2Index = -1;
        internal int addDesc3Index = -1;
        internal int copiesIndex = -1;
        internal int expeditedIndex = -1;
        internal int internationalIndex = -1;
        internal int authorIndex = -1;
        internal int bindingIndex = -1;
        internal int bookCondIndex = -1;
        internal int bookSizeIndex = -1;
        internal int catalogIndex = -1;
        internal int costIndex = -1;
        internal int dateSoldIndex = -1;
        internal int descIndex = -1;
        internal int djCondIndex = -1;
        internal int editionIndex = -1;
        internal int illusIndex = -1;
        internal int UPCIndex = -1;
        internal int keywordsIndex = -1;
        internal int priceIndex = -1;
        internal int privNotesIndex = -1;
        internal int publisherIndex = -1;
        internal int pubLocIndex = -1;
        internal int signedAuthorIndex = -1;
        internal int signedIllusIndex = -1;
        internal int titleIndex = -1;
        internal int typeIndex = -1;
        internal int yearPubIndex = -1;
        internal int locationIndex = -1;
        internal int nbrOfPagesIndex = -1;
        internal int bookWeightIndex = -1;
        internal int appendToTitleIndex = -1;
        internal int statusIndex = -1;

        static int rejectedCount = 0;


        public importBookTrakkerFiles()  //  constructor
        {

        }


        //-------------------------------    convertFile    -----------------------------------------------
        static int count = 0;
        public void convertFile(mainForm mf, string sFileName, Label recordsProcessed, ListBox lbMappingNames, Label recordsRejected, ListBox rejectedRecs,
            RadioButton rbMarkAsSold, RadioButton rbReplaceRecords, RadioButton rbImportAZ)
        {

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

                if (rc == -1)
                {
                    recordsRejected.Text = "Records Rejected: " + ++rejectedCount;
                    recordsRejected.Refresh();
                }

                Application.DoEvents();

            }

            sr.Close();  //  close the stream reader
        }


        //---------------------------------    createDatabaseElements    --------------------------------------------------
        private int createDatabaseElements(mainForm mf, string inputRecord, FbCommand cmd, ListBox lbMappingNames, Label recordsRejected, ListBox rejRecords,
            RadioButton rbMarkAsSold, RadioButton rbReplaceRecords, RadioButton rbImportAZ)
        {

            object SKU, Title, Author, UPC, Illus, Locn, Ed, Signed, Pub, PubPlace;
            object PubYear, Descr, bookSize, Notes, Keywds, Jaket, Bndg, bookType, Condn;
            object Cat, Stat, NbrOfPages, BookWeight, ExpeditedShip, InternationalShip, Shipping, Quantity, Volume ;

            string[] delimitedData = inputRecord.Split('\t');  //  now split each record into elements

            //  find out how many valid elements are in the Tab Mapping cells
            if (lbMappingNames.Items.Count != delimitedData.Length && rbImportAZ.Checked == false)
            {
                rejRecords.Items.Add(delimitedData[SKUIndex] + " - Number of fields (" + 
                    delimitedData.Length.ToString() + ") does not match header count (" + 
                    lbMappingNames.Items.Count.ToString() + ")");
                rejRecords.Refresh();
                return -1;
            }

            //  if status is REMOVED, don't import this record
            if (statusIndex != -1 && delimitedData[statusIndex].ToString().ToLower().Contains("removed"))
                return 0;

            if (delimitedData[SKUIndex].Length == 0)
            {
                rejRecords.Items.Add("SKU (Book Number) is missing");
                rejRecords.Refresh();
                return -1;
            }
            if (delimitedData[titleIndex].Length == 0)
            {
                rejRecords.Items.Add(delimitedData[SKUIndex] + " - Title is missing");
                rejRecords.Refresh();
                return -1;
            }
            //if (delimitedData[bookCondIndex].Length == 0)
            //{
            //    rejRecords.Items.Add(delimitedData[SKUIndex] + " - Condition is missing");
            //    rejRecords.Refresh();
            //    return -1;
            //}

            string[] pricePieces = delimitedData[priceIndex].Split(' ');  //  dig out the price
            pricePieces[0] = pricePieces[0].Replace("\"", "");
            pricePieces[0] = pricePieces[0].Replace("$", "");  //  10.5.0
            if (!mainForm.IsNumeric(pricePieces[0]))
            {
                rejRecords.Items.Add(delimitedData[SKUIndex] + " - Price is not numeric");
                rejRecords.Refresh();
                return -1;
            }
            if (delimitedData[priceIndex].Length == 0)
            {
                rejRecords.Items.Add(delimitedData[SKUIndex] + " - Price is missing");
                rejRecords.Refresh();
                return -1;
            }

            if (rbImportAZ.Checked == false)
            {

                if (delimitedData[bindingIndex].Length == 0)
                {
                    rejRecords.Items.Add(delimitedData[SKUIndex] + " - Binding is missing");
                    rejRecords.Refresh();
                    return -1;
                }
            }

            //  work on dates...
            DateTime tempDate = DateTime.Now;
            string da = tempDate.ToString("g");
            da = Regex.Replace(da, "AM|PM|a.m.|p.m.", "");
            string du = da;

            SKU = delimitedData[SKUIndex];

            Title = delimitedData[titleIndex].Length > 100 ? delimitedData[titleIndex].Substring(0, 100) : delimitedData[titleIndex];
            if (appendToTitleIndex != -1)  //  is there a sub-title?
            {
                int subLen = delimitedData[appendToTitleIndex].Length;
                int titleLen = delimitedData[titleIndex].Length > 100 ? 100 : delimitedData[titleIndex].Length;
                if (subLen > 0 && titleLen < 99)
                {
                    Title += ": ";  //  separator
                    Title += (subLen < (98 - titleLen)) ? delimitedData[appendToTitleIndex] : delimitedData[appendToTitleIndex].Substring(0, 98 - titleLen);
                }
            }

            if (delimitedData[bookCondIndex].Length == 0)
                Condn = "Good";
            else
                Condn = delimitedData[bookCondIndex].Length > 25 ? delimitedData[bookCondIndex].Substring(0, 25) : delimitedData[bookCondIndex];

            //if (authorIndex != -1)
            if (delimitedData[authorIndex].Length == 0)
                Author = "n/a";
            else
                Author = delimitedData[authorIndex].Length > 75 ? delimitedData[authorIndex].Substring(0, 75) : delimitedData[authorIndex];

            if (publisherIndex != -1)
                if (delimitedData[nbrOfPagesIndex].Length == 0)
                    Pub = "n/a";
                else
                    Pub = delimitedData[publisherIndex].Length > 85 ? delimitedData[publisherIndex].Substring(0, 85) : delimitedData[publisherIndex];
            else
                Pub = DBNull.Value;

            if (bindingIndex != -1)
                Bndg = delimitedData[bindingIndex].Replace("'", "");
            else
                Bndg = DBNull.Value;

            if (UPCIndex == -1)
                UPC = DBNull.Value;
            else
            {
                Regex r = new Regex(@"-\s*");  //  remove dashes and blanks
                UPC = delimitedData[UPCIndex].Length > 13 ? delimitedData[UPCIndex].Substring(0, 13) : delimitedData[UPCIndex];
                UPC = r.Replace((string)UPC, "");
            }

            if (illusIndex == -1)
                Illus = DBNull.Value;
            else
                Illus = delimitedData[illusIndex].Length > 75 ? delimitedData[illusIndex].Substring(0, 75) : delimitedData[illusIndex];

            if (locationIndex == -1)
                Locn = DBNull.Value;
            else
                Locn = delimitedData[locationIndex].Length > 10 ? delimitedData[locationIndex].Substring(0, 10) : delimitedData[locationIndex];

            //  shipping constants
            byte DomStd = 32;
            byte DomExp = 16;
            byte IntlStd = 2;

            ExpeditedShip = DBNull.Value;  //  set the old fields to null
            InternationalShip = DBNull.Value;

            Shipping = DomStd;  //  this is a given

            if (expeditedIndex != -1)  //  Domestic expedited shipping 
                Shipping = delimitedData[expeditedIndex] == "y" ? (byte)Shipping & DomExp : Shipping;

            if (internationalIndex != -1)  //  international shipping
                Shipping = delimitedData[internationalIndex] == "y" ? (byte)Shipping & IntlStd : Shipping;

            CultureInfo ci = CultureInfo.CurrentCulture;
            NumberFormatInfo nfi = ci.NumberFormat;
            string Cost = "";

            if (costIndex == -1)
                Cost = "0" + nfi.CurrencyDecimalSeparator.ToString() + "00";
            else
                Cost = mainForm.IsNumeric(delimitedData[costIndex]) ? delimitedData[costIndex] : "0.00";

            if (editionIndex == -1)
                Ed = DBNull.Value;
            else
                Ed = delimitedData[editionIndex];

            if (signedAuthorIndex == -1)
                Signed = DBNull.Value;
            else
                Signed = delimitedData[signedAuthorIndex];

            if (pubLocIndex == -1)
                PubPlace = DBNull.Value;
            else
                //PubPlace = delimitedData[pubLocIndex];
                PubPlace = delimitedData[pubLocIndex].Length > 25 ? delimitedData[pubLocIndex].Substring(0, 25) : delimitedData[pubLocIndex];

            PubYear = DBNull.Value;
            if (yearPubIndex != -1)
            {
                if (delimitedData[yearPubIndex].Length == 4)
                    PubYear = delimitedData[yearPubIndex];
                else if (delimitedData[yearPubIndex].Length < 4)
                    PubYear = DBNull.Value;
            }

            //  work on description
            if (descIndex == -1)
                Descr = DBNull.Value;
            else
                Descr = delimitedData[descIndex].Length > 500 ? delimitedData[descIndex].Substring(0, 500) : delimitedData[descIndex];
            //  add code for tbMapAddDesc3 here <-----------------  TODO


            if (bookSizeIndex == -1)
                bookSize = DBNull.Value;
            else
                bookSize = delimitedData[bookSizeIndex].Trim();

            if (privNotesIndex == -1)
                Notes = DBNull.Value;
            else
                //Notes = delimitedData[privNotesIndex];
                Notes = delimitedData[privNotesIndex].Length > 50 ? delimitedData[privNotesIndex].Substring(0, 50) : delimitedData[privNotesIndex];

            if (keywordsIndex == -1)
                Keywds = DBNull.Value;
            else
                Keywds = delimitedData[keywordsIndex].Length > 85 ? delimitedData[keywordsIndex].Substring(0, 85) : delimitedData[keywordsIndex];

            if (djCondIndex == -1)
                Jaket = DBNull.Value;
            else
                Jaket = delimitedData[djCondIndex].Length > 25 ? delimitedData[djCondIndex].Substring(0, 25) : delimitedData[djCondIndex];

            if (typeIndex == -1)
                bookType = DBNull.Value;
            else
                bookType = delimitedData[typeIndex].Length > 15 ? delimitedData[typeIndex].Substring(0, 15) : delimitedData[typeIndex];

            if (catalogIndex == -1)
                Cat = DBNull.Value;
            else
                Cat = delimitedData[catalogIndex].Length > 50 ? delimitedData[catalogIndex].Substring(0, 50) : delimitedData[catalogIndex];

            if (nbrOfPagesIndex == -1)
                NbrOfPages = DBNull.Value;
            else
            {
                Regex rgx = new Regex(@"[^\d]");
                NbrOfPages = rgx.Replace(delimitedData[nbrOfPagesIndex].ToString(), "");
            }

            if (bookWeightIndex == -1)
                BookWeight = DBNull.Value;
            else
                BookWeight = delimitedData[bookWeightIndex];

            //  do status...
            Stat = "";  //  initialize
            if (statusIndex != -1)
            {
                switch (delimitedData[statusIndex])
                {
                    case "Available":
                    case "In Store":
                        Stat = "For Sale";
                        break;
                    case "On Hold":
                    case "Pending":
                        Stat = "Hold";
                        break;
                    //case "Removed":
                    case "Sold":
                        Stat = "Sold";
                        break;
                    default:
                        if (copiesIndex != -1 && int.Parse(delimitedData[copiesIndex]) > 0)  //  if user indicated they have copies
                            Stat = "For Sale";
                        else if (copiesIndex != -1 && int.Parse(delimitedData[copiesIndex]) == 0)
                            Stat = "Sold";
                        break;
                }
            }

            //  do number of copies...
            if (copiesIndex == -1)  //  if user didn't indicate they have copies
                Quantity = 1;
            else  //  the user does have copies indicated...
            {
                if (mainForm.IsInteger(delimitedData[copiesIndex]))
                    Quantity = delimitedData[copiesIndex];
                else  //  number of copies is not numeric, so default
                    Quantity = rbMarkAsSold.Checked == true ? 0 : 1;
            }

            string fbInsertString =
                "insert into tMedia (SKU, Title, Author, UPC, Illus, Locn, Price, Ed, Signed, Cost, TranC, Pub, PubPlace," +
                "PubYear, Descr, bookSize, Notes, Keywds, Jaket, Bndg, bookType, Condn, ExpediteShip, IntlShip, DateA, DateU, Cat, " +
                " SubCategory, Stat, " + "DoNotReprice, NbrOfPages, BookWeight, ImageURL, Quantity, Shipping)" +
                " values ('" +
                SKU + "', '" +
                Title.ToString().Replace("'", "''") + "', '" +
                Author.ToString().Replace("'", "''") + "', '" +
                UPC + "', '" +
                Illus + "', '" +
                Locn + "', '" +
                pricePieces[0].Replace(nfi.CurrencyDecimalSeparator, ".") + "', '" +
                (Ed = Ed.ToString().Length < 16 ? Ed : Ed.ToString().Substring(0, 15)) + "', '" +
                Signed + "', '" +
                Cost.Replace(nfi.CurrencyDecimalSeparator, ".") + "', '" +
                "A" + "', '" +
                Pub.ToString().Replace("'", "''") + "', '" +
                PubPlace + "', '" +
                PubYear + "', '" +
                Descr.ToString().Replace("'", "''") + "', '" +
                bookSize + "', '" +
                Notes + "', '" +
                Keywds.ToString().Replace("'", "''").Trim() + "', '" +
                Jaket + "', '" +
                Bndg + "', '" +
                bookType.ToString().Replace("'", "''") + "', '" +
                Condn + "', '" + "" + "', '" + "" + "', '" +
                da +
                "', '" +
                du + "', '" +
                Cat + "', '" + DBNull.Value + "', '" +
                Stat + "', '" + "N" + "', '" +
                NbrOfPages + "', '" +
                BookWeight + "', '" +
                DBNull.Value + "', '" +
                Quantity + "', '" +
                Shipping + "')";

            cmd.CommandText = fbInsertString;
            cmd.Connection = mainForm.databaseConn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("violation of PRIMARY or UNIQUE KEY constraint"))
                {
                    if (rbReplaceRecords.Checked == true)
                    {
                        string fbUpdateString = @"UPDATE tMedia SET " +
                            "Title = '" + Title.ToString().Replace("'", "''") +
                            "', Author = '" + Author.ToString().Replace("'", "''") +
                            "', UPC = '" + UPC +
                            "', Illus = '" + Illus +
                            "', Locn = '" + Locn +
                            "', Price = '" + pricePieces[0].Replace(nfi.CurrencyDecimalSeparator, ".") +
                            "', Ed = '" + Ed +
                            "', Signed = '" + Signed +
                            "', Cost = '" + Cost.Replace(nfi.CurrencyDecimalSeparator, ".") +
                            "', TranC = 'U" +
                            "', Pub = '" + Pub.ToString().Replace("'", "''") +
                            "', PubPlace = '" + PubPlace +
                            "', PubYear = '" + PubYear +
                            "', Descr = '" + Descr.ToString().Replace("'", "''") +
                            "', bookSize = '" + bookSize +
                            "', Notes = '" + Notes +
                            "', Keywds = '" + Keywds.ToString().Replace("'", "''") +
                            "', Jaket = '" + Jaket +
                            "', Bndg = '" + Bndg +
                            "', bookType = '" + bookType.ToString().Replace("'", "''") +
                            "', Condn = '" + Condn +
                            "', DateU = '" + du +
                            "', Cat = '" + Cat +
                            "', Stat = '" + Stat +
                            "', ExpediteShip = '" + ExpeditedShip +
                            "', IntlShip = '" + InternationalShip +
                            "', DoNotReprice = 'N" +
                            "', NbrOfPages = '" + NbrOfPages +
                            "', BookWeight = '" + BookWeight +
                            "', ImageURL = '" + DBNull.Value +
                            "', Shipping = '" + 32 +
                            "', Quantity = '" + Quantity +
                            "' WHERE SKU = '" + SKU + "'";

                        cmd.CommandText = fbUpdateString;
                        cmd.Connection = mainForm.databaseConn;
                        cmd.ExecuteNonQuery();
                    }
                    else  //  reject record with a reason
                    {
                        mf.lbRejectedRecords.Items.Add("SKU: " + SKU + "  " + ex.Message);
                        mf.lbRejectedRecords.Refresh();
                        return -1;
                    }
                }  //  not a violation of the key, so it must be something else... 
                else
                {
                    mf.lbRejectedRecords.Items.Add("SKU: " + SKU + "  " + ex.Message);
                    mf.lbRejectedRecords.Refresh();
                    return -1;
                }
            }

            return 0;
        }


        //-----------------------------    put heading names in listbox    -----------------------------------------
        internal void putHeaderNamesInListBox(string sFileName, ListBox lbMappingNames)
        {
            string input;

            //  create stream reader object
            System.IO.StreamReader sr = new System.IO.StreamReader(sFileName);
            input = sr.ReadLine();  //  read first line to get titles
            sr.Close();  //  close the stream reader

            mainForm.headingNames = input.Split('\t');  //  tab delimited
            foreach (string dataString in mainForm.headingNames)
            {
                lbMappingNames.Items.Add(dataString);
            }

            return;
        }

    }
}
