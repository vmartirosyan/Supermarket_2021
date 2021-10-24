using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class ProductPackage
    {
        public int? ShippingId { get; set; }
        public int? BranchId { get; set; }
        public int? ProdId { get; set; }
        public int? WarehouseQuantity { get; set; }
        public int? DepQuantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? Volume { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Product Prod { get; set; }
        public virtual Shipping Shipping { get; set; }
    }
}
