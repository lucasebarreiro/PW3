using PW3.Domain.Models;

namespace PW3.Application.Interfaces;

public interface IScoreRepository
{
    Task AddAsync(Score score, CancellationToken cancellationToken);
    Task<IEnumerable<Score>> GetTopScoresAsync(int top, CancellationToken cancellationToken);
    Task<IEnumerable<Score>> GetScoresByUserIdAsync(int userId, CancellationToken cancellationToken);
}
