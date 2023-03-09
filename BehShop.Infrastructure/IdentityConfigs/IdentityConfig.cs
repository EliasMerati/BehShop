using BehShop.Domain.Entities.User;
using BehShop.Persistance.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BehShop.Infrastructure.IdentityConfigs
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityDataBaseContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("BehShopConnectionString"));

                services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataBaseContext>()
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<CustomIdentityErrors>();

                services.Configure<IdentityOptions>(opt =>
                {
                    opt.Password.RequireDigit = false;
                    opt.Password.RequiredLength = 8;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequiredUniqueChars = 1;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                    opt.User.RequireUniqueEmail = true;
                    opt.Lockout.MaxFailedAccessAttempts = 5;
                    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                });


            });
            return services;
        }
    }
}
