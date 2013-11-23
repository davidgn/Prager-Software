#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

#endregion

namespace Prager_Book_Inventory
{

    partial class mainForm : Form
    {

        //++++++++++++++++++++++++++++++++++++++++
        //--    fill Primary catalog listbox
        //++++++++++++++++++++++++++++++++++++++++
        private void populatePriCatalogListbox() {
            Cursor.Current = Cursors.WaitCursor;

            lbPrimaryCatalog.Items.Clear();  //  so we don't expand the list 

            //  need to fill Primary catalog listbox
            if (cbDontSortCatalog.Checked == true)
                commandString = "select * from tCatalog WHERE AttachedTo = ' ' OR AttachedTo IS NULL";
            else
                commandString = "select * from tCatalog WHERE AttachedTo = ' ' OR AttachedTo IS NULL ORDER BY CatID";
            FbDataReader dr = null;
            FbCommand cmd = new FbCommand(commandString, bookConn);
            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read()) {
                lbPrimaryCatalog.Items.Add(dr["CatID"]);
                lbChangePricesCat.Items.Add(dr["CatID"]);
            }
            dr.Close();

            Cursor.Current = Cursors.Default;

        }


        //+++++++++++++++++++++++++++++++++++++++++++++
        //--    fill secondary catalog listbox
        //+++++++++++++++++++++++++++++++++++++++++++++
        private void populateSecCatalogListbox() {
            //lbSecondaryCatalog.SelectedIndexChanged -= lbSecondaryCatalog_SelectedIndexChanged;
            lbSecondaryCatalog.Items.Clear();  //  remove all of the old items...

            if (lbPrimaryCatalog.SelectedIndex == -1)
                return;

            string attachedTo = lbPrimaryCatalog.SelectedItem.ToString();  //  which primary catalog?
            commandString = "select * from tCatalog WHERE AttachedTo = '" + attachedTo.Replace("'", "''") +
                "' order by CatID";

            FbDataReader dr = null;
            FbCommand cmd = new FbCommand(commandString, bookConn);
            if (bookConn.State == ConnectionState.Closed)
                bookConn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read()) {
                lbSecondaryCatalog.Items.Add(dr["CatID"]);
                lbChangePricesCat.Items.Add(dr["CatID"]);
            }
            dr.Close();

        }


        //+++++++++++++++++++++++++++++++++++++++++++++
        //--   choose a primary catalog entry
        //+++++++++++++++++++++++++++++++++++++++++++++
        private void choosePriCatalogEntry() {
            if (searchOnCatalog) {
                //tbPriCatalogSearch.Text = lbPrimaryCatalog.Text;

                //  fill Database Panel using catalog as search criteria
                commandString = "select BookNbr, Title, ISBN, Quantity, Locn, Price, Stat, InvoiceNbr from tBooks where Cat = '" + lbPrimaryCatalog.Text.Trim() + "'";

                fillDataBasePanel(commandString);  //  fill the tBooks datagridview      
                tabTaskPanel.SelectTab(cSearch);  //  go to search tab
            }
            else  //  we are not doing a search, so...
            {
                tbPriCatalog.Text = lbPrimaryCatalog.Text;

                if (updateNeeded) {
                    bUpdateRecord.BackColor = System.Drawing.Color.OrangeRed;
                    bUpdateRecord.Enabled = true;
                }

                if (catalogTabClicked == false && lbSecondaryCatalog.Items.Count == 0)  //  if we're not on the catalog page and there are no secondary items...
                {
                    tbSecCatalog.Text = "";  //  if we don't have any secondary catalogs, clear residual values, if any
                    tabTaskPanel.SelectTab(cPricingResults);  //  go all the way to the left, then...
                    tabTaskPanel.SelectTab(cBookDetail);  //  return to detail panel
                }
            }
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++
        //--     choose a secondary catalog entry
        //+++++++++++++++++++++++++++++++++++++++++++++++++
        private void chooseSecondaryCatalogEntry() {
            tbPriCatalog.Text = lbPrimaryCatalog.Text;  //  force them to match
            tbSecCatalog.Text = lbSecondaryCatalog.Text;
            if (!bAddRecord.Enabled)
                bUpdateRecord.BackColor = Color.OrangeRed;

            if (catalogTabClicked == false)  //  if adding a book...
            {
                tabTaskPanel.SelectTab(cPricingResults);  //  go all the way to the left, then...
                tabTaskPanel.SelectTab(cBookDetail);  //  return to detail panel
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++
        //--  import catalog entries from a text file
        //++++++++++++++++++++++++++++++++++++++++++++++++
        private void importCatalog() {
            string input;

            if (cbDeleteCurrentContents.Checked) {
                string commandLine = @"delete from tCatalog";
                sqlCmd = new FbCommand(commandLine, bookConn);
                sqlCmd.ExecuteNonQuery();
            }

            //  create stream reader object
            System.IO.StreamReader sr = new System.IO.StreamReader(sFileName1);

            //  now read entire file into the array
            while ((input = sr.ReadLine()) != null) {
                input = input.Replace("'", "''");  //  fix it up....
                input = input.Trim();
                input = input.Length > 50 ? input.Substring(0, 50) : input;

                string insertString = @"insert into tCatalog (CatID) values ('" + input + "')";
                sqlCmd = new FbCommand(insertString, bookConn);
                if (bookConn.State == ConnectionState.Closed)
                    bookConn.Open();
                try {
                    sqlCmd.ExecuteNonQuery();
                }
                catch (Exception ex)   //  catch duplicate keys
                {
                    if (ex.Message.Contains("violation of PRIMARY or UNIQUE KEY") || ex.Message.Contains("violation of FOREIGN KEY constraint")) {
                        MessageBox.Show("You have previously entered " + input, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            sr.Close();  //  close the stream reader

            populatePriCatalogListbox();  //  now fill the listbox
            backupNeeded = true;
        }


        //+++++++++++++++++++++++++++++++++++++++++++
        //--    add an entry to the catalog
        //+++++++++++++++++++++++++++++++++++++++++++
        private void tCatAddEntry() {

            if (rbAddToPriCatalog.Checked == false && rbAddToSecCatalog.Checked == false) {
                MessageBox.Show("You must indicate which catalog to add this entry", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rbAddToPriCatalog.Checked == true) {
                string insertString = @"insert into tCatalog (CatID) " + "values ('" + tbCatAdd.Text + "')";
                sqlCmd = new FbCommand(insertString, bookConn);
                if (bookConn.State == ConnectionState.Closed)
                    bookConn.Open();
                try {
                    sqlCmd.ExecuteNonQuery();
                }
                catch (Exception ex)   //  catch duplicate keys
                {
                    if (ex.Message.Contains("violation of PRIMARY or UNIQUE KEY") || ex.Message.Contains("violation of FOREIGN KEY constraint")) {
                        MessageBox.Show("You have previously entered " + tbCatAdd.Text, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                populatePriCatalogListbox();  //  refresh the Catalog listbox
                tbCatAdd.Clear();
            }
            else if (rbAddToSecCatalog.Checked == true) //  Secondary catalog
            {
                //  find out what it is attached to  
                string attachedTo = "";
                if (lbPrimaryCatalog.SelectedIndex != -1)
                    attachedTo = lbPrimaryCatalog.SelectedItem.ToString();
                else {
                    MessageBox.Show("You have to indicate which primary catalog this is attached to.", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //  add it...
                string insertString = @"insert into tCatalog (CatID, AttachedTo) " + "values ('" + tbCatAdd.Text + "', '" + attachedTo + "')";
                sqlCmd = new FbCommand(insertString, bookConn);
                if (bookConn.State == ConnectionState.Closed)
                    bookConn.Open();
                try {
                    sqlCmd.ExecuteNonQuery();
                }
                catch (Exception ex)   //  catch duplicate keys  TODO  <--------------------------------   TODO
                {
                    if (ex.Message.Contains("violation of PRIMARY or UNIQUE KEY") || ex.Message.Contains("violation of FOREIGN KEY constraint")) {
                        MessageBox.Show("You have previously entered " + tbCatAdd.Text, "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                populateSecCatalogListbox();  //  refresh the Catalog listbox
                tbCatAdd.Clear();
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    delete an entry from the Catalog
        //++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void tCatDeleteEntry() {
            string deleteString = "";
            string ws = "";
            if (lbSecondaryCatalog.Items.Count == 0 || lbSecondaryCatalog.SelectedIndex == -1)  //  if there are no secondary items, then we must be deleting a primary entry
            {
                if (lbPrimaryCatalog.SelectedItem == null) {
                    MessageBox.Show("You have not selected a catalog item to delete", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ws = lbPrimaryCatalog.SelectedItem.ToString().Replace("'", "''");
                deleteString = "DELETE from tCatalog where CatID = '" + ws + "'";

                if (cbVerifyDeletes.Checked == true) {
                    DialogResult dg = MessageBox.Show("Are you sure you want to delete this record?", "Verify Deletion", MessageBoxButtons.YesNoCancel);
                    if (dg == DialogResult.No || dg == DialogResult.Cancel)
                        return;
                }

                sqlCmd = new FbCommand(deleteString, bookConn);
                if (bookConn.State == ConnectionState.Closed)
                    bookConn.Open();
                sqlCmd.ExecuteNonQuery();

                populatePriCatalogListbox();  //  refresh the Catalog listbox
            }
            else  //  delete sub-category
            {
                if (lbSecondaryCatalog.SelectedIndex != -1 && lbSecondaryCatalog.SelectedItem != null) {
                    ws = lbSecondaryCatalog.SelectedItem.ToString().Replace("'", "''");
                    deleteString = "DELETE from tCatalog where CatID = '" + ws + "'";

                    if (cbVerifyDeletes.Checked == true) {
                        DialogResult dg = MessageBox.Show("Are you sure you want to delete this record?", "Verify Deletion", MessageBoxButtons.YesNoCancel);
                        if (dg == DialogResult.No || dg == DialogResult.Cancel)
                            return;
                    }

                    sqlCmd = new FbCommand(deleteString, bookConn);
                    if (bookConn.State == ConnectionState.Closed)
                        bookConn.Open();
                    sqlCmd.ExecuteNonQuery();
                }
                populateSecCatalogListbox();  //  refresh the Catalog listbox
            }
        }


    }  //  end partial class Form1

}  //  end namespace


