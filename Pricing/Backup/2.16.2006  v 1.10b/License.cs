#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using Microsoft.Win32;


#endregion

namespace Prager_Pricing_Program
{
    partial class License : Form
    {
        public License()
        {
            InitializeComponent();
            lRegCodeMsg.Visible = false;
            bClose.Visible = false;
        }




//-------------------------------------------------------------------------------------------
        private void bUpdateRegCode_Click(object sender, EventArgs e)
        {
            char ch;
            int chInt = 0;

            if (tbRegCode.Text.Length < 15)
            {
                MessageBox.Show("Registration code length invalid", "Prager Pricing Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
/*
JDVB-EXHV-VVRW-974
*/
            for (int j = 0; j < 14; j++)  //  number of characters to work with = 14
            {
                if (j == 4 || j == 9 || j == 14)
                    continue;
                ch = Convert.ToChar(tbRegCode.Text.Substring(j, 1));
                chInt += Convert.ToInt32(ch);  //  chInt must match last set of characters
            }
            chInt += 24;  //  add 24 for purchase code

            string[] msg = tbRegCode.Text.Split('-');  //  now, split it into pieces

            if (msg[3] != Convert.ToString(chInt))
            {
                MessageBox.Show("Error in Registration Code\rPlease do a cut and paste for accuracy",
                    "Prager Pricing Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else  //  code was good, store it in the Registry
            {
                RegistryKey OurKey = Registry.Users;  //  get registration code from registry
                OurKey = OurKey.OpenSubKey(@".DEFAULT\Prager\MultiISBN", true);
                OurKey.SetValue("RegistrationCode", tbRegCode.Text);  //  put it in the registry

                lRegCodeMsg.Visible = true;
                bClose.Visible = true;
                MessageBox.Show("Registration was completed.  You must restart the program for it to take effect.",
                     "Prager Pricing Program", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


//-------------------------------------------------------------------------------------------
        private void bLater_Click(object sender, EventArgs e)
        {
            this.Close();
        }


//-------------------------------------------------------------------------------------------
        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


//--------------------------------------------------------------------------------------------
        private void bGoToWebSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.pragerbooksellers.com/html/book_pricing_program.html");
            this.Close();
        }




    }
}