using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.Modelos
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numero de Serie es requerido")]
        [MaxLength(60)]
        public string Activo_Serie { get; set; }

        [Required(ErrorMessage = "Descripcion es requerido")]
        [MaxLength(60)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Condicion es requerido")]
        [MaxLength(60)]
        public string Condicion { get; set; }

        [Required(ErrorMessage = "Ubicacion es requerido")]
        [MaxLength(60)]
        public string Ubicacion { get; set; }

        [Required(ErrorMessage = "Estado es requerido")]
        public bool EstadoP { get; set; }

        [Required(ErrorMessage = "Categoria es requerida")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "SubCategoria es requerida")]
        public int SubCategoriaId { get; set; }

        [ForeignKey("SubCategoriaId")]
        public SubCategoria SubCategoria { get; set; }

        [Required(ErrorMessage = "Marca es requerido")]
        public int MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }

        [Required(ErrorMessage = "Modelo es requerido")]
        public int ModeloPId { get; set; }

        [ForeignKey("ModeloPId")]
        public ModeloP ModeloP { get; set; }

    }
}
