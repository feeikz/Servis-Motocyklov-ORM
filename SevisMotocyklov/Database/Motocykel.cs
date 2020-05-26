using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevisMotocyklov.Database
{
    public class Motocykel
    {
        public int ID { get; set; }
        public string vyrobca { get; set; }
        public string model { get; set; }
        public string typ { get; set; }
        public int obsah_valca { get; set; }
        public int rok_vyroby { get; set; }
    }
}
