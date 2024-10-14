using SampleService.APIs.Dtos;
using SampleService.Infrastructure.Models;

namespace SampleService.APIs.Extensions;

public static class FeedbacksExtensions
{
    public static Feedback ToDto(this FeedbackDbModel model)
    {
        return new Feedback
        {
            Comment = model.Comment,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Order = model.OrderId,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static FeedbackDbModel ToModel(
        this FeedbackUpdateInput updateDto,
        FeedbackWhereUniqueInput uniqueId
    )
    {
        var feedback = new FeedbackDbModel { Id = uniqueId.Id, Comment = updateDto.Comment };

        if (updateDto.CreatedAt != null)
        {
            feedback.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Order != null)
        {
            feedback.OrderId = updateDto.Order;
        }
        if (updateDto.UpdatedAt != null)
        {
            feedback.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return feedback;
    }
}
