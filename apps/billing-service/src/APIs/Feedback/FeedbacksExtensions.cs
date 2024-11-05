using BillingService.APIs.Dtos;
using BillingService.Infrastructure.Models;

namespace BillingService.APIs.Extensions;

public static class FeedbacksExtensions
{
    public static Feedback ToDto(this FeedbackDbModel model)
    {
        return new Feedback
        {
            Comments = model.Comments,
            CreatedAt = model.CreatedAt,
            Customer = model.CustomerId,
            Id = model.Id,
            Rating = model.Rating,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static FeedbackDbModel ToModel(
        this FeedbackUpdateInput updateDto,
        FeedbackWhereUniqueInput uniqueId
    )
    {
        var feedback = new FeedbackDbModel
        {
            Id = uniqueId.Id,
            Comments = updateDto.Comments,
            Rating = updateDto.Rating
        };

        if (updateDto.CreatedAt != null)
        {
            feedback.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Customer != null)
        {
            feedback.CustomerId = updateDto.Customer;
        }
        if (updateDto.UpdatedAt != null)
        {
            feedback.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return feedback;
    }
}
