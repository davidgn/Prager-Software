using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using FirebirdSql.Data.FirebirdClient;


namespace Prager_Book_Inventory
{

    partial class mainForm : Form
    {

        //----------------------------    preview print    --------------------------
        private void previewInclusiveSearchResults()
        {
            string[] vals = { "", "", "", "", "", "", "" };
            PrintEngine _engine = new PrintEngine();
            foreach (ListViewItem lvi in dataBasePanel.Items)
            {
                ListContentsV lc = new ListContentsV();
                ListViewItem.ListViewSubItemCollection items = lvi.SubItems;
                lc.bookNumber = items[0].Text;
                lc.title = items[1].Text;
                lc.NbrOfCopies = items[2].Text;
                lc.ISBN = items[3].Text.ToString().PadRight(21, ' ');
                lc.location = items[4].Text;
                lc.price = items[5].Text;
                lc.status = items[6].Text;
                _engine.AddPrintObject(lc);  //  add item to the list to print
            }

            if (_engine.ShowPageSettings() == 0)  //  allow user to change page settings
                _engine.ShowPreview();
        }



        //-------------------------    print Database Panel listview    ---------------------------
        private void printInclusiveSearchResults()
        {
            string[] vals = { "", "", "", "", "", "", "" };
            PrintEngine _engine = new PrintEngine();
            foreach (ListViewItem lvi in dataBasePanel.Items)
            {
                ListContentsV lc = new ListContentsV();
                ListViewItem.ListViewSubItemCollection items = lvi.SubItems;
                lc.bookNumber = items[0].Text;
                lc.title = items[1].Text;
                lc.NbrOfCopies = items[2].Text;
                lc.ISBN = items[3].Text.ToString().PadRight(21, ' ');
                lc.location = items[4].Text;
                lc.price = items[5].Text;
                lc.status = items[6].Text;
                _engine.AddPrintObject(lc);  //  add item to the list to print
            }

            _engine.ShowPrintDialog();  //  allow user to change page settings
            if (_engine.ShowPageSettings() == 0)  //  allow user to change page settings
                _engine.Print();

        }


        //--------------------------------------------------------------------------------------------
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Color fillColor;
            fillColor = dataBasePanel.BackColor;

            // Create the source rectangle from the BackgroundImage Bitmap Dimensions
            printDocument2.DefaultPageSettings.Landscape = true;

            int nWidth = dataBasePanel.Width;
            //            int nHeight = listView3.Height;
            //            int nWidth = printDocument2.PrinterSettings.DefaultPageSettings.PaperSize.Width;
            int nHeight = printDocument2.PrinterSettings.DefaultPageSettings.PaperSize.Height;
            RectangleF srcRect = new Rectangle(0, 0, nWidth, nHeight);

            // Create the destination rectangle from the printer settings holding printer page dimensions
            nWidth = printDocument2.PrinterSettings.DefaultPageSettings.PaperSize.Width;
            nHeight = printDocument2.PrinterSettings.DefaultPageSettings.PaperSize.Height;
            RectangleF destRect = new Rectangle(0, 0, nWidth, nHeight);

            //  Determine the scaling factors of each dimension based on the bitmap and the printed page dimensions
            //  These factors will be used to scale the positioning of the control contents on the printed form
            float scalex = destRect.Width / srcRect.Width;
            float scaley = destRect.Height / srcRect.Height;

            Pen aPen = new Pen(Brushes.Black, 1);

            //  need to print the subcolumn headers
            ListView theListView = dataBasePanel;  //  unbox it...
            ListView.ColumnHeaderCollection lvcc = theListView.Columns;  //  get the column headers


            //  print the listview column headings
            int nextColumnPosition = dataBasePanel.Bounds.X;
            for (int columnIndx = 0; columnIndx < lvcc.Count; columnIndx++)
            {

                Rectangle aRect = theListView.Bounds;

                g.FillRectangle(new SolidBrush(fillColor),
                    aRect.Left * scalex,
                    aRect.Top * scaley,
                    aRect.Width * scalex,
                    (aRect.Height / ((dataBasePanel.Items.Count + 2) * 2)) * scaley);

                nextColumnPosition += dataBasePanel.Columns[columnIndx].Width;
            }

            nextColumnPosition = dataBasePanel.Bounds.X;
            for (int columnIndx = 0; columnIndx < lvcc.Count; columnIndx++)
            {
                g.DrawString(lvcc[columnIndx].Text,
                         dataBasePanel.Font,
                        Brushes.Black,
                        (nextColumnPosition + 3) * scalex,
                        dataBasePanel.Bounds.Y * scaley,
                        new StringFormat());

                nextColumnPosition += dataBasePanel.Columns[columnIndx].Width;
            }

            //  now print the subcolumn data
            for (int row = 0; row < dataBasePanel.Items.Count; row++)
            {
                nextColumnPosition = dataBasePanel.Bounds.X;
                for (int col = 0; col < dataBasePanel.Items[row].SubItems.Count; col++)
                {
                    g.DrawString(dataBasePanel.Items[row].SubItems[col].Text,
                        dataBasePanel.Items[row].Font,
                        Brushes.Black,
                        (nextColumnPosition + 3) * scalex,
                        (dataBasePanel.Items[row].Bounds.Y + dataBasePanel.Bounds.Y) * scaley,
                        new StringFormat());

                    nextColumnPosition += dataBasePanel.Columns[col].Width;
                }
            }
        }


        //----------    print routines for any generic object (ie listbox)    ----------------------
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintControlToGraphics(lbRejectedRecords, e.Graphics, e.MarginBounds);
        }

        private void PrintControlToGraphics(Control control, Graphics graphics, Rectangle bounds)
        {
            Bitmap bitmap = new Bitmap(control.Width / 2, control.Height / 2); 
            control.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));

            Rectangle target = new Rectangle(0, 0, bounds.Width, bounds.Height);
            double xScale = (double)bitmap.Width / bounds.Width;
            double yScale = (double)bitmap.Height / bounds.Height;

            if (xScale < yScale)
                target.Width = (int)(xScale * target.Width / yScale);
            else
                target.Height = (int)(yScale * target.Height / xScale);

            graphics.PageUnit = GraphicsUnit.Display;
            graphics.DrawImage(bitmap, target);
        }


    }

}