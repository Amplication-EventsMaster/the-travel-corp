using Microsoft.AspNetCore.Mvc;

namespace ShippingTracking.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
