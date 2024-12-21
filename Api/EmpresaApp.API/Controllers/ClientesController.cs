using EmpresaApp.Application.Dtos.Client;
using EmpresaApp.Domain.Entities;
using EmpresaApp.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpresaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            var clientes = await _context.Cliente.ToListAsync();
            
            return clientes;
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

      

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(ClienteRequestDto cliente)
        {
            var clienteDto = new Cliente
            {
                Nombre = cliente.Nombre,
                Email = cliente.Email,
                FechaRegistro = DateTime.Now,
            };

            _context.Cliente.Add(clienteDto);
            await _context.SaveChangesAsync();

            var response = new ClienteCreateResponseDto
            {
                Nombre = clienteDto.Nombre,
                Email = clienteDto.Email
            };

            return CreatedAtAction("GetCliente", response);
        }

      
    }
}
