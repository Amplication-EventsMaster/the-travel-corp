using BillingService.APIs.Common;
using BillingService.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace BillingService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class FeedbackFindManyArgs : FindManyInput<Feedback, FeedbackWhereInput> { }
