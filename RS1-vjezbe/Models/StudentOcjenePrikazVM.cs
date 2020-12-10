using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_vjezbe.Models
{
    public class StudentOcjenePrikazVM
    {
        public int ID { get; set; }
        public string NazivPredmeta { get; set; }
        public int BrojcanaOcjena { get; set; }
        public DateTime Datum { get; set; }
    }
}
