using SportsCenter.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Application.Abstractions;
using SportsCenter.Application.Features.Customers.UpdateCustomer;

namespace SportsCenter.Application.Features.Customers.UpdateCustomer;

public class UpdateCustomerHandler : IHandlerDefinition
{
    private readonly SportsCenterDbContext _db;

    public UpdateCustomerHandler(SportsCenterDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(Guid publicId, UpdateCustomerRequest request)
    {
        var customer = await _db.Customers
            .SingleOrDefaultAsync(c => c.PublicId == publicId);

        if (customer is null)
            return false;

        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.Email = request.Email;
        customer.Phone = request.Phone;

        await _db.SaveChangesAsync();
        return true;
    }
}