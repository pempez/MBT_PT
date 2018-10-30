using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MBTransPT
{
    
    public partial class FormNovoLiceRelacija : Form
    {
        Metode metode = new Metode();
        int idRelac = 0;
        public FormNovoLiceRelacija()
        {
            InitializeComponent();
            ucitaj();
        }

        public FormNovoLiceRelacija(int sifLice, int idRelacijeLice,int idRelacija)
        {
            InitializeComponent();

            //ucitavanje
            cbLica.DataSource = metode.baza_upit("select sif, imprez from matrad where sif =" + sifLice +"");
            cbLica.DisplayMember = "imprez";
            cbLica.ValueMember = "sif";

            cbRelacije.DataSource = metode.baza_upit("SELECT RELACIJA.SIFRA_RELACIJE, RELACIJA.POVRATNA,  MESZAJ.NAZIVMZ + ' - ' + MESZAJ_1.NAZIVMZ + ' :' + CONVERT(nvarchar(100), RELACIJA.CENArelacije) + 'din' AS relacija " +
                " FROM            RELACIJA INNER JOIN " +
                  "       MESZAJ ON RELACIJA.Od_mesta = MESZAJ.SIFRAMZ INNER JOIN " +
                   "      MESZAJ AS MESZAJ_1 ON RELACIJA.Do_mesta = MESZAJ_1.SIFRAMZ");
            cbRelacije.DisplayMember = "relacija";
            cbRelacije.ValueMember = "RELACIJA.SIFRA_RELACIJE";
            cbRelacije.SelectedValue = idRelacija;
            btnIzmeni.Visible = true;
            button1.Visible = false;
            idRelac = idRelacijeLice;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            metode.pristup_bazi("INSERT  INTO ISP_LICA_RELACIJE( Id_Relacija, Id_Lice, Aktiv) "+
                                        " VALUES        (" + cbRelacije.SelectedValue + "," + cbLica.SelectedValue + ",1)");

            MessageBox.Show("Uspešno uneto.","Uspesno",MessageBoxButtons.OK);
        }

        private void ucitaj()
        {
            cbLica.DataSource= metode.baza_upit("select sif, imprez from matrad where akt =N'DA'");
            cbLica.DisplayMember = "imprez";
            cbLica.ValueMember = "sif";

            cbRelacije.DataSource = metode.baza_upit("SELECT RELACIJA.SIFRA_RELACIJE, RELACIJA.POVRATNA,  MESZAJ.NAZIVMZ + ' - ' + MESZAJ_1.NAZIVMZ + ' :' + CONVERT(nvarchar(100), RELACIJA.CENArelacije) + 'din' AS relacija " +
                " FROM            RELACIJA INNER JOIN "+
                  "       MESZAJ ON RELACIJA.Od_mesta = MESZAJ.SIFRAMZ INNER JOIN "+
                   "      MESZAJ AS MESZAJ_1 ON RELACIJA.Do_mesta = MESZAJ_1.SIFRAMZ");
            cbRelacije.DisplayMember = "relacija";
            cbRelacije.ValueMember = "RELACIJA.SIFRA_RELACIJE";
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            metode.pristup_bazi("update   ISP_LICA_RELACIJE set Id_Lice =" + cbLica.SelectedValue + ", Id_Relacija = " + cbRelacije.SelectedValue + " " +
                                       " where  id = " + idRelac +" ");

            MessageBox.Show("Uspešno izmenjeno.", "Uspesno", MessageBoxButtons.OK);
            this.Close();
         
        }

      

    }
}
