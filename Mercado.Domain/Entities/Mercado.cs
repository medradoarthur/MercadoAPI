using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Domain.Entities
{
    public class Mercados
    {
        public int IdMercado { get; set; }
        public string CNPJ { get; set; }        
        public string NomeMercado { get; set; }

        public ICollection<Cliente> Clientes { get; set; }

        public Mercados()
        {

        }
    }
}
