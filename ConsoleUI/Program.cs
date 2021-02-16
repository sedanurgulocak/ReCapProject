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
            //CarTest();

            //BrandTest();

            //ColorTest();

            RentalTest();

            //UserTest();

            //CustomerTest();
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            /*var result = rentalManager.Add(new Rental { CarId = 3, CustomerId = 3, 
                RentDate = new DateTime(2021, 2, 16), ReturnDate = new DateTime(2021, 2, 28) });*/
            

            /*var result = rentalManager.Add(new Rental
            {
                CarId = 2,
                CustomerId = 2,
                RentDate = new DateTime(2021, 3, 16),
                ReturnDate = new DateTime(2021, 3, 20)
            });*/

            //Console.WriteLine(result.Message);

            /*foreach (var rent in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rent.CarId + "---" + rent.CustomerId +"--"+ rent.RentDate + "--"+ rent.ReturnDate);
            }*/

            
        }
        private static void CustomerTest()
        {
            /*CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer {CompanyName="M3 Müsteri", UserId=4 });
            Console.WriteLine(result.Message);*/
        }

        private static void UserTest()
        {
            /*UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User { FirstName = "Seda", LastName = "Nur", Email = "nur@gmail.com", Password = "789" });

            Console.WriteLine(result.Message);*/

        }   

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //colorManager.Add(new Color {ColorName = "Gri" });
            //colorManager.Update(new Color {ColorId=1003, ColorName = "Gri" });


            /*foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);

            }*/
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //brandManager.Delete(new Brand {BrandId=4 ,BrandName = "MINI" });

            /*foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }*/
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Add(new Car {BrandId=1, ColorId=1, ModelYear="2021", Descriptions="Manuel dizel", DailyPrice = 500 } );

            //carManager.Update(new Car { Id = 1003, BrandId = 2, ColorId = 3, ModelYear = "1990", Descriptions = "Manuel dizel", DailyPrice = 600});

            var result = carManager.GetCarDetailDtos();

            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Descriptions + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
