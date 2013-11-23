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
 

//-----------------------------------------------------------------------------------------------
        public void checkForLicense()
        {
            DateTime todaysDate;
            RegistryKey OurKey = Registry.Users;

            OurKey = OurKey.OpenSubKey(".DEFAULT", true); // Set it to HKEY_LOCAL_MACHINE/Software
            if (OurKey.OpenSubKey(@"Prager\MultiISBN", true) == null)
            {

                OurKey.CreateSubKey("Prager"); // Create the key HKEY_USERS\.DEAFULT\OurSubKey
                OurKey.CreateSubKey(@"Prager\MultiISBN"); // Create a sub key HKEY_USERS\.DEFAULT\Prager\MultiISBN
            }

            OurKey = OurKey.OpenSubKey(@"Prager\MultiISBN", true);

            if (OurKey.GetValue("RegistrationCode") != null)  //  it's there, verify it...
            {
                verifyLicenseIsValid();
                return;
            }

            //  has it been installed?
            todaysDate = DateTime.Now;
            string encodedDate = "";
            if (OurKey.GetValue("InstallDate") == null)  //  if it has not been installed...
            {
                encodedDate = encodeDecodeDate(todaysDate.ToShortDateString(), true);  //  true = encode
                OurKey.SetValue("InstallDate", encodedDate);  //  set install date
                OurKey.SetValue("Version", programVersion);  //  set version
                return;
            }
            else  //  has been installed, so convert date in registry
            {
                char[] checkDate = (char[])OurKey.GetValue("InstallDate").ToString().ToCharArray();
                if (checkDate[2] == '/')
                {
                //  make sure date is not beyond today
                    string tempDT = (string)OurKey.GetValue("InstallDate").ToString();
                    if (todaysDate.CompareTo(Convert.ToDateTime(tempDT)) == -1)  //   means it's been altered
                    {
                        OurKey.SetValue("InstallDate", DateTime.Now);  //  set install date to today
                        OurKey.SetValue("Version", programVersion);  //  set version
                        OurKey.SetValue("DateAltered", "Y");  //  indicate date has been altered
                    }

                    encodedDate = encodeDecodeDate((string)OurKey.GetValue("InstallDate").ToString(), true);
                    OurKey.SetValue("InstallDate", encodedDate);  //  set install date
                }
            }

            string decodedDate = encodeDecodeDate((string)OurKey.GetValue("InstallDate"), false);  //  false = decode
            DateTime installationDate = Convert.ToDateTime(decodedDate);

            if (OurKey.GetValue("Version") != null)   //  older version installed, so 30-day rule applys
            {
                TimeSpan thirtyDays = TimeSpan.FromDays(30);
                TimeSpan fourtyFiveDays = TimeSpan.FromDays(45);
                DateTime expiryDate = installationDate.Add(thirtyDays);
//                DateTime expiryDate = installationDate.Subtract(thirtyDays);  //  TESTING ONLY!

                if (todaysDate.CompareTo(expiryDate) == -1)  //  time has not expired
                {
                    License regScreen = new License();    //  display the form
                    regScreen.Show();
                    regScreen.TopMost = true;
                }
                else  //  time has expired
                {
                    if (OurKey.GetValue("RegistrationCode", null) == null)  //  means we have not registered yet
                    {
                        bSearch.Enabled = false;
                        tabControl1.Enabled = false;

                        License regScreen = new License();    //  display the form
                        regScreen.Show();
                        regScreen.TopMost = true;
                    }
                    else  //  we have registered, so validate the registration code
                    {
                        verifyLicenseIsValid();
                    }
                }
            }
            OurKey.Close();
        }  //  end check registry


//  JDVB-EXHV-VVRW-974
//---------------------------------------------------------------------------------------
        public void verifyLicenseIsValid()
        {

            RegistryKey OurKey = Registry.Users;

            OurKey = OurKey.OpenSubKey(".DEFAULT", true); // Set it to HKEY_USERS\.DEFUALT
            OurKey = OurKey.OpenSubKey(@"Prager\MultiISBN", true);

            string registryRegCode = (string)OurKey.GetValue("RegistrationCode");  //  get registration code from registry
            if (registryRegCode.Length != 0)
            {
                char ch;
                int chInt = 0;
                for (int j = 0; j < 14; j++)
                {
                    if (j == 4 || j == 9 || j == 14)
                        continue;
                    ch = Convert.ToChar(registryRegCode.Substring(j, 1));
                    chInt += Convert.ToInt32(ch);  //  chInt must match last set of characters
                }
                chInt += 24;  //  indicates it was paid for...
                string[] msg = registryRegCode.Split('-');  //  now, split it into pieces

                if (msg[3] != Convert.ToString(chInt))
                {
                    MessageBox.Show("Error in Registration Code\rNotify Prager,Booksellers of this error",
                        "Prager Pricing Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bSearch.Enabled = false;
                    tabControl1.Enabled = false;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Error in Registration Code\rNotify Prager,Booksellers of this error",
                    "Prager Pricing Program", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bSearch.Enabled = false;
                tabControl1.Enabled = false;
                return;
            }

        }


//-------------------------------------------------------------------------------------
        public string encodeDecodeDate(string workingDate, bool encodeOrDecode)
        {
            char[] monthKey = { 'T', 'v', 'm', 'P', 'E', 'k', 'X', 'W', 'a', 'C' };
            char[] dayKey = { 'g', 'S', 'o', 'Y', 'K', 'v', 'H', 'a', 'l', 'f' };
            char[] yearKey = { 'O', 'B', 'k', 'R', 'X', 'J', 'c', 'P', 'I', 'e' };
            char[] workingChars = null;
            char[] charReturnedDate = { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0' };
            string returnedDate = "";

            if (encodeOrDecode == true)  //  encode
            {
                string[] dateParts = workingDate.Split('/');  //  split into components

                workingChars = dateParts[0].ToCharArray();  //  do month
                charReturnedDate[2] = monthKey[workingChars[0] - 48];
                charReturnedDate[3] = monthKey[workingChars[1] - 48];

                workingChars = dateParts[1].ToCharArray();  //  do day
                charReturnedDate[0] = dayKey[workingChars[0] - 48];
                charReturnedDate[1] = dayKey[workingChars[1] - 48];

                workingChars = dateParts[2].ToCharArray();  //  do day
                charReturnedDate[4] = yearKey[workingChars[0] - 48];
                charReturnedDate[5] = yearKey[workingChars[1] - 48];
                charReturnedDate[6] = yearKey[workingChars[2] - 48];
                charReturnedDate[7] = yearKey[workingChars[3] - 48];
                returnedDate = new string(charReturnedDate);

            }
            else  //  decode
            {
                workingChars = workingDate.ToCharArray();

                charReturnedDate[0] = decodeMonth(workingChars[2]);
                charReturnedDate[1] = decodeMonth(workingChars[3]);
                charReturnedDate[2] = '/';
                charReturnedDate[3] = decodeDay(workingChars[0]);
                charReturnedDate[4] = decodeDay(workingChars[1]);
                charReturnedDate[5] = '/';
                charReturnedDate[6] = decodeYear(workingChars[4]);
                charReturnedDate[7] = decodeYear(workingChars[5]);
                charReturnedDate[8] = decodeYear(workingChars[6]);
                charReturnedDate[9] = decodeYear(workingChars[7]);
                returnedDate = new string(charReturnedDate);
            }

            return returnedDate;
        }


//--------------------------    decode month    ----------------------------------------
        private char decodeMonth(char bite)
        {
            char byteToReturn = ' ';
            switch (bite)
            {
                case 'T':
                    byteToReturn = '0';
                    break;
                case 'v':
                    byteToReturn = '1';
                    break;
                case 'm':
                    byteToReturn = '2';
                    break;
                case 'P':
                    byteToReturn = '3';
                    break;
                case 'E':
                    byteToReturn = '4';
                    break;
                case 'k':
                    byteToReturn = '5';
                    break;
                case 'X':
                    byteToReturn = '6';
                    break;
                case 'W':
                    byteToReturn = '7';
                    break;
                case 'a':
                    byteToReturn = '8';
                    break;
                case 'C':
                    byteToReturn = '9';
                    break;
                default:
                    byteToReturn = '0';
                    break;
            }
            return byteToReturn;
        }



//--------------------------    decode day    ----------------------------------------
        private char decodeDay(char bite)
        {
            char byteToReturn = ' ';

            switch (bite)
            {
                case 'g':
                    byteToReturn = '0';
                    break;
                case 'S':
                    byteToReturn = '1';
                    break;
                case 'o':
                    byteToReturn = '2';
                    break;
                case 'Y':
                    byteToReturn = '3';
                    break;
                case 'K':
                    byteToReturn = '4';
                    break;
                case 'v':
                    byteToReturn = '5';
                    break;
                case 'H':
                    byteToReturn = '6';
                    break;
                case 'a':
                    byteToReturn = '7';
                    break;
                case 'l':
                    byteToReturn = '8';
                    break;
                case 'f':
                    byteToReturn = '9';
                    break;
                default:
                    byteToReturn = '0';
                    break;
            }
            return byteToReturn;
        }



//--------------------------    decode year    ----------------------------------------
        private char decodeYear(char bite)
        {
            char byteToReturn = ' ';
            switch (bite)
            {
                case 'O':
                    byteToReturn = '0';
                    break;
                case 'B':
                    byteToReturn = '1';
                    break;
                case 'k':
                    byteToReturn = '2';
                    break;
                case 'R':
                    byteToReturn = '3';
                    break;
                case 'X':
                    byteToReturn = '4';
                    break;
                case 'J':
                    byteToReturn = '5';
                    break;
                case 'c':
                    byteToReturn = '6';
                    break;
                case 'P':
                    byteToReturn = '7';
                    break;
                case 'I':
                    byteToReturn = '8';
                    break;
                case 'e':
                    byteToReturn = '9';
                    break;
                default:
                    byteToReturn = '0';
                    break;
            }
            return byteToReturn;
        }


//---------------------------------------------------------------------------------------------------
        public void checkForUpdates()
        {
            string replyFromHost = DownloadVersionInfo();

            int dataLength = replyFromHost.Length - 3;
            if (programVersion != replyFromHost.Substring(1, dataLength))
            {
                MessageBox.Show("There is a new version of this program available.\r" +
                    "Please go to http://www.PragerBooksellers.com and download it.",
                    "Prager Pricing Program", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cursor.Current = Cursors.Default;
        }
        
        
//--------------------------------------------------------------------------------------------------
        static string DownloadVersionInfo()
        {
            NetworkCredential credentials = new NetworkCredential("lkmarsh", "spokane");

            string serverAddress = "ftp://ftp.users.qwest.net/";
            FtpWebRequest request = null;
            FtpWebResponse response = null;
            string replyFromHost = " ";

            // download file
            StreamReader sr = null;
            try
            {
                string downloadAddress = serverAddress + "ISBNversionInfo.txt";

                // create a FtpWebRequest object
                request = (FtpWebRequest)FtpWebRequest.Create(new Uri(downloadAddress));
                request.Credentials = credentials;

                // set the method
                request.Method = FtpMethods.DownloadFile;

                // get the response object. We would need to extract the response stream from this
                //  object to get handle on the data we are downloading
                response = (FtpWebResponse)request.GetResponse();

                // to read the contents of the file, get the ResponseStream
                sr = new StreamReader(response.GetResponseStream());
                replyFromHost = sr.ReadToEnd();
            }
            catch (WebException)
            {
//                MessageBox.Show(e.ToString());
                MessageBox.Show("Unable to determine if there is a new version (site busy)\nPlease try later", "Prager Pricing Program",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //        response.Close();
                sr.Close();
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