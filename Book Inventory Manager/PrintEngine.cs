using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Prager_Book_Inventory
{
    public class PrintEngine : PrintDocument
    {

        // members...
        private ArrayList _printObjects = new ArrayList();
        public Font PrintFont = new Font("Courier", 10);
        public Brush PrintBrush = Brushes.Black;
        public PrintElement Header;
        public PrintElement Footer;
        private ArrayList _printElements;
        private int _printIndex = 0;
        private int _pageNum = 0;

        public PrintEngine()
        {
            // create the header...
            Header = new PrintElement(null);
            Header.AddText("Database Listing Report");
            Header.AddText("Page: [pagenum]");
            Header.AddHorizontalRule();
            Header.AddBlankLine();

            // create the footer...
            Footer = new PrintElement(null);
            Footer.AddBlankLine();
            Footer.AddHorizontalRule();
            Footer.AddText("Prager Inventory Program           (c) 2009 Prager, Software. All Rights Reserved");
        }

        // AddPrintObject - add a print object the document...
        public void AddPrintObject(IPrintable printObject)
        {
            _printObjects.Add(printObject);
        }
        // ShowPreview - show a print preview...
        public void ShowPreview()
        {
            // now, show the print dialog...
            PrintPreviewDialog dialog = new PrintPreviewDialog();
            dialog.Document = this;

            // show the dialog...
            dialog.ShowDialog();
        }


        // OnBeginPrint - called when printing starts
        protected override void OnBeginPrint(PrintEventArgs e)
        {
            // reset...
            _printElements = new ArrayList();
            _pageNum = 0;
            _printIndex = 0;

            // go through the objects in the list and create print elements for each one...
            foreach (IPrintable printObject in _printObjects)
            {
                // create an element...
                PrintElement element = new PrintElement(printObject);
                _printElements.Add(element);

                // tell it to print...
                printObject.Print(element);
            }
        }
        // OnPrintPage - called when printing needs to be done...
        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            // adjust the page number...
            _pageNum++;
            
            // now, render the header element...
            float headerHeight = Header.CalculateHeight(this, e.Graphics);
            Header.Draw(this, e.MarginBounds.Top, e.Graphics, e.MarginBounds);
            
            //Drawing the footer is a similar deal, except this has to appear at the bottom of the page:
            // also, we need to calculate the footer height...
            float footerHeight = Footer.CalculateHeight(this, e.Graphics);
            Footer.Draw(this, e.MarginBounds.Bottom - footerHeight, e.Graphics, e.MarginBounds);
            
            // now we know the header and footer, we can adjust the page bounds...
            Rectangle pageBounds = new Rectangle(e.MarginBounds.Left, (int)(e.MarginBounds.Top + headerHeight), e.MarginBounds.Width,
              (int)(e.MarginBounds.Height - footerHeight - headerHeight));
            float yPos = pageBounds.Top;
            
            // ok, now we need to loop through the elements...
            bool morePages = false;
            int elementsOnPage = 0;
            while (_printIndex < _printElements.Count)
            {
                // get the element...
                PrintElement element = (PrintElement)_printElements[_printIndex];
                // how tall is the primitive?
                float height = element.CalculateHeight(this, e.Graphics);

                // will it fit on the page?
                if (yPos + height > pageBounds.Bottom)
                {
                    // we don't want to do this if we're the first thing on the page...
                    if (elementsOnPage != 0)
                    {
                        morePages = true;
                        break;
                    }
                }
                // now draw the element...
                element.Draw(this, yPos, e.Graphics, pageBounds);

                // move the ypos...
                yPos += height;

                // next...
                _printIndex++;
                elementsOnPage++;
            }
            // do we have more pages?
            e.HasMorePages = morePages;
        }

        
        // ReplaceTokens - take a string and remove any tokens replacing them with values...
        public String ReplaceTokens(String buf)
        {
            // replace...
            buf = buf.Replace("[pagenum]", _pageNum.ToString());

            // return...
            return buf;
        }

        // ShowPageSettings - let's us change the page settings...
        public int ShowPageSettings()
        {
            PageSetupDialog setup = new PageSetupDialog();
            PageSettings settings = DefaultPageSettings;
            setup.PageSettings = settings;

            // display the dialog and,
            if (setup.ShowDialog() == DialogResult.OK)
            {
                DefaultPageSettings = setup.PageSettings;
                return 0;
            }
            else
                return -1;
        }

        // ShowPrintDialog - display the print dialog...
        public void ShowPrintDialog()
        {
            // create and show...
            PrintDialog dialog = new PrintDialog();
            dialog.PrinterSettings = PrinterSettings;
            dialog.Document = this;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // save the changes...
                PrinterSettings = dialog.PrinterSettings;

                // do the printing...
                Print();
            }
        } 

    }  //  end class - PrintEngine




    public interface IPrintable
    {
        // Print
        void Print(PrintElement element);
    }

    public interface IPrintPrimitive
    {
        // CalculateHeight - work out how tall the primitive is...
        float CalculateHeight(PrintEngine engine, Graphics graphics);

        // Print - tell the primitive to physically draw itself...
        void Draw(PrintEngine engine, float yPos, Graphics graphics, Rectangle elementBounds);
    }

    public class PrintPrimitiveRule : IPrintPrimitive
    {
        // CalculateHeight - work out how tall the primitive is...
        public float CalculateHeight(PrintEngine engine, Graphics graphics)
        {
            // we're always five units tall...
            return 5;
        }

        // Print - draw the rule...
        public void Draw(PrintEngine engine, float yPos, Graphics graphics, Rectangle elementBounds)
        {
            // draw a line...
            Pen pen = new Pen(engine.PrintBrush, 1);
            graphics.DrawLine(pen, elementBounds.Left, yPos + 2,
                          elementBounds.Right, yPos + 2);
        }
    }

    public class PrintPrimitiveText : IPrintPrimitive
    {
        // members...
        public String Text;

        public PrintPrimitiveText(String buf)
        {
            Text = buf;
        }
        // CalculateHeight - work out how tall the primitive is...
        public float CalculateHeight(PrintEngine engine, Graphics graphics)
        {
            // return the height...
            return engine.PrintFont.GetHeight(graphics);
        }
        // Print - draw the text...
        public void Draw(PrintEngine engine, float yPos, Graphics graphics, Rectangle elementBounds)
        {
            // draw it...
            graphics.DrawString(engine.ReplaceTokens(Text), engine.PrintFont,
            engine.PrintBrush, elementBounds.Left, yPos, new StringFormat());
        }

    }

    public class PrintElement
    {
        // members...
        private ArrayList _printPrimitives = new ArrayList();
        private IPrintable _printObject;

        public PrintElement(IPrintable printObject)
        {
            _printObject = printObject;
        }
        // AddText - add text to the element...
        public void AddText(String buf)
        {
            // add the text...
            AddPrimitive(new PrintPrimitiveText(buf));
        }
        // AddPrimitive - add a primitive to the list...
        public void AddPrimitive(IPrintPrimitive primitive)
        {
            // add it...
            _printPrimitives.Add(primitive);
        }
        // AddData - add data to the element...
        public void AddData(String dataName, String dataValue)
        {
            // add this data to the collection...
            AddText(dataName + ": " + dataValue);
        }

        // AddHorizontalRule - add a rule to the element...
        public void AddHorizontalRule()
        {
            // add a rule object...
            AddPrimitive(new PrintPrimitiveRule());
        }

        // AddBlankLine - add a blank line...
        public void AddBlankLine()
        {
            // add a blank line...
            AddText("");
        }

        // AddHeader - add a header...
        public void AddHeader(String buf)
        {
            AddText(buf);
            AddHorizontalRule();
        }
        public float CalculateHeight(PrintEngine engine, Graphics graphics)
        {
            // loop through the print height...
            float height = 0;
            foreach (IPrintPrimitive primitive in _printPrimitives)
            {
                // get the height...
                height += primitive.CalculateHeight(engine, graphics);
            }

            // return the height...
            return height;
        }
        // Draw - draw the element on a graphics object...
        public void Draw(PrintEngine engine, float yPos, Graphics graphics, Rectangle pageBounds)
        {
            // where...
            float height = CalculateHeight(engine, graphics);
            Rectangle elementBounds = new Rectangle(pageBounds.Left, (int)yPos, pageBounds.Right - pageBounds.Left, (int)height);

            // now, tell the primitives to print themselves...
            foreach (IPrintPrimitive primitive in _printPrimitives)
            {
                // render it...
                primitive.Draw(engine, yPos, graphics, elementBounds);

                // move to the next line...
                yPos += primitive.CalculateHeight(engine, graphics);
            }
        }
    }


    public class ListContentsV : IPrintable
    {
        // members...
        public String bookNumber;
        public String title;
        public String NbrOfCopies;
        public String ISBN;
        public String location;
        public String price;
        public String status;

        // Print...
        public void Print(PrintElement element)
        {
            // tell the engine to draw a header...
          //  element.AddHeader("Contents of List");

            // now, draw the data...
           // element.AddData("Book Nbr", bookNumber);
           // element.AddData("Title", title);
            element.AddData("", bookNumber.PadRight(16,' ') + title);
            element.AddData("ISBN", ISBN.PadRight(16,' ') + "Location: " + location.PadRight(15,' ') + "Price: $" + price.PadRight(10,' ') + "Status: " + status);
            //element.AddData("Location", location);
            //element.AddData("Price", price);
            //element.AddData("Status", status);

            // finally, add a blank line...
            element.AddBlankLine();
        }
    }

    public class ListContentsH : IPrintable
    {
        // members...
        public String detailLine;

        // Print...
        public void Print(PrintElement element)
        {
            // tell the engine to draw a header...
            //   element.AddHeader("Book Number                    Title                                ISBN          Location      Price    Status");

            // now, draw the data...
            element.AddData("", detailLine);

            // finally, add a blank line...
          //  element.AddBlankLine();
        }
    }



}
