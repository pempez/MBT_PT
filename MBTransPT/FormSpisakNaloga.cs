using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;


namespace MBTransPT
{
    public partial class FormSpisakNaloga : Form
    {
        Metode metode = new Metode();
        ReportDocument ReportDoc = new ReportDocument();

        public FormSpisakNaloga()
        {
            InitializeComponent();


            ucitajNaloge();
        }

        private void btnObrisiNalog_Click(object sender, EventArgs e)
        {
            int idNalog = int.Parse(dgvNalozi.CurrentRow.Cells["id"].Value.ToString());
            metode.pristup_bazi(" delete from isp_nalog where id=" + idNalog + "; delete from isp_stavke where id_naloga = " + idNalog + ";");
            ucitajNaloge();
        }

        private void ucitajNaloge()
        {

            //   dgvNalozi.DataSource = metode.baza_upit("SELECT id, redni_broj as rb, datum, neto_iznos as neto, godina, mesec FROM ISP_NALOG  order by godina,redni_broj");
            dgvNalozi.DataSource = metode.baza_upit(" SELECT        TOP (100) PERCENT dbo.KORISNIK.id as idKorisnik  ,dbo.ISP_NALOG.id, dbo.ISP_NALOG.redni_broj AS rb, dbo.ISP_NALOG.datum, dbo.ISP_NALOG.neto_iznos AS neto, dbo.ISP_NALOG.godina, " +
                              " dbo.ISP_NALOG.mesec, dbo.KORISNIK.KORISNIK as Firma FROM            dbo.ISP_NALOG INNER JOIN " +
                              " dbo.KORISNIK ON dbo.ISP_NALOG.korisnik = dbo.KORISNIK.ID " +
                              " ORDER BY dbo.ISP_NALOG.godina, rb");
            dgvNalozi.AutoSize = true;
            dgvNalozi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvNalozi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvNalozi.Columns["ID"].Visible = false;
            dgvNalozi.Columns["idKorisnik"].Visible = false;
            dgvNalozi.Columns["neto"].DefaultCellStyle.Format = "F2";

            dgvNalozi.Columns["datum"].DefaultCellStyle.Format = "dd.MM.yyyy";

        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }



        private void dgvNalozi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idNalog = int.Parse(dgvNalozi.CurrentRow.Cells["id"].Value.ToString());

            FormNoviNalog fn = new FormNoviNalog(idNalog);
            fn.ShowDialog();
            ucitajNaloge();
        }

        private void btnStampaj_Click(object sender, EventArgs e)
        {
            int idNalog = int.Parse(dgvNalozi.CurrentRow.Cells["id"].Value.ToString());
            int idKor = int.Parse(dgvNalozi.CurrentRow.Cells["idKorisnik"].Value.ToString());
            

            makeReport("C:\\Program files\\IT\\MB\\StampaNaloga.rpt");
            ReportDoc.SetParameterValue("IdNaloga", (idNalog));
            ReportDoc.SetParameterValue("idkorisnik", (idKor));

            Report rep = new Report(ReportDoc);
            rep.ShowDialog();

        }

        private void makeReport(string ReportFile)
        {
            TextReader textReader = new StreamReader("c:\\Program files\\IT\\MB\\dblogon.txt");
            string uid = textReader.ReadLine();
            string pwd = textReader.ReadLine();
            string server = textReader.ReadLine();
            string db = textReader.ReadLine();
            textReader.Close();

            ReportDoc.Load(ReportFile);
            ReportDoc.SetDatabaseLogon(uid, pwd, server, db);

        }

        private void btnVirmani_Click(object sender, EventArgs e)
        {
            //napraviVirmane();
            stampaVirmana();
        }

        private void napraviVirmane()
        {
            string idNaloga = (dgvNalozi.CurrentRow.Cells["id"].Value.ToString());

            string nalog = "Viramni-nalog " + dgvNalozi.CurrentRow.Cells["godina"].Value.ToString() + "-" + dgvNalozi.CurrentRow.Cells["rb"].Value.ToString() + "";
            if (idNaloga != "")
            {
                //makeReport("C:\\Program files\\IT\\IspFL\\ZaduzenjaVirmani.rpt");
                //ReportDoc.SetParameterValue("IdNaloga", int.Parse(idNaloga));
                //ReportDoc.SetParameterValue("godina", godina);
                //ReportDoc.SetParameterValue("korisnik", int.Parse(comboBox3.SelectedValue.ToString()));


                //Report rep = new Report(ReportDoc);
                //rep.ShowDialog();

                //ReportDoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Text, "C://blankouplatnice/" + nalog + ".txt");
                //MessageBox.Show("Virmani od naloga " + comboBox8.Text + "-" + textBox11.Text + " su sacuvani u *C://BlankoUplatnice/"+nalog+".txt*. Otvorite porgram Stampa Uplatnica ukoliko zelite da ih odstampate", "Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!Directory.Exists("C://blankoUPLATNICE/"))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory("C://blankoUPLATNICE/");
                }
                TextWriter upisi = new StreamWriter("C://blankouplatnice/" + nalog + ".txt", false, System.Text.Encoding.UTF8);



                //string queryStavke = "SELECT        dbo.I_KORISNIK.KORISNIK, dbo.I_KORISNIK.MESTO, dbo.I_KORISNIK.adresa, dbo.I_KORISNIK.ID, dbo.FIN_KOMITENTI_ISP.Prezime + ' ' + dbo.FIN_KOMITENTI_ISP.Ime AS Lice, dbo.FIN_KOMITENTI_ISP.SifraKomitenta,  " +
                //                        "  [" + godina + "_ISP].dbo.ISP_NALOG.konto AS Konto, [" + godina + "_ISP].dbo.ISP_NALOG.datum_isp, [" + godina + "_ISP].dbo.ISP_STAVKE.NETO, [" + godina + "_ISP].dbo.ISP_STAVKE.BRUTO, [" + godina + "_ISP].dbo.ISP_NALOG.bruto_iznos,  " +
                //        "   [" + godina + "_ISP].dbo.ISP_NALOG.neto_iznos, [" + godina + "_ISP].dbo.ISP_NALOG.zat_otv, dbo.ISP_POZICIJA.oznaka + N'-' + CONVERT(VARCHAR(50), [" + godina + "_ISP].dbo.ISP_NALOG.redni_broj) AS BrojNaloga,  " +
                //        "   [" + godina + "_ISP].dbo.ISP_STAVKE.brDana, [" + godina + "_ISP].dbo.ISP_STAVKE.neoporeziv, [" + godina + "_ISP].dbo.ISP_STAVKE.ID_NALOGA, [" + godina + "_ISP].dbo.ISP_ODBICI.IZNOS_POREZA, [" + godina + "_ISP].dbo.ISP_ODBICI.Osnova_POREZ,  " +
                //        "   [" + godina + "_ISP].dbo.ISP_NALOG.mesec, dbo.FIN_ZIRO_RACUNI_ISP.ZIRO, dbo.FIN_ZIRO_RACUNI_ISP.Opis, dbo.FIN_ZIRO_RACUNI_ISP.BANKA, dbo.FIN_ZIRO_RACUNI_ISP.BANKA_MESTO,  " +
                //        "   dbo.FIN_ZIRO_RACUNI_ISP.Adresa AS Expr2, dbo.FIN_ZIRO_RACUNI_ISP.PRIMARNI, dbo.I_KORISNIK.pib, dbo.FIN_KOMITENTI_ISP.OPSTINA, dbo.FIN_KOMITENTI_ISP.MESTO AS mestoKom, dbo.FIN_KOMITENTI_ISP.ULICA,  " +
                //        "   dbo.FIN_KOMITENTI_ISP.BROJ, [" + godina + "_ISP].dbo.ISP_NALOG.sifra_placanja, dbo.ISP_POZICIJA.naziv_pozicije, [" + godina + "_ISP].dbo.ISP_NALOG.model, dbo.FIN_ZIRO_RACUNI.ZIRO AS ziroRacunNalogodavac " +
                //    "  FROM            dbo.I_KORISNIK INNER JOIN " +
                //       "    dbo.FIN_KOMITENTI_ISP INNER JOIN " +
                //       "    [" + godina + "_ISP].dbo.ISP_STAVKE INNER JOIN " +
                //       "    [" + godina + "_ISP].dbo.ISP_NALOG ON [" + godina + "_ISP].dbo.ISP_STAVKE.ID_NALOGA = [" + godina + "_ISP].dbo.ISP_NALOG.id ON dbo.FIN_KOMITENTI_ISP.ID_KOMITENTA = [" + godina + "_ISP].dbo.ISP_STAVKE.ID_KOMITENTA ON  " +
                //        "   dbo.I_KORISNIK.ID = [" + godina + "_ISP].dbo.ISP_NALOG.korisnik INNER JOIN " +
                //      "     dbo.ISP_POZICIJA ON [" + godina + "_ISP].dbo.ISP_NALOG.pozicija = dbo.ISP_POZICIJA.id_pozicija INNER JOIN " +
                //      "     [" + godina + "_ISP].dbo.ISP_ODBICI ON [" + godina + "_ISP].dbo.ISP_STAVKE.ID = [" + godina + "_ISP].dbo.ISP_ODBICI.ID_STAVKE LEFT OUTER JOIN " +
                //       "    dbo.FIN_ZIRO_RACUNI ON dbo.I_KORISNIK.ID = dbo.FIN_ZIRO_RACUNI.SifraKomitenta LEFT OUTER JOIN " +
                //       "    dbo.FIN_ZIRO_RACUNI_ISP ON dbo.FIN_KOMITENTI_ISP.SifraKomitenta = dbo.FIN_ZIRO_RACUNI_ISP.SifraKomitenta" +
                //"  WHERE        (dbo.I_KORISNIK.ID = " + int.Parse(comboBox3.SelectedValue.ToString()) + ") AND ([" + godina + "_ISP].dbo.ISP_NALOG.id = " + int.Parse(idNaloga) + ") AND (dbo.FIN_ZIRO_RACUNI_ISP.PRIMARNI = 1)";

                string queryStavke = " select * from isp_virmani where idnalog = " + idNaloga + "";
                DataTable Stavke = metode.baza_upit(queryStavke);

                foreach (DataRow row in Stavke.Rows)
                {
                    //nalogodavac
                    string nalogodavac = row["duznik"].ToString();
                    //  string nalogodavac_mesto = row["MESTO"].ToString();
                    // string nalogodavac_adresa = row["adresa"].ToString();
                    string nalogodavac_ziro = row["racun_duznika"].ToString();
                    string nalogodavac_pozic = "79-01841-415112-00-07-920";
                    string sifraPlac = row["sifra_placanja"].ToString();

                    //lice
                    string lice = row["poverilac"].ToString();
                    string lice_pom = lice.PadRight(48);

                    string neto = row["iznos"].ToString();
                    double neto_pom = double.Parse(neto);


                    string lice_ziro = row["racun_poverioca"].ToString();
                    string svrha = row["svrha_placanja"].ToString();

                    upisi.Write("");
                    upisi.WriteLine();
                    upisi.WriteLine();
                    upisi.WriteLine();
                    upisi.WriteLine();
                    upisi.WriteLine();
                    upisi.WriteLine();
                    upisi.Write("      ");
                    upisi.WriteLine();
                    upisi.Write("   " + nalogodavac.PadRight(40) + " " + sifraPlac + "   RSD        =" + neto_pom.ToString("N2") + "");//37
                    upisi.WriteLine();
                    upisi.Write("   ");
                    upisi.WriteLine();
                    upisi.WriteLine();
                    upisi.Write("                                                   " + nalogodavac_ziro + "");
                    upisi.WriteLine();
                    upisi.WriteLine();
                    upisi.Write("   " + svrha + "");
                    upisi.WriteLine();
                    upisi.Write("                                            97     ");
                    upisi.WriteLine();
                    upisi.WriteLine();
                    upisi.WriteLine();
                    upisi.Write("   " + lice_pom + "" + lice_ziro + " ");
                    upisi.WriteLine();
                    upisi.WriteLine();
                    upisi.WriteLine();
                    upisi.Write("                                            97 ");
                    upisi.WriteLine();
                    upisi.WriteLine();
                    upisi.WriteLine();
                    upisi.Write("                  INDJIJA,                        ");
                    upisi.WriteLine();
                    upisi.WriteLine();

                    //upisi.Write("");
                    //upisi.WriteLine();
                    //upisi.WriteLine();
                    //upisi.WriteLine();
                    //upisi.WriteLine();
                    //upisi.WriteLine();
                    //upisi.WriteLine();
                    // upisi.Write("      " + row["korisnik"].ToString() + "");
                    //upisi.WriteLine();
                    //upisi.Write("   " + nalogodavac_adresa.PadRight(37) + "RSD        =" + neto_pom.ToString("N2") + "");//37
                    //upisi.WriteLine();
                    //upisi.Write("   " + nalogodavac_mesto + "");
                    //upisi.WriteLine();
                    //upisi.WriteLine();
                    //upisi.Write("                                                   " + nalogodavac_ziro + "");
                    //upisi.WriteLine();
                    //upisi.WriteLine();
                    //upisi.Write("   " + svrha + "");
                    //upisi.WriteLine();
                    //upisi.Write("                                            97     ");
                    //upisi.WriteLine();
                    //upisi.WriteLine();
                    //upisi.WriteLine();
                    //upisi.Write("   " + lice_pom + "" + lice_ziro + " ");
                    //upisi.WriteLine();
                    //upisi.WriteLine();
                    //upisi.WriteLine();
                    //upisi.Write("                                            97 ");
                    //upisi.WriteLine();
                    //upisi.WriteLine();
                    //upisi.WriteLine();
                    //upisi.Write("                  INDJIJA,                        ");
                    //upisi.WriteLine();
                    //upisi.WriteLine();

                }
                upisi.Close();

                MessageBox.Show("Virmani od naloga " + dgvNalozi.CurrentRow.Cells["godina"].Value.ToString() + "-" + dgvNalozi.CurrentRow.Cells["rb"].Value.ToString() + " su sacuvani u *C://BlankoUplatnice/" + nalog + ".txt*. Otvorite porgram Stampa Uplatnica ukoliko zelite da ih odstampate", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Niste odabrali nalog za štampu", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
        }

        private void stampaVirmana()
        {
            int idNalog = int.Parse(dgvNalozi.CurrentRow.Cells["id"].Value.ToString());


            makeReport("C:\\Program files\\IT\\MB\\Virmani.rpt");
            ReportDoc.SetParameterValue("IdNalog", (idNalog));

            Report rep = new Report(ReportDoc);
            rep.ShowDialog();
        }

        private void btnSpisakBanka_Click(object sender, EventArgs e)
        {
            int idNalog = int.Parse(dgvNalozi.CurrentRow.Cells["id"].Value.ToString());
            int idKor = int.Parse(dgvNalozi.CurrentRow.Cells["idKorisnik"].Value.ToString());

            makeReport("C:\\Program files\\IT\\MB\\SpisakBanka.rpt");
            ReportDoc.SetParameterValue("IdNaloga", (idNalog));
            ReportDoc.SetParameterValue("idkorisnik", (idKor));

            Report rep = new Report(ReportDoc);
            rep.ShowDialog();
        }

        private void btnENalog_Click(object sender, EventArgs e)
        {
            btnNapraviTxt_Click();
        }

        private void btnNapraviTxt_Click()
        {
            if (!Directory.Exists("C://Uplatnice/"))
            {
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory("C://Uplatnice/");
            }

            int idNalog = int.Parse(dgvNalozi.CurrentRow.Cells["id"].Value.ToString());
            double ukupanIznosZaPlacanje = 0;
            bool sviIstogDatuma = true;
            string pomZaDatum = "";
            string datumSaSest = "";
            string racunDirekcije = "";
            string racunDirekcijePom = "";
            int count = 0;

            DataTable dtStavke = metode.baza_upit("SELECT        dbo.ISP_VIRMANI.duznik, dbo.ISP_VIRMANI.racun_duznika, dbo.ISP_VIRMANI.poverilac, dbo.ISP_VIRMANI.racun_poverioca, dbo.ISP_VIRMANI.svrha_placanja, " +
                        " dbo.ISP_VIRMANI.sifra_placanja, dbo.ISP_VIRMANI.iznos, dbo.ISP_NALOG.datum " +
                        " FROM            dbo.ISP_VIRMANI INNER JOIN " +
                        " dbo.ISP_NALOG ON dbo.ISP_VIRMANI.idNalog = dbo.ISP_NALOG.id " +
                        " WHERE        (dbo.ISP_NALOG.id = " + idNalog + ")");

            foreach (DataRow row in dtStavke.Rows)
            {

                if (sviIstogDatuma)
                {
                    if (pomZaDatum == "")
                    {

                        racunDirekcijePom = row["racun_duznika"].ToString().Replace("-", "");
                        string a = racunDirekcijePom.Substring(3, racunDirekcijePom.Length - 3);
                        pomZaDatum = row["datum"].ToString();
                        int duzp = a.Length;
                        if (a.Length < 15)
                        {
                            for (int i = 0; i < 15 - duzp; i++)
                            {
                                a = "0" + a;
                            }
                        }
                        racunDirekcije = racunDirekcijePom.Substring(0, 3) + a;
                    }
                    if (pomZaDatum != row["datum"].ToString())
                    {
                        sviIstogDatuma = false;
                    }
                }
                count += 1;
                ukupanIznosZaPlacanje += double.Parse(row["iznos"].ToString());

            }

            if (count == 0)
            {
                MessageBox.Show("Niste odabrali ništa za plaćanje", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sviIstogDatuma)
            {
                DateTime konvert = Convert.ToDateTime(pomZaDatum);
                datumSaSest = konvert.Day.ToString();
                if (datumSaSest.Length == 1)
                {
                    datumSaSest = "0" + datumSaSest;
                }
                if (konvert.Month.ToString().Length == 1)
                {
                    datumSaSest += "0";
                }
                datumSaSest += konvert.Month.ToString();
                datumSaSest += konvert.Year.ToString().Substring(2, 2);
            }
            else 
            {
                datumSaSest = "      ";
            }

           // datumSaSest += "_" + dgvNalozi.CurrentRow.Cells["Firma"].Value.ToString();
            string pomNa = datumSaSest +"_" + dgvNalozi.CurrentRow.Cells["Firma"].Value.ToString();
            TextWriter upisi = new StreamWriter("C:\\Uplatnice\\Elektronsko placanje" + pomNa + ".txt", false, System.Text.Encoding.Default);


            string queryNazivFirme = "select korisnik from korisnik";
            DataTable dtNaz = metode.baza_upit(queryNazivFirme);
            string nazivFir = dtNaz.Rows[0]["korisnik"].ToString();

            if (nazivFir.Length > 35)
            {
                nazivFir = nazivFir.Substring(0, 35);
            }
            else if (nazivFir.Length < 35)
            {
                int pomD = nazivFir.Length;
                for (int i = 0; i < 35 - pomD; i++)
                {

                    nazivFir = " " + nazivFir;
                }
            }

            upisi.Write("");
            upisi.Write(racunDirekcije);
            upisi.Write(nazivFir);
            upisi.Write("    INđIJA");
            upisi.Write(datumSaSest);
            upisi.Write("                                                                                                  ");
            upisi.Write("MULTI E-BANK");
            upisi.Write("0");
            upisi.WriteLine();

            //UPIS REDA DATOTEKE SA SABIRNOM STAVKOM
            upisi.Write("");
            upisi.Write(racunDirekcije);
            upisi.Write(nazivFir);
            upisi.Write("    INđIJA");
            ukupanIznosZaPlacanje = ukupanIznosZaPlacanje * 100;
            string pomUkupanIznos = ukupanIznosZaPlacanje.ToString();
            int pomUkupanIznosLength = pomUkupanIznos.Length;
            if (pomUkupanIznosLength < 15)
            {
                for (int i = 0; i < 15 - pomUkupanIznosLength; i++)
                {
                    pomUkupanIznos = "0" + pomUkupanIznos;
                }
            }
            upisi.Write(pomUkupanIznos);
            string pomCount = count.ToString();
            int pomCountLength = pomCount.Length;
            if (pomCountLength < 5)
            {
                for (int i = 0; i < 5 - pomCountLength; i++)
                {
                    pomCount = "0" + pomCount;
                }
            }
            upisi.Write(pomCount);
            upisi.Write("                                                                                                ");
            upisi.Write("9");
            upisi.WriteLine();

            //UPIS REDA DATOTEKE SA INDIVIDUALNOM STAVKOM
            foreach (DataRow r in dtStavke.Rows)
            {
                //if (Convert.ToBoolean(r.Cells["Odaberi"].Value))
                //{
                string racunPovpom = "";
                string racunPov = "";
                racunPovpom = r["racun_poverioca"].ToString().Replace("-", "");
                string a = racunPovpom.Substring(3, racunPovpom.Length - 3);
                pomZaDatum = r["datum"].ToString();
                int duz = a.Length;
                if (a.Length < 15)
                {
                    for (int i = 0; i < 15 - duz; i++)
                    {
                        a = "0" + a;
                    }
                }
                racunPov = racunPovpom.Substring(0, 3) + a;


                upisi.Write("");
                upisi.Write(racunPov);

                string nazPomocni = r["poverilac"].ToString();
                if (nazPomocni.Length < 35)
                {
                    int nazPomLen = nazPomocni.Length;
                    for (int i = 0; i < 35 - nazPomLen; i++)
                    {
                        nazPomocni = " " + nazPomocni;
                    }
                }
                upisi.Write(nazPomocni);

                string mestoPomocni = "";// r.Cells["Mesto primaoca"].Value.ToString();
                if (mestoPomocni.Length < 10)
                {
                    int mesPomLen = mestoPomocni.Length;
                    for (int i = 0; i < 10 - mesPomLen; i++)
                    {
                        mestoPomocni = " " + mestoPomocni;
                    }
                }
                upisi.Write(mestoPomocni);

                upisi.Write("0");

                string modelZadPom = "";// r.Cells["modelPozivaZaduzenja"].Value.ToString();
                if ((modelZadPom.Length < 2) && (modelZadPom != ""))
                {
                    modelZadPom = " " + modelZadPom;
                }
                if (modelZadPom == "")
                {
                    modelZadPom = "  ";
                }
                upisi.Write(modelZadPom);

                string pozivZadPom = "";// r.Cells["pozivZaduzenja"].Value.ToString();
                if (pozivZadPom.Length < 23)
                {
                    int pozZadLen = pozivZadPom.Length;
                    for (int i = 0; i < 23 - pozZadLen; i++)
                    {
                        pozivZadPom = pozivZadPom + " ";
                    }
                }
                upisi.Write(pozivZadPom);

                string svrhaPlacPom = r["svrha_placanja"].ToString();
                if (svrhaPlacPom.Length < 36)
                {
                    int svrPlLen = svrhaPlacPom.Length;
                    for (int i = 0; i < 36 - svrPlLen; i++)
                    {
                        svrhaPlacPom = " " + svrhaPlacPom;
                    }
                }
                upisi.Write(svrhaPlacPom);

                upisi.Write("00000 ");

                string pomSifPl = r["sifra_Placanja"].ToString();
                int pomSifPlLen = pomSifPl.Length;
                if (pomSifPlLen < 3)
                {
                    for (int i = 0; i < 3 - pomSifPlLen; i++)
                    {
                        pomSifPl = "0" + pomSifPl;
                    }
                }
                upisi.Write(pomSifPl);

                upisi.Write("  ");

                double iznosZaPlacPom = double.Parse(r["iznos"].ToString());
                iznosZaPlacPom = iznosZaPlacPom * 100;
                string iznosString = iznosZaPlacPom.ToString();
                int iznosLen = iznosString.Length;
                if (iznosLen < 13)
                {
                    for (int i = 0; i < 13 - iznosLen; i++)
                    {
                        iznosString = "0" + iznosString;
                    }
                }
                upisi.Write(iznosString);

                string modelOdoPom = "";// r.Cells["modelPozivaOdobrenja"].Value.ToString();
                if ((modelOdoPom.Length < 2) && (modelOdoPom != ""))
                {
                    modelOdoPom = " " + modelOdoPom;
                }
                if (modelOdoPom == "")
                {
                    modelOdoPom = "  ";
                }
                upisi.Write(modelOdoPom);

                string pozivOdoPom = "";// r.Cells["pozivOdobrenja"].Value.ToString();
                if (pozivOdoPom.Length < 23)
                {
                    int pozOdoLen = pozivOdoPom.Length;
                    for (int i = 0; i < 23 - pozOdoLen; i++)
                    {
                        pozivOdoPom = pozivOdoPom + " ";
                    }
                }
                upisi.Write(pozivOdoPom);

                DateTime konvPom = Convert.ToDateTime(r["Datum"].ToString());
                string danAAA = konvPom.Day.ToString();
                if (danAAA.Length == 1) { danAAA = "0" + konvPom.Day; }
                string monAAA = konvPom.Month.ToString();
                if (monAAA.Length == 1) { monAAA = "0" + konvPom.Month; }
                string datumSaSestJedna = danAAA + monAAA + konvPom.Year.ToString().Substring(2, 2);
                upisi.Write(datumSaSestJedna);

                upisi.Write("01");
                upisi.WriteLine();

                //string query12345 = "update fakt_priprema set kreiran = 1 where id = " + int.Parse(r.Cells["id"].Value.ToString());
                //SqlConnection conn12345 = new SqlConnection(connection);
                //conn12345.Open();
                //SqlCommand izmeniKreiran = new SqlCommand();
                //izmeniKreiran.CommandText = query12345;
                //izmeniKreiran.Connection = conn12345;
                //izmeniKreiran.ExecuteNonQuery();
                //conn12345.Close();

            }

            upisi.Close();
            MessageBox.Show("Uspešno kreiran fajl. Fajl se nalazi u C:/Uplatnice/Elektrosnko placanje " + datumSaSest + "", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //ucitaj_pripremljene();
            return;
        }

    }
}
