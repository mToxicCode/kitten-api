using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using KittenApi.BusinessLayer.Users;
using KittenApi.Dtos.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace KittenApi.HttpControllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _resolver;
        private readonly HttpCancellationTokenAccessor _accessor;

        public UsersController(IUsersService resolver, HttpCancellationTokenAccessor accessor)
        {
            _resolver = resolver;
            _accessor = accessor;
        }

        [HttpGet("/api/v1/users/{id:long}")]
        public async Task<IActionResult> GetUser([Required] long id)
            => Ok(await _resolver.GetUserAsync(id, _accessor.Token));

        [HttpGet("/api/v1/users")]
        public async Task<IActionResult> GetUsers()
            => Ok(await _resolver.GetUsersAsync(_accessor.Token));
        
        [HttpPost("/api/v1/users")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
            => Ok(await _resolver.CreateUserAsync(request, _accessor.Token));
        
        [HttpDelete("/api/v1/users/{id:long}")]
        public async Task<IActionResult> DeleteUser([Required] long id)
        {
            await _resolver.DeleteUserAsync(id, _accessor.Token);
            return Ok();
        }
    }
}