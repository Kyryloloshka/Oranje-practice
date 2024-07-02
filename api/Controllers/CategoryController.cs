using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Category;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categories = await _categoryRepo.GetAllAsync();
            var categoriesDto = categories.Select(s => s.ToCategoryDto());
            return Ok(categoriesDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category.ToCategoryDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var categoryModel = categoryDto.ToCategoryFromCreateDto();
            await _categoryRepo.CreateAsync(categoryModel);
            return Ok(categoryModel.ToCategoryDto());
        }
    }
}