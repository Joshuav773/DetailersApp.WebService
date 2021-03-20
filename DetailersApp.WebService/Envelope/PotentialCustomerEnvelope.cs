using DetailersApp.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetailersApp.WebService.Envelope
{
    public class PotentialCustomerEnvelope 
    {
        public class PotentialCustomerResponse : BaseResponse<PotentialCustomer>
        {
        }

        public class PotentialCustomerRequest : PotentialCustomer
        {
        }
    }
}
