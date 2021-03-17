using System;
using System.Collections.Generic;

#nullable disable

namespace DetailersApp.Repository.Models
{
    public partial class PotentialCustomer
    {
        public PotentialCustomer()
        {
            InverseRealCustomer = new HashSet<PotentialCustomer>();
            RealCustomers = new HashSet<RealCustomer>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public long? RealCustomerId { get; set; }

        public virtual PotentialCustomer RealCustomer { get; set; }
        public virtual ICollection<PotentialCustomer> InverseRealCustomer { get; set; }
        public virtual ICollection<RealCustomer> RealCustomers { get; set; }
    }
}
