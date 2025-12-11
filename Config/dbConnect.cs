using Microsoft.EntityFrameworkCore;
using todoApiDotNet.Data;

namespace todoApiDotNet.Config;

public static class DbConnect
{
    // Register PostgreSQL database connection
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var host = Environment.GetEnvironmentVariable("DB_HOST");
        var port = Environment.GetEnvironmentVariable("DB_PORT");
        var database = Environment.GetEnvironmentVariable("DB_NAME");
        var username = Environment.GetEnvironmentVariable("DB_USER");
        var password = Environment.GetEnvironmentVariable("DB_PASS");

        var connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));
    }

    // Test database connection
    public static void TestDatabaseConnection(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<AppDbContext>>();

            try
            {
                db.Database.OpenConnection();
                db.Database.CloseConnection();
                logger.LogInformation("Database connection successful.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Database connection failed.");
            }
        }
    }
}