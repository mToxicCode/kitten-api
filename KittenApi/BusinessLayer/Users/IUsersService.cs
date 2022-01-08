using System.Threading;
using System.Threading.Tasks;
using KittenApi.Dtos.CreateUser;
using KittenApi.Dtos.GetUser;
using KittenApi.Dtos.GetUsers;

namespace KittenApi.BusinessLayer.Users
{
    public interface IUsersService
    {
        public Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken token);
        public Task<GetUsersResponse> GetUsersAsync(CancellationToken token);
        public Task<GetUserResponse> GetUserAsync(long id, CancellationToken token);
        public Task DeleteUserAsync(long id, CancellationToken token);
    }
}