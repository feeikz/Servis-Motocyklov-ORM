using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevisMotocyklov.Database
{
    public class Objednavka
    {
        public int ID { get; set; }
        public DateTime datum_vytvorenia { get; set; }
        public DateTime datum_uhradenia { get; set; }
        public int uhradene { get; set; }
        public int Zakaznik_ID { get; set; }
        public int Motocykel_ID { get; set; }
        public int? Zamestnanec_ID { get; set; }

        //tmp variables
        public string ZakaznikMeno { get; set; }
        public string NazovMotorky { get; set; }
        public int PocetOprav { get; set; }
        public decimal Cena { get; set; }
        public String ZamestnanecMeno { get; set; }
        public int? karta { get; set; }
        public string telefon { get; set; }
        public string meno { get; set; }
        public string priezvisko { get; set; }


        public decimal vypoocitajZlavu(decimal cena, int zlava)
        {
            int percenta = 100;
            percenta = percenta - zlava;
            cena = (cena / 100) * percenta;
            return cena;
        }
    }
}
