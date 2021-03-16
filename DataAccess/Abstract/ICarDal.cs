using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<ViewCar> GetAllCars();
        List<Brand> GetAllBrands();
        List<Color> GetAllColors();
        List<ViewCar> GetAllByBrand();
        List<ViewCar> GetAllByColor();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car Car);
    }
}
