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

        private ICategoryLogic categoryLogic;

        public CategoryController(ICategoryLogic categoryLogic)
        {
            this.categoryLogic = categoryLogic;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Category> categories = this.categoryLogic.GetCategories();
            return Ok(categories);
        }
        
        [HttpGet("{Name}")]
        public IActionResult GetCategoryByName([FromRoute]string Name)
        {
            Category categoryByName=categoryLogic.GetCategoryByName(Name);
            return Ok(categoryByName);
        }

    }
}