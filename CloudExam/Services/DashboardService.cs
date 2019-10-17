using CloudExam.Data;
using CloudExam.Models;
using CloudExam.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudExam.Services
{
    public class DashboardService : IDashboardService
    {

        public DbSet<Order> Orders { get; }
        public DbSet<OrderProduct> OrderProducts { get; }
        public DbSet<Customer> Customers { get; }

        protected CloudExamDbContext _dbContext { get; }

        public DashboardService(CloudExamDbContext dbContext)
        {

            this._dbContext = dbContext;

            this.Orders = this._dbContext.Set<Order>();
            this.OrderProducts = this._dbContext.Set<OrderProduct>();
            this.Customers = this._dbContext.Set<Customer>();

        }

        public DashboardViewModel GetDashboard()
        {
            var dashboardViewModel = new DashboardViewModel();

            var bestSellingProducts = (from p in _dbContext.Products
                                       join op in _dbContext.OrderProducts on p.Id equals op.ProductId
                                       group op by new { Name = p.Name } into o
                                       select new ItemValue
                                       {
                                           Name = o.Key.Name,
                                           Value = o.Sum(op => op.Quantity)
                                       }).OrderByDescending(op => op.Value).ToList();

            var topCustomers = (from c in _dbContext.Customers
                                join o in _dbContext.Orders on c.Id equals o.CustomerId
                                group o by new { TopCustomer = c.Name, o.CustomerId } into g
                                select new ItemValue
                                {
                                    Name = g.Key.TopCustomer,
                                    Value = g.Count(x => x.CustomerId == g.Key.CustomerId)
                                }).Where(x => x.Value > 0).ToList();

            dashboardViewModel.BestSellingProducts = bestSellingProducts;
            dashboardViewModel.TopCustomers = topCustomers;

            return dashboardViewModel;

        }
    }
}
