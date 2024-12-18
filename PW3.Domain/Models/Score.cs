namespace PW3.Domain.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int Points { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
