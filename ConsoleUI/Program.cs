using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //oncekiTestler();
            GetCarsDetailTest();
            //GetByIdTest();

            //CarAddTest();

            //CarUpdateTest();
        }

        private static void CarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car
            {
                Id = 2,
                BrandId = 10,
                ColorId = 5,
                Name = "Volvo s80",
                ModelYear = 2019,
                DailyPrice = 800
            });
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(
                new Car
                {
                    Name = "Giulietta 1.6 JTD Distinctive",
                    BrandId = 3,
                    ColorId = 5,
                    ModelYear = 2020,
                    DailyPrice = 600,
                    Description = "Hatchback 5 kapı"
                });
        }

        private static void GetByIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine(carManager.GetById(1).Name);
        }

        private static void GetCarsDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var carDetailDto in carManager.GetCarDetails())
            {
                Console.WriteLine("{0}/{1}/{2}/{3} ", carDetailDto.CarName, carDetailDto.BrandName,
                                                      carDetailDto.ColorName, carDetailDto.DailyPrice);


            };
        }

        private static void oncekiTestler()
        {
            CarManager carManager = new CarManager(new EfCarDal()); //InMemoryCarDal() 

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "-" + car.BrandId + "-" + car.ColorId + " " + car.ModelYear);
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
            });

            Console.WriteLine("---------------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "-" + car.BrandId + "-" + car.ColorId + " " + car.ModelYear);
            }
        }
    
    }
}
