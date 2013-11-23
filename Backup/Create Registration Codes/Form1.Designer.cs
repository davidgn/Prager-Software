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
            this.tbRN1 = new System.Windows.Forms.TextBox();
            this.tbVerified = new System.Windows.Forms.TextBox();
            this.rbInventory = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPricing = new System.Windows.Forms.RadioButton();
            this.rbSynchronizer = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bGenerate
            // 
            this.bGenerate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bGenerate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bGenerate.FlatAppearance.BorderSize = 2;
            this.bGenerate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bGenerate.Location = new System.Drawing.Point(340, 170);
            this.bGenerate.Name = "bGenerate";
            this.bGenerate.Size = new System.Drawing.Size(134, 37);
            this.bGenerate.TabIndex = 0;
            this.bGenerate.Text = "Generate";
            this.bGenerate.UseVisualStyleBackColor = false;
            this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
            // 
            // tbRN1
            // 
            this.tbRN1.Location = new System.Drawing.Point(183, 121);
            this.tbRN1.Name = "tbRN1";
            this.tbRN1.Size = new System.Drawing.Size(189, 20);
            this.tbRN1.TabIndex = 1;
            // 
            // tbVerified
            // 
            this.tbVerified.Location = new System.Drawing.Point(413, 121);
            this.tbVerified.Name = "tbVerified";
            this.tbVerified.Size = new System.Drawing.Size(61, 20);
            this.tbVerified.TabIndex = 2;
            // 
            // rbInventory
            // 
            this.rbInventory.AutoSize = true;
            this.rbInventory.Location = new System.Drawing.Point(32, 29);
            this.rbInventory.Name = "rbInventory";
            this.rbInventory.Size = new System.Drawing.Size(111, 17);
            this.rbInventory.TabIndex = 3;
            this.rbInventory.Text = "Inventory Program";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSynchronizer);
            this.groupBox1.Controls.Add(this.rbPricing);
            this.groupBox1.Controls.Add(this.rbInventory);
            this.groupBox1.Location = new System.Drawing.Point(54, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 68);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rbPricing
            // 
            this.rbPricing.AutoSize = true;
            this.rbPricing.Location = new System.Drawing.Point(165, 29);
            this.rbPricing.Name = "rbPricing";
            this.rbPricing.Size = new System.Drawing.Size(99, 17);
            this.rbPricing.TabIndex = 4;
            this.rbPricing.Text = "Pricing Program";
            // 
            // rbSynchronizer
            // 
            this.rbSynchronizer.AutoSize = true;
            this.rbSynchronizer.Location = new System.Drawing.Point(286, 29);
            this.rbSynchronizer.Name = "rbSynchronizer";
            this.rbSynchronizer.Size = new System.Drawing.Size(86, 17);
            this.rbSynchronizer.TabIndex = 5;
            this.rbSynchronizer.Text = "Synchronizer";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(528, 262);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbVerified);
            this.Controls.Add(this.tbRN1);
            this.Controls.Add(this.bGenerate);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Key Generator v.1.2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bGenerate;
        private System.Windows.Forms.TextBox tbRN1;
        private System.Windows.Forms.TextBox tbVerified;
        private System.Windows.Forms.RadioButton rbInventory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPricing;
        private System.Windows.Forms.RadioButton rbSynchronizer;
    }
}

