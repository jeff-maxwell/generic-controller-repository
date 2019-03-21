using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegularService.Models;

namespace RegularService.Interfaces
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(string id);
        Task<Employee> Add(Employee entity);
        Task<bool> Delete(string id);
        Task<Employee> Update(Employee entity);
        Task<int> Count();
    }
}