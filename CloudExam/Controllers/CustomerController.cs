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
    /// Customers Endpoint
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Get all Customers async
        /// </summary>
        /// <returns>All the products</returns>
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllAsync()
        {
            return await _customerService.GetAllAsync();
        }

        /// <summary>
        /// Get a Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The Customer</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetAsync(int id)
        {
            var product = await _customerService.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        /// <summary>
        /// Adds a Customer
        /// </summary>
        /// <param name="product"></param>
        /// <returns>The Product</returns>
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateAsync(Customer product)
        {
            await _customerService.CreateAsync(product);

            return CreatedAtAction(nameof(GetAsync), new { id = product.Id }, product);
        }

        /// <summary>
        /// Update a Customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns>The Product</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            await _customerService.UpdateAsync(customer);

            return NoContent();
        }

        /// <summary>
        /// Delete a Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Result of the action</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _customerService.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await _customerService.DeleteAsync(product);

            return NoContent();
        }
    }

}