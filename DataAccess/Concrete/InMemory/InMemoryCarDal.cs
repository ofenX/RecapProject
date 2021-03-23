using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
       
        
        
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=2,ModelYear="2010",DailyPrice=1500,Description="Clear"},
                new Car{Id=2,BrandId=1,ColorId=3,ModelYear="2012",DailyPrice=170,Description="Good"},
                new Car{Id=3,BrandId=1,ColorId=8,ModelYear="2005",DailyPrice=180,Description="Clear"},
                new Car{Id=4,BrandId=5,ColorId=10,ModelYear="2009",DailyPrice=195,Description="Good"},
                new Car{Id=5,BrandId=5,ColorId=6,ModelYear="2008",DailyPrice=185,Description="Clear"},
                new Car{Id=6,BrandId=15,ColorId=1,ModelYear="2006",DailyPrice=190,Description="Good"},
                new Car{Id=7,BrandId=10,ColorId=10,ModelYear="2010",DailyPrice=210,Description="Clear"},
                new Car{Id=8,BrandId=18,ColorId=2,ModelYear="2015",DailyPrice=180,Description="Clear"},
                new Car{Id=9,BrandId=18,ColorId=4,ModelYear="2016",DailyPrice=175,Description="Clear"},
                new Car{Id=10,BrandId=18,ColorId=8,ModelYear="2014",DailyPrice=140,Description="Clear"},
                new Car{Id=11,BrandId=18,ColorId=8,ModelYear="2014",DailyPrice=140,Description="Clear"}
            };

           
           


        }

        public void Add(Car entity)
        {
           
           
                _cars.Add(entity);
           
            
            
           
        }

        public void Delete(Car entity)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == entity.Id);
            _cars.Remove(carToDelete);
        }

        

        public Car Get(Expression<Func<Car, bool>> filter)
        {

            return _cars.AsQueryable<Car>().Where(filter).SingleOrDefault();

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
                return filter == null
                ? _cars
                : _cars.AsQueryable<Car>().Where(filter).ToList();
                       
        }

        public void Update(Car entity)
        {

            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == entity.Id);
            carToUpdate.BrandId = entity.BrandId;
            carToUpdate.ColorId = entity.ColorId;
            carToUpdate.ModelYear = entity.ModelYear;
            carToUpdate.DailyPrice = entity.DailyPrice;
            carToUpdate.Description = entity.Description;

        }
    }

       
    
}
