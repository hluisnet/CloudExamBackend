using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CloudExam.Models
{
    [Table("PaymentType")]
    public class PaymentType: Entity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
