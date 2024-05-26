using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaInventarioyReparaciones.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventarioyReparaciones.Modelos;
using SistemaInventarioyReparaciones.Utilidades;

namespace SistemaInventarioyReparaciones.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Role_Jefatura)]

    public class SubCategoriaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public SubCategoriaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            SubCategoria subCategoria = new SubCategoria();
            

            if (id == null) //Se trata de crear una nueva categoria
            {
                subCategoria.EstadoSC = true;
                subCategoria.FechaRegistro = DateTime.Now;
                return View(subCategoria);
            }
            //si no es nueva es una actualizacion

            subCategoria = await _unidadTrabajo.SubCategoria.Obtener(id.GetValueOrDefault());
            if (subCategoria == null)
            {
                return NotFound();
            }
            return View(subCategoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(SubCategoria subCategoria)
        {
            if (ModelState.IsValid)
            {
                if (subCategoria.Id == 0)
                {
                    subCategoria.FechaRegistro = DateTime.Now;
                    await _unidadTrabajo.SubCategoria.Agregar(subCategoria);
                    TempData[DS.Exitosa] = "SubCategoria creada Exitosamente";
                }
                else
                {
                    _unidadTrabajo.SubCategoria.Actualizar(subCategoria);
                    TempData[DS.Exitosa] = "SubCategoria actualizada Exitosamente";
                }
                
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al grabar SubCategoria";
            return View(subCategoria);
        }




        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.SubCategoria.ObtenerTodos();
            return Json(new { data = todos });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var subCategoriaDB = await _unidadTrabajo.SubCategoria.Obtener(id);
            if (subCategoriaDB == null)
            {
                return Json(new { success = false, message = "Error al borrar SubCategoria" });
            }
            _unidadTrabajo.SubCategoria.Remover(subCategoriaDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "SubCategoria borrada exitosamente" });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.SubCategoria.ObtenerTodos();
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

