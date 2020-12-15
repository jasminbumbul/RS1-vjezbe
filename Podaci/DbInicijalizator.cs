using Podaci.EntityModels;
using RS1_vjezbe.EF;
using RS1_vjezbe.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podaci
{
    public static class Ext
    {
        public static T GetRandomElement<T>(this List<T> list)
        {
            int x = new Random().Next(0, list.Count);
            return list[x];
        }
    }

    public class DbInicijalizator
    {

        public static string GetRandomString(int lenght = 3)
        {
            return Guid.NewGuid().ToString().Substring(0, lenght);
        }




        public static void Generisi()
        {
            MojDbContext db = new MojDbContext();


            var k = new KorisnickiNalog
            {
                KorisnickoIme = "admin",
                Lozinka = "admin"
            };
            db.KorisnickiNalog.Add(k);
            db.SaveChanges();
         
            if(db.Student.Any())
            {
                return;
            }

            var Opstine = new List<Opcina>();
            var Predmeti = new List<Predmet>();
            var Studenti = new List<Student>();

            for (int i = 0; i < 5; i++)
            {
                Opstine.Add(new Opcina { NazivOpcine = "Opstina" + GetRandomString() });
                Predmeti.Add(new Predmet { Naziv = "Predmet" + GetRandomString() });

            }

            for (int i = 0; i < 20; i++)
            {
                Studenti.Add(new Student()
                {
                    BrojIndeksa = GetRandomString(5),
                    Ime = GetRandomString(4),
                    Prezime = GetRandomString(4),
                    OpcinaPrebivalista = Opstine.GetRandomElement(),
                    OpcinaRodjenja = Opstine.GetRandomElement(),
                });
            }

            for (int i = 0; i < 100; i++)
            {
                db.Add(new Ocjene
                {
                    Datum = DateTime.Now,
                    OcjenaBrojcano = (i % 5) + 6,
                    Predmet = Predmeti.GetRandomElement(),
                    Student = Studenti.GetRandomElement()
                });
            }

            db.AddRange(Opstine);
            db.AddRange(Predmeti);
            db.AddRange(Studenti);
            db.SaveChanges();

            int j = 0;
            foreach (var x in db.Student)
            {
                j++;
                db.PrisustvoNaNastavi.Add(new PrisustvoNaNastavi
                {
                    Datum = DateTime.Now,
                    Predmet = Predmeti.GetRandomElement(),
                    Student = x,
                });
            }


            db.SaveChanges();
        }
    }
}
