using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.Modelos.ViewModels
{
    public class DespachoProductoVM
    {        

        public Producto Producto { get; set; }

        public int Stock { get; set; }

        public DespachoProducto DespachoProducto { get; set; }

        public IEnumerable<DespachoProducto> DespachoProductoLista { get; set; }

        public OrdenEgreso OrdenEgreso { get; set; }
    }
}
