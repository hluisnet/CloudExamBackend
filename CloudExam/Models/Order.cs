using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CloudExam.Models
{
    [Table("Order")]
    public class Order: Entity
    {
        [Key]
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int AddressId { get; set; }
        public int PaymentTypeId { get; set; }
        public int Number { get; set; }
        public DateTime Timestamp { get; set; }
        
        
    }
 
}
