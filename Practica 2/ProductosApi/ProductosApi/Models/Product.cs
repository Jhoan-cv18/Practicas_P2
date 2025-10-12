namespace ProductosApi.Models
{
    public class Product
    {
        public int Id { get; set; }          // Identificador único
        public string Name { get; set; } = ""; // Nombre del producto
        public decimal Price { get; set; }     // Precio
        public int Stock { get; set; }         // Cantidad disponible
    }
}