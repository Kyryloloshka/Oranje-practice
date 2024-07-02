using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Category
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(25, ErrorMessage = "Name must be at most 25 characters long")]
        public string Name { get; set; } = string.Empty;
    }
}