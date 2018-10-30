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
    public partial class FormNovaFirma : Form
    {
        Metode metode = new Metode();
        public FormNovaFirma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = metode.baza_upit("SELECT MAX(ID) +1 AS a FROM            KORISNIK").Rows[0]["a"].ToString();
           string  query = "INSERT INTO KORISNIK (god, id, KORISNIK, MESTO, ZIRO, SIFRADEL, MATBR, REGBR, adresa, filijala, telefon1, odgovornoLice, pib)" +
                             " VALUES        ("+DateTime.Now.Year.ToString() +", "+id+",N'" + tbKorisnik.Text + "',N'" + tbMesto.Text + "',N'" + tbZiro.Text + "',N'" + tbSigraDel.Text + "',N'" + tbMatBroj.Text + "',N'" + tbRegBr.Text + "',N'" + tbAdresa.Text + "',N'" + tbFilijala.Text + "',N'" + tbTelefon.Text + "',N'" + tbOdgLice.Text + "',N'" + tbPIB.Text + "')";
           string poruka = "Uspešno uneto.";

           metode.pristup_bazi(query);
           MessageBox.Show(poruka);
        }
    }
}
