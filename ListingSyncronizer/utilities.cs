
using System;
using System.Collections;
using System.IO;
using System.Management;
using System.Security.Principal;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace ListingSyncronizer
{
    partial class mainForm : Form
    {

        static public ArrayList trace = new ArrayList();

        //----------------------------------------------------------------------    read the configuration file    -----------------------------------
        private int readConfigFile()
        {
            //bool pathFound = false;  //  indicator for FirebirdInstallationPath

            ////  find Inventory Program application path...
            //string configFilePath = @"c:\Prager";  // Application.StartupPath;
            //fTrace("I - configFilePath:  " + configFilePath);

            ////  see if it's there; otherwise ask where it is
            //FileInfo fi = new FileInfo(configFilePath + @"\Inv\Inventory.cfg");
            ////FileInfo fi = new FileInfo(@"c:\Prager\Inventory.cfg");  //  moved due to 2 program file folders
            //if (!fi.Exists)
            //{
            //    DialogResult dr = MessageBox.Show("Unable to locate Inventory program configuration file (Inventory.cfg)." +
            //        @"It should be in the C:\Prager sub-directory" +
            //         "\nClick OK to enter the location of the Inventory.cfg file", "Prager, Software",
            //         MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            //    if (dr == DialogResult.OK)
            //    {
            //        OpenFileDialog ofd = new OpenFileDialog();
            //        ofd.Filter = "configuration files (*.cfg)|*.cfg";
            //        if (ofd.ShowDialog() == DialogResult.OK)
            //            configFilePath = System.IO.Path.GetDirectoryName(ofd.FileName);
            //        else
            //            return -1;
            //    }
            //    else
            //        return -1;
            //}

            string applicationPath = Application.StartupPath;
            //applicationPath = @"C:\Program Files (x86)\Prager\Inv";  //  for TESTING ONLY!!
            //applicationPath = @"C:\Program Files\Prager\Inv";  //  for TESTING ONLY!!

            FileInfo newLoc = new FileInfo(@"C:\Prager\Inventory.cfg");
            if (!newLoc.Exists)  //  if the config file is NOT in the new directory...
            {
                //  look at the first possible application path...
                fTrace("I - applicationPath:  " + applicationPath);
                if (applicationPath.Contains("Program Files (x86)"))  //  on 64-bit machines
                {
                    FileInfo x86 = new FileInfo(applicationPath + @"\Inventory.cfg");
                    if (x86.Exists)  //  yep, it's here, so move it to new directory
                        x86.MoveTo(@"C:\Prager\Inventory.cfg");  //  move to new directory
                }
                else  //  application path is C:\Program Files\Prager\Inv (on 32-bit machines)
                {
                    FileInfo x64 = new FileInfo(applicationPath + @"\Inventory.cfg");
                    if (x64.Exists)  //  yep, it's here, so move it to new directory
                        x64.MoveTo(@"C:\Prager\Inventory.cfg");  //  move to new directory
                    else  //  it's missing (shouldn't happen!)
                    {
                        MessageBox.Show("Inventory.cfg file is missing - contact support@pragersoftware.com", "Prager, Software", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        systemCrash = true;
                        Application.Exit();
                    }
                }
            }

            XmlTextReader reader = new XmlTextReader(@"c:\Prager\Inventory.cfg");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "DatabasePath":
                            databasePath = reader.ReadElementContentAsString();
                            break;
                        default:
                            break;
                    }
                }
            }
            reader.Close();


            fTrace("I - Database Path: " + databasePath);
            fTrace("I - finished readConfigFile");
            return 0;
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
            else if (osName.Contains("Vista") || osName.Contains("Windows 7") == true)
            {
                WindowsIdentity id = WindowsIdentity.GetCurrent();
                WindowsPrincipal p = new WindowsPrincipal(id);

                if (!p.IsInRole("Administrators"))
                {
                    fTrace("W - Administrator role message displayed");
                    MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();
                    DialogResult dr =
                        dlg.Show(@"Software\Prager\Inventory Program\Vista",  //  registry entry
                        "DontShowAgain",  //  registry value name
                        DialogResult.OK,  //  default return value returned immediately if box is not shown
                        "Don't show this again",  //  message for checkbox
                        "To run this program under Windows Vista, you must either run as Administrator or disable UAC.\n" +
                        "For further information, please see the FAQs page at our website (click on the Support tab)",
                        "Prager, Software",  //  window title
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);  //  button and icon code
                }
            }


            //  if it's not Vista, check the service pack level of .NET v2.0
            if (!osName.Contains("Vista") && !osName.Contains("Windows 7"))
            {
                //  delete the old restoreKey stuff... (caused David's window to shrink on the right)
                using (RegistryKey restoreState = Registry.CurrentUser.OpenSubKey("SOFTWARE\\RestoreState\\RealPosition\\", true))
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


                //using (RegistryKey dotNET = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v2.0.50727", true))
                //{
                //    if ((int)dotNET.GetValue("SP", (int)-1) != 1)
                //    {
                //        fTrace("W - .NET Framework service pack (SP1) not installed");
                //        MsgBoxCheck.MessageBox dlg = new MsgBoxCheck.MessageBox();
                //        DialogResult dr =
                //        dlg.Show(@"Software\Prager\Inventory Program\dotNET",  //  registry entry
                //        "DontShowAgain",  //  registry value name
                //        DialogResult.OK,  //  default return value returned immediately if box is not shown
                //        "Don't show this again",  //  message for checkbox
                //       "The service pack (SP1) for .NET Framework v2.0 doesn't appear to be installed; contact support@pragersoftware.com if you need help",
                //        "Prager, Software",  //  window title
                //        MessageBoxButtons.OK, MessageBoxIcon.Warning);  //  button and icon code }
                //    }
                //}
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

            //  get screen size and see if they need to increase the resolution
            int width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            fTrace("I - screen resolution: (W x H): " + width.ToString() + " x " + height.ToString());
            if (width < 1024 && height < 960)
                MessageBox.Show("Your screen resolution is too low (" + width.ToString() + " X " + height.ToString() + ") to view the entire program window.  Please set it to something greater than 1024 x 768", "Prager, Software", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //----------------------------------------------------------    allow user to send trace data    ----------------------------------------
        private void fTrace(string str)
        {
            trace.Add(str);
        }

    }
}