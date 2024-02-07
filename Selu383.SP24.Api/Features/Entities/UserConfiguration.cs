using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

public class User : IdentityUser<int>
{
    public ICollection<UserRole> Roles { get; set; }
}