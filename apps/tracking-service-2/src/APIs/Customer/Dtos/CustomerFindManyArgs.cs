using Microsoft.AspNetCore.Mvc;
using TrackingService_2.APIs.Common;
using TrackingService_2.Infrastructure.Models;

namespace TrackingService_2.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class CustomerFindManyArgs : FindManyInput<Customer, CustomerWhereInput> { }
