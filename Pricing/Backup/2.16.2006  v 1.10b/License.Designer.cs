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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bGoToWebSite = new System.Windows.Forms.Button();
            this.bLater = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bUpdateRegCode = new System.Windows.Forms.Button();
            this.tbRegCode = new System.Windows.Forms.TextBox();
            this.lRegCodeMsg = new System.Windows.Forms.Label();
            this.bClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
// 
// pictureBox1
// 
            this.pictureBox1.BackgroundImage = Prager_Pricing_Program.Properties.Resources.banner;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(41, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(479, 87);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
// 
// label1
// 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "You must purchase a License within 30 days of installation.";
// 
// label2
// 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 154);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(396, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Failure to do will disable the Search function (the program will no longer work)." +
                "";
// 
// bGoToWebSite
// 
            this.bGoToWebSite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bGoToWebSite.Location = new System.Drawing.Point(112, 196);
            this.bGoToWebSite.Name = "bGoToWebSite";
            this.bGoToWebSite.Size = new System.Drawing.Size(130, 33);
            this.bGoToWebSite.TabIndex = 3;
            this.bGoToWebSite.Text = "Purchase Now";
            this.bGoToWebSite.Click += new System.EventHandler(this.bGoToWebSite_Click);
// 
// bLater
// 
            this.bLater.Location = new System.Drawing.Point(318, 196);
            this.bLater.Name = "bLater";
            this.bLater.Size = new System.Drawing.Size(130, 33);
            this.bLater.TabIndex = 4;
            this.bLater.Text = "Purchase Later";
            this.bLater.Click += new System.EventHandler(this.bLater_Click);
// 
// groupBox1
// 
            this.groupBox1.Controls.Add(this.bUpdateRegCode);
            this.groupBox1.Controls.Add(this.tbRegCode);
            this.groupBox1.Location = new System.Drawing.Point(38, 276);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 87);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unlock Code";
// 
// bUpdateRegCode
// 
            this.bUpdateRegCode.Location = new System.Drawing.Point(318, 37);
            this.bUpdateRegCode.Name = "bUpdateRegCode";
            this.bUpdateRegCode.Size = new System.Drawing.Size(130, 33);
            this.bUpdateRegCode.TabIndex = 6;
            this.bUpdateRegCode.Text = "Update";
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
            this.lRegCodeMsg.Location = new System.Drawing.Point(112, 401);
            this.lRegCodeMsg.Name = "lRegCodeMsg";
            this.lRegCodeMsg.Size = new System.Drawing.Size(178, 14);
            this.lRegCodeMsg.TabIndex = 6;
            this.lRegCodeMsg.Text = "Unlock code successfully updated.";
// 
// bClose
// 
            this.bClose.Location = new System.Drawing.Point(356, 391);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(130, 33);
            this.bClose.TabIndex = 7;
            this.bClose.Text = "Close";
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
// 
// License
// 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(560, 474);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.lRegCodeMsg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bLater);
            this.Controls.Add(this.bGoToWebSite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "License";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase a License";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bGoToWebSite;
        private System.Windows.Forms.Button bLater;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbRegCode;
        private System.Windows.Forms.Button bUpdateRegCode;
        private System.Windows.Forms.Label lRegCodeMsg;
        private System.Windows.Forms.Button bClose;
    }
}