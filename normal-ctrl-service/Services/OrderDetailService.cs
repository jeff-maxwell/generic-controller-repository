using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegularService.Interfaces;
using RegularService.Models;

namespace RegularService.Services
{
    public class OrderDetailService : IOrderDetail
    {
        private DataContext _context;
        public OrderDetailService(DataContext context)
        {
            _context = context;
        }
        public async Task<OrderDetail> Add(OrderDetail entity)
        {
            if (entity.Id == null) {
                entity.Id = Guid.NewGuid();
            }

            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;

            await _context.OrderDetails.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.OrderDetails.FindAsync(id);

            if (entity.CreatedDate == null)
                entity.CreatedDate = DateTime.UtcNow;

            entity.Deleted = true;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.DeletedDate = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            _context.OrderDetails.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
 
        public async Task<OrderDetail> GetById(Guid id)
        {
            return await _context.OrderDetails.FindAsync(id);
        }

        public async Task<IEnumerable<OrderDetail>> GetAll()
        {
            return await _context.OrderDetails.ToListAsync();
        }
 
        public async Task<OrderDetail> Update(OrderDetail entity)
        {
            if (entity.CreatedDate == null)
                entity.CreatedDate = DateTime.UtcNow;

            entity.UpdatedDate = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            _context.OrderDetails.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Count() {
            return await _context.OrderDetails.CountAsync();
        }
    }
}