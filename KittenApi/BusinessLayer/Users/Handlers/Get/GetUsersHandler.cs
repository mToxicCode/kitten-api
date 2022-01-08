using System.Threading;
using System.Threading.Tasks;
using KittenApi.BusinessLayer.Abstractions;
using KittenApi.Dtos.GetUsers;

namespace KittenApi.BusinessLayer.Users.Handlers.Get
{
    public class GetUsersHandler : IHandler<GetUsersResponse>
    {
        public async Task<GetUsersResponse> HandleAsync(CancellationToken token)
        {
            await Task.Delay(1, token);
            return new GetUsersResponse();
        }
    }
}