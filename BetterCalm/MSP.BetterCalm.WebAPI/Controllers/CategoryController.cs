using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Filters;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
    [FilterExceptions]
    [Route("api/Category")]
    public class CategoryController : ControllerBase
    {

        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Category> categories = this._categoryService.GetCategories();
            return Ok(categories);
        }
        
        [HttpGet("name")]
        public IActionResult GetCategoryByName([FromQuery]string name)
        {
            Category categoryByName=_categoryService.GetCategoryByName(name);
            return Ok(categoryByName);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById([FromRoute] int id)
        {
            Category categoryById = _categoryService.GetCategoryById(id);
            return Ok(categoryById);
        }

    }
}