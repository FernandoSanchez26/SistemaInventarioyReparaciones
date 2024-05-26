using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaInventarioyReparaciones.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventarioyReparaciones.Modelos;
using SistemaInventarioyReparaciones.Utilidades;

namespace SistemaInventarioyReparaciones.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Role_Jefatura)]

    public class ModeloPController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public ModeloPController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            ModeloP modeloP = new ModeloP();
            modeloP.FechaRegistro = DateTime.Now;

            if (id == null) //Se trata de crear una nueva categoria
            {
                modeloP.EstadoMP = true;
                return View(modeloP);
            }
            //si no es nueva es una actualizacion

            modeloP = await _unidadTrabajo.ModeloP.Obtener(id.GetValueOrDefault());
            if (modeloP == null)
            {
                return NotFound();
            }
            return View(modeloP);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ModeloP modeloP)
        {
            if (ModelState.IsValid)
            {
                if (modeloP.Id == 0)
                {
                    await _unidadTrabajo.ModeloP.Agregar(modeloP);
                    TempData[DS.Exitosa] = "Modelo creada Exitosamente";
                }
                else
                {
                    _unidadTrabajo.ModeloP.Actualizar(modeloP);
                    TempData[DS.Exitosa] = "Modelo actualizada Exitosamente";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al grabar Categoria";
            return View(modeloP);
        }


        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.ModeloP.ObtenerTodos();
            return Json(new { data = todos });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var modeloP = await _unidadTrabajo.ModeloP.Obtener(id);
            if (modeloP == null)
            {
                return Json(new { success = false, message = "Error al borrar Marca" });
            }
            _unidadTrabajo.ModeloP.Remover(modeloP);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Modelo borrada exitosamente" });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.ModeloP.ObtenerTodos();
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

