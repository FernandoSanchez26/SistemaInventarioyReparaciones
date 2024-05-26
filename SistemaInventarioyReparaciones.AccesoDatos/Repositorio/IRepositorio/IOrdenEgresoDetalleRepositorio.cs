using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaInventarioyReparaciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.AccesoDatos.Repositorio.IRepositorio
{
    public interface IOrdenEgresoDetalleRepositorio : IRepositorio<OrdenEgresoDetalle>
    {
        void Actualizar(OrdenEgresoDetalle ordenEgresoDetalle);
    }
}
