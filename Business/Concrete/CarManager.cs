﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager:ICarService 
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            this._carDal = carDal;
        }

        private bool checkData(Car car)
        {
            bool value = true;

            if (car.Name.Length < 2)
                value = false;

            if (car.DailyPrice == 0)
                value = false;

            return value;
        }
        public IResult Add(Car car)
        {
            if (!checkData(car))
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult< List<Car>> GetAll()
        {
            return  new SuccessDataResult<List<Car>>( _carDal.GetAll())  ;
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult <Car>( _carDal.GetById( c=>c.Id ==id  ) ) ;
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult <List<Car>>( _carDal.GetAll(c => c.BrandId == brandId) ) ;
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.ColorId == colorId) ) ;
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new  SuccessResult( Messages.CarUpdated );
            
        }

        public IDataResult< List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult <List<CarDetailDto>>( _carDal.GetCarDetails()) ;
        }
    }
}
