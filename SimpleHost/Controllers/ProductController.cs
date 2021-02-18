using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleHost.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly BusinessLogicLayer.Interface.IProductService _productService;

        public ProductController(ILogger<ProductController> logger, BusinessLogicLayer.Interface.IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] BusinessLogicLayer.DTO.ProductDto model)
        {
            try
            {
                var product = await _productService.Update(model);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProduct(Guid userId)
        {
            try
            {
                var data = await _productService.GetProduct(userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetProducts(Guid categoryId)
        {
            try
            {
                var data = await _productService.GetProducts(categoryId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
