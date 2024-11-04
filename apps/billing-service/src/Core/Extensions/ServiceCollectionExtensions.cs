using BillingService.APIs;

namespace BillingService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddScoped<IInvoicesService, InvoicesService>();
        services.AddScoped<IPaymentsService, PaymentsService>();
    }
}
