using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UceniciMenu
{
    public class Ucenik
    {
        static double ocena_ukupno;
        static double prosecna_ocena;
        static int broj_ucenika;
        int sifra;
        string ime;
        string prezime;
        string telefon;
        int ocena;

        public Ucenik(int sifra, string ime, string prezime, string telefon, int ocena)
        {
            this.Sifra = sifra;
            this.ime = ime;
            this.prezime = prezime;
            this.telefon = telefon;
            this.ocena = ocena;
            ocena_ukupno += ocena;
            broj_ucenika++;
            prosecna_ocena = ocena_ukupno / broj_ucenika;
        }

        public static double Prosecna_ocena { get => prosecna_ocena; set => prosecna_ocena = value; }
        public int Sifra { get => sifra; set => sifra = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public int Ocena { get => ocena; set => ocena = value; }
    }
}
