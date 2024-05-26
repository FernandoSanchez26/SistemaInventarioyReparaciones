using SistemaInventarioyReparaciones.AccesoDatos.Data;
using SistemaInventarioyReparaciones.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventarioyReparaciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.AccesoDatos.Repositorio
{
    public class SubCategoriaRepositorio : Repositorio<SubCategoria>, ISubCategoriaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public SubCategoriaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(SubCategoria subCategoria)
        {
            var subcategoriaBD = _db.SubCategorias.FirstOrDefault(b => b.Id == subCategoria.Id);
            if (subcategoriaBD != null)
            {
                subcategoriaBD.Nombre = subCategoria.Nombre;
                subcategoriaBD.EstadoSC = subCategoria.EstadoSC;
                subcategoriaBD.FechaRegistro = subCategoria.FechaRegistro;
                _db.SaveChanges();
            }
        }
    }
}
