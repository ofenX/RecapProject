using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService

    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {

            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if(brand.Name.Length>2)
            {
                _brandDal.Add(brand);

            }
           
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public Brand Get(int id)
        {
            return _brandDal.Get(p =>p.Id==id);

        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
