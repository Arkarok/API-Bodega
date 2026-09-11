using Api_Bodega_DB.Models;
using Api_Bodega_DB.Models.Dtos;

namespace Api_Bodega_DB.Interfaces
{
    public interface IProductoRepository
    {
        public Task<List<Producto>> GetProductos();
        public Task<Producto> GetProducto(int id);
        public Task<string> CreateProducto(ProductoDto item);
        public Task<string> UpdateProducto(ProductoDto item, int id);
        public Task<string> DeleteProducto(int id);
    }
}
