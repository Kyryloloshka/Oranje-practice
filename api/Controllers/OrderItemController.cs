using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/order-items")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IProductRepository _productRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IOrderItemRepository _orderItemRepo;
        public OrderItemController(ApplicationDBContext context, IProductRepository productRepo, IOrderRepository orderRepo, IOrderItemRepository orderItemRepo)
        {
            _productRepo = productRepo;
            _context = context;
            _orderRepo = orderRepo;
            _orderItemRepo = orderItemRepo;
        }

        [HttpPost("{orderId:int}/{productId:int}")]
        public async Task<IActionResult> Create([FromRoute] int orderId, [FromRoute] int productId, [FromBody] CreateOrderItemDto orderItemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = await _orderRepo.GetByIdAsync(orderId);
            if (order == null)
            {
                return BadRequest("Order with this id does not exist.");
            }

            var product = await _productRepo.GetByIdAsync(productId);
            if (product == null)
            {
                return BadRequest("Product with this id does not exist.");
            }

            var orderItem = orderItemDto.ToOrderItemFromCreateDto(order.Id, product);
            await _orderItemRepo.CreateAsync(orderItem);
            await _context.SaveChangesAsync();
            return Ok(orderItem);
        }
    }
}