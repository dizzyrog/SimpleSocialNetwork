using DAL.Domain;
using DAL.EF.Contexts;
using DAL.EF.Exceptions;
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
        protected ApplicationDbContext context;
        
        protected GenericRepository(ApplicationDbContext context)
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

            if (entity == null)
            {
                throw new DbRecordNotFoundException("No record found with id: ", id.ToString());
            }

            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await DbSetWithAllProperties()
                .AsNoTracking()
                .ToListAsync();
            

            return entities;
        }

        

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity","Error while checking for null in create entity method in repository");
            }

            await DbSet.AddAsync(entity);
            context.SaveChanges();

        }

        public void Remove(T entity)
        {
            
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Error while checking for null in remove entity method in repository");
            }
            DbSet.Remove(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Error while checking for null in update entity method in repository");
            }
            context.Entry(DbSet.FirstOrDefault(x => x.Id == entity.Id)).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }
    }
}

