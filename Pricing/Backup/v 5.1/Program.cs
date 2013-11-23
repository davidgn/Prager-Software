#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

#endregion

namespace Prager_Pricing_Program
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process ThisProcess = Process.GetCurrentProcess();
            Process[] AllProcesses = Process.GetProcessesByName(ThisProcess.ProcessName);
            if (AllProcesses.Length > 1)
            {
                MessageBox.Show(ThisProcess.ProcessName + " is already running", ThisProcess.ProcessName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Application.EnableVisualStyles();
                // string compileDate = "01/30/2006 12:00:00 PM";  //  for testing only!
                string compileDate = "12/31/2007 12:00:00 PM";  //  version is only good until...

                int rc = DateTime.Now.CompareTo(Convert.ToDateTime(compileDate));
                if (rc == 1)
                {
                    MessageBox.Show("This version is obsolete.  Click OK\rto Download the latest version.",
                        "Prager Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    System.Diagnostics.Process.Start("http://www.pragersoftware.com/downloads");

                }
                else
                    Application.Run(new formISBNLookup());

            }

        }
    }
}