using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class CartManager:ICartService
   {
       private IBasketDal _basketDal;

       public CartManager(IBasketDal basketDal)
       {
           _basketDal = basketDal;
       }
        [ValidationAspect(typeof(CartValidator))]
       public IResult AddToCart(Basket basket)
       {
           try
           {
               _basketDal.Add(basket);
               return new SuccessResult(Messages.CartAddSuccessful);
           }
           catch 
           {
               return new ErrorResult(Messages.CartAddError);
           }
           
        }
   }
}
