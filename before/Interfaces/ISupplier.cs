using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegularService.Models;

namespace RegularService.Interfaces
{
    public interface ISupplier
    {
        Task<IEnumerable<Supplier>> GetAll();
        Task<Supplier> GetById(Guid id);
        Task<Supplier> Add(Supplier entity);
        Task<bool> Delete(Guid id);
        Task<Supplier> Update(Supplier entity);
        Task<int> Count();
    }
}