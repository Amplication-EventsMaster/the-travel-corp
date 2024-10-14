using EmployeeService.APIs;
using EmployeeService.APIs.Common;
using EmployeeService.APIs.Dtos;
using EmployeeService.APIs.Errors;
using EmployeeService.APIs.Extensions;
using EmployeeService.Infrastructure;
using EmployeeService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.APIs;

public abstract class DepartmentsServiceBase : IDepartmentsService
{
    protected readonly EmployeeServiceDbContext _context;

    public DepartmentsServiceBase(EmployeeServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Department
    /// </summary>
    public async Task<Department> CreateDepartment(DepartmentCreateInput createDto)
    {
        var department = new DepartmentDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Location = createDto.Location,
            Manager = createDto.Manager,
            Name = createDto.Name,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            department.Id = createDto.Id;
        }
        if (createDto.Employees != null)
        {
            department.Employees = await _context
                .Employees.Where(employee =>
                    createDto.Employees.Select(t => t.Id).Contains(employee.Id)
                )
                .ToListAsync();
        }

        _context.Departments.Add(department);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<DepartmentDbModel>(department.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Department
    /// </summary>
    public async Task DeleteDepartment(DepartmentWhereUniqueInput uniqueId)
    {
        var department = await _context.Departments.FindAsync(uniqueId.Id);
        if (department == null)
        {
            throw new NotFoundException();
        }

        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Departments
    /// </summary>
    public async Task<List<Department>> Departments(DepartmentFindManyArgs findManyArgs)
    {
        var departments = await _context
            .Departments.Include(x => x.Employees)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return departments.ConvertAll(department => department.ToDto());
    }

    /// <summary>
    /// Meta data about Department records
    /// </summary>
    public async Task<MetadataDto> DepartmentsMeta(DepartmentFindManyArgs findManyArgs)
    {
        var count = await _context.Departments.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Department
    /// </summary>
    public async Task<Department> Department(DepartmentWhereUniqueInput uniqueId)
    {
        var departments = await this.Departments(
            new DepartmentFindManyArgs { Where = new DepartmentWhereInput { Id = uniqueId.Id } }
        );
        var department = departments.FirstOrDefault();
        if (department == null)
        {
            throw new NotFoundException();
        }

        return department;
    }

    /// <summary>
    /// Update one Department
    /// </summary>
    public async Task UpdateDepartment(
        DepartmentWhereUniqueInput uniqueId,
        DepartmentUpdateInput updateDto
    )
    {
        var department = updateDto.ToModel(uniqueId);

        if (updateDto.Employees != null)
        {
            department.Employees = await _context
                .Employees.Where(employee =>
                    updateDto.Employees.Select(t => t).Contains(employee.Id)
                )
                .ToListAsync();
        }

        _context.Entry(department).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Departments.Any(e => e.Id == department.Id))
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
    /// Connect multiple Employees records to Department
    /// </summary>
    public async Task ConnectEmployees(
        DepartmentWhereUniqueInput uniqueId,
        EmployeeWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Departments.Include(x => x.Employees)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Employees.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Employees);

        foreach (var child in childrenToConnect)
        {
            parent.Employees.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Employees records from Department
    /// </summary>
    public async Task DisconnectEmployees(
        DepartmentWhereUniqueInput uniqueId,
        EmployeeWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Departments.Include(x => x.Employees)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Employees.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Employees?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Employees records for Department
    /// </summary>
    public async Task<List<Employee>> FindEmployees(
        DepartmentWhereUniqueInput uniqueId,
        EmployeeFindManyArgs departmentFindManyArgs
    )
    {
        var employees = await _context
            .Employees.Where(m => m.DepartmentId == uniqueId.Id)
            .ApplyWhere(departmentFindManyArgs.Where)
            .ApplySkip(departmentFindManyArgs.Skip)
            .ApplyTake(departmentFindManyArgs.Take)
            .ApplyOrderBy(departmentFindManyArgs.SortBy)
            .ToListAsync();

        return employees.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Employees records for Department
    /// </summary>
    public async Task UpdateEmployees(
        DepartmentWhereUniqueInput uniqueId,
        EmployeeWhereUniqueInput[] childrenIds
    )
    {
        var department = await _context
            .Departments.Include(t => t.Employees)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (department == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Employees.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        department.Employees = children;
        await _context.SaveChangesAsync();
    }
}
