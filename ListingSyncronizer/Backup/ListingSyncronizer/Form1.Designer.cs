namespace ListingSyncronizer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label5 = new System.Windows.Forms.Label();
            this.bBrowseInv = new System.Windows.Forms.Button();
            this.bBrowseInp = new System.Windows.Forms.Button();
            this.tbFilename2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.lLSRecsProcessed = new System.Windows.Forms.Label();
            this.lInRecsProcessed = new System.Windows.Forms.Label();
            this.rbMISold = new System.Windows.Forms.RadioButton();
            this.rbMI4Sale = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bExit = new System.Windows.Forms.Button();
            this.tbStatusLS = new System.Windows.Forms.TextBox();
            this.tbSKULS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bYesGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lStatusLS = new System.Windows.Forms.Label();
            this.lSKULS = new System.Windows.Forms.Label();
            this.rbTabLS = new System.Windows.Forms.RadioButton();
            this.rbHBLS = new System.Windows.Forms.RadioButton();
            this.rbUIEELS = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbTabInv = new System.Windows.Forms.RadioButton();
            this.rbHBInv = new System.Windows.Forms.RadioButton();
            this.rbUIEEInv = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Listing Service file:";
            // 
            // bBrowseInv
            // 
            this.bBrowseInv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bBrowseInv.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bBrowseInv.FlatAppearance.BorderSize = 2;
            this.bBrowseInv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bBrowseInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBrowseInv.Location = new System.Drawing.Point(634, 129);
            this.bBrowseInv.Name = "bBrowseInv";
            this.bBrowseInv.Size = new System.Drawing.Size(77, 28);
            this.bBrowseInv.TabIndex = 34;
            this.bBrowseInv.Text = "Browse";
            this.bBrowseInv.UseVisualStyleBackColor = false;
            this.bBrowseInv.Click += new System.EventHandler(this.bBrowseInv_Click);
            // 
            // bBrowseInp
            // 
            this.bBrowseInp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bBrowseInp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bBrowseInp.FlatAppearance.BorderSize = 2;
            this.bBrowseInp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bBrowseInp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBrowseInp.Location = new System.Drawing.Point(634, 26);
            this.bBrowseInp.Name = "bBrowseInp";
            this.bBrowseInp.Size = new System.Drawing.Size(77, 28);
            this.bBrowseInp.TabIndex = 33;
            this.bBrowseInp.Text = "Browse";
            this.bBrowseInp.UseVisualStyleBackColor = false;
            this.bBrowseInp.Click += new System.EventHandler(this.bBrowseInp_Click);
            // 
            // tbFilename2
            // 
            this.tbFilename2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbFilename2.Location = new System.Drawing.Point(129, 135);
            this.tbFilename2.Name = "tbFilename2";
            this.tbFilename2.Size = new System.Drawing.Size(488, 20);
            this.tbFilename2.TabIndex = 32;
            this.toolTip1.SetToolTip(this.tbFilename2, "This is the name of the file that was exported from the Inventory program.");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Inventory file:";
            // 
            // bStart
            // 
            this.bStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bStart.Enabled = false;
            this.bStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bStart.FlatAppearance.BorderSize = 2;
            this.bStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bStart.Location = new System.Drawing.Point(602, 400);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(77, 28);
            this.bStart.TabIndex = 28;
            this.bStart.Text = "Compare";
            this.toolTip1.SetToolTip(this.bStart, "Start the compare.");
            this.bStart.UseVisualStyleBackColor = false;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(301, 265);
            this.listBox2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(255, 446);
            this.listBox2.TabIndex = 27;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(22, 265);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(255, 446);
            this.listBox1.TabIndex = 26;
            // 
            // tbFilename
            // 
            this.tbFilename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbFilename.Location = new System.Drawing.Point(129, 32);
            this.tbFilename.Multiline = true;
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.Size = new System.Drawing.Size(488, 20);
            this.tbFilename.TabIndex = 25;
            this.toolTip1.SetToolTip(this.tbFilename, "This is the name of the file that was exported from the listing service (Amazon.c" +
                    "om, Biblio.com, etc.)");
            // 
            // lLSRecsProcessed
            // 
            this.lLSRecsProcessed.AutoSize = true;
            this.lLSRecsProcessed.Location = new System.Drawing.Point(22, 249);
            this.lLSRecsProcessed.Name = "lLSRecsProcessed";
            this.lLSRecsProcessed.Size = new System.Drawing.Size(103, 13);
            this.lLSRecsProcessed.TabIndex = 36;
            this.lLSRecsProcessed.Text = "Records Processed:";
            // 
            // lInRecsProcessed
            // 
            this.lInRecsProcessed.AutoSize = true;
            this.lInRecsProcessed.Location = new System.Drawing.Point(298, 249);
            this.lInRecsProcessed.Name = "lInRecsProcessed";
            this.lInRecsProcessed.Size = new System.Drawing.Size(103, 13);
            this.lInRecsProcessed.TabIndex = 37;
            this.lInRecsProcessed.Text = "Records Processed:";
            // 
            // rbMISold
            // 
            this.rbMISold.AutoSize = true;
            this.rbMISold.Location = new System.Drawing.Point(41, 53);
            this.rbMISold.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.rbMISold.Name = "rbMISold";
            this.rbMISold.Size = new System.Drawing.Size(46, 17);
            this.rbMISold.TabIndex = 29;
            this.rbMISold.Text = "Sold";
            this.toolTip1.SetToolTip(this.rbMISold, "Default when Status missing");
            // 
            // rbMI4Sale
            // 
            this.rbMI4Sale.AutoSize = true;
            this.rbMI4Sale.Location = new System.Drawing.Point(41, 26);
            this.rbMI4Sale.Margin = new System.Windows.Forms.Padding(1, 3, 3, 1);
            this.rbMI4Sale.Name = "rbMI4Sale";
            this.rbMI4Sale.Size = new System.Drawing.Size(64, 17);
            this.rbMI4Sale.TabIndex = 28;
            this.rbMI4Sale.Text = "For Sale";
            this.toolTip1.SetToolTip(this.rbMI4Sale, "Default when Status missing");
            // 
            // bExit
            // 
            this.bExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bExit.FlatAppearance.BorderSize = 2;
            this.bExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bExit.Location = new System.Drawing.Point(695, 400);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(77, 28);
            this.bExit.TabIndex = 41;
            this.bExit.Text = "Exit";
            this.toolTip1.SetToolTip(this.bExit, "Exit");
            this.bExit.UseVisualStyleBackColor = false;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // tbStatusLS
            // 
            this.tbStatusLS.Location = new System.Drawing.Point(572, 16);
            this.tbStatusLS.Name = "tbStatusLS";
            this.tbStatusLS.Size = new System.Drawing.Size(157, 20);
            this.tbStatusLS.TabIndex = 8;
            this.toolTip1.SetToolTip(this.tbStatusLS, "Field name which identifies the book status in the tab-delimited file.");
            // 
            // tbSKULS
            // 
            this.tbSKULS.Location = new System.Drawing.Point(313, 16);
            this.tbSKULS.Name = "tbSKULS";
            this.tbSKULS.Size = new System.Drawing.Size(157, 20);
            this.tbSKULS.TabIndex = 7;
            this.toolTip1.SetToolTip(this.tbSKULS, "Field name which identifies the SKU in the tab-delimited file");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(605, 722);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Version:3.0";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.textBox1.Location = new System.Drawing.Point(608, 448);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(162, 222);
            this.textBox1.TabIndex = 42;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // bYesGo
            // 
            this.bYesGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bYesGo.Location = new System.Drawing.Point(608, 677);
            this.bYesGo.Name = "bYesGo";
            this.bYesGo.Size = new System.Drawing.Size(162, 34);
            this.bYesGo.TabIndex = 43;
            this.bYesGo.Text = "Yes, go to the web site!";
            this.bYesGo.UseVisualStyleBackColor = false;
            this.bYesGo.Click += new System.EventHandler(this.bYesGo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 721);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Copyright (c) 2005-2007, Prager, Software.  All Rights Reserved.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(394, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 46;
            this.label3.Text = "Inventory";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(93, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 17);
            this.label6.TabIndex = 47;
            this.label6.Text = "Listing Service";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lStatusLS);
            this.groupBox1.Controls.Add(this.lSKULS);
            this.groupBox1.Controls.Add(this.tbStatusLS);
            this.groupBox1.Controls.Add(this.tbSKULS);
            this.groupBox1.Controls.Add(this.rbTabLS);
            this.groupBox1.Controls.Add(this.rbHBLS);
            this.groupBox1.Controls.Add(this.rbUIEELS);
            this.groupBox1.Location = new System.Drawing.Point(29, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 44);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File format?";
            this.toolTip1.SetToolTip(this.groupBox1, "Indicate what the format is for the file exported from the Listing service.");
            // 
            // lStatusLS
            // 
            this.lStatusLS.AutoSize = true;
            this.lStatusLS.Location = new System.Drawing.Point(498, 20);
            this.lStatusLS.Name = "lStatusLS";
            this.lStatusLS.Size = new System.Drawing.Size(68, 13);
            this.lStatusLS.TabIndex = 10;
            this.lStatusLS.Text = "Book Status:";
            // 
            // lSKULS
            // 
            this.lSKULS.AutoSize = true;
            this.lSKULS.Location = new System.Drawing.Point(279, 20);
            this.lSKULS.Name = "lSKULS";
            this.lSKULS.Size = new System.Drawing.Size(32, 13);
            this.lSKULS.TabIndex = 9;
            this.lSKULS.Text = "SKU:";
            // 
            // rbTabLS
            // 
            this.rbTabLS.AutoSize = true;
            this.rbTabLS.Location = new System.Drawing.Point(155, 18);
            this.rbTabLS.Name = "rbTabLS";
            this.rbTabLS.Size = new System.Drawing.Size(88, 17);
            this.rbTabLS.TabIndex = 2;
            this.rbTabLS.TabStop = true;
            this.rbTabLS.Text = "Tab-delimited";
            this.rbTabLS.UseVisualStyleBackColor = true;
            this.rbTabLS.CheckedChanged += new System.EventHandler(this.rbTabLS_CheckedChanged);
            // 
            // rbHBLS
            // 
            this.rbHBLS.AutoSize = true;
            this.rbHBLS.Location = new System.Drawing.Point(72, 18);
            this.rbHBLS.Name = "rbHBLS";
            this.rbHBLS.Size = new System.Drawing.Size(77, 17);
            this.rbHBLS.TabIndex = 1;
            this.rbHBLS.TabStop = true;
            this.rbHBLS.Text = "HomeBase";
            this.rbHBLS.UseVisualStyleBackColor = true;
            // 
            // rbUIEELS
            // 
            this.rbUIEELS.AutoSize = true;
            this.rbUIEELS.Location = new System.Drawing.Point(16, 18);
            this.rbUIEELS.Name = "rbUIEELS";
            this.rbUIEELS.Size = new System.Drawing.Size(50, 17);
            this.rbUIEELS.TabIndex = 0;
            this.rbUIEELS.TabStop = true;
            this.rbUIEELS.Text = "UIEE";
            this.rbUIEELS.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbTabInv);
            this.groupBox2.Controls.Add(this.rbHBInv);
            this.groupBox2.Controls.Add(this.rbUIEEInv);
            this.groupBox2.Location = new System.Drawing.Point(29, 161);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 44);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File format?";
            this.toolTip1.SetToolTip(this.groupBox2, "Indicate what the format is for the file exported from the Inventory program.");
            // 
            // rbTabInv
            // 
            this.rbTabInv.AutoSize = true;
            this.rbTabInv.Location = new System.Drawing.Point(155, 17);
            this.rbTabInv.Name = "rbTabInv";
            this.rbTabInv.Size = new System.Drawing.Size(88, 17);
            this.rbTabInv.TabIndex = 2;
            this.rbTabInv.TabStop = true;
            this.rbTabInv.Text = "Tab-delimited";
            this.rbTabInv.UseVisualStyleBackColor = true;
            // 
            // rbHBInv
            // 
            this.rbHBInv.AutoSize = true;
            this.rbHBInv.Location = new System.Drawing.Point(72, 17);
            this.rbHBInv.Name = "rbHBInv";
            this.rbHBInv.Size = new System.Drawing.Size(77, 17);
            this.rbHBInv.TabIndex = 1;
            this.rbHBInv.TabStop = true;
            this.rbHBInv.Text = "HomeBase";
            this.rbHBInv.UseVisualStyleBackColor = true;
            // 
            // rbUIEEInv
            // 
            this.rbUIEEInv.AutoSize = true;
            this.rbUIEEInv.Location = new System.Drawing.Point(16, 17);
            this.rbUIEEInv.Name = "rbUIEEInv";
            this.rbUIEEInv.Size = new System.Drawing.Size(50, 17);
            this.rbUIEEInv.TabIndex = 0;
            this.rbUIEEInv.TabStop = true;
            this.rbUIEEInv.Text = "UIEE";
            this.rbUIEEInv.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbMI4Sale);
            this.groupBox3.Controls.Add(this.rbMISold);
            this.groupBox3.Location = new System.Drawing.Point(602, 265);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(162, 106);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "If Status is missing, assume:";
            // 
            // Form1
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(798, 758);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lLSRecsProcessed);
            this.Controls.Add(this.lInRecsProcessed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bYesGo);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bBrowseInv);
            this.Controls.Add(this.bBrowseInp);
            this.Controls.Add(this.tbFilename2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.tbFilename);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prager Listing Synchronizer Program";
         //   this.Load += new System.EventHandler(this.Form1_Load);
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

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bBrowseInv;
        private System.Windows.Forms.Button bBrowseInp;
        private System.Windows.Forms.TextBox tbFilename2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.Label lLSRecsProcessed;
        private System.Windows.Forms.RadioButton rbMISold;
        private System.Windows.Forms.RadioButton rbMI4Sale;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lInRecsProcessed;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bYesGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTabLS;
        private System.Windows.Forms.RadioButton rbHBLS;
        private System.Windows.Forms.RadioButton rbUIEELS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbTabInv;
        private System.Windows.Forms.RadioButton rbHBInv;
        private System.Windows.Forms.RadioButton rbUIEEInv;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lStatusLS;
        private System.Windows.Forms.Label lSKULS;
        private System.Windows.Forms.TextBox tbStatusLS;
        private System.Windows.Forms.TextBox tbSKULS;
    }
}

