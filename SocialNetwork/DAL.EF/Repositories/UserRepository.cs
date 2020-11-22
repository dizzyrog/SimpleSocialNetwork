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

        public void UpdateIdentityId(User user)
        {
            //TODO create exceptions, check for null
            //context.Entry(entity).State = EntityState.Modified;
            //TODO insert a into the next line

            //var a = DbSet.Update(entity);
            var entity = DbSetWithAllProperties().FirstOrDefault(u => u.UserName == user.UserName);

            if (entity.UserIdentityId is null)
            {
                entity.UserIdentityId = user.UserIdentityId;
                context.Set<User>().Update(entity);
                context.SaveChanges();
            }
            
            //context.Entry(user).Property(e => e.UserIdentityId).IsModified = true;
            //context.SaveChanges();


        }
        public void UpdateUser(User userToUpdate)
        {
            var userOld = DbSet.FirstOrDefault(x => x.UserIdentityId == userToUpdate.UserIdentityId);
            userToUpdate.Id = userOld.Id;
            //var user1 = user.Clone();
            //userToUpdate = (User)user1;
            //context.Users.Update(userToUpdate);
            // context.Set<User>().Update(userToUpdate);
            context.Entry(userOld).CurrentValues.SetValues(userToUpdate);
            context.SaveChanges();
            // context.Entry(a).Property(x => x.Id).IsModified = false;
            //context.Entry(a).State = EntityState.Modified;
            //context.Entry(a).CurrentValues.SetValues(user);//.Ignore(x => x.Id); 
            //if (a != null)
            //{
            //    context.Entry<User>(user).State = EntityState.Detached;
            //    context.Entry<User>(a).State = EntityState.Detached;
            //    context.SaveChanges();
            //}

            // context.Attach(user);
            //context.SaveChanges();
            //    var user = _applicationDbContext.Users.FirstOrDefault(u => u.Id == model.Id);

            //    user.PhoneNumberConfirmed = model.PhoneNumberConfirmed;

            //    var user = _applicationDbContext.Users.FirstOrDefault(u => u.Id == model.Id);

            //    user.PhoneNumberConfirmed = model.PhoneNumberConfirmed;


            //context.Entry<User>(a).Property(x => x.Id).IsModified = false;
            //context.Entry<User>(user).Property(x => x.Id).IsModified = false;
            //context.SaveChanges();
            
            ////TODO fixme
            //var entity = DbSetWithAllProperties().FirstOrDefault(u => u.UserName == user.UserName);

            //if (entity.AboutMe == null)
            //{
            //    entity.AboutMe = user.AboutMe;
            //    context.Set<User>().Update(entity);
            //    context.SaveChanges();
            //}
            //if (entity.Age == 0)
            //{
            //    entity.Age = user.Age;
            //    context.Set<User>().Update(entity);
            //    context.SaveChanges();
            //}
            //if (entity.City == null)
            //{
            //    entity.City = user.City;
            //    context.Set<User>().Update(entity);
            //    context.SaveChanges();
            //}
            //if (entity.Country == null)
            //{
            //    entity.Country = user.Country;
            //    context.Set<User>().Update(entity);
            //    context.SaveChanges();
            //}
            //if (entity.Email == null)
            //{
            //    entity.Email = user.Email;
            //    context.Set<User>().Update(entity);
            //    context.SaveChanges();
            //}
            //if (entity.FirstName == null)
            //{
            //    entity.FirstName = user.FirstName;
            //    context.Set<User>().Update(entity);
            //    context.SaveChanges();
            //}
            //if (entity.LastName == null)
            //{
            //    entity.LastName = user.LastName;
            //    context.Set<User>().Update(entity);
            //    context.SaveChanges();
            //}

            //if (entity.PhoneNumber == null)
            //{
            //    entity.PhoneNumber = user.PhoneNumber;
            //    context.Set<User>().Update(entity);
            //    context.SaveChanges();
            //}
            //if (entity.University == null)
            //{
            //    entity.University = user.University;
            //    context.Set<User>().Update(entity);
            //    context.SaveChanges();
            //}
        }


        protected override IQueryable<User> DbSetWithAllProperties()
        {
            return DbSet;
        }
    }
}

