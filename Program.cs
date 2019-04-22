using AutoMapper;
using StartUp.Context;
using StartUp.MappingConfiguration;
using System;

namespace StartUp
{
   public class Program
    {
      public  static void Main(string[] args)
        {
            Console.WriteLine("PharmacyManagment System");

            using (PharmacySystemDbContext context = new PharmacySystemDbContext())

            {
                Engine engine = new Engine(context);
                engine.Run();
            }


           
        }
    }
}
