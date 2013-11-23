namespace Media_Inventory_Manager
{
    partial class aboutScreen
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.llPragerSoftware = new System.Windows.Forms.LinkLabel();
            this.lRegistration = new System.Windows.Forms.Label();
            this.tbRegKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGUID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bCopyGUID = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbExpireDate = new System.Windows.Forms.TextBox();
            this.tbVersion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Copyright (c) 2004-2011, Prager, Software.  All Rights Reserved.";
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVersion.Location = new System.Drawing.Point(179, 163);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(45, 13);
            this.lVersion.TabIndex = 6;
            this.lVersion.Text = "Version ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Media_Inventory_Manager.Properties.Resources.prager_software;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(79, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(378, 116);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // llPragerSoftware
            // 
            this.llPragerSoftware.AutoSize = true;
            this.llPragerSoftware.Location = new System.Drawing.Point(200, 259);
            this.llPragerSoftware.Name = "llPragerSoftware";
            this.llPragerSoftware.Size = new System.Drawing.Size(160, 13);
            this.llPragerSoftware.TabIndex = 9;
            this.llPragerSoftware.TabStop = true;
            this.llPragerSoftware.Text = "http://www.pragerSoftware.com";
            this.llPragerSoftware.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llPragerSoftware_LinkClicked);
            // 
            // lRegistration
            // 
            this.lRegistration.AutoSize = true;
            this.lRegistration.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lRegistration.Location = new System.Drawing.Point(179, 184);
            this.lRegistration.Name = "lRegistration";
            this.lRegistration.Size = new System.Drawing.Size(87, 13);
            this.lRegistration.TabIndex = 10;
            this.lRegistration.Text = "Registration Key:";
            // 
            // tbRegKey
            // 
            this.tbRegKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbRegKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbRegKey.Location = new System.Drawing.Point(272, 184);
            this.tbRegKey.MaxLength = 19;
            this.tbRegKey.Name = "tbRegKey";
            this.tbRegKey.ReadOnly = true;
            this.tbRegKey.Size = new System.Drawing.Size(151, 13);
            this.tbRegKey.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Certain portions of this program have patents pending.";
            // 
            // tbGUID
            // 
            this.tbGUID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbGUID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbGUID.Location = new System.Drawing.Point(215, 205);
            this.tbGUID.MaxLength = 19;
            this.tbGUID.Name = "tbGUID";
            this.tbGUID.ReadOnly = true;
            this.tbGUID.Size = new System.Drawing.Size(100, 13);
            this.tbGUID.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(179, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "MAC:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // bCopyGUID
            // 
            this.bCopyGUID.Location = new System.Drawing.Point(338, 201);
            this.bCopyGUID.Name = "bCopyGUID";
            this.bCopyGUID.Size = new System.Drawing.Size(39, 21);
            this.bCopyGUID.TabIndex = 15;
            this.bCopyGUID.Text = "Copy";
            this.bCopyGUID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bCopyGUID.UseVisualStyleBackColor = true;
            this.bCopyGUID.Click += new System.EventHandler(this.bCopyGUID_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(179, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "License expires: ";
            // 
            // tbExpireDate
            // 
            this.tbExpireDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbExpireDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbExpireDate.Location = new System.Drawing.Point(258, 226);
            this.tbExpireDate.MaxLength = 19;
            this.tbExpireDate.Name = "tbExpireDate";
            this.tbExpireDate.ReadOnly = true;
            this.tbExpireDate.Size = new System.Drawing.Size(74, 13);
            this.tbExpireDate.TabIndex = 17;
            // 
            // tbVersion
            // 
            this.tbVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbVersion.Location = new System.Drawing.Point(230, 163);
            this.tbVersion.MaxLength = 19;
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.ReadOnly = true;
            this.tbVersion.Size = new System.Drawing.Size(157, 13);
            this.tbVersion.TabIndex = 18;
            // 
            // aboutScreen
            // 
            this.ClientSize = new System.Drawing.Size(537, 397);
            this.ControlBox = false;
            this.Controls.Add(this.tbVersion);
            this.Controls.Add(this.tbExpireDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bCopyGUID);
            this.Controls.Add(this.tbGUID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRegKey);
            this.Controls.Add(this.lRegistration);
            this.Controls.Add(this.llPragerSoftware);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Name = "aboutScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Media Inventory Manager";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel llPragerSoftware;
        private System.Windows.Forms.Label lRegistration;
        private System.Windows.Forms.TextBox tbRegKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbGUID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bCopyGUID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbExpireDate;
        private System.Windows.Forms.TextBox tbVersion;
    }
}