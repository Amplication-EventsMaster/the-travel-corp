using EmployeeService.APIs;
using EmployeeService.APIs.Common;
using EmployeeService.APIs.Dtos;
using EmployeeService.APIs.Errors;
using EmployeeService.APIs.Extensions;
using EmployeeService.Infrastructure;
using EmployeeService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.APIs;

public abstract class EmployeesServiceBase : IEmployeesService
{
    protected readonly EmployeeServiceDbContext _context;

    public EmployeesServiceBase(EmployeeServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Employee
    /// </summary>
    public async Task<Employee> CreateEmployee(EmployeeCreateInput createDto)
    {
        var employee = new EmployeeDbModel
        {
            CreatedAt = createDto.CreatedAt,
            DateOfBirth = createDto.DateOfBirth,
            Email = createDto.Email,
            Name = createDto.Name,
            PhoneNumber = createDto.PhoneNumber,
            Position = createDto.Position,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            employee.Id = createDto.Id;
        }
        if (createDto.Attendances != null)
        {
            employee.Attendances = await _context
                .Attendances.Where(attendance =>
                    createDto.Attendances.Select(t => t.Id).Contains(attendance.Id)
                )
                .ToListAsync();
        }

        if (createDto.Department != null)
        {
            employee.Department = await _context
                .Departments.Where(department => createDto.Department.Id == department.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.ProjectAssignments != null)
        {
            employee.ProjectAssignments = await _context
                .ProjectAssignments.Where(projectAssignment =>
                    createDto.ProjectAssignments.Select(t => t.Id).Contains(projectAssignment.Id)
                )
                .ToListAsync();
        }

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<EmployeeDbModel>(employee.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Employee
    /// </summary>
    public async Task DeleteEmployee(EmployeeWhereUniqueInput uniqueId)
    {
        var employee = await _context.Employees.FindAsync(uniqueId.Id);
        if (employee == null)
        {
            throw new NotFoundException();
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Employees
    /// </summary>
    public async Task<List<Employee>> Employees(EmployeeFindManyArgs findManyArgs)
    {
        var employees = await _context
            .Employees.Include(x => x.Department)
            .Include(x => x.Attendances)
            .Include(x => x.ProjectAssignments)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return employees.ConvertAll(employee => employee.ToDto());
    }

    /// <summary>
    /// Meta data about Employee records
    /// </summary>
    public async Task<MetadataDto> EmployeesMeta(EmployeeFindManyArgs findManyArgs)
    {
        var count = await _context.Employees.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Employee
    /// </summary>
    public async Task<Employee> Employee(EmployeeWhereUniqueInput uniqueId)
    {
        var employees = await this.Employees(
            new EmployeeFindManyArgs { Where = new EmployeeWhereInput { Id = uniqueId.Id } }
        );
        var employee = employees.FirstOrDefault();
        if (employee == null)
        {
            throw new NotFoundException();
        }

        return employee;
    }

    /// <summary>
    /// Update one Employee
    /// </summary>
    public async Task UpdateEmployee(
        EmployeeWhereUniqueInput uniqueId,
        EmployeeUpdateInput updateDto
    )
    {
        var employee = updateDto.ToModel(uniqueId);

        if (updateDto.Attendances != null)
        {
            employee.Attendances = await _context
                .Attendances.Where(attendance =>
                    updateDto.Attendances.Select(t => t).Contains(attendance.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Department != null)
        {
            employee.Department = await _context
                .Departments.Where(department => updateDto.Department == department.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.ProjectAssignments != null)
        {
            employee.ProjectAssignments = await _context
                .ProjectAssignments.Where(projectAssignment =>
                    updateDto.ProjectAssignments.Select(t => t).Contains(projectAssignment.Id)
                )
                .ToListAsync();
        }

        _context.Entry(employee).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Employees.Any(e => e.Id == employee.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Connect multiple Attendances records to Employee
    /// </summary>
    public async Task ConnectAttendances(
        EmployeeWhereUniqueInput uniqueId,
        AttendanceWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Employees.Include(x => x.Attendances)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Attendances.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Attendances);

        foreach (var child in childrenToConnect)
        {
            parent.Attendances.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Attendances records from Employee
    /// </summary>
    public async Task DisconnectAttendances(
        EmployeeWhereUniqueInput uniqueId,
        AttendanceWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Employees.Include(x => x.Attendances)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Attendances.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Attendances?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Attendances records for Employee
    /// </summary>
    public async Task<List<Attendance>> FindAttendances(
        EmployeeWhereUniqueInput uniqueId,
        AttendanceFindManyArgs employeeFindManyArgs
    )
    {
        var attendances = await _context
            .Attendances.Where(m => m.EmployeeId == uniqueId.Id)
            .ApplyWhere(employeeFindManyArgs.Where)
            .ApplySkip(employeeFindManyArgs.Skip)
            .ApplyTake(employeeFindManyArgs.Take)
            .ApplyOrderBy(employeeFindManyArgs.SortBy)
            .ToListAsync();

        return attendances.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Attendances records for Employee
    /// </summary>
    public async Task UpdateAttendances(
        EmployeeWhereUniqueInput uniqueId,
        AttendanceWhereUniqueInput[] childrenIds
    )
    {
        var employee = await _context
            .Employees.Include(t => t.Attendances)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (employee == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Attendances.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        employee.Attendances = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Get a Department record for Employee
    /// </summary>
    public async Task<Department> GetDepartment(EmployeeWhereUniqueInput uniqueId)
    {
        var employee = await _context
            .Employees.Where(employee => employee.Id == uniqueId.Id)
            .Include(employee => employee.Department)
            .FirstOrDefaultAsync();
        if (employee == null)
        {
            throw new NotFoundException();
        }
        return employee.Department.ToDto();
    }

    /// <summary>
    /// Connect multiple ProjectAssignments records to Employee
    /// </summary>
    public async Task ConnectProjectAssignments(
        EmployeeWhereUniqueInput uniqueId,
        ProjectAssignmentWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Employees.Include(x => x.ProjectAssignments)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ProjectAssignments.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.ProjectAssignments);

        foreach (var child in childrenToConnect)
        {
            parent.ProjectAssignments.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple ProjectAssignments records from Employee
    /// </summary>
    public async Task DisconnectProjectAssignments(
        EmployeeWhereUniqueInput uniqueId,
        ProjectAssignmentWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Employees.Include(x => x.ProjectAssignments)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ProjectAssignments.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.ProjectAssignments?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple ProjectAssignments records for Employee
    /// </summary>
    public async Task<List<ProjectAssignment>> FindProjectAssignments(
        EmployeeWhereUniqueInput uniqueId,
        ProjectAssignmentFindManyArgs employeeFindManyArgs
    )
    {
        var projectAssignments = await _context
            .ProjectAssignments.Where(m => m.EmployeeId == uniqueId.Id)
            .ApplyWhere(employeeFindManyArgs.Where)
            .ApplySkip(employeeFindManyArgs.Skip)
            .ApplyTake(employeeFindManyArgs.Take)
            .ApplyOrderBy(employeeFindManyArgs.SortBy)
            .ToListAsync();

        return projectAssignments.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple ProjectAssignments records for Employee
    /// </summary>
    public async Task UpdateProjectAssignments(
        EmployeeWhereUniqueInput uniqueId,
        ProjectAssignmentWhereUniqueInput[] childrenIds
    )
    {
        var employee = await _context
            .Employees.Include(t => t.ProjectAssignments)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (employee == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ProjectAssignments.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        employee.ProjectAssignments = children;
        await _context.SaveChangesAsync();
    }
}
