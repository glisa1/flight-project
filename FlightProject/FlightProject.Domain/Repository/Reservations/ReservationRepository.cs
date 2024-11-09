﻿using FlightProject.Domain.Database;
using FlightProject.Domain.Extensions;
using FlightProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightProject.Domain.Repository.Reservations;

internal class ReservationRepository(AppDbContext dbContext) : IReservationRepository
{
    private readonly AppDbContext _appDbContext = dbContext;

    public async Task AddAsync(Reservation entity, CancellationToken cancellationToken = default)
    {
        entity.SetCreatedOnAndUpdatedOn();
        await _appDbContext.Reservations.AddAsync(entity, cancellationToken);

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _appDbContext.Reservations.FindAsync([id], cancellationToken);

        ArgumentNullException.ThrowIfNull(result);

        _appDbContext.Reservations.Remove(result);

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Reservation> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _appDbContext.Reservations
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        ArgumentNullException.ThrowIfNull(result);

        return result;
    }

    public async Task UpdateAsync(Reservation entity, CancellationToken cancellationToken = default)
    {
        entity.SetUpdatedOn();
        _appDbContext.Reservations.Update(entity);

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Reservations.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Reservation>> GetAllReservationsForUserAsync(int userId, CancellationToken token = default)
    {
        return await _appDbContext.Reservations.Where(reservation => reservation.UserId == userId).ToListAsync(token);
    }
}