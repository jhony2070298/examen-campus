namespace EmpresaApp.Application.Dtos.Product
{
    public class GetProductsResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Stock { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
