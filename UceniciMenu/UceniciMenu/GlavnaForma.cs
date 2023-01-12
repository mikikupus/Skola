using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 U okviru genericke liste nalaze se elementi koji predstavljaku objekte klase Ucneik(sifra, ime, prezime, telefon, ocena iz programiranja)
Omoguciti operacije sa listom:
1)Dodavanje novog elementa
2)Prikaz i Uklanjanje iz liste ucenika sa odgovarajucom sifrom
3)Pregled liste
4)Izracunavanje i prikaz prosecne ocene iz programiranja
Podatke o uceniku uvek prikazivati na posebnoj formi.
Za aktiviranje svih opcija aktivirati glavni meni, a za dodavanje i izbacivanje iz liste
na paletu sa alatkama postaviti odgovarajucu kontrolu.
U listi mzoe biti maksimalno 30 ucenika.*/
namespace UceniciMenu
{
    public partial class GlavnaForma : Form
    {
        public GlavnaForma()
        {
            InitializeComponent();
        }
        List<Ucenik> lista_ucenika;
        private void Form1_Load(object sender, EventArgs e)
        {
            lista_ucenika = new List<Ucenik>();
        }

        private void BtUnos_Click(object sender, EventArgs e)
        {
            if(lista_ucenika.Count < 30)
            {
                bool postoji = false;
                if (txtime.Text != "" && txtprezime.Text != "" && txtsifra.Text != "" && txttelefon.Text != "" && txtocena.Text != "")
                {
                    if (lista_ucenika != null)
                    {
                        foreach (Ucenik uc in lista_ucenika)
                        {
                            if (txtsifra.Text == uc.Sifra.ToString())
                                postoji = true;
                        }
                        if (!postoji)
                        {
                            lista_ucenika.Add(new Ucenik(int.Parse(txtsifra.Text), txtime.Text, txtprezime.Text, txttelefon.Text, int.Parse(txtocena.Text)));
                            txtime.Text = txtprezime.Text = txtsifra.Text = txttelefon.Text = txtocena.Text = "";
                            postoji = false;
                        }
                        else MessageBox.Show("Učenik sa ovom šifrom već postoji!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else MessageBox.Show("Niste lepo uneli podatke!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripProsecnaOcena.Text = "Prosečna ocena: " + Ucenik.Prosecna_ocena.ToString();
                UpdateListBox();
            }
            else MessageBox.Show("Maksimalan broj učenika je 30!!!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void toolStripSearch_Click(object sender, EventArgs e)
        {
            bool postoji = false;
            if(toolStripTxtSifra.Text != "")
            {
                foreach (Ucenik uc in lista_ucenika)
                {
                    if (uc.Sifra == int.Parse(toolStripTxtSifra.Text))
                    {
                        postoji = true;
                        UcenikForm ucform = new UcenikForm(uc);
                        ucform.ShowDialog();
                    }
                }
                if(!postoji)
                    MessageBox.Show("Ucenik ne postoji!!!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Niste uneli sifru!!!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            bool postoji = false;
            Ucenik ucenik_za_brisanje = null;
            if (toolStripTxtSifra.Text != "")
            {
                foreach (Ucenik uc in lista_ucenika)
                {
                    if (uc.Sifra == int.Parse(toolStripTxtSifra.Text))
                    {
                        postoji = true;
                        ucenik_za_brisanje = uc;

                    }
                }
                if (postoji)
                {
                    lista_ucenika.Remove(ucenik_za_brisanje);
                    UpdateListBox();
                    toolStripTxtSifra.Text = "";
                }
                else
                    MessageBox.Show("Ucenik ne postoji!!!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Niste uneli sifru!!!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void UpdateListBox()
        {
            lbucenici.Items.Clear();
            foreach(Ucenik uc in lista_ucenika)
            {
                lbucenici.Items.Add(uc.Sifra + ", " + uc.Ime + " " + uc.Prezime + ", " + uc.Telefon + ", " + uc.Ocena);
            }
        }
        private void UnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
            unosToolStripMenuItemUnos.Checked = panel1.Visible;
        }
        private void ListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbucenici.Visible = !lbucenici.Visible;
            ListaToolStripMenuItem.Checked = lbucenici.Visible;
        }
        private void ProsecnaOcenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripProsecnaOcena.Visible = !toolStripProsecnaOcena.Visible;
            ProsecnaOcenaToolStripMenuItem.Checked = toolStripProsecnaOcena.Visible;

        }
    }
}
