using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common.Result;
using WebAPI.Dtos.Product;
using WebAPI.Repositories.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productRepository.GetAllAsync();
            if (result.ResponseType == ResponseType.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productRepository.GetByIdAsync(id);
            if (result.ResponseType == ResponseType.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
            var result = await _productRepository.AddAsync(productAddDto);
            if (result.ResponseType == ResponseType.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            var result = await _productRepository.UpdateAsync(productUpdateDto);
            if (result.ResponseType == ResponseType.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productRepository.DeleteAsync(id);
            if (result.ResponseType == ResponseType.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetProductWithCategories")]
        public IActionResult GetProductWithCategories()
        {
            var result = _productRepository.ProductWithCategories();
            if (result.ResponseType == ResponseType.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

	}
}
