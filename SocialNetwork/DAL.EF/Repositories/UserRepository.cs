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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
        public async Task<User> GetUserByIdAsync(string id)
        {
            // AsNoTracking() - ef not tracking changes in db and it works faster.
            var entity = await DbSetWithAllProperties()
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.UserIdentityId == id);
            //TODO create exceptions, check for null

            return entity;
        }

        public void UpdateIdentityId(User user)
        {
            //TODO create exceptions, check for null
            //context.Entry(entity).State = EntityState.Modified;
            //TODO insert a into the next line

            //var a = DbSet.Update(entity);
            var entity = DbSetWithAllProperties().FirstOrDefault(u => u.UserName == user.UserName);

            entity.UserIdentityId = user.UserIdentityId;

            context.Set<User>().Update(entity);
            context.SaveChanges();
            //context.Entry(user).Property(e => e.UserIdentityId).IsModified = true;
            //context.SaveChanges();


        }
        
        protected override IQueryable<User> DbSetWithAllProperties()
        {
            return DbSet;
        }
    }
}

