using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class Shipping
    {
        public int Id { get; set; }
        public int? BranchId { get; set; }
        public int? SupplierId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime? ArrivedAt { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
