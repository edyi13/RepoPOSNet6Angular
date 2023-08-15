using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Dtos.Request;
using POS.Application.Interfaces;
using POS.Infrastructure.Commons.Bases.Request;

namespace POS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication ?? throw new ArgumentNullException(nameof(categoryApplication));
        }

        [HttpPost]
        public async Task<IActionResult> ListCategories([FromBody] BaseFiltersRequest filters)
        {
            var response = await _categoryApplication.ListCategories(filters);

            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectCategories()
        {
            var response = await _categoryApplication.ListSelectCategories();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> CategoryById(int id)
        {
            var response = await _categoryApplication.GetCategoryById(id);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterCategory([FromBody] CategoryRequestDto requestDto)
        {
            var response = await _categoryApplication.RegisterCategory(requestDto);

            return Ok(response);
        }

        [HttpPut("Edit/{id:int}")]
        public async Task<IActionResult> EditCategory(int id, [FromBody] CategoryRequestDto requestDto)
        {
            var response = await _categoryApplication.UpdateCategory(id,requestDto);

            return Ok(response);
        }

        [HttpPut("Remove/{id:int}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var response = await _categoryApplication.DeleteCategory(id);

            return Ok(response);
        }
    }
}
