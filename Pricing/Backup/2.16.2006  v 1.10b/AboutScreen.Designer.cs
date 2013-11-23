namespace Prager_Pricing_Program
{
    partial class AboutScreen
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label38 = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
// 
// linkLabel1
// 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Links.Add(new System.Windows.Forms.LinkLabel.Link(0, 32));
            this.linkLabel1.Location = new System.Drawing.Point(202, 221);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(177, 14);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.PragerBooksellers.com";
// 
// label38
// 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(141, 195);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(298, 14);
            this.label38.TabIndex = 6;
            this.label38.Text = "Copyright 2005, Prager, Booksellers.  All Rights Reserved.";
// 
// lVersion
// 
            this.lVersion.AutoSize = true;
            this.lVersion.Location = new System.Drawing.Point(258, 156);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(60, 14);
            this.lVersion.TabIndex = 5;
            this.lVersion.Text = "Version x.x";
// 
// pictureBox1
// 
            this.pictureBox1.Image = Prager_Pricing_Program.Properties.Resources.banner;
            this.pictureBox1.Location = new System.Drawing.Point(51, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(478, 83);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
// 
// bClose
// 
            this.bClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bClose.Location = new System.Drawing.Point(380, 327);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(84, 34);
            this.bClose.TabIndex = 8;
            this.bClose.Text = "Close";
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
// 
// AboutScreen
// 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(581, 458);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AboutScreen";
            this.Text = "AboutScreen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bClose;
    }
}