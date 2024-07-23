using Jobify.Domain.DataSeed;
using Jobify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jobify.Domain.Contexts;

public class JobifyContext(
    DbContextOptions<JobifyContext> options) : DbContext(options)
{
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Industry> Industries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        JobifySeed.SeedData(modelBuilder);
    }
}