using DAL.App.EF.SeedData;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<BusinessUser> BusinessUsers { get; set; } = default!;
    public DbSet<Event> Events { get; set; } = default!;
    public DbSet<IndividualUser> IndividualUsers { get; set; } = default!;
    public DbSet<Participation> Participations { get; set; } = default!;
    public DbSet<PaymentType> PaymentTypes { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Seed();

        modelBuilder.Entity<PaymentType>()
            .HasMany(p => p.Participations)
            .WithOne(pa => pa.PaymentType).HasForeignKey(p => p.PaymentTypeId).OnDelete(DeleteBehavior.NoAction);
    }
}