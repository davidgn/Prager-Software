using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IMF_Database
{
    public partial class Form1 : Form
    {
        SQLiteCommand Cmd = new SQLiteCommand();
        SQLiteConnection Conn = new SQLiteConnection();

        public Form1()
        {
            InitializeComponent();
        }

        public void main()
        {
            FileInfo fi = new FileInfo("e:\\temp\\imf.db");
            if (!fi.Exists)
                createDatabase();

            importTabDelimitedFiles import = new importTabDelimitedFiles();
            import.convertFile(recordsProcessed);
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            main();
        }





    }
}
