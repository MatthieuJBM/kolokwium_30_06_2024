using Microsoft.EntityFrameworkCore;

namespace Kolokwium_30_06_2024_w66049.Data;

public class KolokwiumDbContext : DbContext
{
    public KolokwiumDbContext(DbContextOptions options) : base(options)
    {
    }

    // public DbSet<Entity> Entitys { get; set; }
    public DbSet<Mecz> Meczs { get; set; }
    public DbSet<DruzynaPilkarska> DruzynaPilkarskas { get; set; }
}