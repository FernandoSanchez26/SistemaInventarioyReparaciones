using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.Modelos
{
    public class KardexInventario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BodegaProductoId { get; set; }

        [ForeignKey("BodegaProductoId")]
        public BodegaProducto BodegaProducto { get; set; }

        [Required]
        [MaxLength(100)]
        public string Tipo { get; set; } //Entrada -Salida

        [Required]
        public string Detalle { get; set; }

        [Required]
        public int StockAnterior { get; set; }

        [Required]
        public int Cantidad { get; set; }                

        [Required]
        public int Stock { get; set; }        

        [Required]
        public string UsuarioAppId { get; set; }

        [ForeignKey("UsuarioAppId")]
        public UsuarioApp UsuarioApp { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}
