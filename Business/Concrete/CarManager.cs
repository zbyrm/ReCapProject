﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
using Core.Utilities.Results;
using Core.Aspects.Transaction;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [SecuredOperation("admin,editor")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //if (!checkData(car))
            //{
            //    return new ErrorResult(Messages.CarNameInvalid);
            //} 

           // ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        [CacheAspect]//key, value  key =chche verilen isim  //
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

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
