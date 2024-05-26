using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaInventarioyReparaciones.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventarioyReparaciones.Modelos;
using SistemaInventarioyReparaciones.Utilidades;

namespace SistemaInventarioyReparaciones.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Role_Jefatura)]

    public class ProveedorController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public ProveedorController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.FechaRegistro = DateTime.Now;

            if (id == null) //Se trata de crear una nueva categoria
            {
                proveedor.EstadoProv = true;
                return View(proveedor);
            }
            //si no es nueva es una actualizacion

            proveedor = await _unidadTrabajo.Proveedor.Obtener(id.GetValueOrDefault());
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                if (proveedor.Id == 0)
                {
                    await _unidadTrabajo.Proveedor.Agregar(proveedor);
                    TempData[DS.Exitosa] = "Proveedor creado Exitosamente";
                }
                else
                {
                    _unidadTrabajo.Proveedor.Actualizar(proveedor);
                    TempData[DS.Exitosa] = "Proveedor actualizado Exitosamente";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al grabar Proveedor";
            return View(proveedor);
        }




        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Proveedor.ObtenerTodos();
            return Json(new { data = todos });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var proveedorDB = await _unidadTrabajo.Proveedor.Obtener(id);
            if (proveedorDB == null)
            {
                return Json(new { success = false, message = "Error al borrar Proveedor" });
            }
            _unidadTrabajo.Proveedor.Remover(proveedorDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Proveedor borrado exitosamente" });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Proveedor.ObtenerTodos();
            if (id == 0)
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim() && b.Id != id);
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

