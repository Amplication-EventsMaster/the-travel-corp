using TrackingService_2.APIs.Common;
using TrackingService_2.APIs.Dtos;

namespace TrackingService_2.APIs;

public interface ICustomersService
{
    /// <summary>
    /// Create one customer
    /// </summary>
    public Task<Customer> CreateCustomer(CustomerCreateInput customer);

    /// <summary>
    /// Delete one customer
    /// </summary>
    public Task DeleteCustomer(CustomerWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many customers
    /// </summary>
    public Task<List<Customer>> Customers(CustomerFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about customer records
    /// </summary>
    public Task<MetadataDto> CustomersMeta(CustomerFindManyArgs findManyArgs);

    /// <summary>
    /// Get one customer
    /// </summary>
    public Task<Customer> Customer(CustomerWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one customer
    /// </summary>
    public Task UpdateCustomer(CustomerWhereUniqueInput uniqueId, CustomerUpdateInput updateDto);

    /// <summary>
    /// Connect multiple trackings records to customer
    /// </summary>
    public Task ConnectTrackings(
        CustomerWhereUniqueInput uniqueId,
        TrackingWhereUniqueInput[] trackingsId
    );

    /// <summary>
    /// Disconnect multiple trackings records from customer
    /// </summary>
    public Task DisconnectTrackings(
        CustomerWhereUniqueInput uniqueId,
        TrackingWhereUniqueInput[] trackingsId
    );

    /// <summary>
    /// Find multiple trackings records for customer
    /// </summary>
    public Task<List<Tracking>> FindTrackings(
        CustomerWhereUniqueInput uniqueId,
        TrackingFindManyArgs TrackingFindManyArgs
    );

    /// <summary>
    /// Update multiple trackings records for customer
    /// </summary>
    public Task UpdateTrackings(
        CustomerWhereUniqueInput uniqueId,
        TrackingWhereUniqueInput[] trackingsId
    );
}
