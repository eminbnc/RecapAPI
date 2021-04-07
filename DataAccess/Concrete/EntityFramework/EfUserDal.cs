using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ETradeContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ETradeContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
        }
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
                                 ProductPrice = p.UnitPrice,
                                 Quantity = b.Quantity
                             };
                return result.ToList();

            }
        }
    }
}
