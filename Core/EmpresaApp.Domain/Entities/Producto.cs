namespace EmpresaApp.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Stock { get; set; }
        public DateTime FechaCreacion { get; set; }
         public ICollection<PedidoProductos> ProductoPedidos { get; set; }

    }
}
