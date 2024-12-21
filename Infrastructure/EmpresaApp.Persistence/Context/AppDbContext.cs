using EmpresaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmpresaApp.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Cliente>  Cliente {  get; set; }  
        public DbSet<Producto>  Productos {  get; set; }  
        public DbSet<Pedido>  Pedidos {  get; set; }
        public DbSet<PedidoProductos>  PedidoProductos {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación muchos a muchos entre Pedido y Producto a través de ProductoPedido
            modelBuilder.Entity<PedidoProductos>()
                .HasKey(pp => new { pp.PedidoId, pp.ProductoId });

            // Relación entre Pedido y Producto a través de ProductoPedido
            modelBuilder.Entity<PedidoProductos>()
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.PedidoProductos)
                .HasForeignKey(pp => pp.PedidoId);

            modelBuilder.Entity<PedidoProductos>()
                .HasOne(pp => pp.Producto)
                .WithMany(p => p.ProductoPedidos)
                .HasForeignKey(pp => pp.ProductoId);
        }

    }
}
