using Microsoft.AspNetCore.Mvc;
using Podaci.EntityModels;
using RS1_vjezbe.EF;
using RS1_vjezbe.Helper;
using RS1_vjezbe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_vjezbe.Controllers
{
    public class AutentifikacijaController : Controller
    {
        MojDbContext db = new MojDbContext();
        public static KorisnickiNalog logiraniKorisnik = null;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(AutentifikacijaIndexVM x)
        {
            KorisnickiNalog nalog = db.KorisnickiNalog.SingleOrDefault(k => k.KorisnickoIme == x.KorisnickoIme && k.Lozinka == x.Lozinka);

            if(nalog == null)
            {
                TempData["porukaGreska"] = "Neispravan username/password";
                return Redirect("/Autentifikacija/Index");
            }
            this.HttpContext.Session.Set("aaa", nalog);
            logiraniKorisnik = nalog;

            return Redirect("/");
        }

        public IActionResult Logout()
        {
            logiraniKorisnik = null;
            return Redirect("/");
        }
    }
}
