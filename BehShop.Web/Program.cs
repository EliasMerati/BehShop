using BehShop.Domain.Entities.User;
using BehShop.Infrastructure.IdentityConfigs;
using BehShop.Persistance.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.
services.AddControllersWithViews();
#region DataContext

services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BehShopConnectionString"));

});
#endregion

#region Services
services.AddIdentityServices(builder.Configuration);
services.AddAuthorization();
services.ConfigureApplicationCookie(opt =>
{
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    opt.LoginPath = "/Account/Login";
    opt.AccessDeniedPath = "/Account/AccessDenied";
    opt.SlidingExpiration = true;
});
#endregion

#region Add Identity
services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDataBaseContext>()
    .AddDefaultTokenProviders();
#endregion

#region Middlewares
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
       name: "areas",
       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
#endregion


