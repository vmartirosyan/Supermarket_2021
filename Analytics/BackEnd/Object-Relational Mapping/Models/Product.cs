using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
        public int? Code { get; set; }
        public bool? Refunded { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
