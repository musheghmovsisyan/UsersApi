using AutoMapper;
using UsersApi.Core.Entity;
using UsersApi.Core.Models.V1.Responses;

namespace UsersApi.MappingProfiles;

public class EntityToResponseProfile : Profile
{
    public EntityToResponseProfile()
    {
        CreateMap<User, UserResponse>();
    }
}