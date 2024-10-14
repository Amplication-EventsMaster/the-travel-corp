using EmployeeService.APIs.Common;
using EmployeeService.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class AttendanceFindManyArgs : FindManyInput<Attendance, AttendanceWhereInput> { }
