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
    public class SubCategoryManager : ISubCategoryService
    {
        ISubCategoryDal _subCategoryDal;
        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }

        public IDataResult<List<SubCategory>> GetAll()
        {
            var result = _subCategoryDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<SubCategory>>(result);
            }
            return new ErrorDataResult<List<SubCategory>>();

        }

        public IDataResult<List<SubCategory>> GetAllByCategoryId(int categoryId)
        {
            var result = _subCategoryDal.GetAll(p=>p.CategoryId==categoryId);
            if (result!=null)
            {
                return new SuccessDataResult<List<SubCategory>>(result, Messages.GetSubCategories);
            }
            return new ErrorDataResult<List<SubCategory>>(result, Messages.ErrorSubCategories);
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
