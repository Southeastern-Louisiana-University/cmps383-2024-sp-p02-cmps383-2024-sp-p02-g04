using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

public class CustomRole : IdentityRole<int>
{
    public ICollection<UserRole> Users { get; set; }
}
