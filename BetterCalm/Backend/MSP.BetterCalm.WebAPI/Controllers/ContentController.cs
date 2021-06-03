using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Dtos;
using MSP.BetterCalm.WebAPI.Filters;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
    [FilterExceptions]
    [Route("api/Content")]
    public class ContentController : ControllerBase
    {
        private IContentService _ContentService;
        public ContentController(IContentService ContentService)
        {
            this._ContentService = ContentService;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Content> contents = _ContentService.GetContents();
            List<ContentDto> contentDtos = contents.Select(content => new ContentDto().CreateContentDto(content)).ToList();
            return Ok(contentDtos);
        }

        [HttpGet("name")]
        public IActionResult GetContentsByName([FromQuery] string name)
        {
            List<Content> contents = _ContentService.GetContentsByName(name);
            List<ContentDto> contentDtos = contents.Select(content => new ContentDto().CreateContentDto(content)).ToList();
            return Ok(contentDtos);
        }

        [HttpGet("author")]
        public IActionResult GetContentsByAuthor([FromQuery] string author)
        {
            List<Content> contents = _ContentService.GetContentsByAuthor(author);
            List<ContentDto> contentDtos = contents.Select(content => new ContentDto().CreateContentDto(content)).ToList();
            return Ok(contentDtos);        }


        [HttpGet("Category")]
        public IActionResult GetContentsByCategoryName([FromQuery] string name)
        {
            List<Content> contents = _ContentService.GetContentsByCategoryName(name);
            List<ContentDto> contentDtos = contents.Select(content => new ContentDto().CreateContentDto(content)).ToList();
            return Ok(contentDtos);
        }


        [HttpGet("{id}")]
        public IActionResult GetContentById([FromRoute] int id)
        {
            Content contentById = _ContentService.GetContentById(id);
            ContentDto content = new ContentDto().CreateContentDto(contentById);
            return Ok(content);
        }

        
        [HttpPost]
        [ServiceFilter(typeof(FilterAuthentication))]
        public IActionResult CreateContent([FromBody] ContentDto content)
        {
            Content contentAdded = _ContentService.SetContent(content.CreateContent());
            ContentDto contentDto = new ContentDto().CreateContentDto(contentAdded);
            return Created($"api/Content/{contentAdded.Name}", contentDto);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(FilterAuthentication))]
        public IActionResult DeleteContent([FromRoute] int id)
        {
            _ContentService.DeleteContent(id);
            return Ok("Content removed");
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(FilterAuthentication))]
        public IActionResult UpdateContent([FromRoute] int id, [FromBody] ContentDto contentUpdated)
        {
            _ContentService.UpdateContentById(id, contentUpdated.CreateContent());
            return Ok("Content Updated");
        }
    }
}