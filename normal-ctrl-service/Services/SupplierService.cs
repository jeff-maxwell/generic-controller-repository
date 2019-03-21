using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegularService.Interfaces;
using RegularService.Models;

namespace RegularService.Services
{
    public class SupplierService : ISupplier
    {
        private DataContext _context;
        public SupplierService(DataContext context)
        {
            _context = context;
        }
        public async Task<Supplier> Add(Supplier entity)
        {
            if (entity.Id == null) {
                entity.Id = Guid.NewGuid().ToString();
            }

            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;

            await _context.Suppliers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(string id)
        {
            var entity = await _context.Suppliers.FindAsync(id);

            if (entity.CreatedDate == null)
                entity.CreatedDate = DateTime.UtcNow;

            entity.Deleted = true;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.DeletedDate = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            _context.Suppliers.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
 
        public async Task<Supplier> GetById(string id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await _context.Suppliers.ToListAsync();
        }
 
        public async Task<Supplier> Update(Supplier entity)
        {
            if (entity.CreatedDate == null)
                entity.CreatedDate = DateTime.UtcNow;

            entity.UpdatedDate = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            _context.Suppliers.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Count() {
            return await _context.Suppliers.CountAsync();
        }
    }
}