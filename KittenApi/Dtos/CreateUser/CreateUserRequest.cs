using System;
using System.ComponentModel.DataAnnotations;

namespace KittenApi.Dtos.CreateUser
{
    public class CreateUserRequest
    {
        [Required] public string Username { get; set; } = null!;

        public string? Firstname { get; set; }

        public string? Middlename { get; set; }

        public string? Secondname { get; set; }

        public UserRoles Role { get; set; }

        public string? Description { get; set; }

        [Required] public DateTime DateOfBirth { get; set; }
    }
}