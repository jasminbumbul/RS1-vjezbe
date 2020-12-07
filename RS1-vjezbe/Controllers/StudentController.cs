using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_vjezbe.EF;
using RS1_vjezbe.EntityModels;
using RS1_vjezbe.Helper;
using RS1_vjezbe.Models;

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
        public IActionResult Snimi(StudentDodajVM x)
        {
            MojDbContext db = new MojDbContext();

            Student student;

            if(x.ID==0)
            {
                student = new Student();
                db.Add(student);
                TempData["porukaInfo"] = "Uspješno ste dodali studenta " + x.Ime;
            }
            else
            {
                student = db.Student.Find(x.ID);
                TempData["porukaInfo"] = "Uspješno ste editovali studenta " + student.Ime;

            }


            student.Ime = x.Ime;
            student.Prezime = x.Prezime;
            student.OpcinaRodjenjaID = x.OpcinaRodjenjaID;
            student.OpcinaPrebivalistaID = x.OpcinaPrebivalistaID;
            

            db.SaveChanges();

            return Redirect("/Student/Poruka"); 
        }


 
        
        public IActionResult Uredi(int StudentID)
        {
            MojDbContext db = new MojDbContext();
            List<SelectListItem> opcine = db.Opcina.OrderBy(a => a.NazivOpcine).Select(a=> new SelectListItem { Value=a.ID.ToString(), Text=a.NazivOpcine }).ToList();

            //ViewData["opcine"] = opcine;
            StudentDodajVM tempStudent = StudentID == 0 ? new StudentDodajVM() : db.Student.Where(w => w.ID == StudentID)
                .Select(a => new StudentDodajVM
                {
                    ID = a.ID,
                    Ime = a.Ime,
                    OpcinaPrebivalistaID = a.OpcinaPrebivalistaID,
                    OpcinaRodjenjaID = a.OpcinaRodjenjaID,
                    Prezime = a.Prezime,
                    Opcine =  opcine

                }).Single();
            //ViewData["student"] = tempStudent;

            return View("Uredi",tempStudent);
        }

        public IActionResult Poruka()
        {
            return View("Poruka");
        }
        

        public IActionResult Prikaz(string q)
        {
            MojDbContext db = new MojDbContext();

            //kao neki join  
            List<Row> studenti = db.Student.Where(s => q == "" || q == null || s.Ime.ToLower().StartsWith(q)
            || s.Prezime.ToLower().StartsWith(q)
            || s.BrojIndeksa == q).Select(x => new Row
            {
                ID = x.ID,
                Ime = x.Ime,
                Prezime = x.Prezime,
                BrojIndeksa = x.BrojIndeksa,
                OpcinaPrebivalista = x.OpcinaPrebivalista.NazivOpcine,
                OpcinaRodjenja = x.OpcinaRodjenja.NazivOpcine
            }).ToList();
            /*Include(a => a.OpcinaPrebivalista).Include(a => a.OpcinaRodjenja)*/

            //List<Student> filtriraniPodaci = new List<Student>();

            //foreach (var s in podaci)
            //{
            //    if(s.Ime.ToLower().StartsWith(q) || s.Prezime.ToLower().StartsWith(q) || s.BrojIndeksa==q)
            //    {
            //        filtriraniPodaci.Add(s);
            //    }
            //}


            //nema potrebe za ovim jer su dodani modeli
            //ViewData["qKey"] = q;
            //ViewData["studenti"] = studenti;

            StudentPrikazVM m = new StudentPrikazVM();
            m.studenti = studenti;
            m.q = q;

            return View(m);
        }
    }
}
