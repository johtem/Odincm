using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OdinCM.Data.Models;

namespace OdinCM.Data.Data.Interfaces
{
    public interface ICustomerRepository : IDisposable
    {

        Task<IEnumerable<Customer>> GetAllCustomersPaged(int pageSize, int pageNumber);

        Task<int> GetTotalPagesOfCustomers(int pageSize);

        Task<Customer> GetCustomerById(int? Id);
    }
}
