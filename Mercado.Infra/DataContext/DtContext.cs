using Mercado.Domain.Entities;
using Mercado.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Infra.DataContext
{
    public class DtContext : DbContext
    {
        public DbSet<Mercados> Mercados { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        public DtContext(DbContextOptions<DtContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MercadoMap());
            builder.ApplyConfiguration(new ClienteMap());
        }

    }
}
