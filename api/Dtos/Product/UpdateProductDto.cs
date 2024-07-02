using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Product
{
    public class UpdateProductDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters long")]
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Description must be at least 3 characters long")]
        [MaxLength(280, ErrorMessage = "Description must be at most 280 characters long")]
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}