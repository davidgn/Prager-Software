//#define TRACE

using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;


namespace Media_Inventory_Manager
{

    partial class mainForm : Form
    {
        private FbDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
        private FbDataReader dr;
        //private uint Shipping = 0;  //  contains the binary flags to indicate shipping choices
        int rejectedCount = 0;
        static string inclusiveSearchString = "";

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update ONE (1) item in listview panel
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void updateDataBasePanel(string SKU) {
            Cursor.Current = Cursors.WaitCursor;

            CultureInfo ci = CultureInfo.CurrentCulture;
            NumberFormatInfo nfi = ci.NumberFormat;

            commandString = "SELECT SKU, Title, Quantity, UPC, Locn, Price, Stat, InvoiceNbr FROM tMedia WHERE SKU = '" + SKU + "'";
            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();
            FbCommand cmd = new FbCommand(commandString, mediaConn);

            dr = cmd.ExecuteReader();

            ListViewItem lvi = dataBasePanel.FindItemWithText(SKU);  //  find the item we were working on...
            int listIndex = lvi.Index;                          //listData[0];

            dataBasePanel.BeginUpdate();
            while (dr.Read()) {
                dataBasePanel.Items[listIndex].SubItems[1].Text = (string)dr["Title"];
                dataBasePanel.Items[listIndex].SubItems[2].Text = dr["Quantity"].ToString();
                dataBasePanel.Items[listIndex].SubItems[3].Text = (string)dr["UPC"];
                dataBasePanel.Items[listIndex].SubItems[4].Text = (string)dr["Locn"];

                decimal workingPrice = 0.00M;  //  get price if it's there
                if (!dr.IsDBNull(5))
                    workingPrice = dr.GetDecimal(5);
                else
                    workingPrice = 0.00M;
                dataBasePanel.Items[listIndex].SubItems[5].Text = workingPrice.ToString("##,###.00", nfi);

                dataBasePanel.Items[listIndex].SubItems[6].Text = (string)dr["Stat"];

                if (!dr.IsDBNull(7))
                    dataBasePanel.Items[listIndex].SubItems[7].Text = (string)dr["InvoiceNbr"];
                else
                    dataBasePanel.Items[listIndex].SubItems[7].Text = "";  //  if it's null, then clear it out

                if (dr["Stat"].Equals("Sold"))  //  make items that are sold light grey in color
                    dataBasePanel.Items[listIndex].ForeColor = Color.LightGray;
                else
                    dataBasePanel.Items[listIndex].ForeColor = Color.Black;
            }
            dataBasePanel.EndUpdate();

            if (dataBasePanel.Items.Count > 0)
                dataBasePanel.Items[listIndex].EnsureVisible();  //  make sure next row is visible

            Cursor.Current = Cursors.Default;
            dr.Close();

        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    fill database panel
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void fillDataBasePanel(string commandString) {

            Cursor.Current = Cursors.WaitCursor;
            dataBasePanel.Items.Clear();  //  get rid of the other stuff

            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();
            FbCommand cmd = new FbCommand(commandString, mediaConn); //   from tMedia where Title NOT LIKE '%'the%'

            dr = cmd.ExecuteReader();

            CultureInfo ci = CultureInfo.CurrentCulture;
            NumberFormatInfo nfi = ci.NumberFormat;

            dataBasePanel.BeginUpdate();
            while (dr.Read()) {
                ListViewItem lvi = new ListViewItem((string)dr["SKU"]);

                if (dr["Title"].ToString().Length > 80)
                    lvi.SubItems.Add(dr["Title"].ToString().Substring(0, 80));
                else
                    lvi.SubItems.Add((string)dr["Title"]);

                if (dr["Quantity"].ToString().Length == 0)  // if Qty is blank, default is 0
                    lvi.SubItems.Add("0");
                else
                    lvi.SubItems.Add(dr["Quantity"].ToString());

                lvi.SubItems.Add((string)dr["UPC"]);

                if (!dr.IsDBNull(4))
                    lvi.SubItems.Add((string)dr["Locn"]);

                decimal workingPrice = 0.00M;  //  get price if it's there
                if (!dr.IsDBNull(5))
                    workingPrice = dr.GetDecimal(5);
                else
                    workingPrice = 0.00M;

                lvi.SubItems.Add(workingPrice.ToString("##,###.00", nfi));

                string xx = (string)dr["Stat"];
                lvi.SubItems.Add((string)dr["Stat"]);

                if (!dr.IsDBNull(7))
                    lvi.SubItems.Add((string)dr["InvoiceNbr"]);
                else
                    lvi.SubItems.Add("");

                if (dr["Stat"].Equals("Sold"))  //  make items that are sold light grey in color
                    lvi.SubItems[0].ForeColor = Color.LightGray;

                dataBasePanel.Tag = "Title";
                dataBasePanel.Items.Add(lvi);  // Add the list items to the ListView
            }

            dataBasePanel.EndUpdate();  //  now paint

            if (dataBasePanel.Items.Count > 0)
                dataBasePanel.EnsureVisible(0);   //  set listview to point to first record

            Cursor.Current = Cursors.Default;
            dr.Close();

        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    create command string
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public string createCommandString() {

            if (tsShowForSale.Checked == true)
                commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr from tMedia where Stat = 'For Sale' ";
            else if (tsShowSold.Checked == true)
                commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr from tMedia where Stat = 'Sold' ";
            else if (tsShowHold.Checked == true)
                commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr from tMedia where Stat = 'Hold' ";
            else if (tsShowPending.Checked == true)
                commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr from tMedia where Stat = 'Pending' ";
            else  //  show all
                commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr from tMedia ";

            if (cbSortOverride.Checked == true)
                commandString += rbSortAsc.Checked == true ? "ORDER BY DateA ASC" : "ORDER BY DateA DESC";
            else
                commandString += "ORDER BY SKU ASC";  //  ascending is default

            return commandString;

        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    does a 'drill down' search of the tMedia
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void drillDownSearch(string whatField, string fieldData) {
            if (fieldData.Length > 0)  //  make sure we have something to search for
            {
                fieldData = fieldData.Replace("'", "''");  //  replace single quote with two of 'em...
                if (tsShowForSale.Checked == true)
                    commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                        " from tMedia where Stat = 'For Sale'  and lower(" + whatField + ") like '" + fieldData.ToLower() + "%'";
                else if (tsShowSold.Checked == true)
                    commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                        " from tMedia where Stat = 'Sold'  and lower(" + whatField + ") like '" + fieldData.ToLower() + "%'";
                else if (tsShowHold.Checked == true)
                    commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                        " from tMedia where Stat = 'Hold' and lower(" + whatField + ") like '" + fieldData.ToLower() + "%'";
                else if (tsShowPending.Checked == true)
                    commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                        " from tMedia where Stat = 'Pending' and lower(" + whatField + ") like '" + fieldData.ToLower() + "%'";
                else  //  show all
                    commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                        " from tMedia where lower(" + whatField + ") like '" + fieldData.ToLower() + "%'";

            }

            fillDataBasePanel(commandString);
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    generic search
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void genericSearch(string whatField, string fieldData) {
            string s = "";
            int i = 0;

            if (fieldData.Contains("'"))  //  like L'Amour
                fieldData = fieldData.Replace("'", "''");

            if (fieldData.Contains("*"))  //  we are using the wild card...
            {
                i = fieldData.IndexOf('*');  //  remove the asterisk
                s = fieldData.Replace('*', '%');


                if (tsShowForSale.Checked == true)
                    commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tMedia where Stat = 'For Sale' and lower(" + whatField + ") like '" + s.ToLower() + "%'";
                else if (tsShowSold.Checked == true)
                    commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tMedia where Stat = 'Sold' and lower(" + whatField + ") like '" + s.ToLower() + "%'";
                else if (tsShowHold.Checked == true)
                    commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tMedia where Stat = 'Hold' and lower(" + whatField + ") like '" + s.ToLower() + "%'";
                else if (tsShowPending.Checked == true)
                    commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tMedia where Stat = 'Pending' and lower(" + whatField + ") like '" + s.ToLower() + "%'";
                else
                    commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tMedia where lower(" + whatField + ") like '" + s.ToLower() + "%'";
            }
            else  //  no wild card in data, but cbWildCardSearch was checked
            {
                if (tbsrchSKU.Text.Length > 0)
                    commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tMedia where lower(SKU) = '" + fieldData.ToLower() + "'";
                else if (tbsrchUPC.Text.Length > 0)
                    commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tMedia where lower(UPC) = '" + fieldData.ToLower() + "'";
                //else if (tbsrchAuthor.Text.Length > 0)
                //    commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                //                    " from tMedia where lower(Author) = '" + fieldData.ToLower() + "'";
                else if (tbsrchTitle.Text.Length > 0)
                    commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tMedia where lower(Title) = '" + fieldData.ToLower() + "'";
                else if (tbsrchKeywords.Text.Length > 0)
                    commandString = "select SKU, Title, UPC,  Quantity , Locn, Price, Stat, InvoiceNbr" +
                                    " from tMedia where lower(Keywds) = '" + fieldData.ToLower() + "'";
            }

            fillDataBasePanel(commandString);

        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    populate sql fields from detail panel
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private int PopulateFieldsFromDetailPanel() {

            //  SKU
            SKU = tbSKU.Text;

            //  title
            Title = tbTitle.Text.Length > 100 ? tbTitle.Text.Substring(0, 100) : tbTitle.Text;

            //  UPC
            UPC = tbUPC.Text;

            //  location
            Locn = tbLocn.Text;

            //  price
            int commaIndex = tbPrice.Text.IndexOf(',');
            if (commaIndex != -1) {
                Price = tbPrice.Text.Substring(0, commaIndex) + tbPrice.Text.Substring(commaIndex + 1, tbPrice.Text.Length - (commaIndex + 1));
            }
            else
                Price = tbPrice.Text;

            //  cost
            if (tbCost.Text == "")
                Cost = "1.00";  //  default to $1.00  
            else
                Cost = tbCost.Text;

            //  product type
            if (coProductType.Text.Length > 0)  //  is there a value there?
                ProductType = coProductType.Text;

            //  Publisher
            if (ProductType.Contains("Music"))
                Mfgr = tbMusicLabel.Text;
            else if (ProductType.Contains("Video"))
                Mfgr = tbStudio.Text;

            //  mfgr year
            if (ProductType.Contains("Music"))
                MfgrYear = tbMusicYear.Text.Length > 4 ? tbMusicYear.Text.Substring(0, 4) : tbMusicYear.Text;
            else if (ProductType.Contains("Video"))
                MfgrYear = tbVideoYear.Text.Length > 4 ? tbMusicYear.Text.Substring(0, 4) : tbMusicYear.Text;

            //  audio and video keywords
            if (coAudioKeywords.Text.Length > 0)
                AudioKeywords = coAudioKeywords.Text;
            else if (coVideoKeywords.Text.Length > 0)
                VideoKeywords = coVideoKeywords.SelectedItem.ToString();

            //  description
            Description = tbDesc.Text;  //  description of item

            //  condition
            Condition = cbCondition.Text;

            //  notes
            Notes = tbItemNote.Text.Trim();  //  notes on how this item is different from a "new" item

            //  status
            if (cbStatusHold.Checked == true && int.Parse(tbQty.Text) > 0)
                Status = "Hold";
            else if (int.Parse(tbQty.Text) == 0)
                Status = "Sold";
            else
                Status = "For Sale";

            //  do not reprice
            DoNotReprice = cbDoNotReprice.Checked == true ? "T" : "F";

            //  Image URL
            ImageURL = tbImageURL.Text;

            //  number of disks
            NbrOfDisks = tbNbrOfDisks.Text;

            //  shipping 
            Shipping = 0;  //  reset it...
            Shipping += cbDomStd.Checked ? (byte)32 : (byte)0;
            Shipping += cbDomExp.Checked ? (byte)16 : (byte)0;
            Shipping += cb2dDom.Checked ? (byte)8 : (byte)0;
            Shipping += cb1dDom.Checked ? (byte)4 : (byte)0;
            Shipping += cbIntlStd.Checked ? (byte)2 : (byte)0;
            Shipping += cbIntlExp.Checked ? (byte)1 : (byte)0;
            Shipping = Shipping == 0 ? 32 : Shipping;  //  if it's zero, set to Domestic Std as default

            //  Quantity
            Quantity = int.Parse(tbQty.Text);

            //  media type
            if (coMediaType.Text.Length > 0)
                MediaType = coMediaType.Text;

            //  audio format
            if (coAudioFormat.Text.Length > 0)
                AudioFormat = coAudioFormat.Text;

            //  MPAA rating
            if (coMPAA.Text.Length > 0)
                MPAARating = coMPAA.Text;

            //  audio encoding
            if (coAudioEncoding.Text.Length > 0)
                AudioEncoding = coAudioEncoding.Text;

            //  video format
            if (coVideoFormat.Text.Length > 0)
                VideoFormat = coVideoFormat.Text;

            //  language
            if (coLanguage.Text.Length > 0)
                Language = coLanguage.Text;

            //  runtime
            Runtime = tbRuntime.Text;

            //  sub-titles
            if (coSubTitles.Text.Length > 0)
                SubTitles = coSubTitles.Text;

            //  adult content
            AdultContent = cbAdult.Checked == true ? "Y" : "N";

            //  private notes (gets saved, but not uplaoded)
            PrivateNotes = tbPrivNotes.Text;

            //  orgin  (need to convert to 2 characters)
            if (coOrigin.Text.Length > 0) {
                string selectString = "SELECT * from tCountries WHERE CountryName = '" + coOrigin.Text + "'";
                dr = null;
                if (mediaConn.State != ConnectionState.Open)
                    mediaConn.Open();
                FbCommand cmd = new FbCommand(selectString, mediaConn);
                dr = cmd.ExecuteReader();
                dr.Read();  //  read the only line
                Origin = dr["CountryID"].ToString();
            }

            //  audio keywords
            if (coAudioKeywords.Text.Length > 0)
                AudioKeywords = coAudioKeywords.Text;

            //  video keywords
            if (coVideoKeywords.Text.Length > 0)
                VideoKeywords = coVideoKeywords.Text;

            //  vinyl details
            VinylDetails = tbVinylDetails.Text;

            //  Artist
            Artist = tbArtist.Text;

            //  composer
            Composer = tbComposer.Text;

            //  conductor
            Conductor = tbConductor.Text;

            //  orchestra
            Orchestra = tbOrchestra.Text;

            //  audio catalog entry (required if media type is LP)  <------------ TODO (verify LP)
            CatalogID = tbCatalogID.Text;

            //  asin
            ASIN = mtbASIN.Text;

            return (0);
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    add item to database  (called from bAddRecord_Click)
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void addRecord() {
            int rc = 0;  //  return code from addRecord

            if (cbAllowAddUpdate.Checked == false) {  //  check for required fields?
                if (checkForRequiredFields() == -1) {  //  some fields are missing...
                    return;
                }
                else
                    bAddRecord.Enabled = true;  // otherwise, make sure it's enabled
            }

            PopulateFieldsFromDetailPanel();

            ////  if option to increment Quantity if UPC is same
            //if (cbIncrQuantity.Checked) {  

            //    commandString = "SELECT UPC, QUANTITY FROM tMedia WHERE UPC = '" + tbUPC.Text + "'";  //  search for item by UPC

            //    if (bookConn.State == ConnectionState.Closed)
            //        bookConn.Open();

            //    FbCommand cmd = new FbCommand(commandString, bookConn);
            //    FbDataReader dr = null;
            //    dr = cmd.ExecuteReader();
            //    dr.Read();  //  read one row
            //    if (dr[0].ToString() == tbUPC.Text)
            //        Quantity++;     //  if it exists, increment Quantity
            //    dr.Close();  //  close the reader
            //}
            //else {
            if (tbQty.Text.Length == 0) {
                MessageBox.Show("Quantity is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                Quantity = int.Parse(tbQty.Text);

            if (cbAutomaticSKU.Checked == true) {  //  if we are doing auto-numbering...
                Int64 lastKey = findHighestSKU();
                lastKey = lastKey + 1;
                tbSKU.Text = tbSKUPrefix.Text.Length == 1 ? tbSKUPrefix.Text + lastKey.ToString() : lastKey.ToString();
                SKU = tbSKU.Text;
            }
            else {  // user has to supply SKU
                if (tbSKU.Text.Length == 0) {
                    MessageBox.Show("SKU is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            addButtonClicked = true;
            rc = tMediaAddItem();

            resetStrings();  //  clear out old stuff

            fillDataBasePanel(createCommandString());

            //updateCounters();  //  update export and upload counters

            backupNeeded = true;

            if (rc == 0)  //  only clear if we didn't have an error...
                clearDetailPanel();  //  clear the old stuff

            tbUPC.Text = "";
            tbUPC.Focus();  //  UPC entry has focus

            lbPricingResults.Items.Clear();
            lbPricingResults.Refresh();
            lbPrice.Items.Clear();
            lbPrice.Refresh();
            lbCondn.Items.Clear();
            lbCondn.Refresh();
            lListPrice.Text = "List Price:";  //  clear old price
            lListPrice.Refresh();
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    add an item to the table (NOT called from the import routines)
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int tMediaAddItem() {

            TimeSpan oneMinute = TimeSpan.FromMinutes(1);
            DateTime tempDate;

            if (addButtonClicked == false) {  //  this is an update  (11.1.0)
                if (lastExport.Equals(DateTime.MinValue))
                    lastExport = DateTime.Now;
                tempDate = lastExport.Subtract(TimeSpan.FromMinutes(1));
            }
            else  //  add button was clicked or flag was set, so we want to mark item for export
                tempDate = DateTime.Now.Add(oneMinute);

            //  bullet proofing...
            string tempDescr = "";
            if (Description != null) {
                tempDescr = Regex.Replace(Description, @"[\r\n]", " ");
                tempDescr = Regex.Replace(tempDescr, @"[']", "''");      //  replace single quotes with two of them...
            }
            if (Title != null)
                Title = Regex.Replace(Title, @"[']", "''");
            if (Mfgr != null)
                Mfgr = Regex.Replace(Mfgr, @"[']", "''");
            if (Notes != null)
                Notes = Regex.Replace(Notes, @"[']", "''");

            if (DateAdded == null || DateAdded.ToString().Length < 8) {
                DateAdded = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                DateUpdated = DateAdded;  //  indicates item was just added
            }

            Cost = Cost.Replace("\r\n", "");
            Price = Price.Replace("\r\n", "");
            Cost = (Cost.IndexOf('.') == -1) ? Cost + ".00" : Cost;
            Price = (Price.IndexOf('.') == -1) ? Price + ".00" : Price;

            CultureInfo ci = CultureInfo.CurrentCulture;
            NumberFormatInfo nfi = ci.NumberFormat;

            string firstChar = Price.Substring(0, 1);  //  get first character
            if (!IsNumeric(firstChar))
                Price = Price.Remove(0, 1);
            firstChar = Cost.Substring(0, 1);  //  get first character
            if (!IsNumeric(firstChar))
                Cost = Cost.Remove(0, 1);
            decimal decPrice = decimal.Parse(Price, nfi);
            decimal decCost = decimal.Parse(Cost, nfi);

            //  shipping
            Shipping = 0;  //  reset it...
            Shipping += cbDomStd.Checked ? (byte)32 : (byte)0;
            Shipping += cbDomExp.Checked ? (byte)16 : (byte)0;
            Shipping += cb2dDom.Checked ? (byte)8 : (byte)0;
            Shipping += cb1dDom.Checked ? (byte)4 : (byte)0;
            Shipping += cbIntlStd.Checked ? (byte)2 : (byte)0;
            Shipping += cbIntlExp.Checked ? (byte)1 : (byte)0;
            Shipping = Shipping == 0 ? 32 : Shipping;  //  if it's zero, set to Domestic Std as default

            //  tran code
            const char TranC = 'A';  //  this is an Add

            //  do not reprice flag
            DoNotReprice = cbDoNotReprice.Checked == true ? "T" : "F";

            String insertString =
                "insert into tMedia (SKU, TITLE, UPC, LOCN, PRICE, COST, TRANC, MFGR, MFGRYEAR, DESCR, CONDN, DATEA, DATEU, " +
                "NOTES, STAT, INVOICENBR, DONOTREPRICE, ImageURL, NBROFDISKS, SHIPPING, QUANTITY, MediaType, AUDIOFORMAT, " +
                "MPAARATING, AudioEncoding, VIDEOFORMAT, LANGUAGE, RUNTIME, SUBTITLES, ADULTCONTENT, PrivNotes, Origin, AudioKeywords," +
                "VideoKeywords, VinylDetails, Artist, Composer, Conductor, Orchestra, CatalogID, ProductType, ASIN) " +
                " values ('" + SKU +
                "', '" + Title +
                "', '" + UPC +
                "', '" + Locn +
                "', '" + decPrice +
                "', '" + decCost +
                "', '" + TranC +
                "', '" + Mfgr +
                "', '" + MfgrYear +
                "', '" + tempDescr +
                "', '" + Condition +
                "', '" + DateAdded +
                "', '" + DateUpdated +
                "', '" + Notes +
                "', '" + Status +
                "', '" + InvoiceNbr +
                "', '" + DoNotReprice +
                "', '" + ImageURL +
                "', '" + NbrOfDisks +
                "', '" + Shipping +
                "', '" + Quantity +
                "', '" + MediaType +
                "', '" + AudioFormat +
                "', '" + MPAARating +
                "', '" + AudioEncoding +
                "', '" + VideoFormat +
                "', '" + Language +
                "', '" + Runtime +
                "', '" + SubTitles +
                "', '" + AdultContent +
                "', '" + PrivateNotes +
                "', '" + Origin +
                "', '" + AudioKeywords +
                "', '" + VideoKeywords +
                "', '" + VinylDetails +
                "', '" + Artist +
                "', '" + Composer +
                "', '" + Conductor +
                "', '" + Orchestra +
                "', '" + CatalogID +
                "', '" + ProductType +
                "', '" + ASIN +
                "')";

            FbCommand cmd = new FbCommand(insertString, mediaConn);

            try {
                if (mediaConn.State == ConnectionState.Closed)
                    mediaConn.Open();

                cmd.ExecuteNonQuery();
            }

            catch (FbException ex) {

                if (ex.Message.Length > 36) {
                    if ((rbRejectRecord.Checked == true && addButtonClicked == false) && ex.Message.Substring(0, 40) == "String or binary data would be truncated") {
                        lbRejectedRecords.Items.Add(SKU + ": Data too long");
                        lbRejectedRecords.Refresh();
                        lRecordsRejected.Text = "Records rejected: " + ++rejectedCount;
                        lRecordsRejected.Refresh();

                        tabTaskPanel.SelectTab(cImport);
                        return -1;
                    }

                    if (ex.Message.Substring(0, 42).ToLower().Contains("arithmetic exception, numeric overflow,")) {
                        lbRejectedRecords.Items.Add(SKU + ": invalid numeric field or string truncation");
                        lbRejectedRecords.Refresh();
                        lRecordsRejected.Text = "Records rejected: " + ++rejectedCount;
                        lRecordsRejected.Refresh();
                        lbStatus.Items.Insert(0, "Rejected: " + insertString);  //  debugging !  <------------

                        tabTaskPanel.SelectTab(cImport);
                        return -1;
                    }

                    if (ex.Message.Substring(0, 34).Contains("violation of PRIMARY or UNIQUE KEY") && addButtonClicked == true) {
                        if (rbCreateNewKey.Checked == true) {   //  do they want us to create a new SKU?
                            Int64 lastKey = findHighestSKU();
                            lastKey++;
                            tbSKU.Text = tbSKUPrefix.Text.Length == 1 ? tbSKUPrefix.Text + lastKey.ToString() : lastKey.ToString();
                            SKU = tbSKU.Text;

                            tMediaAddItem();  //  try it again...
                            return 0;
                        }
                        else if (rbReplaceRecord.Checked == true) {  //  replace the record on duplicate SKU?
                            string fbUpdateString = @"UPDATE tMedia SET " +
                                "Title = '" + Title +
                                "', UPC = '" + UPC +
                                "', Locn = '" + Locn +
                                "', Price = " + decPrice +
                                ", Cost = " + decCost +
                                ", TranC = 'U" +
                                "', Mfgr = '" + Mfgr +
                                "', MfgrYear = '" + MfgrYear +
                                "', Descr = '" + Description +
                                "', Condn = '" + Condition +
                                "', DateA = '" + DateAdded +
                                "', DateU = '" + DateUpdated +
                                "', Notes = '" + Notes +
                                "', Stat = '" + Status +
                                "', InvoiceNbr = '" + InvoiceNbr +
                                "', DoNotReprice = '" + DoNotReprice +
                                "', ImageURL = '" + ImageURL +
                                "', NbrOfDisks = '" + NbrOfDisks +
                                "', Shipping = " + Shipping +
                                ", Quantity = " + Quantity +
                                ", MediaType = '" + MediaType +
                                "', AudioFormat = '" + AudioFormat +
                                "', MPAARating = '" + MPAARating +
                                "', AudioEncoding = '" + AudioEncoding +
                                "', VideoFormat = '" + VideoFormat +
                                "', Language = '" + Language +
                                "', Runtime = '" + Runtime +
                                "', SUBTITLES = '" + SubTitles +
                                "', AdultContent = '" + AdultContent +
                                "', PrivNotes = '" + PrivateNotes +
                                "', Origin = '" + Origin +
                                "', AudioKeywords = '" + AudioKeywords +
                                "', VideoKeywords = '" + VideoKeywords +
                                "', VinylDetails = '" + VinylDetails +
                                "', Artist = '" + Artist +
                                "', Composer = '" + Composer +
                                "', Conductor = '" + Conductor +
                                "', Orchestra = '" + Orchestra +
                                "', CatalogID = '" + CatalogID +
                                "', ProductType = '" + ProductType +
                                "', ASIN = '" + ASIN +
                                "' WHERE SKU = '" + SKU + "'";


                            cmd.CommandText = fbUpdateString;
                            cmd.Connection = mainForm.mediaConn;
                            cmd.ExecuteNonQuery();
                        }
                        else  //  no, reject the item
                        {
                            MessageBox.Show("Error: duplicate SKU (" + SKU + "); see 'What do you want to do with duplicate SKU's' on Import page to resolve this automatically.", "Prager Media Inventory Manager",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                    }
                    else {  //  reject the item
                        if (ex.Message.Substring(0, 34).Contains("violation of PRIMARY or UNIQUE KEY"))
                            MessageBox.Show("Error: duplicate SKU (" + SKU + "); see 'What do you want to do with duplicate SKU's' on Import page to resolve this automatically.", "Prager Media Inventory Manager",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Error: adding media item (" + SKU + ") - " + ex.Message, "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return -2;  //  duplicate SKU
                    }
                }
            }

            cmd.Dispose();

            //  move book number (SKU) to XML file as last used  <-------------------------TODO  
            return 0;

        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--   update media table
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public int tMediaUpdateRecord() {

            if (PopulateFieldsFromDetailPanel() == 0) {
                DateTime tempDateTime = DateTime.Now;  //  date/time updated
                string newDateTime = tempDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                //  remove single quotes
                Description = Description.Replace("'", "''");
                Title = Title.Replace("'", "''");
                Mfgr = Mfgr.Replace("'", "''");
                Notes = Notes.Replace("'", "''");
                Locn = Locn.Replace("'", "''");
                if (AudioKeywords != null)
                    AudioKeywords = AudioKeywords.Replace("'", "''");
                if (VideoKeywords != null)
                    VideoKeywords = VideoKeywords.Replace("'", "''");

                //  validate price and cost
                string firstChar = Price.Substring(0, 1);  //  get first character
                if (!IsNumeric(firstChar))
                    Price = Price.Remove(0, 1);
                firstChar = Cost.Substring(0, 1);  //  get first character
                if (!IsNumeric(firstChar))
                    Cost = Cost.Remove(0, 1);

                Regex.Replace(Description, @"[\r\n]", " ");

                //  do not reprice
                DoNotReprice = cbDoNotReprice.Checked == true ? "T" : "F";

                //  set culture information
                CultureInfo ci = CultureInfo.CurrentCulture;
                NumberFormatInfo nfi = ci.NumberFormat;

                string updateString = @"UPDATE tMedia SET " +
                    "Title = '" + Title +
                    "', UPC = '" + UPC +
                    "', Locn = '" + Locn +
                    "', Price = " + Price.Replace(nfi.CurrencyDecimalSeparator, ".") +
                    ", Cost = " + Cost.Replace(nfi.CurrencyDecimalSeparator, ".") +
                    ", TranC = 'U" +
                    "', Mfgr = '" + Mfgr +
                    "', MfgrYear = '" + MfgrYear +
                    "', Descr = '" + Description +
                    "', Condn = '" + Condition +
                    "', DateU = '" + newDateTime +
                    "', Notes = '" + Notes +
                    "', Stat = '" + Status +
                    "', InvoiceNbr = '" + InvoiceNbr +
                    "', DoNotReprice = '" + DoNotReprice +
                    "', ImageURL = '" + ImageURL +
                    "', NbrOfDisks = '" + NbrOfDisks +
                    "', Shipping = " + Shipping +
                    ", Quantity = " + Quantity +
                    ", MediaType = '" + MediaType +
                    "', AudioFormat = '" + AudioFormat +
                    "', MPAARating = '" + MPAARating +
                    "', AudioEncoding = '" + AudioEncoding +
                    "', VideoFormat = '" + VideoFormat +
                    "', Language = '" + Language +
                    "', Runtime = '" + Runtime +
                    "', SUBTITLES = '" + SubTitles +
                    "', AdultContent = '" + AdultContent +
                    "', PrivNotes = '" + PrivateNotes +
                    "', Origin = '" + Origin +
                    "', AudioKeywords = '" + AudioKeywords +
                    "', VideoKeywords = '" + VideoKeywords +
                    "', VinylDetails = '" + VinylDetails +
                    "', Artist = '" + Artist +
                    "', Composer = '" + Composer +
                    "', Conductor = '" + Conductor +
                    "', Orchestra = '" + Orchestra +
                    "', CatalogID = '" + CatalogID +
                     "', ProductType = '" + ProductType +
               "' WHERE SKU = '" + tbSKU.Text + "'";

                try {
                    FbCommand cmd = new FbCommand(updateString);
                    cmd.Connection = mediaConn;
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (FbException ex) {
                    lbStatus.ForeColor = Color.Red;
                    lbStatus.Refresh();
                    lbStatus.Items.Insert(0, "Record rejected during update: SKU=" + SKU + " UPC=" + UPC + " " + ex.Message);
                    lbStatus.ForeColor = Color.Black;
                    lbStatus.Refresh();

                    lRecordsRejected.Text = "Records rejected: " + ++rejectedCount;
                    lRecordsRejected.Refresh();
                    tabTaskPanel.SelectedIndex = cStatus;  //  show log

                    return -1;
                }

                //tbsrchAuthor.Text = "";  //  clear the search text boxes
                tbsrchSKU.Text = "";
                tbsrchUPC.Text = "";
                tbsrchTitle.Text = "";

                if (cbFreezeDBPanel.Checked == false && tbSKU.Text.Length > 0)  //  OK to refresh the database panel?
                    updateDataBasePanel(tbSKU.Text);  //  refresh database panel (send SKU)
            }

            return 0;
        }



        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    find highest SKU
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public Int64 findHighestSKU() {

            //  get all of the SKUs and place them in an array
            ArrayList al = new ArrayList();
            commandString = "select max(SKU) from tMedia";
            string tempSKU;

            FbDataReader rdr = null;
            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();
            FbCommand cmd = new FbCommand(commandString, mediaConn);
            rdr = cmd.ExecuteReader();

            while (rdr.Read()) {
            //    tempSKU = "";
            //    if (rdr[0] != DBNull.Value)  //  remove prefix if applicable
            //        //   && !IsNumeric(rdr[0].ToString().Substring(0, 1))
            //        tempSKU = rdr[0].ToString().Substring(1, rdr[0].ToString().Length - 1);

                if (IsInteger(rdr[0]))
                    al.Add(Int64.Parse((string)rdr[0]));
                    //al.Add(Int64.Parse(tempSKU));  //  add sku to array???
            }

            if (al.Count == 0 && cbAutomaticSKU.Checked == true)  //  if first time and they forgot to put in a starting SKU
                return Int64.Parse(tbStartingSKU.Text);

            //  now find the highest numeric SKU in the array and return it as int64
            al.Sort();
            Int64 debugInt = (Int64)al[al.Count - 1];
            cmd.Dispose();

            return (Int64)al[al.Count - 1];
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update counters
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void updateCounters() {

            CultureInfo ci = System.Globalization.CultureInfo.CurrentCulture;  //  Thread.CurrentThread.CurrentCulture;  
            string lastExportDate = lastExport.ToString("MM/dd/yyyy HH:mm:ss", ci);
            lastExportDate = Regex.Replace(lastExportDate, "AM|PM|a.m.|p.m.", "");

            if (lastExport.ToString("mm-dd-yyyy").Substring(0, 10) == "01/01/0001")  //  nothing was exported...
                return;

            commandString = "select COUNT(*) from tMedia where Stat != 'Hold' and DateU > '" + lastExportDate.Trim() + "'";
            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();
            FbCommand cmd = new FbCommand(commandString, mediaConn);

            int itemCount = 0;
            try {
                itemCount = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex) {
                if (ex.Message.Contains("Error reading data from the connection"))
                    MessageBox.Show("Unable to reach database; check your client/server", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            lItemsWaiting.Text = itemCount.ToString() + " items waiting to be exported";  //  on import/export tab
            lItemsWaiting.Refresh();
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    checks for required fields
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private int checkForRequiredFields() {
            if (tbQty.Text.Length == 0) {
                MessageBox.Show("Quantity is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (int.Parse(tbQty.Text) == 0)  //  if we are marking item Sold, don't check any further
                return 0;

            if (int.Parse(tbQty.Text) > 0) {
                if (tbSKU.Text.Length == 0 && cbAutomaticSKU.Checked == false) {
                    MessageBox.Show("SKU is missing and do not have Automatic SKU Numbering checked", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }

                if (tbTitle.Text.Length == 0) {
                    MessageBox.Show("Title is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!cbAllowAddUpdate.Checked)
                        return -1;
                }

                if (tbPrice.Text.Length == 0) {
                    MessageBox.Show("Price is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!cbAllowAddUpdate.Checked)
                        return -1;
                }
                if (tbMusicLabel.Text.Length == 0 && tbStudio.Text.Length == 0) {
                    MessageBox.Show("Music Label or Studio entry is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //if (!cbAllowAddUpdate.Checked)
                    return -1;
                }

                if (coProductType.Text.Length == 0) {
                    MessageBox.Show("Product Type missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!cbAllowAddUpdate.Checked)
                        return -1;
                }

                if (cbCondition.Text.Length == 0) {
                    MessageBox.Show("Condition is missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!cbAllowAddUpdate.Checked)
                        return -1;
                }

                DialogResult dg = DialogResult.None;  //  initialize

                if (cbWarnNoLocation.Checked == true && tbLocn.Text.Length == 0) {
                    dg = MessageBox.Show("Location entry is missing; do you want to continue anyway?", "Prager Media Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dg == DialogResult.No)
                        return -1;
                }

            }

            return 0;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    delete media entry from table
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private int tMediaDeleteEntry(string SKU) {
            commandString = "DELETE FROM tMedia where SKU = '" + SKU + "'";
            sqlCmd = new FbCommand(commandString, mediaConn);

            DialogResult dg = DialogResult.None;  //  initialize
            if (cbVerifyDeletes.Checked == true)
                dg = MessageBox.Show("Are you sure you want to delete this record?", "Verify Deletion", MessageBoxButtons.YesNoCancel);

            if (dg == DialogResult.Yes || cbVerifyDeletes.Checked == false) {
                try {
                    if (mediaConn.State == ConnectionState.Closed)
                        mediaConn.Open();

                    sqlCmd.ExecuteNonQuery();
                }
                catch (System.Exception ex) {
                    MessageBox.Show("Error deleting record " + SKU + "\r" + ex.Message);
                }
                finally {
                    Cursor.Current = Cursors.Default;
                    //createCommandString();
                    //clearDetailPanel();  //  remove reminants of book just deleted
                    //fillListViewPanel(commandString);
                }
            }
            else if (dg == DialogResult.Cancel)
                return -1;

            return 0;

        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    relist an item
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void relistItem() {
            if (!statusForSale && int.Parse(tbQty.Text) == 0)  //  only do this if item is marked Sold and quantity is zero
            {
                if (cbAutomaticSKU.Checked == true) {  //  if we are doing auto-numbering...
                    Int64 lastKey = findHighestSKU();
                    lastKey = lastKey + 1;
                    tbSKU.Text = tbSKUPrefix.Text.Length == 1 ? tbSKUPrefix.Text + lastKey.ToString() : lastKey.ToString();
                    SKU = tbSKU.Text;
                }
                else {  // user has to supply SKU
                    tbSKU.Enabled = true;  //  enable entering new SKU
                    if (tbSKU.Text.Length == 0) {
                        MessageBox.Show("SKU is missing", "Prager Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                int rc = PopulateFieldsFromDetailPanel();
                if (rc == 0) {
                    Quantity = 1;  //  override 
                    Status = "For Sale";
                    addButtonClicked = true;
                    tMediaAddItem();
                }

                resetStrings();  //  clear out old stuff

                createCommandString();
                fillDataBasePanel(commandString);  //  fill the listview panel

                backupNeeded = true;

                clearDetailPanel();  //  clear the old stuff
                tbUPC.Focus();  //  UPC entry has focus

                lbPricingResults.Items.Clear();
                lbPricingResults.Refresh();
                lbPrice.Items.Clear();
                lbPrice.Refresh();
                lbCondn.Items.Clear();
                lbCondn.Refresh();
                lListPrice.Text = "List Price:";  //  clear old price
                lListPrice.Refresh();
            }
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update item statistics
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void updateItemStatistics() {
            Cursor.Current = Cursors.WaitCursor;
            string currentYear = null;

            if (lbAcctgYear.SelectedIndex.Equals(-1))
                currentYear = DateTime.Today.Year.ToString();
            else
                currentYear = lbAcctgYear.SelectedItem.ToString();

            //  database statistics
            string selectStatement = "select sum(Quantity) from tMedia WHERE Stat <> 'Sold'";
            //string selectStatement = "select sum(Quantity) from tMedia";
            FbCommand cmd = new FbCommand(selectStatement, mediaConn);
            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();
            object result = cmd.ExecuteScalar();
            int Count = (result == DBNull.Value ? 0 : Convert.ToInt32(result));
            lblTotalCount.Text = "Total In Inventory:    " + Count.ToString();

            selectStatement = "select sum(Quantity) from tMedia where Stat = 'For Sale'";
            //selectStatement = "select sum(Quantity) from tMedia where Stat = 'For Sale'";
            cmd = new FbCommand(selectStatement, mediaConn);
            int forSaleCount = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            lblSaleCount.Text = "For Sale:    " + forSaleCount.ToString();

            selectStatement = "select COUNT(*) from tMedia where Stat = 'Sold'";
            cmd = new FbCommand(selectStatement, mediaConn);
            //Count = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            Count = (result == DBNull.Value ? 0 : Convert.ToInt32(result));
            lblSoldCount.Text = "Sold:    " + Count.ToString();

            selectStatement = "select COUNT(*) from tMedia where Stat = 'Pending'";
            cmd = new FbCommand(selectStatement, mediaConn);
            //Count = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            Count = (result == DBNull.Value ? 0 : Convert.ToInt32(result));
            lblPendingCount.Text = "Pending:    " + Count.ToString();

            selectStatement = "select coalesce(count(Quantity),0) from tMedia where Stat = 'Hold'";
            cmd = new FbCommand(selectStatement, mediaConn);
            //Count = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            //Count = (result == DBNull.Value ? 0 : Convert.ToInt32(result));
            result = cmd.ExecuteScalar();
            Count = (result == DBNull.Value ? 0 : Convert.ToInt32(result));
            lblHoldCount.Text = "Hold:    " + Count.ToString();

            //  accounting data by year  
            selectStatement = "select sum(Cost) from tMedia where Stat = 'For Sale' and EXTRACT(YEAR FROM DateU) = '" + currentYear + "'";
            cmd = new FbCommand(selectStatement, mediaConn);
            //decimal tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            decimal tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblTotalCost.Text = "Total Inventory Cost:    " + String.Format("{0:c}", tempDollars);

            //  total value
            selectStatement = "select sum(Price * Quantity) as totalValue from tMedia where Stat = 'For Sale' ";
            cmd = new FbCommand(selectStatement, mediaConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblTotalValue.Text = "Total Inventory Value:    " + String.Format("{0:c}", tempDollars);

            //  1st quarter sales figures
            selectStatement = @"select SUM(Price) from tMedia where Stat = 'Sold' and extract(month from DateU) >= 1 " +
                "and extract(month from DateU) <= 3 and extract(year from DateU) = " + currentYear;
            cmd = new FbCommand(selectStatement, mediaConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblQtr1Sales.Text = @"1st Qtr:    " + String.Format("{0:c}", tempDollars);

            //  2nd quarter sales figures
            selectStatement = @"select SUM(Price) from tMedia where Stat = 'Sold' and extract(month from DateU) >= 4 " +
                "and extract(month from DateU) <= 6 and extract(year from DateU) = " + currentYear;
            cmd = new FbCommand(selectStatement, mediaConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblQtr2Sales.Text = @"2nd Qtr:    " + String.Format("{0:c}", tempDollars);

            //  3rd quarter sales figures
            selectStatement = @"select sum(Price) from tMedia where Stat = 'Sold' and extract(month from DateU) >= 7 " +
                "and extract(month from DateU) <= 9 and extract(year from DateU) = " + currentYear;
            cmd = new FbCommand(selectStatement, mediaConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblQtr3Sales.Text = @"3nd Qtr:    " + String.Format("{0:c}", tempDollars);

            //  4th quarter sales figures
            selectStatement = @"select sum(Price) from tMedia where Stat = 'Sold' and extract(month from DateU) >= 10 " +
                "and extract(month from DateU) <= 12 and extract(year from DateU) = " + currentYear;
            cmd = new FbCommand(selectStatement, mediaConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblQtr4Sales.Text = @"4th Qtr:    " + String.Format("{0:c}", tempDollars);

            //  ytd sales figures
            selectStatement = "select sum(Price) from tMedia where Stat = 'Sold' " +
                "and extract(year from DateU) = '" + currentYear + "'";
            cmd = new FbCommand(selectStatement, mediaConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblTotalYTD.Text = @"Total Sales YTD:    " + String.Format("{0:c}", tempDollars);

            //  1st Q cost of goods figures
            selectStatement = @"select sum(Cost) from tMedia where extract(month from DateU) >= 1 " +
                "and extract(month from DateU) <= 3 and extract(year from DateA) = " + currentYear;
            cmd = new FbCommand(selectStatement, mediaConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblCOG1.Text = @"1st Qtr:    " + String.Format("{0:c}", tempDollars);

            //  2nd Q cost of goods figures
            selectStatement = @"select sum(Cost) from tMedia where extract(month from DateU) >= 3 " +
                "and extract(month from DateU) <= 6 and extract(year from DateA) = " + currentYear;
            cmd = new FbCommand(selectStatement, mediaConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblCOG2.Text = @"2nd Qtr:    " + String.Format("{0:c}", tempDollars);


            //  3rd Q cost of goods figures
            selectStatement = @"select sum(Cost) from tMedia where extract(month from DateU) >= 7 " +
                "and extract(month from DateU) <= 9 and extract(year from DateA) = " + currentYear;
            cmd = new FbCommand(selectStatement, mediaConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblCOG3.Text = @"3rd Qtr:    " + String.Format("{0:c}", tempDollars);

            //  4th Q cost of goods figures
            selectStatement = @"select sum(Cost) from tMedia where extract(month from DateU) >= 10 " +
                "and extract(month from DateU) <= 12 and extract(year from DateA) = " + currentYear;
            cmd = new FbCommand(selectStatement, mediaConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblCOG4.Text = @"4th Qtr:    " + String.Format("{0:c}", tempDollars);


            //  ytd CostofGoods figures
            selectStatement = "select sum(Cost) from tMedia where extract(year from DateA) = '" + currentYear + "'";
            cmd = new FbCommand(selectStatement, mediaConn);
            //tempDollars = cmd.ExecuteScalar() is DBNull ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            result = cmd.ExecuteScalar();
            tempDollars = (result == DBNull.Value ? 0 : Convert.ToDecimal(result));
            lblTotalCostofGoods.Text = @"Total Cost YTD:    " + String.Format("{0:c}", tempDollars);

            Cursor.Current = Cursors.Default;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    using T-SQL statements, change prices in d/b
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void changePrices() {
            //string commandString = "";

            //  do some error checking
            if (rbAmount.Checked == false && rbPercentage.Checked == false && rbAbsolute.Checked == false) {
                MessageBox.Show("You must check either Amount, Percentage or Absolute Amount", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else {
                if (tbAmount.Text.Length == 0) {
                    MessageBox.Show("You must enter either an amount or percentage", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Cursor.Current = Cursors.WaitCursor;

            lbStatus.Items.Insert(0, "started changing prices");
            lbStatus.Refresh();

            DateTime newDateTime = DateTime.Now;

            //  determine what we are going to change
            if (rbAll.Checked == true)  //  are we are going to price all of them?
                commandString = "select * from tMedia where Stat = 'For Sale'";
            else {
                if (rbPriceRange.Checked == true)  //  or are we going to do a range?
                {
                    if (tbPriceFrom.Text == " " || tbPriceTo.Text == " ") {
                        MessageBox.Show("Price From and/or Price To are invalid", "Prager Media Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        commandString = @"select * from tMedia where Stat = 'For Sale' and
                             Price >= '" + tbPriceFrom.Text + @"' and Price <= '" + tbPriceTo.Text + "'";
                }  //  end range
                else {
                    if (rbCatalog.Checked == true) {
                        if (lbChangePricesCat.SelectedIndex != 0) {
                            commandString = @"select * from tMedia where Stat = 'For Sale' and Cat = '" +
                               lbChangePricesCat.Text + "'";
                        }
                    }
                    else {
                        if (rbSKU.Checked == true)  //  do a range of item numbers
                        {
                            commandString = @"select * from tMedia where Stat = 'For Sale' " +
                                "and SKU >= '" + tbBkNbrFrom.Text + "' and SKU <= '" + tbBkNbrTo.Text + "'";

                        }
                    }
                }
            }

            dataAdapter = new FbDataAdapter(commandString, mediaConn);  //  <-------------------------------- TODO
            dataSet = new DataSet();  //  create a new dataset
            dataAdapter.Fill(dataSet, "tMedia");  //  fill the dataset from rows in the Table
            dataTable = dataSet.Tables[0];  //  pick out my table from tMedia

            FbCommandBuilder commandBuilder = new FbCommandBuilder(dataAdapter);

            decimal amount;
            decimal decimalAmt = 0.00M;
            const decimal one = 1.00M;
            decimal pctg = Convert.ToDecimal(tbAmount.Text) / 100;

            if (rbIncrease.Checked == true)  //  increase prices...
            {
                pctg = decimal.Add(pctg, one);
                foreach (DataRow dataRow in dataTable.Rows) {
                    amount = decimal.Parse(dataRow["Price"].ToString());  //  get the price to update

                    if (rbAmount.Checked == true)  //  update by amount
                        amount += decimal.Parse(tbAmount.Text.ToString());
                    else  //  update by percentage
                    {
                        decimalAmt = amount;
                        amount = Math.Round(decimalAmt * pctg, 2);
                    }
                    int rowIndex = dataTable.Rows.IndexOf(dataRow);
                    dataSet.Tables["tMedia"].Rows[rowIndex]["Price"] = amount.ToString();
                    dataSet.Tables["tMedia"].Rows[rowIndex]["DateU"] = newDateTime;  //  updated now...
                    amount = 0;  //  clear it
                }
            }
            else  //  decrease prices?
            {
                if (rbDecrease.Checked == true) {
                    pctg = decimal.Subtract(one, pctg);
                    foreach (DataRow dataRow in dataTable.Rows) {
                        amount = decimal.Parse(dataRow["Price"].ToString());  //  get the price to update

                        if (rbAmount.Checked == true)  //  update by amount
                            amount -= decimal.Parse(tbAmount.Text.ToString());
                        else  //  update by percentage
                        {
                            decimalAmt = amount;
                            amount = Math.Round(decimalAmt * pctg, 2);
                        }

                        int rowIndex = dataTable.Rows.IndexOf(dataRow);
                        dataSet.Tables["tMedia"].Rows[rowIndex]["Price"] = amount.ToString();
                        dataSet.Tables["tMedia"].Rows[rowIndex]["DateU"] = newDateTime;  //  updated now...
                        amount = 0;
                    }
                }  //  end decrease
                else //  must be absolute
                {
                    foreach (DataRow dataRow in dataTable.Rows) {
                        int rowIndex = dataTable.Rows.IndexOf(dataRow);
                        amount = Decimal.Parse(tbAmount.Text);
                        dataSet.Tables["tMedia"].Rows[rowIndex]["Price"] = amount.ToString();
                        dataSet.Tables["tMedia"].Rows[rowIndex]["DateU"] = newDateTime;  //  updated now...
                        //       amount = 0;
                    }

                }  //  end absolute
            }

            dataAdapter.Update(dataSet, "tMedia");  //  update database w/ changes
            dataSet.AcceptChanges();

            //  command string for displaying the items
            fillDataBasePanel(createCommandString());

            rbAmount.Checked = false;
            rbPercentage.Checked = false;

            lbStatus.Items.Insert(0, "price changes completed");
            lbStatus.Refresh();

            Cursor.Current = Cursors.Default;

        }  //  end changePrices


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    Inclusive search
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void doInclusiveSearch() {
            ArrayList ssColumnArray = new ArrayList();
            ssColumnArray.Add(cbSSColumn1);
            ssColumnArray.Add(cbSSColumn2);
            ssColumnArray.Add(cbSSColumn3);
            ssColumnArray.Add(cbSSColumn4);

            ArrayList ssCompareTypeArray = new ArrayList();
            ssCompareTypeArray.Add(lbSSCompare1);
            ssCompareTypeArray.Add(lbSSCompare2);
            ssCompareTypeArray.Add(lbSSCompare3);
            ssCompareTypeArray.Add(lbSSCompare4);

            ArrayList ssCompareToArray = new ArrayList();
            ssCompareToArray.Add(tbSSCompareTo1);
            ssCompareToArray.Add(tbSSCompareTo2);
            ssCompareToArray.Add(tbSSCompareTo3);
            ssCompareToArray.Add(tbSSCompareTo4);

            ArrayList ssAndOrArray = new ArrayList();
            ssAndOrArray.Add(null);
            ssAndOrArray.Add(lbSSAndOr2);
            ssAndOrArray.Add(lbSSAndOr3);
            ssAndOrArray.Add(lbSSAndOr4);

            //  make sure something is there to search for... (11.0.3)
            if (((cbSSColumn1.SelectedItem != null || (string)cbSSColumn1.SelectedItem != "") && tbSSCompareTo1.Text.Length == 0) &&  // tbSSCompareTo1.Text.Contains(" search terms go"))) ||
                 ((cbSSColumn2.SelectedItem != null || (string)cbSSColumn2.SelectedItem != "") && tbSSCompareTo2.Text.Length == 0) &&
                 ((cbSSColumn3.SelectedItem != null || (string)cbSSColumn3.SelectedItem != "") && tbSSCompareTo3.Text.Length == 0) &&
                 ((cbSSColumn4.SelectedItem != null || (string)cbSSColumn4.SelectedItem != "") && tbSSCompareTo4.Text.Length == 0)) {

                MessageBox.Show("If you select an item, you must provide search criteria", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            //  validate the request.. 
            if (cbSSColumn1.SelectedItem != null && (cbSSColumn1.SelectedItem.Equals("Date Added") || cbSSColumn1.SelectedItem.Equals("Date Updated"))) {
                if (tbSSCompareTo1.Text.IndexOf("-") == -1 && tbSSCompareTo1.Text.IndexOf(@"/") == -1 || tbSSCompareTo1.Text.IndexOf(".") != -1) {
                    MessageBox.Show("Date format must be either mm/dd/yyyy or mm-dd-yyyy", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (cbSSColumn2.SelectedItem != null)
                if (cbSSColumn2.SelectedItem.Equals("Date Added") || cbSSColumn2.SelectedItem.Equals("Date Updated")) {
                    if (tbSSCompareTo2.Text.IndexOf("-") == -1 && tbSSCompareTo2.Text.IndexOf(@"/") == -1) {
                        MessageBox.Show("Date format must be either mm/dd/yyyy or mm-dd-yyyy", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            if (cbSSColumn3.SelectedItem != null)
                if (cbSSColumn3.SelectedItem.Equals("Date Added") || cbSSColumn3.SelectedItem.Equals("Date Updated")) {
                    if (tbSSCompareTo3.Text.IndexOf("-") == -1 && tbSSCompareTo3.Text.IndexOf(@"/") == -1) {
                        MessageBox.Show("Date format must be either mm/dd/yyyy or mm-dd-yyyy", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            if (cbSSColumn4.SelectedItem != null)
                if (cbSSColumn4.SelectedItem.Equals("Date Added") || cbSSColumn4.SelectedItem.Equals("Date Updated")) {
                    if (tbSSCompareTo4.Text.IndexOf("-") == -1 && tbSSCompareTo4.Text.IndexOf(@"/") == -1) {
                        MessageBox.Show("Date format must be either mm/dd/yyyy or mm-dd-yyyy", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            int arrayNdx = 0;  //  index into the above arrays...

            StringBuilder sb = new StringBuilder("select SKU, Title, UPC, Quantity, Locn, Price, Stat, InvoiceNbr from tMedia where ");  //  initialize

            if (((ComboBox)ssColumnArray[arrayNdx]).SelectedIndex == -1 || ((ListBox)ssCompareTypeArray[arrayNdx]).SelectedIndex == -1) {
                MessageBox.Show("You must click on your selection so it turns blue", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (((ComboBox)ssColumnArray[arrayNdx]).SelectedItem.ToString())  //  first selection
            {
                case "SKU":
                    sb.Append("SKU ");
                    break;
                case "Location":
                    sb.Append("Locn ");
                    break;
                case "Manufacturer":
                    sb.Append("Mfgr ");
                    break;
                case "Year Published":
                    sb.Append("MfgrYear ");
                    break;
                case "Audio Keywords":
                    sb.Append("AudioKeywords ");
                    break;
                case "Video Keywords":
                    sb.Append("VideoKeywords ");
                    break;
                case "Description":
                    sb.Append("Descr ");
                    break;
                case "Condition":
                    sb.Append("Condn ");
                    break;
                case "Invoice Nbr":
                    sb.Append("InvoiceNbr ");
                    break;
                case "Media Type":
                    sb.Append("MediaType ");
                    break;
                case "Audio Format":
                    sb.Append("AudioFormat ");
                    break;
                case "MPAA Rating":
                    sb.Append("MPAARating ");
                    break;
                case "Audio Encoding":
                    sb.Append("AudioEncoding ");
                    break;
                case "Video Format":
                    sb.Append("VideoFormat ");
                    break;
                case "Sub-Titles":
                    sb.Append("Subtitles ");
                    break;
                case "Adult Content":
                    sb.Append("AdultContent ");
                    break;
                case "Product Type":
                    sb.Append("ProductType ");
                    break;


                //  for dates: select SKU, Title, Locn, DateA from tMedia where extract(month from DateA) = '01' and
                //  extract(day from DateA) = '10' and extract(year from DateA) = '2005'  <------------------ TODO

                case "Date Added":
                    sb.Append("DateA ");
                    break;
                case "Date Updated":
                    sb.Append("DateU ");
                    break;
                case "Catalog ID":
                    sb.Append("CatalogID ");
                    break;
                case "Private Notes":
                    sb.Append("PrivNotes ");
                    break;
                case "Status":
                    sb.Append("Stat ");
                    break;
                case "Quantity":
                case "Title":
                case "UPC":
                case "Price":
                case "Notes":
                case "Language":
                case "Artist":
                case "Composer":
                case "Conductor":
                case "Orchestra":
                case "Origin":
                case "ASIN":
                case "Runtime":
                case "Cost":
                    //case "Shipping":
                    sb.Append(((ComboBox)ssColumnArray[arrayNdx]).SelectedItem.ToString() + " ");
                    break;
                default:
                    break;
            }

            // Get the number of times asterisks are in the string
            int asteriskCount = Regex.Matches(((TextBox)ssCompareToArray[arrayNdx]).Text, @"\*").Count;

            //  check to see if there is a wildcard (asterisk) with an equal compare
            r = new Regex("[*]");
            m = r.Match(((TextBox)ssCompareToArray[arrayNdx]).Text);

            if (m.Success) {
                switch (((ListBox)ssCompareTypeArray[arrayNdx]).SelectedItem.ToString())  //  first selection
                {
                    case "is equal to":
                        sb.Append("LIKE '");
                        sb.Append(r.Replace(((TextBox)ssCompareToArray[arrayNdx]).Text, @"%"));
                        sb.Append("'");  //  trailing quote
                        break;
                    case "is not equal to":
                        sb.Append("NOT LIKE '");
                        sb.Append(r.Replace(((TextBox)ssCompareToArray[arrayNdx]).Text, @"%"));
                        sb.Append("'");  //  trailing quote
                        break;
                    default:
                        MessageBox.Show("Error: can not use wildcard (*) with anything \r" +
                                         "other than 'is equal to' or 'is not equal to'",
                                         "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }
            else  //  no, just a regular compare
            {
                switch (((ListBox)ssCompareTypeArray[arrayNdx]).SelectedItem.ToString())  //  first selection
                {
                    case "is equal to":
                        sb.Append("= '");
                        break;
                    case "is not equal to":
                        sb.Append("<> '");
                        break;
                    case "is greater than":
                        sb.Append("> '");
                        break;
                    case "is less than":
                        sb.Append("< '");
                        break;
                    default:
                        break;
                }
                sb.Append(((TextBox)ssCompareToArray[arrayNdx]).Text + @"'");
            }


            int itemCount = 0;
            for (arrayNdx = 1; arrayNdx < 4; arrayNdx++) {
                if (((ListBox)ssAndOrArray[arrayNdx]).SelectedIndex != -1 && (((ComboBox)ssColumnArray[arrayNdx]).SelectedIndex == -1 || ((ListBox)ssCompareTypeArray[arrayNdx]).SelectedIndex == -1)) {
                    MessageBox.Show("You must click on your selection so it turns blue", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (((ListBox)ssAndOrArray[arrayNdx]).Text == "- - -" || ((ListBox)ssAndOrArray[arrayNdx]).Text == "") {
                    inclusiveSearchString = sb.ToString();  //  copy this just in case we are going to do an export
                    fillDataBasePanel(sb.ToString());
                    rbExportInclusiveSearch.Enabled = true;

                    itemCount = dataBasePanel.Items.Count;
                    lItemsReturned.Text = itemCount + " items found.";
                    return;
                }

                //  and/or selected...
                sb.Append(" " + ((ListBox)ssAndOrArray[arrayNdx]).Text + " ");

                switch (((ComboBox)ssColumnArray[arrayNdx]).SelectedItem.ToString())  //  second selection
                {
                    case "SKU":
                        sb.Append("SKU ");
                        break;
                    case "Location":
                        sb.Append("Locn ");
                        break;
                    case "Manufacturer":
                        sb.Append("Mfgr ");
                        break;
                    case "Year Published":
                        sb.Append("MfgrYear ");
                        break;
                    case "Audio Keywords":
                        sb.Append("AudioKeywords ");
                        break;
                    case "Video Keywords":
                        sb.Append("VideoKeywords ");
                        break;
                    case "Description":
                        sb.Append("Descr ");
                        break;
                    case "Condition":
                        sb.Append("Condn ");
                        break;
                    case "Invoice Nbr":
                        sb.Append("InvoiceNbr ");
                        break;
                    case "Media Type":
                        sb.Append("MediaType ");
                        break;
                    case "Audio Format":
                        sb.Append("AudioFormat ");
                        break;
                    case "MPAA Rating":
                        sb.Append("MPAARating ");
                        break;
                    case "Audio Encoding":
                        sb.Append("AudioEncoding ");
                        break;
                    case "Video Format":
                        sb.Append("VideoFormat ");
                        break;
                    case "Sub-Titles":
                        sb.Append("Subtitles ");
                        break;
                    case "Adult Content":
                        sb.Append("AdultContent ");
                        break;
                    case "Product Type":
                        sb.Append("ProductType ");
                        break;
                    case "Date Added":
                        sb.Append("DateA ");
                        break;
                    case "Date Updated":
                        sb.Append("DateU ");
                        break;
                    case "Catalog ID":
                        sb.Append("CatalogID ");
                        break;
                    case "Private Notes":
                        sb.Append("PrivNotes ");
                        break;
                    case "Status":
                        sb.Append("Stat ");
                        break;
                    case "Quantity":
                    case "Title":
                    case "UPC":
                    case "Price":
                    case "Notes":
                    case "Language":
                    case "Artist":
                    case "Composer":
                    case "Conductor":
                    case "Orchestra":
                    case "Origin":
                    case "ASIN":
                    case "Runtime":
                    case "Cost":
                        //case "Shipping":
                        sb.Append(((ComboBox)ssColumnArray[arrayNdx]).SelectedItem.ToString() + " ");
                        break;
                    default:
                        break;
                }

                // Get the number of times asterisks are in the string
                asteriskCount = Regex.Matches(((TextBox)ssCompareToArray[arrayNdx]).Text, @"\*").Count;

                //  check to see if there is a wildcard (asterisk) with an equal compare
                r = new Regex("[*]");
                m = r.Match(((TextBox)ssCompareToArray[arrayNdx]).Text);
                if (m.Success) {
                    switch (((ListBox)ssCompareTypeArray[arrayNdx]).SelectedItem.ToString())  //  second selection
                    {
                        case "is equal to":
                            sb.Append("LIKE '");
                            sb.Append(r.Replace(((TextBox)ssCompareToArray[arrayNdx]).Text, @"%"));
                            sb.Append("'");  //  trailing quote
                            break;
                        case "is not equal to":
                            sb.Append("NOT LIKE '");
                            sb.Append(r.Replace(((TextBox)ssCompareToArray[arrayNdx]).Text, @"%"));
                            sb.Append("'");  //  trailing quote
                            break;
                        default:
                            break;
                    }
                }
                else  //  no, just a regular compare
                {
                    switch (((ListBox)ssCompareTypeArray[arrayNdx]).SelectedItem.ToString())  //  second selection
                    {
                        case "is equal to":
                            sb.Append("= '");
                            break;
                        case "is not equal to":
                            sb.Append("<> '");
                            break;
                        case "is greater than":
                            sb.Append("> '");
                            break;
                        case "is less than":
                            sb.Append("< '");
                            break;
                        default:
                            break;
                    }
                    sb.Append(((TextBox)ssCompareToArray[arrayNdx]).Text + @"'");
                }
            }



            inclusiveSearchString = sb.ToString();  //  copy this just in case we are going to do an export
            fillDataBasePanel(sb.ToString());
            rbExportInclusiveSearch.Enabled = true;

            itemCount = dataBasePanel.Items.Count;
            lItemsReturned.Text = itemCount + " items found";

            return;
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    truncate tMedia table
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        internal void truncateMediaTable() {
            Cursor.Current = Cursors.WaitCursor;

            DialogResult dlgResult = DialogResult.None;
            dlgResult = MessageBox.Show("You have asked to delete all media currently in your inventory.\rAre you sure you want to do this?",
                "Prager Media Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.No)
                return;

            commandString = "delete from tMedia";
            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();

            sqlCmd = new FbCommand(commandString, mediaConn);
            try {
                sqlCmd.ExecuteNonQuery();
            }
            catch (System.Exception ex) {
                MessageBox.Show("Error deleting complete inventory" + ex, "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally {
                dataBasePanel.Items.Clear();  //  remove all of the "dead" stuff from the listview
                //importDataFile.Refresh();
                cbDeleteFirst.Checked = false;
                Cursor.Current = Cursors.Default;
            }
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    make mass changes
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void makeMassChange() {
            if (lbMChangeFields.SelectedIndex == -1) {
                MessageBox.Show("You must highlight a field", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fieldNameToChange = "";
            switch (lbMChangeFields.SelectedItem.ToString()) {
                case "Type":
                    fieldNameToChange = "Type";
                    break;
                case "Size":
                    fieldNameToChange = "Size";
                    break;
                case "Location":
                    fieldNameToChange = "Locn";
                    break;
                case "Keywords":
                    fieldNameToChange = "Keywds";
                    break;
                case "Cost":
                    fieldNameToChange = "Cost";
                    break;
                case "Jacket":
                    fieldNameToChange = "Jaket";
                    break;
                case "Binding":
                    fieldNameToChange = "Bndg";
                    break;
                case "Condition":
                    fieldNameToChange = "Condn";
                    break;
                case "Edition":
                    fieldNameToChange = "Ed";
                    break;
                case "Catalog":
                    fieldNameToChange = "Cat";
                    break;
                case "Private Notes":
                    fieldNameToChange = "Notes";
                    break;
                case "Mfgr":
                    fieldNameToChange = "Pub";
                    break;
                case "Shipping":
                    fieldNameToChange = "Shipping";
                    break;
                case "Date of Publication":
                    fieldNameToChange = "PubYear";
                    break;
                case "Mfgr Location":
                    fieldNameToChange = "PubPlace";
                    break;
                case "Signed by Author":
                case "Signed by Illustrator":
                case "Signed by Both":
                    fieldNameToChange = "Signed";
                    break;
                default:
                    break;

            }

            if (tbMChangeFrom.Text == "NULL" || tbMChangeFrom.Text.Length == 0)
                commandString = "UPDATE tMedia SET " + fieldNameToChange + " = '" + tbMChangeTo.Text + "' " +
                    " WHERE " + fieldNameToChange + " IS NULL"; //'" + tbMChangeFrom.Text + "'";
            else
                commandString = "UPDATE tMedia SET " + fieldNameToChange + " = '" + tbMChangeTo.Text + "' " +
                    " WHERE " + fieldNameToChange + " = '" + tbMChangeFrom.Text + "'";

            Cursor.Current = Cursors.WaitCursor;
            try {
                if (mediaConn.State == ConnectionState.Closed)
                    mediaConn.Open();
                sqlCmd = new FbCommand(commandString, mediaConn);

                sqlCmd.ExecuteNonQuery();
            }
            catch (System.Exception ex) {
                MessageBox.Show("Error updating record " + ex.Message + "\n" + ex.StackTrace);
            }
            finally {
                Cursor.Current = Cursors.Default;
                createCommandString();
                fillDataBasePanel(commandString);
            }

        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    remove "Will not ship int'l" message from description field
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void removeWillNotShip() {

            string alteredDesc = "";
            int mediaCount = 0;

            commandString = "SELECT SKU, Descr from tMedia";
            FbDataReader rdr = null;
            FbCommand selectCmd = new FbCommand(commandString, mediaConn);

            //  read media inventory
            rdr = selectCmd.ExecuteReader();
            while (rdr.Read()) {
                if (rdr[1].ToString().Contains("Will NOT ship international; ")) {
                    alteredDesc = rdr[1].ToString().Replace("Will NOT ship international; ", " ");
                    try {
                        string updateString = "UPDATE tMedia SET Descr = '" + alteredDesc + "' WHERE SKU = '" + rdr[0].ToString() + "'";
                        FbCommand tempCmd = new FbCommand(updateString, mediaConn);

                        tempCmd.ExecuteNonQuery();
                        mediaCount++;

                        lbStatus.Items.Add("SKU: '" + rdr[0] + "'");
                        lbStatus.Refresh();

                    }
                    catch (System.Exception ex) {
                        MessageBox.Show("Error updating record: " + ex.Message + "\n" + ex.StackTrace);
                    }
                }
            }

            lbStatus.Items.Add("Total modified: '" + mediaCount.ToString() + "'");
            lbStatus.Refresh();
            tabTaskPanel.SelectTab(cStatus);

        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    update from pricing service
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void updateFromPricingService() {
            lPricingServiceStatus.Text = "Updating media inventory...";

            lProgress.Visible = true;
            lProgress.Text = "Updating item 0 of " + lvPricingService.CheckedItems.Count.ToString();
            int recordCounter = 0;


            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();

            Cursor.Current = Cursors.WaitCursor;

            if (lvPricingService.CheckedItems.Count > 0)  //  make sure we have something to update
            {
                foreach (ListViewItem CurrentItem in lvPricingService.CheckedItems)  //  go through all of them
                {
                    string updateString = "UPDATE tMedia SET Price = " + CurrentItem.SubItems[8].Text.Trim() +
                        ", DateU = ' " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                        "',  TranC = 'U' WHERE SKU = '" + CurrentItem.SubItems[0].Text.Trim() + "'";
                    FbCommand cmd = new FbCommand(updateString, mediaConn);
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    ++recordCounter;
                    lProgress.Text = "Processing: " + recordCounter.ToString() + " of " + lvPricingService.CheckedItems.Count.ToString();
                    lProgress.Refresh();
                }

                fillDataBasePanel(createCommandString());
                //fillDataBasePanel("select SKU, Title, UPC,  NbrOfCopies, Locn, Price, Stat, InvoiceNbr from tMedia");
                Cursor.Current = Cursors.Default;
            }
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    get next item from table
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void getNextItemInList() {
            string searchString = "";
            FbDataReader dr = null;

            if (tbSKU.Text.Length == 0) {  // nothing selected, so give them an error message
                MessageBox.Show("Error: you must select an item to start with from the top panel", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else {
                searchString = "SELECT SKU FROM tMedia WHERE SKU = (SELECT MIN(SKU) FROM tMedia WHERE SKU > '" + tbSKU.Text + "')";
                if (mediaConn.State != ConnectionState.Open)
                    mediaConn.Open();
                sqlCmd = new FbCommand(searchString, mediaConn);
                dr = sqlCmd.ExecuteReader();

                if (!dr.Read()) {
                    dr.Close();
                    MessageBox.Show("There are no more records to display", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string sku = dr[0].ToString();

                PopulateDetailPanel(sku);
                bUpdateRecord.Enabled = true;  //  allow updates 
                updateNeeded = false;
            }
            dr.Close();
        }
    }
}

