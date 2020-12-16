using Microsoft.AspNetCore.Http;
using Podaci.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_vjezbe.Helper
{
    public static class Autentifikacija
    {
        public static void SetLogiraniKorisnik(this HttpContext httpContext, KorisnickiNalog k)
        {
            httpContext.Session.Set<KorisnickiNalog>("nekiKljucVarijabla", k);
        }

        public static KorisnickiNalog GetLogiraniKorisnik(this HttpContext httpContext)
        {
            var k = httpContext.Session.Get<KorisnickiNalog>("nekiKljucVarijabla");
            return k;
        }

    }
}
