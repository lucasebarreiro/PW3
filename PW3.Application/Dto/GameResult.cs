namespace PW3.Application.Dto
{
    public class GameResult
    {
        public int GameId { get; set; }
        public int Usuario1Id { get; set; }
        public int Usuario2Id { get; set; }
        public int PuntuacionUsuario1 { get; set; }
        public int PuntuacionUsuario2 { get; set; }
        public int GanadorId { get; set; }
        public string? Resultado { get; set; }
    }
}
