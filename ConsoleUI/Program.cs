using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
            //InMemoryTest();
            //BrandTEst();
            // ColorTest();
            //CarTest();
            CarManager carManager = new CarManager(new EfCarDal());


            
            







        }

        private static void CarTest()
        {
            List<Car> _cars = new List<Car>
            {
                new Car{BrandId=1,ColorId=2,ModelYear="2010",DailyPrice=1500,Description="Tüplu"},
                new Car{BrandId=1,ColorId=3,ModelYear="2012",DailyPrice=170,Description="Dizel"},
                new Car{BrandId=1,ColorId=8,ModelYear="2005",DailyPrice=180,Description="Tüplü"},
                new Car{BrandId=5,ColorId=10,ModelYear="2009",DailyPrice=195,Description="Arazi aracı"},
                new Car{BrandId=5,ColorId=6,ModelYear="2008",DailyPrice=185,Description="Tüplü"},
                new Car{BrandId=15,ColorId=1,ModelYear="2006",DailyPrice=190,Description="Arazi Aracı"},
                new Car{BrandId=10,ColorId=10,ModelYear="2010",DailyPrice=210,Description="Dizel"},
                new Car{BrandId=18,ColorId=2,ModelYear="2015",DailyPrice=180,Description="Benzinli"},
                new Car{BrandId=18,ColorId=4,ModelYear="2016",DailyPrice=175,Description="Arazi aracı"},
                new Car{BrandId=18,ColorId=8,ModelYear="2014",DailyPrice=140,Description="Tüplü"},
                new Car{BrandId=18,ColorId=8,ModelYear="2014",DailyPrice=140,Description="Arazi Aracı"},
                new Car{BrandId=18,ColorId=8,ModelYear="2014",DailyPrice=140,Description="Arazi Aracı"}
            };

            CarManager carManager = new CarManager(new EfCarDal());

            // ekleme bölümü
            foreach (var car in _cars)
            {
                carManager.Add(car);

            }

            // 4 nolu kaydın DailyPrice değeri 205 yerine 195 yazılmış düzeltilecek

            Car carToUpdate = new Car();
            carToUpdate.Id = 4;
            carToUpdate.BrandId = 5;
            carToUpdate.ColorId = 10;
            carToUpdate.ModelYear = "2009";
            carToUpdate.DailyPrice = 205;
            carToUpdate.Description = "Arazi Aracı";

            carManager.Update(carToUpdate);

            // 11 ve 12 nolu kayıt örnek için mükerrer girildiğinden 12 nolu kayıt silinecek

            Car carToDelete = new Car();
            carToDelete.Id = 12;

            carManager.Delete(carToDelete);


            // Tüm araçları listeleme
            Console.WriteLine(String.Format("{0,-3} {1,-7}  {2,-7} {3,-15} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(String.Format("{0,4} {1,4}  {2,4} {3,-10} {4,-10} {5,-10}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

            }

            // BrandId si 18 olan tüm araçları listeleme
            Console.WriteLine(String.Format("{0,-3} {1,-7}  {2,-7} {3,-15} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));
            foreach (var car in carManager.GetCarsByBrandId(18))
            {
                Console.WriteLine(String.Format("{0,4} {1,4}  {2,4} {3,-10} {4,-10} {5,-10}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

            }

            // ColorId  si 8 olan tüm araçları listeleme
            Console.WriteLine(String.Format("{0,-3} {1,-7}  {2,-7} {3,-15} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));
            foreach (var car in carManager.GetCarsByColorId(8))
            {
                Console.WriteLine(String.Format("{0,4} {1,4}  {2,4} {3,-10} {4,-10} {5,-10}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

            }

            // Id si 10 olan aracın bilgilerini getirme 
            Console.WriteLine(String.Format("{0,-3} {1,-7}  {2,-7} {3,-15} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));

            Car carToGet = new Car();
            carToGet = carManager.Get(10);
            {
                Console.WriteLine(String.Format("{0,4} {1,4}  {2,4} {3,-10} {4,-10} {5,-10}", carToGet.Id, carToGet.BrandId, carToGet.ColorId, carToGet.ModelYear, carToGet.DailyPrice, carToGet.Description));

            }

            // Araç ile birlikte ve marka ve rengini getirme Dto örneği

            Console.WriteLine(String.Format("{0,-4} {1,20}  {2,20} {3,-10} {4,-10} {5,-10}", "Id", "BrandName", "ColorName", "Model Year", "DailyPrice", "Description"));
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(String.Format("{0,4} {1,20}  {2,20} {3,-10} {4,-10} {5,-10}", car.CarId, car.BrandName, car.ColorName, car.ModelYear, car.DailyPrice, car.Description));

            }

            // DailyPrice değeri 170 - 205 aralığında olan araçları getirme

            Console.WriteLine(String.Format("{0,-4} {1,-4}  {2,-4} {3,-10} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));
            foreach (var car in carManager.GetByDailyPrice(170, 205))
            {
                Console.WriteLine(String.Format("{0,4} {1,4}  {2,4} {3,-10} {4,-10} {5,-10}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

            }








        }

        private static void ColorTest()
        {
            List<Color> _colors = new List<Color>
            {
                new Color{Name="Metallic"},
                new Color{Name="Blue"},
                new Color{Name="Silver"},
                new Color{Name="Gray"},
                new Color{Name="Green"},
                new Color{Name="Pearl"},
                new Color{Name="PearlPurple"},
                new Color{Name="Red"},
                new Color{Name="Paint"},
                new Color{Name="White"},
                new Color{Name="White"}

            };

            // Listenin tümünü vt ye ekleyecez
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in _colors)
            {
                colorManager.Add(color);

            }

            // 7 nolu renk Purple yazılacağına PearlPurple yazılmış düzeltilecek
            Color colorToUpdate = new Color();
            colorToUpdate.Id = 7;
            colorToUpdate.Name = "Purple";
            colorManager.Update(colorToUpdate);

            // 10 ve 11 id nolu renklerin ikisi de White yazılmış 11 nolu fazla olan id silinecek
            Color colorToDelete = new Color();
            colorToDelete.Id = 11;

            colorManager.Delete(colorToDelete);

            // Tüm renkleri listeleme
            Console.WriteLine(String.Format("{0,-3} {1,20}", "Id", "ColorName"));

            foreach (var color in colorManager.GetAll())
            {

                Console.WriteLine(String.Format("{0,-3} {1,20}", color.Id, color.Name));
            }

            // 5 nolu rengi getirme 
            Console.WriteLine(String.Format("{0,-3} {1,20}", "Id", "ColorName"));

            Color colorToGet = new Color();

            colorToGet = colorManager.Get(5);



            Console.WriteLine(String.Format("{0,-3} {1,20}", colorToGet.Id, colorToGet.Name));








        }

        private static void BrandTEst()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            List<Brand> _brands = new List<Brand> {
                new Brand{Name="Audi"},
                new Brand{Name="Bmw"},
                new Brand{Name="Citroen"},
                new Brand{Name="Dacia"},
                new Brand{Name="Fiat"},
                new Brand{Name="Honda"},
                new Brand{Name="Hyundai"},
                new Brand{Name="Isuzu"},
                new Brand{Name="Mitsubishi"},
                new Brand{Name="Nisan"},
                new Brand{Name="Opel"},
                new Brand{Name="Porsche"},
                new Brand{Name="Renault"},
                new Brand{Name="RenaultSeat"},
                new Brand{Name="Skoda"},
                new Brand{Name="Suzuki"},
                new Brand{Name="Toyota"},
                new Brand{Name="Volkswagen"},
                new Brand{Name="Volvo"},
                new Brand{Name="Volvo"}
           };

            // listedeki markaları boş vt ye atacaz
            foreach (var brand in _brands)
            {
                brandManager.Add(brand);
            }

            Brand brandToUpdate = new Brand();
            brandToUpdate.Id = 10;
            brandToUpdate.Name = "Nissan";
            // id si 10 olan ürünü bilerek Nissan yerine Nisan yapmıştım. onu düzeltecez
            brandManager.Update(brandToUpdate);

            Brand brandToDelete = new Brand();
            brandToDelete.Id = 20;

            // id si 19 ve 20 olan markayı  bilerek iki defa yazdım. Fazlalık olan 20 noluyu silecez
            brandManager.Delete(brandToDelete);

            // Tüm markaları listeleme
            Console.WriteLine(String.Format("{0,-3} {1,20}", "Id", "BrandName"));
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(String.Format("{0,-3} {1,20}", brand.Id, brand.Name));
            }

            // 11 nolu markayı listeleme 
            Brand brandToGet = new Brand();
            brandToGet = brandManager.Get(11);


            Console.WriteLine(String.Format("{0,-3} {1,20}", "Id", "BrandName"));

            Console.WriteLine(String.Format("{0,-3} {1,20}", brandToGet.Id, brandToGet.Name));



        }

        private static void InMemoryTest()
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

            Console.WriteLine(String.Format("{0,-3} {1,-7}  {2,-7} {3,-15} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));
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



            Console.WriteLine(String.Format("{0,-3} {1,-15}", "Id", "Brand Name"));
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(String.Format("{0,3} {1,-15}", brand.Id, brand.Name));
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
