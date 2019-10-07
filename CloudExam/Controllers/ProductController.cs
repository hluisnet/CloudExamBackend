using CloudExam.Models;
using CloudExam.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudExam.Controllers
{
    /// <summary>
    /// Products Endpoint
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        /// <summary>
        /// Get all products async
        /// </summary>
        /// <returns>All the products</returns>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllAsync()
        {
            return await _productService.GetAllAsync();
        }

        /// <summary>
        /// Get a Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The Product</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetAsync(int id)
        {
            var product = await _productService.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        /// <summary>
        /// Adds a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>The Product</returns>
        [HttpPost]
        public async Task<ActionResult<Product>> CreateAsync(Product product)
        {
            await _productService.CreateAsync(product);

            return CreatedAtAction(nameof(GetAsync), new { id = product.Id }, product);
        }

        /// <summary>
        /// Update a Product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns>The Product</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _productService.UpdateAsync(product);

            return NoContent();
        }

        /// <summary>
        /// Delete a Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Result of the action</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _productService.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(product);

            return NoContent();
        }
    }
}
