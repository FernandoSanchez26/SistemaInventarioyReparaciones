using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.Modelos
{
    public class DespachoProducto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UsuarioAppId { get; set; }

        [ForeignKey("UsuarioAppId")]
        public UsuarioApp UsuarioApp { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [NotMapped]
        public int TotalProductos { get; set; }
    }
}
