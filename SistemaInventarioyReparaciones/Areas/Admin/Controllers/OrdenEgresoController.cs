using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaInventarioyReparaciones.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventarioyReparaciones.Modelos.ViewModels;
using SistemaInventarioyReparaciones.Utilidades;
using System.Security.Claims;

namespace SistemaInventarioyReparaciones.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrdenEgresoController : Controller
    {

        private readonly IUnidadTrabajo _unidadTrabajo;

        [BindProperty]
        public OrdenEgresoDetalleVM ordenEgresoDetalleVM { get; set; }

        public OrdenEgresoController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detalle(int id)
        {
            ordenEgresoDetalleVM = new OrdenEgresoDetalleVM()
            {
                OrdenEgreso = await _unidadTrabajo.OrdenEgreso.ObtenerPrimero(o => o.Id == id, incluirPropiedades: "UsuarioApp"),
                OrdenEgresoDetalleLista = await _unidadTrabajo.OrdenEgresoDetalle.ObtenerTodos(d => d.OrdenEgresoId == id,
                                                                                   incluirPropiedades: "Producto")
            };
            return View(ordenEgresoDetalleVM);
        }

        #region API

        [HttpGet]
        //public async Task<IActionResult> ObtenerOrdenEgresoLista()
        public async Task<IActionResult> ObtenerTodos()
        {      
            
            var todos = await _unidadTrabajo.OrdenEgreso.ObtenerTodos(incluirPropiedades: "UsuarioApp");

            return Json(new { data = todos });
        }

        #endregion
    }
}
