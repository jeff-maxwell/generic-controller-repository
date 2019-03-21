using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegularService.Interfaces;
using RegularService.Models;

namespace RegularService.Services
{
    public class ShipperService : IShipper
    {
        private DataContext _context;
        public ShipperService(DataContext context)
        {
            _context = context;
        }
        public async Task<Shipper> Add(Shipper entity)
        {
            if (entity.Id == null) {
                entity.Id = Guid.NewGuid().ToString();
            }

            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;

            await _context.Shippers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(string id)
        {
            var entity = await _context.Shippers.FindAsync(id);

            if (entity.CreatedDate == null)
                entity.CreatedDate = DateTime.UtcNow;

            entity.Deleted = true;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.DeletedDate = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            _context.Shippers.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
 
        public async Task<Shipper> GetById(string id)
        {
            return await _context.Shippers.FindAsync(id);
        }

        public async Task<IEnumerable<Shipper>> GetAll()
        {
            return await _context.Shippers.ToListAsync();
        }
 
        public async Task<Shipper> Update(Shipper entity)
        {
            if (entity.CreatedDate == null)
                entity.CreatedDate = DateTime.UtcNow;

            entity.UpdatedDate = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            _context.Shippers.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Count() {
            return await _context.Shippers.CountAsync();
        }
    }
}