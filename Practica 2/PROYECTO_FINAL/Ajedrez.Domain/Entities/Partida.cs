using Ajedrez.Domain.Base;
using System;

namespace Ajedrez.Domain.Entities
{
    public class Partida : BaseEntity
    {
        public int JugadorBlancasId { get; set; }
        public int JugadorNegrasId { get; set; }
        public int TorneoId { get; set; }

        public Resultado Resultado { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;  // 🔥 necesario para historial
    }
}
