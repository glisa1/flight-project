using FlightProject.Domain.Database;
using FlightProject.Domain.Extensions;
using FlightProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Domain.Repository.Cities;

internal class CityRepository(AppDbContext dbContext) : ICityRepository
{
    private readonly AppDbContext _appDbContext = dbContext;

    public async Task AddAsync(City entity, CancellationToken cancellationToken = default)
    {
        entity.SetCreatedOnAndUpdatedOn();
        await _appDbContext.Cities.AddAsync(entity, cancellationToken);

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _appDbContext.Cities.FindAsync([id], cancellationToken);

        ArgumentNullException.ThrowIfNull(result);

        _appDbContext.Cities.Remove(result);

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<City> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _appDbContext.Cities
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        ArgumentNullException.ThrowIfNull(result);

        return result;
    }

    public async Task UpdateAsync(City entity, CancellationToken cancellationToken = default)
    {
        entity.SetUpdatedOn();
        _appDbContext.Cities.Update(entity);

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<City>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Cities.ToListAsync(cancellationToken);
    }
}
