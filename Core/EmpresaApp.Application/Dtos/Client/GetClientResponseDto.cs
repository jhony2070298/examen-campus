namespace EmpresaApp.Application.Dtos.Client
{
    public class GetClientResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
