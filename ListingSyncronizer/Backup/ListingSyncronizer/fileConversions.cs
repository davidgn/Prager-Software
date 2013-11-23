#region Using directives

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace ListingSyncronizer
{
    partial class Form1 : Form
    {


        //------------------------------------------------------------------------------------------
        int SKUIndexLS = -1;
        int statusIndexLS = -1;
        //int SKUIndexInv = -1;
        //int statusIndexInv = -1;

        public int formatInventoryFile(string sFileName)
        {
            //this.Cursor = Cursors.WaitCursor;
            
            string book = "";
            string stat = "";
            int i = 0;

            System.IO.StreamReader sr = new System.IO.StreamReader(sFileName);  //  create stream reader object
            while ((inputRecord = sr.ReadLine()) != null)  //  read each record in the file
            {
                if (inputRecord != null)
                {
                    if (rbHBInv.Checked == true)
                    {
                        string firstFour = inputRecord.Substring(0, 4);  //  get the first 4 characters
                        switch (firstFour)
                        {
                            case "BOOK":  //  get unique book number
                                book = inputRecord.Substring(5, inputRecord.Length - 5);
                                break;
                            case "STAT":  //  For Sale, Hold or Sold
                                stat = inputRecord.Substring(5, inputRecord.Length - 5);
                                break;
                            case "BOOE":
                                if (stat.Length == 0)
                                {
                                    if (rbMI4Sale.Checked == true)
                                        stat = "For Sale";
                                    else
                                        stat = "Sold";
                                }
                                BookData bookData = new BookData(book, stat);  //  structure to hold data
                                inventoryArray.Add(bookData);
                                i++;
                                break;
                            default:
                                break;
                        }  //  end switch
                    }
                    else if (rbUIEEInv.Checked == true)
                    {
                        string firstTwo = inputRecord.Substring(0, 2);  //  get the first 2 characters
                        switch (firstTwo)
                        {
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
                                inventoryArray.Add(bookData);
                                i++;
                                break;
                            default:
                                break;
                        }  //  end switch 
                    }
                    else if (rbTabInv.Checked == true)
                    {
                        string[] tmpArray = inputRecord.Split('\t');  // split into parts
                        
                        if(tmpArray[0].Contains("Book Number"))
                            continue;  //  get past header

                        if (tmpArray[0].Trim().Length == 0)  //  if there is no SKU, don't look any further
                            continue;
                        else
                            book = tmpArray[0];

                        if (tmpArray.GetUpperBound(0) > 20)
                            stat = tmpArray[20];
                            if (stat.Length == 0)
                                stat = "For Sale";

                        BookData bookData = new BookData(book, stat);  //  structure to hold data
                        inventoryArray.Add(bookData);
                        i++;
                    }
                    else
                    {
                        MessageBox.Show("You must indicate the file format", "Prager, Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }  //  end if
            }  //  end while

            lInRecsProcessed.Text = "Records Processed: " + i;
            if (inventoryArray.Count > 1)
                inventoryArray.Sort();  //  now sort it...

            //Cursor.Current = Cursors.Default;
            return 0;
        }


        //-------------------------------------------------------------------------------------------
        public int formatListingFile(string sFileName)
        {
            string book = "";
            string stat = "";
            int i = 0;

            //Cursor.Current = Cursors.WaitCursor;

            System.IO.StreamReader sr = new System.IO.StreamReader(sFileName);  //  create stream reader object

            while ((inputRecord = sr.ReadLine()) != null)  //  read each record in the file
            {
                if (inputRecord != null)
                {
                    if (rbHBLS.Checked == true)
                    {
                        string firstFour = inputRecord.Substring(0, 4);  //  get the first 4 characters
                        switch (firstFour)
                        {
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
                    else if (rbUIEELS.Checked == true)
                    {
                        string firstTwo = inputRecord.Substring(0, 2);  //  get the first 2 characters
                        switch (firstTwo)
                        {
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
                    else if (rbTabLS.Checked == true)
                    {
                        if (SKUIndexLS == -1)  //  if -1, we have not determined column descriptions
                        {
                            string[] tmp = inputRecord.Split('\t');  // split into parts
                            for (i = 0; i < tmp.Length; i++)
                                if (tbSKULS.Text.Contains(tmp[i]))
                                    SKUIndexLS = i;
                                else if (tbStatusLS.Text.Contains(tmp[i]))
                                    statusIndexLS = i;
                            continue;  //  get next record
                        }

                        string[] tmpArray = inputRecord.Split('\t');  // split into parts
                        if (tmpArray[SKUIndexLS].Trim().Length == 0)  //  if there is no SKU, don't look any further
                            continue;
                        else
                        book = tmpArray[SKUIndexLS];

                        if (statusIndexLS == -1)
                            stat = "For Sale";
                        else
                            stat = tmpArray[statusIndexLS];

                        BookData bookData = new BookData(book, stat);  //  structure to hold data
                        listingArray.Add(bookData);
                        i++;
                    }
                    else
                    {
                        MessageBox.Show("You must indicate the file format", "Prager, Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }

                }  //  end if
            }  //  end while

            lLSRecsProcessed.Text = "Records Processed: " + i;
            if (listingArray.Count > 1)
                listingArray.Sort();  //  now sort it...

            //Cursor.Current = Cursors.Default;
            return 0;
        }
    }
}
