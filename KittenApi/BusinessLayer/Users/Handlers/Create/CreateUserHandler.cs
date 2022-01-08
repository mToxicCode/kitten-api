using System.Threading;
using System.Threading.Tasks;
using KittenApi.BusinessLayer.Abstractions;
using KittenApi.Dtos.CreateUser;

namespace KittenApi.BusinessLayer.Users.Handlers.Create
{
    public class CreateUserHandler : IHandler<CreateUserRequest, CreateUserResponse>
    {
        public async Task<CreateUserResponse> HandleAsync(CreateUserRequest request, CancellationToken token)
        {
            await Task.Delay(1, token);
            return new CreateUserResponse(){Id = 17};
        }
    }
}