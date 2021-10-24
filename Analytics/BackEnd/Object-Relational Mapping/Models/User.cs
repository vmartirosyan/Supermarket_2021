using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class User
    {
        public User()
        {
            CashboxTransactions = new HashSet<CashboxTransaction>();
            OrderCustomers = new HashSet<Order>();
            OrderDeliveryMen = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Passwd { get; set; }

        public virtual ICollection<CashboxTransaction> CashboxTransactions { get; set; }
        public virtual ICollection<Order> OrderCustomers { get; set; }
        public virtual ICollection<Order> OrderDeliveryMen { get; set; }
    }
}
