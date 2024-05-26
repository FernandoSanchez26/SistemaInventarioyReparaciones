using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaInventarioyReparaciones.AccesoDatos.Data;
using SistemaInventarioyReparaciones.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventarioyReparaciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.AccesoDatos.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public ProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Producto producto)
        {
            var productoBD = _db.Productos.FirstOrDefault(b => b.Id == producto.Id);
            if (productoBD != null)
            {
                productoBD.Activo_Serie = producto.Activo_Serie;
                productoBD.Descripcion = producto.Descripcion;
                productoBD.Condicion = producto.Condicion;
                productoBD.Ubicacion = producto.Ubicacion;
                productoBD.EstadoP = producto.EstadoP;
                productoBD.CategoriaId = producto.CategoriaId;
                productoBD.SubCategoriaId = producto.SubCategoriaId;
                productoBD.MarcaId = producto.MarcaId;
                productoBD.ModeloPId = producto.ModeloPId;

                _db.SaveChanges();
            }
        }


        public IEnumerable<SelectListItem> ObtenerTodosDropdownLista(string obj)
        {
            if (obj == "Categoria")
            {
                return _db.Categorias.Where(c => c.EstadoC == true).Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                });
            }
            if (obj == "SubCategoria")
            {
                return _db.SubCategorias.Where(c => c.EstadoSC == true).Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                });
            }
            if (obj == "Marca")
            {
                return _db.Marcas.Where(c => c.EstadoM == true).Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                });
            }
            if (obj == "ModeloP")
            {
                return _db.ModelosP.Where(c => c.EstadoMP == true).Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                });
            }
            if (obj == "Producto")
            {
                return _db.Productos.Where(c => c.EstadoP == true).Select(c => new SelectListItem
                {
                    Text = c.Descripcion,
                    Value = c.Id.ToString()
                });
            }
            return null;
        }

    }
}
