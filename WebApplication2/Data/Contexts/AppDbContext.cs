using Microsoft.EntityFrameworkCore;
using WebApplication2.Data.Entities;

namespace WebApplication2.Data.Contexts;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Doctor> Doctors { get; set; } = null!;
}
