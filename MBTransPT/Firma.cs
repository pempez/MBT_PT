using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Threading;

namespace MBTransPT
{
    public partial class Firma : Form
    {
        string connection = "";
        string idFirme = "";
        Metode metode = new Metode();
        public Firma()
        {

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us", false);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us", false);

            TextReader tr = new StreamReader("c:\\Program files\\IT\\MB\\conn.txt");
            connection = tr.ReadLine();
            tr.Close();
            InitializeComponent();

            ucitaj();

            string query = "SELECT  ID, KORISNIK, MESTO, ZIRO, SIFRADEL, MATBR, REGBR, adresa, filijala, telefon1, odgovornoLice, pib, E_mail FROM  KORISNIK";
            SqlDataAdapter myAdapter = new SqlDataAdapter(query, connection);
            DataTable idData = new DataTable();
            myAdapter.Fill(idData);

            if (idData.Rows.Count > 0)
            {
                tbKorisnik.Text = idData.Rows[0]["korisnik"].ToString();
                tbMesto.Text = idData.Rows[0]["MESTO"].ToString();
                tbZiro.Text = idData.Rows[0]["ZIRO"].ToString();
                tbSigraDel.Text = idData.Rows[0]["SIFRADEL"].ToString();
                tbMatBroj.Text = idData.Rows[0]["MATBR"].ToString();
                tbRegBr.Text = idData.Rows[0]["REGBR"].ToString();
                tbAdresa.Text = idData.Rows[0]["adresa"].ToString();
                tbFilijala.Text = idData.Rows[0]["filijala"].ToString();
                tbTelefon.Text = idData.Rows[0]["telefon1"].ToString();
                tbOdgLice.Text = idData.Rows[0]["odgovornoLice"].ToString();
                idFirme = idData.Rows[0]["ID"].ToString();

             
            }

        }
        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void Firma_Load(object sender, EventArgs e)
        {

        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            string query = "";
            string poruka = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {

                    if (idFirme != "")
                    {
                        query = "UPDATE       KORISNIK " +
                                      " SET                KORISNIK =N'" + tbKorisnik.Text + "', MESTO =N'" + tbMesto.Text + "', ZIRO =N'" + tbZiro.Text + "', SIFRADEL =N'" + tbSigraDel.Text + "'," +
                                      " MATBR =N'" + tbMatBroj.Text + "', REGBR =N'" + tbRegBr.Text + "', adresa =N'" + tbAdresa.Text + "', filijala =N'" + tbFilijala.Text + "', telefon1 =N'" + tbTelefon.Text + "', odgovornoLice =N'" + tbOdgLice.Text + "', pib =N'" + tbPIB.Text + "'" +
                                      " where ID =N'" + idFirme + "'";
                        poruka = "Uspešno izmenjeno.";
                    }
                    else
                    {
                        query = "INSERT INTO KORISNIK (KORISNIK, MESTO, ZIRO, SIFRADEL, MATBR, REGBR, adresa, filijala, telefon1, odgovornoLice, pib)" +
                               " VALUES        (N'" + tbKorisnik.Text + "',N'" + tbMesto.Text + "',N'" + tbZiro.Text + "',N'" + tbSigraDel.Text + "',N'" + tbMatBroj.Text + "',N'" + tbRegBr.Text + "',N'" + tbAdresa.Text + "',N'" + tbFilijala.Text + "',N'" + tbTelefon.Text + "',N'" + tbOdgLice.Text + "',N'" + tbPIB.Text + "')";
                        poruka = "Uspešno uneto.";
                    }
                    conn.Open();
                    SqlCommand commUp = new SqlCommand();
                    commUp.Connection = conn;
                    commUp.CommandText = query;
                    commUp.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show(poruka, "Uspešno");
            }
            catch
            {
                MessageBox.Show("Došlo je do greške", "Greška");
            }
        }

        private void ucitaj()
        {
            dataGridView1.DataSource = metode.baza_upit(" SELECT  ID, KORISNIK, MESTO, ZIRO, SIFRADEL, MATBR, REGBR, adresa, filijala, telefon1, odgovornoLice, pib FROM  KORISNIK");
            dataGridView1.Columns["id"].Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();

            DataTable idData = metode.baza_upit("SELECT  ID, KORISNIK, MESTO, ZIRO, SIFRADEL, MATBR, REGBR, adresa, filijala, telefon1, odgovornoLice, pib, E_mail FROM  KORISNIK where id=" + id + "");

            if (idData.Rows.Count > 0)
            {
                tbKorisnik.Text = idData.Rows[0]["korisnik"].ToString();
                tbMesto.Text = idData.Rows[0]["MESTO"].ToString();
                tbZiro.Text = idData.Rows[0]["ZIRO"].ToString();
                tbSigraDel.Text = idData.Rows[0]["SIFRADEL"].ToString();
                tbMatBroj.Text = idData.Rows[0]["MATBR"].ToString();
                tbRegBr.Text = idData.Rows[0]["REGBR"].ToString();
                tbAdresa.Text = idData.Rows[0]["adresa"].ToString();
                tbFilijala.Text = idData.Rows[0]["filijala"].ToString();
                tbTelefon.Text = idData.Rows[0]["telefon1"].ToString();
                tbOdgLice.Text = idData.Rows[0]["odgovornoLice"].ToString();
                tbPIB.Text = idData.Rows[0]["pib"].ToString();
                idFirme = idData.Rows[0]["ID"].ToString();


            }
        }

        private void btnNova_Click(object sender, EventArgs e)
        {
            FormNovaFirma f1 = new FormNovaFirma();
            f1.ShowDialog();
        }
    }
}
