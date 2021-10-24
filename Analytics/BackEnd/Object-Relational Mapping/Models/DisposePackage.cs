using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class DisposePackage
    {
        public int? ProdId { get; set; }
        public int? BranchId { get; set; }
        public int? Quantity { get; set; }
        public int? Volume { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Product Prod { get; set; }
    }
}
