using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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
            // UserTest();
            //CustomerTest();
            // RentalTest();


           



            

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental1 = new Rental();
            rental1.CarId = 4;
            rental1.CustomerId = 4;
            rental1.Rentdate = new DateTime(2021, 02, 05);
            var result = rentalManager.Add(rental1);
            if (result.Success == true)

            {
                Console.WriteLine(Messages.RentalAdded);

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            List<Customer> _customers = new List<Customer>
            {
                new Customer() { UserId = 2, CompanyName = "Başarı İletişim" } ,
                new Customer() { UserId = 3, CompanyName = "Samancı Gıda" } ,
                new Customer() { UserId = 4, CompanyName = "Global Serviss" } ,
                new Customer() { UserId = 5, CompanyName = "Turuncu Kuruyemiş" } ,


            };
            foreach (var customer in _customers)
            {


                var result = customerManager.Add(customer);
                if (result.Success == true)
                {
                    Console.WriteLine(Messages.CustomerAdded);

                }
                else
                {
                    Console.WriteLine(result.Message);
                }


            }

            // Global Servis yanlışlıkla Global Serviss yazılmış düzeltilecek.
            Customer customerToUpdate = new Customer();
            customerToUpdate.Id = 3;
            customerToUpdate.UserId = 4;
            customerToUpdate.CompanyName = "Global Servis";
            var result2 = customerManager.Update(customerToUpdate);
            if (result2.Success == true)
            {
                Console.WriteLine(Messages.CustomerUpdated);

            }
            else
            {
                Console.WriteLine(result2.Message);
            }

            // Turuncu Kuruyemiş silinecek
            Customer customerToDelete = new Customer();
            customerToDelete.Id = 4;


            var result3 = customerManager.Delete(customerToDelete);
            if (result3.Success == true)
            {
                Console.WriteLine(Messages.CustomerDeleted);

            }
            else
            {
                Console.WriteLine(result3.Message);
            }

            var result4 = customerManager.GetAll();
            if (result4.Success == true)
            {


                foreach (var customer in result4.Data)

                {
                    Console.WriteLine("{0}        {1}          {2}", customer.Id, customer.UserId, customer.CompanyName);

                }
                Console.WriteLine(Messages.CustomersListed);

            }
            else
            {
                Console.WriteLine(result4.Message);
            }
            // Id si 1 olan müşterinin bilgilerini getir
            var result5 = customerManager.Get(1);
            if (result5.Success == true)
            {

                Console.WriteLine("{0}        {1}          {2}", result5.Data.Id, result5.Data.UserId, result5.Data.CompanyName);


                Console.WriteLine(Messages.CustomerListed);

            }
            else
            {
                Console.WriteLine(result5.Message);
            }


        }

        private static void UserTest()
        {
            List<User> _users = new List<User>()
            { new User{FirstName="Ahmet",LastName="KAPLAN",Email="ahmetkaplan@gmail.com",Password="123456789012"},
              new User{FirstName="Mehmet",LastName="SUCUk",Email="mehmetsucu1865@hotmail.com",Password="985456789012"},
              new User{FirstName="Ayşe",LastName="KIZILDEMİR",Email="kizildemiraysen@gmail.com",Password="654456789012"},
              new User{FirstName="Gülay",LastName="AKMAN",Email="gakman@gmail.com",Password="321456789012"},
              new User{FirstName="Serap",LastName="GÜNDÜZ",Email="serapgunduz85@outlook.com",Password="951456789012"},
            };

            User user1 = new User() { FirstName = "Serap", LastName = "GÜNDÜZ", Email = "serapgunduz85@outlook.com", Password = "951456789012" };

            UserManager userManager = new UserManager(new EfUserDal());



            //5 adet kullanıcıyı toplu olarak ekleme

            foreach (var user in _users)
            {
                var result = userManager.Add(user);
                if (result.Success == true)
                {
                    Console.WriteLine(Messages.UserAdded);

                }
                else
                {
                    Console.WriteLine(result.Message);
                }


            }
            // Mehmet SUCU adlı kullanıcı yanlışlıkla Mehmet SUCUk olarak girilmiş düzeltilecek
            User userToUpdate = new User();

            userToUpdate.Id = 3;
            userToUpdate.FirstName = "Mehmet";
            userToUpdate.LastName = "SUCU";
            userToUpdate.Email = "mehmetsucu1865@hotmail.com";
            userToUpdate.Password = "985456789012";

            var result2 = userManager.Update(userToUpdate);

            if (result2.Success == true)
            {

                Console.WriteLine(Messages.UserUpdated);

            }
            else
            {
                Console.WriteLine(result2.Message);
            }
            // Serap GÜNDÜZ mükerrer girilmiş sondaki kayıt silinecek.
            User userToDelete = new User();

            userToDelete.Id = 8;

            var result3 = userManager.Delete(userToDelete);

            if (result3.Success == true)
            {

                Console.WriteLine(Messages.UserDeleted);

            }
            else
            {
                Console.WriteLine(result3.Message);
            }

            // Tüm Kullanıcıları listeleme

            var result4 = userManager.GetAll();

            if (result4.Success == true)
            {
                foreach (var user in result4.Data)
                {
                    Console.WriteLine("{0}   {1}   {2}   {3}   {4}", user.Id, user.FirstName, user.LastName, user.Email, user.Password);

                }

                Console.WriteLine(Messages.UsersListed);

            }
            else
            {
                Console.WriteLine(result4.Message);
            }


            // 4 nolu kullanıcının bilgilerini getirme

            var result5 = userManager.Get(4);

            if (result5.Success == true)
            {

                Console.WriteLine("{0}   {1}   {2}   {3}   {4}", result5.Data.Id, result5.Data.FirstName, result5.Data.LastName, result5.Data.Email, result5.Data.Password);

                Console.WriteLine(Messages.UserListed);

            }
            else
            {
                Console.WriteLine(result5.Message);
            }



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

            var result = carManager.GetAll();
            if (result.Success == true)
            {

                Console.WriteLine(String.Format("{0,-3} {1,-7}  {2,-7} {3,-15} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));
                foreach (var car in result.Data)
                {
                    Console.WriteLine(String.Format("{0,4} {1,4}  {2,4} {3,-10} {4,-10} {5,-10}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


             result = carManager.GetCarsByBrandId(18);
            if (result.Success == true)
            {
                // BrandId si 18 olan tüm araçları listeleme
                Console.WriteLine(String.Format("{0,-3} {1,-7}  {2,-7} {3,-15} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));
                foreach (var car in result.Data)
                {
                    Console.WriteLine(String.Format("{0,4} {1,4}  {2,4} {3,-10} {4,-10} {5,-10}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            } 



            // ColorId  si 8 olan tüm araçları listeleme
             result = carManager.GetCarsByColorId(8);
            if (result.Success == true)
            {


                Console.WriteLine(String.Format("{0,-3} {1,-7}  {2,-7} {3,-15} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));
                foreach (var car in result.Data)
                {
                    Console.WriteLine(String.Format("{0,4} {1,4}  {2,4} {3,-10} {4,-10} {5,-10}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            // Id si 10 olan aracın bilgilerini getirme
            
             
            Console.WriteLine(String.Format("{0,-3} {1,-7}  {2,-7} {3,-15} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));

            
            var carToGet = carManager.Get(10);
            if (carToGet.Success == true)
            {

                {
                    Console.WriteLine(String.Format("{0,4} {1,4}  {2,4} {3,-10} {4,-10} {5,-10}", carToGet.Data.Id, carToGet.Data.BrandId, carToGet.Data.ColorId, carToGet.Data.ModelYear, carToGet.Data.DailyPrice, carToGet.Data.Description));

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            
            var crd = carManager.GetCarDetails();
            // Araç ile birlikte ve marka ve rengini getirme Dto örneği
            
            if (crd.Success == true)
            {


                Console.WriteLine(String.Format("{0,-4} {1,20}  {2,20} {3,-10} {4,-10} {5,-10}", "Id", "BrandName", "ColorName", "Model Year", "DailyPrice", "Description"));
                foreach (var car in crd.Data)
                {
                    Console.WriteLine(String.Format("{0,4} {1,20}  {2,20} {3,-10} {4,-10} {5,-10}", car.CarId, car.BrandName, car.ColorName, car.ModelYear, car.DailyPrice, car.Description));

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            // DailyPrice değeri 170 - 205 aralığında olan araçları getirme
            result = carManager.GetByDailyPrice(170, 205);
            if (result.Success == true)
            {


                Console.WriteLine(String.Format("{0,-4} {1,-4}  {2,-4} {3,-10} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));
                foreach (var car in result.Data)
                {
                    Console.WriteLine(String.Format("{0,4} {1,4}  {2,4} {3,-10} {4,-10} {5,-10}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

                }
            }
            else
            {
                Console.WriteLine(result.Message);
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
            var result = colorManager.GetAll();
            if (result.Success == true)
            {


                foreach (var color in result.Data)
                {

                    Console.WriteLine(String.Format("{0,-3} {1,20}", color.Id, color.Name));
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            // 5 nolu rengi getirme 
            Console.WriteLine(String.Format("{0,-3} {1,20}", "Id", "ColorName"));

          

            var colorToGet = colorManager.Get(5);
            if (colorToGet.Success == true)
            {




                Console.WriteLine(String.Format("{0,-3} {1,20}", colorToGet.Data.Id, colorToGet.Data.Name));
            }
            else
            {
                Console.WriteLine(result.Message);
            }







        }

        private static void BrandTest()
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
                var  resulti = brandManager.Add(brand);
                if (resulti.Success==true)
                {
                    Console.WriteLine(Messages.CarAdded);

                }
                else
                {
                    Console.WriteLine(resulti.Message);
                }
            }

            Brand brandToUpdate = new Brand();
            brandToUpdate.Id = 10;
            brandToUpdate.Name = "Nissan";
            // id si 10 olan ürünü bilerek Nissan yerine Nisan yapmıştım. onu düzeltecez
           
            
            
            var result=brandManager.Update(brandToUpdate);
            if (result.Success==true)
            {
                Console.WriteLine(Messages.CarUpdated);

            }
            else
            {
                Console.WriteLine(result.Message);
            }



            Brand brandToDelete = new Brand();
            brandToDelete.Id = 20;

            // id si 19 ve 20 olan markayı  bilerek iki defa yazdım. Fazlalık olan 20 noluyu silecez
            
            
            result=brandManager.Delete(brandToDelete);
            if (result.Success==true)
            {

                Console.WriteLine(Messages.CarDeleted);
            }
            else
            {
                Console.WriteLine(result.Message);
            }





            // Tüm markaları listeleme
            


            var result3 = brandManager.GetAll();
            if (result3.Success == true)
            {
                Console.WriteLine(String.Format("{0,-3} {1,20}", "Id", "BrandName"));

                foreach (var brand in result3.Data)
                {
                    Console.WriteLine(String.Format("{0,-3} {1,20}", brand.Id, brand.Name));
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            // 11 nolu markayı listeleme 
           
            var brandToGet = brandManager.Get(11);
            if (brandToGet.Success==true)
            {
                Console.WriteLine(String.Format("{0,-3} {1,20}", "Id", "BrandName"));

                Console.WriteLine(String.Format("{0,-3} {1,20}", brandToGet.Data.Id, brandToGet.Data.Name));

            }
            else
            {
                Console.WriteLine(result.Message);

            }

            



        }

        private static void InMemoryTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());


            Console.WriteLine("********** GetAll Cars ****************************");

            var result =carManager.GetAll();

            if (result.Success == true)
            {


                Console.WriteLine(String.Format("{0,-3} {1,-7}  {2,-7} {3,-15} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));
                foreach (var car in result.Data)
                {
                    Console.WriteLine(String.Format("{0,4} {1,4}  {2,4} {3,-10} {4,-10} {5,-10}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
            
            Console.WriteLine("**********GetAll Cars By Brand Id****************************");


            result=carManager.GetCarsByBrandId(18);
            if (result.Success == true)
            {


                Console.WriteLine(String.Format("{0,-3} {1,-7}  {2,-7} {3,-15} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));
                foreach (var car in result.Data)
                {
                    Console.WriteLine(String.Format("{0,3} {1,7}  {2,7} {3,-15} {4,-10} {5,-10}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));


                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            Console.WriteLine("********GetAll Cars By Color Id******************************");


            result=carManager.GetCarsByColorId(10);
            if (result.Success==true)
            {


                Console.WriteLine(String.Format("{0,-3} {1,-7}  {2,-7} {3,-15} {4,-10} {5,-10}", "Id", "BrandId", "ColorId", "Model Year", "DailyPrice", "Description"));
                foreach (var car in result.Data)
                {
                    Console.WriteLine(String.Format("{0,3} {1,7}  {2,7} {3,-15} {4,-10} {5,-10}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }









            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            brandManager.GetAll();

            Console.WriteLine("******** GetAll Brands ******************************");


            var resultb = brandManager.GetAll();
            if (resultb.Success == true)
            {


                Console.WriteLine(String.Format("{0,-3} {1,-15}", "Id", "Brand Name"));
                foreach (var brand in resultb.Data)
                {
                    Console.WriteLine(String.Format("{0,3} {1,-15}", brand.Id, brand.Name));
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }




            Console.WriteLine("******** Get a Brand ******************************");


             var resultg =brandManager.Get(3);
            if (result.Success == true)
            {



                Console.WriteLine(String.Format("{0,-3} {1,-15}", "Id", "Brand Name"));

                Console.WriteLine(String.Format("{0,3} {1,-15}", resultg.Data.Id, resultg.Data.Name));

            }
            else
            {
                Console.WriteLine(result.Message);
            }

            ColorManager colorManager = new ColorManager(new InMemoryColorDal());
            
            
            Console.WriteLine("******** GetAll Colors ******************************");

            var resultc = colorManager.GetAll();
            if (resultc.Success == true)
            {

                Console.WriteLine(String.Format("{0,-3} {1,-15}", "Id", "Color Name"));
                foreach (var color in resultc.Data)
                {
                    Console.WriteLine(String.Format("{0,3} {1,-15}", color.Id, color.Name));
                }
            }
            else
            {

                Console.WriteLine(result.Message);
            }


            Console.WriteLine("******** Get a Color ******************************");


           var colorg= colorManager.Get(5);

            if (colorg.Success == true)
            {


                Console.WriteLine(String.Format("{0,-3} {1,-15}", "Id", "Color Name"));

                Console.WriteLine(String.Format("{0,3} {1,-15}", colorg.Data.Id, colorg.Data.Name));
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
