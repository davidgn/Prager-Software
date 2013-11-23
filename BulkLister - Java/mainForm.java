package BulkAddBooks;

import javax.swing.*;
import FirebirdSql.Data.FirebirdClient.*;

public class mainForm extends Form
{
	private String SKU = "";
	private String Author = "";
	private String Binding = "";
	private String Edition = "";
	private String Pages = "";
	private String PubDate = "";
	private String Publisher = "";
	private String Title = "";
	private String DateAdded = "";
	private String DateUpdated = "";

	public static String backupPath;
	public static String imagePath;
	public static String exportPath;
	public static String daysRetention;
	public static String databasePath;
	public static String firebirdInstallationPath;
	public static String dataBaseName = "dbBooks";

	private FbConnection bookConn = new FbConnection();

	private static IFormatProvider localCulture = System.Globalization.CultureInfo.CurrentCulture; // get current culture
	public static java.util.Date compileDate = java.util.Date.Parse("30 Jan 2010 11:25 AM", localCulture);
	public static String versionNumber = "1.1.0 " + String.format("%d", compileDate);
	//public static string versionNumber = "1.0.2 BETA " + compileDate.ToString("dd-MMM-yyyy");


	//  my Amazon.com access key:  084BT0EPNB27A07DGR82
	//  my Amazon.com Secret Key:  Gk0QGlcORtiSZQxqGiifKyiarqmyf9jcS1U/5Eyw
	private String AWSKey = "084BT0EPNB27A07DGR82";
	private String AWSSecretKey = "Gk0QGlcORtiSZQxqGiifKyiarqmyf9jcS1U/5Eyw";

//        
//         *
//         ------    Cumulative changes    ----------------
//         
//         -  changed:  location of executables (now in separate sub-directory) (v1.1.0)
//         -  changed:  now uses Inventory program Inventory.cfg file  (v1.1.0)
//         * 
//         * 
//         * 

	//------------------------------------------------------    Initialization routines    ------------------------------------------------
	public mainForm()
	{
		InitializeComponent();

		dgvDataEntry.ColumnHeadersBorderStyle = getProperColumnHeadersBorderStyle();
		this.setText("Prager Bulk Book Loader     Version " + versionNumber);

		int rc = readConfigFile();
		if (rc == -1)
		{
			Application.Exit();
		}

		//  check to see if database is there...
		String dbPath = databasePath + dataBaseName + ".fdb";
		fTrace("I - dbPath: " + dbPath); //<------------ nETVISTA-8311:c:\Prager\ (change first : to a \\)

		FileInfo fi;
		if (dbPath.indexOf(':') == dbPath.lastIndexOf(':'))
		{
			fi = new FileInfo(dbPath);
		}
		else
		{
			int i = dbPath.indexOf(':');
			String filePath = "\\\\" + dbPath.substring(0, i) + "\\";
			//filePath += dbPath.Substring(i + 1, dbPath.Length - i - 1);
			filePath += dbPath.substring(i + 3, i + 3 + dbPath.length() - i - 3);
			fi = new FileInfo(filePath);
		}
		if (!fi.Exists) // if the database is missing, stop...
		{
			fTrace("E - database is missing");
			JOptionPane.showConfirmDialog(null, "The database is missing; notify support@pragersoftware.com for help", "Prager, Software", JOptionPane.DEFAULT_OPTION, JOptionPane.PLAIN_MESSAGE);
			Application.Exit();
			return;
		}

		bookConn = new FbConnection("User=prager;Password=books;Database=" + dbPath);

	}


	//---------------------------------------    main routine    ----------------------------------------------
	private void bStart_Click(Object sender, EventArgs e)
	{
		dgvDataEntry.ReadOnly = true; // mark dgv as read only now...
		lDone.setVisible(false);
		String sku = "";

		//  now loop through the rows in the dgv
		for (DataGridViewRow r : dgvDataEntry.Rows)
		{
			if (r.IsNewRow == true) // end of rows?
			{
				break; // yep, we're done
			}

			if (r.Cells[1].getValue() == null && !cbAutomaticSKU.Checked) // no SKU was provided
			{
				JOptionPane.showConfirmDialog(null, "You must either provide a SKU or check the box for automatic SKU numbering", "Prager, Software", JOptionPane.DEFAULT_OPTION, JOptionPane.ERROR_MESSAGE);
				return;
			}

			InvokeItemSearch(r.Cells[0].getValue().toString(), AWSKey, AWSSecretKey); // get the book info from Amazon.com

			if (r.Cells[1].getValue() == null) // did the user supply a SKU?
			{
				sku = ""; // no...
			}
			else
			{
				sku = r.Cells[1].getValue().toString(); // yes, save it...
			}

			tBooksAddBook(r.Cells[0].getValue().toString(), sku); // add it to the database, passing possible SKU

			r.Cells[1].setValue(SKU); // display the SKU
		}

		lDone.setVisible(true);
	}



	//----------------------------------    find the book data using Amazon.com    ------------------------------------
	private boolean InvokeItemSearch(String ISBN, String AWSKey, String AWSSecretKey)
	{
		Cursor.Current = Cursors.WaitCursor;

		//string DestinationPath = mainForm.backupPath.Replace("Backup", "ImageFiles");
		String idType = "";

		idType = "ISBN&SearchIndex=Books";
		String requestString = "Service=AWSECommerceService&Version=2009-03-31&Operation=ItemLookup" + "&ItemId=" + ISBN + "&IdType=" + idType + "&Condition=New&OfferPage=1" + "&MerchantId=All&ResponseGroup=Medium";

		SignedRequestHelper helper = new SignedRequestHelper(AWSKey, AWSSecretKey, "ecs.amazonaws.com");
		String requestURL = helper.Sign(requestString);
		WebRequest request = HttpWebRequest.Create(requestURL);


		request.Timeout = 30000; // 30 seconds
		System.Net.ServicePointManager.MaxServicePointIdleTime = 10000; // needed for bug in.NET 2.0

		// get the response object
		HttpWebResponse response = (HttpWebResponse)request.GetResponse();


		// to read the contents of the file, get the ResponseStream
		StreamReader sr = null;
		try
		{
			sr = new StreamReader(response.GetResponseStream());
		}
		catch (RuntimeException ex)
		{
			if (ex.getMessage().Contains("unable to connect to the remote server"))
			{
				JOptionPane.showConfirmDialog(null, "Amazon.com appears to be busy; please try again", "Prager, Software", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
				return false;
			}
		}

		// Create an insntance of XmlTextReader and call Read method to read the file
		XmlTextReader textReader = new XmlTextReader(sr);
		textReader.Read();

		// If the node has value
		textReader.MoveToAttribute("ItemLookupRequest");
		while (textReader.Read())
		{
			if (textReader.NodeType == XmlNodeType.Element && textReader.NodeType != XmlNodeType.EndElement)
			{
//C# TO JAVA CONVERTER NOTE: The following 'switch' operated on a string member and was converted to Java 'if-else' logic:
//				switch (textReader.LocalName)
//ORIGINAL LINE: case "Author":
				if (textReader.LocalName.equals("Author"))
				{
						textReader.Read(); // get value
						Author = textReader.getValue().getLength() > 75 ? textReader.getValue().substring(0, 75) : textReader.getValue();
				}
//ORIGINAL LINE: case "Binding":
				else if (textReader.LocalName.equals("Binding"))
				{
						textReader.Read(); // get value
						Binding = textReader.getValue();
				}
//ORIGINAL LINE: case "Edition":
				else if (textReader.LocalName.equals("Edition"))
				{
						textReader.Read(); // get value
						Edition = textReader.getValue().getLength() > 15 ? textReader.getValue().substring(0, 15) : textReader.getValue();
				}
//ORIGINAL LINE: case "NumberOfPages":
				else if (textReader.LocalName.equals("NumberOfPages"))
				{
						textReader.Read(); // get value
						Pages = textReader.getValue().toString();
				}
//ORIGINAL LINE: case "PublicationDate":
				else if (textReader.LocalName.equals("PublicationDate"))
				{
						textReader.Read(); // get value
						String[] splitFields = textReader.getValue().split("[-]", -1);
						PubDate = splitFields[0]; // just take the year
				}
//ORIGINAL LINE: case "Publisher":
				else if (textReader.LocalName.equals("Publisher"))
				{
						textReader.Read(); // get value
						Publisher = textReader.getValue().getLength() > 85 ? textReader.getValue().substring(0, 85) : textReader.getValue();
				}
//ORIGINAL LINE: case "Title":
				else if (textReader.LocalName.equals("Title"))
				{
						textReader.Read(); // get value
						Title = textReader.getValue().getLength() > 100 ? textReader.getValue().substring(0, 100) : textReader.getValue();
						Title = Title.replace("'", "''");
				}
				else
				{
				}
			}

		}
		return true;
	}


	//---------------------------------------------------------    add a book to the table  (called from the import routines)    ----------------------------------------
	private int tBooksAddBook(String ISBN, String possibleSKU)
	{

		//if (BookNumber == "")   <-------------------------------------------TODO
		//{
		//    if (cbAutomaticSKU.Checked == true)  //  if we are doing auto-numbering...
		//    {
		//        long lastKey = findHighestBookNbr();
		//        lastKey++;
		//        BookNumber = lastKey.ToString();
		//    }
		//}


		DateAdded = new java.util.Date().ToString("yyyy-MM-dd HH:mm:ss");
		DateUpdated = DateAdded; // indicates book was just added
		String Condn = "";

		CultureInfo ci = CultureInfo.CurrentCulture;
		NumberFormatInfo nfi = ci.NumberFormat;
		//decimal decPrice = decimal.Parse(Price, nfi);

		//if (Binding.ToLower().Contains("paperback"))
		// Jacket.SelectedIndex = 8;  // none as issued 

		if (cbAutomaticSKU.Checked)
		{
			long sku = findHighestBookNbr(); // get next book number
			sku++;
			SKU = (new Long(sku)).toString(); // convert it...
		}
		else // use user provided SKU
		{
			SKU = possibleSKU;
		}

		String insertString = "insert into tBooks (BookNbr, Title, Author, ISBN, Locn, Pub, PubYear, Bndg, Condn, Ed, DateA, DateU, TranC, Stat, NbrOfPages, Price)" + " values ('" + SKU + "', '" + Title + "', '" + Author + "', '" + ISBN + "', '" + "" + "', '" + Publisher + "', '" + PubDate + "', '" + Binding + "', '" + Condn + "', '" + Edition + "', '" + DateAdded + "', '" + DateUpdated + "', '" + "A" + "', '" + "Pending" + "', '" + Pages + "', '" + 0.00 + "')";

		FbCommand cmd = new FbCommand(insertString, bookConn);
		try
		{
			if (bookConn.getState() == ConnectionState.Closed)
			{
				bookConn.Open();
			}

			cmd.ExecuteNonQuery();
		}

		catch (FbException ex)
		{
			JOptionPane.showConfirmDialog(null, "exception: " + ex.getMessage());
			if (ex.getMessage().getLength() > 36)
			{
				//if ((rbRejectRecord.Checked == true && addButtonClicked == false) && ex.Message.Substring(0, 40) == "String or binary data would be truncated")
				//{
				//    lbRejectedRecords.Items.Add(BookNumber + ": Data too long");
				//    lbRejectedRecords.Refresh();
				//    lRecordsRejected.Text = "Records rejected: " + ++rejectedCount;
				//    lRecordsRejected.Refresh();
				//    return -1;
				//}

				//if (ex.Message.Substring(0, 42).ToLower().Contains("arithmetic exception, numeric overflow,"))
				//{
				//    lbRejectedRecords.Items.Add(BookNumber + ": invalid numeric field");
				//    lbRejectedRecords.Refresh();

				//    lRecordsRejected.Text = "Records rejected: " + ++rejectedCount;
				//    lRecordsRejected.Refresh();

				return -1;
			}
			else // reject the book
			{
				if (ex.getMessage().substring(0, 34).Contains("violation of PRIMARY or UNIQUE KEY"))
				{
					JOptionPane.showConfirmDialog(null, "Error: duplicate SKU (" + SKU + "); check Automatic SKU numbering to resolve this automatically.", "Prager, Software", JOptionPane.DEFAULT_OPTION, JOptionPane.ERROR_MESSAGE);
				}
				else
				{
					JOptionPane.showConfirmDialog(null, "Error: adding book (" + SKU + ") - " + ex.getMessage(), "Prager, Software", JOptionPane.DEFAULT_OPTION, JOptionPane.ERROR_MESSAGE);
				}

				return -2; // duplicate SKU
			}
		} // end Catch

		cmd.dispose();
		return 0;

	} // end - tBooksAddBook


	//-----------------------------------------------------------------------    find highest book number    ----------------------------------------------------------
	public final long findHighestBookNbr()
	{

		//  get all of the book numbers and place them in an array
		java.util.ArrayList al = new java.util.ArrayList();
		String selectString = "select BookNbr from tBooks";

		FbDataReader rdr = null;
		if (bookConn.getState() == ConnectionState.Closed)
		{
			bookConn.Open();
		}
		FbCommand cmd = new FbCommand(selectString, bookConn);
		rdr = cmd.ExecuteReader();

		while (rdr.Read())
		{
			if (IsNumeric(rdr.getItem(0)))
			{
				al.add(Long.parseLong((String)rdr.getItem(0)));
			}
		}

		if (al.isEmpty() && cbAutomaticSKU.Checked == true) // if first time and they forgot to put in a starting SKU
		{
			return 0;
		}

		//  now find the highest numeric BookNbr in the array and return it as int64
		al.Sort();
		long debugInt = (long)al.get(al.size() - 1);
		cmd.dispose();

		return (long)al.get(al.size() - 1);

	}



	//-----------------------------------------------------------------------    test to see if an object is numeric    --------------------------------------------
	public static boolean IsNumeric(Object value)
	{
		System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();

		try
		{
			double d = Double.parseDouble(value.toString(), nfi);
			return true;
		}
		catch (FormatException e)
		{
			return false;
		}

	}

	private void bClear_Click(Object sender, EventArgs e)
	{
		dgvDataEntry.ReadOnly = false; // mark dgv as read only now...
		lDone.setVisible(false);
		String sku = "";

		//  now loop through the rows in the dgv
		for (DataGridViewRow r : dgvDataEntry.Rows)
		{
			r.Cells[0].setValue(null);
			r.Cells[1].setValue(null);
		}
	}



	/** 
	 Required designer variable.
	 
	*/
	private System.ComponentModel.IContainer components = null;

	/** 
	 Clean up any resources being used.
	 
	 @param disposing true if managed resources should be disposed; otherwise, false.
	*/
	@Override
	protected void dispose(boolean disposing)
	{
		if (disposing && (components != null))
		{
			components.dispose();
		}
		super.dispose(disposing);
	}


	/** 
	 Required method for Designer support - do not modify
	 the contents of this method with the code editor.
	 
	*/
	private void InitializeComponent()
	{
		this.dgvDataEntry = new System.Windows.Forms.DataGridView();
		this.cISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.cSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.bStart = new System.Windows.Forms.Button();
		this.cbAutomaticSKU = new System.Windows.Forms.CheckBox();
		this.lDone = new System.Windows.Forms.Label();
		this.bClear = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)(this.dgvDataEntry)).BeginInit();
		this.SuspendLayout();
		// 
		// dgvDataEntry
		// 
		this.dgvDataEntry.BackgroundColor = System.Drawing.SystemColors.Window;
		this.dgvDataEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgvDataEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.cISBN, this.cSKU});
		this.dgvDataEntry.setLocation(new System.Drawing.Point(21, 22));
		this.dgvDataEntry.setName("dgvDataEntry");
		this.dgvDataEntry.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.dgvDataEntry.Size = new System.Drawing.Size(264, 579);
		this.dgvDataEntry.TabIndex = 0;
		// 
		// cISBN
		// 
		this.cISBN.HeaderText = "ISBN";
		this.cISBN.MaxInputLength = 13;
		this.cISBN.setName("cISBN");
		// 
		// cSKU
		// 
		this.cSKU.HeaderText = "SKU";
		this.cSKU.MaxInputLength = 15;
		this.cSKU.setName("cSKU");
		// 
		// bStart
		// 
		this.bStart.setLocation(new System.Drawing.Point(309, 154));
		this.bStart.setName("bStart");
		this.bStart.Size = new System.Drawing.Size(75, 23);
		this.bStart.TabIndex = 1;
		this.bStart.setText("Start");
		this.bStart.UseVisualStyleBackColor = true;
//C# TO JAVA CONVERTER TODO TASK: Java has no equivalent to C#-style event wireups:
		this.bStart.Click += new System.EventHandler(this.bStart_Click);
		// 
		// cbAutomaticSKU
		// 
		this.cbAutomaticSKU.AutoSize = true;
		this.cbAutomaticSKU.setLocation(new System.Drawing.Point(309, 51));
		this.cbAutomaticSKU.setName("cbAutomaticSKU");
		this.cbAutomaticSKU.Size = new System.Drawing.Size(171, 17);
		this.cbAutomaticSKU.TabIndex = 2;
		this.cbAutomaticSKU.setText("Use automatic SKU numbering");
		this.cbAutomaticSKU.UseVisualStyleBackColor = true;
		// 
		// lDone
		// 
		this.lDone.AutoSize = true;
		this.lDone.setForeColor(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))));
		this.lDone.setLocation(new System.Drawing.Point(422, 161));
		this.lDone.setName("lDone");
		this.lDone.Size = new System.Drawing.Size(33, 13);
		this.lDone.TabIndex = 3;
		this.lDone.setText("Done");
		this.lDone.setVisible(false);
		// 
		// bClear
		// 
		this.bClear.setLocation(new System.Drawing.Point(309, 196));
		this.bClear.setName("bClear");
		this.bClear.Size = new System.Drawing.Size(75, 23);
		this.bClear.TabIndex = 4;
		this.bClear.setText("Clear");
		this.bClear.UseVisualStyleBackColor = true;
//C# TO JAVA CONVERTER TODO TASK: Java has no equivalent to C#-style event wireups:
		this.bClear.Click += new System.EventHandler(this.bClear_Click);
		// 
		// mainForm
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(495, 613);
		this.Controls.Add(this.bClear);
		this.Controls.Add(this.lDone);
		this.Controls.Add(this.cbAutomaticSKU);
		this.Controls.Add(this.bStart);
		this.Controls.Add(this.dgvDataEntry);
		this.setName("mainForm");
		this.setText("Prager Bulk Book Adder");
		((System.ComponentModel.ISupportInitialize)(this.dgvDataEntry)).EndInit();
		this.ResumeLayout(false);
		this.PerformLayout();

	}

	private System.Windows.Forms.DataGridView dgvDataEntry;
	private System.Windows.Forms.DataGridViewTextBoxColumn cISBN;
	private System.Windows.Forms.DataGridViewTextBoxColumn cSKU;
	private System.Windows.Forms.Button bStart;
	private System.Windows.Forms.CheckBox cbAutomaticSKU;
	private System.Windows.Forms.Label lDone;
	private System.Windows.Forms.Button bClear;



	//----------------------------------------------------------------------    read the configuration file    -----------------------------------
	private int readConfigFile()
	{
		//bool pathFound = false;  //  indicator for FirebirdInstallationPath

		//  find Inventory Program application path...
		String applicationPath = Application.StartupPath;
		fTrace("I - applicationPath:  " + applicationPath);

		//  see if it's there; otherwise ask where it is
		FileInfo fi = new FileInfo(applicationPath + "\\Inv\\Inventory.cfg");
		if (!fi.Exists)
		{
			int dr = JOptionPane.showConfirmDialog(null, "Unable to locate Inventory program configuration file (Inventory.cfg)." + "It should be in the C:\\Program Files\\Prager\\Inv sub-directory" + "\nClick OK to enter the location of the Inventory.cfg file", "Prager, Software", JOptionPane.OK_CANCEL_OPTION, JOptionPane.ERROR_MESSAGE);
			if (dr == JOptionPane.OK_OPTION)
			{
				OpenFileDialog ofd = new OpenFileDialog();
				ofd.Filter = "configuration files (*.cfg)|*.cfg";
				if (ofd.ShowDialog() == JOptionPane.OK_OPTION)
				{
					applicationPath = System.IO.Path.GetDirectoryName(ofd.FileName);
				}
				else
				{
					return -1;
				}
			}
			else
			{
				return -1;
			}
		}

		XmlTextReader reader = new XmlTextReader(applicationPath + "\\Inventory.cfg");
		while (reader.Read())
		{
			if (reader.NodeType == XmlNodeType.Element)
			{
//C# TO JAVA CONVERTER NOTE: The following 'switch' operated on a string member and was converted to Java 'if-else' logic:
//				switch (reader.LocalName)
//ORIGINAL LINE: case "DatabasePath":
				if (reader.LocalName.equals("DatabasePath"))
				{
						databasePath = reader.ReadElementContentAsString();
					//case "FirebirdInstallationPath":
					//    firebirdInstallationPath = reader.ReadElementContentAsString();
					//    fTrace("I - Firebird installation path: " + firebirdInstallationPath);
					//    //pathFound = true;
					//    break;
				}
				else
				{
				}
			}
		}
		reader.Close();

		//if (pathFound == false)
		//    MessageBox.Show("You need to modify Inventory.cfg file to indicate FIrebird installation path", "Prager Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Error);

		fTrace("I - Database Path: " + databasePath);
		fTrace("I - Backup Path: " + backupPath);
		fTrace("I - Export Path: " + exportPath);

		//if (databasePath == null || backupPath == null || exportPath == null || daysRetention == null ||
		//    databasePath.Length == 0 || backupPath.Length == 0 || exportPath.Length == 0 || daysRetention.Length == 0)
		//{
		//    fTrace("E - configuration file is invalid");
		//    MessageBox.Show("The configuration file is invalid; the Inventory program is \nunable to continue without major damage to the database!",
		//        "Prager Inventory Program", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		//    Application.Exit();
		//}
		fTrace("I - finished readConfigFile");
		return 0;
	}


	//---------------------------------    allow user to send trace data    ----------------------------------------
	private void fTrace(String str)
	{
		//trace.Add(str);
	}


	//-------------------------------------    used to change look of datagridview    ---------------------------------------------------
	private static DataGridViewHeaderBorderStyle getProperColumnHeadersBorderStyle()
	{
		return (SystemFonts.MessageBoxFont.getName().equals("Segoe UI")) ? DataGridViewHeaderBorderStyle.None : DataGridViewHeaderBorderStyle.Raised;
	}



}