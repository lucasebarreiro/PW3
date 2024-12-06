using System.ComponentModel.DataAnnotations;

namespace PW3.Domain.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public User Player1 { get; set; }
        public User Player2 { get; set; }
        public DateTime Gamedate { get; set; }
    }
}
