using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
            bool isCarAvailable = _rentalDal.IsCarAvailable(rental.CarId);

            if(!isCarAvailable)
            {
                return new ErrorResult(Messages.RentalNotAvailable);
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result, Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            var result = _rentalDal.GetById(r => r.Id == id);
            return new SuccessDataResult<Rental>(result);
        }

        public IResult IsCarAvailable(int carId)
        {
            bool isCarAvailable = _rentalDal.IsCarAvailable(carId);
             
            if(isCarAvailable)
            {
                return new SuccessResult(Messages.RentalAvailable);
            }
            else
            {
                return new ErrorResult(Messages.RentalNotAvailable);
            }
        }

        //public bool IsReturn(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public IResult Upate(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
