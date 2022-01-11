using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KittenApi.BusinessLayer.Abstractions;
using KittenApi.DataLayer;
using KittenApi.DataLayer.Cmds.Users;
using KittenApi.Dtos.CreateUser;

namespace KittenApi.BusinessLayer.Users.Handlers.Create
{
    public class CreateUserHandler : IHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly UsersRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserHandler(UsersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> HandleAsync(CreateUserRequest request, CancellationToken token)
        {
            var result = await _repository.InsertNewUserAsync(_mapper.Map<InsertNewUserCmd>(request), token);
            return new CreateUserResponse { Id = result };
        }
    }
}