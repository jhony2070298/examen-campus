using EmpresaApp.Application.Dtos.Product;
using EmpresaApp.Application.Interfaces;
using EmpresaApp.Domain.Entities;
using EmpresaApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EmpresaApp.Persistence.Repositories
{
    public class ProductoRepository : IProductoRepository
    {

        private readonly AppDbContext _dbContext;

        public ProductoRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<GetProductsResponseDto>> GetProducts()
        {
            var products = await _dbContext.Productos.ToListAsync();
            var productDtos = products.Select(p => new GetProductsResponseDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock
            }).ToList();

            return productDtos;
        }
        public async Task<GetProductsResponseDto> GetProductById(int id)
        {
            var producto = await _dbContext.Productos.FindAsync(id);


            // Map Producto to GetProductsResponseDto
            var productDto = new GetProductsResponseDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                // Map other properties as necessary
            };

            return productDto;
        }


        public async Task CreateProduct(CreateProductRequestDto producto)
        {
            var product = new Producto
            {
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock,
                FechaCreacion = producto.FechaCreacion,
            };

            _dbContext.Productos.Add(product);
            await _dbContext.SaveChangesAsync();
        }

    }
}
