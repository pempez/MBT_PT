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
    public partial class FormNoviNalog : Form
    {
        Metode metode = new Metode();
        int godina = DateTime.Now.Year;
        string ziroFirme = "";
        string firmaNaziv = "";
        public FormNoviNalog()
        {
            InitializeComponent();
            inicijalizacija();
            ucitajFirme();
            tbGodina.Text = godina.ToString();
            tbBrojNaloga.Text = metode.baza_upit("SELECT max(redni_broj) +1 as br FROM  ISP_NALOG where godina = " + godina + "").Rows[0]["br"].ToString();
            dateTimePicker1.Value = DateTime.Now;
        }

        public FormNoviNalog(int idNalog)
        {
            InitializeComponent();
            inicijalizacija();
            ucitajFirme();

            DataTable dt = metode.baza_upit("SELECT datum FROM ISP_NALOG WHERE  id = " + idNalog + "");
            dateTimePicker1.Value = DateTime.Parse(dt.Rows[0]["datum"].ToString());
            

            prikaz(idNalog);
            tbBrojNaloga.Enabled = false;
            tbGodina.Enabled = false;
            tbMesec.Enabled = false;
            btnPreuzmiAktivna.Enabled = false;
            btnDodajStavku.Visible = true;
            btnUnesiNalog.Visible = false;

            
        }

        public FormNoviNalog(string drugiNalog)
        {
            InitializeComponent();
            inicijalizacija();

            ucitajFirme();

            tbGodina.Text = godina.ToString();
            tbBrojNaloga.Text = metode.baza_upit("SELECT max(redni_broj) +1 as br FROM  ISP_NALOG where godina = " + godina + "").Rows[0]["br"].ToString();
            dateTimePicker1.Value = DateTime.Now;
            btnPreuzmiAktivna.Visible = false;
            btnUnesiNalog.Visible = true;
        }

        private void ucitajFirme()
        {
            cbFirma.DataSource = metode.baza_upit(" SELECT  ID, KORISNIK+ ' ' + ZIRO as disp, SIFRADEL, MATBR, REGBR, adresa, filijala, telefon1, odgovornoLice, pib FROM  KORISNIK");
            cbFirma.DisplayMember = "disp";
            cbFirma.ValueMember = "id";
        }

        private void btnPreuzmiAktivna_Click(object sender, EventArgs e)
        {
            if (tbGodina.Text == "" || tbMesec.Text == "")
            {
                MessageBox.Show("Unesite mesec i godinu");
                return;
            }
            godina = int.Parse(tbGodina.Text);
            int mesec = int.Parse(tbMesec.Text);
            //unosi novi nalog
            string unesiNoviNalog = "INSERT    INTO  ISP_NALOG(  redni_broj, datum,   zat_otv, svrha_isplate, sifra_placanja, " +
                         " mesec, godina) " +
                        " VALUES        (" + metode.baza_upit("select ISNULL(MAX(redni_broj), 0) + 1 AS br from isp_nalog where (godina = " + godina + ")").Rows[0]["br"].ToString() + ",getdate(),0,N'putni trosak',240," + mesec + "," + godina + ")";

            metode.pristup_bazi(unesiNoviNalog);

            //uzima id novog naloga
            int idNalog = int.Parse(metode.baza_upit("select max(id) as id from isp_nalog where godina = " + godina + "").Rows[0]["id"].ToString());

            //unos stavke za svako lice koje ima definisanu aktivnu relaciju i koje ja aktvno
            string queryUnesi = "SELECT        dbo.ISP_LICA_RELACIJE.Id_Relacija, dbo.ISP_LICA_RELACIJE.Id_Lice, dbo.MATRAD.IMPREZ, dbo.RELACIJA.CENArelacije, dbo.ISP_LICA_RELACIJE.Aktiv, dbo.MATRAD.JMBG " +
                                  " FROM            dbo.ISP_LICA_RELACIJE INNER JOIN " +
                                " dbo.RELACIJA ON dbo.ISP_LICA_RELACIJE.Id_Relacija = dbo.RELACIJA.SIFRA_RELACIJE INNER JOIN " +
                        "  dbo.MATRAD ON dbo.ISP_LICA_RELACIJE.Id_Lice = dbo.MATRAD.SIF " +
                                " WHERE        (dbo.ISP_LICA_RELACIJE.Aktiv = 1) and  dbo.MATRAD.AKT= N'DA'";

            DataTable dtStavke = metode.baza_upit(queryUnesi);
            int i = 1;
            foreach (DataRow r in dtStavke.Rows)
            {
               
                string insert = " INSERT INTO ISP_STAVKE( ID_NALOGA, ISPL_STAVKA, ID_KOMITENTA,  NETO,  Upisan, svrha) "+
                                " VALUES        (" + idNalog + ",   " + i + ",  " + r["id_lice"].ToString() + ",    " + r["cenarelacije"].ToString().Replace(",",".") + "    ,getdate(), N'putni trosak')";
                metode.pristup_bazi(insert);
                i++;
            }
            azurirajIznosNaloga(idNalog);
            prikaz(idNalog);
            btnDodajStavku.Visible = true;
            MessageBox.Show("Uspesno preuzeta aktuelna lica za putni trosak.");

        }

        private void prikaz(int idNalog)
        {
            dgvStavke.DataSource = metode.baza_upit("SELECT        dbo.MATRAD.SIF, dbo.ISP_STAVKE.id, dbo.ISP_STAVKE.ISPL_STAVKA AS [Redni broj], dbo.MATRAD.IMPREZ as [Lice] , dbo.isp_stavke.dnevnica as Dnevnice, "+
                                             " dbo.isp_stavke.refundacija as [Refundacija troskova],  dbo.isp_stavke.neto as [Iznos]  " +
                        " FROM            dbo.ISP_STAVKE INNER JOIN"+
                      "   dbo.MATRAD ON dbo.ISP_STAVKE.ID_KOMITENTA = dbo.MATRAD.SIF where dbo.ISP_STAVKE.ID_NALOGA = " + idNalog + " order by     dbo.ISP_STAVKE.ISPL_STAVKA");

            //dgvStavke.AutoSize = true;
            dgvStavke.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvStavke.Columns["id"].Visible = false;
            dgvStavke.Columns["SIF"].Visible = false;
            DataTable dt = metode.baza_upit(" select korisnik, mesec, godina,redni_broj from isp_nalog where id=" + idNalog + "");
            tbMesec.Text = dt.Rows[0]["mesec"].ToString();
            tbGodina.Text = dt.Rows[0]["godina"].ToString();
            tbBrojNaloga.Text = dt.Rows[0]["redni_broj"].ToString();
            cbFirma.SelectedValue = dt.Rows[0]["korisnik"].ToString();
         

            DataTable dtSum=  metode.baza_upit("SELECT SUM(NETO) AS ukupno,  sum(refundacija) as refund, sum(dnevnica) as dnevnica FROM  ISP_STAVKE WHERE   (ID_NALOGA = " + idNalog + ")");
            lblUkupno.Text = "Dnevnice: " + dtSum.Rows[0]["dnevnica"].ToString() + "         Refundacija troskova: " + dtSum.Rows[0]["refund"].ToString() + "           UKUPNO: " + dtSum.Rows[0]["ukupno"].ToString() + "";
        }

        private void azurirajIznosNaloga(int idNalog)
        {
            double ukupno = double.Parse(metode.baza_upit("SELECT SUM(NETO) AS ukupno FROM  ISP_STAVKE WHERE   (ID_NALOGA = " + idNalog + ")").Rows[0]["ukupno"].ToString());

            metode.pristup_bazi("UPDATE  ISP_NALOG SET            neto_iznos = " + ukupno.ToString().Replace(",", ".") + " WHERE        (id = " + idNalog + ")");
        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void btnDodajStavku_Click(object sender, EventArgs e)
        {
            gbNovaStavka.Visible = true;
            btnIzmeni.Visible = false;
            btnUnesi.Visible = true;
            tbRedndacija.Text = "0";
            tbIznos.Text = "0";
            cbLice.SelectedIndex = 0;
        
        }

        private void cbLice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLice.Text != "System.Data.DataRowView")
            {
                cbZiro.DataSource = metode.baza_upit(" SELECT  SIF, IMPREZ, ADRESA, MESTO, JMBG, BRLK, Banka, ZiroRacun, AKT " +
                                                     " FROM MATRAD WHERE IMPREZ=N'" + cbLice.Text + "' order by imprez");
                cbZiro.DisplayMember = "ZiroRacun";
                cbZiro.ValueMember = "Sif";
             
            }
            else
            {
            }
        }

        private void tbBrojNaloga_Leave(object sender, EventArgs e)
        {
            try
            {
                int idNalog = vratiIdNaloga(int.Parse(tbBrojNaloga.Text), godina);// (int.Parse(metode.baza_upit("select id from isp_nalog where redni_broj = " + tbBrojNaloga.Text + " and godina = " + godina + "").Rows[0]["id"].ToString()));
              
                prikaz(int.Parse(metode.baza_upit("select id from isp_nalog where redni_broj = " + tbBrojNaloga.Text + " and godina = " + godina + "").Rows[0]["id"].ToString()));
                //DataTable dt = metode.baza_upit(" select mesec, godina from isp_nalog where id=" + idNalog + "");
                //tbMesec.Text = dt.Rows[0]["mesec"].ToString();
                //tbGodina.Text = dt.Rows[0]["godina"].ToString();
                btnPreuzmiAktivna.Enabled = false;
                btnDodajStavku.Visible = true;
                btnUnesiNalog.Visible = false;
            }
            catch
            {
                dgvStavke.DataSource = null;
                btnPreuzmiAktivna.Enabled = true;
                gbNovaStavka.Visible = false;
                btnUnesiNalog.Visible = true;
                btnDodajStavku.Visible = false;

              //  tbMesec.Text = "";
              //  tbGodina.Text="";
            }
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            if (ziroFirme == "")
            {
                DataTable dtFir = metode.baza_upit("SELECT   KORISNIK + ' ' + MESTO + ', ' + adresa AS FIRMA, ZIRO FROM KORISNIK where id="+cbFirma.SelectedValue.ToString()+"");
                ziroFirme = dtFir.Rows[0]["ZIRO"].ToString();
                firmaNaziv = dtFir.Rows[0]["FIRMA"].ToString();
            }
            int idNalog = vratiIdNaloga(int.Parse(tbBrojNaloga.Text), int.Parse(tbGodina.Text));
            string brStavke = metode.baza_upit(" select max (ispl_stavka) +1 as br from isp_stavke where id_naloga = " + idNalog + "").Rows[0]["br"].ToString();
            if (brStavke == "") brStavke = "1";
            double neto = double.Parse(tbIznos.Text.Replace(",", ".")) + double.Parse(tbRedndacija.Text.Replace(",", "."));
            tbUkupno.Text = neto.ToString();
            string insert =
                "INSERT INTO  ISP_STAVKE( ID_NALOGA, ISPL_STAVKA, ID_KOMITENTA, dnevnica, refundacija,  NETO) " +
                            " VALUES        (" + idNalog + "," + brStavke + "," + cbLice.SelectedValue + ",'" + tbIznos.Text.Replace(",", ".") + "', '" + tbRedndacija.Text.Replace(",", ".") + "', " + tbIznos.Text.Replace(",", ".") + " + "+ tbRedndacija.Text.Replace(",", ".") + ");" +//'" + tbUkupno.Text.Replace(",", ".") + "'); " +
                            " update isp_nalog set neto_iznos = isnull(neto_iznos,0) + " + tbIznos.Text.Replace(",", ".") + " + " + tbRedndacija.Text.Replace(",", ".") + " where id = " + idNalog + "; " +
                            " INSERT INTO ISP_VIRMANI( idNalog, duznik, svrha_placanja, poverilac, sifra_placanja, iznos, racun_duznika, poziv_zaduzenje, racun_poverioca, poziv_odobrenje, model2) "+
                            " VALUES                 (" + idNalog + ",N'" + firmaNaziv + "',N'OSTALI PRIHODI FIZICKIH LICA',N'" + cbLice.Text + "',241, " + tbIznos.Text.Replace(",", ".") + " + " + tbRedndacija.Text.Replace(",", ".") + ",N'" + ziroFirme + "','',N'" + cbZiro.Text + "','','')";
            metode.pristup_bazi(insert);
            prikaz(idNalog);
            tbRedndacija.Text = "0";
            tbIznos.Text = "0";
            cbLice.SelectedIndex = 0;
            try
            {
                dgvStavke.CurrentRow.Selected = false;
            }
            catch { }
          //  MessageBox.Show("Uspesno uneto");
        }

        private void tbGodina_Leave(object sender, EventArgs e)
        {
            if (godina != int.Parse(tbGodina.Text))
            {
                godina = int.Parse(tbGodina.Text);
                tbBrojNaloga.Text = "1";
                tbBrojNaloga_Leave(null, null);

            }
        }

        private int vratiIdNaloga(int brNaloga, int godinaNaloga)
        {
            DataTable dt = metode.baza_upit("select id from isp_nalog where redni_broj = " + brNaloga + " and " +
                                               " godina = " + godinaNaloga + "");
            if (dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["id"].ToString());
            }
            else
            {
                //string unesiNoviNalog = "INSERT    INTO  ISP_NALOG(  redni_broj, datum,   zat_otv, svrha_isplate, sifra_placanja, " +
                //        " mesec, godina) " +
                //       " VALUES        (" + metode.baza_upit("select ISNULL(MAX(redni_broj), 0) + 1 AS br from isp_nalog where (godina = " + godina + ")").Rows[0]["br"].ToString() + ",getdate(),0,N'putni trosak',240," + mesec + "," + godina + ")";

                //metode.pristup_bazi(unesiNoviNalog);

                ////uzima id novog naloga
                //return int.Parse(metode.baza_upit("select max(id) as id from isp_nalog where godina = " + godina + "").Rows[0]["id"].ToString());
                return 1;

            }
        }

        private void btnObrisiStavku_Click(object sender, EventArgs e)
        {
            if (dgvStavke.Rows.Count == 0)
            {
                MessageBox.Show("Nema stavki za brisanje.");
                return;
            }

            if (dgvStavke.CurrentRow == null)
            {
                MessageBox.Show("Niste odabrali stavku za brisanje.");
                return;
            }
            int idNalog = vratiIdNaloga(int.Parse(tbBrojNaloga.Text), int.Parse(tbGodina.Text));
         
            metode.pristup_bazi("DELETE FROM ISP_stavke WHERE (id = " + dgvStavke.CurrentRow.Cells["id"].Value + ")");
          

            metode.pristup_bazi("DELETE FROM ISP_VIRMANI WHERE   (idNalog = " + idNalog + ") AND (poverilac = N'" + dgvStavke.CurrentRow.Cells["Lice"].Value + "')");// AND (iznos = N'" + dgvStavke.CurrentRow.Cells["iznos"].Value + "')");
            MessageBox.Show("Uspesno ste obrisali stavku");
         

            DataTable dtStavke =  metode.baza_upit("select id, ispl_stavka from isp_stavke where id_naloga = "+ idNalog +" order by ispl_stavka");

            if (dtStavke.Rows.Count > 0)
            {
                int i = 1;
                foreach (DataRow r in dtStavke.Rows)
                {
                    if (int.Parse(r["ispl_stavka"].ToString()) != i)
                    {
                        metode.pristup_bazi("UPDATE ISP_STAVKE SET ISPL_STAVKA = " + i + "  WHERE        (ID = " + r["id"].ToString() + ")");
                    }
                    i++;
                }

                azurirajIznosNaloga(idNalog);
                prikaz(idNalog);
            }
            else
            {
                metode.pristup_bazi("delete from isp_nalog where id = " + idNalog + "");
                dgvStavke.DataSource = null;
            }
          
        }

        private void btnUnesiNalog_Click(object sender, EventArgs e)
        {
            if (tbGodina.Text == "" || tbMesec.Text == "")
            {
                MessageBox.Show("Unesite mesec i godinu");
                return;
            }
            godina = int.Parse(tbGodina.Text);
            int mesec = int.Parse(tbMesec.Text);
            //unosi novi nalog
            string unesiNoviNalog = "INSERT    INTO  ISP_NALOG( korisnik,  redni_broj, datum,   zat_otv, svrha_isplate, sifra_placanja, " +
                         " mesec, godina) " +
                        " VALUES        (" + cbFirma.SelectedValue.ToString() +"," + metode.baza_upit("select ISNULL(MAX(redni_broj), 0) + 1 AS br from isp_nalog where (godina = " + godina + ")").Rows[0]["br"].ToString() + ",getdate(),0,N'putni trosak',240," + mesec + "," + godina + ")";

            metode.pristup_bazi(unesiNoviNalog);

            //uzima id novog naloga
            int idNalog = int.Parse(metode.baza_upit("select max(id) as id from isp_nalog where godina = " + godina + "").Rows[0]["id"].ToString());
            btnDodajStavku.Visible = true;
            btnUnesiNalog.Visible = false;
        }

        private void dgvStavke_Click(object sender, EventArgs e)
        {
            if (dgvStavke.CurrentRow != null)
            {
                cbLice.SelectedValue = int.Parse(dgvStavke.CurrentRow.Cells["SIF"].Value.ToString());
                tbIznos.Text = dgvStavke.CurrentRow.Cells["Dnevnice"].Value.ToString();
                tbRedndacija.Text = dgvStavke.CurrentRow.Cells["Refundacija troskova"].Value.ToString();
                gbNovaStavka.Visible = true;
                btnUnesi.Visible = false;
                btnIzmeni.Visible = true;
            }
        }

        private void inicijalizacija()
        {
            cbLice.DataSource = metode.baza_upit(" SELECT  SIF, IMPREZ, ADRESA, MESTO, JMBG, BRLK, Banka, ZiroRacun, AKT " +
                                                " FROM MATRAD WHERE        (AKT = N'da') order by imprez ");
            cbLice.DisplayMember = "IMPREZ";
            cbLice.ValueMember = "SIF";
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            int idNal = vratiIdNaloga(int.Parse(tbBrojNaloga.Text), int.Parse(tbGodina.Text));
            double dnevnica = double.Parse(tbIznos.Text);
            double refun = double.Parse(tbRedndacija.Text);
            double neto = dnevnica + refun;
            string a = " update isp_stavke SET  ID_KOMITENTA = " + cbLice.SelectedValue + ", dnevnica = " + dnevnica.ToString().Replace(",", ".") + ", refundacija = " + refun.ToString().Replace(",", ".") + ", NETO = " + neto.ToString().Replace(",", ".") + ",  Promene = getdate() where id=" + int.Parse(dgvStavke.CurrentRow.Cells["id"].Value.ToString()) + "; " +
                        " update isp_virmani set iznos= " + neto.ToString().Replace(",", ".") + " where idNalog = " + idNal + " and poverilac = N'" + cbLice.Text + "'";

            metode.pristup_bazi(a);
         
            azurirajIznosNaloga(idNal);

            prikaz(idNal);
        }

        private void btnNoviKomitent_Click(object sender, EventArgs e)
        {
            FormDodavanjeKomitenta dk = new FormDodavanjeKomitenta();
            dk.ShowDialog();
            inicijalizacija();
        }
     
    }
}
