#region Using directives

using System;
using System.Diagnostics;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace ListingSyncronizer
{
    static class Program
    {
        // The main entry point for the application.
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
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
                bool dontRunFlag = false;
                string versionDate = "";

                // Add the event handler for handling UI thread exceptions to the event.
                Application.ThreadException += new ThreadExceptionEventHandler(mainForm.Form1_UIThreadException);

                // Add the event handler for handling non-UI thread exceptions to the event.
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(mainForm.CurrentDomain_UnhandledException);

                IFormatProvider localCulture = System.Globalization.CultureInfo.CurrentCulture;

                DateTime currentDate = DateTime.Now;
                //DateTime currentDate = DateTime.Now.AddDays(182);  //  TESTING ONLY!

                if (mainForm.versionNumber.Contains("BETA"))  //  if it's a BETA, it's only good for 30 days...
                {
                    versionDate = mainForm.compileDate.AddDays(30).ToString();
                    //else
                    //    versionDate = formISBNLookup.compileDate.AddMonths(12).ToString();  //  version is only good for 6 months

                    int rc = currentDate.CompareTo(Convert.ToDateTime(versionDate, localCulture));
                    if (rc == 1)
                    {
                        MessageBox.Show("This BETA version is obsolete.  Click OK\rto Download the latest version.",
                            "Prager Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        System.Diagnostics.Process.Start("http://www.pragersoftware.com/clickCounter/count.php?http://www.pragersoftware.com/downloads/PragerSynchroSetup.exe");
                        dontRunFlag = true;
                    }
                }

                if (dontRunFlag == false)
                    Application.Run(new mainForm());
                else
                    Application.Exit();
            }
        }
    }
}