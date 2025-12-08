using Microsoft.EntityFrameworkCore;
using SportsCenter.Application.Abstractions;
using SportsCenter.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsCenter.Application.Features.Customers.DeleteCustomer;

public class DeleteCustomerHandler : IHandlerDefinition
{
    private readonly SportsCenterDbContext _db;

    public DeleteCustomerHandler(SportsCenterDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(Guid publicId)
    {
        var customer = await _db.Customers
            .SingleOrDefaultAsync(c => c.PublicId == publicId);

        if (customer is null)
            return false;

        _db.Customers.Remove(customer);
        await _db.SaveChangesAsync();

        return true;
    }
}