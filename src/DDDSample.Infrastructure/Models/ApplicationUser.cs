using Microsoft.AspNetCore.Identity;

namespace DDDSample.Infrastructure.Models
{
	public class ApplicationUser : IdentityUser
	{
        public string DisplayName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<ApplicationUserRole> Roles { get; } = new List<ApplicationUserRole>();
    }

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}

