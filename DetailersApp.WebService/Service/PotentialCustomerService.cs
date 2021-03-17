using DetailersApp.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetailersApp.WebService.Service
{
    public class PotentialCustomerService 
    {
        private DetailersAppContext _context;

        public PotentialCustomerService(DetailersAppContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<PotentialCustomer>> GetAllPotentialCustomers() 
        {
            using (var ctx = _context)
            {
                return await ctx.PotentialCustomers.ToListAsync();
            }
        }
    }
}
