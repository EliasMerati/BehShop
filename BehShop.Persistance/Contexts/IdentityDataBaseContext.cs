using BehShop.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BehShop.Persistance.Contexts
{
    public class IdentityDataBaseContext : IdentityDbContext<User>
    {
        public IdentityDataBaseContext(DbContextOptions<IdentityDataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUser<string>>().ToTable("Users", "Identity");
            builder.Entity<IdentityRole<string>>().ToTable("Roles", "Identity");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Identity");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Identity");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Identity");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Identity");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Identity");

            builder.Entity<IdentityUserLogin<string>>()
                .HasKey(p => new { p.LoginProvider, p.ProviderKey });
            builder.Entity<IdentityUserRole<string>>()
                .HasKey(p => new { p.RoleId, p.UserId });
            builder.Entity<IdentityUserToken<string>>()
                .HasKey(p => new { p.LoginProvider, p.Name, p.UserId });
            //base.OnModelCreating(builder);
        }
    }
}
