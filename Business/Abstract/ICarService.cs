using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        List<ViewCar> GetAllCarsList();
        List<Brand> GetAllBrands();
        List<Color> GetAllColors();
        List<ViewCar> GetAllByColors();
        List<ViewCar> GetAllByBrands();

    }
}
