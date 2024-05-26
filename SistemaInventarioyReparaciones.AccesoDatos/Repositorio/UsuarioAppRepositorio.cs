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
    public class UsuarioAppRepositorio : Repositorio<UsuarioApp>, IUsuarioAppRepositorio
    {
        private readonly ApplicationDbContext _db;

        public UsuarioAppRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

       
    }
}
