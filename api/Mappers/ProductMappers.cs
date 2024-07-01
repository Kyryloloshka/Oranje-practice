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
            Console.WriteLine($"Mapping Product to DTO: {product.Name}, CategoryId: {product.CategoryId}");
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

        public static Product ToProductCreateDto(this CreateProductDto product) 
        {
            return new Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryId = product.CategoryId,
                ImageUrl = product.ImageUrl
            };
        }

        public static Product ToProductFromUpdateDto(this CreateProductDto product) 
        {
            
            Console.WriteLine($"Mapping DTO to Product: {product.Name}, CategoryId: {product.CategoryId}");
            return new Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryId = product.CategoryId,
                ImageUrl = product.ImageUrl
            };
        }
    }
}