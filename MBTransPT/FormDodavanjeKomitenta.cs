using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Data.SqlClient;
using System.Drawing.Printing;


namespace MBTransPT
{
    public partial class FormDodavanjeKomitenta : Form
    {
        string connection = "";

        public FormDodavanjeKomitenta()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us", false);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us", false);

            TextReader tr = new StreamReader("c:\\Program files\\IT\\MB\\conn.txt");
            connection = tr.ReadLine();
            tr.Close();

            InitializeComponent();
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();

                    string queryUnesi = "INSERT INTO  MATRAD(IMPREZ, ADRESA, MESTO, JMBG, Banka, ZiroRacun, AKT) " +
                                  " VALUES        (N'" + tbImePrez.Text + "',N'" + tbUlica.Text + " " + tbBroj.Text + "',N'" + tbMesto.Text + "',N'" + tbJMBG.Text + "',N'" + tbBanka.Text + "',N'" + tbZiro.Text + "',N'DA')";

                    SqlCommand commUnosi = new SqlCommand();
                    commUnosi.CommandText = queryUnesi;
                    commUnosi.Connection = conn;
                    commUnosi.ExecuteNonQuery();

                    conn.Close();
                }
                MessageBox.Show("Uspešno unet komitent", "Uspešno");
            }
            catch
            {
                MessageBox.Show("Dosšlo je do greške", "Greška");
            }
        }
    }
}
