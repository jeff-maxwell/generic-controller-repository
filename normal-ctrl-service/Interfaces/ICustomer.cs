using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegularService.Models;

namespace RegularService.Interfaces
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(string id);
        Task<Customer> Add(Customer entity);
        Task<bool> Delete(string id);
        Task<Customer> Update(Customer entity);
        Task<int> Count();
    }
}