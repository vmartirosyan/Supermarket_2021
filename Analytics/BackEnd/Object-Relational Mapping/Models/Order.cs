using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? DeliveryStatusId { get; set; }
        public int? OrderStatusId { get; set; }
        public int? DeliveryManId { get; set; }
        public string OrderDescription { get; set; }
        public int? BranchId { get; set; }
        public bool? PeymentStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? Delivered { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual User Customer { get; set; }
        public virtual User DeliveryMan { get; set; }
        public virtual DeliveryStatus DeliveryStatus { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
    }
}
