using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {

            

            
           int sayac= _rentalDal.GetAll(p=>p.CarId==rental.CarId && p.ReturnDate==new DateTime(0001,01,01)).Count;
            if (sayac>0)
            {
                
                return new Result(false,Messages.CarNotReturned);
            }
            else
            {
                _rentalDal.Add(rental);
                return new Result(true);
            }

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new Result(true);
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

       

        public IResult IsRentable(int carId)
        {
            int sayac = _rentalDal.GetAll(p => p.CarId == carId && p.ReturnDate == new DateTime(0001, 01, 01)).Count;
            if (sayac > 0)
            {

                return new Result(false, Messages.CarNotReturned);
            }
            else
            {
               
                return new Result(true,Messages.CarIsRentable);
            }
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new Result(true);
        }
    }
}
