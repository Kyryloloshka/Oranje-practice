using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Order
{
    public class UpdateOrderDto
    {
        public ICollection<OrderItem> OrderItems { get; set; } = [];
    }
}