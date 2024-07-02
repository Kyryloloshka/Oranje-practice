using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Product;
using api.Models;

namespace api.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryId = product.CategoryId,
                ImageUrl = product.ImageUrl
            };
        }

        public static Product ToProductFromCreateDto(this CreateProductDto product, int categoryId) 
        {
            return new Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryId = categoryId,
                ImageUrl = product.ImageUrl
            };
        }

        public static Product ToProductFromUpdateDto(this UpdateProductDto product, int categoryId) 
        {
            
            return new Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryId = categoryId,
                ImageUrl = product.ImageUrl
            };
        }
    }
}