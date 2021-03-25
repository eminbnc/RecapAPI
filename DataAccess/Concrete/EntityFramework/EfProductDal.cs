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
    }
}
