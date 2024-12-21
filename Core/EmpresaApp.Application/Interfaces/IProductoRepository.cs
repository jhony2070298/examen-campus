using EmpresaApp.Application.Dtos.Product;

namespace EmpresaApp.Application.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<GetProductsResponseDto>> GetProducts();
        Task CreateProduct(CreateProductRequestDto producto);
        Task<GetProductsResponseDto> GetProductById(int id);
    }
}
