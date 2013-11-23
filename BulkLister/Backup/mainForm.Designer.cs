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
            this.dgvDataEntry.Location = new System.Drawing.Point(21, 22);
            this.dgvDataEntry.Name = "dgvDataEntry";
            this.dgvDataEntry.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDataEntry.Size = new System.Drawing.Size(264, 579);
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
            this.bStart.Location = new System.Drawing.Point(309, 154);
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
            this.lDone.Location = new System.Drawing.Point(422, 161);
            this.lDone.Name = "lDone";
            this.lDone.Size = new System.Drawing.Size(33, 13);
            this.lDone.TabIndex = 3;
            this.lDone.Text = "Done";
            this.lDone.Visible = false;
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(309, 196);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 4;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 613);
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
    }
}

