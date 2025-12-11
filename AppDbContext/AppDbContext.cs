using Microsoft.EntityFrameworkCore;
using todoApiDotNet.Models;

namespace todoApiDotNet.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Todo> Todos => Set<Todo>();
}
