using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.APIs;

[ApiController()]
public class DepartmentsController : DepartmentsControllerBase
{
    public DepartmentsController(IDepartmentsService service)
        : base(service) { }
}
