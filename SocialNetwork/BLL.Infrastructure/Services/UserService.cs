using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Domain;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        public async Task AddUser(UserDTO user)
        {
            var userMapped = Mapper.Map<UserDTO, User>(user);
            await UnitOfWork.User.CreateAsync(userMapped);
        }
        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var result = await UnitOfWork.User.GetByIdAsync(id);
            var resultDTO = Mapper.Map<User, UserDTO>(result);
            return resultDTO;
        }
        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var result = await UnitOfWork.User.GetAllAsync();
            var resultDTOs = Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(result);
            return resultDTOs;
        }
        public void UpdateUser(UserDTO userDTO)
        {
            var user = Mapper.Map<UserDTO, User>(userDTO);
            UnitOfWork.User.Update(user);
            //var oldUser = new User
            //{
            //    Id = userDTO.Id,
                //Email = userDTO.Email,
                //UserName = userDTO.UserName,
                //FirstName = userDTO.FirstName,
                //LastName = userDTO.LastName,
                //PhoneNumber = userDTO.PhoneNumber,
                //City = userDTO.City,
                //Country = userDTO.Country,
                //University = userDTO.University,
                //AboutMe = userDTO.AboutMe,
                //Age = userDTO.Age,
                //Friendships = (ICollection<Friendship>)userDTO.Friendships,
                //Messages = (ICollection<Message>)userDTO.Messages,
            //};
            //UnitOfWork.User.Remove(oldUser);
            //await UnitOfWork.User.CreateAsync(user);
        }
        public void DeleteUser(UserDTO user)
        {
            var userMapped = Mapper.Map<UserDTO, User>(user);
            UnitOfWork.User.Remove(userMapped);
        }
    }
}
