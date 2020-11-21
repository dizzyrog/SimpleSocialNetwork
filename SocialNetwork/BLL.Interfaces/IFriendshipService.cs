using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFriendshipService
    {
        public Task<IEnumerable<FriendshipDTO>> GetFriendshipsAsync();
        public Task<IEnumerable<UserDTO>> GetFriendsByUserIdAsync(int userId);
    }
}
