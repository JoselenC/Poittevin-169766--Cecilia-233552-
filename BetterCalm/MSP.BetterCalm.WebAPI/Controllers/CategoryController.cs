using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
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
        
        [HttpGet("{Name}")]
        public IActionResult GetCategoryByName([FromRoute]string Name)
        {
            Category categoryByName=_categoryService.GetCategoryByName(Name);
            return Ok(categoryByName);
        }

    }
}