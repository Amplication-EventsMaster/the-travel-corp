using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.APIs;

[ApiController()]
public class AttendancesController : AttendancesControllerBase
{
    public AttendancesController(IAttendancesService service)
        : base(service) { }
}
