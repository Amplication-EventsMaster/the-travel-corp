using Microsoft.AspNetCore.Mvc;

namespace TrackingService_2.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
