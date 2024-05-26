﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaInventarioyReparaciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.AccesoDatos.Repositorio.IRepositorio
{
    public interface IKardexInventarioRepositorio : IRepositorio<KardexInventario>
    {
        Task RegistrarKardex(int bodegaProductoId, string tipo, string detalle, int stockAnterior, int cantidad, string usuarioId);
    }
}
