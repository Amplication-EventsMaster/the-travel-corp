using SampleService.APIs.Common;
using SampleService.APIs.Dtos;

namespace SampleService.APIs;

public interface IOrdersService
{
    /// <summary>
    /// Create one Order
    /// </summary>
    public Task<Order> CreateOrder(OrderCreateInput order);

    /// <summary>
    /// Delete one Order
    /// </summary>
    public Task DeleteOrder(OrderWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Orders
    /// </summary>
    public Task<List<Order>> Orders(OrderFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Order records
    /// </summary>
    public Task<MetadataDto> OrdersMeta(OrderFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Order
    /// </summary>
    public Task<Order> Order(OrderWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Order
    /// </summary>
    public Task UpdateOrder(OrderWhereUniqueInput uniqueId, OrderUpdateInput updateDto);

    /// <summary>
    /// Get a Customer record for Order
    /// </summary>
    public Task<Customer> GetCustomer(OrderWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple feedbacks records to Order
    /// </summary>
    public Task ConnectFeedbacks(
        OrderWhereUniqueInput uniqueId,
        FeedbackWhereUniqueInput[] feedbacksId
    );

    /// <summary>
    /// Disconnect multiple feedbacks records from Order
    /// </summary>
    public Task DisconnectFeedbacks(
        OrderWhereUniqueInput uniqueId,
        FeedbackWhereUniqueInput[] feedbacksId
    );

    /// <summary>
    /// Find multiple feedbacks records for Order
    /// </summary>
    public Task<List<Feedback>> FindFeedbacks(
        OrderWhereUniqueInput uniqueId,
        FeedbackFindManyArgs FeedbackFindManyArgs
    );

    /// <summary>
    /// Update multiple feedbacks records for Order
    /// </summary>
    public Task UpdateFeedbacks(
        OrderWhereUniqueInput uniqueId,
        FeedbackWhereUniqueInput[] feedbacksId
    );

    /// <summary>
    /// Connect multiple Payments records to Order
    /// </summary>
    public Task ConnectPayments(
        OrderWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Disconnect multiple Payments records from Order
    /// </summary>
    public Task DisconnectPayments(
        OrderWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );

    /// <summary>
    /// Find multiple Payments records for Order
    /// </summary>
    public Task<List<Payment>> FindPayments(
        OrderWhereUniqueInput uniqueId,
        PaymentFindManyArgs PaymentFindManyArgs
    );

    /// <summary>
    /// Update multiple Payments records for Order
    /// </summary>
    public Task UpdatePayments(
        OrderWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    );
}
