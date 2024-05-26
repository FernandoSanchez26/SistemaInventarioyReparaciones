using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.Modelos
{
    public class UsuarioApp : IdentityUser
    {
        [Required(ErrorMessage = "Nombres es Requerido")]
        [MaxLength(80)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Apellidos es Requerido")]
        [MaxLength(80)]
        public string Apellidos { get; set; }

        [NotMapped]  // No se agrega a la tabla
        public string Role { get; set; }
    }
}
