using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ApplicationDBContext _context;

        public OrderItemRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<OrderItem?> GetByIdAsync(int id)
        {
            return await _context.OrderItems.FindAsync(id);
        }

        public async Task<OrderItem> CreateAsync(OrderItem orderItemModel)
        {
            await _context.OrderItems.AddAsync(orderItemModel);
            await _context.SaveChangesAsync();
            return orderItemModel;
        }
    }
}