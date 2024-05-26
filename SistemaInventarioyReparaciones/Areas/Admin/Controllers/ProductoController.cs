using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaInventarioyReparaciones.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventarioyReparaciones.Modelos;
using SistemaInventarioyReparaciones.Modelos.ViewModels;
using SistemaInventarioyReparaciones.Utilidades;

namespace SistemaInventarioyReparaciones.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Role_Jefatura + "," + DS.Role_Adm_Inventario)]

    public class ProductoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        //private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductoController(IUnidadTrabajo unidadTrabajo/*, IWebHostEnvironment webHostEnvironment*/)
        {
            _unidadTrabajo = unidadTrabajo;
            //_webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            ProductoVM productoVM = new ProductoVM()
            {
                Producto = new Producto(),
                CategoriaLista = _unidadTrabajo.Producto.ObtenerTodosDropdownLista("Categoria"),
                SubCategoriaLista = _unidadTrabajo.Producto.ObtenerTodosDropdownLista("SubCategoria"),
                MarcaLista = _unidadTrabajo.Producto.ObtenerTodosDropdownLista("Marca"),
                ModeloPLista = _unidadTrabajo.Producto.ObtenerTodosDropdownLista("ModeloP")
            };

            if (id == null)
            {
                //Crear nuevo producto
                productoVM.Producto.EstadoP = true;
                return View(productoVM);
            }
            else
            {
                productoVM.Producto = await _unidadTrabajo.Producto.Obtener(id.GetValueOrDefault());

                if (productoVM.Producto == null)
                {
                    return NotFound();
                }
                return View(productoVM);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ProductoVM productoVM)
        {
            if (ModelState.IsValid)
            {
                
                if (productoVM.Producto.Id == 0)
                {
                    await _unidadTrabajo.Producto.Agregar(productoVM.Producto);
                    TempData[DS.Exitosa] = "Transaccion Exitosa";
                }
                else
                {
                    //var objProducto = await _unidadTrabajo.Producto.ObtenerPrimero(p => p.Id == productoVM.Producto.Id, istracking: false);
                    _unidadTrabajo.Producto.Actualizar(productoVM.Producto);
                    TempData[DS.Exitosa] = "Producto actualizado Exitosamente";
                }
                
                await _unidadTrabajo.Guardar();
                return View("Index");
            }//if not valid
            productoVM.CategoriaLista = _unidadTrabajo.Producto.ObtenerTodosDropdownLista("Categoria");
            productoVM.SubCategoriaLista = _unidadTrabajo.Producto.ObtenerTodosDropdownLista("SubCategoria");
            productoVM.MarcaLista = _unidadTrabajo.Producto.ObtenerTodosDropdownLista("Marca");
            productoVM.ModeloPLista = _unidadTrabajo.Producto.ObtenerTodosDropdownLista("ModeloP");
            TempData[DS.Error] = "Error al grabar Producto";

            return View(productoVM);
        }




        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Producto.ObtenerTodos(incluirPropiedades: "Categoria,SubCategoria,Marca,ModeloP");
            return Json(new { data = todos });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var productoDB = await _unidadTrabajo.Producto.Obtener(id);
            if (productoDB == null)
            {
                return Json(new { success = false, message = "Error al borrar producto" });
            }

            ////Remover imagen
            //string upload = _webHostEnvironment.WebRootPath + DS.ImagenRuta;
            //var anteriorFile = Path.Combine(upload, productoDB.ImagenUrl);
            //if (System.IO.File.Exists(anteriorFile))
            //{
            //    System.IO.File.Delete(anteriorFile);
            //}

            _unidadTrabajo.Producto.Remover(productoDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Producto borrado exitosamente" });
        }

        [ActionName("ValidarActivoSerie")]
        public async Task<IActionResult> ValidarActivoSerie(string activoserie, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Producto.ObtenerTodos();
            if (id == 0)
            {
                valor = lista.Any(b => b.Activo_Serie.ToLower().Trim() == activoserie.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Activo_Serie.ToLower().Trim() == activoserie.ToLower().Trim() && b.Id != id);
            }
            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }

        #endregion
    }
}


