using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleHost.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly BusinessLogicLayer.Interface.ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, 
            ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContainersTree()
        {
            try
            {
                return Ok(await _categoryService.GetCategories());
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
