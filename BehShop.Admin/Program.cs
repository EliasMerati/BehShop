using BehShop.Infrastructure.IdentityConfigs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
var services = builder.Services;

#region Services
//services.AddIdentityServices(builder.Configuration);
//services.AddAuthorization();
//services.ConfigureApplicationCookie(opt =>
//{
//    opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
//    opt.LoginPath = "/Account/Login";
//    opt.AccessDeniedPath = "/Account/AccessDenied";
//    opt.SlidingExpiration = true;
//});
#endregion

#region Middlewares
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
#endregion

