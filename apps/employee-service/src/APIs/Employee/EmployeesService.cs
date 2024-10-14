using EmployeeService.Infrastructure;

namespace EmployeeService.APIs;

public class EmployeesService : EmployeesServiceBase
{
    public EmployeesService(EmployeeServiceDbContext context)
        : base(context) { }
}
