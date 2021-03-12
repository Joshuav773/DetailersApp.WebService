using DetailersApp.WebService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetailersApp.WebService.Service
{
    public class PotentialCustomerService : CustomerService<PotentialCustomer>
    {
        public override async Task<(IEnumerable<PotentialCustomer>, string)> GetAll()
        {
            return await base.GetAll();
        }

        public override async Task<(PotentialCustomer, string)> GetById(int id)
        {
            return await base.GetById(id);
        }
    }
}
