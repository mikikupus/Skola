using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UceniciMenu
{
    public partial class UcenikForm : Form
    {
        Ucenik ucenik;
        public UcenikForm(Ucenik ucenik)
        {
            InitializeComponent();
            this.ucenik = ucenik;
        }

        private void UcenikForm_Load(object sender, EventArgs e)
        {
            lbsifra.Text = "Šifra: " + ucenik.Sifra.ToString();
            lbime.Text = "Ime: " + ucenik.Ime.ToString();
            lbprezime.Text = "Prezime: " + ucenik.Prezime.ToString();
            lbtelefon.Text = "Telefon: " + ucenik.Telefon.ToString();
            lbocena.Text = "Ocena: " + ucenik.Ocena.ToString();
        }

        private void btexit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
