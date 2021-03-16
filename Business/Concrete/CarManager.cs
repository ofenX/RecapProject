using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService

    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

       

        public List<Brand> GetAllBrands()
        {
            return _carDal.GetAllBrands();
        }

        public List<ViewCar> GetAllByBrands()
        {
            return _carDal.GetAllByBrand();
        }

        public List<ViewCar> GetAllByColors()
        {
           return _carDal.GetAllByColor();
        }

        public List<ViewCar> GetAllCarsList()
        {
            return _carDal.GetAllCars();
        }

        public List<Color> GetAllColors()
        {
            return _carDal.GetAllColors();
        }

       
    }
}
