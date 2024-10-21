using Microsoft.AspNetCore.Mvc;
using SampleService.APIs.Common;
using SampleService.Infrastructure.Models;

namespace SampleService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class FeedbackFindManyArgs : FindManyInput<Feedback, FeedbackWhereInput> { }
