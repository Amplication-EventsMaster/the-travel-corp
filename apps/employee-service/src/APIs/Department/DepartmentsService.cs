using EmployeeService.Infrastructure;

namespace EmployeeService.APIs;

public class DepartmentsService : DepartmentsServiceBase
{
    public DepartmentsService(EmployeeServiceDbContext context)
        : base(context) { }
}
