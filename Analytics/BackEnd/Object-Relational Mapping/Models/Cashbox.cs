using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class Cashbox
    {
        public Cashbox()
        {
            CashboxTransactions = new HashSet<CashboxTransaction>();
        }

        public int Id { get; set; }
        public int? BranchId { get; set; }
        public decimal? Money { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual ICollection<CashboxTransaction> CashboxTransactions { get; set; }
    }
}
