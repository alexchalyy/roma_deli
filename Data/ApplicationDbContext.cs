using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AuthApp.Models;

/*

The provided code defines a class named ApplicationDbContext that inherits from IdentityDbContext<ApplicationUser>. This class is part of an ASP.NET Core application and is used to manage the database context for the application, specifically for handling user authentication and authorization using ASP.NET Core Identity. By inheriting from IdentityDbContext<ApplicationUser>, the ApplicationDbContext class gains all the necessary functionality to interact with the database for identity-related operations.

The constructor of the ApplicationDbContext class takes a parameter of type DbContextOptions<ApplicationDbContext> and passes it to the base class constructor. This parameter is used to configure the database context, such as specifying the database provider and connection string.

The OnModelCreating method is overridden to customize the model creation process. This method is called when the model for the context is being created. In this implementation, the base class's OnModelCreating method is called to ensure that the default behavior is preserved. This method can be further customized to configure additional aspects of the model, such as defining relationships between entities or configuring entity properties.

The ApplicationDbContext class is referenced in several other files within the project. For example, in the 20241231154511_InitialCreate.Designer.cs and 20250114162303_AddCityStateZipCode.Designer.cs files, the ApplicationDbContext class is used to define the structure of the database schema during migrations. These files contain code that specifies how the database tables should be created and modified, including the creation of tables for user roles, user claims, and user logins.

In the Program.cs file, the ApplicationDbContext class is configured as part of the ASP.NET Core application's setup. The WebApplicationBuilder instance is created using the WebApplication.CreateBuilder(args) method, which sets up the configuration, logging, and dependency injection container for the application. The builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); line adds the ApplicationDbContext to the service container and configures it to use SQL Server as the database provider, with the connection string specified in the application's configuration.

Additionally, the builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders(); line configures ASP.NET Core Identity to use the ApplicationDbContext for storing identity data in the database. This setup enables user authentication and authorization within the application.

Overall, the ApplicationDbContext class plays a crucial role in managing the database context for the ASP.NET Core application, providing the necessary functionality for user authentication and authorization using ASP.NET Core Identity. The class is referenced in various parts of the project to configure and manage the database schema and to set up the application's services and middleware.

Written by Alex Chalyy on 2/14/2025.

*/

namespace AuthApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}