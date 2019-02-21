using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegularService.Models;

namespace RegularService.Interfaces
{
    public interface IShipper
    {
        Task<IEnumerable<Shipper>> GetAll();
        Task<Shipper> GetById(Guid id);
        Task<Shipper> Add(Shipper entity);
        Task<bool> Delete(Guid id);
        Task<Shipper> Update(Shipper entity);
        Task<int> Count();
    }
}