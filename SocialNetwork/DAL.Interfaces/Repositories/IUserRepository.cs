using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetUserByIdAsync(string id);
        public Task<User> GetUserByUsernameAsync(string username);
        public void UpdateIdentityId(User user);
        public void UpdateUser(User user);
    }
}
