using System.Threading;
using System.Threading.Tasks;
using KittenApi.BusinessLayer.Abstractions;
using KittenApi.Dtos;

namespace KittenApi.BusinessLayer.Users.Handlers.Delete
{
    public class DeleteUserHandler : IHandler<long, Empty>
    {
        public async Task<Empty> HandleAsync(long request, CancellationToken token)
        {
            await Task.Delay(1, token);
            return new Empty();
        }
    }
}