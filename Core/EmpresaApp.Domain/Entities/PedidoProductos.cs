namespace EmpresaApp.Domain.Entities
{
    public class PedidoProductos
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }
    }
}
