using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;
        
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=2,ModelYear="2010",DailyPrice=70000,Description="Clear"},
                new Car{Id=2,BrandId=1,ColorId=3,ModelYear="2012",DailyPrice=80000,Description="Good"},
                new Car{Id=3,BrandId=1,ColorId=8,ModelYear="2005",DailyPrice=40000,Description="Clear"},
                new Car{Id=4,BrandId=5,ColorId=10,ModelYear="2009",DailyPrice=60000,Description="Good"},
                new Car{Id=5,BrandId=5,ColorId=6,ModelYear="2008",DailyPrice=70000,Description="Clear"},
                new Car{Id=6,BrandId=15,ColorId=1,ModelYear="2006",DailyPrice=35000,Description="Good"},
                new Car{Id=7,BrandId=10,ColorId=10,ModelYear="2010",DailyPrice=40000,Description="Clear"},
                new Car{Id=8,BrandId=18,ColorId=2,ModelYear="2015",DailyPrice=80000,Description="Clear"},
                new Car{Id=9,BrandId=18,ColorId=4,ModelYear="2016",DailyPrice=85000,Description="Clear"},
                new Car{Id=10,BrandId=18,ColorId=8,ModelYear="2014",DailyPrice=65000,Description="Clear"}
            };

            _brands = new List<Brand> {
                new Brand{Id=1,BrandName="Audi"},
                new Brand{Id=2,BrandName="Bmw"},
                new Brand{Id=3,BrandName="Citroen"},
                new Brand{Id=4,BrandName="Dacia"},
                new Brand{Id=5,BrandName="Fiat"},
                new Brand{Id=6,BrandName="Honda"},
                new Brand{Id=7,BrandName="Hyundai"},
                new Brand{Id=8,BrandName="Isuzu"},
                new Brand{Id=9,BrandName="Mitsubishi"},
                new Brand{Id=10,BrandName="Nissan"},
                new Brand{Id=11,BrandName="Opel"},
                new Brand{Id=12,BrandName="Porsche"},
                new Brand{Id=13,BrandName="Renault"},
                new Brand{Id=14,BrandName="Seat"},
                new Brand{Id=15,BrandName="Skoda"},
                new Brand{Id=16,BrandName="Suzuki"},
                new Brand{Id=17,BrandName="Toyota"},
                new Brand{Id=18,BrandName="Volkswagen"},
                new Brand{Id=19,BrandName="Volvo"}
            };

            _colors = new List<Color>
            {
                new Color{Id=1,ColorName="Metallic"},
                new Color{Id=2,ColorName="Blue"},
                new Color{Id=3,ColorName="Silver"},
                new Color{Id=4,ColorName="Gray"},
                new Color{Id=5,ColorName="Green"},
                new Color{Id=6,ColorName="Pearl"},
                new Color{Id=7,ColorName="Purple"},
                new Color{Id=8,ColorName="Red"},
                new Color{Id=9,ColorName="Paint"},
                new Color{Id=10,ColorName="White"}
                
            };


        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car Car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == Car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Brand> GetAllBrands()
        {
            return _brands;
        }

        public List<ViewCar> GetAllByBrand()
        {
            List<ViewCar> getCarByBrand = new List<ViewCar>();

            var result = (from ca in _cars
                          join br in _brands
                          on ca.BrandId equals br.Id
                          join co in _colors
                          on ca.ColorId equals co.Id
                          orderby br.BrandName

                          select new
                          {
                              ca.Id,
                              br.BrandName,
                              co.ColorName,
                              ca.ModelYear,
                              ca.DailyPrice,
                              ca.Description
                          }).ToList();




            getCarByBrand = result.Select(x => new ViewCar
            {
                Id = x.Id,
                BrandName = x.BrandName,
                ColorName = x.ColorName,
                ModelYear = x.ModelYear,
                DailyPrice = x.DailyPrice,
                Description = x.Description
            }).ToList();


            return getCarByBrand;
        }

       

        public List<ViewCar> GetAllByColor()
        {
            List<ViewCar> getCarByColor = new List<ViewCar>();

            var result  = (from ca in _cars
                                     join br in _brands
                                     on ca.BrandId equals br.Id
                                     join co in _colors
                                     on ca.ColorId equals co.Id
                                     orderby co.ColorName

                                     select new
                                     {
                                        ca.Id,
                                        br.BrandName,
                                        co.ColorName,
                                        ca.ModelYear,
                                        ca.DailyPrice,
                                        ca.Description
                                     }).ToList();




            getCarByColor = result.Select(x => new ViewCar
            {
                Id = x.Id,
                BrandName = x.BrandName,
                ColorName = x.ColorName,
                ModelYear = x.ModelYear,
                DailyPrice = x.DailyPrice,
                Description = x.Description
            }).ToList();


            return getCarByColor;
        }

        public List<ViewCar> GetAllCars()
        {
            List<ViewCar> getCarById = new List<ViewCar>();

            var result = (from ca in _cars
                          join br in _brands
                          on ca.BrandId equals br.Id
                          join co in _colors
                          on ca.ColorId equals co.Id
                          orderby ca.Id

                          select new
                          {
                              ca.Id,
                              br.BrandName,
                              co.ColorName,
                              ca.ModelYear,
                              ca.DailyPrice,
                              ca.Description
                          }).ToList();




            getCarById = result.Select(x => new ViewCar
            {
                Id = x.Id,
                BrandName = x.BrandName,
                ColorName = x.ColorName,
                ModelYear = x.ModelYear,
                DailyPrice = x.DailyPrice,
                Description = x.Description
            }).ToList();


            return getCarById;



           
        }

        public List<Color> GetAllColors()
        {
            return _colors;

        }

        public void Update(Car car)
        {
                       
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

      
    }
}
