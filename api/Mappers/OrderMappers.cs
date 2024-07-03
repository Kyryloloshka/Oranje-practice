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

        public static Order ToOrderFromCreateDto(this CreateOrderDto orderDto)
        {
            return new Order
            {
                UserId = orderDto.UserId,
                OrderItems = orderDto.OrderItems,
            };
        }
    }
}