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
        public async Task<UserDTO> GetUserByIdAsync(string id)
        {
            var result = await UnitOfWork.User.GetUserByIdAsync(id);
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
            UnitOfWork.User.UpdateUser(user);
        }
        public void UpdateIdentityId(UserDTO userDTO)
        {
            var userMapped = Mapper.Map<UserDTO, User>(userDTO);
            UnitOfWork.User.UpdateIdentityId(userMapped);

            //var propertiesNew = userDTO.GetType().GetProperties().Where(p => p.PropertyType == typeof(string) && p.CanRead).Select(p => p.GetValue(userDTO));
          
            //if (properties.All(value => !string.IsNullOrEmpty(value)))
                //context.Entry(user).Property(e => e.).IsModified = true;
            //context.Entry(user).Collection(e => e.Images).IsModified = true;

        }
        public void DeleteUser(UserDTO user)
        {
            var userMapped = Mapper.Map<UserDTO, User>(user);
            UnitOfWork.User.Remove(userMapped);
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var result = await UnitOfWork.User.GetByIdAsync(id); 
            var resultDTO = Mapper.Map<User, UserDTO>(result);
            return resultDTO;
        }
    }
}
