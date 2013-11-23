using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLite_Database_Manager
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            test();
        }
        public void test()
        {
            SQLiteConnection Conn = new SQLiteConnection();
            Conn.ConnectionString = "Data Source=e:\\temp\\diary.db;New=True;Compress=True;Synchronous=Off";
            Conn.Open();
            SQLiteCommand Cmd = new SQLiteCommand();
            Cmd = Conn.CreateCommand();
            //Cmd.CommandText = "drop database (diary.db)";
            //Cmd.ExecuteNonQuery();
            Cmd.CommandText = "CREATE TABLE GOALS(GOALS_ID integer primary key , CATEGORY varchar (50), PRIORITY integer , SUBJECT varchar (150) , DESCRIPTION varchar (500),START_DATE datetime , COMPLETION_DATE datetime)";
            Cmd.ExecuteNonQuery();
            Cmd.CommandText = "CREATE TABLE NOTES (NOTES_ID integer primary key ,NOTES_DATE datetime ,NOTES_TEXT varchar (8000) )";
            Cmd.ExecuteNonQuery();
            Cmd.CommandText = " CREATE TABLE REMINDERS (REMINDER_ID integer primary key ,REMINDER_DATE smalldatetime ,SUBJECT varchar (150) ,DESCRIPTION varchar (500) , ALARM1_DATE datetime ,ALARM2_DATE datetime ,ALARM3_DATE datetime ,EMAIL_ALARM bit )";
            Cmd.ExecuteNonQuery();
            Cmd.CommandText = "CREATE TABLE TODO ( TODO_ID integer primary key,CATEGORY varchar (20),PRIORITY int, PERCENT_COMPLETE float, START_DATE datetime ,END_DATE datetime , SUBJECT varchar (150) , DETAILS varchar (8000)) ";
            Cmd.ExecuteNonQuery();
            Cmd.CommandText = "CREATE TABLE CATEGORIES (CATEGORY_ID INTEGER PRIMARY KEY,CATEGORY_NAME varchar (25))";
            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
            Conn.Close();
        }
    }
}
