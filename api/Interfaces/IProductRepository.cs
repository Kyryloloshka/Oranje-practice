using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Product;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(QueryObject query);
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product productModel);
        Task<Product?> UpdateAsync(int id, UpdateProductDto productDto, int categoryId);
        Task<Product?> DeleteAsync(int id);
    }
}