using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BulkAddBooks
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            bool dontRun = false;

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

                AtomicTime at = new AtomicTime();  //  returns correct date
                DateTime currentDate = DateTime.Parse(at.getAtomicTime(), localCulture);
                if (mainForm.versionNumber.Contains("BETA"))  //  if it's a BETA, it's only good for 30 days...
                {
                    versionDate = mainForm.compileDate.AddDays(30).ToString();
                    //else
                    //    versionDate = mainForm.compileDate.AddMonths(6).ToString();  //  version is only good for 6 months
                   //  versionDate = "01/30/2006 12:00:00 PM";  //  for testing only!

                    int rc = currentDate.CompareTo(Convert.ToDateTime(versionDate, localCulture));
                    if (rc == 1)
                    {
                        MessageBox.Show("This BETA version was only good for 30 days.  Go to our web site to download the latest release.",
                            "Prager Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start("http://www.pragersoftware.com/downloads.htm");
                        dontRun = true;
                    }
                }

                if (dontRun == false)
                {

                //    // Add the event handler for handling UI thread exceptions to the event.
                //    Application.ThreadException += new ThreadExceptionEventHandler(mainForm.Form1_UIThreadException);

                //    // Add the event handler for handling non-UI thread exceptions to the event. 
                //    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(mainForm.CurrentDomain_UnhandledException);

                    Application.Run(new mainForm());
                }
                else
                    Application.Exit();
            }
        }
    }
}