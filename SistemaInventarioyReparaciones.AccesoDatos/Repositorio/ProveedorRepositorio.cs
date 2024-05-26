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
    public class ProveedorRepositorio : Repositorio<Proveedor>, IProveedorRepositorio
    {
        private readonly ApplicationDbContext _db;

        public ProveedorRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Proveedor proveedor)
        {
            var proveedorBD = _db.Proveedores.FirstOrDefault(b => b.Id == proveedor.Id);
            if (proveedorBD != null)
            {
                proveedorBD.Nombre = proveedor.Nombre;
                proveedorBD.EstadoProv = proveedor.EstadoProv;
                proveedorBD.FechaRegistro = proveedor.FechaRegistro;
                proveedorBD.Correo = proveedor.Correo; 

                _db.SaveChanges();
            }
        }
    }
}
