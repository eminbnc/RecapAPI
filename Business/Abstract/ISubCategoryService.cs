using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISubCategoryService
    {
        IDataResult<SubCategory> GetById(int subCategoryId);
        IDataResult<List<SubCategory>> GetAll();
        IDataResult<List<SubCategory>> GetAllByCategoryId(int categoryId);
    }
}
