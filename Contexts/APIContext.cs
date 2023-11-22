namespace API.Contexts;

using Microsoft.EntityFrameworkCore;


public class APIContext : DbContext
{
    public APIContext(DbContextOptions<APIContext> options) : base(options) { }
    public DbSet<Driver> Drivers { get; set; }

}