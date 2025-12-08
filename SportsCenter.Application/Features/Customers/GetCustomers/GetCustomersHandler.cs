using Microsoft.EntityFrameworkCore;
using SportsCenter.Application.Abstractions;
using SportsCenter.Application.Features.Customers.GetCustomers;
using SportsCenter.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsCenter.Application.Features.Customers.GetCustomers;
public class GetCustomersHandler : IHandlerDefinition
{
    private readonly SportsCenterDbContext _db;

    public GetCustomersHandler(SportsCenterDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GetCustomersResponse>> Handle()
    {
        return await _db.Customers
            .Select(c => new GetCustomersResponse
            {
                PublicId = c.PublicId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone
            })
            .ToListAsync();
    }
}