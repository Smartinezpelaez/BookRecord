using BookRecord.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRecord.BLL.Repository.Implements
{
    public class GenericRepository<TEntity> : IGenericRepositor<TEntity> where TEntity : class
    {
        private readonly BookRecordContext context;

        public GenericRepository(BookRecordContext context)
        {
            this.context = context;
        }

        public int Count()
        {
            return context.Set<TEntity>().ToList().Count();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
                throw new Exception("The entity is null");

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            context.ChangeTracker.Clear();
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }


    }
}
