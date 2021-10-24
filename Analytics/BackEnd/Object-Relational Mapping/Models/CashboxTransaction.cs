using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class CashboxTransaction
    {
        public int Id { get; set; }
        public int? Cashier { get; set; }
        public int? CashboxId { get; set; }
        public byte[] Date { get; set; }

        public virtual Cashbox Cashbox { get; set; }
        public virtual User CashierNavigation { get; set; }
    }
}
