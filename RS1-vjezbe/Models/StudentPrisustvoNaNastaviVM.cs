using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_vjezbe.Models
{
    public class StudentPrisustvoNaNastaviVM
    {
        public string ImeStudenta { get; set; }
        public List<Zapis> Zapisi{ get; set; }

        public class Zapis
        {
            public string Predmet { get; set; }
            public DateTime Datum { get; set; }
        }
    }
}
