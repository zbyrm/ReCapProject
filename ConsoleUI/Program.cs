using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager( new InMemoryCarDal() );

            foreach (var car in carManager.GetAll() )
            {
                Console.WriteLine(car.Id + "-"+ car.BrandId + "-" + car.ColorId + " " + car.ModelYear );
            }

            Console.WriteLine("---------------------");
            Console.WriteLine(carManager.GetById(3).ToString());

            carManager.Add(new Entities.Concrete.Car
            {
                Id = 6,
                BrandId = 4,
                ColorId = 2,
                DailyPrice = 100000,
                ModelYear = 2008,
                Description = "Ön tapon değişmiş "
            } );

            Console.WriteLine("---------------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "-" + car.BrandId + "-" + car.ColorId + " " + car.ModelYear);
            }
        }
    }
}
