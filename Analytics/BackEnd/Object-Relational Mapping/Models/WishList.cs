using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class WishList
    {
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }

        public virtual User Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
