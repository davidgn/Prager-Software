package BulkAddBooks;

import javax.swing.*;

public final class Program
{
	/** 
	 The main entry point for the application.
	 
	*/
//C# TO JAVA CONVERTER TODO TASK: Java annotations will not correspond to .NET attributes:
	//[STAThread]
	private static void main()
	{
		//Application.EnableVisualStyles();
		//Application.SetCompatibleTextRenderingDefault(false);
		//Application.Run(new Form1());
		boolean dontRun = false;

		Process ThisProcess = Process.GetCurrentProcess();
		Process[] AllProcesses = Process.GetProcessesByName(ThisProcess.ProcessName);
		if (AllProcesses.length > 1)
		{
			JOptionPane.showConfirmDialog(null, ThisProcess.ProcessName + " is already running", ThisProcess.ProcessName, JOptionPane.DEFAULT_OPTION, JOptionPane.ERROR_MESSAGE);
		}
		else
		{
			Application.EnableVisualStyles();

			String versionDate = "";
			IFormatProvider localCulture = System.Globalization.CultureInfo.CurrentCulture;

			AtomicTime at = new AtomicTime(); // returns correct date
			java.util.Date currentDate = java.util.Date.Parse(at.getAtomicTime(), localCulture);
			if (mainForm.versionNumber.contains("BETA")) // if it's a BETA, it's only good for 30 days...
			{
				versionDate = mainForm.compileDate.AddDays(30).toString();
				//else
				//    versionDate = mainForm.compileDate.AddMonths(6).ToString();  //  version is only good for 6 months
			   //  versionDate = "01/30/2006 12:00:00 PM";  //  for testing only!

				int rc = currentDate.compareTo(Convert.ToDateTime(versionDate, localCulture));
				if (rc == 1)
				{
					JOptionPane.showConfirmDialog(null, "This BETA version was only good for 30 days.  Go to our web site to download the latest release.", "Prager Inventory Program", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
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
			{
				Application.Exit();
			}
		}
	}
}