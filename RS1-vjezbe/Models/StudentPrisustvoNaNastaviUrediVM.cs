using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_vjezbe.Models
{
    public class StudentPrisustvoNaNastaviUrediVM
    {
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        public string Komentar { get; set; }
        public bool Prisustvo { get; set; }
    }
}
