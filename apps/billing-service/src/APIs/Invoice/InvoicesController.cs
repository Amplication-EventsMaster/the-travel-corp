using Microsoft.AspNetCore.Mvc;

namespace BillingService.APIs;

[ApiController()]
public class InvoicesController : InvoicesControllerBase
{
    public InvoicesController(IInvoicesService service)
        : base(service) { }
}
