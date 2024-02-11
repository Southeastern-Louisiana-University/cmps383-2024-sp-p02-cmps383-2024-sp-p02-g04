using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

public class Role : IdentityRole<int>
{
    public ICollection<UserRole> Users { get; set; } = new List<UserRole>();
}

//Setting Role names 
public class Roles
{
    public const string Admin = nameof(Admin);

    public const string User = nameof(User);
}