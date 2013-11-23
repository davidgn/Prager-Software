namespace Prager_Pricing_Program
{
    partial class License
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(License));
            this.bGoToWebSite = new System.Windows.Forms.Button();
            this.bLater = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bUpdateRegCode = new System.Windows.Forms.Button();
            this.tbRegCode = new System.Windows.Forms.TextBox();
            this.lRegCodeMsg = new System.Windows.Forms.Label();
            this.bClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbLicenseMsg = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bGoToWebSite
            // 
            this.bGoToWebSite.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bGoToWebSite.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bGoToWebSite.FlatAppearance.BorderSize = 2;
            this.bGoToWebSite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bGoToWebSite.Location = new System.Drawing.Point(112, 246);
            this.bGoToWebSite.Name = "bGoToWebSite";
            this.bGoToWebSite.Size = new System.Drawing.Size(141, 33);
            this.bGoToWebSite.TabIndex = 3;
            this.bGoToWebSite.Text = "Purchase License Now";
            this.bGoToWebSite.UseVisualStyleBackColor = false;
            this.bGoToWebSite.Click += new System.EventHandler(this.bGoToWebSite_Click);
            // 
            // bLater
            // 
            this.bLater.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bLater.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bLater.FlatAppearance.BorderSize = 2;
            this.bLater.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bLater.Location = new System.Drawing.Point(318, 246);
            this.bLater.Name = "bLater";
            this.bLater.Size = new System.Drawing.Size(149, 33);
            this.bLater.TabIndex = 4;
            this.bLater.Text = "Purchase License Later";
            this.bLater.UseVisualStyleBackColor = false;
            this.bLater.Click += new System.EventHandler(this.bLater_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bUpdateRegCode);
            this.groupBox1.Controls.Add(this.tbRegCode);
            this.groupBox1.Location = new System.Drawing.Point(38, 303);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 87);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unlock Code";
            // 
            // bUpdateRegCode
            // 
            this.bUpdateRegCode.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bUpdateRegCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bUpdateRegCode.FlatAppearance.BorderSize = 2;
            this.bUpdateRegCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bUpdateRegCode.Location = new System.Drawing.Point(318, 37);
            this.bUpdateRegCode.Name = "bUpdateRegCode";
            this.bUpdateRegCode.Size = new System.Drawing.Size(130, 33);
            this.bUpdateRegCode.TabIndex = 6;
            this.bUpdateRegCode.Text = "Update Code";
            this.bUpdateRegCode.UseVisualStyleBackColor = false;
            this.bUpdateRegCode.Click += new System.EventHandler(this.bUpdateRegCode_Click);
            // 
            // tbRegCode
            // 
            this.tbRegCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRegCode.Location = new System.Drawing.Point(64, 42);
            this.tbRegCode.MaxLength = 20;
            this.tbRegCode.Name = "tbRegCode";
            this.tbRegCode.Size = new System.Drawing.Size(183, 21);
            this.tbRegCode.TabIndex = 0;
            // 
            // lRegCodeMsg
            // 
            this.lRegCodeMsg.AutoSize = true;
            this.lRegCodeMsg.Location = new System.Drawing.Point(112, 423);
            this.lRegCodeMsg.Name = "lRegCodeMsg";
            this.lRegCodeMsg.Size = new System.Drawing.Size(173, 13);
            this.lRegCodeMsg.TabIndex = 6;
            this.lRegCodeMsg.Text = "Unlock code successfully updated.";
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bClose.FlatAppearance.BorderSize = 2;
            this.bClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bClose.Location = new System.Drawing.Point(356, 413);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(130, 33);
            this.bClose.TabIndex = 7;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(104, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(382, 120);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tbLicenseMsg
            // 
            this.tbLicenseMsg.BackColor = System.Drawing.SystemColors.Info;
            this.tbLicenseMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLicenseMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbLicenseMsg.Location = new System.Drawing.Point(115, 169);
            this.tbLicenseMsg.Multiline = true;
            this.tbLicenseMsg.Name = "tbLicenseMsg";
            this.tbLicenseMsg.Size = new System.Drawing.Size(352, 49);
            this.tbLicenseMsg.TabIndex = 8;
            this.tbLicenseMsg.Text = "Your trial period has expired.  You must purchase a license to continue using thi" +
                "s program.";
            // 
            // License
            // 
            this.ClientSize = new System.Drawing.Size(580, 481);
            this.Controls.Add(this.tbLicenseMsg);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.lRegCodeMsg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bLater);
            this.Controls.Add(this.bGoToWebSite);
            this.Controls.Add(this.pictureBox1);
            this.Name = "License";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase a License";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bGoToWebSite;
        private System.Windows.Forms.Button bLater;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbRegCode;
        private System.Windows.Forms.Button bUpdateRegCode;
        private System.Windows.Forms.Label lRegCodeMsg;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbLicenseMsg;
    }
}