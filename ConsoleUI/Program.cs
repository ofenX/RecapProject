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

            carManager.GetAllBrands();
            
               foreach (var brand in carManager.GetAllBrands())
               {
           Console.WriteLine(brand.Id+"\t"+brand.BrandName);
           

               }

            Console.WriteLine("**************************************");
            

            carManager.GetAllColors();

            foreach (var color in carManager.GetAllColors())
            {
                Console.WriteLine(color.Id + "\t" + color.ColorName);
              
            }

            
            Console.WriteLine("**************************************");
            carManager.GetAllCarsList();

            foreach (var car in carManager.GetAllCarsList())
            {
                Console.WriteLine(String.Format("{0,4} {1,-10}  {2,-10} {3,-10} {4,-10} {5,-10}", car.Id, car.BrandName, car.ColorName, car.ModelYear, car.DailyPrice, car.Description));

            }

            Console.WriteLine("************ by colors **************************");
            carManager.GetAllByColors();
            foreach (var car in carManager.GetAllByColors())
            {
                
              
                Console.WriteLine(String.Format("{0,4} {1,-10}  {2,-10} {3,-10} {4,-10} {5,-10}", car.Id,car.BrandName,car.ColorName,car.ModelYear,car.DailyPrice,car.Description));
              


            }
            Console.WriteLine("************ by brandname **************************");
            carManager.GetAllByColors();
            foreach (var car in carManager.GetAllByBrands())
            {


                Console.WriteLine(String.Format("{0,4} {1,-10}  {2,-10} {3,-10} {4,-10} {5,-10}", car.Id, car.BrandName, car.ColorName, car.ModelYear, car.DailyPrice, car.Description));



            }





        }
    }
}
