using Microsoft.EntityFrameworkCore;
using TrackingService_2.APIs;
using TrackingService_2.APIs.Common;
using TrackingService_2.APIs.Dtos;
using TrackingService_2.APIs.Errors;
using TrackingService_2.APIs.Extensions;
using TrackingService_2.Infrastructure;
using TrackingService_2.Infrastructure.Models;

namespace TrackingService_2.APIs;

public abstract class TrackingsServiceBase : ITrackingsService
{
    protected readonly TrackingService_2DbContext _context;

    public TrackingsServiceBase(TrackingService_2DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one tracking
    /// </summary>
    public async Task<Tracking> CreateTracking(TrackingCreateInput createDto)
    {
        var tracking = new TrackingDbModel
        {
            Comment = createDto.Comment,
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            tracking.Id = createDto.Id;
        }
        if (createDto.Customer != null)
        {
            tracking.Customer = await _context
                .Customers.Where(customer => createDto.Customer.Id == customer.Id)
                .FirstOrDefaultAsync();
        }

        _context.Trackings.Add(tracking);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TrackingDbModel>(tracking.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one tracking
    /// </summary>
    public async Task DeleteTracking(TrackingWhereUniqueInput uniqueId)
    {
        var tracking = await _context.Trackings.FindAsync(uniqueId.Id);
        if (tracking == null)
        {
            throw new NotFoundException();
        }

        _context.Trackings.Remove(tracking);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many trackings
    /// </summary>
    public async Task<List<Tracking>> Trackings(TrackingFindManyArgs findManyArgs)
    {
        var trackings = await _context
            .Trackings.Include(x => x.Customer)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return trackings.ConvertAll(tracking => tracking.ToDto());
    }

    /// <summary>
    /// Meta data about tracking records
    /// </summary>
    public async Task<MetadataDto> TrackingsMeta(TrackingFindManyArgs findManyArgs)
    {
        var count = await _context.Trackings.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one tracking
    /// </summary>
    public async Task<Tracking> Tracking(TrackingWhereUniqueInput uniqueId)
    {
        var trackings = await this.Trackings(
            new TrackingFindManyArgs { Where = new TrackingWhereInput { Id = uniqueId.Id } }
        );
        var tracking = trackings.FirstOrDefault();
        if (tracking == null)
        {
            throw new NotFoundException();
        }

        return tracking;
    }

    /// <summary>
    /// Update one tracking
    /// </summary>
    public async Task UpdateTracking(
        TrackingWhereUniqueInput uniqueId,
        TrackingUpdateInput updateDto
    )
    {
        var tracking = updateDto.ToModel(uniqueId);

        if (updateDto.Customer != null)
        {
            tracking.Customer = await _context
                .Customers.Where(customer => updateDto.Customer == customer.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(tracking).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Trackings.Any(e => e.Id == tracking.Id))
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
    /// Get a Customer record for tracking
    /// </summary>
    public async Task<Customer> GetCustomer(TrackingWhereUniqueInput uniqueId)
    {
        var tracking = await _context
            .Trackings.Where(tracking => tracking.Id == uniqueId.Id)
            .Include(tracking => tracking.Customer)
            .FirstOrDefaultAsync();
        if (tracking == null)
        {
            throw new NotFoundException();
        }
        return tracking.Customer.ToDto();
    }
}
