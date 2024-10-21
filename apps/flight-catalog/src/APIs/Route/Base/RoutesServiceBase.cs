using FlightCatalog.APIs;
using FlightCatalog.APIs.Common;
using FlightCatalog.APIs.Dtos;
using FlightCatalog.APIs.Errors;
using FlightCatalog.APIs.Extensions;
using FlightCatalog.Infrastructure;
using FlightCatalog.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightCatalog.APIs;

public abstract class RoutesServiceBase : IRoutesService
{
    protected readonly FlightCatalogDbContext _context;

    public RoutesServiceBase(FlightCatalogDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Route
    /// </summary>
    public async Task<Route> CreateRoute(RouteCreateInput createDto)
    {
        var route = new RouteDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Destination = createDto.Destination,
            Origin = createDto.Origin,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            route.Id = createDto.Id;
        }
        if (createDto.Flights != null)
        {
            route.Flights = await _context
                .Flights.Where(flight => createDto.Flights.Select(t => t.Id).Contains(flight.Id))
                .ToListAsync();
        }

        _context.Routes.Add(route);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<RouteDbModel>(route.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Route
    /// </summary>
    public async Task DeleteRoute(RouteWhereUniqueInput uniqueId)
    {
        var route = await _context.Routes.FindAsync(uniqueId.Id);
        if (route == null)
        {
            throw new NotFoundException();
        }

        _context.Routes.Remove(route);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Routes
    /// </summary>
    public async Task<List<Route>> Routes(RouteFindManyArgs findManyArgs)
    {
        var routes = await _context
            .Routes.Include(x => x.Flights)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return routes.ConvertAll(route => route.ToDto());
    }

    /// <summary>
    /// Meta data about Route records
    /// </summary>
    public async Task<MetadataDto> RoutesMeta(RouteFindManyArgs findManyArgs)
    {
        var count = await _context.Routes.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Route
    /// </summary>
    public async Task<Route> Route(RouteWhereUniqueInput uniqueId)
    {
        var routes = await this.Routes(
            new RouteFindManyArgs { Where = new RouteWhereInput { Id = uniqueId.Id } }
        );
        var route = routes.FirstOrDefault();
        if (route == null)
        {
            throw new NotFoundException();
        }

        return route;
    }

    /// <summary>
    /// Update one Route
    /// </summary>
    public async Task UpdateRoute(RouteWhereUniqueInput uniqueId, RouteUpdateInput updateDto)
    {
        var route = updateDto.ToModel(uniqueId);

        if (updateDto.Flights != null)
        {
            route.Flights = await _context
                .Flights.Where(flight => updateDto.Flights.Select(t => t).Contains(flight.Id))
                .ToListAsync();
        }

        _context.Entry(route).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Routes.Any(e => e.Id == route.Id))
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
    /// Connect multiple Flights records to Route
    /// </summary>
    public async Task ConnectFlights(
        RouteWhereUniqueInput uniqueId,
        FlightWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Routes.Include(x => x.Flights)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Flights.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Flights);

        foreach (var child in childrenToConnect)
        {
            parent.Flights.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Flights records from Route
    /// </summary>
    public async Task DisconnectFlights(
        RouteWhereUniqueInput uniqueId,
        FlightWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Routes.Include(x => x.Flights)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Flights.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Flights?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Flights records for Route
    /// </summary>
    public async Task<List<Flight>> FindFlights(
        RouteWhereUniqueInput uniqueId,
        FlightFindManyArgs routeFindManyArgs
    )
    {
        var flights = await _context
            .Flights.Where(m => m.RouteId == uniqueId.Id)
            .ApplyWhere(routeFindManyArgs.Where)
            .ApplySkip(routeFindManyArgs.Skip)
            .ApplyTake(routeFindManyArgs.Take)
            .ApplyOrderBy(routeFindManyArgs.SortBy)
            .ToListAsync();

        return flights.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Flights records for Route
    /// </summary>
    public async Task UpdateFlights(
        RouteWhereUniqueInput uniqueId,
        FlightWhereUniqueInput[] childrenIds
    )
    {
        var route = await _context
            .Routes.Include(t => t.Flights)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (route == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Flights.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        route.Flights = children;
        await _context.SaveChangesAsync();
    }
}
