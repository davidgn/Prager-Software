#region Using directives


using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

#endregion

namespace Prager_Book_Inventory
{
    partial class mainForm : Form
    {
        public string bookNbr;
        //---------------------------    populate the detail panel    ---------------------|
        private int PopulateDetailPanel(string bookNumber) {
            decimal convertedMoney;
            int i = 0;

            clearDetailPanel(false);  //  clear out old stuff (not doing an update)

            //  find book in table
            string strSQL = "SELECT * from tBooks where BookNbr = '" + bookNumber + "'";

            FbCommand command = new FbCommand(strSQL, bookConn);
            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();

            FbDataReader data = command.ExecuteReader();

            if (data.HasRows == false)
                return -1;

            CultureInfo ci = CultureInfo.CurrentCulture;
            NumberFormatInfo nfi = ci.NumberFormat;

            while (data.Read()) {
                tbBookNbr.Text = data["BookNbr"].ToString();  //  book number
                tbBookNbr.Enabled = false;  //  don't allow any changes to key
                tbTitle.Text = data["Title"].ToString();  //  title
                tbAuthor.Text = data["Author"].ToString();  //  author
                mtbISBN.Text = data["ISBN"].ToString();
                tbIllus.Text = data["Illus"].ToString();
                tbLocn.Text = data["Locn"].ToString();

                convertedMoney = (decimal)data["Price"];
                tbListPrice.Text = String.Format("{0:c}", convertedMoney);  //  11.4.0

                if (data["Cost"] != DBNull.Value)
                    convertedMoney = (decimal)data["Cost"];
                tbMyCost.Text = String.Format("{0:c}", convertedMoney);  //  11.4.0

                tbPub.Text = data["Pub"].ToString();
                tbPlace.Text = data["PubPlace"].ToString();

                if (data["Quantity"] != DBNull.Value)
                    tbCopies.Text = data["Quantity"].ToString();  //  new field as of 11.5.0
                else
                    tbCopies.Text = "0";  //  fixed: now matches d/b default  //  11.4.0

                if (data["NbrOfPages"] != DBNull.Value)
                    tbPages.Text = data["NbrOfPages"].ToString();
                else
                    tbPages.Text = "";

                if (data["BookWeight"] != DBNull.Value)
                    tbWeight.Text = data["BookWeight"].ToString();
                else
                    tbWeight.Text = "";

                if (data["PubYear"] != DBNull.Value)
                    tbYear.Text = data["PubYear"].ToString();
                else
                    tbYear.Text = "";

                if (data["Keywds"] != DBNull.Value)
                    tbKeywords.Text = data["Keywds"].ToString();
                else
                    tbKeywords.Text = "";

                if (data["Descr"] != DBNull.Value)
                    tbDesc.Text = data["Descr"].ToString();
                else
                    tbDesc.Text = "";

                //  binding
                if (data["Bndg"] != DBNull.Value)
                    coBinding.Text = data["Bndg"].ToString();

                if (data["Jaket"] != DBNull.Value)
                    coJacket.Text = data["Jaket"].ToString();

                //  condition
                if (data["Condn"] != DBNull.Value)
                    coCondition.Text = data["Condn"].ToString();

                //  book type
                if (data["BookType"] != DBNull.Value)
                    coType.Text = data["BookType"].ToString();

                //  edition
                if (data["Ed"] != DBNull.Value)
                    coEdition.Text = data["Ed"].ToString();

                //  volume
                if (data["Volume"] != DBNull.Value)
                    tbVolume.Text = data["Volume"].ToString();

                //  DoNotReprice flag
                string tempFlag;
                if (data["DoNotReprice"] != DBNull.Value) {
                    tempFlag = data["DoNotReprice"].ToString();
                    if (tempFlag == "T")
                        cbDoNotReprice.Checked = true;
                    else
                        cbDoNotReprice.Checked = false;
                }
                else
                    cbDoNotReprice.Checked = false;

                cbAuthorSigned.Checked = false;
                cbIllusSigned.Checked = false;
                if (data["Signed"].ToString() != " ")  //  signed
                {
                    if (data["Signed"].ToString() == "B") {
                        cbAuthorSigned.Checked = true;
                        cbIllusSigned.Checked = true;
                    }
                    else {
                        if (data["Signed"].ToString() == "A") {
                            cbAuthorSigned.Checked = true;
                        }
                        else {
                            if (data["Signed"].ToString() == "I")
                                cbIllusSigned.Checked = true;
                        }
                    }
                }

                string s = "";
                s = data["BookSize"].ToString();
                if (s.Trim().Length > 0)  //  if size not empty
                {
                    for (i = 1; i < coSize.Items.Count; i++) {
                        if (coSize.Items[i].ToString().Substring(0, 4) == s.Substring(0, 4)) {
                            coSize.SelectedIndex = i;
                            break;
                        }
                    }
                    if (i == 13)
                        coSize.SelectedIndex = -1;
                }
                else
                    coSize.SelectedIndex = -1;

                //  get the byte that holds the hex byte for shipping
                uint shipping = 0;
                if (data["Shipping"] != DBNull.Value)
                    shipping = uint.Parse(data["Shipping"].ToString());
                else
                    shipping = 0;


                //  now convert it to the proper checkbox
                uint DomStd = 32;
                uint DomExp = 16;
                uint Dom2Day = 8;
                uint Dom1Day = 4;
                uint IntlStd = 2;
                uint IntlExp = 1;

                cbDomStd.Checked = (shipping & DomStd) != 0;
                cbDomExp.Checked = (shipping & DomExp) != 0;
                cb2dDom.Checked = (shipping & Dom2Day) != 0;
                cb1dDom.Checked = (shipping & Dom1Day) != 0;
                cbIntlStd.Checked = (shipping & IntlStd) != 0;
                cbIntlExp.Checked = (shipping & IntlExp) != 0;

                //  display date and time added to d/b  
                IFormatProvider localCulture = System.Globalization.CultureInfo.CurrentCulture;

                DateTime dtTemp = (DateTime)data["DateA"];
                lblDateAdded.Text = "Date Added: " + dtTemp.ToString(new System.Globalization.CultureInfo(localCulture.ToString()));

                //  diaplay date and time last updated
                if (data["DateU"] != DBNull.Value) {
                    dtTemp = (DateTime)data["DateU"];
                    lblDateUpdated.Text = "Date Last Updated: " + dtTemp.ToString(new System.Globalization.CultureInfo(localCulture.ToString()));
                }
                else
                    lblDateUpdated.Text = "Date Last Updated: ";

                if (data["Cat"] != DBNull.Value)  //  catalog
                    tbPriCatalog.Text = data["Cat"].ToString();
                else
                    tbPriCatalog.Text = " ";

                if (data["SubCategory"] != DBNull.Value)  //  sub-category
                    tbSecCatalog.Text = data["SubCategory"].ToString();
                else
                    tbSecCatalog.Text = " ";

                if (data["Notes"] != DBNull.Value)
                    tbNotes.Text = data["Notes"].ToString();
                else
                    tbNotes.Text = " ";

                if (data["ImageFilename"] != DBNull.Value)
                    tbImageURL.Text = data["ImageFilename"].ToString();
                else
                    tbImageURL.Text = " ";

                switch (data["Stat"].ToString()) //  status
                {
                    case "For Sale":
                        statusForSale = true;
                        bRelist.Enabled = false;
                        if (tbCopies.Text.Equals("0"))
                            MessageBox.Show("Book is marked For Sale, but the quantity is 0", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case "Sold":
                        statusForSale = false;
                        bRelist.Enabled = true;
                        break;
                    case "Hold":
                        statusForSale = false;
                        bRelist.Enabled = false;
                        cbStatusHold.Checked = true;
                        break;
                    default:
                        break;
                }

                //  do invoice number if available
                //if (!data.IsDBNull((int)tBooks.InvoiceNbr))
                //    tbBookDtlInvNbr.Text = data.GetString((int)tBooks.InvoiceNbr);
                //else
                //    tbBookDtlInvNbr.Text = " ";

            }  

            data.Close();
            data.Dispose();

            bUpdateRecord.BackColor = enabled;  //  reset it from all of the action above

            return 0;

        }  //  end Populate...



        //-----------------------------    set bindings categories    --------------------|
        private void setBindingCategories() {
            coBinding.Items.Clear();  //  clear the old stuff

            if (!cbAmazonCategories.Checked)  //  not using Amazon categories
            {
                coBinding.Items.Add("");  // 0
                coBinding.Items.Add("Hardcover");  //  1
                coBinding.Items.Add("Cloth");  //  2
                coBinding.Items.Add("MMPB");  // 3
                coBinding.Items.Add("Trade PB");  //  4
                coBinding.Items.Add("Leather");  //  5
                coBinding.Items.Add("Spiral");  //  6
                coBinding.Items.Add("Other");  //  7
            }
            else  //  using Amazon categories for bindings
            {
                coBinding.Items.Add("Paperback");  //  0
                coBinding.Items.Add("Hardcover");  //  1
                coBinding.Items.Add("Audio CD");  //  2
                coBinding.Items.Add("Board_Book");  //  3
                coBinding.Items.Add("Calendar");  //  4
                coBinding.Items.Add("Cards");  //  5
                coBinding.Items.Add("Audio Cassette");  //  6
                coBinding.Items.Add("CD-ROM");  //  7
                coBinding.Items.Add("Comic");  //  8
                coBinding.Items.Add("Hardcover_Comic");  //  9
                coBinding.Items.Add("Diskette");  //  10
                coBinding.Items.Add("Leather_Bound");  //  11
                coBinding.Items.Add("Map");  //  12
                coBinding.Items.Add("Mass_Market");  //  13
                coBinding.Items.Add("Pamphlet");  //  14
                coBinding.Items.Add("Rag_Book");  //  15
                coBinding.Items.Add("Ring_bound");  //  16
                coBinding.Items.Add("Sheet_Music");  //  17
                coBinding.Items.Add("Spiral_bound");  //  18
            }

            coBinding.Text = "";
            coBinding.SelectedIndex = -1;

        }


        //---------------------------    clear detail panel    ----------------|
        public void clearDetailPanel(bool UpdateFlag) {

            tbBookNbr.Text = "";

            if (cbAutomaticSKU.Checked == true)
                tbBookNbr.Enabled = false;
            else
                tbBookNbr.Enabled = true;

            //  clear stickey text boxes, etc. if not marked as 'stickey'
            if (lCost.ForeColor == SystemColors.ControlText)
                tbMyCost.Text = "";
            if (lPrivNotes.ForeColor == SystemColors.ControlText)
                tbNotes.Text = "";
            if (lPlace.ForeColor == SystemColors.ControlText)
                tbPlace.Text = "";
            if (lLocation.ForeColor == SystemColors.ControlText)
                tbLocn.Text = "";
            if (lBinding.ForeColor == SystemColors.ControlText)
                setBindingCategories();
            if (lCondition.ForeColor == SystemColors.ControlText) { //  if foreground color is normal, clear entries
                coCondition.Text = "";
                coCondition.SelectedIndex = -1;
            }
            if (lJacket.ForeColor == SystemColors.ControlText) {  //  here too...
                coJacket.Text = "";
                coJacket.SelectedIndex = -1;
            }
            if (gbShipping.ForeColor == SystemColors.ControlText) {  //  now clear all of the shipping checkboxes
                cbDomStd.Checked = false;
                cbDomExp.Checked = false;
                cb2dDom.Checked = false;
                cb1dDom.Checked = false;
                cbIntlStd.Checked = false;
                cbIntlExp.Checked = false;
            }

            //  clear regular controls
            tbTitle.Text = "";
            tbAuthor.Text = "";
            tbIllus.Text = "";
            tbListPrice.Text = "";
            tbPub.Text = "";
            tbYear.Text = "";
            tbKeywords.Text = "";
            tbDesc.Text = "";
            lblDateAdded.Text = "Date Added: ";
            lblDateUpdated.Text = "Date Last Updated: ";
            tbPriCatalog.Text = "";
            tbSecCatalog.Text = "";
            tbPages.Text = "";
            tbWeight.Text = "";
            tbCopies.Text = "1";
            tbImageURL.Text = "";  //  (12.0.7)
            pbBookImage.Image = null;

            //  reset combo boxes
            coType.SelectedIndex = -1;
            coEdition.SelectedIndex = -1;
            coSize.SelectedIndex = -1;
            tbVolume.Text = "";  //  11.5.0

            cbAuthorSigned.Checked = false;
            cbIllusSigned.Checked = false;
            cbStatusHold.Checked = false;  //  reset

            //  now reset controls
            bDeleteBook.Enabled = false;  //  can't delete unless selected...
            bClone.Enabled = false;
            if (UpdateFlag) {
                bUpdateRecord.Enabled = true;  //  can do an update
                bAddRecord.Enabled = false;  //  but can't add
                updateNeeded = true;
            }
            else {
                bUpdateRecord.Enabled = false;  //  or update
                bAddRecord.Enabled = true;  //  but can add
                doingAnAdd = true;  //  possible Add forthcoming  (12.0.8)
                updateNeeded = false;
            }

            //bGetInfoWISBN.Enabled = false;
            //bLookupPrices.Enabled = false;
            //bShoppingCart.Enabled = false;

            bUpdateRecord.BackColor = enabled;
            bAddRecord.BackColor = enabled;

            lNotFound.Visible = false;
        }


        //---------------------------    populate the ASIN data    -----------------|
        public void populateASINPage(string bookNbr) {
            ////  clear the old stuff
            //tbasinSKU.Text = "";
            //tbasinTitle.Text = "";
            //tbasinAuthor.Text = "";
            //tbasinPublisher.Text = "";
            //tbasinASIN.Text = "";

            string strSQL = "SELECT * from tBooks where BookNbr = '" + bookNbr + "'";         //  find book in table

            FbCommand command = new FbCommand(strSQL, bookConn);
            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();

            FbDataReader data = command.ExecuteReader();

            while (data.Read()) {
                tbasinSKU.Text = data["BookNbr"].ToString();  //  book number
                tbasinTitle.Text = data["Title"].ToString();  //  title
                tbasinAuthor.Text = data["Author"].ToString();  //  author
                tbasinPublisher.Text = data["Pub"].ToString();
                tbasinCond.Text = data["Condn"].ToString();
                tbasinBinding.Text = data["Bndg"].ToString();
            }

        }


        //--------------------    fill combobox with user's choice for condition    ----------------|
        private void fillBookCondition() {
            coCondition.Items.Clear();  //  get rid of the old stuff

            if (rbUseAmazonCond.Checked) {
                coCondition.Items.Add("New");
                coCondition.Items.Add("Used: Like New");
                coCondition.Items.Add("Used: Very Good");
                coCondition.Items.Add("Used: Good");
                coCondition.Items.Add("Used: Acceptable");
                coCondition.Items.Add("Collectible: Like New");
                coCondition.Items.Add("Collectible: Very Good");
                coCondition.Items.Add("Collectible: Good");
                coCondition.Items.Add("Collectible: Acceptable");
            }
            else if (rbUseGenericCond.Checked) {
                coCondition.Items.Add("New");
                coCondition.Items.Add("Fine - Used");
                coCondition.Items.Add("Very Good - Used");
                coCondition.Items.Add("Good - Used");
                coCondition.Items.Add("Fair - Used");
                coCondition.Items.Add("Poor - Used");
                coCondition.Items.Add("Fine - Colllectible");
                coCondition.Items.Add("Very Good - Collectible");
                coCondition.Items.Add("Good - Collectible");
                coCondition.Items.Add("Fair - Collectible");
                coCondition.Items.Add("Poor - Collectible");
            }
            else if (rbUseCustomCond.Checked) {
                coCondition.Items.Clear();  //  12.5.1
                for (int i = 0; i < tbcustomCondition.Lines.Length; i++) {
                    coCondition.Items.Add(tbcustomCondition.Lines[i]);
                }
            }
        }

    }  //  end Form1
}  //  end namespace
