using AutoMapper;
using BLL.DTO;
using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure.AutomapperProfiles
{
    public class FriendshipAutomapperProfile : Profile
    {
        public FriendshipAutomapperProfile()
        {
            CreateMap<FriendshipDTO, Friendship>();
            CreateMap<Friendship, FriendshipDTO>();
        }
    }
}
