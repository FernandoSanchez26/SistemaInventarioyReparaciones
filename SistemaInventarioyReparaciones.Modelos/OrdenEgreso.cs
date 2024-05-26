using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.Modelos
{
    public class OrdenEgreso
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UsuarioAppId { get; set; }

        [ForeignKey("UsuarioAppId")]
        public UsuarioApp UsuarioApp { get; set; }

        public DateTime FechaOrden { get; set; }

        public string NumeroOficio { get; set; }

        public string NombreRecibe { get; set; }

        public string Oficina { get; set; }

        public string Observaciones { get; set; }
    }
}
