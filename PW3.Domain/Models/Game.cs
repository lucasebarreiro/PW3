using System.ComponentModel.DataAnnotations;

namespace PW3.Domain.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public int Usuario1Id { get; set; }
        public User? Usuario1 { get; set; }

        public int Usuario2Id { get; set; }
        public User? Usuario2 { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int DuracionEnSegundos { get; set; }
        public List<GameWord> Words { get; set; } = [];

        public int PuntuacionUsuario1 { get; set; }
        public int PuntuacionUsuario2 { get; set; }
    }
}
