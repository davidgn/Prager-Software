using System.Data.SQLite;
using System.Windows.Forms;

namespace Blank_Quilting_Manager
{
    public partial class mainForm : Form
    {
        //--------------    open the database    ----------------------|
            SQLiteConnection conn;

            public int OpenDB() {
            conn = new SQLiteConnection(@"Data Source=D:\BlankCustomerDB.s3db");  //  CHANGE  <--------------------
            conn.Open();  //  open the connection to the d/b

            return 0;
        }

        //--------------    add a record to the table    ----------------------|
        public int CustomerDBAdd() {

            string insertString = @"INSERT INTO CustomerInfo " +
                "(StoreName, StoreEmail, StoreStreetAddr, StorePhone, StoreFax, StoreCity, StoreState, StoreZip,  " +
                "ShipStreetAddress, ShipCity, ShipState, ShipZip, BuyerName, BuyerEmail, OwnerName, OwnerEmail) " +
                "values ('" + 
                tbCustName.Text + "', '" + 
                tbCustEmail.Text + "', '" + 
                tbCustStreetAddr.Text + "', '" +
                tbCustPhone.Text + "', '" + 
                tbCustFax.Text + "', '" + 
                tbCustCity.Text + "', '" +
                "1" + "', '" +
                tbCustZip.Text + "', '" + 
                tbCustMailingAddr.Text + "', '" + 
                tbCustMailingCity.Text + "', '" +
                "1" + "', '" + 
                tbCustMailingZip.Text + "', '" + 
                tbBuyerName.Text + "', '" + 
                tbBuyerEmail.Text + "', '" +
                tbOwnerName.Text + "', '" + 
                tbOwnerEmail.Text + "' )";

            SQLiteCommand cmd = new SQLiteCommand(insertString, conn);
            cmd.ExecuteNonQuery();


            return 0;
        }

        //--------------    update a record in the table    ----------------------|
        public int CustomerDBUpdate() {

            return 0;
        }

        //--------------    delete a record in the table    ----------------------|
        public int CustomerDBDelete() {

            return 0;

        }

        //--------------    add a record to the Order table    ----------------------|
        public int OrderAdd() {

            return 0;
        }

        //--------------    delete a record from the Order table    ----------------------|
        public int OrderDelete() {

            return 0;
        }
    }
}
