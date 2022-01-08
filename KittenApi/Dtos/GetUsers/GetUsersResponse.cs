using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KittenApi.Dtos.GetUsers
{
    public class GetUsersResponse
    {
        public List<User> Users { get; set; } = new();
    }
}