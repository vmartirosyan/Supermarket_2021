using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class Employee
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? AddressId { get; set; }
        public int? ProfessionId { get; set; }
        public decimal? StartingSalary { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? FirstdayDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? DepartmentId { get; set; }
        public int? BranchId { get; set; }

        public virtual AddressLocation Address { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Department Department { get; set; }
        public virtual User IdNavigation { get; set; }
        public virtual Proffesion Profession { get; set; }
    }
}
