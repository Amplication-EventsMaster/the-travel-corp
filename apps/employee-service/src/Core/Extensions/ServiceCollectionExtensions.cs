using EmployeeService.APIs;

namespace EmployeeService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAttendancesService, AttendancesService>();
        services.AddScoped<IDepartmentsService, DepartmentsService>();
        services.AddScoped<IEmployeesService, EmployeesService>();
        services.AddScoped<IProjectAssignmentsService, ProjectAssignmentsService>();
        services.AddScoped<IRolesService, RolesService>();
    }
}
