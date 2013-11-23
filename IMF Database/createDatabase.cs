using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IMF_Database
{
    public partial class Form1 : Form
    {

        //  create the database if necessary
        public void createDatabase()
        {
            Conn.ConnectionString = "Data Source=e:\\temp\\imf.db;New=True;Compress=True;Synchronous=Off";
            Conn.Open();
            Cmd = Conn.CreateCommand();
            Cmd.CommandText = "CREATE TABLE WEO(" +
            "countryCode integer," +
              "ISO varchar (3) ," +
              "subjectCode varchar (10) ," +
              "country varchar (50) ," +
              "subjectDescriptor varchar (50) ," +
              "subjectNotes varchar (500) ," +
              "units varchar (25) ," +
              "scale varchar (25) ," +
              "seriesSpecificNotes varchar (500) ," +
              "yr_1980 real," +
              "yr_1981 real," +
              "yr_1982 real," +
              "yr_1983 real," +
              "yr_1984 real," +
              "yr_1985 real," +
              "yr_1986 real," +
              "yr_1987 real," +
              "yr_1988 real," +
              "yr_1989 real," +
              "yr_1990 real," +
              "yr_1991 real," +
              "yr_1992 real," +
              "yr_1993 real," +
              "yr_1994 real," +
              "yr_1995 real," +
              "yr_1996 real," +
              "yr_1997 real," +
              "yr_1998 real," +
              "yr_1999 real," +
              "yr_2000 real," +
              "yr_2001 real," +
              "yr_2002 real," +
              "yr_2003 real," +
              "yr_2004 real," +
              "yr_2005 real," +
              "yr_2006 real," +
              "yr_2007 real," +
              "yr_2008 real," +
              "yr_2009 real," +
              "yr_2010 real," +
              "yr_2011 real," +
              "yr_2012 real," +
              "yr_2013 real," +
              "yr_2014 real," +
              "yr_2015 real," +
              "estStartAfter varchar (4))";
            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
            Conn.Close();
        }
    }
}