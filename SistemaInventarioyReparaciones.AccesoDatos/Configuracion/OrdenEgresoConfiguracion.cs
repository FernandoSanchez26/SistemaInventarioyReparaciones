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
    public class OrdenEgresoConfiguracion : IEntityTypeConfiguration<OrdenEgreso>
    {
        public void Configure(EntityTypeBuilder<OrdenEgreso> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.UsuarioAppId).IsRequired();
            builder.Property(x => x.FechaOrden).IsRequired();
            builder.Property(x => x.NumeroOficio).IsRequired();
            builder.Property(x => x.NombreRecibe).IsRequired();
            builder.Property(x => x.Oficina).IsRequired();
            builder.Property(x => x.Observaciones).IsRequired();           

            /* Relaciones*/

            builder.HasOne(x => x.UsuarioApp).WithMany()
                   .HasForeignKey(x => x.UsuarioAppId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
