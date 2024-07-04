using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Order;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;
        public OrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateAsync(Order orderModel)
        {
            await _context.Orders.AddAsync(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task<Order?> DeleteAsync(int id)
        {
            var orderModel = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (orderModel == null)
            {
                return null;
            }
            _context.Orders.Remove(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order?> UpdateAsync(int id, UpdateOrderDto orderDto)
        {
            var existingOrder = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (existingOrder == null)
            {
                return null;
            }
            existingOrder.OrderItems = orderDto.OrderItems;

            await _context.SaveChangesAsync();
            return existingOrder;
        }

        public async Task<List<Order>> GetUserOrders(User user)
        {
            return await _context.Orders.Where(u => u.UserId == user.Id).ToListAsync();
        }
    }
}