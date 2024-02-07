using Microsoft.AspNetCore.Identity;

public class UserRole : IdentityUserRole<int>
{
    public CustomRole Role { get; set; }

    public CustomUser User { get; set; }
}

