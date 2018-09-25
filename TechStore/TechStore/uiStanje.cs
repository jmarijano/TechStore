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
    /// Parcijalna klasa uiStanje.
    /// </summary>
    public partial class UiStanje : Form
    {
        private Poslovnica trenutnaPoslovnica = Poslovnica.DohvatiPoslovnicu(Zaposlenik.PrijavljeniZaposlenik.Poslovnica_ID);
        /// <summary>
        /// Konstruktor forme uiStanje.
        /// </summary>
        public UiStanje()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda koja se poziva prilikom učitavanja forme uiStanje.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStanje_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += FrmStanje_KeyDown;
            uiLabelPoslovnice.Text = "Poslovnica : " + trenutnaPoslovnica.Naziv;
            OsvjeziArtikle();

        }

        /// <summary>
        /// Metoda koja se poziva prilikom pritiska na tipku F11.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStanje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                uiHelp frmHelp = new uiHelp();
                RichTextBox richTextBox = (RichTextBox)frmHelp.Controls.Find("uiOutputPrikazPomoci", true)[0];
                richTextBox.Clear();
                richTextBox.Text = "TechStore Help Center\nViše informacija možete pronaći na sljedećem linku:\nhttps://github.com/foivz/r18038/wiki/3.-Korisni%C4%8Dka-dokumentacija\n\n";
                richTextBox.Text += "Trenutno ste stisnuli F1 na formi Stanje. Na formi Stanje možete vidjeti popis poslovnica te svih artikala i količinu artikala u odabranoj poslovnici.";
                richTextBox.Text += " Korisnik može vidjeti artikle druge poslovnice mijenjanjem poslovnice u prikazu poslovnica. Ako želi naručiti proizvod može pritisnuti na gumbić Naruči ";
                richTextBox.Text += " ili Naruči postojeći. Ako je pritisnut gumbić naruči korisnik može odabrati sve poslovnice i sve artikla a ako je pritisnut gumbić naruči postojeći može ";
                richTextBox.Text += " naručiti samo odabrani artikl za odabranu poslovnicu. Pritiskom na gumbić Natrag korisnik se vraća na glavni izbornik aplikacije.";
                frmHelp.Show();

            }
        }

        /// <summary>
        /// Metoda koja se poziva prilikom pritiska na gumbić Natrag.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiActionNatrag_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metoda koja se poziva prilikom pritiska na gumbić Naruči.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiActionNaruci_Click(object sender, EventArgs e)
        {

            UiNabava formaNabava = new UiNabava(trenutnaPoslovnica);
            formaNabava.ShowDialog();
            OsvjeziArtikle();
        }

        /// <summary>
        /// Metoda koja služi za prikaz artikala pojedine poslovnice
        /// </summary>
        private void OsvjeziArtikle()
        {
            try
            {
                using (var db = new TechStoreEntities())
                {
                    var rezultat = (from artikl in db.Artikl
                                    join dostupnost in db.Dostupnost on artikl.ID equals dostupnost.Artikl_ID
                                    join poslovnica in db.Poslovnica on dostupnost.Poslovnica_ID equals poslovnica.ID
                                    where poslovnica.ID == trenutnaPoslovnica.ID
                                    select new
                                    {
                                        artikl.ID,
                                        artikl.Naziv,
                                        artikl.Cijena,
                                        dostupnost.Kolicina
                                    }).ToList();
                    uiOutputStanjeArtikala.DataSource = rezultat;
                    uiOutputStanjeArtikala.Refresh();
                    foreach (DataGridViewRow red in uiOutputStanjeArtikala.Rows)
                    {
                        if (Convert.ToInt32(red.Cells[3].Value) < 5)
                        {
                            red.DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                    uiOutputStanjeArtikala.Refresh();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Pogreška!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}