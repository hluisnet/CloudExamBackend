using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudExam.Models;
using CloudExam.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudExam.Controllers
{
    /// <summary>
    /// Address Endpoint
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AddressController : ControllerBase
    {

        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        /// <summary>
        /// Get all address async
        /// </summary>
        /// <returns>All the address</returns>
        [HttpGet]
        public async Task<ActionResult<List<Address>>> GetAllAsync()
        {
            return await _addressService.GetAllAsync();
        }

        /// <summary>
        /// Get a Address
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The Address</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAsync(int id)
        {
            var address = await _addressService.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        /// <summary>
        /// Adds a Address
        /// </summary>
        /// <param name="address"></param>
        /// <returns>The Address</returns>
        [HttpPost]
        public async Task<ActionResult<Address>> CreateAsync(Address address)
        {
            await _addressService.CreateAsync(address);

            return CreatedAtAction(nameof(GetAsync), new { id = address.Id }, address);
        }

        /// <summary>
        /// Update a Address
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns>The Address</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            await _addressService.UpdateAsync(address);

            return NoContent();
        }

        /// <summary>
        /// Delete a Address
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Result of the action</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var address = await _addressService.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            await _addressService.DeleteAsync(address);

            return NoContent();
        }

    }
}
