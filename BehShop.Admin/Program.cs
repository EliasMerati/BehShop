using BehShop.Application.Interfaces.Context;
using BehShop.Application.VisitorServices.GetTodayReport;
using BehShop.Infrastructure.IdentityConfigs;
using BehShop.Infrastructure.MappingProfile;
using BehShop.Persistance.Contexts.MongoDBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var services = builder.Services;
#region IOC
services.AddScoped<IGetTodayReportService, GetTodayReportService>();
services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
#endregion

#region AutoMapper
services.AddAutoMapper(typeof(CatalogMappingProfile));
#endregion

#region Services
services.AddIdentityServices(builder.Configuration);
services.AddAuthorization();
#endregion
var app = builder.Build();

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

