using PropertyApp.Infrastructure.Data.Contexts;
using System;

namespace PropertyApp.Infrastructure.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la DB si no existe...");
            PropertyContext db = new PropertyContext();
            db.Database.EnsureCreated();
            Console.WriteLine(db.Database);
            Console.ReadKey();
        }
    }
}