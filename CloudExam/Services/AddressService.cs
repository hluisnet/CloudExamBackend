using CloudExam.Data;
using CloudExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudExam.Services
{
    public class AddressService : BaseService<Address, int>, IAddressService
    {
        public AddressService(CloudExamDbContext dbContext): base(dbContext)
        {

        }
    }
}
