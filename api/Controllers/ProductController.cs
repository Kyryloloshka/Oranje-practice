using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Product;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        public ProductController(ApplicationDBContext context, IProductRepository productRepo, ICategoryRepository categoryRepo)
        {
            _productRepo = productRepo;
            _context = context;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepo.GetAllAsync();
            var productsDto = products.Select(s => s.ToProductDto());
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto productDto)
        {
            Console.WriteLine($"Received CreateProductDto: {productDto.Name}, CategoryId: {productDto.CategoryId}");
            var category = await _categoryRepo.GetByIdAsync(productDto.CategoryId);
            if (category == null)
            {
                return BadRequest($"Category with Id {productDto.CategoryId} does not exist.");
            }

            var productModel = productDto.ToProductFromUpdateDto();
            await _productRepo.CreateAsync(productModel);

            Console.WriteLine($"Returning created product: {productModel.Name}, CategoryId: {productModel.CategoryId}");
            return CreatedAtAction(nameof(GetById), new { id = productModel.Id }, productModel.ToProductDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto updateDto)
        {
            var product = await _productRepo.UpdateAsync(id, updateDto);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var product = await _productRepo.DeleteAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}