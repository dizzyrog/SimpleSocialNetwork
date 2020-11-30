using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Domain;
using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var result = new List<UserDTO>();
            var users = await _userService.GetUsersAsync();
            if (searchDTO.Name != null)
            {
                var nameToSearch = searchDTO.Name.Split(" ");
                result = users.Where(x => x.FirstName == nameToSearch[0] || x.LastName == nameToSearch[0]).ToList();
            }
            if (searchDTO.Country !=null)
            {
                var res = new List<UserDTO>();
                res = users.Where(x => x.Country == searchDTO.Country).ToList();
                foreach (var item in res)
                {
                    result.Add(item);
                }
            }
            if (searchDTO.City != null)
            {
                var res = new List<UserDTO>();
                res = users.Where(x => x.City == searchDTO.City).ToList();
                foreach (var item in res)
                {
                    result.Add(item);
                }
            }
            if (searchDTO.University != null)
            {
                var res = new List<UserDTO>();
                res = users.Where(x => x.University == searchDTO.University).ToList();
                foreach (var item in res)
                {
                    result.Add(item);
                }
            }
            if (searchDTO.Email != null)
            {
                var res = new List<UserDTO>();
                res = users.Where(x => x.Email == searchDTO.Email).ToList();
                foreach (var item in res)
                {
                    result.Add(item);
                }
            }
            if (searchDTO.AgeMin != 0 && searchDTO.AgeMax != 0)
            {
                var res = new List<UserDTO>();
                res = users.Where(x => ( x.Age > searchDTO.AgeMin && x.Age < searchDTO.AgeMax)).ToList();
                foreach (var item in res)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public async Task<IEnumerable<UserDTO>> GetFriendsByUserIdAsync(string userId)
        {
            //var user = await _userService.GetUserByIdAsync(userId);
            var friends = new List<UserDTO>();
            var friendships = await GetFriendshipsAsync();
            var selectedFriendships = friendships.Where(t => t.UserId == userId);
            foreach (var item in selectedFriendships)
            {
                friends.Add(await _userService.GetByIdAsync(item.FriendId));
            }
            return friends;
        }
        public async Task AddFriendshipAsync(UserDTO friend, string userId)
        {
            //var user = _userService.GetUserByIdAsync(userId);
            var friendship = new Friendship()
            {
                UserId = userId,
                FriendId = friend.Id
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
