using Microsoft.EntityFrameworkCore;
using ShippingTracking.Infrastructure.Models;

namespace ShippingTracking.Infrastructure;

public class ShippingTrackingDbContext : DbContext
{
    public ShippingTrackingDbContext(DbContextOptions<ShippingTrackingDbContext> options)
        : base(options) { }

    public DbSet<CustomerDbModel> Customers { get; set; }
}
