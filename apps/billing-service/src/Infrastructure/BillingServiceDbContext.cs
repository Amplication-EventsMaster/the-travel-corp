using BillingService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingService.Infrastructure;

public class BillingServiceDbContext : DbContext
{
    public BillingServiceDbContext(DbContextOptions<BillingServiceDbContext> options)
        : base(options) { }

    public DbSet<InvoiceDbModel> Invoices { get; set; }

    public DbSet<PaymentDbModel> Payments { get; set; }

    public DbSet<CustomerDbModel> Customers { get; set; }
}
