using System;
using KittenApi.Dtos;

namespace KittenApi.DataLayer.Cmds.Users;

public class InsertNewUserCmd
{
    public string Username { get; set; } = null!;

    public string? Firstname { get; set; }

    public string? Middlename { get; set; }

    public string? Secondname { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? Description { get; set; }

    public UserRoles Role { get; set; }
}