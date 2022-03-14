using AutoMapper;
using UsersApi.Core.Entity;
using UsersApi.Core.Models.V1.Requests;

namespace UsersApi.MappingProfiles;

public class RequestToEntityProfile : Profile
{
    public RequestToEntityProfile()
    {
        CreateMap<UserRequest, User>();
    }
}