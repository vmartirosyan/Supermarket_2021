using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class Branch
    {
        public Branch()
        {
            Cashboxes = new HashSet<Cashbox>();
            Orders = new HashSet<Order>();
            Shippings = new HashSet<Shipping>();
        }

        public int Id { get; set; }
        public int? LocationId { get; set; }
        public int? FreezerVolume { get; set; }
        public int? StorageVolume { get; set; }
        public string Type { get; set; }

        public virtual AddressLocation Location { get; set; }
        public virtual ICollection<Cashbox> Cashboxes { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
