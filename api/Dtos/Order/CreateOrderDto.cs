using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Order
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = [];
    }
}