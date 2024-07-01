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
                ProductIds = category.Products.Select(p => p.Id).ToList()
            };
        }

        public static CreateCategoryDto ToCreateCategoryDto(this Category category)
        {
            return new CreateCategoryDto
            {
                Name = category.Name
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