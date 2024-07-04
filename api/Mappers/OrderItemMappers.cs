using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class OrderItemMappers
    {
        public static OrderItem ToOrderItemFromCreateDto(this CreateOrderItemDto orderItemCreateDto, int orderId, Product product)
        {
            return new OrderItem
            {
                ProductId = product.Id,
                OrderId = orderId,
                Product = product,
                Quantity = orderItemCreateDto.Quantity,
                UnitPrice = product.Price * orderItemCreateDto.Quantity
            };
        }
    }
}