#region Using directives
//#define NO_EMAIL 

using System;
using System.Diagnostics;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;


#endregion

namespace Prager_Book_Inventory
{
    static class Prager
    {
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        [STAThread]
        static void Main() {
            bool dontRun = false;

            Process ThisProcess = Process.GetCurrentProcess();
            Process[] AllProcesses = Process.GetProcessesByName(ThisProcess.ProcessName);

            if (AllProcesses.Length > 1)
                MessageBox.Show(ThisProcess.ProcessName + " is already running", ThisProcess.ProcessName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                Application.EnableVisualStyles();

                string versionDate = "";
                IFormatProvider localCulture = System.Globalization.CultureInfo.CurrentCulture;

                AtomicTime at = new AtomicTime();  //  returns correct date
                DateTime currentDate = DateTime.Parse(at.getAtomicTime(), localCulture);

                if (mainForm.versionNumber.Contains("BETA"))  //  if it's a BETA, it's only good for 15 days...
                    versionDate = mainForm.compileDate.AddDays(15).ToString();
                else
                    versionDate = mainForm.compileDate.AddMonths(6).ToString();  //  version is only good for 6 months
                //versionDate = "01/30/2006 12:00:00 PM";  //  for testing only!

                int rc = currentDate.CompareTo(Convert.ToDateTime(versionDate, localCulture));

                if (rc == 1 && mainForm.versionNumber.Contains("BETA")) {   //  instance is later, therefore pgm is obsolete
                    MessageBox.Show("This BETA version was only good for 15 days.  Go to our web site to download the latest release.",
                        "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start("http://www.pragersoftware.com/downloads.htm");
                    dontRun = true;
                }
                else if (rc == 1) {
                    MessageBox.Show("This version is obsolete and has been replaced by a newer version.  Go to our web site to download the latest release.",
                        "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start("http://www.pragersoftware.com/downloads.htm");
                    dontRun = true;
                }
            }

            if (dontRun == false) {
                // Add the event handler for handling UI thread exceptions to the event.
                Application.ThreadException += new ThreadExceptionEventHandler(Form1_UIThreadException);

                // Add the event handler for handling non-UI thread exceptions to the event. 
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                Application.Run(new mainForm());
            }
            else
                Application.Exit();
        }

        //--    handler for thread exception
        internal static void Form1_UIThreadException(object sender, ThreadExceptionEventArgs t) {
            string maskedTextValue = Repository.maskedTxtBoxValue;
            mainForm.ShowThreadExceptionDialog("B(1) - thread exception", t.Exception, maskedTextValue);
        }

        //--    handler for unhandled exceptions
        internal static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            string maskedTextValue = Repository.maskedTxtBoxValue;
            Exception ex = (Exception)e.ExceptionObject;
            mainForm.ShowThreadExceptionDialog("B(2) - thread exception", ex, maskedTextValue);
        }
    }

    //--  class to hold last ISBN
    public static class Repository
    {  //the repository class
        public static string maskedTxtBoxValue;
    }


}
