using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegularService.Interfaces;
using RegularService.Models;

namespace RegularService.Services
{
    public class ProductService : IProduct
    {
        private DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }
        public async Task<Product> Add(Product entity)
        {
            if (entity.Id == null) {
                entity.Id = Guid.NewGuid();
            }

            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;

            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Products.FindAsync(id);

            if (entity.CreatedDate == null)
                entity.CreatedDate = DateTime.UtcNow;

            entity.Deleted = true;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.DeletedDate = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
 
        public async Task<Product> GetById(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }
 
        public async Task<Product> Update(Product entity)
        {
            if (entity.CreatedDate == null)
                entity.CreatedDate = DateTime.UtcNow;

            entity.UpdatedDate = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Count() {
            return await _context.Products.CountAsync();
        }
    }
}