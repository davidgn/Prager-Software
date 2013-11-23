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

        public class BookData : IComparable
        {
            public string BookNbr;
            public string Status;
            public string ISBN;
            public string Location;
            public string Title;

            public BookData(string bookID, string status)  //  constructor
            {
                this.BookNbr = bookID;
                this.Status = status;
            }

            public BookData(string locn, string bookID, string status, string isbn, string title)
            {
                this.BookNbr = bookID;
                this.Status = status;
                this.ISBN = isbn;
                this.Location = locn;
                this.Title = title;
            }

            public int CompareTo(Object rhs)
            {
                BookData bd = (BookData)rhs;
                return this.BookNbr.CompareTo(bd.BookNbr);
                //    return this.Location.CompareTo(bd.Location);
            }

        }  //  end class BookData

        string inputRecord;

        public ArrayList inventoryArray = new ArrayList();  //  create an array to hold structures
        public ArrayList listingArray = new ArrayList();  //  create an array to hold structures





//------------------------------------------------------------------------------------------
        public void compareFiles()
        {
            BookData listingBooks;
            BookData inventoryBooks;
            bool found = false;

            //this.Cursor = Cursors.WaitCursor;

            //  check to see that Listing records exist in Inventory records
            for (int i = 0; i < listingArray.Count; i++)
            {
                listingBooks = (BookData)listingArray[i];
                found = false;
                for (int j = 0; j < inventoryArray.Count; j++)
                {
                    inventoryBooks = (BookData)inventoryArray[j];
                    if (listingBooks.BookNbr.ToString().Equals(inventoryBooks.BookNbr.ToString()))
                    {
                        found = true;
                        break;
                    }
                }

                if (found == false && listingBooks.Status.ToString().Equals("For Sale"))
                    listBox1.Items.Add(listingBooks.BookNbr + '\t' + "Not in inventory");
            }


            //  check to see that Inventory records exist in Listing records
            for (int i = 0; i < inventoryArray.Count; i++)
            {
                inventoryBooks = (BookData)inventoryArray[i];
                found = false;
                for (int j = 0; j < listingArray.Count; j++)
                {
                    listingBooks = (BookData)listingArray[j];
                    if (inventoryBooks.BookNbr.ToString().Equals(listingBooks.BookNbr.ToString())) //   found it!
                    {
                        if (!listingBooks.Status.ToString().Equals(inventoryBooks.Status.ToString()))
                        {
                            listBox1.Items.Add(listingBooks.BookNbr + '\t' + listingBooks.Status);
                            listBox2.Items.Add(inventoryBooks.BookNbr + '\t' + inventoryBooks.Status);
                        }
                        found = true;
                        break;
                    }
                }
                if (found == false && !inventoryBooks.Status.ToString().Equals("Sold"))
                    listBox2.Items.Add(inventoryBooks.BookNbr + '\t' + "Not on listing service");
            }

            //Cursor.Current = Cursors.Default;
        }


//---------------------------------------------------------------------------------------------

        
/*

1.  connect to internet
2.  submit search and parse results
3.  if found, get next ISBN
4.  if not found, are we at end of pages
        no, loop until end of pages
5.  if still not found, add to listing
6.  loop until done with all ISBN's

@"http://www.alibris.com" + 
@"/search/search.cfm?chunk=25&mtype=&qisbn=0760702411&S=R&matches=29&browse=0&qsort=r&page=2"

*/

    }      //  end Form1
}  //  end Namespace