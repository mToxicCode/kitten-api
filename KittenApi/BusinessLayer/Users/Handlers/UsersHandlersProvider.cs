using JetBrains.Annotations;
using KittenApi.BusinessLayer.Abstractions;
using KittenApi.Dtos;
using KittenApi.Dtos.CreateUser;
using KittenApi.Dtos.GetUser;
using KittenApi.Dtos.GetUsers;

namespace KittenApi.BusinessLayer.Users.Handlers
{
    [UsedImplicitly]
    public class UsersHandlersProvider
    {
        public UsersHandlersProvider(
            IHandler<CreateUserRequest, CreateUserResponse> createUserHandler,
            IHandler<long, GetUserResponse> getUserHandler,
            IHandler<GetUsersResponse> getUsersHandler, 
            IHandler<long, Empty> deleteUserHandler)
        {
            CreateUserHandler = createUserHandler;
            GetUserHandler = getUserHandler;
            GetUsersHandler = getUsersHandler;
            DeleteUserHandler = deleteUserHandler;
        }
        public IHandler<CreateUserRequest, CreateUserResponse> CreateUserHandler { get; }
        public IHandler<GetUsersResponse> GetUsersHandler { get; }
        public IHandler<long, GetUserResponse> GetUserHandler { get; }
        public IHandler<long, Empty> DeleteUserHandler { get; }
    }
}