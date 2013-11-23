#region Using directives


using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

#endregion

namespace Media_Inventory_Manager
{
    partial class mainForm : Form
    {
        string mediaFormat = "";
        bool video;
        bool audio;
        //---------------------------    populate the detail panel    ---------------------]
        private int PopulateDetailPanel(string SKU) {
            decimal convertedMoney;

            clearDetailPanel();  //  clear out old stuff

            //  now, find all data for this SKU
            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();

            string strSQL = "SELECT * from tMedia where SKU = '" + SKU + "'";
            FbCommand command = new FbCommand(strSQL, mediaConn);

            FbDataReader data = command.ExecuteReader();  //  find product type and set flag for later testing
            data.Read();  //  only one row is returned

            mediaFormat = data["ProductType"].ToString();
            if (mediaFormat != "")
                if (mediaFormat.Substring(0, 6) == "Video ")
                    video = true;
                else if (mediaFormat.Substring(0, 7) == "Music: ")
                    audio = true;

            CultureInfo ci = CultureInfo.CurrentCulture;
            NumberFormatInfo nfi = ci.NumberFormat;

            // SKU
            tbSKU.Text = data["SKU"].ToString();
            tbSKU.Enabled = false;  //  don't allow any changes to key

            //  title
            tbTitle.Text = data["Title"].ToString();  //  title

            //  UPC
            tbUPC.Text = data["UPC"].ToString();

            //  location
            tbLocn.Text = data["Locn"].ToString();

            //  price
            convertedMoney = (decimal)data["Price"];
            tbPrice.Text = String.Format("{0:c}", convertedMoney);  //  11.4.0

            //  cost
            if (data["Cost"] != DBNull.Value)
                convertedMoney = (decimal)data["Cost"];
            tbCost.Text = String.Format("{0:c}", convertedMoney);  //  11.4.0

            //  manufacturer
            if (audio)
                tbMusicLabel.Text = data["Mfgr"].ToString();
            else if (video)
                tbStudio.Text = data["Mfgr"].ToString();

            //  year manufactured
            if (data["MfgrYear"] != DBNull.Value)
                if (audio)
                    tbMusicYear.Text = data["MfgrYear"].ToString();
                else if (video)
                    tbVideoYear.Text = data["MfgrYear"].ToString();

            //  description
            if (data["Descr"] != DBNull.Value)
                tbDesc.Text = data["Descr"].ToString();
            else
                tbDesc.Text = "";

            //  condition
            if (data["Condn"] != DBNull.Value)
                cbCondition.Text = data["Condn"].ToString();

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

            //  item notes
            if (data["Notes"] != DBNull.Value)
                tbItemNote.Text = data["Notes"].ToString();

            //  status
            switch (data["Stat"].ToString()) {
                case "For Sale":
                    statusForSale = true;
                    bRelist.Enabled = false;
                    if (tbQty.Text.Equals("0"))
                        MessageBox.Show("Item is marked For Sale, but the quantity is 0", "Prager Media Inventory Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            //  DoNotReprice flag
            if (data["DoNotReprice"] != DBNull.Value)
                cbDoNotReprice.Checked = data["DoNotReprice"].ToString() == "T" ? true : false;

            //  Image URL
            if (data["ImageUrl"] != DBNull.Value)
                tbImageURL.Text = data["ImageURL"].ToString();

            //  NbrOfDisks
            if (data["NbrOfDisks"] != DBNull.Value)
                tbNbrOfDisks.Text = data["NbrOfDisks"].ToString();

            //  shipping
            uint shipping = 0;
            if (data["Shipping"] != DBNull.Value)
                shipping = uint.Parse(data["Shipping"].ToString());
            else
                shipping = 0;

            const uint DomStd = 32;   //  now convert it to the proper checkbox
            const uint DomExp = 16;
            const uint Dom2Day = 8;
            const uint Dom1Day = 4;
            const uint IntlStd = 2;
            const uint IntlExp = 1;

            cbDomStd.Checked = (shipping & DomStd) != 0;
            cbDomExp.Checked = (shipping & DomExp) != 0;
            cb2dDom.Checked = (shipping & Dom2Day) != 0;
            cb1dDom.Checked = (shipping & Dom1Day) != 0;
            cbIntlStd.Checked = (shipping & IntlStd) != 0;
            cbIntlExp.Checked = (shipping & IntlExp) != 0;

            //  quantity
            if (data["Quantity"] != DBNull.Value)
                tbQty.Text = data["Quantity"].ToString();
            else
                tbQty.Text = "0";

            //  Media type
            if (data["MediaType"] != DBNull.Value)
                coMediaType.Text = data["MediaType"].ToString();

            //  audio format
            if (data["AudioFormat"] != DBNull.Value && audio)
                coAudioFormat.Text = data["AudioFormat"].ToString();

            //  MPAA rating
            if (data["MPAARating"] != DBNull.Value && video)
                coMPAA.Text = data["MPAARating"].ToString();

            //  audio encoding
            if (data["AudioEncoding"] != DBNull.Value && video)
                coAudioEncoding.Text = data["AudioEncoding"].ToString();

            //  video format
            if (data["VideoFormat"] != DBNull.Value && video)
                coVideoFormat.Text = data["VideoFormat"].ToString();

            //  language
            if (data["Language"] != DBNull.Value)
                coLanguage.Text = data["Language"].ToString();

            //  runtime
            if (data["Runtime"] != DBNull.Value && video)
                tbRuntime.Text = data["Runtime"].ToString();

            //  subtitles
            if (data["SubTitles"] != DBNull.Value && video)
                coSubTitles.Text = data["SubTitles"].ToString();

            //  Adult Content flag
            if (data["AdultContent"] != DBNull.Value)
                cbAdult.Checked = data["AdultContent"].ToString() == "Y" ? true : false;

            //  private notes
            if (data["PrivNotes"] != DBNull.Value)
                tbPrivNotes.Text = data["PrivNotes"].ToString();
            else
                tbPrivNotes.Text = " ";

            //  origin
            if ((string) data["Origin"] != "") {  //  country of origin
                string temp = data["Origin"].ToString();
                string selectString = "SELECT CountryName from tCountries WHERE CountryID = '" + temp + "'";
                dr = null;
                if (mediaConn.State != ConnectionState.Open)
                    mediaConn.Open();
                FbCommand cmd = new FbCommand(selectString, mediaConn);
                dr = cmd.ExecuteReader();
                dr.Read();  //  read the only line
                coOrigin.Text = dr["CountryName"].ToString();
            }
            else
                coOrigin.SelectedIndex = -1;

            //  language
            if ((string) data["Language"] != "")
                coLanguage.Text = data["Language"].ToString();
            else
                if (coOrigin.Text == "United States")
                    coLanguage.Text = "English";

            //  audio keywords
            if (data["AudioKeywords"] != DBNull.Value && audio)
                coAudioKeywords.Text = data["AudioKeywords"].ToString();
            else
                coAudioKeywords.SelectedIndex = -1;

            //  video keywords
            if (data["VideoKeywords"] != DBNull.Value && video)
                coVideoKeywords.Text = data["VideoKeywords"].ToString();
            else
                coVideoKeywords.SelectedIndex = -1;

            //  vinyl details
            if (data["VinylDetails"] != DBNull.Value && audio)
                tbVinylDetails.Text = data["VinylDetails"].ToString();
            else
                tbVinylDetails.Text = "";

            //  artist
            if (data["Artist"] != DBNull.Value && audio)
                tbArtist.Text = data["Artist"].ToString();
            else
                tbArtist.Text = "";

            //  composer
            if (data["Composer"] != DBNull.Value && audio)
                tbComposer.Text = data["Composer"].ToString();
            else
                tbComposer.Text = "";

            //  conductor
            if (data["Conductor"] != DBNull.Value && audio)
                tbConductor.Text = data["Conductor"].ToString();
            else
                tbVinylDetails.Text = "";

            //  orchestra
            if (data["Orchestra"] != DBNull.Value && audio)
                tbOrchestra.Text = data["Orchestra"].ToString();
            else
                tbOrchestra.Text = "";

            //  catalog ID
            if (data["CatalogID"] != DBNull.Value && audio)
                tbCatalogID.Text = data["CatalogID"].ToString();
            else
                tbCatalogID.Text = "";

            //  product type
            if (data["ProductType"] != DBNull.Value)
                coProductType.Text = data["ProductType"].ToString();
            else
                coProductType.SelectedIndex = -1;

            //  asin
            if (data["ASIN"] != DBNull.Value)
                mtbASIN.Text = data["ASIN"].ToString();
            else
                mtbASIN.Text = "";

            data.Close();

            bUpdateRecord.BackColor = enabled;  //  reset it from all of the action above

            return 0;
        }


        //---------------------------    clear detail panel    ----------------]
        public void clearDetailPanel() {
            tbSKU.Text = "";

            if (cbAutomaticSKU.Checked == true)
                tbSKU.Enabled = false;
            else
                tbSKU.Enabled = true;

            //  clear stickey text boxes, etc. if not marked as 'stickey'
            if (lCost.ForeColor == SystemColors.ControlText)
                tbCost.Text = "";
            if (lPrivNotes.ForeColor == SystemColors.ControlText)
                tbPrivNotes.Text = "";
            if (lLocation.ForeColor == SystemColors.ControlText)
                tbLocn.Text = "";
            if (lCondition.ForeColor == SystemColors.ControlText)  //  if foreground color is normal, clear entries
            {
                //coCondition.Text = "";
                cbCondition.SelectedIndex = -1;
            }
            if (lMediaType.ForeColor == SystemColors.ControlText)  //  here too...
            {
                coMediaType.Text = "";
                coMediaType.SelectedIndex = -1;
            }
            if (gbShipping.ForeColor == SystemColors.ControlText)  //  now clear all of the shipping checkboxes
            {
                cbDomStd.Checked = false;
                cbDomExp.Checked = false;
                cb2dDom.Checked = false;
                cb1dDom.Checked = false;
                cbIntlStd.Checked = false;
                cbIntlExp.Checked = false;
            }

            //  clear regular controls
            tbTitle.Text = "";
            tbUPC.Text = "";
            tbPrice.Text = "";
            tbStudio.Text = "";
            tbMusicLabel.Text = "";
            tbMusicYear.Text = "";
            tbVideoYear.Text = "";
            tbDesc.Text = "";
            lblDateAdded.Text = "Date Added: ";
            lblDateUpdated.Text = "Date Last Updated: ";
            tbItemNote.Text = "";
            tbInvoiceNbr.Text = "";
            cbDoNotReprice.Checked = false;
            tbImageURL.Text = "";
            tbNbrOfDisks.Text = "";
            tbQty.Text = "1";
            mtbASIN.Text = "";
            coMediaType.SelectedIndex = -1;
            coAudioFormat.SelectedIndex = -1;
            coMPAA.SelectedIndex = -1;
            coAudioEncoding.SelectedIndex = -1;
            coVideoFormat.SelectedIndex = -1;
            coLanguage.SelectedIndex = -1;
            tbRuntime.Text = "";
            coSubTitles.SelectedIndex = -1;
            cbAdult.Checked = false;
            tbPrivNotes.Text = "";
            coOrigin.SelectedIndex = -1;
            coAudioKeywords.SelectedIndex = -1;
            coVideoKeywords.SelectedIndex = -1;
            tbVinylDetails.Text = "";
            tbArtist.Text = "";
            tbComposer.Text = "";
            tbConductor.Text = "";
            tbOrchestra.Text = "";
            tbCatalogID.Text = "";
            coProductType.SelectedIndex = -1;

            cbStatusHold.Checked = false;  //  reset

            //  now reset controls
            bDeleteItem.Enabled = false;  //  can't delete unless selected...
            bClone.Enabled = false;
            bShoppingCart.Enabled = false;

            if (doingAnUpdate == true) {
                bUpdateRecord.Enabled = true;  //  or update
                bAddRecord.Enabled = false;  //  but can add
            }
            else {
                bUpdateRecord.Enabled = false;  //  or update
                bAddRecord.Enabled = true;  //  but can add
            }

            bUpdateRecord.BackColor = enabled;
            bAddRecord.BackColor = enabled;

            updateNeeded = false;  //  clear row selected indicator
            lNotFound.Visible = false;
        }


        //---------------------------    populate the ASIN data    -----------------]
        public void populateASINPage(string SKU) {

            string strSQL = "SELECT * from tMedia where SKU = '" + SKU + "'";         //  find item in table

            FbCommand command = new FbCommand(strSQL, mediaConn);
            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();

            FbDataReader data = command.ExecuteReader();

            while (data.Read()) {
                tbasinSKU.Text = data["SKU"].ToString();  //  SKU
                tbasinTitle.Text = data["Title"].ToString();  //  title
                tbasinAuthor.Text = data["Author"].ToString();  //  author
                tbasinPublisher.Text = data["Pub"].ToString();
                tbasinCond.Text = data["Condn"].ToString();
                tbasinBinding.Text = data["Bndg"].ToString();
            }
        }
    }
}