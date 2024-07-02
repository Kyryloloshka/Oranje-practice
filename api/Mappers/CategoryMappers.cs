using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Models;

namespace api.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products.Select(p => p.ToProductDto()).ToList()
            };
        }

        public static Category ToCategoryFromCreateDto(this CreateCategoryDto category) 
        {
            
            return new Category
            {
                Name = category.Name,
            };
        }
    }
}