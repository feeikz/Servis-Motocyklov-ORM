using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevisMotocyklov.Database
{
    public class Zakaznik
    {
        public int ID { get; set; }
        public string meno { get; set; }
        public string priezvisko { get; set; }
        public string telefon { get; set; }
        public int pristup { get; set; }
        public int? karta { get; set; }
        public String CeleMeno { get { return this.meno + " " + this.priezvisko; } }

        public String login { get; set; }
        public String heslo { get; set; }

        public int strieborna = 5;
        public int zlata = 10;
        public int platinova = 15;


    }
}
