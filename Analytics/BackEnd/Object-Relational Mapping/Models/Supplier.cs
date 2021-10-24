using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
            Shippings = new HashSet<Shipping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? LocationId { get; set; }
        public DateTime? ContractExpDate { get; set; }
        public int? ContactNum { get; set; }
        public string ContactEmail { get; set; }

        public virtual AddressLocation Location { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
