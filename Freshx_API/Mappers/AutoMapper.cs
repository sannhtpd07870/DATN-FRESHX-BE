using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Models;

namespace Freshx_API.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Savefile, FileDto>().ReverseMap();
        }
    }
}
    