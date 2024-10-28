using Microsoft.EntityFrameworkCore;

namespace ShippingTracking.Infrastructure;

public class ShippingTrackingDbContext : DbContext
{
    public ShippingTrackingDbContext(DbContextOptions<ShippingTrackingDbContext> options)
        : base(options) { }
}
