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
    public class EfProductDal : EfEntityRepositoryBase<Product, ETradeContext>, IProductDal
    {
        public List<BrandNameDTO> GetBrands()
        {
            using (ETradeContext context=new ETradeContext())
            {
                var result = from p in context.Products
                             select new BrandNameDTO
                             {
                                 Brand = p.Brand
                             };
                return result.Distinct().ToList();
            }
        }

        public List<Product> GetProductsOfCategory(int categoryId)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var result = from p in context.Products
                             join s in context.SubCategories
                             on p.SubCategoryId equals s.Id
                             join c in context.Categories
                             on s.CategoryId equals c.Id
                             where (c.Id == categoryId)
                             select new Product
                             {
                                 Id = p.Id,
                                 SubCategoryId = p.SubCategoryId,
                                 Brand = p.Brand,
                                 Description = p.Description,
                                 Discount=p.Discount,
                                 ImageUrl=p.ImageUrl,
                                 IsActive=p.IsActive,
                                 Model=p.Model,
                                 Stock=p.Stock,
                                 ProductName=p.ProductName,
                                 Tax=p.Tax,
                                 UnitPrice=p.UnitPrice
                             };
                return result.ToList();
            }
        }
    }
}
