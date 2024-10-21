using FlightCatalog.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightCatalog.Infrastructure;

public class FlightCatalogDbContext : DbContext
{
    public FlightCatalogDbContext(DbContextOptions<FlightCatalogDbContext> options)
        : base(options) { }

    public DbSet<FlightDbModel> Flights { get; set; }

    public DbSet<AirlineDbModel> Airlines { get; set; }

    public DbSet<RouteDbModel> Routes { get; set; }

    public DbSet<AirportDbModel> Airports { get; set; }

    public DbSet<TicketDbModel> Tickets { get; set; }

    public DbSet<ScheduleDbModel> Schedules { get; set; }
}
