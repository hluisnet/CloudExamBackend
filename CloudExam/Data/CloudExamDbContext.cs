using CloudExam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CloudExam.Data
{
    public class CloudExamDbContext : DbContext
    {
        public CloudExamDbContext(DbContextOptions<CloudExamDbContext> options)
          : base(options) { }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}
