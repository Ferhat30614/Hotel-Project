using AutoMapper;
using HotelProject.EntityLayer.Concrete;
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
        }

    }
}
