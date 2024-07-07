using DataGen.Models;
using Microsoft.EntityFrameworkCore;

namespace DataGen;

public class AfghanContext(DbContextOptions<AfghanContext> options) : DbContext(options)
{
    public DbSet<Afghan> Afghans { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<MilitaryPersonnel> MilitaryPersonnel { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<AfghansInGroups> AfghansInGroups { get; set; }
    public DbSet<Encounter> Encounters { get; set; }
}