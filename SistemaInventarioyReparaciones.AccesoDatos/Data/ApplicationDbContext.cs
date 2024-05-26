using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioyReparaciones.Modelos;
using System.Reflection;

namespace SistemaInventarioyReparaciones.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bodega> Bodegas { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<SubCategoria> SubCategorias { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<ModeloP> ModelosP { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<UsuarioApp> UsuarioApps { get; set; }

        public DbSet<BodegaProducto>BodegasProductos { get; set; }

        public DbSet<Inventario> Inventarios { get; set; }

        public DbSet<InventarioDetalle> InventariosDetalles { get; set; }

        public DbSet<KardexInventario> KardexInventarios { get; set; }

        public DbSet<DespachoProducto> DespachoProductos { get; set; }

        public DbSet<OrdenEgreso> OrdenesEgreso { get; set; }

        public DbSet<OrdenEgresoDetalle> OrdenesEgresoDetalles { get; set; }

        public DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}