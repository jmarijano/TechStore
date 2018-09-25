﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechStore
{
    /// <summary>
    /// Forma glavni izbornik.
    /// </summary>
    public partial class uiIzbornik : Form
    {
        /// <summary>
        /// Konstruktor forme uiIzbornik.
        /// </summary>
        public uiIzbornik()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Rukuje događajem klika na tipku uiActionIzlaz. Ispisuje poruku o odjavi
        /// i zatvara formu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiActionIzlaz_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Uspješno ste se odjavili.", "ODJAVA", MessageBoxButtons.OK);
            Close();
        }

        /// <summary>
        /// Rukuje događajem klika na tipku uiActionZaposlenici. Otvara formu uiZaposlenici.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiActionZaposlenici_Click(object sender, EventArgs e)
        {
            uiZaposlenici formaZaposlenici = new uiZaposlenici();
            formaZaposlenici.ShowDialog();
        }

        /// <summary>
        /// Rukuje događajem klika na tipku uiActionPoslovnice. Otvara formu uiPoslovnice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiActionPoslovnice_Click(object sender, EventArgs e)
        {
            uiPoslovnice formaPoslovnica = new uiPoslovnice();
            formaPoslovnica.ShowDialog();
        }

        /// <summary>
        /// Rukuje događajem klika na tipku uiActionPregledArtikala. Otvara formu
        /// uiKolicinaArtikala.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiActionPregledArtikala_Click(object sender, EventArgs e)
        {
            uiKolicinaArtikala formaKolicina = new uiKolicinaArtikala();
            formaKolicina.ShowDialog();   
        }

        /// <summary>
        /// Metoda koja se poziva prilikom klika na gumbić Artikl.
        /// Metoda otvara novu formu naziva uiArtikl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiActionDodajArtikl_Click(object sender, EventArgs e)
        {
            UiArtikl formaArtikli = new UiArtikl();
            formaArtikli.Show();
        }

        /// <summary>
        /// Rukuje događajem pokretanja forme.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiIzbornik_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += UiIzbornik_KeyDown;
            PripremiFunkcionalnosti();
        }

        /// <summary>
        /// Rukuje događajem pritiska tipke na tipkovnici. Ako je na tipkovnici
        /// pritisnuta tipka "F1" otvara formu uiHelp.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiIzbornik_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                uiHelp frmHelp = new uiHelp();
                RichTextBox richTextBox = (RichTextBox)frmHelp.Controls.Find("uiOutputPrikazPomoci", true)[0];
                richTextBox.Clear();
                richTextBox.Text = "TechStore Help Center\n\n";
                richTextBox.Text += "Trenutno ste stisnuli F1 na formi Izbornik.\n\nNa formi Izbornik možete vidjeti 7 tipki: ''Zaposlenici'', ''Poslovnice'', ''Pregled artikala po poslovnicama'' " +
                    ", ''Izrada konfiguracije'', ''Artikli'', ''Nabava artikala'' i ''Odjava''.\n\nPritiskom na tipku ''Zaposlenici'' otvara se forma za pregled svih zaposlenika i dodavanje novih zaposlenika.\n\nPritiskom " +
                    "na tipku ''Poslovnice'' otvara se forma za pregled svih poslovnica i dodavanje novih poslovnice.\n\nPritiskom na tipku ''Pregled artikala po poslovnicama'' otvara se forma na kojoj je moguće provjeriti " +
                    "stanje artikala po poslovnicama.\n\nPritiskom na tipku ''Izrada konfiguracije'' otvara se forma za izradu konfiguracije po želji korisnika.\n\n Pritiskom na tipku ''Artikli'' otvara se forma za pregled artikala.\n\n Pritiskom na tipku ''Nabava artikala''" +
                    "otvara se forma za pregled stanja artikala poslovnice u kojoj je zaposlen korisnik.\n\n Pritiskom na tipku ''Vrste artikala'' otvara se forma za pregled vrsti artikala. \n\n Pritiskom na tipku ''Pregled narudžbi'' otvara se forma za pregled narudžbi. "  +
                    "\n\nPritiskom na tipku ''Odjava'' korisnika se odjavljuje iz aplikacije." +
                    "\n\nPrijavljeni korisnik može biti ili administrator ili korisnik. Ukoliko se korisnik ulogirao kao administrator, dostupne su mu sve funkcionalnosti. Ukoliko se ulogirao kao korisnik, funkcionalnosti za evidenciju" +
                    " zaposlenika i poslovnica te dodavanje artikala mu neće biti dostupne.";
                frmHelp.Show();

            }
        }

        /// <summary>
        /// Rukuje događejem klika na tipku uiActionIzradaKonfiguracije. Otvara formu uiKonfiguracija.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiActionIzradaKonfiguracije_Click(object sender, EventArgs e)
        {
            uiKonfiguracija formaKonfiguracija = new uiKonfiguracija();
            formaKonfiguracija.ShowDialog();
        }

        /// <summary>
        /// Metoda koja se poziva prilikom pritiska na gumbić Nabava artikala.
        /// Metoda otvara formu uiStanje.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiActionNabavaArtikala_Click(object sender, EventArgs e)
        {
            UiStanje formaStanje = new UiStanje();
            formaStanje.Show();
        }

        /// <summary>
        /// Ukoliko je ID prijavljenog zaposlenika 1, odnosno prijavljeni zaposlenik je
        /// administrator, u labelu uiOutputIspis zapisuje odgovarajući tekst. Ukoliko je
        /// ID prijavljenog zaposlenika 2, odnosno prijavljeni zaposlenik je korisnik, u
        /// labelu uiOutputIspis zapisuje odgovarajući tekst te onemogućuje pritisak na 
        /// tipke uiActionZaposlenici i uiActionPoslovnice.
        /// </summary>
        private void PripremiFunkcionalnosti()
        {
            if (Zaposlenik.PrijavljeniZaposlenik.Tip_ID == 1)
            {
                uiOutputIspis.Text = "Prijavljeni ste kao administrator.";
            }
            else
            {
                uiOutputIspis.Text = "Prijavljeni ste kao korisnik.";
                uiActionZaposlenici.Enabled = false;
                uiActionPoslovnice.Enabled = false;
            }
        }

        /// <summary>
        /// Metoda koja se poziva prilikom pritiska na gumbić Vrste artikala.
        /// Metoda otvara novu formu naziva uiVrstaArtikl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiActionVrsteArtikala_Click(object sender, EventArgs e)
        {
            UiVrstaArtikl formaVrstaArtikl = new UiVrstaArtikl();
            formaVrstaArtikl.Show();
        }

        /// <summary>
        /// Metoda koja se poziva prilikom pritisna na gumbić Narudžbe.
        /// Metoda otvara novu formu naziva uiPregledNarudzbi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiActionNarudzbe_Click(object sender, EventArgs e)
        {
            UiPregledNarudzbi formaPregledNarudzbi= new UiPregledNarudzbi();
            formaPregledNarudzbi.ShowDialog();
        }
    }
}
