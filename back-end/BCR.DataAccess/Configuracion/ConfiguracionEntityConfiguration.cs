using System;
using System.Collections.Generic;
using System.Text;
using BCR.Business.Domain.Configuracion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCR.DataAccess.Configuracion
{
    public class ConfiguracionEntityConfiguration : IEntityTypeConfiguration<ConfiguracionUnidadNegocio>
    {
        public void Configure(EntityTypeBuilder<ConfiguracionUnidadNegocio> builder)
        {
            builder.ToTable("t_mon_Configuracion");
            builder.HasKey(o => o.Id).HasName("ID_Configuracion");
            builder.Property(p => p.Nombre).HasColumnName("Nombre").IsRequired();


        }
    }
}
