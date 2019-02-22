using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegularControllerRepo.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Add(T entity);
        Task<bool> Delete(Guid id);
        Task<T> Update(T entity);
        Task<int> Count();
    }
}