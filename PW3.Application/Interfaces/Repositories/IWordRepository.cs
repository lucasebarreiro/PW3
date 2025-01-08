using PW3.Domain.Models;

namespace PW3.Application.Interfaces.Repositories;

public interface IWordRepository
{
    Task AddAsync(GameWord Word);
    Task<IEnumerable<GameWord>> GetWordsPerGameIdAsync(int GameId, CancellationToken cancellationToken);
}
