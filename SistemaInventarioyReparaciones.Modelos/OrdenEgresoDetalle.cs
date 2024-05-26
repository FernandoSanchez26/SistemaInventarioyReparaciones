using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.Modelos
{
    public class OrdenEgresoDetalle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrdenEgresoId { get; set; }

        [ForeignKey("OrdenEgresoId")]
        public OrdenEgreso OrdenEgreso { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }

        
    }
}
