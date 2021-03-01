using Business.Concrete;
using Core.Entities.Concrete;
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
            //  GetCarsDetailTest();
            //   GetCarsDetailTest2();
            //GetByIdTest();
            //CarAddTest();
            //CarUpdateTest();


            //UserAddTest();
            //CustomerAddTest();
            AracKiralaTest();
        }

        private static void UserAddTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(
                new User
                {
                    FirstName = "Ahmet",
                    LastName = "candan",
                    Email = "acandan@gmail.com",
                    Password = "123"
                });
            Console.WriteLine(result.Message);

        }

        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal() );
            var result =  customerManager.Add(
                new Customer { UserId =1, CompanyName ="ornek firma"  } );
            Console.WriteLine(result.Message);
        }

        private static void AracKiralaTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal() );
            var result = rentalManager.Add(new Rental
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Now.Date,                
            });
            Console.WriteLine(result.Message);
        }

        private static void AracKiralaUpdateTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Now.Date,
                ReturnDate = DateTime.Now.Date
            });

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
            Console.WriteLine(carManager.GetById(1).Data.Name);
        }

        private static void GetCarsDetailTest2()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var carDetailDto in result.Data)
                {
                    Console.WriteLine("{0}/{1}/{2}/{3} ", carDetailDto.CarName, carDetailDto.BrandName,
                                                          carDetailDto.ColorName, carDetailDto.DailyPrice);


                };
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarsDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var carDetailDto in carManager.GetCarDetails().Data )
            {
                Console.WriteLine("{0}/{1}/{2}/{3} ", carDetailDto.CarName, carDetailDto.BrandName,
                                                      carDetailDto.ColorName, carDetailDto.DailyPrice);


            };
        }

        private static void oncekiTestler()
        {
            CarManager carManager = new CarManager(new EfCarDal()); //InMemoryCarDal() 

            foreach (var car in carManager.GetAll().Data )
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
            foreach (var car in carManager.GetAll().Data )
            {
                Console.WriteLine(car.Id + "-" + car.BrandId + "-" + car.ColorId + " " + car.ModelYear);
            }
        }
    
    }
}
