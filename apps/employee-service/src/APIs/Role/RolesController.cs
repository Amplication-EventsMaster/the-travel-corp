using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.APIs;

[ApiController()]
public class RolesController : RolesControllerBase
{
    public RolesController(IRolesService service)
        : base(service) { }
}
