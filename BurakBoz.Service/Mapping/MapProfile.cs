using AutoMapper;
using BurakBoz.Core.DTOs;
using BurakBoz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Blog,BlogDto>().ReverseMap();
            CreateMap<MainCategory, MainCategoryDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<Static, StaticDto>().ReverseMap();
            CreateMap<MainCategoryWithFileDto, MainCategory>().ReverseMap();
        }
    }
}

