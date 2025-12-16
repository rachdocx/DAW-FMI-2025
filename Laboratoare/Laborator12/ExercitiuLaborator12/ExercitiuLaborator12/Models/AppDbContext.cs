using Microsoft.EntityFrameworkCore;

namespace ExercitiuLaborator12.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Gym> Gym { get; set; }
        public DbSet<Membership> Membership { get; set; }
    }
}
