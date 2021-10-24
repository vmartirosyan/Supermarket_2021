using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class Deliveryman
    {
        public int? EmployeeId { get; set; }
        public string CarType { get; set; }
        public string CarNumber { get; set; }
        public string CarModel { get; set; }

        public virtual User Employee { get; set; }
    }
}
