using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample.Infrastructure.Persistence.Configuration.Identity
{
    internal class UserLoginsConfiguration : IEntityTypeConfiguration<IdentityUserLogin<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder.ToTable("UserLogins");
            builder.HasKey(l => new { l.LoginProvider, l.ProviderKey });
        }
    }
}

