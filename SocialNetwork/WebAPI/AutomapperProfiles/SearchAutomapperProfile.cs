using AutoMapper;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.AutomapperProfiles
{
    public class SearchAutomapperProfile : Profile
    {
        public SearchAutomapperProfile()
        {
            CreateMap<SearchDTO, SearchModel>();
            CreateMap<SearchModel, SearchDTO>();
        }
    }
}