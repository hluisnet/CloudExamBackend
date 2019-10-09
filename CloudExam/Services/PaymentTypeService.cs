using CloudExam.Data;
using CloudExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudExam.Services
{
    public class PaymentTypeService : BaseService<PaymentType, int>, IPaymentTypeService
    {
        public PaymentTypeService(CloudExamDbContext context) : base(context)
        {

        }
    }
}
