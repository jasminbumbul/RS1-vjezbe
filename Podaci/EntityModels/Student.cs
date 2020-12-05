using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_vjezbe.EntityModels
{
    public class Student
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojIndeksa { get; set; }

        public int? OpcinaRodjenjaID { get; set; }
        public Opcina OpcinaRodjenja { get; set; }
        public int? OpcinaPrebivalistaID { get; set; }
        public Opcina OpcinaPrebivalista { get; set; }

    }
}
