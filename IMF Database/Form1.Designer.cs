namespace IMF_Database
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.recordsProcessed = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 58);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(364, 442);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // recordsProcessed
            // 
            this.recordsProcessed.AutoSize = true;
            this.recordsProcessed.Location = new System.Drawing.Point(12, 9);
            this.recordsProcessed.Name = "recordsProcessed";
            this.recordsProcessed.Size = new System.Drawing.Size(126, 13);
            this.recordsProcessed.TabIndex = 1;
            this.recordsProcessed.Text = "Records Processed: xxxx";
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(254, 7);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(91, 28);
            this.bStart.TabIndex = 2;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 512);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.recordsProcessed);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.Label recordsProcessed;
        private System.Windows.Forms.Button bStart;
    }
}

