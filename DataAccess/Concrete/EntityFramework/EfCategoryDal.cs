using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ETradeContext>, ICategoryDal
    {
        public List<CategoryWithSubCategoryDTO> GetCategoriesWithSubCategories()
        {
            using (ETradeContext context=new ETradeContext())
            {
                var result = from c in context.Categories
                             join s in context.SubCategories
                             on c.Id equals s.CategoryId
                             where c.IsActive == true && s.IsActive == true
                             select new CategoryWithSubCategoryDTO
                             {
                                 CategoryId = c.Id,
                                 SubCategoryId = s.Id,
                                 CategoryName = c.CategoryName,
                                 SubCategoryName = s.SubCategoryName
                             };
                return result.ToList();
            }
        }
    }
}
