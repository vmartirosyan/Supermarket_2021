using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class CellProduct
    {
        public int? BranchId { get; set; }
        public int? ProductId { get; set; }
        public int? DepQuantity { get; set; }
        public int? OptimalQuantity { get; set; }
        public int? MaxQuantity { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Product Product { get; set; }
    }
}
