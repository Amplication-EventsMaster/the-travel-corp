using EmployeeService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Infrastructure;

public class EmployeeServiceDbContext : DbContext
{
    public EmployeeServiceDbContext(DbContextOptions<EmployeeServiceDbContext> options)
        : base(options) { }

    public DbSet<EmployeeDbModel> Employees { get; set; }

    public DbSet<RoleDbModel> Roles { get; set; }

    public DbSet<DepartmentDbModel> Departments { get; set; }

    public DbSet<AttendanceDbModel> Attendances { get; set; }

    public DbSet<ProjectAssignmentDbModel> ProjectAssignments { get; set; }
}
