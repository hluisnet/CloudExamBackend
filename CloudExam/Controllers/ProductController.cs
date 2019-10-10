using AutoMapper;
using CloudExam.Models;
using CloudExam.Services;
using CloudExam.ViewModels;
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
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            this._mapper = mapper;


            
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
        public async Task<ActionResult<Product>> CreateAsync(ProductViewModel product)
        {
            var productObj = this._mapper.Map<ProductViewModel, Product>(product);

            await _productService.CreateAsync(productObj);

            return CreatedAtAction(nameof(GetAsync), new { id = productObj.Id }, productObj);
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
