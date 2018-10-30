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
using System.Threading;
using System.Globalization;

namespace MBTransPT
{
    public partial class FormKomitenti : Form
    {
        string connection = "";
        public FormKomitenti()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us", false);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us", false);

            TextReader tr = new StreamReader("c:\\Program files\\IT\\MB\\conn.txt");
            connection = tr.ReadLine();
            tr.Close();

            InitializeComponent();

            ucitaj_komitente();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ucitaj_komitente(txtNaziv.Text);
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string querydelete = "delete from MATRAD where SIF = " + dataGridView1.CurrentRow.Cells["SIF"].Value.ToString() + "";
                SqlCommand commUp = new SqlCommand();
                commUp.Connection = conn;
                commUp.CommandText = querydelete;
                commUp.ExecuteNonQuery();
                conn.Close();
            }
            ucitaj_komitente();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            string naziv = (dataGridView1.CurrentRow.Cells["naziv"].Value.ToString());
            string mesto = (dataGridView1.CurrentRow.Cells["mesto"].Value.ToString());
            string ulica = (dataGridView1.CurrentRow.Cells["ulica"].Value.ToString());
            string broj = (dataGridView1.CurrentRow.Cells["broj"].Value.ToString());
            string racun = (dataGridView1.CurrentRow.Cells["Ziro racun"].Value.ToString());
            string model = (dataGridView1.CurrentRow.Cells["model"].Value.ToString());
            string poziv = (dataGridView1.CurrentRow.Cells["Poziv na broj"].Value.ToString());
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string query = "UPDATE primalac set primalac_naziv = N'" + naziv + "', primalac_mesto = N'" + mesto + "', primalac_ulica = N'" + ulica + "', primalac_broj = N'" + broj + "', primalac_racun = N'" + racun + "', prmalac_model = N'" + model + "', primalac_poziv = N'" + poziv + "' " +
                               " WHERE        (id = " + id + ")";
                SqlCommand commUp = new SqlCommand();
                commUp.Connection = conn;
                commUp.CommandText = query;
                commUp.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FormDodavanjeKomitenta dk = new FormDodavanjeKomitenta();
            dk.ShowDialog();
        }

        private void ucitaj_komitente()
        {
            string query1 = "SELECT SIF, IMPREZ as [IME I PREZIME], ADRESA, MESTO, JMBG, BRLK, Banka, ZiroRacun as [Žiro račun], AKT  as aktivan FROM MATRAD";
            if (rbAktivni.Checked)
            {
                query1 += " where   (AKT = N'DA') ";
            }
            if (rbSvi.Checked)
            {
               
            }
            if (rbNeaktivni.Checked)
            {
                query1 += " where   (AKT = N'NE') ";
            }

            query1 += " order by imprez";
            SqlDataAdapter myAdapter1 = new SqlDataAdapter(query1, connection);
            DataTable idData1 = new DataTable();

            myAdapter1.Fill(idData1);
            dataGridView1.DataSource = idData1;
            //dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView1.Columns["SIF"].Visible = false;


        }
        private void ucitaj_komitente(string naziv)
        {
            string query1 = "SELECT SIF, IMPREZ as [IME I PREZIME], ADRESA, MESTO, JMBG, BRLK, Banka, ZiroRacun as [Žiro račun], AKT  as aktivan FROM MATRAD" +
                            " WHERE        (IMPREZ LIKE N'%" + naziv + "%')";

            SqlDataAdapter myAdapter1 = new SqlDataAdapter(query1, connection);
            DataTable idData1 = new DataTable();

            myAdapter1.Fill(idData1);
            dataGridView1.DataSource = idData1;
            //dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView1.Columns["SIF"].Visible = false;


        }
        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void dataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            int sif = int.Parse(dataGridView1.CurrentRow.Cells["sif"].Value.ToString());
            string IMPREZ = (dataGridView1.CurrentRow.Cells["IME I PREZIME"].Value.ToString());
            string ADRESA = (dataGridView1.CurrentRow.Cells["ADRESA"].Value.ToString());
            string MESTO = (dataGridView1.CurrentRow.Cells["MESTO"].Value.ToString());
            string JMBG = (dataGridView1.CurrentRow.Cells["JMBG"].Value.ToString());
            string BRLK = (dataGridView1.CurrentRow.Cells["BRLK"].Value.ToString());
            string Banka = (dataGridView1.CurrentRow.Cells["Banka"].Value.ToString());
            string ZiroRacun = (dataGridView1.CurrentRow.Cells["Žiro račun"].Value.ToString());
            string AKT = (dataGridView1.CurrentRow.Cells["aktivan"].Value.ToString());
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string query = "UPDATE  MATRAD SET   IMPREZ =N'" + IMPREZ + "', ADRESA =N'" + ADRESA + "', MESTO =N'" + MESTO + "', JMBG =N'" + JMBG + "', " +
                                " BRLK =N'" + BRLK + "', Banka =N'" + Banka + "', ZiroRacun =N'" + ZiroRacun + "', AKT = N'" + AKT + "'" +
                                " WHERE        (sif = " + sif + ")";
                SqlCommand commUp = new SqlCommand();
                commUp.Connection = conn;
                commUp.CommandText = query;
                commUp.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ucitaj_komitente();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ucitaj_komitente();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ucitaj_komitente();
        }

    }
}
