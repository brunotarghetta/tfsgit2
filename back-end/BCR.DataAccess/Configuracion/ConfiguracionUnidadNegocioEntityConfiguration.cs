using BCR.Business.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCR.DataAccess.Configuracion
{
    public class ConfiguracionUnidadNegocioEntityConfiguration : IEntityTypeConfiguration<ConfiguracionUnidadNegocio>
    {
        public void Configure(EntityTypeBuilder<ConfiguracionUnidadNegocio> builder)
        {
            builder.ToTable("t_mon_Configuracion");
            builder.HasKey(o => o.Id).HasName("ID_Configuracion");
            builder.Property(p => p.Nombre).HasColumnName("Nombre").IsRequired();
        }
    }
}
