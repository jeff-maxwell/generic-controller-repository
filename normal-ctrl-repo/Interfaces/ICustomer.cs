using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegularService.Models;

namespace RegularService.Interfaces
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(Guid id);
        Task<Customer> Add(Customer entity);
        Task<bool> Delete(Guid id);
        Task<Customer> Update(Customer entity);
        Task<int> Count();
    }
}