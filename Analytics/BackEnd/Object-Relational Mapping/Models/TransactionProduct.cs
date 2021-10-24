using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class TransactionProduct
    {
        public int? TransactionId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual CashboxTransaction Transaction { get; set; }
    }
}
