using Ajedrez.Domain.Base;
using System;
using System.Collections.Generic;

namespace Ajedrez.Domain.Entities
{
    public class Torneo : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public List<Partida> Partidas { get; set; } = new List<Partida>();

    }
}
