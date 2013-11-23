namespace Blank_Quilting_Manager
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
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listView1 = new System.Windows.Forms.ListView();
            this.customerNbr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.customerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbCustName = new System.Windows.Forms.TextBox();
            this.tbCustEmail = new System.Windows.Forms.TextBox();
            this.tbCustStreetAddr = new System.Windows.Forms.TextBox();
            this.tbCustPhone = new System.Windows.Forms.TextBox();
            this.tbCustFax = new System.Windows.Forms.TextBox();
            this.tbCustCity = new System.Windows.Forms.TextBox();
            this.tbCustZip = new System.Windows.Forms.TextBox();
            this.tbCustMailingCity = new System.Windows.Forms.TextBox();
            this.tbCustMailingAddr = new System.Windows.Forms.TextBox();
            this.tbCustMailingZip = new System.Windows.Forms.TextBox();
            this.tbBuyerName = new System.Windows.Forms.TextBox();
            this.tbOwnerEmail = new System.Windows.Forms.TextBox();
            this.tbBuyerEmail = new System.Windows.Forms.TextBox();
            this.tbOwnerName = new System.Windows.Forms.TextBox();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.bDBAdd = new System.Windows.Forms.Button();
            this.bDBDelete = new System.Windows.Forms.Button();
            this.bDBUpdate = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bScanOrder = new System.Windows.Forms.Button();
            this.tbCustNbr = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtContactDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbphoneContact = new System.Windows.Forms.RadioButton();
            this.rbInPersonContact = new System.Windows.Forms.RadioButton();
            this.rbEmailContact = new System.Windows.Forms.RadioButton();
            this.label20 = new System.Windows.Forms.Label();
            this.listView3 = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.customerNbr,
            this.customerName});
            this.listView1.Location = new System.Drawing.Point(14, 21);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(287, 187);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // customerNbr
            // 
            this.customerNbr.Text = "Customer Number";
            // 
            // customerName
            // 
            this.customerName.Text = "Customer Name";
            this.customerName.Width = 250;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Store Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 445);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Buyer Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 475);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Owner Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(475, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Email:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Street Address:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "City:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(383, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "State:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(255, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Zip:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(254, 405);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Zip:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 405);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "City:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 370);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Ship Address:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(303, 286);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Phone:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(495, 286);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(27, 13);
            this.label16.TabIndex = 18;
            this.label16.Text = "Fax:";
            // 
            // tbCustName
            // 
            this.tbCustName.BackColor = System.Drawing.SystemColors.Window;
            this.tbCustName.Location = new System.Drawing.Point(84, 250);
            this.tbCustName.Name = "tbCustName";
            this.tbCustName.Size = new System.Drawing.Size(213, 20);
            this.tbCustName.TabIndex = 19;
            // 
            // tbCustEmail
            // 
            this.tbCustEmail.Location = new System.Drawing.Point(513, 250);
            this.tbCustEmail.Name = "tbCustEmail";
            this.tbCustEmail.Size = new System.Drawing.Size(155, 20);
            this.tbCustEmail.TabIndex = 20;
            // 
            // tbCustStreetAddr
            // 
            this.tbCustStreetAddr.Location = new System.Drawing.Point(103, 283);
            this.tbCustStreetAddr.Name = "tbCustStreetAddr";
            this.tbCustStreetAddr.Size = new System.Drawing.Size(194, 20);
            this.tbCustStreetAddr.TabIndex = 21;
            // 
            // tbCustPhone
            // 
            this.tbCustPhone.Location = new System.Drawing.Point(347, 283);
            this.tbCustPhone.Name = "tbCustPhone";
            this.tbCustPhone.Size = new System.Drawing.Size(100, 20);
            this.tbCustPhone.TabIndex = 22;
            // 
            // tbCustFax
            // 
            this.tbCustFax.Location = new System.Drawing.Point(528, 283);
            this.tbCustFax.Name = "tbCustFax";
            this.tbCustFax.Size = new System.Drawing.Size(100, 20);
            this.tbCustFax.TabIndex = 23;
            // 
            // tbCustCity
            // 
            this.tbCustCity.BackColor = System.Drawing.SystemColors.Window;
            this.tbCustCity.Location = new System.Drawing.Point(45, 317);
            this.tbCustCity.Name = "tbCustCity";
            this.tbCustCity.Size = new System.Drawing.Size(194, 20);
            this.tbCustCity.TabIndex = 24;
            // 
            // tbCustZip
            // 
            this.tbCustZip.BackColor = System.Drawing.SystemColors.Window;
            this.tbCustZip.Location = new System.Drawing.Point(286, 317);
            this.tbCustZip.Name = "tbCustZip";
            this.tbCustZip.Size = new System.Drawing.Size(71, 20);
            this.tbCustZip.TabIndex = 25;
            // 
            // tbCustMailingCity
            // 
            this.tbCustMailingCity.Location = new System.Drawing.Point(44, 402);
            this.tbCustMailingCity.Name = "tbCustMailingCity";
            this.tbCustMailingCity.Size = new System.Drawing.Size(194, 20);
            this.tbCustMailingCity.TabIndex = 27;
            // 
            // tbCustMailingAddr
            // 
            this.tbCustMailingAddr.Location = new System.Drawing.Point(102, 367);
            this.tbCustMailingAddr.Name = "tbCustMailingAddr";
            this.tbCustMailingAddr.Size = new System.Drawing.Size(194, 20);
            this.tbCustMailingAddr.TabIndex = 26;
            // 
            // tbCustMailingZip
            // 
            this.tbCustMailingZip.Location = new System.Drawing.Point(286, 402);
            this.tbCustMailingZip.Name = "tbCustMailingZip";
            this.tbCustMailingZip.Size = new System.Drawing.Size(71, 20);
            this.tbCustMailingZip.TabIndex = 28;
            // 
            // tbBuyerName
            // 
            this.tbBuyerName.Location = new System.Drawing.Point(86, 442);
            this.tbBuyerName.Name = "tbBuyerName";
            this.tbBuyerName.Size = new System.Drawing.Size(194, 20);
            this.tbBuyerName.TabIndex = 29;
            // 
            // tbOwnerEmail
            // 
            this.tbOwnerEmail.Location = new System.Drawing.Point(339, 472);
            this.tbOwnerEmail.Name = "tbOwnerEmail";
            this.tbOwnerEmail.Size = new System.Drawing.Size(194, 20);
            this.tbOwnerEmail.TabIndex = 30;
            // 
            // tbBuyerEmail
            // 
            this.tbBuyerEmail.Location = new System.Drawing.Point(339, 442);
            this.tbBuyerEmail.Name = "tbBuyerEmail";
            this.tbBuyerEmail.Size = new System.Drawing.Size(194, 20);
            this.tbBuyerEmail.TabIndex = 31;
            // 
            // tbOwnerName
            // 
            this.tbOwnerName.Location = new System.Drawing.Point(86, 472);
            this.tbOwnerName.Name = "tbOwnerName";
            this.tbOwnerName.Size = new System.Drawing.Size(194, 20);
            this.tbOwnerName.TabIndex = 32;
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(269, 531);
            this.tbNotes.MaxLength = 500;
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(417, 70);
            this.tbNotes.TabIndex = 33;
            // 
            // bDBAdd
            // 
            this.bDBAdd.Location = new System.Drawing.Point(12, 18);
            this.bDBAdd.Name = "bDBAdd";
            this.bDBAdd.Size = new System.Drawing.Size(69, 29);
            this.bDBAdd.TabIndex = 34;
            this.bDBAdd.Text = "Add";
            this.bDBAdd.UseVisualStyleBackColor = true;
            this.bDBAdd.Click += new System.EventHandler(this.bDBAdd_Click);
            // 
            // bDBDelete
            // 
            this.bDBDelete.Location = new System.Drawing.Point(12, 92);
            this.bDBDelete.Name = "bDBDelete";
            this.bDBDelete.Size = new System.Drawing.Size(69, 29);
            this.bDBDelete.TabIndex = 35;
            this.bDBDelete.Text = "Delete";
            this.bDBDelete.UseVisualStyleBackColor = true;
            this.bDBDelete.Click += new System.EventHandler(this.bDBDelete_Click);
            // 
            // bDBUpdate
            // 
            this.bDBUpdate.Location = new System.Drawing.Point(13, 55);
            this.bDBUpdate.Name = "bDBUpdate";
            this.bDBUpdate.Size = new System.Drawing.Size(69, 29);
            this.bDBUpdate.TabIndex = 36;
            this.bDBUpdate.Text = "Update";
            this.bDBUpdate.UseVisualStyleBackColor = true;
            this.bDBUpdate.Click += new System.EventHandler(this.bDBUpdate_Click);
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(320, 21);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(159, 187);
            this.listView2.TabIndex = 37;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(112, 5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 13);
            this.label17.TabIndex = 38;
            this.label17.Text = "Customer Information";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(353, 5);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 13);
            this.label18.TabIndex = 39;
            this.label18.Text = "Customer Contacts";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Location = new System.Drawing.Point(15, 355);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(561, 2);
            this.panel1.TabIndex = 40;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel2.Location = new System.Drawing.Point(15, 434);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(561, 2);
            this.panel2.TabIndex = 41;
            // 
            // bScanOrder
            // 
            this.bScanOrder.Location = new System.Drawing.Point(12, 132);
            this.bScanOrder.Name = "bScanOrder";
            this.bScanOrder.Size = new System.Drawing.Size(69, 29);
            this.bScanOrder.TabIndex = 42;
            this.bScanOrder.Text = "Scan";
            this.bScanOrder.UseVisualStyleBackColor = true;
            this.bScanOrder.Click += new System.EventHandler(this.bScanOrder_Click);
            // 
            // tbCustNbr
            // 
            this.tbCustNbr.Enabled = false;
            this.tbCustNbr.Location = new System.Drawing.Point(392, 250);
            this.tbCustNbr.Name = "tbCustNbr";
            this.tbCustNbr.Size = new System.Drawing.Size(69, 20);
            this.tbCustNbr.TabIndex = 44;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(314, 253);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 13);
            this.label19.TabIndex = 43;
            this.label19.Text = "Customer Nbr:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(427, 308);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 29);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Enabled = false;
            this.radioButton3.Location = new System.Drawing.Point(48, 10);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(41, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "MT";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(97, 10);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(43, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "WA";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(10, 10);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(36, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "ID";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.radioButton6);
            this.groupBox2.Location = new System.Drawing.Point(427, 393);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 29);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Enabled = false;
            this.radioButton4.Location = new System.Drawing.Point(49, 9);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(41, 17);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "MT";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Enabled = false;
            this.radioButton5.Location = new System.Drawing.Point(92, 9);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(43, 17);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "WA";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radioButton6.Enabled = false;
            this.radioButton6.Location = new System.Drawing.Point(11, 9);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(36, 17);
            this.radioButton6.TabIndex = 3;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "ID";
            this.radioButton6.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(383, 405);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "State:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bDBAdd);
            this.groupBox3.Controls.Add(this.bDBDelete);
            this.groupBox3.Controls.Add(this.bDBUpdate);
            this.groupBox3.Controls.Add(this.bScanOrder);
            this.groupBox3.Location = new System.Drawing.Point(595, 320);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(91, 171);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel3.Location = new System.Drawing.Point(15, 510);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(561, 2);
            this.panel3.TabIndex = 49;
            // 
            // dtContactDate
            // 
            this.dtContactDate.Location = new System.Drawing.Point(15, 531);
            this.dtContactDate.Name = "dtContactDate";
            this.dtContactDate.Size = new System.Drawing.Size(200, 20);
            this.dtContactDate.TabIndex = 50;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbEmailContact);
            this.groupBox4.Controls.Add(this.rbInPersonContact);
            this.groupBox4.Controls.Add(this.rbphoneContact);
            this.groupBox4.Location = new System.Drawing.Point(15, 557);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 44);
            this.groupBox4.TabIndex = 51;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Contact Type";
            // 
            // rbphoneContact
            // 
            this.rbphoneContact.AutoSize = true;
            this.rbphoneContact.Location = new System.Drawing.Point(16, 19);
            this.rbphoneContact.Name = "rbphoneContact";
            this.rbphoneContact.Size = new System.Drawing.Size(56, 17);
            this.rbphoneContact.TabIndex = 0;
            this.rbphoneContact.TabStop = true;
            this.rbphoneContact.Text = "Phone";
            this.rbphoneContact.UseVisualStyleBackColor = true;
            // 
            // rbInPersonContact
            // 
            this.rbInPersonContact.AutoSize = true;
            this.rbInPersonContact.Location = new System.Drawing.Point(78, 19);
            this.rbInPersonContact.Name = "rbInPersonContact";
            this.rbInPersonContact.Size = new System.Drawing.Size(69, 17);
            this.rbInPersonContact.TabIndex = 1;
            this.rbInPersonContact.TabStop = true;
            this.rbInPersonContact.Text = "In-person";
            this.rbInPersonContact.UseVisualStyleBackColor = true;
            // 
            // rbEmailContact
            // 
            this.rbEmailContact.AutoSize = true;
            this.rbEmailContact.Location = new System.Drawing.Point(153, 19);
            this.rbEmailContact.Name = "rbEmailContact";
            this.rbEmailContact.Size = new System.Drawing.Size(50, 17);
            this.rbEmailContact.TabIndex = 2;
            this.rbEmailContact.TabStop = true;
            this.rbEmailContact.Text = "Email";
            this.rbEmailContact.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(540, 5);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 13);
            this.label20.TabIndex = 53;
            this.label20.Text = "Customer Orders";
            // 
            // listView3
            // 
            this.listView3.Location = new System.Drawing.Point(498, 21);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(159, 187);
            this.listView3.TabIndex = 52;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(694, 616);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dtContactDate);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbCustNbr);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.tbOwnerName);
            this.Controls.Add(this.tbBuyerEmail);
            this.Controls.Add(this.tbOwnerEmail);
            this.Controls.Add(this.tbBuyerName);
            this.Controls.Add(this.tbCustMailingZip);
            this.Controls.Add(this.tbCustMailingCity);
            this.Controls.Add(this.tbCustMailingAddr);
            this.Controls.Add(this.tbCustZip);
            this.Controls.Add(this.tbCustCity);
            this.Controls.Add(this.tbCustFax);
            this.Controls.Add(this.tbCustPhone);
            this.Controls.Add(this.tbCustStreetAddr);
            this.Controls.Add(this.tbCustEmail);
            this.Controls.Add(this.tbCustName);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "mainForm";
            this.Text = "Blank Quilting Customer Manager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button bDBAdd;
        private System.Windows.Forms.Button bDBDelete;
        private System.Windows.Forms.Button bDBUpdate;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bScanOrder;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ColumnHeader customerNbr;
        private System.Windows.Forms.ColumnHeader customerName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ListView listView3;
        public System.Windows.Forms.TextBox tbCustName;
        public System.Windows.Forms.TextBox tbCustEmail;
        public System.Windows.Forms.TextBox tbCustStreetAddr;
        public System.Windows.Forms.TextBox tbCustPhone;
        public System.Windows.Forms.TextBox tbCustFax;
        public System.Windows.Forms.TextBox tbCustCity;
        public System.Windows.Forms.TextBox tbCustZip;
        public System.Windows.Forms.TextBox tbCustMailingCity;
        public System.Windows.Forms.TextBox tbCustMailingAddr;
        public System.Windows.Forms.TextBox tbCustMailingZip;
        public System.Windows.Forms.TextBox tbBuyerName;
        public System.Windows.Forms.TextBox tbOwnerEmail;
        public System.Windows.Forms.TextBox tbBuyerEmail;
        public System.Windows.Forms.TextBox tbOwnerName;
        public System.Windows.Forms.TextBox tbNotes;
        public System.Windows.Forms.TextBox tbCustNbr;
        public System.Windows.Forms.RadioButton radioButton3;
        public System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.RadioButton radioButton4;
        public System.Windows.Forms.RadioButton radioButton5;
        public System.Windows.Forms.RadioButton radioButton6;
        public System.Windows.Forms.DateTimePicker dtContactDate;
        public System.Windows.Forms.RadioButton rbEmailContact;
        public System.Windows.Forms.RadioButton rbInPersonContact;
        public System.Windows.Forms.RadioButton rbphoneContact;
    }
}

