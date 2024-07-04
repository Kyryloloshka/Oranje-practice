using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Order;
using api.Models;

namespace api.Mappers
{
    public static class OrderMappers
    {
        public static OrderDto ToOrderDto(this Order product)
        {
            return new OrderDto
            {
                Id = product.Id,
                UserId = product.UserId,
                OrderDate = product.OrderDate,
                OrderItems = product.OrderItems,
                TotalAmount = product.TotalAmount
            };
        }

        public static Order ToOrderFromCreateDto(this CreateOrderDto orderDto, User user)
        {
            return new Order
            {
                UserId = user.Id,
                OrderDate = DateTime.Now,
                OrderItems = orderDto.OrderItems,
                TotalAmount = orderDto.OrderItems.Sum(x => x.UnitPrice)
            };
        }
    }
}