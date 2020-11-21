using DAL.Domain;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Repositories
{
   public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected DbSet<T> DbSet { get; }
        protected DbContext context;
        
        protected GenericRepository(DbContext context)
        {
            DbSet = context.Set<T>();
            this.context = context;
        }

        protected abstract IQueryable<T> DbSetWithAllProperties();

        public async Task<T> GetByIdAsync(int id)
        {
            // AsNoTracking() - ef not tracking changes in db and it works faster.
            var entity = await DbSetWithAllProperties()
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
            //TODO create exceptions, check for null
            

            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await DbSetWithAllProperties()
                .AsNoTracking()
                .ToListAsync();
            //TODO create exceptions, check for null

            return entities;
        }

        

        public async Task CreateAsync(T entity)
        {
            //TODO create exceptions, check for null

            await DbSet.AddAsync(entity);
            context.SaveChanges();

        }

        public void Remove(T entity)
        {
            //TODO create exceptions, check for null

            DbSet.Remove(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {

            //TODO create exceptions, check for null
            //context.Entry(entity).State = EntityState.Modified;
            //TODO insert a into the next line
            
            var a =  DbSet.FirstOrDefault(x => x.Id == entity.Id);
            context.Entry(a).CurrentValues.SetValues(entity);
            //var a = DbSet.Update(entity);
            context.SaveChanges();
        }
    }
}

