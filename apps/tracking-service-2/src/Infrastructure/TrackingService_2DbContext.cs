using Microsoft.EntityFrameworkCore;
using TrackingService_2.Infrastructure.Models;

namespace TrackingService_2.Infrastructure;

public class TrackingService_2DbContext : DbContext
{
    public TrackingService_2DbContext(DbContextOptions<TrackingService_2DbContext> options)
        : base(options) { }

    public DbSet<CustomerDbModel> Customers { get; set; }

    public DbSet<TrackingDbModel> Trackings { get; set; }
}
