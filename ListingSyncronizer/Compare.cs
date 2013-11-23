#region Using directives

using System;
using System.Collections;
using System.Windows.Forms;

#endregion

namespace ListingSyncronizer
{
    partial class mainForm : Form
    {

        public class BookData : IComparable
        {
            public string BookNbr;
            public string Status;
            //public string ISBN;
            //public string Location;
            //public string Title;

            public BookData(string bookID, string status)  //  constructor
            {
                this.BookNbr = bookID;  //  SKU
                this.Status = status;
            }

            //public BookData(string locn, string bookID, string status, string isbn, string title) {
            //    this.BookNbr = bookID;
            //    this.Status = status;
            //    this.ISBN = isbn;
            //    this.Location = locn;
            //    this.Title = title;
            //}

            public int CompareTo(Object rhs) {
                BookData bd = (BookData)rhs;
                return this.BookNbr.CompareTo(bd.BookNbr);
                //    return this.Location.CompareTo(bd.Location);
            }

        }  //  end class BookData

        string inputRecord;

        public ArrayList inventoryArray = new ArrayList();  //  create an array to hold structures
        public ArrayList listingArray = new ArrayList();  //  create an array to hold structures





        //------------------------------------------------------------------------------------------
        public void compareFiles() {

            BookData venueBooks, inventoryBooks;  //  both contain SKU and Status
            bool found = false;

            //--  check to see that a Listing record exists for each Inventory record
            for (int i = 0; i < listingArray.Count; i++) {  //  look at inventory array
                venueBooks = (BookData)listingArray[i];
                if (IsNumeric(venueBooks.BookNbr))
                    venueBooks.BookNbr = venueBooks.BookNbr.Replace(".", "");  //  clean SKU

                for (int j = 0; j < inventoryArray.Count; j++) {  //  look at inventory array
                    found = false;
                    inventoryBooks = (BookData)inventoryArray[j];
                    if (IsNumeric(inventoryBooks.BookNbr))
                        inventoryBooks.BookNbr = inventoryBooks.BookNbr.Replace(".", "");  //  replace any crap in the book number

                    //if (venueBooks.BookNbr.Contains("2987") && inventoryBooks.BookNbr.Contains("2987"))   //  test
                    //    found = false;

                    if (IsNumeric(venueBooks.BookNbr) && IsNumeric(inventoryBooks.BookNbr)) {  //  SKU is numeric
                        if (Int64.Parse(venueBooks.BookNbr) == Int64.Parse(inventoryBooks.BookNbr) &&
                                venueBooks.Status == inventoryBooks.Status) {  //  does it exist and is status equal?
                            found = true;  //  found in both places
                            j = inventoryArray.Count;
                            continue;
                        }
                    }
                    else {  //  SKU is not numeric
                        if (venueBooks.BookNbr.Equals(inventoryBooks.BookNbr) &&
                                venueBooks.Status == inventoryBooks.Status) {  //  does it exist and is status equal?
                            found = true;  //  found in both places
                            j = inventoryArray.Count;  //  get out of this 
                            continue;  //  go to next compare
                        }
                    }
                }

                if (!found) {
                    int status = 0;
                    if (int.TryParse(venueBooks.Status, out status)) {
                        if (status > 0)
                            listBox1.Items.Add(venueBooks.BookNbr + '\t' + "Not in venue inventory");
                    }
                    else {
                        if (venueBooks.Status.Equals("For Sale"))
                            listBox1.Items.Add(venueBooks.BookNbr + '\t' + "Not in database inventory");
                    }
                }
            }


            //  now check to see that Inventory records exist in venueListing records
            for (int i = 0; i < inventoryArray.Count; i++) {
                inventoryBooks = (BookData)inventoryArray[i];

                for (int j = 0; j < listingArray.Count; j++) {
                    found = false;  //  reset
                    venueBooks = (BookData)listingArray[j];

                    if (IsNumeric(inventoryBooks.BookNbr) && IsNumeric(venueBooks.BookNbr)) {
                        if (Int64.Parse(inventoryBooks.BookNbr) == Int64.Parse(venueBooks.BookNbr) &&
                            venueBooks.Status == inventoryBooks.Status) {  //  does it exist and is status equal?
                            found = true;
                            j = inventoryArray.Count;
                            continue;
                        }
                    }
                    else {
                        if (inventoryBooks.BookNbr.ToString().Equals(venueBooks.BookNbr.ToString())) {
                            found = true;  //  found in both places
                            j = inventoryArray.Count;  //  get out of this 
                            continue;  //  go to next compare
                        }
                    }
                }

                if (!found) {
                    int status = 0;
                    if (int.TryParse(inventoryBooks.Status, out status)) {
                        if (status > 0)
                            listBox2.Items.Add(inventoryBooks.BookNbr + '\t' + "Not in database inventory");
                    }
                    else {
                        if (inventoryBooks.Status == "For Sale")
                            listBox2.Items.Add(inventoryBooks.BookNbr + '\t' + "Not in venue inventory");  //  <---??
                    }
                }

            }

            lErrorsDB.Text = "Errors: " + listBox2.Items.Count.ToString();
            lErrorsLS.Text = "Errors: " + listBox1.Items.Count.ToString();

        }
    }      
} 