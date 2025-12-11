using Ajedrez.Domain.Base;

namespace Ajedrez.Domain.Entities
{
    public class Jugador : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;

       
        public int ELO { get; set; } = 1000;

        public Jugador() { }
    }
}