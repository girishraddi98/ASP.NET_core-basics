using AutoMapper;
using ExcelToDatabaseAPI.DTO;
using ExcelToDatabaseAPI.Models;

namespace ExcelToDatabaseAPI.profiles
{
    public class TabProfile : Profile
    {
        public TabProfile()
        {
            CreateMap<tab, TabDto>().ReverseMap();
        }

    }
}
