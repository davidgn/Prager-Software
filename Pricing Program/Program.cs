#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

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
            string versionDate;

            if (AllProcesses.Length > 1)
            {
                MessageBox.Show(ThisProcess.ProcessName + " is already running", ThisProcess.ProcessName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Application.EnableVisualStyles();
                bool dontRunFlag = false;

                // Add the event handler for handling UI thread exceptions to the event.
                Application.ThreadException += new ThreadExceptionEventHandler(formISBNLookup.Form1_UIThreadException);

                // Add the event handler for handling non-UI thread exceptions to the event. 
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(formISBNLookup.CurrentDomain_UnhandledException);

                DateTime currentDate = DateTime.Now;
                //DateTime currentDate = DateTime.Now.AddDays(182);  //  TESTING ONLY!

                if (formISBNLookup.programVersion.Contains("BETA"))  //  if it's a BETA, it's only good for 30 days...
                {
                    versionDate = formISBNLookup.compileDate.AddDays(30).ToString();
                    //else
                    //    versionDate = formISBNLookup.compileDate.AddMonths(12).ToString();  //  version is only good for 6 months

                    int rc = currentDate.CompareTo(Convert.ToDateTime(versionDate, formISBNLookup.localCulture));
                    if (rc == 1)
                    {
                        MessageBox.Show("This BETA version is obsolete.  Click OK\rto Download the latest version.",
                            "Prager Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        System.Diagnostics.Process.Start("http://www.pragersoftware.com/clickCounter/count.php?http://www.pragersoftware.com/downloads/PragerPricingSetup.exe");
                        dontRunFlag = true;
                    }
                }

                else if (dontRunFlag == false)
                    Application.Run(new formISBNLookup());
                else
                    Application.Exit();
            }
        }
    }
}