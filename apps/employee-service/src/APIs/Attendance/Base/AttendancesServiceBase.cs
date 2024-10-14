using EmployeeService.APIs;
using EmployeeService.APIs.Common;
using EmployeeService.APIs.Dtos;
using EmployeeService.APIs.Errors;
using EmployeeService.APIs.Extensions;
using EmployeeService.Infrastructure;
using EmployeeService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.APIs;

public abstract class AttendancesServiceBase : IAttendancesService
{
    protected readonly EmployeeServiceDbContext _context;

    public AttendancesServiceBase(EmployeeServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Attendance
    /// </summary>
    public async Task<Attendance> CreateAttendance(AttendanceCreateInput createDto)
    {
        var attendance = new AttendanceDbModel
        {
            CheckInTime = createDto.CheckInTime,
            CheckOutTime = createDto.CheckOutTime,
            CreatedAt = createDto.CreatedAt,
            Date = createDto.Date,
            Status = createDto.Status,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            attendance.Id = createDto.Id;
        }
        if (createDto.Employee != null)
        {
            attendance.Employee = await _context
                .Employees.Where(employee => createDto.Employee.Id == employee.Id)
                .FirstOrDefaultAsync();
        }

        _context.Attendances.Add(attendance);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AttendanceDbModel>(attendance.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Attendance
    /// </summary>
    public async Task DeleteAttendance(AttendanceWhereUniqueInput uniqueId)
    {
        var attendance = await _context.Attendances.FindAsync(uniqueId.Id);
        if (attendance == null)
        {
            throw new NotFoundException();
        }

        _context.Attendances.Remove(attendance);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Attendances
    /// </summary>
    public async Task<List<Attendance>> Attendances(AttendanceFindManyArgs findManyArgs)
    {
        var attendances = await _context
            .Attendances.Include(x => x.Employee)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return attendances.ConvertAll(attendance => attendance.ToDto());
    }

    /// <summary>
    /// Meta data about Attendance records
    /// </summary>
    public async Task<MetadataDto> AttendancesMeta(AttendanceFindManyArgs findManyArgs)
    {
        var count = await _context.Attendances.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Attendance
    /// </summary>
    public async Task<Attendance> Attendance(AttendanceWhereUniqueInput uniqueId)
    {
        var attendances = await this.Attendances(
            new AttendanceFindManyArgs { Where = new AttendanceWhereInput { Id = uniqueId.Id } }
        );
        var attendance = attendances.FirstOrDefault();
        if (attendance == null)
        {
            throw new NotFoundException();
        }

        return attendance;
    }

    /// <summary>
    /// Update one Attendance
    /// </summary>
    public async Task UpdateAttendance(
        AttendanceWhereUniqueInput uniqueId,
        AttendanceUpdateInput updateDto
    )
    {
        var attendance = updateDto.ToModel(uniqueId);

        if (updateDto.Employee != null)
        {
            attendance.Employee = await _context
                .Employees.Where(employee => updateDto.Employee == employee.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(attendance).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Attendances.Any(e => e.Id == attendance.Id))
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
    /// Get a Employee record for Attendance
    /// </summary>
    public async Task<Employee> GetEmployee(AttendanceWhereUniqueInput uniqueId)
    {
        var attendance = await _context
            .Attendances.Where(attendance => attendance.Id == uniqueId.Id)
            .Include(attendance => attendance.Employee)
            .FirstOrDefaultAsync();
        if (attendance == null)
        {
            throw new NotFoundException();
        }
        return attendance.Employee.ToDto();
    }
}
