using DDDSample.Infrastructure.Models;

namespace DDDSample.Infrastructure.Auth.Abstractions
{
	public interface IJWTGenerator
	{
        string CreateToken(ApplicationUser user);
    }
}

