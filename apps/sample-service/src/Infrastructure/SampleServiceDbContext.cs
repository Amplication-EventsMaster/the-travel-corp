using Microsoft.EntityFrameworkCore;
using SampleService.Infrastructure.Models;

namespace SampleService.Infrastructure;

public class SampleServiceDbContext : DbContext
{
    public SampleServiceDbContext(DbContextOptions<SampleServiceDbContext> options)
        : base(options) { }

    public DbSet<CustomerDbModel> Customers { get; set; }

    public DbSet<LocationDbModel> Locations { get; set; }

    public DbSet<OrderDbModel> Orders { get; set; }

    public DbSet<PaymentDbModel> Payments { get; set; }

    public DbSet<FeedbackDbModel> Feedbacks { get; set; }
}
