using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Division> Divisions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.CreatedAt).ValueGeneratedOnAdd();
            entity.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate();
            entity.HasMany<Company>(e => e.Companies);
        });
        
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(company => company.Id);
            entity.Property(company => company.Name).IsRequired();
            entity.Property(company => company.NumberOfProperties).HasDefaultValue(0);
            entity.Property(company => company.NumberOfNotListedUnits).HasDefaultValue(0);
            entity.Property(company => company.NumberOfAvailableUnits).HasDefaultValue(0);
            entity.Property(company => company.NumberOfInProgressUnits).HasDefaultValue(0);
            entity.Property(company => company.NumberOfActiveUnits).HasDefaultValue(0);
            entity.Property(company => company.DivisionId).IsRequired();
            entity.Property(e => e.CreatedAt).ValueGeneratedOnAdd();
            entity.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate();
            entity.HasOne<Division>(company => company.Division)
                .WithMany(division => division.Companies);
        });
    }
}