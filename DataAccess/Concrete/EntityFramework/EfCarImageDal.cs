using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal: EfEntityRepositoryBase<CarImage, CarRentalContext>, ICarImageDal
    {
      

        public List<CarImageDto> GetCarImageByCarId(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {

                
                var result = from ca in context.Cars
                             join br in context.Brands
                             on ca.BrandId equals br.Id
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             join ci in context.CarImages
                             on ca.Id equals ci.CarId
                             where ca.Id==id


                             select new CarImageDto
                             {
                                 CarId = ca.Id,
                                 BrandName = br.Name,
                                 ColorName = co.Name,
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 Date=ci.Date,
                                 ImagePath=ci.ImagePath

                             };
                return result.ToList();



            }
        }
    }
}
