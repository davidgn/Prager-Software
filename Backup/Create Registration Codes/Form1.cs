#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace WindowsApplication1
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bGenerate_Click(object sender, EventArgs e)
        {

            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            Int32 int32 = 0;
            int chInt = 0;
            int size = 12;

            for (int i = 0; i < size; i++)
            {
                int32 = Convert.ToInt32(26 * random.NextDouble() + 65);  //  get random number
                if (int32 < 64 || int32 > 90)  //  only want upper case letters
                {
                    i--;  //  decrement control
                    continue;
                }
                chInt += int32;  //  add to verification number
                ch = Convert.ToChar(int32);  //  convert to a character
                builder.Append(ch);  //  append it to the string
            }

            //  find out which program this is for...
            if (rbInventory.Checked == true)
                chInt += 24;  
            else if (rbPricing.Checked == true)
                chInt += 33;  
            else if (rbSynchronizer.Checked == true)
                chInt += 67;

            builder.Append(chInt);  //  now append the verification number
            builder.Insert(4, '-');  //  insert hyphens
            builder.Insert(9, '-');
            builder.Insert(14, '-');
            tbRN1.Text = builder.ToString();  //  move it to the text field

            chInt = 0;

            for (int j = 0; j < size + 2; j++)  //  now, verify it...
            {
                if (j == 4 || j == 9 || j == 14)
                   continue;
                ch = Convert.ToChar(tbRN1.Text.Substring(j, 1));
                chInt += Convert.ToInt32(ch);
            }

            tbVerified.Text = Convert.ToString(chInt);

        }
    }
}
