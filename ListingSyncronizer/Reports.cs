#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

#endregion

namespace ListingSyncronizer
{
    partial class mainForm : Form
    {

        public void generateInventoryReport(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            bOpenDialog_Click(sender, e);

            string book = "";
            string stat = "";
            string isbn = "";
            string title = "";
            string locn = "";

            System.IO.StreamReader sr = new System.IO.StreamReader(sFileName);  //  create stream reader object
            while ((inputRecord = sr.ReadLine()) != null)  //  read each record in the file
            {
                if (inputRecord != null)
                {
                    string firstFour = inputRecord.Substring(0, 4);  //  get the first 4 characters
                    switch (firstFour)
                    {
                        case "BOOS":  //  book start, clear out old stuff
                            book = "";
                            stat = "";
                            isbn = "";
                            title = "";
                            locn = "";
                            break;
                        case "BOOK":  //  get unique book number
                            book = inputRecord.Substring(5, inputRecord.Length - 5);
                            break;
                        case "STAT":  //  For Sale, Hold or Sold
                            stat = inputRecord.Substring(5, inputRecord.Length - 5);
                            break;
                        case "ISBN":  //  ISBN
                            isbn = inputRecord.Substring(5, inputRecord.Length - 5);
                            break;
                        case "TNAM":  //  title
                            title = inputRecord.Substring(5, inputRecord.Length - 5);
                            break;
                        case "LOCA":  //  location
                            locn = inputRecord.Substring(5, inputRecord.Length - 5);
                            break;
                        case "BOOE":
                            if (stat == "For Sale")
                            //{
                            //    BookData bookData = new BookData(locn, book, stat, isbn, title);  //  structure to hold data
                            //    inventoryArray.Add(bookData);
                            //}
                            break;
                        default:
                            break;
                    }  //  end switch

                }  //  end if
            }  //  end while

            inventoryArray.Sort();  //  now sort it...
            BookData data;


            for (int i = 0; i < inventoryArray.Count; i++)
            {
                data = (BookData)inventoryArray[i];

//                if (bd1.BookNbr == bd2.BookNbr && bd1.Status != bd2.Status)
            }


        }  //  end generateReports

    }  //  end Form1
}  //  end ListingSyncronizer