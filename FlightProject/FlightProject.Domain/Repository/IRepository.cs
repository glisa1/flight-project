using FlightProject.Domain.Models.Base;

namespace FlightProject.Domain.Repository;

public interface IRepository<T> where T : Entity
{
    public Task<T> GetAsync(int id, CancellationToken cancellationToken = default);
    public Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    public Task AddAsync(T entity, CancellationToken cancellationToken = default);
}
