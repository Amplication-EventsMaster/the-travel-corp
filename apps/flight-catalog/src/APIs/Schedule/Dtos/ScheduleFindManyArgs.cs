using FlightCatalog.APIs.Common;
using FlightCatalog.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightCatalog.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ScheduleFindManyArgs : FindManyInput<Schedule, ScheduleWhereInput> { }
