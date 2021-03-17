using DetailersApp.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetailersApp.WebService.Envelope
{
    public class PotentialCustomerEnvelope 
    {
        public class PotentialCustomerResponse : BaseEnvelope
        {
            public IEnumerable<PotentialCustomer> PotentialCustomers { get; set; }
        }

        public class PotentialCustomerRequest : PotentialCustomer
        {

        }
    }
}
