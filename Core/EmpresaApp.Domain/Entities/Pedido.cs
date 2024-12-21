namespace EmpresaApp.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaPedido { get; set; }

        public decimal Total {  get; set; }
        public ICollection<PedidoProductos> PedidoProductos { get; set; }
        


    }
}
