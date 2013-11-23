#region Using directive
using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;
#endregion

namespace IMF_Database
{
    class importTabDelimitedFiles
    {


        static int rejectedCount = 0;
        SQLiteCommand Cmd = new SQLiteCommand();
        SQLiteConnection Conn = new SQLiteConnection();


        public importTabDelimitedFiles()  //  constructor
        {

        }


        //-------------------------------    convertFile    -----------------------------------------------
        public void convertFile(Label recordsProcessed)
        {

            string inputRecord;
            int count = 0;

            //  create stream reader object 
            System.IO.StreamReader sr = new System.IO.StreamReader(@"F:\downloads\WEOApr2010all.tab");
            sr.ReadLine();  //  get past the first record which contains the header information

            while ((inputRecord = sr.ReadLine()) != null)  //  read a tab-delimited records
            {
                int rc = createDatabaseElements(inputRecord);  //  create data for insert into database
                recordsProcessed.Text = "Records Processed: " + ++count;
                recordsProcessed.Refresh();

                if (rc == -1)
                {
                    return;
                }

                Application.DoEvents();

            }

            Cmd.Dispose();
            Conn.Close();


            sr.Close();  //  close the stream reader
        }


        //---------------------------------    createDatabaseElements    --------------------------------------------------
        private int createDatabaseElements(string inputRecord)
        {

            string[] delimitedData = inputRecord.Split('\t');  //  now split each record into elements
            if (delimitedData.Length == 1)
                return -1;

            Conn.ConnectionString = "Data Source=e:\\temp\\imf.db;Compress=True;Synchronous=Off";
            if (Conn.State == System.Data.ConnectionState.Closed)
                Conn.Open();



            string insertString =
              "insert into WEO (countryCode," +
              "ISO," +
              "subjectCode," +
              "country," +
              "subjectDescriptor," +
              "subjectNotes," +
              "units," +
              "scale," +
              "seriesSpecificNotes," +
              "yr_1980," +
              "yr_1981," +
              "yr_1982," +
              "yr_1983," +
              "yr_1984," +
              "yr_1985," +
              "yr_1986," +
              "yr_1987," +
              "yr_1988," +
              "yr_1989," +
              "yr_1990," +
              "yr_1991," +
              "yr_1992," +
              "yr_1993," +
              "yr_1994," +
              "yr_1995," +
              "yr_1996," +
              "yr_1997," +
              "yr_1998," +
              "yr_1999," +
              "yr_2000," +
              "yr_2001," +
              "yr_2002," +
              "yr_2003," +
              "yr_2004," +
              "yr_2005," +
              "yr_2006," +
              "yr_2007," +
              "yr_2008," +
              "yr_2009," +
              "yr_2010," +
              "yr_2011," +
              "yr_2012," +
              "yr_2013," +
              "yr_2014," +
              "yr_2015," +
              "estStartAfter)" +
                " values ('" +
                delimitedData[0] + "', '" +
                delimitedData[1] + "', '" +
                delimitedData[2] + "', '" +
                delimitedData[3].Replace("'", "''") + "', '" +
                delimitedData[4] + "', '" +
                delimitedData[5].Replace("'", "''") +"', '" +
                delimitedData[6] + "', '" +
                delimitedData[7] + "', '" +
                delimitedData[8].Replace("'", "''") + "', '" +
                delimitedData[9] + "', '" +
                delimitedData[10] + "', '" +
                delimitedData[11] + "', '" +
                delimitedData[12] + "', '" +
                delimitedData[13] + "', '" +
                delimitedData[14] + "', '" +
                delimitedData[15] + "', '" +
                delimitedData[16] + "', '" +
                delimitedData[17] + "', '" +
                delimitedData[18] + "', '" +
                delimitedData[19] + "', '" +
                delimitedData[20] + "', '" +
                delimitedData[21] + "', '" +
                delimitedData[22] + "', '" +
                delimitedData[23] + "', '" +
                delimitedData[24] + "', '" +
                delimitedData[25] + "', '" +
                delimitedData[26] + "', '" +
                delimitedData[27] + "', '" +
                delimitedData[28] + "', '" +
                delimitedData[29] + "', '" +
                delimitedData[30] + "', '" +
                delimitedData[31] + "', '" +
                delimitedData[32] + "', '" +
                delimitedData[33] + "', '" +
                delimitedData[34] + "', '" +
                delimitedData[35] + "', '" +
                delimitedData[36] + "', '" +
                delimitedData[37] + "', '" +
                delimitedData[38] + "', '" +
                delimitedData[39] + "', '" +
                delimitedData[40] + "', '" +
                delimitedData[41] + "', '" +
                delimitedData[42] + "', '" +
                delimitedData[43] + "', '" +
                delimitedData[44] + "', '" +
                delimitedData[45] + "')";


            //System.Data.ConnectionState cs = new System.Data.ConnectionState();
            Cmd = Conn.CreateCommand();
            Cmd.CommandText = insertString;
            Cmd.CommandType = System.Data.CommandType.Text;
            Cmd.ExecuteNonQuery();
            Conn.Close();

            return 0;
        }

    }
}
