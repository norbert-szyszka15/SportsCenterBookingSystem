using SportsCenter.API.Extentions;
using SportsCenter.Application.Features.Customers.UpdateCustomer;

namespace SportsCenter.API.Endpoints.CustomersEndpoints.UPDATE;

public class UpdateCustomerEndpoint : IEndpointDefinition
{
    public void RegisterEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPut($"{CustomersRoutes.Base}/{{publicId:guid}}",
                async (Guid publicId, UpdateCustomerRequest req, UpdateCustomerHandler handler)
                    => await handler.Handle(publicId, req)
                        ? Results.Ok()
                        : Results.NotFound())
            .WithName("UpdateCustomer")
            .WithTags("Customers");
    }
}