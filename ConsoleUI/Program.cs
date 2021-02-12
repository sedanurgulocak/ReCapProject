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
            CarTest();

            //BrandTest();

            //ColorTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //colorManager.Add(new Color {ColorName = "Gri" });
            //colorManager.Update(new Color {ColorId=1003, ColorName = "Gri" });


            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);

            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //brandManager.Delete(new Brand {BrandId=4 ,BrandName = "MINI" });

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
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
