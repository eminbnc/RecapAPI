using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
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
       [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            user.CreateDate = DateTime.Now;
            user.UpdateDate = DateTime.Now;
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<List<User>> GetAll()
        {
           
                var result = _userDal.GetAll();
                return new SuccessDataResult<List<User>>(result, Messages.UserList);
            
          
        }

        public IDataResult<List<ProductsInBasketDTO>> GetBasketDetail(int id)
        {
            return new SuccessDataResult<List<ProductsInBasketDTO>>(_userDal.GetBasketDetail(id), Messages.BasketList);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == id), Messages.SuccessUserData);
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
