using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Product;
using api.Helpers;
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
        public async Task<List<Product>> GetAllAsync(QueryObject query)
        {

            var products = _context.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                products = products.Where(p => p.Name.Contains(query.Name));
            }

            if (!string.IsNullOrWhiteSpace(query.Description))
            {
                products = products.Where(p => p.Name.Contains(query.Description));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                products = query.SortBy switch
                {
                    "name" => query.IsDecsending ? products.OrderByDescending(p => p.Name) : products.OrderBy(p => p.Name),
                    "price" => query.IsDecsending ? products.OrderByDescending(p => p.Price) : products.OrderBy(p => p.Price),
                    "category" => query.IsDecsending ? products.OrderByDescending(p => p.CategoryId) : products.OrderBy(p => p.CategoryId),
                    _ => products.OrderBy(p => p.Id)
                };
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await products.Skip(skipNumber).Take(query.PageSize).ToListAsync();
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