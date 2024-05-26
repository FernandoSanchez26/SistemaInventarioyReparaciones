using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
    public class OrdenEgresoDetalleRepositorio : Repositorio<OrdenEgresoDetalle>, IOrdenEgresoDetalleRepositorio
    {
        private readonly ApplicationDbContext _db;

        public OrdenEgresoDetalleRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(OrdenEgresoDetalle ordenEgresoDetalle)
        {
            _db.Update(ordenEgresoDetalle);
        }
    }
}
