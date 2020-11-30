using DAL.Domain;
using DAL.EF.Contexts;
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
        public UserRepository(ApplicationDbContext context) : base(context)
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
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var entity =  await DbSetWithAllProperties()
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.UserName == username);
            //TODO create exceptions, check for null

            return entity;
        }

        public void UpdateIdentityId(User user)
        {
            //TODO create exceptions, check for null
            var entity = DbSetWithAllProperties().FirstOrDefault(u => u.UserName == user.UserName);

            if (entity.UserIdentityId is null)
            {
                entity.UserIdentityId = user.UserIdentityId;
                context.Set<User>().Update(entity);
                context.SaveChanges();
            }


        }
        public void UpdateUser(User userToUpdate)
        {
            var userOld = DbSet.FirstOrDefault(x => x.UserIdentityId == userToUpdate.UserIdentityId);
            userToUpdate.Id = userOld.Id;
            context.Entry(userOld).CurrentValues.SetValues(userToUpdate);
            context.SaveChanges();
        }


        protected override IQueryable<User> DbSetWithAllProperties()
        {
            return DbSet;
        }
    }
}

