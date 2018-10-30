using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data.SqlClient;
using System.Data;
using System.Configuration;

using System.ComponentModel;

using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using System.Globalization;





namespace MBTransPT
{
    public class Metode
    {

        
        public void pristup_bazi(string query)
        {
            TextReader tr = new StreamReader("c:\\Program files\\IT\\MB\\conn.txt");
            string connection = tr.ReadLine();
            tr.Close();

            SqlConnection myconnection = new SqlConnection(connection);

            myconnection.Open();

            SqlCommand mycommand = new SqlCommand();
            mycommand.CommandText = query;
            mycommand.Connection = myconnection;
            mycommand.ExecuteNonQuery();

            myconnection.Close();
        }

        public DataTable baza_upit(string query)
        {
            TextReader tr = new StreamReader("c:\\Program files\\IT\\MB\\conn.txt");
            string connection = tr.ReadLine();
            tr.Close();

            SqlDataAdapter myAdapterPretraga = new SqlDataAdapter(query, connection);
            DataTable pretraga = new DataTable();
            myAdapterPretraga.Fill(pretraga);

            return pretraga;
        }

        

    }
}
