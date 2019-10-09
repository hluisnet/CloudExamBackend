using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudExam.ViewModels
{
    public class DashboardViewModel
    {
        public List<ItemValue> BestSellingProducts { get; set; }
        public List<ItemValue> TopCustomers { get; set; }

        public DashboardViewModel()
        {
            BestSellingProducts = new List<ItemValue>();
            TopCustomers = new List<ItemValue>();
        }

    }

    public class ItemValue
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
         
    }
}
