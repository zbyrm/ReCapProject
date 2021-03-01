﻿using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result,Messages.UserListed );
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.GetById(u => u.Id == id);
            return new SuccessDataResult<User>(result, Messages.UserGet);
        }

        public  User  GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            return result;// new SuccessDataResult<User>(result, Messages.UserGet);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return result;// new SuccessDataResult<List<OperationClaim>>(result);
        }

        public IResult Update(User user)
        {
             _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
