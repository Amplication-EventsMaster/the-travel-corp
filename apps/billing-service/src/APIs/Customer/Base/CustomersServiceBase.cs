using BillingService.APIs;
using BillingService.APIs.Common;
using BillingService.APIs.Dtos;
using BillingService.APIs.Errors;
using BillingService.APIs.Extensions;
using BillingService.Infrastructure;
using BillingService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingService.APIs;

public abstract class CustomersServiceBase : ICustomersService
{
    protected readonly BillingServiceDbContext _context;

    public CustomersServiceBase(BillingServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Customer
    /// </summary>
    public async Task<Customer> CreateCustomer(CustomerCreateInput createDto)
    {
        var customer = new CustomerDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Email = createDto.Email,
            Name = createDto.Name,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            customer.Id = createDto.Id;
        }
        if (createDto.Invoices != null)
        {
            customer.Invoices = await _context
                .Invoices.Where(invoice =>
                    createDto.Invoices.Select(t => t.Id).Contains(invoice.Id)
                )
                .ToListAsync();
        }

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CustomerDbModel>(customer.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Customer
    /// </summary>
    public async Task DeleteCustomer(CustomerWhereUniqueInput uniqueId)
    {
        var customer = await _context.Customers.FindAsync(uniqueId.Id);
        if (customer == null)
        {
            throw new NotFoundException();
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Customers
    /// </summary>
    public async Task<List<Customer>> Customers(CustomerFindManyArgs findManyArgs)
    {
        var customers = await _context
            .Customers.Include(x => x.Invoices)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return customers.ConvertAll(customer => customer.ToDto());
    }

    /// <summary>
    /// Meta data about Customer records
    /// </summary>
    public async Task<MetadataDto> CustomersMeta(CustomerFindManyArgs findManyArgs)
    {
        var count = await _context.Customers.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Customer
    /// </summary>
    public async Task<Customer> Customer(CustomerWhereUniqueInput uniqueId)
    {
        var customers = await this.Customers(
            new CustomerFindManyArgs { Where = new CustomerWhereInput { Id = uniqueId.Id } }
        );
        var customer = customers.FirstOrDefault();
        if (customer == null)
        {
            throw new NotFoundException();
        }

        return customer;
    }

    /// <summary>
    /// Update one Customer
    /// </summary>
    public async Task UpdateCustomer(
        CustomerWhereUniqueInput uniqueId,
        CustomerUpdateInput updateDto
    )
    {
        var customer = updateDto.ToModel(uniqueId);

        if (updateDto.Invoices != null)
        {
            customer.Invoices = await _context
                .Invoices.Where(invoice => updateDto.Invoices.Select(t => t).Contains(invoice.Id))
                .ToListAsync();
        }

        _context.Entry(customer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Customers.Any(e => e.Id == customer.Id))
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
    /// Connect multiple Invoices records to Customer
    /// </summary>
    public async Task ConnectInvoices(
        CustomerWhereUniqueInput uniqueId,
        InvoiceWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Customers.Include(x => x.Invoices)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Invoices.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Invoices);

        foreach (var child in childrenToConnect)
        {
            parent.Invoices.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Invoices records from Customer
    /// </summary>
    public async Task DisconnectInvoices(
        CustomerWhereUniqueInput uniqueId,
        InvoiceWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Customers.Include(x => x.Invoices)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Invoices.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Invoices?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Invoices records for Customer
    /// </summary>
    public async Task<List<Invoice>> FindInvoices(
        CustomerWhereUniqueInput uniqueId,
        InvoiceFindManyArgs customerFindManyArgs
    )
    {
        var invoices = await _context
            .Invoices.Where(m => m.CustomerId == uniqueId.Id)
            .ApplyWhere(customerFindManyArgs.Where)
            .ApplySkip(customerFindManyArgs.Skip)
            .ApplyTake(customerFindManyArgs.Take)
            .ApplyOrderBy(customerFindManyArgs.SortBy)
            .ToListAsync();

        return invoices.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Invoices records for Customer
    /// </summary>
    public async Task UpdateInvoices(
        CustomerWhereUniqueInput uniqueId,
        InvoiceWhereUniqueInput[] childrenIds
    )
    {
        var customer = await _context
            .Customers.Include(t => t.Invoices)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (customer == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Invoices.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        customer.Invoices = children;
        await _context.SaveChangesAsync();
    }
}
