using Jobify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jobify.Domain.Contexts;

public class JobifyContext(
    DbContextOptions<JobifyContext> options) : DbContext(options)
{
    public DbSet<Job> Jobs { get; set; }
    public DbSet<JobType> JobTypes { get; set; }
}