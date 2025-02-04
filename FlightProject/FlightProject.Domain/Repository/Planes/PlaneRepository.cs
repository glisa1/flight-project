using FlightProject.Domain.Database;
using FlightProject.Domain.Extensions;
using FlightProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Domain.Repository.Planes;

internal sealed class PlaneRepository(AppDbContext dbContext) : IPlaneRepository
{
    private readonly AppDbContext _appDbContext = dbContext;

    public async Task AddAsync(Plane entity, CancellationToken cancellationToken = default)
    {
        entity.SetCreatedOnAndUpdatedOn();
        await _appDbContext.Planes.AddAsync(entity, cancellationToken);

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _appDbContext.Planes.FindAsync([id], cancellationToken);

        ArgumentNullException.ThrowIfNull(result);

        _appDbContext.Planes.Remove(result);

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Plane> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _appDbContext.Planes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        ArgumentNullException.ThrowIfNull(result);

        return result;
    }

    public async Task UpdateAsync(Plane entity, CancellationToken cancellationToken = default)
    {
        entity.SetUpdatedOn();
        _appDbContext.Planes.Update(entity);

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Plane>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Planes.ToListAsync(cancellationToken);
    }
}
