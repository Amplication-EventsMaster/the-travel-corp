using TrackingService_2.APIs.Common;
using TrackingService_2.APIs.Dtos;

namespace TrackingService_2.APIs;

public interface ITrackingsService
{
    /// <summary>
    /// Create one tracking
    /// </summary>
    public Task<Tracking> CreateTracking(TrackingCreateInput tracking);

    /// <summary>
    /// Delete one tracking
    /// </summary>
    public Task DeleteTracking(TrackingWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many trackings
    /// </summary>
    public Task<List<Tracking>> Trackings(TrackingFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about tracking records
    /// </summary>
    public Task<MetadataDto> TrackingsMeta(TrackingFindManyArgs findManyArgs);

    /// <summary>
    /// Get one tracking
    /// </summary>
    public Task<Tracking> Tracking(TrackingWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one tracking
    /// </summary>
    public Task UpdateTracking(TrackingWhereUniqueInput uniqueId, TrackingUpdateInput updateDto);

    /// <summary>
    /// Get a Customer record for tracking
    /// </summary>
    public Task<Customer> GetCustomer(TrackingWhereUniqueInput uniqueId);
}
