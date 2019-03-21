using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegularService.Models;

namespace RegularService.Interfaces
{
    public interface IShipper
    {
        Task<IEnumerable<Shipper>> GetAll();
        Task<Shipper> GetById(string id);
        Task<Shipper> Add(Shipper entity);
        Task<bool> Delete(string id);
        Task<Shipper> Update(Shipper entity);
        Task<int> Count();
    }
}