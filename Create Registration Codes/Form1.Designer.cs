namespace WindowsApplication1
{
    partial class Form1
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
            this.bGenerate = new System.Windows.Forms.Button();
            this.tbGeneratedKey = new System.Windows.Forms.TextBox();
            this.rbInventory = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbMedia = new System.Windows.Forms.RadioButton();
            this.rbSynchronizer = new System.Windows.Forms.RadioButton();
            this.rbPricing = new System.Windows.Forms.RadioButton();
            this.tbGUID = new System.Windows.Forms.TextBox();
            this.bPasteGUID = new System.Windows.Forms.Button();
            this.bCopyKey = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tbDecryptedKey = new System.Windows.Forms.TextBox();
            this.bDecrypt = new System.Windows.Forms.Button();
            this.bAddOneYear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbLocaleUK = new System.Windows.Forms.RadioButton();
            this.rbLocaleUS = new System.Windows.Forms.RadioButton();
            this.bCopyNetworkLic = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bGenerate
            // 
            this.bGenerate.BackColor = System.Drawing.SystemColors.Control;
            this.bGenerate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bGenerate.FlatAppearance.BorderSize = 2;
            this.bGenerate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bGenerate.Location = new System.Drawing.Point(377, 227);
            this.bGenerate.Name = "bGenerate";
            this.bGenerate.Size = new System.Drawing.Size(99, 23);
            this.bGenerate.TabIndex = 0;
            this.bGenerate.Text = "Generate Key";
            this.bGenerate.UseVisualStyleBackColor = false;
            this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
            // 
            // tbGeneratedKey
            // 
            this.tbGeneratedKey.Location = new System.Drawing.Point(17, 68);
            this.tbGeneratedKey.Name = "tbGeneratedKey";
            this.tbGeneratedKey.Size = new System.Drawing.Size(189, 20);
            this.tbGeneratedKey.TabIndex = 1;
            // 
            // rbInventory
            // 
            this.rbInventory.AutoSize = true;
            this.rbInventory.Location = new System.Drawing.Point(32, 29);
            this.rbInventory.Name = "rbInventory";
            this.rbInventory.Size = new System.Drawing.Size(69, 17);
            this.rbInventory.TabIndex = 3;
            this.rbInventory.Text = "Inventory";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbMedia);
            this.groupBox1.Controls.Add(this.rbSynchronizer);
            this.groupBox1.Controls.Add(this.rbPricing);
            this.groupBox1.Controls.Add(this.rbInventory);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 68);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rbMedia
            // 
            this.rbMedia.AutoSize = true;
            this.rbMedia.Location = new System.Drawing.Point(152, 29);
            this.rbMedia.Name = "rbMedia";
            this.rbMedia.Size = new System.Drawing.Size(54, 17);
            this.rbMedia.TabIndex = 6;
            this.rbMedia.Text = "Media";
            // 
            // rbSynchronizer
            // 
            this.rbSynchronizer.AutoSize = true;
            this.rbSynchronizer.Location = new System.Drawing.Point(365, 29);
            this.rbSynchronizer.Name = "rbSynchronizer";
            this.rbSynchronizer.Size = new System.Drawing.Size(86, 17);
            this.rbSynchronizer.TabIndex = 5;
            this.rbSynchronizer.Text = "Synchronizer";
            // 
            // rbPricing
            // 
            this.rbPricing.AutoSize = true;
            this.rbPricing.Location = new System.Drawing.Point(257, 29);
            this.rbPricing.Name = "rbPricing";
            this.rbPricing.Size = new System.Drawing.Size(57, 17);
            this.rbPricing.TabIndex = 4;
            this.rbPricing.Text = "Pricing";
            // 
            // tbGUID
            // 
            this.tbGUID.Location = new System.Drawing.Point(32, 120);
            this.tbGUID.Name = "tbGUID";
            this.tbGUID.Size = new System.Drawing.Size(189, 20);
            this.tbGUID.TabIndex = 5;
            // 
            // bPasteGUID
            // 
            this.bPasteGUID.Location = new System.Drawing.Point(244, 118);
            this.bPasteGUID.Name = "bPasteGUID";
            this.bPasteGUID.Size = new System.Drawing.Size(75, 23);
            this.bPasteGUID.TabIndex = 6;
            this.bPasteGUID.Text = "Paste MAC";
            this.bPasteGUID.UseVisualStyleBackColor = true;
            this.bPasteGUID.Click += new System.EventHandler(this.bPasteGUID_Click);
            // 
            // bCopyKey
            // 
            this.bCopyKey.Location = new System.Drawing.Point(229, 66);
            this.bCopyKey.Name = "bCopyKey";
            this.bCopyKey.Size = new System.Drawing.Size(75, 23);
            this.bCopyKey.TabIndex = 7;
            this.bCopyKey.Text = "Copy Key";
            this.bCopyKey.UseVisualStyleBackColor = true;
            this.bCopyKey.Click += new System.EventHandler(this.bCopyKey_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(17, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(199, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // tbDecryptedKey
            // 
            this.tbDecryptedKey.Location = new System.Drawing.Point(17, 104);
            this.tbDecryptedKey.Name = "tbDecryptedKey";
            this.tbDecryptedKey.Size = new System.Drawing.Size(76, 20);
            this.tbDecryptedKey.TabIndex = 9;
            // 
            // bDecrypt
            // 
            this.bDecrypt.Location = new System.Drawing.Point(108, 104);
            this.bDecrypt.Name = "bDecrypt";
            this.bDecrypt.Size = new System.Drawing.Size(75, 23);
            this.bDecrypt.TabIndex = 10;
            this.bDecrypt.Text = "Decrypt";
            this.bDecrypt.UseVisualStyleBackColor = true;
            this.bDecrypt.Click += new System.EventHandler(this.bDecrypt_Click);
            // 
            // bAddOneYear
            // 
            this.bAddOneYear.Location = new System.Drawing.Point(229, 26);
            this.bAddOneYear.Name = "bAddOneYear";
            this.bAddOneYear.Size = new System.Drawing.Size(75, 23);
            this.bAddOneYear.TabIndex = 11;
            this.bAddOneYear.Text = "Add 1 year";
            this.bAddOneYear.UseVisualStyleBackColor = true;
            this.bAddOneYear.Click += new System.EventHandler(this.bAddOneYear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbLocaleUK);
            this.groupBox2.Controls.Add(this.rbLocaleUS);
            this.groupBox2.Location = new System.Drawing.Point(386, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 74);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Locale";
            // 
            // rbLocaleUK
            // 
            this.rbLocaleUK.AutoSize = true;
            this.rbLocaleUK.Location = new System.Drawing.Point(13, 42);
            this.rbLocaleUK.Name = "rbLocaleUK";
            this.rbLocaleUK.Size = new System.Drawing.Size(58, 17);
            this.rbLocaleUK.TabIndex = 1;
            this.rbLocaleUK.TabStop = true;
            this.rbLocaleUK.Text = "en_UK";
            this.rbLocaleUK.UseVisualStyleBackColor = true;
            this.rbLocaleUK.CheckedChanged += new System.EventHandler(this.rbLocaleUK_CheckedChanged);
            // 
            // rbLocaleUS
            // 
            this.rbLocaleUS.AutoSize = true;
            this.rbLocaleUS.Checked = true;
            this.rbLocaleUS.Location = new System.Drawing.Point(13, 20);
            this.rbLocaleUS.Name = "rbLocaleUS";
            this.rbLocaleUS.Size = new System.Drawing.Size(99, 17);
            this.rbLocaleUS.TabIndex = 0;
            this.rbLocaleUS.TabStop = true;
            this.rbLocaleUS.Text = "en_US (default)";
            this.rbLocaleUS.UseVisualStyleBackColor = true;
            // 
            // bCopyNetworkLic
            // 
            this.bCopyNetworkLic.Location = new System.Drawing.Point(377, 283);
            this.bCopyNetworkLic.Name = "bCopyNetworkLic";
            this.bCopyNetworkLic.Size = new System.Drawing.Size(108, 36);
            this.bCopyNetworkLic.TabIndex = 13;
            this.bCopyNetworkLic.Text = "Copy Network License";
            this.bCopyNetworkLic.UseVisualStyleBackColor = true;
            this.bCopyNetworkLic.Click += new System.EventHandler(this.bCopyNetworkLic_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbGeneratedKey);
            this.groupBox3.Controls.Add(this.bCopyKey);
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Controls.Add(this.bAddOneYear);
            this.groupBox3.Controls.Add(this.tbDecryptedKey);
            this.groupBox3.Controls.Add(this.bDecrypt);
            this.groupBox3.Location = new System.Drawing.Point(12, 162);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(337, 146);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(528, 371);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.bCopyNetworkLic);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bPasteGUID);
            this.Controls.Add(this.tbGUID);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bGenerate);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Key Generator v 2.2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bGenerate;
        private System.Windows.Forms.TextBox tbGeneratedKey;
        private System.Windows.Forms.RadioButton rbInventory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPricing;
        private System.Windows.Forms.RadioButton rbSynchronizer;
        private System.Windows.Forms.TextBox tbGUID;
        private System.Windows.Forms.Button bPasteGUID;
        private System.Windows.Forms.Button bCopyKey;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox tbDecryptedKey;
        private System.Windows.Forms.Button bDecrypt;
        private System.Windows.Forms.Button bAddOneYear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbLocaleUK;
        private System.Windows.Forms.RadioButton rbLocaleUS;
        private System.Windows.Forms.RadioButton rbMedia;
        private System.Windows.Forms.Button bCopyNetworkLic;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

