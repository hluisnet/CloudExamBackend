using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudExam.Models;
using CloudExam.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudExam.Controllers
{
    /// <summary>
    /// Order Endpoint
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        /// <summary>
        /// Get all orders async
        /// </summary>
        /// <returns>All the products</returns>
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllAsync()
        {
            return await _orderService.GetAllAsync();
        }

        /// <summary>
        /// Get a Order
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The Order</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetAsync(int id)
        {
            var order = await _orderService.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        /// <summary>
        /// Adds a Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns>The Order</returns>
        [HttpPost]
        public async Task<ActionResult<Order>> CreateAsync(Order order)
        {
            await _orderService.CreateAsync(order);

            return CreatedAtAction(nameof(GetAsync), new { id = order.Id }, order);
        }

        /// <summary>
        /// Update a Order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns>The Order</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            await _orderService.UpdateAsync(order);

            return NoContent();
        }

        /// <summary>
        /// Delete a Order
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Result of the action</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _orderService.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await _orderService.DeleteAsync(product);

            return NoContent();
        }

    }
}