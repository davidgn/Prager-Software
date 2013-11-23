namespace ListingSyncronizer
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label5 = new System.Windows.Forms.Label();
            this.bBrowseInp = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.lLSRecsProcessed = new System.Windows.Forms.Label();
            this.lInRecsProcessed = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAmazon = new System.Windows.Forms.RadioButton();
            this.lbStatus = new System.Windows.Forms.ListBox();
            this.lbSKU = new System.Windows.Forms.ListBox();
            this.rbCSVLS = new System.Windows.Forms.RadioButton();
            this.lStatusLS = new System.Windows.Forms.Label();
            this.lSKULS = new System.Windows.Forms.Label();
            this.rbTabLS = new System.Windows.Forms.RadioButton();
            this.rbHBLS = new System.Windows.Forms.RadioButton();
            this.rbUIEELS = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lErrorsDB = new System.Windows.Forms.Label();
            this.lErrorsLS = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // bBrowseInp
            // 
            this.bBrowseInp.BackColor = System.Drawing.SystemColors.ButtonFace;
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
            this.bBrowseInp.Click += new System.EventHandler(this.bOpenDialog_Click);
            // 
            // bStart
            // 
            this.bStart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bStart.FlatAppearance.BorderSize = 2;
            this.bStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bStart.Location = new System.Drawing.Point(608, 177);
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
            this.listBox2.Location = new System.Drawing.Point(301, 239);
            this.listBox2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(255, 472);
            this.listBox2.TabIndex = 27;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(22, 239);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(255, 472);
            this.listBox1.TabIndex = 26;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
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
            this.lLSRecsProcessed.Location = new System.Drawing.Point(23, 204);
            this.lLSRecsProcessed.Name = "lLSRecsProcessed";
            this.lLSRecsProcessed.Size = new System.Drawing.Size(103, 13);
            this.lLSRecsProcessed.TabIndex = 36;
            this.lLSRecsProcessed.Text = "Records Processed:";
            // 
            // lInRecsProcessed
            // 
            this.lInRecsProcessed.AutoSize = true;
            this.lInRecsProcessed.Location = new System.Drawing.Point(300, 204);
            this.lInRecsProcessed.Name = "lInRecsProcessed";
            this.lInRecsProcessed.Size = new System.Drawing.Size(103, 13);
            this.lInRecsProcessed.TabIndex = 37;
            this.lInRecsProcessed.Text = "Records Processed:";
            // 
            // bExit
            // 
            this.bExit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bExit.FlatAppearance.BorderSize = 2;
            this.bExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bExit.Location = new System.Drawing.Point(701, 177);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(77, 28);
            this.bExit.TabIndex = 41;
            this.bExit.Text = "Exit";
            this.toolTip1.SetToolTip(this.bExit, "Exit");
            this.bExit.UseVisualStyleBackColor = false;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAmazon);
            this.groupBox1.Controls.Add(this.lbStatus);
            this.groupBox1.Controls.Add(this.lbSKU);
            this.groupBox1.Controls.Add(this.rbCSVLS);
            this.groupBox1.Controls.Add(this.lStatusLS);
            this.groupBox1.Controls.Add(this.lSKULS);
            this.groupBox1.Controls.Add(this.rbTabLS);
            this.groupBox1.Controls.Add(this.rbHBLS);
            this.groupBox1.Controls.Add(this.rbUIEELS);
            this.groupBox1.Location = new System.Drawing.Point(28, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 83);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File format?";
            this.toolTip1.SetToolTip(this.groupBox1, "Indicate what the format is for the file exported from the Listing service.");
            // 
            // rbAmazon
            // 
            this.rbAmazon.AutoSize = true;
            this.rbAmazon.Location = new System.Drawing.Point(194, 18);
            this.rbAmazon.Name = "rbAmazon";
            this.rbAmazon.Size = new System.Drawing.Size(63, 17);
            this.rbAmazon.TabIndex = 14;
            this.rbAmazon.TabStop = true;
            this.rbAmazon.Text = "Amazon";
            this.rbAmazon.UseVisualStyleBackColor = true;
            // 
            // lbStatus
            // 
            this.lbStatus.FormattingEnabled = true;
            this.lbStatus.Location = new System.Drawing.Point(572, 40);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(161, 30);
            this.lbStatus.TabIndex = 13;
            // 
            // lbSKU
            // 
            this.lbSKU.FormattingEnabled = true;
            this.lbSKU.Location = new System.Drawing.Point(340, 40);
            this.lbSKU.Name = "lbSKU";
            this.lbSKU.Size = new System.Drawing.Size(154, 30);
            this.lbSKU.TabIndex = 12;
            // 
            // rbCSVLS
            // 
            this.rbCSVLS.AutoSize = true;
            this.rbCSVLS.Location = new System.Drawing.Point(116, 41);
            this.rbCSVLS.Name = "rbCSVLS";
            this.rbCSVLS.Size = new System.Drawing.Size(173, 17);
            this.rbCSVLS.TabIndex = 11;
            this.rbCSVLS.TabStop = true;
            this.rbCSVLS.Text = "CSV (comma separated values)";
            this.rbCSVLS.UseVisualStyleBackColor = true;
            this.rbCSVLS.CheckedChanged += new System.EventHandler(this.rbTabLS_CheckedChanged);
            // 
            // lStatusLS
            // 
            this.lStatusLS.AutoSize = true;
            this.lStatusLS.Location = new System.Drawing.Point(502, 45);
            this.lStatusLS.Name = "lStatusLS";
            this.lStatusLS.Size = new System.Drawing.Size(68, 13);
            this.lStatusLS.TabIndex = 10;
            this.lStatusLS.Text = "Book Status:";
            // 
            // lSKULS
            // 
            this.lSKULS.AutoSize = true;
            this.lSKULS.Location = new System.Drawing.Point(307, 44);
            this.lSKULS.Name = "lSKULS";
            this.lSKULS.Size = new System.Drawing.Size(32, 13);
            this.lSKULS.TabIndex = 9;
            this.lSKULS.Text = "SKU:";
            // 
            // rbTabLS
            // 
            this.rbTabLS.AutoSize = true;
            this.rbTabLS.Location = new System.Drawing.Point(16, 41);
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
            this.rbHBLS.Location = new System.Drawing.Point(91, 18);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 721);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Copyright (c) 2005-2013, Prager, Software.  All Rights Reserved.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(400, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 46;
            this.label3.Text = "Database";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(99, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 17);
            this.label6.TabIndex = 47;
            this.label6.Text = "Listing Service";
            // 
            // lErrorsDB
            // 
            this.lErrorsDB.AutoSize = true;
            this.lErrorsDB.Location = new System.Drawing.Point(300, 221);
            this.lErrorsDB.Name = "lErrorsDB";
            this.lErrorsDB.Size = new System.Drawing.Size(40, 13);
            this.lErrorsDB.TabIndex = 57;
            this.lErrorsDB.Text = "Errors: ";
            // 
            // lErrorsLS
            // 
            this.lErrorsLS.AutoSize = true;
            this.lErrorsLS.Location = new System.Drawing.Point(22, 221);
            this.lErrorsLS.Name = "lErrorsLS";
            this.lErrorsLS.Size = new System.Drawing.Size(40, 13);
            this.lErrorsLS.TabIndex = 58;
            this.lErrorsLS.Text = "Errors: ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(798, 24);
            this.menuStrip1.TabIndex = 60;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.helpToolStripMenuItem.Text = "Support";
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.registerToolStripMenuItem.Text = "Register";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.registerToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(575, 234);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 427);
            this.panel1.TabIndex = 61;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Window;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(10, 335);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(190, 63);
            this.textBox5.TabIndex = 65;
            this.textBox5.Text = "5.  For your convenience, you can select an entry in either list, and the corresp" +
    "onding entry (if it exists) will be selected in the opposite list.";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(10, 158);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(190, 72);
            this.textBox2.TabIndex = 64;
            this.textBox2.Text = "3.  If the format is tab-delimited or CSV, you must choose the column name of the" +
    " SKU and Book Status; make sure you select the correct one (it must turn blue).";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Window;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(10, 239);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(190, 87);
            this.textBox4.TabIndex = 63;
            this.textBox4.Text = "4.  Click the Compare button.  The program will take each record from your export" +
    "ed file and compare against the Status in the database; the differences (if any)" +
    " will appear in the boxes to the left.";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Window;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(10, 110);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(190, 39);
            this.textBox3.TabIndex = 62;
            this.textBox3.Text = "2.  Use the Browse button to find the exported filename.";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(10, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(190, 51);
            this.textBox1.TabIndex = 61;
            this.textBox1.Text = "1.  Export from the listing venue that you want to check.  The files can be in an" +
    "y of the formats above.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(61, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 15);
            this.label7.TabIndex = 60;
            this.label7.Text = "Instructions";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(684, 690);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 35);
            this.button1.TabIndex = 62;
            this.button1.Text = "Throw ex";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainForm
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(798, 758);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lErrorsLS);
            this.Controls.Add(this.lErrorsDB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lLSRecsProcessed);
            this.Controls.Add(this.lInRecsProcessed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bBrowseInp);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.tbFilename);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prager Listing Synchronizer Program";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bBrowseInp;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.Label lLSRecsProcessed;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lInRecsProcessed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTabLS;
        private System.Windows.Forms.RadioButton rbHBLS;
        private System.Windows.Forms.RadioButton rbUIEELS;
        private System.Windows.Forms.Label lStatusLS;
        private System.Windows.Forms.Label lSKULS;
        private System.Windows.Forms.RadioButton rbCSVLS;
        private System.Windows.Forms.ListBox lbStatus;
        private System.Windows.Forms.ListBox lbSKU;
        private System.Windows.Forms.Label lErrorsDB;
        private System.Windows.Forms.Label lErrorsLS;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbAmazon;
    }
}

