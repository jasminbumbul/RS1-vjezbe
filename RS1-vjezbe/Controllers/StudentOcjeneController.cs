using Microsoft.AspNetCore.Mvc;
using RS1_vjezbe.EF;
using RS1_vjezbe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_vjezbe.Controllers
{
    public class StudentOcjeneController : Controller
    {
        MojDbContext db = new MojDbContext();
        public IActionResult Prikaz(int StudentID)
        {
            var temp = db.Ocjena.Where(o => o.StudentID == StudentID)
                .Select(s => new StudentOcjenePrikazVM
                {
                    ID=s.ID,
                    BrojcanaOcjena = s.OcjenaBrojcano,
                    Datum = s.Datum,
                    NazivPredmeta = s.Predmet.Naziv
                }).ToList();

            return View(temp);
        }

        public IActionResult Uredi(int OcjenaID)
        {
            StudentOcjeneUrediVM temp = db.Ocjena.Where(o => o.ID == OcjenaID)
                .Select(o => new StudentOcjeneUrediVM() {
                    ID=o.ID,
                    Datum = o.Datum,
                    Ocjena = o.OcjenaBrojcano
                }).Single();

            return View(temp);
        }

        public IActionResult Snimi(StudentOcjeneUrediVM x)
        {
            var ocjena = db.Ocjena.Find(x.ID);
            ocjena.OcjenaBrojcano = x.Ocjena;
            ocjena.Datum = x.Datum;

            db.SaveChanges();

            //return RedirectToAction("Prikaz", new {StudentID=ocjena.StudentID });
            return Redirect("/StudentOcjene/Prikaz?StudentID=" + ocjena.StudentID);
        }
    }
}
