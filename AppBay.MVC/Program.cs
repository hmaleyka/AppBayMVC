using AppBay.Business.Services.Implementations;
using AppBay.Business.Services.Interfaces;
using AppBay.DAL.Context;
using AppBay.DAL.Repositories.Implementations;
using AppBay.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.Configure<IdentityOptions>(options =>
{

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Password.RequireLowercase = true;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
});

builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<IFeatureService , FeatureService>();
builder.Services.AddScoped<IAccountService, AccountService>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
