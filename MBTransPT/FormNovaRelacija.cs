using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;

namespace MBTransPT
{
    public partial class FormNovaRelacija : Form
    {
        string connection = "";
        int sifraRelacije;
        public FormNovaRelacija()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us", false);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us", false);

            TextReader tr = new StreamReader("c:\\Program files\\IT\\MB\\conn.txt");
            connection = tr.ReadLine();
            tr.Close();

            InitializeComponent();

            puni_opstine();
        }

        public FormNovaRelacija(int sifRelacije)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us", false);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us", false);

            TextReader tr = new StreamReader("c:\\Program files\\IT\\MB\\conn.txt");
            connection = tr.ReadLine();
            tr.Close();

            InitializeComponent();
            sifraRelacije = sifRelacije;
            puni_opstine();
            popuni(sifRelacije);
            button1.Text = "Izmeni";
        }

        private void puni_opstine()
        {
            string query = "SELECT SIFRAOP, NAZIVOP, [PROC], ZIRO, IZNOS, IZNPorez, ZIROzaPOREZ, OBRPOREZA, PLACPOREZA, OBRDOPRIN, PLACDOPRIN, OSNOVDOPR, "+
                          "  PROCPOREZA, OKRUG, POKRAJINA, REPUBLIKA, DRŽAVA, SDK FROM            OPST";

            SqlConnection myConnection = new SqlConnection(connection);
            SqlDataAdapter myAdapter = new SqlDataAdapter(query, connection);
            DataTable opst = new DataTable();
            myAdapter.Fill(opst);

            comboBox3.DataSource = opst;
            comboBox3.DisplayMember = "NAZIVOP";
            comboBox3.ValueMember = "SIFRAOP";

            comboBox3.SelectedValue = "212";

            string queryTip = "SELECT        SIFRAMZ, NAZIVMZ, SIFRAOP FROM MESZAJ where sifraop=212";
            SqlConnection myConnectionTip = new SqlConnection(connection);
            SqlDataAdapter myAdapterTip = new SqlDataAdapter(queryTip, connection);
            DataTable Tip = new DataTable();
            myAdapterTip.Fill(Tip);

            comboBox1.DataSource = Tip;
            comboBox1.DisplayMember = "NAZIVMZ";
            comboBox1.ValueMember = "SIFRAMZ";


            string query1 = "SELECT SIFRAOP, NAZIVOP, [PROC], ZIRO, IZNOS, IZNPorez, ZIROzaPOREZ, OBRPOREZA, PLACPOREZA, OBRDOPRIN, PLACDOPRIN, OSNOVDOPR, " +
                          "  PROCPOREZA, OKRUG, POKRAJINA, REPUBLIKA, DRŽAVA, SDK FROM            OPST";

            SqlConnection myConnection1 = new SqlConnection(connection);
            SqlDataAdapter myAdapter1 = new SqlDataAdapter(query1, connection);
            DataTable opst1 = new DataTable();
            myAdapter1.Fill(opst1);

            comboBox4.DataSource = opst1;
            comboBox4.DisplayMember = "NAZIVOP";
            comboBox4.ValueMember = "SIFRAOP";

            comboBox4.SelectedValue = "212";

            string queryTip1 = "SELECT        SIFRAMZ, NAZIVMZ, SIFRAOP FROM MESZAJ where sifraop=212";
            SqlConnection myConnectionTip1 = new SqlConnection(connection);
            SqlDataAdapter myAdapterTip1 = new SqlDataAdapter(queryTip1, connection);
            DataTable Tip1 = new DataTable();
            myAdapterTip1.Fill(Tip1);

            comboBox2.DataSource = Tip1;
            comboBox2.DisplayMember = "NAZIVMZ";
            comboBox2.ValueMember = "SIFRAMZ";


        }

        private void dodaj()
        {
            int povratna = 0;
            if (checkBox2.Checked)
            {
                povratna = 1;
            }
            //int aktivna = 0;
            //if (checkBox1.Checked)
            //{
            //    aktivna = 1;
            //}

            string query = "INSERT  INTO RELACIJA( Od_mesta, Do_mesta, POVRATNA, CENArelacije) "+
                    "VALUES  " +
                    "('" + comboBox1.SelectedValue + "','" + comboBox2.SelectedValue + "'," + povratna + ", '" + textBox1.Text.Replace(",", ".") + "')";

            SqlConnection myConnection = new SqlConnection(connection);
            myConnection.Open();
            SqlCommand mycommand1 = new SqlCommand();
            mycommand1.CommandText = query;
            mycommand1.Connection = myConnection;
            mycommand1.ExecuteNonQuery();
            myConnection.Close();

            MessageBox.Show("Uspešno !!!!");
            this.Close();
        }

        private void popuni( int sifra)
        {
            string queryTip = "SELECT * FROM RELACIJa WHERE SIFRA_RELACIJE = " + sifra;

            SqlConnection myConnectionTip = new SqlConnection(connection);
            SqlDataAdapter myAdapterTip = new SqlDataAdapter(queryTip, connection);
            DataTable Tip = new DataTable();
            myAdapterTip.Fill(Tip);

            foreach (DataRow row in Tip.Rows)
            {
                string queryOpst1 = "select sifraop from  MESZAJ WHERE siframz = " + row["od_mesta"].ToString() + "";

                SqlConnection myConnectionOpst1 = new SqlConnection(connection);
                SqlDataAdapter myAdapterOpst1 = new SqlDataAdapter(queryOpst1, connection);
                DataTable Opst1 = new DataTable();
                myAdapterOpst1.Fill(Opst1);

                comboBox3.SelectedValue = Opst1.Rows[0]["sifraop"].ToString();

                string queryOpst2 = "select sifraop from  MESZAJ WHERE siframz= " + row["do_mesta"].ToString() + "";

                SqlConnection myConnectionOpst2 = new SqlConnection(connection);
                SqlDataAdapter myAdapterOpst2 = new SqlDataAdapter(queryOpst2, connection);
                DataTable Opst2 = new DataTable();
                myAdapterOpst2.Fill(Opst2);

                comboBox4.SelectedValue = Opst2.Rows[0]["sifraop"].ToString();


                comboBox1.SelectedValue = row["od_mesta"].ToString();
                comboBox2.SelectedValue = row["do_mesta"].ToString();

                textBox1.Text = row["cenaRelacije"].ToString();

                //if (row["aktivna"].ToString() == "True")
                //{
                //    checkBox1.Checked = true;
                //}
                //else
                //{
                //    checkBox1.Checked = false;
                //}

                if (row["povratna"].ToString() == "True")
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }
            }
        }

        private void izmeni(int sifra)
        {
            int povratna = 0;
            if (checkBox2.Checked)
            {
                povratna = 1;
            }
         
            string query =  " UPDATE RELACIJA SET  Od_mesta ='" + comboBox1.SelectedValue + "', Do_mesta = '" + comboBox2.SelectedValue + "'," +
                            " POVRATNA = " + povratna + ", CENArelacije = '" + textBox1.Text.Replace(",", ".") + "' where   SIFRA_RELACIJE =" + sifra;

            SqlConnection myConnection = new SqlConnection(connection);
            myConnection.Open();
            SqlCommand mycommand1 = new SqlCommand();
            mycommand1.CommandText = query;
            mycommand1.Connection = myConnection;
            mycommand1.ExecuteNonQuery();
            myConnection.Close();

            MessageBox.Show("Uspešno !!!!");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Izmeni")
            {
                izmeni(sifraRelacije);
            }
            else
            {
                dodaj();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string queryTip1 = "select SIFRAMZ, NAZIVMZ, SIFRAOP from MESZAJ WHERE SIFRAOP = " + comboBox4.SelectedValue + " order by NAZIVMZ";

                SqlConnection myConnectionTip1 = new SqlConnection(connection);
                SqlDataAdapter myAdapterTip1 = new SqlDataAdapter(queryTip1, connection);
                DataTable Tip1 = new DataTable();
                myAdapterTip1.Fill(Tip1);

                comboBox2.DataSource = Tip1;
                comboBox2.DisplayMember = "NAZIVMZ";
                comboBox2.ValueMember = "SIFRAMZ";
            }
            catch
            {
                //
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string queryTip = "select SIFRAMZ, NAZIVMZ, SIFRAOP from MESZAJ WHERE SIFRAOP = " + comboBox3.SelectedValue + " order by NAZIVMZ";

                SqlConnection myConnectionTip = new SqlConnection(connection);
                SqlDataAdapter myAdapterTip = new SqlDataAdapter(queryTip, connection);
                DataTable Tip = new DataTable();
                myAdapterTip.Fill(Tip);

                comboBox1.DataSource = Tip;
                comboBox1.DisplayMember = "NAZIVMZ";
                comboBox1.ValueMember = "SIFRAMZ";
            }
            catch
            {
                //
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                comboBox2.Focus();
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                checkBox2.Focus();
            }
        }

        private void checkBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                comboBox2.Focus();
            }
        }

        private void checkBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        
    }
}
