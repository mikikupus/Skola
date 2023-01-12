using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*genericki red sadrzi stringove, omoguciti dodavanje i uklanjanje iz reda. Rez moze imati max 5 elemenata
 red na formi prikazati graficki kao pravougaonik koji:
-kada je prazan je obojen belom bojom
-ako je popunjen 20% taj element je prikazan zutom bojom
-ako ima 2 elementa oni su prikazani zelenom bojom
-za 3 elementa plava boja
-za 4 crvena
-ako je red potpuno popunjen crnom bojom*/
namespace PravougaonikGrafika
{
    public partial class Form1 : Form
    {
        Queue<string> red;
        Graphics g;
        Brush b;
        int x = 300;
        int y = 30;
        int height = 50;
        bool nacrtano = false;
        int j = 4;
        Color[] boje = new Color[] { Color.White, Color.Yellow, Color.Green, Color.Blue, Color.Red, Color.Black };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            red = new Queue<string>();
            g = CreateGraphics();

        }

        private void btdodaj_Click(object sender, EventArgs e)
        {
            if (txtelement.Text != "" && red.Count < 5)
            {
                red.Enqueue(txtelement.Text);
                DodajPravougaonik();
                txtelement.Text = "";
            }
        }
        private void btukloni_Click(object sender, EventArgs e)
        {
            if (red.Count > 0) 
            { 
                UkloniPravougaonik(); 
            }
        }
        private void DodajPravougaonik()
        {
            if(red.Count <=5)
            {
                b = new SolidBrush(boje[red.Count]);
                if (red.Count < 5 && red.Count >= 0)
                {
                    g.FillRectangle(b, x, y + ((j-1) * height), 100, 50);
                    j--;
                }
                else
                {
                    g.FillRectangle(b, x, y, 100, 200);
                }
            }
        }
        private void UkloniPravougaonik()
        {
            if(red.Count > 0)
            {
                if (red.Count == 5)
                {
                    int k = 4;
                    for (int i = 0; i < 4; i++)
                    {
                        b = new SolidBrush(boje[k--]);
                        g.FillRectangle(b, x, y + (i * height), 100, 50);
                    }
                }
                else
                {
                    b = new SolidBrush(boje[0]);
                    g.FillRectangle(b, x, y + (j++ * height), 100, 50);
                }
                red.Dequeue();
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(!nacrtano)
            {
                b = new SolidBrush(boje[0]);
                for (int i = 0; i < 4; i++)
                {
                    g.FillRectangle(b, x, y + ((i) * height), 100, 50);
                }
                nacrtano = true;
            }
           
        }
    }
}
