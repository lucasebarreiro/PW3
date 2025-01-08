namespace PW3.Domain.Models;

public class GameWord
{
    public int Id { get; set; }
    public string? Word { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }
}
