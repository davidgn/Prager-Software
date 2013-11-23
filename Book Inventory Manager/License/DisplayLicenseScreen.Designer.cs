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
            this.bClose = new System.Windows.Forms.Button();
            this.lUnlockMsg = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.bValidateLicenseInfo = new System.Windows.Forms.Button();
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
            this.tbLicenseInfo.Location = new System.Drawing.Point(208, 371);
            this.tbLicenseInfo.MaxLength = 24;
            this.tbLicenseInfo.Name = "tbLicenseInfo";
            this.tbLicenseInfo.Size = new System.Drawing.Size(259, 20);
            this.tbLicenseInfo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter License Number: ";
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bClose.Location = new System.Drawing.Point(590, 415);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 8;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Visible = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // lUnlockMsg
            // 
            this.lUnlockMsg.AutoSize = true;
            this.lUnlockMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUnlockMsg.ForeColor = System.Drawing.Color.Firebrick;
            this.lUnlockMsg.Location = new System.Drawing.Point(485, 374);
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
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel14.Location = new System.Drawing.Point(70, 327);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(564, 4);
            this.panel14.TabIndex = 334;
            // 
            // bValidateLicenseInfo
            // 
            this.bValidateLicenseInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bValidateLicenseInfo.Location = new System.Drawing.Point(590, 368);
            this.bValidateLicenseInfo.Name = "bValidateLicenseInfo";
            this.bValidateLicenseInfo.Size = new System.Drawing.Size(75, 23);
            this.bValidateLicenseInfo.TabIndex = 335;
            this.bValidateLicenseInfo.Text = "Validate";
            this.bValidateLicenseInfo.UseVisualStyleBackColor = false;
            this.bValidateLicenseInfo.Click += new System.EventHandler(this.bValidateLicenseInfo_Click);
            // 
            // DisplayLicenseScreen
            // 
            this.ClientSize = new System.Drawing.Size(703, 502);
            this.ControlBox = false;
            this.Controls.Add(this.bValidateLicenseInfo);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.lUnlockMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.tbLicenseInfo);
            this.Controls.Add(this.tbLicenseMsg);
            this.Controls.Add(this.bPurchaseLater);
            this.Controls.Add(this.bPurchaseLicense);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisplayLicenseScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LicenseScreen";
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
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Label lUnlockMsg;
        public System.Windows.Forms.TextBox tbLicenseMsg;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Button bValidateLicenseInfo;
    }
}