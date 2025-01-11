using PW3.Domain.Models;

namespace PW3.Application.Servicios
{
    public interface IGameService
    {
        Task<Game> CreateGameSessionAsync(int userId, int user2Id, int duracionEnSegundos, CancellationToken cancellationToken);
        Task<bool> VerifyWordAsync(int gameId, string userId, string word, CancellationToken cancellationToken);
        Task GetGameResultAsync(int gameId, CancellationToken cancellationToken);

    }
}
