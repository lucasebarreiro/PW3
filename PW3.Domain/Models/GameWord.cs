using System.ComponentModel.DataAnnotations;

namespace PW3.Domain.Models;

public class GameWord
{
    [Key]
    public int Id { get; set; }

    public string? Word { get; set; }
    public int GameId { get; set; }
    public Game? Game { get; set; }
}
