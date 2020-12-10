using Microsoft.AspNetCore.Mvc;
using Podaci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_vjezbe.Controllers
{
    public class TestniPodaciController : Controller
    {
        public IActionResult Index()
        {
            DbInicijalizator.Generisi();

            return View();
        }
    }
}
