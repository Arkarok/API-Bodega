using Api_Bodega_DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Bodega_DB.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Producto { get; set; }
    }
}
