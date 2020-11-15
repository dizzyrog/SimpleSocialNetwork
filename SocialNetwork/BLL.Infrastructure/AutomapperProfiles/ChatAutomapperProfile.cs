﻿using AutoMapper;
using BLL.DTO;
using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure.AutomapperProfiles
{
    public class ChatAutomapperProfile : Profile
    {
        public ChatAutomapperProfile()
        {
            CreateMap<ChatDTO, Chat>();
            CreateMap<Chat, ChatDTO>();
        }
    }
}
