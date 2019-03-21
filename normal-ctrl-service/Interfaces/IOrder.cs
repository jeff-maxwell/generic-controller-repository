using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegularService.Models;

namespace RegularService.Interfaces
{
    public interface IOrder
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(string id);
        Task<Order> Add(Order entity);
        Task<bool> Delete(string id);
        Task<Order> Update(Order entity);
        Task<int> Count();
    }
}