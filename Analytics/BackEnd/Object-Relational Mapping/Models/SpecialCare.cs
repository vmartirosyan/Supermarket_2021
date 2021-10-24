using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class SpecialCare
    {
        public int? ProdId { get; set; }
        public int? MaxTemp { get; set; }
        public int? MinTemp { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public virtual Product Prod { get; set; }
    }
}
