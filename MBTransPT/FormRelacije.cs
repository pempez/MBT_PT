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
    public partial class FormRelacije : Form
    {
        string connection = "";
        Metode metode = new Metode();
        public FormRelacije()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us", false);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us", false);

            TextReader tr = new StreamReader("c:\\Program files\\IT\\MB\\conn.txt");
            connection = tr.ReadLine();
            tr.Close();

            InitializeComponent();
            ucitaj();
        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormNovaRelacija fp = new FormNovaRelacija();
            fp.ShowDialog();

            ucitaj();
        }

        private void ucitaj()
        {
            string query = "SELECT        dbo.RELACIJA.SIFRA_RELACIJE,dbo.MESZAJ.NAZIVMZ AS [Od mesta] , MESZAJ_1.NAZIVMZ  AS [Do mesta],  dbo.RELACIJA.CENArelacije as [Cena], dbo.RELACIJA.POVRATNA " +
                           " FROM            dbo.MESZAJ INNER JOIN dbo.RELACIJA ON dbo.MESZAJ.SIFRAMZ = dbo.RELACIJA.Od_mesta INNER JOIN "+
                           " dbo.MESZAJ AS MESZAJ_1 ON dbo.RELACIJA.Do_mesta = MESZAJ_1.SIFRAMZ INNER JOIN "+
                           "  dbo.OPST AS OPST_1 ON MESZAJ_1.SIFRAOP = OPST_1.SIFRAOP INNER JOIN "+
                           " dbo.OPST ON dbo.MESZAJ.SIFRAOP = dbo.OPST.SIFRAOP";

            SqlConnection conn = new SqlConnection(connection);
            SqlDataAdapter myAdapter = new SqlDataAdapter(query, conn);
            DataTable tbl = new DataTable();
            myAdapter.Fill(tbl);
            dataGridView1.DataSource = tbl;
            dataGridView1.Columns["SIFRA_RELACIJE"].Visible = false;
            dataGridView1.Columns["Cena"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Cena"].DefaultCellStyle.Format = "N2";
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                FormNovaRelacija fpo = new FormNovaRelacija(int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()));
                fpo.ShowDialog();

                ucitaj();
            }
            catch
            {
                //
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            string del = "DELETE FROM  RELACIJA WHERE        (SIFRA_RELACIJE = " + int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString()) + ")";
            metode.pristup_bazi(del);
            ucitaj();
        }
    }
}
