using EmployeeService.Infrastructure;

namespace EmployeeService.APIs;

public class AttendancesService : AttendancesServiceBase
{
    public AttendancesService(EmployeeServiceDbContext context)
        : base(context) { }
}
