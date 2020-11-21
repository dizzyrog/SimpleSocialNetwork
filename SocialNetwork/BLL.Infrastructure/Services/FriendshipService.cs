using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Domain;
using DAL.EF;
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

        public async Task<IEnumerable<UserDTO>> SearchFriendsAsync(SearchDTO searchDTO)
        {
            var users = await _userService.GetUsersAsync();
            //if (searchDTO.Name != null)
            
                var k = searchDTO.Name.Split(" ");
                var a = users.Where(x => x.FirstName == k[0] || x.LastName == k[0]);
            
            return a;
        }
        public async Task<IEnumerable<UserDTO>> GetFriendsByUserIdAsync(string userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            var friends = new List<UserDTO>();
            var friendships = await GetFriendshipsAsync();
            var selectedFriendships = friendships.Where(t => t.UserId == user.Id);
            foreach (var item in selectedFriendships)
            {
                friends.Add(await _userService.GetByIdAsync(item.FriendId));
            }
            return friends;
        }
        public async Task AddFriendshipAsync(UserDTO friend, string userId)
        {
            var user = _userService.GetUserByIdAsync(userId);
            var friendship = new Friendship()
            {
                UserId = user.Id,
                FriendId = friend.Id,
                ChatId = 2,
            };
            await UnitOfWork.Friendship.CreateAsync(friendship);
        }
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

    }
}
