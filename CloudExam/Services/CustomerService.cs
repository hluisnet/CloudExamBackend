using CloudExam.Data;
using CloudExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudExam.Services
{
    public class CustomerService: BaseService<Customer, int>, ICustomerService
    {
        public CustomerService(CloudExamDbContext dbContext): base(dbContext)
        {

        }
    }
}
