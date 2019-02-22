using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegularService.Models;

namespace RegularService.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<Product> Add(Product entity);
        Task<bool> Delete(Guid id);
        Task<Product> Update(Product entity);
        Task<int> Count();
    }
}