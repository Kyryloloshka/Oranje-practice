using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Order;
using api.Models;

namespace api.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<List<Order>> GetUserOrders(User user);
        Task<Order?> GetByIdAsync(int id);
        Task<Order> CreateAsync(Order orderModel);
        Task<Order?> UpdateAsync(int id, UpdateOrderDto orderModel);
        Task<Order?> DeleteAsync(int id);
    }
}