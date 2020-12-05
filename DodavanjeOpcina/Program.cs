using RS1_vjezbe.EF;
using RS1_vjezbe.EntityModels;
using System;


namespace DodavanjeOpcina
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Unesite naziv nove općine: ");

            var novaOpcina = new Opcina { NazivOpcine = Console.ReadLine() };

            MojDbContext dbContext = new MojDbContext();
            dbContext.Add(novaOpcina);
            dbContext.SaveChanges();
        }
    }
}
