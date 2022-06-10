using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {

        }
        public int IdCliente { get; set; }

        public int IdMercado { get; set; }
        public Mercados Mercado { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

    }
}

