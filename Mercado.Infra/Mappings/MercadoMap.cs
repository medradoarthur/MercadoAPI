using Mercado.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Infra.Mappings
{
    public class MercadoMap : IEntityTypeConfiguration<Mercados>
    {
        public void Configure(EntityTypeBuilder<Mercados> builder)
        {
            builder.ToTable("Mercado");

            builder.HasKey(x => x.IdMercado);

            builder.Property(x => x.IdMercado).IsRequired().UseIdentityColumn().HasColumnType("int");
            builder.Property(x => x.CNPJ).IsRequired().HasColumnType("varchar(30)");
            builder.Property(x => x.NomeMercado).IsRequired().HasColumnType("varchar(200)");            
        }
    }
}
