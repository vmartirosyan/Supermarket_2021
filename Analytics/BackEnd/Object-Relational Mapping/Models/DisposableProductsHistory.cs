using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class DisposableProductsHistory
    {
        public int? Id { get; set; }
        public bool? RefoundStatus { get; set; }
        public int? RefunderId { get; set; }
        public int? RefundPrice { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Product IdNavigation { get; set; }
        public virtual Supplier Refunder { get; set; }
    }
}
