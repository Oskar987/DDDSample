using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample.Infrastructure.Persistence.Configuration.Identity
{
    internal class UserTokensConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
            builder.ToTable("UserTokens");
            builder.HasKey(l => new { l.LoginProvider, l.UserId });
        }
    }
}
