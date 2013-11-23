namespace BulkAddBooks
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
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.dgvDataEntry = new System.Windows.Forms.DataGridView();
            this.cISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bStart = new System.Windows.Forms.Button();
            this.cbAutomaticSKU = new System.Windows.Forms.CheckBox();
            this.lDone = new System.Windows.Forms.Label();
            this.bClear = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bRestore = new System.Windows.Forms.Button();
            this.lSaveDone = new System.Windows.Forms.Label();
            this.lRestoreDone = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDataEntry
            // 
            this.dgvDataEntry.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDataEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cISBN,
            this.cSKU});
            this.dgvDataEntry.Location = new System.Drawing.Point(21, 12);
            this.dgvDataEntry.MultiSelect = false;
            this.dgvDataEntry.Name = "dgvDataEntry";
            this.dgvDataEntry.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDataEntry.ShowCellToolTips = false;
            this.dgvDataEntry.Size = new System.Drawing.Size(264, 596);
            this.dgvDataEntry.TabIndex = 0;
            // 
            // cISBN
            // 
            this.cISBN.HeaderText = "ISBN";
            this.cISBN.MaxInputLength = 13;
            this.cISBN.Name = "cISBN";
            // 
            // cSKU
            // 
            this.cSKU.HeaderText = "SKU";
            this.cSKU.MaxInputLength = 15;
            this.cSKU.Name = "cSKU";
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(309, 95);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 1;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // cbAutomaticSKU
            // 
            this.cbAutomaticSKU.AutoSize = true;
            this.cbAutomaticSKU.Location = new System.Drawing.Point(309, 51);
            this.cbAutomaticSKU.Name = "cbAutomaticSKU";
            this.cbAutomaticSKU.Size = new System.Drawing.Size(171, 17);
            this.cbAutomaticSKU.TabIndex = 2;
            this.cbAutomaticSKU.Text = "Use automatic SKU numbering";
            this.cbAutomaticSKU.UseVisualStyleBackColor = true;
            // 
            // lDone
            // 
            this.lDone.AutoSize = true;
            this.lDone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lDone.Location = new System.Drawing.Point(406, 100);
            this.lDone.Name = "lDone";
            this.lDone.Size = new System.Drawing.Size(57, 13);
            this.lDone.TabIndex = 3;
            this.lDone.Text = "Completed";
            this.lDone.Visible = false;
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(309, 137);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 4;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(309, 285);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 5;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bRestore
            // 
            this.bRestore.Location = new System.Drawing.Point(309, 327);
            this.bRestore.Name = "bRestore";
            this.bRestore.Size = new System.Drawing.Size(75, 23);
            this.bRestore.TabIndex = 6;
            this.bRestore.Text = "Restore";
            this.bRestore.UseVisualStyleBackColor = true;
            this.bRestore.Click += new System.EventHandler(this.bRestore_Click);
            // 
            // lSaveDone
            // 
            this.lSaveDone.AutoSize = true;
            this.lSaveDone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lSaveDone.Location = new System.Drawing.Point(406, 290);
            this.lSaveDone.Name = "lSaveDone";
            this.lSaveDone.Size = new System.Drawing.Size(57, 13);
            this.lSaveDone.TabIndex = 7;
            this.lSaveDone.Text = "Completed";
            this.lSaveDone.Visible = false;
            // 
            // lRestoreDone
            // 
            this.lRestoreDone.AutoSize = true;
            this.lRestoreDone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lRestoreDone.Location = new System.Drawing.Point(406, 332);
            this.lRestoreDone.Name = "lRestoreDone";
            this.lRestoreDone.Size = new System.Drawing.Size(57, 13);
            this.lRestoreDone.TabIndex = 8;
            this.lRestoreDone.Text = "Completed";
            this.lRestoreDone.Visible = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 620);
            this.Controls.Add(this.lRestoreDone);
            this.Controls.Add(this.lSaveDone);
            this.Controls.Add(this.bRestore);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.lDone);
            this.Controls.Add(this.cbAutomaticSKU);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.dgvDataEntry);
            this.Name = "mainForm";
            this.Text = "Prager Bulk Book Adder";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataEntry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn cISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSKU;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.CheckBox cbAutomaticSKU;
        private System.Windows.Forms.Label lDone;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bRestore;
        private System.Windows.Forms.Label lSaveDone;
        private System.Windows.Forms.Label lRestoreDone;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

