using Microsoft.AspNetCore.SignalR;
using PW3.Application.Servicios;

namespace PW3.Presentation.Hubs;

public class GameHub(IGameService _gameService) : Hub
{
    public async Task JoinGame(int gameId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"game-{gameId}");
        await Clients.Group($"game-{gameId}").SendAsync("UserJoined", $"{Context.ConnectionId} se ha unido al juego {gameId}");
    }

    // Enviar una palabra a los usuarios del juego
    public async Task SendWord(int gameId, string word)
    {
        await Clients.Group($"game-{gameId}").SendAsync("NewWord", word);
    }

    // Recibir la palabra escrita por un usuario y verificar si es correcta
    public async Task SubmitWord(int gameId, string userId, string word, CancellationToken cancellationToken)
    {
        // aca llamar al servicio para verificar la palabra y actualizar la puntuación
        var isCorrect = await _gameService.VerifyWordAsync(gameId, userId, word, cancellationToken);
        if (isCorrect)
        {
            await Clients.Group($"game-{gameId}").SendAsync("WordCorrect", userId);
        }
        else
        {
            await Clients.Group($"game-{gameId}").SendAsync("WordIncorrect", userId);
        }
    }

    public async Task ActualizarPuntuacion(int juegoId, int puntuacionUsuario1, int puntuacionUsuario2)
    {
        await Clients.All.SendAsync("ActualizarPuntuacion", puntuacionUsuario1, puntuacionUsuario2);
    }

    // Notificar final del juego?
    public async Task EndGame(int gameId, CancellationToken cancellationToken)
    {
        var gameResult = await _gameService.GetGameResultAsync(gameId, cancellationToken);
        await Clients.Group($"game-{gameId}").SendAsync("GameEnded", gameResult);
    }
}
