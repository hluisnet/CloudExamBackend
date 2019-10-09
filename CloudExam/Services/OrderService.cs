using CloudExam.Data;
using CloudExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudExam.Services
{
    public class OrderService: BaseService<Order , int>, IOrderService
    {
        public OrderService(CloudExamDbContext dbContext): base(dbContext)
        {

        }
    }
}
