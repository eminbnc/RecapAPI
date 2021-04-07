using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(P => P.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(p=>p.Discount).GreaterThan(0);
            RuleFor(P => P.Brand).NotEmpty();
            RuleFor(P => P.Description).NotEmpty();

            RuleFor(P => P.Stock).NotEmpty();
            RuleFor(P => P.Tax).NotEmpty();
            RuleFor(P => P.SubCategoryId).NotEmpty();
        }
    }
}
