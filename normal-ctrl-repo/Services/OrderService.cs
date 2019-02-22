using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegularService.Interfaces;
using RegularService.Models;

namespace RegularService.Services
{
    public class OrderService : IOrder
    {
        private DataContext _context;
        public OrderService(DataContext context)
        {
            _context = context;
        }
        public async Task<Order> Add(Order entity)
        {
            if (entity.Id == null) {
                entity.Id = Guid.NewGuid();
            }

            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;

            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Orders.FindAsync(id);

            if (entity.CreatedDate == null)
                entity.CreatedDate = DateTime.UtcNow;

            entity.Deleted = true;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.DeletedDate = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
 
        public async Task<Order> GetById(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }
 
        public async Task<Order> Update(Order entity)
        {
            if (entity.CreatedDate == null)
                entity.CreatedDate = DateTime.UtcNow;

            entity.UpdatedDate = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Count() {
            return await _context.Orders.CountAsync();
        }
    }
}