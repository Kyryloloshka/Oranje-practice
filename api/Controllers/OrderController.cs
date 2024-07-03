using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Order;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IOrderRepository _orderRepo;
        public OrderController(ApplicationDBContext context, IOrderRepository orderRepo)
        {
            _context = context;
            _orderRepo = orderRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orders = await _orderRepo.GetAllAsync();
            var ordersDto = orders.Select(s => s.ToOrderDto());
            return Ok(ordersDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = await _orderRepo.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order.ToOrderDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderModel = orderDto.ToOrderFromCreateDto();
            await _orderRepo.CreateAsync(orderModel);

            return CreatedAtAction(nameof(GetById), new { id = orderModel }, orderModel.ToOrderDto());
        }

        [HttpPut("{id:int}")]
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