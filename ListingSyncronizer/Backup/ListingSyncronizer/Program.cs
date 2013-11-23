#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
#endregion

namespace ListingSyncronizer
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

                string versionDate = "";
                IFormatProvider localCulture = System.Globalization.CultureInfo.CurrentCulture;

                //AtomicTime at = new AtomicTime();  //  returns correct date
                //DateTime currentDate = DateTime.Parse(at.getAtomicTime());
                DateTime currentDate = DateTime.Now;

                if (Form1.versionNumber.Contains("BETA"))  //  if it's a BETA, it's only good for 30 days...
                    versionDate = Form1.compileDate.AddDays(30).ToString();
                else
                    versionDate = Form1.compileDate.AddMonths(6).ToString();  //  only good for 6 months

                //currentDate = currentDate.AddDays(31);  //  for testing only!
                //versionDate = "01/30/2006 12:00:00 PM";  //  for testing only!

                int rc = currentDate.CompareTo(Convert.ToDateTime(versionDate, localCulture));
                if (rc == 1)
                {
                    MessageBox.Show("This version is obsolete.  We suggest you go to our web \nsite now and download the latest version.",
                        "Prager Listing Synchronizer Program", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    System.Diagnostics.Process.Start("http://www.pragersoftware.com/downloads.aspx");

                }
                else
                    Application.Run(new Form1());
            }
        }
    }
}