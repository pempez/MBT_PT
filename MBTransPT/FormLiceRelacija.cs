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
    public partial class FormLiceRelacija : Form
    {
        Metode metode = new Metode();
        public FormLiceRelacija()
        {
            InitializeComponent();
            ucitaj();
        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void ucitaj()
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us", false);
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us", false);

            TextReader tr = new StreamReader("c:\\Program files\\IT\\MB\\conn.txt");
            string connection = tr.ReadLine();
            tr.Close();


            string query = "SELECT        dbo.ISP_LICA_RELACIJE.Aktiv, dbo.MATRAD.IMPREZ AS Lice, dbo.RELACIJA.POVRATNA, dbo.RELACIJA.CENArelacije AS Cena, dbo.ISP_LICA_RELACIJE.id, dbo.MESZAJ.NAZIVMZ AS [od mesta],  "+
                       "  MESZAJ_1.NAZIVMZ AS [do mesta], dbo.MATRAD.SIF, dbo.relacija.sifra_relacije " +
                        "  FROM            dbo.ISP_LICA_RELACIJE INNER JOIN "+
                       "    dbo.MATRAD ON dbo.ISP_LICA_RELACIJE.Id_Lice = dbo.MATRAD.SIF INNER  JOIN "+
                       "    dbo.RELACIJA ON dbo.ISP_LICA_RELACIJE.Id_Relacija = dbo.RELACIJA.SIFRA_RELACIJE INNER JOIN "+
                      "     dbo.MESZAJ ON dbo.RELACIJA.Od_mesta = dbo.MESZAJ.SIFRAMZ INNER JOIN "+
                       "    dbo.MESZAJ AS MESZAJ_1 ON dbo.RELACIJA.Do_mesta = MESZAJ_1.SIFRAMZ "+
                        "  WHERE        (dbo.ISP_LICA_RELACIJE.Aktiv = 1) order by dbo.MATRAD.imprez";

            SqlConnection conn = new SqlConnection(connection);
            SqlDataAdapter myAdapter = new SqlDataAdapter(query, conn);
            DataTable tbl = new DataTable();
            myAdapter.Fill(tbl);
            dataGridView1.DataSource = tbl;
            dataGridView1.Columns["Aktiv"].Visible = false;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["sif"].Visible = false;
            dataGridView1.Columns["sifra_relacije"].Visible = false;
            dataGridView1.Columns["Cena"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Cena"].DefaultCellStyle.Format = "N2";
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            

        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            metode.pristup_bazi("DELETE FROM ISP_LICA_RELACIJE WHERE (id = " + dataGridView1.CurrentRow.Cells["id"].Value + ")");
            MessageBox.Show("Uspesno ste obrisali lice iz relacije");
            ucitaj();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FormNovoLiceRelacija f1 = new FormNovoLiceRelacija();
            f1.ShowDialog();

            ucitaj();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            FormNovoLiceRelacija f1 = new FormNovoLiceRelacija(int.Parse(dataGridView1.CurrentRow.Cells["sif"].Value.ToString()), int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString()), int.Parse(dataGridView1.CurrentRow.Cells["sifra_relacije"].Value.ToString()));
            f1.ShowDialog();

            ucitaj();
        }

      
    }
}
