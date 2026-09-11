using Api_Bodega_DB.DB;
using Api_Bodega_DB.Interfaces;
using Api_Bodega_DB.Models;
using Api_Bodega_DB.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Api_Bodega_DB.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateProducto(ProductoDto item)
        {
            Producto nuevoProducto = new()
            {
                Nombre = item.Nombre,
                Cantidad = item.Cantidad,
                Valor = item.Valor,
            };

            await _context.Producto.AddAsync(nuevoProducto);
            await _context.SaveChangesAsync();

            return "El producto fue creado con exito.";
        }

        public async Task<string> DeleteProducto(int id)
        {
            var productoExiste = await _context.Producto.FirstOrDefaultAsync(x => x.Id == id);

            if(productoExiste == null)
            {
                throw new ArgumentException("El producto no se encuentra registrado.");
            }

            _context.Producto.Remove(productoExiste);
            await _context.SaveChangesAsync();

            return "El producto fue eliminado con exito.";
        }

        public async Task<Producto> GetProducto(int id)
        {
            return await _context.Producto.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Producto>> GetProductos()
        {
            return await _context.Producto.ToListAsync();
        }

        public async Task<string> UpdateProducto(ProductoDto item, int id)
        {
            var productoExiste = await _context.Producto.FirstOrDefaultAsync(x =>x.Id == id);

            if( productoExiste == null)
            {
                throw new ArgumentException("El producto no se encuentra registrado.");
            }

            productoExiste.Cantidad = item.Cantidad;
            productoExiste.Valor = item.Valor;

            await _context.SaveChangesAsync();

            return "El producto fue actualizado con exito.";
        }
    }
}
