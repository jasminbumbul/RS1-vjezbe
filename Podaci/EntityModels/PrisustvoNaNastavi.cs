using RS1_vjezbe.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Podaci.EntityModels
{
    public class PrisustvoNaNastavi
    {
        public int ID { get; set; }
        public DateTime Datum { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int PredmetID { get; set; }
        public Predmet Predmet { get; set; }
        public bool Prisutan { get; set; }
        public string Komentar { get; set; }

    }
}
