using System.Threading;
using System.Threading.Tasks;
using KittenApi.BusinessLayer.Users.Handlers;
using KittenApi.Dtos.CreateUser;
using KittenApi.Dtos.GetUser;
using KittenApi.Dtos.GetUsers;

namespace KittenApi.BusinessLayer.Users
{
    public class UsersServiceResolver : IUsersService
    {
        private readonly UsersHandlersProvider _provider;

        public UsersServiceResolver(UsersHandlersProvider provider)
            => _provider = provider;


        public Task<GetUsersResponse> GetUsersAsync(CancellationToken token)
            => _provider.GetUsersHandler.HandleAsync(token);

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken token)
            => await _provider.CreateUserHandler.HandleAsync(request, token);

        public async Task<GetUserResponse> GetUserAsync(long id, CancellationToken token)
            => await _provider.GetUserHandler.HandleAsync(id, token);

        public async Task DeleteUserAsync(long id,CancellationToken token)
            => await _provider.DeleteUserHandler.HandleAsync(id, token);
    }
}