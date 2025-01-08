using PW3.Application.Interfaces.Repositories;
using PW3.Application.Servicios;
using PW3.Domain.Models;

namespace PW3.Application.Interfaces
{
    public class GameService(IGameRepository _gameRepository, IWordRepository _wordRepository, IRandomWordProviderService _randomWordProviderService) : IGameService
    {
        public async Task<Game> CreateGameSessionAsync(int userId, int user2Id, int duracionEnSegundos, CancellationToken cancellationToken)
        {
            var game = new Game
            {
                Usuario1Id = userId,
                Usuario2Id = user2Id,
                FechaInicio = DateTime.UtcNow,
                FechaFin = DateTime.UtcNow.AddSeconds(duracionEnSegundos),
                DuracionEnSegundos = duracionEnSegundos,
                PuntuacionUsuario1 = 0,
                PuntuacionUsuario2 = 0,
                Words = new List<GameWord>()
            };

            for (int i = 0; i < 10; i++) // limito a 10 palabras 
            {
                var word = await _randomWordProviderService.GetWordsAsync(cancellationToken); // Traigo las palabras de la api
                var newWord = new GameWord
                {
                    Word = word,
                    GameId = game.Id
                };
                await _wordRepository.AddAsync(newWord);  // Guardar la palabra en la bd
                game.Words.Add(newWord);
            }

            await _gameRepository.AddAsync(game, cancellationToken);  // Agrrego el juego a la bd

            return game;
        }
    }
}
