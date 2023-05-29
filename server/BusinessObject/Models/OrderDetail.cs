using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int CourseId { get; set; }
        public decimal? UnitPrice { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
