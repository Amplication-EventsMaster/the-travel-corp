using Microsoft.AspNetCore.Mvc;

namespace SampleService.APIs;

[ApiController()]
public class OrdersController : OrdersControllerBase
{
    public OrdersController(IOrdersService service)
        : base(service) { }
}
