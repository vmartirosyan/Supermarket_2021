using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class DeliveryStatus
    {
        public DeliveryStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
