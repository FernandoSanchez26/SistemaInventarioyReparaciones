using Microsoft.AspNetCore.Mvc;
using SistemaInventarioyReparaciones.AccesoDatos.Repositorio;
using SistemaInventarioyReparaciones.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventarioyReparaciones.Modelos.ViewModels;
using SistemaInventarioyReparaciones.Utilidades;
using System.Diagnostics;
using System.Security.Claims;

namespace SistemaInventarioyReparaciones.Areas.Inventario.Controllers
{
    [Area("Inventario")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly IUnidadTrabajo _unidadTrabajo;//**ojo

        public HomeController(ILogger<HomeController> logger, IUnidadTrabajo unidadTrabajo)//**ojo
        {
            _logger = logger;
            _unidadTrabajo = unidadTrabajo;//**ojo
        }

        public async Task <IActionResult> Index()
        {
            // Controlar sesion
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var despachoLista = await _unidadTrabajo.DespachoProducto.ObtenerTodos(c => c.UsuarioAppId == claim.Value);
                var numeroProductos = despachoLista.Count();  // Numero de Registros
                HttpContext.Session.SetInt32(DS.ssdespachoProducto, numeroProductos);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}