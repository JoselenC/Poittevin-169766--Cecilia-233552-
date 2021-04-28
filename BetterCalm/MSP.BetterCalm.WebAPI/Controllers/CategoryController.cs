using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
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
        
        [HttpGet("name")]
        public IActionResult GetCategoryByName([FromQuery]string name)
        {
            try{
            Category categoryByName=_categoryService.GetCategoryByName(name);
            return Ok(categoryByName);
            }
            catch (ValueNotFound)
            {
                return NotFound("Not found playlist by this name");
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult GetCategoryById([FromRoute] int id)
        {
            try
            {
                Category categoryById = _categoryService.GetCategoryById(id);
                return Ok(categoryById);
            }
            catch (ValueNotFound)
            {
                return NotFound("Not found playlist by this id");
            }
        }

    }
}