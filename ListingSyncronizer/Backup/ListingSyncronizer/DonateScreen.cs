#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

namespace ListingSyncronizer
{
    partial class DonateScreen : Form
    {
        public DonateScreen()
        {
            InitializeComponent();
        }


//----------------------------------------------------------------------------------------
        private void bLater_Click(object sender, EventArgs e)
        {
            this.Close();
        }


//-----------------------------------------------------------------------------------------
        private void bDonateNow_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.pragersoftware.com/html/licensing.html");
            lThanks.Visible = true;
            this.Close();
        }


//-------------------------------------------------------------------------------------------
        private void bAlreadyDonated_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}