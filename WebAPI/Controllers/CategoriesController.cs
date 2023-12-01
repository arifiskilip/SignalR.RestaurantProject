using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos.Category;
using WebAPI.Repositories.Abstract;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoriesController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		[HttpGet("getall")]
		public async Task<IActionResult> GetAll()
		{
			var result = await _categoryRepository.GetAllAsync();
			if (result.ResponseType == Common.Result.ResponseType.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpPost("add")]
		public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
		{
			var result = await _categoryRepository.AddAsync(categoryAddDto);
            if (result.ResponseType == Common.Result.ResponseType.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> delete(int id)
        {
            var result = await _categoryRepository.DeleteAsync(id);
            if (result.ResponseType == Common.Result.ResponseType.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var result = await _categoryRepository.UpdateAsync(categoryUpdateDto);
            if (result.ResponseType == Common.Result.ResponseType.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryRepository.GetByIdAsync(id);
            if (result.ResponseType == Common.Result.ResponseType.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
