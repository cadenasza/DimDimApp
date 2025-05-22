using cp3.Model;
using Microsoft.EntityFrameworkCore;

namespace cp3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Carros> Carros { get; set; }
    }
}