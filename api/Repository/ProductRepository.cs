using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Product;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<Product> CreateAsync(Product productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }
        public async Task<Product?> UpdateAsync(int id, UpdateProductDto productDto, int categoryId)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.Name = productDto.Name;
            existingProduct.Price = productDto.Price;
            existingProduct.CategoryId = categoryId;
            existingProduct.Description = productDto.Description;
            existingProduct.ImageUrl = productDto.ImageUrl;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null)
            {
                return null;
            }
            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }
    }
}