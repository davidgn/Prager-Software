namespace Prager_Book_Inventory
{
    partial class DisplayLicenseScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayLicenseScreen));
            this.bPurchaseLicense = new System.Windows.Forms.Button();
            this.bPurchaseLater = new System.Windows.Forms.Button();
            this.tbLicenseMsg = new System.Windows.Forms.TextBox();
            this.tbLicenseInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bValidateLicense = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lRenewalMsg = new System.Windows.Forms.Label();
            this.bEnterRenewCode = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRenewCode = new System.Windows.Forms.TextBox();
            this.lUnlockMsg = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bPurchaseLicense
            // 
            this.bPurchaseLicense.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bPurchaseLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPurchaseLicense.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bPurchaseLicense.Location = new System.Drawing.Point(365, 268);
            this.bPurchaseLicense.Name = "bPurchaseLicense";
            this.bPurchaseLicense.Size = new System.Drawing.Size(175, 29);
            this.bPurchaseLicense.TabIndex = 2;
            this.bPurchaseLicense.Text = "Purchase or renew now";
            this.bPurchaseLicense.UseVisualStyleBackColor = false;
            this.bPurchaseLicense.Click += new System.EventHandler(this.bPurchaseLicense_Click);
            // 
            // bPurchaseLater
            // 
            this.bPurchaseLater.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bPurchaseLater.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPurchaseLater.Location = new System.Drawing.Point(169, 268);
            this.bPurchaseLater.Name = "bPurchaseLater";
            this.bPurchaseLater.Size = new System.Drawing.Size(132, 29);
            this.bPurchaseLater.TabIndex = 3;
            this.bPurchaseLater.Text = "Remind me later";
            this.bPurchaseLater.UseVisualStyleBackColor = false;
            this.bPurchaseLater.Click += new System.EventHandler(this.bPurchaseLater_Click);
            // 
            // tbLicenseMsg
            // 
            this.tbLicenseMsg.BackColor = System.Drawing.Color.Firebrick;
            this.tbLicenseMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLicenseMsg.ForeColor = System.Drawing.SystemColors.Info;
            this.tbLicenseMsg.Location = new System.Drawing.Point(88, 149);
            this.tbLicenseMsg.Multiline = true;
            this.tbLicenseMsg.Name = "tbLicenseMsg";
            this.tbLicenseMsg.ReadOnly = true;
            this.tbLicenseMsg.Size = new System.Drawing.Size(526, 89);
            this.tbLicenseMsg.TabIndex = 4;
            this.tbLicenseMsg.Text = resources.GetString("tbLicenseMsg.Text");
            this.tbLicenseMsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbLicenseInfo
            // 
            this.tbLicenseInfo.Location = new System.Drawing.Point(116, 23);
            this.tbLicenseInfo.MaxLength = 24;
            this.tbLicenseInfo.Name = "tbLicenseInfo";
            this.tbLicenseInfo.Size = new System.Drawing.Size(259, 20);
            this.tbLicenseInfo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "License Number: ";
            // 
            // bValidateLicense
            // 
            this.bValidateLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bValidateLicense.Location = new System.Drawing.Point(392, 21);
            this.bValidateLicense.Name = "bValidateLicense";
            this.bValidateLicense.Size = new System.Drawing.Size(75, 23);
            this.bValidateLicense.TabIndex = 7;
            this.bValidateLicense.Text = "Validate";
            this.bValidateLicense.UseVisualStyleBackColor = false;
            this.bValidateLicense.Click += new System.EventHandler(this.bValidateLicenseInfo_Click);
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bClose.Location = new System.Drawing.Point(520, 106);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 8;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Visible = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lRenewalMsg);
            this.groupBox1.Controls.Add(this.bEnterRenewCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbRenewCode);
            this.groupBox1.Controls.Add(this.lUnlockMsg);
            this.groupBox1.Controls.Add(this.bClose);
            this.groupBox1.Controls.Add(this.bValidateLicense);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbLicenseInfo);
            this.groupBox1.Location = new System.Drawing.Point(38, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 156);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // lRenewalMsg
            // 
            this.lRenewalMsg.AutoSize = true;
            this.lRenewalMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRenewalMsg.ForeColor = System.Drawing.Color.Firebrick;
            this.lRenewalMsg.Location = new System.Drawing.Point(481, 64);
            this.lRenewalMsg.Name = "lRenewalMsg";
            this.lRenewalMsg.Size = new System.Drawing.Size(65, 13);
            this.lRenewalMsg.TabIndex = 13;
            this.lRenewalMsg.Text = "Successful. ";
            this.lRenewalMsg.Visible = false;
            // 
            // bEnterRenewCode
            // 
            this.bEnterRenewCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bEnterRenewCode.Location = new System.Drawing.Point(392, 58);
            this.bEnterRenewCode.Name = "bEnterRenewCode";
            this.bEnterRenewCode.Size = new System.Drawing.Size(75, 23);
            this.bEnterRenewCode.TabIndex = 12;
            this.bEnterRenewCode.Text = "Validate";
            this.bEnterRenewCode.UseVisualStyleBackColor = false;
            this.bEnterRenewCode.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Renewal Code:";
            this.label2.Visible = false;
            // 
            // tbRenewCode
            // 
            this.tbRenewCode.Location = new System.Drawing.Point(116, 61);
            this.tbRenewCode.MaxLength = 24;
            this.tbRenewCode.Name = "tbRenewCode";
            this.tbRenewCode.Size = new System.Drawing.Size(259, 20);
            this.tbRenewCode.TabIndex = 10;
            this.tbRenewCode.Visible = false;
            // 
            // lUnlockMsg
            // 
            this.lUnlockMsg.AutoSize = true;
            this.lUnlockMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUnlockMsg.ForeColor = System.Drawing.Color.Firebrick;
            this.lUnlockMsg.Location = new System.Drawing.Point(481, 26);
            this.lUnlockMsg.Name = "lUnlockMsg";
            this.lUnlockMsg.Size = new System.Drawing.Size(65, 13);
            this.lUnlockMsg.TabIndex = 9;
            this.lUnlockMsg.Text = "Successful. ";
            this.lUnlockMsg.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Prager_Book_Inventory.Properties.Resources.prager_software;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(162, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(378, 119);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LicenseScreen
            // 
            this.ClientSize = new System.Drawing.Size(703, 502);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbLicenseMsg);
            this.Controls.Add(this.bPurchaseLater);
            this.Controls.Add(this.bPurchaseLicense);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LicenseScreen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bPurchaseLicense;
        private System.Windows.Forms.Button bPurchaseLater;
        private System.Windows.Forms.TextBox tbLicenseInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bValidateLicense;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lUnlockMsg;
        public System.Windows.Forms.TextBox tbLicenseMsg;
        private System.Windows.Forms.Button bEnterRenewCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRenewCode;
        private System.Windows.Forms.Label lRenewalMsg;
    }
}