using Microsoft.EntityFrameworkCore;
using SportsCenter.Application.Abstractions;
using SportsCenter.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsCenter.Application.Features.Customers.GetCustomerById;

public class GetCustomerByIdHandler : IHandlerDefinition
{
    private readonly SportsCenterDbContext _db;

    public GetCustomerByIdHandler(SportsCenterDbContext db)
    {
        _db = db;
    }

    public async Task<GetCustomerByIdResponse?> Handle(Guid publicId)
    {
        return await _db.Customers
            .Where(c => c.PublicId == publicId)
            .Select(c => new GetCustomerByIdResponse
            {
                PublicId = c.PublicId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone
            })
            .SingleOrDefaultAsync();
    }
}