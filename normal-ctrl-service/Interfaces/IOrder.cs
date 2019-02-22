using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegularService.Models;

namespace RegularService.Interfaces
{
    public interface IOrder
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(Guid id);
        Task<Order> Add(Order entity);
        Task<bool> Delete(Guid id);
        Task<Order> Update(Order entity);
        Task<int> Count();
    }
}