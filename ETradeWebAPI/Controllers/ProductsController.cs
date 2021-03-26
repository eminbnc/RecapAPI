using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETradeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("add")]
        public IActionResult ProductAdd(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAllProduct()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbysubcategory")]
        public IActionResult GetProductsBySubCategoryId(int subCategoryId)
        {
            var result = _productService.GetAllBySubCategoryId(subCategoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbrands")]
        public IActionResult GetBrands()
        {
            var result = _productService.BrandName();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("productsbybrand")]
        public IActionResult GetProductsOfBrand(string brand)
        {
            var result = _productService.GetAllProductsByBrand(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("productsofcategory")]
        public IActionResult GetProductsOfCategory(int categoryId)
        {
            var result = _productService.GetProductsOfCategory(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyunitprice")]
        public IActionResult GetByUnitPrice(decimal min, decimal max)
        {
            var result = _productService.GetByUnitPrice(min, max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("testtransaction")]
        public IActionResult TransactionTest(Product product)
        {
            var result = _productService.TestTransaction(product);
            return Ok(result);
        }
    }
}
