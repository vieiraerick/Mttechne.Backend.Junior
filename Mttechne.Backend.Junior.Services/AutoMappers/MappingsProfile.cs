using AutoMapper;
using Mttechne.Backend.Junior.Domain.Model;
using Mttechne.Backend.Junior.Services.Services.DTO;

namespace Mttechne.Backend.Junior.Services.AutoMappers;

public class MappingsProfile : Profile
{
    public MappingsProfile()
    {
        this.CreateMap<UserLogin, User>().ReverseMap();
    }
}
