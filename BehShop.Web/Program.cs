using BehShop.Application.Interfaces.Context;
using BehShop.Application.VisitorServices.OnlineVisitor;
using BehShop.Application.VisitorServices.SaveVisitorInfo;
using BehShop.Common.Filters;
using BehShop.Domain.Entities.User;
using BehShop.Infrastructure.IdentityConfigs;
using BehShop.Persistance.Contexts;
using BehShop.Persistance.Contexts.MongoDBContext;
using BehShop.Web.Hubs;
using BehShop.Web.Middlwares;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    #region DataContext

    builder.Services.AddDbContext<DatabaseContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("BehShopConnectionString"));

    });
    #endregion

    #region Services
    builder.Services.AddIdentityServices(builder.Configuration);
    builder.Services.AddAuthorization();
    builder.Services.ConfigureApplicationCookie(opt =>
    {
        opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
        opt.LoginPath = "/Account/Login";
        opt.AccessDeniedPath = "/Account/AccessDenied";
        opt.SlidingExpiration = true;
    });
    #endregion

    #region IOC
    builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
    builder.Services.AddTransient<ISaveVisitorInfoService, SaveVisitorInfoService>();
    builder.Services.AddTransient<IOnlineVisitorService, OnlineVisitorService>();
    builder.Services.AddScoped<ServiceVisitorFilter>();
    builder.Services.AddSignalR();
    #endregion

}


#region Middlewares

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    app.UseSetVisitorId();
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

    app.MapHub<SignalROnlineVisitorsHub>("/ChatHub");
}
app.Run();
#endregion


