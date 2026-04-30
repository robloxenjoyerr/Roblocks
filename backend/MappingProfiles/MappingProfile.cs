using Roblocks.Models;
using Roblocks.Models.Dtos;
using AutoMapper;
using Roblocks.Database.Models;

namespace Roblocks.MappingProfiles;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<Game, GameDto>();
    }
}