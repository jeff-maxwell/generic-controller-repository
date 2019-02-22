
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GenericControllerRepository.Interfaces;
using GenericControllerRepository.Models;
using GenericControllerRepository.Services;

namespace GenericControllerRepository.Services
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
       private DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public async Task<T> Add(T entity)
        {
            if (entity.Id == null) {
                entity.Id = Guid.NewGuid();
            }

            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity.CreatedDate == null)
                entity.CreatedDate = DateTime.UtcNow;

            entity.Deleted = true;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.DeletedDate = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
 
        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync<T>();
        }
 
        public async Task<T> Update(T entity)
        {
            if (entity.CreatedDate == null)
                entity.CreatedDate = DateTime.UtcNow;

            entity.UpdatedDate = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Count()
        {
            return await _context.Set<T>().CountAsync();
        }
    }
}