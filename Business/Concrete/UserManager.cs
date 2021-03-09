using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result=_userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result);
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }
        public IDataResult<User> GetByMail(string email)
        {
            var result= _userDal.Get(u => u.Email == email);
            if (result!=null)
            {
                return new SuccessDataResult<User>(result,Messages.GetUser);
            }
            return new ErrorDataResult<User>(result);
        }
    }
}
