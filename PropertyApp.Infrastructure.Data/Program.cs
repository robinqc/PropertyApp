using PropertyApp.Infrastructure.Data.Contexts;
using System;

namespace PropertyApp.Infrastructure.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la DB si no existe...");
            Contexts.MainContext db = new Contexts.MainContext();
            db.Database.EnsureCreated();
            Console.WriteLine(db.Database);
            Console.ReadKey();
        }
    }
}