using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegularService.Interfaces;
using RegularService.Models;

namespace RegularService.Services
{
    public class CustomerService : ICustomer
    {
        private DataContext _context;
        public CustomerService(DataContext context)
        {
            _context = context;
        }
        public async Task<Customer> Add(Customer entity)
        {
            if (entity.Id == null) {
                entity.Id = Guid.NewGuid();
            }

            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;

            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Customers.FindAsync(id);

            if (entity.CreatedDate == null)
                entity.CreatedDate = DateTime.UtcNow;

            entity.Deleted = true;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.DeletedDate = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            _context.Customers.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
 
        public async Task<Customer> GetById(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }
 
        public async Task<Customer> Update(Customer entity)
        {
            if (entity.CreatedDate == null)
                entity.CreatedDate = DateTime.UtcNow;

            entity.UpdatedDate = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            _context.Customers.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Count() {
            return await _context.Customers.CountAsync();
        }
    }
}