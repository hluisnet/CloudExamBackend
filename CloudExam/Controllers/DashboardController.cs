using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudExam.Data;
using CloudExam.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloudExam.Controllers
{

    /// <summary>
    /// Dashboard Endpoint
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
      

        public DashboardController(IDashboardService dashboardService)
        {

            _dashboardService = dashboardService;
        }

        /// <summary>
        /// Get Dashboard 
        /// </summary>
        /// <returns>All the products</returns>
        [HttpGet]
        public IActionResult Index()
        {

            return Ok(_dashboardService.GetDashboard());
        }
    }
}