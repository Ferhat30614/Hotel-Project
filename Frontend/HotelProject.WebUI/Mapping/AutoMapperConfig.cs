﻿using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.ServiceDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig:Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();

            CreateMap<AppUser,CreateNewUserDto>().ReverseMap();
            CreateMap<AppUser, LoginUserDto>().ReverseMap();

            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

        }

    }
}
