using System;
using System.Collections.Generic;

#nullable disable

namespace DetailersApp.Repository.Models
{
    public partial class RealCustomer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public long? PotentialCustomerId { get; set; }

        public virtual PotentialCustomer PotentialCustomer { get; set; }
    }
}
