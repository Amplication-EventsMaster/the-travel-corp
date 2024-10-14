using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.APIs;

[ApiController()]
public class ProjectAssignmentsController : ProjectAssignmentsControllerBase
{
    public ProjectAssignmentsController(IProjectAssignmentsService service)
        : base(service) { }
}
