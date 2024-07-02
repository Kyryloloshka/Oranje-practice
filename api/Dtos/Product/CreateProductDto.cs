using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Product
{
    public class CreateProductDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters long")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0.01, 10000000, ErrorMessage = "Price must be between 0.01 and 10000000")]
        public decimal Price { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Description must be at least 3 characters long")]
        [MaxLength(280, ErrorMessage = "Description must be at most 280 characters long")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MinLength(3, ErrorMessage = "ImageUrl must be at least 3 characters long")]
        [MaxLength(2083, ErrorMessage = "ImageUrl must be at most 2083 characters long")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}