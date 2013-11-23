#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Prager_Pricing_Program
{
    partial class AboutScreen : Form
    {
        public AboutScreen()
        {
            InitializeComponent();
            lVersion.Text = "Version " + formISBNLookup.programVersion;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}