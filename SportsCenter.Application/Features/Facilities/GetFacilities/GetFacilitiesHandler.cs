using SportsCenter.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Application.Abstractions;

namespace SportsCenter.Application.Features.Facilities.GetFacilities;

public class GetFacilitiesHandler : IHandlerDefinition
{
    private readonly SportsCenterDbContext _db;

    public GetFacilitiesHandler(SportsCenterDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GetFacilitiesResponse>> Handle()
    {
        return await _db.Facilities
            .AsNoTracking()
            .Select(f => new GetFacilitiesResponse(
                f.Id,
                f.Name,
                f.SportType,
                f.MaxPlayers,
                f.PricePerHour,
                f.IsActive))
            .ToListAsync();
    }
}