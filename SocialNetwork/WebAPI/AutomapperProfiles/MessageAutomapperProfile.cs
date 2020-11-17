using AutoMapper;
using BLL.DTO;
using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure.AutomapperProfiles
{
    public class MessageAutomapperProfile : Profile
    {
        //todo fix me to the  api model
        public MessageAutomapperProfile()
        {
            CreateMap<MessageDTO, Message>();
            CreateMap<Message, MessageDTO>();
        }
    }
}
