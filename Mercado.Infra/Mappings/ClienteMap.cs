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
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(x => x.IdCliente);

            builder.Property(x => x.IdCliente).IsRequired().UseIdentityColumn().HasColumnType("int");
            builder.Property(x => x.IdMercado).IsRequired().HasColumnType("int");
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Senha).IsRequired().HasColumnType("varchar(30)");

            builder.HasOne<Mercados>(x => x.Mercado).WithMany(x => x.Clientes).HasForeignKey(x => x.IdMercado);

        }
    }
}
