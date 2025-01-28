using AutoMapper;
using poc.Mapper.Dtos;

namespace poc.Mapper.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Entities.Customer, CustomerDto>()
            .ForMember(
                dest => dest.Name, 
                opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.Email, 
                opt => opt.MapFrom(src => src.Email))
            .ForMember(
                dest => dest.Type, 
                opt => opt.MapFrom(src => src.Type))
            .ForMember(
                dest => dest.Phone, 
                opt => opt.MapFrom(src => src.Phone));
    }
}