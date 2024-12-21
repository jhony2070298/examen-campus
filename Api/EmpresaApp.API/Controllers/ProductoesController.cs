using EmpresaApp.Application.Dtos.Product;
using EmpresaApp.Domain.Entities;
using EmpresaApp.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpresaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductoesController(AppDbContext context)
        {
            _context = context;
        }



        // GET: api/Productoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProductsResponseDto>>> GetProductos()
        {
            var products = await _context.Productos.ToListAsync();

            var productDtos = products.Select(p => new GetProductsResponseDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock
            }).ToList();

            return productDtos;
        }

        // GET: api/Productoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductsResponseDto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

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

        // PUT: api/Productoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Productoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(CreateProductRequestDto producto)
        {
            var product = new Producto
            {
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock,
                FechaCreacion = producto.FechaCreacion,
            };

            _context.Productos.Add(product);
            await _context.SaveChangesAsync();

            // Usar el ID del producto recién creado en el CreatedAtAction
            return CreatedAtAction("GetProducto", new { id = product.Id }, product);
        }

        // DELETE: api/Productoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
