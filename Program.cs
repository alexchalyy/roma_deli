/*

The provided code is part of an ASP.NET Core application setup, specifically focusing on configuring services and middleware for the application. The code begins by creating a WebApplicationBuilder instance using the WebApplication.CreateBuilder(args) method. This builder is used to configure and build the web application.

The builder.Services.AddControllersWithViews() line adds support for MVC controllers with views to the service container, enabling the application to handle HTTP requests and return HTML views.

Next, the code configures the database context by adding ApplicationDbContext to the service container with builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));. This line sets up Entity Framework Core to use SQL Server as the database provider, with the connection string specified in the application's configuration.

The code then configures ASP.NET Core Identity by adding ApplicationUser and IdentityRole to the service container with builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();. This setup enables user authentication and authorization, using Entity Framework Core to store identity data in the database.

Finally, the code configures the application cookie settings with builder.Services.ConfigureApplicationCookie(options => { options.LoginPath = "/Account/Login"; options.AccessDeniedPath = "/Account/AccessDenied"; });. This specifies the paths for the login and access denied pages, which are used when a user needs to authenticate or is denied access to a resource.

Overall, this code sets up essential services and configurations for an ASP.NET Core application, including MVC, Entity Framework Core, and Identity, ensuring the application is ready to handle user authentication, database interactions, and HTTP requests.

Written by Alex Chalyy on 2/13/2025.

*/

using Microsoft.EntityFrameworkCore;
using AuthApp.Data;
using Microsoft.AspNetCore.Identity;
using AuthApp.Models;

// Create a builder for the web application, which sets up the configuration, logging, and dependency injection container.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configure the application cookie settings for authentication
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Configure authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
