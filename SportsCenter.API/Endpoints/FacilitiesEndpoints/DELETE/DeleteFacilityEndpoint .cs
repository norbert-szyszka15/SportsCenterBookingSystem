using SportsCenter.API.Extentions;
using SportsCenter.Application.Features.Facilities.DeleteFacility;

namespace SportsCenter.API.Endpoints.FacilitiesEndpoints.DELETE;
public class DeleteFacilityEndpoint : IEndpointDefinition
{
    public void RegisterEndpoints(IEndpointRouteBuilder app)
    {
        app.MapDelete($"{FacilitiesRoutes.Base}/{{id:int}}",
                async (int id, DeleteFacilityHandler h)
                    => await h.Handle(id) ? Results.Ok() : Results.NotFound())
            .WithName("DeleteFacility")
            .WithTags("Facilities");
    }
}