using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
           List<Brand> _brands;


        public InMemoryBrandDal()
        {
            _brands = new List<Brand> {
                new Brand{Id=1,Name="Audi"},
                new Brand{Id=2,Name="Bmw"},
                new Brand{Id=3,Name="Citroen"},
                new Brand{Id=4,Name="Dacia"},
                new Brand{Id=5,Name="Fiat"},
                new Brand{Id=6,Name="Honda"},
                new Brand{Id=7,Name="Hyundai"},
                new Brand{Id=8,Name="Isuzu"},
                new Brand{Id=9,Name="Mitsubishi"},
                new Brand{Id=10,Name="Nisan"},
                new Brand{Id=11,Name="Opel"},
                new Brand{Id=12,Name="Porsche"},
                new Brand{Id=13,Name="Renault"},
                new Brand{Id=14,Name="RenaultSeat"},
                new Brand{Id=15,Name="Skoda"},
                new Brand{Id=16,Name="Suzuki"},
                new Brand{Id=17,Name="Toyota"},
                new Brand{Id=18,Name="Volkswagen"},
                new Brand{Id=19,Name="Volvo"},
                new Brand{Id=20,Name="Volvo"}

            };

        }

        public void Add(Brand entity)
        {
           
            
                _brands.Add(entity);
            
            
        }

        public void Delete(Brand entity)
        {
            Brand brandToDelete = _brands.SingleOrDefault(p => p.Id == entity.Id);
            _brands.Remove(brandToDelete);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            return _brands.AsQueryable<Brand>().Where(filter).SingleOrDefault();
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return filter == null
              ? _brands
              : _brands.AsQueryable<Brand>().Where(filter).ToList();
        }

        public void Update(Brand entity)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(p => p.Id == entity.Id);
            brandToUpdate.Name = entity.Name;
        }
    }
}
