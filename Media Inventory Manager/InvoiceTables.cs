
#region Using directives

using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

#endregion

namespace Media_Inventory_Manager
{
    partial class mainForm : Form
    {

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //--    fill customer listview on Invoice page
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void fillCustomerListView() {
            Cursor.Current = Cursors.WaitCursor;

            commandString = "SELECT * from tCustomer";
            FbDataAdapter da = new FbDataAdapter(commandString, mediaConn);
            DataSet customerDS = new DataSet();
            da.Fill(customerDS, "tCustomer");  //  fill dataset

            DataTable dtable = customerDS.Tables["tCustomer"];  // Get the table from the data set
            lvCustomerList.Items.Clear();  // Clear the ListView control

            // Display items in the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++) {
                DataRow drow = dtable.Rows[i];
                if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                {
                    ListViewItem lvi = new ListViewItem(drow["tCustName"].ToString());
                    lvi.SubItems.Add(drow["tCustNbr"].ToString());
                    lvi.SubItems.Add(drow["tPhone"].ToString());
                    lvi.Tag = "Title";
                    lvCustomerList.Items.Add(lvi);  // Add the list items to the ListView
                }
            }

            Cursor.Current = Cursors.Default;

        }


        //--------------------------------------------------------------------    fill Invoice listview on Invoice page    --------------------------------
        private void fillInvoiceListView() {
            Cursor.Current = Cursors.WaitCursor;

            lvInvoiceList.Items.Clear();  // Clear the ListView control

            commandString = "SELECT * from tInvoice";
            FbDataAdapter da = new FbDataAdapter(commandString, mediaConn);
            DataSet invoiceDS = new DataSet();
            da.Fill(invoiceDS, "tInvoice");  //  fill dataset

            DataTable dtable = invoiceDS.Tables["tInvoice"];  // Get the table from the data set

            // Display items in the ListView control
            for (int i = 0; i < dtable.Rows.Count; i++) {
                DataRow drow = dtable.Rows[i];
                if (drow.RowState != DataRowState.Deleted)  // Only row that have not been deleted
                {
                    ListViewItem lvi = new ListViewItem(drow["tInvoiceNbr"].ToString());
                    lvi.SubItems.Add(drow["tInvCustNbr"].ToString());
                    DateTime shortDT = (DateTime)drow["tInvDate"];
                    lvi.SubItems.Add(shortDT.ToShortDateString());
                    lvi.SubItems.Add(drow["tInvSoldTo"].ToString());
                    lvi.Tag = "Title";
                    lvInvoiceList.Items.Add(lvi);  // Add the list items to the ListView
                }
            }
            Cursor.Current = Cursors.Default;
        }


        //----------------------------------------------------------------------    add Customer information to table    -----------------------
        private void addCustomerInfo() {
            const string sZeros = "0000000000";
            string custNbr = "";

            if (cbAutoCustomerNbr.Checked == true && tbCustID.Text.Length == 0) {
                Int64 highestNbr = findHighestNbr("customer");
                if (highestNbr != -1) {
                    highestNbr++;
                    tbCustID.Text = highestNbr.ToString();
                    if (tbCustID.Text.Length < 10)
                        tbCustID.Text = sZeros.Substring(0, 10 - tbCustID.Text.Length) + tbCustID.Text;

                }
                else  //  creating first customer number on file
                {
                    if (tbCustID.Text.Length == 0) {
                        MessageBox.Show("Enter starting Customer number in text box", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (tbCustID.Text.Length < 10)
                        tbCustID.Text = sZeros.Substring(0, 10 - tbCustID.Text.Length) + tbCustID.Text;
                }

            }
            else  //  autogenerate == false OR tbInvoiceNbr.Text.Length > 0
            {

                bAddCustomer.Enabled = false;  //  don't allow duplicate adds...

                if (tbCustID.Text.Length == 0) {
                    MessageBox.Show("Customer Number (key) missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (tbCustID.Text.Length < 10)
                custNbr = sZeros.Substring(0, 10 - tbCustID.Text.Length) + tbCustID.Text;
            else
                custNbr = tbCustID.Text;

            if (tbCustName.Text.Length == 0)  //  if customer name is missing, use billing name
                tbCustName.Text = tbBillingName.Text;

            //  remove single quotes
            tbBillingName.Text = tbBillingName.Text.Replace("'", "");
            tbBillingAddr1.Text = tbBillingAddr1.Text.Replace("'", "");
            tbBillingAddr2.Text = tbBillingAddr2.Text.Replace("'", "");
            tbBillingCity.Text = tbBillingCity.Text.Replace("'", "");

            //  do same for shipping...
            tbShipName.Text = tbShipName.Text.Replace("'", "");
            tbShipAddr1.Text = tbShipAddr1.Text.Replace("'", "");
            tbShipAddr2.Text = tbShipAddr2.Text.Replace("'", "");
            tbShipCity.Text = tbShipCity.Text.Replace("'", "");

            if (cbSameAsBillingInfo.Checked == true) {
                tbShipName.Text = tbBillingName.Text;
                tbShipAddr1.Text = tbBillingAddr1.Text;
                tbShipAddr2.Text = tbBillingAddr2.Text;
                tbShipCity.Text = tbBillingCity.Text;
                tbShipState.Text = tbBillingState.Text;
                tbShipZip.Text = tbBillingZip.Text;
                tbShipCntry.Text = tbBillingCntry.Text;
            }

            string insertString = "INSERT INTO tCustomer (" +
                "tCustNbr,tCustName,tBillCustName,tBillAddr1,tBillAddr2,tBillCity,tBillState,tBillZip,tBillCountry,tShipCustName," +
                "tShipAddr1,tShipAddr2,tShipCity,tShipState,tShipZip,tShipCountry,tPhone,tAltPhone,tEmail,tGroup,tContact,tNotes)" +
                "VALUES('" +
                custNbr + "', '" + tbCustName.Text + "', '" + tbBillingName.Text + "', '" + tbBillingAddr1.Text +
                "', '" + tbBillingAddr2.Text + "', '" + tbBillingCity.Text + "', '" + tbBillingState.Text + "', '" + tbBillingZip.Text + "', '" +
                tbBillingCntry.Text + "', '" + tbShipName.Text + "', '" + tbShipAddr1.Text + "', '" + tbShipAddr2.Text + "', '" + tbShipCity.Text +
                "', '" + tbShipState.Text + "', '" + tbShipZip.Text + "', '" + tbShipCntry.Text + "', '" + tbCustPhone.Text + "', '" +
                tbCustAltPhone.Text + "', '" + tbCustEmail.Text + "', '" + tbCustGroup.Text + "', '" + tbCustContact.Text + "', '" +
                tbCustNotes.Text + "')";

            FbCommand cmd = new FbCommand(insertString, mediaConn);
            cmd.ExecuteNonQuery();

            fillCustomerListView();

        }


        //-----------------------------------------------------------------------    populate invoice detail panel    ---------------------------------------
        private void PopulateInvoiceDetailPanel(string invoiceNbr) {
            string custNbr = "";

            clearInvDetailPanel();  //  clear out old stuff

            //  create the DataSet and DataAdapter
            string strSQL = "SELECT i.*, b.* from tInvoice i LEFT JOIN tMedia b ON i.tInvoiceNbr = b.InvoiceNbr WHERE i.tInvoiceNbr = '" + invoiceNbr + "'";
            DataSet ds = new DataSet();

            if (mediaConn.State == ConnectionState.Open)  //  it is the da's responsibility to open the connection
                mediaConn.Close();

            FbDataAdapter da = new FbDataAdapter(strSQL, mediaConn);
            da.Fill(ds, "joinedTable");

            /*
            tInvoiceNbr - 0    tInvCustNbr - 1    tInvDate - 2    tInvSoldBy - 3    tInvSoldTo - 4    tInvShipCustName - 5
            tInvShipAddr1 - 6    tInvShipAddr2 - 7    tInvShipCity - 8    tInvShipState - 9    tInvShipZip - 10
            tInvShipCountry - 11    tInvComments - 12    tInvPaymentMethod - 13    tInvOrderTotal - 14    tInvOrderDiscounts - 15
            tInvTaxVAT - 16    tInvShipping - 17    tInvCommission - 18    tInvAdjustments - 19
              */

            tbInvoiceNbr.Text = ds.Tables[0].Rows[0]["tInvoiceNbr"].ToString();
            custNbr = ds.Tables[0].Rows[0]["tInvCustNbr"].ToString();  //  for later...
            dateTimePicker2.Value = (DateTime)ds.Tables[0].Rows[0]["tInvDate"];
            tbSoldBy.Text = ds.Tables[0].Rows[0]["tInvSoldBy"].ToString();

            lbShipTo.Items.Add(ds.Tables[0].Rows[0]["tInvShipCustName"].ToString());
            lbShipTo.Items.Add(ds.Tables[0].Rows[0]["tInvShipAddr1"].ToString());
            if (ds.Tables[0].Rows[0].IsNull("tInvShipAddr2"))
                lbShipTo.Items.Add(ds.Tables[0].Rows[0]["tInvShipAddr2"].ToString());
            lbShipTo.Items.Add(ds.Tables[0].Rows[0]["tInvShipCity"].ToString() + ", " + ds.Tables[0].Rows[0]["tInvShipState"].ToString() + "  " + ds.Tables[0].Rows[0]["tInvShipZip"].ToString());
            lbShipTo.Items.Add(ds.Tables[0].Rows[0]["tInvShipCountry"].ToString());

            if (!ds.Tables[0].Rows[0].IsNull("tInvPaymentMethod")) {
                string paymentMethod = ds.Tables[0].Rows[0]["tInvPaymentMethod"].ToString();
                switch (paymentMethod) {
                    case "Amazon":
                        cbPayAmazon.Checked = true;
                        break;
                    case "Cash":
                        cbPayCash.Checked = true;
                        break;
                    case "Cheque":
                        cbPayCheque.Checked = true;
                        break;
                    case "Credit Card":
                        cbPayCC.Checked = true;
                        break;
                    case "Debit Card":
                        cbPayDC.Checked = true;
                        break;
                    case "Other":
                        cbPayOther.Checked = true;
                        break;
                    case "PayPal":
                        cbPayPP.Checked = true;
                        break;
                }
            }

            //  search for items that are in this order and populate shopping cart
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++) {
                if (ds.Tables[0].Rows[i].RowState != DataRowState.Deleted)  // Only row that have not been deleted
                {
                    ListViewItem lvi = new ListViewItem(ds.Tables[0].Rows[i]["SKU"].ToString());
                    lvi.SubItems.Add(ds.Tables[0].Rows[i]["Title"].ToString());
                    lvi.SubItems.Add(ds.Tables[0].Rows[i]["UPC"].ToString());
                    string workingPrice = ds.Tables[0].Rows[i]["Price"].ToString();
                    lvi.SubItems.Add(workingPrice);
                    lvShoppingCart.Items.Add(lvi);  // Add the list items to the ListView
                }
            }

            decimal dec = (decimal)ds.Tables[0].Rows[0]["tInvOrderTotal"];  //  order total
            //tbOrderTotal.Text = dec.ToString("#0.00");
            tbOrderTotal.Text = String.Format("{0:c}", dec);

            dec = (decimal)ds.Tables[0].Rows[0]["tInvOrderDiscounts"];  //  discounts
            tbDiscount.Text = String.Format("{0:c}", dec);

            dec = (decimal)ds.Tables[0].Rows[0]["tInvTaxVAT"];  //taxvat
            tbTaxVAT.Text = String.Format("{0:c}", dec);

            dec = (decimal)ds.Tables[0].Rows[0]["tInvShipping"];  //shipping
            tbShipping.Text = String.Format("{0:c}", dec);

            dec = (decimal)ds.Tables[0].Rows[0]["tInvCommission"];
            tbComm.Text = String.Format("{0:c}", dec);

            dec = (decimal)ds.Tables[0].Rows[0]["tInvAdjustments"];
            tbAdj.Text = String.Format("{0:c}", dec);
            computeNewInvTotal();

            PopulateCustDetailPanel(custNbr);  //  pull up customer and populate customer side...

            lbSoldTo.Items.Add(tbBillingName.Text);
            lbSoldTo.Items.Add(tbBillingAddr1.Text);
            if (tbBillingAddr2.Text.Length > 0)
                lbSoldTo.Items.Add(tbBillingAddr2.Text);
            lbSoldTo.Items.Add(tbBillingCity.Text + ", " + tbBillingState.Text + "  " + tbBillingZip.Text);
            lbSoldTo.Items.Add(tbBillingCntry.Text);


        }


        //------------------------------------------------------------------    populate Customer detail panel    ---------------------------------
        private void PopulateCustDetailPanel(string custNbr) {

            clearCustDetailPanel();  //  clear out old stuff

            string strSQL = "SELECT * from tCustomer where tCustNbr = '" + custNbr + "'";
            FbCommand command = new FbCommand(strSQL, mediaConn);

            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();
            /*
              tCustNbr - 0    tCustName - 1    tBillCustName - 2    tBillAddr1 - 3    tBillAddr2 - 4    tBillCity - 5
              tBillState - 6    tBillZip - 7    tBillCountry - 8    tShipCustName - 9    tShipAddr1 - 10    tShipAddr2 - 11
              tShipCity - 12    tShipState - 13    tShipZip - 14    tShipCountry - 15    tPhone - 16    tAltPhone - 17
              tEmail - 18    tContact - 19    tNotes - 20    tGroup - 21
            */

            FbDataReader dataC = command.ExecuteReader();

            while (dataC.Read()) {
                tbCustID.Text = dataC.GetString(0);
                tbCustName.Text = dataC.GetString(1);
                tbBillingName.Text = dataC.GetString(2);
                tbBillingAddr1.Text = dataC.GetString(3);
                tbBillingAddr2.Text = dataC.GetString(4);
                tbBillingCity.Text = dataC.GetString(5);
                tbBillingState.Text = dataC.GetString(6);
                tbBillingZip.Text = dataC.GetString(7);
                tbBillingCntry.Text = dataC.GetString(8);
                tbShipName.Text = dataC.GetString(9);
                tbShipAddr1.Text = dataC.GetString(10);
                tbShipAddr2.Text = dataC.GetString(11);
                tbShipCity.Text = dataC.GetString(12);
                tbShipState.Text = dataC.GetString(13);
                tbShipZip.Text = dataC.GetString(14);
                tbShipCntry.Text = dataC.GetString(15);
                tbCustPhone.Text = dataC.GetString(16);
                tbCustAltPhone.Text = dataC.GetString(17);
                tbCustEmail.Text = dataC.GetString(18);
                tbCustGroup.Text = dataC.GetString(21);
                tbCustContact.Text = dataC.GetString(19);
                tbCustNotes.Text = dataC.GetString(20);
            }

            dataC.Close();
            dataC.Dispose();
        }


        //-------------------------------------------------------------------------    propogate billing info to shipping info    ------------------------
        private void propagateBillingInfo() {
            /*            string strSQL = "SELECT * from tCustomer where tCustNbr = '" + tbCustID.Text + "'";
                        FbConnection connection = new FbConnection(@"server=.\sqlexpress; database=" + dataBaseName + "; integrated security=SSPI ");
                        FbCommand command = new FbCommand(strSQL, connection);
                        connection.Open();
                        FbDataReader data = command.ExecuteReader(CommandBehavior.CloseConnection);
                        while (data.Read())
                        {
                            tbShipName.Text = data.GetString(2);
                            tbShipAddr1.Text = data.GetString(3);
                            tbShipAddr2.Text = data.GetString(4);
                            tbShipCity.Text = data.GetString(5);
                            tbShipState.Text = data.GetString(6);
                            tbShipZip.Text = data.GetString(7);
                            tbShipCntry.Text = data.GetString(8);
                        }
            */
            tbShipName.Text = tbBillingName.Text;
            tbShipAddr1.Text = tbBillingAddr1.Text;
            tbShipAddr2.Text = tbBillingAddr2.Text;
            tbShipCity.Text = tbBillingCity.Text;
            tbShipState.Text = tbBillingState.Text;
            tbShipZip.Text = tbBillingZip.Text;
            tbShipCntry.Text = tbBillingCntry.Text;

        }


        //------------------------------------------------------------------    Update Customer table    --------------------------
        private void updateCustomerTable() {
            try {
                string updateString = "UPDATE tCustomer SET " +
                "tCustNbr = '" + tbCustID.Text + "', " +
                "tCustName = '" + tbCustName.Text + "', " +
                "tBillCustName = '" + tbBillingName.Text + "', " +
                "tBillAddr1 = '" + tbBillingAddr1.Text + "', " +
                "tBillAddr2 = '" + tbBillingAddr2.Text + "', " +
                "tBillCity = '" + tbBillingCity.Text + "', " +
                "tBillState = '" + tbBillingState.Text + "', " +
                "tBillZip = '" + tbBillingZip.Text + "', " +
                "tBillCountry = '" + tbBillingCntry.Text + "', " +
                "tShipCustName = '" + tbShipName.Text + "', " +
                "tShipAddr1 = '" + tbShipAddr1.Text + "', " +
                "tShipAddr2 = '" + tbShipAddr2.Text + "', " +
                "tShipCity = '" + tbShipCity.Text + "', " +
                "tShipState = '" + tbShipState.Text + "', " +
                "tShipZip = '" + tbShipZip.Text + "', " +
                "tShipCountry = '" + tbShipCntry.Text + "', " +
                "tPhone = '" + tbCustPhone.Text + "', " +
                "tAltPhone = '" + tbCustAltPhone.Text + "', " +
                "tEmail = '" + tbCustEmail.Text + "', " +
                "tGroup = '" + tbCustGroup.Text + "', " +
                "tContact = '" + tbCustContact.Text + "', " +
                "tNotes = '" + tbCustNotes.Text + "' WHERE tCustNbr = '" + tbCustID.Text + "'";

                FbCommand cmd = new FbCommand(updateString, mediaConn);
                cmd.ExecuteNonQuery();

                lUpdateStatus2.Visible = true;
            }
            catch (IndexOutOfRangeException) {
                MessageBox.Show("You can not update a record before adding it", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fillCustomerListView();
        }


        //------------------------------------------------------------------------    delete record from Customer table    ------------------------
        private void deleteRecordFromCustomerTable() {

            if (cbVerifyDeletes.Checked) {
                DialogResult dg = MessageBox.Show("Are you sure you want to delete this record?", "Verify Deletion", MessageBoxButtons.YesNo);
                if (dg == DialogResult.No)
                    return;
            }
            commandString = "DELETE FROM tCustomer where tCustNbr = '" + tbCustID.Text + "'";
            FbCommand myCommand = new FbCommand(commandString, mediaConn);

            try {
                myCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex) {
                MessageBox.Show("Error deleting record " + tbCustID.Text + "\r" + ex.Message + "\n" + ex.StackTrace);
            }
            finally {
                fillCustomerListView();
            }

        }  


        //--  add invoice to table
        private void addInvoiceToTable() {
            //  are there any items in invoice?
            if (lvShoppingCart.Items.Count == 0) {
                MessageBox.Show("There are no items in shopping cart!", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            const string sZeros = "0000000000";

            if (cbAutoInvoiceNbr.Checked == true && tbInvoiceNbr.Text.Length == 0) {
                Int64 highestNbr = findHighestNbr("invoice");
                if (highestNbr != -1) {
                    highestNbr++;
                    tbInvoiceNbr.Text = highestNbr.ToString();
                    if (tbInvoiceNbr.Text.Length < 10)
                        tbInvoiceNbr.Text = sZeros.Substring(0, 10 - tbInvoiceNbr.Text.Length) + tbInvoiceNbr.Text;

                }
                else  //  creating first invoice on file
                {
                    if (tbInvoiceNbr.Text.Length == 0) {
                        MessageBox.Show("Enter numeric starting invoice number in text box", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (tbInvoiceNbr.Text.Length < 10)
                        tbInvoiceNbr.Text = sZeros.Substring(0, 10 - tbInvoiceNbr.Text.Length) + tbInvoiceNbr.Text;
                }

            }
            else  //  autogenerate == false OR tbInvoiceNbr.Text.Length > 0
            {
                if (tbInvoiceNbr.Text.Length == 0) {
                    MessageBox.Show("Enter Invoice number in text box and/or check AutoGenerate in Options menu", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (tbInvoiceNbr.Text.Length < 10)
                    tbInvoiceNbr.Text = sZeros.Substring(0, 10 - tbInvoiceNbr.Text.Length) + tbInvoiceNbr.Text;
            }

            if (lbSoldTo.Items.Count == 0)  //  did the user pick a customer?
            {
                MessageBox.Show("Error:  you must choose a customer from the customer tab and Transfer Data to Invoice", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string paymentMethod = "";
            if (cbPayAmazon.Checked == false && cbPayCash.Checked == false && cbPayCC.Checked == false && cbPayCheque.Checked == false &&
                cbPayDC.Checked == false && cbPayOther.Checked == false && cbPayPP.Checked == false) {
                DialogResult dg = MessageBox.Show("You did not select a payment method.\rAre you sure you want to leave it blank?",
                     "Prager Media Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg == DialogResult.No)
                    return;
            }
            else {
                if (cbPayAmazon.Checked == true)
                    paymentMethod = "Amazon";
                else if (cbPayCash.Checked == true)
                    paymentMethod = "Cash";
                else if (cbPayCC.Checked == true)
                    paymentMethod = "Credit Card";
                else if (cbPayCheque.Checked == true)
                    paymentMethod = "Cheque";
                else if (cbPayDC.Checked == true)
                    paymentMethod = "Debit Card";
                else if (cbPayOther.Checked == true)
                    paymentMethod = "Other";
                else if (cbPayPP.Checked == true)
                    paymentMethod = "PayPal";
            }

            //  clean up blank money fields
            tbDiscount.Text = tbDiscount.Text.Length == 0 ? "0.00" : tbDiscount.Text;
            tbTaxVAT.Text = tbTaxVAT.Text.Length == 0 ? "0.00" : tbTaxVAT.Text;
            tbShipping.Text = tbShipping.Text.Length == 0 ? "0.00" : tbShipping.Text;
            tbComm.Text = tbComm.Text.Length == 0 ? "0.00" : tbComm.Text;
            tbAdj.Text = tbAdj.Text.Length == 0 ? "0.00" : tbAdj.Text;

            string insertString = "INSERT INTO tInvoice (" +
            "tInvoiceNbr, tInvCustNbr, tInvDate, tInvSoldBy, tInvSoldTo, tInvPaymentMethod, " +
            "tInvShipCustName, tInvShipAddr1, tInvShipAddr2, tInvShipCity, tInvShipState," +
            " tInvShipZip, tInvShipCountry, tInvOrderTotal, tInvOrderDiscounts, tInvTaxVAT, tInvShipping, tInvCommission, tInvAdjustments)" +
            "VALUES('" +
            tbInvoiceNbr.Text + "', '" +
            tbCustID.Text + "', '" +
            dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "', '" +
            tbSoldBy.Text + "', '" +
            lbSoldTo.Items[0].ToString() + "', '" +  //  assumes that the customer stuff has been selected from prior screen...  <----------- TODO
            paymentMethod + "', '" +
            tbShipName.Text + "', '" +
            tbShipAddr1.Text + "', '" +
            tbShipAddr2.Text + "', '" +
            tbShipCity.Text + "', '" +
            tbShipState.Text + "', '" +
            tbShipZip.Text + "', '" +
            tbShipCntry.Text + "', '" +
            tbOrderTotal.Text + "', '" +
            tbDiscount.Text + "', '" +
            tbTaxVAT.Text + "', '" +
            tbShipping.Text + "', '" +
            tbComm.Text + "', '" +
            tbAdj.Text + "')";

            FbCommand cmd = new FbCommand(insertString, mediaConn);
            try {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                if (ex.Message.Contains("violation of PRIMARY or UNIQUE KEY")) {
                    MessageBox.Show("Invoice number already exists in database; change or clear Invoice number and try again", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else {
                    MessageBox.Show("537 - error adding Invoice: " + ex.Message, "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            updateItemWithInvoiceNbr(true);   //  now, update tMedia with invoice number for each item in list 

            //fillInvoiceListView();

        }


        //--  update Invoice table
        private void updateInvoiceTable() {
            if (lvShoppingCart.Items.Count == 0) {
                MessageBox.Show("There are no items in shopping cart!", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tbInvoiceNbr.Text.Length == 0) {
                MessageBox.Show("Error:  you can not do an Update without establishing an existing Invoice number", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbPayAmazon.Checked == false && cbPayCash.Checked == false && cbPayCC.Checked == false && cbPayCheque.Checked == false &&
                  cbPayDC.Checked == false && cbPayOther.Checked == false && cbPayPP.Checked == false) {
                DialogResult dg = MessageBox.Show("You did not check a payment method.\rAre you sure you want to leave it blank?",
                     "Prager Media Inventory Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg == DialogResult.No)
                    return;
            }

            string paymentMethod = "";
            if (cbPayAmazon.Checked == true)
                paymentMethod = "Amazon";
            else if (cbPayCash.Checked == true)
                paymentMethod = "Cash";
            else if (cbPayCC.Checked == true)
                paymentMethod = "Credit Card";
            else if (cbPayCheque.Checked == true)
                paymentMethod = "Cheque";
            else if (cbPayDC.Checked == true)
                paymentMethod = "Debit Card";
            else if (cbPayOther.Checked == true)
                paymentMethod = "Other";
            else if (cbPayPP.Checked == true)
                paymentMethod = "PayPal";

            string updateString = "UPDATE tInvoice SET " +
                "tInvCustNbr = '" + tbCustID.Text + "', " +
                "tInvDate = '" + dateTimePicker2.Text + "', " +
                "tInvSoldBy = '" + tbSoldBy.Text + "', " +
                "tInvSoldTo = '" + tbBillingName.Text + "', " +
                "tInvShipCustName = '" + tbShipName.Text + "', " +
                "tInvShipAddr1 = '" + tbShipAddr1.Text + "', " +
                "tInvShipAddr2 = '" + tbShipAddr2.Text + "', " +
                "tInvShipCity = '" + tbShipCity.Text + "', " +
                "tInvShipState = '" + tbShipState.Text + "', " +
                //"tInvPaymentMethod = '" + lbPaymentMethod.Text + "', " + 
                "tInvPaymentMethod = '" + paymentMethod + "', " +
                "tInvShipZip = '" + tbShipZip.Text + "', " +
                "tInvShipCountry = '" + tbShipCntry.Text + "', " +
                "tInvOrderTotal = '" + tbOrderTotal.Text + "', " +
                "tInvOrderDiscounts = '" + tbDiscount.Text + "', " +
                "tInvTaxVAT = '" + tbTaxVAT.Text + "', " +
                "tInvShipping = '" + tbShipping.Text + "', " +
                "tInvCommission = '" + tbComm.Text + "', " +
                "tInvAdjustments = '" + tbAdj.Text + "' " +
                "WHERE tInvoiceNbr = '" + tbInvoiceNbr.Text + "'";
            FbCommand cmd = new FbCommand(updateString, mediaConn);
            cmd.ExecuteNonQuery();

            lUpdateStatus.Text = "Update Successful";
            lUpdateStatus.Visible = true;


            updateItemWithInvoiceNbr(true);   //  now, update tMedia with invoice number for each item in list

            //fillInvoiceListView();
        }



        //--------------------    delete record from Invoice table    -------------------]
        private void deleteRecordFromInvoiceTable() {
            if (cbVerifyDeletes.Checked == true) {
                DialogResult dg = MessageBox.Show("Are you sure you want to delete this record?", "Verify Deletion", MessageBoxButtons.YesNo);
                if (dg == DialogResult.No)
                    return;
            }

            commandString = "DELETE FROM tInvoice where tInvoiceNbr = '" + tbInvoiceNbr.Text + "'";
            FbCommand myCommand = new FbCommand(commandString, mediaConn);
            myCommand.ExecuteNonQuery(); //  delete record from invoice table

            updateItemWithInvoiceNbr(false);  //  delete invoice number from item(s) in invoice table

            //fillInvoiceListView();


        }  //  end delete Invoice record



        //--  update item in table with invoice number
        private void updateItemWithInvoiceNbr(bool updateFlag)  //  true = update, false = delete
        {
            //  get SKUs
            int i = lvShoppingCart.Items.Count;
            string SKU = "";
            string updateString = "";

            for (i = 0; i < lvShoppingCart.Items.Count; i++) {
                SKU = lvShoppingCart.Items[i].SubItems[0].Text;
                if (SKU.Length > 0) {
                    if (updateFlag == true)
                        updateString = "UPDATE tMedia SET InvoiceNbr = '" + tbInvoiceNbr.Text + "' WHERE SKU = '" + SKU + "'";
                    else  //  delete SKU
                        updateString = "UPDATE tMedia SET InvoiceNbr = null WHERE SKU = '" + SKU + "'";
                    FbCommand cmd = new FbCommand(updateString, mediaConn);
                    cmd.ExecuteNonQuery();
                }

                updateDataBasePanel(SKU);  // now, repaint the database listview
            }

        }



        //--  search by invoice number
        private void searchByInvoiceNbr() {
            //string commandString = "";
            Regex r;
            Match m;

            if (tbInvoiceNbr.Text.Length == 0) {
                MessageBox.Show("Search argument missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //  check to see if there is a wildcard (asterisk) with an equal compare
            r = new Regex("[*]");
            m = r.Match(tbInvoiceNbr.Text);
            if (m.Success)
                commandString = "SELECT * from tInvoice where tInvoiceNbr LIKE '%" +
                    tbInvoiceNbr.Text.Substring(0, tbInvoiceNbr.Text.Length - 1) + "%'";
            else
                commandString = "SELECT * from tInvoice where tInvoiceNbr = '" + tbInvoiceNbr.Text + "'";

            FbDataReader rdr = null;
            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();

            FbCommand cmd = new FbCommand(commandString, mediaConn);

            rdr = cmd.ExecuteReader();

            lvInvoiceList.Items.Clear();  // Clear the ListView control

            while (rdr.Read()) {
                ListViewItem lvi = new ListViewItem(rdr["tInvoiceNbr"].ToString());
                lvi.SubItems.Add(rdr["tInvCustNbr"].ToString());
                lvi.SubItems.Add(rdr["tInvDate"].ToString());
                lvi.SubItems.Add(rdr["tInvSoldTo"].ToString());
                lvInvoiceList.Items.Add(lvi);  // Add the list items to the ListView
            }
            rdr.Close();

        }  //  end searchByInvoiceNbr


        //-----------------------------------------------------------------    search by customer number    ------------------------------------------
        private void searchByCustomerNbr() {
            //string commandString = "";
            string custNbr = "";
            Regex r;
            Match m;

            if (tbCustID.Text.Length == 0 && tbCustName.Text.Length == 0) {
                MessageBox.Show("Search argument missing", "Prager Media Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (tbCustName.Text.Length == 0) {
                r = new Regex("[*]");  //  check to see if there is a wildcard (asterisk) with an equal compare
                m = r.Match(custNbr);
                if (m.Success)
                    commandString = "SELECT * from tCustomer where tCustNbr LIKE '%" +
                        tbCustID.Text.Substring(0, tbCustID.Text.Length - 1) + "%'";
                else
                    commandString = "SELECT * from tCustomer where tCustNbr = '" + tbCustID.Text + "'";
            }
            else {
                r = new Regex("[*]");  //  check to see if there is a wildcard (asterisk) with an equal compare
                m = r.Match(tbCustName.Text);
                if (m.Success)
                    commandString = "SELECT * from tCustomer where tCustName LIKE '%" +
                        tbCustName.Text.Substring(0, tbCustName.Text.Length - 1) + "%'";
                else
                    commandString = "SELECT * from tCustomer where tCustName = '" + tbCustName.Text + "'";
            }
            FbDataReader rdr = null;
            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();

            FbCommand cmd = new FbCommand(commandString, mediaConn);

            rdr = cmd.ExecuteReader();

            lvCustomerList.Items.Clear();  // Clear the ListView control

            while (rdr.Read()) {
                ListViewItem lvi = new ListViewItem(rdr["tCustName"].ToString());
                lvi.SubItems.Add(rdr["tCustNbr"].ToString());
                lvi.SubItems.Add(rdr["tPhone"].ToString());
                lvCustomerList.Items.Add(lvi);  // Add the list items to the ListView
            }

            rdr.Close();
        }


    }     //  end mainWindow class

}  //  end namespace

