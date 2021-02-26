using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
       IResult Add(User user);
        IDataResult<User> GetById(int id);
        IDataResult<List<User>> GetAll();
        IResult Update(User user);
        IDataResult<List<ProductsInBasketDTO>> GetBasketDetail(int id);
    }
}
