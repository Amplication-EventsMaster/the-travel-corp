using EmployeeService.Infrastructure;

namespace EmployeeService.APIs;

public class ProjectAssignmentsService : ProjectAssignmentsServiceBase
{
    public ProjectAssignmentsService(EmployeeServiceDbContext context)
        : base(context) { }
}
