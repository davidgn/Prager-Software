#define COMPILED4OTHERS

using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;


namespace ListingSyncronizer
{
    partial class mainForm : Form
    {


        //------------------------------------------------------------------------------------------
        int SKUIndex = -1;
        int statusIndex = -1;

        private int createInventoryArray() {

            this.Text = "Prager Listing Synchronizer Program    Version " + versionNumber;

#if COMPILED4OTHERS
            string dataBaseName = "dbBooks";
#else
            string dataBaseName = "dbPrager";
#endif

            int i = 0;  //  record count
            int j = 0;  //  sold count
            string selectString = "SELECT BookNbr, Stat from tBooks";

            FbConnection bookConn = new FbConnection("User=prager;Password=books;Database=" + databasePath + dataBaseName + ".fdb");
            FbDataReader dr = null;
            bookConn.Open();
            FbCommand cmd = new FbCommand(selectString, bookConn);
            dr = cmd.ExecuteReader();
            while (dr.Read()) {
                BookData bookData = new BookData((string)dr[0], (string)dr[1]);
                inventoryArray.Add(bookData);
                i++;
                int status = 0;
                if (int.TryParse(bookData.Status, out status)) {
                    if (status == 0)
                        j++;
                }
                else {
                    if (bookData.Status.Equals("Sold"))
                        j++;
                }

            }

            dr.Close();
            bookConn.Close();

            lInRecsProcessed.Text = "Records Processed: " + i + "  (Sold: " + j + ")";
            if (inventoryArray.Count > 1)
                inventoryArray.Sort();  //  now sort it...
            return 0;
        }


        //-------------------------------------------------------------------------------------------
        public int formatVenueFile(string sFileName) {
            string book = "";
            string stat = "";
            int i = 0;
            StreamReader sr;

            if (File.Exists(sFileName)) {  //  check to see if file exists... of so, set permissions to allow sharing
                FileStream fileStr = File.Open(sFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                sr = new System.IO.StreamReader(fileStr);  //  create stream reader object
            }
            else {
                MessageBox.Show("The filename is either missing or invalid.", "Prager, Software",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (rbCSVLS.Checked != true && rbHBLS.Checked != true && rbTabLS.Checked != true && rbUIEELS.Checked != true
                 && rbAmazon.Checked != true) {
                MessageBox.Show("You have not indicated the format of the input file.", "Prager, Software",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (rbCSVLS.Checked == true || rbTabLS.Checked == true)
                if (lbSKU.SelectedIndex == -1 || lbStatus.SelectedIndex == -1) {
                    MessageBox.Show("You have not chosen the column names for either SKU or Book Status or both.",
                        "Prager, Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }

            if (rbCSVLS.Checked == true || rbTabLS.Checked == true)
                sr.ReadLine();  //  skip the first record which contains the column headings

            while ((inputRecord = sr.ReadLine()) != null)  //  read each record in the file
            {
                if (inputRecord != null && inputRecord.Length != 0) {
                    if (rbHBLS.Checked == true)  //--    HomeBase format
                    {
                        string firstFour = inputRecord.Substring(0, 4);  //  get the first 4 characters
                        switch (firstFour) {
                            case "BOOK":  //  get unique book number
                                book = inputRecord.Substring(5, inputRecord.Length - 5);
                                break;
                            case "STAT":  //  For Sale, Hold or Sold
                                stat = inputRecord.Substring(5, inputRecord.Length - 5);
                                break;
                            case "BOOE":
                                if (stat.Length == 0)
                                    stat = "For Sale";
                                BookData bookData = new BookData(book, stat);  //  structure to hold data
                                listingArray.Add(bookData);
                                i++;
                                break;
                            default:
                                break;
                        }  //  end switch
                    }
                    else if (rbUIEELS.Checked == true)  //--   UIEE format
                    {
                        string firstTwo = inputRecord.Substring(0, 2);  //  get the first 2 characters
                        switch (firstTwo) {
                            case "CI":  //  get unique book number (SKU)
                            case "UR":
                                book = inputRecord.Substring(3, inputRecord.Length - 3);
                                break;
                            case "IS":  //  For Sale, Hold or Sold
                                stat = inputRecord.Substring(3, inputRecord.Length - 3);
                                break;
                            case "\r\n":  //  CR-LF indicates end of record
                            case "\r\n\r\n":
                                if (stat.Length == 0)
                                    stat = "For Sale";
                                BookData bookData = new BookData(book, stat);  //  structure to hold data
                                listingArray.Add(bookData);
                                i++;
                                break;
                            default:
                                break;
                        }  //  end switch 
                    }
                    else if (rbTabLS.Checked == true)  //--    tab-delimited file format
                    {
                        string[] tmpArray = inputRecord.Split('\t');  // split into parts
                        if (tmpArray[SKUIndex].Trim().Length == 0)  //  if there is no SKU, don't look any further
                            continue;
                        else
                            book = tmpArray[SKUIndex];  //  save the SKU

                        //if (statusIndex == -1)  //  <--------------------???????????  TODO
                        //    stat = "For Sale";
                        //else
                        stat = int.Parse(tmpArray[statusIndex]) > 0 ? "For Sale" : "Sold";

                        BookData bookData = new BookData(book, stat);  //  structure to hold data
                        listingArray.Add(bookData);
                        i++;
                    }
                    else if (rbAmazon.Checked == true)  //--    Amazon tab-delimited file format
                    {
                        string[] tmpArray = inputRecord.Split('\t');  // split into parts
                        if (tmpArray[SKUIndex].Trim().Length == 0 || tmpArray[0] == "item-name")  //  if there is no SKU, don't look any further
                            continue;
                        else
                            book = tmpArray[SKUIndex];  //  save the SKU

                        stat = "For Sale";

                        BookData bookData = new BookData(book, stat);  //  structure to hold data
                        listingArray.Add(bookData);
                        i++;
                    }
                    else if (rbCSVLS.Checked == true)  //--    CSV file format
                    {
                        string pattern = @"(?<!"")""(?!"").*?(?<!"")""(?!"")|(?<=^|,)[^,]*?(?=,|$)";
                        ArrayList results = new ArrayList();

                        Regex re = new Regex(pattern);
                        MatchCollection mc = re.Matches(inputRecord);
                        for (int nn = 0; nn < mc.Count; nn++)
                            results.Add(mc[nn].Value);  //  add parts to array

                        if (results[SKUIndex].ToString().Trim().Length == 0)  //  if there is no SKU, don't look any further
                            continue;
                        else
                            book = (string)results[SKUIndex];

                        if (IsNumeric(results[statusIndex]))
                            stat = int.Parse((string)results[statusIndex]) > 0 ? "For Sale" : "Sold";
                        else
                            stat = (string)results[statusIndex].ToString().Replace('\"', ' ').Trim();

                        BookData bookData = new BookData(book, stat);  //  structure to hold data
                        listingArray.Add(bookData);
                        i++;
                    }
                }
            }

            lLSRecsProcessed.Text = "Records Processed: " + i;
            if (listingArray.Count > 1)
                listingArray.Sort();  //  now sort it...
            return 0;
        }


        //--    performs numeric test
        public static bool IsNumeric(object value) {
            Double d = 0;
            return Double.TryParse(value.ToString(), out d);
        }

    }
}
