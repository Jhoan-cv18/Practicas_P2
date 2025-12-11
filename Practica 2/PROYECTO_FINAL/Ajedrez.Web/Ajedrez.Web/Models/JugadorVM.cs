namespace Ajedrez.Web.Models
{
    public class JugadorVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Elo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}