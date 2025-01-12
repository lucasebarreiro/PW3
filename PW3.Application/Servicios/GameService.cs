using PW3.Application.Dto;
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
                Words = []
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

        public async Task<GameResult> GetGameResultAsync(int gameId, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetByIdAsync(gameId, cancellationToken) ?? throw new Exception("juego No Encontra2");
            return new GameResult
            {
                GameId = gameId,
                Usuario1Id = game.Usuario1Id,
                Usuario2Id = game.Usuario2Id,
                PuntuacionUsuario1 = game.PuntuacionUsuario1,
                PuntuacionUsuario2 = game.PuntuacionUsuario2,
                GanadorId = game.PuntuacionUsuario1 > game.PuntuacionUsuario2 ? game.Usuario1Id : game.Usuario2Id,
                Resultado = game.PuntuacionUsuario1 > game.PuntuacionUsuario2 ? "Ganó Usuario 1" :
                      game.PuntuacionUsuario1 < game.PuntuacionUsuario2 ? "Ganó Usuario 2" : "Empate"
            };
        }

        public async Task<bool> VerifyWordAsync(int gameId, string userId, string word, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetByIdAsync(gameId, cancellationToken);
            if (game == null)
            {
                throw new Exception("Juego no encontrado.");
            }

            var palabrasDelJuego = await _wordRepository.GetWordsPerGameIdAsync(gameId, cancellationToken);

            var palabraCorrecta = palabrasDelJuego.FirstOrDefault(p => p.Word.Equals(word, StringComparison.OrdinalIgnoreCase));
            if (palabraCorrecta == null)
            {
                return false;
            }

            // Encontrar al usuario que escribió la palabra (si es el Usuario1 o Usuario2)
            var usuario = userId == game.Usuario1Id.ToString() ? game.Usuario1Id : game.Usuario2Id;

            // Si la palabra es correcta, actualizar la puntuación del usuario correspondiente
            if (userId == game.Usuario1Id.ToString())
            {
                game.PuntuacionUsuario1++;
            }
            else
            {
                game.PuntuacionUsuario2++;
            }

            // Guardar el juego con la puntuación actualizada
            await _gameRepository.UpdateAsync(game, cancellationToken);

            return true;


        }

    }
}
