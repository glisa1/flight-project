using FlightProject.Domain.Database;
using FlightProject.Domain.Extensions;
using FlightProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Domain.Repository.Flights;

internal class FlightRepository(AppDbContext dbContext) : IFlightRepository
{
    private readonly AppDbContext _appDbContext = dbContext;

    public async Task AddAsync(Flight entity, CancellationToken cancellationToken = default)
    {
        entity.SetCreatedOnAndUpdatedOn();
        await _appDbContext.Flights.AddAsync(entity, cancellationToken);

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _appDbContext.Flights.FindAsync([id], cancellationToken);

        ArgumentNullException.ThrowIfNull(result);

        _appDbContext.Flights.Remove(result);

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Flight> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _appDbContext.Flights
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        ArgumentNullException.ThrowIfNull(result);

        return result;
    }

    public async Task UpdateAsync(Flight entity, CancellationToken cancellationToken = default)
    {
        entity.SetUpdatedOn();
        _appDbContext.Flights.Update(entity);

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Flight>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Flights.ToListAsync(cancellationToken);
    }
}
