using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager:IProductService
    {
        IProductDal _productDal;
        ISubCategoryService _subCategoryService;
        public ProductManager(IProductDal productDal,ISubCategoryService subCategoryService)
        {
            _productDal = productDal;
            _subCategoryService = subCategoryService;
        }
        [PerformanceAspect(50)]
        [CacheRemoveAspect("IProductService.Get",Priority =3)]
        [SecuredOperation("product.add,admin",Priority =1)]
        [ValidationAspect(typeof(ProductValidator),Priority =2)]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.SubCategoryId), CheckIfProductNameExists(product.ProductName), IsSubCategoryActive(product.SubCategoryId));
            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<BrandNameDTO>> BrandName()
        {
            var result = _productDal.GetBrands();
            if (result != null)
            {
                return new SuccessDataResult<List<BrandNameDTO>>(result, Messages.GetBrands);
            }
            return new ErrorDataResult<List<BrandNameDTO>>(result, Messages.ErroyGetBrands);
        }

        [CacheAspect(30,Priority =1)]
        public IDataResult<List<Product>> GetAll()
        {
            var result = _productDal.GetAll();
            if (DateTime.Now.Hour == 16)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(result, Messages.ProductList);
        }


        [CacheAspect(30, Priority = 1)]
        public IDataResult<List<Product>> GetAllBySubCategoryId(int subCategoryId)
        {
            var result = _productDal.GetAll(p => p.SubCategoryId == subCategoryId);
            if (result!=null)
            {
                return new SuccessDataResult<List<Product>>(result, Messages.ProductList);
            }
            return new ErrorDataResult<List<Product>>(result, Messages.ProductsNotFound);
        }

        public IDataResult<List<Product>> GetAllProductsByBrand(string brand)
        {
            var result = _productDal.GetAll(p => p.Brand == brand);
            if (result!=null)
            {
                return new SuccessDataResult<List<Product>>(result, Messages.ProductList);
            }
            return new ErrorDataResult<List<Product>>(result, Messages.ProductsNotFound);
        }

        public IDataResult<List<Product>> GetAllSubCategoryByBrand(string brandName)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IResult GetProduct(int productId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(c => c.Id == productId), Messages.GetProduct);
        }

        public IDataResult<List<ProductsInBasketDTO>> GetProductDetails()
        {
            throw new NotImplementedException();
        }
        [TransactionScopeAspect]
        public IResult TestTransaction(Product product)
        {
            var result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName));
            if (result != null)
            {
                throw new Exception(Messages.ProductNameAlreadyExists);
            }
            _productDal.Add(product);
            var result1 = BusinessRules.Run(CheckIfProductNameExists(product.ProductName));
            if (result1 != null)
            {
                throw new Exception(Messages.ProductNameAlreadyExists);
            }
            _productDal.Add(product);

            return new ErrorResult();
        }

        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int subCategoryId)  
        {
            var result = _productDal.GetAll(p => p.SubCategoryId == subCategoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult IsSubCategoryActive(int subCategoryId)
        {
            var result = _subCategoryService.GetById(subCategoryId);
            if (result.Data.IsActive==true)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.SubCategoryNotActive);
        }
    }
}
