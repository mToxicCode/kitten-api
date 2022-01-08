using System.Threading;
using System.Threading.Tasks;
using KittenApi.BusinessLayer.Abstractions;
using KittenApi.Dtos.GetUser;

namespace KittenApi.BusinessLayer.Users.Handlers.Get
{
    public class GetUserHandler : IHandler<long, GetUserResponse>
    {
        public async Task<GetUserResponse> HandleAsync(long request, CancellationToken token)
        {
            await Task.Delay(1, token);
            return new GetUserResponse();
        }
    }
}