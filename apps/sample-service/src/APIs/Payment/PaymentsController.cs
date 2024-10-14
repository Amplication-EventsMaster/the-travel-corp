using Microsoft.AspNetCore.Mvc;

namespace SampleService.APIs;

[ApiController()]
public class PaymentsController : PaymentsControllerBase
{
    public PaymentsController(IPaymentsService service)
        : base(service) { }
}
