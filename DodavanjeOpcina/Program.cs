using RS1_vjezbe.EF;
using RS1_vjezbe.EntityModels;
using System;
using System.Threading;

namespace DodavanjeOpcina
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC to stop");

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                Thread.Sleep(1000);
                Console.WriteLine("Unesite naziv nove općine: ");

                var novaOpcina = new Opcina { NazivOpcine = Console.ReadLine() };
                MojDbContext dbContext = new MojDbContext();
                dbContext.Add(novaOpcina);
                dbContext.SaveChanges();
            }
        }
    }
}
