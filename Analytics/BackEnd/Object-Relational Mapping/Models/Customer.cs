using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class Customer
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? AddressId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual AddressLocation Address { get; set; }
        public virtual User IdNavigation { get; set; }
    }
}
