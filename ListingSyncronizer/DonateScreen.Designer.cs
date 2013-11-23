namespace ListingSyncronizer
{
    partial class DonateScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonateScreen));
            this.label1 = new System.Windows.Forms.Label();
            this.bDonateNow = new System.Windows.Forms.Button();
            this.bLater = new System.Windows.Forms.Button();
            this.lThanks = new System.Windows.Forms.Label();
            this.bAlreadyDonated = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(565, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "If you haven\'t already done so, won\'t you please donate to help keep this program" +
                " alive?";
            // 
            // bDonateNow
            // 
            this.bDonateNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bDonateNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDonateNow.Location = new System.Drawing.Point(360, 206);
            this.bDonateNow.Name = "bDonateNow";
            this.bDonateNow.Size = new System.Drawing.Size(197, 23);
            this.bDonateNow.TabIndex = 2;
            this.bDonateNow.Text = "Yes, I would like to donate";
            this.bDonateNow.UseVisualStyleBackColor = false;
            this.bDonateNow.Click += new System.EventHandler(this.bDonateNow_Click);
            // 
            // bLater
            // 
            this.bLater.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bLater.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLater.Location = new System.Drawing.Point(211, 206);
            this.bLater.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.bLater.Name = "bLater";
            this.bLater.Size = new System.Drawing.Size(125, 23);
            this.bLater.TabIndex = 3;
            this.bLater.Text = "I\'ll donate later.";
            this.bLater.UseVisualStyleBackColor = false;
            this.bLater.Click += new System.EventHandler(this.bLater_Click);
            // 
            // lThanks
            // 
            this.lThanks.AutoSize = true;
            this.lThanks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lThanks.Location = new System.Drawing.Point(468, 282);
            this.lThanks.Name = "lThanks";
            this.lThanks.Size = new System.Drawing.Size(89, 17);
            this.lThanks.TabIndex = 4;
            this.lThanks.Text = "Thank you.";
            this.lThanks.Visible = false;
            // 
            // bAlreadyDonated
            // 
            this.bAlreadyDonated.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bAlreadyDonated.Location = new System.Drawing.Point(54, 206);
            this.bAlreadyDonated.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.bAlreadyDonated.Name = "bAlreadyDonated";
            this.bAlreadyDonated.Size = new System.Drawing.Size(133, 23);
            this.bAlreadyDonated.TabIndex = 5;
            this.bAlreadyDonated.Text = "I\'ve already donated.";
            this.bAlreadyDonated.UseVisualStyleBackColor = false;
            this.bAlreadyDonated.Click += new System.EventHandler(this.bAlreadyDonated_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(109, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(392, 120);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // DonateScreen
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(610, 445);
            this.Controls.Add(this.bAlreadyDonated);
            this.Controls.Add(this.lThanks);
            this.Controls.Add(this.bLater);
            this.Controls.Add(this.bDonateNow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DonateScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DonateScreen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bDonateNow;
        private System.Windows.Forms.Button bLater;
        private System.Windows.Forms.Label lThanks;
        private System.Windows.Forms.Button bAlreadyDonated;
    }
}