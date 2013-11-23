#region Using directives

using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
#endregion

[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]

namespace Prager_Pricing_Program
{
    partial class formISBNLookup : Form
    {

        ////---------------------------------------------------------------------------------------------------
        //public void checkForUpdates()
        //{
        //    string replyFromHost = DownloadVersionInfo();

        //    int dataLength = replyFromHost.Length - 4;
        //    string debugInfo = replyFromHost.Substring(1, dataLength + 1);
        //    if (programVersion != replyFromHost.Substring(1, dataLength + 1))
        //        newVersionAvailableToolStripMenuItem.Visible = true;
        //}


        //--------------------------------------------------------------------------------------------------
        static string DownloadVersionInfo()
        {
            //NetworkCredential credentials = new NetworkCredential("wwwmar1", "zBQmdTCt");  //  userid/password

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            string replyFromHost = " ";
            StreamReader sr = null;
            try
            {
                // create a FtpWebRequest object
                request = (HttpWebRequest)HttpWebRequest.Create(new Uri(@"http://www.pragersoftware.com/downloads/PricingVersionInfo.txt"));
                request.Timeout = 30000;  //  30 seconds
                //request.Credentials = credentials;
                request.KeepAlive = false;

                System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;  //  needed for bug in .NET 2.0

                // get the response object
                response = (HttpWebResponse)request.GetResponse();

                // to read the contents of the file, get the ResponseStream
                sr = new StreamReader(response.GetResponseStream());
                replyFromHost = sr.ReadToEnd();
            }

            catch (WebException ex)
            {
                if (ex.Message.Contains("The operation has timed out."))
                    return " ";
                //    MessageBox.Show(e.ToString());
                MessageBox.Show("Unable to determine if there is a new version (site busy)\nPlease try later", "Prager Inventory Program",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return " ";
            }

            return replyFromHost;

        }


    

        //----------------------------------------------------------------    check memory and OS    ------------------------------------------------
        private void checkMemoryAndOS()  //  did have static after private; removed because ftrace had errors
        {
            ulong totalMemory = 0;
            ulong memoryInK = 0;
            ManagementObjectSearcher query;
            ManagementObjectCollection queryCollection;
            System.Management.ObjectQuery oq;

            ConnectionOptions co = new ConnectionOptions();

            System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2", co);

            oq = new System.Management.ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            query = new ManagementObjectSearcher(ms, oq);

            queryCollection = query.Get();
            foreach (ManagementObject mo in queryCollection)
            {
                osName = (string)mo["Caption"];
                osServicePack = mo["ServicePackMajorVersion"].ToString();
            }


            if (osName.Contains("2000 Professional") == true)
            {
                if (osServicePack != "4")
                    MessageBox.Show("Your Service Pack level is not current.  This may affect the execution of this program.",
                        "Prager Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (osName.Contains("Windows XP") == true)
            {
                if (osServicePack != "2" && osServicePack != "3")
                    MessageBox.Show("Your Service Pack level is not current.  This may affect the execution of this program.",
                        "Prager Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                                                                            
            }



            //  if it's not Vista, check the service pack level of .NET v2.0
            if (!osName.Contains("Vista") && !osName.Contains("Windows 7"))
            {
                //  delete the old restoreKey stuff... (caused David's window to shrink on the right)
                using (RegistryKey restoreState = Registry.CurrentUser.OpenSubKey("SOFTWARE\\RestoreState\\RealPosition\\", true))
                {
                    if (restoreState != null)
                    {
                        try
                        {
                            restoreState.DeleteSubKeyTree("RealPosition");
                        }
                        catch (Exception ex)
                        {
                            if (!ex.Message.Contains("the subkey does not exist"))
                                fTrace("W - 193 (Subkey RealPosition does not exist): " + ex.Message);
                        }
                    }
                }

            }

            //machine info
            oq = new System.Management.ObjectQuery("SELECT * FROM Win32_ComputerSystem");
            query = new ManagementObjectSearcher(ms, oq);
            queryCollection = query.Get();

            foreach (ManagementObject mo in queryCollection)
                totalMemory = (ulong)mo["totalphysicalmemory"];

            //  enough memory?
            amountOfMemory = (totalMemory / 1048576).ToString();  //  just in case we abort and need to send email
            fTrace("I - memory = " + (totalMemory / 1048576) + "K");
            if (int.Parse(amountOfMemory) < 510)
            {
                memoryInK = totalMemory / 1048576;
                MessageBox.Show("You only have " + memoryInK.ToString() + " Mb of memory which is not enough to run this\n" +
                    "program successfully.  Please contact support@pragersoftware.com \nfor instructions.", "Prager Inventory Program", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                //traceSource.TraceInformation("-->Critical - memory: " + memoryInK.ToString());
                //traceSource.Flush();
                Application.Exit();  //  cancel program
            }

            //  get machine serial number
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            //string MACAddress = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (MACAddress == String.Empty)  // only return MAC Address from first card
                {
                    if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }
            MACAddress = MACAddress.Replace(":", "");
            fTrace("I - MAC Address: " + MACAddress);

        }

    
        //----------------------------------------------------------    allow user to send trace data    ----------------------------------------
        private void fTrace(string str)
        {
            trace.Add(str);
        }
    
    }




    ////----------------    converts 10-digit ISBN to 13-digit ISBN
    //public class ConvertISBN
    //{
    //    public ConvertISBN()
    //    {
    //    }

    //    public string convertToISBN13(string ISBN10)
    //    {
    //        string workingISBN = "978" + ISBN10.Substring(0, 9);
    //        char[] ISBNdigit = workingISBN.ToCharArray();
    //        int weightedValues = int.Parse(ISBNdigit[0].ToString()) + int.Parse(ISBNdigit[1].ToString()) * 3 +
    //            int.Parse(ISBNdigit[2].ToString()) + int.Parse(ISBNdigit[3].ToString()) * 3 +
    //            int.Parse(ISBNdigit[4].ToString()) + int.Parse(ISBNdigit[5].ToString()) * 3 +
    //            int.Parse(ISBNdigit[6].ToString()) + int.Parse(ISBNdigit[7].ToString()) * 3 +
    //            int.Parse(ISBNdigit[8].ToString()) + int.Parse(ISBNdigit[9].ToString()) * 3 +
    //            int.Parse(ISBNdigit[10].ToString()) + int.Parse(ISBNdigit[11].ToString()) * 3;
    //        int remainder, checkDigit;
    //        Math.DivRem(weightedValues, 10, out remainder);
    //        if (remainder != 0)
    //            checkDigit = 10 - remainder;
    //        else
    //            checkDigit = 0;

    //        return workingISBN + checkDigit.ToString();
    //    }

    //    //  9780735606043  (converted check digit s/b 8)
    //    public string convertToISBN10(string ISBN13)
    //    {
    //        string workingISBN = ISBN13.Substring(3, 9);  //  receives a 13-digit ISBN
    //        char[] ISBNdigit = workingISBN.ToCharArray();

    //        int weightedValues = int.Parse(ISBNdigit[0].ToString()) * 10 + int.Parse(ISBNdigit[1].ToString()) * 9 +
    //            int.Parse(ISBNdigit[2].ToString()) * 8 + int.Parse(ISBNdigit[3].ToString()) * 7 +
    //            int.Parse(ISBNdigit[4].ToString()) * 6 + int.Parse(ISBNdigit[5].ToString()) * 5 +
    //            int.Parse(ISBNdigit[6].ToString()) * 4 + int.Parse(ISBNdigit[7].ToString()) * 3 +
    //            int.Parse(ISBNdigit[8].ToString()) * 2;

    //        int quotient = weightedValues / 11;
    //        int checkDigit = ((quotient + 1)) * 11 - weightedValues;

    //        if (checkDigit > 10)
    //            return workingISBN + "X";
    //        else
    //            return workingISBN + checkDigit.ToString();
    //    }
    //}


}