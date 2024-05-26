using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.Modelos.ViewModels
{
    public class OrdenEgresoDetalleVM
    {
        public OrdenEgreso OrdenEgreso  { get; set; }

        public IEnumerable<OrdenEgresoDetalle> OrdenEgresoDetalleLista { get; set; }
    }
}
