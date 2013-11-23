#region Using directives

using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

#endregion

namespace Prager_Book_Inventory
{

    partial class mainForm : Form
    {

        //MemoryStream invoiceXMLDoc = new MemoryStream();
        static private bool customerLVInitialized = false;
        static private bool invoiceLVInitialized = false;

        //--------------------------    initialize new invoice    ------------------------------------------------
        public void initializeInvoice()
        {
            initializeShoppingCart();

            if (invoiceLVInitialized == false)
                initializeInvoiceListView();

            fillInvoiceListView();

            //  compute order value and initialize
            int i = lvShoppingCart.Items.Count;
            decimal subAmount = 0;
            if (i != 0)
            {
                for (i = 0; i < lvShoppingCart.Items.Count; i++)
                {
                    string tempStr = lvShoppingCart.Items[i].SubItems[3].Text;
                    if (tempStr.Length != 0)
                        subAmount += decimal.Parse(tempStr);
                }
                tbOrderTotal.Text = subAmount.ToString();
                tbInvoiceTtl.Text = subAmount.ToString();
            }
            else
            {
                tbOrderTotal.Text = "0.00";
                tbDiscount.Text = "0.00";
                tbTaxVAT.Text = "0.00";
                tbShipping.Text = "0.00";
                tbComm.Text = "0.00";
                tbAdj.Text = "0.00";
                tbInvoiceTtl.Text = "0.00";
            }
        }


        //--------------------------    xfer customer data to invoice    ----------------------------------
        private void xferDataToInvoice()
        {

            ListView.SelectedListViewItemCollection customerCount = lvCustomerList.SelectedItems;

            if (customerCount.Count > 0)
            {
                bXfer.Enabled = false;  //  don't allow more than one click
                propagateCustToInvoice();

                //tabTaskPanel.SelectTab(cInvoice);  //  go to Invoice tab
            }
            else
            {
                MessageBox.Show("You must select a customer from the list above", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }


        //--------------------------    remove shopping cart item    --------------------------------
        private void removeShoppingCartItem()
        {

            //  find which row was selected
            ListView.SelectedListViewItemCollection invdata = lvShoppingCart.SelectedItems;
            foreach (ListViewItem item in invdata)
            {
                item.Remove();  //  remove item from listview

                //  now remove item from record in books table (item.text has SKU)
                string updateString = "UPDATE tBooks SET InvoiceNbr = null WHERE BookNbr = '" + item.Text + "'";
                FbCommand cmd = new FbCommand(updateString, bookConn);
                cmd.ExecuteNonQuery();

                updateDataBasePanel(item.Text);
            }
            lvShoppingCart.Refresh();  //  repaint...

            //  compute order value and initialize
            int i = lvShoppingCart.Items.Count;
            if (i > 0)
            {
                decimal subAmount = 0;
                for (i = 0; i < lvShoppingCart.Items.Count; i++)
                {
                    string tempStr = lvShoppingCart.Items[i].SubItems[3].Text;
                    subAmount += decimal.Parse(tempStr);
                }
                tbOrderTotal.Text = subAmount.ToString();
            }
            else
            {
                tbOrderTotal.Text = String.Format("{0:c}","0.00");  //  no items, zero is the balance
            }

            computeNewInvTotal();

        }


        //--------------------------    allows copying of shipping address    ------------------------------
        public void copyShipAddressToClipboard(System.Windows.Forms.ListBox shipAddress)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (shipAddress.Items.Count == 0)
            {
                MessageBox.Show("Nothing to copy", "Prager Book Inventory Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int itemIndex = 0; itemIndex < shipAddress.Items.Count; itemIndex++)
            {
                stringBuilder.Append(shipAddress.Items[itemIndex].ToString() + Environment.NewLine);
            }
            Clipboard.SetText(stringBuilder.ToString());
        }


        //--------------------------    initialize customer listview    -------------------------------
        private void initializeCustomerListView()
        {
            lvCustomerList.View = View.Details;  // Set the view to show details.
            lvCustomerList.LabelEdit = false;  // Allow the user to edit item text.
            lvCustomerList.GridLines = true;
            lvCustomerList.AllowColumnReorder = true;  // Allow the user to rearrange columns.
            lvCustomerList.FullRowSelect = true;  // Select the item and subitems when selection is made.

            // Attach Subitems to the ListView
            lvCustomerList.Columns.Add("Name", 310, HorizontalAlignment.Left);
            lvCustomerList.Columns.Add("Customer ID", 95, HorizontalAlignment.Left);
            lvCustomerList.Columns.Add("Phone", 95, HorizontalAlignment.Left);
            customerLVInitialized = true;
        }


        //--------------------------    initialize invoice listview    ------------------------------
        private void initializeInvoiceListView()
        {
            lvInvoiceList.View = View.Details;  // Set the view to show details.
            lvInvoiceList.LabelEdit = false;  // Allow the user to edit item text.
            lvInvoiceList.GridLines = true;
            lvInvoiceList.AllowColumnReorder = true;  // Allow the user to rearrange columns.
            lvInvoiceList.FullRowSelect = true;  // Select the item and subitems when selection is made.

            // Attach Subitems to the ListView
            lvInvoiceList.Columns.Add("Invoice Nbr", 95, HorizontalAlignment.Left);
            lvInvoiceList.Columns.Add("Customer Nbr", 95, HorizontalAlignment.Left);
            lvInvoiceList.Columns.Add("Date", 80, HorizontalAlignment.Left);
            lvInvoiceList.Columns.Add("Sold To", 210, HorizontalAlignment.Left);

            invoiceLVInitialized = true;
        }


        //--------------------------    initialize shopping cart    --------------------------
        private void initializeShoppingCart()
        {
            if (lvShoppingCart.AllowColumnReorder == false)  //  first time flag...
            {
                lvShoppingCart.View = View.Details;  // Set the view to show details.
                lvShoppingCart.LabelEdit = false;  // Allow the user to edit item text.
                lvShoppingCart.GridLines = true;
                lvShoppingCart.AllowColumnReorder = true;  // Allow the user to rearrange columns.
                lvShoppingCart.FullRowSelect = true;  // Select the item and subitems when selection is made.

                // Attach Subitems to the ListView
                lvShoppingCart.Columns.Add("Book Number", 110, HorizontalAlignment.Left);
                lvShoppingCart.Columns.Add("Title", 300, HorizontalAlignment.Left);
                lvShoppingCart.Columns.Add("ISBN", 90, HorizontalAlignment.Left);
                lvShoppingCart.Columns.Add("Price", 61, HorizontalAlignment.Right);
            }

            if (shoppingCart.Count > 0)
            {
                string buildCommand = "select BookNbr, Title, ISBN, Price from tBooks where  ";
                foreach (string dataString in shoppingCart)
                {
                    buildCommand += "BookNbr = '" + dataString.Trim() + "' or ";
                }
                int buildLength = buildCommand.Length;
                commandString = buildCommand.Remove(buildLength - 3);

                FbDataReader dr = null;
                if (bookConn.State == ConnectionState.Closed)
                    bookConn.Open();
                FbCommand cmd = new FbCommand(commandString, bookConn);
                dr = cmd.ExecuteReader();

                bool skipIt = false;
                while (dr.Read())
                {
                    if (lvShoppingCart.Items.Count > 0)  //  if listview is not empty
                    {
                        for (int x = 0; x < lvShoppingCart.Items.Count; x++)
                        {
                            if (lvShoppingCart.Items[x].SubItems[0].Text == (string)dr[0])  //  if book is already in the invoice, skip it...
                            {
                                skipIt = true;
                                break;
                            }
                        }
                    }

                    CultureInfo ci = CultureInfo.CurrentCulture;
                    NumberFormatInfo nfi = ci.NumberFormat;

                    if (!skipIt)
                    {
                        ListViewItem lvi = new ListViewItem(dr[0].ToString());  //  SKU
                        lvi.SubItems.Add(dr[1].ToString());  // Title        //.Substring(0,60));
                        lvi.SubItems.Add(dr[2].ToString());  //  ISBN
                        //lvi.SubItems.Add( ((decimal)dr[3]).ToString("#,###.##"));
                        decimal workingPrice = dr.GetDecimal(3);
                        lvi.SubItems.Add(workingPrice.ToString("#,###.00", nfi));

                        lvShoppingCart.Items.Add(lvi);  // Add the list items to the ListView           
                    }
                    skipIt = false;
                }
            }
        }

        //--------------------------    clear invoice detail panel    --------------------------
        private void clearInvDetailPanel()
        {
            tbInvoiceNbr.Text = "";
            tbCustID.Text = "";
            dateTimePicker2.Value = DateTime.Now;
            tbSoldBy.Text = "";
            tbBillingName.Text = "";
            tbShipName.Text = "";
            tbShipAddr1.Text = "";
            tbShipAddr2.Text = "";
            tbShipCity.Text = "";
            tbShipState.Text = "";
            tbShipZip.Text = "";
            tbShipCntry.Text = "";
            //      lbPaymentMethod.Text = "";
            cbPayAmazon.Checked = false;
            cbPayCash.Checked = false;
            cbPayCC.Checked = false;
            cbPayCheque.Checked = false;
            cbPayDC.Checked = false;
            cbPayOther.Checked = false;
            cbPayPP.Checked = false;
            tbOrderTotal.Text = "0.00";
            tbDiscount.Text = "0.00";
            tbTaxVAT.Text = "0.00";
            //tbTaxVAT.Enabled = true;  //  get's disabled when there is a percentage
            tbShipping.Text = "0.00";
            tbPayment.Text = "0.00";
            tbInvoiceTtl.Text = "0.00";
            tbComm.Text = "0.00";
            tbAdj.Text = "0.00";
            lbSoldTo.Items.Clear();
            lbSoldTo.Refresh();
            lbShipTo.Items.Clear();
            lbShipTo.Refresh();

            ListView.ListViewItemCollection invdata = lvShoppingCart.Items;
            foreach (ListViewItem item in invdata)
            {
                item.Remove();
            }
            bAddInvoice.Enabled = true;


        }


        //--------------------------    clear customer detail panel    --------------------------------------
        private void clearCustDetailPanel()
        {
            tbCustID.Text = "";
            tbCustName.Text = "";
            tbBillingName.Text = "";
            tbBillingAddr1.Text = "";
            tbBillingAddr2.Text = "";
            tbBillingCity.Text = "";
            tbBillingState.Text = "";
            tbBillingZip.Text = "";
            tbBillingCntry.Text = "";
            tbShipName.Text = "";
            tbShipAddr1.Text = "";
            tbShipAddr2.Text = "";
            tbShipCity.Text = "";
            tbShipState.Text = "";
            tbShipZip.Text = "";
            tbShipCntry.Text = "";
            tbCustPhone.Text = "";
            tbCustAltPhone.Text = "";
            tbCustEmail.Text = "";
            tbCustGroup.Text = "";
            tbCustContact.Text = "";
            tbCustNotes.Text = "";
            cbSameAsBillingInfo.Checked = false;
        }


        //--------------------------    propogate customer info to invoice    ---------------------
        private void propagateCustToInvoice()
        {
            lbSoldTo.Items.Clear();
            lbShipTo.Items.Clear();

            lbSoldTo.Items.Add(tbBillingName.Text);
            lbSoldTo.Items.Add(tbBillingAddr1.Text);
            if (tbBillingAddr2.Text.Length > 0)
                lbSoldTo.Items.Add(tbBillingAddr2.Text);
            lbSoldTo.Items.Add(tbBillingCity.Text + ", " + tbBillingState.Text + "  " + tbBillingZip.Text);
            lbSoldTo.Items.Add(tbBillingCntry.Text);
            lbSoldTo.Refresh();

            lbShipTo.Items.Add(tbShipName.Text);
            lbShipTo.Items.Add(tbShipAddr1.Text);
            if (tbShipAddr2.Text.Length > 0)
                lbShipTo.Items.Add(tbShipAddr2.Text);
            lbShipTo.Items.Add(tbShipCity.Text + ", " + tbShipState.Text + "  " + tbShipZip.Text);
            lbShipTo.Items.Add(tbShipCntry.Text);
            lbShipTo.Refresh();
        }


        //--------------------------    compute new invoice total    ------------------------
        private void computeNewInvTotal()
        {
            tbInvoiceTtl.Text = "";  //  clear out old stuff
            decimal subAmount = decimal.Parse(tbOrderTotal.Text.ToString().Replace("$",""));
            CultureInfo ci = CultureInfo.CurrentCulture;
            NumberFormatInfo nfi = ci.NumberFormat;

            //  discount
            if (tbDiscount.Text.Length > 0 && tbDiscount.Text != ".")
                subAmount -= decimal.Parse(tbDiscount.Text.ToString().Replace("$", ""));

            //  handle tax
            if ((tbTaxVAT.Text.Length > 0 && tbTaxVAT.Text != ".") || tbTaxPct.Text.Length > 0)
            {
                if (tbTaxPct.Text.Length > 0)  //  handle tax as a percent
                {
                    tbTaxPct.Text = tbTaxPct.Text.Replace("%", "");
                    tbTaxVAT.Enabled = false;
                    tbTaxVAT.Text = (subAmount * (decimal.Parse(tbTaxPct.Text) / 100)).ToString("###.00", nfi);
                    subAmount += decimal.Parse(tbTaxVAT.Text);
                }
                else if (tbTaxVAT.Text.Length > 0)  //  is there a tax amount?
                    subAmount += decimal.Parse(tbTaxVAT.Text.Replace("$", ""));
            }

            //  shipping
            if (tbShipping.Text.Length > 0 && tbShipping.Text != ".")
                subAmount += decimal.Parse(tbShipping.Text.Replace("$", ""));

            //  commission
            if (tbComm.Text.Length > 0 && tbComm.Text != ".")
                subAmount += decimal.Parse(tbComm.Text.Replace("$", ""));

            //  adjustments
            if (tbAdj.Text.Length > 0 && tbAdj.Text != ".")
            {
                if (!tbAdj.Text.Contains("-"))  //  not a negative number
                    subAmount += decimal.Parse(tbAdj.Text.Replace("$", ""));
                else  //  negative amount
                    subAmount -= decimal.Parse(tbAdj.Text.Substring(1));
            }

            //  payments
            if (tbPayment.Text.Length > 0 && tbPayment.Text != ".")
                subAmount -= decimal.Parse(tbPayment.Text.Replace("$", ""));

            //  move computed amount to total field
            tbInvoiceTtl.Text = subAmount.ToString();
        }


        //--------------------------    find highest customer/invoice number    --------------------------------
        public Int64 findHighestNbr(string whichOne)
        {
            string highestNbr;

            //  find the highest invoice number
            //string commandString = "";
            if (whichOne.Contains("invoice"))
                commandString = "select max(tInvoiceNbr) from tInvoice";
            else if (whichOne.Contains("customer"))
                commandString = "select max(tCustNbr) from tCustomer";

            FbDataReader dr = null;
            if (bookConn.State != ConnectionState.Open)
                bookConn.Open();
            FbCommand cmd = new FbCommand(commandString, bookConn);
            dr = cmd.ExecuteReader();
            dr.Read();
            try
            {
                highestNbr = (string)dr[0];
            }
            catch (InvalidCastException)
            {
                highestNbr = "0000";
            }

            dr.Close();

            if (highestNbr.Length > 0 && IsInteger(highestNbr))
                return Int64.Parse(highestNbr);
            else
                return (-1);  //  no valid customer/invoice number currently exists

        }


        //--------------------------    scaling function    ------------------------------------
        RectangleF GetScaledRectangle(float x, float y, RectangleF r)
        {
            RectangleF result = new RectangleF(r.X * x, r.Y * y, r.Width * x, r.Height * y);
            return result;
        }


        //--------------------------    pageSetup    ------------------------------
        private void pageSetup()
        {

            // Initialize the dialog's PrinterSettings property to hold user defined printer settings.
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();

            // Initialize dialog's PrinterSettings property to hold user set printer settings.
            pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();

            //Do not show the network in the printer dialog.
            pageSetupDialog1.ShowNetwork = false;

            //Show the dialog storing the result.
            DialogResult result = pageSetupDialog1.ShowDialog();

        }


        //--------------------------    preview Print Invoice    --------------------------------
        private void previewPrintInvoice()
        {
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = this.printDocument1;
            printPreviewDialog1.FormBorderStyle = FormBorderStyle.Fixed3D;
            printPreviewDialog1.SetBounds(20, 20, 1050, 800);

            printPreviewDialog1.ShowDialog();
        }


        //--------------------------    print Invoice    -----------------------------------
        private void printInvoice()
        {
            if (cbUseReceipt.Checked == false)  //  print an invoice
            {
                printDialog1.Document = this.printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.printDocument1.Print();
                }
            }
            else  //  print a receipt
            {
                //  copy fields from invoice
                lStoreName.Text = tbStoreName.Text;
                lDateTime.Text = dateTimePicker2.Value.ToString();
                lTax.Text = "Tax: " + tbTaxVAT.Text;
                lTotal.Text = "Total: " + tbInvoiceTtl.Text;

                if (cbPayAmazon.Checked == true)
                    lPmtMethod.Text = "Payment Method: Amazon";
                else if (cbPayCash.Checked == true)
                    lPmtMethod.Text = "Payment Method: Cash";
                else if (cbPayCC.Checked == true)
                    lPmtMethod.Text = "Payment Method: Credit Card";
                else if (cbPayCheque.Checked == true)
                    lPmtMethod.Text = "Payment Method: Cheque";
                else if (cbPayDC.Checked == true)
                    lPmtMethod.Text = "Payment Method: Debit Card";
                else if (cbPayPP.Checked == true)
                    lPmtMethod.Text = "Payment Method: PayPal";
                else if (cbPayOther.Checked == true)
                    lPmtMethod.Text = "Payment Method: Other";




                //  now copy the selected listview contents (only col 1 and 3)
                int[] ndxs = { 1, 3 };
               int i = 0;
                string[] newLines = { "","","","","","","","","",""};  //  <----------------------  increase to 25 entries
                    foreach (ListViewItem item in lvShoppingCart.Items)
                    {
                       int j = item.SubItems.Count;
                       string x = item.SubItems[1].Text.Length > 30 ? item.SubItems[1].Text.Substring(0, 30) : item.SubItems[1].Text;
                       newLines[i] = x + "    $" + item.SubItems[3].Text;
                       i++;
                   }

                tbPurchase.Lines = newLines;

                //  now draw the receipt
                printDialog1.Document = this.printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.printDocument1.Print();
                }
            }
        }


        //--------------------------    Invoice drawing routine    ----------------------------------
        //    http://www.c-sharpcorner.com/UploadFile/mgold/PrintingW2Form09162005061136AM/PrintingW2Form.aspx
        private void drawInvoice(Graphics g)
        {
            tbInvoiceDate.Text = dateTimePicker2.Text;

            // Create the source rectangle from the BackgroundImage Bitmap Dimensions
            RectangleF srcRect = new Rectangle(0, 0, gbInvoice.Width, gbInvoice.Height);

            // Create the destination rectangle from the printer settings holding printer page dimensions
            int nWidth = printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.Width;
            int nHeight = printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.Height / 2;
            RectangleF destRect = new Rectangle(0, 0, nWidth, nHeight);

            //  Draw the image scaled to fit on a printed page
            g.DrawImage(gbInvoice.BackgroundImage, destRect, srcRect, GraphicsUnit.Pixel);

            //  Determine the scaling factors of each dimension based on the bitmap and the printed page dimensions
            //  These factors will be used to scale the positioning of the control contents on the printed form
            float scalex = destRect.Width / srcRect.Width;
            float scaley = destRect.Height / srcRect.Height;

            Pen aPen = new Pen(Brushes.Black, 1);

            //  Cycle through each control
            for (int i = 0; i < gbInvoice.Controls.Count; i++)
            {
                //  for debugging --V
                //       MessageBox.Show("i = " + i + "\ncontrol is a: " + gbInvoice.Controls[i].GetType().ToString()
                //         + "\nname: " + gbInvoice.Controls[i].Name);

                // Check if its a TextBox type by comparing to the type of one of the textboxes
                if (gbInvoice.Controls[i].GetType() == tbInvoiceNbr.GetType())
                {
                    // Unbox the Textbox
                    TextBox theText = (TextBox)gbInvoice.Controls[i];

                    // Draw the textbox string at the position of the textbox on the form, scaled to the print page
                    g.DrawString(theText.Text, theText.Font, Brushes.Black, theText.Bounds.Left * scalex, theText.Bounds.Top * scaley, new StringFormat());
                }

                // Check if its a CheckBox type by comparing to the type of one of the checkboxes
                if (gbInvoice.Controls[i].GetType() == cbPayAmazon.GetType())  //  
                {
                    // Unbox the Checkbox
                    CheckBox theCheck = (CheckBox)gbInvoice.Controls[i];

                    // Draw the checkbox rectangle on the form scaled to the print page
                    Rectangle aRect = theCheck.Bounds;
                    g.DrawRectangle(aPen, aRect.Left * scalex - 2, aRect.Top * scaley + 5, aRect.Height * scaley / 2, aRect.Height * scaley / 2);

                    // If the checkbox is checked, Draw the x inside the checkbox on the form scaled to the print page
                    if (theCheck.Checked)
                        g.DrawString("x", theCheck.Font, Brushes.Black, theCheck.Left * scalex, theCheck.Top * scaley + 3, new StringFormat());

                    g.DrawString(theCheck.Text, theCheck.Font, Brushes.Black, theCheck.Bounds.Left * scalex + 15, theCheck.Bounds.Top * scaley + 5, new StringFormat());

                }

                // draw logo
                if (gbInvoice.Controls[i].GetType() == pInvoiceLogo.GetType())
                {
                    if (pInvoiceLogo.Image != null)
                    {
                        GraphicsUnit gu = GraphicsUnit.Pixel;
                        RectangleF scaledRectangle = GetScaledRectangle(scalex, scaley, pInvoiceLogo.Bounds);
                        Image myImage = (Image)pInvoiceLogo.Image.Clone();
                        g.DrawImage(myImage, scaledRectangle, pInvoiceLogo.Image.GetBounds(ref gu), GraphicsUnit.Pixel);
                    }
                }

                Color fillColor = Color.White;

                //  do labels...
                if (gbInvoice.Controls[i].GetType() == label83.GetType())
                {
                    // Unbox the label
                    Label theLabel = (Label)gbInvoice.Controls[i];
                    fillColor = theLabel.BackColor;

                    Rectangle aRect = theLabel.Bounds;
                    g.FillRectangle(new SolidBrush(fillColor), aRect.Left * scalex - 10, aRect.Top * scaley - 5, aRect.Width * scalex, aRect.Height * scaley);

                    g.DrawString(theLabel.Text, theLabel.Font, Brushes.Black, theLabel.Bounds.Left * scalex, theLabel.Bounds.Top * scaley, new StringFormat());
                }

                //  do listboxes
                if (gbInvoice.Controls[i].GetType() == lbShipTo.GetType())
                {
                    if ((string)gbInvoice.Controls[i].Tag == "singleEntry")
                    {
                        ListBox aListBox = (ListBox)gbInvoice.Controls[i];
                        if (aListBox.SelectedItem != null)
                            g.DrawString(aListBox.SelectedItem.ToString(),
                                aListBox.Font,
                                Brushes.Black,
                                aListBox.Bounds.Left * scalex,
                                aListBox.Bounds.Top * scaley,
                                new StringFormat());
                    }
                    else  //  print all the entries
                    {
                        // Unbox the listbox
                        ListBox aListBox = (ListBox)gbInvoice.Controls[i];
                        int itemCount = aListBox.Items.Count;
                        for (int j = 0, k = 0; j < itemCount; j++, k++)
                        {
                            string aString = aListBox.Items[j].ToString();
                            if (aListBox.Items[j].ToString().Length != 0)
                            {
                                g.DrawString(aListBox.Items[j].ToString(),
                                    aListBox.Font,
                                    Brushes.Black,
                                    aListBox.Bounds.Left * scalex,
                                    (aListBox.Bounds.Top + (k * 10)) * scaley,
                                    new StringFormat());
                            }
                            else
                                k--;
                        }
                    }
                }

                // do the date
                if (gbInvoice.Controls[i].GetType() == dateTimePicker2.GetType())
                {
                    //  unbox the date
                    DateTimePicker dt = new DateTimePicker();
                    g.DrawString(dateTimePicker2.Value.ToShortDateString(),
                        dateTimePicker2.Font,
                        Brushes.Black,
                        dateTimePicker2.Bounds.Left * scalex,
                        dateTimePicker2.Bounds.Top * scaley,
                        new StringFormat());

                }

                // do the listview
                if (gbInvoice.Controls[i].GetType() == lvShoppingCart.GetType())
                {
                    //  need to print the subcolumn headers
                    ListView theListView = (ListView)gbInvoice.Controls[i];  //  unbox it...
                    ListView.ColumnHeaderCollection lvcc = theListView.Columns;  //  get the column headers


                    //  print the listview column headings
                    int nextColumnPosition = lvShoppingCart.Bounds.X;
                    for (int columnIndx = 0; columnIndx < lvcc.Count; columnIndx++)
                    {

                        Rectangle aRect = theListView.Bounds;
                        g.FillRectangle(new SolidBrush(fillColor),
                            aRect.Left * scalex,
                            aRect.Top * scaley,
                            aRect.Width * scalex,
                            (aRect.Height / ((lvShoppingCart.Items.Count + 2) * 2)) * scaley);

                        nextColumnPosition += lvShoppingCart.Columns[columnIndx].Width;
                    }

                    nextColumnPosition = lvShoppingCart.Bounds.X;
                    for (int columnIndx = 0; columnIndx < lvcc.Count; columnIndx++)
                    {
                        g.DrawString(lvcc[columnIndx].Text,
                                 lvShoppingCart.Font,
                                Brushes.Black,
                                (nextColumnPosition + 3) * scalex,
                                lvShoppingCart.Bounds.Y * scaley,
                                new StringFormat());

                        nextColumnPosition += lvShoppingCart.Columns[columnIndx].Width;
                    }

                    //  now print the subcolumn data
                    for (int row = 0; row < lvShoppingCart.Items.Count; row++)
                    {
                        nextColumnPosition = lvShoppingCart.Bounds.X;
                        for (int col = 0; col < lvShoppingCart.Items[row].SubItems.Count; col++)
                        {
                            g.DrawString(lvShoppingCart.Items[row].SubItems[col].Text,
                                lvShoppingCart.Items[row].Font,
                                Brushes.Black,
                                (nextColumnPosition + 3) * scalex,
                                (lvShoppingCart.Items[row].Bounds.Y + lvShoppingCart.Bounds.Y) * scaley,
                                new StringFormat());

                            nextColumnPosition += lvShoppingCart.Columns[col].Width;
                        }
                    }
                }
            }


        }


        //--------------------------    receipt drawing routine    ----------------------------------
        private void drawReceipt(Graphics g)
        {
            // Create the source rectangle from the BackgroundImage Bitmap Dimensions
            RectangleF srcRect = new Rectangle(0, 0, receiptPanel.Width, receiptPanel.Height);

            // Create the destination rectangle from the printer settings holding printer page dimensions
            //int nWidth = printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.Width;  //  <-  in hundreths of an inch
            //int nHeight = printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.Height / 2;  //  same here
            int nWidth = int.Parse(tbWidth.Text) * 100;
            int nHeight = 500;
            RectangleF destRect = new Rectangle(0, 0, nWidth, nHeight);

            ////  Draw the image scaled to fit on a printed page
            //g.DrawImage(receiptPanel.BackgroundImage, destRect, srcRect, GraphicsUnit.Pixel);

            //  Determine the scaling factors of each dimension based on the bitmap and the printed page dimensions
            //  These factors will be used to scale the positioning of the control contents on the printed form
            float scalex = destRect.Width / srcRect.Width;
            float scaley = destRect.Height / srcRect.Height;

            Pen aPen = new Pen(Brushes.Black, 1);


            //  Cycle through each control
            for (int i = 0; i < receiptPanel.Controls.Count; i++)
            {
                //  for debugging --V
                //       MessageBox.Show("i = " + i + "\ncontrol is a: " + gbInvoice.Controls[i].GetType().ToString()
                //         + "\nname: " + gbInvoice.Controls[i].Name);

                // Check if its a TextBox type by comparing to the type of one of the textboxes
                if (receiptPanel.Controls[i].GetType() == tbInvoiceNbr.GetType())
                {
                    // Unbox the Textbox
                    TextBox theText = (TextBox)receiptPanel.Controls[i];

                    // Draw the textbox string at the position of the textbox on the form, scaled to the print page
                    g.DrawString(theText.Text, theText.Font, Brushes.Black, theText.Bounds.Left * scalex, theText.Bounds.Top * scaley, new StringFormat());
                }

                Color fillColor = Color.White;

                //  do labels...
                if (receiptPanel.Controls[i].GetType() == label83.GetType())
                {
                    // Unbox the label
                    Label theLabel = (Label)receiptPanel.Controls[i];
                    fillColor = theLabel.BackColor;

                    Rectangle aRect = theLabel.Bounds;
                    g.FillRectangle(new SolidBrush(fillColor), aRect.Left * scalex - 10, aRect.Top * scaley - 5, aRect.Width * scalex, aRect.Height * scaley);

                    g.DrawString(theLabel.Text, theLabel.Font, Brushes.Black, theLabel.Bounds.Left * scalex, theLabel.Bounds.Top * scaley, new StringFormat());
                }

                // do the listview
                //if (receiptPanel.Controls[i].GetType() == lvReceipt.GetType())
                //{
                //    //  need to print the subcolumn headers
                //    ListView theListView = (ListView)receiptPanel.Controls[i];  //  unbox it...
                //    ListView.ColumnHeaderCollection lvcc = theListView.Columns;  //  get the column headers


                //    //  print the listview column headings
                //    int nextColumnPosition = lvReceipt.Bounds.X;
                //    for (int columnIndx = 0; columnIndx < lvcc.Count; columnIndx++)
                //    {

                //        Rectangle aRect = theListView.Bounds;
                //        g.FillRectangle(new SolidBrush(fillColor),
                //            aRect.Left * scalex,
                //            aRect.Top * scaley,
                //            aRect.Width * scalex,
                //            (aRect.Height / ((lvReceipt.Items.Count + 2) * 2)) * scaley);

                //        nextColumnPosition += lvReceipt.Columns[columnIndx].Width;
                //    }

                //    nextColumnPosition = lvReceipt.Bounds.X;
                //    for (int columnIndx = 0; columnIndx < lvcc.Count; columnIndx++)
                //    {
                //        g.DrawString(lvcc[columnIndx].Text,
                //                 lvReceipt.Font,
                //                Brushes.Black,
                //                (nextColumnPosition + 3) * scalex,
                //                lvReceipt.Bounds.Y * scaley,
                //                new StringFormat());

                //        nextColumnPosition += lvReceipt.Columns[columnIndx].Width;
                //    }

                //    //  now print the subcolumn data
                //    for (int row = 0; row < lvReceipt.Items.Count; row++)
                //    {
                //        nextColumnPosition = lvReceipt.Bounds.X;
                //        for (int col = 0; col < lvReceipt.Items[row].SubItems.Count-1; col++)
                //        {
                //            g.DrawString(lvReceipt.Items[row].SubItems[col].Text,
                //                lvReceipt.Items[row].Font,
                //                Brushes.Black,
                //                (nextColumnPosition + 3) * scalex,
                //                (lvReceipt.Items[row].Bounds.Y + lvReceipt.Bounds.Y) * scaley,
                //                new StringFormat());

                //            nextColumnPosition += lvReceipt.Columns[col].Width;
                //        }
                //    }
                //}


            }


        }

#if XML
//-----------------------------------------------------------------------------------------
        private void createXMLFile()
        {
  //          XmlElement rootElem;

            //  create an XML document in memory
            XmlDocument XMLDoc = new XmlDocument();
            XMLDoc.AppendChild(XMLDoc.CreateXmlDeclaration("1.0", "UTF-8", "no"));

            //  create root node
            XmlNode rootElem = XMLDoc.CreateNode("element", "Invoice", null);
            XMLDoc.AppendChild(rootElem);

            //  billing info
            XmlElement billingElem = XMLDoc.CreateElement(null, "BillingInfo", null);
            billingElem.SetAttribute("billingName", null, tbBillingName.Text);
            billingElem.SetAttribute("billingAddr1", null, tbBillingAddr1.Text);
            billingElem.SetAttribute("billingAddr2", null, tbBillingAddr2.Text);
            billingElem.SetAttribute("billingCity", null, tbBillingCity.Text);
            billingElem.SetAttribute("billingState", null, tbBillingState.Text);
            billingElem.SetAttribute("billingZip", null, tbBillingZip.Text);
            billingElem.SetAttribute("billingCntry", null, tbBillingCntry.Text);
            rootElem.AppendChild(billingElem);

            //  shipping info
            XmlElement shippingElem = XMLDoc.CreateElement(null, "ShippingInfo", null);
            shippingElem.SetAttribute("shippingName", null, tbShipName.Text);
            shippingElem.SetAttribute("shippingAddr1", null, tbShipAddr1.Text);
            shippingElem.SetAttribute("shippingAddr2", null, tbShipAddr2.Text);
            shippingElem.SetAttribute("shippingCity", null, tbShipCity.Text);
            shippingElem.SetAttribute("shippingState", null, tbShipState.Text);
            shippingElem.SetAttribute("shippingZip", null, tbShipZip.Text);
            shippingElem.SetAttribute("shippingCntry", null, tbShipCntry.Text);
            rootElem.AppendChild(shippingElem);

            //  order details
            XmlElement invoiceDetails = XMLDoc.CreateElement(null, "invoiceDetails", null);
            invoiceDetails.SetAttribute("orderDate", null, dateTimePicker2.Value.ToShortDateString());
            invoiceDetails.SetAttribute("soldBy", null, tbSoldBy.Text);
            invoiceDetails.SetAttribute("invoiceNbr", null, tbInvoiceNbr.Text);
            invoiceDetails.SetAttribute("paymentMethod", null, lbPaymentMethod.SelectedItem.ToString());
            invoiceDetails.SetAttribute("orderTotal", null, tbOrderTotal.Text);
            invoiceDetails.SetAttribute("discounts", null, tbDiscount.Text);
            invoiceDetails.SetAttribute("taxVAT", null, tbTaxVAT.Text);
            invoiceDetails.SetAttribute("shippingAmt", null, tbShipping.Text);
            invoiceDetails.SetAttribute("invTotal", null, tbInvoiceTtl.Text);
            rootElem.AppendChild(invoiceDetails);

            //  shopping cart
            int itemCount = lvShoppingCart.Items.Count;
            XmlElement shoppingCart = XMLDoc.CreateElement(null, "ShoppingCart", null);
            for (int row = 0; row < itemCount; row++)
            {
                XmlElement lineItem = XMLDoc.CreateElement(null, "lineItem", null);
                lineItem.SetAttribute("bookNumber", null, lvShoppingCart.Items[row].SubItems[0].Text);
                lineItem.SetAttribute("bookTitle", null, lvShoppingCart.Items[row].SubItems[1].Text);
                lineItem.SetAttribute("bookISBN", null, lvShoppingCart.Items[row].SubItems[2].Text);
                lineItem.SetAttribute("bookPrice", null, lvShoppingCart.Items[row].SubItems[3].Text);//           }
                shoppingCart.AppendChild(lineItem);
            }
            rootElem.AppendChild(shoppingCart);

            XMLDoc.Save(invoiceXMLDoc);

        }


//-------------------------------------------------------------------------------------------
        private void readXMLDocument()
        {

            //Create an XmlNodeReader to read the XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load(invoiceXMLDoc);

            XmlNode child = doc.SelectSingleNode("/Invoice/invoiceDetails");
            if (child != null)
            {
                XmlNodeReader nr = new XmlNodeReader(child);
                while (nr.Read())
                    Console.WriteLine(nr.Value);
            }

        }
#endif

    }  //  end partial class
}  //  end namespace