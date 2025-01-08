using PW3.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PW3.Domain.Models
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public int Score { get; set; } = 0;

    }
}
