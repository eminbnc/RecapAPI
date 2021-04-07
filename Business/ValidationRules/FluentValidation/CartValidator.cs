using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CartValidator:AbstractValidator<Basket>
    {
        public CartValidator()
        {
            RuleFor(c => c.ProductId).NotEmpty();
            RuleFor(c => c.Quantity).NotEmpty();
            RuleFor(c => c.Quantity).GreaterThan(0);
            RuleFor(c => c.UserId).NotEmpty();
        }
    }
}
