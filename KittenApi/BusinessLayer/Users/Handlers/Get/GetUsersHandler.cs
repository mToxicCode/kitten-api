using System.Threading;
using System.Threading.Tasks;
using KittenApi.BusinessLayer.Abstractions;
using KittenApi.DataLayer;
using KittenApi.Dtos.GetUsers;

namespace KittenApi.BusinessLayer.Users.Handlers.Get
{
    public class GetUsersHandler : IHandler<GetUsersResponse>
    {
        private readonly UsersRepository _repository;

        public GetUsersHandler(UsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetUsersResponse> HandleAsync(CancellationToken token)
        {
            var result = await _repository.GetUsers(token);
            return new GetUsersResponse(result);
        }
    }
}