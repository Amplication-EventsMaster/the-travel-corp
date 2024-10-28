using Microsoft.AspNetCore.Mvc;
using ShippingTracking.APIs.Common;
using ShippingTracking.Infrastructure.Models;

namespace ShippingTracking.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class CustomerFindManyArgs : FindManyInput<Customer, CustomerWhereInput> { }
