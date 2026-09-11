using Api_Bodega_DB.Interfaces;
using Api_Bodega_DB.Models;
using Api_Bodega_DB.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api_Bodega_DB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet("GetProductos")]
        public async Task<List<Producto>> Get()
        {
            return await _productoRepository.GetProductos();
        }

        [HttpGet("GetProducto/{id}")]
        public async Task<Producto> GetProducto([FromRoute] int id)
        {
            return await _productoRepository.GetProducto(id);
        }

        [HttpPost("CreateProducto")]
        public async Task<string> Post([FromBody] ProductoDto item)
        {
            var respuesta = await _productoRepository.CreateProducto(item);
            return respuesta;
        }

        [HttpPut("UpdateProducto/{idProducto}")]
        public async Task<string> Put([FromRoute] int idProducto, [FromBody] ProductoDto item)
        {
            var respuesta = await _productoRepository.UpdateProducto(item, idProducto);
            return respuesta;
        }

        [HttpDelete("DeleteProducto/{idProducto}")]
        public async Task<string> Delete([FromRoute] int idProducto)
        {
            var respuesta = await _productoRepository.DeleteProducto(idProducto);
            return respuesta;
        }
    }
}
