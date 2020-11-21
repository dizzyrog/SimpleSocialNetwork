using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserByIdAsync(string id);
        public Task<UserDTO> GetByIdAsync(int id);
        public Task AddUser(UserDTO user);
        public Task<IEnumerable<UserDTO>> GetUsersAsync();
        public void UpdateIdentityId(UserDTO userDTO);
        public void UpdateUser(UserDTO userDTO);
        public void DeleteUser(UserDTO user);
    }
}
