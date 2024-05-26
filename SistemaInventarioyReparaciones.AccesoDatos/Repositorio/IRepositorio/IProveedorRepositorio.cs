using SistemaInventarioyReparaciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.AccesoDatos.Repositorio.IRepositorio
{
    public interface IProveedorRepositorio : IRepositorio<Proveedor>
    {
        void Actualizar(Proveedor proveedor);

    }
}
