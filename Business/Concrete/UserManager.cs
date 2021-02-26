using Business.Abstract;
using Business.Constants;
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
        public IResult Add(User user)
        {
            //_userDal.Add(user);
            return new ErrorResult("deneme");
        }

        public IDataResult<List<User>> GetAll()
        {
            try
            {
                var result = _userDal.GetAll();
                return new SuccessDataResult<List<User>>(result, Messages.UserList);
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        public IDataResult<List<ProductsInBasketDTO>> GetBasketDetail(int id)
        {
            return new SuccessDataResult<List<ProductsInBasketDTO>>(_userDal.GetBasketDetail(id), Messages.BasketList);
        }

        public IDataResult<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
