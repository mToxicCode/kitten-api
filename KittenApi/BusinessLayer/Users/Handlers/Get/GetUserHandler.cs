using System.Threading;
using System.Threading.Tasks;
using KittenApi.BusinessLayer.Abstractions;
using KittenApi.DataLayer;
using KittenApi.DataLayer.Cmds.Users;
using KittenApi.Dtos.GetUser;

namespace KittenApi.BusinessLayer.Users.Handlers.Get
{
    public class GetUserHandler : IHandler<long, GetUserResponse>
    {
        private readonly UsersRepository _repository;

        public GetUserHandler(UsersRepository repository)
            => _repository = repository;

        public async Task<GetUserResponse> HandleAsync(long request, CancellationToken token)
        {
            var result = await _repository.GetUserByIdAsync(new GetUserCmd(request), token);
            return new GetUserResponse(result);
        }
    }
}