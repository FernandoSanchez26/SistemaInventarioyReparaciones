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
    public class ModeloPRepositorio : Repositorio<ModeloP>, IModeloPRepositorio
    {
        private readonly ApplicationDbContext _db;

        public ModeloPRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(ModeloP modeloP)
        {
            var modeloPBD = _db.ModelosP.FirstOrDefault(b => b.Id == modeloP.Id);
            if (modeloPBD != null)
            {
                modeloPBD.Nombre = modeloP.Nombre;
                modeloPBD.EstadoMP = modeloP.EstadoMP;
                modeloPBD.FechaRegistro = modeloP.FechaRegistro;
                _db.SaveChanges();
            }
        }
    }
}
