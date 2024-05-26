using Microsoft.AspNetCore.Mvc;
using SistemaInventarioyReparaciones.AccesoDatos.Repositorio;
using SistemaInventarioyReparaciones.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventarioyReparaciones.Modelos;
using SistemaInventarioyReparaciones.Modelos.ViewModels;
using SistemaInventarioyReparaciones.Utilidades;
using System.Security.Claims;

namespace SistemaInventarioyReparaciones.Areas.Inventario.Controllers
{
    [Area("Inventario")]

    public class DespachoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        private string _webUrl;

        [BindProperty]
        public DespachoProductoVM despachoProductoVM { get; set; }

        public DespachoController(IUnidadTrabajo unidadTrabajo, IConfiguration configuration)
        {
            _unidadTrabajo = unidadTrabajo;

        }

        public async Task<IActionResult> Index()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            despachoProductoVM = new DespachoProductoVM();
            despachoProductoVM.OrdenEgreso = new SistemaInventarioyReparaciones.Modelos.OrdenEgreso();
            despachoProductoVM.DespachoProductoLista = await _unidadTrabajo.DespachoProducto.ObtenerTodos(
                                                u => u.UsuarioAppId == claim.Value,
                                                incluirPropiedades: "Producto");

            despachoProductoVM.OrdenEgreso.UsuarioAppId = claim.Value;

            
            return View(despachoProductoVM);
        }

        public async Task<IActionResult> mas(int despachoId)
        {
            var despachoProductos = await _unidadTrabajo.DespachoProducto.ObtenerPrimero(d => d.Id == despachoId);
            despachoProductos.Cantidad += 1;
            await _unidadTrabajo.Guardar();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> menos(int despachoId)
        {
            var despachoProductos = await _unidadTrabajo.DespachoProducto.ObtenerPrimero(d => d.Id == despachoId);

            if (despachoProductos.Cantidad == 1)
            {
                // Removemos el Registro del Carro de Compras y actualizamos la sesion
                var despachoLista = await _unidadTrabajo.DespachoProducto.ObtenerTodos(
                                                d => d.UsuarioAppId == despachoProductos.UsuarioAppId);
                var numeroProductos = despachoLista.Count();
                _unidadTrabajo.DespachoProducto.Remover(despachoProductos);
                await _unidadTrabajo.Guardar();
                HttpContext.Session.SetInt32(DS.ssdespachoProducto, numeroProductos - 1);
            }
            else
            {
                despachoProductos.Cantidad -= 1;
                await _unidadTrabajo.Guardar();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> remover(int despachoId)
        {
            // Remueve el Registro del Carro de Compras y Actualiza la sesion
            var despachoProductos = await _unidadTrabajo.DespachoProducto.ObtenerPrimero(d => d.Id == despachoId);
            var despachoLista = await _unidadTrabajo.DespachoProducto.ObtenerTodos(
                                               d => d.UsuarioAppId == despachoProductos.UsuarioAppId);
            var numeroProductos = despachoLista.Count();
            _unidadTrabajo.DespachoProducto.Remover(despachoProductos);
            await _unidadTrabajo.Guardar();
            HttpContext.Session.SetInt32(DS.ssdespachoProducto, numeroProductos - 1);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Proceder()
        {
            var claimIdentidad = (ClaimsIdentity)User.Identity;
            var claim = claimIdentidad.FindFirst(ClaimTypes.NameIdentifier);

            despachoProductoVM = new DespachoProductoVM()
            {
                OrdenEgreso = new SistemaInventarioyReparaciones.Modelos.OrdenEgreso(),
                DespachoProductoLista = await _unidadTrabajo.DespachoProducto.ObtenerTodos(
                             d => d.UsuarioAppId == claim.Value, incluirPropiedades: "Producto")
            };


            despachoProductoVM.OrdenEgreso.UsuarioApp = await _unidadTrabajo.UsuarioApp.ObtenerPrimero(u => u.Id ==
                                                                                                           claim.Value);


            despachoProductoVM.OrdenEgreso.UsuarioApp.Nombres = despachoProductoVM.OrdenEgreso.UsuarioApp.Nombres + " " +
                                                 despachoProductoVM.OrdenEgreso.UsuarioApp.Apellidos;
            

            // Controlar Stock
            foreach (var lista in despachoProductoVM.DespachoProductoLista)
            {
                // Capturar el Stock de cada Producto
                var producto = await _unidadTrabajo.BodegaProducto.ObtenerPrimero(b => b.ProductoId == lista.ProductoId);
                if (lista.Cantidad > producto.Cantidad)
                {
                    TempData[DS.Error] = "La Cantidad del Producto " + lista.Producto.Descripcion +
                                        " Excede al Stock actual (" + producto.Cantidad + ")";
                    return RedirectToAction("Index");
                }
            }
            return View(despachoProductoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Proceder(DespachoProductoVM despachoProductoVM)
        {
            var claimIdentidad = (ClaimsIdentity)User.Identity;
            var claim = claimIdentidad.FindFirst(ClaimTypes.NameIdentifier);

            despachoProductoVM.DespachoProductoLista = await _unidadTrabajo.DespachoProducto.ObtenerTodos(
                                                 c => c.UsuarioAppId == claim.Value,
                                                 incluirPropiedades: "Producto");

            despachoProductoVM.OrdenEgreso.UsuarioAppId = claim.Value;
            despachoProductoVM.OrdenEgreso.FechaOrden = DateTime.Now;

            // Controlar Stock
            foreach (var lista in despachoProductoVM.DespachoProductoLista)
            {
                var producto = await _unidadTrabajo.BodegaProducto.ObtenerPrimero(b => b.ProductoId == lista.ProductoId);
                if (lista.Cantidad > producto.Cantidad)
                {
                    TempData[DS.Error] = "La Cantidad del Producto " + lista.Producto.Descripcion +
                                        " Excede al Stock actual (" + producto.Cantidad + ")";
                    return RedirectToAction("Index");
                }
            }

            await _unidadTrabajo.OrdenEgreso.Agregar(despachoProductoVM.OrdenEgreso);
            await _unidadTrabajo.Guardar();

            // Grabar Detalle Orden Egreso
            foreach (var lista in despachoProductoVM.DespachoProductoLista)
            {
                OrdenEgresoDetalle ordenEgresoDetalle = new OrdenEgresoDetalle()
                {
                    ProductoId = lista.ProductoId,
                    OrdenEgresoId = despachoProductoVM.OrdenEgreso.Id,
                    Cantidad = lista.Cantidad
                };
                await _unidadTrabajo.OrdenEgresoDetalle.Agregar(ordenEgresoDetalle);
                await _unidadTrabajo.Guardar();

            }
            return RedirectToAction("OrdenEgresoConfirmacion", new { id = despachoProductoVM.OrdenEgreso.Id });
        }

        public async Task <IActionResult> OrdenEgresoConfirmacion(int id)
        {
            var ordenEgreso = await _unidadTrabajo.OrdenEgreso.ObtenerPrimero(o => o.Id == id, incluirPropiedades: "UsuarioApp");
            var despachoProducto = await _unidadTrabajo.DespachoProducto.ObtenerTodos(u => u.UsuarioAppId == ordenEgreso.UsuarioAppId);

            // Disminuir Stock de la Bodega de Venta
            

            foreach (var lista in despachoProducto)
            {
                var bodegaProducto = new BodegaProducto();
                bodegaProducto = await _unidadTrabajo.BodegaProducto.ObtenerPrimero(b => b.ProductoId == lista.ProductoId);
                
                await _unidadTrabajo.KardexInventario.RegistrarKardex(bodegaProducto.Id, "Salida",
                                                                      "Egreso - Orden# " + id,
                                                                      bodegaProducto.Cantidad,
                                                                      lista.Cantidad,
                                                                      ordenEgreso.UsuarioAppId);
                bodegaProducto.Cantidad -= lista.Cantidad;
                await _unidadTrabajo.Guardar();
            }

            // Borramos el Carro de Compra y la Session del Carro de Compras

            List<DespachoProducto> despachoProductoLista = despachoProducto.ToList();

            _unidadTrabajo.DespachoProducto.RemoverRango(despachoProductoLista);
            await _unidadTrabajo.Guardar();
            HttpContext.Session.SetInt32(DS.ssdespachoProducto, 0);

            return View(id);
        }
    }
        
    
}
