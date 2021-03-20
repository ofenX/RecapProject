using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

           



            CarManager carManager = new CarManager(new InMemoryCarDal());


            Console.WriteLine("********** GetAll Cars ****************************");
              
               carManager.GetAll();
            Console.WriteLine(String.Format("{0,-3} {1,-7}  {2,-7} {3,-15} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));
            foreach (var car in carManager.GetAll())
               {
                Console.WriteLine(String.Format("{0,4} {1,4}  {2,4} {3,-10} {4,-10} {5,-10}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

            }

            Console.WriteLine("**********GetAll Cars By Brand Id****************************");


            carManager.GetCarsByBrandId(2);

            Console.WriteLine(String.Format("{0,-3} {1,-7}  {2,-7} {3,-15} {4,-10} {5,-10}", "Id", "BrandId","ColorId" , "Model Year","DailyPrice" ,"Description"));
            foreach (var car in carManager.GetCarsByBrandId(18))
            {
                Console.WriteLine(String.Format("{0,3} {1,7}  {2,7} {3,-15} {4,-10} {5,-10}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));


            }


            Console.WriteLine("********GetAll Cars By Color Id******************************");


            carManager.GetCarsByColorId(10);
            Console.WriteLine(String.Format("{0,-3} {1,-7}  {2,-7} {3,-15} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));
            foreach (var car in carManager.GetCarsByColorId(10))
            {
                Console.WriteLine(String.Format("{0,3} {1,7}  {2,7} {3,-15} {4,-10} {5,-10}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));
            }



           





            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            brandManager.GetAll();

            Console.WriteLine("******** GetAll Brands ******************************");


           
            Console.WriteLine(String.Format("{0,-3} {1,-15}", "Id","Brand Name"));
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(String.Format("{0,3} {1,-15}",  brand.Id, brand.Name));
            }

            
            Console.WriteLine("******** Get a Brand ******************************");


            brandManager.Get(3);


            Console.WriteLine(String.Format("{0,-3} {1,-15}", "Id", "Brand Name"));
           
                Console.WriteLine(String.Format("{0,3} {1,-15}", brandManager.Get(3).Id, brandManager.Get(3).Name));



            ColorManager colorManager = new ColorManager(new InMemoryColorDal());
            colorManager.GetAll();

            Console.WriteLine("******** GetAll Colors ******************************");



            Console.WriteLine(String.Format("{0,-3} {1,-15}", "Id", "Color Name"));
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(String.Format("{0,3} {1,-15}", color.Id, color.Name));
            }


            Console.WriteLine("******** Get a Color ******************************");


            colorManager.Get(5);


            Console.WriteLine(String.Format("{0,-3} {1,-15}", "Id", "Color Name"));

            Console.WriteLine(String.Format("{0,3} {1,-15}", colorManager.Get(5).Id, colorManager.Get(5).Name));






        }
    }
}
