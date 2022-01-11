using AutoMapper;
using KittenApi.DataLayer.Cmds.Users;
using KittenApi.Dtos.CreateUser;

namespace KittenApi.Infrastructure.Profiles;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<CreateUserRequest, InsertNewUserCmd>();
    }
}