using Microsoft.AspNetCore.Mvc;
using RS1_vjezbe.EF;
using RS1_vjezbe.EntityModels;
using RS1_vjezbe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_vjezbe.Controllers
{
    public class StudentPrisustvoNaNastaviController : Controller
    {
            MojDbContext db = new MojDbContext();
        public IActionResult Prikaz(int StudentID)
        {
            var temp = new StudentPrisustvoNaNastaviPrikazVM();

            Student s = db.Student.Find(StudentID);
            temp.ImeStudenta = s.Ime + " " + s.Prezime;

            temp.Zapisi = db.PrisustvoNaNastavi.Where(p => p.StudentID == StudentID)
                .Select(p => new StudentPrisustvoNaNastaviPrikazVM.Zapis
                {
                    ID=p.ID,
                    Datum = p.Datum,
                    Predmet = p.Predmet.Naziv,
                    Komentar = p.Komentar,
                    Prisustvo = p.Prisutan
                }).ToList();

            return View(temp);
        }

        public IActionResult Uredi(int PrisustvoID)
        {
            var tempPrisustvo = db.PrisustvoNaNastavi.Where(p => p.ID == PrisustvoID)
                .Select(p=> new StudentPrisustvoNaNastaviUrediVM { 
                    ID=p.ID,
                    Datum=p.Datum,
                    Komentar=p.Komentar,
                    Prisustvo=p.Prisutan
                }).Single();

            return View(tempPrisustvo);
        }

        public IActionResult Snimi(StudentPrisustvoNaNastaviUrediVM x)
        {
            var tempPrisustvo = db.PrisustvoNaNastavi.Find(x.ID);
            tempPrisustvo.Komentar = x.Komentar;
            tempPrisustvo.Prisutan = x.Prisustvo;
            tempPrisustvo.Datum = x.Datum;

            db.SaveChanges();

            return Redirect("/StudentPrisustvoNaNastavi/Prikaz?PrisustvoID=" + tempPrisustvo.ID);
        }


    }
}
