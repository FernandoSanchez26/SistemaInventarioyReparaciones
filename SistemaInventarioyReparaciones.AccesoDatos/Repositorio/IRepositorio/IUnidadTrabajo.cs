using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        IBodegaRepositorio Bodega { get; }

        ICategoriaRepositorio Categoria { get; }

        ISubCategoriaRepositorio SubCategoria { get; }

        IMarcaRepositorio Marca { get; }

        IModeloPRepositorio ModeloP { get; }

        IProductoRepositorio Producto { get; }

        IUsuarioAppRepositorio UsuarioApp { get; }

        IBodegaProductoRepositorio BodegaProducto { get; }

        IInventarioRepositorio Inventario { get; }

        IInventarioDetalleRepositorio InventarioDetalle { get; }

        IKardexInventarioRepositorio KardexInventario { get; }

        IDespachoProductoRepositorio DespachoProducto { get; }

        IOrdenEgresoRepositorio OrdenEgreso { get; }

        IOrdenEgresoDetalleRepositorio OrdenEgresoDetalle { get; }

        IProveedorRepositorio Proveedor { get; }

        Task Guardar();
    }
}
