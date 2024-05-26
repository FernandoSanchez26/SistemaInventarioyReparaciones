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
    public class OrdenEgresoDetalleConfiguracion : IEntityTypeConfiguration<OrdenEgresoDetalle>
    {
        public void Configure(EntityTypeBuilder<OrdenEgresoDetalle> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.OrdenEgresoId).IsRequired();
            builder.Property(x => x.ProductoId).IsRequired();
            builder.Property(x => x.Cantidad).IsRequired();
            


            /* Relaciones*/


            builder.HasOne(x => x.OrdenEgreso).WithMany()
                   .HasForeignKey(x => x.OrdenEgresoId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Producto).WithMany()
                  .HasForeignKey(x => x.ProductoId)
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
