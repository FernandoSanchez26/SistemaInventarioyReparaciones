using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioyReparaciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioyReparaciones.AccesoDatos.Configuracion
{
    public class ModeloPConfiguracion : IEntityTypeConfiguration<ModeloP>
    {
        public void Configure(EntityTypeBuilder<ModeloP> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);            
            builder.Property(x => x.EstadoMP).IsRequired();
            builder.Property(x => x.FechaRegistro).IsRequired();

            
        }
    }
}
