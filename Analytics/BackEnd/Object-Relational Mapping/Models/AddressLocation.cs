using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class AddressLocation
    {
        public AddressLocation()
        {
            Branches = new HashSet<Branch>();
            Suppliers = new HashSet<Supplier>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public int? BuildingNumber { get; set; }
        public int? PostalCode { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
