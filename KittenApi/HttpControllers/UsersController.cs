using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using KittenApi.Dtos.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace KittenApi.HttpControllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("/api/v1/users")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            return Ok();
        }
        
        [HttpGet("/api/v1/users")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok();
        }
        
        [HttpGet("/api/v1/users/{id:int}")]
        public async Task<IActionResult> GetUser([Required]int id)
        {
            return Ok();
        }
        
        [HttpDelete("/api/v1/users/{id:int}")]
        public async Task<IActionResult> DeleteUser([Required]int id)
        {
            return Ok();
        }
    }
}