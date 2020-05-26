using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevisMotocyklov.Database
{
    public class Zamestnanec
    {
        public int ID { get; set; }
        public string meno { get; set; }
        public string priezvisko { get; set; }
        public string telefon { get; set; }
        public int cena_prace { get; set; }
        public int pristup { get; set; }
        public String CeleMeno { get { return this.meno + " " + this.priezvisko; } }
        public String login { get; set; }
        public String heslo { get; set; }
    }
}
