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
    public class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Activo_Serie).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Condicion).IsRequired();
            builder.Property(x => x.Ubicacion).IsRequired();
            builder.Property(x => x.EstadoP).IsRequired();
            builder.Property(x => x.CategoriaId).IsRequired();
            builder.Property(x => x.SubCategoriaId).IsRequired();
            builder.Property(x => x.MarcaId).IsRequired();
            builder.Property(x => x.ModeloPId).IsRequired();

            /*Relaciones*/
            builder.HasOne(x => x.Categoria).WithMany()
                   .HasForeignKey(x => x.CategoriaId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SubCategoria).WithMany()
                   .HasForeignKey(x => x.SubCategoriaId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Marca).WithMany()
                   .HasForeignKey(x => x.MarcaId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ModeloP).WithMany()
                   .HasForeignKey(x => x.ModeloPId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
