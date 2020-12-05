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

            TempData["porukaInfo"] = "Uspješno ste obrisali studenta " + tempStudent.Ime;

            return Redirect("/Student/Poruka");
        }
        public IActionResult Snimi(int StudentID, string Ime, string Prezime, int OpcinaRodjenjaID, int OpcinaPrebivalistaID)
        {
            MojDbContext db = new MojDbContext();

            Student student;

            if(StudentID==0)
            {
                student = new Student();
                db.Student.Add(student);
                TempData["porukaInfo"] = "Uspješno ste dodali studenta " + Ime;
            }
            else
            {
                student = db.Student.Find(StudentID);
                TempData["porukaInfo"] = "Uspješno ste editovali studenta " + student.Ime;

            }


            student.Ime = Ime;
            student.Prezime = Prezime;
            student.OpcinaRodjenjaID = OpcinaRodjenjaID;
            student.OpcinaPrebivalistaID = OpcinaPrebivalistaID;
            

            db.SaveChanges();

            return Redirect("/Student/Poruka"); 
        }


 
        
        public IActionResult Uredi(int StudentID)
        {
            MojDbContext db = new MojDbContext();
            List<Opcina> opcine = db.Opcina.OrderBy(a => a.NazivOpcine).ToList();

            ViewData["opcine"] = opcine;
            var tempStudent = StudentID==0? new Student(): db.Student.Find(StudentID);
            ViewData["student"] = tempStudent;

            return View("Uredi");
        }

        public IActionResult Poruka()
        {
            return View("Poruka");
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
