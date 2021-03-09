using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SubCategoryManager : ISubCategoryService
    {
        ISubCategoryDal _subCategoryDal;
        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }
        public IDataResult<SubCategory> GetById(int subCategoryId)
        {
            var result = _subCategoryDal.Get(p => p.Id == subCategoryId);
            if (result!=null)
            {
                return new SuccessDataResult<SubCategory>(result);
            }
            return new ErrorDataResult<SubCategory>();
        }
    }
}
