using EmployeeService.Infrastructure;

namespace EmployeeService.APIs;

public class RolesService : RolesServiceBase
{
    public RolesService(EmployeeServiceDbContext context)
        : base(context) { }
}
