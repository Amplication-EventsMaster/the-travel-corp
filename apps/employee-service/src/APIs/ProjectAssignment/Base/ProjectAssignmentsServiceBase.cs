using EmployeeService.APIs;
using EmployeeService.APIs.Common;
using EmployeeService.APIs.Dtos;
using EmployeeService.APIs.Errors;
using EmployeeService.APIs.Extensions;
using EmployeeService.Infrastructure;
using EmployeeService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.APIs;

public abstract class ProjectAssignmentsServiceBase : IProjectAssignmentsService
{
    protected readonly EmployeeServiceDbContext _context;

    public ProjectAssignmentsServiceBase(EmployeeServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one ProjectAssignment
    /// </summary>
    public async Task<ProjectAssignment> CreateProjectAssignment(
        ProjectAssignmentCreateInput createDto
    )
    {
        var projectAssignment = new ProjectAssignmentDbModel
        {
            CreatedAt = createDto.CreatedAt,
            EndDate = createDto.EndDate,
            ProjectName = createDto.ProjectName,
            StartDate = createDto.StartDate,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            projectAssignment.Id = createDto.Id;
        }
        if (createDto.Employee != null)
        {
            projectAssignment.Employee = await _context
                .Employees.Where(employee => createDto.Employee.Id == employee.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Role != null)
        {
            projectAssignment.Role = await _context
                .Roles.Where(role => createDto.Role.Id == role.Id)
                .FirstOrDefaultAsync();
        }

        _context.ProjectAssignments.Add(projectAssignment);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ProjectAssignmentDbModel>(projectAssignment.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one ProjectAssignment
    /// </summary>
    public async Task DeleteProjectAssignment(ProjectAssignmentWhereUniqueInput uniqueId)
    {
        var projectAssignment = await _context.ProjectAssignments.FindAsync(uniqueId.Id);
        if (projectAssignment == null)
        {
            throw new NotFoundException();
        }

        _context.ProjectAssignments.Remove(projectAssignment);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ProjectAssignments
    /// </summary>
    public async Task<List<ProjectAssignment>> ProjectAssignments(
        ProjectAssignmentFindManyArgs findManyArgs
    )
    {
        var projectAssignments = await _context
            .ProjectAssignments.Include(x => x.Employee)
            .Include(x => x.Role)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return projectAssignments.ConvertAll(projectAssignment => projectAssignment.ToDto());
    }

    /// <summary>
    /// Meta data about ProjectAssignment records
    /// </summary>
    public async Task<MetadataDto> ProjectAssignmentsMeta(
        ProjectAssignmentFindManyArgs findManyArgs
    )
    {
        var count = await _context.ProjectAssignments.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one ProjectAssignment
    /// </summary>
    public async Task<ProjectAssignment> ProjectAssignment(
        ProjectAssignmentWhereUniqueInput uniqueId
    )
    {
        var projectAssignments = await this.ProjectAssignments(
            new ProjectAssignmentFindManyArgs
            {
                Where = new ProjectAssignmentWhereInput { Id = uniqueId.Id }
            }
        );
        var projectAssignment = projectAssignments.FirstOrDefault();
        if (projectAssignment == null)
        {
            throw new NotFoundException();
        }

        return projectAssignment;
    }

    /// <summary>
    /// Update one ProjectAssignment
    /// </summary>
    public async Task UpdateProjectAssignment(
        ProjectAssignmentWhereUniqueInput uniqueId,
        ProjectAssignmentUpdateInput updateDto
    )
    {
        var projectAssignment = updateDto.ToModel(uniqueId);

        if (updateDto.Employee != null)
        {
            projectAssignment.Employee = await _context
                .Employees.Where(employee => updateDto.Employee == employee.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.Role != null)
        {
            projectAssignment.Role = await _context
                .Roles.Where(role => updateDto.Role == role.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(projectAssignment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ProjectAssignments.Any(e => e.Id == projectAssignment.Id))
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
    /// Get a Employee record for ProjectAssignment
    /// </summary>
    public async Task<Employee> GetEmployee(ProjectAssignmentWhereUniqueInput uniqueId)
    {
        var projectAssignment = await _context
            .ProjectAssignments.Where(projectAssignment => projectAssignment.Id == uniqueId.Id)
            .Include(projectAssignment => projectAssignment.Employee)
            .FirstOrDefaultAsync();
        if (projectAssignment == null)
        {
            throw new NotFoundException();
        }
        return projectAssignment.Employee.ToDto();
    }

    /// <summary>
    /// Get a Role record for ProjectAssignment
    /// </summary>
    public async Task<Role> GetRole(ProjectAssignmentWhereUniqueInput uniqueId)
    {
        var projectAssignment = await _context
            .ProjectAssignments.Where(projectAssignment => projectAssignment.Id == uniqueId.Id)
            .Include(projectAssignment => projectAssignment.Role)
            .FirstOrDefaultAsync();
        if (projectAssignment == null)
        {
            throw new NotFoundException();
        }
        return projectAssignment.Role.ToDto();
    }
}
