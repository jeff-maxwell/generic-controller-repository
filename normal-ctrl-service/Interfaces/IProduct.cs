using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegularService.Models;

namespace RegularService.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(string id);
        Task<Product> Add(Product entity);
        Task<bool> Delete(string id);
        Task<Product> Update(Product entity);
        Task<int> Count();
    }
}