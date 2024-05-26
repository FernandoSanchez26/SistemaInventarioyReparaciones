using SistemaInventarioyReparaciones.AccesoDatos.Data;
using SistemaInventarioyReparaciones.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;

        public IBodegaRepositorio Bodega { get; private set; }
        public ICategoriaRepositorio Categoria { get; private set; }
        public ISubCategoriaRepositorio SubCategoria { get; private set; }
        public IMarcaRepositorio Marca { get; private set; }
        public IModeloPRepositorio ModeloP { get; private set; }
        public IProductoRepositorio Producto { get; private set; }
        public IUsuarioAppRepositorio UsuarioApp { get; private set; }
        public IBodegaProductoRepositorio BodegaProducto { get; private set; }
        public IInventarioRepositorio Inventario { get; private set; }
        public IInventarioDetalleRepositorio InventarioDetalle { get; private set; }
        public IKardexInventarioRepositorio KardexInventario { get; private set; }
        public IDespachoProductoRepositorio DespachoProducto { get; private set; }
        public IOrdenEgresoRepositorio OrdenEgreso { get; private set; }
        public IOrdenEgresoDetalleRepositorio OrdenEgresoDetalle { get; private set; }
        public IProveedorRepositorio Proveedor { get; private set; }


        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Bodega = new BodegaRepositorio(_db);
            Categoria = new CategoriaRepositorio(_db);
            SubCategoria = new SubCategoriaRepositorio(_db);
            Marca = new MarcaRepositorio(_db);
            ModeloP = new ModeloPRepositorio(_db);
            Producto = new ProductoRepositorio(_db);
            UsuarioApp = new UsuarioAppRepositorio(_db);
            BodegaProducto = new BodegaProductoRepositorio(_db);
            Inventario = new InventarioRepositorio(_db);
            InventarioDetalle = new InventarioDetalleRepositorio(_db);
            KardexInventario = new KardexInventarioRepositorio(_db);
            DespachoProducto = new DespachoProductoRepositorio(_db);
            OrdenEgreso = new OrdenEgresoRepositorio(_db);
            OrdenEgresoDetalle = new OrdenEgresoDetalleRepositorio(_db);
            Proveedor = new ProveedorRepositorio(_db);
        }


        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();

        }
    }
}
