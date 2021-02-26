using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ETradeContext>, IUserDal
    {
        public List<ProductsInBasketDTO> GetBasketDetail(int id)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var result = from p in context.Products
                             join b in context.Baskets
                             on p.Id equals b.ProductId
                             where b.UserId == id
                             select new ProductsInBasketDTO
                             {
                                 ProductId = p.Id,
                                 ProductModel = p.Model,
                                 ImageUrl = p.ImageUrl,
                                 ProductPrice = p.Price,
                                 Quantity = b.Quantity
                             };
                return result.ToList();

            }
        }
    }
}
