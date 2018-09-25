﻿using Komponente;
using System;
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
    /// Parcijalna klasa uiVrstaArtikl
    /// </summary>
    public partial class UiVrstaArtikl : Form
    {
        
        private Pretraga pretraga = new Pretraga();
        /// <summary>
        /// Konstruktor forme uiVrstaArtikl
        /// </summary>
        public UiVrstaArtikl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda koja se poziva prilikom učitavanja
        /// forme uiVrstaArtikl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiVrstaArtikl_Load(object sender, EventArgs e)
        {
            if (Zaposlenik.PrijavljeniZaposlenik.Tip_ID!=1)
            {
                uiActionAzuriraj.Enabled = false;
                uiActionDodaj.Enabled = false;
                uiActionObrisi.Enabled = false;
            }
            try
            {
                vrstaArtiklaBindingSource.DataSource = VrstaArtikla.DohvatiVrsteArtikala();
            }
            catch (Exception)
            {
                MessageBox.Show("Pogreška!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.KeyPreview = true;
            this.KeyDown += UiVrstaArtikl_KeyDown;
        }

        /// <summary>
        /// Metoda koja se poziva prilikom pritiska na tipku F11
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiVrstaArtikl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                uiHelp frmHelp = new uiHelp();
                RichTextBox richTextBox = (RichTextBox)frmHelp.Controls.Find("uiOutputPrikazPomoci", true)[0];
                richTextBox.Clear();
                richTextBox.Text = "TechStore Help Center\nViše informacija možete pronaći na sljedećem linku:\nhttps://github.com/foivz/r18038/wiki/3.-Korisni%C4%8Dka-dokumentacija\n\n";
                richTextBox.Text += "Trenutno ste stisnuli F1 na formi Vrsta artikla. Na formi Vrsta artikla možete vidjeti popis svih vrsta artikala u TechStore aplikaciji. Na formi se ";
                richTextBox.Text += "također nalaze i tri gumbića: Ažuriraj, Obriši i Dodaj. Ukoliko je pritisnut gumbić Ažuriraj korisnik može ažurirati postojeću vrstu artikla. Ukoliko je ";
                richTextBox.Text += "pritisnut gumbić Obriši, korisnik može obrisati odabranu vrstu artikla. Ako je pak pritisnuo gumbić Dodaj može dodati novu vrstu artikla.";
                frmHelp.Show();

            }
        }

        /// <summary>
        /// Metoda koja se poziva prilikom pritiska na gumbić uiActionDodaj.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiActionDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                uiDodavanjeVrsteArtikla dodavanjeVrsteArtikla = new uiDodavanjeVrsteArtikla();
                dodavanjeVrsteArtikla.ShowDialog();
                vrstaArtiklaBindingSource.DataSource = VrstaArtikla.DohvatiVrsteArtikala();
            }
            catch (Exception)
            {
                MessageBox.Show("Pogreška!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Metoda koja se poziva prilikom pritiska na gumbić uiActionObrisi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiActionObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                VrstaArtikla vrstaArtiklaZaBrisanje = (VrstaArtikla)vrstaArtiklaBindingSource.Current;
                if (MessageBox.Show("Sigurno želite obrisati vrstu artikla " + vrstaArtiklaZaBrisanje.Naziv.ToString() + " ?", "Upozorenje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    VrstaArtikla.ObrisiVrstuArtikla(vrstaArtiklaZaBrisanje);
                }
                vrstaArtiklaBindingSource.DataSource = VrstaArtikla.DohvatiVrsteArtikala();
            }
            catch (Exception)
            {
                MessageBox.Show("Pogreška!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Metoda koja se poziva prilikom pritiska na gumbić uiActionAzuriraj.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiActionAzuriraj_Click(object sender, EventArgs e)
        {
            try
            {
                VrstaArtikla vrstaArtiklaZaIzmjenu = (VrstaArtikla)vrstaArtiklaBindingSource.Current;
                uiDodavanjeVrsteArtikla formaDodavanjeVrsteArtikla = new uiDodavanjeVrsteArtikla(vrstaArtiklaZaIzmjenu);
                formaDodavanjeVrsteArtikla.ShowDialog();
                vrstaArtiklaBindingSource.DataSource = VrstaArtikla.DohvatiVrsteArtikala();
            }
            catch (Exception)
            {
                MessageBox.Show("Pogreška!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        /// <summary>
        /// Metoda koja se poziva prilikom pritiska na gumbić Natrag.
        /// Metoda zatvara formu uiVrstaArtikl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiActionNatrag_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Metoda se  poziva prilikom promjene sadržaja polja uiInputPretraga.
        /// Metoda osvježava prikaz dataGridView - a te se pretražuje datagridView
        /// prema unesenom tekstu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiInputPretraga_TextChanged(object sender, EventArgs e)
        {
            try
            {
                vrstaArtiklaBindingSource.DataSource = VrstaArtikla.DohvatiVrsteArtikala();
            }
            catch (Exception)
            {
                MessageBox.Show("Pogreška!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            pretraga.Pretrazi(uiOutputVrsteArtikla, uiInputPretraga.Text, 1);
        }

    }
}
