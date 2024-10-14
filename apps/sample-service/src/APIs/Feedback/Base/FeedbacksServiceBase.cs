using Microsoft.EntityFrameworkCore;
using SampleService.APIs;
using SampleService.APIs.Common;
using SampleService.APIs.Dtos;
using SampleService.APIs.Errors;
using SampleService.APIs.Extensions;
using SampleService.Infrastructure;
using SampleService.Infrastructure.Models;

namespace SampleService.APIs;

public abstract class FeedbacksServiceBase : IFeedbacksService
{
    protected readonly SampleServiceDbContext _context;

    public FeedbacksServiceBase(SampleServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one feedback
    /// </summary>
    public async Task<Feedback> CreateFeedback(FeedbackCreateInput createDto)
    {
        var feedback = new FeedbackDbModel
        {
            Comment = createDto.Comment,
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            feedback.Id = createDto.Id;
        }
        if (createDto.Order != null)
        {
            feedback.Order = await _context
                .Orders.Where(order => createDto.Order.Id == order.Id)
                .FirstOrDefaultAsync();
        }

        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<FeedbackDbModel>(feedback.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one feedback
    /// </summary>
    public async Task DeleteFeedback(FeedbackWhereUniqueInput uniqueId)
    {
        var feedback = await _context.Feedbacks.FindAsync(uniqueId.Id);
        if (feedback == null)
        {
            throw new NotFoundException();
        }

        _context.Feedbacks.Remove(feedback);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many feedbacks
    /// </summary>
    public async Task<List<Feedback>> Feedbacks(FeedbackFindManyArgs findManyArgs)
    {
        var feedbacks = await _context
            .Feedbacks.Include(x => x.Order)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return feedbacks.ConvertAll(feedback => feedback.ToDto());
    }

    /// <summary>
    /// Meta data about feedback records
    /// </summary>
    public async Task<MetadataDto> FeedbacksMeta(FeedbackFindManyArgs findManyArgs)
    {
        var count = await _context.Feedbacks.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one feedback
    /// </summary>
    public async Task<Feedback> Feedback(FeedbackWhereUniqueInput uniqueId)
    {
        var feedbacks = await this.Feedbacks(
            new FeedbackFindManyArgs { Where = new FeedbackWhereInput { Id = uniqueId.Id } }
        );
        var feedback = feedbacks.FirstOrDefault();
        if (feedback == null)
        {
            throw new NotFoundException();
        }

        return feedback;
    }

    /// <summary>
    /// Update one feedback
    /// </summary>
    public async Task UpdateFeedback(
        FeedbackWhereUniqueInput uniqueId,
        FeedbackUpdateInput updateDto
    )
    {
        var feedback = updateDto.ToModel(uniqueId);

        if (updateDto.Order != null)
        {
            feedback.Order = await _context
                .Orders.Where(order => updateDto.Order == order.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(feedback).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Feedbacks.Any(e => e.Id == feedback.Id))
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
    /// Get a order record for feedback
    /// </summary>
    public async Task<Order> GetOrder(FeedbackWhereUniqueInput uniqueId)
    {
        var feedback = await _context
            .Feedbacks.Where(feedback => feedback.Id == uniqueId.Id)
            .Include(feedback => feedback.Order)
            .FirstOrDefaultAsync();
        if (feedback == null)
        {
            throw new NotFoundException();
        }
        return feedback.Order.ToDto();
    }
}
