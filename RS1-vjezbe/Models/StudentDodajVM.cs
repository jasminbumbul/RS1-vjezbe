using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_vjezbe.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_vjezbe.Models
{
    public class StudentDodajVM
    {
        public List<SelectListItem> Opcine;
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int OpcinaRodjenjaID { get; set; }
        public int OpcinaPrebivalistaID { get; set; }
    }
}
