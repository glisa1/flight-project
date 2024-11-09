using FlightProject.Domain.Models;

namespace FlightProject.Domain.Repository.Reservations;

public interface IReservationRepository : IRepository<Reservation>
{
    public Task<IEnumerable<Reservation>> GetAllReservationsForUserAsync(int userId, CancellationToken token = default);
}
