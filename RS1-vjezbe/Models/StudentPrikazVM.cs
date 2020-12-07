using RS1_vjezbe.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_vjezbe.Models
{
    public class StudentPrikazVM
    {
        public List<Row> studenti;
        public string q;

    }
    public class Row
    {
        public int ID { get; set; }
        public string BrojIndeksa { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string OpcinaPrebivalista { get; set; }
        public string OpcinaRodjenja { get; set; }
    }
}
