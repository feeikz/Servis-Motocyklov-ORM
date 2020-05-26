using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevisMotocyklov.Database
{
    public class Nahradny_diel
    {
        public int ID { get; set; }
        public string nazov { get; set; }
        public string vyrobca { get; set; }
        public DateTime datum_nakupu { get; set; }
        public decimal nakupna_cena { get; set; }
        public decimal predajna_cena { get; set; }
        public int? OpravaID { get; set; }
    }
}
