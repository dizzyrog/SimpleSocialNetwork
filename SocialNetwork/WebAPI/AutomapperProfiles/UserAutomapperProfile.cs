using AutoMapper;
using BLL.DTO;
using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Models;

namespace BLL.Infrastructure.AutomapperProfiles
{
   public class UserAutomapperProfile : Profile
    {
        public UserAutomapperProfile()
        {
            CreateMap<UserDTO, UserModel>();
            CreateMap<UserModel, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
