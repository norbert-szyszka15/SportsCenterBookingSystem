using SportsCenter.API.Extentions;
using SportsCenter.Application.Features.Customers.GetCustomers;

namespace SportsCenter.API.Endpoints.CustomersEndpoints.GET;
public class GetCustomersEndpoint : IEndpointDefinition
{
    public void RegisterEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet(CustomersRoutes.Base,
                async (GetCustomersHandler handler)
                    => Results.Ok(await handler.Handle()))
            .WithName("GetCustomers")
            .WithTags("Customers");
    }
}
