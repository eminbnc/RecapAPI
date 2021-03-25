using Business.Abstract;
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
    public class SubCategoriesController : ControllerBase
    {
        ISubCategoryService _subCategoryService;
        public SubCategoriesController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _subCategoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("subcategoriesbycategoryid")]
        public IActionResult GetSubCategoriesByCategory(int categoryId)
        {
            var result = _subCategoryService.GetAllByCategoryId(categoryId);
            return Ok(result);
        }

    }
}
