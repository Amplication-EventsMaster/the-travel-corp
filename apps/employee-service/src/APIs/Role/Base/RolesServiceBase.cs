using EmployeeService.APIs;
using EmployeeService.APIs.Common;
using EmployeeService.APIs.Dtos;
using EmployeeService.APIs.Errors;
using EmployeeService.APIs.Extensions;
using EmployeeService.Infrastructure;
using EmployeeService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.APIs;

public abstract class RolesServiceBase : IRolesService
{
    protected readonly EmployeeServiceDbContext _context;

    public RolesServiceBase(EmployeeServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Role
    /// </summary>
    public async Task<Role> CreateRole(RoleCreateInput createDto)
    {
        var role = new RoleDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            Name = createDto.Name,
            SalaryRange = createDto.SalaryRange,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            role.Id = createDto.Id;
        }
        if (createDto.ProjectAssignments != null)
        {
            role.ProjectAssignments = await _context
                .ProjectAssignments.Where(projectAssignment =>
                    createDto.ProjectAssignments.Select(t => t.Id).Contains(projectAssignment.Id)
                )
                .ToListAsync();
        }

        _context.Roles.Add(role);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<RoleDbModel>(role.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Role
    /// </summary>
    public async Task DeleteRole(RoleWhereUniqueInput uniqueId)
    {
        var role = await _context.Roles.FindAsync(uniqueId.Id);
        if (role == null)
        {
            throw new NotFoundException();
        }

        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Roles
    /// </summary>
    public async Task<List<Role>> Roles(RoleFindManyArgs findManyArgs)
    {
        var roles = await _context
            .Roles.Include(x => x.ProjectAssignments)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return roles.ConvertAll(role => role.ToDto());
    }

    /// <summary>
    /// Meta data about Role records
    /// </summary>
    public async Task<MetadataDto> RolesMeta(RoleFindManyArgs findManyArgs)
    {
        var count = await _context.Roles.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Role
    /// </summary>
    public async Task<Role> Role(RoleWhereUniqueInput uniqueId)
    {
        var roles = await this.Roles(
            new RoleFindManyArgs { Where = new RoleWhereInput { Id = uniqueId.Id } }
        );
        var role = roles.FirstOrDefault();
        if (role == null)
        {
            throw new NotFoundException();
        }

        return role;
    }

    /// <summary>
    /// Update one Role
    /// </summary>
    public async Task UpdateRole(RoleWhereUniqueInput uniqueId, RoleUpdateInput updateDto)
    {
        var role = updateDto.ToModel(uniqueId);

        if (updateDto.ProjectAssignments != null)
        {
            role.ProjectAssignments = await _context
                .ProjectAssignments.Where(projectAssignment =>
                    updateDto.ProjectAssignments.Select(t => t).Contains(projectAssignment.Id)
                )
                .ToListAsync();
        }

        _context.Entry(role).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Roles.Any(e => e.Id == role.Id))
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
    /// Connect multiple ProjectAssignments records to Role
    /// </summary>
    public async Task ConnectProjectAssignments(
        RoleWhereUniqueInput uniqueId,
        ProjectAssignmentWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Roles.Include(x => x.ProjectAssignments)
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
    /// Disconnect multiple ProjectAssignments records from Role
    /// </summary>
    public async Task DisconnectProjectAssignments(
        RoleWhereUniqueInput uniqueId,
        ProjectAssignmentWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Roles.Include(x => x.ProjectAssignments)
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
    /// Find multiple ProjectAssignments records for Role
    /// </summary>
    public async Task<List<ProjectAssignment>> FindProjectAssignments(
        RoleWhereUniqueInput uniqueId,
        ProjectAssignmentFindManyArgs roleFindManyArgs
    )
    {
        var projectAssignments = await _context
            .ProjectAssignments.Where(m => m.RoleId == uniqueId.Id)
            .ApplyWhere(roleFindManyArgs.Where)
            .ApplySkip(roleFindManyArgs.Skip)
            .ApplyTake(roleFindManyArgs.Take)
            .ApplyOrderBy(roleFindManyArgs.SortBy)
            .ToListAsync();

        return projectAssignments.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple ProjectAssignments records for Role
    /// </summary>
    public async Task UpdateProjectAssignments(
        RoleWhereUniqueInput uniqueId,
        ProjectAssignmentWhereUniqueInput[] childrenIds
    )
    {
        var role = await _context
            .Roles.Include(t => t.ProjectAssignments)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (role == null)
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

        role.ProjectAssignments = children;
        await _context.SaveChangesAsync();
    }
}
