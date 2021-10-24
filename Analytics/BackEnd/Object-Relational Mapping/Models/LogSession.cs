using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class LogSession
    {
        public int? Id { get; set; }
        public DateTime? LogIn { get; set; }
        public DateTime? LogOut { get; set; }

        public virtual User IdNavigation { get; set; }
    }
}
