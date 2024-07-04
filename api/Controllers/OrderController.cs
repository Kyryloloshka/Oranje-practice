using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Order;
using api.Extensions;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IOrderRepository _orderRepo;
        private readonly IOrderItemRepository _orderItemRepo;
        private readonly UserManager<User> _userManager;

        public OrderController(UserManager<User> userManager, ApplicationDBContext context, IOrderRepository orderRepo, IOrderItemRepository orderItemRepo)
        {
            _context = context;
            _orderRepo = orderRepo;
            _orderItemRepo = orderItemRepo;
            _userManager = userManager;
        }

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orders = await _orderRepo.GetAllAsync();
            var ordersDto = orders.Select(s => s.ToOrderDto());
            return Ok(ordersDto);
        }

        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> GetUserOrders()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);

            var orders = await _orderRepo.GetUserOrders(user);
            return Ok(orders);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            var orderModel = orderDto.ToOrderFromCreateDto(user);
            await _orderRepo.CreateAsync(orderModel);

            return CreatedAtAction(nameof(GetUserOrders), new { id = orderModel }, orderModel.ToOrderDto());
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = await _orderRepo.UpdateAsync(id, updateDto);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order.ToOrderDto());
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = await _orderRepo.DeleteAsync(id);
            if (order == null)
            {
                return NotFound("Order does not exist");
            }
            return NoContent();
        }
    }
}