using CloudExam.Data;
using CloudExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudExam.Services
{
    public class ProductService : BaseService<Product, int>, IProductService
    {
        public ProductService(CloudExamDbContext dbContext) : base(dbContext)
        {
        }
    }
}
