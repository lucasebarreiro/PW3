using PW3.Domain.Models;

namespace PW3.Application.Interfaces.Repositories
{
    public interface IGameRepository
    {
        Task AddAsync(Game Game, CancellationToken cancellationToken);
        Task<Game> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Game>> GetAllAsync(CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);

        Task UpdateAsync(Game Game, CancellationToken cancellationToken);


    }
}
