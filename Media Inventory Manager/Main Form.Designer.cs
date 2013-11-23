using System.Drawing;

namespace Media_Inventory_Manager
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.databaselStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSINUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workOfflineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initializeQuantityFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pragerOnTheWebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportaproblemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.newVersionAvailableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bAddCustomer = new System.Windows.Forms.Button();
            this.bCustUpdate = new System.Windows.Forms.Button();
            this.bCustDelete = new System.Windows.Forms.Button();
            this.bXfer = new System.Windows.Forms.Button();
            this.bClearCustInfo = new System.Windows.Forms.Button();
            this.bCustSearch = new System.Windows.Forms.Button();
            this.lbAcctgYear = new System.Windows.Forms.ListBox();
            this.bPrintPreviewLV = new System.Windows.Forms.Button();
            this.bPrintListView = new System.Windows.Forms.Button();
            this.tbSSCompareTo2 = new System.Windows.Forms.TextBox();
            this.tbSSCompareTo1 = new System.Windows.Forms.TextBox();
            this.bPageSetup = new System.Windows.Forms.Button();
            this.bPrintPreview = new System.Windows.Forms.Button();
            this.bPrintInvoice = new System.Windows.Forms.Button();
            this.bDeleteInvoice = new System.Windows.Forms.Button();
            this.bUpdateInvoice = new System.Windows.Forms.Button();
            this.bAddInvoice = new System.Windows.Forms.Button();
            this.bInvSearch = new System.Windows.Forms.Button();
            this.bRemoveItem = new System.Windows.Forms.Button();
            this.bClearInvFields = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbCustomSite2 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.cbUploadCS1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCustomSite4 = new System.Windows.Forms.TextBox();
            this.label214 = new System.Windows.Forms.Label();
            this.cbUploadCS2 = new System.Windows.Forms.CheckBox();
            this.cbUploadAmazonUK = new System.Windows.Forms.CheckBox();
            this.tbCustomSite3 = new System.Windows.Forms.TextBox();
            this.cbUploadCS3 = new System.Windows.Forms.CheckBox();
            this.label194 = new System.Windows.Forms.Label();
            this.cbUploadCS4 = new System.Windows.Forms.CheckBox();
            this.label191 = new System.Windows.Forms.Label();
            this.tbCustomSite1 = new System.Windows.Forms.TextBox();
            this.label190 = new System.Windows.Forms.Label();
            this.label182 = new System.Windows.Forms.Label();
            this.label180 = new System.Windows.Forms.Label();
            this.cbUploadScribblemonger = new System.Windows.Forms.CheckBox();
            this.label39 = new System.Windows.Forms.Label();
            this.cbUploadPapaMedia = new System.Windows.Forms.CheckBox();
            this.cbUploadBandN = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.label144 = new System.Windows.Forms.Label();
            this.cbUploadChrislands = new System.Windows.Forms.CheckBox();
            this.cbUploadAmazon = new System.Windows.Forms.CheckBox();
            this.cbUploadHalfDotCom = new System.Windows.Forms.CheckBox();
            this.cbUploadAlibris = new System.Windows.Forms.CheckBox();
            this.bChangeLogo = new System.Windows.Forms.Button();
            this.RePricingTool = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.cbExcludeAbove = new System.Windows.Forms.CheckBox();
            this.tbExcludeBelowAmt = new System.Windows.Forms.TextBox();
            this.cbExcludeBelow = new System.Windows.Forms.CheckBox();
            this.tbExcludeAboveAmt = new System.Windows.Forms.TextBox();
            this.groupBox52 = new System.Windows.Forms.GroupBox();
            this.cbAboveAverage = new System.Windows.Forms.CheckBox();
            this.cbAboveLow = new System.Windows.Forms.CheckBox();
            this.cbBelowAverage = new System.Windows.Forms.CheckBox();
            this.cbAboveHigh = new System.Windows.Forms.CheckBox();
            this.cbEqualSugg = new System.Windows.Forms.CheckBox();
            this.cbGreaterSugg = new System.Windows.Forms.CheckBox();
            this.cbLessSugg = new System.Windows.Forms.CheckBox();
            this.groupBox40 = new System.Windows.Forms.GroupBox();
            this.cbDontGoBelowCost = new System.Windows.Forms.CheckBox();
            this.tbBelowMyCostOr = new System.Windows.Forms.TextBox();
            this.lDiscardAbove = new System.Windows.Forms.Label();
            this.tbDiscardAboveAmt = new System.Windows.Forms.TextBox();
            this.lDiscardBelow = new System.Windows.Forms.Label();
            this.tbDiscardBelowAmt = new System.Windows.Forms.TextBox();
            this.groupBox39 = new System.Windows.Forms.GroupBox();
            this.rbVenuePrice = new System.Windows.Forms.RadioButton();
            this.label88 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.cbCombineNewUsed = new System.Windows.Forms.CheckBox();
            this.groupBox34 = new System.Windows.Forms.GroupBox();
            this.label91 = new System.Windows.Forms.Label();
            this.rbPriceNewFixed = new System.Windows.Forms.RadioButton();
            this.rbPriceNewPct = new System.Windows.Forms.RadioButton();
            this.lbNewWhatPrice = new System.Windows.Forms.ListBox();
            this.label195 = new System.Windows.Forms.Label();
            this.tbNewByAmt = new System.Windows.Forms.TextBox();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.label90 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbPriceLowFixed = new System.Windows.Forms.RadioButton();
            this.rbPriceLowPct = new System.Windows.Forms.RadioButton();
            this.rbLowAbove = new System.Windows.Forms.RadioButton();
            this.rbLowBelow = new System.Windows.Forms.RadioButton();
            this.tbLowByAmt = new System.Windows.Forms.TextBox();
            this.label193 = new System.Windows.Forms.Label();
            this.lbWhatPriceL = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbAmazonPrice = new System.Windows.Forms.CheckBox();
            this.rbRepriceSelected = new System.Windows.Forms.RadioButton();
            this.dtpReprice = new System.Windows.Forms.DateTimePicker();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbRepriceThus = new System.Windows.Forms.RadioButton();
            this.rbStartWithNbr = new System.Windows.Forms.RadioButton();
            this.tbStartNbr = new System.Windows.Forms.TextBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.label201 = new System.Windows.Forms.Label();
            this.tbCondAmtVG = new System.Windows.Forms.TextBox();
            this.label203 = new System.Windows.Forms.Label();
            this.label206 = new System.Windows.Forms.Label();
            this.tbCondAmtP = new System.Windows.Forms.TextBox();
            this.label204 = new System.Windows.Forms.Label();
            this.label208 = new System.Windows.Forms.Label();
            this.tbCondAmtG = new System.Windows.Forms.TextBox();
            this.label207 = new System.Windows.Forms.Label();
            this.bStartPricingService = new System.Windows.Forms.Button();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.label89 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbPriceHighPct = new System.Windows.Forms.RadioButton();
            this.rbPriceHighFixed = new System.Windows.Forms.RadioButton();
            this.rbHighAbove = new System.Windows.Forms.RadioButton();
            this.rbHighBelow = new System.Windows.Forms.RadioButton();
            this.lbWhatPriceH = new System.Windows.Forms.ListBox();
            this.label192 = new System.Windows.Forms.Label();
            this.tbHighByAmt = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lTimeRemaining = new System.Windows.Forms.Label();
            this.bPricingServiceUpdate = new System.Windows.Forms.Button();
            this.lProgress = new System.Windows.Forms.Label();
            this.bMarkAll = new System.Windows.Forms.Button();
            this.bStopPricingService = new System.Windows.Forms.Button();
            this.lPricingServiceStatus = new System.Windows.Forms.Label();
            this.lvPricingService = new System.Windows.Forms.ListView();
            this.lvSKU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvUPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvURPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvLow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvAverage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvHigh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSuggPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbSSCompare2 = new System.Windows.Forms.ListBox();
            this.lbSSAndOr2 = new System.Windows.Forms.ListBox();
            this.lbSSCompare1 = new System.Windows.Forms.ListBox();
            this.cbUploadPurgeReplace = new System.Windows.Forms.CheckBox();
            this.cbUploadTest = new System.Windows.Forms.CheckBox();
            this.cbFreezeDBPanel = new System.Windows.Forms.CheckBox();
            this.cbDeleteByYear = new System.Windows.Forms.CheckBox();
            this.tbPurgeDate = new System.Windows.Forms.TextBox();
            this.lbSSCompare3 = new System.Windows.Forms.ListBox();
            this.tbSSCompareTo3 = new System.Windows.Forms.TextBox();
            this.lbSSAndOr3 = new System.Windows.Forms.ListBox();
            this.lbSSCompare4 = new System.Windows.Forms.ListBox();
            this.tbSSCompareTo4 = new System.Windows.Forms.TextBox();
            this.lbSSAndOr4 = new System.Windows.Forms.ListBox();
            this.lbMappingNames = new System.Windows.Forms.ListBox();
            this.tbMapAddDesc3 = new System.Windows.Forms.TextBox();
            this.tbMapAddDesc2 = new System.Windows.Forms.TextBox();
            this.tbMapAddTitle = new System.Windows.Forms.TextBox();
            this.tbMapQty = new System.Windows.Forms.TextBox();
            this.tbMapLocation = new System.Windows.Forms.TextBox();
            this.tbMapPrivateNotes = new System.Windows.Forms.TextBox();
            this.tbMapDateSold = new System.Windows.Forms.TextBox();
            this.tbMapProductID = new System.Windows.Forms.TextBox();
            this.tbMapCondition = new System.Windows.Forms.TextBox();
            this.tbMapProdIDType = new System.Windows.Forms.TextBox();
            this.tbMapPubLoc = new System.Windows.Forms.TextBox();
            this.tbMapMediaCond = new System.Windows.Forms.TextBox();
            this.tbMapUPC = new System.Windows.Forms.TextBox();
            this.tbMapASIN = new System.Windows.Forms.TextBox();
            this.tbMapItemNotes = new System.Windows.Forms.TextBox();
            this.tbMapPrice = new System.Windows.Forms.TextBox();
            this.tbMapDesc = new System.Windows.Forms.TextBox();
            this.tbMapPublisher = new System.Windows.Forms.TextBox();
            this.tbMapTitle = new System.Windows.Forms.TextBox();
            this.tbMapSKU = new System.Windows.Forms.TextBox();
            this.bClear = new System.Windows.Forms.Button();
            this.tbUPC = new System.Windows.Forms.MaskedTextBox();
            this.bLookupPrices = new System.Windows.Forms.Button();
            this.lCondition = new System.Windows.Forms.Label();
            this.cbCondition = new System.Windows.Forms.ComboBox();
            this.lBinding = new System.Windows.Forms.Label();
            this.coProductType = new System.Windows.Forms.ComboBox();
            this.lPrivNotes = new System.Windows.Forms.Label();
            this.bShoppingCart = new System.Windows.Forms.Button();
            this.bGetMediaInfo = new System.Windows.Forms.Button();
            this.tbSKU = new System.Windows.Forms.TextBox();
            this.lLocation = new System.Windows.Forms.Label();
            this.bDeleteItem = new System.Windows.Forms.Button();
            this.bUpdateRecord = new System.Windows.Forms.Button();
            this.bAddRecord = new System.Windows.Forms.Button();
            this.bRelist = new System.Windows.Forms.Button();
            this.bNextItem = new System.Windows.Forms.Button();
            this.resetDBPanel = new System.Windows.Forms.Button();
            this.tbInternational = new System.Windows.Forms.TextBox();
            this.tbExpedited = new System.Windows.Forms.TextBox();
            this.bUpdateInfo = new System.Windows.Forms.Button();
            this.cbStatusHold = new System.Windows.Forms.CheckBox();
            this.rbCreateNewKey = new System.Windows.Forms.RadioButton();
            this.bUpdateASIN = new System.Windows.Forms.Button();
            this.bSearch = new System.Windows.Forms.Button();
            this.cbWildCardSearch = new System.Windows.Forms.CheckBox();
            this.bClearSearch = new System.Windows.Forms.Button();
            this.bClone = new System.Windows.Forms.Button();
            this.tbTaxPct = new System.Windows.Forms.TextBox();
            this.dataBasePanel = new System.Windows.Forms.ListView();
            this.ch1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.invoice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShowForSale = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShowSold = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShowHold = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShowPending = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShowCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.bClearIncSearch = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.tbsrchKeywords = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbsrchUPC = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbsrchTitle = new System.Windows.Forms.TextBox();
            this.tbsrchSKU = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.bCopy2Clipboard = new System.Windows.Forms.Button();
            this.rbImportAZ = new System.Windows.Forms.RadioButton();
            this.rbTabDelimited = new System.Windows.Forms.RadioButton();
            this.cbAutoPricingLookup = new System.Windows.Forms.CheckBox();
            this.cbBackupDB = new System.Windows.Forms.CheckBox();
            this.cbAllowAddUpdate = new System.Windows.Forms.CheckBox();
            this.cbVerifyDeletes = new System.Windows.Forms.CheckBox();
            this.lCost = new System.Windows.Forms.Label();
            this.bClearShoppingCart = new System.Windows.Forms.Button();
            this.bInvReport = new System.Windows.Forms.Button();
            this.bConvertToUPC13 = new System.Windows.Forms.Button();
            this.lbChangePricesCat = new System.Windows.Forms.ListBox();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.label185 = new System.Windows.Forms.Label();
            this.tbMapStatus = new System.Windows.Forms.TextBox();
            this.label213 = new System.Windows.Forms.Label();
            this.tbMarketplaceID = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.tbAWSSecretKey = new System.Windows.Forms.TextBox();
            this.bGetAccessKey = new System.Windows.Forms.Button();
            this.label87 = new System.Windows.Forms.Label();
            this.tbAWSKey = new System.Windows.Forms.TextBox();
            this.rbExportSelected = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbPurgeReplace = new System.Windows.Forms.CheckBox();
            this.tbBusinessAddr = new System.Windows.Forms.TextBox();
            this.lbShipTo = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.lbSoldTo = new System.Windows.Forms.ListBox();
            this.bDecrement = new System.Windows.Forms.Button();
            this.bIncrement = new System.Windows.Forms.Button();
            this.label215 = new System.Windows.Forms.Label();
            this.tbDevKey = new System.Windows.Forms.TextBox();
            this.tbMerchantID = new System.Windows.Forms.TextBox();
            this.bGetMWSKeys = new System.Windows.Forms.Button();
            this.label209 = new System.Windows.Forms.Label();
            this.tbAZAssocTag = new System.Windows.Forms.TextBox();
            this.label218 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.coAudioEncoding = new System.Windows.Forms.ComboBox();
            this.coVideoFormat = new System.Windows.Forms.ComboBox();
            this.label114 = new System.Windows.Forms.Label();
            this.lMediaType = new System.Windows.Forms.Label();
            this.coMPAA = new System.Windows.Forms.ComboBox();
            this.label109 = new System.Windows.Forms.Label();
            this.tbItemNote = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.coMediaType = new System.Windows.Forms.ComboBox();
            this.coLanguage = new System.Windows.Forms.ComboBox();
            this.coAudioFormat = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.coSubTitles = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.coOrigin = new System.Windows.Forms.ComboBox();
            this.mtbASIN = new System.Windows.Forms.MaskedTextBox();
            this.bGetHalfToken = new System.Windows.Forms.Button();
            this.tbHalfToken = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.bSubscribeFileEx = new System.Windows.Forms.Button();
            this.cbEdition = new System.Windows.Forms.ComboBox();
            this.label199 = new System.Windows.Forms.Label();
            this.cbDVDRegion = new System.Windows.Forms.ComboBox();
            this.label200 = new System.Windows.Forms.Label();
            this.tbSKUSuffix = new System.Windows.Forms.TextBox();
            this.tbSKUPrefix = new System.Windows.Forms.TextBox();
            this.tbStartingSKU = new System.Windows.Forms.TextBox();
            this.cbAutomaticSKU = new System.Windows.Forms.CheckBox();
            this.searchTab = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gbSS = new System.Windows.Forms.GroupBox();
            this.cbSSColumn4 = new System.Windows.Forms.ComboBox();
            this.cbSSColumn3 = new System.Windows.Forms.ComboBox();
            this.cbSSColumn2 = new System.Windows.Forms.ComboBox();
            this.cbSSColumn1 = new System.Windows.Forms.ComboBox();
            this.lItemsReturned = new System.Windows.Forms.Label();
            this.bSSearch = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lbStatus = new System.Windows.Forms.ListBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.printDialog2 = new System.Windows.Forms.PrintDialog();
            this.pageSetupDialog2 = new System.Windows.Forms.PageSetupDialog();
            this.invoiceTab = new System.Windows.Forms.TabPage();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabInvoice = new System.Windows.Forms.TabPage();
            this.gbInvoice = new System.Windows.Forms.GroupBox();
            this.cbPayOther = new System.Windows.Forms.CheckBox();
            this.cbPayPP = new System.Windows.Forms.CheckBox();
            this.cbPayDC = new System.Windows.Forms.CheckBox();
            this.cbPayCC = new System.Windows.Forms.CheckBox();
            this.cbPayCheque = new System.Windows.Forms.CheckBox();
            this.cbPayCash = new System.Windows.Forms.CheckBox();
            this.cbPayAmazon = new System.Windows.Forms.CheckBox();
            this.tbPayment = new System.Windows.Forms.TextBox();
            this.label174 = new System.Windows.Forms.Label();
            this.tbComm = new System.Windows.Forms.TextBox();
            this.tbAdj = new System.Windows.Forms.TextBox();
            this.label112 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.pInvoiceLogo = new System.Windows.Forms.PictureBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.tbInvoiceDate = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.tbInvoiceTtl = new System.Windows.Forms.TextBox();
            this.tbShipping = new System.Windows.Forms.TextBox();
            this.tbTaxVAT = new System.Windows.Forms.TextBox();
            this.tbDiscount = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.lOrderTotal = new System.Windows.Forms.Label();
            this.tbOrderTotal = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.lvShoppingCart = new System.Windows.Forms.ListView();
            this.tbSoldBy = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.tbInvoiceNbr = new System.Windows.Forms.TextBox();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.lvInvoiceList = new System.Windows.Forms.ListView();
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.label101 = new System.Windows.Forms.Label();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.lUpdateStatus = new System.Windows.Forms.Label();
            this.tabReceipt = new System.Windows.Forms.TabPage();
            this.lvReceipt = new System.Windows.Forms.ListView();
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.receiptPanel = new System.Windows.Forms.Panel();
            this.tbPurchase = new System.Windows.Forms.TextBox();
            this.lPmtMethod = new System.Windows.Forms.Label();
            this.lTotal = new System.Windows.Forms.Label();
            this.lTax = new System.Windows.Forms.Label();
            this.lDateTime = new System.Windows.Forms.Label();
            this.lStoreName = new System.Windows.Forms.Label();
            this.tbStoreName = new System.Windows.Forms.TextBox();
            this.label188 = new System.Windows.Forms.Label();
            this.label184 = new System.Windows.Forms.Label();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.label183 = new System.Windows.Forms.Label();
            this.customerInfoTab = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.tbCustGroup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCustNotes = new System.Windows.Forms.TextBox();
            this.tbCustContact = new System.Windows.Forms.TextBox();
            this.tbCustEmail = new System.Windows.Forms.TextBox();
            this.tbCustAltPhone = new System.Windows.Forms.TextBox();
            this.tbCustPhone = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.tbCustName = new System.Windows.Forms.TextBox();
            this.tbCustID = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.cbSameAsBillingInfo = new System.Windows.Forms.CheckBox();
            this.tbShipCntry = new System.Windows.Forms.TextBox();
            this.tbShipZip = new System.Windows.Forms.TextBox();
            this.tbShipState = new System.Windows.Forms.TextBox();
            this.tbShipCity = new System.Windows.Forms.TextBox();
            this.tbShipAddr2 = new System.Windows.Forms.TextBox();
            this.tbShipAddr1 = new System.Windows.Forms.TextBox();
            this.tbShipName = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.tbBillingCntry = new System.Windows.Forms.TextBox();
            this.tbBillingZip = new System.Windows.Forms.TextBox();
            this.tbBillingState = new System.Windows.Forms.TextBox();
            this.tbBillingCity = new System.Windows.Forms.TextBox();
            this.tbBillingAddr2 = new System.Windows.Forms.TextBox();
            this.tbBillingAddr1 = new System.Windows.Forms.TextBox();
            this.tbBillingName = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.lvCustomerList = new System.Windows.Forms.ListView();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.lUpdateStatus2 = new System.Windows.Forms.Label();
            this.mediaDetailTab = new System.Windows.Forms.TabPage();
            this.label115 = new System.Windows.Forms.Label();
            this.cbAdult = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.tbNbrOfDisks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label172 = new System.Windows.Forms.Label();
            this.tbImageURL = new System.Windows.Forms.TextBox();
            this.tabSpecificInfo = new System.Windows.Forms.TabControl();
            this.tabAudio = new System.Windows.Forms.TabPage();
            this.tbOrchestra = new System.Windows.Forms.TextBox();
            this.label181 = new System.Windows.Forms.Label();
            this.tbConductor = new System.Windows.Forms.TextBox();
            this.label178 = new System.Windows.Forms.Label();
            this.tbComposer = new System.Windows.Forms.TextBox();
            this.label147 = new System.Windows.Forms.Label();
            this.tbArtist = new System.Windows.Forms.TextBox();
            this.label141 = new System.Windows.Forms.Label();
            this.tbVinylDetails = new System.Windows.Forms.TextBox();
            this.label137 = new System.Windows.Forms.Label();
            this.coAudioKeywords = new System.Windows.Forms.ComboBox();
            this.label130 = new System.Windows.Forms.Label();
            this.tbCatalogID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tbMusicLabel = new System.Windows.Forms.TextBox();
            this.tbMusicYear = new System.Windows.Forms.TextBox();
            this.tabVideo = new System.Windows.Forms.TabPage();
            this.tbDirector = new System.Windows.Forms.TextBox();
            this.label198 = new System.Windows.Forms.Label();
            this.tbActors = new System.Windows.Forms.TextBox();
            this.label197 = new System.Windows.Forms.Label();
            this.coVideoKeywords = new System.Windows.Forms.ComboBox();
            this.tbRuntime = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label196 = new System.Windows.Forms.Label();
            this.tbVideoYear = new System.Windows.Forms.TextBox();
            this.tbStudio = new System.Windows.Forms.TextBox();
            this.label134 = new System.Windows.Forms.Label();
            this.label140 = new System.Windows.Forms.Label();
            this.gbShipping = new System.Windows.Forms.GroupBox();
            this.cbIntlStd = new System.Windows.Forms.CheckBox();
            this.cb1dDom = new System.Windows.Forms.CheckBox();
            this.cb2dDom = new System.Windows.Forms.CheckBox();
            this.cbDomExp = new System.Windows.Forms.CheckBox();
            this.cbIntlExp = new System.Windows.Forms.CheckBox();
            this.cbDomStd = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lNotFound = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbCost = new System.Windows.Forms.TextBox();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.lbCannedText = new System.Windows.Forms.ListBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lblDateUpdated = new System.Windows.Forms.Label();
            this.cbDoNotReprice = new System.Windows.Forms.CheckBox();
            this.tbPrivNotes = new System.Windows.Forms.TextBox();
            this.lblDateAdded = new System.Windows.Forms.Label();
            this.lPrice = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.tbLocn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cannedTextTab = new System.Windows.Forms.TabPage();
            this.tbCannedTitle18 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle17 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle16 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc18 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc16 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc17 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle15 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle14 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle13 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle12 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle11 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc15 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc12 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc13 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc14 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc11 = new System.Windows.Forms.TextBox();
            this.label187 = new System.Windows.Forms.Label();
            this.label171 = new System.Windows.Forms.Label();
            this.tbCannedTitle10 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle9 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle8 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle7 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle6 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc10 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc7 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc8 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc9 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc6 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle5 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle4 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle3 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle2 = new System.Windows.Forms.TextBox();
            this.tbCannedTitle1 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc5 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc2 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc3 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc4 = new System.Windows.Forms.TextBox();
            this.tbCannedDesc1 = new System.Windows.Forms.TextBox();
            this.uploadTab = new System.Windows.Forms.TabPage();
            this.bVerifyAZUploads = new System.Windows.Forms.Button();
            this.lbUploadStatus = new System.Windows.Forms.ListBox();
            this.lFileWaiting = new System.Windows.Forms.Label();
            this.bFTPUpload = new System.Windows.Forms.Button();
            this.accountingTab = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.lItemsPurged = new System.Windows.Forms.Label();
            this.bDeleteByYear = new System.Windows.Forms.Button();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.lblCOG2 = new System.Windows.Forms.Label();
            this.lblCOG3 = new System.Windows.Forms.Label();
            this.lblCOG4 = new System.Windows.Forms.Label();
            this.lblTotalCostofGoods = new System.Windows.Forms.Label();
            this.lblCOG1 = new System.Windows.Forms.Label();
            this.label170 = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblQtr2Sales = new System.Windows.Forms.Label();
            this.lblQtr3Sales = new System.Windows.Forms.Label();
            this.lblQtr4Sales = new System.Windows.Forms.Label();
            this.lblTotalYTD = new System.Windows.Forms.Label();
            this.lblQtr1Sales = new System.Windows.Forms.Label();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.lblPendingCount = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblSoldCount = new System.Windows.Forms.Label();
            this.lblHoldCount = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblSaleCount = new System.Windows.Forms.Label();
            this.alterPricesTab = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox41 = new System.Windows.Forms.GroupBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbAbsolute = new System.Windows.Forms.RadioButton();
            this.rbDecrease = new System.Windows.Forms.RadioButton();
            this.rbIncrease = new System.Windows.Forms.RadioButton();
            this.bReprice = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.rbPercentage = new System.Windows.Forms.RadioButton();
            this.rbAmount = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label86 = new System.Windows.Forms.Label();
            this.tbBkNbrTo = new System.Windows.Forms.TextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.tbBkNbrFrom = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.rbSKU = new System.Windows.Forms.RadioButton();
            this.tbPriceTo = new System.Windows.Forms.TextBox();
            this.tbPriceFrom = new System.Windows.Forms.TextBox();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbPriceRange = new System.Windows.Forms.RadioButton();
            this.rbCatalog = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.bChangeStatus = new System.Windows.Forms.Button();
            this.label148 = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.label142 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbMark4Sale = new System.Windows.Forms.RadioButton();
            this.rbMarkHold = new System.Windows.Forms.RadioButton();
            this.rbMarkSold = new System.Windows.Forms.RadioButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label175 = new System.Windows.Forms.Label();
            this.groupBox42 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbMassChangeMsg = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.lbMChangeFields = new System.Windows.Forms.ListBox();
            this.label149 = new System.Windows.Forms.Label();
            this.bMassChange = new System.Windows.Forms.Button();
            this.lMaxLength = new System.Windows.Forms.Label();
            this.tbMChangeTo = new System.Windows.Forms.TextBox();
            this.tbMChangeFrom = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.pricingResultsTab = new System.Windows.Forms.TabPage();
            this.lSalesRank = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lbCondn = new System.Windows.Forms.ListBox();
            this.lVendorNote = new System.Windows.Forms.Label();
            this.lPricesReturned = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.ListBox();
            this.lAveragePrice = new System.Windows.Forms.Label();
            this.lbPricingResults = new System.Windows.Forms.ListBox();
            this.lListPrice = new System.Windows.Forms.Label();
            this.tabTaskPanel = new System.Windows.Forms.TabControl();
            this.ExportTab = new System.Windows.Forms.TabPage();
            this.tabControl6 = new System.Windows.Forms.TabControl();
            this.tabExportOptions = new System.Windows.Forms.TabPage();
            this.groupBox46 = new System.Windows.Forms.GroupBox();
            this.rbExportInclusiveSearch = new System.Windows.Forms.RadioButton();
            this.rbExportAll = new System.Windows.Forms.RadioButton();
            this.lItemsWaiting = new System.Windows.Forms.Label();
            this.rbChangeDate = new System.Windows.Forms.RadioButton();
            this.bExport = new System.Windows.Forms.Button();
            this.tabExportListing = new System.Windows.Forms.TabPage();
            this.lbExportList = new System.Windows.Forms.ListBox();
            this.getASIN = new System.Windows.Forms.TabPage();
            this.label25 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lv1Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv1Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv1Publisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv1Year = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv1Binding = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv1ASIN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv1Rank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tbasinBinding = new System.Windows.Forms.TextBox();
            this.label100 = new System.Windows.Forms.Label();
            this.tbasinCond = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbasinASIN = new System.Windows.Forms.TextBox();
            this.label99 = new System.Windows.Forms.Label();
            this.tbasinPublisher = new System.Windows.Forms.TextBox();
            this.tbasinSKU = new System.Windows.Forms.TextBox();
            this.tbasinAuthor = new System.Windows.Forms.TextBox();
            this.tbasinTitle = new System.Windows.Forms.TextBox();
            this.label96 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.optionsTab = new System.Windows.Forms.TabPage();
            this.tabPrimary = new System.Windows.Forms.TabControl();
            this.tabProgramOptions = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lSKUSuffix = new System.Windows.Forms.Label();
            this.lSKUPrefix = new System.Windows.Forms.Label();
            this.label202 = new System.Windows.Forms.Label();
            this.groupBox48 = new System.Windows.Forms.GroupBox();
            this.rbMoveAvgPrice = new System.Windows.Forms.RadioButton();
            this.rbMoveLowPrice = new System.Windows.Forms.RadioButton();
            this.cbUseAWS = new System.Windows.Forms.CheckBox();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.cbWarnNoLocation = new System.Windows.Forms.CheckBox();
            this.cbWarnNoCatalog = new System.Windows.Forms.CheckBox();
            this.groupBox50 = new System.Windows.Forms.GroupBox();
            this.cbAutoFileRetention = new System.Windows.Forms.CheckBox();
            this.cbAutoInvoiceNbr = new System.Windows.Forms.CheckBox();
            this.cbAutoCustomerNbr = new System.Windows.Forms.CheckBox();
            this.groupBox49 = new System.Windows.Forms.GroupBox();
            this.cbUseReceipt = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbSortDsc = new System.Windows.Forms.RadioButton();
            this.rbSortAsc = new System.Windows.Forms.RadioButton();
            this.cbSortOverride = new System.Windows.Forms.CheckBox();
            this.rbStartDetail = new System.Windows.Forms.RadioButton();
            this.cbToolTips = new System.Windows.Forms.CheckBox();
            this.rbStartSearch = new System.Windows.Forms.RadioButton();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.rbEUDollar = new System.Windows.Forms.RadioButton();
            this.rbGBPound = new System.Windows.Forms.RadioButton();
            this.rbCNDollar = new System.Windows.Forms.RadioButton();
            this.groupBox51 = new System.Windows.Forms.GroupBox();
            this.label129 = new System.Windows.Forms.Label();
            this.cbDontOverlay = new System.Windows.Forms.CheckBox();
            this.cbAddDesc = new System.Windows.Forms.CheckBox();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.label104 = new System.Windows.Forms.Label();
            this.tbPubSeq = new System.Windows.Forms.TextBox();
            this.label103 = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.label159 = new System.Windows.Forms.Label();
            this.label160 = new System.Windows.Forms.Label();
            this.label161 = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.label163 = new System.Windows.Forms.Label();
            this.label164 = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.label166 = new System.Windows.Forms.Label();
            this.label167 = new System.Windows.Forms.Label();
            this.label168 = new System.Windows.Forms.Label();
            this.label173 = new System.Windows.Forms.Label();
            this.label176 = new System.Windows.Forms.Label();
            this.label177 = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.label156 = new System.Windows.Forms.Label();
            this.label155 = new System.Windows.Forms.Label();
            this.label154 = new System.Windows.Forms.Label();
            this.label153 = new System.Windows.Forms.Label();
            this.label152 = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
            this.label150 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.tbKeySeq = new System.Windows.Forms.TextBox();
            this.tbSecSeq = new System.Windows.Forms.TextBox();
            this.tbPriSeq = new System.Windows.Forms.TextBox();
            this.tbSizeSeq = new System.Windows.Forms.TextBox();
            this.tbTypeSeq = new System.Windows.Forms.TextBox();
            this.tbWeightSeq = new System.Windows.Forms.TextBox();
            this.tbPagesSeq = new System.Windows.Forms.TextBox();
            this.tbEdSeq = new System.Windows.Forms.TextBox();
            this.tbJacketSeq = new System.Windows.Forms.TextBox();
            this.tbCondSeq = new System.Windows.Forms.TextBox();
            this.tbBindingSeq = new System.Windows.Forms.TextBox();
            this.tbCannedSeq = new System.Windows.Forms.TextBox();
            this.tbDescSeq = new System.Windows.Forms.TextBox();
            this.tbYearSeq = new System.Windows.Forms.TextBox();
            this.tbPlaceSeq = new System.Windows.Forms.TextBox();
            this.tbIllusSignedSeq = new System.Windows.Forms.TextBox();
            this.tbIllusSeq = new System.Windows.Forms.TextBox();
            this.tbAuthorSignSeq = new System.Windows.Forms.TextBox();
            this.tbAuthorSeq = new System.Windows.Forms.TextBox();
            this.tbTitleSeq = new System.Windows.Forms.TextBox();
            this.tbRepriceSeq = new System.Windows.Forms.TextBox();
            this.tbPriceSeq = new System.Windows.Forms.TextBox();
            this.tbCostSeq = new System.Windows.Forms.TextBox();
            this.tbShipSeq = new System.Windows.Forms.TextBox();
            this.tbSKUSeq = new System.Windows.Forms.TextBox();
            this.tbLocSeq = new System.Windows.Forms.TextBox();
            this.tbQtySeq = new System.Windows.Forms.TextBox();
            this.tbUPCSeq = new System.Windows.Forms.TextBox();
            this.label102 = new System.Windows.Forms.Label();
            this.mappingTab = new System.Windows.Forms.TabPage();
            this.bClearImportTabMappings = new System.Windows.Forms.Button();
            this.lOptionsSaved = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.bSaveMapping = new System.Windows.Forms.Button();
            this.bContinueImport = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label124 = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.label126 = new System.Windows.Forms.Label();
            this.label131 = new System.Windows.Forms.Label();
            this.label132 = new System.Windows.Forms.Label();
            this.label133 = new System.Windows.Forms.Label();
            this.label135 = new System.Windows.Forms.Label();
            this.label136 = new System.Windows.Forms.Label();
            this.label138 = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            this.label127 = new System.Windows.Forms.Label();
            this.label128 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.Import = new System.Windows.Forms.TabPage();
            this.bPrintRejRecords = new System.Windows.Forms.Button();
            this.label72 = new System.Windows.Forms.Label();
            this.lbRejectedRecords = new System.Windows.Forms.ListBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rbMarkAsSold = new System.Windows.Forms.RadioButton();
            this.rbMarkAsForSale = new System.Windows.Forms.RadioButton();
            this.lRecordsRejected = new System.Windows.Forms.Label();
            this.lRecordsProcessed = new System.Windows.Forms.Label();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.label145 = new System.Windows.Forms.Label();
            this.rbRejectRecord = new System.Windows.Forms.RadioButton();
            this.rbReplaceRecord = new System.Windows.Forms.RadioButton();
            this.bImportMedia = new System.Windows.Forms.Button();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bOpenFileDialog = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbFormatUIEE = new System.Windows.Forms.RadioButton();
            this.groupBox44 = new System.Windows.Forms.GroupBox();
            this.cbDeleteFirst = new System.Windows.Forms.CheckBox();
            this.cbDontImportSold = new System.Windows.Forms.CheckBox();
            this.UIDandPswdMaintenance = new System.Windows.Forms.TabPage();
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.tabListingVenues = new System.Windows.Forms.TabPage();
            this.lMsgSettingsSaved = new System.Windows.Forms.Label();
            this.bSaveUIDs = new System.Windows.Forms.Button();
            this.UIDdataGridView = new System.Windows.Forms.DataGridView();
            this.dgvListingServiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FTPAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FTPDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FTPFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabGetKeys = new System.Windows.Forms.TabPage();
            this.label189 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label220 = new System.Windows.Forms.Label();
            this.label219 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.lAssocTag = new System.Windows.Forms.Label();
            this.label216 = new System.Windows.Forms.Label();
            this.bCopyDevKey = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.Reports = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.Aging = new System.Windows.Forms.TabPage();
            this.bGenerateAgingReport = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbAgingFilter = new System.Windows.Forms.CheckBox();
            this.label146 = new System.Windows.Forms.Label();
            this.tbAgingDays = new System.Windows.Forms.TextBox();
            this.Sales = new System.Windows.Forms.TabPage();
            this.gbReportTime = new System.Windows.Forms.GroupBox();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.bCreateSalesReport = new System.Windows.Forms.Button();
            this.lvSalesReport = new System.Windows.Forms.ListView();
            this.cSKU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cUPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cDateSold = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cSRInvoice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cSRCustNbr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Inventory = new System.Windows.Forms.TabPage();
            this.lFinished = new System.Windows.Forms.Label();
            this.bPageSetup3 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.rbIRFile = new System.Windows.Forms.RadioButton();
            this.rbIRClipBoard = new System.Windows.Forms.RadioButton();
            this.rbIRPrint = new System.Windows.Forms.RadioButton();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.checkBox20 = new System.Windows.Forms.CheckBox();
            this.checkBox21 = new System.Windows.Forms.CheckBox();
            this.checkBox22 = new System.Windows.Forms.CheckBox();
            this.checkBox23 = new System.Windows.Forms.CheckBox();
            this.gbFields = new System.Windows.Forms.GroupBox();
            this.invRepSelAll = new System.Windows.Forms.Button();
            this.cbIRType = new System.Windows.Forms.CheckBox();
            this.cbIRCost = new System.Windows.Forms.CheckBox();
            this.cbIRDateA = new System.Windows.Forms.CheckBox();
            this.cbIRTitle = new System.Windows.Forms.CheckBox();
            this.cbIRDateU = new System.Windows.Forms.CheckBox();
            this.cbIRCat = new System.Windows.Forms.CheckBox();
            this.cbIRSKU = new System.Windows.Forms.CheckBox();
            this.cbIRNotes = new System.Windows.Forms.CheckBox();
            this.cbIRStatus = new System.Windows.Forms.CheckBox();
            this.cbIRInvoice = new System.Windows.Forms.CheckBox();
            this.cbIREdition = new System.Windows.Forms.CheckBox();
            this.cbIRUPC = new System.Windows.Forms.CheckBox();
            this.cbIRLocn = new System.Windows.Forms.CheckBox();
            this.cbIRMediaCond = new System.Windows.Forms.CheckBox();
            this.cbIRQty = new System.Windows.Forms.CheckBox();
            this.cbIRPrice = new System.Windows.Forms.CheckBox();
            this.cbIRAdultContent = new System.Windows.Forms.CheckBox();
            this.cbIRPub = new System.Windows.Forms.CheckBox();
            this.cbIRASIN = new System.Windows.Forms.CheckBox();
            this.cbIRPubYear = new System.Windows.Forms.CheckBox();
            this.cbIRPrivNotes = new System.Windows.Forms.CheckBox();
            this.cbIRDesc = new System.Windows.Forms.CheckBox();
            this.browserTab = new System.Windows.Forms.TabPage();
            this.label186 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.StatusTab = new System.Windows.Forms.TabPage();
            this.label179 = new System.Windows.Forms.Label();
            this.tbTraceComments = new System.Windows.Forms.TextBox();
            this.bSendTrace = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox47 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.printDialog3 = new System.Windows.Forms.PrintDialog();
            this.printDocument3 = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog3 = new System.Windows.Forms.PageSetupDialog();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.RePricingTool.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox52.SuspendLayout();
            this.groupBox40.SuspendLayout();
            this.groupBox39.SuspendLayout();
            this.groupBox34.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.searchTab.SuspendLayout();
            this.gbSS.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.invoiceTab.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabInvoice.SuspendLayout();
            this.gbInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pInvoiceLogo)).BeginInit();
            this.groupBox36.SuspendLayout();
            this.groupBox35.SuspendLayout();
            this.tabReceipt.SuspendLayout();
            this.receiptPanel.SuspendLayout();
            this.customerInfoTab.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.mediaDetailTab.SuspendLayout();
            this.tabSpecificInfo.SuspendLayout();
            this.tabAudio.SuspendLayout();
            this.tabVideo.SuspendLayout();
            this.gbShipping.SuspendLayout();
            this.cannedTextTab.SuspendLayout();
            this.uploadTab.SuspendLayout();
            this.accountingTab.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.alterPricesTab.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox41.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox42.SuspendLayout();
            this.pricingResultsTab.SuspendLayout();
            this.tabTaskPanel.SuspendLayout();
            this.ExportTab.SuspendLayout();
            this.tabControl6.SuspendLayout();
            this.tabExportOptions.SuspendLayout();
            this.groupBox46.SuspendLayout();
            this.tabExportListing.SuspendLayout();
            this.getASIN.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.optionsTab.SuspendLayout();
            this.tabPrimary.SuspendLayout();
            this.tabProgramOptions.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox48.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox50.SuspendLayout();
            this.groupBox49.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox51.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.mappingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.Import.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox44.SuspendLayout();
            this.UIDandPswdMaintenance.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tabListingVenues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UIDdataGridView)).BeginInit();
            this.tabGetKeys.SuspendLayout();
            this.Reports.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.Aging.SuspendLayout();
            this.Sales.SuspendLayout();
            this.gbReportTime.SuspendLayout();
            this.Inventory.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.groupBox29.SuspendLayout();
            this.gbFields.SuspendLayout();
            this.browserTab.SuspendLayout();
            this.StatusTab.SuspendLayout();
            this.groupBox47.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaselStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.toolStripMenuItemExit,
            this.newVersionAvailableToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 30, 2);
            this.menuStrip1.Size = new System.Drawing.Size(880, 21);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // databaselStripMenuItem
            // 
            this.databaselStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseBackupToolStripMenuItem,
            this.restoreToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem1});
            this.databaselStripMenuItem.Name = "databaselStripMenuItem";
            this.databaselStripMenuItem.Size = new System.Drawing.Size(67, 17);
            this.databaselStripMenuItem.Text = "Database";
            // 
            // databaseBackupToolStripMenuItem
            // 
            this.databaseBackupToolStripMenuItem.Name = "databaseBackupToolStripMenuItem";
            this.databaseBackupToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.databaseBackupToolStripMenuItem.Text = "Backup";
            this.databaseBackupToolStripMenuItem.Click += new System.EventHandler(this.databaseBackupToolStripMenuItem_Click);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(110, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aSINUpdateToolStripMenuItem,
            this.workOfflineToolStripMenuItem,
            this.initializeQuantityFieldToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 17);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // aSINUpdateToolStripMenuItem
            // 
            this.aSINUpdateToolStripMenuItem.Name = "aSINUpdateToolStripMenuItem";
            this.aSINUpdateToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.aSINUpdateToolStripMenuItem.Text = "ASIN Update";
            this.aSINUpdateToolStripMenuItem.Click += new System.EventHandler(this.aSINUpdateToolStripMenuItem_Click);
            // 
            // workOfflineToolStripMenuItem
            // 
            this.workOfflineToolStripMenuItem.Name = "workOfflineToolStripMenuItem";
            this.workOfflineToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.workOfflineToolStripMenuItem.Text = "Work Offline";
            this.workOfflineToolStripMenuItem.ToolTipText = "Allows you to work without an internet connection";
            this.workOfflineToolStripMenuItem.Click += new System.EventHandler(this.workOfflineToolStripMenuItem_Click);
            // 
            // initializeQuantityFieldToolStripMenuItem
            // 
            this.initializeQuantityFieldToolStripMenuItem.Name = "initializeQuantityFieldToolStripMenuItem";
            this.initializeQuantityFieldToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.initializeQuantityFieldToolStripMenuItem.Text = "Initialize Quantity field";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.tutorialsToolStripMenuItem,
            this.registerToolStripMenuItem,
            this.getUpdatesToolStripMenuItem,
            this.pragerOnTheWebToolStripMenuItem,
            this.reportaproblemToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 17);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(201, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // tutorialsToolStripMenuItem
            // 
            this.tutorialsToolStripMenuItem.Name = "tutorialsToolStripMenuItem";
            this.tutorialsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.tutorialsToolStripMenuItem.Text = "Tutorials";
            this.tutorialsToolStripMenuItem.Click += new System.EventHandler(this.tutorialsToolStripMenuItem_Click);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.registerToolStripMenuItem.Text = "Purchase/Renew license";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.licenseToolStripMenuItem_Click);
            // 
            // getUpdatesToolStripMenuItem
            // 
            this.getUpdatesToolStripMenuItem.Name = "getUpdatesToolStripMenuItem";
            this.getUpdatesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.getUpdatesToolStripMenuItem.Text = "Get Updates";
            this.getUpdatesToolStripMenuItem.Click += new System.EventHandler(this.getUpdatesToolStripMenuItem_Click);
            // 
            // pragerOnTheWebToolStripMenuItem
            // 
            this.pragerOnTheWebToolStripMenuItem.Name = "pragerOnTheWebToolStripMenuItem";
            this.pragerOnTheWebToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.pragerOnTheWebToolStripMenuItem.Text = "Website";
            this.pragerOnTheWebToolStripMenuItem.Click += new System.EventHandler(this.pragerOnTheWebToolStripMenuItem_Click);
            // 
            // reportaproblemToolStripMenuItem
            // 
            this.reportaproblemToolStripMenuItem.Name = "reportaproblemToolStripMenuItem";
            this.reportaproblemToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.reportaproblemToolStripMenuItem.Text = "Report a problem";
            this.reportaproblemToolStripMenuItem.Click += new System.EventHandler(this.reportaproblemToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItemExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(60, 17);
            this.toolStripMenuItemExit.Text = "Exit (F3)";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // newVersionAvailableToolStripMenuItem
            // 
            this.newVersionAvailableToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newVersionAvailableToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.newVersionAvailableToolStripMenuItem.Name = "newVersionAvailableToolStripMenuItem";
            this.newVersionAvailableToolStripMenuItem.Size = new System.Drawing.Size(171, 17);
            this.newVersionAvailableToolStripMenuItem.Text = "New version available!";
            this.newVersionAvailableToolStripMenuItem.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolTip1.InitialDelay = 250;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            // 
            // bAddCustomer
            // 
            this.bAddCustomer.BackColor = System.Drawing.SystemColors.Desktop;
            this.bAddCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bAddCustomer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bAddCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bAddCustomer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bAddCustomer.Location = new System.Drawing.Point(29, 75);
            this.bAddCustomer.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.bAddCustomer.Name = "bAddCustomer";
            this.bAddCustomer.Size = new System.Drawing.Size(66, 28);
            this.bAddCustomer.TabIndex = 1;
            this.bAddCustomer.Text = "Add";
            this.toolTip1.SetToolTip(this.bAddCustomer, "Add a record to database");
            this.bAddCustomer.UseVisualStyleBackColor = false;
            this.bAddCustomer.Click += new System.EventHandler(this.bAddCustomer_Click);
            // 
            // bCustUpdate
            // 
            this.bCustUpdate.BackColor = System.Drawing.SystemColors.Desktop;
            this.bCustUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bCustUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bCustUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bCustUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bCustUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bCustUpdate.Location = new System.Drawing.Point(29, 116);
            this.bCustUpdate.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.bCustUpdate.Name = "bCustUpdate";
            this.bCustUpdate.Size = new System.Drawing.Size(66, 28);
            this.bCustUpdate.TabIndex = 2;
            this.bCustUpdate.Text = "Update";
            this.toolTip1.SetToolTip(this.bCustUpdate, "Update selected record");
            this.bCustUpdate.UseVisualStyleBackColor = false;
            this.bCustUpdate.Click += new System.EventHandler(this.bCustUpdate_Click);
            // 
            // bCustDelete
            // 
            this.bCustDelete.BackColor = System.Drawing.SystemColors.Desktop;
            this.bCustDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bCustDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bCustDelete.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bCustDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bCustDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bCustDelete.Location = new System.Drawing.Point(29, 157);
            this.bCustDelete.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.bCustDelete.Name = "bCustDelete";
            this.bCustDelete.Size = new System.Drawing.Size(66, 28);
            this.bCustDelete.TabIndex = 3;
            this.bCustDelete.Text = "Delete";
            this.toolTip1.SetToolTip(this.bCustDelete, "Delete selected record");
            this.bCustDelete.UseVisualStyleBackColor = false;
            this.bCustDelete.Click += new System.EventHandler(this.bCustDelete_Click);
            // 
            // bXfer
            // 
            this.bXfer.BackColor = System.Drawing.SystemColors.Desktop;
            this.bXfer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bXfer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bXfer.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bXfer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bXfer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bXfer.Location = new System.Drawing.Point(699, 133);
            this.bXfer.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.bXfer.Name = "bXfer";
            this.bXfer.Size = new System.Drawing.Size(88, 39);
            this.bXfer.TabIndex = 16;
            this.bXfer.Text = "Transfer Data to Invoice";
            this.toolTip1.SetToolTip(this.bXfer, "Transfers Billing and Shipping Info to Invoice");
            this.bXfer.UseVisualStyleBackColor = false;
            this.bXfer.Click += new System.EventHandler(this.bXfer_Click);
            // 
            // bClearCustInfo
            // 
            this.bClearCustInfo.BackColor = System.Drawing.SystemColors.Desktop;
            this.bClearCustInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClearCustInfo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bClearCustInfo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bClearCustInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bClearCustInfo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bClearCustInfo.Location = new System.Drawing.Point(699, 90);
            this.bClearCustInfo.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.bClearCustInfo.Name = "bClearCustInfo";
            this.bClearCustInfo.Size = new System.Drawing.Size(88, 28);
            this.bClearCustInfo.TabIndex = 20;
            this.bClearCustInfo.Text = "Clear Cust Data";
            this.toolTip1.SetToolTip(this.bClearCustInfo, "Clear Billing and Shipping information");
            this.bClearCustInfo.UseVisualStyleBackColor = false;
            this.bClearCustInfo.Click += new System.EventHandler(this.bClearCustInfo_Click);
            // 
            // bCustSearch
            // 
            this.bCustSearch.BackColor = System.Drawing.SystemColors.Desktop;
            this.bCustSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bCustSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bCustSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bCustSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bCustSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bCustSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCustSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bCustSearch.Location = new System.Drawing.Point(29, 34);
            this.bCustSearch.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.bCustSearch.Name = "bCustSearch";
            this.bCustSearch.Size = new System.Drawing.Size(66, 28);
            this.bCustSearch.TabIndex = 21;
            this.bCustSearch.Text = " Search";
            this.toolTip1.SetToolTip(this.bCustSearch, "Search for customer by either Name or ID and populate information below (wildcard" +
        " permitted)");
            this.bCustSearch.UseVisualStyleBackColor = false;
            this.bCustSearch.Click += new System.EventHandler(this.bCustSearch_Click);
            // 
            // lbAcctgYear
            // 
            this.lbAcctgYear.FormattingEnabled = true;
            this.lbAcctgYear.Items.AddRange(new object[] {
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015"});
            this.lbAcctgYear.Location = new System.Drawing.Point(125, 40);
            this.lbAcctgYear.Name = "lbAcctgYear";
            this.lbAcctgYear.Size = new System.Drawing.Size(51, 30);
            this.lbAcctgYear.TabIndex = 5;
            this.toolTip1.SetToolTip(this.lbAcctgYear, "Pick year to display");
            this.lbAcctgYear.SelectedValueChanged += new System.EventHandler(this.lbAcctgYear_SelectedValueChanged);
            // 
            // bPrintPreviewLV
            // 
            this.bPrintPreviewLV.BackColor = System.Drawing.SystemColors.Desktop;
            this.bPrintPreviewLV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPrintPreviewLV.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bPrintPreviewLV.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bPrintPreviewLV.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bPrintPreviewLV.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bPrintPreviewLV.Location = new System.Drawing.Point(27, 21);
            this.bPrintPreviewLV.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.bPrintPreviewLV.Name = "bPrintPreviewLV";
            this.bPrintPreviewLV.Size = new System.Drawing.Size(86, 28);
            this.bPrintPreviewLV.TabIndex = 164;
            this.bPrintPreviewLV.Text = "Print Preview";
            this.toolTip1.SetToolTip(this.bPrintPreviewLV, "Print preview contents of Database Panel");
            this.bPrintPreviewLV.UseVisualStyleBackColor = false;
            this.bPrintPreviewLV.Click += new System.EventHandler(this.bPrintPreviewLV_Click);
            // 
            // bPrintListView
            // 
            this.bPrintListView.BackColor = System.Drawing.SystemColors.Desktop;
            this.bPrintListView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPrintListView.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bPrintListView.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bPrintListView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bPrintListView.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bPrintListView.Location = new System.Drawing.Point(132, 21);
            this.bPrintListView.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.bPrintListView.Name = "bPrintListView";
            this.bPrintListView.Size = new System.Drawing.Size(86, 28);
            this.bPrintListView.TabIndex = 163;
            this.bPrintListView.Text = "Print";
            this.toolTip1.SetToolTip(this.bPrintListView, "Print contents of Database Panel");
            this.bPrintListView.UseVisualStyleBackColor = false;
            this.bPrintListView.Click += new System.EventHandler(this.bPrintListView_Click);
            // 
            // tbSSCompareTo2
            // 
            this.tbSSCompareTo2.Location = new System.Drawing.Point(322, 73);
            this.tbSSCompareTo2.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.tbSSCompareTo2.MaxLength = 200;
            this.tbSSCompareTo2.Name = "tbSSCompareTo2";
            this.tbSSCompareTo2.Size = new System.Drawing.Size(230, 20);
            this.tbSSCompareTo2.TabIndex = 16;
            this.toolTip1.SetToolTip(this.tbSSCompareTo2, "If comparison is \"is equal to\" you can use * as a wildcard");
            // 
            // tbSSCompareTo1
            // 
            this.tbSSCompareTo1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbSSCompareTo1.Location = new System.Drawing.Point(323, 27);
            this.tbSSCompareTo1.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.tbSSCompareTo1.MaxLength = 200;
            this.tbSSCompareTo1.Name = "tbSSCompareTo1";
            this.tbSSCompareTo1.Size = new System.Drawing.Size(230, 20);
            this.tbSSCompareTo1.TabIndex = 3;
            this.tbSSCompareTo1.Text = "  search terms go in these boxes";
            this.toolTip1.SetToolTip(this.tbSSCompareTo1, "If comparison is \"is equal to\" you can use * as a wildcard");
            this.tbSSCompareTo1.Enter += new System.EventHandler(this.tbSSCompareTo1_Enter);
            // 
            // bPageSetup
            // 
            this.bPageSetup.BackColor = System.Drawing.SystemColors.Desktop;
            this.bPageSetup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPageSetup.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bPageSetup.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bPageSetup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bPageSetup.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bPageSetup.Location = new System.Drawing.Point(26, 87);
            this.bPageSetup.Margin = new System.Windows.Forms.Padding(3, 0, 1, 3);
            this.bPageSetup.Name = "bPageSetup";
            this.bPageSetup.Size = new System.Drawing.Size(87, 28);
            this.bPageSetup.TabIndex = 156;
            this.bPageSetup.Text = "Page Setup";
            this.toolTip1.SetToolTip(this.bPageSetup, "Page Setup");
            this.bPageSetup.UseVisualStyleBackColor = false;
            this.bPageSetup.Click += new System.EventHandler(this.bPageSetup_Click);
            // 
            // bPrintPreview
            // 
            this.bPrintPreview.BackColor = System.Drawing.SystemColors.Desktop;
            this.bPrintPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bPrintPreview.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bPrintPreview.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bPrintPreview.Location = new System.Drawing.Point(26, 52);
            this.bPrintPreview.Name = "bPrintPreview";
            this.bPrintPreview.Size = new System.Drawing.Size(87, 28);
            this.bPrintPreview.TabIndex = 155;
            this.bPrintPreview.Text = "Print Preview";
            this.toolTip1.SetToolTip(this.bPrintPreview, "Preview invoice");
            this.bPrintPreview.UseVisualStyleBackColor = false;
            this.bPrintPreview.Click += new System.EventHandler(this.bPrintPreview_Click);
            // 
            // bPrintInvoice
            // 
            this.bPrintInvoice.BackColor = System.Drawing.SystemColors.Desktop;
            this.bPrintInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPrintInvoice.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bPrintInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bPrintInvoice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bPrintInvoice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bPrintInvoice.Location = new System.Drawing.Point(26, 122);
            this.bPrintInvoice.Name = "bPrintInvoice";
            this.bPrintInvoice.Size = new System.Drawing.Size(87, 28);
            this.bPrintInvoice.TabIndex = 154;
            this.bPrintInvoice.Text = "Print Invoice";
            this.toolTip1.SetToolTip(this.bPrintInvoice, "Print invoice - Reminder:  Invoice prints on top half of an 8.5 x 11 paper.");
            this.bPrintInvoice.UseVisualStyleBackColor = false;
            this.bPrintInvoice.Click += new System.EventHandler(this.bPrintInvoice_Click);
            // 
            // bDeleteInvoice
            // 
            this.bDeleteInvoice.BackColor = System.Drawing.SystemColors.Desktop;
            this.bDeleteInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bDeleteInvoice.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bDeleteInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bDeleteInvoice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bDeleteInvoice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bDeleteInvoice.Location = new System.Drawing.Point(35, 124);
            this.bDeleteInvoice.Name = "bDeleteInvoice";
            this.bDeleteInvoice.Size = new System.Drawing.Size(69, 28);
            this.bDeleteInvoice.TabIndex = 153;
            this.bDeleteInvoice.Text = "Delete";
            this.toolTip1.SetToolTip(this.bDeleteInvoice, "Delete selected invoice");
            this.bDeleteInvoice.UseVisualStyleBackColor = false;
            this.bDeleteInvoice.Click += new System.EventHandler(this.bDeleteInvoice_Click);
            // 
            // bUpdateInvoice
            // 
            this.bUpdateInvoice.BackColor = System.Drawing.SystemColors.Desktop;
            this.bUpdateInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bUpdateInvoice.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bUpdateInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bUpdateInvoice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bUpdateInvoice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bUpdateInvoice.Location = new System.Drawing.Point(35, 90);
            this.bUpdateInvoice.Name = "bUpdateInvoice";
            this.bUpdateInvoice.Size = new System.Drawing.Size(69, 28);
            this.bUpdateInvoice.TabIndex = 151;
            this.bUpdateInvoice.Text = "Update";
            this.toolTip1.SetToolTip(this.bUpdateInvoice, "Update this invoice (does not update your address or logo)");
            this.bUpdateInvoice.UseVisualStyleBackColor = false;
            this.bUpdateInvoice.Click += new System.EventHandler(this.bUpdateInvoice_Click);
            // 
            // bAddInvoice
            // 
            this.bAddInvoice.BackColor = System.Drawing.SystemColors.Desktop;
            this.bAddInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bAddInvoice.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bAddInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bAddInvoice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bAddInvoice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bAddInvoice.Location = new System.Drawing.Point(35, 56);
            this.bAddInvoice.Name = "bAddInvoice";
            this.bAddInvoice.Size = new System.Drawing.Size(69, 28);
            this.bAddInvoice.TabIndex = 143;
            this.bAddInvoice.Text = "Add";
            this.toolTip1.SetToolTip(this.bAddInvoice, "Add this invoice to the database");
            this.bAddInvoice.UseVisualStyleBackColor = false;
            this.bAddInvoice.Click += new System.EventHandler(this.bAddInvoice_Click);
            // 
            // bInvSearch
            // 
            this.bInvSearch.BackColor = System.Drawing.SystemColors.Desktop;
            this.bInvSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bInvSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bInvSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bInvSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bInvSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bInvSearch.Location = new System.Drawing.Point(35, 22);
            this.bInvSearch.Name = "bInvSearch";
            this.bInvSearch.Size = new System.Drawing.Size(69, 28);
            this.bInvSearch.TabIndex = 146;
            this.bInvSearch.Text = "Search";
            this.toolTip1.SetToolTip(this.bInvSearch, "Search for an invoice by filling in an Invoice Nbr field (ending wildcard permitt" +
        "ed)");
            this.bInvSearch.UseVisualStyleBackColor = false;
            this.bInvSearch.Click += new System.EventHandler(this.bInvSearch_Click);
            // 
            // bRemoveItem
            // 
            this.bRemoveItem.BackColor = System.Drawing.SystemColors.Desktop;
            this.bRemoveItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bRemoveItem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bRemoveItem.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bRemoveItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bRemoveItem.Location = new System.Drawing.Point(26, 192);
            this.bRemoveItem.Margin = new System.Windows.Forms.Padding(1, 2, 2, 3);
            this.bRemoveItem.Name = "bRemoveItem";
            this.bRemoveItem.Size = new System.Drawing.Size(87, 44);
            this.bRemoveItem.TabIndex = 104;
            this.bRemoveItem.Text = "Remove Item from Invoice";
            this.toolTip1.SetToolTip(this.bRemoveItem, "Delete an item from Shopping Cart");
            this.bRemoveItem.UseVisualStyleBackColor = false;
            this.bRemoveItem.Click += new System.EventHandler(this.bRemoveItem_Click);
            // 
            // bClearInvFields
            // 
            this.bClearInvFields.BackColor = System.Drawing.SystemColors.Desktop;
            this.bClearInvFields.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClearInvFields.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bClearInvFields.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bClearInvFields.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bClearInvFields.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bClearInvFields.Location = new System.Drawing.Point(26, 157);
            this.bClearInvFields.Name = "bClearInvFields";
            this.bClearInvFields.Size = new System.Drawing.Size(87, 28);
            this.bClearInvFields.TabIndex = 157;
            this.bClearInvFields.Text = "Clear";
            this.toolTip1.SetToolTip(this.bClearInvFields, "Clears all of the fields");
            this.bClearInvFields.UseVisualStyleBackColor = false;
            this.bClearInvFields.Click += new System.EventHandler(this.bClearInvFields_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox7.Controls.Add(this.tbCustomSite2);
            this.groupBox7.Controls.Add(this.label44);
            this.groupBox7.Controls.Add(this.cbUploadCS1);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.tbCustomSite4);
            this.groupBox7.Controls.Add(this.label214);
            this.groupBox7.Controls.Add(this.cbUploadCS2);
            this.groupBox7.Controls.Add(this.cbUploadAmazonUK);
            this.groupBox7.Controls.Add(this.tbCustomSite3);
            this.groupBox7.Controls.Add(this.cbUploadCS3);
            this.groupBox7.Controls.Add(this.label194);
            this.groupBox7.Controls.Add(this.cbUploadCS4);
            this.groupBox7.Controls.Add(this.label191);
            this.groupBox7.Controls.Add(this.tbCustomSite1);
            this.groupBox7.Controls.Add(this.label190);
            this.groupBox7.Controls.Add(this.label182);
            this.groupBox7.Controls.Add(this.label180);
            this.groupBox7.Controls.Add(this.cbUploadScribblemonger);
            this.groupBox7.Controls.Add(this.label39);
            this.groupBox7.Controls.Add(this.cbUploadPapaMedia);
            this.groupBox7.Controls.Add(this.cbUploadBandN);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label93);
            this.groupBox7.Controls.Add(this.label144);
            this.groupBox7.Controls.Add(this.cbUploadChrislands);
            this.groupBox7.Controls.Add(this.cbUploadAmazon);
            this.groupBox7.Controls.Add(this.cbUploadHalfDotCom);
            this.groupBox7.Controls.Add(this.cbUploadAlibris);
            this.groupBox7.Location = new System.Drawing.Point(24, 242);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(823, 294);
            this.groupBox7.TabIndex = 133;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Media Upload Sites";
            this.toolTip1.SetToolTip(this.groupBox7, "You can change the name to something more meaningful.  Changes are save on exit.");
            // 
            // tbCustomSite2
            // 
            this.tbCustomSite2.Location = new System.Drawing.Point(241, 54);
            this.tbCustomSite2.MaxLength = 25;
            this.tbCustomSite2.Name = "tbCustomSite2";
            this.tbCustomSite2.Size = new System.Drawing.Size(97, 20);
            this.tbCustomSite2.TabIndex = 163;
            this.tbCustomSite2.Text = "Custom Site 2";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label44.Location = new System.Drawing.Point(441, 21);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(232, 184);
            this.label44.TabIndex = 173;
            this.label44.Text = resources.GetString("label44.Text");
            // 
            // cbUploadCS1
            // 
            this.cbUploadCS1.AutoSize = true;
            this.cbUploadCS1.Location = new System.Drawing.Point(220, 35);
            this.cbUploadCS1.Name = "cbUploadCS1";
            this.cbUploadCS1.Size = new System.Drawing.Size(15, 14);
            this.cbUploadCS1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(417, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 13);
            this.label3.TabIndex = 172;
            this.label3.Text = "Don\'t see your favorite site listed?  Contact us.";
            // 
            // tbCustomSite4
            // 
            this.tbCustomSite4.Location = new System.Drawing.Point(241, 100);
            this.tbCustomSite4.MaxLength = 25;
            this.tbCustomSite4.Name = "tbCustomSite4";
            this.tbCustomSite4.Size = new System.Drawing.Size(97, 20);
            this.tbCustomSite4.TabIndex = 165;
            this.tbCustomSite4.Text = "Custom Site 4";
            // 
            // label214
            // 
            this.label214.AutoSize = true;
            this.label214.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label214.ForeColor = System.Drawing.Color.Black;
            this.label214.Location = new System.Drawing.Point(137, 80);
            this.label214.Name = "label214";
            this.label214.Size = new System.Drawing.Size(17, 9);
            this.label214.TabIndex = 169;
            this.label214.Text = "4, 8";
            // 
            // cbUploadCS2
            // 
            this.cbUploadCS2.AutoSize = true;
            this.cbUploadCS2.Location = new System.Drawing.Point(220, 58);
            this.cbUploadCS2.Name = "cbUploadCS2";
            this.cbUploadCS2.Size = new System.Drawing.Size(15, 14);
            this.cbUploadCS2.TabIndex = 1;
            // 
            // cbUploadAmazonUK
            // 
            this.cbUploadAmazonUK.AutoSize = true;
            this.cbUploadAmazonUK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUploadAmazonUK.Location = new System.Drawing.Point(38, 78);
            this.cbUploadAmazonUK.Name = "cbUploadAmazonUK";
            this.cbUploadAmazonUK.Size = new System.Drawing.Size(97, 17);
            this.cbUploadAmazonUK.TabIndex = 168;
            this.cbUploadAmazonUK.Text = "Amazon.co.UK";
            // 
            // tbCustomSite3
            // 
            this.tbCustomSite3.Location = new System.Drawing.Point(241, 77);
            this.tbCustomSite3.MaxLength = 25;
            this.tbCustomSite3.Name = "tbCustomSite3";
            this.tbCustomSite3.Size = new System.Drawing.Size(97, 20);
            this.tbCustomSite3.TabIndex = 164;
            this.tbCustomSite3.Text = "Custom Site 3";
            // 
            // cbUploadCS3
            // 
            this.cbUploadCS3.AutoSize = true;
            this.cbUploadCS3.Location = new System.Drawing.Point(220, 81);
            this.cbUploadCS3.Name = "cbUploadCS3";
            this.cbUploadCS3.Size = new System.Drawing.Size(15, 14);
            this.cbUploadCS3.TabIndex = 2;
            // 
            // label194
            // 
            this.label194.AutoSize = true;
            this.label194.Location = new System.Drawing.Point(415, 251);
            this.label194.Name = "label194";
            this.label194.Size = new System.Drawing.Size(143, 13);
            this.label194.TabIndex = 155;
            this.label194.Text = "5.  Sites with NO monthly fee";
            // 
            // cbUploadCS4
            // 
            this.cbUploadCS4.AutoSize = true;
            this.cbUploadCS4.Location = new System.Drawing.Point(220, 104);
            this.cbUploadCS4.Name = "cbUploadCS4";
            this.cbUploadCS4.Size = new System.Drawing.Size(15, 14);
            this.cbUploadCS4.TabIndex = 3;
            // 
            // label191
            // 
            this.label191.AutoSize = true;
            this.label191.Location = new System.Drawing.Point(415, 233);
            this.label191.Name = "label191";
            this.label191.Size = new System.Drawing.Size(244, 13);
            this.label191.TabIndex = 154;
            this.label191.Text = "4.   Requires you to have a Pro-Merchant account";
            // 
            // tbCustomSite1
            // 
            this.tbCustomSite1.Location = new System.Drawing.Point(241, 31);
            this.tbCustomSite1.MaxLength = 25;
            this.tbCustomSite1.Name = "tbCustomSite1";
            this.tbCustomSite1.Size = new System.Drawing.Size(97, 20);
            this.tbCustomSite1.TabIndex = 162;
            this.tbCustomSite1.Text = "Custom Site 1";
            this.toolTip1.SetToolTip(this.tbCustomSite1, "You can change the name to your liking; changes are saved upon exit.");
            // 
            // label190
            // 
            this.label190.AutoSize = true;
            this.label190.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label190.ForeColor = System.Drawing.Color.Black;
            this.label190.Location = new System.Drawing.Point(122, 58);
            this.label190.Name = "label190";
            this.label190.Size = new System.Drawing.Size(9, 9);
            this.label190.TabIndex = 153;
            this.label190.Text = "4";
            // 
            // label182
            // 
            this.label182.AutoSize = true;
            this.label182.Location = new System.Drawing.Point(27, 269);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(348, 13);
            this.label182.TabIndex = 151;
            this.label182.Text = "3.   Requires registration for user id and password before you can upload";
            // 
            // label180
            // 
            this.label180.AutoSize = true;
            this.label180.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label180.ForeColor = System.Drawing.Color.Black;
            this.label180.Location = new System.Drawing.Point(136, 193);
            this.label180.Name = "label180";
            this.label180.Size = new System.Drawing.Size(17, 9);
            this.label180.TabIndex = 150;
            this.label180.Text = "3, 5";
            this.label180.Visible = false;
            // 
            // cbUploadScribblemonger
            // 
            this.cbUploadScribblemonger.AutoSize = true;
            this.cbUploadScribblemonger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUploadScribblemonger.Location = new System.Drawing.Point(38, 191);
            this.cbUploadScribblemonger.Name = "cbUploadScribblemonger";
            this.cbUploadScribblemonger.Size = new System.Drawing.Size(99, 17);
            this.cbUploadScribblemonger.TabIndex = 149;
            this.cbUploadScribblemonger.Text = "Scribblemonger";
            this.cbUploadScribblemonger.Visible = false;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(120, 169);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(17, 9);
            this.label39.TabIndex = 148;
            this.label39.Text = "2, 5";
            // 
            // cbUploadPapaMedia
            // 
            this.cbUploadPapaMedia.AutoSize = true;
            this.cbUploadPapaMedia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUploadPapaMedia.Location = new System.Drawing.Point(38, 168);
            this.cbUploadPapaMedia.Name = "cbUploadPapaMedia";
            this.cbUploadPapaMedia.Size = new System.Drawing.Size(83, 17);
            this.cbUploadPapaMedia.TabIndex = 147;
            this.cbUploadPapaMedia.Text = "Papa Media";
            // 
            // cbUploadBandN
            // 
            this.cbUploadBandN.AutoSize = true;
            this.cbUploadBandN.Location = new System.Drawing.Point(38, 100);
            this.cbUploadBandN.Name = "cbUploadBandN";
            this.cbUploadBandN.Size = new System.Drawing.Size(99, 17);
            this.cbUploadBandN.TabIndex = 146;
            this.cbUploadBandN.Text = "Barnes && Noble";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(113, 123);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(9, 9);
            this.label20.TabIndex = 143;
            this.label20.Text = "2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(106, 145);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 9);
            this.label15.TabIndex = 140;
            this.label15.Text = "1, 5";
            this.label15.Visible = false;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(27, 233);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(224, 13);
            this.label93.TabIndex = 136;
            this.label93.Text = "1.   Must be manually uploaded  (see Help file)";
            // 
            // label144
            // 
            this.label144.AutoSize = true;
            this.label144.Location = new System.Drawing.Point(27, 251);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(321, 13);
            this.label144.TabIndex = 134;
            this.label144.Text = "2.   Requires registration and file verification before you can upload";
            // 
            // cbUploadChrislands
            // 
            this.cbUploadChrislands.AutoSize = true;
            this.cbUploadChrislands.Location = new System.Drawing.Point(38, 122);
            this.cbUploadChrislands.Name = "cbUploadChrislands";
            this.cbUploadChrislands.Size = new System.Drawing.Size(74, 17);
            this.cbUploadChrislands.TabIndex = 109;
            this.cbUploadChrislands.Text = "Chrislands";
            // 
            // cbUploadAmazon
            // 
            this.cbUploadAmazon.AutoSize = true;
            this.cbUploadAmazon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUploadAmazon.Location = new System.Drawing.Point(38, 56);
            this.cbUploadAmazon.Name = "cbUploadAmazon";
            this.cbUploadAmazon.Size = new System.Drawing.Size(87, 17);
            this.cbUploadAmazon.TabIndex = 81;
            this.cbUploadAmazon.Text = "Amazon.com";
            // 
            // cbUploadHalfDotCom
            // 
            this.cbUploadHalfDotCom.AutoSize = true;
            this.cbUploadHalfDotCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUploadHalfDotCom.Location = new System.Drawing.Point(38, 145);
            this.cbUploadHalfDotCom.Name = "cbUploadHalfDotCom";
            this.cbUploadHalfDotCom.Size = new System.Drawing.Size(71, 17);
            this.cbUploadHalfDotCom.TabIndex = 53;
            this.cbUploadHalfDotCom.Text = "Half.com ";
            // 
            // cbUploadAlibris
            // 
            this.cbUploadAlibris.AutoSize = true;
            this.cbUploadAlibris.Location = new System.Drawing.Point(38, 34);
            this.cbUploadAlibris.Name = "cbUploadAlibris";
            this.cbUploadAlibris.Size = new System.Drawing.Size(53, 17);
            this.cbUploadAlibris.TabIndex = 13;
            this.cbUploadAlibris.Text = "Alibris";
            // 
            // bChangeLogo
            // 
            this.bChangeLogo.BackColor = System.Drawing.SystemColors.Desktop;
            this.bChangeLogo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bChangeLogo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bChangeLogo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bChangeLogo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bChangeLogo.Location = new System.Drawing.Point(710, 446);
            this.bChangeLogo.Name = "bChangeLogo";
            this.bChangeLogo.Size = new System.Drawing.Size(87, 43);
            this.bChangeLogo.TabIndex = 121;
            this.bChangeLogo.Text = "Change logo and address";
            this.toolTip1.SetToolTip(this.bChangeLogo, "Updates the Logo and Business Address");
            this.bChangeLogo.UseVisualStyleBackColor = false;
            this.bChangeLogo.Click += new System.EventHandler(this.bChangeLogo_Click);
            // 
            // RePricingTool
            // 
            this.RePricingTool.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.RePricingTool.Controls.Add(this.tabControl1);
            this.RePricingTool.Location = new System.Drawing.Point(4, 44);
            this.RePricingTool.Name = "RePricingTool";
            this.RePricingTool.Size = new System.Drawing.Size(865, 550);
            this.RePricingTool.TabIndex = 20;
            this.RePricingTool.Text = "Re-pricing Tool ";
            this.toolTip1.SetToolTip(this.RePricingTool, "Only prices items with UPC\'s at the present time.");
            this.RePricingTool.ToolTipText = "Pricing Service where the program goes to the internet for each item in your inve" +
    "ntory automatically, finding high, low and computed average price.";
            this.RePricingTool.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(863, 545);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage1.Controls.Add(this.groupBox14);
            this.tabPage1.Controls.Add(this.groupBox52);
            this.tabPage1.Controls.Add(this.groupBox40);
            this.tabPage1.Controls.Add(this.groupBox39);
            this.tabPage1.Controls.Add(this.groupBox34);
            this.tabPage1.Controls.Add(this.groupBox33);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.groupBox21);
            this.tabPage1.Controls.Add(this.bStartPricingService);
            this.tabPage1.Controls.Add(this.groupBox32);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(855, 519);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "    Filters    ";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.cbExcludeAbove);
            this.groupBox14.Controls.Add(this.tbExcludeBelowAmt);
            this.groupBox14.Controls.Add(this.cbExcludeBelow);
            this.groupBox14.Controls.Add(this.tbExcludeAboveAmt);
            this.groupBox14.Location = new System.Drawing.Point(15, 348);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(388, 78);
            this.groupBox14.TabIndex = 131;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Control range of items to reprice:";
            // 
            // cbExcludeAbove
            // 
            this.cbExcludeAbove.AutoSize = true;
            this.cbExcludeAbove.Location = new System.Drawing.Point(6, 25);
            this.cbExcludeAbove.Name = "cbExcludeAbove";
            this.cbExcludeAbove.Size = new System.Drawing.Size(171, 17);
            this.cbExcludeAbove.TabIndex = 91;
            this.cbExcludeAbove.Text = "Exclude items above a price of";
            this.cbExcludeAbove.UseVisualStyleBackColor = true;
            // 
            // tbExcludeBelowAmt
            // 
            this.tbExcludeBelowAmt.Location = new System.Drawing.Point(188, 46);
            this.tbExcludeBelowAmt.MaxLength = 6;
            this.tbExcludeBelowAmt.Name = "tbExcludeBelowAmt";
            this.tbExcludeBelowAmt.Size = new System.Drawing.Size(54, 20);
            this.tbExcludeBelowAmt.TabIndex = 93;
            this.toolTip1.SetToolTip(this.tbExcludeBelowAmt, "Do not price items whose price is below this amount.");
            this.tbExcludeBelowAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            // 
            // cbExcludeBelow
            // 
            this.cbExcludeBelow.AutoSize = true;
            this.cbExcludeBelow.Location = new System.Drawing.Point(6, 48);
            this.cbExcludeBelow.Name = "cbExcludeBelow";
            this.cbExcludeBelow.Size = new System.Drawing.Size(169, 17);
            this.cbExcludeBelow.TabIndex = 92;
            this.cbExcludeBelow.Text = "Exclude items below a price of";
            this.cbExcludeBelow.UseVisualStyleBackColor = true;
            // 
            // tbExcludeAboveAmt
            // 
            this.tbExcludeAboveAmt.Location = new System.Drawing.Point(188, 23);
            this.tbExcludeAboveAmt.MaxLength = 6;
            this.tbExcludeAboveAmt.Name = "tbExcludeAboveAmt";
            this.tbExcludeAboveAmt.Size = new System.Drawing.Size(54, 20);
            this.tbExcludeAboveAmt.TabIndex = 91;
            this.toolTip1.SetToolTip(this.tbExcludeAboveAmt, "Do not price items whose price is above this amount.");
            this.tbExcludeAboveAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            // 
            // groupBox52
            // 
            this.groupBox52.Controls.Add(this.cbAboveAverage);
            this.groupBox52.Controls.Add(this.cbAboveLow);
            this.groupBox52.Controls.Add(this.cbBelowAverage);
            this.groupBox52.Controls.Add(this.cbAboveHigh);
            this.groupBox52.Controls.Add(this.cbEqualSugg);
            this.groupBox52.Controls.Add(this.cbGreaterSugg);
            this.groupBox52.Controls.Add(this.cbLessSugg);
            this.groupBox52.Location = new System.Drawing.Point(431, 211);
            this.groupBox52.Name = "groupBox52";
            this.groupBox52.Size = new System.Drawing.Size(363, 109);
            this.groupBox52.TabIndex = 130;
            this.groupBox52.TabStop = false;
            this.groupBox52.Text = "Highlight price when";
            // 
            // cbAboveAverage
            // 
            this.cbAboveAverage.AutoSize = true;
            this.cbAboveAverage.Location = new System.Drawing.Point(208, 40);
            this.cbAboveAverage.Name = "cbAboveAverage";
            this.cbAboveAverage.Size = new System.Drawing.Size(143, 17);
            this.cbAboveAverage.TabIndex = 99;
            this.cbAboveAverage.Text = "My price > average price";
            this.cbAboveAverage.UseVisualStyleBackColor = true;
            // 
            // cbAboveLow
            // 
            this.cbAboveLow.AutoSize = true;
            this.cbAboveLow.Location = new System.Drawing.Point(208, 17);
            this.cbAboveLow.Name = "cbAboveLow";
            this.cbAboveLow.Size = new System.Drawing.Size(120, 17);
            this.cbAboveLow.TabIndex = 43;
            this.cbAboveLow.Text = "My price > low price";
            this.cbAboveLow.UseVisualStyleBackColor = true;
            // 
            // cbBelowAverage
            // 
            this.cbBelowAverage.AutoSize = true;
            this.cbBelowAverage.Location = new System.Drawing.Point(208, 63);
            this.cbBelowAverage.Name = "cbBelowAverage";
            this.cbBelowAverage.Size = new System.Drawing.Size(143, 17);
            this.cbBelowAverage.TabIndex = 100;
            this.cbBelowAverage.Text = "My price < average price";
            this.cbBelowAverage.UseVisualStyleBackColor = true;
            // 
            // cbAboveHigh
            // 
            this.cbAboveHigh.AutoSize = true;
            this.cbAboveHigh.Location = new System.Drawing.Point(208, 86);
            this.cbAboveHigh.Name = "cbAboveHigh";
            this.cbAboveHigh.Size = new System.Drawing.Size(124, 17);
            this.cbAboveHigh.TabIndex = 101;
            this.cbAboveHigh.Text = "My price > high price";
            this.cbAboveHigh.UseVisualStyleBackColor = true;
            // 
            // cbEqualSugg
            // 
            this.cbEqualSugg.AutoSize = true;
            this.cbEqualSugg.Location = new System.Drawing.Point(6, 66);
            this.cbEqualSugg.Name = "cbEqualSugg";
            this.cbEqualSugg.Size = new System.Drawing.Size(153, 17);
            this.cbEqualSugg.TabIndex = 102;
            this.cbEqualSugg.Text = "My price = suggested price";
            this.cbEqualSugg.UseVisualStyleBackColor = true;
            // 
            // cbGreaterSugg
            // 
            this.cbGreaterSugg.AutoSize = true;
            this.cbGreaterSugg.Checked = true;
            this.cbGreaterSugg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGreaterSugg.Location = new System.Drawing.Point(6, 22);
            this.cbGreaterSugg.Name = "cbGreaterSugg";
            this.cbGreaterSugg.Size = new System.Drawing.Size(194, 17);
            this.cbGreaterSugg.TabIndex = 103;
            this.cbGreaterSugg.Text = "My price > suggested price (default)";
            this.cbGreaterSugg.UseVisualStyleBackColor = true;
            // 
            // cbLessSugg
            // 
            this.cbLessSugg.AutoSize = true;
            this.cbLessSugg.Checked = true;
            this.cbLessSugg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLessSugg.Location = new System.Drawing.Point(6, 45);
            this.cbLessSugg.Name = "cbLessSugg";
            this.cbLessSugg.Size = new System.Drawing.Size(194, 17);
            this.cbLessSugg.TabIndex = 104;
            this.cbLessSugg.Text = "My price < suggested price (default)";
            this.cbLessSugg.UseVisualStyleBackColor = true;
            // 
            // groupBox40
            // 
            this.groupBox40.Controls.Add(this.cbDontGoBelowCost);
            this.groupBox40.Controls.Add(this.tbBelowMyCostOr);
            this.groupBox40.Controls.Add(this.lDiscardAbove);
            this.groupBox40.Controls.Add(this.tbDiscardAboveAmt);
            this.groupBox40.Controls.Add(this.lDiscardBelow);
            this.groupBox40.Controls.Add(this.tbDiscardBelowAmt);
            this.groupBox40.Location = new System.Drawing.Point(431, 95);
            this.groupBox40.Name = "groupBox40";
            this.groupBox40.Size = new System.Drawing.Size(363, 112);
            this.groupBox40.TabIndex = 129;
            this.groupBox40.TabStop = false;
            // 
            // cbDontGoBelowCost
            // 
            this.cbDontGoBelowCost.AutoSize = true;
            this.cbDontGoBelowCost.Location = new System.Drawing.Point(15, 76);
            this.cbDontGoBelowCost.Name = "cbDontGoBelowCost";
            this.cbDontGoBelowCost.Size = new System.Drawing.Size(206, 17);
            this.cbDontGoBelowCost.TabIndex = 130;
            this.cbDontGoBelowCost.Text = "Minimum suggested price is my cost or";
            this.toolTip1.SetToolTip(this.cbDontGoBelowCost, "Check this to control the minimum price, either the cost or amont in box to the r" +
        "ight.");
            this.cbDontGoBelowCost.UseVisualStyleBackColor = true;
            // 
            // tbBelowMyCostOr
            // 
            this.tbBelowMyCostOr.Location = new System.Drawing.Point(225, 74);
            this.tbBelowMyCostOr.MaxLength = 6;
            this.tbBelowMyCostOr.Name = "tbBelowMyCostOr";
            this.tbBelowMyCostOr.Size = new System.Drawing.Size(48, 20);
            this.tbBelowMyCostOr.TabIndex = 129;
            this.toolTip1.SetToolTip(this.tbBelowMyCostOr, "Do not price below this amount.");
            // 
            // lDiscardAbove
            // 
            this.lDiscardAbove.AutoSize = true;
            this.lDiscardAbove.Location = new System.Drawing.Point(15, 18);
            this.lDiscardAbove.Name = "lDiscardAbove";
            this.lDiscardAbove.Size = new System.Drawing.Size(258, 13);
            this.lDiscardAbove.TabIndex = 125;
            this.lDiscardAbove.Text = "When looking at web prices, discard any price above";
            this.toolTip1.SetToolTip(this.lDiscardAbove, "Discard any price above this price when computing the average.");
            // 
            // tbDiscardAboveAmt
            // 
            this.tbDiscardAboveAmt.Location = new System.Drawing.Point(279, 15);
            this.tbDiscardAboveAmt.MaxLength = 6;
            this.tbDiscardAboveAmt.Name = "tbDiscardAboveAmt";
            this.tbDiscardAboveAmt.Size = new System.Drawing.Size(41, 20);
            this.tbDiscardAboveAmt.TabIndex = 124;
            this.toolTip1.SetToolTip(this.tbDiscardAboveAmt, "Will discard above this price if amount is not blank");
            // 
            // lDiscardBelow
            // 
            this.lDiscardBelow.AutoSize = true;
            this.lDiscardBelow.Location = new System.Drawing.Point(153, 42);
            this.lDiscardBelow.Name = "lDiscardBelow";
            this.lDiscardBelow.Size = new System.Drawing.Size(120, 13);
            this.lDiscardBelow.TabIndex = 126;
            this.lDiscardBelow.Text = "Discard any price below";
            this.toolTip1.SetToolTip(this.lDiscardBelow, "Discard any price above this price when computing the average.");
            // 
            // tbDiscardBelowAmt
            // 
            this.tbDiscardBelowAmt.Location = new System.Drawing.Point(279, 39);
            this.tbDiscardBelowAmt.MaxLength = 6;
            this.tbDiscardBelowAmt.Name = "tbDiscardBelowAmt";
            this.tbDiscardBelowAmt.Size = new System.Drawing.Size(41, 20);
            this.tbDiscardBelowAmt.TabIndex = 127;
            this.toolTip1.SetToolTip(this.tbDiscardBelowAmt, "Will discard below this price if amount is not blank");
            // 
            // groupBox39
            // 
            this.groupBox39.Controls.Add(this.rbVenuePrice);
            this.groupBox39.Controls.Add(this.label88);
            this.groupBox39.Controls.Add(this.label51);
            this.groupBox39.Controls.Add(this.cbCombineNewUsed);
            this.groupBox39.ForeColor = System.Drawing.Color.Black;
            this.groupBox39.Location = new System.Drawing.Point(15, 6);
            this.groupBox39.Name = "groupBox39";
            this.groupBox39.Size = new System.Drawing.Size(388, 85);
            this.groupBox39.TabIndex = 110;
            this.groupBox39.TabStop = false;
            this.groupBox39.Text = "Base comparisons and computations on:";
            // 
            // rbVenuePrice
            // 
            this.rbVenuePrice.AutoSize = true;
            this.rbVenuePrice.Enabled = false;
            this.rbVenuePrice.Location = new System.Drawing.Point(14, 59);
            this.rbVenuePrice.Name = "rbVenuePrice";
            this.rbVenuePrice.Size = new System.Drawing.Size(128, 17);
            this.rbVenuePrice.TabIndex = 132;
            this.rbVenuePrice.Text = "Prices from all venues";
            this.rbVenuePrice.UseVisualStyleBackColor = true;
            this.rbVenuePrice.Visible = false;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.ForeColor = System.Drawing.Color.Firebrick;
            this.label88.Location = new System.Drawing.Point(221, -1);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(50, 13);
            this.label88.TabIndex = 131;
            this.label88.Text = "Required";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(32, 38);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(280, 13);
            this.label51.TabIndex = 130;
            this.label51.Text = "Otherwise, they are based on the condition of YOUR item.";
            // 
            // cbCombineNewUsed
            // 
            this.cbCombineNewUsed.AutoSize = true;
            this.cbCombineNewUsed.Location = new System.Drawing.Point(14, 21);
            this.cbCombineNewUsed.Name = "cbCombineNewUsed";
            this.cbCombineNewUsed.Size = new System.Drawing.Size(298, 17);
            this.cbCombineNewUsed.TabIndex = 129;
            this.cbCombineNewUsed.Text = "Combine new and used prices for High, Low and Average";
            this.toolTip1.SetToolTip(this.cbCombineNewUsed, "Price will be adjusted based on USPS Media Mail rates for weight.");
            this.cbCombineNewUsed.UseVisualStyleBackColor = true;
            // 
            // groupBox34
            // 
            this.groupBox34.Controls.Add(this.label91);
            this.groupBox34.Controls.Add(this.rbPriceNewFixed);
            this.groupBox34.Controls.Add(this.rbPriceNewPct);
            this.groupBox34.Controls.Add(this.lbNewWhatPrice);
            this.groupBox34.Controls.Add(this.label195);
            this.groupBox34.Controls.Add(this.tbNewByAmt);
            this.groupBox34.Location = new System.Drawing.Point(15, 253);
            this.groupBox34.Name = "groupBox34";
            this.groupBox34.Size = new System.Drawing.Size(388, 76);
            this.groupBox34.TabIndex = 108;
            this.groupBox34.TabStop = false;
            this.groupBox34.Text = "If the book is NEW, compute a suggested price based on:";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.ForeColor = System.Drawing.Color.Firebrick;
            this.label91.Location = new System.Drawing.Point(305, -2);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(50, 13);
            this.label91.TabIndex = 132;
            this.label91.Text = "Required";
            // 
            // rbPriceNewFixed
            // 
            this.rbPriceNewFixed.AutoSize = true;
            this.rbPriceNewFixed.Location = new System.Drawing.Point(13, 19);
            this.rbPriceNewFixed.Name = "rbPriceNewFixed";
            this.rbPriceNewFixed.Size = new System.Drawing.Size(85, 17);
            this.rbPriceNewFixed.TabIndex = 52;
            this.rbPriceNewFixed.TabStop = true;
            this.rbPriceNewFixed.Text = "fixed amount";
            this.rbPriceNewFixed.UseVisualStyleBackColor = true;
            // 
            // rbPriceNewPct
            // 
            this.rbPriceNewPct.AutoSize = true;
            this.rbPriceNewPct.Location = new System.Drawing.Point(13, 36);
            this.rbPriceNewPct.Name = "rbPriceNewPct";
            this.rbPriceNewPct.Size = new System.Drawing.Size(79, 17);
            this.rbPriceNewPct.TabIndex = 53;
            this.rbPriceNewPct.TabStop = true;
            this.rbPriceNewPct.Text = "percentage";
            this.rbPriceNewPct.UseVisualStyleBackColor = true;
            // 
            // lbNewWhatPrice
            // 
            this.lbNewWhatPrice.FormattingEnabled = true;
            this.lbNewWhatPrice.Items.AddRange(new object[] {
            "over my cost.",
            "below the List Price",
            "over the Average price."});
            this.lbNewWhatPrice.Location = new System.Drawing.Point(176, 26);
            this.lbNewWhatPrice.Name = "lbNewWhatPrice";
            this.lbNewWhatPrice.Size = new System.Drawing.Size(142, 30);
            this.lbNewWhatPrice.TabIndex = 70;
            // 
            // label195
            // 
            this.label195.AutoSize = true;
            this.label195.Location = new System.Drawing.Point(101, 33);
            this.label195.Name = "label195";
            this.label195.Size = new System.Drawing.Size(16, 13);
            this.label195.TabIndex = 67;
            this.label195.Text = "of";
            // 
            // tbNewByAmt
            // 
            this.tbNewByAmt.Location = new System.Drawing.Point(121, 30);
            this.tbNewByAmt.MaxLength = 6;
            this.tbNewByAmt.Name = "tbNewByAmt";
            this.tbNewByAmt.Size = new System.Drawing.Size(44, 20);
            this.tbNewByAmt.TabIndex = 69;
            this.toolTip1.SetToolTip(this.tbNewByAmt, "Enter either a percentage or a fixed dollar amount.");
            this.tbNewByAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.label90);
            this.groupBox33.Controls.Add(this.panel3);
            this.groupBox33.Controls.Add(this.rbLowAbove);
            this.groupBox33.Controls.Add(this.rbLowBelow);
            this.groupBox33.Controls.Add(this.tbLowByAmt);
            this.groupBox33.Controls.Add(this.label193);
            this.groupBox33.Controls.Add(this.lbWhatPriceL);
            this.groupBox33.Location = new System.Drawing.Point(15, 176);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(388, 69);
            this.groupBox33.TabIndex = 107;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "If my price is LOW, compute a suggested price based on:";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.ForeColor = System.Drawing.Color.Firebrick;
            this.label90.Location = new System.Drawing.Point(302, -1);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(50, 13);
            this.label90.TabIndex = 132;
            this.label90.Text = "Required";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbPriceLowFixed);
            this.panel3.Controls.Add(this.rbPriceLowPct);
            this.panel3.Location = new System.Drawing.Point(15, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(92, 42);
            this.panel3.TabIndex = 112;
            // 
            // rbPriceLowFixed
            // 
            this.rbPriceLowFixed.AutoSize = true;
            this.rbPriceLowFixed.Location = new System.Drawing.Point(3, 3);
            this.rbPriceLowFixed.Name = "rbPriceLowFixed";
            this.rbPriceLowFixed.Size = new System.Drawing.Size(85, 17);
            this.rbPriceLowFixed.TabIndex = 52;
            this.rbPriceLowFixed.TabStop = true;
            this.rbPriceLowFixed.Text = "fixed amount";
            this.rbPriceLowFixed.UseVisualStyleBackColor = true;
            // 
            // rbPriceLowPct
            // 
            this.rbPriceLowPct.AutoSize = true;
            this.rbPriceLowPct.Location = new System.Drawing.Point(3, 21);
            this.rbPriceLowPct.Name = "rbPriceLowPct";
            this.rbPriceLowPct.Size = new System.Drawing.Size(79, 17);
            this.rbPriceLowPct.TabIndex = 53;
            this.rbPriceLowPct.TabStop = true;
            this.rbPriceLowPct.Text = "percentage";
            this.rbPriceLowPct.UseVisualStyleBackColor = true;
            // 
            // rbLowAbove
            // 
            this.rbLowAbove.AutoSize = true;
            this.rbLowAbove.Location = new System.Drawing.Point(176, 23);
            this.rbLowAbove.Name = "rbLowAbove";
            this.rbLowAbove.Size = new System.Drawing.Size(73, 17);
            this.rbLowAbove.TabIndex = 52;
            this.rbLowAbove.TabStop = true;
            this.rbLowAbove.Text = "above the";
            this.rbLowAbove.UseVisualStyleBackColor = true;
            // 
            // rbLowBelow
            // 
            this.rbLowBelow.AutoSize = true;
            this.rbLowBelow.Location = new System.Drawing.Point(176, 40);
            this.rbLowBelow.Name = "rbLowBelow";
            this.rbLowBelow.Size = new System.Drawing.Size(71, 17);
            this.rbLowBelow.TabIndex = 53;
            this.rbLowBelow.TabStop = true;
            this.rbLowBelow.Text = "below the";
            this.rbLowBelow.UseVisualStyleBackColor = true;
            // 
            // tbLowByAmt
            // 
            this.tbLowByAmt.Location = new System.Drawing.Point(130, 29);
            this.tbLowByAmt.MaxLength = 6;
            this.tbLowByAmt.Name = "tbLowByAmt";
            this.tbLowByAmt.Size = new System.Drawing.Size(31, 20);
            this.tbLowByAmt.TabIndex = 63;
            this.toolTip1.SetToolTip(this.tbLowByAmt, "Enter either a percentage or a fixed dollar amount.");
            this.tbLowByAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            // 
            // label193
            // 
            this.label193.AutoSize = true;
            this.label193.Location = new System.Drawing.Point(110, 32);
            this.label193.Name = "label193";
            this.label193.Size = new System.Drawing.Size(16, 13);
            this.label193.TabIndex = 61;
            this.label193.Text = "of";
            // 
            // lbWhatPriceL
            // 
            this.lbWhatPriceL.FormattingEnabled = true;
            this.lbWhatPriceL.Items.AddRange(new object[] {
            "low price.",
            "average price.",
            "high price."});
            this.lbWhatPriceL.Location = new System.Drawing.Point(253, 26);
            this.lbWhatPriceL.Name = "lbWhatPriceL";
            this.lbWhatPriceL.Size = new System.Drawing.Size(95, 30);
            this.lbWhatPriceL.TabIndex = 64;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbAmazonPrice);
            this.panel2.Controls.Add(this.rbRepriceSelected);
            this.panel2.Controls.Add(this.dtpReprice);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.rbRepriceThus);
            this.panel2.Controls.Add(this.rbStartWithNbr);
            this.panel2.Controls.Add(this.tbStartNbr);
            this.panel2.Location = new System.Drawing.Point(433, 329);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 130);
            this.panel2.TabIndex = 115;
            // 
            // cbAmazonPrice
            // 
            this.cbAmazonPrice.AutoSize = true;
            this.cbAmazonPrice.Enabled = false;
            this.cbAmazonPrice.Location = new System.Drawing.Point(12, 9);
            this.cbAmazonPrice.Name = "cbAmazonPrice";
            this.cbAmazonPrice.Size = new System.Drawing.Size(324, 17);
            this.cbAmazonPrice.TabIndex = 118;
            this.cbAmazonPrice.Text = "Prices from Amazon.com only (can extend the time dramatically)";
            this.cbAmazonPrice.UseVisualStyleBackColor = true;
            // 
            // rbRepriceSelected
            // 
            this.rbRepriceSelected.AutoSize = true;
            this.rbRepriceSelected.Enabled = false;
            this.rbRepriceSelected.Location = new System.Drawing.Point(13, 101);
            this.rbRepriceSelected.Name = "rbRepriceSelected";
            this.rbRepriceSelected.Size = new System.Drawing.Size(291, 17);
            this.rbRepriceSelected.TabIndex = 117;
            this.rbRepriceSelected.Text = "Reprice items selected in Database Panel (coming soon)";
            this.rbRepriceSelected.UseVisualStyleBackColor = true;
            this.rbRepriceSelected.Visible = false;
            // 
            // dtpReprice
            // 
            this.dtpReprice.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReprice.Location = new System.Drawing.Point(197, 76);
            this.dtpReprice.Name = "dtpReprice";
            this.dtpReprice.Size = new System.Drawing.Size(87, 20);
            this.dtpReprice.TabIndex = 116;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(200, 17);
            this.radioButton1.TabIndex = 55;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Reprice all items in inventory (default)";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbRepriceThus
            // 
            this.rbRepriceThus.AutoSize = true;
            this.rbRepriceThus.Location = new System.Drawing.Point(13, 78);
            this.rbRepriceThus.Name = "rbRepriceThus";
            this.rbRepriceThus.Size = new System.Drawing.Size(179, 17);
            this.rbRepriceThus.TabIndex = 1;
            this.rbRepriceThus.TabStop = true;
            this.rbRepriceThus.Text = "Reprice items added or modified:";
            this.rbRepriceThus.UseVisualStyleBackColor = true;
            // 
            // rbStartWithNbr
            // 
            this.rbStartWithNbr.AutoSize = true;
            this.rbStartWithNbr.Location = new System.Drawing.Point(13, 55);
            this.rbStartWithNbr.Name = "rbStartWithNbr";
            this.rbStartWithNbr.Size = new System.Drawing.Size(97, 17);
            this.rbStartWithNbr.TabIndex = 0;
            this.rbStartWithNbr.TabStop = true;
            this.rbStartWithNbr.Text = "Start with SKU:";
            this.rbStartWithNbr.UseVisualStyleBackColor = true;
            // 
            // tbStartNbr
            // 
            this.tbStartNbr.Location = new System.Drawing.Point(112, 54);
            this.tbStartNbr.MaxLength = 15;
            this.tbStartNbr.Name = "tbStartNbr";
            this.tbStartNbr.Size = new System.Drawing.Size(112, 20);
            this.tbStartNbr.TabIndex = 54;
            this.toolTip1.SetToolTip(this.tbStartNbr, "Enter the book number that you want the re-pricing tool to start with.");
            this.tbStartNbr.Leave += new System.EventHandler(this.tbStartNbr_Leave);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.label201);
            this.groupBox21.Controls.Add(this.tbCondAmtVG);
            this.groupBox21.Controls.Add(this.label203);
            this.groupBox21.Controls.Add(this.label206);
            this.groupBox21.Controls.Add(this.tbCondAmtP);
            this.groupBox21.Controls.Add(this.label204);
            this.groupBox21.Controls.Add(this.label208);
            this.groupBox21.Controls.Add(this.tbCondAmtG);
            this.groupBox21.Controls.Add(this.label207);
            this.groupBox21.Location = new System.Drawing.Point(431, 6);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(363, 85);
            this.groupBox21.TabIndex = 105;
            this.groupBox21.TabStop = false;
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Location = new System.Drawing.Point(6, 15);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(231, 13);
            this.label201.TabIndex = 80;
            this.label201.Text = "If condition is marked \'Very Good\', drop price by";
            // 
            // tbCondAmtVG
            // 
            this.tbCondAmtVG.Location = new System.Drawing.Point(241, 12);
            this.tbCondAmtVG.Name = "tbCondAmtVG";
            this.tbCondAmtVG.Size = new System.Drawing.Size(35, 20);
            this.tbCondAmtVG.TabIndex = 81;
            this.toolTip1.SetToolTip(this.tbCondAmtVG, "Will drop price by this amount if not blank");
            this.tbCondAmtVG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            // 
            // label203
            // 
            this.label203.AutoSize = true;
            this.label203.Location = new System.Drawing.Point(280, 15);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(46, 13);
            this.label203.TabIndex = 82;
            this.label203.Text = "percent.";
            // 
            // label206
            // 
            this.label206.AutoSize = true;
            this.label206.Location = new System.Drawing.Point(6, 60);
            this.label206.Name = "label206";
            this.label206.Size = new System.Drawing.Size(203, 13);
            this.label206.TabIndex = 83;
            this.label206.Text = "If condition is marked \'Poor\', drop price by";
            // 
            // tbCondAmtP
            // 
            this.tbCondAmtP.Location = new System.Drawing.Point(213, 57);
            this.tbCondAmtP.Name = "tbCondAmtP";
            this.tbCondAmtP.Size = new System.Drawing.Size(35, 20);
            this.tbCondAmtP.TabIndex = 84;
            this.toolTip1.SetToolTip(this.tbCondAmtP, "Will drop price by this amount if not blank");
            this.tbCondAmtP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            // 
            // label204
            // 
            this.label204.AutoSize = true;
            this.label204.Location = new System.Drawing.Point(252, 60);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(46, 13);
            this.label204.TabIndex = 85;
            this.label204.Text = "percent.";
            // 
            // label208
            // 
            this.label208.AutoSize = true;
            this.label208.Location = new System.Drawing.Point(6, 38);
            this.label208.Name = "label208";
            this.label208.Size = new System.Drawing.Size(207, 13);
            this.label208.TabIndex = 86;
            this.label208.Text = "If condition is marked \'Good\', drop price by";
            // 
            // tbCondAmtG
            // 
            this.tbCondAmtG.Location = new System.Drawing.Point(217, 35);
            this.tbCondAmtG.Name = "tbCondAmtG";
            this.tbCondAmtG.Size = new System.Drawing.Size(35, 20);
            this.tbCondAmtG.TabIndex = 87;
            this.toolTip1.SetToolTip(this.tbCondAmtG, "Will drop price by this amount if not blank");
            this.tbCondAmtG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            // 
            // label207
            // 
            this.label207.AutoSize = true;
            this.label207.Location = new System.Drawing.Point(256, 38);
            this.label207.Name = "label207";
            this.label207.Size = new System.Drawing.Size(46, 13);
            this.label207.TabIndex = 88;
            this.label207.Text = "percent.";
            // 
            // bStartPricingService
            // 
            this.bStartPricingService.BackColor = System.Drawing.SystemColors.Desktop;
            this.bStartPricingService.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bStartPricingService.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bStartPricingService.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bStartPricingService.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bStartPricingService.Location = new System.Drawing.Point(721, 477);
            this.bStartPricingService.Name = "bStartPricingService";
            this.bStartPricingService.Size = new System.Drawing.Size(73, 25);
            this.bStartPricingService.TabIndex = 37;
            this.bStartPricingService.Text = "Start";
            this.bStartPricingService.UseVisualStyleBackColor = false;
            this.bStartPricingService.Click += new System.EventHandler(this.bStartPricingService_Click);
            // 
            // groupBox32
            // 
            this.groupBox32.Controls.Add(this.label89);
            this.groupBox32.Controls.Add(this.panel1);
            this.groupBox32.Controls.Add(this.rbHighAbove);
            this.groupBox32.Controls.Add(this.rbHighBelow);
            this.groupBox32.Controls.Add(this.lbWhatPriceH);
            this.groupBox32.Controls.Add(this.label192);
            this.groupBox32.Controls.Add(this.tbHighByAmt);
            this.groupBox32.Location = new System.Drawing.Point(15, 99);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new System.Drawing.Size(388, 69);
            this.groupBox32.TabIndex = 106;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "If my price is HIGH, compute a suggested price based on:";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.ForeColor = System.Drawing.Color.Firebrick;
            this.label89.Location = new System.Drawing.Point(304, 0);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(50, 13);
            this.label89.TabIndex = 132;
            this.label89.Text = "Required";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbPriceHighPct);
            this.panel1.Controls.Add(this.rbPriceHighFixed);
            this.panel1.Location = new System.Drawing.Point(14, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 42);
            this.panel1.TabIndex = 113;
            // 
            // rbPriceHighPct
            // 
            this.rbPriceHighPct.AutoSize = true;
            this.rbPriceHighPct.Location = new System.Drawing.Point(3, 20);
            this.rbPriceHighPct.Name = "rbPriceHighPct";
            this.rbPriceHighPct.Size = new System.Drawing.Size(79, 17);
            this.rbPriceHighPct.TabIndex = 53;
            this.rbPriceHighPct.TabStop = true;
            this.rbPriceHighPct.Text = "percentage";
            this.rbPriceHighPct.UseVisualStyleBackColor = true;
            // 
            // rbPriceHighFixed
            // 
            this.rbPriceHighFixed.AutoSize = true;
            this.rbPriceHighFixed.Location = new System.Drawing.Point(3, 3);
            this.rbPriceHighFixed.Name = "rbPriceHighFixed";
            this.rbPriceHighFixed.Size = new System.Drawing.Size(85, 17);
            this.rbPriceHighFixed.TabIndex = 52;
            this.rbPriceHighFixed.TabStop = true;
            this.rbPriceHighFixed.Text = "fixed amount";
            this.rbPriceHighFixed.UseVisualStyleBackColor = true;
            // 
            // rbHighAbove
            // 
            this.rbHighAbove.AutoSize = true;
            this.rbHighAbove.Location = new System.Drawing.Point(173, 26);
            this.rbHighAbove.Name = "rbHighAbove";
            this.rbHighAbove.Size = new System.Drawing.Size(73, 17);
            this.rbHighAbove.TabIndex = 52;
            this.rbHighAbove.TabStop = true;
            this.rbHighAbove.Text = "above the";
            this.rbHighAbove.UseVisualStyleBackColor = true;
            // 
            // rbHighBelow
            // 
            this.rbHighBelow.AutoSize = true;
            this.rbHighBelow.Location = new System.Drawing.Point(173, 43);
            this.rbHighBelow.Name = "rbHighBelow";
            this.rbHighBelow.Size = new System.Drawing.Size(71, 17);
            this.rbHighBelow.TabIndex = 53;
            this.rbHighBelow.TabStop = true;
            this.rbHighBelow.Text = "below the";
            this.rbHighBelow.UseVisualStyleBackColor = true;
            // 
            // lbWhatPriceH
            // 
            this.lbWhatPriceH.FormattingEnabled = true;
            this.lbWhatPriceH.Items.AddRange(new object[] {
            "low price.",
            "average price.",
            "high price."});
            this.lbWhatPriceH.Location = new System.Drawing.Point(252, 26);
            this.lbWhatPriceH.Name = "lbWhatPriceH";
            this.lbWhatPriceH.Size = new System.Drawing.Size(95, 30);
            this.lbWhatPriceH.TabIndex = 57;
            // 
            // label192
            // 
            this.label192.AutoSize = true;
            this.label192.Location = new System.Drawing.Point(106, 35);
            this.label192.Name = "label192";
            this.label192.Size = new System.Drawing.Size(16, 13);
            this.label192.TabIndex = 53;
            this.label192.Text = "of";
            // 
            // tbHighByAmt
            // 
            this.tbHighByAmt.Location = new System.Drawing.Point(126, 32);
            this.tbHighByAmt.MaxLength = 6;
            this.tbHighByAmt.Name = "tbHighByAmt";
            this.tbHighByAmt.Size = new System.Drawing.Size(31, 20);
            this.tbHighByAmt.TabIndex = 55;
            this.toolTip1.SetToolTip(this.tbHighByAmt, "Enter either a percentage or a fixed dollar amount.");
            this.tbHighByAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage2.Controls.Add(this.lTimeRemaining);
            this.tabPage2.Controls.Add(this.bPricingServiceUpdate);
            this.tabPage2.Controls.Add(this.lProgress);
            this.tabPage2.Controls.Add(this.bMarkAll);
            this.tabPage2.Controls.Add(this.bStopPricingService);
            this.tabPage2.Controls.Add(this.lPricingServiceStatus);
            this.tabPage2.Controls.Add(this.lvPricingService);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(855, 519);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "    Actions & Results    ";
            // 
            // lTimeRemaining
            // 
            this.lTimeRemaining.AutoSize = true;
            this.lTimeRemaining.Location = new System.Drawing.Point(47, 14);
            this.lTimeRemaining.Name = "lTimeRemaining";
            this.lTimeRemaining.Size = new System.Drawing.Size(81, 13);
            this.lTimeRemaining.TabIndex = 29;
            this.lTimeRemaining.Text = "Time remaining:";
            // 
            // bPricingServiceUpdate
            // 
            this.bPricingServiceUpdate.BackColor = System.Drawing.SystemColors.Desktop;
            this.bPricingServiceUpdate.Enabled = false;
            this.bPricingServiceUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bPricingServiceUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bPricingServiceUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bPricingServiceUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bPricingServiceUpdate.Location = new System.Drawing.Point(683, 44);
            this.bPricingServiceUpdate.Name = "bPricingServiceUpdate";
            this.bPricingServiceUpdate.Size = new System.Drawing.Size(73, 25);
            this.bPricingServiceUpdate.TabIndex = 13;
            this.bPricingServiceUpdate.Text = "Update";
            this.toolTip1.SetToolTip(this.bPricingServiceUpdate, "Update books with the \'suggested\' price that have check marks next to them.");
            this.bPricingServiceUpdate.UseVisualStyleBackColor = false;
            this.bPricingServiceUpdate.Click += new System.EventHandler(this.bPricingServiceUpdate_Click);
            // 
            // lProgress
            // 
            this.lProgress.AutoSize = true;
            this.lProgress.Location = new System.Drawing.Point(47, 56);
            this.lProgress.Name = "lProgress";
            this.lProgress.Size = new System.Drawing.Size(92, 13);
            this.lProgress.TabIndex = 27;
            this.lProgress.Text = "Processing: 0 of 0";
            // 
            // bMarkAll
            // 
            this.bMarkAll.BackColor = System.Drawing.SystemColors.Desktop;
            this.bMarkAll.Enabled = false;
            this.bMarkAll.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bMarkAll.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bMarkAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bMarkAll.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bMarkAll.Location = new System.Drawing.Point(683, 13);
            this.bMarkAll.Name = "bMarkAll";
            this.bMarkAll.Size = new System.Drawing.Size(73, 25);
            this.bMarkAll.TabIndex = 20;
            this.bMarkAll.Text = "Check all";
            this.toolTip1.SetToolTip(this.bMarkAll, "Mark all records for updating; then, if needed, you can unmark those books you do" +
        " not want to update or repricing.");
            this.bMarkAll.UseVisualStyleBackColor = false;
            this.bMarkAll.Click += new System.EventHandler(this.bMarkAll_Click);
            // 
            // bStopPricingService
            // 
            this.bStopPricingService.BackColor = System.Drawing.SystemColors.Desktop;
            this.bStopPricingService.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bStopPricingService.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bStopPricingService.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bStopPricingService.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bStopPricingService.Location = new System.Drawing.Point(561, 13);
            this.bStopPricingService.Name = "bStopPricingService";
            this.bStopPricingService.Size = new System.Drawing.Size(73, 25);
            this.bStopPricingService.TabIndex = 19;
            this.bStopPricingService.Text = "Stop";
            this.bStopPricingService.UseVisualStyleBackColor = false;
            this.bStopPricingService.Click += new System.EventHandler(this.bStopPricingService_Click);
            // 
            // lPricingServiceStatus
            // 
            this.lPricingServiceStatus.AutoSize = true;
            this.lPricingServiceStatus.Location = new System.Drawing.Point(47, 35);
            this.lPricingServiceStatus.Name = "lPricingServiceStatus";
            this.lPricingServiceStatus.Size = new System.Drawing.Size(108, 13);
            this.lPricingServiceStatus.TabIndex = 9;
            this.lPricingServiceStatus.Tag = "";
            this.lPricingServiceStatus.Text = "PricingServiceStatus:";
            // 
            // lvPricingService
            // 
            this.lvPricingService.CheckBoxes = true;
            this.lvPricingService.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvSKU,
            this.lvUPC,
            this.lvTitle,
            this.lvURPrice,
            this.lvLow,
            this.lvAverage,
            this.lvHigh,
            this.lvCost,
            this.lvSuggPrice});
            this.lvPricingService.GridLines = true;
            this.lvPricingService.LabelWrap = false;
            this.lvPricingService.Location = new System.Drawing.Point(9, 79);
            this.lvPricingService.MultiSelect = false;
            this.lvPricingService.Name = "lvPricingService";
            this.lvPricingService.Size = new System.Drawing.Size(817, 425);
            this.lvPricingService.TabIndex = 0;
            this.lvPricingService.UseCompatibleStateImageBehavior = false;
            this.lvPricingService.View = System.Windows.Forms.View.Details;
            // 
            // lvSKU
            // 
            this.lvSKU.Text = "Updt          SKU";
            this.lvSKU.Width = 115;
            // 
            // lvUPC
            // 
            this.lvUPC.Text = "UPC";
            this.lvUPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lvUPC.Width = 90;
            // 
            // lvTitle
            // 
            this.lvTitle.Text = "                                   Title";
            this.lvTitle.Width = 245;
            // 
            // lvURPrice
            // 
            this.lvURPrice.Text = "Current ";
            this.lvURPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lvURPrice.Width = 55;
            // 
            // lvLow
            // 
            this.lvLow.Text = "Low    ";
            this.lvLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lvLow.Width = 55;
            // 
            // lvAverage
            // 
            this.lvAverage.Text = "Avg    ";
            this.lvAverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lvAverage.Width = 55;
            // 
            // lvHigh
            // 
            this.lvHigh.Text = "High    ";
            this.lvHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lvHigh.Width = 55;
            // 
            // lvCost
            // 
            this.lvCost.Text = "Cost  ";
            this.lvCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lvCost.Width = 45;
            // 
            // lvSuggPrice
            // 
            this.lvSuggPrice.Text = "Suggest ";
            this.lvSuggPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lvSuggPrice.Width = 58;
            // 
            // lbSSCompare2
            // 
            this.lbSSCompare2.FormattingEnabled = true;
            this.lbSSCompare2.Items.AddRange(new object[] {
            "is equal to",
            "is not equal to",
            "is greater than",
            "is less than"});
            this.lbSSCompare2.Location = new System.Drawing.Point(217, 73);
            this.lbSSCompare2.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.lbSSCompare2.Name = "lbSSCompare2";
            this.lbSSCompare2.Size = new System.Drawing.Size(103, 30);
            this.lbSSCompare2.TabIndex = 18;
            this.toolTip1.SetToolTip(this.lbSSCompare2, "Using the up and down arrows, select one item so it turns blue");
            // 
            // lbSSAndOr2
            // 
            this.lbSSAndOr2.FormattingEnabled = true;
            this.lbSSAndOr2.Items.AddRange(new object[] {
            "- - -",
            "and",
            "or"});
            this.lbSSAndOr2.Location = new System.Drawing.Point(13, 73);
            this.lbSSAndOr2.Name = "lbSSAndOr2";
            this.lbSSAndOr2.Size = new System.Drawing.Size(48, 30);
            this.lbSSAndOr2.TabIndex = 15;
            this.toolTip1.SetToolTip(this.lbSSAndOr2, "Select one item so it turns blue");
            // 
            // lbSSCompare1
            // 
            this.lbSSCompare1.FormattingEnabled = true;
            this.lbSSCompare1.Items.AddRange(new object[] {
            "is equal to",
            "is not equal to",
            "is greater than",
            "is less than"});
            this.lbSSCompare1.Location = new System.Drawing.Point(218, 27);
            this.lbSSCompare1.Margin = new System.Windows.Forms.Padding(1, 3, 0, 3);
            this.lbSSCompare1.Name = "lbSSCompare1";
            this.lbSSCompare1.Size = new System.Drawing.Size(103, 30);
            this.lbSSCompare1.TabIndex = 14;
            this.toolTip1.SetToolTip(this.lbSSCompare1, "Using the up and down arrows, select one item so it turns blue");
            // 
            // cbUploadPurgeReplace
            // 
            this.cbUploadPurgeReplace.AutoSize = true;
            this.cbUploadPurgeReplace.Location = new System.Drawing.Point(274, 210);
            this.cbUploadPurgeReplace.Name = "cbUploadPurgeReplace";
            this.cbUploadPurgeReplace.Size = new System.Drawing.Size(99, 17);
            this.cbUploadPurgeReplace.TabIndex = 138;
            this.cbUploadPurgeReplace.Text = "Purge/Replace";
            this.toolTip1.SetToolTip(this.cbUploadPurgeReplace, "Check this if you are doing a purge/replace (it will display the correct filename" +
        "s)");
            // 
            // cbUploadTest
            // 
            this.cbUploadTest.AutoSize = true;
            this.cbUploadTest.Location = new System.Drawing.Point(175, 210);
            this.cbUploadTest.Name = "cbUploadTest";
            this.cbUploadTest.Size = new System.Drawing.Size(84, 17);
            this.cbUploadTest.TabIndex = 21;
            this.cbUploadTest.Text = "Test Upload";
            this.toolTip1.SetToolTip(this.cbUploadTest, "Check this if you only want to do a test upload");
            // 
            // cbFreezeDBPanel
            // 
            this.cbFreezeDBPanel.AutoSize = true;
            this.cbFreezeDBPanel.Location = new System.Drawing.Point(591, 29);
            this.cbFreezeDBPanel.Name = "cbFreezeDBPanel";
            this.cbFreezeDBPanel.Size = new System.Drawing.Size(96, 17);
            this.cbFreezeDBPanel.TabIndex = 165;
            this.cbFreezeDBPanel.Text = "Freeze Results";
            this.toolTip1.SetToolTip(this.cbFreezeDBPanel, "Prevents the Database Panel from refreshing.");
            this.cbFreezeDBPanel.UseVisualStyleBackColor = true;
            this.cbFreezeDBPanel.CheckStateChanged += new System.EventHandler(this.cbFreezeDBPanel_CheckStateChanged);
            // 
            // cbDeleteByYear
            // 
            this.cbDeleteByYear.AutoSize = true;
            this.cbDeleteByYear.Location = new System.Drawing.Point(54, 39);
            this.cbDeleteByYear.Name = "cbDeleteByYear";
            this.cbDeleteByYear.Size = new System.Drawing.Size(210, 17);
            this.cbDeleteByYear.TabIndex = 0;
            this.cbDeleteByYear.Text = "Delete items marked SOLD for the year";
            this.toolTip1.SetToolTip(this.cbDeleteByYear, "Filter to delete books from database by year sold; only works on previous years s" +
        "ales.");
            this.cbDeleteByYear.UseVisualStyleBackColor = true;
            this.cbDeleteByYear.CheckedChanged += new System.EventHandler(this.cbDeleteByYear_CheckedChanged);
            // 
            // tbPurgeDate
            // 
            this.tbPurgeDate.Location = new System.Drawing.Point(275, 39);
            this.tbPurgeDate.Name = "tbPurgeDate";
            this.tbPurgeDate.Size = new System.Drawing.Size(53, 20);
            this.tbPurgeDate.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbPurgeDate, "Enter year to be deleted");
            this.tbPurgeDate.TextChanged += new System.EventHandler(this.tbPurgeDate_TextChanged);
            // 
            // lbSSCompare3
            // 
            this.lbSSCompare3.FormattingEnabled = true;
            this.lbSSCompare3.Items.AddRange(new object[] {
            "is equal to",
            "is not equal to",
            "is greater than",
            "is less than"});
            this.lbSSCompare3.Location = new System.Drawing.Point(217, 119);
            this.lbSSCompare3.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.lbSSCompare3.Name = "lbSSCompare3";
            this.lbSSCompare3.Size = new System.Drawing.Size(103, 30);
            this.lbSSCompare3.TabIndex = 170;
            this.toolTip1.SetToolTip(this.lbSSCompare3, "Using the up and down arrows, select one item so it turns blue");
            // 
            // tbSSCompareTo3
            // 
            this.tbSSCompareTo3.Location = new System.Drawing.Point(322, 119);
            this.tbSSCompareTo3.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.tbSSCompareTo3.MaxLength = 200;
            this.tbSSCompareTo3.Name = "tbSSCompareTo3";
            this.tbSSCompareTo3.Size = new System.Drawing.Size(230, 20);
            this.tbSSCompareTo3.TabIndex = 169;
            this.toolTip1.SetToolTip(this.tbSSCompareTo3, "If comparison is \"is equal to\" you can use * as a wildcard");
            // 
            // lbSSAndOr3
            // 
            this.lbSSAndOr3.FormattingEnabled = true;
            this.lbSSAndOr3.Items.AddRange(new object[] {
            "- - -",
            "and",
            "or"});
            this.lbSSAndOr3.Location = new System.Drawing.Point(13, 118);
            this.lbSSAndOr3.Name = "lbSSAndOr3";
            this.lbSSAndOr3.Size = new System.Drawing.Size(48, 30);
            this.lbSSAndOr3.TabIndex = 168;
            this.toolTip1.SetToolTip(this.lbSSAndOr3, "Select one item so it turns blue");
            // 
            // lbSSCompare4
            // 
            this.lbSSCompare4.FormattingEnabled = true;
            this.lbSSCompare4.Items.AddRange(new object[] {
            "is equal to",
            "is not equal to",
            "is greater than",
            "is less than"});
            this.lbSSCompare4.Location = new System.Drawing.Point(217, 165);
            this.lbSSCompare4.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.lbSSCompare4.Name = "lbSSCompare4";
            this.lbSSCompare4.Size = new System.Drawing.Size(103, 30);
            this.lbSSCompare4.TabIndex = 174;
            this.toolTip1.SetToolTip(this.lbSSCompare4, "Using the up and down arrows, select one item so it turns blue");
            // 
            // tbSSCompareTo4
            // 
            this.tbSSCompareTo4.Location = new System.Drawing.Point(322, 165);
            this.tbSSCompareTo4.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.tbSSCompareTo4.MaxLength = 200;
            this.tbSSCompareTo4.Name = "tbSSCompareTo4";
            this.tbSSCompareTo4.Size = new System.Drawing.Size(230, 20);
            this.tbSSCompareTo4.TabIndex = 173;
            this.toolTip1.SetToolTip(this.tbSSCompareTo4, "If comparison is \"is equal to\" you can use * as a wildcard");
            // 
            // lbSSAndOr4
            // 
            this.lbSSAndOr4.FormattingEnabled = true;
            this.lbSSAndOr4.Items.AddRange(new object[] {
            "- - -",
            "and",
            "or"});
            this.lbSSAndOr4.Location = new System.Drawing.Point(13, 164);
            this.lbSSAndOr4.Name = "lbSSAndOr4";
            this.lbSSAndOr4.Size = new System.Drawing.Size(48, 30);
            this.lbSSAndOr4.TabIndex = 172;
            this.toolTip1.SetToolTip(this.lbSSAndOr4, "Select one item so it turns blue");
            // 
            // lbMappingNames
            // 
            this.lbMappingNames.FormattingEnabled = true;
            this.lbMappingNames.HorizontalScrollbar = true;
            this.lbMappingNames.Location = new System.Drawing.Point(17, 12);
            this.lbMappingNames.MultiColumn = true;
            this.lbMappingNames.Name = "lbMappingNames";
            this.lbMappingNames.Size = new System.Drawing.Size(693, 69);
            this.lbMappingNames.TabIndex = 68;
            this.toolTip1.SetToolTip(this.lbMappingNames, "Drag and drop these names to text boxes below.");
            this.lbMappingNames.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbMappingNames_MouseDown);
            // 
            // tbMapAddDesc3
            // 
            this.tbMapAddDesc3.AllowDrop = true;
            this.tbMapAddDesc3.Location = new System.Drawing.Point(395, 448);
            this.tbMapAddDesc3.MaxLength = 25;
            this.tbMapAddDesc3.Name = "tbMapAddDesc3";
            this.tbMapAddDesc3.Size = new System.Drawing.Size(105, 20);
            this.tbMapAddDesc3.TabIndex = 66;
            this.toolTip1.SetToolTip(this.tbMapAddDesc3, "Drag and drop from list of names above.");
            this.tbMapAddDesc3.Visible = false;
            this.tbMapAddDesc3.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapAddDesc3_DragDrop);
            this.tbMapAddDesc3.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapAddDesc2
            // 
            this.tbMapAddDesc2.AllowDrop = true;
            this.tbMapAddDesc2.Location = new System.Drawing.Point(395, 422);
            this.tbMapAddDesc2.MaxLength = 25;
            this.tbMapAddDesc2.Name = "tbMapAddDesc2";
            this.tbMapAddDesc2.Size = new System.Drawing.Size(105, 20);
            this.tbMapAddDesc2.TabIndex = 63;
            this.toolTip1.SetToolTip(this.tbMapAddDesc2, "Drag and drop from list of names above.");
            this.tbMapAddDesc2.Visible = false;
            this.tbMapAddDesc2.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapAddDesc2_DragDrop);
            this.tbMapAddDesc2.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapAddTitle
            // 
            this.tbMapAddTitle.AllowDrop = true;
            this.tbMapAddTitle.Location = new System.Drawing.Point(395, 394);
            this.tbMapAddTitle.Margin = new System.Windows.Forms.Padding(1, 3, 2, 3);
            this.tbMapAddTitle.MaxLength = 25;
            this.tbMapAddTitle.Name = "tbMapAddTitle";
            this.tbMapAddTitle.Size = new System.Drawing.Size(105, 20);
            this.tbMapAddTitle.TabIndex = 62;
            this.toolTip1.SetToolTip(this.tbMapAddTitle, "Drag and drop from list of names above.");
            this.tbMapAddTitle.Visible = false;
            this.tbMapAddTitle.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapAddDesc1_DragDrop);
            this.tbMapAddTitle.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapQty
            // 
            this.tbMapQty.AllowDrop = true;
            this.tbMapQty.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbMapQty.Location = new System.Drawing.Point(17, 209);
            this.tbMapQty.MaxLength = 25;
            this.tbMapQty.Name = "tbMapQty";
            this.tbMapQty.Size = new System.Drawing.Size(105, 20);
            this.tbMapQty.TabIndex = 58;
            this.toolTip1.SetToolTip(this.tbMapQty, "Drag and drop from list of names above.");
            this.tbMapQty.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbNbrOfCopies_DragDrop);
            this.tbMapQty.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapLocation
            // 
            this.tbMapLocation.AllowDrop = true;
            this.tbMapLocation.Location = new System.Drawing.Point(395, 369);
            this.tbMapLocation.MaxLength = 25;
            this.tbMapLocation.Name = "tbMapLocation";
            this.tbMapLocation.Size = new System.Drawing.Size(105, 20);
            this.tbMapLocation.TabIndex = 55;
            this.toolTip1.SetToolTip(this.tbMapLocation, "Drag and drop from list of names above.");
            this.tbMapLocation.Visible = false;
            this.tbMapLocation.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapLocation_DragDrop);
            this.tbMapLocation.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapPrivateNotes
            // 
            this.tbMapPrivateNotes.AllowDrop = true;
            this.tbMapPrivateNotes.Location = new System.Drawing.Point(395, 341);
            this.tbMapPrivateNotes.MaxLength = 25;
            this.tbMapPrivateNotes.Name = "tbMapPrivateNotes";
            this.tbMapPrivateNotes.Size = new System.Drawing.Size(105, 20);
            this.tbMapPrivateNotes.TabIndex = 54;
            this.toolTip1.SetToolTip(this.tbMapPrivateNotes, "Drag and drop from list of names above.");
            this.tbMapPrivateNotes.Visible = false;
            this.tbMapPrivateNotes.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapPrivateNotes_DragDrop);
            this.tbMapPrivateNotes.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapDateSold
            // 
            this.tbMapDateSold.AllowDrop = true;
            this.tbMapDateSold.Location = new System.Drawing.Point(395, 230);
            this.tbMapDateSold.MaxLength = 25;
            this.tbMapDateSold.Name = "tbMapDateSold";
            this.tbMapDateSold.Size = new System.Drawing.Size(105, 20);
            this.tbMapDateSold.TabIndex = 50;
            this.toolTip1.SetToolTip(this.tbMapDateSold, "Drag and drop from list of names above.");
            this.tbMapDateSold.Visible = false;
            this.tbMapDateSold.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapDateSold_DragDrop);
            this.tbMapDateSold.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapProductID
            // 
            this.tbMapProductID.AllowDrop = true;
            this.tbMapProductID.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbMapProductID.Location = new System.Drawing.Point(17, 405);
            this.tbMapProductID.MaxLength = 25;
            this.tbMapProductID.Name = "tbMapProductID";
            this.tbMapProductID.Size = new System.Drawing.Size(105, 20);
            this.tbMapProductID.TabIndex = 47;
            this.toolTip1.SetToolTip(this.tbMapProductID, "Drag and drop from list of names above.");
            this.tbMapProductID.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapType_DragDrop);
            this.tbMapProductID.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapCondition
            // 
            this.tbMapCondition.AllowDrop = true;
            this.tbMapCondition.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbMapCondition.Location = new System.Drawing.Point(17, 292);
            this.tbMapCondition.MaxLength = 25;
            this.tbMapCondition.Name = "tbMapCondition";
            this.tbMapCondition.Size = new System.Drawing.Size(105, 20);
            this.tbMapCondition.TabIndex = 43;
            this.toolTip1.SetToolTip(this.tbMapCondition, "Drag and drop from list of names above.");
            this.tbMapCondition.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapYearPub_DragDrop);
            this.tbMapCondition.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapProdIDType
            // 
            this.tbMapProdIDType.AllowDrop = true;
            this.tbMapProdIDType.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbMapProdIDType.Location = new System.Drawing.Point(17, 235);
            this.tbMapProdIDType.MaxLength = 25;
            this.tbMapProdIDType.Name = "tbMapProdIDType";
            this.tbMapProdIDType.Size = new System.Drawing.Size(105, 20);
            this.tbMapProdIDType.TabIndex = 42;
            this.toolTip1.SetToolTip(this.tbMapProdIDType, "Drag and drop from list of names above.");
            this.tbMapProdIDType.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapCost_DragDrop);
            this.tbMapProdIDType.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapPubLoc
            // 
            this.tbMapPubLoc.AllowDrop = true;
            this.tbMapPubLoc.Location = new System.Drawing.Point(395, 128);
            this.tbMapPubLoc.MaxLength = 25;
            this.tbMapPubLoc.Name = "tbMapPubLoc";
            this.tbMapPubLoc.Size = new System.Drawing.Size(105, 20);
            this.tbMapPubLoc.TabIndex = 36;
            this.toolTip1.SetToolTip(this.tbMapPubLoc, "Drag and drop from list of names above.");
            this.tbMapPubLoc.Visible = false;
            this.tbMapPubLoc.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapPubLoc_DragDrop);
            this.tbMapPubLoc.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapMediaCond
            // 
            this.tbMapMediaCond.AllowDrop = true;
            this.tbMapMediaCond.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbMapMediaCond.Location = new System.Drawing.Point(395, 260);
            this.tbMapMediaCond.MaxLength = 25;
            this.tbMapMediaCond.Name = "tbMapMediaCond";
            this.tbMapMediaCond.Size = new System.Drawing.Size(105, 20);
            this.tbMapMediaCond.TabIndex = 33;
            this.toolTip1.SetToolTip(this.tbMapMediaCond, "Drag and drop from list of names above.");
            this.tbMapMediaCond.Visible = false;
            this.tbMapMediaCond.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapMediaCond_DragDrop);
            this.tbMapMediaCond.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapUPC
            // 
            this.tbMapUPC.AllowDrop = true;
            this.tbMapUPC.Location = new System.Drawing.Point(395, 176);
            this.tbMapUPC.MaxLength = 25;
            this.tbMapUPC.Name = "tbMapUPC";
            this.tbMapUPC.Size = new System.Drawing.Size(105, 20);
            this.tbMapUPC.TabIndex = 29;
            this.toolTip1.SetToolTip(this.tbMapUPC, "Drag and drop from list of names above.");
            this.tbMapUPC.Visible = false;
            this.tbMapUPC.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapUPC_DragDrop);
            this.tbMapUPC.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapASIN
            // 
            this.tbMapASIN.AllowDrop = true;
            this.tbMapASIN.Location = new System.Drawing.Point(17, 318);
            this.tbMapASIN.MaxLength = 25;
            this.tbMapASIN.Name = "tbMapASIN";
            this.tbMapASIN.Size = new System.Drawing.Size(105, 20);
            this.tbMapASIN.TabIndex = 28;
            this.toolTip1.SetToolTip(this.tbMapASIN, "Drag and drop from list of names above.");
            this.tbMapASIN.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapCatalog_DragDrop);
            this.tbMapASIN.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapItemNotes
            // 
            this.tbMapItemNotes.AllowDrop = true;
            this.tbMapItemNotes.Location = new System.Drawing.Point(17, 263);
            this.tbMapItemNotes.MaxLength = 25;
            this.tbMapItemNotes.Name = "tbMapItemNotes";
            this.tbMapItemNotes.Size = new System.Drawing.Size(105, 20);
            this.tbMapItemNotes.TabIndex = 25;
            this.toolTip1.SetToolTip(this.tbMapItemNotes, "Drag and drop from list of names above.");
            this.tbMapItemNotes.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapEdition_DragDrop);
            this.tbMapItemNotes.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapPrice
            // 
            this.tbMapPrice.AllowDrop = true;
            this.tbMapPrice.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbMapPrice.Location = new System.Drawing.Point(17, 180);
            this.tbMapPrice.MaxLength = 25;
            this.tbMapPrice.Name = "tbMapPrice";
            this.tbMapPrice.Size = new System.Drawing.Size(105, 20);
            this.tbMapPrice.TabIndex = 21;
            this.toolTip1.SetToolTip(this.tbMapPrice, "Drag and drop from list of names above.");
            this.tbMapPrice.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapPrice_DragDrop);
            this.tbMapPrice.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapDesc
            // 
            this.tbMapDesc.AllowDrop = true;
            this.tbMapDesc.Location = new System.Drawing.Point(16, 128);
            this.tbMapDesc.MaxLength = 25;
            this.tbMapDesc.Name = "tbMapDesc";
            this.tbMapDesc.Size = new System.Drawing.Size(105, 20);
            this.tbMapDesc.TabIndex = 20;
            this.toolTip1.SetToolTip(this.tbMapDesc, "Drag and drop from list of names above.");
            this.tbMapDesc.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapDesc_DragDrop);
            this.tbMapDesc.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapPublisher
            // 
            this.tbMapPublisher.AllowDrop = true;
            this.tbMapPublisher.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbMapPublisher.Location = new System.Drawing.Point(394, 99);
            this.tbMapPublisher.MaxLength = 25;
            this.tbMapPublisher.Name = "tbMapPublisher";
            this.tbMapPublisher.Size = new System.Drawing.Size(105, 20);
            this.tbMapPublisher.TabIndex = 16;
            this.toolTip1.SetToolTip(this.tbMapPublisher, "Drag and drop from list of names above.");
            this.tbMapPublisher.Visible = false;
            this.tbMapPublisher.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapPublisher_DragDrop);
            this.tbMapPublisher.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapTitle
            // 
            this.tbMapTitle.AllowDrop = true;
            this.tbMapTitle.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbMapTitle.Location = new System.Drawing.Point(16, 99);
            this.tbMapTitle.MaxLength = 25;
            this.tbMapTitle.Name = "tbMapTitle";
            this.tbMapTitle.Size = new System.Drawing.Size(105, 20);
            this.tbMapTitle.TabIndex = 13;
            this.toolTip1.SetToolTip(this.tbMapTitle, "Drag and drop from list of names above.");
            this.tbMapTitle.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapTitle_DragDrop);
            this.tbMapTitle.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbMapSKU
            // 
            this.tbMapSKU.AllowDrop = true;
            this.tbMapSKU.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbMapSKU.Location = new System.Drawing.Point(16, 154);
            this.tbMapSKU.MaxLength = 25;
            this.tbMapSKU.Name = "tbMapSKU";
            this.tbMapSKU.Size = new System.Drawing.Size(105, 20);
            this.tbMapSKU.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbMapSKU, "Drag and drop from list of names above.");
            this.tbMapSKU.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapSKU_DragDrop);
            this.tbMapSKU.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // bClear
            // 
            this.bClear.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClear.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.bClear.FlatAppearance.BorderSize = 2;
            this.bClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bClear.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bClear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bClear.Location = new System.Drawing.Point(706, 11);
            this.bClear.Margin = new System.Windows.Forms.Padding(2, 3, 1, 3);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(46, 25);
            this.bClear.TabIndex = 229;
            this.bClear.Text = "Clear";
            this.toolTip1.SetToolTip(this.bClear, "Clears all of the data on this page");
            this.bClear.UseVisualStyleBackColor = false;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // tbUPC
            // 
            this.tbUPC.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbUPC.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbUPC.Location = new System.Drawing.Point(79, 58);
            this.tbUPC.Mask = "AAAAAAAAAAAAa";
            this.tbUPC.Name = "tbUPC";
            this.tbUPC.PromptChar = ' ';
            this.tbUPC.Size = new System.Drawing.Size(92, 20);
            this.tbUPC.TabIndex = 0;
            this.toolTip1.SetToolTip(this.tbUPC, "Enter 12 digit UPC or 13 digit EAN");
            this.tbUPC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbUPC_MouseClick);
            this.tbUPC.TextChanged += new System.EventHandler(this.tbUPC_TextChanged);
            this.tbUPC.Leave += new System.EventHandler(this.tbUPC_Leave);
            this.tbUPC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbUPC_MouseDown);
            // 
            // bLookupPrices
            // 
            this.bLookupPrices.AutoEllipsis = true;
            this.bLookupPrices.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bLookupPrices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bLookupPrices.Enabled = false;
            this.bLookupPrices.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.bLookupPrices.FlatAppearance.BorderSize = 2;
            this.bLookupPrices.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bLookupPrices.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bLookupPrices.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bLookupPrices.Location = new System.Drawing.Point(191, 11);
            this.bLookupPrices.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.bLookupPrices.Name = "bLookupPrices";
            this.bLookupPrices.Size = new System.Drawing.Size(72, 25);
            this.bLookupPrices.TabIndex = 248;
            this.bLookupPrices.Text = "Get  Prices";
            this.toolTip1.SetToolTip(this.bLookupPrices, "Submits UPC to website to get prices");
            this.bLookupPrices.UseVisualStyleBackColor = false;
            this.bLookupPrices.Visible = false;
            this.bLookupPrices.Click += new System.EventHandler(this.bLookupPrices_Click);
            // 
            // lCondition
            // 
            this.lCondition.AutoSize = true;
            this.lCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCondition.Location = new System.Drawing.Point(502, 160);
            this.lCondition.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.lCondition.Name = "lCondition";
            this.lCondition.Size = new System.Drawing.Size(58, 13);
            this.lCondition.TabIndex = 244;
            this.lCondition.Text = "Condition *";
            this.toolTip1.SetToolTip(this.lCondition, "Click for stickey effect");
            this.lCondition.Click += new System.EventHandler(this.lCondition_Click);
            // 
            // cbCondition
            // 
            this.cbCondition.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.cbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbCondition.FormattingEnabled = true;
            this.cbCondition.Items.AddRange(new object[] {
            "New",
            "Used: Like New",
            "Used: Very Good",
            "Used: Good",
            "Used: Acceptable",
            "Collectible: Like New",
            "Collectible: Very Good",
            "Collectible: Good",
            "Collectible: Acceptable"});
            this.cbCondition.Location = new System.Drawing.Point(566, 156);
            this.cbCondition.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.cbCondition.MaxLength = 25;
            this.cbCondition.Name = "cbCondition";
            this.cbCondition.Size = new System.Drawing.Size(113, 21);
            this.cbCondition.TabIndex = 9;
            this.toolTip1.SetToolTip(this.cbCondition, "Enter data or select from drop-down list");
            this.cbCondition.SelectedIndexChanged += new System.EventHandler(this.textbox_TextChanged);
            this.cbCondition.KeyUp += new System.Windows.Forms.KeyEventHandler(this.coCondition_KeyUp);
            // 
            // lBinding
            // 
            this.lBinding.AutoSize = true;
            this.lBinding.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBinding.Location = new System.Drawing.Point(13, 95);
            this.lBinding.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.lBinding.Name = "lBinding";
            this.lBinding.Size = new System.Drawing.Size(81, 13);
            this.lBinding.TabIndex = 243;
            this.lBinding.Text = "Product Type: *";
            this.toolTip1.SetToolTip(this.lBinding, "Click for stickey effect");
            this.lBinding.Click += new System.EventHandler(this.lBinding_Click);
            // 
            // coProductType
            // 
            this.coProductType.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.coProductType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.coProductType.FormattingEnabled = true;
            this.coProductType.Items.AddRange(new object[] {
            "Music Classical",
            "Music Popular",
            "Video DVD",
            "Video VHS"});
            this.coProductType.Location = new System.Drawing.Point(99, 92);
            this.coProductType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.coProductType.MaxDropDownItems = 10;
            this.coProductType.MaxLength = 25;
            this.coProductType.Name = "coProductType";
            this.coProductType.Size = new System.Drawing.Size(113, 21);
            this.coProductType.TabIndex = 2;
            this.toolTip1.SetToolTip(this.coProductType, "Enter data or select from drop-down list");
            this.coProductType.SelectedIndexChanged += new System.EventHandler(this.coProductType_SelectedIndexChanged);
            // 
            // lPrivNotes
            // 
            this.lPrivNotes.AutoSize = true;
            this.lPrivNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPrivNotes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lPrivNotes.Location = new System.Drawing.Point(9, 499);
            this.lPrivNotes.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.lPrivNotes.Name = "lPrivNotes";
            this.lPrivNotes.Size = new System.Drawing.Size(78, 13);
            this.lPrivNotes.TabIndex = 235;
            this.lPrivNotes.Text = "Private Notes *";
            this.toolTip1.SetToolTip(this.lPrivNotes, "Click for stickey effect");
            // 
            // bShoppingCart
            // 
            this.bShoppingCart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bShoppingCart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bShoppingCart.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.bShoppingCart.FlatAppearance.BorderSize = 2;
            this.bShoppingCart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bShoppingCart.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bShoppingCart.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bShoppingCart.Location = new System.Drawing.Point(590, 11);
            this.bShoppingCart.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.bShoppingCart.Name = "bShoppingCart";
            this.bShoppingCart.Size = new System.Drawing.Size(107, 25);
            this.bShoppingCart.TabIndex = 241;
            this.bShoppingCart.Text = "To Shopping Cart";
            this.toolTip1.SetToolTip(this.bShoppingCart, "Transfer item to shopping cart (invoice)");
            this.bShoppingCart.UseVisualStyleBackColor = false;
            this.bShoppingCart.Click += new System.EventHandler(this.bShoppingCart_Click);
            // 
            // bGetMediaInfo
            // 
            this.bGetMediaInfo.AutoEllipsis = true;
            this.bGetMediaInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bGetMediaInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bGetMediaInfo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.bGetMediaInfo.FlatAppearance.BorderSize = 2;
            this.bGetMediaInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bGetMediaInfo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bGetMediaInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bGetMediaInfo.Location = new System.Drawing.Point(16, 11);
            this.bGetMediaInfo.Margin = new System.Windows.Forms.Padding(3, 3, 1, 1);
            this.bGetMediaInfo.Name = "bGetMediaInfo";
            this.bGetMediaInfo.Size = new System.Drawing.Size(88, 25);
            this.bGetMediaInfo.TabIndex = 205;
            this.bGetMediaInfo.Text = "Get Media Info";
            this.toolTip1.SetToolTip(this.bGetMediaInfo, "Submits data to web services, clearing the old data");
            this.bGetMediaInfo.UseVisualStyleBackColor = false;
            this.bGetMediaInfo.Click += new System.EventHandler(this.bGetMediaInfo_Click);
            // 
            // tbSKU
            // 
            this.tbSKU.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbSKU.Location = new System.Drawing.Point(694, 58);
            this.tbSKU.Margin = new System.Windows.Forms.Padding(0, 3, 3, 1);
            this.tbSKU.MaxLength = 15;
            this.tbSKU.Name = "tbSKU";
            this.tbSKU.Size = new System.Drawing.Size(108, 20);
            this.tbSKU.TabIndex = 0;
            this.toolTip1.SetToolTip(this.tbSKU, "SKU (Stock Keeping Unit) ");
            // 
            // lLocation
            // 
            this.lLocation.AutoSize = true;
            this.lLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLocation.Location = new System.Drawing.Point(639, 96);
            this.lLocation.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.lLocation.Name = "lLocation";
            this.lLocation.Size = new System.Drawing.Size(86, 13);
            this.lLocation.TabIndex = 202;
            this.lLocation.Text = "Stock Location *";
            this.toolTip1.SetToolTip(this.lLocation, "Click for stickey effect");
            this.lLocation.Click += new System.EventHandler(this.lLocation_Click);
            // 
            // bDeleteItem
            // 
            this.bDeleteItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bDeleteItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bDeleteItem.Enabled = false;
            this.bDeleteItem.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.bDeleteItem.FlatAppearance.BorderSize = 2;
            this.bDeleteItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bDeleteItem.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bDeleteItem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bDeleteItem.Location = new System.Drawing.Point(403, 11);
            this.bDeleteItem.Margin = new System.Windows.Forms.Padding(0, 0, 2, 3);
            this.bDeleteItem.Name = "bDeleteItem";
            this.bDeleteItem.Size = new System.Drawing.Size(52, 25);
            this.bDeleteItem.TabIndex = 228;
            this.bDeleteItem.Text = "Delete";
            this.toolTip1.SetToolTip(this.bDeleteItem, "Delete record from database");
            this.bDeleteItem.UseVisualStyleBackColor = false;
            this.bDeleteItem.Click += new System.EventHandler(this.bDeleteItem_Click);
            // 
            // bUpdateRecord
            // 
            this.bUpdateRecord.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bUpdateRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bUpdateRecord.Enabled = false;
            this.bUpdateRecord.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.bUpdateRecord.FlatAppearance.BorderSize = 2;
            this.bUpdateRecord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bUpdateRecord.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bUpdateRecord.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bUpdateRecord.Location = new System.Drawing.Point(340, 11);
            this.bUpdateRecord.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.bUpdateRecord.Name = "bUpdateRecord";
            this.bUpdateRecord.Size = new System.Drawing.Size(56, 25);
            this.bUpdateRecord.TabIndex = 203;
            this.bUpdateRecord.Text = "Update";
            this.toolTip1.SetToolTip(this.bUpdateRecord, "Update record in database");
            this.bUpdateRecord.UseVisualStyleBackColor = false;
            this.bUpdateRecord.Click += new System.EventHandler(this.bUpdateRecord_Click);
            // 
            // bAddRecord
            // 
            this.bAddRecord.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bAddRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bAddRecord.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.bAddRecord.FlatAppearance.BorderSize = 2;
            this.bAddRecord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bAddRecord.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bAddRecord.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bAddRecord.Location = new System.Drawing.Point(279, 11);
            this.bAddRecord.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.bAddRecord.Name = "bAddRecord";
            this.bAddRecord.Size = new System.Drawing.Size(55, 25);
            this.bAddRecord.TabIndex = 204;
            this.bAddRecord.Text = "Add";
            this.toolTip1.SetToolTip(this.bAddRecord, "Add record to database");
            this.bAddRecord.UseVisualStyleBackColor = false;
            this.bAddRecord.Click += new System.EventHandler(this.bAddRecord_Click);
            // 
            // bRelist
            // 
            this.bRelist.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bRelist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bRelist.Enabled = false;
            this.bRelist.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.bRelist.FlatAppearance.BorderSize = 2;
            this.bRelist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bRelist.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bRelist.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bRelist.Location = new System.Drawing.Point(462, 11);
            this.bRelist.Margin = new System.Windows.Forms.Padding(0, 0, 2, 3);
            this.bRelist.Name = "bRelist";
            this.bRelist.Size = new System.Drawing.Size(45, 25);
            this.bRelist.TabIndex = 268;
            this.bRelist.Text = "Relist";
            this.toolTip1.SetToolTip(this.bRelist, "Relist book giving it a new SKU and marked \'For Sale\'  (quantity must be zero; it" +
        " will be changed to 1 when added)");
            this.bRelist.UseVisualStyleBackColor = false;
            this.bRelist.Click += new System.EventHandler(this.bRelist_Click);
            // 
            // bNextItem
            // 
            this.bNextItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bNextItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bNextItem.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.bNextItem.FlatAppearance.BorderSize = 2;
            this.bNextItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bNextItem.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bNextItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNextItem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bNextItem.Location = new System.Drawing.Point(762, 11);
            this.bNextItem.Margin = new System.Windows.Forms.Padding(0, 0, 2, 3);
            this.bNextItem.Name = "bNextItem";
            this.bNextItem.Size = new System.Drawing.Size(63, 25);
            this.bNextItem.TabIndex = 272;
            this.bNextItem.Text = "Get Next";
            this.toolTip1.SetToolTip(this.bNextItem, "Will display the next book from the database");
            this.bNextItem.UseVisualStyleBackColor = false;
            this.bNextItem.Click += new System.EventHandler(this.bNextItem_Click);
            // 
            // resetDBPanel
            // 
            this.resetDBPanel.BackColor = System.Drawing.SystemColors.Desktop;
            this.resetDBPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.resetDBPanel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.resetDBPanel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.resetDBPanel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.resetDBPanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.resetDBPanel.Location = new System.Drawing.Point(667, 40);
            this.resetDBPanel.Name = "resetDBPanel";
            this.resetDBPanel.Size = new System.Drawing.Size(127, 34);
            this.resetDBPanel.TabIndex = 176;
            this.resetDBPanel.Text = "Reset database panel";
            this.toolTip1.SetToolTip(this.resetDBPanel, "Resets the Database Panel above");
            this.resetDBPanel.UseVisualStyleBackColor = false;
            this.resetDBPanel.Click += new System.EventHandler(this.resetDBPanel_Click);
            // 
            // tbInternational
            // 
            this.tbInternational.AllowDrop = true;
            this.tbInternational.Location = new System.Drawing.Point(17, 347);
            this.tbInternational.MaxLength = 25;
            this.tbInternational.Name = "tbInternational";
            this.tbInternational.Size = new System.Drawing.Size(105, 20);
            this.tbInternational.TabIndex = 75;
            this.toolTip1.SetToolTip(this.tbInternational, "Drag and drop from list of names above.");
            this.tbInternational.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbInternational_DragDrop);
            this.tbInternational.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // tbExpedited
            // 
            this.tbExpedited.AllowDrop = true;
            this.tbExpedited.Location = new System.Drawing.Point(17, 376);
            this.tbExpedited.MaxLength = 25;
            this.tbExpedited.Name = "tbExpedited";
            this.tbExpedited.Size = new System.Drawing.Size(105, 20);
            this.tbExpedited.TabIndex = 74;
            this.toolTip1.SetToolTip(this.tbExpedited, "Drag and drop from list of names above.");
            this.tbExpedited.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbExpedited_DragDrop);
            this.tbExpedited.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // bUpdateInfo
            // 
            this.bUpdateInfo.AutoEllipsis = true;
            this.bUpdateInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bUpdateInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bUpdateInfo.Enabled = false;
            this.bUpdateInfo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.bUpdateInfo.FlatAppearance.BorderSize = 2;
            this.bUpdateInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bUpdateInfo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bUpdateInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bUpdateInfo.Location = new System.Drawing.Point(110, 11);
            this.bUpdateInfo.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.bUpdateInfo.Name = "bUpdateInfo";
            this.bUpdateInfo.Size = new System.Drawing.Size(74, 25);
            this.bUpdateInfo.TabIndex = 286;
            this.bUpdateInfo.Text = "Update Info";
            this.toolTip1.SetToolTip(this.bUpdateInfo, "Submits UPC to website to get prices without clearing any data");
            this.bUpdateInfo.UseVisualStyleBackColor = false;
            this.bUpdateInfo.Click += new System.EventHandler(this.bUpdateInfo_Click);
            // 
            // cbStatusHold
            // 
            this.cbStatusHold.AutoSize = true;
            this.cbStatusHold.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbStatusHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatusHold.Location = new System.Drawing.Point(699, 125);
            this.cbStatusHold.Name = "cbStatusHold";
            this.cbStatusHold.Size = new System.Drawing.Size(120, 17);
            this.cbStatusHold.TabIndex = 287;
            this.cbStatusHold.Text = "Set Status to \"Hold\"";
            this.toolTip1.SetToolTip(this.cbStatusHold, "Will not upload these books");
            this.cbStatusHold.UseVisualStyleBackColor = true;
            this.cbStatusHold.CheckedChanged += new System.EventHandler(this.cbStatusHold_CheckedChanged);
            // 
            // rbCreateNewKey
            // 
            this.rbCreateNewKey.AutoSize = true;
            this.rbCreateNewKey.Location = new System.Drawing.Point(15, 69);
            this.rbCreateNewKey.Name = "rbCreateNewKey";
            this.rbCreateNewKey.Size = new System.Drawing.Size(196, 17);
            this.rbCreateNewKey.TabIndex = 2;
            this.rbCreateNewKey.Text = "Create a new key using next highest";
            this.toolTip1.SetToolTip(this.rbCreateNewKey, "Will create a new key from the highest numeric existing key");
            // 
            // bUpdateASIN
            // 
            this.bUpdateASIN.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bUpdateASIN.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bUpdateASIN.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bUpdateASIN.Location = new System.Drawing.Point(659, 19);
            this.bUpdateASIN.Name = "bUpdateASIN";
            this.bUpdateASIN.Size = new System.Drawing.Size(76, 25);
            this.bUpdateASIN.TabIndex = 12;
            this.bUpdateASIN.Text = "Update";
            this.toolTip1.SetToolTip(this.bUpdateASIN, "Directions: ONLY while on this page, click any title above ; when list of ASIN\'s " +
        "appear, select a line and it will automatically copy the selected ASIN to the te" +
        "xtbox; then click UPDATE.\r\n");
            this.bUpdateASIN.UseVisualStyleBackColor = false;
            this.bUpdateASIN.Click += new System.EventHandler(this.bUpdateASIN_Click);
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.SystemColors.Desktop;
            this.bSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSearch.Enabled = false;
            this.bSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bSearch.Location = new System.Drawing.Point(701, 27);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(62, 28);
            this.bSearch.TabIndex = 174;
            this.bSearch.Text = "Search";
            this.toolTip1.SetToolTip(this.bSearch, "Does a search; you may use the * wildcard here (see Help file for details)");
            this.bSearch.UseVisualStyleBackColor = false;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // cbWildCardSearch
            // 
            this.cbWildCardSearch.AutoSize = true;
            this.cbWildCardSearch.Location = new System.Drawing.Point(555, 27);
            this.cbWildCardSearch.Name = "cbWildCardSearch";
            this.cbWildCardSearch.Size = new System.Drawing.Size(122, 17);
            this.cbWildCardSearch.TabIndex = 175;
            this.cbWildCardSearch.Text = "Use wildcard search";
            this.toolTip1.SetToolTip(this.cbWildCardSearch, "A wildcard search is faster than drill-down when you have a large inventory");
            this.cbWildCardSearch.UseVisualStyleBackColor = true;
            this.cbWildCardSearch.CheckStateChanged += new System.EventHandler(this.cbWildCardSearch_CheckStateChanged);
            // 
            // bClearSearch
            // 
            this.bClearSearch.BackColor = System.Drawing.SystemColors.Desktop;
            this.bClearSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClearSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bClearSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bClearSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bClearSearch.Location = new System.Drawing.Point(701, 78);
            this.bClearSearch.Name = "bClearSearch";
            this.bClearSearch.Size = new System.Drawing.Size(62, 28);
            this.bClearSearch.TabIndex = 176;
            this.bClearSearch.Text = "Clear";
            this.toolTip1.SetToolTip(this.bClearSearch, "Clears the text boxes");
            this.bClearSearch.UseVisualStyleBackColor = false;
            this.bClearSearch.Click += new System.EventHandler(this.bClearSearch_Click);
            // 
            // bClone
            // 
            this.bClone.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bClone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClone.Enabled = false;
            this.bClone.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.bClone.FlatAppearance.BorderSize = 2;
            this.bClone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bClone.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bClone.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bClone.Location = new System.Drawing.Point(514, 11);
            this.bClone.Margin = new System.Windows.Forms.Padding(0, 0, 2, 3);
            this.bClone.Name = "bClone";
            this.bClone.Size = new System.Drawing.Size(45, 25);
            this.bClone.TabIndex = 294;
            this.bClone.Text = "Clone";
            this.toolTip1.SetToolTip(this.bClone, "Select a book from the Database panel; when you click Clone, the SKU is cleared a" +
        "nd the Add button enabled.");
            this.bClone.UseVisualStyleBackColor = false;
            this.bClone.Click += new System.EventHandler(this.bClone_Click);
            // 
            // tbTaxPct
            // 
            this.tbTaxPct.Location = new System.Drawing.Point(87, 21);
            this.tbTaxPct.Name = "tbTaxPct";
            this.tbTaxPct.Size = new System.Drawing.Size(37, 20);
            this.tbTaxPct.TabIndex = 158;
            this.toolTip1.SetToolTip(this.tbTaxPct, "Enter tax percent (a tax rate of 8.5 percent would be entered as 8.5, with no per" +
        "cent sign)");
            this.tbTaxPct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            this.tbTaxPct.Leave += new System.EventHandler(this.invFieldsChanged);
            // 
            // dataBasePanel
            // 
            this.dataBasePanel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch1,
            this.ch2,
            this.qty,
            this.ch3,
            this.ch4,
            this.ch5,
            this.ch6,
            this.invoice});
            this.dataBasePanel.ContextMenuStrip = this.contextMenuStrip2;
            this.dataBasePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataBasePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataBasePanel.FullRowSelect = true;
            this.dataBasePanel.GridLines = true;
            this.dataBasePanel.HideSelection = false;
            this.dataBasePanel.Location = new System.Drawing.Point(0, 21);
            this.dataBasePanel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.dataBasePanel.Name = "dataBasePanel";
            this.dataBasePanel.Size = new System.Drawing.Size(880, 106);
            this.dataBasePanel.TabIndex = 20;
            this.toolTip1.SetToolTip(this.dataBasePanel, "Right-click for display criteria choices");
            this.dataBasePanel.UseCompatibleStateImageBehavior = false;
            this.dataBasePanel.View = System.Windows.Forms.View.Details;
            this.dataBasePanel.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.dataBasePanel_ColumnClick);
            this.dataBasePanel.SelectedIndexChanged += new System.EventHandler(this.dataBasePanel_SelectedIndexChanged);
            this.dataBasePanel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataBasePanel_KeyPress);
            this.dataBasePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataBasePanel_MouseClick);
            // 
            // ch1
            // 
            this.ch1.Text = "        SKU";
            this.ch1.Width = 96;
            // 
            // ch2
            // 
            this.ch2.Text = "                                           Title";
            this.ch2.Width = 350;
            // 
            // qty
            // 
            this.qty.Text = " Qty";
            this.qty.Width = 36;
            // 
            // ch3
            // 
            this.ch3.Text = "      UPC/EAN";
            this.ch3.Width = 110;
            // 
            // ch4
            // 
            this.ch4.Text = "   Location";
            this.ch4.Width = 70;
            // 
            // ch5
            // 
            this.ch5.Text = "Price    ";
            this.ch5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ch6
            // 
            this.ch6.Text = "  Status";
            this.ch6.Width = 55;
            // 
            // invoice
            // 
            this.invoice.Text = "Invoice";
            this.invoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.invoice.Width = 74;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsShowAll,
            this.tsShowForSale,
            this.tsShowSold,
            this.tsShowHold,
            this.tsShowPending,
            this.tsShowCatalog});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.ShowCheckMargin = true;
            this.contextMenuStrip2.ShowImageMargin = false;
            this.contextMenuStrip2.Size = new System.Drawing.Size(227, 136);
            this.contextMenuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip2_ItemClicked);
            // 
            // tsShowAll
            // 
            this.tsShowAll.Checked = true;
            this.tsShowAll.CheckOnClick = true;
            this.tsShowAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsShowAll.Name = "tsShowAll";
            this.tsShowAll.Size = new System.Drawing.Size(226, 22);
            this.tsShowAll.Text = "Show all books";
            // 
            // tsShowForSale
            // 
            this.tsShowForSale.CheckOnClick = true;
            this.tsShowForSale.Name = "tsShowForSale";
            this.tsShowForSale.Size = new System.Drawing.Size(226, 22);
            this.tsShowForSale.Text = "Show only For Sale";
            // 
            // tsShowSold
            // 
            this.tsShowSold.CheckOnClick = true;
            this.tsShowSold.Name = "tsShowSold";
            this.tsShowSold.Size = new System.Drawing.Size(226, 22);
            this.tsShowSold.Text = "Show only Sold";
            // 
            // tsShowHold
            // 
            this.tsShowHold.CheckOnClick = true;
            this.tsShowHold.Name = "tsShowHold";
            this.tsShowHold.Size = new System.Drawing.Size(226, 22);
            this.tsShowHold.Text = "Show only Hold";
            // 
            // tsShowPending
            // 
            this.tsShowPending.Name = "tsShowPending";
            this.tsShowPending.Size = new System.Drawing.Size(226, 22);
            this.tsShowPending.Text = "Show only Pending";
            // 
            // tsShowCatalog
            // 
            this.tsShowCatalog.CheckOnClick = true;
            this.tsShowCatalog.Name = "tsShowCatalog";
            this.tsShowCatalog.Size = new System.Drawing.Size(226, 22);
            this.tsShowCatalog.Text = "Show from Catalog selection";
            this.tsShowCatalog.ToolTipText = "Show only those in a catalog entry";
            // 
            // bClearIncSearch
            // 
            this.bClearIncSearch.BackColor = System.Drawing.SystemColors.Desktop;
            this.bClearIncSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClearIncSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bClearIncSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bClearIncSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bClearIncSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bClearIncSearch.Location = new System.Drawing.Point(591, 144);
            this.bClearIncSearch.Name = "bClearIncSearch";
            this.bClearIncSearch.Size = new System.Drawing.Size(62, 28);
            this.bClearIncSearch.TabIndex = 177;
            this.bClearIncSearch.Text = "Clear";
            this.toolTip1.SetToolTip(this.bClearIncSearch, "Clears the text boxes");
            this.bClearIncSearch.UseVisualStyleBackColor = false;
            this.bClearIncSearch.Click += new System.EventHandler(this.bClearIncSearch_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox13.Controls.Add(this.bClearSearch);
            this.groupBox13.Controls.Add(this.cbWildCardSearch);
            this.groupBox13.Controls.Add(this.tbsrchKeywords);
            this.groupBox13.Controls.Add(this.bSearch);
            this.groupBox13.Controls.Add(this.label14);
            this.groupBox13.Controls.Add(this.tbsrchUPC);
            this.groupBox13.Controls.Add(this.label26);
            this.groupBox13.Controls.Add(this.tbsrchTitle);
            this.groupBox13.Controls.Add(this.tbsrchSKU);
            this.groupBox13.Controls.Add(this.label34);
            this.groupBox13.Controls.Add(this.label33);
            this.groupBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox13.Location = new System.Drawing.Point(15, 120);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(783, 166);
            this.groupBox13.TabIndex = 56;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Drill-down or wildcard (using an asterisk) search";
            this.toolTip1.SetToolTip(this.groupBox13, "See the tutorial on our website for help");
            // 
            // tbsrchKeywords
            // 
            this.tbsrchKeywords.Location = new System.Drawing.Point(74, 78);
            this.tbsrchKeywords.MaxLength = 85;
            this.tbsrchKeywords.Name = "tbsrchKeywords";
            this.tbsrchKeywords.Size = new System.Drawing.Size(397, 20);
            this.tbsrchKeywords.TabIndex = 55;
            this.tbsrchKeywords.TextChanged += new System.EventHandler(this.setupDrillDownSearch);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(14, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 54;
            this.label14.Text = "Keywords:";
            // 
            // tbsrchUPC
            // 
            this.tbsrchUPC.Location = new System.Drawing.Point(87, 118);
            this.tbsrchUPC.MaxLength = 13;
            this.tbsrchUPC.Name = "tbsrchUPC";
            this.tbsrchUPC.Size = new System.Drawing.Size(100, 20);
            this.tbsrchUPC.TabIndex = 49;
            this.tbsrchUPC.TextChanged += new System.EventHandler(this.setupDrillDownSearch);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(16, 121);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(59, 13);
            this.label26.TabIndex = 47;
            this.label26.Text = "UPC/EAN:";
            // 
            // tbsrchTitle
            // 
            this.tbsrchTitle.Location = new System.Drawing.Point(62, 31);
            this.tbsrchTitle.MaxLength = 100;
            this.tbsrchTitle.Name = "tbsrchTitle";
            this.tbsrchTitle.Size = new System.Drawing.Size(411, 20);
            this.tbsrchTitle.TabIndex = 1;
            this.tbsrchTitle.TextChanged += new System.EventHandler(this.setupDrillDownSearch);
            // 
            // tbsrchSKU
            // 
            this.tbsrchSKU.Location = new System.Drawing.Point(261, 118);
            this.tbsrchSKU.MaxLength = 15;
            this.tbsrchSKU.Name = "tbsrchSKU";
            this.tbsrchSKU.Size = new System.Drawing.Size(100, 20);
            this.tbsrchSKU.TabIndex = 52;
            this.tbsrchSKU.TextChanged += new System.EventHandler(this.setupDrillDownSearch);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(225, 122);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(32, 13);
            this.label34.TabIndex = 48;
            this.label34.Text = "SKU:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(16, 35);
            this.label33.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(30, 13);
            this.label33.TabIndex = 45;
            this.label33.Text = "Title:";
            // 
            // bCopy2Clipboard
            // 
            this.bCopy2Clipboard.BackColor = System.Drawing.SystemColors.Desktop;
            this.bCopy2Clipboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bCopy2Clipboard.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bCopy2Clipboard.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bCopy2Clipboard.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bCopy2Clipboard.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bCopy2Clipboard.Location = new System.Drawing.Point(240, 21);
            this.bCopy2Clipboard.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.bCopy2Clipboard.Name = "bCopy2Clipboard";
            this.bCopy2Clipboard.Size = new System.Drawing.Size(103, 28);
            this.bCopy2Clipboard.TabIndex = 165;
            this.bCopy2Clipboard.Text = "Copy to Clipboard";
            this.toolTip1.SetToolTip(this.bCopy2Clipboard, "Print contents of Database Panel");
            this.bCopy2Clipboard.UseVisualStyleBackColor = false;
            this.bCopy2Clipboard.Click += new System.EventHandler(this.bCopy2Clipboard_Click);
            // 
            // rbImportAZ
            // 
            this.rbImportAZ.AutoSize = true;
            this.rbImportAZ.Location = new System.Drawing.Point(15, 72);
            this.rbImportAZ.Name = "rbImportAZ";
            this.rbImportAZ.Size = new System.Drawing.Size(293, 17);
            this.rbImportAZ.TabIndex = 44;
            this.rbImportAZ.Text = "Tab-delimited created by Amazon export (and sample file)";
            this.toolTip1.SetToolTip(this.rbImportAZ, "NOTE: Comma-delimited is not the same as tab-delimited!");
            // 
            // rbTabDelimited
            // 
            this.rbTabDelimited.AutoSize = true;
            this.rbTabDelimited.Enabled = false;
            this.rbTabDelimited.Location = new System.Drawing.Point(15, 47);
            this.rbTabDelimited.Name = "rbTabDelimited";
            this.rbTabDelimited.Size = new System.Drawing.Size(120, 17);
            this.rbTabDelimited.TabIndex = 64;
            this.rbTabDelimited.Text = "Tab-delimited format";
            this.toolTip1.SetToolTip(this.rbTabDelimited, "NOTE: Comma-delimited is not the same as tab-delimited!");
            // 
            // cbAutoPricingLookup
            // 
            this.cbAutoPricingLookup.AutoSize = true;
            this.cbAutoPricingLookup.Location = new System.Drawing.Point(20, 96);
            this.cbAutoPricingLookup.Name = "cbAutoPricingLookup";
            this.cbAutoPricingLookup.Size = new System.Drawing.Size(255, 17);
            this.cbAutoPricingLookup.TabIndex = 0;
            this.cbAutoPricingLookup.Text = "Automatically lookup prices when adding an item";
            this.toolTip1.SetToolTip(this.cbAutoPricingLookup, "Lookup book prices automatically when adding a book");
            this.cbAutoPricingLookup.UseVisualStyleBackColor = true;
            // 
            // cbBackupDB
            // 
            this.cbBackupDB.AutoSize = true;
            this.cbBackupDB.Checked = true;
            this.cbBackupDB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBackupDB.Enabled = false;
            this.cbBackupDB.Location = new System.Drawing.Point(17, 45);
            this.cbBackupDB.Name = "cbBackupDB";
            this.cbBackupDB.Size = new System.Drawing.Size(213, 17);
            this.cbBackupDB.TabIndex = 2;
            this.cbBackupDB.Text = "Backup database when exiting (default)";
            this.toolTip1.SetToolTip(this.cbBackupDB, "Backup the database before exiting the program");
            this.cbBackupDB.UseVisualStyleBackColor = true;
            // 
            // cbAllowAddUpdate
            // 
            this.cbAllowAddUpdate.AutoSize = true;
            this.cbAllowAddUpdate.Location = new System.Drawing.Point(17, 50);
            this.cbAllowAddUpdate.Name = "cbAllowAddUpdate";
            this.cbAllowAddUpdate.Size = new System.Drawing.Size(323, 17);
            this.cbAllowAddUpdate.TabIndex = 20;
            this.cbAllowAddUpdate.Text = "Allow add/update with missing required fields (use with caution)";
            this.toolTip1.SetToolTip(this.cbAllowAddUpdate, "Allows books to be added or updated when required fields are missing");
            this.cbAllowAddUpdate.UseVisualStyleBackColor = true;
            this.cbAllowAddUpdate.Click += new System.EventHandler(this.cbAllowAddUpdate_Click);
            // 
            // cbVerifyDeletes
            // 
            this.cbVerifyDeletes.AutoSize = true;
            this.cbVerifyDeletes.Location = new System.Drawing.Point(17, 27);
            this.cbVerifyDeletes.Name = "cbVerifyDeletes";
            this.cbVerifyDeletes.Size = new System.Drawing.Size(91, 17);
            this.cbVerifyDeletes.TabIndex = 1;
            this.cbVerifyDeletes.Text = "Verify Deletes";
            this.toolTip1.SetToolTip(this.cbVerifyDeletes, "Ask for verification before deleting a book");
            this.cbVerifyDeletes.UseVisualStyleBackColor = true;
            // 
            // lCost
            // 
            this.lCost.AutoSize = true;
            this.lCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCost.Location = new System.Drawing.Point(247, 97);
            this.lCost.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.lCost.Name = "lCost";
            this.lCost.Size = new System.Drawing.Size(35, 13);
            this.lCost.TabIndex = 233;
            this.lCost.Text = "Cost *";
            this.toolTip1.SetToolTip(this.lCost, "Click for stickey effect");
            this.lCost.Click += new System.EventHandler(this.lCost_Click);
            // 
            // bClearShoppingCart
            // 
            this.bClearShoppingCart.BackColor = System.Drawing.SystemColors.Desktop;
            this.bClearShoppingCart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClearShoppingCart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bClearShoppingCart.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bClearShoppingCart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bClearShoppingCart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bClearShoppingCart.Location = new System.Drawing.Point(698, 35);
            this.bClearShoppingCart.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.bClearShoppingCart.Name = "bClearShoppingCart";
            this.bClearShoppingCart.Size = new System.Drawing.Size(89, 39);
            this.bClearShoppingCart.TabIndex = 31;
            this.bClearShoppingCart.Text = "Clear Shopping Cart";
            this.toolTip1.SetToolTip(this.bClearShoppingCart, "Clear Shopping Cart");
            this.bClearShoppingCart.UseVisualStyleBackColor = false;
            this.bClearShoppingCart.Click += new System.EventHandler(this.bClearShoppingCart_Click);
            // 
            // bInvReport
            // 
            this.bInvReport.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.bInvReport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bInvReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bInvReport.Location = new System.Drawing.Point(709, 140);
            this.bInvReport.Name = "bInvReport";
            this.bInvReport.Size = new System.Drawing.Size(83, 28);
            this.bInvReport.TabIndex = 2;
            this.bInvReport.Text = "Create";
            this.toolTip1.SetToolTip(this.bInvReport, "This creates a report of ONLY those records that are in the database panel above." +
        "");
            this.bInvReport.UseVisualStyleBackColor = true;
            this.bInvReport.Click += new System.EventHandler(this.bPrintInvReport_Click);
            // 
            // bConvertToUPC13
            // 
            this.bConvertToUPC13.BackColor = System.Drawing.SystemColors.Desktop;
            this.bConvertToUPC13.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.bConvertToUPC13.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bConvertToUPC13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bConvertToUPC13.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bConvertToUPC13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bConvertToUPC13.Location = new System.Drawing.Point(63, 32);
            this.bConvertToUPC13.Name = "bConvertToUPC13";
            this.bConvertToUPC13.Size = new System.Drawing.Size(127, 27);
            this.bConvertToUPC13.TabIndex = 49;
            this.bConvertToUPC13.Text = "Convert to UPC-13";
            this.toolTip1.SetToolTip(this.bConvertToUPC13, "Convert all of the 10-digit UPCs to 13-digit UPCs ");
            this.bConvertToUPC13.UseVisualStyleBackColor = false;
            // 
            // lbChangePricesCat
            // 
            this.lbChangePricesCat.Enabled = false;
            this.lbChangePricesCat.FormattingEnabled = true;
            this.lbChangePricesCat.Location = new System.Drawing.Point(87, 101);
            this.lbChangePricesCat.Name = "lbChangePricesCat";
            this.lbChangePricesCat.Size = new System.Drawing.Size(224, 17);
            this.lbChangePricesCat.TabIndex = 42;
            this.toolTip1.SetToolTip(this.lbChangePricesCat, "Select a Catalog entry");
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(17, 66);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(120, 17);
            this.radioButton11.TabIndex = 64;
            this.radioButton11.Text = "Tab-delimited format";
            this.toolTip1.SetToolTip(this.radioButton11, "NOTE: Comma-delimited is not the same as tab-delimited!");
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.Location = new System.Drawing.Point(17, 87);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(140, 17);
            this.radioButton14.TabIndex = 44;
            this.radioButton14.Text = "Created by Amazon.com";
            this.toolTip1.SetToolTip(this.radioButton14, "NOTE: Comma-delimited is not the same as tab-delimited!");
            // 
            // label185
            // 
            this.label185.AutoSize = true;
            this.label185.Location = new System.Drawing.Point(507, 207);
            this.label185.Name = "label185";
            this.label185.Size = new System.Drawing.Size(52, 13);
            this.label185.TabIndex = 82;
            this.label185.Text = "--> Status";
            this.toolTip1.SetToolTip(this.label185, "i.e. For Sale, Sold, etc.");
            this.label185.Visible = false;
            // 
            // tbMapStatus
            // 
            this.tbMapStatus.AllowDrop = true;
            this.tbMapStatus.Location = new System.Drawing.Point(395, 204);
            this.tbMapStatus.MaxLength = 25;
            this.tbMapStatus.Name = "tbMapStatus";
            this.tbMapStatus.Size = new System.Drawing.Size(105, 20);
            this.tbMapStatus.TabIndex = 81;
            this.toolTip1.SetToolTip(this.tbMapStatus, "Drag and drop from list of names above.");
            this.tbMapStatus.Visible = false;
            this.tbMapStatus.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMapStatus_DragDrop);
            this.tbMapStatus.DragEnter += new System.Windows.Forms.DragEventHandler(this.mappingDragEnter);
            // 
            // label213
            // 
            this.label213.AutoSize = true;
            this.label213.Location = new System.Drawing.Point(158, 321);
            this.label213.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label213.Name = "label213";
            this.label213.Size = new System.Drawing.Size(83, 13);
            this.label213.TabIndex = 246;
            this.label213.Text = "Marketplace ID:";
            this.toolTip1.SetToolTip(this.label213, "See Help file for instructions on how to obtain this.");
            // 
            // tbMarketplaceID
            // 
            this.tbMarketplaceID.Location = new System.Drawing.Point(247, 318);
            this.tbMarketplaceID.Margin = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.tbMarketplaceID.MaxLength = 1024;
            this.tbMarketplaceID.Name = "tbMarketplaceID";
            this.tbMarketplaceID.Size = new System.Drawing.Size(138, 20);
            this.tbMarketplaceID.TabIndex = 245;
            this.toolTip1.SetToolTip(this.tbMarketplaceID, "You must request this key from Amazon.com (see Help file)");
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(402, 138);
            this.label41.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(62, 13);
            this.label41.TabIndex = 243;
            this.label41.Text = "Secret Key:";
            this.toolTip1.SetToolTip(this.label41, "See Help file for instructions on how to obtain this.");
            // 
            // tbAWSSecretKey
            // 
            this.tbAWSSecretKey.Location = new System.Drawing.Point(469, 135);
            this.tbAWSSecretKey.Margin = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.tbAWSSecretKey.MaxLength = 1024;
            this.tbAWSSecretKey.Name = "tbAWSSecretKey";
            this.tbAWSSecretKey.Size = new System.Drawing.Size(281, 20);
            this.tbAWSSecretKey.TabIndex = 242;
            this.toolTip1.SetToolTip(this.tbAWSSecretKey, "You must request this key from Amazon.com (see Help file)");
            // 
            // bGetAccessKey
            // 
            this.bGetAccessKey.BackColor = System.Drawing.SystemColors.Desktop;
            this.bGetAccessKey.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bGetAccessKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bGetAccessKey.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bGetAccessKey.Location = new System.Drawing.Point(21, 132);
            this.bGetAccessKey.Name = "bGetAccessKey";
            this.bGetAccessKey.Size = new System.Drawing.Size(101, 25);
            this.bGetAccessKey.TabIndex = 241;
            this.bGetAccessKey.Text = "Get AWS Keys";
            this.toolTip1.SetToolTip(this.bGetAccessKey, "Click to get your own Amazon Access Key");
            this.bGetAccessKey.UseVisualStyleBackColor = false;
            this.bGetAccessKey.Click += new System.EventHandler(this.bGetAmazonKeys_Click);
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(167, 138);
            this.label87.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(66, 13);
            this.label87.TabIndex = 240;
            this.label87.Text = "Access Key:";
            this.toolTip1.SetToolTip(this.label87, "See Help file for instructions on how to obtain this.");
            // 
            // tbAWSKey
            // 
            this.tbAWSKey.Location = new System.Drawing.Point(235, 135);
            this.tbAWSKey.Margin = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.tbAWSKey.MaxLength = 1024;
            this.tbAWSKey.Name = "tbAWSKey";
            this.tbAWSKey.Size = new System.Drawing.Size(154, 20);
            this.tbAWSKey.TabIndex = 239;
            this.toolTip1.SetToolTip(this.tbAWSKey, "You must request this key from Amazon.com  (see Help file)");
            // 
            // rbExportSelected
            // 
            this.rbExportSelected.AutoSize = true;
            this.rbExportSelected.Location = new System.Drawing.Point(16, 117);
            this.rbExportSelected.Name = "rbExportSelected";
            this.rbExportSelected.Size = new System.Drawing.Size(555, 17);
            this.rbExportSelected.TabIndex = 43;
            this.rbExportSelected.Text = "Only those selected in the Database Panel by doing multiple selections (hold SHIF" +
    "T or CTRL key while selecting)";
            this.toolTip1.SetToolTip(this.rbExportSelected, "Click this BEFORE selecting books from Database Panel");
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MMMM dd, yyyy     hh:mm:ss tt";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(125, 84);
            this.dateTimePicker1.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(233, 20);
            this.dateTimePicker1.TabIndex = 31;
            this.toolTip1.SetToolTip(this.dateTimePicker1, "Click on Month, day, etc. to set date to other than date last exported (will show" +
        " today\'s date if you have not exported yet)");
            this.dateTimePicker1.Value = new System.DateTime(2007, 12, 1, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cbPurgeReplace
            // 
            this.cbPurgeReplace.AutoSize = true;
            this.cbPurgeReplace.Location = new System.Drawing.Point(390, 27);
            this.cbPurgeReplace.Name = "cbPurgeReplace";
            this.cbPurgeReplace.Size = new System.Drawing.Size(105, 17);
            this.cbPurgeReplace.TabIndex = 40;
            this.cbPurgeReplace.Text = "Purge/Replace?";
            this.toolTip1.SetToolTip(this.cbPurgeReplace, "Automatic purge/replace is only for:");
            this.cbPurgeReplace.CheckedChanged += new System.EventHandler(this.cbPurgeReplace_CheckedChanged);
            // 
            // tbBusinessAddr
            // 
            this.tbBusinessAddr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBusinessAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusinessAddr.Location = new System.Drawing.Point(2, 49);
            this.tbBusinessAddr.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbBusinessAddr.MaxLength = 64;
            this.tbBusinessAddr.Multiline = true;
            this.tbBusinessAddr.Name = "tbBusinessAddr";
            this.tbBusinessAddr.Size = new System.Drawing.Size(234, 34);
            this.tbBusinessAddr.TabIndex = 122;
            this.tbBusinessAddr.Text = "Logo goes above; place your address here.  Maximum of 64 characters on two lines." +
    "";
            this.toolTip1.SetToolTip(this.tbBusinessAddr, "To make changes to logo and address, click on \"Changer logo...\" bottom right corn" +
        "er.");
            // 
            // lbShipTo
            // 
            this.lbShipTo.ContextMenuStrip = this.contextMenuStrip1;
            this.lbShipTo.FormattingEnabled = true;
            this.lbShipTo.Location = new System.Drawing.Point(322, 145);
            this.lbShipTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.lbShipTo.Name = "lbShipTo";
            this.lbShipTo.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbShipTo.Size = new System.Drawing.Size(271, 56);
            this.lbShipTo.TabIndex = 93;
            this.toolTip1.SetToolTip(this.lbShipTo, "Enter the Customer\'s ship to information here.  Right click with mouse to copy to" +
        " clipboard.");
            this.lbShipTo.Click += new System.EventHandler(this.lbShipTo_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCopy});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 26);
            // 
            // miCopy
            // 
            this.miCopy.Name = "miCopy";
            this.miCopy.Size = new System.Drawing.Size(171, 22);
            this.miCopy.Text = "&Copy to Clipboard";
            // 
            // lbSoldTo
            // 
            this.lbSoldTo.FormattingEnabled = true;
            this.lbSoldTo.Location = new System.Drawing.Point(27, 145);
            this.lbSoldTo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.lbSoldTo.Name = "lbSoldTo";
            this.lbSoldTo.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbSoldTo.Size = new System.Drawing.Size(271, 56);
            this.lbSoldTo.TabIndex = 92;
            this.toolTip1.SetToolTip(this.lbSoldTo, "If you click on this box, you will be taken to the Customer Info tab, where you c" +
        "an select a customer and populate this and the Ship To information.");
            this.lbSoldTo.Click += new System.EventHandler(this.lbSoldTo_Click);
            // 
            // bDecrement
            // 
            this.bDecrement.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bDecrement.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.bDecrement.FlatAppearance.BorderSize = 2;
            this.bDecrement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bDecrement.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bDecrement.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDecrement.Image = ((System.Drawing.Image)(resources.GetObject("bDecrement.Image")));
            this.bDecrement.Location = new System.Drawing.Point(580, 54);
            this.bDecrement.Name = "bDecrement";
            this.bDecrement.Size = new System.Drawing.Size(25, 25);
            this.bDecrement.TabIndex = 266;
            this.bDecrement.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.bDecrement, "Decrement book count");
            this.bDecrement.UseVisualStyleBackColor = false;
            this.bDecrement.Click += new System.EventHandler(this.bDecrement_Click);
            // 
            // bIncrement
            // 
            this.bIncrement.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bIncrement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bIncrement.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.bIncrement.FlatAppearance.BorderSize = 2;
            this.bIncrement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bIncrement.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bIncrement.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bIncrement.Image = ((System.Drawing.Image)(resources.GetObject("bIncrement.Image")));
            this.bIncrement.Location = new System.Drawing.Point(548, 54);
            this.bIncrement.Name = "bIncrement";
            this.bIncrement.Size = new System.Drawing.Size(25, 25);
            this.bIncrement.TabIndex = 265;
            this.bIncrement.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.bIncrement, "Increment book count");
            this.bIncrement.UseVisualStyleBackColor = false;
            this.bIncrement.Click += new System.EventHandler(this.bIncrement_Click);
            // 
            // label215
            // 
            this.label215.AutoSize = true;
            this.label215.Location = new System.Drawing.Point(246, 24);
            this.label215.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label215.Name = "label215";
            this.label215.Size = new System.Drawing.Size(142, 13);
            this.label215.TabIndex = 315;
            this.label215.Text = "Developer Account Number:";
            this.toolTip1.SetToolTip(this.label215, "See Help file for instructions on how to obtain this.");
            // 
            // tbDevKey
            // 
            this.tbDevKey.Enabled = false;
            this.tbDevKey.Location = new System.Drawing.Point(397, 21);
            this.tbDevKey.Margin = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.tbDevKey.MaxLength = 1024;
            this.tbDevKey.Name = "tbDevKey";
            this.tbDevKey.ReadOnly = true;
            this.tbDevKey.Size = new System.Drawing.Size(90, 20);
            this.tbDevKey.TabIndex = 316;
            this.tbDevKey.Text = "1145-8140-6600";
            this.toolTip1.SetToolTip(this.tbDevKey, "You must request this key from Amazon.com (see Help file)");
            // 
            // tbMerchantID
            // 
            this.tbMerchantID.Location = new System.Drawing.Point(476, 318);
            this.tbMerchantID.Margin = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.tbMerchantID.MaxLength = 1024;
            this.tbMerchantID.Name = "tbMerchantID";
            this.tbMerchantID.Size = new System.Drawing.Size(138, 20);
            this.tbMerchantID.TabIndex = 319;
            this.toolTip1.SetToolTip(this.tbMerchantID, "You must request this key from Amazon.com (see Help file)");
            // 
            // bGetMWSKeys
            // 
            this.bGetMWSKeys.BackColor = System.Drawing.SystemColors.Desktop;
            this.bGetMWSKeys.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bGetMWSKeys.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bGetMWSKeys.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bGetMWSKeys.Location = new System.Drawing.Point(21, 315);
            this.bGetMWSKeys.Name = "bGetMWSKeys";
            this.bGetMWSKeys.Size = new System.Drawing.Size(101, 25);
            this.bGetMWSKeys.TabIndex = 310;
            this.bGetMWSKeys.Text = "Get MWS Keys";
            this.toolTip1.SetToolTip(this.bGetMWSKeys, "Click to get your own Amazon Access Key");
            this.bGetMWSKeys.UseVisualStyleBackColor = false;
            this.bGetMWSKeys.Click += new System.EventHandler(this.bGetMWSKeys_Click);
            // 
            // label209
            // 
            this.label209.AutoSize = true;
            this.label209.Location = new System.Drawing.Point(167, 182);
            this.label209.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label209.Name = "label209";
            this.label209.Size = new System.Drawing.Size(78, 13);
            this.label209.TabIndex = 322;
            this.label209.Text = "Associate Tag:";
            this.toolTip1.SetToolTip(this.label209, "See Help file for instructions on how to obtain this.");
            // 
            // tbAZAssocTag
            // 
            this.tbAZAssocTag.Location = new System.Drawing.Point(256, 179);
            this.tbAZAssocTag.Margin = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.tbAZAssocTag.MaxLength = 1024;
            this.tbAZAssocTag.Name = "tbAZAssocTag";
            this.tbAZAssocTag.Size = new System.Drawing.Size(138, 20);
            this.tbAZAssocTag.TabIndex = 321;
            this.toolTip1.SetToolTip(this.tbAZAssocTag, "You must request this key from Amazon.com (see Help file)");
            // 
            // label218
            // 
            this.label218.AutoSize = true;
            this.label218.Location = new System.Drawing.Point(22, 160);
            this.label218.Name = "label218";
            this.label218.Size = new System.Drawing.Size(0, 13);
            this.label218.TabIndex = 323;
            this.toolTip1.SetToolTip(this.label218, "AWS Keys are used for getting prices from Amazon.");
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(228, 48);
            this.label21.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 13);
            this.label21.TabIndex = 350;
            this.label21.Text = "Audio Encoding";
            this.toolTip1.SetToolTip(this.label21, "Click for stickey effect");
            // 
            // coAudioEncoding
            // 
            this.coAudioEncoding.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.coAudioEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coAudioEncoding.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.coAudioEncoding.FormattingEnabled = true;
            this.coAudioEncoding.Items.AddRange(new object[] {
            "dts_6.1_es",
            "dts_es",
            "surround",
            "dolby_surround",
            "unknown_audio_encoding",
            "dts_5.1",
            "dolby_digital_1.0",
            "dolby_digital_2.0",
            "dolby_digital_2.0_mono",
            "dolby_digital_2.0_stereo",
            "dolby_digital_2.0_surround",
            "dolby_digital_3.0",
            "dolby_digital_4.0",
            "dolby_digital_4.1",
            "dolby_digital_5.0",
            "dolby_digital_5.1",
            "mpeg_1_2.0",
            "mpeg_2_5.1",
            "pcm",
            "pcm_mono",
            "pcm_stereo",
            "pcm_surround",
            "pcm_24bit_96khz",
            "thx_surround_ex",
            "mono",
            "analog",
            "dolby_digital_2.1",
            "dolby_digital_6.1_ex",
            "stereo",
            "digital_atrac",
            "dolby_digital_5.1_es",
            "dolby_digital_6.1_es",
            "dts_6.1",
            "dolby_digital_5.1_ex",
            "quadraphonic",
            "dolby_digital_live",
            "dolby_truehd",
            "dolby_digital_plus",
            "dolby_digital_ex",
            "dts_interactive",
            "dts_hd_high_res_audio",
            "mlp_lossless",
            "dolby_stereo_analog",
            "dts_5.0",
            "dolby_truehd_5_1",
            "dolby_digital_plus_2_0",
            "dolby_digital_plus_5_1",
            "hi_res_96_24_digital_surround",
            "dts_6_1_es",
            "5_1_disney_enhanced_home_theater_mix",
            "7_1_disney_enhanced_home_theater_mix"});
            this.coAudioEncoding.Location = new System.Drawing.Point(316, 45);
            this.coAudioEncoding.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.coAudioEncoding.MaxLength = 25;
            this.coAudioEncoding.Name = "coAudioEncoding";
            this.coAudioEncoding.Size = new System.Drawing.Size(228, 21);
            this.coAudioEncoding.TabIndex = 349;
            this.toolTip1.SetToolTip(this.coAudioEncoding, "Enter data or select from drop-down list");
            // 
            // coVideoFormat
            // 
            this.coVideoFormat.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.coVideoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coVideoFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.coVideoFormat.FormattingEnabled = true;
            this.coVideoFormat.Items.AddRange(new object[] {
            "",
            "ac-3",
            "dolby",
            "thx",
            "pal",
            "ntsc",
            "bw",
            "color",
            "subtitled",
            "dubbed",
            "closed-captioned",
            "import",
            "remastered",
            "widescreen",
            "hi-fidelity",
            "collectors_edition",
            "silent",
            "directors_cut",
            "full_screen",
            "anamorphic",
            "surround",
            "dts_stereo",
            "dvd_video",
            "vhs",
            "vhs_c",
            "hybrid_sacd",
            "digital_sound",
            "deluxe_edition",
            "special_extended_version",
            "special_limited_edition",
            "mono",
            "dual_disc",
            "value_price",
            "multisystem",
            "hd_dvd",
            "blu_ray"});
            this.coVideoFormat.Location = new System.Drawing.Point(83, 44);
            this.coVideoFormat.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.coVideoFormat.MaxLength = 15;
            this.coVideoFormat.Name = "coVideoFormat";
            this.coVideoFormat.Size = new System.Drawing.Size(131, 21);
            this.coVideoFormat.TabIndex = 344;
            this.toolTip1.SetToolTip(this.coVideoFormat, "Enter data or select from drop-down list");
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label114.Location = new System.Drawing.Point(5, 48);
            this.label114.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(72, 13);
            this.label114.TabIndex = 343;
            this.label114.Text = "Video Format:";
            this.toolTip1.SetToolTip(this.label114, "Click for stickey effect");
            // 
            // lMediaType
            // 
            this.lMediaType.AutoSize = true;
            this.lMediaType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMediaType.Location = new System.Drawing.Point(17, 159);
            this.lMediaType.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.lMediaType.Name = "lMediaType";
            this.lMediaType.Size = new System.Drawing.Size(73, 13);
            this.lMediaType.TabIndex = 340;
            this.lMediaType.Text = "Media Type: *";
            this.toolTip1.SetToolTip(this.lMediaType, "Click for stickey effect");
            // 
            // coMPAA
            // 
            this.coMPAA.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.coMPAA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coMPAA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.coMPAA.FormattingEnabled = true;
            this.coMPAA.Items.AddRange(new object[] {
            "G",
            "NC-17",
            "PG",
            "PG-13 ",
            "NR ",
            "UNRATED",
            "R ",
            "X"});
            this.coMPAA.Location = new System.Drawing.Point(511, 14);
            this.coMPAA.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.coMPAA.MaxLength = 25;
            this.coMPAA.Name = "coMPAA";
            this.coMPAA.Size = new System.Drawing.Size(74, 21);
            this.coMPAA.TabIndex = 345;
            this.toolTip1.SetToolTip(this.coMPAA, "Enter data or select from drop-down list");
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label109.Location = new System.Drawing.Point(433, 17);
            this.label109.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(74, 13);
            this.label109.TabIndex = 346;
            this.label109.Text = "MPAA Rating:";
            this.toolTip1.SetToolTip(this.label109, "Click for stickey effect");
            // 
            // tbItemNote
            // 
            this.tbItemNote.Location = new System.Drawing.Point(91, 234);
            this.tbItemNote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.tbItemNote.MaxLength = 100;
            this.tbItemNote.Name = "tbItemNote";
            this.tbItemNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbItemNote.Size = new System.Drawing.Size(508, 20);
            this.tbItemNote.TabIndex = 13;
            this.toolTip1.SetToolTip(this.tbItemNote, "Describe any differences your item has from a new item.");
            this.tbItemNote.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(19, 235);
            this.label31.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(56, 13);
            this.label31.TabIndex = 237;
            this.label31.Text = "Item Note:";
            this.toolTip1.SetToolTip(this.label31, "Describe any differences your item has from a new item.");
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button4.Location = new System.Drawing.Point(294, 274);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 26);
            this.button4.TabIndex = 240;
            this.button4.Text = "Select Catalog";
            this.toolTip1.SetToolTip(this.button4, "Select item from catalog entries");
            this.button4.UseVisualStyleBackColor = false;
            // 
            // comboBox7
            // 
            this.comboBox7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.comboBox7.Location = new System.Drawing.Point(443, 155);
            this.comboBox7.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.comboBox7.MaxLength = 15;
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(43, 21);
            this.comboBox7.TabIndex = 343;
            this.toolTip1.SetToolTip(this.comboBox7, "Enter data or select from drop-down list");
            // 
            // coMediaType
            // 
            this.coMediaType.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.coMediaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coMediaType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.coMediaType.FormattingEnabled = true;
            this.coMediaType.Items.AddRange(new object[] {
            "",
            "LP Record",
            "Audio CD",
            "Cassette",
            "DVD Audio",
            "DVD",
            "HD DVD",
            "BLU RAY",
            "Video Disk",
            "DVD I",
            "DVD R",
            "UMD",
            "Video CD",
            "Mini Disk",
            "Laser Disc",
            "VH STAPE",
            "VIDEO TAPE"});
            this.coMediaType.Location = new System.Drawing.Point(96, 156);
            this.coMediaType.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.coMediaType.MaxDropDownItems = 10;
            this.coMediaType.MaxLength = 25;
            this.coMediaType.Name = "coMediaType";
            this.coMediaType.Size = new System.Drawing.Size(121, 21);
            this.coMediaType.TabIndex = 7;
            this.toolTip1.SetToolTip(this.coMediaType, "Enter data or select from drop-down list");
            this.coMediaType.SelectedIndexChanged += new System.EventHandler(this.coMediaType_SelectedIndexChanged);
            // 
            // coLanguage
            // 
            this.coLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coLanguage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.coLanguage.FormattingEnabled = true;
            this.coLanguage.Items.AddRange(new object[] {
            "English",
            "Abkhazian",
            "Adygei",
            "Afar",
            "Afrikaans",
            "Albanian",
            "Alsatian",
            "Amharic",
            "Arabic",
            "Aramaic",
            "Armenian",
            "Assamese",
            "Aymara",
            "Azerbaijani",
            "Bambara",
            "Bashkir",
            "Basque",
            "Bengali",
            "Berber",
            "Bhutani",
            "Bihari",
            "Bislama",
            "Breton",
            "Bulgarian",
            "Burmese",
            "Buryat",
            "Byelorussian",
            "CantoneseChinese",
            "Castillian",
            "Catalan",
            "Cayuga",
            "Cheyenne",
            "Chinese",
            "ClassicalNewari",
            "Cornish",
            "Corsican",
            "Creole",
            "CrimeanTatar",
            "Croatian",
            "Czech",
            "Danish",
            "Dargwa",
            "Dutch",
            "",
            "Esperanto",
            "Estonian",
            "Faroese",
            "Farsi",
            "Fiji",
            "Filipino",
            "Finnish",
            "Flemish",
            "French",
            "FrenchCanadian",
            "Frisian",
            "Galician",
            "Georgian",
            "German",
            "Gibberish",
            "Greek",
            "Greenlandic",
            "Guarani",
            "Gujarati",
            "Gullah",
            "Hausa",
            "Hawaiian",
            "Hebrew",
            "Hindi",
            "Hmong",
            "Hungarian",
            "Icelandic",
            "IndoEuropean",
            "Indonesian",
            "Ingush",
            "Interlingua",
            "Interlingue",
            "Inuktitun",
            "Inuktitut",
            "Inupiak",
            "Inupiaq",
            "Irish",
            "Italian",
            "Japanese",
            "Javanese",
            "Kalaallisut",
            "Kalmyk",
            "Kannada",
            "KarachayBalkar",
            "Kashmiri",
            "Kashubian",
            "Kazakh",
            "Khmer",
            "Kinyarwanda",
            "Kirghiz",
            "Kirundi",
            "Klingon",
            "Korean",
            "Kurdish",
            "Ladino",
            "Lao",
            "Lapp",
            "Latin",
            "Latvian",
            "Lingala",
            "Lithuanian",
            "Lojban",
            "LowerSorbian",
            "Macedonian",
            "Malagasy",
            "Malay",
            "Malayalam",
            "Maltese",
            "MandarinChinese",
            "Maori",
            "Marathi",
            "Mende",
            "MiddleEnglish",
            "Mirandese",
            "Moksha",
            "Moldavian",
            "Mongo",
            "Mongolian",
            "Multilingual",
            "Nauru",
            "Navaho",
            "Nepali",
            "Nogai",
            "Norwegian",
            "Occitan",
            "OldEnglish",
            "Oriya",
            "Oromo",
            "Pashto",
            "Persian",
            "PigLatin",
            "Polish",
            "Portuguese",
            "Punjabi",
            "Quechua",
            "Romance",
            "Romanian",
            "Romany",
            "Russian",
            "Samaritan",
            "Samoan",
            "Sangho",
            "Sanskrit",
            "Serbian",
            "Serbo-Croatian",
            "Sesotho",
            "Setswana",
            "Shona",
            "SichuanYi",
            "Sicilian",
            "SignLanguage",
            "Sindhi",
            "Sinhalese",
            "Siswati",
            "Slavic",
            "Slovak",
            "Slovakian",
            "Slovene",
            "Somali",
            "Spanish",
            "Sumerian",
            "Sundanese",
            "Swahili",
            "Swedish",
            "SwissGerman",
            "Syriac",
            "Tagalog",
            "TaiwaneseChinese",
            "Tajik",
            "Tamil",
            "Tatar",
            "Telugu",
            "Thai",
            "Tibetan",
            "Tigrinya",
            "Tonga",
            "Tsonga",
            "Turkish",
            "Turkmen",
            "Twi",
            "Udmurt",
            "Uighur",
            "Ukrainian",
            "Ukranian",
            "Unknown",
            "Urdu",
            "Uzbek",
            "Vietnamese",
            "Volapuk",
            "Welsh",
            "Wolof",
            "Xhosa",
            "Yiddish",
            "Yoruba",
            "Zhuang",
            "Zulu"});
            this.coLanguage.Location = new System.Drawing.Point(670, 282);
            this.coLanguage.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.coLanguage.MaxLength = 15;
            this.coLanguage.Name = "coLanguage";
            this.coLanguage.Size = new System.Drawing.Size(100, 21);
            this.coLanguage.TabIndex = 355;
            this.toolTip1.SetToolTip(this.coLanguage, "Enter data or select from drop-down list");
            // 
            // coAudioFormat
            // 
            this.coAudioFormat.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.coAudioFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coAudioFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.coAudioFormat.FormattingEnabled = true;
            this.coAudioFormat.Items.AddRange(new object[] {
            "authorized_bootleg",
            "bsides",
            "best_of",
            "box_set",
            "original_recording",
            "reissued",
            "remastered",
            "soundtrack",
            "special_edition",
            "special_limited_edition",
            "cast_recording",
            "compilation",
            "deluxe_edition",
            "digital_sound",
            "double_lp",
            "explicit_lyrics",
            "hi-fidelity",
            "import",
            "limited_collectors_edition",
            "limited_edition",
            "remixes",
            "live",
            "extra_tracks",
            "cutout"});
            this.coAudioFormat.Location = new System.Drawing.Point(702, 13);
            this.coAudioFormat.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.coAudioFormat.MaxLength = 15;
            this.coAudioFormat.Name = "coAudioFormat";
            this.coAudioFormat.Size = new System.Drawing.Size(87, 21);
            this.coAudioFormat.TabIndex = 351;
            this.toolTip1.SetToolTip(this.coAudioFormat, "Enter data or select from drop-down list");
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(651, 17);
            this.label40.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(42, 13);
            this.label40.TabIndex = 350;
            this.label40.Text = "Format:";
            this.toolTip1.SetToolTip(this.label40, "Click for stickey effect");
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(91, 185);
            this.tbDesc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.tbDesc.MaxLength = 500;
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDesc.Size = new System.Drawing.Size(508, 39);
            this.tbDesc.TabIndex = 11;
            this.toolTip1.SetToolTip(this.tbDesc, "Description of the product itself  (not your specific offering).");
            this.tbDesc.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 188);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 359;
            this.label13.Text = "Description:";
            this.toolTip1.SetToolTip(this.label13, "Description of the product itself  (not your specific offering).");
            // 
            // coSubTitles
            // 
            this.coSubTitles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coSubTitles.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.coSubTitles.FormattingEnabled = true;
            this.coSubTitles.Items.AddRange(new object[] {
            "",
            "English",
            "Abkhazian",
            "Adygei",
            "Afar",
            "Afrikaans",
            "Albanian",
            "Alsatian",
            "Amharic",
            "Arabic",
            "Aramaic",
            "Armenian",
            "Assamese",
            "Aymara",
            "Azerbaijani",
            "Bambara",
            "Bashkir",
            "Basque",
            "Bengali",
            "Berber",
            "Bhutani",
            "Bihari",
            "Bislama",
            "Breton",
            "Bulgarian",
            "Burmese",
            "Buryat",
            "Byelorussian",
            "CantoneseChinese",
            "Castillian",
            "Catalan",
            "Cayuga",
            "Cheyenne",
            "Chinese",
            "ClassicalNewari",
            "Cornish",
            "Corsican",
            "Creole",
            "CrimeanTatar",
            "Croatian",
            "Czech",
            "Danish",
            "Dargwa",
            "Dutch",
            "Esperanto",
            "Estonian",
            "Faroese",
            "Farsi",
            "Fiji",
            "Filipino",
            "Finnish",
            "Flemish",
            "French",
            "FrenchCanadian",
            "Frisian",
            "Galician",
            "Georgian",
            "German",
            "Gibberish",
            "Greek",
            "Greenlandic",
            "Guarani",
            "Gujarati",
            "Gullah",
            "Hausa",
            "Hawaiian",
            "Hebrew",
            "Hindi",
            "Hmong",
            "Hungarian",
            "Icelandic",
            "IndoEuropean",
            "Indonesian",
            "Ingush",
            "Interlingua",
            "Interlingue",
            "Inuktitun",
            "Inuktitut",
            "Inupiak",
            "Inupiaq",
            "Irish",
            "Italian",
            "Japanese",
            "Javanese",
            "Kalaallisut",
            "Kalmyk",
            "Kannada",
            "KarachayBalkar",
            "Kashmiri",
            "Kashubian",
            "Kazakh",
            "Khmer",
            "Kinyarwanda",
            "Kirghiz",
            "Kirundi",
            "Klingon",
            "Korean",
            "Kurdish",
            "Ladino",
            "Lao",
            "Lapp",
            "Latin",
            "Latvian",
            "Lingala",
            "Lithuanian",
            "Lojban",
            "LowerSorbian",
            "Macedonian",
            "Malagasy",
            "Malay",
            "Malayalam",
            "Maltese",
            "MandarinChinese",
            "Maori",
            "Marathi",
            "Mende",
            "MiddleEnglish",
            "Mirandese",
            "Moksha",
            "Moldavian",
            "Mongo",
            "Mongolian",
            "Multilingual",
            "Nauru",
            "Navaho",
            "Nepali",
            "Nogai",
            "Norwegian",
            "Occitan",
            "OldEnglish",
            "Oriya",
            "Oromo",
            "Pashto",
            "Persian",
            "PigLatin",
            "Polish",
            "Portuguese",
            "Punjabi",
            "Quechua",
            "Romance",
            "Romanian",
            "Romany",
            "Russian",
            "Samaritan",
            "Samoan",
            "Sangho",
            "Sanskrit",
            "Serbian",
            "Serbo-Croatian",
            "Sesotho",
            "Setswana",
            "Shona",
            "SichuanYi",
            "Sicilian",
            "SignLanguage",
            "Sindhi",
            "Sinhalese",
            "Siswati",
            "Slavic",
            "Slovak",
            "Slovakian",
            "Slovene",
            "Somali",
            "Spanish",
            "Sumerian",
            "Sundanese",
            "Swahili",
            "Swedish",
            "SwissGerman",
            "Syriac",
            "Tagalog",
            "TaiwaneseChinese",
            "Tajik",
            "Tamil",
            "Tatar",
            "Telugu",
            "Thai",
            "Tibetan",
            "Tigrinya",
            "Tonga",
            "Tsonga",
            "Turkish",
            "Turkmen",
            "Twi",
            "Udmurt",
            "Uighur",
            "Ukrainian",
            "Ukranian",
            "Unknown",
            "Urdu",
            "Uzbek",
            "Vietnamese",
            "Volapuk",
            "Welsh",
            "Wolof",
            "Xhosa",
            "Yiddish",
            "Yoruba",
            "Zhuang",
            "Zulu"});
            this.coSubTitles.Location = new System.Drawing.Point(664, 15);
            this.coSubTitles.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.coSubTitles.MaxLength = 15;
            this.coSubTitles.Name = "coSubTitles";
            this.coSubTitles.Size = new System.Drawing.Size(129, 21);
            this.coSubTitles.TabIndex = 356;
            this.toolTip1.SetToolTip(this.coSubTitles, "Enter data or select from drop-down list");
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(602, 19);
            this.label43.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(57, 13);
            this.label43.TabIndex = 355;
            this.label43.Text = "Sub-Titles:";
            this.toolTip1.SetToolTip(this.label43, "Click for stickey effect");
            // 
            // coOrigin
            // 
            this.coOrigin.BackColor = System.Drawing.SystemColors.Window;
            this.coOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coOrigin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.coOrigin.FormattingEnabled = true;
            this.coOrigin.Location = new System.Drawing.Point(399, 282);
            this.coOrigin.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.coOrigin.MaxLength = 50;
            this.coOrigin.Name = "coOrigin";
            this.coOrigin.Size = new System.Drawing.Size(181, 21);
            this.coOrigin.TabIndex = 16;
            this.toolTip1.SetToolTip(this.coOrigin, "Enter data or select from drop-down list");
            this.coOrigin.SelectedIndexChanged += new System.EventHandler(this.coOrigin_SelectedIndexChanged);
            // 
            // mtbASIN
            // 
            this.mtbASIN.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.mtbASIN.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mtbASIN.Location = new System.Drawing.Point(318, 59);
            this.mtbASIN.Mask = "AAAAAAAAAAAAA";
            this.mtbASIN.Name = "mtbASIN";
            this.mtbASIN.PromptChar = ' ';
            this.mtbASIN.Size = new System.Drawing.Size(92, 20);
            this.mtbASIN.TabIndex = 1;
            this.toolTip1.SetToolTip(this.mtbASIN, "Enter 12 digit UPC or 13 digit EAN");
            this.mtbASIN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mtbASIN_MouseClick);
            this.mtbASIN.TextChanged += new System.EventHandler(this.mtbASIN_TextChanged);
            this.mtbASIN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mtbASIN_MouseDown);
            // 
            // bGetHalfToken
            // 
            this.bGetHalfToken.BackColor = System.Drawing.SystemColors.Desktop;
            this.bGetHalfToken.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bGetHalfToken.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bGetHalfToken.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bGetHalfToken.Location = new System.Drawing.Point(21, 432);
            this.bGetHalfToken.Name = "bGetHalfToken";
            this.bGetHalfToken.Size = new System.Drawing.Size(133, 25);
            this.bGetHalfToken.TabIndex = 334;
            this.bGetHalfToken.Text = "Get Half.com Token";
            this.toolTip1.SetToolTip(this.bGetHalfToken, "Click to get your own Amazon Access Key");
            this.bGetHalfToken.UseVisualStyleBackColor = false;
            this.bGetHalfToken.Click += new System.EventHandler(this.bGetHalfToken_Click);
            // 
            // tbHalfToken
            // 
            this.tbHalfToken.Location = new System.Drawing.Point(270, 435);
            this.tbHalfToken.Margin = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.tbHalfToken.MaxLength = 1024;
            this.tbHalfToken.Name = "tbHalfToken";
            this.tbHalfToken.Size = new System.Drawing.Size(393, 20);
            this.tbHalfToken.TabIndex = 335;
            this.toolTip1.SetToolTip(this.tbHalfToken, "You must request this key from Amazon.com (see Help file)");
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(174, 438);
            this.label22.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(86, 13);
            this.label22.TabIndex = 336;
            this.label22.Text = "Half.com Token:";
            this.toolTip1.SetToolTip(this.label22, "See Help file for instructions on how to obtain this.");
            // 
            // bSubscribeFileEx
            // 
            this.bSubscribeFileEx.BackColor = System.Drawing.SystemColors.Desktop;
            this.bSubscribeFileEx.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bSubscribeFileEx.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bSubscribeFileEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSubscribeFileEx.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bSubscribeFileEx.Location = new System.Drawing.Point(21, 475);
            this.bSubscribeFileEx.Name = "bSubscribeFileEx";
            this.bSubscribeFileEx.Size = new System.Drawing.Size(153, 25);
            this.bSubscribeFileEx.TabIndex = 339;
            this.bSubscribeFileEx.Text = "Subscribe to File Exchange";
            this.toolTip1.SetToolTip(this.bSubscribeFileEx, "Click to get your own Half.com Token");
            this.bSubscribeFileEx.UseVisualStyleBackColor = false;
            this.bSubscribeFileEx.Visible = false;
            this.bSubscribeFileEx.Click += new System.EventHandler(this.bSubscribeFileEx_Click);
            // 
            // cbEdition
            // 
            this.cbEdition.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.cbEdition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEdition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbEdition.FormattingEnabled = true;
            this.cbEdition.Items.AddRange(new object[] {
            "Collector\'s Edition",
            "Director\'s Cut"});
            this.cbEdition.Location = new System.Drawing.Point(673, 234);
            this.cbEdition.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.cbEdition.MaxLength = 25;
            this.cbEdition.Name = "cbEdition";
            this.cbEdition.Size = new System.Drawing.Size(157, 21);
            this.cbEdition.TabIndex = 14;
            this.toolTip1.SetToolTip(this.cbEdition, "Enter data or select from drop-down list");
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label199.Location = new System.Drawing.Point(625, 238);
            this.label199.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(42, 13);
            this.label199.TabIndex = 363;
            this.label199.Text = "Edition:";
            this.toolTip1.SetToolTip(this.label199, "Click for stickey effect");
            // 
            // cbDVDRegion
            // 
            this.cbDVDRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDVDRegion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbDVDRegion.FormattingEnabled = true;
            this.cbDVDRegion.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "All"});
            this.cbDVDRegion.Location = new System.Drawing.Point(649, 45);
            this.cbDVDRegion.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.cbDVDRegion.MaxLength = 15;
            this.cbDVDRegion.Name = "cbDVDRegion";
            this.cbDVDRegion.Size = new System.Drawing.Size(129, 21);
            this.cbDVDRegion.TabIndex = 365;
            this.toolTip1.SetToolTip(this.cbDVDRegion, "Enter data or select from drop-down list");
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label200.Location = new System.Drawing.Point(569, 49);
            this.label200.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(70, 13);
            this.label200.TabIndex = 364;
            this.label200.Text = "DVD Region:";
            this.toolTip1.SetToolTip(this.label200, "Click for stickey effect");
            // 
            // tbSKUSuffix
            // 
            this.tbSKUSuffix.Location = new System.Drawing.Point(319, 19);
            this.tbSKUSuffix.MaxLength = 1;
            this.tbSKUSuffix.Name = "tbSKUSuffix";
            this.tbSKUSuffix.Size = new System.Drawing.Size(21, 20);
            this.tbSKUSuffix.TabIndex = 10;
            this.toolTip1.SetToolTip(this.tbSKUSuffix, "Characters to append to SKU");
            this.tbSKUSuffix.Visible = false;
            // 
            // tbSKUPrefix
            // 
            this.tbSKUPrefix.Location = new System.Drawing.Point(332, 50);
            this.tbSKUPrefix.MaxLength = 1;
            this.tbSKUPrefix.Name = "tbSKUPrefix";
            this.tbSKUPrefix.Size = new System.Drawing.Size(21, 20);
            this.tbSKUPrefix.TabIndex = 8;
            this.toolTip1.SetToolTip(this.tbSKUPrefix, "Characters to prepend to SKU");
            // 
            // tbStartingSKU
            // 
            this.tbStartingSKU.Location = new System.Drawing.Point(131, 50);
            this.tbStartingSKU.Name = "tbStartingSKU";
            this.tbStartingSKU.Size = new System.Drawing.Size(77, 20);
            this.tbStartingSKU.TabIndex = 6;
            this.toolTip1.SetToolTip(this.tbStartingSKU, "Starting SKU (can have alpha)");
            // 
            // cbAutomaticSKU
            // 
            this.cbAutomaticSKU.AutoSize = true;
            this.cbAutomaticSKU.Location = new System.Drawing.Point(17, 24);
            this.cbAutomaticSKU.Name = "cbAutomaticSKU";
            this.cbAutomaticSKU.Size = new System.Drawing.Size(220, 17);
            this.cbAutomaticSKU.TabIndex = 4;
            this.cbAutomaticSKU.Text = "Automatic SKU numbering (Numeric only)";
            this.toolTip1.SetToolTip(this.cbAutomaticSKU, "SKU must be numeric ");
            this.cbAutomaticSKU.UseVisualStyleBackColor = true;
            // 
            // searchTab
            // 
            this.searchTab.BackColor = System.Drawing.SystemColors.Window;
            this.searchTab.Controls.Add(this.panel10);
            this.searchTab.Controls.Add(this.panel9);
            this.searchTab.Controls.Add(this.resetDBPanel);
            this.searchTab.Controls.Add(this.groupBox13);
            this.searchTab.Controls.Add(this.button2);
            this.searchTab.Controls.Add(this.button1);
            this.searchTab.Controls.Add(this.gbSS);
            this.searchTab.Controls.Add(this.groupBox10);
            this.searchTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTab.Location = new System.Drawing.Point(4, 44);
            this.searchTab.Name = "searchTab";
            this.searchTab.Padding = new System.Windows.Forms.Padding(3);
            this.searchTab.Size = new System.Drawing.Size(865, 550);
            this.searchTab.TabIndex = 1;
            this.searchTab.Text = "Search";
            this.searchTab.ToolTipText = "Different ways to search your inventory";
            this.searchTab.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel10.Location = new System.Drawing.Point(15, 303);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(814, 2);
            this.panel10.TabIndex = 312;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel9.Location = new System.Drawing.Point(15, 101);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(814, 2);
            this.panel9.TabIndex = 312;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Firebrick;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(19, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 172;
            this.button2.Text = "throw ex2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(19, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 171;
            this.button1.Text = "throw ex1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbSS
            // 
            this.gbSS.BackColor = System.Drawing.SystemColors.Window;
            this.gbSS.Controls.Add(this.bClearIncSearch);
            this.gbSS.Controls.Add(this.cbSSColumn4);
            this.gbSS.Controls.Add(this.lbSSCompare4);
            this.gbSS.Controls.Add(this.tbSSCompareTo4);
            this.gbSS.Controls.Add(this.lbSSAndOr4);
            this.gbSS.Controls.Add(this.cbSSColumn3);
            this.gbSS.Controls.Add(this.lbSSCompare3);
            this.gbSS.Controls.Add(this.tbSSCompareTo3);
            this.gbSS.Controls.Add(this.lbSSAndOr3);
            this.gbSS.Controls.Add(this.cbSSColumn2);
            this.gbSS.Controls.Add(this.cbSSColumn1);
            this.gbSS.Controls.Add(this.cbFreezeDBPanel);
            this.gbSS.Controls.Add(this.lItemsReturned);
            this.gbSS.Controls.Add(this.lbSSCompare2);
            this.gbSS.Controls.Add(this.tbSSCompareTo2);
            this.gbSS.Controls.Add(this.lbSSAndOr2);
            this.gbSS.Controls.Add(this.lbSSCompare1);
            this.gbSS.Controls.Add(this.bSSearch);
            this.gbSS.Controls.Add(this.tbSSCompareTo1);
            this.gbSS.Controls.Add(this.label19);
            this.gbSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSS.Location = new System.Drawing.Point(15, 320);
            this.gbSS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.gbSS.Name = "gbSS";
            this.gbSS.Size = new System.Drawing.Size(783, 210);
            this.gbSS.TabIndex = 58;
            this.gbSS.TabStop = false;
            this.gbSS.Text = "Inclusive Search (wildcard may also be used)";
            // 
            // cbSSColumn4
            // 
            this.cbSSColumn4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSSColumn4.FormattingEnabled = true;
            this.cbSSColumn4.Items.AddRange(new object[] {
            "Adult Content",
            "Artist",
            "ASIN",
            "Audio Encoding",
            "Audio Format",
            "Audio Keywords",
            "Catalog ID",
            "Composer",
            "Condition",
            "Conductor",
            "Cost",
            "Date Added",
            "Date Updated",
            "Description",
            "Do Not Reprice",
            "Image URL",
            "Invoice Nbr",
            "Language",
            "Location",
            "Manufacturer",
            "Media Type",
            "MPAA Rating",
            "Nbr Of Disks",
            "Notes",
            "Orchestra",
            "Origin",
            "Price",
            "Private Notes",
            "Product Type",
            "Quantity",
            "Runtime",
            "Shipping",
            "SKU",
            "Status",
            "Sub-Titles",
            "Title",
            "UPC",
            "Video Format",
            "Video Keywords",
            "Vinyl Details",
            "Year Published"});
            this.cbSSColumn4.Location = new System.Drawing.Point(67, 165);
            this.cbSSColumn4.Name = "cbSSColumn4";
            this.cbSSColumn4.Size = new System.Drawing.Size(147, 21);
            this.cbSSColumn4.Sorted = true;
            this.cbSSColumn4.TabIndex = 175;
            // 
            // cbSSColumn3
            // 
            this.cbSSColumn3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSSColumn3.FormattingEnabled = true;
            this.cbSSColumn3.Items.AddRange(new object[] {
            "Adult Content",
            "Artist",
            "ASIN",
            "Audio Encoding",
            "Audio Format",
            "Audio Keywords",
            "Catalog ID",
            "Composer",
            "Condition",
            "Conductor",
            "Cost",
            "Date Added",
            "Date Updated",
            "Description",
            "Do Not Reprice",
            "Image URL",
            "Invoice Nbr",
            "Language",
            "Location",
            "Manufacturer",
            "Media Type",
            "MPAA Rating",
            "Nbr Of Disks",
            "Notes",
            "Orchestra",
            "Origin",
            "Price",
            "Private Notes",
            "Product Type",
            "Quantity",
            "Runtime",
            "Shipping",
            "SKU",
            "Status",
            "Sub-Titles",
            "Title",
            "UPC",
            "Video Format",
            "Video Keywords",
            "Vinyl Details",
            "Year Published"});
            this.cbSSColumn3.Location = new System.Drawing.Point(67, 119);
            this.cbSSColumn3.Name = "cbSSColumn3";
            this.cbSSColumn3.Size = new System.Drawing.Size(147, 21);
            this.cbSSColumn3.Sorted = true;
            this.cbSSColumn3.TabIndex = 171;
            // 
            // cbSSColumn2
            // 
            this.cbSSColumn2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSSColumn2.FormattingEnabled = true;
            this.cbSSColumn2.Items.AddRange(new object[] {
            "Adult Content",
            "Artist",
            "ASIN",
            "Audio Encoding",
            "Audio Format",
            "Audio Keywords",
            "Catalog ID",
            "Composer",
            "Condition",
            "Conductor",
            "Cost",
            "Date Added",
            "Date Updated",
            "Description",
            "Do Not Reprice",
            "Image URL",
            "Invoice Nbr",
            "Language",
            "Location",
            "Manufacturer",
            "Media Type",
            "MPAA Rating",
            "Nbr Of Disks",
            "Notes",
            "Orchestra",
            "Origin",
            "Price",
            "Private Notes",
            "Product Type",
            "Quantity",
            "Runtime",
            "Shipping",
            "SKU",
            "Status",
            "Sub-Titles",
            "Title",
            "UPC",
            "Video Format",
            "Video Keywords",
            "Vinyl Details",
            "Year Published"});
            this.cbSSColumn2.Location = new System.Drawing.Point(67, 73);
            this.cbSSColumn2.Name = "cbSSColumn2";
            this.cbSSColumn2.Size = new System.Drawing.Size(147, 21);
            this.cbSSColumn2.Sorted = true;
            this.cbSSColumn2.TabIndex = 167;
            // 
            // cbSSColumn1
            // 
            this.cbSSColumn1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSSColumn1.FormattingEnabled = true;
            this.cbSSColumn1.Items.AddRange(new object[] {
            "Adult Content",
            "Artist",
            "ASIN",
            "Audio Encoding",
            "Audio Format",
            "Audio Keywords",
            "Catalog ID",
            "Composer",
            "Condition",
            "Conductor",
            "Cost",
            "Date Added",
            "Date Updated",
            "Description",
            "Do Not Reprice",
            "Image URL",
            "Invoice Nbr",
            "Language",
            "Location",
            "Manufacturer",
            "Media Type",
            "MPAA Rating",
            "Nbr Of Disks",
            "Notes",
            "Orchestra",
            "Origin",
            "Price",
            "Private Notes",
            "Product Type",
            "Quantity",
            "Runtime",
            "Shipping",
            "SKU",
            "Status",
            "Sub-Titles",
            "Title",
            "UPC",
            "Video Format",
            "Video Keywords",
            "Vinyl Details",
            "Year Published"});
            this.cbSSColumn1.Location = new System.Drawing.Point(67, 27);
            this.cbSSColumn1.Name = "cbSSColumn1";
            this.cbSSColumn1.Size = new System.Drawing.Size(147, 21);
            this.cbSSColumn1.Sorted = true;
            this.cbSSColumn1.TabIndex = 166;
            // 
            // lItemsReturned
            // 
            this.lItemsReturned.AutoSize = true;
            this.lItemsReturned.Location = new System.Drawing.Point(675, 106);
            this.lItemsReturned.Name = "lItemsReturned";
            this.lItemsReturned.Size = new System.Drawing.Size(73, 13);
            this.lItemsReturned.TabIndex = 19;
            this.lItemsReturned.Text = "0 items found.";
            // 
            // bSSearch
            // 
            this.bSSearch.BackColor = System.Drawing.SystemColors.Desktop;
            this.bSSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bSSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bSSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bSSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bSSearch.Location = new System.Drawing.Point(591, 98);
            this.bSSearch.Name = "bSSearch";
            this.bSSearch.Size = new System.Drawing.Size(62, 28);
            this.bSSearch.TabIndex = 12;
            this.bSSearch.Text = "Search";
            this.bSSearch.UseVisualStyleBackColor = false;
            this.bSSearch.Click += new System.EventHandler(this.bSSearch_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(16, 29);
            this.label19.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 15);
            this.label19.TabIndex = 1;
            this.label19.Text = "where";
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox10.Controls.Add(this.bCopy2Clipboard);
            this.groupBox10.Controls.Add(this.bPrintPreviewLV);
            this.groupBox10.Controls.Add(this.bPrintListView);
            this.groupBox10.Location = new System.Drawing.Point(197, 22);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(360, 61);
            this.groupBox10.TabIndex = 170;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Print/Copy contents of Database Panel above";
            // 
            // lbStatus
            // 
            this.lbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lbStatus.FormattingEnabled = true;
            this.lbStatus.HorizontalScrollbar = true;
            this.lbStatus.Location = new System.Drawing.Point(5, 88);
            this.lbStatus.Margin = new System.Windows.Forms.Padding(0, 1, 3, 3);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.ScrollAlwaysVisible = true;
            this.lbStatus.Size = new System.Drawing.Size(728, 446);
            this.lbStatus.TabIndex = 24;
            this.lbStatus.TabStop = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            // 
            // invoiceTab
            // 
            this.invoiceTab.BackColor = System.Drawing.SystemColors.Window;
            this.invoiceTab.Controls.Add(this.tabControl4);
            this.invoiceTab.Location = new System.Drawing.Point(4, 44);
            this.invoiceTab.Name = "invoiceTab";
            this.invoiceTab.Size = new System.Drawing.Size(865, 550);
            this.invoiceTab.TabIndex = 12;
            this.invoiceTab.Text = "Invoices ";
            this.invoiceTab.ToolTipText = "Displays information from the Invoice database";
            this.invoiceTab.UseVisualStyleBackColor = true;
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabInvoice);
            this.tabControl4.Controls.Add(this.tabReceipt);
            this.tabControl4.Location = new System.Drawing.Point(8, 4);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(837, 540);
            this.tabControl4.TabIndex = 160;
            // 
            // tabInvoice
            // 
            this.tabInvoice.BackColor = System.Drawing.SystemColors.Window;
            this.tabInvoice.Controls.Add(this.gbInvoice);
            this.tabInvoice.Controls.Add(this.bChangeLogo);
            this.tabInvoice.Controls.Add(this.lvInvoiceList);
            this.tabInvoice.Controls.Add(this.groupBox36);
            this.tabInvoice.Controls.Add(this.groupBox35);
            this.tabInvoice.Location = new System.Drawing.Point(4, 22);
            this.tabInvoice.Name = "tabInvoice";
            this.tabInvoice.Padding = new System.Windows.Forms.Padding(3);
            this.tabInvoice.Size = new System.Drawing.Size(829, 514);
            this.tabInvoice.TabIndex = 0;
            this.tabInvoice.Text = "Invoice";
            this.tabInvoice.UseVisualStyleBackColor = true;
            // 
            // gbInvoice
            // 
            this.gbInvoice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gbInvoice.BackgroundImage")));
            this.gbInvoice.Controls.Add(this.cbPayOther);
            this.gbInvoice.Controls.Add(this.cbPayPP);
            this.gbInvoice.Controls.Add(this.cbPayDC);
            this.gbInvoice.Controls.Add(this.cbPayCC);
            this.gbInvoice.Controls.Add(this.cbPayCheque);
            this.gbInvoice.Controls.Add(this.cbPayCash);
            this.gbInvoice.Controls.Add(this.cbPayAmazon);
            this.gbInvoice.Controls.Add(this.tbPayment);
            this.gbInvoice.Controls.Add(this.label174);
            this.gbInvoice.Controls.Add(this.tbComm);
            this.gbInvoice.Controls.Add(this.tbAdj);
            this.gbInvoice.Controls.Add(this.label112);
            this.gbInvoice.Controls.Add(this.label111);
            this.gbInvoice.Controls.Add(this.tbBusinessAddr);
            this.gbInvoice.Controls.Add(this.pInvoiceLogo);
            this.gbInvoice.Controls.Add(this.dateTimePicker2);
            this.gbInvoice.Controls.Add(this.tbInvoiceDate);
            this.gbInvoice.Controls.Add(this.label73);
            this.gbInvoice.Controls.Add(this.tbInvoiceTtl);
            this.gbInvoice.Controls.Add(this.tbShipping);
            this.gbInvoice.Controls.Add(this.tbTaxVAT);
            this.gbInvoice.Controls.Add(this.tbDiscount);
            this.gbInvoice.Controls.Add(this.label74);
            this.gbInvoice.Controls.Add(this.label75);
            this.gbInvoice.Controls.Add(this.label76);
            this.gbInvoice.Controls.Add(this.label78);
            this.gbInvoice.Controls.Add(this.lOrderTotal);
            this.gbInvoice.Controls.Add(this.tbOrderTotal);
            this.gbInvoice.Controls.Add(this.label79);
            this.gbInvoice.Controls.Add(this.lvShoppingCart);
            this.gbInvoice.Controls.Add(this.tbSoldBy);
            this.gbInvoice.Controls.Add(this.label80);
            this.gbInvoice.Controls.Add(this.label81);
            this.gbInvoice.Controls.Add(this.label82);
            this.gbInvoice.Controls.Add(this.lbShipTo);
            this.gbInvoice.Controls.Add(this.lbSoldTo);
            this.gbInvoice.Controls.Add(this.tbInvoiceNbr);
            this.gbInvoice.Controls.Add(this.label83);
            this.gbInvoice.Controls.Add(this.label84);
            this.gbInvoice.Location = new System.Drawing.Point(6, 94);
            this.gbInvoice.Margin = new System.Windows.Forms.Padding(0, 3, 1, 3);
            this.gbInvoice.Name = "gbInvoice";
            this.gbInvoice.Size = new System.Drawing.Size(614, 414);
            this.gbInvoice.TabIndex = 139;
            this.gbInvoice.TabStop = false;
            // 
            // cbPayOther
            // 
            this.cbPayOther.AutoSize = true;
            this.cbPayOther.Location = new System.Drawing.Point(537, 317);
            this.cbPayOther.Name = "cbPayOther";
            this.cbPayOther.Size = new System.Drawing.Size(52, 17);
            this.cbPayOther.TabIndex = 136;
            this.cbPayOther.Text = "Other";
            this.cbPayOther.UseVisualStyleBackColor = true;
            // 
            // cbPayPP
            // 
            this.cbPayPP.AutoSize = true;
            this.cbPayPP.Location = new System.Drawing.Point(474, 317);
            this.cbPayPP.Name = "cbPayPP";
            this.cbPayPP.Size = new System.Drawing.Size(59, 17);
            this.cbPayPP.TabIndex = 135;
            this.cbPayPP.Text = "PayPal";
            this.cbPayPP.UseVisualStyleBackColor = true;
            // 
            // cbPayDC
            // 
            this.cbPayDC.AutoSize = true;
            this.cbPayDC.Location = new System.Drawing.Point(394, 317);
            this.cbPayDC.Name = "cbPayDC";
            this.cbPayDC.Size = new System.Drawing.Size(76, 17);
            this.cbPayDC.TabIndex = 134;
            this.cbPayDC.Text = "Debit Card";
            this.cbPayDC.UseVisualStyleBackColor = true;
            // 
            // cbPayCC
            // 
            this.cbPayCC.AutoSize = true;
            this.cbPayCC.Location = new System.Drawing.Point(312, 317);
            this.cbPayCC.Name = "cbPayCC";
            this.cbPayCC.Size = new System.Drawing.Size(78, 17);
            this.cbPayCC.TabIndex = 133;
            this.cbPayCC.Text = "Credit Card";
            this.cbPayCC.UseVisualStyleBackColor = true;
            // 
            // cbPayCheque
            // 
            this.cbPayCheque.AutoSize = true;
            this.cbPayCheque.Location = new System.Drawing.Point(245, 317);
            this.cbPayCheque.Name = "cbPayCheque";
            this.cbPayCheque.Size = new System.Drawing.Size(63, 17);
            this.cbPayCheque.TabIndex = 132;
            this.cbPayCheque.Text = "Cheque";
            this.cbPayCheque.UseVisualStyleBackColor = true;
            // 
            // cbPayCash
            // 
            this.cbPayCash.AutoSize = true;
            this.cbPayCash.Location = new System.Drawing.Point(191, 317);
            this.cbPayCash.Name = "cbPayCash";
            this.cbPayCash.Size = new System.Drawing.Size(50, 17);
            this.cbPayCash.TabIndex = 131;
            this.cbPayCash.Text = "Cash";
            this.cbPayCash.UseVisualStyleBackColor = true;
            // 
            // cbPayAmazon
            // 
            this.cbPayAmazon.AutoSize = true;
            this.cbPayAmazon.Location = new System.Drawing.Point(123, 317);
            this.cbPayAmazon.Name = "cbPayAmazon";
            this.cbPayAmazon.Size = new System.Drawing.Size(64, 17);
            this.cbPayAmazon.TabIndex = 130;
            this.cbPayAmazon.Text = "Amazon";
            this.cbPayAmazon.UseVisualStyleBackColor = true;
            // 
            // tbPayment
            // 
            this.tbPayment.ForeColor = System.Drawing.Color.Black;
            this.tbPayment.Location = new System.Drawing.Point(334, 382);
            this.tbPayment.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.tbPayment.MaxLength = 6;
            this.tbPayment.Name = "tbPayment";
            this.tbPayment.Size = new System.Drawing.Size(55, 20);
            this.tbPayment.TabIndex = 128;
            this.tbPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            this.tbPayment.Leave += new System.EventHandler(this.invFieldsChanged);
            // 
            // label174
            // 
            this.label174.AutoSize = true;
            this.label174.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label174.Location = new System.Drawing.Point(282, 385);
            this.label174.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.label174.Name = "label174";
            this.label174.Size = new System.Drawing.Size(51, 13);
            this.label174.TabIndex = 127;
            this.label174.Text = "Payment:";
            // 
            // tbComm
            // 
            this.tbComm.ForeColor = System.Drawing.Color.Black;
            this.tbComm.Location = new System.Drawing.Point(219, 382);
            this.tbComm.MaxLength = 6;
            this.tbComm.Name = "tbComm";
            this.tbComm.Size = new System.Drawing.Size(55, 20);
            this.tbComm.TabIndex = 126;
            this.tbComm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            this.tbComm.Leave += new System.EventHandler(this.invFieldsChanged);
            // 
            // tbAdj
            // 
            this.tbAdj.ForeColor = System.Drawing.Color.Black;
            this.tbAdj.Location = new System.Drawing.Point(218, 352);
            this.tbAdj.MaxLength = 6;
            this.tbAdj.Name = "tbAdj";
            this.tbAdj.Size = new System.Drawing.Size(55, 20);
            this.tbAdj.TabIndex = 125;
            this.tbAdj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            this.tbAdj.Leave += new System.EventHandler(this.invFieldsChanged);
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label112.Location = new System.Drawing.Point(150, 385);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(65, 13);
            this.label112.TabIndex = 124;
            this.label112.Text = "Commission:";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label111.Location = new System.Drawing.Point(150, 355);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(64, 13);
            this.label111.TabIndex = 123;
            this.label111.Text = "Adjustments";
            // 
            // pInvoiceLogo
            // 
            this.pInvoiceLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pInvoiceLogo.Location = new System.Drawing.Point(0, 8);
            this.pInvoiceLogo.Name = "pInvoiceLogo";
            this.pInvoiceLogo.Size = new System.Drawing.Size(237, 41);
            this.pInvoiceLogo.TabIndex = 129;
            this.pInvoiceLogo.TabStop = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(398, 72);
            this.dateTimePicker2.MinDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(89, 20);
            this.dateTimePicker2.TabIndex = 117;
            this.dateTimePicker2.Value = new System.DateTime(2010, 2, 7, 7, 37, 31, 0);
            // 
            // tbInvoiceDate
            // 
            this.tbInvoiceDate.Location = new System.Drawing.Point(398, 72);
            this.tbInvoiceDate.MaxLength = 10;
            this.tbInvoiceDate.Name = "tbInvoiceDate";
            this.tbInvoiceDate.Size = new System.Drawing.Size(65, 20);
            this.tbInvoiceDate.TabIndex = 116;
            this.tbInvoiceDate.Visible = false;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.BackColor = System.Drawing.Color.White;
            this.label73.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.Location = new System.Drawing.Point(500, 20);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(96, 29);
            this.label73.TabIndex = 113;
            this.label73.Text = "Invoice";
            // 
            // tbInvoiceTtl
            // 
            this.tbInvoiceTtl.Location = new System.Drawing.Point(535, 382);
            this.tbInvoiceTtl.Margin = new System.Windows.Forms.Padding(1, 1, 3, 3);
            this.tbInvoiceTtl.MaxLength = 10;
            this.tbInvoiceTtl.Name = "tbInvoiceTtl";
            this.tbInvoiceTtl.ReadOnly = true;
            this.tbInvoiceTtl.Size = new System.Drawing.Size(55, 20);
            this.tbInvoiceTtl.TabIndex = 109;
            this.tbInvoiceTtl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbShipping
            // 
            this.tbShipping.ForeColor = System.Drawing.Color.Black;
            this.tbShipping.Location = new System.Drawing.Point(334, 352);
            this.tbShipping.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.tbShipping.MaxLength = 6;
            this.tbShipping.Name = "tbShipping";
            this.tbShipping.Size = new System.Drawing.Size(55, 20);
            this.tbShipping.TabIndex = 106;
            this.tbShipping.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbShipping.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            this.tbShipping.Leave += new System.EventHandler(this.invFieldsChanged);
            // 
            // tbTaxVAT
            // 
            this.tbTaxVAT.ForeColor = System.Drawing.Color.Black;
            this.tbTaxVAT.Location = new System.Drawing.Point(85, 382);
            this.tbTaxVAT.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.tbTaxVAT.MaxLength = 6;
            this.tbTaxVAT.Name = "tbTaxVAT";
            this.tbTaxVAT.Size = new System.Drawing.Size(55, 20);
            this.tbTaxVAT.TabIndex = 105;
            this.tbTaxVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTaxVAT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            this.tbTaxVAT.Leave += new System.EventHandler(this.invFieldsChanged);
            // 
            // tbDiscount
            // 
            this.tbDiscount.ForeColor = System.Drawing.Color.Black;
            this.tbDiscount.Location = new System.Drawing.Point(86, 352);
            this.tbDiscount.Margin = new System.Windows.Forms.Padding(1, 1, 3, 2);
            this.tbDiscount.MaxLength = 6;
            this.tbDiscount.Name = "tbDiscount";
            this.tbDiscount.Size = new System.Drawing.Size(55, 20);
            this.tbDiscount.TabIndex = 104;
            this.tbDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            this.tbDiscount.Leave += new System.EventHandler(this.invFieldsChanged);
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label74.Location = new System.Drawing.Point(452, 385);
            this.label74.Margin = new System.Windows.Forms.Padding(2, 3, 1, 3);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(72, 13);
            this.label74.TabIndex = 102;
            this.label74.Text = "Invoice Total:";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label75.Location = new System.Drawing.Point(282, 355);
            this.label75.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(51, 13);
            this.label75.TabIndex = 101;
            this.label75.Text = "Shipping:";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label76.Location = new System.Drawing.Point(31, 385);
            this.label76.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(54, 13);
            this.label76.TabIndex = 100;
            this.label76.Text = "Tax/VAT:";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label78.Location = new System.Drawing.Point(28, 355);
            this.label78.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(57, 13);
            this.label78.TabIndex = 98;
            this.label78.Text = "Discounts:";
            // 
            // lOrderTotal
            // 
            this.lOrderTotal.AutoSize = true;
            this.lOrderTotal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lOrderTotal.Location = new System.Drawing.Point(465, 355);
            this.lOrderTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.lOrderTotal.Name = "lOrderTotal";
            this.lOrderTotal.Size = new System.Drawing.Size(63, 13);
            this.lOrderTotal.TabIndex = 97;
            this.lOrderTotal.Text = "Order Total:";
            // 
            // tbOrderTotal
            // 
            this.tbOrderTotal.Location = new System.Drawing.Point(535, 352);
            this.tbOrderTotal.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.tbOrderTotal.MaxLength = 10;
            this.tbOrderTotal.Name = "tbOrderTotal";
            this.tbOrderTotal.ReadOnly = true;
            this.tbOrderTotal.Size = new System.Drawing.Size(55, 20);
            this.tbOrderTotal.TabIndex = 107;
            this.tbOrderTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbOrderTotal.Leave += new System.EventHandler(this.invFieldsChanged);
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label79.Location = new System.Drawing.Point(24, 318);
            this.label79.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(90, 13);
            this.label79.TabIndex = 110;
            this.label79.Text = "Payment Method:";
            // 
            // lvShoppingCart
            // 
            this.lvShoppingCart.Location = new System.Drawing.Point(28, 207);
            this.lvShoppingCart.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lvShoppingCart.Name = "lvShoppingCart";
            this.lvShoppingCart.Size = new System.Drawing.Size(565, 100);
            this.lvShoppingCart.TabIndex = 94;
            this.lvShoppingCart.UseCompatibleStateImageBehavior = false;
            // 
            // tbSoldBy
            // 
            this.tbSoldBy.Location = new System.Drawing.Point(445, 98);
            this.tbSoldBy.Margin = new System.Windows.Forms.Padding(1, 3, 3, 2);
            this.tbSoldBy.MaxLength = 20;
            this.tbSoldBy.Name = "tbSoldBy";
            this.tbSoldBy.Size = new System.Drawing.Size(145, 20);
            this.tbSoldBy.TabIndex = 96;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label80.Location = new System.Drawing.Point(393, 101);
            this.label80.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(45, 13);
            this.label80.TabIndex = 95;
            this.label80.Text = "Sold by:";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.BackColor = System.Drawing.Color.Gainsboro;
            this.label81.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label81.Location = new System.Drawing.Point(322, 128);
            this.label81.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label81.Name = "label81";
            this.label81.Padding = new System.Windows.Forms.Padding(0, 0, 220, 0);
            this.label81.Size = new System.Drawing.Size(272, 15);
            this.label81.TabIndex = 91;
            this.label81.Text = "Ship To  ";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.BackColor = System.Drawing.Color.Gainsboro;
            this.label82.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label82.Location = new System.Drawing.Point(27, 128);
            this.label82.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label82.Name = "label82";
            this.label82.Padding = new System.Windows.Forms.Padding(0, 0, 228, 0);
            this.label82.Size = new System.Drawing.Size(266, 15);
            this.label82.TabIndex = 90;
            this.label82.Text = "Bill To";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbInvoiceNbr
            // 
            this.tbInvoiceNbr.Location = new System.Drawing.Point(496, 72);
            this.tbInvoiceNbr.Margin = new System.Windows.Forms.Padding(1, 1, 3, 3);
            this.tbInvoiceNbr.MaxLength = 10;
            this.tbInvoiceNbr.Name = "tbInvoiceNbr";
            this.tbInvoiceNbr.Size = new System.Drawing.Size(94, 20);
            this.tbInvoiceNbr.TabIndex = 89;
            this.tbInvoiceNbr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbInvoiceNbr_KeyPress);
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label83.Location = new System.Drawing.Point(499, 56);
            this.label83.Margin = new System.Windows.Forms.Padding(3, 3, 2, 1);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(65, 13);
            this.label83.TabIndex = 87;
            this.label83.Text = "Invoice Nbr:";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label84.Location = new System.Drawing.Point(398, 56);
            this.label84.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(33, 13);
            this.label84.TabIndex = 86;
            this.label84.Text = "Date:";
            // 
            // lvInvoiceList
            // 
            this.lvInvoiceList.Location = new System.Drawing.Point(6, 4);
            this.lvInvoiceList.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lvInvoiceList.Name = "lvInvoiceList";
            this.lvInvoiceList.Size = new System.Drawing.Size(614, 82);
            this.lvInvoiceList.TabIndex = 147;
            this.lvInvoiceList.UseCompatibleStateImageBehavior = false;
            this.lvInvoiceList.SelectedIndexChanged += new System.EventHandler(this.lvInvoiceList_SelectedIndexChanged);
            // 
            // groupBox36
            // 
            this.groupBox36.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox36.Controls.Add(this.label101);
            this.groupBox36.Controls.Add(this.tbTaxPct);
            this.groupBox36.Controls.Add(this.bClearInvFields);
            this.groupBox36.Controls.Add(this.bPageSetup);
            this.groupBox36.Controls.Add(this.bPrintPreview);
            this.groupBox36.Controls.Add(this.bPrintInvoice);
            this.groupBox36.Controls.Add(this.bRemoveItem);
            this.groupBox36.Location = new System.Drawing.Point(684, 184);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Size = new System.Drawing.Size(139, 250);
            this.groupBox36.TabIndex = 159;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "Invoice";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(19, 24);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(62, 13);
            this.label101.TabIndex = 159;
            this.label101.Text = "Tax/VAT %";
            // 
            // groupBox35
            // 
            this.groupBox35.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox35.Controls.Add(this.lUpdateStatus);
            this.groupBox35.Controls.Add(this.bDeleteInvoice);
            this.groupBox35.Controls.Add(this.bUpdateInvoice);
            this.groupBox35.Controls.Add(this.bAddInvoice);
            this.groupBox35.Controls.Add(this.bInvSearch);
            this.groupBox35.Location = new System.Drawing.Point(684, 6);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(139, 162);
            this.groupBox35.TabIndex = 158;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "Database";
            // 
            // lUpdateStatus
            // 
            this.lUpdateStatus.AutoSize = true;
            this.lUpdateStatus.Location = new System.Drawing.Point(23, 162);
            this.lUpdateStatus.Name = "lUpdateStatus";
            this.lUpdateStatus.Size = new System.Drawing.Size(0, 13);
            this.lUpdateStatus.TabIndex = 154;
            this.lUpdateStatus.Visible = false;
            // 
            // tabReceipt
            // 
            this.tabReceipt.BackColor = System.Drawing.SystemColors.Window;
            this.tabReceipt.Controls.Add(this.lvReceipt);
            this.tabReceipt.Controls.Add(this.receiptPanel);
            this.tabReceipt.Controls.Add(this.tbStoreName);
            this.tabReceipt.Controls.Add(this.label188);
            this.tabReceipt.Controls.Add(this.label184);
            this.tabReceipt.Controls.Add(this.tbWidth);
            this.tabReceipt.Controls.Add(this.label183);
            this.tabReceipt.Location = new System.Drawing.Point(4, 22);
            this.tabReceipt.Name = "tabReceipt";
            this.tabReceipt.Padding = new System.Windows.Forms.Padding(3);
            this.tabReceipt.Size = new System.Drawing.Size(829, 514);
            this.tabReceipt.TabIndex = 1;
            this.tabReceipt.Text = "Receipt";
            this.tabReceipt.UseVisualStyleBackColor = true;
            // 
            // lvReceipt
            // 
            this.lvReceipt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTitle,
            this.chPrice});
            this.lvReceipt.Location = new System.Drawing.Point(189, 252);
            this.lvReceipt.Name = "lvReceipt";
            this.lvReceipt.Size = new System.Drawing.Size(214, 35);
            this.lvReceipt.TabIndex = 5;
            this.lvReceipt.UseCompatibleStateImageBehavior = false;
            // 
            // chTitle
            // 
            this.chTitle.Width = 30;
            // 
            // chPrice
            // 
            this.chPrice.Width = 6;
            // 
            // receiptPanel
            // 
            this.receiptPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.receiptPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.receiptPanel.Controls.Add(this.tbPurchase);
            this.receiptPanel.Controls.Add(this.lPmtMethod);
            this.receiptPanel.Controls.Add(this.lTotal);
            this.receiptPanel.Controls.Add(this.lTax);
            this.receiptPanel.Controls.Add(this.lDateTime);
            this.receiptPanel.Controls.Add(this.lStoreName);
            this.receiptPanel.Location = new System.Drawing.Point(465, 38);
            this.receiptPanel.Name = "receiptPanel";
            this.receiptPanel.Size = new System.Drawing.Size(253, 356);
            this.receiptPanel.TabIndex = 28;
            // 
            // tbPurchase
            // 
            this.tbPurchase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPurchase.Location = new System.Drawing.Point(28, 76);
            this.tbPurchase.MaxLength = 50;
            this.tbPurchase.Multiline = true;
            this.tbPurchase.Name = "tbPurchase";
            this.tbPurchase.Size = new System.Drawing.Size(200, 81);
            this.tbPurchase.TabIndex = 5;
            // 
            // lPmtMethod
            // 
            this.lPmtMethod.AutoSize = true;
            this.lPmtMethod.Location = new System.Drawing.Point(25, 321);
            this.lPmtMethod.Name = "lPmtMethod";
            this.lPmtMethod.Size = new System.Drawing.Size(90, 13);
            this.lPmtMethod.TabIndex = 4;
            this.lPmtMethod.Text = "Payment Method:";
            // 
            // lTotal
            // 
            this.lTotal.AutoSize = true;
            this.lTotal.Location = new System.Drawing.Point(25, 297);
            this.lTotal.Name = "lTotal";
            this.lTotal.Size = new System.Drawing.Size(31, 13);
            this.lTotal.TabIndex = 3;
            this.lTotal.Text = "Total";
            // 
            // lTax
            // 
            this.lTax.AutoSize = true;
            this.lTax.Location = new System.Drawing.Point(25, 273);
            this.lTax.Name = "lTax";
            this.lTax.Size = new System.Drawing.Size(25, 13);
            this.lTax.TabIndex = 2;
            this.lTax.Text = "Tax";
            // 
            // lDateTime
            // 
            this.lDateTime.AutoSize = true;
            this.lDateTime.Location = new System.Drawing.Point(25, 41);
            this.lDateTime.Name = "lDateTime";
            this.lDateTime.Size = new System.Drawing.Size(58, 13);
            this.lDateTime.TabIndex = 1;
            this.lDateTime.Text = "Date/Time";
            // 
            // lStoreName
            // 
            this.lStoreName.AutoSize = true;
            this.lStoreName.Location = new System.Drawing.Point(25, 12);
            this.lStoreName.Name = "lStoreName";
            this.lStoreName.Size = new System.Drawing.Size(63, 13);
            this.lStoreName.TabIndex = 0;
            this.lStoreName.Text = "Store Name";
            // 
            // tbStoreName
            // 
            this.tbStoreName.Location = new System.Drawing.Point(138, 94);
            this.tbStoreName.MaxLength = 50;
            this.tbStoreName.Name = "tbStoreName";
            this.tbStoreName.Size = new System.Drawing.Size(202, 20);
            this.tbStoreName.TabIndex = 27;
            // 
            // label188
            // 
            this.label188.AutoSize = true;
            this.label188.Location = new System.Drawing.Point(50, 96);
            this.label188.Name = "label188";
            this.label188.Size = new System.Drawing.Size(82, 13);
            this.label188.TabIndex = 26;
            this.label188.Text = "2.  Store name: ";
            // 
            // label184
            // 
            this.label184.AutoSize = true;
            this.label184.Location = new System.Drawing.Point(186, 69);
            this.label184.Name = "label184";
            this.label184.Size = new System.Drawing.Size(114, 13);
            this.label184.TabIndex = 17;
            this.label184.Text = "in inches (no decimals)";
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(148, 67);
            this.tbWidth.MaxLength = 4;
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(33, 20);
            this.tbWidth.TabIndex = 16;
            // 
            // label183
            // 
            this.label183.AutoSize = true;
            this.label183.Location = new System.Drawing.Point(50, 69);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(95, 13);
            this.label183.TabIndex = 15;
            this.label183.Text = "1.  Width of paper:";
            // 
            // customerInfoTab
            // 
            this.customerInfoTab.BackColor = System.Drawing.SystemColors.Window;
            this.customerInfoTab.Controls.Add(this.bClearShoppingCart);
            this.customerInfoTab.Controls.Add(this.groupBox11);
            this.customerInfoTab.Controls.Add(this.tbCustName);
            this.customerInfoTab.Controls.Add(this.tbCustID);
            this.customerInfoTab.Controls.Add(this.label56);
            this.customerInfoTab.Controls.Add(this.groupBox17);
            this.customerInfoTab.Controls.Add(this.groupBox19);
            this.customerInfoTab.Controls.Add(this.label71);
            this.customerInfoTab.Controls.Add(this.lvCustomerList);
            this.customerInfoTab.Controls.Add(this.groupBox37);
            this.customerInfoTab.Controls.Add(this.bXfer);
            this.customerInfoTab.Controls.Add(this.bClearCustInfo);
            this.customerInfoTab.Location = new System.Drawing.Point(4, 44);
            this.customerInfoTab.Name = "customerInfoTab";
            this.customerInfoTab.Size = new System.Drawing.Size(865, 550);
            this.customerInfoTab.TabIndex = 11;
            this.customerInfoTab.Text = "Customers ";
            this.customerInfoTab.ToolTipText = "Displays information from the Customer database";
            this.customerInfoTab.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox11.Controls.Add(this.tbCustGroup);
            this.groupBox11.Controls.Add(this.label4);
            this.groupBox11.Controls.Add(this.tbCustNotes);
            this.groupBox11.Controls.Add(this.tbCustContact);
            this.groupBox11.Controls.Add(this.tbCustEmail);
            this.groupBox11.Controls.Add(this.tbCustAltPhone);
            this.groupBox11.Controls.Add(this.tbCustPhone);
            this.groupBox11.Controls.Add(this.label47);
            this.groupBox11.Controls.Add(this.label52);
            this.groupBox11.Controls.Add(this.label53);
            this.groupBox11.Controls.Add(this.label54);
            this.groupBox11.Controls.Add(this.label55);
            this.groupBox11.Location = new System.Drawing.Point(27, 451);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(714, 84);
            this.groupBox11.TabIndex = 30;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Other";
            // 
            // tbCustGroup
            // 
            this.tbCustGroup.Location = new System.Drawing.Point(383, 18);
            this.tbCustGroup.Margin = new System.Windows.Forms.Padding(1, 0, 3, 3);
            this.tbCustGroup.MaxLength = 25;
            this.tbCustGroup.Name = "tbCustGroup";
            this.tbCustGroup.Size = new System.Drawing.Size(87, 20);
            this.tbCustGroup.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Group:";
            // 
            // tbCustNotes
            // 
            this.tbCustNotes.Location = new System.Drawing.Point(269, 50);
            this.tbCustNotes.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbCustNotes.MaxLength = 200;
            this.tbCustNotes.Multiline = true;
            this.tbCustNotes.Name = "tbCustNotes";
            this.tbCustNotes.Size = new System.Drawing.Size(431, 25);
            this.tbCustNotes.TabIndex = 22;
            // 
            // tbCustContact
            // 
            this.tbCustContact.Location = new System.Drawing.Point(75, 55);
            this.tbCustContact.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbCustContact.MaxLength = 50;
            this.tbCustContact.Name = "tbCustContact";
            this.tbCustContact.Size = new System.Drawing.Size(140, 20);
            this.tbCustContact.TabIndex = 21;
            // 
            // tbCustEmail
            // 
            this.tbCustEmail.Location = new System.Drawing.Point(530, 18);
            this.tbCustEmail.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbCustEmail.MaxLength = 25;
            this.tbCustEmail.Name = "tbCustEmail";
            this.tbCustEmail.Size = new System.Drawing.Size(158, 20);
            this.tbCustEmail.TabIndex = 20;
            // 
            // tbCustAltPhone
            // 
            this.tbCustAltPhone.Location = new System.Drawing.Point(232, 18);
            this.tbCustAltPhone.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbCustAltPhone.MaxLength = 15;
            this.tbCustAltPhone.Name = "tbCustAltPhone";
            this.tbCustAltPhone.Size = new System.Drawing.Size(90, 20);
            this.tbCustAltPhone.TabIndex = 18;
            // 
            // tbCustPhone
            // 
            this.tbCustPhone.Location = new System.Drawing.Point(68, 18);
            this.tbCustPhone.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbCustPhone.MaxLength = 15;
            this.tbCustPhone.Name = "tbCustPhone";
            this.tbCustPhone.Size = new System.Drawing.Size(90, 20);
            this.tbCustPhone.TabIndex = 17;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(225, 58);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(38, 13);
            this.label47.TabIndex = 4;
            this.label47.Text = "Notes:";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(22, 58);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(47, 13);
            this.label52.TabIndex = 3;
            this.label52.Text = "Contact:";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(490, 21);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(32, 13);
            this.label53.TabIndex = 2;
            this.label53.Text = "Email";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(172, 21);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(53, 13);
            this.label54.TabIndex = 1;
            this.label54.Text = "Alt.Phone";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(24, 21);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(38, 13);
            this.label55.TabIndex = 0;
            this.label55.Text = "Phone";
            // 
            // tbCustName
            // 
            this.tbCustName.Location = new System.Drawing.Point(124, 104);
            this.tbCustName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbCustName.MaxLength = 50;
            this.tbCustName.Name = "tbCustName";
            this.tbCustName.Size = new System.Drawing.Size(306, 20);
            this.tbCustName.TabIndex = 24;
            // 
            // tbCustID
            // 
            this.tbCustID.Location = new System.Drawing.Point(534, 104);
            this.tbCustID.MaxLength = 15;
            this.tbCustID.Name = "tbCustID";
            this.tbCustID.Size = new System.Drawing.Size(97, 20);
            this.tbCustID.TabIndex = 25;
            this.tbCustID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCustID_KeyPress);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(30, 107);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(85, 13);
            this.label56.TabIndex = 29;
            this.label56.Text = "Customer Name:";
            // 
            // groupBox17
            // 
            this.groupBox17.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox17.Controls.Add(this.cbSameAsBillingInfo);
            this.groupBox17.Controls.Add(this.tbShipCntry);
            this.groupBox17.Controls.Add(this.tbShipZip);
            this.groupBox17.Controls.Add(this.tbShipState);
            this.groupBox17.Controls.Add(this.tbShipCity);
            this.groupBox17.Controls.Add(this.tbShipAddr2);
            this.groupBox17.Controls.Add(this.tbShipAddr1);
            this.groupBox17.Controls.Add(this.tbShipName);
            this.groupBox17.Controls.Add(this.label57);
            this.groupBox17.Controls.Add(this.label58);
            this.groupBox17.Controls.Add(this.label59);
            this.groupBox17.Controls.Add(this.label60);
            this.groupBox17.Controls.Add(this.label61);
            this.groupBox17.Controls.Add(this.label62);
            this.groupBox17.Controls.Add(this.label63);
            this.groupBox17.Location = new System.Drawing.Point(27, 294);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(604, 152);
            this.groupBox17.TabIndex = 28;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Shipping Information";
            // 
            // cbSameAsBillingInfo
            // 
            this.cbSameAsBillingInfo.AutoSize = true;
            this.cbSameAsBillingInfo.Location = new System.Drawing.Point(473, 25);
            this.cbSameAsBillingInfo.Name = "cbSameAsBillingInfo";
            this.cbSameAsBillingInfo.Size = new System.Drawing.Size(118, 17);
            this.cbSameAsBillingInfo.TabIndex = 16;
            this.cbSameAsBillingInfo.Text = "Same as Billing Info";
            this.cbSameAsBillingInfo.CheckedChanged += new System.EventHandler(this.cbSameAsBillingInfo_CheckedChanged);
            // 
            // tbShipCntry
            // 
            this.tbShipCntry.Location = new System.Drawing.Point(343, 115);
            this.tbShipCntry.Margin = new System.Windows.Forms.Padding(1, 0, 3, 3);
            this.tbShipCntry.MaxLength = 25;
            this.tbShipCntry.Name = "tbShipCntry";
            this.tbShipCntry.Size = new System.Drawing.Size(182, 20);
            this.tbShipCntry.TabIndex = 16;
            // 
            // tbShipZip
            // 
            this.tbShipZip.Location = new System.Drawing.Point(116, 115);
            this.tbShipZip.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbShipZip.MaxLength = 14;
            this.tbShipZip.Name = "tbShipZip";
            this.tbShipZip.Size = new System.Drawing.Size(90, 20);
            this.tbShipZip.TabIndex = 15;
            // 
            // tbShipState
            // 
            this.tbShipState.Location = new System.Drawing.Point(377, 91);
            this.tbShipState.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbShipState.MaxLength = 20;
            this.tbShipState.Name = "tbShipState";
            this.tbShipState.Size = new System.Drawing.Size(90, 20);
            this.tbShipState.TabIndex = 14;
            // 
            // tbShipCity
            // 
            this.tbShipCity.Location = new System.Drawing.Point(55, 91);
            this.tbShipCity.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbShipCity.MaxLength = 25;
            this.tbShipCity.Name = "tbShipCity";
            this.tbShipCity.Size = new System.Drawing.Size(211, 20);
            this.tbShipCity.TabIndex = 13;
            // 
            // tbShipAddr2
            // 
            this.tbShipAddr2.Location = new System.Drawing.Point(90, 68);
            this.tbShipAddr2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbShipAddr2.MaxLength = 50;
            this.tbShipAddr2.Name = "tbShipAddr2";
            this.tbShipAddr2.Size = new System.Drawing.Size(283, 20);
            this.tbShipAddr2.TabIndex = 12;
            // 
            // tbShipAddr1
            // 
            this.tbShipAddr1.Location = new System.Drawing.Point(90, 45);
            this.tbShipAddr1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbShipAddr1.MaxLength = 50;
            this.tbShipAddr1.Name = "tbShipAddr1";
            this.tbShipAddr1.Size = new System.Drawing.Size(283, 20);
            this.tbShipAddr1.TabIndex = 11;
            // 
            // tbShipName
            // 
            this.tbShipName.Location = new System.Drawing.Point(66, 23);
            this.tbShipName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbShipName.MaxLength = 50;
            this.tbShipName.Name = "tbShipName";
            this.tbShipName.Size = new System.Drawing.Size(307, 20);
            this.tbShipName.TabIndex = 10;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(289, 118);
            this.label57.Margin = new System.Windows.Forms.Padding(3, 2, 2, 3);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(46, 13);
            this.label57.TabIndex = 6;
            this.label57.Text = "Country:";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(21, 118);
            this.label58.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(87, 13);
            this.label58.TabIndex = 5;
            this.label58.Text = "Zip/Postal Code:";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(289, 94);
            this.label59.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(82, 13);
            this.label59.TabIndex = 4;
            this.label59.Text = "Province/State:";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(21, 93);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(27, 13);
            this.label60.TabIndex = 3;
            this.label60.Text = "City:";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(21, 71);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(57, 13);
            this.label61.TabIndex = 2;
            this.label61.Text = "Address 2:";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(21, 48);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(57, 13);
            this.label62.TabIndex = 1;
            this.label62.Text = "Address 1:";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(21, 26);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(38, 13);
            this.label63.TabIndex = 0;
            this.label63.Text = "Name:";
            // 
            // groupBox19
            // 
            this.groupBox19.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox19.Controls.Add(this.tbBillingCntry);
            this.groupBox19.Controls.Add(this.tbBillingZip);
            this.groupBox19.Controls.Add(this.tbBillingState);
            this.groupBox19.Controls.Add(this.tbBillingCity);
            this.groupBox19.Controls.Add(this.tbBillingAddr2);
            this.groupBox19.Controls.Add(this.tbBillingAddr1);
            this.groupBox19.Controls.Add(this.tbBillingName);
            this.groupBox19.Controls.Add(this.label64);
            this.groupBox19.Controls.Add(this.label65);
            this.groupBox19.Controls.Add(this.label66);
            this.groupBox19.Controls.Add(this.label67);
            this.groupBox19.Controls.Add(this.label68);
            this.groupBox19.Controls.Add(this.label69);
            this.groupBox19.Controls.Add(this.label70);
            this.groupBox19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox19.Location = new System.Drawing.Point(27, 133);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(604, 146);
            this.groupBox19.TabIndex = 26;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Billing Information";
            // 
            // tbBillingCntry
            // 
            this.tbBillingCntry.Location = new System.Drawing.Point(343, 115);
            this.tbBillingCntry.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbBillingCntry.MaxLength = 25;
            this.tbBillingCntry.Name = "tbBillingCntry";
            this.tbBillingCntry.Size = new System.Drawing.Size(182, 20);
            this.tbBillingCntry.TabIndex = 9;
            // 
            // tbBillingZip
            // 
            this.tbBillingZip.Location = new System.Drawing.Point(116, 115);
            this.tbBillingZip.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbBillingZip.MaxLength = 14;
            this.tbBillingZip.Name = "tbBillingZip";
            this.tbBillingZip.Size = new System.Drawing.Size(90, 20);
            this.tbBillingZip.TabIndex = 8;
            // 
            // tbBillingState
            // 
            this.tbBillingState.Location = new System.Drawing.Point(377, 91);
            this.tbBillingState.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbBillingState.MaxLength = 20;
            this.tbBillingState.Name = "tbBillingState";
            this.tbBillingState.Size = new System.Drawing.Size(90, 20);
            this.tbBillingState.TabIndex = 7;
            // 
            // tbBillingCity
            // 
            this.tbBillingCity.Location = new System.Drawing.Point(55, 91);
            this.tbBillingCity.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbBillingCity.MaxLength = 25;
            this.tbBillingCity.Name = "tbBillingCity";
            this.tbBillingCity.Size = new System.Drawing.Size(211, 20);
            this.tbBillingCity.TabIndex = 6;
            // 
            // tbBillingAddr2
            // 
            this.tbBillingAddr2.Location = new System.Drawing.Point(90, 68);
            this.tbBillingAddr2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbBillingAddr2.MaxLength = 50;
            this.tbBillingAddr2.Name = "tbBillingAddr2";
            this.tbBillingAddr2.Size = new System.Drawing.Size(283, 20);
            this.tbBillingAddr2.TabIndex = 5;
            // 
            // tbBillingAddr1
            // 
            this.tbBillingAddr1.Location = new System.Drawing.Point(90, 45);
            this.tbBillingAddr1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.tbBillingAddr1.MaxLength = 50;
            this.tbBillingAddr1.Name = "tbBillingAddr1";
            this.tbBillingAddr1.Size = new System.Drawing.Size(283, 20);
            this.tbBillingAddr1.TabIndex = 4;
            // 
            // tbBillingName
            // 
            this.tbBillingName.Location = new System.Drawing.Point(66, 23);
            this.tbBillingName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbBillingName.MaxLength = 50;
            this.tbBillingName.Name = "tbBillingName";
            this.tbBillingName.Size = new System.Drawing.Size(307, 20);
            this.tbBillingName.TabIndex = 3;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(289, 118);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(46, 13);
            this.label64.TabIndex = 6;
            this.label64.Text = "Country:";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(21, 118);
            this.label65.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(87, 13);
            this.label65.TabIndex = 5;
            this.label65.Text = "Zip/Postal Code:";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(289, 94);
            this.label66.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(82, 13);
            this.label66.TabIndex = 4;
            this.label66.Text = "Province/State:";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(21, 93);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(27, 13);
            this.label67.TabIndex = 3;
            this.label67.Text = "City:";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(21, 70);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(57, 13);
            this.label68.TabIndex = 2;
            this.label68.Text = "Address 2:";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(21, 47);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(57, 13);
            this.label69.TabIndex = 1;
            this.label69.Text = "Address 1:";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(21, 26);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(38, 13);
            this.label70.TabIndex = 0;
            this.label70.Text = "Name:";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(457, 107);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(68, 13);
            this.label71.TabIndex = 27;
            this.label71.Text = "Customer ID:";
            // 
            // lvCustomerList
            // 
            this.lvCustomerList.Location = new System.Drawing.Point(27, 7);
            this.lvCustomerList.Name = "lvCustomerList";
            this.lvCustomerList.Size = new System.Drawing.Size(604, 84);
            this.lvCustomerList.TabIndex = 23;
            this.lvCustomerList.UseCompatibleStateImageBehavior = false;
            this.lvCustomerList.SelectedIndexChanged += new System.EventHandler(this.lvCustomerList_SelectedIndexChanged);
            // 
            // groupBox37
            // 
            this.groupBox37.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox37.Controls.Add(this.lUpdateStatus2);
            this.groupBox37.Controls.Add(this.bCustDelete);
            this.groupBox37.Controls.Add(this.bCustUpdate);
            this.groupBox37.Controls.Add(this.bCustSearch);
            this.groupBox37.Controls.Add(this.bAddCustomer);
            this.groupBox37.Location = new System.Drawing.Point(684, 211);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(125, 218);
            this.groupBox37.TabIndex = 22;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "  Customer Database";
            // 
            // lUpdateStatus2
            // 
            this.lUpdateStatus2.AutoSize = true;
            this.lUpdateStatus2.Location = new System.Drawing.Point(12, 195);
            this.lUpdateStatus2.Name = "lUpdateStatus2";
            this.lUpdateStatus2.Size = new System.Drawing.Size(97, 13);
            this.lUpdateStatus2.TabIndex = 22;
            this.lUpdateStatus2.Text = "Update Successful";
            this.lUpdateStatus2.Visible = false;
            // 
            // mediaDetailTab
            // 
            this.mediaDetailTab.BackColor = System.Drawing.SystemColors.Window;
            this.mediaDetailTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mediaDetailTab.Controls.Add(this.cbEdition);
            this.mediaDetailTab.Controls.Add(this.label199);
            this.mediaDetailTab.Controls.Add(this.label115);
            this.mediaDetailTab.Controls.Add(this.mtbASIN);
            this.mediaDetailTab.Controls.Add(this.coOrigin);
            this.mediaDetailTab.Controls.Add(this.cbAdult);
            this.mediaDetailTab.Controls.Add(this.tbDesc);
            this.mediaDetailTab.Controls.Add(this.label13);
            this.mediaDetailTab.Controls.Add(this.label8);
            this.mediaDetailTab.Controls.Add(this.coMediaType);
            this.mediaDetailTab.Controls.Add(this.label121);
            this.mediaDetailTab.Controls.Add(this.tbNbrOfDisks);
            this.mediaDetailTab.Controls.Add(this.label7);
            this.mediaDetailTab.Controls.Add(this.coLanguage);
            this.mediaDetailTab.Controls.Add(this.label17);
            this.mediaDetailTab.Controls.Add(this.label172);
            this.mediaDetailTab.Controls.Add(this.tbImageURL);
            this.mediaDetailTab.Controls.Add(this.tabSpecificInfo);
            this.mediaDetailTab.Controls.Add(this.gbShipping);
            this.mediaDetailTab.Controls.Add(this.label6);
            this.mediaDetailTab.Controls.Add(this.panel6);
            this.mediaDetailTab.Controls.Add(this.lNotFound);
            this.mediaDetailTab.Controls.Add(this.bClone);
            this.mediaDetailTab.Controls.Add(this.label92);
            this.mediaDetailTab.Controls.Add(this.tbUPC);
            this.mediaDetailTab.Controls.Add(this.cbStatusHold);
            this.mediaDetailTab.Controls.Add(this.lMediaType);
            this.mediaDetailTab.Controls.Add(this.bUpdateInfo);
            this.mediaDetailTab.Controls.Add(this.tbPrice);
            this.mediaDetailTab.Controls.Add(this.tbCost);
            this.mediaDetailTab.Controls.Add(this.tbQty);
            this.mediaDetailTab.Controls.Add(this.lbCannedText);
            this.mediaDetailTab.Controls.Add(this.bNextItem);
            this.mediaDetailTab.Controls.Add(this.tbTitle);
            this.mediaDetailTab.Controls.Add(this.bRelist);
            this.mediaDetailTab.Controls.Add(this.lblDateUpdated);
            this.mediaDetailTab.Controls.Add(this.tbItemNote);
            this.mediaDetailTab.Controls.Add(this.cbCondition);
            this.mediaDetailTab.Controls.Add(this.lCondition);
            this.mediaDetailTab.Controls.Add(this.bClear);
            this.mediaDetailTab.Controls.Add(this.cbDoNotReprice);
            this.mediaDetailTab.Controls.Add(this.label31);
            this.mediaDetailTab.Controls.Add(this.bDecrement);
            this.mediaDetailTab.Controls.Add(this.bIncrement);
            this.mediaDetailTab.Controls.Add(this.bLookupPrices);
            this.mediaDetailTab.Controls.Add(this.lBinding);
            this.mediaDetailTab.Controls.Add(this.coProductType);
            this.mediaDetailTab.Controls.Add(this.tbPrivNotes);
            this.mediaDetailTab.Controls.Add(this.lblDateAdded);
            this.mediaDetailTab.Controls.Add(this.lPrivNotes);
            this.mediaDetailTab.Controls.Add(this.lPrice);
            this.mediaDetailTab.Controls.Add(this.lCost);
            this.mediaDetailTab.Controls.Add(this.label29);
            this.mediaDetailTab.Controls.Add(this.bShoppingCart);
            this.mediaDetailTab.Controls.Add(this.bGetMediaInfo);
            this.mediaDetailTab.Controls.Add(this.tbLocn);
            this.mediaDetailTab.Controls.Add(this.tbSKU);
            this.mediaDetailTab.Controls.Add(this.lLocation);
            this.mediaDetailTab.Controls.Add(this.label5);
            this.mediaDetailTab.Controls.Add(this.bDeleteItem);
            this.mediaDetailTab.Controls.Add(this.bUpdateRecord);
            this.mediaDetailTab.Controls.Add(this.bAddRecord);
            this.mediaDetailTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediaDetailTab.Location = new System.Drawing.Point(4, 44);
            this.mediaDetailTab.Name = "mediaDetailTab";
            this.mediaDetailTab.Size = new System.Drawing.Size(865, 550);
            this.mediaDetailTab.TabIndex = 10;
            this.mediaDetailTab.Text = "Media Detail ";
            this.mediaDetailTab.ToolTipText = "Shows the detail for the selected book in the Database Panel";
            this.mediaDetailTab.UseVisualStyleBackColor = true;
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label115.Location = new System.Drawing.Point(276, 63);
            this.label115.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(35, 13);
            this.label115.TabIndex = 361;
            this.label115.Text = "ASIN:";
            // 
            // cbAdult
            // 
            this.cbAdult.AutoSize = true;
            this.cbAdult.Location = new System.Drawing.Point(597, 126);
            this.cbAdult.Name = "cbAdult";
            this.cbAdult.Size = new System.Drawing.Size(90, 17);
            this.cbAdult.TabIndex = 357;
            this.cbAdult.Text = "Adult Content";
            this.cbAdult.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(244, 159);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 1, 1, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 197;
            this.label8.Text = "Image URL:";
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label121.Location = new System.Drawing.Point(607, 285);
            this.label121.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(58, 13);
            this.label121.TabIndex = 356;
            this.label121.Text = "Language:";
            // 
            // tbNbrOfDisks
            // 
            this.tbNbrOfDisks.Location = new System.Drawing.Point(796, 156);
            this.tbNbrOfDisks.MaxLength = 4;
            this.tbNbrOfDisks.Name = "tbNbrOfDisks";
            this.tbNbrOfDisks.Size = new System.Drawing.Size(34, 20);
            this.tbNbrOfDisks.TabIndex = 10;
            this.tbNbrOfDisks.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(702, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 354;
            this.label7.Text = "Number of Disks:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(309, 284);
            this.label17.Margin = new System.Windows.Forms.Padding(3, 1, 1, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 13);
            this.label17.TabIndex = 352;
            this.label17.Text = "Country of Orgin:";
            // 
            // label172
            // 
            this.label172.AutoSize = true;
            this.label172.Location = new System.Drawing.Point(619, 188);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(71, 13);
            this.label172.TabIndex = 315;
            this.label172.Text = "Canned Text:";
            // 
            // tbImageURL
            // 
            this.tbImageURL.Location = new System.Drawing.Point(321, 156);
            this.tbImageURL.Margin = new System.Windows.Forms.Padding(1, 1, 3, 2);
            this.tbImageURL.MaxLength = 75;
            this.tbImageURL.Name = "tbImageURL";
            this.tbImageURL.Size = new System.Drawing.Size(160, 20);
            this.tbImageURL.TabIndex = 8;
            this.tbImageURL.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            this.tbImageURL.Leave += new System.EventHandler(this.tbImageURL_Leave);
            // 
            // tabSpecificInfo
            // 
            this.tabSpecificInfo.Controls.Add(this.tabAudio);
            this.tabSpecificInfo.Controls.Add(this.tabVideo);
            this.tabSpecificInfo.Location = new System.Drawing.Point(12, 340);
            this.tabSpecificInfo.Name = "tabSpecificInfo";
            this.tabSpecificInfo.SelectedIndex = 0;
            this.tabSpecificInfo.Size = new System.Drawing.Size(818, 145);
            this.tabSpecificInfo.TabIndex = 325;
            // 
            // tabAudio
            // 
            this.tabAudio.Controls.Add(this.tbOrchestra);
            this.tabAudio.Controls.Add(this.label181);
            this.tabAudio.Controls.Add(this.tbConductor);
            this.tabAudio.Controls.Add(this.label178);
            this.tabAudio.Controls.Add(this.tbComposer);
            this.tabAudio.Controls.Add(this.label147);
            this.tabAudio.Controls.Add(this.tbArtist);
            this.tabAudio.Controls.Add(this.label141);
            this.tabAudio.Controls.Add(this.tbVinylDetails);
            this.tabAudio.Controls.Add(this.label137);
            this.tabAudio.Controls.Add(this.coAudioKeywords);
            this.tabAudio.Controls.Add(this.label130);
            this.tabAudio.Controls.Add(this.coAudioFormat);
            this.tabAudio.Controls.Add(this.label40);
            this.tabAudio.Controls.Add(this.tbCatalogID);
            this.tabAudio.Controls.Add(this.label9);
            this.tabAudio.Controls.Add(this.label18);
            this.tabAudio.Controls.Add(this.label117);
            this.tabAudio.Controls.Add(this.label11);
            this.tabAudio.Controls.Add(this.comboBox7);
            this.tabAudio.Controls.Add(this.button4);
            this.tabAudio.Controls.Add(this.textBox12);
            this.tabAudio.Controls.Add(this.label24);
            this.tabAudio.Controls.Add(this.tbMusicLabel);
            this.tabAudio.Controls.Add(this.tbMusicYear);
            this.tabAudio.Location = new System.Drawing.Point(4, 22);
            this.tabAudio.Name = "tabAudio";
            this.tabAudio.Size = new System.Drawing.Size(810, 119);
            this.tabAudio.TabIndex = 2;
            this.tabAudio.Text = "Audio Specifics";
            this.tabAudio.UseVisualStyleBackColor = true;
            // 
            // tbOrchestra
            // 
            this.tbOrchestra.BackColor = System.Drawing.SystemColors.Window;
            this.tbOrchestra.Location = new System.Drawing.Point(678, 87);
            this.tbOrchestra.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.tbOrchestra.MaxLength = 25;
            this.tbOrchestra.Name = "tbOrchestra";
            this.tbOrchestra.Size = new System.Drawing.Size(111, 20);
            this.tbOrchestra.TabIndex = 370;
            this.tbOrchestra.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label181
            // 
            this.label181.AutoSize = true;
            this.label181.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label181.Location = new System.Drawing.Point(615, 90);
            this.label181.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label181.Name = "label181";
            this.label181.Size = new System.Drawing.Size(56, 13);
            this.label181.TabIndex = 371;
            this.label181.Text = "Orchestra:";
            // 
            // tbConductor
            // 
            this.tbConductor.BackColor = System.Drawing.SystemColors.Window;
            this.tbConductor.Location = new System.Drawing.Point(468, 87);
            this.tbConductor.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.tbConductor.MaxLength = 25;
            this.tbConductor.Name = "tbConductor";
            this.tbConductor.Size = new System.Drawing.Size(111, 20);
            this.tbConductor.TabIndex = 368;
            this.tbConductor.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label178
            // 
            this.label178.AutoSize = true;
            this.label178.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label178.Location = new System.Drawing.Point(405, 90);
            this.label178.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label178.Name = "label178";
            this.label178.Size = new System.Drawing.Size(59, 13);
            this.label178.TabIndex = 369;
            this.label178.Text = "Conductor:";
            // 
            // tbComposer
            // 
            this.tbComposer.BackColor = System.Drawing.SystemColors.Window;
            this.tbComposer.Location = new System.Drawing.Point(254, 87);
            this.tbComposer.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.tbComposer.MaxLength = 25;
            this.tbComposer.Name = "tbComposer";
            this.tbComposer.Size = new System.Drawing.Size(111, 20);
            this.tbComposer.TabIndex = 366;
            this.tbComposer.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label147.Location = new System.Drawing.Point(190, 90);
            this.label147.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(57, 13);
            this.label147.TabIndex = 367;
            this.label147.Text = "Composer:";
            // 
            // tbArtist
            // 
            this.tbArtist.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbArtist.Location = new System.Drawing.Point(57, 87);
            this.tbArtist.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.tbArtist.MaxLength = 25;
            this.tbArtist.Name = "tbArtist";
            this.tbArtist.Size = new System.Drawing.Size(111, 20);
            this.tbArtist.TabIndex = 364;
            this.tbArtist.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label141.Location = new System.Drawing.Point(16, 90);
            this.label141.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(33, 13);
            this.label141.TabIndex = 365;
            this.label141.Text = "Artist:";
            // 
            // tbVinylDetails
            // 
            this.tbVinylDetails.BackColor = System.Drawing.SystemColors.Window;
            this.tbVinylDetails.Location = new System.Drawing.Point(126, 50);
            this.tbVinylDetails.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.tbVinylDetails.MaxLength = 25;
            this.tbVinylDetails.Multiline = true;
            this.tbVinylDetails.Name = "tbVinylDetails";
            this.tbVinylDetails.Size = new System.Drawing.Size(339, 20);
            this.tbVinylDetails.TabIndex = 362;
            this.tbVinylDetails.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label137.Location = new System.Drawing.Point(16, 53);
            this.label137.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(105, 13);
            this.label137.TabIndex = 363;
            this.label137.Text = "Vinyl Record Details:";
            // 
            // coAudioKeywords
            // 
            this.coAudioKeywords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coAudioKeywords.FormattingEnabled = true;
            this.coAudioKeywords.Items.AddRange(new object[] {
            "",
            "Blues - Acoustic",
            "Blues - Contemporary",
            "Blues - Electric",
            "Blues - General",
            "Blues - Traditional",
            "Broadway & Vocal - General",
            "Broadway & Vocal - Musicals",
            "Children\'s Music - Educational",
            "Children\'s Music - General",
            "Children\'s Music - Lullabies",
            "Christian Music - Alternative",
            "Christian Music - Contemporary",
            "Christian Music - General",
            "Christian Music - Gospel",
            "Christian Music - Praise and Worship",
            "Christian Music - Rock",
            "Classical - Baroque Period - Ballets & Dances",
            "Classical - Baroque Period - Chamber Music",
            "Classical - Baroque Period - Concertos",
            "Classical - Baroque Period - General",
            "Classical - Baroque Period - Opera",
            "Classical - Baroque Period - Symphonies",
            "Classical - Baroque Period - Vocal Music",
            "Classical - Classical Period - Ballets & Dances",
            "Classical - Classical Period - Chamber Music",
            "Classical - Classical Period - Concertos",
            "Classical - Classical Period - General",
            "Classical - Classical Period - Opera",
            "Classical - Classical Period - Symphonies",
            "Classical - Classical Period - Vocal Music",
            "Classical - Early Music - Ballets & Dances",
            "Classical - Early Music - Chamber Music",
            "Classical - Early Music - Concertos",
            "Classical - Early Music - General",
            "Classical - Early Music - Opera",
            "Classical - Early Music - Symphonies",
            "Classical - Early Music - Vocal Music",
            "Classical - General",
            "Classical - Modern Period - Ballets & Dances",
            "Classical - Modern Period - Chamber Music",
            "Classical - Modern Period - Concertos",
            "Classical - Modern Period - General",
            "Classical - Modern Period - Opera",
            "Classical - Modern Period - Symphonies",
            "Classical - Modern Period - Vocal Music",
            "Classical - Renaissance Period - Ballets & Dances",
            "Classical - Renaissance Period - Chamber Music",
            "Classical - Renaissance Period - Concertos",
            "Classical - Renaissance Period - General",
            "Classical - Renaissance Period - Opera",
            "Classical - Renaissance Period - Symphonies",
            "Classical - Renaissance Period - Vocal Music",
            "Classical - Romantic Period - Ballets & Dances",
            "Classical - Romantic Period - Chamber Music",
            "Classical - Romantic Period - Concertos",
            "Classical - Romantic Period - General",
            "Classical - Romantic Period - Opera",
            "Classical - Romantic Period - Symphonies",
            "Classical - Romantic Period - Vocal Music",
            "Country - Alt-Country",
            "Country - Bluegrass",
            "Country - Contemporary Country",
            "Country - General",
            "Country - Traditional Country",
            "Dance & DJ - Ambient",
            "Dance & DJ - Disco",
            "Dance & DJ - Electronica",
            "Dance & DJ - General",
            "Dance & DJ - Techno",
            "Dance & DJ - Trip-Hop",
            "Folk Music - Contemporary Folk",
            "Folk Music - General",
            "Folk Music - Jewish Folk",
            "Folk Music - Traditional British Folk",
            "Folk Music - Traditional Folk",
            "Folk Music - Traditional Irish Folk",
            "International Music - African",
            "International Music - Asian",
            "International Music - Australia & Oceania",
            "International Music - Caribbean",
            "International Music - Central American",
            "International Music - European",
            "International Music - General",
            "International Music - Latin",
            "International Music - Middle Eastern",
            "International Music - Reggae",
            "International Music - South American",
            "Jazz - Avant Garde Jazz",
            "Jazz - Bop Jazz",
            "Jazz - Cool Jazz",
            "Jazz - Free Jazz",
            "Jazz - General",
            "Jazz - Jazz",
            "Jazz - Jazz Fusion",
            "Jazz - Latin Jazz",
            "Jazz - Smooth Jazz",
            "Jazz - Swing",
            "Jazz - Traditional Jazz",
            "Jazz - Vocal Jazz",
            "Latin Music - Flamenco",
            "Latin Music - General",
            "Latin Music - Latin Pop",
            "Latin Music - Mambo",
            "Latin Music - Mariachi",
            "Latin Music - Merengue",
            "Latin Music - Salsa",
            "Latin Music - Tango",
            "Miscellaneous - Comedy",
            "Miscellaneous - Exercise",
            "Miscellaneous - Experimental",
            "Miscellaneous - General",
            "Miscellaneous - Holiday",
            "Miscellaneous - Instruction",
            "Miscellaneous - Karaoke",
            "New Age - General",
            "New Age - Meditation",
            "New Age - Relaxation",
            "Pop - Adult Contemporary Pop",
            "Pop - Dance Pop",
            "Pop - Easy Listening",
            "Pop - General",
            "Pop - Pop Rock",
            "Pop - Singer-Songwriters",
            "Pop - Soft Rock",
            "Pop - Vocal Pop",
            "R&B Music - Classic R&B",
            "R&B Music - Contemporary R&B",
            "R&B Music - Funk",
            "R&B Music - General",
            "R&B Music - R&B",
            "R&B Music - Soul",
            "Rap - East Coast Rap",
            "Rap - Experimental Rap",
            "Rap - General",
            "Rap - Pop-Rap",
            "Rap - Rap & Hip-Hop",
            "Rap - Southern Rap",
            "Rap - West Coast Rap",
            "Rock - Album-Oriented Rock",
            "Rock - Alternative Rock",
            "Rock - British Invasion Rock",
            "Rock - Classic Rock",
            "Rock - Death Metal",
            "Rock - General",
            "Rock - Glam Rock",
            "Rock - Goth & Industrial Rock",
            "Rock - Hard Rock & Metal",
            "Rock - Hardcore & Punk Rock",
            "Rock - Indie Rock",
            "Rock - New Wave",
            "Rock - Psychedelic Rock",
            "Rock - Southern Rock",
            "Soundtracks - General",
            "Soundtracks - Movie Scores",
            "Soundtracks - Movie Soundtracks",
            "Soundtracks - Television Soundtracks",
            "Blues - Acoustic",
            "Blues - Contemporary",
            "Blues - Electric",
            "Blues - General",
            "Blues - Traditional",
            "Broadway & Vocal - General",
            "Broadway & Vocal - Musicals",
            "Children\'s Music - Educational",
            "Children\'s Music - General",
            "Children\'s Music - Lullabies",
            "Christian Music - Alternative",
            "Christian Music - Contemporary",
            "Christian Music - General",
            "Christian Music - Gospel",
            "Christian Music - Praise and Worship",
            "Christian Music - Rock",
            "Classical - Baroque Period - Ballets & Dances",
            "Classical - Baroque Period - Chamber Music",
            "Classical - Baroque Period - Concertos",
            "Classical - Baroque Period - General",
            "Classical - Baroque Period - Opera",
            "Classical - Baroque Period - Symphonies",
            "Classical - Baroque Period - Vocal Music",
            "Classical - Classical Period - Ballets & Dances",
            "Classical - Classical Period - Chamber Music",
            "Classical - Classical Period - Concertos",
            "Classical - Classical Period - General",
            "Classical - Classical Period - Opera",
            "Classical - Classical Period - Symphonies",
            "Classical - Classical Period - Vocal Music",
            "Classical - Early Music - Ballets & Dances",
            "Classical - Early Music - Chamber Music",
            "Classical - Early Music - Concertos",
            "Classical - Early Music - General",
            "Classical - Early Music - Opera",
            "Classical - Early Music - Symphonies",
            "Classical - Early Music - Vocal Music",
            "Classical - General",
            "Classical - Modern Period - Ballets & Dances",
            "Classical - Modern Period - Chamber Music",
            "Classical - Modern Period - Concertos",
            "Classical - Modern Period - General",
            "Classical - Modern Period - Opera",
            "Classical - Modern Period - Symphonies",
            "Classical - Modern Period - Vocal Music",
            "Classical - Renaissance Period - Ballets & Dances",
            "Classical - Renaissance Period - Chamber Music",
            "Classical - Renaissance Period - Concertos",
            "Classical - Renaissance Period - General",
            "Classical - Renaissance Period - Opera",
            "Classical - Renaissance Period - Symphonies",
            "Classical - Renaissance Period - Vocal Music",
            "Classical - Romantic Period - Ballets & Dances",
            "Classical - Romantic Period - Chamber Music",
            "Classical - Romantic Period - Concertos",
            "Classical - Romantic Period - General",
            "Classical - Romantic Period - Opera",
            "Classical - Romantic Period - Symphonies",
            "Classical - Romantic Period - Vocal Music",
            "Country - Alt-Country",
            "Country - Bluegrass",
            "Country - Contemporary Country",
            "Country - General",
            "Country - Traditional Country",
            "Dance & DJ - Ambient",
            "Dance & DJ - Disco",
            "Dance & DJ - Electronica",
            "Dance & DJ - General",
            "Dance & DJ - Techno",
            "Dance & DJ - Trip-Hop",
            "Folk Music - Contemporary Folk",
            "Folk Music - General",
            "Folk Music - Jewish Folk",
            "Folk Music - Traditional British Folk",
            "Folk Music - Traditional Folk",
            "Folk Music - Traditional Irish Folk",
            "International Music - African",
            "International Music - Asian",
            "International Music - Australia & Oceania",
            "International Music - Caribbean",
            "International Music - Central American",
            "International Music - European",
            "International Music - General",
            "International Music - Latin",
            "International Music - Middle Eastern",
            "International Music - Reggae",
            "International Music - South American",
            "Jazz - Avant Garde Jazz",
            "Jazz - Bop Jazz",
            "Jazz - Cool Jazz",
            "Jazz - Free Jazz",
            "Jazz - General",
            "Jazz - Jazz",
            "Jazz - Jazz Fusion"});
            this.coAudioKeywords.Location = new System.Drawing.Point(578, 49);
            this.coAudioKeywords.Name = "coAudioKeywords";
            this.coAudioKeywords.Size = new System.Drawing.Size(211, 21);
            this.coAudioKeywords.TabIndex = 361;
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label130.Location = new System.Drawing.Point(516, 52);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(56, 13);
            this.label130.TabIndex = 360;
            this.label130.Text = "Keywords:";
            // 
            // tbCatalogID
            // 
            this.tbCatalogID.BackColor = System.Drawing.SystemColors.Window;
            this.tbCatalogID.Location = new System.Drawing.Point(418, 14);
            this.tbCatalogID.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.tbCatalogID.MaxLength = 25;
            this.tbCatalogID.Name = "tbCatalogID";
            this.tbCatalogID.Size = new System.Drawing.Size(75, 20);
            this.tbCatalogID.TabIndex = 347;
            this.tbCatalogID.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 198;
            this.label9.Text = "Music Label:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(308, 17);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 13);
            this.label18.TabIndex = 349;
            this.label18.Text = "Catalog ID Number:";
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label117.Location = new System.Drawing.Point(349, 159);
            this.label117.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(88, 13);
            this.label117.TabIndex = 344;
            this.label117.Text = "Number of Disks:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(505, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 200;
            this.label11.Text = "Year Released:";
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.SystemColors.Window;
            this.textBox12.Location = new System.Drawing.Point(132, 278);
            this.textBox12.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.textBox12.MaxLength = 50;
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(150, 20);
            this.textBox12.TabIndex = 239;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(28, 280);
            this.label24.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 13);
            this.label24.TabIndex = 241;
            this.label24.Text = "Catalog ID Number:";
            // 
            // tbMusicLabel
            // 
            this.tbMusicLabel.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbMusicLabel.Location = new System.Drawing.Point(93, 14);
            this.tbMusicLabel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tbMusicLabel.MaxLength = 85;
            this.tbMusicLabel.Name = "tbMusicLabel";
            this.tbMusicLabel.Size = new System.Drawing.Size(200, 20);
            this.tbMusicLabel.TabIndex = 0;
            this.tbMusicLabel.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // tbMusicYear
            // 
            this.tbMusicYear.Location = new System.Drawing.Point(592, 13);
            this.tbMusicYear.MaxLength = 4;
            this.tbMusicYear.Name = "tbMusicYear";
            this.tbMusicYear.Size = new System.Drawing.Size(42, 20);
            this.tbMusicYear.TabIndex = 0;
            this.tbMusicYear.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            this.tbMusicYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            // 
            // tabVideo
            // 
            this.tabVideo.Controls.Add(this.cbDVDRegion);
            this.tabVideo.Controls.Add(this.label200);
            this.tabVideo.Controls.Add(this.tbDirector);
            this.tabVideo.Controls.Add(this.label198);
            this.tabVideo.Controls.Add(this.tbActors);
            this.tabVideo.Controls.Add(this.label197);
            this.tabVideo.Controls.Add(this.coVideoKeywords);
            this.tabVideo.Controls.Add(this.coSubTitles);
            this.tabVideo.Controls.Add(this.label43);
            this.tabVideo.Controls.Add(this.tbRuntime);
            this.tabVideo.Controls.Add(this.label32);
            this.tabVideo.Controls.Add(this.label196);
            this.tabVideo.Controls.Add(this.label21);
            this.tabVideo.Controls.Add(this.coAudioEncoding);
            this.tabVideo.Controls.Add(this.label109);
            this.tabVideo.Controls.Add(this.coMPAA);
            this.tabVideo.Controls.Add(this.coVideoFormat);
            this.tabVideo.Controls.Add(this.tbVideoYear);
            this.tabVideo.Controls.Add(this.label114);
            this.tabVideo.Controls.Add(this.tbStudio);
            this.tabVideo.Controls.Add(this.label134);
            this.tabVideo.Controls.Add(this.label140);
            this.tabVideo.Location = new System.Drawing.Point(4, 22);
            this.tabVideo.Name = "tabVideo";
            this.tabVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabVideo.Size = new System.Drawing.Size(810, 119);
            this.tabVideo.TabIndex = 1;
            this.tabVideo.Text = "Video Specifics";
            this.tabVideo.UseVisualStyleBackColor = true;
            // 
            // tbDirector
            // 
            this.tbDirector.Location = new System.Drawing.Point(378, 79);
            this.tbDirector.MaxLength = 50;
            this.tbDirector.Name = "tbDirector";
            this.tbDirector.Size = new System.Drawing.Size(103, 20);
            this.tbDirector.TabIndex = 362;
            this.tbDirector.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label198.Location = new System.Drawing.Point(325, 83);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(47, 13);
            this.label198.TabIndex = 363;
            this.label198.Text = "Director:";
            // 
            // tbActors
            // 
            this.tbActors.Location = new System.Drawing.Point(51, 78);
            this.tbActors.MaxLength = 100;
            this.tbActors.Name = "tbActors";
            this.tbActors.Size = new System.Drawing.Size(244, 20);
            this.tbActors.TabIndex = 360;
            this.tbActors.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label197
            // 
            this.label197.AutoSize = true;
            this.label197.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label197.Location = new System.Drawing.Point(6, 82);
            this.label197.Name = "label197";
            this.label197.Size = new System.Drawing.Size(40, 13);
            this.label197.TabIndex = 361;
            this.label197.Text = "Actors:";
            // 
            // coVideoKeywords
            // 
            this.coVideoKeywords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coVideoKeywords.FormattingEnabled = true;
            this.coVideoKeywords.Items.AddRange(new object[] {
            "",
            "Action - Comedy",
            "Action - Crime",
            "Action - Drama",
            "Action - Espionage",
            "Action - General",
            "Action - Martial Arts",
            "Action - Superheroes",
            "Action - Swashbucklers",
            "African American Cinema - Comedy",
            "African American Cinema - Documentary",
            "African American Cinema - Drama",
            "African American Cinema - General",
            "Animation - Anime",
            "Animation - Children\'s",
            "Animation - Feature Film",
            "Animation - General",
            "Animation - Holiday",
            "Animation - Science Fiction",
            "Art House - Action",
            "Art House - Comedy",
            "Art House - Drama",
            "Art House - General",
            "Art House - Mystery & Suspense",
            "Art House - Romance",
            "Children\'s - 10-12 Years",
            "Children\'s - 3-6 Years",
            "Children\'s - 7-9 Years",
            "Children\'s - Action & Adventure",
            "Children\'s - Birth-2 Years",
            "Children\'s - Comedy",
            "Children\'s - Drama",
            "Children\'s - General",
            "Children\'s - Science Fiction & Fantasy",
            "Comedy - General",
            "Comedy - Parody & Spoof",
            "Comedy - Romantic Comedy",
            "Comedy - Satire",
            "Comedy - Stand-up Comedy",
            "Concert Footage & Music Videos - Blues",
            "Concert Footage & Music Videos - Country",
            "Concert Footage & Music Videos - General",
            "Concert Footage & Music Videos - International",
            "Concert Footage & Music Videos - Jazz",
            "Concert Footage & Music Videos - Metal",
            "Concert Footage & Music Videos - New Age",
            "Concert Footage & Music Videos - Pop",
            "Concert Footage & Music Videos - Rap",
            "Concert Footage & Music Videos - Rock",
            "Drama - Crime",
            "Drama - Epic",
            "Drama - Family Life",
            "Drama - General",
            "Drama - Romance",
            "Fantasy - General",
            "Gay Cinema - General",
            "Horror - General",
            "International - Africa",
            "International - Asia",
            "International - Europe",
            "International - General",
            "International - Latin America",
            "International - United Kingdom",
            "Lesbian Cinema - General",
            "Military & War - Action & Adventure",
            "Military & War - Civil War",
            "Military & War - Comedy",
            "Military & War - Drama",
            "Military & War - General",
            "Military & War - Gulf Wars",
            "Military & War - Vietnam War",
            "Military & War - World War I",
            "Military & War - World War II",
            "Musicals - General",
            "Mystery - General",
            "Nonfiction - Art",
            "Nonfiction - Cooking & Beverages",
            "Nonfiction - Crafts & Hobbies",
            "Nonfiction - Dance",
            "Nonfiction - Gardening",
            "Nonfiction - General",
            "Nonfiction - Health",
            "Nonfiction - Home Improvement",
            "Nonfiction - Instructional",
            "Nonfiction - Metaphysical & Supernatural",
            "Nonfiction - Nature",
            "Nonfiction - Outdoor Recreation",
            "Nonfiction - Parenting",
            "Nonfiction - Religion",
            "Nonfiction - Self-Help",
            "Nonfiction - Transportation",
            "Nonfiction - Travel",
            "Nonfiction - Documentary - Biography",
            "Nonfiction - Documentary - Comedy",
            "Nonfiction - Documentary - Crime",
            "Nonfiction - Documentary - Gay & Lesbian",
            "Nonfiction - Documentary - General",
            "Nonfiction - Documentary - History",
            "Nonfiction - Documentary - Military",
            "Nonfiction - Documentary - Politics",
            "Nonfiction - Documentary - Religion",
            "Nonfiction - Documentary - Science",
            "Nonfiction - Educational - Business",
            "Nonfiction - Educational - General",
            "Nonfiction - Educational - Language",
            "Nonfiction - Educational - Mathematics",
            "Nonfiction - Educational - Science & Technology",
            "Nonfiction - Educational - Teaching Aids",
            "Nonfiction - Instructional - Aerobics",
            "Nonfiction - Instructional - Fitness",
            "Nonfiction - Instructional - General",
            "Nonfiction - Instructional - Pilates",
            "Nonfiction - Instructional - Tai Chi",
            "Nonfiction - Instructional - Yoga",
            "Nonfiction - Professional - Certification",
            "Nonfiction - Professional - General",
            "Nonfiction - Professional - Training",
            "Performing Arts - Ballet Perfomance",
            "Performing Arts - Classical Music Performance",
            "Performing Arts - Dance Perfomance",
            "Performing Arts - General",
            "Science Fiction - General",
            "Sports - General",
            "Television - Drama",
            "Television - General",
            "Television - Miniseries",
            "Thriller & Suspense - General",
            "Western - General"});
            this.coVideoKeywords.Location = new System.Drawing.Point(590, 78);
            this.coVideoKeywords.Name = "coVideoKeywords";
            this.coVideoKeywords.Size = new System.Drawing.Size(203, 21);
            this.coVideoKeywords.TabIndex = 359;
            // 
            // tbRuntime
            // 
            this.tbRuntime.Location = new System.Drawing.Point(390, 15);
            this.tbRuntime.MaxLength = 4;
            this.tbRuntime.Name = "tbRuntime";
            this.tbRuntime.Size = new System.Drawing.Size(28, 20);
            this.tbRuntime.TabIndex = 353;
            this.tbRuntime.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(334, 19);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(49, 13);
            this.label32.TabIndex = 354;
            this.label32.Text = "Runtime:";
            // 
            // label196
            // 
            this.label196.AutoSize = true;
            this.label196.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label196.Location = new System.Drawing.Point(528, 81);
            this.label196.Name = "label196";
            this.label196.Size = new System.Drawing.Size(56, 13);
            this.label196.TabIndex = 357;
            this.label196.Text = "Keywords:";
            // 
            // tbVideoYear
            // 
            this.tbVideoYear.Location = new System.Drawing.Point(279, 13);
            this.tbVideoYear.MaxLength = 4;
            this.tbVideoYear.Name = "tbVideoYear";
            this.tbVideoYear.Size = new System.Drawing.Size(43, 20);
            this.tbVideoYear.TabIndex = 328;
            this.tbVideoYear.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // tbStudio
            // 
            this.tbStudio.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbStudio.Location = new System.Drawing.Point(49, 13);
            this.tbStudio.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tbStudio.MaxLength = 85;
            this.tbStudio.Name = "tbStudio";
            this.tbStudio.Size = new System.Drawing.Size(119, 20);
            this.tbStudio.TabIndex = 331;
            this.tbStudio.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label134.Location = new System.Drawing.Point(194, 17);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(80, 13);
            this.label134.TabIndex = 338;
            this.label134.Text = "Year Released:";
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label140.Location = new System.Drawing.Point(5, 16);
            this.label140.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(40, 13);
            this.label140.TabIndex = 336;
            this.label140.Text = "Studio:";
            // 
            // gbShipping
            // 
            this.gbShipping.Controls.Add(this.cbIntlStd);
            this.gbShipping.Controls.Add(this.cb1dDom);
            this.gbShipping.Controls.Add(this.cb2dDom);
            this.gbShipping.Controls.Add(this.cbDomExp);
            this.gbShipping.Controls.Add(this.cbIntlExp);
            this.gbShipping.Controls.Add(this.cbDomStd);
            this.gbShipping.Location = new System.Drawing.Point(12, 263);
            this.gbShipping.Name = "gbShipping";
            this.gbShipping.Size = new System.Drawing.Size(270, 71);
            this.gbShipping.TabIndex = 303;
            this.gbShipping.TabStop = false;
            this.gbShipping.Text = "Shipping*";
            this.gbShipping.Click += new System.EventHandler(this.gbShipping_Click);
            // 
            // cbIntlStd
            // 
            this.cbIntlStd.AutoSize = true;
            this.cbIntlStd.Location = new System.Drawing.Point(96, 43);
            this.cbIntlStd.Name = "cbIntlStd";
            this.cbIntlStd.Size = new System.Drawing.Size(61, 17);
            this.cbIntlStd.TabIndex = 302;
            this.cbIntlStd.Text = "Int\'l Std";
            this.cbIntlStd.UseVisualStyleBackColor = true;
            // 
            // cb1dDom
            // 
            this.cb1dDom.AutoSize = true;
            this.cb1dDom.Location = new System.Drawing.Point(10, 43);
            this.cb1dDom.Name = "cb1dDom";
            this.cb1dDom.Size = new System.Drawing.Size(77, 17);
            this.cb1dDom.TabIndex = 301;
            this.cb1dDom.Text = "1 day Dom";
            this.cb1dDom.UseVisualStyleBackColor = true;
            // 
            // cb2dDom
            // 
            this.cb2dDom.AutoSize = true;
            this.cb2dDom.Location = new System.Drawing.Point(164, 21);
            this.cb2dDom.Name = "cb2dDom";
            this.cb2dDom.Size = new System.Drawing.Size(77, 17);
            this.cb2dDom.TabIndex = 300;
            this.cb2dDom.Text = "2 day Dom";
            this.cb2dDom.UseVisualStyleBackColor = true;
            // 
            // cbDomExp
            // 
            this.cbDomExp.AutoSize = true;
            this.cbDomExp.Location = new System.Drawing.Point(86, 21);
            this.cbDomExp.Name = "cbDomExp";
            this.cbDomExp.Size = new System.Drawing.Size(69, 17);
            this.cbDomExp.TabIndex = 299;
            this.cbDomExp.Text = "Dom Exp";
            this.cbDomExp.UseVisualStyleBackColor = true;
            // 
            // cbIntlExp
            // 
            this.cbIntlExp.AutoSize = true;
            this.cbIntlExp.Location = new System.Drawing.Point(166, 43);
            this.cbIntlExp.Name = "cbIntlExp";
            this.cbIntlExp.Size = new System.Drawing.Size(63, 17);
            this.cbIntlExp.TabIndex = 298;
            this.cbIntlExp.Text = "Int\'l Exp";
            this.cbIntlExp.UseVisualStyleBackColor = true;
            // 
            // cbDomStd
            // 
            this.cbDomStd.AutoSize = true;
            this.cbDomStd.Location = new System.Drawing.Point(10, 21);
            this.cbDomStd.Name = "cbDomStd";
            this.cbDomStd.Size = new System.Drawing.Size(67, 17);
            this.cbDomStd.TabIndex = 15;
            this.cbDomStd.Text = "Dom Std";
            this.cbDomStd.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 127);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 195;
            this.label6.Text = "Title:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel6.Location = new System.Drawing.Point(16, 47);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(814, 2);
            this.panel6.TabIndex = 310;
            // 
            // lNotFound
            // 
            this.lNotFound.AutoSize = true;
            this.lNotFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lNotFound.Location = new System.Drawing.Point(175, 62);
            this.lNotFound.Name = "lNotFound";
            this.lNotFound.Size = new System.Drawing.Size(57, 13);
            this.lNotFound.TabIndex = 306;
            this.lNotFound.Text = "Not Found";
            this.lNotFound.Visible = false;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label92.Location = new System.Drawing.Point(13, 62);
            this.label92.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(59, 13);
            this.label92.TabIndex = 288;
            this.label92.Text = "UPC/EAN:";
            // 
            // tbPrice
            // 
            this.tbPrice.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbPrice.Location = new System.Drawing.Point(434, 92);
            this.tbPrice.MaxLength = 7;
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(63, 20);
            this.tbPrice.TabIndex = 4;
            this.tbPrice.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            this.tbPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            // 
            // tbCost
            // 
            this.tbCost.Location = new System.Drawing.Point(286, 93);
            this.tbCost.MaxLength = 7;
            this.tbCost.Name = "tbCost";
            this.tbCost.Size = new System.Drawing.Size(63, 20);
            this.tbCost.TabIndex = 3;
            this.tbCost.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            this.tbCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            // 
            // tbQty
            // 
            this.tbQty.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbQty.Location = new System.Drawing.Point(514, 57);
            this.tbQty.MaxLength = 3;
            this.tbQty.Name = "tbQty";
            this.tbQty.ReadOnly = true;
            this.tbQty.Size = new System.Drawing.Size(25, 20);
            this.tbQty.TabIndex = 0;
            this.tbQty.Text = "1";
            this.tbQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbQty.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            this.tbQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericKeyPress);
            // 
            // lbCannedText
            // 
            this.lbCannedText.FormattingEnabled = true;
            this.lbCannedText.Location = new System.Drawing.Point(696, 185);
            this.lbCannedText.Name = "lbCannedText";
            this.lbCannedText.ScrollAlwaysVisible = true;
            this.lbCannedText.Size = new System.Drawing.Size(129, 30);
            this.lbCannedText.TabIndex = 12;
            this.lbCannedText.SelectedIndexChanged += new System.EventHandler(this.lbCannedText_SelectedIndexChanged);
            // 
            // tbTitle
            // 
            this.tbTitle.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tbTitle.Location = new System.Drawing.Point(55, 124);
            this.tbTitle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.tbTitle.MaxLength = 100;
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(504, 20);
            this.tbTitle.TabIndex = 6;
            this.tbTitle.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // lblDateUpdated
            // 
            this.lblDateUpdated.AutoSize = true;
            this.lblDateUpdated.Location = new System.Drawing.Point(246, 526);
            this.lblDateUpdated.MinimumSize = new System.Drawing.Size(104, 0);
            this.lblDateUpdated.Name = "lblDateUpdated";
            this.lblDateUpdated.Size = new System.Drawing.Size(106, 13);
            this.lblDateUpdated.TabIndex = 267;
            this.lblDateUpdated.Text = "Date Last Updated:  ";
            // 
            // cbDoNotReprice
            // 
            this.cbDoNotReprice.AutoSize = true;
            this.cbDoNotReprice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbDoNotReprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDoNotReprice.Location = new System.Drawing.Point(521, 95);
            this.cbDoNotReprice.Name = "cbDoNotReprice";
            this.cbDoNotReprice.Size = new System.Drawing.Size(91, 17);
            this.cbDoNotReprice.TabIndex = 260;
            this.cbDoNotReprice.Text = "Do not reprice";
            this.cbDoNotReprice.UseVisualStyleBackColor = true;
            this.cbDoNotReprice.CheckedChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // tbPrivNotes
            // 
            this.tbPrivNotes.Location = new System.Drawing.Point(97, 496);
            this.tbPrivNotes.Margin = new System.Windows.Forms.Padding(1, 1, 3, 3);
            this.tbPrivNotes.MaxLength = 50;
            this.tbPrivNotes.Name = "tbPrivNotes";
            this.tbPrivNotes.Size = new System.Drawing.Size(550, 20);
            this.tbPrivNotes.TabIndex = 0;
            this.tbPrivNotes.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // lblDateAdded
            // 
            this.lblDateAdded.AutoSize = true;
            this.lblDateAdded.Location = new System.Drawing.Point(9, 526);
            this.lblDateAdded.Name = "lblDateAdded";
            this.lblDateAdded.Size = new System.Drawing.Size(67, 13);
            this.lblDateAdded.TabIndex = 236;
            this.lblDateAdded.Text = "Date Added:";
            // 
            // lPrice
            // 
            this.lPrice.AutoSize = true;
            this.lPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPrice.Location = new System.Drawing.Point(396, 96);
            this.lPrice.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.lPrice.Name = "lPrice";
            this.lPrice.Size = new System.Drawing.Size(34, 13);
            this.lPrice.TabIndex = 234;
            this.lPrice.Text = "Price:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(460, 61);
            this.label29.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(49, 13);
            this.label29.TabIndex = 230;
            this.label29.Text = "Quantity:";
            // 
            // tbLocn
            // 
            this.tbLocn.Location = new System.Drawing.Point(730, 93);
            this.tbLocn.Margin = new System.Windows.Forms.Padding(1, 3, 3, 2);
            this.tbLocn.MaxLength = 10;
            this.tbLocn.Name = "tbLocn";
            this.tbLocn.Size = new System.Drawing.Size(95, 20);
            this.tbLocn.TabIndex = 5;
            this.tbLocn.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(656, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 194;
            this.label5.Text = "SKU:";
            // 
            // cannedTextTab
            // 
            this.cannedTextTab.BackColor = System.Drawing.SystemColors.Window;
            this.cannedTextTab.Controls.Add(this.tbCannedTitle18);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle17);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle16);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc18);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc16);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc17);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle15);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle14);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle13);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle12);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle11);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc15);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc12);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc13);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc14);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc11);
            this.cannedTextTab.Controls.Add(this.label187);
            this.cannedTextTab.Controls.Add(this.label171);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle10);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle9);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle8);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle7);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle6);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc10);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc7);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc8);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc9);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc6);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle5);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle4);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle3);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle2);
            this.cannedTextTab.Controls.Add(this.tbCannedTitle1);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc5);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc2);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc3);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc4);
            this.cannedTextTab.Controls.Add(this.tbCannedDesc1);
            this.cannedTextTab.Location = new System.Drawing.Point(4, 44);
            this.cannedTextTab.Name = "cannedTextTab";
            this.cannedTextTab.Size = new System.Drawing.Size(865, 550);
            this.cannedTextTab.TabIndex = 7;
            this.cannedTextTab.Text = " Canned Text  ";
            this.cannedTextTab.ToolTipText = "Canned text for use while entering books into the database";
            this.cannedTextTab.UseVisualStyleBackColor = true;
            // 
            // tbCannedTitle18
            // 
            this.tbCannedTitle18.Location = new System.Drawing.Point(26, 508);
            this.tbCannedTitle18.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbCannedTitle18.MaxLength = 20;
            this.tbCannedTitle18.Name = "tbCannedTitle18";
            this.tbCannedTitle18.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle18.TabIndex = 55;
            this.tbCannedTitle18.Text = "Repl w/ title";
            this.tbCannedTitle18.Leave += new System.EventHandler(this.tbCannedTitle18_Leave);
            // 
            // tbCannedTitle17
            // 
            this.tbCannedTitle17.Location = new System.Drawing.Point(26, 480);
            this.tbCannedTitle17.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbCannedTitle17.MaxLength = 20;
            this.tbCannedTitle17.Name = "tbCannedTitle17";
            this.tbCannedTitle17.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle17.TabIndex = 53;
            this.tbCannedTitle17.Text = "Repl w/ title";
            this.tbCannedTitle17.Leave += new System.EventHandler(this.tbCannedTitle17_Leave);
            // 
            // tbCannedTitle16
            // 
            this.tbCannedTitle16.Location = new System.Drawing.Point(26, 452);
            this.tbCannedTitle16.Margin = new System.Windows.Forms.Padding(1, 3, 3, 1);
            this.tbCannedTitle16.MaxLength = 20;
            this.tbCannedTitle16.Name = "tbCannedTitle16";
            this.tbCannedTitle16.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle16.TabIndex = 51;
            this.tbCannedTitle16.Text = "Repl w/ title";
            this.tbCannedTitle16.Leave += new System.EventHandler(this.tbCannedTitle16_Leave);
            // 
            // tbCannedDesc18
            // 
            this.tbCannedDesc18.Location = new System.Drawing.Point(162, 508);
            this.tbCannedDesc18.MaxLength = 100;
            this.tbCannedDesc18.Name = "tbCannedDesc18";
            this.tbCannedDesc18.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc18.TabIndex = 56;
            // 
            // tbCannedDesc16
            // 
            this.tbCannedDesc16.Location = new System.Drawing.Point(162, 452);
            this.tbCannedDesc16.MaxLength = 100;
            this.tbCannedDesc16.Name = "tbCannedDesc16";
            this.tbCannedDesc16.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc16.TabIndex = 52;
            // 
            // tbCannedDesc17
            // 
            this.tbCannedDesc17.Location = new System.Drawing.Point(162, 480);
            this.tbCannedDesc17.MaxLength = 100;
            this.tbCannedDesc17.Name = "tbCannedDesc17";
            this.tbCannedDesc17.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc17.TabIndex = 54;
            // 
            // tbCannedTitle15
            // 
            this.tbCannedTitle15.Location = new System.Drawing.Point(26, 424);
            this.tbCannedTitle15.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbCannedTitle15.MaxLength = 20;
            this.tbCannedTitle15.Name = "tbCannedTitle15";
            this.tbCannedTitle15.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle15.TabIndex = 49;
            this.tbCannedTitle15.Text = "Repl w/ title";
            this.tbCannedTitle15.Leave += new System.EventHandler(this.tbCannedTitle15_Leave);
            // 
            // tbCannedTitle14
            // 
            this.tbCannedTitle14.Location = new System.Drawing.Point(26, 396);
            this.tbCannedTitle14.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbCannedTitle14.MaxLength = 20;
            this.tbCannedTitle14.Name = "tbCannedTitle14";
            this.tbCannedTitle14.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle14.TabIndex = 47;
            this.tbCannedTitle14.Text = "Repl w/ title";
            this.tbCannedTitle14.Leave += new System.EventHandler(this.tbCannedTitle14_Leave);
            // 
            // tbCannedTitle13
            // 
            this.tbCannedTitle13.Location = new System.Drawing.Point(26, 368);
            this.tbCannedTitle13.Margin = new System.Windows.Forms.Padding(1, 3, 3, 1);
            this.tbCannedTitle13.MaxLength = 20;
            this.tbCannedTitle13.Name = "tbCannedTitle13";
            this.tbCannedTitle13.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle13.TabIndex = 45;
            this.tbCannedTitle13.Text = "Repl w/ title";
            this.tbCannedTitle13.Leave += new System.EventHandler(this.tbCannedTitle13_Leave);
            // 
            // tbCannedTitle12
            // 
            this.tbCannedTitle12.Location = new System.Drawing.Point(26, 340);
            this.tbCannedTitle12.Margin = new System.Windows.Forms.Padding(1, 3, 3, 1);
            this.tbCannedTitle12.MaxLength = 20;
            this.tbCannedTitle12.Name = "tbCannedTitle12";
            this.tbCannedTitle12.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle12.TabIndex = 43;
            this.tbCannedTitle12.Text = "Repl w/ title";
            this.tbCannedTitle12.Leave += new System.EventHandler(this.tbCannedTitle12_Leave);
            // 
            // tbCannedTitle11
            // 
            this.tbCannedTitle11.Location = new System.Drawing.Point(26, 312);
            this.tbCannedTitle11.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbCannedTitle11.MaxLength = 20;
            this.tbCannedTitle11.Name = "tbCannedTitle11";
            this.tbCannedTitle11.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle11.TabIndex = 41;
            this.tbCannedTitle11.Text = "Repl w/ title";
            this.tbCannedTitle11.Leave += new System.EventHandler(this.tbCannedTitle11_Leave);
            // 
            // tbCannedDesc15
            // 
            this.tbCannedDesc15.Location = new System.Drawing.Point(162, 424);
            this.tbCannedDesc15.MaxLength = 100;
            this.tbCannedDesc15.Name = "tbCannedDesc15";
            this.tbCannedDesc15.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc15.TabIndex = 50;
            // 
            // tbCannedDesc12
            // 
            this.tbCannedDesc12.Location = new System.Drawing.Point(162, 340);
            this.tbCannedDesc12.MaxLength = 100;
            this.tbCannedDesc12.Name = "tbCannedDesc12";
            this.tbCannedDesc12.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc12.TabIndex = 44;
            // 
            // tbCannedDesc13
            // 
            this.tbCannedDesc13.Location = new System.Drawing.Point(162, 368);
            this.tbCannedDesc13.MaxLength = 100;
            this.tbCannedDesc13.Name = "tbCannedDesc13";
            this.tbCannedDesc13.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc13.TabIndex = 46;
            // 
            // tbCannedDesc14
            // 
            this.tbCannedDesc14.Location = new System.Drawing.Point(162, 396);
            this.tbCannedDesc14.MaxLength = 100;
            this.tbCannedDesc14.Name = "tbCannedDesc14";
            this.tbCannedDesc14.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc14.TabIndex = 48;
            // 
            // tbCannedDesc11
            // 
            this.tbCannedDesc11.Location = new System.Drawing.Point(162, 312);
            this.tbCannedDesc11.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.tbCannedDesc11.MaxLength = 100;
            this.tbCannedDesc11.Name = "tbCannedDesc11";
            this.tbCannedDesc11.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc11.TabIndex = 42;
            // 
            // label187
            // 
            this.label187.AutoSize = true;
            this.label187.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label187.Location = new System.Drawing.Point(339, 10);
            this.label187.Name = "label187";
            this.label187.Size = new System.Drawing.Size(251, 13);
            this.label187.TabIndex = 40;
            this.label187.Text = "Canned text (up to 200 characters per box)";
            // 
            // label171
            // 
            this.label171.AutoSize = true;
            this.label171.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label171.Location = new System.Drawing.Point(57, 10);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(32, 13);
            this.label171.TabIndex = 39;
            this.label171.Text = "Title";
            // 
            // tbCannedTitle10
            // 
            this.tbCannedTitle10.Location = new System.Drawing.Point(26, 284);
            this.tbCannedTitle10.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbCannedTitle10.MaxLength = 20;
            this.tbCannedTitle10.Name = "tbCannedTitle10";
            this.tbCannedTitle10.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle10.TabIndex = 29;
            this.tbCannedTitle10.Text = "Repl w/ title";
            this.tbCannedTitle10.Leave += new System.EventHandler(this.tbCannedTitle10_Leave);
            // 
            // tbCannedTitle9
            // 
            this.tbCannedTitle9.Location = new System.Drawing.Point(26, 256);
            this.tbCannedTitle9.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbCannedTitle9.MaxLength = 20;
            this.tbCannedTitle9.Name = "tbCannedTitle9";
            this.tbCannedTitle9.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle9.TabIndex = 27;
            this.tbCannedTitle9.Text = "Repl w/ title";
            this.tbCannedTitle9.Leave += new System.EventHandler(this.tbCannedTitle9_Leave);
            // 
            // tbCannedTitle8
            // 
            this.tbCannedTitle8.Location = new System.Drawing.Point(26, 228);
            this.tbCannedTitle8.Margin = new System.Windows.Forms.Padding(1, 3, 3, 1);
            this.tbCannedTitle8.MaxLength = 20;
            this.tbCannedTitle8.Name = "tbCannedTitle8";
            this.tbCannedTitle8.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle8.TabIndex = 25;
            this.tbCannedTitle8.Text = "Repl w/ title";
            this.tbCannedTitle8.Leave += new System.EventHandler(this.tbCannedTitle8_Leave);
            // 
            // tbCannedTitle7
            // 
            this.tbCannedTitle7.Location = new System.Drawing.Point(26, 200);
            this.tbCannedTitle7.Margin = new System.Windows.Forms.Padding(1, 3, 3, 1);
            this.tbCannedTitle7.MaxLength = 20;
            this.tbCannedTitle7.Name = "tbCannedTitle7";
            this.tbCannedTitle7.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle7.TabIndex = 23;
            this.tbCannedTitle7.Text = "Repl w/ title";
            this.tbCannedTitle7.Leave += new System.EventHandler(this.tbCannedTitle7_Leave);
            // 
            // tbCannedTitle6
            // 
            this.tbCannedTitle6.Location = new System.Drawing.Point(26, 172);
            this.tbCannedTitle6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbCannedTitle6.MaxLength = 20;
            this.tbCannedTitle6.Name = "tbCannedTitle6";
            this.tbCannedTitle6.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle6.TabIndex = 21;
            this.tbCannedTitle6.Text = "Repl w/ title";
            this.tbCannedTitle6.Leave += new System.EventHandler(this.tbCannedTitle6_Leave);
            // 
            // tbCannedDesc10
            // 
            this.tbCannedDesc10.Location = new System.Drawing.Point(162, 284);
            this.tbCannedDesc10.MaxLength = 100;
            this.tbCannedDesc10.Name = "tbCannedDesc10";
            this.tbCannedDesc10.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc10.TabIndex = 30;
            // 
            // tbCannedDesc7
            // 
            this.tbCannedDesc7.Location = new System.Drawing.Point(162, 200);
            this.tbCannedDesc7.MaxLength = 100;
            this.tbCannedDesc7.Name = "tbCannedDesc7";
            this.tbCannedDesc7.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc7.TabIndex = 24;
            // 
            // tbCannedDesc8
            // 
            this.tbCannedDesc8.Location = new System.Drawing.Point(162, 228);
            this.tbCannedDesc8.MaxLength = 100;
            this.tbCannedDesc8.Name = "tbCannedDesc8";
            this.tbCannedDesc8.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc8.TabIndex = 26;
            // 
            // tbCannedDesc9
            // 
            this.tbCannedDesc9.Location = new System.Drawing.Point(162, 256);
            this.tbCannedDesc9.MaxLength = 100;
            this.tbCannedDesc9.Name = "tbCannedDesc9";
            this.tbCannedDesc9.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc9.TabIndex = 28;
            // 
            // tbCannedDesc6
            // 
            this.tbCannedDesc6.Location = new System.Drawing.Point(162, 172);
            this.tbCannedDesc6.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.tbCannedDesc6.MaxLength = 100;
            this.tbCannedDesc6.Name = "tbCannedDesc6";
            this.tbCannedDesc6.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc6.TabIndex = 22;
            // 
            // tbCannedTitle5
            // 
            this.tbCannedTitle5.Location = new System.Drawing.Point(26, 144);
            this.tbCannedTitle5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbCannedTitle5.MaxLength = 20;
            this.tbCannedTitle5.Name = "tbCannedTitle5";
            this.tbCannedTitle5.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle5.TabIndex = 19;
            this.tbCannedTitle5.Text = "Repl w/ title";
            this.tbCannedTitle5.Leave += new System.EventHandler(this.tbCannedTitle5_Leave);
            // 
            // tbCannedTitle4
            // 
            this.tbCannedTitle4.Location = new System.Drawing.Point(26, 116);
            this.tbCannedTitle4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbCannedTitle4.MaxLength = 20;
            this.tbCannedTitle4.Name = "tbCannedTitle4";
            this.tbCannedTitle4.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle4.TabIndex = 17;
            this.tbCannedTitle4.Text = "Repl w/ title";
            this.tbCannedTitle4.Leave += new System.EventHandler(this.tbCannedTitle4_Leave);
            // 
            // tbCannedTitle3
            // 
            this.tbCannedTitle3.Location = new System.Drawing.Point(26, 88);
            this.tbCannedTitle3.Margin = new System.Windows.Forms.Padding(1, 3, 3, 1);
            this.tbCannedTitle3.MaxLength = 20;
            this.tbCannedTitle3.Name = "tbCannedTitle3";
            this.tbCannedTitle3.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle3.TabIndex = 15;
            this.tbCannedTitle3.Text = "Repl w/ title";
            this.tbCannedTitle3.Leave += new System.EventHandler(this.tbCannedTitle3_Leave);
            // 
            // tbCannedTitle2
            // 
            this.tbCannedTitle2.Location = new System.Drawing.Point(26, 60);
            this.tbCannedTitle2.Margin = new System.Windows.Forms.Padding(1, 3, 3, 1);
            this.tbCannedTitle2.MaxLength = 20;
            this.tbCannedTitle2.Name = "tbCannedTitle2";
            this.tbCannedTitle2.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle2.TabIndex = 13;
            this.tbCannedTitle2.Text = "Repl w/ title";
            this.tbCannedTitle2.Leave += new System.EventHandler(this.tbCannedTitle2_Leave);
            // 
            // tbCannedTitle1
            // 
            this.tbCannedTitle1.Location = new System.Drawing.Point(26, 32);
            this.tbCannedTitle1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.tbCannedTitle1.MaxLength = 20;
            this.tbCannedTitle1.Name = "tbCannedTitle1";
            this.tbCannedTitle1.Size = new System.Drawing.Size(120, 20);
            this.tbCannedTitle1.TabIndex = 11;
            this.tbCannedTitle1.Text = "Repl w/ title";
            this.tbCannedTitle1.Leave += new System.EventHandler(this.tbCannedTitle1_Leave);
            // 
            // tbCannedDesc5
            // 
            this.tbCannedDesc5.Location = new System.Drawing.Point(162, 144);
            this.tbCannedDesc5.MaxLength = 100;
            this.tbCannedDesc5.Name = "tbCannedDesc5";
            this.tbCannedDesc5.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc5.TabIndex = 20;
            // 
            // tbCannedDesc2
            // 
            this.tbCannedDesc2.Location = new System.Drawing.Point(162, 60);
            this.tbCannedDesc2.MaxLength = 100;
            this.tbCannedDesc2.Name = "tbCannedDesc2";
            this.tbCannedDesc2.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc2.TabIndex = 14;
            // 
            // tbCannedDesc3
            // 
            this.tbCannedDesc3.Location = new System.Drawing.Point(162, 88);
            this.tbCannedDesc3.MaxLength = 100;
            this.tbCannedDesc3.Name = "tbCannedDesc3";
            this.tbCannedDesc3.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc3.TabIndex = 16;
            // 
            // tbCannedDesc4
            // 
            this.tbCannedDesc4.Location = new System.Drawing.Point(162, 116);
            this.tbCannedDesc4.MaxLength = 100;
            this.tbCannedDesc4.Name = "tbCannedDesc4";
            this.tbCannedDesc4.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc4.TabIndex = 18;
            // 
            // tbCannedDesc1
            // 
            this.tbCannedDesc1.Location = new System.Drawing.Point(162, 32);
            this.tbCannedDesc1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.tbCannedDesc1.MaxLength = 100;
            this.tbCannedDesc1.Name = "tbCannedDesc1";
            this.tbCannedDesc1.Size = new System.Drawing.Size(668, 20);
            this.tbCannedDesc1.TabIndex = 12;
            // 
            // uploadTab
            // 
            this.uploadTab.BackColor = System.Drawing.SystemColors.Window;
            this.uploadTab.Controls.Add(this.bVerifyAZUploads);
            this.uploadTab.Controls.Add(this.cbUploadPurgeReplace);
            this.uploadTab.Controls.Add(this.lbUploadStatus);
            this.uploadTab.Controls.Add(this.groupBox7);
            this.uploadTab.Controls.Add(this.cbUploadTest);
            this.uploadTab.Controls.Add(this.lFileWaiting);
            this.uploadTab.Controls.Add(this.bFTPUpload);
            this.uploadTab.Location = new System.Drawing.Point(4, 44);
            this.uploadTab.Name = "uploadTab";
            this.uploadTab.Padding = new System.Windows.Forms.Padding(3);
            this.uploadTab.Size = new System.Drawing.Size(865, 550);
            this.uploadTab.TabIndex = 6;
            this.uploadTab.Text = " Upload ";
            this.uploadTab.ToolTipText = "Uploading exported files to the listing services";
            this.uploadTab.UseVisualStyleBackColor = true;
            // 
            // bVerifyAZUploads
            // 
            this.bVerifyAZUploads.BackColor = System.Drawing.SystemColors.Desktop;
            this.bVerifyAZUploads.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bVerifyAZUploads.FlatAppearance.BorderSize = 0;
            this.bVerifyAZUploads.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bVerifyAZUploads.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bVerifyAZUploads.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bVerifyAZUploads.Location = new System.Drawing.Point(674, 205);
            this.bVerifyAZUploads.Name = "bVerifyAZUploads";
            this.bVerifyAZUploads.Size = new System.Drawing.Size(128, 25);
            this.bVerifyAZUploads.TabIndex = 140;
            this.bVerifyAZUploads.Text = "Verify Amazon uploads";
            this.bVerifyAZUploads.UseVisualStyleBackColor = false;
            this.bVerifyAZUploads.Click += new System.EventHandler(this.bVerifyAZUploads_Click);
            // 
            // lbUploadStatus
            // 
            this.lbUploadStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbUploadStatus.FormattingEnabled = true;
            this.lbUploadStatus.HorizontalScrollbar = true;
            this.lbUploadStatus.Location = new System.Drawing.Point(24, 15);
            this.lbUploadStatus.Name = "lbUploadStatus";
            this.lbUploadStatus.Size = new System.Drawing.Size(758, 173);
            this.lbUploadStatus.TabIndex = 136;
            // 
            // lFileWaiting
            // 
            this.lFileWaiting.AutoSize = true;
            this.lFileWaiting.Location = new System.Drawing.Point(390, 212);
            this.lFileWaiting.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.lFileWaiting.Name = "lFileWaiting";
            this.lFileWaiting.Size = new System.Drawing.Size(152, 13);
            this.lFileWaiting.TabIndex = 8;
            this.lFileWaiting.Text = "NO file waiting to be uploaded.";
            // 
            // bFTPUpload
            // 
            this.bFTPUpload.BackColor = System.Drawing.SystemColors.Desktop;
            this.bFTPUpload.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bFTPUpload.FlatAppearance.BorderSize = 0;
            this.bFTPUpload.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bFTPUpload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bFTPUpload.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bFTPUpload.Location = new System.Drawing.Point(561, 205);
            this.bFTPUpload.Name = "bFTPUpload";
            this.bFTPUpload.Size = new System.Drawing.Size(68, 25);
            this.bFTPUpload.TabIndex = 7;
            this.bFTPUpload.Text = "Upload";
            this.bFTPUpload.UseVisualStyleBackColor = false;
            this.bFTPUpload.Click += new System.EventHandler(this.bFTPUpload_Click);
            // 
            // accountingTab
            // 
            this.accountingTab.BackColor = System.Drawing.SystemColors.Window;
            this.accountingTab.Controls.Add(this.panel4);
            this.accountingTab.Controls.Add(this.groupBox18);
            this.accountingTab.Controls.Add(this.groupBox24);
            this.accountingTab.Controls.Add(this.groupBox20);
            this.accountingTab.Location = new System.Drawing.Point(4, 44);
            this.accountingTab.Name = "accountingTab";
            this.accountingTab.Size = new System.Drawing.Size(865, 550);
            this.accountingTab.TabIndex = 5;
            this.accountingTab.Text = " Accounting ";
            this.accountingTab.ToolTipText = "Statistics and accounting data";
            this.accountingTab.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel4.Location = new System.Drawing.Point(27, 310);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(751, 2);
            this.panel4.TabIndex = 10;
            // 
            // groupBox18
            // 
            this.groupBox18.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox18.Controls.Add(this.lItemsPurged);
            this.groupBox18.Controls.Add(this.bDeleteByYear);
            this.groupBox18.Controls.Add(this.tbPurgeDate);
            this.groupBox18.Controls.Add(this.cbDeleteByYear);
            this.groupBox18.Location = new System.Drawing.Point(27, 335);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(751, 98);
            this.groupBox18.TabIndex = 9;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Prune database";
            // 
            // lItemsPurged
            // 
            this.lItemsPurged.AutoSize = true;
            this.lItemsPurged.Location = new System.Drawing.Point(526, 42);
            this.lItemsPurged.Name = "lItemsPurged";
            this.lItemsPurged.Size = new System.Drawing.Size(146, 13);
            this.lItemsPurged.TabIndex = 3;
            this.lItemsPurged.Text = "0 items purged from database";
            this.lItemsPurged.Visible = false;
            // 
            // bDeleteByYear
            // 
            this.bDeleteByYear.BackColor = System.Drawing.SystemColors.Desktop;
            this.bDeleteByYear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bDeleteByYear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bDeleteByYear.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bDeleteByYear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bDeleteByYear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bDeleteByYear.Location = new System.Drawing.Point(376, 37);
            this.bDeleteByYear.Name = "bDeleteByYear";
            this.bDeleteByYear.Size = new System.Drawing.Size(75, 23);
            this.bDeleteByYear.TabIndex = 2;
            this.bDeleteByYear.Text = "Delete";
            this.bDeleteByYear.UseVisualStyleBackColor = false;
            this.bDeleteByYear.Click += new System.EventHandler(this.bDeleteByYear_Click);
            // 
            // groupBox24
            // 
            this.groupBox24.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox24.Controls.Add(this.lblCOG2);
            this.groupBox24.Controls.Add(this.lblCOG3);
            this.groupBox24.Controls.Add(this.lblCOG4);
            this.groupBox24.Controls.Add(this.lblTotalCostofGoods);
            this.groupBox24.Controls.Add(this.lblCOG1);
            this.groupBox24.Controls.Add(this.label170);
            this.groupBox24.Controls.Add(this.label169);
            this.groupBox24.Controls.Add(this.label36);
            this.groupBox24.Controls.Add(this.lbAcctgYear);
            this.groupBox24.Controls.Add(this.lblQtr2Sales);
            this.groupBox24.Controls.Add(this.lblQtr3Sales);
            this.groupBox24.Controls.Add(this.lblQtr4Sales);
            this.groupBox24.Controls.Add(this.lblTotalYTD);
            this.groupBox24.Controls.Add(this.lblQtr1Sales);
            this.groupBox24.Location = new System.Drawing.Point(27, 26);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(439, 260);
            this.groupBox24.TabIndex = 8;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Sales and Purchases";
            // 
            // lblCOG2
            // 
            this.lblCOG2.AutoSize = true;
            this.lblCOG2.Location = new System.Drawing.Point(258, 123);
            this.lblCOG2.Name = "lblCOG2";
            this.lblCOG2.Size = new System.Drawing.Size(45, 13);
            this.lblCOG2.TabIndex = 13;
            this.lblCOG2.Text = "2nd Qtr:";
            // 
            // lblCOG3
            // 
            this.lblCOG3.AutoSize = true;
            this.lblCOG3.Location = new System.Drawing.Point(258, 148);
            this.lblCOG3.Name = "lblCOG3";
            this.lblCOG3.Size = new System.Drawing.Size(42, 13);
            this.lblCOG3.TabIndex = 12;
            this.lblCOG3.Text = "3rd Qtr:";
            // 
            // lblCOG4
            // 
            this.lblCOG4.AutoSize = true;
            this.lblCOG4.Location = new System.Drawing.Point(258, 173);
            this.lblCOG4.Name = "lblCOG4";
            this.lblCOG4.Size = new System.Drawing.Size(42, 13);
            this.lblCOG4.TabIndex = 11;
            this.lblCOG4.Text = "4th Qtr:";
            // 
            // lblTotalCostofGoods
            // 
            this.lblTotalCostofGoods.AutoSize = true;
            this.lblTotalCostofGoods.Location = new System.Drawing.Point(258, 198);
            this.lblTotalCostofGoods.Name = "lblTotalCostofGoods";
            this.lblTotalCostofGoods.Size = new System.Drawing.Size(70, 13);
            this.lblTotalCostofGoods.TabIndex = 10;
            this.lblTotalCostofGoods.Text = "Total to date:";
            // 
            // lblCOG1
            // 
            this.lblCOG1.AutoSize = true;
            this.lblCOG1.Location = new System.Drawing.Point(258, 98);
            this.lblCOG1.Name = "lblCOG1";
            this.lblCOG1.Size = new System.Drawing.Size(41, 13);
            this.lblCOG1.TabIndex = 9;
            this.lblCOG1.Text = "1st Qtr:";
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label170.Location = new System.Drawing.Point(258, 76);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(70, 13);
            this.label170.TabIndex = 8;
            this.label170.Text = "Purchases:";
            // 
            // label169
            // 
            this.label169.AutoSize = true;
            this.label169.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label169.Location = new System.Drawing.Point(54, 76);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(42, 13);
            this.label169.TabIndex = 7;
            this.label169.Text = "Sales:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(51, 47);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(48, 13);
            this.label36.TabIndex = 6;
            this.label36.Text = "For year:";
            // 
            // lblQtr2Sales
            // 
            this.lblQtr2Sales.AutoSize = true;
            this.lblQtr2Sales.Location = new System.Drawing.Point(51, 123);
            this.lblQtr2Sales.Name = "lblQtr2Sales";
            this.lblQtr2Sales.Size = new System.Drawing.Size(45, 13);
            this.lblQtr2Sales.TabIndex = 4;
            this.lblQtr2Sales.Text = "2nd Qtr:";
            // 
            // lblQtr3Sales
            // 
            this.lblQtr3Sales.AutoSize = true;
            this.lblQtr3Sales.Location = new System.Drawing.Point(51, 148);
            this.lblQtr3Sales.Name = "lblQtr3Sales";
            this.lblQtr3Sales.Size = new System.Drawing.Size(42, 13);
            this.lblQtr3Sales.TabIndex = 3;
            this.lblQtr3Sales.Text = "3rd Qtr:";
            // 
            // lblQtr4Sales
            // 
            this.lblQtr4Sales.AutoSize = true;
            this.lblQtr4Sales.Location = new System.Drawing.Point(51, 173);
            this.lblQtr4Sales.Name = "lblQtr4Sales";
            this.lblQtr4Sales.Size = new System.Drawing.Size(42, 13);
            this.lblQtr4Sales.TabIndex = 2;
            this.lblQtr4Sales.Text = "4th Qtr:";
            // 
            // lblTotalYTD
            // 
            this.lblTotalYTD.AutoSize = true;
            this.lblTotalYTD.Location = new System.Drawing.Point(51, 198);
            this.lblTotalYTD.Name = "lblTotalYTD";
            this.lblTotalYTD.Size = new System.Drawing.Size(70, 13);
            this.lblTotalYTD.TabIndex = 1;
            this.lblTotalYTD.Text = "Total to date:";
            // 
            // lblQtr1Sales
            // 
            this.lblQtr1Sales.AutoSize = true;
            this.lblQtr1Sales.Location = new System.Drawing.Point(51, 98);
            this.lblQtr1Sales.Name = "lblQtr1Sales";
            this.lblQtr1Sales.Size = new System.Drawing.Size(41, 13);
            this.lblQtr1Sales.TabIndex = 0;
            this.lblQtr1Sales.Text = "1st Qtr:";
            // 
            // groupBox20
            // 
            this.groupBox20.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox20.Controls.Add(this.lblPendingCount);
            this.groupBox20.Controls.Add(this.lblTotalValue);
            this.groupBox20.Controls.Add(this.lblTotalCost);
            this.groupBox20.Controls.Add(this.lblSoldCount);
            this.groupBox20.Controls.Add(this.lblHoldCount);
            this.groupBox20.Controls.Add(this.lblTotalCount);
            this.groupBox20.Controls.Add(this.lblSaleCount);
            this.groupBox20.Location = new System.Drawing.Point(493, 26);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(285, 260);
            this.groupBox20.TabIndex = 7;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Database Statistics";
            // 
            // lblPendingCount
            // 
            this.lblPendingCount.AutoSize = true;
            this.lblPendingCount.Location = new System.Drawing.Point(49, 121);
            this.lblPendingCount.Name = "lblPendingCount";
            this.lblPendingCount.Size = new System.Drawing.Size(46, 13);
            this.lblPendingCount.TabIndex = 7;
            this.lblPendingCount.Text = "Pending";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Location = new System.Drawing.Point(49, 202);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(108, 13);
            this.lblTotalValue.TabIndex = 6;
            this.lblTotalValue.Text = "Total Inventory Value";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(49, 175);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(102, 13);
            this.lblTotalCost.TabIndex = 5;
            this.lblTotalCost.Text = "Total Inventory Cost";
            // 
            // lblSoldCount
            // 
            this.lblSoldCount.AutoSize = true;
            this.lblSoldCount.Location = new System.Drawing.Point(49, 40);
            this.lblSoldCount.Name = "lblSoldCount";
            this.lblSoldCount.Size = new System.Drawing.Size(28, 13);
            this.lblSoldCount.TabIndex = 3;
            this.lblSoldCount.Text = "Sold";
            // 
            // lblHoldCount
            // 
            this.lblHoldCount.AutoSize = true;
            this.lblHoldCount.Location = new System.Drawing.Point(49, 94);
            this.lblHoldCount.Name = "lblHoldCount";
            this.lblHoldCount.Size = new System.Drawing.Size(46, 13);
            this.lblHoldCount.TabIndex = 2;
            this.lblHoldCount.Text = "On Hold";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(49, 148);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(89, 13);
            this.lblTotalCount.TabIndex = 1;
            this.lblTotalCount.Text = "Total in Inventory";
            // 
            // lblSaleCount
            // 
            this.lblSaleCount.AutoSize = true;
            this.lblSaleCount.Location = new System.Drawing.Point(49, 67);
            this.lblSaleCount.Name = "lblSaleCount";
            this.lblSaleCount.Size = new System.Drawing.Size(46, 13);
            this.lblSaleCount.TabIndex = 0;
            this.lblSaleCount.Text = "For Sale";
            // 
            // alterPricesTab
            // 
            this.alterPricesTab.BackColor = System.Drawing.SystemColors.Window;
            this.alterPricesTab.Controls.Add(this.tabControl3);
            this.alterPricesTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alterPricesTab.Location = new System.Drawing.Point(4, 44);
            this.alterPricesTab.Name = "alterPricesTab";
            this.alterPricesTab.Padding = new System.Windows.Forms.Padding(3);
            this.alterPricesTab.Size = new System.Drawing.Size(865, 550);
            this.alterPricesTab.TabIndex = 3;
            this.alterPricesTab.Text = " Mass Changes  ";
            this.alterPricesTab.ToolTipText = "For making mass changes to the inventory";
            this.alterPricesTab.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage3);
            this.tabControl3.Controls.Add(this.tabPage4);
            this.tabControl3.Location = new System.Drawing.Point(3, 3);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(856, 541);
            this.tabControl3.TabIndex = 47;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage3.Controls.Add(this.groupBox41);
            this.tabPage3.Controls.Add(this.groupBox22);
            this.tabPage3.Controls.Add(this.groupBox23);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(848, 515);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Prices and Status";
            // 
            // groupBox41
            // 
            this.groupBox41.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox41.Controls.Add(this.bConvertToUPC13);
            this.groupBox41.Location = new System.Drawing.Point(535, 284);
            this.groupBox41.Name = "groupBox41";
            this.groupBox41.Size = new System.Drawing.Size(286, 79);
            this.groupBox41.TabIndex = 50;
            this.groupBox41.TabStop = false;
            this.groupBox41.Text = "Miscellaneous mass changes";
            this.groupBox41.Visible = false;
            // 
            // groupBox22
            // 
            this.groupBox22.BackColor = System.Drawing.Color.Transparent;
            this.groupBox22.Controls.Add(this.groupBox3);
            this.groupBox22.Controls.Add(this.bReprice);
            this.groupBox22.Controls.Add(this.groupBox5);
            this.groupBox22.Controls.Add(this.groupBox4);
            this.groupBox22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox22.Location = new System.Drawing.Point(6, 25);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(513, 338);
            this.groupBox22.TabIndex = 48;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Change Prices";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox3.Controls.Add(this.rbAbsolute);
            this.groupBox3.Controls.Add(this.rbDecrease);
            this.groupBox3.Controls.Add(this.rbIncrease);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(16, 21);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(418, 59);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Type of change?";
            // 
            // rbAbsolute
            // 
            this.rbAbsolute.AutoSize = true;
            this.rbAbsolute.Location = new System.Drawing.Point(258, 24);
            this.rbAbsolute.Name = "rbAbsolute";
            this.rbAbsolute.Size = new System.Drawing.Size(104, 17);
            this.rbAbsolute.TabIndex = 27;
            this.rbAbsolute.Text = "Absolute amount";
            this.rbAbsolute.CheckedChanged += new System.EventHandler(this.rbAbsolute_CheckedChanged);
            // 
            // rbDecrease
            // 
            this.rbDecrease.AutoSize = true;
            this.rbDecrease.Location = new System.Drawing.Point(135, 24);
            this.rbDecrease.Name = "rbDecrease";
            this.rbDecrease.Size = new System.Drawing.Size(103, 17);
            this.rbDecrease.TabIndex = 26;
            this.rbDecrease.Text = "Decrease Prices";
            // 
            // rbIncrease
            // 
            this.rbIncrease.AutoSize = true;
            this.rbIncrease.Location = new System.Drawing.Point(20, 24);
            this.rbIncrease.Name = "rbIncrease";
            this.rbIncrease.Size = new System.Drawing.Size(98, 17);
            this.rbIncrease.TabIndex = 43;
            this.rbIncrease.Text = "Increase Prices";
            // 
            // bReprice
            // 
            this.bReprice.BackColor = System.Drawing.SystemColors.Desktop;
            this.bReprice.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.bReprice.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bReprice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bReprice.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bReprice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bReprice.Location = new System.Drawing.Point(414, 259);
            this.bReprice.Name = "bReprice";
            this.bReprice.Size = new System.Drawing.Size(79, 25);
            this.bReprice.TabIndex = 23;
            this.bReprice.Text = "Change";
            this.bReprice.UseVisualStyleBackColor = false;
            this.bReprice.Click += new System.EventHandler(this.bReprice_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox5.Controls.Add(this.tbAmount);
            this.groupBox5.Controls.Add(this.rbPercentage);
            this.groupBox5.Controls.Add(this.rbAmount);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(16, 242);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(375, 59);
            this.groupBox5.TabIndex = 42;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Change by?";
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(228, 26);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(73, 20);
            this.tbAmount.TabIndex = 39;
            this.tbAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            // 
            // rbPercentage
            // 
            this.rbPercentage.AutoSize = true;
            this.rbPercentage.Location = new System.Drawing.Point(118, 26);
            this.rbPercentage.Name = "rbPercentage";
            this.rbPercentage.Size = new System.Drawing.Size(80, 17);
            this.rbPercentage.TabIndex = 38;
            this.rbPercentage.Text = "Percentage";
            // 
            // rbAmount
            // 
            this.rbAmount.AutoSize = true;
            this.rbAmount.Location = new System.Drawing.Point(21, 26);
            this.rbAmount.Name = "rbAmount";
            this.rbAmount.Size = new System.Drawing.Size(64, 17);
            this.rbAmount.TabIndex = 44;
            this.rbAmount.Text = " Amount";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox4.Controls.Add(this.label86);
            this.groupBox4.Controls.Add(this.tbBkNbrTo);
            this.groupBox4.Controls.Add(this.label85);
            this.groupBox4.Controls.Add(this.tbBkNbrFrom);
            this.groupBox4.Controls.Add(this.label77);
            this.groupBox4.Controls.Add(this.rbSKU);
            this.groupBox4.Controls.Add(this.lbChangePricesCat);
            this.groupBox4.Controls.Add(this.tbPriceTo);
            this.groupBox4.Controls.Add(this.tbPriceFrom);
            this.groupBox4.Controls.Add(this.rbAll);
            this.groupBox4.Controls.Add(this.rbPriceRange);
            this.groupBox4.Controls.Add(this.rbCatalog);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(16, 92);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(477, 136);
            this.groupBox4.TabIndex = 41;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Change which items?";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.Location = new System.Drawing.Point(369, 79);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(61, 13);
            this.label86.TabIndex = 48;
            this.label86.Text = "( Inclusive )";
            // 
            // tbBkNbrTo
            // 
            this.tbBkNbrTo.Location = new System.Drawing.Point(262, 76);
            this.tbBkNbrTo.Name = "tbBkNbrTo";
            this.tbBkNbrTo.Size = new System.Drawing.Size(100, 20);
            this.tbBkNbrTo.TabIndex = 47;
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(236, 79);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(23, 13);
            this.label85.TabIndex = 46;
            this.label85.Text = "To:";
            // 
            // tbBkNbrFrom
            // 
            this.tbBkNbrFrom.Location = new System.Drawing.Point(122, 76);
            this.tbBkNbrFrom.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.tbBkNbrFrom.Name = "tbBkNbrFrom";
            this.tbBkNbrFrom.Size = new System.Drawing.Size(100, 20);
            this.tbBkNbrFrom.TabIndex = 45;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(87, 79);
            this.label77.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(33, 13);
            this.label77.TabIndex = 44;
            this.label77.Text = "From:";
            // 
            // rbSKU
            // 
            this.rbSKU.AutoSize = true;
            this.rbSKU.Location = new System.Drawing.Point(20, 76);
            this.rbSKU.Name = "rbSKU";
            this.rbSKU.Size = new System.Drawing.Size(52, 17);
            this.rbSKU.TabIndex = 43;
            this.rbSKU.Text = "SKUs";
            // 
            // tbPriceTo
            // 
            this.tbPriceTo.Location = new System.Drawing.Point(252, 49);
            this.tbPriceTo.Name = "tbPriceTo";
            this.tbPriceTo.Size = new System.Drawing.Size(57, 20);
            this.tbPriceTo.TabIndex = 42;
            this.tbPriceTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            // 
            // tbPriceFrom
            // 
            this.tbPriceFrom.Location = new System.Drawing.Point(159, 48);
            this.tbPriceFrom.Name = "tbPriceFrom";
            this.tbPriceFrom.Size = new System.Drawing.Size(60, 20);
            this.tbPriceFrom.TabIndex = 41;
            this.tbPriceFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(20, 24);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(64, 17);
            this.rbAll.TabIndex = 34;
            this.rbAll.Text = "All Items";
            // 
            // rbPriceRange
            // 
            this.rbPriceRange.AutoSize = true;
            this.rbPriceRange.Location = new System.Drawing.Point(20, 49);
            this.rbPriceRange.Name = "rbPriceRange";
            this.rbPriceRange.Size = new System.Drawing.Size(84, 17);
            this.rbPriceRange.TabIndex = 33;
            this.rbPriceRange.Text = "Price Range";
            // 
            // rbCatalog
            // 
            this.rbCatalog.AutoSize = true;
            this.rbCatalog.Location = new System.Drawing.Point(20, 101);
            this.rbCatalog.Name = "rbCatalog";
            this.rbCatalog.Size = new System.Drawing.Size(61, 17);
            this.rbCatalog.TabIndex = 32;
            this.rbCatalog.Text = "Catalog";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(226, 52);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(23, 13);
            this.label28.TabIndex = 31;
            this.label28.Text = "To:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(122, 51);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(33, 13);
            this.label27.TabIndex = 30;
            this.label27.Text = "From:";
            // 
            // groupBox23
            // 
            this.groupBox23.BackColor = System.Drawing.Color.Transparent;
            this.groupBox23.Controls.Add(this.bChangeStatus);
            this.groupBox23.Controls.Add(this.label148);
            this.groupBox23.Controls.Add(this.label143);
            this.groupBox23.Controls.Add(this.label142);
            this.groupBox23.Controls.Add(this.groupBox6);
            this.groupBox23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox23.Location = new System.Drawing.Point(535, 25);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(288, 240);
            this.groupBox23.TabIndex = 49;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Change Status ONLY";
            // 
            // bChangeStatus
            // 
            this.bChangeStatus.BackColor = System.Drawing.SystemColors.Desktop;
            this.bChangeStatus.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.bChangeStatus.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bChangeStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bChangeStatus.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bChangeStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bChangeStatus.Location = new System.Drawing.Point(164, 107);
            this.bChangeStatus.Name = "bChangeStatus";
            this.bChangeStatus.Size = new System.Drawing.Size(79, 25);
            this.bChangeStatus.TabIndex = 48;
            this.bChangeStatus.Text = "Change";
            this.bChangeStatus.UseVisualStyleBackColor = false;
            this.bChangeStatus.Click += new System.EventHandler(this.bChangeStatus_Click);
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label148.Location = new System.Drawing.Point(48, 57);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(195, 13);
            this.label148.TabIndex = 47;
            this.label148.Text = "when you click the button below.";
            // 
            // label143
            // 
            this.label143.AutoSize = true;
            this.label143.Location = new System.Drawing.Point(47, 44);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(160, 13);
            this.label143.TabIndex = 46;
            this.label143.Text = "Database Panel will be changed";
            // 
            // label142
            // 
            this.label142.AutoSize = true;
            this.label142.Location = new System.Drawing.Point(11, 31);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(192, 13);
            this.label142.TabIndex = 45;
            this.label142.Text = "NOTE: Only those items selected in the";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox6.Controls.Add(this.rbMark4Sale);
            this.groupBox6.Controls.Add(this.rbMarkHold);
            this.groupBox6.Controls.Add(this.rbMarkSold);
            this.groupBox6.Location = new System.Drawing.Point(14, 88);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(110, 115);
            this.groupBox6.TabIndex = 44;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Mark Status as:";
            // 
            // rbMark4Sale
            // 
            this.rbMark4Sale.AutoSize = true;
            this.rbMark4Sale.Location = new System.Drawing.Point(25, 73);
            this.rbMark4Sale.Name = "rbMark4Sale";
            this.rbMark4Sale.Size = new System.Drawing.Size(64, 17);
            this.rbMark4Sale.TabIndex = 7;
            this.rbMark4Sale.TabStop = true;
            this.rbMark4Sale.Text = "For Sale";
            this.rbMark4Sale.UseVisualStyleBackColor = true;
            // 
            // rbMarkHold
            // 
            this.rbMarkHold.AutoSize = true;
            this.rbMarkHold.Location = new System.Drawing.Point(25, 50);
            this.rbMarkHold.Name = "rbMarkHold";
            this.rbMarkHold.Size = new System.Drawing.Size(47, 17);
            this.rbMarkHold.TabIndex = 6;
            this.rbMarkHold.TabStop = true;
            this.rbMarkHold.Text = "Hold";
            this.rbMarkHold.UseVisualStyleBackColor = true;
            // 
            // rbMarkSold
            // 
            this.rbMarkSold.AutoSize = true;
            this.rbMarkSold.Location = new System.Drawing.Point(25, 27);
            this.rbMarkSold.Name = "rbMarkSold";
            this.rbMarkSold.Size = new System.Drawing.Size(46, 17);
            this.rbMarkSold.TabIndex = 5;
            this.rbMarkSold.TabStop = true;
            this.rbMarkSold.Text = "Sold";
            this.rbMarkSold.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage4.Controls.Add(this.label175);
            this.tabPage4.Controls.Add(this.groupBox42);
            this.tabPage4.Controls.Add(this.label48);
            this.tabPage4.Controls.Add(this.label46);
            this.tabPage4.Controls.Add(this.lbMChangeFields);
            this.tabPage4.Controls.Add(this.label149);
            this.tabPage4.Controls.Add(this.bMassChange);
            this.tabPage4.Controls.Add(this.lMaxLength);
            this.tabPage4.Controls.Add(this.tbMChangeTo);
            this.tabPage4.Controls.Add(this.tbMChangeFrom);
            this.tabPage4.Controls.Add(this.label49);
            this.tabPage4.Controls.Add(this.label50);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(848, 515);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Mass Changes";
            // 
            // label175
            // 
            this.label175.AutoSize = true;
            this.label175.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label175.ForeColor = System.Drawing.Color.Firebrick;
            this.label175.Location = new System.Drawing.Point(64, 42);
            this.label175.Name = "label175";
            this.label175.Size = new System.Drawing.Size(654, 17);
            this.label175.TabIndex = 23;
            this.label175.Text = "NOTE: EVERY record in the database is subject to the changes you make in this sec" +
    "tion.";
            // 
            // groupBox42
            // 
            this.groupBox42.Controls.Add(this.textBox1);
            this.groupBox42.Controls.Add(this.tbMassChangeMsg);
            this.groupBox42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox42.ForeColor = System.Drawing.Color.Firebrick;
            this.groupBox42.Location = new System.Drawing.Point(61, 303);
            this.groupBox42.Name = "groupBox42";
            this.groupBox42.Size = new System.Drawing.Size(732, 139);
            this.groupBox42.TabIndex = 32;
            this.groupBox42.TabStop = false;
            this.groupBox42.Text = "Important Notes!";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(14, 72);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(692, 48);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // tbMassChangeMsg
            // 
            this.tbMassChangeMsg.BackColor = System.Drawing.SystemColors.Window;
            this.tbMassChangeMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMassChangeMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMassChangeMsg.ForeColor = System.Drawing.SystemColors.MenuText;
            this.tbMassChangeMsg.Location = new System.Drawing.Point(14, 26);
            this.tbMassChangeMsg.Multiline = true;
            this.tbMassChangeMsg.Name = "tbMassChangeMsg";
            this.tbMassChangeMsg.ReadOnly = true;
            this.tbMassChangeMsg.Size = new System.Drawing.Size(692, 34);
            this.tbMassChangeMsg.TabIndex = 21;
            this.tbMassChangeMsg.Text = "The values for checkboxes are \'Y\' or \'N\', except for Signed, which has values of " +
    "\'A\' for Author, \'I\' for Illustrator or \'B\' for both.  ";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(266, 143);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(215, 13);
            this.label48.TabIndex = 31;
            this.label48.Text = "field in ALL records in the Database ";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(64, 143);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(72, 13);
            this.label46.TabIndex = 30;
            this.label46.Text = "Change the";
            // 
            // lbMChangeFields
            // 
            this.lbMChangeFields.FormattingEnabled = true;
            this.lbMChangeFields.Items.AddRange(new object[] {
            "Binding",
            "Catalog",
            "Condition",
            "Cost",
            "Date of Publication",
            "Edition",
            "Jacket",
            "Keywords",
            "Location",
            "Mfgr",
            "Mfgr Location",
            "Private Notes",
            "Shipping",
            "Signed by Author",
            "Signed by Both",
            "Signed by Illustrator",
            "Size",
            "Type"});
            this.lbMChangeFields.Location = new System.Drawing.Point(136, 142);
            this.lbMChangeFields.Name = "lbMChangeFields";
            this.lbMChangeFields.Size = new System.Drawing.Size(124, 43);
            this.lbMChangeFields.Sorted = true;
            this.lbMChangeFields.TabIndex = 29;
            // 
            // label149
            // 
            this.label149.AutoSize = true;
            this.label149.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label149.Location = new System.Drawing.Point(488, 245);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(185, 13);
            this.label149.TabIndex = 28;
            this.label149.Text = "Maximum length of this field is: ";
            // 
            // bMassChange
            // 
            this.bMassChange.BackColor = System.Drawing.SystemColors.Desktop;
            this.bMassChange.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.bMassChange.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bMassChange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bMassChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMassChange.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bMassChange.Location = new System.Drawing.Point(606, 143);
            this.bMassChange.Name = "bMassChange";
            this.bMassChange.Size = new System.Drawing.Size(67, 25);
            this.bMassChange.TabIndex = 27;
            this.bMassChange.Text = "Change";
            this.bMassChange.UseVisualStyleBackColor = false;
            this.bMassChange.Click += new System.EventHandler(this.bMassChange_Click);
            // 
            // lMaxLength
            // 
            this.lMaxLength.AutoSize = true;
            this.lMaxLength.Location = new System.Drawing.Point(679, 245);
            this.lMaxLength.Name = "lMaxLength";
            this.lMaxLength.Size = new System.Drawing.Size(13, 13);
            this.lMaxLength.TabIndex = 26;
            this.lMaxLength.Text = "0";
            // 
            // tbMChangeTo
            // 
            this.tbMChangeTo.Location = new System.Drawing.Point(101, 241);
            this.tbMChangeTo.Name = "tbMChangeTo";
            this.tbMChangeTo.Size = new System.Drawing.Size(373, 20);
            this.tbMChangeTo.TabIndex = 25;
            // 
            // tbMChangeFrom
            // 
            this.tbMChangeFrom.Location = new System.Drawing.Point(101, 215);
            this.tbMChangeFrom.Name = "tbMChangeFrom";
            this.tbMChangeFrom.Size = new System.Drawing.Size(373, 20);
            this.tbMChangeFrom.TabIndex = 24;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(64, 218);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(31, 13);
            this.label49.TabIndex = 15;
            this.label49.Text = "from";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(64, 244);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(22, 13);
            this.label50.TabIndex = 16;
            this.label50.Text = "to:";
            // 
            // pricingResultsTab
            // 
            this.pricingResultsTab.BackColor = System.Drawing.SystemColors.Window;
            this.pricingResultsTab.Controls.Add(this.lSalesRank);
            this.pricingResultsTab.Controls.Add(this.label23);
            this.pricingResultsTab.Controls.Add(this.lbCondn);
            this.pricingResultsTab.Controls.Add(this.lVendorNote);
            this.pricingResultsTab.Controls.Add(this.lPricesReturned);
            this.pricingResultsTab.Controls.Add(this.lbPrice);
            this.pricingResultsTab.Controls.Add(this.lAveragePrice);
            this.pricingResultsTab.Controls.Add(this.lbPricingResults);
            this.pricingResultsTab.Controls.Add(this.lListPrice);
            this.pricingResultsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pricingResultsTab.Location = new System.Drawing.Point(4, 44);
            this.pricingResultsTab.Name = "pricingResultsTab";
            this.pricingResultsTab.Padding = new System.Windows.Forms.Padding(3);
            this.pricingResultsTab.Size = new System.Drawing.Size(865, 550);
            this.pricingResultsTab.TabIndex = 0;
            this.pricingResultsTab.Text = " Pricing Results ";
            this.pricingResultsTab.ToolTipText = "Shows the results of getting prices from the web";
            this.pricingResultsTab.UseVisualStyleBackColor = true;
            // 
            // lSalesRank
            // 
            this.lSalesRank.AutoSize = true;
            this.lSalesRank.Location = new System.Drawing.Point(530, 62);
            this.lSalesRank.Name = "lSalesRank";
            this.lSalesRank.Size = new System.Drawing.Size(65, 13);
            this.lSalesRank.TabIndex = 44;
            this.lSalesRank.Text = "Sales Rank:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(158, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(166, 13);
            this.label23.TabIndex = 43;
            this.label23.Text = "Results from Pricing Lookup";
            // 
            // lbCondn
            // 
            this.lbCondn.BackColor = System.Drawing.SystemColors.Window;
            this.lbCondn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbCondn.FormatString = "#,##0.00";
            this.lbCondn.FormattingEnabled = true;
            this.lbCondn.Location = new System.Drawing.Point(338, 57);
            this.lbCondn.Name = "lbCondn";
            this.lbCondn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbCondn.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbCondn.Size = new System.Drawing.Size(46, 468);
            this.lbCondn.TabIndex = 37;
            // 
            // lVendorNote
            // 
            this.lVendorNote.AutoSize = true;
            this.lVendorNote.BackColor = System.Drawing.SystemColors.Window;
            this.lVendorNote.Location = new System.Drawing.Point(530, 115);
            this.lVendorNote.Name = "lVendorNote";
            this.lVendorNote.Size = new System.Drawing.Size(277, 26);
            this.lVendorNote.TabIndex = 42;
            this.lVendorNote.Text = "NOTE: If a vendor has the media listed multiple times with\r\nthe same price and co" +
    "ndition, it is only counted once.";
            this.lVendorNote.Visible = false;
            // 
            // lPricesReturned
            // 
            this.lPricesReturned.AutoSize = true;
            this.lPricesReturned.BackColor = System.Drawing.SystemColors.Window;
            this.lPricesReturned.Location = new System.Drawing.Point(530, 82);
            this.lPricesReturned.Name = "lPricesReturned";
            this.lPricesReturned.Size = new System.Drawing.Size(154, 13);
            this.lPricesReturned.TabIndex = 41;
            this.lPricesReturned.Text = "xxx prices returned for this item.";
            // 
            // lbPrice
            // 
            this.lbPrice.BackColor = System.Drawing.SystemColors.Window;
            this.lbPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbPrice.FormatString = "#,##0.00";
            this.lbPrice.FormattingEnabled = true;
            this.lbPrice.Location = new System.Drawing.Point(278, 57);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbPrice.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbPrice.Size = new System.Drawing.Size(46, 468);
            this.lbPrice.TabIndex = 34;
            // 
            // lAveragePrice
            // 
            this.lAveragePrice.AutoSize = true;
            this.lAveragePrice.Location = new System.Drawing.Point(530, 42);
            this.lAveragePrice.Name = "lAveragePrice";
            this.lAveragePrice.Size = new System.Drawing.Size(110, 13);
            this.lAveragePrice.TabIndex = 40;
            this.lAveragePrice.Text = "Average Price: $0.00 ";
            // 
            // lbPricingResults
            // 
            this.lbPricingResults.BackColor = System.Drawing.SystemColors.Window;
            this.lbPricingResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbPricingResults.FormattingEnabled = true;
            this.lbPricingResults.Location = new System.Drawing.Point(52, 57);
            this.lbPricingResults.Name = "lbPricingResults";
            this.lbPricingResults.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbPricingResults.Size = new System.Drawing.Size(213, 468);
            this.lbPricingResults.TabIndex = 30;
            this.lbPricingResults.TabStop = false;
            // 
            // lListPrice
            // 
            this.lListPrice.AutoSize = true;
            this.lListPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lListPrice.Location = new System.Drawing.Point(530, 20);
            this.lListPrice.Name = "lListPrice";
            this.lListPrice.Size = new System.Drawing.Size(60, 15);
            this.lListPrice.TabIndex = 38;
            this.lListPrice.Text = "List Price:";
            // 
            // tabTaskPanel
            // 
            this.tabTaskPanel.Controls.Add(this.pricingResultsTab);
            this.tabTaskPanel.Controls.Add(this.ExportTab);
            this.tabTaskPanel.Controls.Add(this.uploadTab);
            this.tabTaskPanel.Controls.Add(this.accountingTab);
            this.tabTaskPanel.Controls.Add(this.RePricingTool);
            this.tabTaskPanel.Controls.Add(this.getASIN);
            this.tabTaskPanel.Controls.Add(this.optionsTab);
            this.tabTaskPanel.Controls.Add(this.customerInfoTab);
            this.tabTaskPanel.Controls.Add(this.invoiceTab);
            this.tabTaskPanel.Controls.Add(this.mediaDetailTab);
            this.tabTaskPanel.Controls.Add(this.searchTab);
            this.tabTaskPanel.Controls.Add(this.mappingTab);
            this.tabTaskPanel.Controls.Add(this.Import);
            this.tabTaskPanel.Controls.Add(this.alterPricesTab);
            this.tabTaskPanel.Controls.Add(this.cannedTextTab);
            this.tabTaskPanel.Controls.Add(this.UIDandPswdMaintenance);
            this.tabTaskPanel.Controls.Add(this.Reports);
            this.tabTaskPanel.Controls.Add(this.browserTab);
            this.tabTaskPanel.Controls.Add(this.StatusTab);
            this.tabTaskPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTaskPanel.HotTrack = true;
            this.tabTaskPanel.Location = new System.Drawing.Point(0, 130);
            this.tabTaskPanel.Margin = new System.Windows.Forms.Padding(1, 1, 3, 3);
            this.tabTaskPanel.MaximumSize = new System.Drawing.Size(873, 598);
            this.tabTaskPanel.MinimumSize = new System.Drawing.Size(873, 598);
            this.tabTaskPanel.Multiline = true;
            this.tabTaskPanel.Name = "tabTaskPanel";
            this.tabTaskPanel.Padding = new System.Drawing.Point(14, 4);
            this.tabTaskPanel.SelectedIndex = 0;
            this.tabTaskPanel.Size = new System.Drawing.Size(873, 598);
            this.tabTaskPanel.TabIndex = 19;
            this.tabTaskPanel.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabSelected);
            this.tabTaskPanel.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabTaskPanel_Deselecting);
            this.tabTaskPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabTaskPanel_MouseDown);
            this.tabTaskPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabTaskPanel_MouseMove);
            // 
            // ExportTab
            // 
            this.ExportTab.BackColor = System.Drawing.SystemColors.Window;
            this.ExportTab.Controls.Add(this.tabControl6);
            this.ExportTab.Location = new System.Drawing.Point(4, 44);
            this.ExportTab.Name = "ExportTab";
            this.ExportTab.Padding = new System.Windows.Forms.Padding(3);
            this.ExportTab.Size = new System.Drawing.Size(865, 550);
            this.ExportTab.TabIndex = 2;
            this.ExportTab.Text = " Export ";
            this.ExportTab.ToolTipText = "Exporting files to be uploaded here";
            this.ExportTab.UseVisualStyleBackColor = true;
            // 
            // tabControl6
            // 
            this.tabControl6.Controls.Add(this.tabExportOptions);
            this.tabControl6.Controls.Add(this.tabExportListing);
            this.tabControl6.Location = new System.Drawing.Point(8, 6);
            this.tabControl6.Name = "tabControl6";
            this.tabControl6.SelectedIndex = 0;
            this.tabControl6.Size = new System.Drawing.Size(851, 538);
            this.tabControl6.TabIndex = 51;
            // 
            // tabExportOptions
            // 
            this.tabExportOptions.Controls.Add(this.groupBox46);
            this.tabExportOptions.Controls.Add(this.bExport);
            this.tabExportOptions.Location = new System.Drawing.Point(4, 22);
            this.tabExportOptions.Name = "tabExportOptions";
            this.tabExportOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabExportOptions.Size = new System.Drawing.Size(843, 512);
            this.tabExportOptions.TabIndex = 0;
            this.tabExportOptions.Text = "  Export Options";
            this.tabExportOptions.UseVisualStyleBackColor = true;
            // 
            // groupBox46
            // 
            this.groupBox46.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox46.Controls.Add(this.rbExportSelected);
            this.groupBox46.Controls.Add(this.rbExportInclusiveSearch);
            this.groupBox46.Controls.Add(this.rbExportAll);
            this.groupBox46.Controls.Add(this.dateTimePicker1);
            this.groupBox46.Controls.Add(this.cbPurgeReplace);
            this.groupBox46.Controls.Add(this.lItemsWaiting);
            this.groupBox46.Controls.Add(this.rbChangeDate);
            this.groupBox46.Location = new System.Drawing.Point(28, 51);
            this.groupBox46.Name = "groupBox46";
            this.groupBox46.Size = new System.Drawing.Size(592, 165);
            this.groupBox46.TabIndex = 52;
            this.groupBox46.TabStop = false;
            this.groupBox46.Text = "Export options for all listing venues";
            // 
            // rbExportInclusiveSearch
            // 
            this.rbExportInclusiveSearch.AutoSize = true;
            this.rbExportInclusiveSearch.Enabled = false;
            this.rbExportInclusiveSearch.Location = new System.Drawing.Point(16, 55);
            this.rbExportInclusiveSearch.Name = "rbExportInclusiveSearch";
            this.rbExportInclusiveSearch.Size = new System.Drawing.Size(354, 17);
            this.rbExportInclusiveSearch.TabIndex = 39;
            this.rbExportInclusiveSearch.Text = "Only those displayed in the Database Panel by using Inclusive Search";
            // 
            // rbExportAll
            // 
            this.rbExportAll.AutoSize = true;
            this.rbExportAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbExportAll.Location = new System.Drawing.Point(16, 24);
            this.rbExportAll.Name = "rbExportAll";
            this.rbExportAll.Size = new System.Drawing.Size(359, 19);
            this.rbExportAll.TabIndex = 24;
            this.rbExportAll.Text = "Export entire database (only media with a Status of \'For Sale\')";
            this.rbExportAll.CheckedChanged += new System.EventHandler(this.rbExportAll_CheckedChanged);
            // 
            // lItemsWaiting
            // 
            this.lItemsWaiting.AutoSize = true;
            this.lItemsWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lItemsWaiting.Location = new System.Drawing.Point(376, 86);
            this.lItemsWaiting.Name = "lItemsWaiting";
            this.lItemsWaiting.Size = new System.Drawing.Size(170, 15);
            this.lItemsWaiting.TabIndex = 36;
            this.lItemsWaiting.Text = "0 items waiting to be exported";
            // 
            // rbChangeDate
            // 
            this.rbChangeDate.AutoSize = true;
            this.rbChangeDate.Checked = true;
            this.rbChangeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbChangeDate.Location = new System.Drawing.Point(16, 84);
            this.rbChangeDate.Name = "rbChangeDate";
            this.rbChangeDate.Size = new System.Drawing.Size(110, 19);
            this.rbChangeDate.TabIndex = 23;
            this.rbChangeDate.TabStop = true;
            this.rbChangeDate.Text = "Changed since:";
            this.rbChangeDate.CheckedChanged += new System.EventHandler(this.rbChangeDate_CheckedChanged);
            // 
            // bExport
            // 
            this.bExport.BackColor = System.Drawing.SystemColors.Desktop;
            this.bExport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bExport.FlatAppearance.BorderSize = 0;
            this.bExport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bExport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bExport.Location = new System.Drawing.Point(704, 51);
            this.bExport.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(71, 30);
            this.bExport.TabIndex = 51;
            this.bExport.Text = "Export";
            this.bExport.UseVisualStyleBackColor = false;
            this.bExport.Click += new System.EventHandler(this.bExport_Click);
            // 
            // tabExportListing
            // 
            this.tabExportListing.Controls.Add(this.lbExportList);
            this.tabExportListing.Location = new System.Drawing.Point(4, 22);
            this.tabExportListing.Name = "tabExportListing";
            this.tabExportListing.Padding = new System.Windows.Forms.Padding(3);
            this.tabExportListing.Size = new System.Drawing.Size(843, 512);
            this.tabExportListing.TabIndex = 1;
            this.tabExportListing.Text = "    Export Listing";
            this.tabExportListing.UseVisualStyleBackColor = true;
            // 
            // lbExportList
            // 
            this.lbExportList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbExportList.FormattingEnabled = true;
            this.lbExportList.Location = new System.Drawing.Point(6, 14);
            this.lbExportList.MultiColumn = true;
            this.lbExportList.Name = "lbExportList";
            this.lbExportList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbExportList.Size = new System.Drawing.Size(831, 485);
            this.lbExportList.TabIndex = 0;
            // 
            // getASIN
            // 
            this.getASIN.BackColor = System.Drawing.SystemColors.Window;
            this.getASIN.Controls.Add(this.label25);
            this.getASIN.Controls.Add(this.listView1);
            this.getASIN.Controls.Add(this.groupBox9);
            this.getASIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getASIN.Location = new System.Drawing.Point(4, 44);
            this.getASIN.Name = "getASIN";
            this.getASIN.Size = new System.Drawing.Size(865, 550);
            this.getASIN.TabIndex = 21;
            this.getASIN.Text = "Get ASIN ";
            this.getASIN.ToolTipText = "Get ASIN list from Amazon.com";
            this.getASIN.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.DarkRed;
            this.label25.Location = new System.Drawing.Point(-1, 11);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(0, 13);
            this.label25.TabIndex = 18;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv1Title,
            this.lv1Author,
            this.lv1Publisher,
            this.lv1Year,
            this.lv1Binding,
            this.lv1ASIN,
            this.lv1Rank});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(13, 140);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(838, 407);
            this.listView1.TabIndex = 16;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // lv1Title
            // 
            this.lv1Title.Text = "                      Title";
            this.lv1Title.Width = 220;
            // 
            // lv1Author
            // 
            this.lv1Author.Text = "        Author";
            this.lv1Author.Width = 100;
            // 
            // lv1Publisher
            // 
            this.lv1Publisher.Text = "        Mfgr";
            this.lv1Publisher.Width = 96;
            // 
            // lv1Year
            // 
            this.lv1Year.Text = "Year";
            // 
            // lv1Binding
            // 
            this.lv1Binding.Text = "Binding      ";
            this.lv1Binding.Width = 72;
            // 
            // lv1ASIN
            // 
            this.lv1ASIN.Text = "       ASIN";
            this.lv1ASIN.Width = 83;
            // 
            // lv1Rank
            // 
            this.lv1Rank.Text = "Rank";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tbasinBinding);
            this.groupBox9.Controls.Add(this.label100);
            this.groupBox9.Controls.Add(this.tbasinCond);
            this.groupBox9.Controls.Add(this.label10);
            this.groupBox9.Controls.Add(this.tbasinASIN);
            this.groupBox9.Controls.Add(this.label99);
            this.groupBox9.Controls.Add(this.tbasinPublisher);
            this.groupBox9.Controls.Add(this.tbasinSKU);
            this.groupBox9.Controls.Add(this.tbasinAuthor);
            this.groupBox9.Controls.Add(this.bUpdateASIN);
            this.groupBox9.Controls.Add(this.tbasinTitle);
            this.groupBox9.Controls.Add(this.label96);
            this.groupBox9.Controls.Add(this.label95);
            this.groupBox9.Controls.Add(this.label98);
            this.groupBox9.Controls.Add(this.label97);
            this.groupBox9.Location = new System.Drawing.Point(13, 12);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(838, 117);
            this.groupBox9.TabIndex = 15;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Your book information";
            // 
            // tbasinBinding
            // 
            this.tbasinBinding.Location = new System.Drawing.Point(577, 85);
            this.tbasinBinding.Name = "tbasinBinding";
            this.tbasinBinding.ReadOnly = true;
            this.tbasinBinding.Size = new System.Drawing.Size(112, 20);
            this.tbasinBinding.TabIndex = 54;
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(519, 88);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(45, 13);
            this.label100.TabIndex = 55;
            this.label100.Text = "Binding:";
            // 
            // tbasinCond
            // 
            this.tbasinCond.Location = new System.Drawing.Point(378, 85);
            this.tbasinCond.Name = "tbasinCond";
            this.tbasinCond.ReadOnly = true;
            this.tbasinCond.Size = new System.Drawing.Size(112, 20);
            this.tbasinCond.TabIndex = 52;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(320, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 53;
            this.label10.Text = "Condition:";
            // 
            // tbasinASIN
            // 
            this.tbasinASIN.AllowDrop = true;
            this.tbasinASIN.Location = new System.Drawing.Point(270, 28);
            this.tbasinASIN.Name = "tbasinASIN";
            this.tbasinASIN.Size = new System.Drawing.Size(148, 20);
            this.tbasinASIN.TabIndex = 2;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(10, 31);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(29, 13);
            this.label99.TabIndex = 14;
            this.label99.Text = "SKU";
            // 
            // tbasinPublisher
            // 
            this.tbasinPublisher.Location = new System.Drawing.Point(68, 85);
            this.tbasinPublisher.Name = "tbasinPublisher";
            this.tbasinPublisher.ReadOnly = true;
            this.tbasinPublisher.Size = new System.Drawing.Size(229, 20);
            this.tbasinPublisher.TabIndex = 4;
            // 
            // tbasinSKU
            // 
            this.tbasinSKU.Location = new System.Drawing.Point(68, 28);
            this.tbasinSKU.Name = "tbasinSKU";
            this.tbasinSKU.ReadOnly = true;
            this.tbasinSKU.Size = new System.Drawing.Size(119, 20);
            this.tbasinSKU.TabIndex = 13;
            // 
            // tbasinAuthor
            // 
            this.tbasinAuthor.Location = new System.Drawing.Point(504, 57);
            this.tbasinAuthor.Name = "tbasinAuthor";
            this.tbasinAuthor.ReadOnly = true;
            this.tbasinAuthor.Size = new System.Drawing.Size(231, 20);
            this.tbasinAuthor.TabIndex = 5;
            // 
            // tbasinTitle
            // 
            this.tbasinTitle.Location = new System.Drawing.Point(68, 57);
            this.tbasinTitle.Name = "tbasinTitle";
            this.tbasinTitle.ReadOnly = true;
            this.tbasinTitle.Size = new System.Drawing.Size(352, 20);
            this.tbasinTitle.TabIndex = 6;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(10, 88);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(31, 13);
            this.label96.TabIndex = 11;
            this.label96.Text = "Mfgr:";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(215, 31);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(32, 13);
            this.label95.TabIndex = 7;
            this.label95.Text = "ASIN";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(10, 60);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(27, 13);
            this.label98.TabIndex = 10;
            this.label98.Text = "Title";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(449, 60);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(38, 13);
            this.label97.TabIndex = 9;
            this.label97.Text = "Author";
            // 
            // optionsTab
            // 
            this.optionsTab.BackColor = System.Drawing.SystemColors.Window;
            this.optionsTab.Controls.Add(this.tabPrimary);
            this.optionsTab.Location = new System.Drawing.Point(4, 44);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Size = new System.Drawing.Size(865, 550);
            this.optionsTab.TabIndex = 16;
            this.optionsTab.Text = "Program Options ";
            this.optionsTab.UseVisualStyleBackColor = true;
            // 
            // tabPrimary
            // 
            this.tabPrimary.Controls.Add(this.tabProgramOptions);
            this.tabPrimary.Controls.Add(this.tabOptions);
            this.tabPrimary.Location = new System.Drawing.Point(3, 3);
            this.tabPrimary.Name = "tabPrimary";
            this.tabPrimary.SelectedIndex = 0;
            this.tabPrimary.Size = new System.Drawing.Size(832, 539);
            this.tabPrimary.TabIndex = 0;
            // 
            // tabProgramOptions
            // 
            this.tabProgramOptions.BackColor = System.Drawing.SystemColors.Window;
            this.tabProgramOptions.Controls.Add(this.groupBox2);
            this.tabProgramOptions.Controls.Add(this.groupBox48);
            this.tabProgramOptions.Controls.Add(this.groupBox28);
            this.tabProgramOptions.Controls.Add(this.groupBox50);
            this.tabProgramOptions.Controls.Add(this.groupBox49);
            this.tabProgramOptions.Controls.Add(this.groupBox25);
            this.tabProgramOptions.Controls.Add(this.groupBox51);
            this.tabProgramOptions.Location = new System.Drawing.Point(4, 22);
            this.tabProgramOptions.Name = "tabProgramOptions";
            this.tabProgramOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabProgramOptions.Size = new System.Drawing.Size(824, 513);
            this.tabProgramOptions.TabIndex = 0;
            this.tabProgramOptions.Text = "Program Options";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbSKUSuffix);
            this.groupBox2.Controls.Add(this.lSKUSuffix);
            this.groupBox2.Controls.Add(this.tbSKUPrefix);
            this.groupBox2.Controls.Add(this.lSKUPrefix);
            this.groupBox2.Controls.Add(this.tbStartingSKU);
            this.groupBox2.Controls.Add(this.label202);
            this.groupBox2.Controls.Add(this.cbAutomaticSKU);
            this.groupBox2.Location = new System.Drawing.Point(19, 373);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 86);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SKU Numbering";
            // 
            // lSKUSuffix
            // 
            this.lSKUSuffix.AutoSize = true;
            this.lSKUSuffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSKUSuffix.Location = new System.Drawing.Point(272, 22);
            this.lSKUSuffix.Name = "lSKUSuffix";
            this.lSKUSuffix.Size = new System.Drawing.Size(36, 13);
            this.lSKUSuffix.TabIndex = 9;
            this.lSKUSuffix.Text = "Suffix:";
            this.lSKUSuffix.Visible = false;
            // 
            // lSKUPrefix
            // 
            this.lSKUPrefix.AutoSize = true;
            this.lSKUPrefix.Location = new System.Drawing.Point(242, 53);
            this.lSKUPrefix.Name = "lSKUPrefix";
            this.lSKUPrefix.Size = new System.Drawing.Size(78, 13);
            this.lSKUPrefix.TabIndex = 7;
            this.lSKUPrefix.Text = "Optional Prefix:";
            // 
            // label202
            // 
            this.label202.AutoSize = true;
            this.label202.Location = new System.Drawing.Point(14, 53);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(111, 13);
            this.label202.TabIndex = 5;
            this.label202.Text = "Starting SKU Number:";
            // 
            // groupBox48
            // 
            this.groupBox48.Controls.Add(this.rbMoveAvgPrice);
            this.groupBox48.Controls.Add(this.rbMoveLowPrice);
            this.groupBox48.Controls.Add(this.cbUseAWS);
            this.groupBox48.Controls.Add(this.cbAutoPricingLookup);
            this.groupBox48.Location = new System.Drawing.Point(460, 209);
            this.groupBox48.Name = "groupBox48";
            this.groupBox48.Size = new System.Drawing.Size(343, 125);
            this.groupBox48.TabIndex = 34;
            this.groupBox48.TabStop = false;
            this.groupBox48.Text = "Pricing options";
            // 
            // rbMoveAvgPrice
            // 
            this.rbMoveAvgPrice.AutoSize = true;
            this.rbMoveAvgPrice.Location = new System.Drawing.Point(20, 21);
            this.rbMoveAvgPrice.Name = "rbMoveAvgPrice";
            this.rbMoveAvgPrice.Size = new System.Drawing.Size(315, 17);
            this.rbMoveAvgPrice.TabIndex = 25;
            this.rbMoveAvgPrice.TabStop = true;
            this.rbMoveAvgPrice.Text = "Move average price from Pricing Results page to price of item";
            this.rbMoveAvgPrice.UseVisualStyleBackColor = true;
            // 
            // rbMoveLowPrice
            // 
            this.rbMoveLowPrice.AutoSize = true;
            this.rbMoveLowPrice.Location = new System.Drawing.Point(20, 46);
            this.rbMoveLowPrice.Name = "rbMoveLowPrice";
            this.rbMoveLowPrice.Size = new System.Drawing.Size(294, 17);
            this.rbMoveLowPrice.TabIndex = 24;
            this.rbMoveLowPrice.TabStop = true;
            this.rbMoveLowPrice.Text = "Move lowest price from Pricing Results page to item price";
            this.rbMoveLowPrice.UseVisualStyleBackColor = true;
            // 
            // cbUseAWS
            // 
            this.cbUseAWS.AutoSize = true;
            this.cbUseAWS.Checked = true;
            this.cbUseAWS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseAWS.Enabled = false;
            this.cbUseAWS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUseAWS.Location = new System.Drawing.Point(20, 71);
            this.cbUseAWS.Name = "cbUseAWS";
            this.cbUseAWS.Size = new System.Drawing.Size(211, 17);
            this.cbUseAWS.TabIndex = 23;
            this.cbUseAWS.Text = "Use Amazon.com to get prices (default)";
            this.cbUseAWS.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbUseAWS.UseVisualStyleBackColor = true;
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.cbWarnNoLocation);
            this.groupBox28.Controls.Add(this.cbWarnNoCatalog);
            this.groupBox28.Location = new System.Drawing.Point(19, 132);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(374, 79);
            this.groupBox28.TabIndex = 35;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Warnings";
            // 
            // cbWarnNoLocation
            // 
            this.cbWarnNoLocation.AutoSize = true;
            this.cbWarnNoLocation.Location = new System.Drawing.Point(17, 46);
            this.cbWarnNoLocation.Name = "cbWarnNoLocation";
            this.cbWarnNoLocation.Size = new System.Drawing.Size(224, 17);
            this.cbWarnNoLocation.TabIndex = 6;
            this.cbWarnNoLocation.Text = "Warn when adding item without a location";
            this.cbWarnNoLocation.UseVisualStyleBackColor = true;
            // 
            // cbWarnNoCatalog
            // 
            this.cbWarnNoCatalog.AutoSize = true;
            this.cbWarnNoCatalog.Location = new System.Drawing.Point(17, 21);
            this.cbWarnNoCatalog.Name = "cbWarnNoCatalog";
            this.cbWarnNoCatalog.Size = new System.Drawing.Size(239, 17);
            this.cbWarnNoCatalog.TabIndex = 5;
            this.cbWarnNoCatalog.Text = "Warn when adding item without catalog entry";
            this.cbWarnNoCatalog.UseVisualStyleBackColor = true;
            // 
            // groupBox50
            // 
            this.groupBox50.Controls.Add(this.cbAutoFileRetention);
            this.groupBox50.Controls.Add(this.cbAutoInvoiceNbr);
            this.groupBox50.Controls.Add(this.cbAutoCustomerNbr);
            this.groupBox50.Location = new System.Drawing.Point(19, 13);
            this.groupBox50.Name = "groupBox50";
            this.groupBox50.Size = new System.Drawing.Size(374, 100);
            this.groupBox50.TabIndex = 36;
            this.groupBox50.TabStop = false;
            this.groupBox50.Text = "Automatic options";
            // 
            // cbAutoFileRetention
            // 
            this.cbAutoFileRetention.AutoSize = true;
            this.cbAutoFileRetention.Checked = true;
            this.cbAutoFileRetention.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoFileRetention.Location = new System.Drawing.Point(17, 72);
            this.cbAutoFileRetention.Name = "cbAutoFileRetention";
            this.cbAutoFileRetention.Size = new System.Drawing.Size(231, 17);
            this.cbAutoFileRetention.TabIndex = 10;
            this.cbAutoFileRetention.Text = "Automatically maintain file retention (default)";
            this.cbAutoFileRetention.UseVisualStyleBackColor = true;
            // 
            // cbAutoInvoiceNbr
            // 
            this.cbAutoInvoiceNbr.AutoSize = true;
            this.cbAutoInvoiceNbr.Location = new System.Drawing.Point(17, 47);
            this.cbAutoInvoiceNbr.Name = "cbAutoInvoiceNbr";
            this.cbAutoInvoiceNbr.Size = new System.Drawing.Size(213, 17);
            this.cbAutoInvoiceNbr.TabIndex = 9;
            this.cbAutoInvoiceNbr.Text = "Automatically generate invoice numbers";
            this.cbAutoInvoiceNbr.UseVisualStyleBackColor = true;
            // 
            // cbAutoCustomerNbr
            // 
            this.cbAutoCustomerNbr.AutoSize = true;
            this.cbAutoCustomerNbr.Location = new System.Drawing.Point(17, 22);
            this.cbAutoCustomerNbr.Name = "cbAutoCustomerNbr";
            this.cbAutoCustomerNbr.Size = new System.Drawing.Size(222, 17);
            this.cbAutoCustomerNbr.TabIndex = 8;
            this.cbAutoCustomerNbr.Text = "Automatically generate customer numbers";
            this.cbAutoCustomerNbr.UseVisualStyleBackColor = true;
            // 
            // groupBox49
            // 
            this.groupBox49.Controls.Add(this.cbUseReceipt);
            this.groupBox49.Controls.Add(this.panel5);
            this.groupBox49.Controls.Add(this.cbSortOverride);
            this.groupBox49.Controls.Add(this.rbStartDetail);
            this.groupBox49.Controls.Add(this.cbToolTips);
            this.groupBox49.Controls.Add(this.rbStartSearch);
            this.groupBox49.Controls.Add(this.cbBackupDB);
            this.groupBox49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox49.Location = new System.Drawing.Point(460, 13);
            this.groupBox49.Name = "groupBox49";
            this.groupBox49.Size = new System.Drawing.Size(343, 178);
            this.groupBox49.TabIndex = 40;
            this.groupBox49.TabStop = false;
            this.groupBox49.Text = "Program run options";
            // 
            // cbUseReceipt
            // 
            this.cbUseReceipt.AutoSize = true;
            this.cbUseReceipt.Location = new System.Drawing.Point(18, 149);
            this.cbUseReceipt.Name = "cbUseReceipt";
            this.cbUseReceipt.Size = new System.Drawing.Size(314, 17);
            this.cbUseReceipt.TabIndex = 20;
            this.cbUseReceipt.Tag = "Invoice prints on 8.5\" x 5.25\" paper; invoice is customizable but defaults to 3\" " +
    "wide for a roll printer, like a Cannon CT-S300.";
            this.cbUseReceipt.Text = "Use a \"receipt\" rather than an \"invoice\" (uses special printer)";
            this.cbUseReceipt.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rbSortDsc);
            this.panel5.Controls.Add(this.rbSortAsc);
            this.panel5.Location = new System.Drawing.Point(50, 90);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(253, 23);
            this.panel5.TabIndex = 18;
            // 
            // rbSortDsc
            // 
            this.rbSortDsc.AutoSize = true;
            this.rbSortDsc.Location = new System.Drawing.Point(107, 3);
            this.rbSortDsc.Name = "rbSortDsc";
            this.rbSortDsc.Size = new System.Drawing.Size(82, 17);
            this.rbSortDsc.TabIndex = 17;
            this.rbSortDsc.TabStop = true;
            this.rbSortDsc.Text = "Descending";
            this.rbSortDsc.UseVisualStyleBackColor = true;
            this.rbSortDsc.CheckedChanged += new System.EventHandler(this.rbSortAsc_CheckedChanged);
            // 
            // rbSortAsc
            // 
            this.rbSortAsc.AutoSize = true;
            this.rbSortAsc.Location = new System.Drawing.Point(10, 3);
            this.rbSortAsc.Name = "rbSortAsc";
            this.rbSortAsc.Size = new System.Drawing.Size(75, 17);
            this.rbSortAsc.TabIndex = 16;
            this.rbSortAsc.TabStop = true;
            this.rbSortAsc.Text = "Ascending";
            this.rbSortAsc.UseVisualStyleBackColor = true;
            this.rbSortAsc.CheckedChanged += new System.EventHandler(this.rbSortAsc_CheckedChanged);
            // 
            // cbSortOverride
            // 
            this.cbSortOverride.AutoSize = true;
            this.cbSortOverride.Location = new System.Drawing.Point(17, 69);
            this.cbSortOverride.Name = "cbSortOverride";
            this.cbSortOverride.Size = new System.Drawing.Size(246, 17);
            this.cbSortOverride.TabIndex = 15;
            this.cbSortOverride.Text = "Sort records based on date added to database";
            this.cbSortOverride.UseVisualStyleBackColor = true;
            // 
            // rbStartDetail
            // 
            this.rbStartDetail.AutoSize = true;
            this.rbStartDetail.Location = new System.Drawing.Point(190, 123);
            this.rbStartDetail.Name = "rbStartDetail";
            this.rbStartDetail.Size = new System.Drawing.Size(126, 17);
            this.rbStartDetail.TabIndex = 1;
            this.rbStartDetail.TabStop = true;
            this.rbStartDetail.Text = "on Media Detail page";
            this.rbStartDetail.UseVisualStyleBackColor = true;
            // 
            // cbToolTips
            // 
            this.cbToolTips.AutoSize = true;
            this.cbToolTips.Location = new System.Drawing.Point(17, 22);
            this.cbToolTips.Name = "cbToolTips";
            this.cbToolTips.Size = new System.Drawing.Size(181, 17);
            this.cbToolTips.TabIndex = 14;
            this.cbToolTips.Text = "Turn off informational balloon tips";
            this.cbToolTips.UseVisualStyleBackColor = true;
            this.cbToolTips.CheckedChanged += new System.EventHandler(this.cbToolTips_CheckedChanged);
            // 
            // rbStartSearch
            // 
            this.rbStartSearch.AutoSize = true;
            this.rbStartSearch.Location = new System.Drawing.Point(17, 123);
            this.rbStartSearch.Name = "rbStartSearch";
            this.rbStartSearch.Size = new System.Drawing.Size(167, 17);
            this.rbStartSearch.TabIndex = 0;
            this.rbStartSearch.TabStop = true;
            this.rbStartSearch.Text = "Start program on Search page";
            this.rbStartSearch.UseVisualStyleBackColor = true;
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.label12);
            this.groupBox25.Controls.Add(this.rbEUDollar);
            this.groupBox25.Controls.Add(this.rbGBPound);
            this.groupBox25.Controls.Add(this.rbCNDollar);
            this.groupBox25.Location = new System.Drawing.Point(460, 349);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(343, 90);
            this.groupBox25.TabIndex = 38;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "When uploading to Amazon, convert from USD to:";
            this.groupBox25.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(17, 48);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(286, 26);
            this.label12.TabIndex = 3;
            this.label12.Text = "To request other currencies, please go to the Support page\r\n on our web site and " +
    "open a new ticket.";
            // 
            // rbEUDollar
            // 
            this.rbEUDollar.AutoSize = true;
            this.rbEUDollar.Location = new System.Drawing.Point(258, 24);
            this.rbEUDollar.Name = "rbEUDollar";
            this.rbEUDollar.Size = new System.Drawing.Size(74, 17);
            this.rbEUDollar.TabIndex = 1;
            this.rbEUDollar.Text = "EuroDollar";
            this.rbEUDollar.UseVisualStyleBackColor = true;
            this.rbEUDollar.CheckedChanged += new System.EventHandler(this.rbConvertUSD_CheckedChanged);
            // 
            // rbGBPound
            // 
            this.rbGBPound.AutoSize = true;
            this.rbGBPound.Location = new System.Drawing.Point(144, 24);
            this.rbGBPound.Name = "rbGBPound";
            this.rbGBPound.Size = new System.Drawing.Size(87, 17);
            this.rbGBPound.TabIndex = 0;
            this.rbGBPound.Text = "British Pound";
            this.rbGBPound.UseVisualStyleBackColor = true;
            this.rbGBPound.CheckedChanged += new System.EventHandler(this.rbConvertUSD_CheckedChanged);
            // 
            // rbCNDollar
            // 
            this.rbCNDollar.AutoSize = true;
            this.rbCNDollar.Location = new System.Drawing.Point(17, 24);
            this.rbCNDollar.Name = "rbCNDollar";
            this.rbCNDollar.Size = new System.Drawing.Size(100, 17);
            this.rbCNDollar.TabIndex = 2;
            this.rbCNDollar.Text = "Canadian Dollar";
            this.rbCNDollar.UseVisualStyleBackColor = true;
            this.rbCNDollar.CheckedChanged += new System.EventHandler(this.rbConvertUSD_CheckedChanged);
            // 
            // groupBox51
            // 
            this.groupBox51.Controls.Add(this.label129);
            this.groupBox51.Controls.Add(this.cbDontOverlay);
            this.groupBox51.Controls.Add(this.cbAddDesc);
            this.groupBox51.Controls.Add(this.cbAllowAddUpdate);
            this.groupBox51.Controls.Add(this.cbVerifyDeletes);
            this.groupBox51.Location = new System.Drawing.Point(19, 230);
            this.groupBox51.Name = "groupBox51";
            this.groupBox51.Size = new System.Drawing.Size(374, 123);
            this.groupBox51.TabIndex = 37;
            this.groupBox51.TabStop = false;
            this.groupBox51.Text = "Media Entry options";
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label129.ForeColor = System.Drawing.Color.Firebrick;
            this.label129.Location = new System.Drawing.Point(311, 95);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(40, 13);
            this.label129.TabIndex = 25;
            this.label129.Text = "(New)";
            // 
            // cbDontOverlay
            // 
            this.cbDontOverlay.AutoSize = true;
            this.cbDontOverlay.Location = new System.Drawing.Point(17, 94);
            this.cbDontOverlay.Name = "cbDontOverlay";
            this.cbDontOverlay.Size = new System.Drawing.Size(287, 17);
            this.cbDontOverlay.TabIndex = 24;
            this.cbDontOverlay.Text = "When using Get Media Info, don\'t overlay existing data.";
            this.cbDontOverlay.UseVisualStyleBackColor = true;
            // 
            // cbAddDesc
            // 
            this.cbAddDesc.AutoSize = true;
            this.cbAddDesc.Location = new System.Drawing.Point(17, 71);
            this.cbAddDesc.Name = "cbAddDesc";
            this.cbAddDesc.Size = new System.Drawing.Size(287, 17);
            this.cbAddDesc.TabIndex = 21;
            this.cbAddDesc.Text = "Use Amazon\'s description when getting item information";
            this.cbAddDesc.UseVisualStyleBackColor = true;
            // 
            // tabOptions
            // 
            this.tabOptions.BackColor = System.Drawing.SystemColors.Window;
            this.tabOptions.Controls.Add(this.label104);
            this.tabOptions.Controls.Add(this.tbPubSeq);
            this.tabOptions.Controls.Add(this.label103);
            this.tabOptions.Controls.Add(this.label158);
            this.tabOptions.Controls.Add(this.label159);
            this.tabOptions.Controls.Add(this.label160);
            this.tabOptions.Controls.Add(this.label161);
            this.tabOptions.Controls.Add(this.label162);
            this.tabOptions.Controls.Add(this.label163);
            this.tabOptions.Controls.Add(this.label164);
            this.tabOptions.Controls.Add(this.label165);
            this.tabOptions.Controls.Add(this.label166);
            this.tabOptions.Controls.Add(this.label167);
            this.tabOptions.Controls.Add(this.label168);
            this.tabOptions.Controls.Add(this.label173);
            this.tabOptions.Controls.Add(this.label176);
            this.tabOptions.Controls.Add(this.label177);
            this.tabOptions.Controls.Add(this.label157);
            this.tabOptions.Controls.Add(this.label156);
            this.tabOptions.Controls.Add(this.label155);
            this.tabOptions.Controls.Add(this.label154);
            this.tabOptions.Controls.Add(this.label153);
            this.tabOptions.Controls.Add(this.label152);
            this.tabOptions.Controls.Add(this.label151);
            this.tabOptions.Controls.Add(this.label150);
            this.tabOptions.Controls.Add(this.label110);
            this.tabOptions.Controls.Add(this.label108);
            this.tabOptions.Controls.Add(this.label107);
            this.tabOptions.Controls.Add(this.label106);
            this.tabOptions.Controls.Add(this.label105);
            this.tabOptions.Controls.Add(this.tbKeySeq);
            this.tabOptions.Controls.Add(this.tbSecSeq);
            this.tabOptions.Controls.Add(this.tbPriSeq);
            this.tabOptions.Controls.Add(this.tbSizeSeq);
            this.tabOptions.Controls.Add(this.tbTypeSeq);
            this.tabOptions.Controls.Add(this.tbWeightSeq);
            this.tabOptions.Controls.Add(this.tbPagesSeq);
            this.tabOptions.Controls.Add(this.tbEdSeq);
            this.tabOptions.Controls.Add(this.tbJacketSeq);
            this.tabOptions.Controls.Add(this.tbCondSeq);
            this.tabOptions.Controls.Add(this.tbBindingSeq);
            this.tabOptions.Controls.Add(this.tbCannedSeq);
            this.tabOptions.Controls.Add(this.tbDescSeq);
            this.tabOptions.Controls.Add(this.tbYearSeq);
            this.tabOptions.Controls.Add(this.tbPlaceSeq);
            this.tabOptions.Controls.Add(this.tbIllusSignedSeq);
            this.tabOptions.Controls.Add(this.tbIllusSeq);
            this.tabOptions.Controls.Add(this.tbAuthorSignSeq);
            this.tabOptions.Controls.Add(this.tbAuthorSeq);
            this.tabOptions.Controls.Add(this.tbTitleSeq);
            this.tabOptions.Controls.Add(this.tbRepriceSeq);
            this.tabOptions.Controls.Add(this.tbPriceSeq);
            this.tabOptions.Controls.Add(this.tbCostSeq);
            this.tabOptions.Controls.Add(this.tbShipSeq);
            this.tabOptions.Controls.Add(this.tbSKUSeq);
            this.tabOptions.Controls.Add(this.tbLocSeq);
            this.tabOptions.Controls.Add(this.tbQtySeq);
            this.tabOptions.Controls.Add(this.tbUPCSeq);
            this.tabOptions.Controls.Add(this.label102);
            this.tabOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(824, 513);
            this.tabOptions.TabIndex = 1;
            this.tabOptions.Text = "Tab Sequence";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(136, 414);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(28, 13);
            this.label104.TabIndex = 305;
            this.label104.Text = "Mfgr";
            // 
            // tbPubSeq
            // 
            this.tbPubSeq.Location = new System.Drawing.Point(97, 411);
            this.tbPubSeq.Name = "tbPubSeq";
            this.tbPubSeq.Size = new System.Drawing.Size(28, 20);
            this.tbPubSeq.TabIndex = 304;
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(400, 436);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(53, 13);
            this.label103.TabIndex = 303;
            this.label103.Text = "Keywords";
            // 
            // label158
            // 
            this.label158.AutoSize = true;
            this.label158.Location = new System.Drawing.Point(400, 410);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(58, 13);
            this.label158.TabIndex = 302;
            this.label158.Text = "Secondary";
            // 
            // label159
            // 
            this.label159.AutoSize = true;
            this.label159.Location = new System.Drawing.Point(400, 384);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(80, 13);
            this.label159.TabIndex = 301;
            this.label159.Text = "Primary Catalog";
            // 
            // label160
            // 
            this.label160.AutoSize = true;
            this.label160.Location = new System.Drawing.Point(400, 356);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(27, 13);
            this.label160.TabIndex = 300;
            this.label160.Text = "Size";
            // 
            // label161
            // 
            this.label161.AutoSize = true;
            this.label161.Location = new System.Drawing.Point(400, 331);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(31, 13);
            this.label161.TabIndex = 299;
            this.label161.Text = "Type";
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.Location = new System.Drawing.Point(400, 305);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(41, 13);
            this.label162.TabIndex = 298;
            this.label162.Text = "Weight";
            // 
            // label163
            // 
            this.label163.AutoSize = true;
            this.label163.Location = new System.Drawing.Point(400, 280);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(37, 13);
            this.label163.TabIndex = 297;
            this.label163.Text = "Pages";
            // 
            // label164
            // 
            this.label164.AutoSize = true;
            this.label164.Location = new System.Drawing.Point(400, 253);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(39, 13);
            this.label164.TabIndex = 296;
            this.label164.Text = "Edition";
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Location = new System.Drawing.Point(400, 227);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(39, 13);
            this.label165.TabIndex = 295;
            this.label165.Text = "Jacket";
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Location = new System.Drawing.Point(400, 201);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(51, 13);
            this.label166.TabIndex = 294;
            this.label166.Text = "Condition";
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(400, 175);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(42, 13);
            this.label167.TabIndex = 293;
            this.label167.Text = "Binding";
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Location = new System.Drawing.Point(400, 149);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(68, 13);
            this.label168.TabIndex = 292;
            this.label168.Text = "Canned Text";
            // 
            // label173
            // 
            this.label173.AutoSize = true;
            this.label173.Location = new System.Drawing.Point(400, 123);
            this.label173.Name = "label173";
            this.label173.Size = new System.Drawing.Size(60, 13);
            this.label173.TabIndex = 291;
            this.label173.Text = "Description";
            // 
            // label176
            // 
            this.label176.AutoSize = true;
            this.label176.Location = new System.Drawing.Point(400, 96);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(29, 13);
            this.label176.TabIndex = 290;
            this.label176.Text = "Year";
            // 
            // label177
            // 
            this.label177.AutoSize = true;
            this.label177.Location = new System.Drawing.Point(400, 70);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(58, 13);
            this.label177.TabIndex = 289;
            this.label177.Text = "Mfgr Place";
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Location = new System.Drawing.Point(136, 388);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(85, 13);
            this.label157.TabIndex = 288;
            this.label157.Text = "Illustrator Signed";
            // 
            // label156
            // 
            this.label156.AutoSize = true;
            this.label156.Location = new System.Drawing.Point(136, 362);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(49, 13);
            this.label156.TabIndex = 287;
            this.label156.Text = "Illustrator";
            // 
            // label155
            // 
            this.label155.AutoSize = true;
            this.label155.Location = new System.Drawing.Point(136, 335);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(74, 13);
            this.label155.TabIndex = 286;
            this.label155.Text = "Author Signed";
            // 
            // label154
            // 
            this.label154.AutoSize = true;
            this.label154.Location = new System.Drawing.Point(136, 310);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(38, 13);
            this.label154.TabIndex = 285;
            this.label154.Text = "Author";
            // 
            // label153
            // 
            this.label153.AutoSize = true;
            this.label153.Location = new System.Drawing.Point(136, 283);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(27, 13);
            this.label153.TabIndex = 284;
            this.label153.Text = "Title";
            // 
            // label152
            // 
            this.label152.AutoSize = true;
            this.label152.Location = new System.Drawing.Point(136, 257);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(81, 13);
            this.label152.TabIndex = 283;
            this.label152.Text = "Do Not Reprice";
            // 
            // label151
            // 
            this.label151.AutoSize = true;
            this.label151.Location = new System.Drawing.Point(136, 231);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(31, 13);
            this.label151.TabIndex = 282;
            this.label151.Text = "Price";
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.Location = new System.Drawing.Point(136, 208);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(28, 13);
            this.label150.TabIndex = 281;
            this.label150.Text = "Cost";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(136, 179);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(48, 13);
            this.label110.TabIndex = 279;
            this.label110.Text = "Shipping";
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(136, 149);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(29, 13);
            this.label108.TabIndex = 277;
            this.label108.Text = "SKU";
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(136, 124);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(48, 13);
            this.label107.TabIndex = 276;
            this.label107.Text = "Location";
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Location = new System.Drawing.Point(136, 97);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(46, 13);
            this.label106.TabIndex = 275;
            this.label106.Text = "Quantity";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(136, 71);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(29, 13);
            this.label105.TabIndex = 274;
            this.label105.Text = "UPC";
            // 
            // tbKeySeq
            // 
            this.tbKeySeq.Location = new System.Drawing.Point(354, 432);
            this.tbKeySeq.Name = "tbKeySeq";
            this.tbKeySeq.Size = new System.Drawing.Size(28, 20);
            this.tbKeySeq.TabIndex = 33;
            // 
            // tbSecSeq
            // 
            this.tbSecSeq.Location = new System.Drawing.Point(354, 406);
            this.tbSecSeq.Name = "tbSecSeq";
            this.tbSecSeq.Size = new System.Drawing.Size(28, 20);
            this.tbSecSeq.TabIndex = 32;
            // 
            // tbPriSeq
            // 
            this.tbPriSeq.Location = new System.Drawing.Point(354, 380);
            this.tbPriSeq.Name = "tbPriSeq";
            this.tbPriSeq.Size = new System.Drawing.Size(28, 20);
            this.tbPriSeq.TabIndex = 31;
            // 
            // tbSizeSeq
            // 
            this.tbSizeSeq.Location = new System.Drawing.Point(354, 353);
            this.tbSizeSeq.Name = "tbSizeSeq";
            this.tbSizeSeq.Size = new System.Drawing.Size(28, 20);
            this.tbSizeSeq.TabIndex = 30;
            // 
            // tbTypeSeq
            // 
            this.tbTypeSeq.Location = new System.Drawing.Point(354, 328);
            this.tbTypeSeq.Name = "tbTypeSeq";
            this.tbTypeSeq.Size = new System.Drawing.Size(28, 20);
            this.tbTypeSeq.TabIndex = 29;
            // 
            // tbWeightSeq
            // 
            this.tbWeightSeq.Location = new System.Drawing.Point(354, 302);
            this.tbWeightSeq.Name = "tbWeightSeq";
            this.tbWeightSeq.Size = new System.Drawing.Size(28, 20);
            this.tbWeightSeq.TabIndex = 28;
            // 
            // tbPagesSeq
            // 
            this.tbPagesSeq.Location = new System.Drawing.Point(354, 276);
            this.tbPagesSeq.Name = "tbPagesSeq";
            this.tbPagesSeq.Size = new System.Drawing.Size(28, 20);
            this.tbPagesSeq.TabIndex = 27;
            // 
            // tbEdSeq
            // 
            this.tbEdSeq.Location = new System.Drawing.Point(354, 250);
            this.tbEdSeq.Name = "tbEdSeq";
            this.tbEdSeq.Size = new System.Drawing.Size(28, 20);
            this.tbEdSeq.TabIndex = 26;
            // 
            // tbJacketSeq
            // 
            this.tbJacketSeq.Location = new System.Drawing.Point(354, 224);
            this.tbJacketSeq.Name = "tbJacketSeq";
            this.tbJacketSeq.Size = new System.Drawing.Size(28, 20);
            this.tbJacketSeq.TabIndex = 25;
            // 
            // tbCondSeq
            // 
            this.tbCondSeq.Location = new System.Drawing.Point(354, 198);
            this.tbCondSeq.Name = "tbCondSeq";
            this.tbCondSeq.Size = new System.Drawing.Size(28, 20);
            this.tbCondSeq.TabIndex = 24;
            // 
            // tbBindingSeq
            // 
            this.tbBindingSeq.Location = new System.Drawing.Point(354, 172);
            this.tbBindingSeq.Name = "tbBindingSeq";
            this.tbBindingSeq.Size = new System.Drawing.Size(28, 20);
            this.tbBindingSeq.TabIndex = 23;
            // 
            // tbCannedSeq
            // 
            this.tbCannedSeq.Location = new System.Drawing.Point(354, 146);
            this.tbCannedSeq.Name = "tbCannedSeq";
            this.tbCannedSeq.Size = new System.Drawing.Size(28, 20);
            this.tbCannedSeq.TabIndex = 22;
            // 
            // tbDescSeq
            // 
            this.tbDescSeq.Location = new System.Drawing.Point(354, 120);
            this.tbDescSeq.Name = "tbDescSeq";
            this.tbDescSeq.Size = new System.Drawing.Size(28, 20);
            this.tbDescSeq.TabIndex = 21;
            // 
            // tbYearSeq
            // 
            this.tbYearSeq.Location = new System.Drawing.Point(354, 94);
            this.tbYearSeq.Name = "tbYearSeq";
            this.tbYearSeq.Size = new System.Drawing.Size(28, 20);
            this.tbYearSeq.TabIndex = 20;
            // 
            // tbPlaceSeq
            // 
            this.tbPlaceSeq.Location = new System.Drawing.Point(354, 68);
            this.tbPlaceSeq.Name = "tbPlaceSeq";
            this.tbPlaceSeq.Size = new System.Drawing.Size(28, 20);
            this.tbPlaceSeq.TabIndex = 19;
            // 
            // tbIllusSignedSeq
            // 
            this.tbIllusSignedSeq.Location = new System.Drawing.Point(97, 385);
            this.tbIllusSignedSeq.Name = "tbIllusSignedSeq";
            this.tbIllusSignedSeq.Size = new System.Drawing.Size(28, 20);
            this.tbIllusSignedSeq.TabIndex = 17;
            // 
            // tbIllusSeq
            // 
            this.tbIllusSeq.Location = new System.Drawing.Point(97, 359);
            this.tbIllusSeq.Name = "tbIllusSeq";
            this.tbIllusSeq.Size = new System.Drawing.Size(28, 20);
            this.tbIllusSeq.TabIndex = 16;
            // 
            // tbAuthorSignSeq
            // 
            this.tbAuthorSignSeq.Location = new System.Drawing.Point(97, 332);
            this.tbAuthorSignSeq.Name = "tbAuthorSignSeq";
            this.tbAuthorSignSeq.Size = new System.Drawing.Size(28, 20);
            this.tbAuthorSignSeq.TabIndex = 15;
            // 
            // tbAuthorSeq
            // 
            this.tbAuthorSeq.Location = new System.Drawing.Point(97, 307);
            this.tbAuthorSeq.Name = "tbAuthorSeq";
            this.tbAuthorSeq.Size = new System.Drawing.Size(28, 20);
            this.tbAuthorSeq.TabIndex = 14;
            // 
            // tbTitleSeq
            // 
            this.tbTitleSeq.Location = new System.Drawing.Point(97, 280);
            this.tbTitleSeq.Name = "tbTitleSeq";
            this.tbTitleSeq.Size = new System.Drawing.Size(28, 20);
            this.tbTitleSeq.TabIndex = 13;
            // 
            // tbRepriceSeq
            // 
            this.tbRepriceSeq.Location = new System.Drawing.Point(97, 254);
            this.tbRepriceSeq.Name = "tbRepriceSeq";
            this.tbRepriceSeq.Size = new System.Drawing.Size(28, 20);
            this.tbRepriceSeq.TabIndex = 12;
            // 
            // tbPriceSeq
            // 
            this.tbPriceSeq.Location = new System.Drawing.Point(97, 228);
            this.tbPriceSeq.Name = "tbPriceSeq";
            this.tbPriceSeq.Size = new System.Drawing.Size(28, 20);
            this.tbPriceSeq.TabIndex = 11;
            // 
            // tbCostSeq
            // 
            this.tbCostSeq.Location = new System.Drawing.Point(97, 204);
            this.tbCostSeq.Name = "tbCostSeq";
            this.tbCostSeq.Size = new System.Drawing.Size(28, 20);
            this.tbCostSeq.TabIndex = 10;
            // 
            // tbShipSeq
            // 
            this.tbShipSeq.Location = new System.Drawing.Point(97, 176);
            this.tbShipSeq.Name = "tbShipSeq";
            this.tbShipSeq.Size = new System.Drawing.Size(28, 20);
            this.tbShipSeq.TabIndex = 8;
            // 
            // tbSKUSeq
            // 
            this.tbSKUSeq.Location = new System.Drawing.Point(97, 146);
            this.tbSKUSeq.Name = "tbSKUSeq";
            this.tbSKUSeq.Size = new System.Drawing.Size(28, 20);
            this.tbSKUSeq.TabIndex = 6;
            // 
            // tbLocSeq
            // 
            this.tbLocSeq.Location = new System.Drawing.Point(97, 121);
            this.tbLocSeq.Name = "tbLocSeq";
            this.tbLocSeq.Size = new System.Drawing.Size(28, 20);
            this.tbLocSeq.TabIndex = 5;
            // 
            // tbQtySeq
            // 
            this.tbQtySeq.Location = new System.Drawing.Point(97, 94);
            this.tbQtySeq.Name = "tbQtySeq";
            this.tbQtySeq.Size = new System.Drawing.Size(28, 20);
            this.tbQtySeq.TabIndex = 4;
            // 
            // tbUPCSeq
            // 
            this.tbUPCSeq.Location = new System.Drawing.Point(97, 68);
            this.tbUPCSeq.Name = "tbUPCSeq";
            this.tbUPCSeq.Size = new System.Drawing.Size(28, 20);
            this.tbUPCSeq.TabIndex = 2;
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(136, 9);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(552, 39);
            this.label102.TabIndex = 0;
            this.label102.Text = resources.GetString("label102.Text");
            // 
            // mappingTab
            // 
            this.mappingTab.BackColor = System.Drawing.SystemColors.Window;
            this.mappingTab.Controls.Add(this.bClearImportTabMappings);
            this.mappingTab.Controls.Add(this.label185);
            this.mappingTab.Controls.Add(this.tbMapStatus);
            this.mappingTab.Controls.Add(this.lOptionsSaved);
            this.mappingTab.Controls.Add(this.label42);
            this.mappingTab.Controls.Add(this.tbInternational);
            this.mappingTab.Controls.Add(this.tbExpedited);
            this.mappingTab.Controls.Add(this.label45);
            this.mappingTab.Controls.Add(this.bSaveMapping);
            this.mappingTab.Controls.Add(this.bContinueImport);
            this.mappingTab.Controls.Add(this.pictureBox7);
            this.mappingTab.Controls.Add(this.lbMappingNames);
            this.mappingTab.Controls.Add(this.tbMapAddDesc3);
            this.mappingTab.Controls.Add(this.label124);
            this.mappingTab.Controls.Add(this.label125);
            this.mappingTab.Controls.Add(this.tbMapAddDesc2);
            this.mappingTab.Controls.Add(this.tbMapAddTitle);
            this.mappingTab.Controls.Add(this.label126);
            this.mappingTab.Controls.Add(this.tbMapQty);
            this.mappingTab.Controls.Add(this.label131);
            this.mappingTab.Controls.Add(this.label132);
            this.mappingTab.Controls.Add(this.tbMapLocation);
            this.mappingTab.Controls.Add(this.tbMapPrivateNotes);
            this.mappingTab.Controls.Add(this.label133);
            this.mappingTab.Controls.Add(this.tbMapDateSold);
            this.mappingTab.Controls.Add(this.label135);
            this.mappingTab.Controls.Add(this.label136);
            this.mappingTab.Controls.Add(this.tbMapProductID);
            this.mappingTab.Controls.Add(this.label138);
            this.mappingTab.Controls.Add(this.tbMapCondition);
            this.mappingTab.Controls.Add(this.tbMapProdIDType);
            this.mappingTab.Controls.Add(this.label139);
            this.mappingTab.Controls.Add(this.tbMapPubLoc);
            this.mappingTab.Controls.Add(this.label127);
            this.mappingTab.Controls.Add(this.label128);
            this.mappingTab.Controls.Add(this.tbMapMediaCond);
            this.mappingTab.Controls.Add(this.label118);
            this.mappingTab.Controls.Add(this.tbMapUPC);
            this.mappingTab.Controls.Add(this.tbMapASIN);
            this.mappingTab.Controls.Add(this.label119);
            this.mappingTab.Controls.Add(this.label120);
            this.mappingTab.Controls.Add(this.tbMapItemNotes);
            this.mappingTab.Controls.Add(this.label122);
            this.mappingTab.Controls.Add(this.tbMapPrice);
            this.mappingTab.Controls.Add(this.tbMapDesc);
            this.mappingTab.Controls.Add(this.label123);
            this.mappingTab.Controls.Add(this.tbMapPublisher);
            this.mappingTab.Controls.Add(this.label116);
            this.mappingTab.Controls.Add(this.label113);
            this.mappingTab.Controls.Add(this.tbMapTitle);
            this.mappingTab.Controls.Add(this.tbMapSKU);
            this.mappingTab.Controls.Add(this.label38);
            this.mappingTab.Location = new System.Drawing.Point(4, 44);
            this.mappingTab.Name = "mappingTab";
            this.mappingTab.Size = new System.Drawing.Size(865, 550);
            this.mappingTab.TabIndex = 13;
            this.mappingTab.Text = "  Tab Mapping";
            this.mappingTab.ToolTipText = "Maps your tab-delimited file to standard fields for importing";
            // 
            // bClearImportTabMappings
            // 
            this.bClearImportTabMappings.BackColor = System.Drawing.SystemColors.Desktop;
            this.bClearImportTabMappings.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bClearImportTabMappings.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bClearImportTabMappings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bClearImportTabMappings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bClearImportTabMappings.Location = new System.Drawing.Point(734, 15);
            this.bClearImportTabMappings.Name = "bClearImportTabMappings";
            this.bClearImportTabMappings.Size = new System.Drawing.Size(95, 30);
            this.bClearImportTabMappings.TabIndex = 83;
            this.bClearImportTabMappings.Text = "Clear";
            this.bClearImportTabMappings.UseVisualStyleBackColor = false;
            this.bClearImportTabMappings.Click += new System.EventHandler(this.bClearImportTabMappings_Click);
            // 
            // lOptionsSaved
            // 
            this.lOptionsSaved.AutoSize = true;
            this.lOptionsSaved.Location = new System.Drawing.Point(733, 84);
            this.lOptionsSaved.Name = "lOptionsSaved";
            this.lOptionsSaved.Size = new System.Drawing.Size(98, 13);
            this.lOptionsSaved.TabIndex = 77;
            this.lOptionsSaved.Text = "-- Mapping saved.--";
            this.lOptionsSaved.Visible = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(128, 350);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(121, 13);
            this.label42.TabIndex = 76;
            this.label42.Text = "-->International Shipping";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(128, 379);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(113, 13);
            this.label45.TabIndex = 73;
            this.label45.Text = "--> Expedited Shipping";
            // 
            // bSaveMapping
            // 
            this.bSaveMapping.BackColor = System.Drawing.SystemColors.Desktop;
            this.bSaveMapping.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bSaveMapping.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bSaveMapping.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bSaveMapping.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bSaveMapping.Location = new System.Drawing.Point(734, 51);
            this.bSaveMapping.Name = "bSaveMapping";
            this.bSaveMapping.Size = new System.Drawing.Size(95, 30);
            this.bSaveMapping.TabIndex = 70;
            this.bSaveMapping.Text = "Save Mapping";
            this.bSaveMapping.UseVisualStyleBackColor = false;
            this.bSaveMapping.Click += new System.EventHandler(this.bSaveMapping_Click);
            // 
            // bContinueImport
            // 
            this.bContinueImport.BackColor = System.Drawing.SystemColors.Desktop;
            this.bContinueImport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bContinueImport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bContinueImport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bContinueImport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bContinueImport.Location = new System.Drawing.Point(734, 176);
            this.bContinueImport.Name = "bContinueImport";
            this.bContinueImport.Size = new System.Drawing.Size(95, 30);
            this.bContinueImport.TabIndex = 69;
            this.bContinueImport.Text = "Continue";
            this.bContinueImport.UseVisualStyleBackColor = false;
            this.bContinueImport.Click += new System.EventHandler(this.bContinueImport_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBox7.Location = new System.Drawing.Point(708, 99);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(2, 420);
            this.pictureBox7.TabIndex = 80;
            this.pictureBox7.TabStop = false;
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(506, 451);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(111, 13);
            this.label124.TabIndex = 65;
            this.label124.Text = "append to Description";
            this.label124.Visible = false;
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Location = new System.Drawing.Point(506, 425);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(111, 13);
            this.label125.TabIndex = 64;
            this.label125.Text = "append to Description";
            this.label125.Visible = false;
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Location = new System.Drawing.Point(506, 397);
            this.label126.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(78, 13);
            this.label126.TabIndex = 61;
            this.label126.Text = "append to Title";
            this.label126.Visible = false;
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Location = new System.Drawing.Point(128, 212);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(61, 13);
            this.label131.TabIndex = 57;
            this.label131.Text = "--> Quantity";
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Location = new System.Drawing.Point(507, 372);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(63, 13);
            this.label132.TabIndex = 56;
            this.label132.Text = "--> Location";
            this.label132.Visible = false;
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Location = new System.Drawing.Point(507, 344);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(86, 13);
            this.label133.TabIndex = 53;
            this.label133.Text = "--> Private Notes";
            this.label133.Visible = false;
            // 
            // label135
            // 
            this.label135.AutoSize = true;
            this.label135.Location = new System.Drawing.Point(507, 233);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(69, 13);
            this.label135.TabIndex = 49;
            this.label135.Text = "--> Date Sold";
            this.label135.Visible = false;
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Location = new System.Drawing.Point(128, 408);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(131, 13);
            this.label136.TabIndex = 48;
            this.label136.Text = "--> Product ID (UPC/EAN)";
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Location = new System.Drawing.Point(128, 295);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(66, 13);
            this.label138.TabIndex = 44;
            this.label138.Text = "--> Condition";
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Location = new System.Drawing.Point(128, 238);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(138, 13);
            this.label139.TabIndex = 41;
            this.label139.Text = "--> Product Type (DVD/CD)";
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Location = new System.Drawing.Point(507, 131);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(87, 13);
            this.label127.TabIndex = 35;
            this.label127.Text = "--> Mfgr Location";
            this.label127.Visible = false;
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Location = new System.Drawing.Point(507, 263);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(141, 13);
            this.label128.TabIndex = 34;
            this.label128.Text = "--> Book Condition (required)";
            this.label128.Visible = false;
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(506, 179);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(47, 13);
            this.label118.TabIndex = 30;
            this.label118.Text = "--> UPC.";
            this.label118.Visible = false;
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(128, 321);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(47, 13);
            this.label119.TabIndex = 27;
            this.label119.Text = "--> ASIN";
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(128, 266);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(73, 13);
            this.label120.TabIndex = 26;
            this.label120.Text = "--> Item Notes";
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(128, 183);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(46, 13);
            this.label122.TabIndex = 22;
            this.label122.Text = "--> Price";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(127, 131);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(78, 13);
            this.label123.TabIndex = 19;
            this.label123.Text = "--> Description.";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(503, 102);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(132, 13);
            this.label116.TabIndex = 15;
            this.label116.Text = "--> Manufacturer (required)";
            this.label116.Visible = false;
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(127, 102);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(42, 13);
            this.label113.TabIndex = 14;
            this.label113.Text = "--> Title";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(127, 157);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(44, 13);
            this.label38.TabIndex = 0;
            this.label38.Text = "--> SKU";
            // 
            // Import
            // 
            this.Import.BackColor = System.Drawing.SystemColors.Window;
            this.Import.Controls.Add(this.bPrintRejRecords);
            this.Import.Controls.Add(this.label72);
            this.Import.Controls.Add(this.lbRejectedRecords);
            this.Import.Controls.Add(this.groupBox8);
            this.Import.Controls.Add(this.lRecordsRejected);
            this.Import.Controls.Add(this.lRecordsProcessed);
            this.Import.Controls.Add(this.groupBox26);
            this.Import.Controls.Add(this.bImportMedia);
            this.Import.Controls.Add(this.tbFileName);
            this.Import.Controls.Add(this.label1);
            this.Import.Controls.Add(this.bOpenFileDialog);
            this.Import.Controls.Add(this.groupBox1);
            this.Import.Controls.Add(this.groupBox44);
            this.Import.Location = new System.Drawing.Point(4, 44);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(865, 550);
            this.Import.TabIndex = 18;
            this.Import.Text = "  Import Records";
            this.Import.ToolTipText = "Import files into your Book database";
            this.Import.UseVisualStyleBackColor = true;
            // 
            // bPrintRejRecords
            // 
            this.bPrintRejRecords.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bPrintRejRecords.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bPrintRejRecords.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bPrintRejRecords.Location = new System.Drawing.Point(606, 120);
            this.bPrintRejRecords.Name = "bPrintRejRecords";
            this.bPrintRejRecords.Size = new System.Drawing.Size(45, 20);
            this.bPrintRejRecords.TabIndex = 68;
            this.bPrintRejRecords.Text = "Print";
            this.bPrintRejRecords.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bPrintRejRecords.UseVisualStyleBackColor = true;
            this.bPrintRejRecords.Click += new System.EventHandler(this.bPrintRejRecords_Click);
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.Color.Brown;
            this.label72.Location = new System.Drawing.Point(23, 464);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(326, 39);
            this.label72.TabIndex = 67;
            this.label72.Text = "NOTE:Missing number of copies will default to: Copies= 1 and \r\nStatus=\'For Sale\'." +
    "  Items without a conditiion will default to \"Good\".  \r\nMissing req\'d fields wil" +
    "l be set to \"n/a\" (not available).";
            // 
            // lbRejectedRecords
            // 
            this.lbRejectedRecords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbRejectedRecords.FormattingEnabled = true;
            this.lbRejectedRecords.HorizontalScrollbar = true;
            this.lbRejectedRecords.Location = new System.Drawing.Point(437, 148);
            this.lbRejectedRecords.Name = "lbRejectedRecords";
            this.lbRejectedRecords.Size = new System.Drawing.Size(393, 368);
            this.lbRejectedRecords.TabIndex = 65;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.rbMarkAsSold);
            this.groupBox8.Controls.Add(this.rbMarkAsForSale);
            this.groupBox8.Location = new System.Drawing.Point(26, 269);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(339, 72);
            this.groupBox8.TabIndex = 62;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "If a media item has no Status...";
            // 
            // rbMarkAsSold
            // 
            this.rbMarkAsSold.AutoSize = true;
            this.rbMarkAsSold.Location = new System.Drawing.Point(14, 42);
            this.rbMarkAsSold.Name = "rbMarkAsSold";
            this.rbMarkAsSold.Size = new System.Drawing.Size(95, 17);
            this.rbMarkAsSold.TabIndex = 1;
            this.rbMarkAsSold.Text = "Mark it as Sold";
            this.rbMarkAsSold.UseVisualStyleBackColor = true;
            // 
            // rbMarkAsForSale
            // 
            this.rbMarkAsForSale.AutoSize = true;
            this.rbMarkAsForSale.Checked = true;
            this.rbMarkAsForSale.Location = new System.Drawing.Point(15, 19);
            this.rbMarkAsForSale.Name = "rbMarkAsForSale";
            this.rbMarkAsForSale.Size = new System.Drawing.Size(154, 17);
            this.rbMarkAsForSale.TabIndex = 0;
            this.rbMarkAsForSale.TabStop = true;
            this.rbMarkAsForSale.Text = "Mark it as For Sale (default)";
            this.rbMarkAsForSale.UseVisualStyleBackColor = true;
            // 
            // lRecordsRejected
            // 
            this.lRecordsRejected.AutoSize = true;
            this.lRecordsRejected.Location = new System.Drawing.Point(434, 123);
            this.lRecordsRejected.Name = "lRecordsRejected";
            this.lRecordsRejected.Size = new System.Drawing.Size(91, 13);
            this.lRecordsRejected.TabIndex = 58;
            this.lRecordsRejected.Text = "Records rejected:";
            // 
            // lRecordsProcessed
            // 
            this.lRecordsProcessed.AutoSize = true;
            this.lRecordsProcessed.Location = new System.Drawing.Point(434, 102);
            this.lRecordsProcessed.Name = "lRecordsProcessed";
            this.lRecordsProcessed.Size = new System.Drawing.Size(103, 13);
            this.lRecordsProcessed.TabIndex = 57;
            this.lRecordsProcessed.Text = "Records Processed:";
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.label145);
            this.groupBox26.Controls.Add(this.rbCreateNewKey);
            this.groupBox26.Controls.Add(this.rbRejectRecord);
            this.groupBox26.Controls.Add(this.rbReplaceRecord);
            this.groupBox26.Location = new System.Drawing.Point(26, 352);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(339, 98);
            this.groupBox26.TabIndex = 60;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "What do you want to do with duplicate SKUs?";
            // 
            // label145
            // 
            this.label145.AutoSize = true;
            this.label145.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label145.Location = new System.Drawing.Point(207, 71);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(127, 13);
            this.label145.TabIndex = 3;
            this.label145.Text = "existing numeric SKU";
            // 
            // rbRejectRecord
            // 
            this.rbRejectRecord.AutoSize = true;
            this.rbRejectRecord.Checked = true;
            this.rbRejectRecord.Location = new System.Drawing.Point(15, 46);
            this.rbRejectRecord.Name = "rbRejectRecord";
            this.rbRejectRecord.Size = new System.Drawing.Size(220, 17);
            this.rbRejectRecord.TabIndex = 1;
            this.rbRejectRecord.TabStop = true;
            this.rbRejectRecord.Text = "Reject the record being imported (default)";
            // 
            // rbReplaceRecord
            // 
            this.rbReplaceRecord.AutoSize = true;
            this.rbReplaceRecord.Location = new System.Drawing.Point(15, 23);
            this.rbReplaceRecord.Name = "rbReplaceRecord";
            this.rbReplaceRecord.Size = new System.Drawing.Size(156, 17);
            this.rbReplaceRecord.TabIndex = 0;
            this.rbReplaceRecord.Text = "Replace record in database";
            // 
            // bImportMedia
            // 
            this.bImportMedia.BackColor = System.Drawing.SystemColors.Desktop;
            this.bImportMedia.Enabled = false;
            this.bImportMedia.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bImportMedia.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bImportMedia.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bImportMedia.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bImportMedia.Location = new System.Drawing.Point(731, 90);
            this.bImportMedia.Name = "bImportMedia";
            this.bImportMedia.Size = new System.Drawing.Size(71, 30);
            this.bImportMedia.TabIndex = 55;
            this.bImportMedia.Text = "Import";
            this.bImportMedia.UseVisualStyleBackColor = false;
            this.bImportMedia.Click += new System.EventHandler(this.bImportMedia_Click);
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(452, 40);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(292, 20);
            this.tbFileName.TabIndex = 54;
            this.tbFileName.TextChanged += new System.EventHandler(this.tbFileName_TextChanged);
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(387, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 53;
            this.label1.Text = "Filename:";
            // 
            // bOpenFileDialog
            // 
            this.bOpenFileDialog.BackColor = System.Drawing.SystemColors.Desktop;
            this.bOpenFileDialog.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bOpenFileDialog.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bOpenFileDialog.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bOpenFileDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bOpenFileDialog.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bOpenFileDialog.Location = new System.Drawing.Point(759, 36);
            this.bOpenFileDialog.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.bOpenFileDialog.Name = "bOpenFileDialog";
            this.bOpenFileDialog.Size = new System.Drawing.Size(71, 30);
            this.bOpenFileDialog.TabIndex = 52;
            this.bOpenFileDialog.Text = "Browse";
            this.bOpenFileDialog.UseVisualStyleBackColor = false;
            this.bOpenFileDialog.Click += new System.EventHandler(this.bOpenFileDialog_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbTabDelimited);
            this.groupBox1.Controls.Add(this.rbFormatUIEE);
            this.groupBox1.Controls.Add(this.rbImportAZ);
            this.groupBox1.Location = new System.Drawing.Point(26, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 142);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "What is the format of the input file?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(10, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 26);
            this.label2.TabIndex = 69;
            this.label2.Text = "For any format other than Amazon, you must send us the file.  See \r\nweb-based Hel" +
    "p file for details (Getting Started -> Import a file)";
            // 
            // rbFormatUIEE
            // 
            this.rbFormatUIEE.AutoSize = true;
            this.rbFormatUIEE.Enabled = false;
            this.rbFormatUIEE.Location = new System.Drawing.Point(15, 22);
            this.rbFormatUIEE.Name = "rbFormatUIEE";
            this.rbFormatUIEE.Size = new System.Drawing.Size(81, 17);
            this.rbFormatUIEE.TabIndex = 63;
            this.rbFormatUIEE.Text = " CSV format";
            // 
            // groupBox44
            // 
            this.groupBox44.Controls.Add(this.cbDeleteFirst);
            this.groupBox44.Controls.Add(this.cbDontImportSold);
            this.groupBox44.Location = new System.Drawing.Point(26, 178);
            this.groupBox44.Name = "groupBox44";
            this.groupBox44.Size = new System.Drawing.Size(339, 79);
            this.groupBox44.TabIndex = 64;
            this.groupBox44.TabStop = false;
            this.groupBox44.Text = "Special Instructions:";
            // 
            // cbDeleteFirst
            // 
            this.cbDeleteFirst.AutoSize = true;
            this.cbDeleteFirst.Location = new System.Drawing.Point(15, 23);
            this.cbDeleteFirst.Name = "cbDeleteFirst";
            this.cbDeleteFirst.Size = new System.Drawing.Size(216, 17);
            this.cbDeleteFirst.TabIndex = 40;
            this.cbDeleteFirst.Text = "Delete existing records in database first?";
            // 
            // cbDontImportSold
            // 
            this.cbDontImportSold.AutoSize = true;
            this.cbDontImportSold.Location = new System.Drawing.Point(15, 52);
            this.cbDontImportSold.Name = "cbDontImportSold";
            this.cbDontImportSold.Size = new System.Drawing.Size(251, 17);
            this.cbDontImportSold.TabIndex = 43;
            this.cbDontImportSold.Text = "Do not import media items with a Status of \'Sold\'";
            // 
            // UIDandPswdMaintenance
            // 
            this.UIDandPswdMaintenance.BackColor = System.Drawing.SystemColors.Window;
            this.UIDandPswdMaintenance.Controls.Add(this.tabControl5);
            this.UIDandPswdMaintenance.Location = new System.Drawing.Point(4, 44);
            this.UIDandPswdMaintenance.Name = "UIDandPswdMaintenance";
            this.UIDandPswdMaintenance.Size = new System.Drawing.Size(865, 550);
            this.UIDandPswdMaintenance.TabIndex = 17;
            this.UIDandPswdMaintenance.Text = " User IDs & Passwords";
            this.UIDandPswdMaintenance.ToolTipText = "UserID and Password maintenance";
            this.UIDandPswdMaintenance.UseVisualStyleBackColor = true;
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabListingVenues);
            this.tabControl5.Controls.Add(this.tabGetKeys);
            this.tabControl5.Location = new System.Drawing.Point(5, 3);
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.Size = new System.Drawing.Size(857, 544);
            this.tabControl5.TabIndex = 237;
            // 
            // tabListingVenues
            // 
            this.tabListingVenues.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabListingVenues.Controls.Add(this.lMsgSettingsSaved);
            this.tabListingVenues.Controls.Add(this.bSaveUIDs);
            this.tabListingVenues.Controls.Add(this.UIDdataGridView);
            this.tabListingVenues.Location = new System.Drawing.Point(4, 22);
            this.tabListingVenues.Name = "tabListingVenues";
            this.tabListingVenues.Padding = new System.Windows.Forms.Padding(3);
            this.tabListingVenues.Size = new System.Drawing.Size(849, 518);
            this.tabListingVenues.TabIndex = 0;
            this.tabListingVenues.Text = "  Listing Venues  ";
            // 
            // lMsgSettingsSaved
            // 
            this.lMsgSettingsSaved.AutoSize = true;
            this.lMsgSettingsSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lMsgSettingsSaved.Location = new System.Drawing.Point(742, 488);
            this.lMsgSettingsSaved.Name = "lMsgSettingsSaved";
            this.lMsgSettingsSaved.Size = new System.Drawing.Size(79, 13);
            this.lMsgSettingsSaved.TabIndex = 225;
            this.lMsgSettingsSaved.Text = "Settings Saved";
            // 
            // bSaveUIDs
            // 
            this.bSaveUIDs.BackColor = System.Drawing.SystemColors.Desktop;
            this.bSaveUIDs.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bSaveUIDs.FlatAppearance.BorderSize = 0;
            this.bSaveUIDs.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bSaveUIDs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bSaveUIDs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bSaveUIDs.Location = new System.Drawing.Point(577, 482);
            this.bSaveUIDs.Name = "bSaveUIDs";
            this.bSaveUIDs.Size = new System.Drawing.Size(124, 25);
            this.bSaveUIDs.TabIndex = 224;
            this.bSaveUIDs.Text = "Save UIDs and Keys";
            this.bSaveUIDs.UseVisualStyleBackColor = false;
            this.bSaveUIDs.Click += new System.EventHandler(this.bSaveUIDs_Click);
            // 
            // UIDdataGridView
            // 
            this.UIDdataGridView.AllowUserToAddRows = false;
            this.UIDdataGridView.AllowUserToDeleteRows = false;
            this.UIDdataGridView.AllowUserToResizeColumns = false;
            this.UIDdataGridView.AllowUserToResizeRows = false;
            this.UIDdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.UIDdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.UIDdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvListingServiceID,
            this.dgvUserID,
            this.dgvPassword,
            this.FTPAddr,
            this.FTPDir,
            this.FTPFormat});
            this.UIDdataGridView.Location = new System.Drawing.Point(32, 8);
            this.UIDdataGridView.MultiSelect = false;
            this.UIDdataGridView.Name = "UIDdataGridView";
            this.UIDdataGridView.RowHeadersVisible = false;
            this.UIDdataGridView.RowHeadersWidth = 60;
            this.UIDdataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.UIDdataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UIDdataGridView.Size = new System.Drawing.Size(793, 464);
            this.UIDdataGridView.TabIndex = 223;
            // 
            // dgvListingServiceID
            // 
            this.dgvListingServiceID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvListingServiceID.DataPropertyName = "listingservice";
            this.dgvListingServiceID.HeaderText = "Listing Service";
            this.dgvListingServiceID.MaxInputLength = 35;
            this.dgvListingServiceID.Name = "dgvListingServiceID";
            this.dgvListingServiceID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListingServiceID.Width = 160;
            // 
            // dgvUserID
            // 
            this.dgvUserID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvUserID.DataPropertyName = "uid";
            this.dgvUserID.HeaderText = "User ID";
            this.dgvUserID.MaxInputLength = 35;
            this.dgvUserID.Name = "dgvUserID";
            this.dgvUserID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUserID.Width = 120;
            // 
            // dgvPassword
            // 
            this.dgvPassword.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvPassword.DataPropertyName = "pwd";
            this.dgvPassword.HeaderText = "Password";
            this.dgvPassword.MaxInputLength = 15;
            this.dgvPassword.Name = "dgvPassword";
            this.dgvPassword.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPassword.Width = 80;
            // 
            // FTPAddr
            // 
            this.FTPAddr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FTPAddr.DataPropertyName = "ftpaddr";
            this.FTPAddr.HeaderText = "FTP Address";
            this.FTPAddr.MaxInputLength = 35;
            this.FTPAddr.Name = "FTPAddr";
            this.FTPAddr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FTPAddr.Width = 220;
            // 
            // FTPDir
            // 
            this.FTPDir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FTPDir.DataPropertyName = "ftpdir";
            this.FTPDir.HeaderText = "FTP Directory";
            this.FTPDir.MaxInputLength = 35;
            this.FTPDir.Name = "FTPDir";
            this.FTPDir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FTPDir.Width = 105;
            // 
            // FTPFormat
            // 
            this.FTPFormat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FTPFormat.DataPropertyName = "filefmt";
            this.FTPFormat.HeaderText = "File Format";
            this.FTPFormat.MaxInputLength = 5;
            this.FTPFormat.Name = "FTPFormat";
            this.FTPFormat.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FTPFormat.Width = 85;
            // 
            // tabGetKeys
            // 
            this.tabGetKeys.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabGetKeys.Controls.Add(this.bSubscribeFileEx);
            this.tabGetKeys.Controls.Add(this.label189);
            this.tabGetKeys.Controls.Add(this.label22);
            this.tabGetKeys.Controls.Add(this.tbHalfToken);
            this.tabGetKeys.Controls.Add(this.bGetHalfToken);
            this.tabGetKeys.Controls.Add(this.panel7);
            this.tabGetKeys.Controls.Add(this.label220);
            this.tabGetKeys.Controls.Add(this.label219);
            this.tabGetKeys.Controls.Add(this.label94);
            this.tabGetKeys.Controls.Add(this.lAssocTag);
            this.tabGetKeys.Controls.Add(this.label218);
            this.tabGetKeys.Controls.Add(this.label209);
            this.tabGetKeys.Controls.Add(this.tbAZAssocTag);
            this.tabGetKeys.Controls.Add(this.tbMerchantID);
            this.tabGetKeys.Controls.Add(this.label216);
            this.tabGetKeys.Controls.Add(this.bCopyDevKey);
            this.tabGetKeys.Controls.Add(this.tbDevKey);
            this.tabGetKeys.Controls.Add(this.label215);
            this.tabGetKeys.Controls.Add(this.panel13);
            this.tabGetKeys.Controls.Add(this.panel11);
            this.tabGetKeys.Controls.Add(this.bGetMWSKeys);
            this.tabGetKeys.Controls.Add(this.label213);
            this.tabGetKeys.Controls.Add(this.tbMarketplaceID);
            this.tabGetKeys.Controls.Add(this.label41);
            this.tabGetKeys.Controls.Add(this.tbAWSSecretKey);
            this.tabGetKeys.Controls.Add(this.bGetAccessKey);
            this.tabGetKeys.Controls.Add(this.label87);
            this.tabGetKeys.Controls.Add(this.tbAWSKey);
            this.tabGetKeys.Location = new System.Drawing.Point(4, 22);
            this.tabGetKeys.Name = "tabGetKeys";
            this.tabGetKeys.Padding = new System.Windows.Forms.Padding(3);
            this.tabGetKeys.Size = new System.Drawing.Size(849, 518);
            this.tabGetKeys.TabIndex = 1;
            this.tabGetKeys.Text = "    Keys    ";
            // 
            // label189
            // 
            this.label189.AutoSize = true;
            this.label189.ForeColor = System.Drawing.Color.Firebrick;
            this.label189.Location = new System.Drawing.Point(18, 400);
            this.label189.Name = "label189";
            this.label189.Size = new System.Drawing.Size(356, 13);
            this.label189.TabIndex = 337;
            this.label189.Text = "If you are going to upload to Half.com, you must have a Half.com Token.  ";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel7.Location = new System.Drawing.Point(24, 377);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(800, 2);
            this.panel7.TabIndex = 333;
            // 
            // label220
            // 
            this.label220.AutoSize = true;
            this.label220.ForeColor = System.Drawing.Color.Firebrick;
            this.label220.Location = new System.Drawing.Point(18, 285);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(785, 13);
            this.label220.TabIndex = 332;
            this.label220.Text = "If you are going to upload to Amazon, you must have these two IDs, in addition to" +
    " the AWS keys.  No website is needed, but you must have a Pro Merchant account.";
            // 
            // label219
            // 
            this.label219.AutoSize = true;
            this.label219.ForeColor = System.Drawing.Color.Firebrick;
            this.label219.Location = new System.Drawing.Point(22, 77);
            this.label219.Name = "label219";
            this.label219.Size = new System.Drawing.Size(573, 39);
            this.label219.TabIndex = 331;
            this.label219.Text = resources.GetString("label219.Text");
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label94.Location = new System.Drawing.Point(18, 24);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(204, 13);
            this.label94.TabIndex = 330;
            this.label94.Text = "Developer Name:  Prager Software";
            // 
            // lAssocTag
            // 
            this.lAssocTag.AutoSize = true;
            this.lAssocTag.ForeColor = System.Drawing.Color.Firebrick;
            this.lAssocTag.Location = new System.Drawing.Point(167, 204);
            this.lAssocTag.Name = "lAssocTag";
            this.lAssocTag.Size = new System.Drawing.Size(529, 39);
            this.lAssocTag.TabIndex = 325;
            this.lAssocTag.Text = resources.GetString("lAssocTag.Text");
            this.lAssocTag.Visible = false;
            // 
            // label216
            // 
            this.label216.AutoSize = true;
            this.label216.Location = new System.Drawing.Point(402, 321);
            this.label216.Name = "label216";
            this.label216.Size = new System.Drawing.Size(69, 13);
            this.label216.TabIndex = 318;
            this.label216.Text = "Merchant ID:";
            // 
            // bCopyDevKey
            // 
            this.bCopyDevKey.Location = new System.Drawing.Point(504, 19);
            this.bCopyDevKey.Name = "bCopyDevKey";
            this.bCopyDevKey.Size = new System.Drawing.Size(110, 23);
            this.bCopyDevKey.TabIndex = 317;
            this.bCopyDevKey.Text = "Copy to clipboard";
            this.bCopyDevKey.UseVisualStyleBackColor = true;
            this.bCopyDevKey.Click += new System.EventHandler(this.bCopyDevKey_Click);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel13.Location = new System.Drawing.Point(24, 264);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(800, 2);
            this.panel13.TabIndex = 314;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel11.Location = new System.Drawing.Point(24, 60);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(800, 2);
            this.panel11.TabIndex = 313;
            // 
            // Reports
            // 
            this.Reports.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Reports.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Reports.Controls.Add(this.tabControl2);
            this.Reports.Location = new System.Drawing.Point(4, 44);
            this.Reports.Name = "Reports";
            this.Reports.Size = new System.Drawing.Size(865, 550);
            this.Reports.TabIndex = 15;
            this.Reports.Text = " Reports  ";
            this.Reports.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.Aging);
            this.tabControl2.Controls.Add(this.Sales);
            this.tabControl2.Controls.Add(this.Inventory);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(834, 543);
            this.tabControl2.TabIndex = 5;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // Aging
            // 
            this.Aging.BackColor = System.Drawing.SystemColors.Window;
            this.Aging.Controls.Add(this.bGenerateAgingReport);
            this.Aging.Controls.Add(this.listView2);
            this.Aging.Controls.Add(this.cbAgingFilter);
            this.Aging.Controls.Add(this.label146);
            this.Aging.Controls.Add(this.tbAgingDays);
            this.Aging.Location = new System.Drawing.Point(4, 22);
            this.Aging.Name = "Aging";
            this.Aging.Padding = new System.Windows.Forms.Padding(3);
            this.Aging.Size = new System.Drawing.Size(826, 517);
            this.Aging.TabIndex = 0;
            this.Aging.Text = "Aging Report";
            this.Aging.UseVisualStyleBackColor = true;
            // 
            // bGenerateAgingReport
            // 
            this.bGenerateAgingReport.BackColor = System.Drawing.SystemColors.Desktop;
            this.bGenerateAgingReport.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.bGenerateAgingReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bGenerateAgingReport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bGenerateAgingReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bGenerateAgingReport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bGenerateAgingReport.Location = new System.Drawing.Point(676, 15);
            this.bGenerateAgingReport.Name = "bGenerateAgingReport";
            this.bGenerateAgingReport.Size = new System.Drawing.Size(98, 27);
            this.bGenerateAgingReport.TabIndex = 4;
            this.bGenerateAgingReport.Text = "Generate Report";
            this.bGenerateAgingReport.UseVisualStyleBackColor = false;
            this.bGenerateAgingReport.Click += new System.EventHandler(this.bGenerateAgingReport_Click);
            // 
            // listView2
            // 
            this.listView2.AllowColumnReorder = true;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(10, 57);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(805, 464);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "SKU";
            this.columnHeader7.Width = 90;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Title";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 405;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "UPC/EAN";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 90;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = " Location";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Price    ";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Age (Days)";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader12.Width = 75;
            // 
            // cbAgingFilter
            // 
            this.cbAgingFilter.AutoSize = true;
            this.cbAgingFilter.Location = new System.Drawing.Point(407, 19);
            this.cbAgingFilter.Name = "cbAgingFilter";
            this.cbAgingFilter.Size = new System.Drawing.Size(138, 17);
            this.cbAgingFilter.TabIndex = 1;
            this.cbAgingFilter.Text = "Only select items OVER";
            this.cbAgingFilter.UseVisualStyleBackColor = true;
            // 
            // label146
            // 
            this.label146.AutoSize = true;
            this.label146.Location = new System.Drawing.Point(593, 20);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(32, 13);
            this.label146.TabIndex = 3;
            this.label146.Text = "days.";
            // 
            // tbAgingDays
            // 
            this.tbAgingDays.Location = new System.Drawing.Point(553, 17);
            this.tbAgingDays.Name = "tbAgingDays";
            this.tbAgingDays.Size = new System.Drawing.Size(34, 20);
            this.tbAgingDays.TabIndex = 2;
            // 
            // Sales
            // 
            this.Sales.BackColor = System.Drawing.SystemColors.Window;
            this.Sales.Controls.Add(this.gbReportTime);
            this.Sales.Controls.Add(this.bCreateSalesReport);
            this.Sales.Controls.Add(this.lvSalesReport);
            this.Sales.Location = new System.Drawing.Point(4, 22);
            this.Sales.Name = "Sales";
            this.Sales.Padding = new System.Windows.Forms.Padding(3);
            this.Sales.Size = new System.Drawing.Size(826, 517);
            this.Sales.TabIndex = 1;
            this.Sales.Text = "Sales Report";
            this.Sales.UseVisualStyleBackColor = true;
            // 
            // gbReportTime
            // 
            this.gbReportTime.Controls.Add(this.radioButton10);
            this.gbReportTime.Controls.Add(this.radioButton4);
            this.gbReportTime.Controls.Add(this.radioButton9);
            this.gbReportTime.Controls.Add(this.radioButton8);
            this.gbReportTime.Controls.Add(this.radioButton7);
            this.gbReportTime.Controls.Add(this.radioButton6);
            this.gbReportTime.Controls.Add(this.radioButton5);
            this.gbReportTime.Controls.Add(this.radioButton3);
            this.gbReportTime.Location = new System.Drawing.Point(25, 6);
            this.gbReportTime.Name = "gbReportTime";
            this.gbReportTime.Size = new System.Drawing.Size(670, 31);
            this.gbReportTime.TabIndex = 51;
            this.gbReportTime.TabStop = false;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(351, 10);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(60, 17);
            this.radioButton10.TabIndex = 5;
            this.radioButton10.TabStop = true;
            this.radioButton10.Tag = "4";
            this.radioButton10.Text = "2nd Qtr";
            this.radioButton10.UseVisualStyleBackColor = true;
            this.radioButton10.CheckedChanged += new System.EventHandler(this.reportingPeriod_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(585, 10);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(58, 17);
            this.radioButton4.TabIndex = 8;
            this.radioButton4.TabStop = true;
            this.radioButton4.Tag = "7";
            this.radioButton4.Text = "Annual";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.reportingPeriod_CheckedChanged);
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(431, 10);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(57, 17);
            this.radioButton9.TabIndex = 6;
            this.radioButton9.TabStop = true;
            this.radioButton9.Tag = "5";
            this.radioButton9.Text = "3rd Qtr";
            this.radioButton9.UseVisualStyleBackColor = true;
            this.radioButton9.CheckedChanged += new System.EventHandler(this.reportingPeriod_CheckedChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(508, 10);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(57, 17);
            this.radioButton8.TabIndex = 7;
            this.radioButton8.TabStop = true;
            this.radioButton8.Tag = "6";
            this.radioButton8.Text = "4th Qtr";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.reportingPeriod_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(94, 10);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(79, 17);
            this.radioButton7.TabIndex = 2;
            this.radioButton7.TabStop = true;
            this.radioButton7.Tag = "1";
            this.radioButton7.Text = "Prev Week";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.reportingPeriod_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(193, 10);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(62, 17);
            this.radioButton6.TabIndex = 3;
            this.radioButton6.TabStop = true;
            this.radioButton6.Tag = "2";
            this.radioButton6.Text = "Monthly";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.reportingPeriod_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(275, 10);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(56, 17);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Tag = "3";
            this.radioButton5.Text = "1st Qtr";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.reportingPeriod_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(19, 9);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(55, 17);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Tag = "0";
            this.radioButton3.Text = "Today";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.reportingPeriod_CheckedChanged);
            // 
            // bCreateSalesReport
            // 
            this.bCreateSalesReport.BackColor = System.Drawing.SystemColors.Desktop;
            this.bCreateSalesReport.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.bCreateSalesReport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bCreateSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bCreateSalesReport.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCreateSalesReport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bCreateSalesReport.Location = new System.Drawing.Point(739, 12);
            this.bCreateSalesReport.Name = "bCreateSalesReport";
            this.bCreateSalesReport.Size = new System.Drawing.Size(48, 25);
            this.bCreateSalesReport.TabIndex = 49;
            this.bCreateSalesReport.Text = "Create";
            this.bCreateSalesReport.UseVisualStyleBackColor = false;
            this.bCreateSalesReport.Click += new System.EventHandler(this.bCreateSalesReport_Click);
            // 
            // lvSalesReport
            // 
            this.lvSalesReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cSKU,
            this.cTitle,
            this.cUPC,
            this.cDateSold,
            this.cPrice,
            this.cSRInvoice,
            this.cSRCustNbr});
            this.lvSalesReport.GridLines = true;
            this.lvSalesReport.Location = new System.Drawing.Point(6, 43);
            this.lvSalesReport.Name = "lvSalesReport";
            this.lvSalesReport.Size = new System.Drawing.Size(814, 471);
            this.lvSalesReport.TabIndex = 0;
            this.lvSalesReport.UseCompatibleStateImageBehavior = false;
            this.lvSalesReport.View = System.Windows.Forms.View.Details;
            // 
            // cSKU
            // 
            this.cSKU.Text = "       SKU";
            this.cSKU.Width = 100;
            // 
            // cTitle
            // 
            this.cTitle.Text = "Title";
            this.cTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cTitle.Width = 300;
            // 
            // cUPC
            // 
            this.cUPC.Text = "UPC/EAN";
            this.cUPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cUPC.Width = 90;
            // 
            // cDateSold
            // 
            this.cDateSold.Text = "    Date Sold";
            this.cDateSold.Width = 80;
            // 
            // cPrice
            // 
            this.cPrice.Text = "Price    ";
            this.cPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cSRInvoice
            // 
            this.cSRInvoice.Text = "  Invoice Nbr";
            this.cSRInvoice.Width = 80;
            // 
            // cSRCustNbr
            // 
            this.cSRCustNbr.Text = "   Customer";
            this.cSRCustNbr.Width = 80;
            // 
            // Inventory
            // 
            this.Inventory.Controls.Add(this.lFinished);
            this.Inventory.Controls.Add(this.bPageSetup3);
            this.Inventory.Controls.Add(this.richTextBox1);
            this.Inventory.Controls.Add(this.groupBox30);
            this.Inventory.Controls.Add(this.bInvReport);
            this.Inventory.Controls.Add(this.groupBox29);
            this.Inventory.Controls.Add(this.gbFields);
            this.Inventory.Location = new System.Drawing.Point(4, 22);
            this.Inventory.Name = "Inventory";
            this.Inventory.Size = new System.Drawing.Size(826, 517);
            this.Inventory.TabIndex = 2;
            this.Inventory.Text = "Inventory Report";
            this.Inventory.UseVisualStyleBackColor = true;
            // 
            // lFinished
            // 
            this.lFinished.AutoSize = true;
            this.lFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFinished.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lFinished.Location = new System.Drawing.Point(709, 175);
            this.lFinished.Name = "lFinished";
            this.lFinished.Size = new System.Drawing.Size(55, 13);
            this.lFinished.TabIndex = 6;
            this.lFinished.Text = "Finished...";
            this.lFinished.Visible = false;
            // 
            // bPageSetup3
            // 
            this.bPageSetup3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.bPageSetup3.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bPageSetup3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bPageSetup3.Location = new System.Drawing.Point(712, 222);
            this.bPageSetup3.Name = "bPageSetup3";
            this.bPageSetup3.Size = new System.Drawing.Size(80, 31);
            this.bPageSetup3.TabIndex = 5;
            this.bPageSetup3.Text = "Page Setup";
            this.bPageSetup3.UseVisualStyleBackColor = true;
            this.bPageSetup3.Visible = false;
            this.bPageSetup3.Click += new System.EventHandler(this.bPageSetup3_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(752, 270);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(40, 41);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.rbIRFile);
            this.groupBox30.Controls.Add(this.rbIRClipBoard);
            this.groupBox30.Controls.Add(this.rbIRPrint);
            this.groupBox30.Location = new System.Drawing.Point(699, 21);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(111, 93);
            this.groupBox30.TabIndex = 3;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "Output to?";
            // 
            // rbIRFile
            // 
            this.rbIRFile.AutoSize = true;
            this.rbIRFile.Location = new System.Drawing.Point(10, 64);
            this.rbIRFile.Name = "rbIRFile";
            this.rbIRFile.Size = new System.Drawing.Size(41, 17);
            this.rbIRFile.TabIndex = 2;
            this.rbIRFile.TabStop = true;
            this.rbIRFile.Text = "File";
            this.rbIRFile.UseVisualStyleBackColor = true;
            // 
            // rbIRClipBoard
            // 
            this.rbIRClipBoard.AutoSize = true;
            this.rbIRClipBoard.Location = new System.Drawing.Point(10, 41);
            this.rbIRClipBoard.Name = "rbIRClipBoard";
            this.rbIRClipBoard.Size = new System.Drawing.Size(69, 17);
            this.rbIRClipBoard.TabIndex = 1;
            this.rbIRClipBoard.TabStop = true;
            this.rbIRClipBoard.Text = "Clipboard";
            this.rbIRClipBoard.UseVisualStyleBackColor = true;
            // 
            // rbIRPrint
            // 
            this.rbIRPrint.AutoSize = true;
            this.rbIRPrint.Location = new System.Drawing.Point(10, 18);
            this.rbIRPrint.Name = "rbIRPrint";
            this.rbIRPrint.Size = new System.Drawing.Size(46, 17);
            this.rbIRPrint.TabIndex = 0;
            this.rbIRPrint.TabStop = true;
            this.rbIRPrint.Text = "Print";
            this.rbIRPrint.UseVisualStyleBackColor = true;
            // 
            // groupBox29
            // 
            this.groupBox29.Controls.Add(this.checkBox1);
            this.groupBox29.Controls.Add(this.checkBox2);
            this.groupBox29.Controls.Add(this.checkBox3);
            this.groupBox29.Controls.Add(this.checkBox4);
            this.groupBox29.Controls.Add(this.checkBox5);
            this.groupBox29.Controls.Add(this.checkBox6);
            this.groupBox29.Controls.Add(this.checkBox7);
            this.groupBox29.Controls.Add(this.checkBox8);
            this.groupBox29.Controls.Add(this.checkBox9);
            this.groupBox29.Controls.Add(this.checkBox10);
            this.groupBox29.Controls.Add(this.checkBox11);
            this.groupBox29.Controls.Add(this.checkBox12);
            this.groupBox29.Controls.Add(this.checkBox13);
            this.groupBox29.Controls.Add(this.checkBox14);
            this.groupBox29.Controls.Add(this.checkBox15);
            this.groupBox29.Controls.Add(this.checkBox16);
            this.groupBox29.Controls.Add(this.checkBox17);
            this.groupBox29.Controls.Add(this.checkBox18);
            this.groupBox29.Controls.Add(this.checkBox19);
            this.groupBox29.Controls.Add(this.checkBox20);
            this.groupBox29.Controls.Add(this.checkBox21);
            this.groupBox29.Controls.Add(this.checkBox22);
            this.groupBox29.Controls.Add(this.checkBox23);
            this.groupBox29.Enabled = false;
            this.groupBox29.Location = new System.Drawing.Point(376, 21);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Size = new System.Drawing.Size(301, 457);
            this.groupBox29.TabIndex = 1;
            this.groupBox29.TabStop = false;
            this.groupBox29.Text = "Sort on (any two fields)";
            this.groupBox29.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(168, 64);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 54;
            this.checkBox1.Text = "Media Type";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(22, 196);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(47, 17);
            this.checkBox2.TabIndex = 46;
            this.checkBox2.Text = "Cost";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(168, 97);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(83, 17);
            this.checkBox3.TabIndex = 33;
            this.checkBox3.Text = "Date Added";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(22, 64);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(46, 17);
            this.checkBox4.TabIndex = 43;
            this.checkBox4.Text = "Title";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(168, 130);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(93, 17);
            this.checkBox5.TabIndex = 34;
            this.checkBox5.Text = "Date Updated";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(168, 163);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(62, 17);
            this.checkBox6.TabIndex = 35;
            this.checkBox6.Text = "Catalog";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(22, 31);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(48, 17);
            this.checkBox7.TabIndex = 42;
            this.checkBox7.Text = "SKU";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(168, 196);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(54, 17);
            this.checkBox8.TabIndex = 36;
            this.checkBox8.Text = "Notes";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(168, 229);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(56, 17);
            this.checkBox9.TabIndex = 37;
            this.checkBox9.Text = "Status";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(168, 262);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(101, 17);
            this.checkBox10.TabIndex = 38;
            this.checkBox10.Text = "Invoice Number";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(168, 31);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(58, 17);
            this.checkBox11.TabIndex = 53;
            this.checkBox11.Text = "Edition";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(168, 295);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(123, 17);
            this.checkBox12.TabIndex = 39;
            this.checkBox12.Text = "Do Not Reprice Flag";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(22, 97);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(78, 17);
            this.checkBox13.TabIndex = 32;
            this.checkBox13.Text = "UPC/ASIN";
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(22, 130);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(67, 17);
            this.checkBox14.TabIndex = 44;
            this.checkBox14.Text = "Location";
            this.checkBox14.UseVisualStyleBackColor = true;
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(22, 392);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(102, 17);
            this.checkBox15.TabIndex = 52;
            this.checkBox15.Text = "Media Condition";
            this.checkBox15.UseVisualStyleBackColor = true;
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(168, 328);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(65, 17);
            this.checkBox16.TabIndex = 40;
            this.checkBox16.Text = "Quantity";
            this.checkBox16.UseVisualStyleBackColor = true;
            // 
            // checkBox17
            // 
            this.checkBox17.AutoSize = true;
            this.checkBox17.Location = new System.Drawing.Point(22, 163);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(50, 17);
            this.checkBox17.TabIndex = 45;
            this.checkBox17.Text = "Price";
            this.checkBox17.UseVisualStyleBackColor = true;
            // 
            // checkBox18
            // 
            this.checkBox18.AutoSize = true;
            this.checkBox18.Location = new System.Drawing.Point(168, 361);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(67, 17);
            this.checkBox18.TabIndex = 41;
            this.checkBox18.Text = "Shipping";
            this.checkBox18.UseVisualStyleBackColor = true;
            // 
            // checkBox19
            // 
            this.checkBox19.AutoSize = true;
            this.checkBox19.Location = new System.Drawing.Point(22, 229);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(47, 17);
            this.checkBox19.TabIndex = 47;
            this.checkBox19.Text = "Mfgr";
            this.checkBox19.UseVisualStyleBackColor = true;
            // 
            // checkBox20
            // 
            this.checkBox20.AutoSize = true;
            this.checkBox20.Location = new System.Drawing.Point(22, 262);
            this.checkBox20.Name = "checkBox20";
            this.checkBox20.Size = new System.Drawing.Size(91, 17);
            this.checkBox20.TabIndex = 48;
            this.checkBox20.Text = "Mfgr Location";
            this.checkBox20.UseVisualStyleBackColor = true;
            // 
            // checkBox21
            // 
            this.checkBox21.AutoSize = true;
            this.checkBox21.Location = new System.Drawing.Point(22, 295);
            this.checkBox21.Name = "checkBox21";
            this.checkBox21.Size = new System.Drawing.Size(97, 17);
            this.checkBox21.TabIndex = 49;
            this.checkBox21.Text = "Year Published";
            this.checkBox21.UseVisualStyleBackColor = true;
            // 
            // checkBox22
            // 
            this.checkBox22.AutoSize = true;
            this.checkBox22.Location = new System.Drawing.Point(22, 328);
            this.checkBox22.Name = "checkBox22";
            this.checkBox22.Size = new System.Drawing.Size(72, 17);
            this.checkBox22.TabIndex = 50;
            this.checkBox22.Text = "Keywords";
            this.checkBox22.UseVisualStyleBackColor = true;
            // 
            // checkBox23
            // 
            this.checkBox23.AutoSize = true;
            this.checkBox23.Location = new System.Drawing.Point(22, 361);
            this.checkBox23.Name = "checkBox23";
            this.checkBox23.Size = new System.Drawing.Size(79, 17);
            this.checkBox23.TabIndex = 51;
            this.checkBox23.Text = "Description";
            this.checkBox23.UseVisualStyleBackColor = true;
            // 
            // gbFields
            // 
            this.gbFields.Controls.Add(this.invRepSelAll);
            this.gbFields.Controls.Add(this.cbIRType);
            this.gbFields.Controls.Add(this.cbIRCost);
            this.gbFields.Controls.Add(this.cbIRDateA);
            this.gbFields.Controls.Add(this.cbIRTitle);
            this.gbFields.Controls.Add(this.cbIRDateU);
            this.gbFields.Controls.Add(this.cbIRCat);
            this.gbFields.Controls.Add(this.cbIRSKU);
            this.gbFields.Controls.Add(this.cbIRNotes);
            this.gbFields.Controls.Add(this.cbIRStatus);
            this.gbFields.Controls.Add(this.cbIRInvoice);
            this.gbFields.Controls.Add(this.cbIREdition);
            this.gbFields.Controls.Add(this.cbIRUPC);
            this.gbFields.Controls.Add(this.cbIRLocn);
            this.gbFields.Controls.Add(this.cbIRMediaCond);
            this.gbFields.Controls.Add(this.cbIRQty);
            this.gbFields.Controls.Add(this.cbIRPrice);
            this.gbFields.Controls.Add(this.cbIRAdultContent);
            this.gbFields.Controls.Add(this.cbIRPub);
            this.gbFields.Controls.Add(this.cbIRASIN);
            this.gbFields.Controls.Add(this.cbIRPubYear);
            this.gbFields.Controls.Add(this.cbIRPrivNotes);
            this.gbFields.Controls.Add(this.cbIRDesc);
            this.gbFields.Location = new System.Drawing.Point(36, 21);
            this.gbFields.Name = "gbFields";
            this.gbFields.Size = new System.Drawing.Size(301, 457);
            this.gbFields.TabIndex = 0;
            this.gbFields.TabStop = false;
            this.gbFields.Text = "Fields to include";
            // 
            // invRepSelAll
            // 
            this.invRepSelAll.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.invRepSelAll.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.invRepSelAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.invRepSelAll.Location = new System.Drawing.Point(217, 426);
            this.invRepSelAll.Name = "invRepSelAll";
            this.invRepSelAll.Size = new System.Drawing.Size(74, 23);
            this.invRepSelAll.TabIndex = 32;
            this.invRepSelAll.Text = "Select All";
            this.invRepSelAll.UseVisualStyleBackColor = true;
            this.invRepSelAll.Click += new System.EventHandler(this.invRepSelAll_Click);
            // 
            // cbIRType
            // 
            this.cbIRType.AutoSize = true;
            this.cbIRType.Location = new System.Drawing.Point(167, 97);
            this.cbIRType.Name = "cbIRType";
            this.cbIRType.Size = new System.Drawing.Size(82, 17);
            this.cbIRType.TabIndex = 31;
            this.cbIRType.Text = "Media Type";
            this.cbIRType.UseVisualStyleBackColor = true;
            // 
            // cbIRCost
            // 
            this.cbIRCost.AutoSize = true;
            this.cbIRCost.Location = new System.Drawing.Point(21, 196);
            this.cbIRCost.Name = "cbIRCost";
            this.cbIRCost.Size = new System.Drawing.Size(47, 17);
            this.cbIRCost.TabIndex = 20;
            this.cbIRCost.Text = "Cost";
            this.cbIRCost.UseVisualStyleBackColor = true;
            // 
            // cbIRDateA
            // 
            this.cbIRDateA.AutoSize = true;
            this.cbIRDateA.Location = new System.Drawing.Point(167, 130);
            this.cbIRDateA.Name = "cbIRDateA";
            this.cbIRDateA.Size = new System.Drawing.Size(83, 17);
            this.cbIRDateA.TabIndex = 2;
            this.cbIRDateA.Text = "Date Added";
            this.cbIRDateA.UseVisualStyleBackColor = true;
            // 
            // cbIRTitle
            // 
            this.cbIRTitle.AutoSize = true;
            this.cbIRTitle.Location = new System.Drawing.Point(21, 64);
            this.cbIRTitle.Name = "cbIRTitle";
            this.cbIRTitle.Size = new System.Drawing.Size(46, 17);
            this.cbIRTitle.TabIndex = 15;
            this.cbIRTitle.Text = "Title";
            this.cbIRTitle.UseVisualStyleBackColor = true;
            // 
            // cbIRDateU
            // 
            this.cbIRDateU.AutoSize = true;
            this.cbIRDateU.Location = new System.Drawing.Point(167, 163);
            this.cbIRDateU.Name = "cbIRDateU";
            this.cbIRDateU.Size = new System.Drawing.Size(93, 17);
            this.cbIRDateU.TabIndex = 3;
            this.cbIRDateU.Text = "Date Updated";
            this.cbIRDateU.UseVisualStyleBackColor = true;
            // 
            // cbIRCat
            // 
            this.cbIRCat.AutoSize = true;
            this.cbIRCat.Location = new System.Drawing.Point(167, 196);
            this.cbIRCat.Name = "cbIRCat";
            this.cbIRCat.Size = new System.Drawing.Size(62, 17);
            this.cbIRCat.TabIndex = 4;
            this.cbIRCat.Text = "Catalog";
            this.cbIRCat.UseVisualStyleBackColor = true;
            // 
            // cbIRSKU
            // 
            this.cbIRSKU.AutoSize = true;
            this.cbIRSKU.Location = new System.Drawing.Point(21, 31);
            this.cbIRSKU.Name = "cbIRSKU";
            this.cbIRSKU.Size = new System.Drawing.Size(48, 17);
            this.cbIRSKU.TabIndex = 14;
            this.cbIRSKU.Text = "SKU";
            this.cbIRSKU.UseVisualStyleBackColor = true;
            // 
            // cbIRNotes
            // 
            this.cbIRNotes.AutoSize = true;
            this.cbIRNotes.Location = new System.Drawing.Point(167, 229);
            this.cbIRNotes.Name = "cbIRNotes";
            this.cbIRNotes.Size = new System.Drawing.Size(54, 17);
            this.cbIRNotes.TabIndex = 5;
            this.cbIRNotes.Text = "Notes";
            this.cbIRNotes.UseVisualStyleBackColor = true;
            // 
            // cbIRStatus
            // 
            this.cbIRStatus.AutoSize = true;
            this.cbIRStatus.Location = new System.Drawing.Point(167, 262);
            this.cbIRStatus.Name = "cbIRStatus";
            this.cbIRStatus.Size = new System.Drawing.Size(56, 17);
            this.cbIRStatus.TabIndex = 6;
            this.cbIRStatus.Text = "Status";
            this.cbIRStatus.UseVisualStyleBackColor = true;
            // 
            // cbIRInvoice
            // 
            this.cbIRInvoice.AutoSize = true;
            this.cbIRInvoice.Location = new System.Drawing.Point(167, 295);
            this.cbIRInvoice.Name = "cbIRInvoice";
            this.cbIRInvoice.Size = new System.Drawing.Size(101, 17);
            this.cbIRInvoice.TabIndex = 7;
            this.cbIRInvoice.Text = "Invoice Number";
            this.cbIRInvoice.UseVisualStyleBackColor = true;
            // 
            // cbIREdition
            // 
            this.cbIREdition.AutoSize = true;
            this.cbIREdition.Location = new System.Drawing.Point(167, 64);
            this.cbIREdition.Name = "cbIREdition";
            this.cbIREdition.Size = new System.Drawing.Size(58, 17);
            this.cbIREdition.TabIndex = 29;
            this.cbIREdition.Text = "Edition";
            this.cbIREdition.UseVisualStyleBackColor = true;
            // 
            // cbIRUPC
            // 
            this.cbIRUPC.AutoSize = true;
            this.cbIRUPC.Location = new System.Drawing.Point(21, 97);
            this.cbIRUPC.Name = "cbIRUPC";
            this.cbIRUPC.Size = new System.Drawing.Size(78, 17);
            this.cbIRUPC.TabIndex = 0;
            this.cbIRUPC.Text = "UPC/ASIN";
            this.cbIRUPC.UseVisualStyleBackColor = true;
            // 
            // cbIRLocn
            // 
            this.cbIRLocn.AutoSize = true;
            this.cbIRLocn.Location = new System.Drawing.Point(21, 130);
            this.cbIRLocn.Name = "cbIRLocn";
            this.cbIRLocn.Size = new System.Drawing.Size(67, 17);
            this.cbIRLocn.TabIndex = 18;
            this.cbIRLocn.Text = "Location";
            this.cbIRLocn.UseVisualStyleBackColor = true;
            // 
            // cbIRMediaCond
            // 
            this.cbIRMediaCond.AutoSize = true;
            this.cbIRMediaCond.Location = new System.Drawing.Point(167, 31);
            this.cbIRMediaCond.Name = "cbIRMediaCond";
            this.cbIRMediaCond.Size = new System.Drawing.Size(102, 17);
            this.cbIRMediaCond.TabIndex = 28;
            this.cbIRMediaCond.Text = "Media Condition";
            this.cbIRMediaCond.UseVisualStyleBackColor = true;
            // 
            // cbIRQty
            // 
            this.cbIRQty.AutoSize = true;
            this.cbIRQty.Location = new System.Drawing.Point(167, 328);
            this.cbIRQty.Name = "cbIRQty";
            this.cbIRQty.Size = new System.Drawing.Size(65, 17);
            this.cbIRQty.TabIndex = 12;
            this.cbIRQty.Text = "Quantity";
            this.cbIRQty.UseVisualStyleBackColor = true;
            // 
            // cbIRPrice
            // 
            this.cbIRPrice.AutoSize = true;
            this.cbIRPrice.Location = new System.Drawing.Point(21, 163);
            this.cbIRPrice.Name = "cbIRPrice";
            this.cbIRPrice.Size = new System.Drawing.Size(50, 17);
            this.cbIRPrice.TabIndex = 19;
            this.cbIRPrice.Text = "Price";
            this.cbIRPrice.UseVisualStyleBackColor = true;
            // 
            // cbIRAdultContent
            // 
            this.cbIRAdultContent.AutoSize = true;
            this.cbIRAdultContent.Location = new System.Drawing.Point(167, 361);
            this.cbIRAdultContent.Name = "cbIRAdultContent";
            this.cbIRAdultContent.Size = new System.Drawing.Size(90, 17);
            this.cbIRAdultContent.TabIndex = 13;
            this.cbIRAdultContent.Text = "Adult Content";
            this.cbIRAdultContent.UseVisualStyleBackColor = true;
            // 
            // cbIRPub
            // 
            this.cbIRPub.AutoSize = true;
            this.cbIRPub.Location = new System.Drawing.Point(21, 229);
            this.cbIRPub.Name = "cbIRPub";
            this.cbIRPub.Size = new System.Drawing.Size(47, 17);
            this.cbIRPub.TabIndex = 21;
            this.cbIRPub.Text = "Mfgr";
            this.cbIRPub.UseVisualStyleBackColor = true;
            // 
            // cbIRASIN
            // 
            this.cbIRASIN.AutoSize = true;
            this.cbIRASIN.Location = new System.Drawing.Point(21, 262);
            this.cbIRASIN.Name = "cbIRASIN";
            this.cbIRASIN.Size = new System.Drawing.Size(51, 17);
            this.cbIRASIN.TabIndex = 22;
            this.cbIRASIN.Text = "ASIN";
            this.cbIRASIN.UseVisualStyleBackColor = true;
            // 
            // cbIRPubYear
            // 
            this.cbIRPubYear.AutoSize = true;
            this.cbIRPubYear.Location = new System.Drawing.Point(21, 295);
            this.cbIRPubYear.Name = "cbIRPubYear";
            this.cbIRPubYear.Size = new System.Drawing.Size(97, 17);
            this.cbIRPubYear.TabIndex = 23;
            this.cbIRPubYear.Text = "Year Published";
            this.cbIRPubYear.UseVisualStyleBackColor = true;
            // 
            // cbIRPrivNotes
            // 
            this.cbIRPrivNotes.AutoSize = true;
            this.cbIRPrivNotes.Location = new System.Drawing.Point(21, 328);
            this.cbIRPrivNotes.Name = "cbIRPrivNotes";
            this.cbIRPrivNotes.Size = new System.Drawing.Size(90, 17);
            this.cbIRPrivNotes.TabIndex = 24;
            this.cbIRPrivNotes.Text = "Private Notes";
            this.cbIRPrivNotes.UseVisualStyleBackColor = true;
            // 
            // cbIRDesc
            // 
            this.cbIRDesc.AutoSize = true;
            this.cbIRDesc.Location = new System.Drawing.Point(21, 361);
            this.cbIRDesc.Name = "cbIRDesc";
            this.cbIRDesc.Size = new System.Drawing.Size(79, 17);
            this.cbIRDesc.TabIndex = 25;
            this.cbIRDesc.Text = "Description";
            this.cbIRDesc.UseVisualStyleBackColor = true;
            // 
            // browserTab
            // 
            this.browserTab.Controls.Add(this.label186);
            this.browserTab.Controls.Add(this.webBrowser1);
            this.browserTab.Location = new System.Drawing.Point(4, 44);
            this.browserTab.Name = "browserTab";
            this.browserTab.Size = new System.Drawing.Size(865, 550);
            this.browserTab.TabIndex = 22;
            this.browserTab.Text = "Web Browser";
            this.browserTab.UseVisualStyleBackColor = true;
            // 
            // label186
            // 
            this.label186.AutoSize = true;
            this.label186.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label186.ForeColor = System.Drawing.Color.Firebrick;
            this.label186.Location = new System.Drawing.Point(364, 107);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(0, 29);
            this.label186.TabIndex = 1;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(865, 550);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // StatusTab
            // 
            this.StatusTab.BackColor = System.Drawing.SystemColors.Window;
            this.StatusTab.Controls.Add(this.label179);
            this.StatusTab.Controls.Add(this.tbTraceComments);
            this.StatusTab.Controls.Add(this.bSendTrace);
            this.StatusTab.Controls.Add(this.lbStatus);
            this.StatusTab.Location = new System.Drawing.Point(4, 44);
            this.StatusTab.Name = "StatusTab";
            this.StatusTab.Size = new System.Drawing.Size(865, 550);
            this.StatusTab.TabIndex = 19;
            this.StatusTab.Text = " Status & Log  ";
            this.StatusTab.ToolTipText = "Main Status page, where you can find information regarding processes that have  o" +
    "ccurred";
            this.StatusTab.UseVisualStyleBackColor = true;
            // 
            // label179
            // 
            this.label179.AutoSize = true;
            this.label179.Location = new System.Drawing.Point(233, 46);
            this.label179.Name = "label179";
            this.label179.Size = new System.Drawing.Size(195, 13);
            this.label179.TabIndex = 27;
            this.label179.Text = "Please enter your e-mail address here ->";
            // 
            // tbTraceComments
            // 
            this.tbTraceComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTraceComments.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbTraceComments.Location = new System.Drawing.Point(437, 43);
            this.tbTraceComments.Name = "tbTraceComments";
            this.tbTraceComments.Size = new System.Drawing.Size(275, 20);
            this.tbTraceComments.TabIndex = 26;
            this.tbTraceComments.TextChanged += new System.EventHandler(this.tbTraceComments_TextChanged);
            // 
            // bSendTrace
            // 
            this.bSendTrace.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bSendTrace.Location = new System.Drawing.Point(735, 38);
            this.bSendTrace.Name = "bSendTrace";
            this.bSendTrace.Size = new System.Drawing.Size(99, 26);
            this.bSendTrace.TabIndex = 25;
            this.bSendTrace.Text = "Send Trace";
            this.bSendTrace.UseVisualStyleBackColor = false;
            this.bSendTrace.Click += new System.EventHandler(this.bSendTrace_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(473, 155);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 13);
            this.label16.TabIndex = 41;
            this.label16.Text = "Amazon.com";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(471, 101);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(110, 13);
            this.label30.TabIndex = 40;
            this.label30.Text = "Average Price: $0.00 ";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(471, 76);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(60, 15);
            this.label35.TabIndex = 38;
            this.label35.Text = "List Price:";
            // 
            // groupBox47
            // 
            this.groupBox47.Controls.Add(this.label37);
            this.groupBox47.Controls.Add(this.listBox1);
            this.groupBox47.Controls.Add(this.listBox2);
            this.groupBox47.Location = new System.Drawing.Point(37, 54);
            this.groupBox47.Name = "groupBox47";
            this.groupBox47.Size = new System.Drawing.Size(385, 513);
            this.groupBox47.TabIndex = 39;
            this.groupBox47.TabStop = false;
            this.groupBox47.Text = "Results from Pricing Lookup";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(23, 104);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(0, 13);
            this.label37.TabIndex = 36;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.FormatString = "#,##0.00";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(283, 37);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(46, 455);
            this.listBox1.TabIndex = 34;
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(64, 37);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox2.Size = new System.Drawing.Size(220, 455);
            this.listBox2.TabIndex = 30;
            this.listBox2.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // printDialog3
            // 
            this.printDialog3.AllowPrintToFile = false;
            this.printDialog3.UseEXDialog = true;
            // 
            // printDocument3
            // 
            this.printDocument3.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument3_BeginPrint);
            this.printDocument3.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument3_PrintPage);
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(17, 45);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(82, 17);
            this.radioButton12.TabIndex = 63;
            this.radioButton12.Text = "UIEE format";
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(17, 24);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(133, 17);
            this.radioButton13.TabIndex = 62;
            this.radioButton13.Text = "HomeBase v2.0 format";
            // 
            // mainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(880, 732);
            this.Controls.Add(this.dataBasePanel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabTaskPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(13, 13);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(886, 760);
            this.MinimumSize = new System.Drawing.Size(884, 758);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prager Media Inventory Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.RePricingTool.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox52.ResumeLayout(false);
            this.groupBox52.PerformLayout();
            this.groupBox40.ResumeLayout(false);
            this.groupBox40.PerformLayout();
            this.groupBox39.ResumeLayout(false);
            this.groupBox39.PerformLayout();
            this.groupBox34.ResumeLayout(false);
            this.groupBox34.PerformLayout();
            this.groupBox33.ResumeLayout(false);
            this.groupBox33.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox32.ResumeLayout(false);
            this.groupBox32.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.searchTab.ResumeLayout(false);
            this.gbSS.ResumeLayout(false);
            this.gbSS.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.invoiceTab.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabInvoice.ResumeLayout(false);
            this.gbInvoice.ResumeLayout(false);
            this.gbInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pInvoiceLogo)).EndInit();
            this.groupBox36.ResumeLayout(false);
            this.groupBox36.PerformLayout();
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            this.tabReceipt.ResumeLayout(false);
            this.tabReceipt.PerformLayout();
            this.receiptPanel.ResumeLayout(false);
            this.receiptPanel.PerformLayout();
            this.customerInfoTab.ResumeLayout(false);
            this.customerInfoTab.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox37.ResumeLayout(false);
            this.groupBox37.PerformLayout();
            this.mediaDetailTab.ResumeLayout(false);
            this.mediaDetailTab.PerformLayout();
            this.tabSpecificInfo.ResumeLayout(false);
            this.tabAudio.ResumeLayout(false);
            this.tabAudio.PerformLayout();
            this.tabVideo.ResumeLayout(false);
            this.tabVideo.PerformLayout();
            this.gbShipping.ResumeLayout(false);
            this.gbShipping.PerformLayout();
            this.cannedTextTab.ResumeLayout(false);
            this.cannedTextTab.PerformLayout();
            this.uploadTab.ResumeLayout(false);
            this.uploadTab.PerformLayout();
            this.accountingTab.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.alterPricesTab.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox41.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox42.ResumeLayout(false);
            this.groupBox42.PerformLayout();
            this.pricingResultsTab.ResumeLayout(false);
            this.pricingResultsTab.PerformLayout();
            this.tabTaskPanel.ResumeLayout(false);
            this.ExportTab.ResumeLayout(false);
            this.tabControl6.ResumeLayout(false);
            this.tabExportOptions.ResumeLayout(false);
            this.groupBox46.ResumeLayout(false);
            this.groupBox46.PerformLayout();
            this.tabExportListing.ResumeLayout(false);
            this.getASIN.ResumeLayout(false);
            this.getASIN.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.optionsTab.ResumeLayout(false);
            this.tabPrimary.ResumeLayout(false);
            this.tabProgramOptions.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox48.ResumeLayout(false);
            this.groupBox48.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            this.groupBox50.ResumeLayout(false);
            this.groupBox50.PerformLayout();
            this.groupBox49.ResumeLayout(false);
            this.groupBox49.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox51.ResumeLayout(false);
            this.groupBox51.PerformLayout();
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            this.mappingTab.ResumeLayout(false);
            this.mappingTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.Import.ResumeLayout(false);
            this.Import.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox44.ResumeLayout(false);
            this.groupBox44.PerformLayout();
            this.UIDandPswdMaintenance.ResumeLayout(false);
            this.tabControl5.ResumeLayout(false);
            this.tabListingVenues.ResumeLayout(false);
            this.tabListingVenues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UIDdataGridView)).EndInit();
            this.tabGetKeys.ResumeLayout(false);
            this.tabGetKeys.PerformLayout();
            this.Reports.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.Aging.ResumeLayout(false);
            this.Aging.PerformLayout();
            this.Sales.ResumeLayout(false);
            this.gbReportTime.ResumeLayout(false);
            this.gbReportTime.PerformLayout();
            this.Inventory.ResumeLayout(false);
            this.Inventory.PerformLayout();
            this.groupBox30.ResumeLayout(false);
            this.groupBox30.PerformLayout();
            this.groupBox29.ResumeLayout(false);
            this.groupBox29.PerformLayout();
            this.gbFields.ResumeLayout(false);
            this.gbFields.PerformLayout();
            this.browserTab.ResumeLayout(false);
            this.browserTab.PerformLayout();
            this.StatusTab.ResumeLayout(false);
            this.StatusTab.PerformLayout();
            this.groupBox47.ResumeLayout(false);
            this.groupBox47.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem databaselStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem getUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportaproblemToolStripMenuItem;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog2;
        private System.Windows.Forms.TabPage Reports;
        private System.Windows.Forms.TabPage invoiceTab;
        private System.Windows.Forms.Button bPageSetup;
        private System.Windows.Forms.Button bPrintPreview;
        private System.Windows.Forms.Button bPrintInvoice;
        private System.Windows.Forms.Button bDeleteInvoice;
        private System.Windows.Forms.Button bUpdateInvoice;
        private System.Windows.Forms.ListView lvInvoiceList;
        private System.Windows.Forms.Button bAddInvoice;
        private System.Windows.Forms.Button bInvSearch;
        private System.Windows.Forms.GroupBox gbInvoice;
        private System.Windows.Forms.TextBox tbComm;
        private System.Windows.Forms.TextBox tbAdj;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.TextBox tbBusinessAddr;
        private System.Windows.Forms.Button bRemoveItem;
        private System.Windows.Forms.PictureBox pInvoiceLogo;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button bChangeLogo;
        private System.Windows.Forms.TextBox tbInvoiceDate;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.TextBox tbInvoiceTtl;
        private System.Windows.Forms.TextBox tbShipping;
        private System.Windows.Forms.TextBox tbTaxVAT;
        private System.Windows.Forms.TextBox tbDiscount;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label lOrderTotal;
        private System.Windows.Forms.TextBox tbOrderTotal;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.ListView lvShoppingCart;
        private System.Windows.Forms.TextBox tbSoldBy;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.ListBox lbShipTo;
        private System.Windows.Forms.ListBox lbSoldTo;
        private System.Windows.Forms.TextBox tbInvoiceNbr;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.TabPage customerInfoTab;
        private System.Windows.Forms.Button bCustSearch;
        private System.Windows.Forms.Button bClearCustInfo;
        private System.Windows.Forms.Button bXfer;
        private System.Windows.Forms.Button bCustDelete;
        private System.Windows.Forms.Button bCustUpdate;
        private System.Windows.Forms.Button bAddCustomer;
        private System.Windows.Forms.TabPage mediaDetailTab;
        private System.Windows.Forms.TabPage cannedTextTab;
        private System.Windows.Forms.TextBox tbCannedTitle5;
        private System.Windows.Forms.TextBox tbCannedTitle4;
        private System.Windows.Forms.TextBox tbCannedTitle3;
        private System.Windows.Forms.TextBox tbCannedTitle2;
        private System.Windows.Forms.TextBox tbCannedTitle1;
        private System.Windows.Forms.TextBox tbCannedDesc5;
        private System.Windows.Forms.TextBox tbCannedDesc2;
        private System.Windows.Forms.TextBox tbCannedDesc3;
        private System.Windows.Forms.TextBox tbCannedDesc4;
        private System.Windows.Forms.TextBox tbCannedDesc1;
        private System.Windows.Forms.TabPage uploadTab;
        private System.Windows.Forms.Label label144;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox cbUploadChrislands;
        private System.Windows.Forms.CheckBox cbUploadAmazon;
        private System.Windows.Forms.CheckBox cbUploadHalfDotCom;
        private System.Windows.Forms.CheckBox cbUploadAlibris;
        private System.Windows.Forms.CheckBox cbUploadTest;
        private System.Windows.Forms.Label lFileWaiting;
        private System.Windows.Forms.Button bFTPUpload;
        private System.Windows.Forms.TabPage accountingTab;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ListBox lbAcctgYear;
        private System.Windows.Forms.Label lblQtr2Sales;
        private System.Windows.Forms.Label lblQtr3Sales;
        private System.Windows.Forms.Label lblQtr4Sales;
        private System.Windows.Forms.Label lblTotalYTD;
        private System.Windows.Forms.Label lblQtr1Sales;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblSoldCount;
        private System.Windows.Forms.Label lblHoldCount;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblSaleCount;
        private System.Windows.Forms.TabPage alterPricesTab;
        private System.Windows.Forms.TabPage ExportTab;
        private System.Windows.Forms.TabPage searchTab;
        private System.Windows.Forms.GroupBox gbSS;
        private System.Windows.Forms.Label lItemsReturned;
        private System.Windows.Forms.ListBox lbSSCompare2;
        private System.Windows.Forms.TextBox tbSSCompareTo2;
        private System.Windows.Forms.ListBox lbSSAndOr2;
        private System.Windows.Forms.ListBox lbSSCompare1;
        private System.Windows.Forms.Button bSSearch;
        private System.Windows.Forms.TextBox tbSSCompareTo1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.TextBox tbsrchSKU;
        private System.Windows.Forms.TextBox tbsrchTitle;
        private System.Windows.Forms.TextBox tbsrchUPC;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TabPage pricingResultsTab;
        private System.Windows.Forms.Label lListPrice;
        private System.Windows.Forms.TabPage optionsTab;
        private System.Windows.Forms.TabPage UIDandPswdMaintenance;
        private System.Windows.Forms.TabPage Import;
        private System.Windows.Forms.Button bPrintPreviewLV;
        private System.Windows.Forms.Button bPrintListView;
        private System.Windows.Forms.Button bClearInvFields;
        private System.Windows.Forms.Label label169;
        private System.Windows.Forms.Label lblCOG2;
        private System.Windows.Forms.Label lblCOG3;
        private System.Windows.Forms.Label lblCOG4;
        private System.Windows.Forms.Label lblTotalCostofGoods;
        private System.Windows.Forms.Label lblCOG1;
        private System.Windows.Forms.Label label170;
        private System.Windows.Forms.ToolStripMenuItem pragerOnTheWebToolStripMenuItem;
        private System.Windows.Forms.TabPage StatusTab;
        private System.Windows.Forms.TextBox tbPayment;
        private System.Windows.Forms.Label label174;
        private System.Windows.Forms.CheckBox cbFreezeDBPanel;
        private System.Windows.Forms.CheckBox cbUploadPurgeReplace;
        private System.Windows.Forms.TextBox tbCannedTitle10;
        private System.Windows.Forms.TextBox tbCannedTitle9;
        private System.Windows.Forms.TextBox tbCannedTitle8;
        private System.Windows.Forms.TextBox tbCannedTitle7;
        private System.Windows.Forms.TextBox tbCannedTitle6;
        private System.Windows.Forms.TextBox tbCannedDesc10;
        private System.Windows.Forms.TextBox tbCannedDesc7;
        private System.Windows.Forms.TextBox tbCannedDesc8;
        private System.Windows.Forms.TextBox tbCannedDesc9;
        private System.Windows.Forms.TextBox tbCannedDesc6;
        private System.Windows.Forms.Label label187;
        private System.Windows.Forms.Label label171;
        private System.Windows.Forms.TabPage RePricingTool;
        private System.Windows.Forms.ColumnHeader lvSKU;
        private System.Windows.Forms.ColumnHeader lvUPC;
        private System.Windows.Forms.ColumnHeader lvURPrice;
        private System.Windows.Forms.ColumnHeader lvLow;
        private System.Windows.Forms.ColumnHeader lvAverage;
        private System.Windows.Forms.ColumnHeader lvHigh;
        private System.Windows.Forms.ColumnHeader lvCost;
        private System.Windows.Forms.ColumnHeader lvTitle;
        private System.Windows.Forms.ColumnHeader lvSuggPrice;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox36;
        private System.Windows.Forms.GroupBox groupBox35;
        private System.Windows.Forms.GroupBox groupBox37;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbSSColumn1;
        private System.Windows.Forms.ComboBox cbSSColumn2;
        public System.Windows.Forms.ListBox lbStatus;
        public System.Windows.Forms.Button bMarkAll;
        public System.Windows.Forms.Button bStopPricingService;
        public System.Windows.Forms.Button bPricingServiceUpdate;
        public System.Windows.Forms.ListView lvPricingService;
        public System.Windows.Forms.Label lPricingServiceStatus;
        public System.Windows.Forms.Button bStartPricingService;
        public System.Windows.Forms.ListBox lbUploadStatus;
        private System.Windows.Forms.Label label93;
        public System.Windows.Forms.TabControl tabTaskPanel;
        private System.Windows.Forms.Label label192;
        private System.Windows.Forms.Label label193;
        private System.Windows.Forms.Label label195;
        private System.Windows.Forms.Label label207;
        private System.Windows.Forms.Label label208;
        private System.Windows.Forms.Label label204;
        private System.Windows.Forms.Label label206;
        private System.Windows.Forms.Label label203;
        private System.Windows.Forms.Label label201;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Button bDeleteByYear;
        private System.Windows.Forms.TextBox tbPurgeDate;
        private System.Windows.Forms.CheckBox cbDeleteByYear;
        private System.Windows.Forms.Label lItemsPurged;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.TextBox tbAgingDays;
        private System.Windows.Forms.CheckBox cbAgingFilter;
        private System.Windows.Forms.Button bGenerateAgingReport;
        private System.Windows.Forms.Label label146;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage Aging;
        private System.Windows.Forms.TabPage Sales;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.GroupBox groupBox33;
        private System.Windows.Forms.GroupBox groupBox32;
        private System.Windows.Forms.GroupBox groupBox34;
        private System.Windows.Forms.GroupBox groupBox39;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.TextBox tbCondAmtG;
        public System.Windows.Forms.TextBox tbCondAmtP;
        public System.Windows.Forms.TextBox tbCondAmtVG;
        public System.Windows.Forms.CheckBox cbAboveLow;
        public System.Windows.Forms.TextBox tbHighByAmt;
        public System.Windows.Forms.ListBox lbWhatPriceH;
        public System.Windows.Forms.RadioButton rbHighAbove;
        public System.Windows.Forms.RadioButton rbHighBelow;
        public System.Windows.Forms.ListBox lbWhatPriceL;
        public System.Windows.Forms.RadioButton rbLowAbove;
        public System.Windows.Forms.RadioButton rbLowBelow;
        public System.Windows.Forms.TextBox tbLowByAmt;
        public System.Windows.Forms.RadioButton rbPriceLowFixed;
        public System.Windows.Forms.RadioButton rbPriceLowPct;
        public System.Windows.Forms.ListBox lbNewWhatPrice;
        public System.Windows.Forms.TextBox tbNewByAmt;
        public System.Windows.Forms.RadioButton rbPriceNewFixed;
        public System.Windows.Forms.RadioButton rbPriceNewPct;
        public System.Windows.Forms.TextBox tbExcludeBelowAmt;
        public System.Windows.Forms.CheckBox cbExcludeBelow;
        public System.Windows.Forms.TextBox tbExcludeAboveAmt;
        public System.Windows.Forms.CheckBox cbExcludeAbove;
        public System.Windows.Forms.CheckBox cbLessSugg;
        public System.Windows.Forms.CheckBox cbGreaterSugg;
        public System.Windows.Forms.CheckBox cbEqualSugg;
        public System.Windows.Forms.CheckBox cbAboveHigh;
        public System.Windows.Forms.CheckBox cbBelowAverage;
        public System.Windows.Forms.CheckBox cbAboveAverage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        //private myListView listView3;
        private System.Windows.Forms.ComboBox cbSSColumn4;
        private System.Windows.Forms.ListBox lbSSCompare4;
        private System.Windows.Forms.TextBox tbSSCompareTo4;
        private System.Windows.Forms.ListBox lbSSAndOr4;
        private System.Windows.Forms.ComboBox cbSSColumn3;
        private System.Windows.Forms.ListBox lbSSCompare3;
        private System.Windows.Forms.TextBox tbSSCompareTo3;
        private System.Windows.Forms.ListBox lbSSAndOr3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TabPage mappingTab;
        private System.Windows.Forms.Button bSaveMapping;
        private System.Windows.Forms.Button bContinueImport;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.Label label125;
        private System.Windows.Forms.Label label126;
        private System.Windows.Forms.Label label131;
        private System.Windows.Forms.Label label132;
        private System.Windows.Forms.Label label133;
        private System.Windows.Forms.Label label135;
        private System.Windows.Forms.Label label136;
        private System.Windows.Forms.Label label138;
        private System.Windows.Forms.Label label139;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.Label label128;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.Label label122;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ListView lvSalesReport;
        private System.Windows.Forms.ColumnHeader cSKU;
        private System.Windows.Forms.ColumnHeader cTitle;
        private System.Windows.Forms.ColumnHeader cUPC;
        private System.Windows.Forms.ColumnHeader cDateSold;
        private System.Windows.Forms.ColumnHeader cPrice;
        private System.Windows.Forms.Label lblDateUpdated;
        private System.Windows.Forms.Button bDecrement;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bIncrement;
        private System.Windows.Forms.CheckBox cbDoNotReprice;
        private System.Windows.Forms.ListBox lbCannedText;
        private System.Windows.Forms.Button bLookupPrices;
        private System.Windows.Forms.Label lCondition;
        private System.Windows.Forms.ComboBox cbCondition;
        private System.Windows.Forms.Label lBinding;
        private System.Windows.Forms.ComboBox coProductType;
        private System.Windows.Forms.TextBox tbPrivNotes;
        private System.Windows.Forms.TextBox tbItemNote;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lblDateAdded;
        private System.Windows.Forms.Label lPrivNotes;
        private System.Windows.Forms.Label lPrice;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button bShoppingCart;
        private System.Windows.Forms.TextBox tbLocn;
        private System.Windows.Forms.TextBox tbMusicLabel;
        private System.Windows.Forms.TextBox tbImageURL;
        private System.Windows.Forms.TextBox tbTitle;
        public System.Windows.Forms.TextBox tbSKU;
        private System.Windows.Forms.Label lLocation;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bDeleteItem;
        private System.Windows.Forms.Button bUpdateRecord;
        private System.Windows.Forms.Button bAddRecord;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.RadioButton rbPriceHighPct;
        public System.Windows.Forms.RadioButton rbPriceHighFixed;
        private System.Windows.Forms.Button bRelist;
        private System.Windows.Forms.Button bNextItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.Label lAveragePrice;
        private System.Windows.Forms.Button resetDBPanel;
        public System.Windows.Forms.ListBox lbMappingNames;
        public System.Windows.Forms.TextBox tbMapTitle;
        public System.Windows.Forms.TextBox tbMapSKU;
        public System.Windows.Forms.TextBox tbMapAddDesc3;
        public System.Windows.Forms.TextBox tbMapAddDesc2;
        public System.Windows.Forms.TextBox tbMapAddTitle;
        public System.Windows.Forms.TextBox tbMapQty;
        public System.Windows.Forms.TextBox tbMapLocation;
        public System.Windows.Forms.TextBox tbMapPrivateNotes;
        public System.Windows.Forms.TextBox tbMapDateSold;
        public System.Windows.Forms.TextBox tbMapProductID;
        public System.Windows.Forms.TextBox tbMapCondition;
        public System.Windows.Forms.TextBox tbMapProdIDType;
        public System.Windows.Forms.TextBox tbMapPubLoc;
        public System.Windows.Forms.TextBox tbMapMediaCond;
        public System.Windows.Forms.TextBox tbMapUPC;
        public System.Windows.Forms.TextBox tbMapASIN;
        public System.Windows.Forms.TextBox tbMapItemNotes;
        public System.Windows.Forms.TextBox tbMapPrice;
        public System.Windows.Forms.TextBox tbMapDesc;
        public System.Windows.Forms.TextBox tbMapPublisher;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox47;
        private System.Windows.Forms.Label label37;
        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TextBox tbQty;
        private System.Windows.Forms.TextBox tbCost;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbMusicYear;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lUpdateStatus;
        private System.Windows.Forms.Label lUpdateStatus2;
        private System.Windows.Forms.TextBox tbsrchKeywords;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.CheckBox cbUploadCS4;
        public System.Windows.Forms.CheckBox cbUploadCS3;
        public System.Windows.Forms.CheckBox cbUploadCS2;
        public System.Windows.Forms.CheckBox cbUploadCS1;
        private System.Windows.Forms.Label label42;
        public System.Windows.Forms.TextBox tbInternational;
        public System.Windows.Forms.TextBox tbExpedited;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label lOptionsSaved;
        public System.Windows.Forms.Label lProgress;
        public System.Windows.Forms.Label lTimeRemaining;
        internal System.Windows.Forms.RadioButton rbRepriceThus;
        internal System.Windows.Forms.TextBox tbStartNbr;
        internal System.Windows.Forms.RadioButton rbStartWithNbr;
        internal System.Windows.Forms.DateTimePicker dtpReprice;
        private System.Windows.Forms.Label lDiscardAbove;
        public System.Windows.Forms.TextBox tbDiscardAboveAmt;
        private System.Windows.Forms.Label lDiscardBelow;
        public System.Windows.Forms.TextBox tbDiscardBelowAmt;
        public System.Windows.Forms.CheckBox cbCombineNewUsed;
        private System.Windows.Forms.GroupBox groupBox40;
        public System.Windows.Forms.CheckBox cbDontGoBelowCost;
        public System.Windows.Forms.TextBox tbBelowMyCostOr;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.GroupBox groupBox52;
        private System.Windows.Forms.Label lPricesReturned;
        private System.Windows.Forms.Label lVendorNote;
        private System.Windows.Forms.Button bUpdateInfo;
        private System.Windows.Forms.CheckBox cbStatusHold;
        private System.Windows.Forms.ToolStripMenuItem newVersionAvailableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutorialsToolStripMenuItem;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.GroupBox groupBox8;
        public System.Windows.Forms.RadioButton rbMarkAsSold;
        public System.Windows.Forms.RadioButton rbMarkAsForSale;
        private System.Windows.Forms.Label lRecordsRejected;
        internal System.Windows.Forms.Label lRecordsProcessed;
        private System.Windows.Forms.GroupBox groupBox26;
        private System.Windows.Forms.Label label145;
        private System.Windows.Forms.RadioButton rbCreateNewKey;
        private System.Windows.Forms.RadioButton rbRejectRecord;
        internal System.Windows.Forms.RadioButton rbReplaceRecord;
        internal System.Windows.Forms.Button bImportMedia;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button bOpenFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox44;
        internal System.Windows.Forms.CheckBox cbDeleteFirst;
        private System.Windows.Forms.CheckBox cbDontImportSold;
        private System.Windows.Forms.Label label23;
        public System.Windows.Forms.ListBox lbCondn;
        public System.Windows.Forms.ListBox lbPrice;
        public System.Windows.Forms.ListBox lbPricingResults;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox tbCustGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCustNotes;
        private System.Windows.Forms.TextBox tbCustContact;
        private System.Windows.Forms.TextBox tbCustEmail;
        private System.Windows.Forms.TextBox tbCustAltPhone;
        private System.Windows.Forms.TextBox tbCustPhone;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox tbCustName;
        private System.Windows.Forms.TextBox tbCustID;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.CheckBox cbSameAsBillingInfo;
        private System.Windows.Forms.TextBox tbShipCntry;
        private System.Windows.Forms.TextBox tbShipZip;
        private System.Windows.Forms.TextBox tbShipState;
        private System.Windows.Forms.TextBox tbShipCity;
        private System.Windows.Forms.TextBox tbShipAddr2;
        private System.Windows.Forms.TextBox tbShipAddr1;
        private System.Windows.Forms.TextBox tbShipName;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.TextBox tbBillingCntry;
        private System.Windows.Forms.TextBox tbBillingZip;
        private System.Windows.Forms.TextBox tbBillingState;
        private System.Windows.Forms.TextBox tbBillingCity;
        private System.Windows.Forms.TextBox tbBillingAddr2;
        private System.Windows.Forms.TextBox tbBillingAddr1;
        private System.Windows.Forms.TextBox tbBillingName;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.ListView lvCustomerList;
        private System.Windows.Forms.TabPage getASIN;
        private System.Windows.Forms.TextBox tbasinTitle;
        private System.Windows.Forms.TextBox tbasinAuthor;
        private System.Windows.Forms.TextBox tbasinPublisher;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.TextBox tbasinSKU;
        private System.Windows.Forms.Button bUpdateASIN;
        private System.Windows.Forms.ColumnHeader lv1ASIN;
        private System.Windows.Forms.ColumnHeader lv1Title;
        private System.Windows.Forms.ColumnHeader lv1Author;
        private System.Windows.Forms.ColumnHeader lv1Publisher;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label25;
        public System.Windows.Forms.TextBox tbasinASIN;
        private System.Windows.Forms.ListView dataBasePanel;
        private System.Windows.Forms.ColumnHeader ch1;
        private System.Windows.Forms.ColumnHeader ch2;
        private System.Windows.Forms.ColumnHeader ch3;
        private System.Windows.Forms.ColumnHeader ch4;
        private System.Windows.Forms.ColumnHeader ch5;
        private System.Windows.Forms.ColumnHeader ch6;
        private System.Windows.Forms.ColumnHeader qty;
        private System.Windows.Forms.TextBox tbCannedTitle18;
        private System.Windows.Forms.TextBox tbCannedTitle17;
        private System.Windows.Forms.TextBox tbCannedTitle16;
        private System.Windows.Forms.TextBox tbCannedDesc18;
        private System.Windows.Forms.TextBox tbCannedDesc16;
        private System.Windows.Forms.TextBox tbCannedDesc17;
        private System.Windows.Forms.TextBox tbCannedTitle15;
        private System.Windows.Forms.TextBox tbCannedTitle14;
        private System.Windows.Forms.TextBox tbCannedTitle13;
        private System.Windows.Forms.TextBox tbCannedTitle12;
        private System.Windows.Forms.TextBox tbCannedTitle11;
        private System.Windows.Forms.TextBox tbCannedDesc15;
        private System.Windows.Forms.TextBox tbCannedDesc12;
        private System.Windows.Forms.TextBox tbCannedDesc13;
        private System.Windows.Forms.TextBox tbCannedDesc14;
        private System.Windows.Forms.TextBox tbCannedDesc11;
        private System.Windows.Forms.RadioButton rbRepriceSelected;
        private System.Windows.Forms.TextBox tbasinCond;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ColumnHeader lv1Binding;
        private System.Windows.Forms.TextBox tbasinBinding;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Button bSearch;
        //private RestoreState.RealPosition realPosition1;
        private PrintEngine printEngine1;
        private System.Windows.Forms.CheckBox cbWildCardSearch;
        private System.Windows.Forms.Button bClearSearch;
        private System.Windows.Forms.Button bSendTrace;
        private System.Windows.Forms.CheckBox cbPayOther;
        private System.Windows.Forms.CheckBox cbPayPP;
        private System.Windows.Forms.CheckBox cbPayDC;
        private System.Windows.Forms.CheckBox cbPayCC;
        private System.Windows.Forms.CheckBox cbPayCheque;
        private System.Windows.Forms.CheckBox cbPayCash;
        private System.Windows.Forms.CheckBox cbPayAmazon;
        private System.Windows.Forms.Button bClone;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.TextBox tbTaxPct;
        private System.Windows.Forms.ColumnHeader cSRInvoice;
        private System.Windows.Forms.ColumnHeader cSRCustNbr;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem tsShowSold;
        private System.Windows.Forms.ToolStripMenuItem tsShowForSale;
        private System.Windows.Forms.ToolStripMenuItem tsShowHold;
        private System.Windows.Forms.ToolStripMenuItem tsShowAll;
        private System.Windows.Forms.Button bClearIncSearch;
        private System.Windows.Forms.ToolStripMenuItem tsShowCatalog;
        private System.Windows.Forms.Button bCopy2Clipboard;
        private System.Windows.Forms.RadioButton rbImportAZ;
        private System.Windows.Forms.RadioButton rbTabDelimited;
        private System.Windows.Forms.RadioButton rbFormatUIEE;
        private System.Windows.Forms.ToolStripMenuItem aSINUpdateToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.TabControl tabPrimary;
        private System.Windows.Forms.TabPage tabProgramOptions;
        private System.Windows.Forms.GroupBox groupBox48;
        private System.Windows.Forms.CheckBox cbAutoPricingLookup;
        private System.Windows.Forms.GroupBox groupBox28;
        private System.Windows.Forms.CheckBox cbWarnNoLocation;
        private System.Windows.Forms.CheckBox cbWarnNoCatalog;
        private System.Windows.Forms.GroupBox groupBox50;
        private System.Windows.Forms.CheckBox cbAutoFileRetention;
        private System.Windows.Forms.CheckBox cbAutoInvoiceNbr;
        private System.Windows.Forms.CheckBox cbAutoCustomerNbr;
        public System.Windows.Forms.CheckBox cbAutomaticSKU;
        private System.Windows.Forms.GroupBox groupBox49;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rbSortDsc;
        private System.Windows.Forms.RadioButton rbSortAsc;
        private System.Windows.Forms.CheckBox cbSortOverride;
        private System.Windows.Forms.RadioButton rbStartDetail;
        private System.Windows.Forms.CheckBox cbToolTips;
        private System.Windows.Forms.RadioButton rbStartSearch;
        private System.Windows.Forms.CheckBox cbBackupDB;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.RadioButton rbEUDollar;
        private System.Windows.Forms.RadioButton rbGBPound;
        private System.Windows.Forms.GroupBox groupBox51;
        public System.Windows.Forms.CheckBox cbAllowAddUpdate;
        private System.Windows.Forms.CheckBox cbVerifyDeletes;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.TextBox tbUPCSeq;
        private System.Windows.Forms.TextBox tbIllusSignedSeq;
        private System.Windows.Forms.TextBox tbIllusSeq;
        private System.Windows.Forms.TextBox tbAuthorSignSeq;
        private System.Windows.Forms.TextBox tbAuthorSeq;
        private System.Windows.Forms.TextBox tbTitleSeq;
        private System.Windows.Forms.TextBox tbRepriceSeq;
        private System.Windows.Forms.TextBox tbPriceSeq;
        private System.Windows.Forms.TextBox tbCostSeq;
        private System.Windows.Forms.TextBox tbShipSeq;
        private System.Windows.Forms.TextBox tbSKUSeq;
        private System.Windows.Forms.TextBox tbLocSeq;
        private System.Windows.Forms.TextBox tbQtySeq;
        private System.Windows.Forms.TextBox tbKeySeq;
        private System.Windows.Forms.TextBox tbSecSeq;
        private System.Windows.Forms.TextBox tbPriSeq;
        private System.Windows.Forms.TextBox tbSizeSeq;
        private System.Windows.Forms.TextBox tbTypeSeq;
        private System.Windows.Forms.TextBox tbWeightSeq;
        private System.Windows.Forms.TextBox tbPagesSeq;
        private System.Windows.Forms.TextBox tbEdSeq;
        private System.Windows.Forms.TextBox tbJacketSeq;
        private System.Windows.Forms.TextBox tbCondSeq;
        private System.Windows.Forms.TextBox tbBindingSeq;
        private System.Windows.Forms.TextBox tbCannedSeq;
        private System.Windows.Forms.TextBox tbDescSeq;
        private System.Windows.Forms.TextBox tbYearSeq;
        private System.Windows.Forms.TextBox tbPlaceSeq;
        private System.Windows.Forms.Label label157;
        private System.Windows.Forms.Label label156;
        private System.Windows.Forms.Label label155;
        private System.Windows.Forms.Label label154;
        private System.Windows.Forms.Label label153;
        private System.Windows.Forms.Label label152;
        private System.Windows.Forms.Label label151;
        private System.Windows.Forms.Label label150;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.Label label158;
        private System.Windows.Forms.Label label159;
        private System.Windows.Forms.Label label160;
        private System.Windows.Forms.Label label161;
        private System.Windows.Forms.Label label162;
        private System.Windows.Forms.Label label163;
        private System.Windows.Forms.Label label164;
        private System.Windows.Forms.Label label165;
        private System.Windows.Forms.Label label166;
        private System.Windows.Forms.Label label167;
        private System.Windows.Forms.Label label168;
        private System.Windows.Forms.Label label173;
        private System.Windows.Forms.Label label176;
        private System.Windows.Forms.Label label177;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.TextBox tbPubSeq;
        private System.Windows.Forms.Label lCost;
        private System.Windows.Forms.TextBox tbTraceComments;
        private System.Windows.Forms.Button bClearShoppingCart;
        private System.Windows.Forms.CheckBox cbUseAWS;
        private System.Windows.Forms.Button bCreateSalesReport;
        private System.Windows.Forms.GroupBox gbReportTime;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton rbMoveAvgPrice;
        private System.Windows.Forms.RadioButton rbMoveLowPrice;
        private System.Windows.Forms.CheckBox cbUploadBandN;
        private System.Windows.Forms.Label lSalesRank;
        private System.Windows.Forms.ColumnHeader invoice;
        private System.Windows.Forms.CheckBox cbIntlStd;
        private System.Windows.Forms.CheckBox cb1dDom;
        private System.Windows.Forms.CheckBox cb2dDom;
        private System.Windows.Forms.CheckBox cbDomExp;
        private System.Windows.Forms.CheckBox cbIntlExp;
        private System.Windows.Forms.CheckBox cbDomStd;
        private System.Windows.Forms.GroupBox gbShipping;
        private System.Windows.Forms.ToolStripMenuItem tsShowPending;
        private System.Windows.Forms.CheckBox cbUploadPapaMedia;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label lNotFound;
        internal System.Windows.Forms.ListBox lbRejectedRecords;
        private System.Windows.Forms.TabPage Inventory;
        private System.Windows.Forms.GroupBox groupBox29;
        private System.Windows.Forms.Button bInvReport;
        private System.Windows.Forms.GroupBox groupBox30;
        public System.Windows.Forms.GroupBox gbFields;
        public System.Windows.Forms.CheckBox cbIRType;
        public System.Windows.Forms.CheckBox cbIREdition;
        public System.Windows.Forms.CheckBox cbIRMediaCond;
        public System.Windows.Forms.CheckBox cbIRDesc;
        public System.Windows.Forms.CheckBox cbIRPrivNotes;
        public System.Windows.Forms.CheckBox cbIRPubYear;
        public System.Windows.Forms.CheckBox cbIRASIN;
        public System.Windows.Forms.CheckBox cbIRPub;
        public System.Windows.Forms.CheckBox cbIRCost;
        public System.Windows.Forms.CheckBox cbIRPrice;
        public System.Windows.Forms.CheckBox cbIRLocn;
        public System.Windows.Forms.CheckBox cbIRTitle;
        public System.Windows.Forms.CheckBox cbIRSKU;
        public System.Windows.Forms.CheckBox cbIRAdultContent;
        public System.Windows.Forms.CheckBox cbIRQty;
        public System.Windows.Forms.CheckBox cbIRInvoice;
        public System.Windows.Forms.CheckBox cbIRStatus;
        public System.Windows.Forms.CheckBox cbIRNotes;
        public System.Windows.Forms.CheckBox cbIRCat;
        public System.Windows.Forms.CheckBox cbIRDateU;
        public System.Windows.Forms.CheckBox cbIRDateA;
        public System.Windows.Forms.CheckBox cbIRUPC;
        public System.Windows.Forms.RadioButton rbIRClipBoard;
        public System.Windows.Forms.RadioButton rbIRPrint;
        public System.Windows.Forms.RadioButton rbIRFile;
        public System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.PrintDialog printDialog2;
        public System.Drawing.Printing.PrintDocument printDocument2;
        public System.Windows.Forms.PrintDialog printDialog3;
        public System.Drawing.Printing.PrintDocument printDocument3;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog3;
        private System.Windows.Forms.Button bPageSetup3;
        public System.Windows.Forms.Label lFinished;
        private System.Windows.Forms.Label lblPendingCount;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox41;
        private System.Windows.Forms.Button bConvertToUPC13;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbAbsolute;
        private System.Windows.Forms.RadioButton rbDecrease;
        private System.Windows.Forms.RadioButton rbIncrease;
        private System.Windows.Forms.Button bReprice;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.RadioButton rbPercentage;
        private System.Windows.Forms.RadioButton rbAmount;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.Button bChangeStatus;
        private System.Windows.Forms.Label label148;
        private System.Windows.Forms.Label label143;
        private System.Windows.Forms.Label label142;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbMark4Sale;
        private System.Windows.Forms.RadioButton rbMarkHold;
        private System.Windows.Forms.RadioButton rbMarkSold;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label175;
        private System.Windows.Forms.GroupBox groupBox42;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbMassChangeMsg;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.ListBox lbMChangeFields;
        private System.Windows.Forms.Label label149;
        private System.Windows.Forms.Button bMassChange;
        private System.Windows.Forms.Label lMaxLength;
        private System.Windows.Forms.TextBox tbMChangeTo;
        private System.Windows.Forms.TextBox tbMChangeFrom;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.TextBox tbBkNbrTo;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.TextBox tbBkNbrFrom;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.RadioButton rbSKU;
        private System.Windows.Forms.ListBox lbChangePricesCat;
        private System.Windows.Forms.TextBox tbPriceTo;
        private System.Windows.Forms.TextBox tbPriceFrom;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbPriceRange;
        private System.Windows.Forms.RadioButton rbCatalog;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton14;
        private System.Windows.Forms.Label label179;
        private System.Windows.Forms.CheckBox cbUploadScribblemonger;
        private System.Windows.Forms.Label label182;
        private System.Windows.Forms.Label label180;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabInvoice;
        private System.Windows.Forms.TabPage tabReceipt;
        private System.Windows.Forms.TextBox tbStoreName;
        private System.Windows.Forms.Label label188;
        private System.Windows.Forms.Label label184;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.Label label183;
        private System.Windows.Forms.Panel receiptPanel;
        private System.Windows.Forms.Label lPmtMethod;
        private System.Windows.Forms.Label lTotal;
        private System.Windows.Forms.Label lTax;
        private System.Windows.Forms.Label lDateTime;
        private System.Windows.Forms.Label lStoreName;
        private System.Windows.Forms.ListView lvReceipt;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.ColumnHeader chPrice;
        private System.Windows.Forms.CheckBox cbUseReceipt;
        private System.Windows.Forms.TextBox tbPurchase;
        internal System.Windows.Forms.MaskedTextBox tbUPC;
        private System.Windows.Forms.ToolStripMenuItem workOfflineToolStripMenuItem;
        private System.Windows.Forms.Label label185;
        public System.Windows.Forms.TextBox tbMapStatus;
        private System.Windows.Forms.Button bPrintRejRecords;
        private System.Windows.Forms.Button invRepSelAll;
        public System.Windows.Forms.RadioButton rbVenuePrice;
        private System.Windows.Forms.Label label191;
        private System.Windows.Forms.Label label190;
        private System.Windows.Forms.ColumnHeader lv1Year;
        private System.Windows.Forms.ColumnHeader lv1Rank;
        private System.Windows.Forms.Label label194;
        private System.Windows.Forms.TabControl tabControl5;
        private System.Windows.Forms.TabPage tabListingVenues;
        private System.Windows.Forms.Label lMsgSettingsSaved;
        private System.Windows.Forms.Button bSaveUIDs;
        internal System.Windows.Forms.DataGridView UIDdataGridView;
        private System.Windows.Forms.TabPage tabGetKeys;
        private System.Windows.Forms.Label label213;
        public System.Windows.Forms.TextBox tbMarketplaceID;
        private System.Windows.Forms.Label label41;
        public System.Windows.Forms.TextBox tbAWSSecretKey;
        private System.Windows.Forms.Button bGetAccessKey;
        private System.Windows.Forms.Label label87;
        public System.Windows.Forms.TextBox tbAWSKey;
        private System.Windows.Forms.TabControl tabControl6;
        private System.Windows.Forms.TabPage tabExportOptions;
        private System.Windows.Forms.GroupBox groupBox46;
        public System.Windows.Forms.RadioButton rbExportSelected;
        public System.Windows.Forms.RadioButton rbExportInclusiveSearch;
        public System.Windows.Forms.RadioButton rbExportAll;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.CheckBox cbPurgeReplace;
        private System.Windows.Forms.Label lItemsWaiting;
        public System.Windows.Forms.RadioButton rbChangeDate;
        private System.Windows.Forms.Button bExport;
        private System.Windows.Forms.TabPage tabExportListing;
        private System.Windows.Forms.ListBox lbExportList;
        private System.Windows.Forms.CheckBox cbAddDesc;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbCNDollar;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox tbCustomSite4;
        public System.Windows.Forms.TextBox tbCustomSite3;
        public System.Windows.Forms.TextBox tbCustomSite2;
        private System.Windows.Forms.Label label214;
        public System.Windows.Forms.TextBox tbCustomSite1;
        public System.Windows.Forms.TextBox tbDevKey;
        private System.Windows.Forms.Label label215;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button bCopyDevKey;
        public System.Windows.Forms.TextBox tbMerchantID;
        private System.Windows.Forms.Label label216;
        private System.Windows.Forms.Button bGetMWSKeys;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.CheckBox cbAmazonPrice;
        private System.Windows.Forms.Label label209;
        public System.Windows.Forms.TextBox tbAZAssocTag;
        private System.Windows.Forms.Label lAssocTag;
        private System.Windows.Forms.Label label218;
        public System.Windows.Forms.CheckBox cbUploadAmazonUK;
        public System.Windows.Forms.Button bGetMediaInfo;
        private System.Windows.Forms.ToolStripMenuItem initializeQuantityFieldToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label220;
        private System.Windows.Forms.Label label219;
        private System.Windows.Forms.Label label172;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tabSpecificInfo;
        private System.Windows.Forms.TabPage tabVideo;
        private System.Windows.Forms.Label label196;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox coAudioEncoding;
        private System.Windows.Forms.Label label109;
        private System.Windows.Forms.ComboBox coMPAA;
        private System.Windows.Forms.ComboBox coVideoFormat;
        private System.Windows.Forms.TextBox tbVideoYear;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.Label lMediaType;
        private System.Windows.Forms.TextBox tbStudio;
        private System.Windows.Forms.Label label134;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.TabPage tabAudio;
        private System.Windows.Forms.TextBox tbCatalogID;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox coMediaType;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.ComboBox coLanguage;
        private System.Windows.Forms.TextBox tbNbrOfDisks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox coAudioFormat;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox coSubTitles;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox tbRuntime;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.CheckBox cbAdult;
        private System.Windows.Forms.TabPage browserTab;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.ComboBox coOrigin;
        private System.Windows.Forms.ComboBox coAudioKeywords;
        private System.Windows.Forms.Label label130;
        private System.Windows.Forms.ComboBox coVideoKeywords;
        private System.Windows.Forms.TextBox tbOrchestra;
        private System.Windows.Forms.Label label181;
        private System.Windows.Forms.TextBox tbConductor;
        private System.Windows.Forms.Label label178;
        private System.Windows.Forms.TextBox tbComposer;
        private System.Windows.Forms.Label label147;
        private System.Windows.Forms.TextBox tbArtist;
        private System.Windows.Forms.Label label141;
        private System.Windows.Forms.TextBox tbVinylDetails;
        private System.Windows.Forms.Label label137;
        private System.Windows.Forms.Button bClearImportTabMappings;
        private System.Windows.Forms.Label label115;
        internal System.Windows.Forms.MaskedTextBox mtbASIN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.TextBox tbHalfToken;
        private System.Windows.Forms.Button bGetHalfToken;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label189;
        private System.Windows.Forms.Button bSubscribeFileEx;
        private System.Windows.Forms.ComboBox cbEdition;
        private System.Windows.Forms.Label label199;
        private System.Windows.Forms.TextBox tbDirector;
        private System.Windows.Forms.Label label198;
        private System.Windows.Forms.TextBox tbActors;
        private System.Windows.Forms.Label label197;
        private System.Windows.Forms.ComboBox cbDVDRegion;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.Button bVerifyAZUploads;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.CheckBox checkBox3;
        public System.Windows.Forms.CheckBox checkBox4;
        public System.Windows.Forms.CheckBox checkBox5;
        public System.Windows.Forms.CheckBox checkBox6;
        public System.Windows.Forms.CheckBox checkBox7;
        public System.Windows.Forms.CheckBox checkBox8;
        public System.Windows.Forms.CheckBox checkBox9;
        public System.Windows.Forms.CheckBox checkBox10;
        public System.Windows.Forms.CheckBox checkBox11;
        public System.Windows.Forms.CheckBox checkBox12;
        public System.Windows.Forms.CheckBox checkBox13;
        public System.Windows.Forms.CheckBox checkBox14;
        public System.Windows.Forms.CheckBox checkBox15;
        public System.Windows.Forms.CheckBox checkBox16;
        public System.Windows.Forms.CheckBox checkBox17;
        public System.Windows.Forms.CheckBox checkBox18;
        public System.Windows.Forms.CheckBox checkBox19;
        public System.Windows.Forms.CheckBox checkBox20;
        public System.Windows.Forms.CheckBox checkBox21;
        public System.Windows.Forms.CheckBox checkBox22;
        public System.Windows.Forms.CheckBox checkBox23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvListingServiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn FTPAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn FTPDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn FTPFormat;
        private System.Windows.Forms.Label label129;
        private System.Windows.Forms.CheckBox cbDontOverlay;
        private System.Windows.Forms.Label label186;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbSKUSuffix;
        private System.Windows.Forms.Label lSKUSuffix;
        private System.Windows.Forms.TextBox tbSKUPrefix;
        private System.Windows.Forms.Label lSKUPrefix;
        private System.Windows.Forms.TextBox tbStartingSKU;
        private System.Windows.Forms.Label label202;


    }
}

