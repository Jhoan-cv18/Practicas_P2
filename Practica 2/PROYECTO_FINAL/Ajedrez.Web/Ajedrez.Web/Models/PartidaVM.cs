namespace Ajedrez.Web.Models
{
    public class PartidaVM
    {
        public int Id { get; set; }

        public int JugadorBlancasId { get; set; }

        public int JugadorNegrasId { get; set; }

        public int TorneoId { get; set; }

        /// <summary>
        /// 1 = Ganan Blancas, 2 = Ganan Negras, 0 = Tablas
        /// </summary>
        public int Resultado { get; set; }

        public DateTime Fecha { get; set; }
    }
}