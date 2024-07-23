using Jobify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jobify.Domain.DataSeed;

public static class JobifySeed
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Industry>().HasData(
            new Industry
            {
                Id = 1,
                Name = "Business Development",
                Code = "business",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 2,
                Name = "Copywriting &amp; Content",
                Code = "copywriting",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 3,
                Name = "Customer Success",
                Code = "supporting",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 4,
                Name = "Technical Support",
                Code = "technical-support",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 5,
                Name = "Data Science",
                Code = "data-science",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 6,
                Name = "Design &amp; Creative",
                Code = "design-multimedia",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 7,
                Name = "Web &amp; App Design",
                Code = "web-app-design",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 8,
                Name = "DevOps &amp; SysAdmin",
                Code = "admin",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 9,
                Name = "Software Engineering",
                Code = "engineering",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 10,
                Name = "Finance &amp; Legal",
                Code = "accounting-finance",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 11,
                Name = "HR &amp; Recruiting",
                Code = "hr",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 12,
                Name = "Sales",
                Code = "marketing",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 13,
                Name = "Sales",
                Code = "seller",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 14,
                Name = "SEO",
                Code = "seo",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 15,
                Name = "Social Media Marketing",
                Code = "smm",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 16,
                Name = "Product &amp; Operations",
                Code = "management",
                CreatedAt = DateTime.UtcNow
            },
            new Industry
            {
                Id = 17,
                Name = "Programming",
                Code = "dev",
                CreatedAt = DateTime.UtcNow
            });
    }
}