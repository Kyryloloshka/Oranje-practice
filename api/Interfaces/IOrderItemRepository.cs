using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> CreateAsync(OrderItem orderItemModel);
        Task<OrderItem?> GetByIdAsync(int id);
    }
}