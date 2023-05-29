using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? AccountId { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
