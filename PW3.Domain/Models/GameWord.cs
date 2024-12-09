namespace PW3.Domain.Models;

public class GameWord
{
    public int Id { get; set; }
    public string? Word { get; set; }
    public bool IsGuessed { get; set; }
    public int GameSessionId { get; set; }
    public Room? Room { get; set; }
}
