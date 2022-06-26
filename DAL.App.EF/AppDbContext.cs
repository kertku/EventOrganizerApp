using Domain.App;
using Domain.App.Validators;
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
}