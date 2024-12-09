using System.ComponentModel.DataAnnotations;

namespace PW3.Domain.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public List<User> Users { get; set; } = [];
        public List<GameWord> Words { get; set; } = [];
        public DateTime StartTime { get; set; }
        public DateTime Endtime { get; set; }
    }
}
