#region Using directive
using System;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Text.RegularExpressions;
using System.Globalization;
#endregion

namespace Prager_Book_Inventory
{
    class importTabDelimitedFiles
    {

        internal int bookNbrIndex = -1;
        internal int addDesc2Index = -1;
        internal int addDesc3Index = -1;
        internal int copiesIndex = -1;
        internal int expeditedIndex = -1;
        internal int internationalIndex = -1;
        internal int authorIndex = -1;
        internal int bindingIndex = -1;
        internal int bookCondIndex = -1;
        internal int bookSizeIndex = -1;
        internal int priCatIndex = -1;
        internal int secCatIndex = -1;
        internal int costIndex = -1;
        internal int dateSoldIndex = -1;
        internal int descIndex = -1;
        internal int djCondIndex = -1;
        internal int editionIndex = -1;
        internal int illusIndex = -1;
        internal int ISBNIndex = -1;
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


        public importTabDelimitedFiles()  //  constructor
        {

        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    convert import File
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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
                int rc = importRecordElements(mf, inputRecord, cmd, lbMappingNames, recordsRejected, rejectedRecs, rbMarkAsSold, rbReplaceRecords, rbImportAZ);  //  create data for insert into database
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


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create Database Elements from import file
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private int importRecordElements(mainForm mf, string inputRecord, FbCommand cmd, ListBox lbMappingNames, Label recordsRejected, ListBox rejRecords,
            RadioButton rbMarkAsSold, RadioButton rbReplaceRecords, RadioButton rbImportAZ) {

            object BookNbr, Title, Author, ISBN, Illus, Locn, Ed, Pub, PubPlace;
            object PubYear, Descr, bookSize, Notes, Keywds, Jaket, Bndg, bookType, Condn, SecCat;
            object PriCat, Stat, NbrOfPages, BookWeight, ExpeditedShip, InternationalShip, Shipping, Quantity, Volume;
            object Signed = DBNull.Value;


            string[] delimitedData = inputRecord.Split('\t'); //  now split each record into elements

            if (inputRecord.Contains("[Audio CD]") || inputRecord.Contains("[DVD]") || inputRecord.Contains("[VHS Tape]")) {
                rejRecords.Items.Add(delimitedData[bookNbrIndex] + " - not a book");
                rejRecords.Refresh();
                return -1; //  accept books only
            }

            ////  find out how many valid elements are in the Tab Mapping cells
            //if (lbMappingNames.Items.Count != delimitedData.Length && rbImportAZ.Checked == false) {
            //    rejRecords.Items.Add(delimitedData[bookNbrIndex] + " - Number of fields (" +
            //                         delimitedData.Length.ToString() + ") does not match header count (" +
            //                         lbMappingNames.Items.Count.ToString() + ")");
            //    rejRecords.Refresh();
            //    return -1;
            //}

            //  minimal error checking
            if (delimitedData[bookNbrIndex].Length == 0) {
                rejRecords.Items.Add("SKU (Book Number) is missing");
                rejRecords.Refresh();
                return -1;
            }
            if (delimitedData[titleIndex].Length == 0) {
                rejRecords.Items.Add(delimitedData[bookNbrIndex] + " - Title is missing");
                rejRecords.Refresh();
                return -1;
            }

            string[] pricePieces = delimitedData[priceIndex].Split(' '); //  dig out the price
            pricePieces[0] = pricePieces[0].Replace("\"", "");
            pricePieces[0] = pricePieces[0].Replace("$", ""); //  10.5.0
            if (!mainForm.IsNumeric(pricePieces[0])) {
                rejRecords.Items.Add(delimitedData[bookNbrIndex] + " - Price is not numeric");
                rejRecords.Refresh();
                return -1;
            }
            if (delimitedData[priceIndex].Length == 0) {
                rejRecords.Items.Add(delimitedData[bookNbrIndex] + " - Price is missing");
                rejRecords.Refresh();
                return -1;
            }

            if (rbImportAZ.Checked == false) {
                if (delimitedData[bindingIndex].Length == 0) {
                    rejRecords.Items.Add(delimitedData[bookNbrIndex] + " - Binding is missing");
                    rejRecords.Refresh();
                    return -1;
                }
            }

            //  work on dates...
            DateTime tempDate = DateTime.Now;
            string da = tempDate.ToString("g");
            da = Regex.Replace(da, "AM|PM|a.m.|p.m.", "");
            string du = da;


            //  now, start moving the data
            BookNbr = delimitedData[bookNbrIndex]; //  SKU

            //  title
            Title = delimitedData[titleIndex].Length > 100
                        ? delimitedData[titleIndex].Substring(0, 100)
                        : delimitedData[titleIndex];
            if (appendToTitleIndex != -1) //  is there a sub-title?
            {
                int subLen = delimitedData[appendToTitleIndex].Length;
                int titleLen = delimitedData[titleIndex].Length > 100 ? 100 : delimitedData[titleIndex].Length;
                if (subLen > 0 && titleLen < 100) {
                    Title += ": "; //  separator
                    Title += (subLen < (98 - titleLen))
                                 ? delimitedData[appendToTitleIndex]
                                 : delimitedData[appendToTitleIndex].Substring(0, 98 - titleLen);
                }
            }

            Condn = "Good";
            if (bookCondIndex != -1) {
                //  book condition
                if (rbImportAZ.Checked) {
                    //  Amazon conditions
                    switch (delimitedData[bookCondIndex]) {
                        case "1":
                            Condn = "Used; Like New";
                            break;
                        case "2":
                            Condn = "Used; Very Good";
                            break;
                        case "3":
                            Condn = "Used; Good";
                            break;
                        case "4":
                            Condn = "Used; Acceptable";
                            break;
                        case "5":
                            Condn = "Collectible; Like New";
                            break;
                        case "6":
                            Condn = "Collectible; Very Good";
                            break;
                        case "7":
                            Condn = "Collectible; Good";
                            break;
                        case "8":
                            Condn = "Collectible; Acceptable";
                            break;
                        case "11":
                            Condn = "New";
                            break;
                        default:
                            Condn = "Good";
                            break;
                    }
                }
                else {
                    if (delimitedData[bookCondIndex].Length == 0)
                        Condn = "Good";
                    else
                        Condn = delimitedData[bookCondIndex].Length > 25
                                    ? delimitedData[bookCondIndex].Substring(0, 25)
                                    : delimitedData[bookCondIndex];
                }
            }

            if (authorIndex != -1) //  author
                if (delimitedData[authorIndex].Length == 0)
                    Author = "n/a"; //  amazon files do not carry author
                else
                    Author = delimitedData[authorIndex].Length > 75
                                 ? delimitedData[authorIndex].Substring(0, 75)
                                 : delimitedData[authorIndex];
            else
                Author = "";

            if (publisherIndex != -1) //  publisher
                if (delimitedData[publisherIndex].Length == 0)
                    Pub = "n/a";
                else
                    Pub = delimitedData[publisherIndex].Length > 85
                              ? delimitedData[publisherIndex].Substring(0, 85)
                              : delimitedData[publisherIndex];
            else
                Pub = DBNull.Value;

            if (bindingIndex != -1) //  binding
                Bndg = delimitedData[bindingIndex].Replace("'", "");
            else
                Bndg = DBNull.Value;

            if (ISBNIndex == -1) //  ISBN
                ISBN = DBNull.Value;
            else {
                ISBN = delimitedData[ISBNIndex];
                if (ISBN.ToString().Length > 6) {
                    string pattern = @"-\s*";
                    string replacement = @"";
                    string input = ISBN.ToString();
                    ISBN = Regex.Replace(input, pattern, replacement);
                }

                if (illusIndex == -1) //  illustrator
                    Illus = DBNull.Value;
                else
                    Illus = delimitedData[illusIndex].Length > 75
                                ? delimitedData[illusIndex].Substring(0, 75)
                                : delimitedData[illusIndex];

                if (locationIndex == -1) //  location
                    Locn = DBNull.Value;
                else
                    Locn = delimitedData[locationIndex].Length > 10
                               ? delimitedData[locationIndex].Substring(0, 10)
                               : delimitedData[locationIndex];

                //  shipping constants
                byte DomStd = 32;
                byte DomExp = 16;
                byte IntlStd = 2;

                ExpeditedShip = DBNull.Value; //  set the old fields to null
                InternationalShip = DBNull.Value;

                Shipping = DomStd; //  this is a given

                if (expeditedIndex != -1) //  Domestic expedited shipping 
                    Shipping = delimitedData[expeditedIndex] == "y" ? (byte)Shipping & DomExp : Shipping;

                if (internationalIndex != -1) //  international shipping
                    Shipping = delimitedData[internationalIndex] == "y" ? (byte)Shipping & IntlStd : Shipping;

                CultureInfo ci = CultureInfo.CurrentCulture;
                NumberFormatInfo nfi = ci.NumberFormat;
                string Cost = "";
                string tempSigning = "";

                if (costIndex == -1) //  cost
                    Cost = "0" + nfi.CurrencyDecimalSeparator.ToString() + "00";
                else
                    Cost = mainForm.IsNumeric(delimitedData[costIndex]) ? delimitedData[costIndex] : "0.00";

                if (editionIndex == -1) //  edition
                    Ed = DBNull.Value;
                else
                    Ed = delimitedData[editionIndex];

                if (signedAuthorIndex == -1) //  signed
                    Signed = DBNull.Value;
                else {
                    tempSigning = delimitedData[signedAuthorIndex];
                    if (tempSigning.ToLower().Contains("author"))
                        Signed = "A";
                    else if (tempSigning.ToLower().Contains("illus"))
                        Signed = "I";
                }

                if (pubLocIndex == -1) //  publisher location
                    PubPlace = DBNull.Value;
                else
                    //PubPlace = delimitedData[pubLocIndex];
                    PubPlace = delimitedData[pubLocIndex].Length > 25
                                   ? delimitedData[pubLocIndex].Substring(0, 25)
                                   : delimitedData[pubLocIndex];

                PubYear = DBNull.Value;
                if (yearPubIndex != -1) {
                    //  year
                    if (delimitedData[yearPubIndex].Length == 4)
                        PubYear = delimitedData[yearPubIndex];
                    else if (delimitedData[yearPubIndex].Length < 4)
                        PubYear = DBNull.Value;
                }

                //  do description...
                if (descIndex == -1)
                    Descr = DBNull.Value;
                else
                    Descr = delimitedData[descIndex].Length > 500
                                ? delimitedData[descIndex].Substring(0, 500)
                                : delimitedData[descIndex];
                //  add tbMapAddDesc here  <----------------  TODO


                if (bookSizeIndex == -1) //  book size
                    bookSize = DBNull.Value;
                else
                    bookSize = delimitedData[bookSizeIndex].Trim();

                if (privNotesIndex == -1) //  private notes
                    Notes = DBNull.Value;
                else
                    Notes = delimitedData[privNotesIndex].Length > 50
                                ? delimitedData[privNotesIndex].Substring(0, 50)
                                : delimitedData[privNotesIndex];

                if (keywordsIndex == -1) //  keywords
                    Keywds = DBNull.Value;
                else
                    Keywds = delimitedData[keywordsIndex].Length > 85
                                 ? delimitedData[keywordsIndex].Substring(0, 85)
                                 : delimitedData[keywordsIndex];

                if (djCondIndex == -1) //  jacket condition
                    Jaket = DBNull.Value;
                else
                    Jaket = delimitedData[djCondIndex].Length > 25
                                ? delimitedData[djCondIndex].Substring(0, 25)
                                : delimitedData[djCondIndex];

                if (typeIndex == -1) //  book type
                    bookType = DBNull.Value;
                else
                    bookType = delimitedData[typeIndex].Length > 15
                                   ? delimitedData[typeIndex].Substring(0, 15)
                                   : delimitedData[typeIndex];

                if (priCatIndex == -1) //  primary catalog
                    PriCat = DBNull.Value;
                else
                    PriCat = delimitedData[priCatIndex].Length > 50
                              ? delimitedData[priCatIndex].Substring(0, 50)
                              : delimitedData[priCatIndex];

                if (secCatIndex == -1) //  secondary catalog
                    SecCat = DBNull.Value;
                else
                    SecCat = delimitedData[secCatIndex].Length > 50
                              ? delimitedData[secCatIndex].Substring(0, 50)
                              : delimitedData[secCatIndex];

                if (nbrOfPagesIndex == -1) //  nbr of pages
                    NbrOfPages = DBNull.Value;
                else {
                    Regex rgx = new Regex(@"[^\d]");
                    NbrOfPages = rgx.Replace(delimitedData[nbrOfPagesIndex].ToString(), "");
                }

                if (bookWeightIndex == -1) //  weight
                    BookWeight = DBNull.Value;
                else
                    BookWeight = delimitedData[bookWeightIndex];


                Stat = "";
                if (statusIndex != -1) {
                    //  status...
                    switch (delimitedData[statusIndex]) {
                        case "Available":
                        case "In Store":
                            Stat = "For Sale";
                            break;
                        case "On Hold":
                        case "Pending":
                            Stat = "Hold";
                            break;
                        case "Sold":
                            Stat = "Sold";
                            break;
                        default:
                            if (copiesIndex != -1 && int.Parse(delimitedData[copiesIndex]) > 0)
                                //  if user indicated they have copies
                                Stat = "For Sale";
                            else if (copiesIndex != -1 && int.Parse(delimitedData[copiesIndex]) == 0)
                                Stat = "Sold";
                            break;
                    }
                }

                //  do number of copies...
                if (copiesIndex == -1) {
                    //  if user didn't indicate they have copies
                    Quantity = 1;
                    Stat = statusIndex != -1 ? "For Sale" : "";
                }
                else {
                    //  the user does have copies indicated...
                    if (mainForm.IsInteger(delimitedData[copiesIndex]))
                        Quantity = delimitedData[copiesIndex];
                    else //  number of copies is not numeric, so default
                        Quantity = rbMarkAsSold.Checked == true ? 0 : 1;
                    if (statusIndex == -1)
                        Stat = (string)Quantity == "0" ? "Sold" : "For Sale";
                }

                string fbInsertString =
                        "insert into tBooks (BookNbr, Title, Author, ISBN, Illus, Locn, Price, Cost, TranC, Pub, PubPlace, PubYear, " +  //  12
                        "Keywds, Descr, Jaket, Bndg, Condn, Ed, Signed, BookType, BookSize, DateA, DateU, Cat, Notes, Stat, InvoiceNbr, " +  // 15
                        "ExpediteShip, IntlShip, SubCategory, DoNotReprice, NbrOfPages, BookWeight, ImageFileName, Quantity, Shipping)" +  // 9
                        " values ('" +
                        BookNbr + "', '" +
                        Title.ToString().Replace("'", "''") + "', '" +
                        Author.ToString().Replace("'", "''") + "', '" +
                        ISBN + "', '" +
                        Illus + "', '" +
                        Locn.ToString().Replace("'", "''") + "', '" +
                        pricePieces[0].Replace(nfi.CurrencyDecimalSeparator, ".") + "', '" +
                        Cost.Replace(nfi.CurrencyDecimalSeparator, ".") + "', '" +
                        "A" + "', '" +  //  TranC
                        Pub.ToString().Replace("'", "''") + "', '" +
                        PubPlace + "', '" +
                        PubYear + "', '" +
                        Keywds.ToString().Replace("'", "''").Trim() + "', '" +
                        Descr.ToString().Replace("'", "''") + "', '" +
                        Jaket + "', '" +
                        Bndg + "', '" +
                        Condn + "', '" +
                        (Ed = Ed.ToString().Length < 16 ? Ed : Ed.ToString().Substring(0, 15)) + "', '" +
                        Signed + "', '" +
                        bookType.ToString().Replace("'", "''") + "', '" +
                        bookSize + "', '" +
                        da + "', '" +
                        du + "', '" +
                        PriCat + "', '" +
                        Notes + "', '" +
                        Stat + "', '" +
                        DBNull.Value + "', '" +  //  invoice number (null)
                        ExpeditedShip + "', '" +  // expedite shipping
                        InternationalShip + "', '" +  // international shipping
                        SecCat + "', '" +  // sub-category
                        "N" + "', '" +  //  do not reprice (default = n)
                        NbrOfPages + "', '" +
                        BookWeight + "', '" +
                        DBNull.Value + "', '" +  //  image filename
                        Quantity + "', '" +
                        Shipping + "')";

                cmd.CommandText = fbInsertString;
                cmd.Connection = mainForm.bookConn;

                try {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) {
                    if (ex.Message.Contains("violation of PRIMARY or UNIQUE KEY constraint")) {
                        if (rbReplaceRecords.Checked == true) {
                            string fbUpdateString = @"UPDATE tBooks SET " +
                                "Title = '" + Title.ToString().Replace("'", "''") +
                                "', Author = '" + Author.ToString().Replace("'", "''") +
                                "', ISBN = '" + ISBN +
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
                                "', Cat = '" + PriCat +
                                "', SubCategory = '" + SecCat +
                                "', Stat = '" + Stat +
                                "', ExpediteShip = '" + ExpeditedShip +
                                "', IntlShip = '" + InternationalShip +
                                "', DoNotReprice = 'N" +
                                "', NbrOfPages = '" + NbrOfPages +
                                "', BookWeight = '" + BookWeight +
                                "', ImageFileName = '" + DBNull.Value +
                                "', Shipping = '" + 32 +
                                "', Quantity = '" + Quantity +
                                "' WHERE BookNbr = '" + BookNbr + "'";

                            cmd.CommandText = fbUpdateString;
                            cmd.Connection = mainForm.bookConn;
                            cmd.ExecuteNonQuery();
                        }
                        else  //  reject record with a reason
                    {
                            mf.lbRejectedRecords.Items.Add("SKU: " + BookNbr + "  " + ex.Message);
                            mf.lbRejectedRecords.Refresh();
                            return -1;
                        }
                    }  //  not a violation of the key, so it must be something else... 
                    else {
                        mf.lbRejectedRecords.Items.Add("SKU: " + BookNbr + "  " + ex.Message);
                        mf.lbRejectedRecords.Refresh();
                        return -1;
                    }
                }

                return 0;
            }
            return 0;
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    put heading names in listbox
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        internal void putHeaderNamesInListBox(string sFileName, ListBox lbMappingNames) {
            string input;

            //  create stream reader object
            System.IO.StreamReader sr = new System.IO.StreamReader(sFileName);
            input = sr.ReadLine();  //  read first line to get titles
            sr.Close();  //  close the stream reader

            mainForm.headingNames = input.Split('\t');  //  tab delimited

            for(int i = 0; i < mainForm.headingNames.Length; i++)  {
                mainForm.headingNames[i] = mainForm.headingNames[i].Replace("\"", "");
            }

            foreach (string dataString in mainForm.headingNames) {
                    lbMappingNames.Items.Add(dataString);
            }

            return;
        }

    }
}
