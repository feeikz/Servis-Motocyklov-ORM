using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevisMotocyklov.Database
{
    public class Oprava
    {
        public int ID { get; set; }
        public decimal cena { get; set; }
        public int pocet_hodin { get; set; }
        public DateTime datum { get; set; }
        public int Objednavka_ID { get; set; }
        public int Zamestnanec_ID { get; set; }
      
    }
}
