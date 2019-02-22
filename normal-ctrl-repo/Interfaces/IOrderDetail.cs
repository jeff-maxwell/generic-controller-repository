using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegularService.Models;

namespace RegularService.Interfaces
{
    public interface IOrderDetail
    {
        Task<IEnumerable<OrderDetail>> GetAll();
        Task<OrderDetail> GetById(Guid id);
        Task<OrderDetail> Add(OrderDetail entity);
        Task<bool> Delete(Guid id);
        Task<OrderDetail> Update(OrderDetail entity);
        Task<int> Count();
    }
}