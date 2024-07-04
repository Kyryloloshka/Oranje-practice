using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = [];
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }
    }
}