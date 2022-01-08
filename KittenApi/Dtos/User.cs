using System;

namespace KittenApi.Dtos
{
    public class User
    {
        public long Id { get; set; }
        
        public string Username { get; set; } = null!;
        
        public string? Firstname { get; set; }
        
        public string? Middlename { get; set; }
        
        public string? Secondname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Description { get; set; }

        public UserRoles Role { get; set; }
    }
}