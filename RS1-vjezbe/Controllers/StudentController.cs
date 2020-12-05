using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_vjezbe.EF;
using RS1_vjezbe.EntityModels;

namespace RS1_vjezbe.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Obrisi(int StudentID)
        {
            MojDbContext db = new MojDbContext();

            Student tempStudent = db.Student.Find(StudentID);

            db.Remove(tempStudent);
            db.SaveChanges();

            return Redirect("/Student/ObrisiPoruka");
        }
        public IActionResult Snimi(string Ime, string Prezime, int OpcinaRodjenjaID, int OpcinaPrebivalistaID)
        {
            var student = new Student
            {
                Ime = Ime,
                Prezime = Prezime,
                OpcinaRodjenjaID = OpcinaRodjenjaID,
                OpcinaPrebivalistaID = OpcinaPrebivalistaID
            };

            MojDbContext db = new MojDbContext();

            db.Add(student);
            db.SaveChanges();

            return Redirect("/Student/DodajPoruka?StudentID="+student.ID); 
        }
        public IActionResult Dodaj()
        {
            MojDbContext db = new MojDbContext();
            List<Opcina> opcine = db.Opcina.OrderBy(a => a.NazivOpcine).ToList();
            ViewData["opcine"] = opcine;
            return View();
        }

        public IActionResult DodajPoruka(int StudentID)
        {
            MojDbContext db = new MojDbContext();
            Student tempStudent = db.Student.Find(StudentID);
            ViewData["imeStudenta"] = tempStudent.Ime;
            return View();
        }
        
        public IActionResult ObrisiPoruka()
        {
            return View("ObrisiPoruka");
        }

        public IActionResult Prikaz(string q)
        {
            MojDbContext db = new MojDbContext();

            //kao neki join  
            List<Student> studenti = db.Student.Where(s=> q=="" || q==null || s.Ime.ToLower().StartsWith(q) 
            || s.Prezime.ToLower().StartsWith(q) 
            || s.BrojIndeksa == q).Include(a => a.OpcinaPrebivalista).Include(a => a.OpcinaRodjenja).ToList();

            //List<Student> filtriraniPodaci = new List<Student>();

            //foreach (var s in podaci)
            //{
            //    if(s.Ime.ToLower().StartsWith(q) || s.Prezime.ToLower().StartsWith(q) || s.BrojIndeksa==q)
            //    {
            //        filtriraniPodaci.Add(s);
            //    }
            //}

           

            ViewData["qKey"] = q;
            ViewData["studenti"] = studenti;

            return View();
        }
    }
}
