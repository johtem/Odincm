using Microsoft.EntityFrameworkCore;
using OdinCM.Data.Data.Interfaces;
using OdinCM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdinCM.Data.Data.Repositories
{
    public class CustomerSqliteRepository : ICustomerRepository
    {
        public IOdinCMContext Context { get; }

        public CustomerSqliteRepository(IOdinCMContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersPaged(int pageSize, int pageNumber)
        {
            return await Context.Customer
                .AsNoTracking()
                .OrderBy(a => a.CustomerName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToArrayAsync();
        }

        public async Task<int> GetTotalPagesOfCustomers(int pageSize)
        {
            return (int)Math.Ceiling(await Context.Customer.CountAsync() / (double)pageSize);
        }

        public async Task<Customer> GetCustomerById(int? Id)
        {
            return await Context.Customer.AsNoTracking().FirstAsync(a => a.CustomerID == Id);
        }


        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
