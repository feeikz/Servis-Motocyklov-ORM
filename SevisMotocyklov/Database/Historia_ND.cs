using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevisMotocyklov.Database
{
    public class Historia_ND
    {
        public int ID { get; set; }
        public string nazov { get; set; }
        public string vyrobca { get; set; }
        public DateTime datum_nakupu { get; set; }
        public double nakupna_cena { get; set; }
        public double predajna_cena { get; set; }
        public int Oprava_ID { get; set; }
    }
}
