using Microsoft.EntityFrameworkCore;
using SportsCenter.Application.Abstractions;
using SportsCenter.Domain.Entities;
using SportsCenter.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsCenter.Application.Features.Customers.CreateCustomer;

public class CreateCustomerHandler : IHandlerDefinition
{
    private readonly SportsCenterDbContext _db;

    public CreateCustomerHandler(SportsCenterDbContext db)
    {
        _db = db;
    }


    public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request)
    {
        var customer = new Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone
        };

        _db.Customers.Add(customer);
        await _db.SaveChangesAsync();

        return new CreateCustomerResponse
        {
            PublicId = customer.PublicId
        };
    }
}