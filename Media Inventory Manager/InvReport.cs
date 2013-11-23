using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Text;
using FirebirdSql.Data.FirebirdClient;


namespace Media_Inventory_Manager
{
    class InvReport
    {

        public InvReport()   //  constructor
        {
        }


        //----------------------------------------    create lines for Inventory Report    --------------------------------------
        public void printInvReport(mainForm mf, ListView dataBasePanel, FbConnection mediaConn, string exportPath)
        {
            Cursor.Current = Cursors.WaitCursor;

            //ArrayList alSKU = new ArrayList();
            ArrayList alCheckBoxes = new ArrayList();
            string chosenFields = "";
            mf.lFinished.Visible = false;  //  finished message on report creation page

            //  contents are already in database panel, so get SKU so we can get the record  
            //foreach (ListViewItem item in dataBasePanel.Items)
            //    alSKU.Add(item.Text);  //  put SKU's in arrayList

            //  now build the chosenFields object
            CheckBox cb = null;
            foreach (Control ctl in mf.gbFields.Controls)
            {
                if (ctl.Name == "invRepSelAll")
                    continue;

                cb = (CheckBox)ctl;
                if (cb.Checked)
                {
                    switch (cb.Text)  {  //  or cb.name or whatever gives me the text associated with the cb
                        case "SKU":
                            chosenFields = "SKU, ";
                            break;
                        case "Title":
                            chosenFields += "Title, ";
                            break;
                          case "UPC/ASIN":
                            chosenFields += "UPC, ";
                            break;
                        case "Location":
                            chosenFields += "Locn, ";
                            break;
                        case "Price":
                            chosenFields += "Price, ";
                            break;
                        case "Cost":
                            chosenFields += "Cost, ";
                            break;
                        case "Mfgr":
                            chosenFields += "Mfgr, ";
                            break;
                        case "ASIN":
                            chosenFields += "ASIN, ";
                            break;
                        case "Year Published":
                            chosenFields += "MfgrYear, ";
                            break;
                        case "Private Notes":
                            chosenFields += "PrivNotes, ";
                            break;
                        case "Description":
                            chosenFields += "Descr, ";
                            break;
                        case "Media Condition":
                            chosenFields += "Condn, ";
                            break;
                        case "Edition":
                            chosenFields += "Edition, ";
                            break;
                        case "Media Type":
                            chosenFields += "MediaType, ";
                            break;
                        case "Date Added":
                            chosenFields += "DateA, ";
                            break;
                        case "Date Updated":
                            chosenFields += "DateU, ";
                            break;
                        case "Catalog":
                            chosenFields += "CatalogID, ";
                            break;
                        case "Notes":
                            chosenFields += "Notes, ";
                            break;
                        case "Status":
                            chosenFields += "Stat, ";
                            break;
                        case "Invoice Number":
                            chosenFields += "InvoiceNbr, ";
                            break;
                        case "Quantity":
                            chosenFields += "Quantity, ";
                            break;
                        case "Adult Content":
                            chosenFields += "AdultContent, ";
                            break;
                        default:
                            break;
                    }
                }
            }

            //  remove the last comma
            int indx = chosenFields.LastIndexOf(',');
            if (indx != -1)
                chosenFields = chosenFields.Remove(indx);

            StringBuilder stringBuilder = new StringBuilder();
            TextWriter tw1 = null;

            if (mf.rbIRPrint.Checked)    //  initial output setup
                mf.richTextBox1.Text = chosenFields + "\r\n\r\n";
            else if (mf.rbIRClipBoard.Checked)  //  comma-delimited
                stringBuilder.Append(chosenFields + "\r\n");
            else if (mf.rbIRFile.Checked)  //  comma-delimited
            {
                string sFileName = "";
                sFileName = exportPath + "InvReport.tab";  //  create filename
                tw1 = new StreamWriter(sFileName);
                tw1.WriteLine(chosenFields + "\r\n");  //  now, build and write header line
            }

            //  now, read each item in listview from the table
            if (mediaConn.State == ConnectionState.Closed)
                mediaConn.Open();
            FbDataReader dr = null;
            FbCommand sqlCmd = null;

            //for (int i = 0; i < alSKU.Count; i++) {
                mainForm.commandString = "SELECT " + chosenFields + " FROM tMedia";
               // mainForm.commandString = "SELECT " + chosenFields + " FROM tMedia";
                sqlCmd = new FbCommand(mainForm.commandString, mediaConn);
                dr = sqlCmd.ExecuteReader();

                while (dr.Read())   {   //  create output lines
              
                    if (mf.rbIRPrint.Checked)
                    {
                        string text = "";
                        for (int c = 0; c < dr.FieldCount; c++)
                        {
                            text += dr[c].ToString() + "\t";
                        }
                        mf.richTextBox1.AppendText(text + "\r\n");
                    }
                    else if (mf.rbIRClipBoard.Checked)  //  comma-delimited
                    {
                        string text = "";
                        for (int c = 0; c < dr.FieldCount; c++)
                        {
                            text += dr[c].ToString() + "\t";
                        }
                        stringBuilder.Append(text + "\r\n");
                    }
                    else if (mf.rbIRFile.Checked)  //  comma-delimited
                    {
                        string text = "";
                        for (int c = 0; c < dr.FieldCount; c++)
                        {
                            text += dr[c].ToString() + "\t";
                        }
                        tw1.WriteLine(text + "\r\n");  //  now, build and write header line
                    }
                }
            //}

            //  we're done, so clean it up...
            if (mf.rbIRPrint.Checked)
            {
                mf.printDialog3.Document = mf.printDocument3;
                if (mf.printDialog3.ShowDialog() == DialogResult.OK)
                    mf.printDocument3.Print();
            }
            else if (mf.rbIRClipBoard.Checked)  //  comma-delimited
            {
                Clipboard.SetText(stringBuilder.ToString());
            }
            else if (mf.rbIRFile.Checked)  //  comma-delimited
            {
                tw1.Flush();  //  flush it...
                tw1.Close();  //  and close it...
            }

            dr.Close();  //  close the reader (leave the connection open)

            Cursor.Current = Cursors.Default;
            mf.lFinished.Visible = true;
        }



    }
}
