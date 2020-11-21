using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Domain;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Services
{
    public class FriendshipService : BaseService, IFriendshipService
    {
        private readonly IUserService _userService;
        public FriendshipService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService) : base(unitOfWork, mapper)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<UserDTO>> GetFriendsByUserIdAsync(int userId)
        {
            var user = await _userService.GetByIdAsync(userId);
            var friends = new List<UserDTO>();
            var friendships = await GetFriendshipsAsync();
            var selectedFriendships = friendships.Where(t => t.UserId == userId);
            foreach (var item in selectedFriendships)
            {
                friends.Add(await _userService.GetByIdAsync(item.FriendId));
            }
            return friends;
        }
        //public async Task AddFriendship(FriendshipDTO user)
        //{
        //    var userMapped = Mapper.Map<UserDTO, User>(user);
        //    await UnitOfWork.User.CreateAsync(userMapped);
        //}
        //public async Task<UserDTO> GetUserByIdAsync(int id)
        //{
        //    var result = await UnitOfWork.User.GetByIdAsync(id);
        //    var resultDTO = Mapper.Map<User, UserDTO>(result);
        //    return resultDTO;
        //}
        public async Task<IEnumerable<FriendshipDTO>> GetFriendshipsAsync()
        {
            var result = await UnitOfWork.Friendship.GetAllAsync();
            var resultDTOs = Mapper.Map<IEnumerable<Friendship>, IEnumerable<FriendshipDTO>>(result);
            return resultDTOs;
        }

        
        //public void UpdateUser(UserDTO userDTO)
        //{
        //    var user = Mapper.Map<UserDTO, User>(userDTO);
        //    UnitOfWork.User.Update(user);
        //}
        //public void DeleteUser(UserDTO user)
        //{
        //    var userMapped = Mapper.Map<UserDTO, User>(user);
        //    UnitOfWork.User.Remove(userMapped);
        //}
    }
}
