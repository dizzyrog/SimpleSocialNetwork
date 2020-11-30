using AutoMapper;
using BLL.DTO;
using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Models;

namespace BLL.Infrastructure.AutomapperProfiles
{
    public class MessageAutomapperProfile : Profile
    {
        public MessageAutomapperProfile()
        {
            CreateMap<MessageDTO, Message>();
            CreateMap<Message, MessageDTO>();
            CreateMap<MessageDTO, MessageModel>();
            CreateMap<MessageModel, MessageDTO>()
                .ForMember(x => x.MessageText, opt => opt.MapFrom(m => m.MessageText))
                .ForMember(x => x.TimeSent, opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(x => x.User1Username, opt => opt.MapFrom(m => m.User1))
                .ForMember(x => x.User2Username, opt => opt.MapFrom(m => m.User2));
        }
    }
}
