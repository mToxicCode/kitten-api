using System.Collections.Generic;

namespace KittenApi.Dtos.GetUsers;

public record GetUsersResponse(IEnumerable<User> Users);