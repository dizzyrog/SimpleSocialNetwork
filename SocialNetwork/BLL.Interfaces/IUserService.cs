using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserByIdAsync(int id);
        public Task AddUser(UserDTO user);
        public Task<IEnumerable<UserDTO>> GetUsersAsync();
        public Task UpdateUserAsync(UserDTO userDTO);
        public void DeleteUser(UserDTO user);
    }
}
