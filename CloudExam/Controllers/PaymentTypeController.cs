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
    /// PaymentType
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypeService;


        public PaymentTypeController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        /// <summary>
        /// Get all payment types async
        /// </summary>
        /// <returns>All the payment types</returns>
        [HttpGet]
        public async Task<ActionResult<List<PaymentType>>> GetAllAsync()
        {
            return await _paymentTypeService.GetAllAsync();
        }

        /// <summary>
        /// Get a Payment Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The Payment Type</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentType>> GetAsync(int id)
        {
            var product = await _paymentTypeService.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
         
    }
}