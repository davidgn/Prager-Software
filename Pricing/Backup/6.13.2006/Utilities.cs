#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
#endregion

[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]

namespace Prager_Pricing_Program
{
    partial class formISBNLookup : Form
    {



        //---------------------------------------------------------------------------------------------------
        public void checkForUpdates()
        {
            string replyFromHost = DownloadVersionInfo();

            int dataLength = replyFromHost.Length - 4;
            if (programVersion != replyFromHost.Substring(1, dataLength))
            {
                MessageBox.Show("There is a new version of this program available.\r" +
                    "Please go to http://www.rainpepper.com/pragersoftware and download it.",
                    "Prager Pricing Program", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You currently have the latest version.", "Prager Pricing Program", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cursor.Current = Cursors.Default;
        }


        //--------------------------------------------------------------------------------------------------
        static string DownloadVersionInfo()
        {
            //  return replyFromHost;
            NetworkCredential credentials = new NetworkCredential("prager", "Sp0Kane");  //  userid/password

            //      string serverAddress = @"www.pragersoftware.com";
            FtpWebRequest request = null;
            FtpWebResponse response = null;
            string replyFromHost = " ";
            StreamReader sr = null;
            try
            {
                // create a FtpWebRequest object
                request = (FtpWebRequest)FtpWebRequest.Create(new Uri(@"ftp://win03.midphase.com/httpdocs/PricingVersionInfo.txt"));
                request.Credentials = credentials;

                // get the response object
                response = (FtpWebResponse)request.GetResponse();

                // to read the contents of the file, get the ResponseStream
                sr = new StreamReader(response.GetResponseStream());
                replyFromHost = sr.ReadToEnd();
            }

            catch (WebException e)
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show("Unable to determine if there is a new version (site busy)\nPlease try later", "Prager Pricing Program",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return " ";
            }

            return replyFromHost;

        }


        //-------------------------------------------------------------------------------------------------
        private void searchRegistry()
        {
            RegistryKey OurKey = Registry.Users;
            string[] subKeyNames = OurKey.GetSubKeyNames();

        }

    }
}