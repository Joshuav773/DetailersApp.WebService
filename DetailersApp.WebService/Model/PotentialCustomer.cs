using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetailersApp.WebService.Model
{
    public class PotentialCustomer : Customer
    {
        public int RealCustomerId { get; set; }
    }
}
